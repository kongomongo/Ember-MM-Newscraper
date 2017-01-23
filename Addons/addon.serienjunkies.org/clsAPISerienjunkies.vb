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

Public Class clsAPISerienjunkies

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private Const strNotFound As String = "<title>Page not found</title>"
    Private Const Regex_DownloadLink As String = "<a href=""(?<URL>.*?)"".*?\| (?<HOSTER>.*?)<"
    Private Const Regex_Episode As String = "<p><strong>(?<RELEASE>.*?)<(?<LINKS>.*)"
    Private Const Regex_InSeasonGroups As String = "<p><strong>.*?<\/p>"                        'Description or Episode/Seasonpack
    Private Const Regex_NextPage As String = "<a href=""(?<NEXTPAGE>.*?)"" class=""next"""
    Private Const Regex_PagesArea As String = "wp-paginate.*?class=""next"""
    Private Const Regex_Season As String = "(?<DESCRIPTION>staffel|season) (?<SEASON>\d+)"
    Private Const Regex_SeasonGroups As String = "<h2>(?!bookmark|staffeln|feeds).*?<\/div>"    'Seasons grouped in German or English

#End Region 'Fields

#Region "Methods"

    Private Shared Function GetCleanReleaseInfo(ByVal strRAWInfo As String) As String
        strRAWInfo = Regex.Replace(strRAWInfo, "<strong>.{0,3}cover:.*?\| ", String.Empty, RegexOptions.IgnoreCase)
        strRAWInfo = strRAWInfo.Replace("<p>", String.Empty)
        strRAWInfo = strRAWInfo.Replace("</p>", String.Empty)
        strRAWInfo = strRAWInfo.Replace("<strong>", String.Empty)
        strRAWInfo = strRAWInfo.Replace("</strong>", String.Empty)

        Return strRAWInfo.Trim
    End Function

    Private Shared Function GetEpisodeNumberFromDescription(ByVal strDescription As String) As Integer
        Dim mEpisode As Match = Regex.Match(strDescription, "E(\d+)")
        If mEpisode.Success Then
            Dim intEpisode As Integer = -1
            If Integer.TryParse(mEpisode.Groups(1).Value, intEpisode) Then
                Return intEpisode
            End If
        End If
        Return -1
    End Function

    Private Shared Function GetLanguageFromString(ByVal strString As String) As Language
        strString = strString.ToLower
        Select Case True
            Case strString.Contains("weitere sprachen"),
                 (strString.Contains("deutsch") OrElse strString.Contains("german")) AndAlso
                (strString.Contains("englisch") OrElse strString.Contains("english")) AndAlso
                (strString.Contains("französisch") OrElse strString.Contains("italienisch") OrElse strString.Contains("spanisch"))
                Return Language.MultiLanguage
            Case (strString.Contains("deutsch") OrElse strString.Contains("german")) AndAlso
                (strString.Contains("englisch") OrElse strString.Contains("english"))
                Return Language.DualLanguage
            Case strString.Contains("deutsch"), strString.Contains("german"), strString.Contains("staffel")
                Return Language.German
            Case strString.Contains("englisch"), strString.Contains("english"), strString.Contains("season")
                Return Language.English
            Case Else
                Return Language.None
        End Select
    End Function

    Private Shared Function GetSeasonNumberFromDescription(ByVal strDescription As String) As Integer
        Dim mSeason As Match = Regex.Match(strDescription, "S(\d+)")
        If mSeason.Success Then
            Dim intSeason As Integer = -1
            If Integer.TryParse(mSeason.Groups(1).Value, intSeason) Then
                Return intSeason
            End If
        End If
        Return -1
    End Function

    Public Shared Function ParseMainPage(ByVal tWatchedItem As Addon.AddonSettings.WatchItem) As TVShowContainer
        Dim nTVShowContainer As New TVShowContainer With {
            .ID = tWatchedItem.ID,
            .Title = tWatchedItem.Title
        }

        Dim strCurrPageURL As String = tWatchedItem.URL
        While Not String.IsNullOrEmpty(strCurrPageURL)
            Dim HTML As String
            Dim intHTTP As New HTTP
            HTML = intHTTP.DownloadData(strCurrPageURL)
            intHTTP.Dispose()
            intHTTP = Nothing

            If Not String.IsNullOrEmpty(HTML) AndAlso Not HTML.Contains(strNotFound) Then
                Dim mcSeasons As MatchCollection = Regex.Matches(HTML, Regex_SeasonGroups, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
                If mcSeasons.Count > 0 Then
                    For Each nMatch As Match In mcSeasons
                        nTVShowContainer.EpisodeList.AddRange(ParseInSeasonGroups(nMatch.Value.Trim))
                    Next
                End If
            Else
                logger.Error(String.Concat("Page not found: ", strCurrPageURL))
            End If

            strCurrPageURL = String.Empty
            Dim mPagesArea = Regex.Match(HTML, Regex_PagesArea, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
            If mPagesArea.Success Then
                Dim mNextPage = Regex.Match(mPagesArea.Value, Regex_NextPage, RegexOptions.IgnoreCase Or RegexOptions.RightToLeft, TimeSpan.FromSeconds(2))
                If mNextPage.Success Then
                    strCurrPageURL = mNextPage.Groups("NEXTPAGE").Value
                End If
            End If
        End While

        Return nTVShowContainer
    End Function

    Private Shared Function ParseInSeasonGroups(ByVal mSeason As String) As List(Of Episode)
        Dim nEpisodes As New List(Of Episode)

        Dim mcInSeasonGroups As MatchCollection = Regex.Matches(mSeason, Regex_InSeasonGroups, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
        If mcInSeasonGroups.Count > 0 Then
            Dim eLanguage As Language = Language.None
            Dim strCodec As String = String.Empty
            Dim strDuration As String = String.Empty
            Dim strRelease As String = String.Empty
            Dim strSize As String = String.Empty
            Dim strUploader As String = String.Empty

            For Each nPart As Match In mcInSeasonGroups
                If nPart.Value.ToLower.Contains("format:") OrElse
                    nPart.Value.ToLower.Contains("dauer:") OrElse
                    nPart.Value.ToLower.Contains("sprache:") OrElse
                    nPart.Value.ToLower.Contains("uploader:") Then
                    eLanguage = GetLanguageFromString(Regex.Match(nPart.Value.Trim, "Sprache:<\/strong> (.*?) \|", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Groups(1).Value.Trim)
                    strCodec = Regex.Match(nPart.Value.Trim, "Format:<\/strong> (.*?) \|", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Groups(1).Value.Trim
                    strDuration = Regex.Match(nPart.Value.Trim, "Dauer:<\/strong> (\d*\:\d*)", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Groups(1).Value.Trim
                    strRelease = GetCleanReleaseInfo(HttpUtility.HtmlDecode(nPart.Value.Trim))
                    strSize = Regex.Match(nPart.Value.Trim, "Größe:<\/strong> (.*?) \|", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Groups(1).Value.Trim
                    strUploader = Regex.Match(nPart.Value.Trim, "Uploader:<\/strong> (.*?)<", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Groups(1).Value.Trim
                Else
                    Dim mEpisode As Match = Regex.Match(nPart.Value.Trim, Regex_Episode, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
                    nEpisodes.Add(New Episode With {
                                  .Codec = HttpUtility.HtmlDecode(strCodec),
                                  .Description = HttpUtility.HtmlDecode(mEpisode.Groups("RELEASE").Value.Trim),
                                  .Duration = HttpUtility.HtmlDecode(strDuration),
                                  .EpisodeNumber = GetEpisodeNumberFromDescription(mEpisode.Groups("RELEASE").Value.Trim),
                                  .Language = eLanguage,
                                  .MirrorList = ParseDownloadLinks(mEpisode.Groups("LINKS").Value.Trim),
                                  .Release = strRelease,
                                  .SeasonNumber = GetSeasonNumberFromDescription(mEpisode.Groups("RELEASE").Value.Trim),
                                  .Size = HttpUtility.HtmlDecode(strSize),
                                  .Uploader = HttpUtility.HtmlDecode(strUploader)
                                  })
                End If
            Next
        End If

        Return nEpisodes
    End Function

    Private Shared Function ParseDownloadLinks(ByVal strLinks As String) As List(Of Mirror)
        Dim nDownloadLinks As New List(Of Mirror)

        Dim mcLinks As MatchCollection = Regex.Matches(strLinks, Regex_DownloadLink, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
        If mcLinks.Count > 0 Then
            For Each mLink As Match In mcLinks
                nDownloadLinks.Add(New Mirror With {
                                   .Hoster = HttpUtility.HtmlDecode(mLink.Groups("HOSTER").Value.Trim),
                                   .URL = HttpUtility.HtmlDecode(mLink.Groups("URL").Value.Trim)
                                   })
            Next
        End If

        Return nDownloadLinks
    End Function

    Public Shared Function SearchTVShow(ByVal strTitle As String) As String
        If String.IsNullOrEmpty(strTitle) Then Return String.Empty

        Dim strURL As String = String.Concat(My.Resources.urlDefaultOverview, HttpUtility.UrlEncode(strTitle).Replace("+", "-").ToLower, "/")

        Dim HTML As String
        Dim intHTTP As New HTTP
        HTML = intHTTP.DownloadData(strURL)
        intHTTP.Dispose()
        intHTTP = Nothing

        If Not String.IsNullOrEmpty(HTML) AndAlso Not HTML.Contains(strNotFound) Then
            Return strURL
        Else
            MessageBox.Show("TV Show not found. Please add the URL manually.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            logger.Error(String.Concat("Page not found: ", strURL))
            Return String.Empty
        End If
    End Function


#End Region 'Methods

#Region "Nested Types"

    Public Class TVShowContainer
        Public EpisodeList As New List(Of Episode)
        Public ID As Long = -1
        Public Title As String = String.Empty
    End Class

    Public Class Episode
        Public Codec As String = String.Empty
        Public Description As String = String.Empty
        Public Duration As String = String.Empty
        Public EpisodeNumber As Integer = -1
        Public Language As Language = Language.None
        Public MirrorList As New List(Of Mirror)
        Public Release As String = String.Empty
        Public SeasonNumber As Integer = -1
        Public Size As String = String.Empty
        Public Uploader As String = String.Empty
        Public ReadOnly Property IsSeasonPack As Boolean
            Get
                Return EpisodeNumber = -1 AndAlso Not SeasonNumber = -1
            End Get
        End Property
    End Class

    Public Class Mirror
        Public Hoster As String = String.Empty
        Public URL As String = String.Empty
    End Class

    Public Enum Language
        None
        DualLanguage
        English
        German
        MultiLanguage
    End Enum

#End Region 'Nested Types

End Class