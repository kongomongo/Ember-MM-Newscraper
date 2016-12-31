' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports EmberAPI
Imports NLog
Imports System.Text.RegularExpressions
Imports System.Web

Public Class clsFernsehserienDE

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _addonsettings As Addon.AddonSettings

#End Region 'Fields

#Region "Constructors"

    Public Sub New(ByVal tSettings As Addon.AddonSettings)
        _addonsettings = tSettings
    End Sub

#End Region 'Constructors

#Region "Methods"

    Private Function BuildBroadcastURL(ByVal strTitle As String) As String
        Return String.Format("http://www.fernsehserien.de/{0}/sendetermine/-", HttpUtility.UrlEncode(Regex.Replace(strTitle, " ", "-")))
    End Function

    Public Shared Function GetAllStations() As List(Of String)
        Dim nResult As New List(Of String)
        Dim strHTML As String = String.Empty
        Dim nHTTP As New HTTP
        strHTML = nHTTP.DownloadData("http://www.fernsehserien.de/serien-nach-sendern")
        nHTTP.Dispose()
        nHTTP = Nothing

        If Not String.IsNullOrEmpty(strHTML) Then
            Try
                Dim rStations = Regex.Matches(strHTML, "<span class=""sendername"" title=""(?<STATION>.*?)""", RegexOptions.Singleline Or RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1))
                If rStations.Count > 0 Then
                    For Each nStation As Match In rStations
                        nResult.Add(HttpUtility.HtmlDecode(nStation.Groups("STATION").Value))
                    Next
                    nResult.Sort()
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End If

        Return nResult
    End Function

    Public Sub GetInfo_TVEpisode(ByRef tDBElement As Database.DBElement)
        If Not tDBElement.MainDetails.EpisodeSpecified OrElse Not tDBElement.MainDetails.SeasonSpecified Then
            Try
                Dim strURLBroadcasts As String = BuildBroadcastURL(tDBElement.TVShowDetails.Title)
                Dim iPage As Integer = 0
                Dim iMaxPages As Integer = 10

                Dim rRegexFilename = Regex.Match(tDBElement.Filename, _addonsettings.RegexFilename, RegexOptions.IgnoreCase)

                If rRegexFilename.Success Then
                    Dim strStation As String = rRegexFilename.Groups("STATION").Value
                    Dim dDateTime As Date = Convert.ToDateTime(String.Format("{0}-{1}-{2} {3}:{4}",
                                                                             rRegexFilename.Groups("YEAR").Value,
                                                                             rRegexFilename.Groups("MONTH").Value,
                                                                             rRegexFilename.Groups("DAY").Value,
                                                                             rRegexFilename.Groups("HOUR").Value,
                                                                             rRegexFilename.Groups("MINUTE").Value
                                                                             ))

                    While Not iPage > iMaxPages
                        Dim strCurrentPage As String = String.Concat(strURLBroadcasts, iPage)

                        Dim strHTML As String = String.Empty
                        Dim nHTTP As New HTTP
                        strHTML = nHTTP.DownloadData(strCurrentPage)
                        nHTTP.Dispose()
                        nHTTP = Nothing

                        'search tv show
                        If String.IsNullOrEmpty(strHTML) Then
                            Dim nSearchResult = Search_TVShow(tDBElement.TVShowDetails.Title)
                            If nSearchResult.Success Then
                                strURLBroadcasts = BuildBroadcastURL(nSearchResult.Title)
                                strHTML = nSearchResult.HTML
                            End If
                        End If

                        Dim rTable = Regex.Match(strHTML, "<table class=""sendetermine.*?"">(?<LIST>.*)(?:<\/table>){1}", RegexOptions.Singleline Or RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1))
                        If rTable.Success Then
                            Dim rBroadcasts = Regex.Matches(rTable.Groups("LIST").Value, "<tbody.*?<\/tbody>", RegexOptions.Singleline Or RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1))
                            If rBroadcasts.Count > 0 Then
                                Dim iYear As Integer = -1
                                For Each nBroadcast As Match In rBroadcasts
                                    'check for Year on iPage = 0
                                    If iPage = 0 Then
                                        Dim rYear = Regex.Match(nBroadcast.ToString, "id=""jahr-(\d{4})""")
                                        If rYear.Success Then
                                            iYear = CInt(rYear.Groups(1).Value)
                                        End If
                                    End If

                                    'skip Special episodes (no season or episode number available)
                                    If Not nBroadcast.ToString.ToLower.Contains("<b title=""specials") Then
                                        Try
                                            Dim rBroadcast = Regex.Match(nBroadcast.ToString, "<td class=""sendetermine-datum"".*?>(?<DATE>.*?)<.*?<span.*?>(?<TIME>.*?)<.*?<td class=""sendetermine-sender"".*?>(?<STATION>.*?)<.*?"">(?<SEASON>\d+)\.<.*?"">(?<EPISODE>\d+)<", RegexOptions.Singleline Or RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1))
                                            If rBroadcast.Success AndAlso rBroadcast.Groups("STATION").Value.ToLower = strStation.ToLower Then
                                                Dim lstTimes = rBroadcast.Groups("TIME").Value.Split(Convert.ToChar("–")).ToList
                                                If lstTimes.Count = 2 Then
                                                    Dim dTimeStart As New Date
                                                    If iPage = 0 Then
                                                        dTimeStart = Convert.ToDateTime(String.Format("{0}{1} {2}", rBroadcast.Groups("DATE").Value, iYear, lstTimes.Item(0)))
                                                    Else
                                                        dTimeStart = Convert.ToDateTime(String.Format("{0} {1}", rBroadcast.Groups("DATE").Value, lstTimes.Item(0)))
                                                    End If

                                                    If dTimeStart < dDateTime.AddMinutes(_addonsettings.TimeOffset) AndAlso
                                                        dTimeStart > dDateTime.AddMinutes(-_addonsettings.TimeOffset) Then
                                                        tDBElement.MainDetails.Episode = CInt(rBroadcast.Groups("EPISODE").Value)
                                                        tDBElement.MainDetails.Season = CInt(rBroadcast.Groups("SEASON").Value)
                                                        Exit While
                                                    End If
                                                End If
                                            End If
                                        Catch ex As Exception
                                            logger.Error(ex, New StackFrame().GetMethod().Name)
                                        End Try
                                    End If
                                Next
                            End If
                        End If
                        iPage += 1
                    End While
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End If
    End Sub

    Private Function ConvertStationName(ByVal strStation As String) As String
        Return String.Empty
    End Function

    Private Function Search_TVShow(ByVal strTVShowTitle As String) As SearchResult
        Dim nSearchResult As New SearchResult



        Return nSearchResult
    End Function

#End Region 'Methods

#Region "Nested Types"

    Private Structure SearchResult
        Dim HTML As String
        Dim Title As String
        Dim Success As Boolean
    End Structure

#End Region 'Nested Types

End Class