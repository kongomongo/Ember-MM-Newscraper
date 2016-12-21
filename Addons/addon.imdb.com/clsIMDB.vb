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

Public Class Scraper

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _AddonSettings As Addon.AddonSettings

    Private Const LINK_PATTERN As String = "<a[\s]+[^>]*?href[\s]?=[\s\""\']*(?<url>.*?)[\""\']*.*?>(?<name>[^<]+|.*?)?<\/a>"
    Private Const ACTORTABLE_PATTERN As String = "<table class=""cast"">(.*?)</table>"
    Private Const HREF_PATTERN As String = "<a.*?href=[""'](?<url>.*?)[""'].*?>(?<name>.*?)</a>"
    Private Const HREF_PATTERN_2 As String = "<a\shref=[""""'](?<url>.*?)[""""'].*?>(?<name>.*?)</a>"
    Private Const HREF_PATTERN_3 As String = "<a href=""/search/title\?certificates=[^""]*"">([^<]*):([^<]*)</a>[^<]*(<i>([^<]*)</i>)?"
    Private Const HREF_PATTERN_4 As String = "<a.*?href=[""']/(title/tt\d{7}/|name/nm\d{7}/)[""'].*?>(?<text>.*?)</a>"
    Private Const IMDB_ID_REGEX As String = "tt\d\d\d\d\d\d\d"
    Private Const IMG_PATTERN As String = "<img src=""(?<thumb>.*?)"" width=""\d{1,3}"" height=""\d{1,3}"" border="".{1,3}"">"
    Private Const MOVIE_TITLE_PATTERN As String = "(?<=<(title)>).*(?=<\/\1>)"
    Private Const TABLE_PATTERN As String = "<table.*?>\n?(.*?)</table>"
    Private Const TABLE_PATTERN_TV As String = "<table class=""results"">(.*?)</table>"
    Private Const TD_PATTERN_1 As String = "<td\sclass=""nm"">(.*?)</td>"
    Private Const TD_PATTERN_2 As String = "(?<=<td\sclass=""char"">)(?<name>.*?)(?=</td>)(\s\(.*?\))?"
    Private Const TD_PATTERN_3 As String = "<td\sclass=""hs"">(.*?)</td>"
    Private Const TD_PATTERN_4 As String = "<td>(?<title>.*?)</td>"
    Private Const TITLE_PATTERN As String = "<a\shref=[""""'](?<url>.*?)[""""'].*?>(?<name>.*?)</a>((\s)+?(\((?<year>\d{4})(\/.*?)?\)))?((\s)+?(\((?<type>.*?)\)))?"
    Private Const TR_PATTERN As String = "<tr\sclass="".*?"">(.*?)</tr>"
    Private Const TvTITLE_PATTERN As String = "<a\shref=[""'](?<url>.*?)[""']\stitle=[""'](?<name>.*?)((\s)+?(\((?<year>\d{4})))"
    Private Const TVSHOWTITLE_PATTERN As String = "<tr class.*?>.*?<a href=""\/title\/(?<IMDB>tt\d*)\/"">(?<TITLE>.*?)<\/a>.*?year_type"">\((?<YEAR>\d*).*?<\/tr>"
    Private Const TVEPISODE_PATTERN As String = "<div class=""list_item (?:odd|even)"">.*?<a href=""\/title\/(?<IMDB>tt\d*)\/.*?title=""(?<TITLE>.*?)"" itemprop=""url"">.*?content=""(?<EPISODE>\d*)"""
    Private Const TVEPISODE_TITLE_PATTERN As String = "<title>&#x22;.*?&#x22;(?<TITLE>.*?)<\/title>"
    Private Const TVEPISODE_SEASON_EPISODE As String = "<h5>Original Air Date:<\/h5>.*?\(Season (?<SEASON>\d+), Episode (?<EPISODE>\d+)\).*?<\/div>"
    Private Const TVEPISODE_CREDITS As String = "<a.*?href=[""'](?<URL>.*?)[""'].*?>(?<NAME>.*?).?<\/a>.*?<td class=""credit"">.*?\((?<CLASS>.*?)\).*?<\/td>"

#End Region 'Fields

