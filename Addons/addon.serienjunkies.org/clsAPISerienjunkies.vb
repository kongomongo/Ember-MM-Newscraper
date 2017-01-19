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

Public Class clsAPISerienjunkies

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private Const strNotFound As String = "<title>Page not found</title>"
    Private Const Regex_SeasonGroup As String = "<h2>(?!bookmark|staffeln|feeds).*?<\/div>"
    Private Const Regex_Season As String = "(?<DESCRIPTION>staffel|season) (?<SEASON>\d+)"
    Private Const Regex_Format As String = "<p><strong>Dauer:<\/strong> (?<DURATION>\d*\:\d*).*?<strong>Größe:<\/strong> (?<SIZE>.*?) \| <strong>Sprache:<\/strong> (?<LANGUAGE>.*?) \| <strong>Format:<\/strong> (?<FORMAT>.*?) \| <strong>Uploader:<\/strong> (?<UPLOADER>.*?)<\/p>(?<EPISODES>.*)<\/p>"
    Private Const Regex_Episode As String = "<p><strong>(?<DESCRIPTION>.*?)<(?<LINKS>.*?<\/p>)"
    Private Const Regex_Link As String = "<a href=""(?<URL>.*?)"".*?\| (?<HOSTER>.*?)<"

#End Region 'Fields

#Region "Methods"

    Public Shared Function ParseMainPage(ByVal strURL As String) As TVShowContainer
        Dim nTVShowContainer As New TVShowContainer

        Dim HTML As String
        Dim intHTTP As New HTTP
        HTML = intHTTP.DownloadData(strURL)
        intHTTP.Dispose()
        intHTTP = Nothing

        If Not HTML.Contains(strNotFound) Then
            Dim mcSeasons As MatchCollection = Regex.Matches(HTML, Regex_SeasonGroup, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
            If mcSeasons.Count > 0 Then
                For Each nMatch As Match In mcSeasons
                    Dim regSeason As Match = Regex.Match(nMatch.Value, Regex_Season, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2))
                    If regSeason.Success Then
                        nTVShowContainer.Seasons.Add(New SeasonGroup With {
                                                     .FormatList = ParseFormats(nMatch),
                                                     .Language = If(regSeason.Groups("DESCRIPTION").Value.ToLower = "staffel", "German", "English"),
                                                     .SeasonNumber = CInt(regSeason.Groups("SEASON").Value),
                                                     .Description = String.Concat(regSeason.Groups("DESCRIPTION").Value, " ", regSeason.Groups("SEASON").Value)
                                                     })
                    End If
                Next
            End If
        Else
            logger.Error(String.Concat("Page not found: ", strURL))
        End If

        Return nTVShowContainer
    End Function

    Private Shared Function ParseFormats(ByVal mSeason As Match) As List(Of Format)
        Dim nFormats As New List(Of Format)

        Dim mcFormats As MatchCollection = Regex.Matches(mSeason.Value, Regex_Format, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
        If mcFormats.Count > 0 Then
            For Each nFormat As Match In mcFormats
                nFormats.Add(New Format With {
                             .Codec = nFormat.Groups("FORMAT").Value.Trim,
                             .Duration = nFormat.Groups("DURATION").Value.Trim,
                             .Language = nFormat.Groups("LANGUAGE").Value.Trim,
                             .Episodes = ParseEpisodes(nFormat.Groups("EPISODES").Value),
                             .Size = nFormat.Groups("SIZE").Value.Trim,
                             .Uploader = nFormat.Groups("UPLOADER").Value.Trim
                             })
            Next
        End If

        Return nFormats
    End Function

    Private Shared Function ParseEpisodes(ByVal strEpisodes As String) As List(Of Episode)
        Dim nEpisodes As New List(Of Episode)

        Dim mcEpisodes As MatchCollection = Regex.Matches(strEpisodes, Regex_Episode, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
        If mcEpisodes.Count > 0 Then
            For Each mEpisodeMatch As Match In mcEpisodes
                nEpisodes.Add(New Episode With {
                              .Description = mEpisodeMatch.Groups("DESCRIPTION").Value,
                              .EpisodeNumber = GetEpisodeNumberFromDescription(mEpisodeMatch.Groups("DESCRIPTION").Value),
                              .Links = ParseDownloadLinks(mEpisodeMatch.Groups("LINKS").Value),
                              .SeasonNumber = GetSeasonNumberFromDescription(mEpisodeMatch.Groups("DESCRIPTION").Value)
                              })
            Next
        End If

        Return nEpisodes
    End Function

    Private Shared Function ParseDownloadLinks(ByVal strLinks As String) As List(Of DownloadLink)
        Dim nDownloadLinks As New List(Of DownloadLink)

        Dim mcLinks As MatchCollection = Regex.Matches(strLinks, Regex_Link, RegexOptions.IgnoreCase Or RegexOptions.Singleline, TimeSpan.FromSeconds(2))
        If mcLinks.Count > 0 Then
            For Each mLink As Match In mcLinks
                nDownloadLinks.Add(New DownloadLink With {
                                   .Hoster = mLink.Groups("HOSTER").Value,
                                   .URL = mLink.Groups("URL").Value
                                   })
            Next
        End If

        Return nDownloadLinks
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


#End Region 'Methods

#Region "Nested Types"

    Public Class TVShowContainer
        Public Seasons As New List(Of SeasonGroup)
    End Class

    Public Class SeasonGroup
        Public Description As String = String.Empty
        Public FormatList As New List(Of Format)
        Public Language As String = String.Empty
        Public SeasonNumber As Integer = -1
    End Class

    Public Class Format
        Public Codec As String = String.Empty
        Public Duration As String = String.Empty
        Public Language As String = String.Empty
        Public Size As String = String.Empty
        Public Uploader As String = String.Empty
        Public Episodes As List(Of Episode)
    End Class

    Public Class Episode
        Public EpisodeNumber As Integer = -1
        Public SeasonNumber As Integer = -1
        Public Description As String = String.Empty
        Public Links As New List(Of DownloadLink)
    End Class

    Public Class DownloadLink
        Public Hoster As String = String.Empty
        Public URL As String = String.Empty
    End Class

#End Region 'Nested Types

End Class