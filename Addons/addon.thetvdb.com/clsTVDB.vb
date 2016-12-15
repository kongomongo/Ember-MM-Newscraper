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
Imports System.IO

Public Class Scraper

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _TVDBApi As TVDB.Web.WebInterface
    Private _TVDBMirror As TVDB.Model.Mirror
    Private _SpecialSettings As Addon.AddonSettings


#End Region 'Fields

#Region "Methods"

    Public Sub New(ByVal Settings As Addon.AddonSettings)
        Try
            _SpecialSettings = Settings

            If Not Directory.Exists(Path.Combine(Master.TempPath, "Shows")) Then Directory.CreateDirectory(Path.Combine(Master.TempPath, "Shows"))
            _TVDBApi = New TVDB.Web.WebInterface(_SpecialSettings.APIKey, Path.Combine(Master.TempPath, "Shows"))
            _TVDBMirror = New TVDB.Model.Mirror With {.Address = "http://thetvdb.com", .ContainsBannerFile = True, .ContainsXmlFile = True, .ContainsZipFile = False}

        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Function ConvertStringToListOfPerson(ByVal strActors As String) As List(Of MediaContainers.Person)
        Dim gActors As New List(Of MediaContainers.Person)
        Dim gRole As String = Master.eLang.GetString(947, "Guest Star")

        Dim GuestStarsList As New List(Of String)
        Dim charsToTrim() As Char = {"|"c, ","c}
        GuestStarsList.AddRange(strActors.Trim(charsToTrim).Split(charsToTrim))

        For Each aGuestStar As String In GuestStarsList
            gActors.Add(New MediaContainers.Person With {.Name = aGuestStar.Trim, .Role = gRole})
        Next

        Return gActors
    End Function
    ''' <summary>
    ''' Workaround to fix the theTVDB bug
    ''' </summary>
    ''' <param name="iTVDB"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Async Function GetFullSeriesById(ByVal iTVDB As Integer) As Task(Of TVDB.Model.SeriesDetails)
        Return Await _TVDBApi.GetFullSeriesById(iTVDB, _SpecialSettings.Language, _TVDBMirror)
    End Function

    Public Function GetImage_TVEpisode(ByRef tEpisodeDetails As TVDB.Model.Episode, ByVal tScrapeModifiers As Structures.ScrapeModifiers) As MediaContainers.SearchResultsContainer
        Dim nImageContainer As New MediaContainers.SearchResultsContainer

        'EpisodePoster
        If tScrapeModifiers.EpisodePoster AndAlso Not String.IsNullOrEmpty(tEpisodeDetails.PictureFilename) Then
            nImageContainer.EpisodePosters.Add(New MediaContainers.Image With {
                                               .Episode = tEpisodeDetails.Number,
                                               .Height = CStr(tEpisodeDetails.ThumbHeight),
                                               .LongLang = If(tEpisodeDetails.Language IsNot Nothing, Localization.ISOGetLangByCode2(tEpisodeDetails.Language), String.Empty),
                                               .Scraper = "TVDB",
                                               .Season = tEpisodeDetails.SeasonNumber,
                                               .ShortLang = If(tEpisodeDetails.Language IsNot Nothing, tEpisodeDetails.Language, String.Empty),
                                               .URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", tEpisodeDetails.PictureFilename),
                                               .URLThumb = If(Not String.IsNullOrEmpty(tEpisodeDetails.PictureFilename), String.Concat(_TVDBMirror.Address, "/banners/_cache/", tEpisodeDetails.PictureFilename), String.Empty),
                                               .Width = CStr(tEpisodeDetails.ThumbWidth)
                                               })
        End If

        Return nImageContainer
    End Function

    Public Function GetInfo_TVEpisode(ByVal iShowTVDB As Integer, ByVal iSeason As Integer, ByVal iEpisode As Integer, ByVal tEpisodeOrdering As Enums.EpisodeOrdering, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
        Dim nAddonResult As New Interfaces.AddonResult

        Try
            Dim APIResult As Task(Of TVDB.Model.SeriesDetails) = Task.Run(Function() GetFullSeriesById(iShowTVDB))
            If APIResult Is Nothing OrElse APIResult.Result Is Nothing Then
                Return Nothing
            End If
            Dim nResult = APIResult.Result

            Dim nEpisodeInfo As TVDB.Model.Episode = Nothing

            Select Case tEpisodeOrdering
                Case Enums.EpisodeOrdering.Absolute
                    nEpisodeInfo = nResult.Series.Episodes.FirstOrDefault(Function(f) f.AbsoluteNumber = iEpisode)
                Case Enums.EpisodeOrdering.DVD
                    nEpisodeInfo = nResult.Series.Episodes.FirstOrDefault(Function(f) f.DVDEpisodeNumber = iEpisode AndAlso f.DVDSeason = iSeason)
                Case Enums.EpisodeOrdering.Standard
                    nEpisodeInfo = nResult.Series.Episodes.FirstOrDefault(Function(f) f.Number = iEpisode AndAlso f.SeasonNumber = iSeason)
            End Select

            If Not nEpisodeInfo Is Nothing Then
                nAddonResult.ScraperResult_Data = GetInfo_TVEpisode(nEpisodeInfo, nResult, tScrapeModifiers, tScrapeOptions)
                nAddonResult.ScraperResult_ImageContainer = GetImage_TVEpisode(nEpisodeInfo, tScrapeModifiers)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            logger.Error(String.Concat("TVDB Scraper: Can't get informations for TV Show with ID: ", iShowTVDB))
            Return Nothing
        End Try

        Return nAddonResult
    End Function

    Public Function GetInfo_TVEpisode(ByVal iShowTVDB As Integer, ByVal strAired As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
        Dim nAddonResult As New Interfaces.AddonResult

        Try
            Dim APIResult As Task(Of TVDB.Model.SeriesDetails) = Task.Run(Function() GetFullSeriesById(iShowTVDB))
            If APIResult Is Nothing OrElse APIResult.Result Is Nothing Then
                Return Nothing
            End If
            Dim nResult = APIResult.Result

            Dim EpisodeList As IEnumerable(Of TVDB.Model.Episode) = nResult.Series.Episodes.Where(Function(f) f.FirstAired = CDate(strAired))
            If EpisodeList IsNot Nothing AndAlso EpisodeList.Count = 1 Then
                nAddonResult.ScraperResult_Data = GetInfo_TVEpisode(EpisodeList(0), nResult, tScrapeModifiers, tScrapeOptions)
                nAddonResult.ScraperResult_ImageContainer = GetImage_TVEpisode(EpisodeList(0), tScrapeModifiers)
            ElseIf EpisodeList IsNot Nothing AndAlso EpisodeList.Count > 1 Then
                logger.Error(String.Concat("TVDB Scraper: More than one episode found with AiredDate: ", strAired))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
            Return Nothing
        End Try

        Return nAddonResult
    End Function

    Public Function GetInfo_TVEpisode(ByRef tEpisodeInfo As TVDB.Model.Episode, ByRef tTVShowInfo As TVDB.Model.SeriesDetails, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
        Dim nEpisode As New MediaContainers.MainDetails

        'IDs
        nEpisode.TVDB = tEpisodeInfo.Id
        If tEpisodeInfo.IMDBId IsNot Nothing AndAlso Not String.IsNullOrEmpty(tEpisodeInfo.IMDBId) Then nEpisode.IMDB = tEpisodeInfo.IMDBId

        'Episode # Absolute
        If Not tEpisodeInfo.AbsoluteNumber = -1 Then
            nEpisode.EpisodeAbsolute = tEpisodeInfo.AbsoluteNumber
        End If

        'Episode # AirsBeforeEpisode (DisplayEpisode)
        If Not tEpisodeInfo.AirsBeforeEpisode = -1 Then
            nEpisode.DisplayEpisode = tEpisodeInfo.AirsBeforeEpisode
        End If

        'Episode # Combined
        If Not tEpisodeInfo.CombinedEpisodeNumber = -1 Then
            nEpisode.EpisodeCombined = tEpisodeInfo.CombinedEpisodeNumber
        End If

        'Episode # DVD
        If Not tEpisodeInfo.DVDEpisodeNumber = -1 Then
            nEpisode.EpisodeDVD = tEpisodeInfo.DVDEpisodeNumber
        End If

        'Episode # Standard
        If Not tEpisodeInfo.Number = -1 Then
            nEpisode.Episode = tEpisodeInfo.Number
        End If

        'Season # AirsBeforeSeason (DisplaySeason)
        If Not tEpisodeInfo.AirsBeforeSeason = -1 Then
            nEpisode.DisplaySeason = tEpisodeInfo.AirsBeforeSeason
        End If

        'Season # AirsAfterSeason (DisplaySeason, DisplayEpisode; Special handling like in Kodi)
        If Not CDbl(tEpisodeInfo.AirsAfterSeason) = -1 Then
            nEpisode.DisplaySeason = tEpisodeInfo.AirsAfterSeason
            nEpisode.DisplayEpisode = 4096
        End If

        'Season # Combined
        If Not tEpisodeInfo.CombinedSeason = -1 Then
            nEpisode.SeasonCombined = tEpisodeInfo.CombinedSeason
        End If

        'Season # DVD
        If Not tEpisodeInfo.DVDSeason = -1 Then
            nEpisode.SeasonDVD = tEpisodeInfo.DVDSeason
        End If

        'Season # Standard
        If Not tEpisodeInfo.SeasonNumber = -1 Then
            nEpisode.Season = tEpisodeInfo.SeasonNumber
        End If

        'Actors
        If tScrapeOptions.bEpisodeActors Then
            If tTVShowInfo.Actors IsNot Nothing Then
                For Each aCast As TVDB.Model.Actor In tTVShowInfo.Actors.Where(Function(f) f.Name IsNot Nothing AndAlso f.Role IsNot Nothing).OrderBy(Function(f) f.SortOrder)
                    nEpisode.Actors.Add(New MediaContainers.Person With {.Name = aCast.Name,
                                                                          .Order = aCast.SortOrder,
                                                                          .Role = aCast.Role,
                                                                          .URLOriginal = If(Not String.IsNullOrEmpty(aCast.ImagePath), String.Format("{0}/banners/{1}", _TVDBMirror.Address, aCast.ImagePath), String.Empty),
                                                                          .TVDB = CStr(aCast.Id)})
                Next
            End If
        End If

        'Aired
        If tScrapeOptions.bEpisodeAired Then
            Dim ScrapedDate As String = CStr(tEpisodeInfo.FirstAired)
            If Not String.IsNullOrEmpty(ScrapedDate) Then
                Dim RelDate As Date
                If Date.TryParse(ScrapedDate, RelDate) Then
                    'always save date in same date format not depending on users language setting!
                    nEpisode.Aired = RelDate.ToString("yyyy-MM-dd")
                Else
                    nEpisode.Aired = ScrapedDate
                End If
            End If
        End If

        'Credits
        If tScrapeOptions.bEpisodeCredits Then
            If tEpisodeInfo.Writer IsNot Nothing AndAlso Not String.IsNullOrEmpty(tEpisodeInfo.Writer) Then
                Dim CreditsList As New List(Of String)
                Dim charsToTrim() As Char = {"|"c, ","c}
                CreditsList.AddRange(tEpisodeInfo.Writer.Trim(charsToTrim).Split(charsToTrim))
                For Each aCredits As String In CreditsList
                    nEpisode.Credits.Add(aCredits.Trim)
                Next
            End If
        End If

        'Writer
        If tScrapeOptions.bEpisodeDirectors Then
            If tEpisodeInfo.Director IsNot Nothing AndAlso Not String.IsNullOrEmpty(tEpisodeInfo.Director) Then
                Dim DirectorsList As New List(Of String)
                Dim charsToTrim() As Char = {"|"c, ","c}
                DirectorsList.AddRange(tEpisodeInfo.Director.Trim(charsToTrim).Split(charsToTrim))
                For Each aDirector As String In DirectorsList
                    nEpisode.Directors.Add(aDirector.Trim)
                Next
            End If
        End If

        'Guest Stars
        If tScrapeOptions.bEpisodeGuestStars Then
            If tEpisodeInfo.GuestStars IsNot Nothing AndAlso Not String.IsNullOrEmpty(tEpisodeInfo.GuestStars) Then
                nEpisode.GuestStars.AddRange(ConvertStringToListOfPerson(tEpisodeInfo.GuestStars))
            End If
        End If

        'Plot
        If tScrapeOptions.bEpisodePlot Then
            If tEpisodeInfo.Overview IsNot Nothing Then
                nEpisode.Plot = tEpisodeInfo.Overview
            End If
        End If

        'Rating
        If tScrapeOptions.bEpisodeRating Then
            nEpisode.Rating = CStr(tEpisodeInfo.Rating)
            nEpisode.Votes = CStr(tEpisodeInfo.RatingCount)
        End If

        'ThumbPoster
        If tEpisodeInfo.PictureFilename IsNot Nothing AndAlso Not String.IsNullOrEmpty(tEpisodeInfo.PictureFilename) Then
            nEpisode.ThumbPoster.URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", tEpisodeInfo.PictureFilename)
        End If

        'Title
        If tScrapeOptions.bEpisodeTitle Then
            If tEpisodeInfo.Name IsNot Nothing Then
                nEpisode.Title = tEpisodeInfo.Name
            End If
        End If

        'Dim alContainer As New MediaContainers.SearchResultsContainer

        'Try
        '    Dim APIResult As Task(Of TVDB.Model.SeriesDetails) = Task.Run(Function() GetFullSeriesById(CInt(tvdbID)))
        '    If APIResult Is Nothing OrElse APIResult.Result Is Nothing Then
        '        Return Nothing
        '    End If
        '    Dim Results = APIResult.Result

        '    If bwTVDB.CancellationPending Then Return Nothing

        '    'EpisodePoster
        '    If FilteredModifiers.EpisodePoster AndAlso Results.Series.Episodes IsNot Nothing Then
        '        Dim EpisodeImages As IEnumerable(Of TVDB.Model.Episode) = Nothing
        '        Select Case tEpisodeOrdering
        '            Case Enums.EpisodeOrdering.Absolute
        '                EpisodeImages = Results.Series.Episodes.Where(Function(f) f.AbsoluteNumber = iEpisode)
        '            Case Enums.EpisodeOrdering.DVD
        '                EpisodeImages = Results.Series.Episodes.Where(Function(f) f.DVDSeason = iSeason And f.DVDEpisodeNumber = iEpisode)
        '            Case Enums.EpisodeOrdering.Standard
        '                EpisodeImages = Results.Series.Episodes.Where(Function(f) f.SeasonNumber = iSeason And f.Number = iEpisode)
        '        End Select

        '        If EpisodeImages IsNot Nothing Then
        '            For Each tEpisode As TVDB.Model.Episode In EpisodeImages
        '                Dim img As New MediaContainers.Image With {
        '                        .Episode = iEpisode,
        '                        .Height = CStr(tEpisode.ThumbHeight),
        '                        .LongLang = If(tEpisode.Language IsNot Nothing, Localization.ISOGetLangByCode2(tEpisode.Language), String.Empty),
        '                        .Scraper = "TVDB",
        '                        .Season = iSeason,
        '                        .ShortLang = If(tEpisode.Language IsNot Nothing, tEpisode.Language, String.Empty),
        '                        .URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", tEpisode.PictureFilename),
        '                        .URLThumb = If(Not String.IsNullOrEmpty(tEpisode.PictureFilename), String.Concat(_TVDBMirror.Address, "/banners/_cache/", tEpisode.PictureFilename), String.Empty),
        '                        .Width = CStr(tEpisode.ThumbWidth)}

        '                alContainer.EpisodePosters.Add(img)
        '            Next
        '        End If
        '    End If

        'Catch ex As Exception
        '    logger.Error(ex, New StackFrame().GetMethod().Name)
        'End Try

        'Return alContainer

        Return nEpisode
    End Function

    Public Function GetTVDBbyIMDB(ByVal strIMDB As String) As Integer
        Dim Shows As List(Of TVDB.Model.Series)

        Shows = _TVDBApi.GetSeriesByRemoteId(strIMDB, String.Empty, _TVDBMirror).Result
        If Shows Is Nothing Then
            Return -1
        End If

        If Shows.Count = 1 Then
            Return Shows.Item(0).Id
        End If

        Return -1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="iTVDB">TVDB ID</param>
    ''' <param name="bGetPoster"></param>
    ''' <param name="tScrapeOptions"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Scrape_TVShow(ByVal iTVDB As Integer, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions, ByVal bGetPoster As Boolean) As Interfaces.AddonResult
        If iTVDB = -1 Then Return Nothing

        Dim nAddonResult As New Interfaces.AddonResult

        Dim APIResult As Task(Of TVDB.Model.SeriesDetails) = Task.Run(Function() GetFullSeriesById(iTVDB))
        If APIResult Is Nothing OrElse APIResult.Result Is Nothing Then
            Return Nothing
        End If
        Dim Results = APIResult.Result

        'Data
        With nAddonResult.ScraperResult_Data
            .Scrapersource = "TVDB"
            .TVDB = Results.Series.Id
            .IMDB = Results.Series.IMDBId

            'Actors
            If tScrapeOptions.bMainActors Then
                If Results.Actors IsNot Nothing Then
                    For Each aCast As TVDB.Model.Actor In Results.Actors.Where(Function(f) f.Name IsNot Nothing AndAlso f.Role IsNot Nothing).OrderBy(Function(f) f.SortOrder)
                        .Actors.Add(New MediaContainers.Person With {
                                    .Name = aCast.Name,
                                    .Order = aCast.SortOrder,
                                    .Role = aCast.Role,
                                    .URLOriginal = If(Not String.IsNullOrEmpty(aCast.ImagePath), String.Format("{0}/banners/{1}", _TVDBMirror.Address, aCast.ImagePath), String.Empty),
                                    .TVDB = CStr(aCast.Id)
                                    })
                    Next
                End If
            End If

            'EpisodeGuideURL
            If tScrapeOptions.bMainEpisodeGuide Then
                .EpisodeGuide.URL = String.Concat(_TVDBMirror.Address, "/api/", _SpecialSettings.APIKey, "/series/", Results.Series.Id, "/all/", Results.Language, ".zip")
            End If

            'Genres
            If tScrapeOptions.bMainGenres Then
                Dim aGenres As List(Of String) = Nothing
                If Results.Series.Genre IsNot Nothing Then
                    aGenres = Results.Series.Genre.Split(CChar(",")).ToList
                End If

                If aGenres IsNot Nothing Then
                    For Each tGenre As String In aGenres
                        .Genres.Add(tGenre.Trim)
                    Next
                End If
            End If

            'MPAA
            If tScrapeOptions.bMainMPAA Then
                .MPAA = Results.Series.ContentRating
            End If

            'Plot
            If tScrapeOptions.bMainPlot Then
                If Results.Series.Overview IsNot Nothing Then
                    .Plot = Results.Series.Overview
                End If
            End If

            'Premiered
            If tScrapeOptions.bMainPremiered Then
                .Premiered = CStr(Results.Series.FirstAired)
            End If

            'Rating
            If tScrapeOptions.bMainRating Then
                .Rating = CStr(Results.Series.Rating)
                .Votes = CStr(Results.Series.RatingCount)
            End If

            'Runtime
            If tScrapeOptions.bMainRuntime Then
                .Runtime = CStr(Results.Series.Runtime)
            End If

            'Status
            If tScrapeOptions.bMainStatus Then
                .Status = Results.Series.Status
            End If

            'Studios
            If tScrapeOptions.bMainStudios Then
                .Studios.Add(Results.Series.Network)
            End If

            'Title
            If tScrapeOptions.bMainTitle Then
                .Title = Results.Series.Name
            End If

            'Seasons and Episodes
            For Each aEpisode As TVDB.Model.Episode In Results.Series.Episodes
                If tScrapeModifiers.withSeasons Then
                    'check if we have already saved season information for this scraped season
                    Dim lSeasonList = .KnownSeasons.Where(Function(f) f.Season = aEpisode.SeasonNumber)

                    If lSeasonList.Count = 0 Then
                        .KnownSeasons.Add(New MediaContainers.MainDetails With {
                                          .Season = aEpisode.SeasonNumber,
                                          .TVDB = aEpisode.SeasonId
                                          })
                    End If
                End If

                If tScrapeModifiers.withEpisodes Then
                    .KnownEpisodes.Add(GetInfo_TVEpisode(aEpisode, Results, tScrapeModifiers, tScrapeOptions))
                End If
            Next
        End With

        'Images
        With nAddonResult.ScraperResult_ImageContainer
            If Results.Banners IsNot Nothing Then

                'EpisodePoster
                If tScrapeModifiers.EpisodePoster AndAlso Results.Series.Episodes IsNot Nothing Then
                    For Each tEpisode As TVDB.Model.Episode In Results.Series.Episodes.Where(Function(f) Not String.IsNullOrEmpty(f.PictureFilename))
                        .EpisodePosters.Add(New MediaContainers.Image With {
                                            .Episode = tEpisode.Number,
                                            .Height = CStr(tEpisode.ThumbHeight),
                                            .LongLang = If(tEpisode.Language IsNot Nothing, Localization.ISOGetLangByCode2(tEpisode.Language), String.Empty),
                                            .Scraper = "TVDB",
                                            .Season = tEpisode.SeasonNumber,
                                            .ShortLang = If(tEpisode.Language IsNot Nothing, tEpisode.Language, String.Empty),
                                            .URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", tEpisode.PictureFilename),
                                            .URLThumb = If(Not String.IsNullOrEmpty(tEpisode.PictureFilename), String.Concat(_TVDBMirror.Address, "/banners/_cache/", tEpisode.PictureFilename), String.Empty),
                                            .Width = CStr(tEpisode.ThumbWidth)
                                            })
                    Next
                End If

                'MainBanner
                If tScrapeModifiers.MainBanner Then
                    For Each image As TVDB.Model.Banner In Results.Banners.Where(Function(f) f.Type = TVDB.Model.BannerTyp.series)
                        .MainBanners.Add(New MediaContainers.Image With {
                                         .Height = "140",
                                         .LongLang = If(image.Language IsNot Nothing, Localization.ISOGetLangByCode2(image.Language), String.Empty),
                                         .Scraper = "TVDB",
                                         .Season = image.Season,
                                         .ShortLang = If(image.Language IsNot Nothing, image.Language, String.Empty),
                                         .URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", image.BannerPath),
                                         .URLThumb = If(Not String.IsNullOrEmpty(image.ThumbnailPath), String.Concat(_TVDBMirror.Address, "/banners/", image.ThumbnailPath), String.Empty),
                                         .VoteAverage = CStr(image.Rating),
                                         .VoteCount = image.RatingCount,
                                         .Width = "758"
                                         })
                    Next
                End If

                'SeasonBanner
                If tScrapeModifiers.SeasonBanner Then
                    For Each image As TVDB.Model.Banner In Results.Banners.Where(Function(f) f.Type = TVDB.Model.BannerTyp.season AndAlso f.BannerPath.Contains("seasonswide"))
                        .SeasonBanners.Add(New MediaContainers.Image With {
                                           .Height = "140",
                                           .LongLang = If(image.Language IsNot Nothing, Localization.ISOGetLangByCode2(image.Language), String.Empty),
                                           .Scraper = "TVDB",
                                           .Season = image.Season,
                                           .ShortLang = If(image.Language IsNot Nothing, image.Language, String.Empty),
                                           .URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", image.BannerPath),
                                           .URLThumb = If(Not String.IsNullOrEmpty(image.ThumbnailPath), String.Concat(_TVDBMirror.Address, "/banners/", image.ThumbnailPath), String.Empty),
                                           .VoteAverage = CStr(image.Rating),
                                           .VoteCount = image.RatingCount,
                                           .Width = "758"
                                           })
                    Next
                End If

                'MainFanart
                If tScrapeModifiers.MainFanart Then
                    For Each image As TVDB.Model.Banner In Results.Banners.Where(Function(f) f.Type = TVDB.Model.BannerTyp.fanart)
                        .MainFanarts.Add(New MediaContainers.Image With {
                                         .Height = StringUtils.StringToSize(image.Dimension).Height.ToString,
                                         .LongLang = If(image.Language IsNot Nothing, Localization.ISOGetLangByCode2(image.Language), String.Empty),
                                         .Scraper = "TVDB",
                                         .Season = image.Season,
                                         .ShortLang = If(image.Language IsNot Nothing, image.Language, String.Empty),
                                         .URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", image.BannerPath),
                                         .URLThumb = If(Not String.IsNullOrEmpty(image.ThumbnailPath), String.Concat(_TVDBMirror.Address, "/banners/", image.ThumbnailPath), String.Empty),
                                         .VoteAverage = CStr(image.Rating),
                                         .VoteCount = image.RatingCount,
                                         .Width = StringUtils.StringToSize(image.Dimension).Width.ToString
                                         })
                    Next
                End If

                'MainPoster
                If tScrapeModifiers.MainPoster Then
                    For Each image As TVDB.Model.Banner In Results.Banners.Where(Function(f) f.Type = TVDB.Model.BannerTyp.poster)
                        .MainPosters.Add(New MediaContainers.Image With {
                                         .Height = StringUtils.StringToSize(image.Dimension).Height.ToString,
                                         .LongLang = If(image.Language IsNot Nothing, Localization.ISOGetLangByCode2(image.Language), String.Empty),
                                         .Scraper = "TVDB",
                                         .Season = image.Season,
                                         .ShortLang = If(image.Language IsNot Nothing, image.Language, String.Empty),
                                         .URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", image.BannerPath),
                                         .URLThumb = If(Not String.IsNullOrEmpty(image.ThumbnailPath), String.Concat(_TVDBMirror.Address, "/banners/", image.ThumbnailPath), String.Empty),
                                         .VoteAverage = CStr(image.Rating),
                                         .VoteCount = image.RatingCount,
                                         .Width = StringUtils.StringToSize(image.Dimension).Width.ToString
                                         })
                    Next
                End If

                'SeasonPoster
                If tScrapeModifiers.SeasonPoster Then
                    For Each image As TVDB.Model.Banner In Results.Banners.Where(Function(f) f.Type = TVDB.Model.BannerTyp.season AndAlso Not f.BannerPath.Contains("seasonswide"))
                        .SeasonPosters.Add(New MediaContainers.Image With {
                                           .Height = "578",
                                           .LongLang = If(image.Language IsNot Nothing, Localization.ISOGetLangByCode2(image.Language), String.Empty),
                                           .Scraper = "TVDB",
                                           .Season = image.Season,
                                           .ShortLang = If(image.Language IsNot Nothing, image.Language, String.Empty),
                                           .URLThumb = If(Not String.IsNullOrEmpty(image.ThumbnailPath), String.Concat(_TVDBMirror.Address, "/banners/", image.ThumbnailPath), String.Empty),
                                           .URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", image.BannerPath),
                                           .VoteAverage = CStr(image.Rating),
                                           .VoteCount = image.RatingCount,
                                           .Width = "400"
                                           })
                    Next
                End If
            End If
        End With

        Return nAddonResult
    End Function

    Public Function Search_TVShow(ByVal strTitle As String) As List(Of MediaContainers.MainDetails)
        If String.IsNullOrEmpty(strTitle) Then Return New List(Of MediaContainers.MainDetails)

        Dim nResult As List(Of TVDB.Model.Series)
        Dim nSearchResults As New List(Of MediaContainers.MainDetails)

        Try
            nResult = _TVDBApi.GetSeriesByName(strTitle, _SpecialSettings.Language, _TVDBMirror).Result
            If nResult Is Nothing Then
                Return Nothing
            End If

            If nResult.Count > 0 Then
                For Each aShow In nResult
                    nSearchResults.Add(New MediaContainers.MainDetails With {
                                       .Aired = CStr(aShow.FirstAired.Year),
                                       .Plot = aShow.Overview,
                                       .Premiered = aShow.FirstAired.ToString("yyyy-MM-dd"),
                                       .IMDB = aShow.IMDBId,
                                       .ThumbPoster = New MediaContainers.Image With {.URLOriginal = String.Concat(_TVDBMirror.Address, "/banners/", aShow.Poster)},
                                       .Title = aShow.Name,
                                       .TVDB = aShow.SeriesId})
                Next
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        Return nSearchResults
    End Function

#End Region 'Methods

End Class