#Region "Methods"

    Public Sub New(ByVal tAddonSettings As Addon.AddonSettings)
        _AddonSettings = tAddonSettings
    End Sub

    Public Function GetInfo_Movie(ByVal strIMDB As String, ByVal FilteredOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
        Try
            Dim nMovie As New MediaContainers.MainDetails

            Dim HTML As String
            Dim intHTTP As New HTTP
            HTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strIMDB, "/combined"))
            intHTTP.Dispose()
            intHTTP = Nothing

            Dim PlotHtml As String
            intHTTP = New HTTP
            PlotHtml = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strIMDB, "/plotsummary"))
            intHTTP.Dispose()
            intHTTP = Nothing

            nMovie.IMDB = strIMDB
            nMovie.Scrapersource = "IMDB"

            Dim scrapedresult As String = String.Empty

            Dim OriginalTitle As String = Regex.Match(HTML, MOVIE_TITLE_PATTERN).ToString


            'Original Title
            If FilteredOptions.bMainOriginalTitle Then
                nMovie.OriginalTitle = CleanTitle(HttpUtility.HtmlDecode(Regex.Match(OriginalTitle, ".*(?=\s\(\d+.*?\))").ToString)).Trim
            End If

            'Title
            If FilteredOptions.bMainTitle Then
                If Not String.IsNullOrEmpty(_AddonSettings.ForceTitleLanguage) Then
                    nMovie.Title = GetForcedTitle(strIMDB, nMovie.OriginalTitle)
                Else
                    nMovie.Title = CleanTitle(HttpUtility.HtmlDecode(Regex.Match(OriginalTitle, ".*(?=\s\(\d+.*?\))").ToString)).Trim
                End If
            End If

            'Year
            If FilteredOptions.bMainYear Then
                nMovie.Year = Regex.Match(OriginalTitle, "(?<=\()\d+(?=.*\))", RegexOptions.RightToLeft).ToString
            End If

            'Certifications
            If FilteredOptions.bMainCertifications Then
                Dim D, W As Integer
                D = HTML.IndexOf("<h5>Certification:</h5>")
                If D > 0 Then
                    W = HTML.IndexOf("</div>", D)
                    Dim rCert As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN_3)

                    If rCert.Count > 0 Then
                        Dim Certs = From M In rCert Select N = String.Format("{0}:{1}", DirectCast(M, Match).Groups(1).ToString.Trim, DirectCast(M, Match).Groups(2).ToString.Trim) Order By N Ascending
                        For Each tCert In Certs
                            nMovie.Certifications.Add(tCert.ToString.Replace("West", String.Empty).Trim)
                        Next
                    End If
                End If
            End If

            'MPAA
            If FilteredOptions.bMainMPAA Then
                Dim D, W, tempD As Integer
                tempD = If(HTML.IndexOf("<h5><a href=""/mpaa"">MPAA</a>:</h5>") > 0, HTML.IndexOf("<h5><a href=""/mpaa"">MPAA</a>:</h5>"), 0)
                D = If(tempD > 0, HTML.IndexOf("<div class=""info-content"">", tempD), 0)
                W = If(D > 0, HTML.IndexOf("</div", D), 0)
                nMovie.MPAA = If(D > 0 AndAlso W > 0, HttpUtility.HtmlDecode(HTML.Substring(D, W - D).Remove(0, 26)).Trim(), String.Empty)
            End If

            'Release Date
            If FilteredOptions.bMainRelease Then
                Dim RelDate As Date
                Dim sRelDate As MatchCollection = Regex.Matches(HTML, "<h5>Release Date:</h5>.*?(?<DATE>\d+\s\w+\s\d\d\d\d\s)", RegexOptions.Singleline)
                If sRelDate.Count > 0 Then
                    If Date.TryParse(sRelDate.Item(0).Groups(1).Value, RelDate) Then
                        nMovie.ReleaseDate = RelDate.ToString("yyyy-MM-dd")
                    End If
                End If
            End If

            'Rating
            If FilteredOptions.bMainRating Then
                Dim RegexRating As String = Regex.Match(HTML, "\b\d\W\d/\d\d").ToString
                If Not String.IsNullOrEmpty(RegexRating) Then
                    nMovie.Rating = RegexRating.Split(Convert.ToChar("/")).First.Trim
                    nMovie.Votes = Regex.Match(HTML, "class=""tn15more"">([0-9,]+) votes</a>").Groups(1).Value.Trim
                End If
            End If

            'Trailer
            If FilteredOptions.bMainTrailer Then 'todo: proper trailer result
                'Get first IMDB trailer if possible
                Dim TrailerList As List(Of MediaContainers.Trailer) = IMDb.Scraper.GetMovieTrailersByIMDBID(nMovie.IMDB)
                If TrailerList.Count > 0 Then
                    Dim sIMDb As New IMDb.Scraper
                    sIMDb.GetVideoLinks(TrailerList.Item(0).URLWebsite)
                    If sIMDb.VideoLinks.Count > 0 Then
                        nMovie.Trailer = sIMDb.VideoLinks.FirstOrDefault().Value.URL.ToString
                    End If
                End If
                Dim alTrailers = IMDb.Scraper.GetMovieTrailersByIMDBID(nMovie.IMDB)
                For Each tTrailer In alTrailers
                    tTrailer.Scraper = "IMDB"
                Next
            End If

            'Top250
            'ie: <a href="/chart/top?tt0167260">Top 250: #13</a>
            If FilteredOptions.bMainTop250 Then
                Dim strTop250 As String = Regex.Match(HTML, String.Concat("/chart/top\?", nMovie.IMDB, """>Top 250: #([0-9]+)</a>")).Groups(1).Value.Trim
                Dim iTop250 As Integer = 0
                If Integer.TryParse(strTop250, iTop250) Then
                    nMovie.Top250 = iTop250
                End If
            End If

            'Actors
            If FilteredOptions.bMainActors Then
                'Find all cast of the movie
                'Match the table only 1 time
                Dim ActorsTable As String = Regex.Match(HTML, ACTORTABLE_PATTERN).ToString
                Dim ThumbsSize = "SY275_SX400" 'AdvancedSettings.GetSetting("ActorThumbsSize", "SY275_SX400")

                Dim rCast As MatchCollection = Regex.Matches(ActorsTable, TR_PATTERN)

                For Each tCast In rCast
                    Dim tActor As New MediaContainers.Person
                    Dim t1 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_1).ToString, HREF_PATTERN)
                    Dim t2 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_2).ToString, HREF_PATTERN)
                    If Not t2.Success Then
                        t2 = Regex.Match(tCast.ToString, TD_PATTERN_2)
                    End If
                    Dim t3 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_3).ToString, IMG_PATTERN)
                    tActor.Name = HttpUtility.HtmlDecode(t1.Groups("name").ToString.Trim)
                    tActor.Role = HttpUtility.HtmlDecode(t2.Groups("name").ToString.Trim)
                    tActor.URLOriginal = If(t3.Groups("thumb").ToString.IndexOf("addtiny") > 0 OrElse t3.Groups("thumb").ToString.IndexOf("no_photo") > 0, String.Empty, HttpUtility.HtmlDecode(t3.Groups("thumb").ToString.Trim).Replace("._SX23_SY30_.jpg", String.Concat("._", ThumbsSize, "_.jpg")))
                    nMovie.Actors.Add(tActor)
                Next
            End If

            'Tagline
            If FilteredOptions.bMainTagline Then
                Dim D, W, tempD As Integer
                tempD = If(HTML.IndexOf("<h5>Tagline:</h5>") > 0, HTML.IndexOf("<h5>Tagline:</h5>"), 0)
                D = If(tempD > 0, HTML.IndexOf("<div class=""info-content"">", tempD), 0)
                Dim lHtmlIndexOf As Integer = If(D > 0, HTML.IndexOf("<a class=""tn15more inline""", D), 0)
                Dim TagLineEnd As Integer = If(lHtmlIndexOf > 0, lHtmlIndexOf, 0)
                If D > 0 Then W = If(TagLineEnd > 0, TagLineEnd, HTML.IndexOf("</div>", D))
                nMovie.Tagline = If(D > 0 AndAlso W > 0, HttpUtility.HtmlDecode(HTML.Substring(D, W - D).Replace("<h5>Tagline:</h5>", String.Empty).Split(Environment.NewLine.ToCharArray)(1)).Trim, String.Empty)
            End If

            'Director
            If FilteredOptions.bMainDirectors Then
                Dim D, W As Integer
                'Get the directors
                D = If(HTML.IndexOf("<h5>Director:</h5>") > 0, HTML.IndexOf("<h5>Director:</h5>"), HTML.IndexOf("<h5>Directors:</h5>"))
                W = If(D > 0, HTML.IndexOf("</div>", D), 0)
                'got any director(s) ?
                If D > 0 AndAlso Not W <= 0 Then
                    'get only the first director's name
                    Dim rDir As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                    Dim Dir = From M In rDir Where Not DirectCast(M, Match).Groups("name").ToString.Contains("more")
                              Select HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString)
                    'only update nMovie if scraped result is not empty/nothing!
                    If Dir.Count > 0 Then
                        ' nMovie.Director = Strings.Join(Dir.ToArray, " / ").Trim
                        nMovie.Directors.AddRange(Dir.ToList)
                    End If
                End If
            End If

            'Countries
            If FilteredOptions.bMainCountries Then
                Dim D, W As Integer
                D = If(HTML.IndexOf("<h5>Country:</h5>") > 0, HTML.IndexOf("<h5>Country:</h5>"), HTML.IndexOf("<h5>Countries:</h5>"))
                W = If(D > 0, HTML.IndexOf("</div>", D), 0)
                'got any country ?
                If D > 0 AndAlso Not W <= 0 Then
                    'get only the first country's name
                    Dim rCou As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                    Dim Cou = From M In rCou Where Not DirectCast(M, Match).Groups("name").ToString.Contains("more")
                              Select HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString)

                    'only update nMovie if scraped result is not empty/nothing!
                    If Cou.Count > 0 Then
                        'If _AddonSettings.CountryAbbreviation = False Then
                        '    For Each entry In Cou
                        '        entry = entry.Replace("USA", "United States of America")
                        '        entry = entry.Replace("UK", "United Kingdom")
                        '        nMovie.Countries.Add(entry)
                        '    Next
                        'Else
                        nMovie.Countries.AddRange(Cou.ToList)
                        'End If
                    End If
                End If
            End If

            'Genres
            If FilteredOptions.bMainGenres Then
                Dim D, W As Integer
                D = HTML.IndexOf("<h5>Genre:</h5>")
                'Check if doesnt find genres
                If D > 0 Then
                    W = HTML.IndexOf("</div>", D)

                    If W > 0 Then
                        Dim rGenres As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                        Dim Gen = From M In rGenres
                                  Select N = HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString) Where Not N.Contains("more") Take 999999
                        If Gen.Count > 0 Then
                            nMovie.Genres.AddRange(Gen.ToList)
                        End If
                    End If
                End If
            End If

            'Outline
            If FilteredOptions.bMainOutline Then
                Dim D, W, tempD As Integer
                Try
                    If nMovie.Title.Contains("(VG)") Then
                        D = If(HTML.IndexOf("<h5>Plot Summary:</h5>") > 0, HTML.IndexOf("<h5>Plot Summary:</h5>"), HTML.IndexOf("<h5>Tagline:</h5>"))
                        If D > 0 Then W = HTML.IndexOf("</div>", D)
                    Else
                        tempD = If(HTML.IndexOf("<h5>Plot:</h5>") > 0, HTML.IndexOf("<h5>Plot:</h5>"), HTML.IndexOf("<h5>Plot Summary:</h5>"))
                        D = If(tempD > 0, HTML.IndexOf("<div class=""info-content"">", tempD), 0)
                        If D <= 0 Then D = HTML.IndexOf("<h5>Plot Synopsis:</h5>")
                        If D > 0 Then
                            W = HTML.IndexOf("<a class=", D)
                            If W > 0 Then
                                W = HTML.IndexOf("</div>", D)
                            Else
                                '   IMnMovie.Outline = String.Empty
                                GoTo mPlot
                            End If
                        Else
                            'IMnMovie.Outline = String.Empty
                            GoTo mPlot 'This plot synopsis is empty
                        End If
                    End If

                    Dim PlotOutline As String = HTML.Substring(D, W - D).Remove(0, 26)

                    PlotOutline = HttpUtility.HtmlDecode(If(PlotOutline.Contains("is empty") OrElse PlotOutline.Contains("View full synopsis") _
                                           , String.Empty, PlotOutline.Replace("|", String.Empty).Replace("&raquo;", String.Empty)).Trim)
                    'only update nMovie if scraped result is not empty/nothing!
                    If Not String.IsNullOrEmpty(PlotOutline) Then
                        'check if outline has links to other IMDB entry
                        For Each rMatch As Match In Regex.Matches(PlotOutline, HREF_PATTERN_4)
                            PlotOutline = PlotOutline.Replace(rMatch.Value, rMatch.Groups("text").Value.Trim)
                        Next
                        nMovie.Outline = Regex.Replace(PlotOutline, HREF_PATTERN, String.Empty).Trim
                    End If

                Catch ex As Exception
                End Try
            End If

mPlot:          'Plot
            If FilteredOptions.bMainPlot Then
                Dim FullPlotS As String = Regex.Match(PlotHtml, "<p class=""plotSummary"">(.*?)</p>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
                Dim FullPlotO As String = Regex.Match(PlotHtml, "<li class=""odd"">\s*<p>(.*?)<br/>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
                Dim FullPlotE As String = Regex.Match(PlotHtml, "<li class=""even"">\s*<p>(.*?)<br/>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
                Dim FullPlot As String = If(Not String.IsNullOrEmpty(FullPlotS), FullPlotS, If(Not String.IsNullOrEmpty(FullPlotO), FullPlotO, FullPlotE))
                FullPlot = Regex.Replace(FullPlot, "<a(.*?)>", "")
                FullPlot = Regex.Replace(FullPlot, "</a>", "")
                'only update nMovie if scraped result is not empty/nothing!
                If Not String.IsNullOrEmpty(FullPlot) Then
                    nMovie.Plot = FullPlot
                End If
            End If

            'Duration
            If FilteredOptions.bMainRuntime Then
                scrapedresult = HttpUtility.HtmlDecode(Regex.Match(HTML, "<h5>Runtime:</h5>[^0-9]*([^<]*)").Groups(1).Value.Trim)
                'only update nMovie if scraped result is not empty/nothing!
                If Not String.IsNullOrEmpty(scrapedresult) Then
                    'examples:
                    ' <h5>Runtime:</h5><div class="info-content">93 min </div> OR
                    ' <h5>Runtime:</h5><div class="info-content">"94 min  | USA:102 min (unrated version)</div>
                    ' <h5>Runtime:</h5><div class="info-content">Thailand: 89 min  | USA:93 min </div>
                    '  scrapedresult = Web.HttpUtility.HtmlDecode(Regex.Match(HTML, "<h5>Runtime:</h5>[^0-9]*([^<]*)").Groups(1).Value.Trim)
                    Dim Match As Match = Regex.Match(HTML, "Runtime:(\s*<((?<!>).)+)+(?<length>\d+|((?!</div|<h).)+)", RegexOptions.IgnoreCase)
                    If Match.Success Then
                        If Regex.IsMatch(Match.Groups("length").Value, "^\d+$") Then
                            scrapedresult = Match.Groups("length").Value
                        ElseIf Regex.IsMatch(Match.Groups("length").Value, "\d+") Then
                            scrapedresult = Regex.Match(Match.Groups("length").Value, "\d+").Value
                        End If
                        nMovie.Runtime = scrapedresult
                    End If
                End If
            End If

            'Studios
            If FilteredOptions.bMainStudios Then
                Dim D, W As Integer
                D = HTML.IndexOf("<b class=""blackcatheader"">Production Companies</b>")
                If D > 0 Then W = HTML.IndexOf("</ul>", D)
                If D > 0 AndAlso W > 0 Then
                    'only get the first one
                    Dim Ps = From P1 In Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                             Where Not DirectCast(P1, Match).Groups("name").ToString = String.Empty
                             Select Studio = HttpUtility.HtmlDecode(DirectCast(P1, Match).Groups("name").ToString)
                    '  nMovie.Studio = Ps(0).ToString.Trim
                    'only update nMovie if scraped result is not empty/nothing!
                    If Ps.Count > 0 Then
                        nMovie.Studios.AddRange(Ps.ToList)
                    End If
                End If
                If _AddonSettings.StudioWithDistributors Then
                    D = HTML.IndexOf("<b class=""blackcatheader"">Distributors</b>")
                    If D > 0 Then W = HTML.IndexOf("</ul>", D)
                    If D > 0 AndAlso W > 0 Then
                        Dim distributor_pattern As String = "<a.*?href=[""'](?<url>.*?)[""'].*?>(?<name>.*?)</a>(?<releaseinfo>.*?)</li>"
                        'example of DISTRIBUTOR_PATTERN input string: 
                        '<li><a href="/company/co0015030/">Alfa Films</a> (2015) (Argentina) (theatrical)</li>
                        '<li><a href="/company/co0481930/">Bravos Pictures</a> (2015) (Hong Kong) (theatrical)</li><li>
                        Dim Ps = From P1 In Regex.Matches(HTML.Substring(D, W - D), distributor_pattern)
                                 Where Not DirectCast(P1, Match).Groups("name").ToString = String.Empty AndAlso DirectCast(P1, Match).Groups("releaseinfo").ToString.Contains(_AddonSettings.ForceTitleLanguage)
                                 Select Studio = HttpUtility.HtmlDecode(DirectCast(P1, Match).Groups("name").ToString)
                        '  nMovie.Studio = Ps(0).ToString.Trim
                        'only update nMovie if scraped result is not empty/nothing!
                        If Ps.Count > 0 Then
                            For Each item In Ps.ToList
                                If nMovie.Studios.Contains(item) = False Then
                                    nMovie.Studios.Add(item)
                                End If
                            Next
                        End If
                    End If
                End If
            End If

            'Writers
            If FilteredOptions.bMainWriters Then
                Dim D, W As Integer
                D = HTML.IndexOf("<h5>Writer")
                If D > 0 Then W = HTML.IndexOf("</div>", D)
                If D > 0 AndAlso W > 0 Then
                    Dim q = From M In Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                            Where Not DirectCast(M, Match).Groups("name").ToString.Trim = "more" _
                                AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim = "(more)" _
                                AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim = "WGA" _
                                AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim.Contains("see more")
                            Select Writer = HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString)

                    'only update nMovie if scraped result is not empty/nothing!
                    If q.Count > 0 Then
                        nMovie.Credits.AddRange(q.ToList) 'Strings.Join(q.ToArray, " / ").Trim
                    End If
                End If
            End If

            Return nMovie
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
            Return Nothing
        End Try
    End Function

    Public Function GetInfo_TVEpisode(ByVal strIMDBID As String, ByRef FilteredOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
        If String.IsNullOrEmpty(strIMDBID) OrElse strIMDBID.Length < 2 Then Return Nothing

        Dim nTVEpisode As New MediaContainers.MainDetails

        nTVEpisode.Scrapersource = "IMDB"

        Dim HTML As String
        Dim intHTTP As New HTTP
        HTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strIMDBID, "/combined"))
        intHTTP.Dispose()
        intHTTP = Nothing

        'IDs
        nTVEpisode.IMDB = strIMDBID

        'get season and episode number
        Dim rSeasonEpisode As Match = Regex.Match(HTML, TVEPISODE_SEASON_EPISODE, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        If Not rSeasonEpisode.Success Then Return Nothing

        'Episode # Standard
        nTVEpisode.Episode = CInt(rSeasonEpisode.Groups("EPISODE").Value)

        'Season # Standard
        nTVEpisode.Season = CInt(rSeasonEpisode.Groups("SEASON").Value)

        'Actors
        If FilteredOptions.bEpisodeActors Then
            'Find all cast of the episode
            'Match the table only 1 time
            Dim ActorsTable As String = Regex.Match(HTML, ACTORTABLE_PATTERN).ToString
            Dim ThumbsSize = "SY275_SX400" 'AdvancedSettings.GetSetting("ActorThumbsSize", "SY275_SX400")

            Dim rCast As MatchCollection = Regex.Matches(ActorsTable, TR_PATTERN)

            For Each tCast In rCast
                Dim tActor As New MediaContainers.Person
                Dim t1 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_1).ToString, HREF_PATTERN)
                Dim t2 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_2).ToString, HREF_PATTERN)
                If Not t2.Success Then
                    t2 = Regex.Match(tCast.ToString, TD_PATTERN_2)
                End If
                Dim t3 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_3).ToString, IMG_PATTERN)
                tActor.Name = HttpUtility.HtmlDecode(t1.Groups("name").ToString.Trim)
                tActor.Role = HttpUtility.HtmlDecode(t2.Groups("name").ToString.Trim)
                tActor.URLOriginal = If(t3.Groups("thumb").ToString.IndexOf("addtiny") > 0 OrElse t3.Groups("thumb").ToString.IndexOf("no_photo") > 0, String.Empty, HttpUtility.HtmlDecode(t3.Groups("thumb").ToString.Trim).Replace("._SX23_SY30_.jpg", String.Concat("._", ThumbsSize, "_.jpg")))
                nTVEpisode.Actors.Add(tActor)
            Next
        End If

        'Aired
        If FilteredOptions.bEpisodeAired Then
            Dim RelDate As Date
            Dim sRelDate As MatchCollection = Regex.Matches(HTML, "<h5>Original Air Date:</h5>.*?(?<DATE>\d+\s\w+\s\d\d\d\d\s)", RegexOptions.Singleline)
            If sRelDate.Count > 0 Then
                If Date.TryParse(sRelDate.Item(0).Groups(1).Value, RelDate) Then
                    nTVEpisode.Aired = RelDate.ToString("yyyy-MM-dd")
                End If
            End If
        End If

        'Credits (writers)
        If FilteredOptions.bEpisodeCredits Then
            Dim strFullCreditsHTML As String
            intHTTP = New HTTP
            strFullCreditsHTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strIMDBID, "/fullcredits"))
            intHTTP.Dispose()
            intHTTP = Nothing

            Dim D, W As Integer
            D = strFullCreditsHTML.IndexOf(">Writing Credits")
            If D > 0 Then W = strFullCreditsHTML.IndexOf("</table>", D)
            If D > 0 AndAlso W > 0 Then
                Dim q = From M In Regex.Matches(strFullCreditsHTML.Substring(D, W - D), TVEPISODE_CREDITS, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                        Where DirectCast(M, Match).Groups("CLASS").Value.Trim.ToLower = "written by"
                        Select Writer = HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("NAME").Value.Trim)
                If q.Count > 0 Then
                    nTVEpisode.Credits.AddRange(q.ToList)
                End If
            End If
        End If

        'Directors
        If FilteredOptions.bEpisodeDirectors Then
            Dim D, W As Integer
            'Get the directors
            D = If(HTML.IndexOf("<h5>Director:</h5>") > 0, HTML.IndexOf("<h5>Director:</h5>"), HTML.IndexOf("<h5>Directors:</h5>"))
            W = If(D > 0, HTML.IndexOf("</div>", D), 0)
            'got any director(s) ?
            If D > 0 AndAlso Not W <= 0 Then
                'get only the first director's name
                Dim rDir As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                Dim Dir = From M In rDir Where Not DirectCast(M, Match).Groups("name").ToString.Contains("more")
                          Select HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString)
                If Dir.Count > 0 Then
                    ' nMovie.Director = Strings.Join(Dir.ToArray, " / ").Trim
                    nTVEpisode.Directors.AddRange(Dir.ToList)
                End If
            End If
        End If

        ''Guest Stars
        'If FilteredOptions.bEpisodeGuestStars Then
        '    If EpisodeInfo.GuestStars IsNot Nothing Then
        '        For Each aCast As TMDbLib.Objects.TvShows.Cast In EpisodeInfo.GuestStars
        '            nTVEpisode.GuestStars.Add(New MediaContainers.Person With {.Name = aCast.Name,
        '                                                               .Role = aCast.Character,
        '                                                               .URLOriginal = If(Not String.IsNullOrEmpty(aCast.ProfilePath), String.Concat(_TMDBApi.Config.Images.BaseUrl, "original", aCast.ProfilePath), String.Empty),
        '                                                               .TMDB = CStr(aCast.Id)})
        '        Next
        '    End If
        'End If

        'Plot
        If FilteredOptions.bEpisodePlot Then
            Dim PlotHtml As String
            intHTTP = New HTTP
            PlotHtml = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strIMDBID, "/plotsummary"))
            intHTTP.Dispose()
            intHTTP = Nothing

            Dim FullPlotS As String = Regex.Match(PlotHtml, "<p class=""plotSummary"">(.*?)</p>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
            Dim FullPlotO As String = Regex.Match(PlotHtml, "<li class=""odd"">\s*<p>(.*?)<br/>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
            Dim FullPlotE As String = Regex.Match(PlotHtml, "<li class=""even"">\s*<p>(.*?)<br/>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
            Dim FullPlot As String = If(Not String.IsNullOrEmpty(FullPlotS), FullPlotS, If(Not String.IsNullOrEmpty(FullPlotO), FullPlotO, FullPlotE))
            FullPlot = Regex.Replace(FullPlot, "<a(.*?)>", "")
            FullPlot = Regex.Replace(FullPlot, "</a>", "")

            If Not String.IsNullOrEmpty(FullPlot) Then
                nTVEpisode.Plot = FullPlot
            End If
        End If

        'Rating
        If FilteredOptions.bEpisodeRating Then
            Dim RegexRating As String = Regex.Match(HTML, "\b\d\W\d/\d\d").ToString
            If String.IsNullOrEmpty(RegexRating) = False Then
                nTVEpisode.Rating = RegexRating.Split(Convert.ToChar("/")).First.Trim
                nTVEpisode.Votes = Regex.Match(HTML, "class=""tn15more"">([0-9,]+) votes</a>").Groups(1).Value.Trim
            End If
        End If

        ''ThumbPoster
        'If EpisodeInfo.StillPath IsNot Nothing Then
        '    nTVEpisode.ThumbPoster.URLOriginal = _TMDBApi.Config.Images.BaseUrl & "original" & EpisodeInfo.StillPath
        '    nTVEpisode.ThumbPoster.URLThumb = _TMDBApi.Config.Images.BaseUrl & "w185" & EpisodeInfo.StillPath
        'End If

        'Title
        If FilteredOptions.bEpisodeTitle Then
            Dim rTitle As Match = Regex.Match(HTML, TVEPISODE_TITLE_PATTERN)
            If rTitle.Success Then
                nTVEpisode.Title = CleanTitle_TVEpisode(HttpUtility.HtmlDecode(rTitle.Groups("TITLE").Value))
            End If
        End If

        Return nTVEpisode
    End Function

    Public Function GetInfo_TVEpisode(ByVal strTVShowIMDBID As String, ByVal iSeasonNumber As Integer, ByVal iEpisodeNumber As Integer, ByRef FilteredOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
        If String.IsNullOrEmpty(strTVShowIMDBID) OrElse iSeasonNumber = -1 OrElse iEpisodeNumber = -1 Then Return Nothing

        Dim strTVEpisodeIMDBID As String = String.Empty

        Dim HTML As String
        Dim intHTTP As New HTTP
        HTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strTVShowIMDBID, "/episodes?season=", iSeasonNumber))
        intHTTP.Dispose()
        intHTTP = Nothing

        Dim D, W As Integer
        D = HTML.IndexOf("<div class=""list detail eplist"">")
        'Check if doesnt find genres
        If D > 0 Then
            W = HTML.IndexOf("<hr>", D)

            If W > 0 Then
                Dim rEpisodes As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), TVEPISODE_PATTERN, RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                If rEpisodes.Count > 0 Then
                    For Each tEpisode As Match In rEpisodes
                        If CInt(tEpisode.Groups("EPISODE").Value) = iEpisodeNumber Then
                            Dim nEpisode As MediaContainers.MainDetails = GetInfo_TVEpisode(tEpisode.Groups("IMDB").Value, FilteredOptions)
                            If nEpisode IsNot Nothing Then
                                Return nEpisode
                            End If
                        End If
                    Next
                End If
            End If
        End If

        Return Nothing
    End Function

    Public Sub GetInfo_TVSeason(ByRef nTVShow As MediaContainers.MainDetails, ByVal strTVShowIMDBID As String, ByVal iSeasonNumber As Integer, ByRef ScrapeModifiers As Structures.ScrapeModifiers, ByRef FilteredOptions As Structures.ScrapeOptions)

        If ScrapeModifiers.withEpisodes Then
            Dim HTML As String
            Dim intHTTP As New HTTP
            HTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strTVShowIMDBID, "/episodes?season=", iSeasonNumber))
            intHTTP.Dispose()
            intHTTP = Nothing

            Dim D, W As Integer
            D = HTML.IndexOf("<div class=""list detail eplist"">")
            'Check if doesnt find genres
            If D > 0 Then
                W = HTML.IndexOf("<hr>", D)

                If W > 0 Then
                    Dim rEpisodes As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), TVEPISODE_PATTERN, RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                    If rEpisodes.Count > 0 Then
                        For Each tEpisode As Match In rEpisodes
                            Dim nEpisode As MediaContainers.MainDetails = GetInfo_TVEpisode(tEpisode.Groups("IMDB").Value, FilteredOptions)
                            If nEpisode IsNot Nothing Then
                                nTVShow.KnownEpisodes.Add(nEpisode)
                            End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub
    ''' <summary>
    '''  Scrape TV Show details from IMDB
    ''' </summary>
    ''' <param name="strID">IMDB ID of tv show to be scraped</param>
    ''' <param name="GetPoster">Scrape posters for the tv show?</param>
    ''' <param name="Options">Module settings<param>
    ''' <returns>True: success, false: no success</returns>
    Public Function GetInfo_TVShow(ByVal strID As String, ByVal ScrapeModifiers As Structures.ScrapeModifiers, ByVal FilteredOptions As Structures.ScrapeOptions, ByVal GetPoster As Boolean) As MediaContainers.MainDetails
        If String.IsNullOrEmpty(strID) OrElse strID.Length < 2 Then Return Nothing

        Try
            Dim nTVShow As New MediaContainers.MainDetails

            nTVShow.IMDB = strID
            nTVShow.Scrapersource = "IMDB"

            Dim HTML As String
            Dim intHTTP As New HTTP
            HTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strID, "/combined"))
            intHTTP.Dispose()
            intHTTP = Nothing

            'Actors
            If FilteredOptions.bMainActors Then
                'Find all cast of the tv show
                'Match the table only 1 time
                Dim ActorsTable As String = Regex.Match(HTML, ACTORTABLE_PATTERN).ToString
                Dim ThumbsSize = "SY275_SX400" 'AdvancedSettings.GetSetting("ActorThumbsSize", "SY275_SX400")

                Dim rCast As MatchCollection = Regex.Matches(ActorsTable, TR_PATTERN)

                For Each tCast In rCast
                    Dim tActor As New MediaContainers.Person
                    Dim t1 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_1).ToString, HREF_PATTERN)
                    Dim t2 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_2).ToString, HREF_PATTERN)
                    If Not t2.Success Then
                        t2 = Regex.Match(tCast.ToString, TD_PATTERN_2)
                    End If
                    Dim t3 = Regex.Match(Regex.Match(tCast.ToString, TD_PATTERN_3).ToString, IMG_PATTERN)
                    tActor.Name = HttpUtility.HtmlDecode(t1.Groups("name").ToString.Trim)
                    tActor.Role = HttpUtility.HtmlDecode(t2.Groups("name").ToString.Trim)
                    tActor.URLOriginal = If(t3.Groups("thumb").ToString.IndexOf("addtiny") > 0 OrElse t3.Groups("thumb").ToString.IndexOf("no_photo") > 0, String.Empty, HttpUtility.HtmlDecode(t3.Groups("thumb").ToString.Trim).Replace("._SX23_SY30_.jpg", String.Concat("._", ThumbsSize, "_.jpg")))
                    nTVShow.Actors.Add(tActor)
                Next
            End If

            'Certifications
            If FilteredOptions.bMainCertifications Then
                Dim D, W As Integer
                D = HTML.IndexOf("<h5>Certification:</h5>")
                If D > 0 Then
                    W = HTML.IndexOf("</div>", D)
                    Dim rCert As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN_3)

                    If rCert.Count > 0 Then
                        Dim Certs = From M In rCert Select N = String.Format("{0}:{1}", DirectCast(M, Match).Groups(1).ToString.Trim, DirectCast(M, Match).Groups(2).ToString.Trim) Order By N Ascending
                        For Each tCert In Certs
                            nTVShow.Certifications.Add(tCert.ToString.Replace("West", String.Empty).Trim)
                        Next
                    End If
                End If
            End If

            'Countries
            If FilteredOptions.bMainCountries Then
                Dim D, W As Integer
                D = If(HTML.IndexOf("<h5>Country:</h5>") > 0, HTML.IndexOf("<h5>Country:</h5>"), HTML.IndexOf("<h5>Countries:</h5>"))
                W = If(D > 0, HTML.IndexOf("</div>", D), 0)
                'got any country ?
                If D > 0 AndAlso Not W <= 0 Then
                    'get only the first country's name
                    Dim rCou As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                    Dim Cou = From M In rCou Where Not DirectCast(M, Match).Groups("name").ToString.Contains("more")
                              Select HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString)

                    If Cou.Count > 0 Then
                        nTVShow.Countries.AddRange(Cou.ToList)
                    End If
                End If
            End If

            'Creators
            If FilteredOptions.bMainCreators Then
                Dim D, W As Integer
                D = HTML.IndexOf("<h5>Creators")
                If D > 0 Then W = HTML.IndexOf("</div>", D)
                If D > 0 AndAlso W > 0 Then
                    Dim q = From M In Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                            Where Not DirectCast(M, Match).Groups("name").ToString.Trim = "more" _
                                AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim = "(more)" _
                                AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim = "WGA" _
                                AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim.Contains("see more")
                            Select Writer = HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString)

                    If q.Count > 0 Then
                        nTVShow.Creators.AddRange(q.ToList)
                    End If
                Else
                    D = HTML.IndexOf("<h5>Writer")
                    If D > 0 Then W = HTML.IndexOf("</div>", D)
                    If D > 0 AndAlso W > 0 Then
                        Dim q = From M In Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                                Where Not DirectCast(M, Match).Groups("name").ToString.Trim = "more" _
                                    AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim = "(more)" _
                                    AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim = "WGA" _
                                    AndAlso Not DirectCast(M, Match).Groups("name").ToString.Trim.Contains("see more")
                                Select Writer = HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString)

                        If q.Count > 0 Then
                            nTVShow.Creators.AddRange(q.ToList)
                        End If
                    End If
                End If
            End If

            'Genres
            If FilteredOptions.bMainGenres Then
                Dim D, W As Integer
                D = HTML.IndexOf("<h5>Genre:</h5>")
                'Check if doesnt find genres
                If D > 0 Then
                    W = HTML.IndexOf("</div>", D)

                    If W > 0 Then
                        Dim rGenres As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                        Dim Gen = From M In rGenres
                                  Select N = HttpUtility.HtmlDecode(DirectCast(M, Match).Groups("name").ToString) Where Not N.Contains("more") Take 999999
                        If Gen.Count > 0 Then
                            nTVShow.Genres.AddRange(Gen.ToList)
                        End If
                    End If
                End If
            End If

            'Plot
            If FilteredOptions.bMainPlot Then
                Dim PlotHtml As String
                intHTTP = New HTTP
                PlotHtml = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strID, "/plotsummary"))
                intHTTP.Dispose()
                intHTTP = Nothing

                Dim FullPlotS As String = Regex.Match(PlotHtml, "<p class=""plotSummary"">(.*?)</p>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
                Dim FullPlotO As String = Regex.Match(PlotHtml, "<li class=""odd"">\s*<p>(.*?)<br/>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
                Dim FullPlotE As String = Regex.Match(PlotHtml, "<li class=""even"">\s*<p>(.*?)<br/>", RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline).Groups(1).Value.ToString.Trim
                Dim FullPlot As String = If(Not String.IsNullOrEmpty(FullPlotS), FullPlotS, If(Not String.IsNullOrEmpty(FullPlotO), FullPlotO, FullPlotE))
                FullPlot = Regex.Replace(FullPlot, "<a(.*?)>", "")
                FullPlot = Regex.Replace(FullPlot, "</a>", "")

                If Not String.IsNullOrEmpty(FullPlot) Then
                    nTVShow.Plot = FullPlot
                End If
            End If

            'Premiered
            If FilteredOptions.bMainPremiered Then
                Dim RelDate As Date
                Dim sRelDate As MatchCollection = Regex.Matches(HTML, "<h5>Release Date:</h5>.*?(?<DATE>\d+\s\w+\s\d\d\d\d\s)", RegexOptions.Singleline)
                If sRelDate.Count > 0 Then
                    If Date.TryParse(sRelDate.Item(0).Groups(1).Value, RelDate) Then
                        'always save date in same date format not depending on users language setting!
                        nTVShow.Premiered = RelDate.ToString("yyyy-MM-dd")
                    End If
                End If
            End If

            'Rating
            If FilteredOptions.bMainRating Then
                Dim RegexRating As String = Regex.Match(HTML, "\b\d\W\d/\d\d").ToString
                If String.IsNullOrEmpty(RegexRating) = False Then
                    nTVShow.Rating = RegexRating.Split(Convert.ToChar("/")).First.Trim
                    nTVShow.Votes = Regex.Match(HTML, "class=""tn15more"">([0-9,]+) votes</a>").Groups(1).Value.Trim
                End If
            End If

            'Runtime
            If FilteredOptions.bMainRuntime Then
                Dim strRuntime As String = HttpUtility.HtmlDecode(Regex.Match(HTML, "<h5>Runtime:</h5>[^0-9]*([^<]*)").Groups(1).Value.Trim)
                If Not String.IsNullOrEmpty(strRuntime) Then
                    'examples:
                    ' <h5>Runtime:</h5><div class="info-content">93 min </div> OR
                    ' <h5>Runtime:</h5><div class="info-content">"94 min  | USA:102 min (unrated version)</div>
                    ' <h5>Runtime:</h5><div class="info-content">Thailand: 89 min  | USA:93 min </div>
                    '  scrapedresult = Web.HttpUtility.HtmlDecode(Regex.Match(HTML, "<h5>Runtime:</h5>[^0-9]*([^<]*)").Groups(1).Value.Trim)
                    Dim Match As Match = Regex.Match(HTML, "Runtime:(\s*<((?<!>).)+)+(?<length>\d+|((?!</div|<h).)+)", RegexOptions.IgnoreCase)
                    If Match.Success Then
                        If Regex.IsMatch(Match.Groups("length").Value, "^\d+$") Then
                            strRuntime = Match.Groups("length").Value
                        ElseIf Regex.IsMatch(Match.Groups("length").Value, "\d+") Then
                            strRuntime = Regex.Match(Match.Groups("length").Value, "\d+").Value
                        End If
                        nTVShow.Runtime = strRuntime
                    End If
                End If
            End If

            'Studios
            If FilteredOptions.bMainStudios Then
                Dim D, W As Integer
                'If FullCrew Then
                '    D = HTML.IndexOf("<b class=""blackcatheader"">Production Companies</b>")
                '    If D > 0 Then W = HTML.IndexOf("</ul>", D)
                '    If D > 0 AndAlso W > 0 Then
                '        'only get the first one
                '        Dim Ps = From P1 In Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN) _
                '                 Where Not DirectCast(P1, Match).Groups("name").ToString = String.Empty _
                '                 Select Studio = Web.HttpUtility.HtmlDecode(DirectCast(P1, Match).Groups("name").ToString) Take 1
                '        '  nMovie.Studio = Ps(0).ToString.Trim
                '        'only update nMovie if scraped result is not empty/nothing!
                '        If Ps.Count > 0 Then
                '            nMovie.Studios.AddRange(Ps.ToList)
                '        End If
                '    End If
                'Else
                D = HTML.IndexOf("<h5>Company:</h5>")
                If D > 0 Then W = HTML.IndexOf("</div>", D)
                If D > 0 AndAlso W > 0 Then
                    nTVShow.Studios.Add(HttpUtility.HtmlDecode(Regex.Match(HTML.Substring(D, W - D), HREF_PATTERN).Groups("name").ToString.Trim))
                End If
                'End If
            End If

            'Title / OriginalTitle
            If FilteredOptions.bMainTitle OrElse FilteredOptions.bMainOriginalTitle Then
                Dim strOriginalTitle As String = Regex.Match(HTML, MOVIE_TITLE_PATTERN).ToString
                strOriginalTitle = CleanTitle(HttpUtility.HtmlDecode(Regex.Match(strOriginalTitle, ".*(?=\s\(\d+.*?\))").ToString)).Trim

                If Not String.IsNullOrEmpty(_AddonSettings.ForceTitleLanguage) Then
                    nTVShow.Title = GetForcedTitle(strID, strOriginalTitle)
                Else
                    nTVShow.Title = CleanTitle(HttpUtility.HtmlDecode(Regex.Match(strOriginalTitle, ".*(?=\s\(\d+.*?\))").ToString)).Trim
                End If

                If FilteredOptions.bMainOriginalTitle Then
                    nTVShow.OriginalTitle = strOriginalTitle
                End If
            End If

            'Seasons and Episodes
            If ScrapeModifiers.withEpisodes OrElse ScrapeModifiers.withSeasons Then
                Dim D, W As Integer
                D = HTML.IndexOf("<h5>Seasons:</h5>")
                'Check if doesnt find genres
                If D > 0 Then
                    W = HTML.IndexOf("</div>", D)

                    If W > 0 Then
                        Dim rSeasons As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), HREF_PATTERN)
                        If rSeasons.Count > 0 Then
                            For Each tSeason As Match In rSeasons
                                Dim iSeason As Integer = -1
                                If Integer.TryParse(tSeason.Groups("name").Value, iSeason) Then
                                    GetInfo_TVSeason(nTVShow, nTVShow.IMDB, iSeason, ScrapeModifiers, FilteredOptions)
                                    If ScrapeModifiers.withSeasons Then
                                        nTVShow.KnownSeasons.Add(New MediaContainers.MainDetails With {.Season = iSeason})
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If

            Return nTVShow
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
            Return Nothing
        End Try

        Return Nothing
    End Function

    Private Function CleanTitle(ByVal sString As String) As String
        Dim CleanString As String = sString

        If sString.StartsWith("""") Then CleanString = sString.Remove(0, 1)

        If sString.EndsWith("""") Then CleanString = CleanString.Remove(CleanString.Length - 1, 1)

        Return CleanString
    End Function

    Private Function CleanTitle_TVEpisode(ByVal sString As String) As String
        Dim CleanString As String = sString.Trim

        If sString.StartsWith("""") Then CleanString = sString.Remove(0, 1)
        If sString.EndsWith("""") Then CleanString = CleanString.Remove(CleanString.Length - 1, 1)
        CleanString = Regex.Replace(sString, "\(\d+\)", String.Empty)

        Return CleanString.Trim
    End Function

    Private Function CleanRole(ByVal strRole As String) As String
        Dim CleanString As String = strRole

        CleanString = Regex.Replace(CleanString, "\/ \.\.\..*", String.Empty).Trim
        CleanString = Regex.Replace(CleanString, "\(\d.*", String.Empty).Trim

        If Not String.IsNullOrEmpty(CleanString) Then
            Return CleanString
        Else
            Return strRole
        End If
    End Function

    Private Function GetForcedTitle(ByVal strID As String, ByVal oTitle As String) As String
        Dim fTitle As String = oTitle

        Dim HTML As String
        Dim intHTTP As New HTTP
        HTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/title/", strID, "/releaseinfo#akas"))
        intHTTP.Dispose()
        intHTTP = Nothing

        Dim D, W As Integer

        D = HTML.IndexOf("<h4 class=""li_group"">Also Known As (AKA)&nbsp;</h4>")

        If D > 0 Then
            W = HTML.IndexOf("</table>", D)
            Dim rTitles As MatchCollection = Regex.Matches(HTML.Substring(D, W - D), TD_PATTERN_4, RegexOptions.Multiline Or RegexOptions.IgnorePatternWhitespace)

            If rTitles.Count > 0 Then
                For i As Integer = 0 To rTitles.Count - 1 Step 2
                    If rTitles(i).Value.ToString.Contains(_AddonSettings.ForceTitleLanguage) AndAlso Not rTitles(i).Value.ToString.Contains(String.Concat(_AddonSettings.ForceTitleLanguage, " (working title)")) AndAlso Not rTitles(i).Value.ToString.Contains(String.Concat(_AddonSettings.ForceTitleLanguage, " (fake working title)")) Then
                        fTitle = CleanTitle(HttpUtility.HtmlDecode(rTitles(i + 1).Groups("title").Value.ToString.Trim))
                        Exit For
                        'if Setting WorldWide Title Fallback is enabled then instead of returning originaltitle (when force title language isn't found), use english/worldwide title instead (i.e. avoid asian original titles)
                    ElseIf _AddonSettings.FallBackWorldwide AndAlso (rTitles(i).Value.ToString.ToUpper.Contains("WORLD-WIDE") OrElse rTitles(i).Value.ToString.ToUpper.Contains("ENGLISH")) Then
                        fTitle = CleanTitle(HttpUtility.HtmlDecode(rTitles(i + 1).Groups("title").Value.ToString.Trim))
                    End If
                Next
            End If
        End If

        Return fTitle
    End Function

    Private Function GetMovieID(ByVal strObj As String) As String
        Return Regex.Match(strObj, IMDB_ID_REGEX).ToString
    End Function

    Private Function Search_Movie(ByVal sMovieTitle As String, ByVal sMovieYear As String) As List(Of MediaContainers.MainDetails)

        Dim sMovie As String = String.Concat(sMovieTitle, " ", If(Not String.IsNullOrEmpty(sMovieYear), String.Concat("(", sMovieYear, ")"), String.Empty))

        Dim D, W As Integer
        Dim nSearchResults As New List(Of MediaContainers.MainDetails)

        Dim HTML As String = String.Empty
        Dim HTMLt As String = String.Empty
        Dim HTMLp As String = String.Empty
        Dim HTMLm As String = String.Empty
        Dim HTMLe As String = String.Empty
        Dim HTMLv As String = String.Empty
        Dim HTMLs As String = String.Empty
        Dim rUri As String = String.Empty

        Dim intHTTP As New HTTP
        HTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/find?q=", HttpUtility.UrlEncode(sMovie), "&s=tt&ttype=ft"))
        HTMLe = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/find?q=", HttpUtility.UrlEncode(sMovie), "&s=tt&ttype=ft&exact=true&ref_=fn_tt_ex"))
        rUri = intHTTP.ResponseUri

        If _AddonSettings.SearchTvTitles Then
            HTMLt = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/search/title?title=", HttpUtility.UrlEncode(sMovie), "&title_type=tv_movie"))
        End If
        If _AddonSettings.SearchVideoTitles Then
            HTMLv = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/search/title?title=", HttpUtility.UrlEncode(sMovie), "&title_type=video"))
        End If
        If _AddonSettings.SearchShortTitles Then
            HTMLs = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/search/title?title=", HttpUtility.UrlEncode(sMovie), "&title_type=short"))
        End If
        If _AddonSettings.SearchPartialTitles Then
            HTMLm = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/find?q=", HttpUtility.UrlEncode(sMovie), "&s=tt&ttype=ft&ref_=fn_ft"))
        End If
        If _AddonSettings.SearchPopularTitles Then
            HTMLp = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/find?q=", HttpUtility.UrlEncode(sMovie), "&s=tt&ttype=ft&ref_=fn_tt_pop"))
        End If
        intHTTP.Dispose()
        intHTTP = Nothing

        'Check if we've been redirected straight to the movie page
        If Regex.IsMatch(rUri, IMDB_ID_REGEX) Then
            nSearchResults.Add(New MediaContainers.MainDetails With {
                                   .IMDB = Regex.Match(rUri, IMDB_ID_REGEX).ToString,
                                   .Lev = 0,
                                   .Title = StringUtils.ConvertToProperCase(sMovie),
                                   .Year = Regex.Match(Regex.Match(HTML, MOVIE_TITLE_PATTERN).ToString, "(?<=\()\d+(?=.*\))").ToString})
            Return nSearchResults
        End If

        'popular titles
        D = HTMLp.IndexOf("</a>Titles</h3>")
        If Not D <= 0 Then
            W = HTMLp.IndexOf("</table>", D) + 8

            Dim Table As String = Regex.Match(HTML.Substring(D, W - D), TABLE_PATTERN).ToString
            Dim qPopular = From Mtr In Regex.Matches(Table, TITLE_PATTERN)
                           Where Not DirectCast(Mtr, Match).Groups("name").ToString.Contains("<img") AndAlso Not DirectCast(Mtr, Match).Groups("type").ToString.Contains("VG")
                           Select New MediaContainers.MainDetails With {
                                   .IMDB = GetMovieID(DirectCast(Mtr, Match).Groups("url").ToString),
                                   .Lev = StringUtils.ComputeLevenshtein(StringUtils.FilterYear(sMovie).ToLower, StringUtils.FilterYear(HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString)).ToLower),
                                   .Title = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString),
                                   .Year = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("year").ToString)}
            nSearchResults = qPopular.ToList
        End If

        'partial titles
        D = HTMLm.IndexOf("</a>Titles</h3>")
        If Not D <= 0 Then
            W = HTMLm.IndexOf("</table>", D) + 8

            Dim Table As String = Regex.Match(HTMLm.Substring(D, W - D), TABLE_PATTERN).ToString
            Dim qpartial = From Mtr In Regex.Matches(Table, TITLE_PATTERN)
                           Where Not DirectCast(Mtr, Match).Groups("name").ToString.Contains("<img") AndAlso Not DirectCast(Mtr, Match).Groups("type").ToString.Contains("VG")
                           Select New MediaContainers.MainDetails With {
                                   .IMDB = GetMovieID(DirectCast(Mtr, Match).Groups("url").ToString),
                                   .Lev = StringUtils.ComputeLevenshtein(StringUtils.FilterYear(sMovie).ToLower, StringUtils.FilterYear(HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString)).ToLower),
                                   .Title = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString),
                                   .Year = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("year").ToString)}

            nSearchResults = qpartial.ToList
        End If

        'tv titles
        D = HTMLt.IndexOf("<table class=""results"">")
        If Not D <= 0 Then
            W = HTMLt.IndexOf("</table>", D) + 8

            Dim Table As String = HTMLt.Substring(D, W - D).ToString
            Dim qtvmovie = From Mtr In Regex.Matches(Table, TvTITLE_PATTERN)
                           Where Not DirectCast(Mtr, Match).Groups("name").ToString.Contains("<img") AndAlso Not DirectCast(Mtr, Match).Groups("type").ToString.Contains("VG")
                           Select New MediaContainers.MainDetails With {
                                   .IMDB = GetMovieID(DirectCast(Mtr, Match).Groups("url").ToString),
                                   .Lev = StringUtils.ComputeLevenshtein(StringUtils.FilterYear(sMovie).ToLower, StringUtils.FilterYear(HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString)).ToLower),
                                   .Title = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString),
                                   .Year = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("year").ToString)}

            nSearchResults = qtvmovie.ToList
        End If

        'video titles
        D = HTMLv.IndexOf("<table class=""results"">")
        If Not D <= 0 Then
            W = HTMLv.IndexOf("</table>", D) + 8

            Dim Table As String = HTMLv.Substring(D, W - D).ToString
            Dim qvideo = From Mtr In Regex.Matches(Table, TvTITLE_PATTERN)
                         Where Not DirectCast(Mtr, Match).Groups("name").ToString.Contains("<img") AndAlso Not DirectCast(Mtr, Match).Groups("type").ToString.Contains("VG")
                         Select New MediaContainers.MainDetails With {
                                 .IMDB = GetMovieID(DirectCast(Mtr, Match).Groups("url").ToString),
                                 .Lev = StringUtils.ComputeLevenshtein(StringUtils.FilterYear(sMovie).ToLower, StringUtils.FilterYear(HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString)).ToLower),
                                 .Title = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString),
                                 .Year = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("year").ToString)}

            nSearchResults = qvideo.ToList
        End If

        'short titles
        D = HTMLs.IndexOf("<table class=""results"">")
        If Not D <= 0 Then
            W = HTMLs.IndexOf("</table>", D) + 8

            Dim Table As String = HTMLs.Substring(D, W - D).ToString
            Dim qshort = From Mtr In Regex.Matches(Table, TvTITLE_PATTERN)
                         Where Not DirectCast(Mtr, Match).Groups("name").ToString.Contains("<img") AndAlso Not DirectCast(Mtr, Match).Groups("type").ToString.Contains("VG")
                         Select New MediaContainers.MainDetails With {
                                 .IMDB = GetMovieID(DirectCast(Mtr, Match).Groups("url").ToString),
                                 .Lev = StringUtils.ComputeLevenshtein(StringUtils.FilterYear(sMovie).ToLower, StringUtils.FilterYear(HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString)).ToLower),
                                 .Title = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString),
                                 .Year = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("year").ToString)}

            nSearchResults = qshort.ToList
        End If

        'exact titles
        D = HTMLe.IndexOf("</a>Titles</h3>")
        If Not D <= 0 Then
            W = HTMLe.IndexOf("</table>", D) + 8

            Dim Table As String = Regex.Match(HTMLe.Substring(D, W - D), TABLE_PATTERN).ToString
            Dim qExact = From Mtr In Regex.Matches(Table, TITLE_PATTERN)
                         Where Not DirectCast(Mtr, Match).Groups("name").ToString.Contains("<img") AndAlso Not DirectCast(Mtr, Match).Groups("type").ToString.Contains("VG")
                         Select New MediaContainers.MainDetails With {
                                 .IMDB = GetMovieID(DirectCast(Mtr, Match).Groups("url").ToString),
                                 .Lev = StringUtils.ComputeLevenshtein(StringUtils.FilterYear(sMovie).ToLower, StringUtils.FilterYear(HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString)).ToLower),
                                 .Title = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("name").ToString.ToString),
                                 .Year = HttpUtility.HtmlDecode(DirectCast(Mtr, Match).Groups("year").ToString)}

            nSearchResults = qExact.ToList
        End If

        Return nSearchResults
    End Function

    Private Function Search_TVShow(ByVal sShowTitle As String) As List(Of MediaContainers.MainDetails)
        Dim sShow As String = sShowTitle

        Dim nSearchResults As New List(Of MediaContainers.MainDetails)

        Dim HTML As String = String.Empty
        Dim rUri As String = String.Empty

        Dim intHTTP As New HTTP
        HTML = intHTTP.DownloadData(String.Concat("http://", Master.eSettings.MovieIMDBURL, "/search/title?title=", HttpUtility.UrlEncode(sShow), "&title_type=tv_series"))
        rUri = intHTTP.ResponseUri

        intHTTP.Dispose()
        intHTTP = Nothing

        'search results
        Dim Table As String = Regex.Match(HTML, TABLE_PATTERN_TV, RegexOptions.Singleline).ToString
        For Each sResult As Match In Regex.Matches(Table, TVSHOWTITLE_PATTERN, RegexOptions.Singleline)
            nSearchResults.Add(New MediaContainers.MainDetails With {.IMDB = sResult.Groups("IMDB").ToString, .Title = HttpUtility.HtmlDecode(sResult.Groups("TITLE").ToString)})
        Next

        Return nSearchResults
    End Function

#End Region 'Methods

End Class