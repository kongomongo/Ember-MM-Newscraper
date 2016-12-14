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
Imports System.Diagnostics

Namespace TMDB

    Public Class Scraper

#Region "Fields"

        Shared logger As Logger = LogManager.GetCurrentClassLogger()

        Private _TMDBApi As TMDbLib.Client.TMDbClient  'preferred language
        Private _TMDBApiE As TMDbLib.Client.TMDbClient 'english language
        Private _TMDBApiG As TMDbLib.Client.TMDbClient 'global, no language
        Private _SpecialSettings As Addon.AddonSettings
        Private _sPoster As String

#End Region 'Fields

#Region "Methods"

        Public Sub New(ByVal tSpecialSettings As Addon.AddonSettings)
            Try
                _SpecialSettings = tSpecialSettings

                _TMDBApi = New TMDbLib.Client.TMDbClient(_SpecialSettings.APIKey)
                _TMDBApi.GetConfig()
                _TMDBApi.DefaultLanguage = _SpecialSettings.PrefLanguage

                _TMDBApiG = New TMDbLib.Client.TMDbClient(tSpecialSettings.APIKey)
                _TMDBApiG.GetConfig()

                If _SpecialSettings.FallBackToEng Then
                    _TMDBApiE = New TMDbLib.Client.TMDbClient(_SpecialSettings.APIKey)
                    _TMDBApiE.GetConfig()
                    _TMDBApiE.DefaultLanguage = "en-US"
                Else
                    _TMDBApiE = _TMDBApi
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End Sub

        Public Function GetImages_Movie_MovieSet(ByVal strTMDB As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tContentType As Enums.ContentType) As MediaContainers.SearchResultsContainer
            Dim nImagesContainer As New MediaContainers.SearchResultsContainer

            Try
                Dim Results As TMDbLib.Objects.General.Images = Nothing
                Dim APIResult As Task(Of TMDbLib.Objects.General.ImagesWithId)

                If tContentType = Enums.ContentType.Movie Then
                    APIResult = Task.Run(Function() _TMDBApiG.GetMovieImagesAsync(CInt(strTMDB)))
                    Results = APIResult.Result
                ElseIf tContentType = Enums.ContentType.MovieSet Then
                    APIResult = Task.Run(Function() _TMDBApiG.GetCollectionImagesAsync(CInt(strTMDB)))
                    Results = APIResult.Result
                End If

                If Results Is Nothing Then
                    Return Nothing
                End If

                'MainFanart
                If (tScrapeModifiers.MainExtrafanarts OrElse tScrapeModifiers.MainExtrathumbs OrElse tScrapeModifiers.MainFanart) AndAlso Results.Backdrops IsNot Nothing Then
                    For Each tImage In Results.Backdrops
                        Dim newImage As New MediaContainers.Image With {
                            .Height = tImage.Height.ToString,
                            .Likes = 0,
                            .LongLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, Localization.ISOGetLangByCode2(tImage.Iso_639_1)),
                            .Scraper = "TMDB",
                            .ShortLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, tImage.Iso_639_1),
                            .URLOriginal = _TMDBApiG.Config.Images.BaseUrl & "original" & tImage.FilePath,
                            .URLThumb = _TMDBApiG.Config.Images.BaseUrl & "w300" & tImage.FilePath,
                            .VoteAverage = tImage.VoteAverage.ToString,
                            .VoteCount = tImage.VoteCount,
                            .Width = tImage.Width.ToString}

                        nImagesContainer.MainFanarts.Add(newImage)
                    Next
                End If

                'MainPoster
                If tScrapeModifiers.MainPoster AndAlso Results.Posters IsNot Nothing Then
                    For Each tImage In Results.Posters
                        Dim newImage As New MediaContainers.Image With {
                                .Height = tImage.Height.ToString,
                                .Likes = 0,
                                .LongLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, Localization.ISOGetLangByCode2(tImage.Iso_639_1)),
                                .Scraper = "TMDB",
                                .ShortLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, tImage.Iso_639_1),
                                .URLOriginal = _TMDBApiG.Config.Images.BaseUrl & "original" & tImage.FilePath,
                                .URLThumb = _TMDBApiG.Config.Images.BaseUrl & "w185" & tImage.FilePath,
                                .VoteAverage = tImage.VoteAverage.ToString,
                                .VoteCount = tImage.VoteCount,
                                .Width = tImage.Width.ToString}

                        nImagesContainer.MainPosters.Add(newImage)
                    Next
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            Return nImagesContainer
        End Function

        Public Function GetImages_TVShow(ByVal iTMDB As Integer, ByVal tScrapeModifiers As Structures.ScrapeModifiers) As MediaContainers.SearchResultsContainer
            Dim nImagesContainer As New MediaContainers.SearchResultsContainer

            Try
                Dim APIResult As Task(Of TMDbLib.Objects.TvShows.TvShow)
                APIResult = Task.Run(Function() _TMDBApiG.GetTvShowAsync(iTMDB, TMDbLib.Objects.TvShows.TvShowMethods.Images))

                If APIResult Is Nothing Then
                    Return Nothing
                End If

                Dim Result As TMDbLib.Objects.TvShows.TvShow = APIResult.Result

                'MainFanart
                If tScrapeModifiers.MainFanart AndAlso Result.Images.Backdrops IsNot Nothing Then
                    For Each tImage In Result.Images.Backdrops
                        Dim newImage As New MediaContainers.Image With {
                            .Height = tImage.Height.ToString,
                            .Likes = 0,
                            .LongLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, Localization.ISOGetLangByCode2(tImage.Iso_639_1)),
                            .Scraper = "TMDB",
                            .ShortLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, tImage.Iso_639_1),
                            .URLOriginal = _TMDBApiG.Config.Images.BaseUrl & "original" & tImage.FilePath,
                            .URLThumb = _TMDBApiG.Config.Images.BaseUrl & "w300" & tImage.FilePath,
                            .VoteAverage = tImage.VoteAverage.ToString,
                            .VoteCount = tImage.VoteCount,
                            .Width = tImage.Width.ToString}

                        nImagesContainer.MainFanarts.Add(newImage)
                    Next
                End If

                'MainPoster
                If tScrapeModifiers.MainPoster AndAlso Result.Images.Posters IsNot Nothing Then
                    For Each tImage In Result.Images.Posters
                        Dim newImage As New MediaContainers.Image With {
                                .Height = tImage.Height.ToString,
                                .Likes = 0,
                                .LongLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, Localization.ISOGetLangByCode2(tImage.Iso_639_1)),
                                .Scraper = "TMDB",
                                .ShortLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, tImage.Iso_639_1),
                                .URLOriginal = _TMDBApiG.Config.Images.BaseUrl & "original" & tImage.FilePath,
                                .URLThumb = _TMDBApiG.Config.Images.BaseUrl & "w185" & tImage.FilePath,
                                .VoteAverage = tImage.VoteAverage.ToString,
                                .VoteCount = tImage.VoteCount,
                                .Width = tImage.Width.ToString}

                        nImagesContainer.MainPosters.Add(newImage)
                    Next
                End If

                'SeasonPoster
                If (tScrapeModifiers.SeasonPoster OrElse tScrapeModifiers.EpisodePoster) AndAlso Result.Seasons IsNot Nothing Then
                    For Each tSeason In Result.Seasons
                        Dim APIResult_Season As Task(Of TMDbLib.Objects.TvShows.TvSeason)
                        APIResult_Season = Task.Run(Function() _TMDBApiG.GetTvSeasonAsync(iTMDB, tSeason.SeasonNumber, TMDbLib.Objects.TvShows.TvSeasonMethods.Images))

                        If APIResult_Season IsNot Nothing Then
                            Dim Result_Season As TMDbLib.Objects.TvShows.TvSeason = APIResult_Season.Result

                            'SeasonPoster
                            If tScrapeModifiers.SeasonPoster AndAlso Result_Season.Images.Posters IsNot Nothing Then
                                For Each tImage In Result_Season.Images.Posters
                                    Dim newImage As New MediaContainers.Image With {
                                        .Height = tImage.Height.ToString,
                                        .Likes = 0,
                                        .LongLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, Localization.ISOGetLangByCode2(tImage.Iso_639_1)),
                                        .Scraper = "TMDB",
                                        .Season = tSeason.SeasonNumber,
                                        .ShortLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, tImage.Iso_639_1),
                                        .URLOriginal = _TMDBApiG.Config.Images.BaseUrl & "original" & tImage.FilePath,
                                        .URLThumb = _TMDBApiG.Config.Images.BaseUrl & "w185" & tImage.FilePath,
                                        .VoteAverage = tImage.VoteAverage.ToString,
                                        .VoteCount = tImage.VoteCount,
                                        .Width = tImage.Width.ToString}

                                    nImagesContainer.SeasonPosters.Add(newImage)
                                Next
                            End If

                            If tScrapeModifiers.EpisodePoster AndAlso Result_Season.Episodes IsNot Nothing Then
                                For Each tEpisode In Result_Season.Episodes

                                    'EpisodePoster
                                    If tScrapeModifiers.EpisodePoster AndAlso tEpisode.StillPath IsNot Nothing Then

                                        Dim newImage As New MediaContainers.Image With {
                                            .Episode = tEpisode.EpisodeNumber,
                                            .Scraper = "TMDB",
                                            .Season = tEpisode.SeasonNumber,
                                            .URLOriginal = _TMDBApiG.Config.Images.BaseUrl & "original" & tEpisode.StillPath,
                                            .URLThumb = _TMDBApiG.Config.Images.BaseUrl & "w185" & tEpisode.StillPath}

                                        nImagesContainer.EpisodePosters.Add(newImage)

                                        '    For Each tImage In tEpisode.Images.Stills
                                        '        Dim newImage As New MediaContainers.Image With {
                                        '            .Episode = tEpisode.EpisodeNumber,
                                        '            .Height = tImage.Height.ToString,
                                        '            .Likes = 0,
                                        '            .LongLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, Localization.ISOGetLangByCode2(tImage.Iso_639_1)),
                                        '            .Scraper = "TMDB",
                                        '            .Season = CInt(tEpisode.SeasonNumber),
                                        '            .ShortLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, tImage.Iso_639_1),
                                        '            .URLOriginal = _TMDBApiG.Config.Images.BaseUrl & "original" & tImage.FilePath,
                                        '            .URLThumb = _TMDBApiG.Config.Images.BaseUrl & "w185" & tImage.FilePath,
                                        '            .VoteAverage = tImage.VoteAverage.ToString,
                                        '            .VoteCount = tImage.VoteCount,
                                        '            .Width = tImage.Width.ToString}

                                        '        alContainer.EpisodePosters.Add(newImage)
                                        '    Next
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            Return nImagesContainer
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="iShowID">TVShow TMDB id</param>
        ''' <param name="iSeason"></param>
        ''' <param name="iEpisode"></param>
        ''' <param name="tScrapeModifiers"></param>
        ''' <returns></returns>
        Public Function GetImages_TVEpisode(ByVal iShowID As Integer, ByVal iSeason As Integer, ByVal iEpisode As Integer, ByVal tScrapeModifiers As Structures.ScrapeModifiers) As MediaContainers.SearchResultsContainer
            Dim nImagesContainer As New MediaContainers.SearchResultsContainer

            Try
                Dim Results As TMDbLib.Objects.General.StillImages = Nothing
                Dim APIResult As Task(Of TMDbLib.Objects.General.StillImages)
                APIResult = Task.Run(Function() _TMDBApiG.GetTvEpisodeImagesAsync(iShowID, iSeason, iEpisode))
                Results = APIResult.Result

                If Results Is Nothing Then
                    Return Nothing
                End If

                'EpisodePoster
                If tScrapeModifiers.EpisodePoster AndAlso Results.Stills IsNot Nothing Then
                    For Each tImage In Results.Stills
                        Dim newImage As New MediaContainers.Image With {
                            .Episode = iEpisode,
                            .Height = tImage.Height.ToString,
                            .Likes = 0,
                            .LongLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, Localization.ISOGetLangByCode2(tImage.Iso_639_1)),
                            .Scraper = "TMDB",
                            .Season = iSeason,
                            .ShortLang = If(String.IsNullOrEmpty(tImage.Iso_639_1), String.Empty, tImage.Iso_639_1),
                            .URLOriginal = _TMDBApiG.Config.Images.BaseUrl & "original" & tImage.FilePath,
                            .URLThumb = _TMDBApiG.Config.Images.BaseUrl & "w185" & tImage.FilePath,
                            .VoteAverage = tImage.VoteAverage.ToString,
                            .VoteCount = tImage.VoteCount,
                            .Width = tImage.Width.ToString}

                        nImagesContainer.EpisodePosters.Add(newImage)
                    Next
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            Return nImagesContainer
        End Function
        ''' <summary>
        '''  Scrape MovieDetails from TMDB
        ''' </summary>
        ''' <param name="strID">TMDBID or ID (IMDB ID starts with "tt") of movie to be scraped</param>
        ''' <param name="GetPoster">Scrape posters for the movie?</param>
        ''' <returns>True: success, false: no success</returns>
        Public Function GetInfo_Movie(ByVal strID As String, ByVal tScrapeOptions As Structures.ScrapeOptions, ByVal GetPoster As Boolean) As MediaContainers.MainDetails
            If String.IsNullOrEmpty(strID) Then Return Nothing

            Dim nMovie As New MediaContainers.MainDetails

            Dim APIResult As Task(Of TMDbLib.Objects.Movies.Movie)
            Dim APIResultE As Task(Of TMDbLib.Objects.Movies.Movie)

            If strID.ToLower.StartsWith("tt") Then
                'search movie by IMDB ID
                APIResult = Task.Run(Function() _TMDBApi.GetMovieAsync(strID, TMDbLib.Objects.Movies.MovieMethods.Credits Or TMDbLib.Objects.Movies.MovieMethods.Releases Or TMDbLib.Objects.Movies.MovieMethods.Videos))
                If _SpecialSettings.FallBackToEng Then
                    APIResultE = Task.Run(Function() _TMDBApiE.GetMovieAsync(strID, TMDbLib.Objects.Movies.MovieMethods.Credits Or TMDbLib.Objects.Movies.MovieMethods.Releases Or TMDbLib.Objects.Movies.MovieMethods.Videos))
                Else
                    APIResultE = APIResult
                End If
            Else
                'search movie by TMDB ID
                APIResult = Task.Run(Function() _TMDBApi.GetMovieAsync(CInt(strID), TMDbLib.Objects.Movies.MovieMethods.Credits Or TMDbLib.Objects.Movies.MovieMethods.Releases Or TMDbLib.Objects.Movies.MovieMethods.Videos))
                If _SpecialSettings.FallBackToEng Then
                    APIResultE = Task.Run(Function() _TMDBApiE.GetMovieAsync(CInt(strID), TMDbLib.Objects.Movies.MovieMethods.Credits Or TMDbLib.Objects.Movies.MovieMethods.Releases Or TMDbLib.Objects.Movies.MovieMethods.Videos))
                Else
                    APIResultE = APIResult
                End If
            End If

            Dim Result As TMDbLib.Objects.Movies.Movie = APIResult.Result
            Dim ResultE As TMDbLib.Objects.Movies.Movie = APIResultE.Result

            If (Result Is Nothing AndAlso Not _SpecialSettings.FallBackToEng) OrElse (Result Is Nothing AndAlso ResultE Is Nothing) OrElse
                (Not Result.Id > 0 AndAlso Not _SpecialSettings.FallBackToEng) OrElse (Not Result.Id > 0 AndAlso Not ResultE.Id > 0) Then
                logger.Error(String.Format("Can't scrape or movie not found: [0]", strID))
                Return Nothing
            End If

            nMovie.Scrapersource = "TMDB"

            'IDs
            nMovie.TMDB = Result.Id
            If Result.ImdbId IsNot Nothing Then nMovie.IMDB = Result.ImdbId

            'Cast (Actors)
            If tScrapeOptions.bMainActors Then
                If Result.Credits IsNot Nothing AndAlso Result.Credits.Cast IsNot Nothing Then
                    For Each aCast As TMDbLib.Objects.Movies.Cast In Result.Credits.Cast
                        nMovie.Actors.Add(New MediaContainers.Person With {.Name = aCast.Name,
                                                                           .Role = aCast.Character,
                                                                           .URLOriginal = If(Not String.IsNullOrEmpty(aCast.ProfilePath), String.Concat(_TMDBApi.Config.Images.BaseUrl, "original", aCast.ProfilePath), String.Empty),
                                                                           .TMDB = CStr(aCast.Id)})
                    Next
                End If
            End If

            'Certifications
            If tScrapeOptions.bMainCertifications Then
                If Result.Releases IsNot Nothing AndAlso Result.Releases.Countries IsNot Nothing AndAlso Result.Releases.Countries.Count > 0 Then
                    For Each cCountry In Result.Releases.Countries
                        If Not String.IsNullOrEmpty(cCountry.Certification) Then
                            Dim CertificationLanguage = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.abbreviation = cCountry.Iso_3166_1.ToLower)
                            If CertificationLanguage IsNot Nothing AndAlso CertificationLanguage.name IsNot Nothing AndAlso Not String.IsNullOrEmpty(CertificationLanguage.name) Then
                                nMovie.Certifications.Add(String.Concat(CertificationLanguage.name, ":", cCountry.Certification))
                            Else
                                logger.Warn("Unhandled certification language encountered: {0}", cCountry.Iso_3166_1.ToLower)
                            End If
                        End If
                    Next
                End If
            End If

            'Collection ID
            If tScrapeOptions.bMainCollectionID Then
                If Result.BelongsToCollection Is Nothing Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.BelongsToCollection IsNot Nothing Then
                        nMovie.AddSet(New MediaContainers.SetDetails With {
                                      .ID = -1,
                                      .Order = -1,
                                      .Plot = String.Empty,
                                      .Title = ResultE.BelongsToCollection.Name,
                                      .TMDB = ResultE.BelongsToCollection.Id})
                        nMovie.TMDBColID = ResultE.BelongsToCollection.Id
                    End If
                Else
                    nMovie.AddSet(New MediaContainers.SetDetails With {
                                  .ID = -1,
                                  .Order = -1,
                                  .Plot = String.Empty,
                                  .Title = ResultE.BelongsToCollection.Name,
                                  .TMDB = ResultE.BelongsToCollection.Id})
                    nMovie.TMDBColID = Result.BelongsToCollection.Id
                End If
            End If

            'Countries
            If tScrapeOptions.bMainCountries Then
                If Result.ProductionCountries IsNot Nothing AndAlso Result.ProductionCountries.Count > 0 Then
                    For Each aContry As TMDbLib.Objects.Movies.ProductionCountry In Result.ProductionCountries
                        nMovie.Countries.Add(aContry.Name)
                    Next
                End If
            End If

            'Director / Writer
            If tScrapeOptions.bMainDirectors OrElse tScrapeOptions.bMainWriters Then
                If Result.Credits IsNot Nothing AndAlso Result.Credits.Crew IsNot Nothing Then
                    For Each aCrew As TMDbLib.Objects.General.Crew In Result.Credits.Crew
                        If tScrapeOptions.bMainDirectors AndAlso aCrew.Department = "Directing" AndAlso aCrew.Job = "Director" Then
                            nMovie.Directors.Add(aCrew.Name)
                        End If
                        If tScrapeOptions.bMainWriters AndAlso aCrew.Department = "Writing" AndAlso (aCrew.Job = "Author" OrElse aCrew.Job = "Screenplay" OrElse aCrew.Job = "Writer") Then
                            nMovie.Credits.Add(aCrew.Name)
                        End If
                    Next
                End If
            End If

            'Genres
            If tScrapeOptions.bMainGenres Then
                Dim aGenres As List(Of TMDbLib.Objects.General.Genre) = Nothing
                If Result.Genres Is Nothing OrElse (Result.Genres IsNot Nothing AndAlso Result.Genres.Count = 0) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Genres IsNot Nothing AndAlso ResultE.Genres.Count > 0 Then
                        aGenres = ResultE.Genres
                    End If
                Else
                    aGenres = Result.Genres
                End If

                If aGenres IsNot Nothing Then
                    For Each tGenre As TMDbLib.Objects.General.Genre In aGenres
                        nMovie.Genres.Add(tGenre.Name)
                    Next
                End If
            End If

            'OriginalTitle
            If tScrapeOptions.bMainOriginalTitle Then
                If Result.OriginalTitle Is Nothing OrElse (Result.OriginalTitle IsNot Nothing AndAlso String.IsNullOrEmpty(Result.OriginalTitle)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.OriginalTitle IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.OriginalTitle) Then
                        nMovie.OriginalTitle = ResultE.OriginalTitle
                    End If
                Else
                    nMovie.OriginalTitle = Result.OriginalTitle
                End If
            End If

            'Plot
            If tScrapeOptions.bMainPlot Then
                If Result.Overview Is Nothing OrElse (Result.Overview IsNot Nothing AndAlso String.IsNullOrEmpty(Result.Overview)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Overview IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.Overview) Then
                        nMovie.Plot = ResultE.Overview
                    End If
                Else
                    nMovie.Plot = Result.Overview
                End If
            End If

            'Posters (only for SearchResult dialog, auto fallback to "en" by TMDB)
            If GetPoster Then
                If Result.PosterPath IsNot Nothing AndAlso Not String.IsNullOrEmpty(Result.PosterPath) Then
                    _sPoster = String.Concat(_TMDBApi.Config.Images.BaseUrl, "w92", Result.PosterPath)
                Else
                    _sPoster = String.Empty
                End If
            End If

            'Rating
            If tScrapeOptions.bMainRating Then
                nMovie.Rating = CStr(Result.VoteAverage)
                nMovie.Votes = CStr(Result.VoteCount)
            End If

            'ReleaseDate
            If tScrapeOptions.bMainRelease Then
                Dim ScrapedDate As String = String.Empty
                If Result.ReleaseDate Is Nothing OrElse (Result.ReleaseDate IsNot Nothing AndAlso String.IsNullOrEmpty(CStr(Result.ReleaseDate))) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.ReleaseDate IsNot Nothing AndAlso Not String.IsNullOrEmpty(CStr(ResultE.ReleaseDate)) Then
                        ScrapedDate = CStr(ResultE.ReleaseDate)
                    End If
                Else
                    ScrapedDate = CStr(Result.ReleaseDate)
                End If
                If Not String.IsNullOrEmpty(ScrapedDate) Then
                    Dim RelDate As Date
                    If Date.TryParse(ScrapedDate, RelDate) Then
                        'always save date in same date format not depending on users language setting!
                        nMovie.ReleaseDate = RelDate.ToString("yyyy-MM-dd")
                    Else
                        nMovie.ReleaseDate = ScrapedDate
                    End If
                End If
            End If

            'Runtime
            If tScrapeOptions.bMainRuntime Then
                If Result.Runtime Is Nothing OrElse Result.Runtime = 0 Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Runtime IsNot Nothing Then
                        nMovie.Runtime = CStr(ResultE.Runtime)
                    End If
                Else
                    nMovie.Runtime = CStr(Result.Runtime)
                End If
            End If

            'Studios
            If tScrapeOptions.bMainStudios Then
                If Result.ProductionCompanies IsNot Nothing AndAlso Result.ProductionCompanies.Count > 0 Then
                    For Each cStudio In Result.ProductionCompanies
                        nMovie.Studios.Add(cStudio.Name)
                    Next
                End If
            End If

            'Tagline
            If tScrapeOptions.bMainTagline Then
                If Result.Tagline Is Nothing OrElse (Result.Tagline IsNot Nothing AndAlso String.IsNullOrEmpty(Result.Tagline)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Tagline IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.Tagline) Then
                        nMovie.Tagline = ResultE.Tagline
                    End If
                Else
                    nMovie.Tagline = Result.Tagline
                End If
            End If

            'Title
            If tScrapeOptions.bMainTitle Then
                If Result.Title Is Nothing OrElse (Result.Title IsNot Nothing AndAlso String.IsNullOrEmpty(Result.Title)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Title IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.Title) Then
                        nMovie.Title = ResultE.Title
                    End If
                Else
                    nMovie.Title = Result.Title
                End If
            End If

            'Trailer
            If tScrapeOptions.bMainTrailer Then
                Dim aTrailers As List(Of TMDbLib.Objects.General.Video) = Nothing
                If Result.Videos Is Nothing OrElse (Result.Videos IsNot Nothing AndAlso Result.Videos.Results.Count = 0) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Videos IsNot Nothing AndAlso ResultE.Videos.Results.Count > 0 Then
                        aTrailers = ResultE.Videos.Results
                    End If
                Else
                    aTrailers = Result.Videos.Results
                End If

                If aTrailers IsNot Nothing AndAlso aTrailers.Count > 0 Then
                    For Each tTrailer In aTrailers
                        If YouTube.Scraper.IsAvailable("http://www.youtube.com/watch?hd=1&v=" & tTrailer.Key) Then
                            nMovie.Trailer = "http://www.youtube.com/watch?hd=1&v=" & tTrailer.Key
                            Exit For
                        End If
                    Next
                End If
            End If

            'Year
            If tScrapeOptions.bMainYear Then
                If Result.ReleaseDate Is Nothing OrElse (Result.ReleaseDate IsNot Nothing AndAlso String.IsNullOrEmpty(CStr(Result.ReleaseDate))) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.ReleaseDate IsNot Nothing AndAlso Not String.IsNullOrEmpty(CStr(ResultE.ReleaseDate)) Then
                        nMovie.Year = CStr(ResultE.ReleaseDate.Value.Year)
                    End If
                Else
                    nMovie.Year = CStr(Result.ReleaseDate.Value.Year)
                End If
            End If

            Return nMovie
        End Function

        Public Function GetInfo_MovieSet(ByVal strID As String, ByVal tScrapeOptions As Structures.ScrapeOptions, ByVal GetPoster As Boolean) As MediaContainers.MainDetails
            If String.IsNullOrEmpty(strID) OrElse Not Integer.TryParse(strID, 0) Then Return Nothing

            Dim nMovieSet As New MediaContainers.MainDetails

            Dim APIResult As Task(Of TMDbLib.Objects.Collections.Collection)
            Dim APIResultE As Task(Of TMDbLib.Objects.Collections.Collection)

            APIResult = Task.Run(Function() _TMDBApi.GetCollectionAsync(CInt(strID), _SpecialSettings.PrefLanguage))
            If _SpecialSettings.FallBackToEng Then
                APIResultE = Task.Run(Function() _TMDBApiE.GetCollectionAsync(CInt(strID)))
            Else
                APIResultE = APIResult
            End If

            If APIResult Is Nothing OrElse APIResultE Is Nothing Then
                Return Nothing
            End If

            Dim Result As TMDbLib.Objects.Collections.Collection = APIResult.Result
            Dim ResultE As TMDbLib.Objects.Collections.Collection = APIResultE.Result

            If (Result Is Nothing AndAlso Not _SpecialSettings.FallBackToEng) OrElse (Result Is Nothing AndAlso ResultE Is Nothing) OrElse
                (Not Result.Id > 0 AndAlso Not _SpecialSettings.FallBackToEng) OrElse (Not Result.Id > 0 AndAlso Not ResultE.Id > 0) Then
                logger.Warn(String.Format("[TMDB_Data] [Abort] No API result for TMDB Collection ID [{0}]", strID))
                Return Nothing
            End If

            nMovieSet.TMDB = Result.Id

            'Plot
            If tScrapeOptions.bMainPlot Then
                If Result.Overview Is Nothing OrElse (Result.Overview IsNot Nothing AndAlso String.IsNullOrEmpty(Result.Overview)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Overview IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.Overview) Then
                        'nMovieSet.Plot = MovieSetE.Overview
                        nMovieSet.Plot = ResultE.Overview
                    End If
                Else
                    'nMovieSet.Plot = MovieSet.Overview
                    nMovieSet.Plot = Result.Overview
                End If
            End If

            'Posters (only for SearchResult dialog, auto fallback to "en" by TMDB)
            If GetPoster Then
                If Result.PosterPath IsNot Nothing AndAlso Not String.IsNullOrEmpty(Result.PosterPath) Then
                    _sPoster = String.Concat(_TMDBApi.Config.Images.BaseUrl, "w92", Result.PosterPath)
                Else
                    _sPoster = String.Empty
                End If
            End If

            'Title
            If tScrapeOptions.bMainTitle Then
                If Result.Name Is Nothing OrElse (Result.Name IsNot Nothing AndAlso String.IsNullOrEmpty(Result.Name)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Name IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.Name) Then
                        'nMovieSet.Title = MovieSetE.Name
                        nMovieSet.Title = ResultE.Name
                    End If
                Else
                    'nMovieSet.Title = MovieSet.Name
                    nMovieSet.Title = Result.Name
                End If
            End If

            Return nMovieSet
        End Function

        Public Function GetInfo_TVEpisode(ByVal iShowID As Integer, ByVal strAired As String, ByVal tScrapeOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
            Dim nTVEpisode As New MediaContainers.MainDetails
            Dim ShowInfo As TMDbLib.Objects.TvShows.TvShow

            Dim showAPIResult As Task(Of TMDbLib.Objects.TvShows.TvShow)
            showAPIResult = Task.Run(Function() _TMDBApi.GetTvShowAsync(iShowID))

            ShowInfo = showAPIResult.Result

            For Each aSeason As TMDbLib.Objects.Search.SearchTvSeason In ShowInfo.Seasons
                Dim seasonAPIResult As Task(Of TMDbLib.Objects.TvShows.TvSeason)
                seasonAPIResult = Task.Run(Function() _TMDBApi.GetTvSeasonAsync(iShowID, aSeason.SeasonNumber, TMDbLib.Objects.TvShows.TvSeasonMethods.Credits Or TMDbLib.Objects.TvShows.TvSeasonMethods.ExternalIds))

                Dim SeasonInfo As TMDbLib.Objects.TvShows.TvSeason = seasonAPIResult.Result
                Dim EpisodeList As IEnumerable(Of TMDbLib.Objects.Search.TvSeasonEpisode) = SeasonInfo.Episodes.Where(Function(f) CBool(f.AirDate = CDate(strAired)))
                If EpisodeList IsNot Nothing AndAlso EpisodeList.Count = 1 Then
                    Return GetInfo_TVEpisode(iShowID, EpisodeList(0).SeasonNumber, EpisodeList(0).EpisodeNumber, tScrapeOptions)
                ElseIf EpisodeList.Count > 0 Then
                    Return Nothing
                End If
            Next

            Return Nothing
        End Function

        Public Function GetInfo_TVEpisode(ByVal iShowID As Integer, ByVal iSeason As Integer, ByVal iEpisode As Integer, ByVal tScrapeOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
            Dim APIResult As Task(Of TMDbLib.Objects.TvShows.TvEpisode)
            APIResult = Task.Run(Function() _TMDBApi.GetTvEpisodeAsync(iShowID, iSeason, iEpisode, TMDbLib.Objects.TvShows.TvEpisodeMethods.Credits Or TMDbLib.Objects.TvShows.TvEpisodeMethods.ExternalIds))

            If APIResult IsNot Nothing AndAlso APIResult.Exception Is Nothing AndAlso APIResult.Result IsNot Nothing Then
                Dim EpisodeInfo As TMDbLib.Objects.TvShows.TvEpisode = APIResult.Result

                If EpisodeInfo Is Nothing OrElse EpisodeInfo.Id Is Nothing OrElse Not EpisodeInfo.Id > 0 Then
                    logger.Error(String.Format("Can't scrape or episode not found: tmdbID={0}, Season{1}, Episode{2}", iShowID, iSeason, iEpisode))
                    Return Nothing
                End If

                Dim nEpisode As MediaContainers.MainDetails = GetInfo_TVEpisode(EpisodeInfo, tScrapeOptions)
                Return nEpisode
            Else
                logger.Error(String.Format("Can't scrape or episode not found: tmdbID={0}, Season{1}, Episode{2}", iShowID, iSeason, iEpisode))
                Return Nothing
            End If
        End Function

        Public Function GetInfo_TVEpisode(ByRef tEpisodeInfo As TMDbLib.Objects.TvShows.TvEpisode, ByVal tScrapeOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
            Dim nTVEpisode As New MediaContainers.MainDetails

            nTVEpisode.Scrapersource = "TMDB"

            'IDs
            nTVEpisode.TMDB = CInt(tEpisodeInfo.Id)
            If tEpisodeInfo.ExternalIds IsNot Nothing AndAlso tEpisodeInfo.ExternalIds.TvdbId IsNot Nothing Then nTVEpisode.TVDB = CInt(tEpisodeInfo.ExternalIds.TvdbId)
            If tEpisodeInfo.ExternalIds IsNot Nothing AndAlso tEpisodeInfo.ExternalIds.ImdbId IsNot Nothing Then nTVEpisode.IMDB = tEpisodeInfo.ExternalIds.ImdbId

            'Episode # Standard
            If tEpisodeInfo.EpisodeNumber >= 0 Then
                nTVEpisode.Episode = tEpisodeInfo.EpisodeNumber
            End If

            'Season # Standard
            If tEpisodeInfo.SeasonNumber >= 0 Then
                nTVEpisode.Season = CInt(tEpisodeInfo.SeasonNumber)
            End If

            'Cast (Actors)
            If tScrapeOptions.bEpisodeActors Then
                If tEpisodeInfo.Credits IsNot Nothing AndAlso tEpisodeInfo.Credits.Cast IsNot Nothing Then
                    For Each aCast As TMDbLib.Objects.TvShows.Cast In tEpisodeInfo.Credits.Cast
                        nTVEpisode.Actors.Add(New MediaContainers.Person With {.Name = aCast.Name,
                                                                           .Role = aCast.Character,
                                                                           .URLOriginal = If(Not String.IsNullOrEmpty(aCast.ProfilePath), String.Concat(_TMDBApi.Config.Images.BaseUrl, "original", aCast.ProfilePath), String.Empty),
                                                                           .TMDB = CStr(aCast.Id)})
                    Next
                End If
            End If

            'Aired
            If tScrapeOptions.bEpisodeAired Then
                If tEpisodeInfo.AirDate IsNot Nothing Then
                    Dim ScrapedDate As String = CStr(tEpisodeInfo.AirDate)
                    If Not String.IsNullOrEmpty(ScrapedDate) AndAlso Not ScrapedDate = "00:00:00" Then
                        Dim RelDate As Date
                        If Date.TryParse(ScrapedDate, RelDate) Then
                            'always save date in same date format not depending on users language setting!
                            nTVEpisode.Aired = RelDate.ToString("yyyy-MM-dd")
                        Else
                            nTVEpisode.Aired = ScrapedDate
                        End If
                    End If
                End If
            End If

            'Director / Writer
            If tScrapeOptions.bEpisodeCredits OrElse tScrapeOptions.bEpisodeDirectors Then
                If tEpisodeInfo.Credits IsNot Nothing AndAlso tEpisodeInfo.Credits.Crew IsNot Nothing Then
                    For Each aCrew As TMDbLib.Objects.General.Crew In tEpisodeInfo.Credits.Crew
                        If tScrapeOptions.bEpisodeCredits AndAlso aCrew.Department = "Writing" AndAlso (aCrew.Job = "Author" OrElse aCrew.Job = "Screenplay" OrElse aCrew.Job = "Writer") Then
                            nTVEpisode.Credits.Add(aCrew.Name)
                        End If
                        If tScrapeOptions.bEpisodeDirectors AndAlso aCrew.Department = "Directing" AndAlso aCrew.Job = "Director" Then
                            nTVEpisode.Directors.Add(aCrew.Name)
                        End If
                    Next
                End If
            End If

            'Guest Stars
            If tScrapeOptions.bEpisodeGuestStars Then
                If tEpisodeInfo.GuestStars IsNot Nothing Then
                    For Each aCast As TMDbLib.Objects.TvShows.Cast In tEpisodeInfo.GuestStars
                        nTVEpisode.GuestStars.Add(New MediaContainers.Person With {.Name = aCast.Name,
                                                                           .Role = aCast.Character,
                                                                           .URLOriginal = If(Not String.IsNullOrEmpty(aCast.ProfilePath), String.Concat(_TMDBApi.Config.Images.BaseUrl, "original", aCast.ProfilePath), String.Empty),
                                                                           .TMDB = CStr(aCast.Id)})
                    Next
                End If
            End If

            'Plot
            If tScrapeOptions.bEpisodePlot Then
                If tEpisodeInfo.Overview IsNot Nothing Then
                    nTVEpisode.Plot = tEpisodeInfo.Overview
                End If
            End If

            'Rating
            If tScrapeOptions.bEpisodeRating Then
                nTVEpisode.Rating = CStr(tEpisodeInfo.VoteAverage)
                nTVEpisode.Votes = CStr(tEpisodeInfo.VoteCount)
            End If

            'ThumbPoster
            If tEpisodeInfo.StillPath IsNot Nothing Then
                nTVEpisode.ThumbPoster.URLOriginal = _TMDBApi.Config.Images.BaseUrl & "original" & tEpisodeInfo.StillPath
                nTVEpisode.ThumbPoster.URLThumb = _TMDBApi.Config.Images.BaseUrl & "w185" & tEpisodeInfo.StillPath
            End If

            'Title
            If tScrapeOptions.bEpisodeTitle Then
                If tEpisodeInfo.Name IsNot Nothing Then
                    nTVEpisode.Title = tEpisodeInfo.Name
                End If
            End If

            Return nTVEpisode
        End Function

        Public Sub GetInfo_TVSeason(ByRef tTVShow As MediaContainers.MainDetails, ByVal iShowID As Integer, ByVal iSeason As Integer, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions)
            Dim nSeason As New MediaContainers.MainDetails

            Dim APIResult As Task(Of TMDbLib.Objects.TvShows.TvSeason)
            APIResult = Task.Run(Function() _TMDBApi.GetTvSeasonAsync(iShowID, iSeason, TMDbLib.Objects.TvShows.TvSeasonMethods.Credits Or TMDbLib.Objects.TvShows.TvSeasonMethods.ExternalIds))

            If APIResult IsNot Nothing AndAlso APIResult.Exception Is Nothing AndAlso APIResult.Result IsNot Nothing Then
                Dim SeasonInfo As TMDbLib.Objects.TvShows.TvSeason = APIResult.Result

                nSeason.TMDB = CInt(SeasonInfo.Id)
                If SeasonInfo.ExternalIds IsNot Nothing AndAlso SeasonInfo.ExternalIds.TvdbId IsNot Nothing Then nSeason.TVDB = CInt(SeasonInfo.ExternalIds.TvdbId)

                If tScrapeModifiers.withSeasons Then

                    'Aired
                    If tScrapeOptions.bSeasonAired Then
                        If SeasonInfo.AirDate IsNot Nothing Then
                            Dim ScrapedDate As String = CStr(SeasonInfo.AirDate)
                            If Not String.IsNullOrEmpty(ScrapedDate) Then
                                Dim RelDate As Date
                                If Date.TryParse(ScrapedDate, RelDate) Then
                                    'always save date in same date format not depending on users language setting!
                                    nSeason.Aired = RelDate.ToString("yyyy-MM-dd")
                                Else
                                    nSeason.Aired = ScrapedDate
                                End If
                            End If
                        End If
                    End If

                    'Plot
                    If tScrapeOptions.bSeasonPlot Then
                        If SeasonInfo.Overview IsNot Nothing Then
                            nSeason.Plot = SeasonInfo.Overview
                        End If
                    End If

                    'Season #
                    If SeasonInfo.SeasonNumber >= 0 Then
                        nSeason.Season = SeasonInfo.SeasonNumber
                    End If

                    'Title
                    If SeasonInfo.Name IsNot Nothing Then
                        nSeason.Title = SeasonInfo.Name
                    End If

                    tTVShow.KnownSeasons.Add(nSeason)
                End If

                If tScrapeModifiers.withEpisodes AndAlso SeasonInfo.Episodes IsNot Nothing Then
                    For Each aEpisode As TMDbLib.Objects.Search.TvSeasonEpisode In SeasonInfo.Episodes
                        tTVShow.KnownEpisodes.Add(GetInfo_TVEpisode(iShowID, aEpisode.SeasonNumber, aEpisode.EpisodeNumber, tScrapeOptions))
                    Next
                End If
            Else
                logger.Error(String.Format("Can't scrape or season not found: ShowID={0}, Season={1}", iShowID, iSeason))
            End If
        End Sub

        Public Function GetInfo_TVSeason(ByVal iShowID As Integer, ByVal iSeason As Integer, ByVal tScrapeOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
            Dim APIResult As Task(Of TMDbLib.Objects.TvShows.TvSeason)
            APIResult = Task.Run(Function() _TMDBApi.GetTvSeasonAsync(iShowID, iSeason, TMDbLib.Objects.TvShows.TvSeasonMethods.Credits Or TMDbLib.Objects.TvShows.TvSeasonMethods.ExternalIds))

            If APIResult IsNot Nothing AndAlso APIResult.Exception Is Nothing AndAlso APIResult.Result IsNot Nothing Then
                Dim SeasonInfo As TMDbLib.Objects.TvShows.TvSeason = APIResult.Result

                If SeasonInfo Is Nothing OrElse SeasonInfo.Id Is Nothing OrElse Not SeasonInfo.Id > 0 Then
                    logger.Error(String.Format("Can't scrape or season not found: tmdbID={0}, Season={1}", iShowID, iSeason))
                    Return Nothing
                End If

                Dim nTVSeason As MediaContainers.MainDetails = GetInfo_TVSeason(SeasonInfo, tScrapeOptions)
                Return nTVSeason
            Else
                logger.Error(String.Format("Can't scrape or season not found: tmdbID={0}, Season={1}", iShowID, iSeason))
                Return Nothing
            End If
        End Function

        Public Function GetInfo_TVSeason(ByRef tSeasonInfo As TMDbLib.Objects.TvShows.TvSeason, ByVal tScrapeOptions As Structures.ScrapeOptions) As MediaContainers.MainDetails
            Dim nTVSeason As New MediaContainers.MainDetails

            nTVSeason.Scrapersource = "TMDB"

            'IDs
            nTVSeason.TMDB = CInt(tSeasonInfo.Id)
            If tSeasonInfo.ExternalIds IsNot Nothing AndAlso tSeasonInfo.ExternalIds.TvdbId IsNot Nothing Then nTVSeason.TVDB = CInt(tSeasonInfo.ExternalIds.TvdbId)

            'Season #
            If tSeasonInfo.SeasonNumber >= 0 Then
                nTVSeason.Season = tSeasonInfo.SeasonNumber
            End If

            'Aired
            If tScrapeOptions.bSeasonAired Then
                If tSeasonInfo.AirDate IsNot Nothing Then
                    Dim ScrapedDate As String = CStr(tSeasonInfo.AirDate)
                    If Not String.IsNullOrEmpty(ScrapedDate) Then
                        Dim RelDate As Date
                        If Date.TryParse(ScrapedDate, RelDate) Then
                            'always save date in same date format not depending on users language setting!
                            nTVSeason.Aired = RelDate.ToString("yyyy-MM-dd")
                        Else
                            nTVSeason.Aired = ScrapedDate
                        End If
                    End If
                End If
            End If

            'Plot
            If tScrapeOptions.bSeasonPlot Then
                If tSeasonInfo.Overview IsNot Nothing Then
                    nTVSeason.Plot = tSeasonInfo.Overview
                End If
            End If

            'Title
            If tScrapeOptions.bSeasonTitle Then
                If tSeasonInfo.Name IsNot Nothing Then
                    nTVSeason.Title = tSeasonInfo.Name
                End If
            End If

            Return nTVSeason
        End Function
        ''' <summary>
        '''  Scrape TV Show details from TMDB
        ''' </summary>
        ''' <param name="iTMDB">TMDB ID of tv show to be scraped</param>
        ''' <param name="GetPoster">Scrape posters for the movie?</param>
        ''' <returns>True: success, false: no success</returns>
        Public Function GetInfo_TVShow(ByVal iTMDB As Integer, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions, ByVal GetPoster As Boolean) As MediaContainers.MainDetails
            Dim nTVShow As New MediaContainers.MainDetails

            Dim APIResult As Task(Of TMDbLib.Objects.TvShows.TvShow)
            Dim APIResultE As Task(Of TMDbLib.Objects.TvShows.TvShow)

            'search tvshow by TMDB ID
            APIResult = Task.Run(Function() _TMDBApi.GetTvShowAsync(iTMDB, TMDbLib.Objects.TvShows.TvShowMethods.ContentRatings Or TMDbLib.Objects.TvShows.TvShowMethods.Credits Or TMDbLib.Objects.TvShows.TvShowMethods.ExternalIds))
            If _SpecialSettings.FallBackToEng Then
                APIResultE = Task.Run(Function() _TMDBApiE.GetTvShowAsync(iTMDB, TMDbLib.Objects.TvShows.TvShowMethods.ContentRatings Or TMDbLib.Objects.TvShows.TvShowMethods.Credits Or TMDbLib.Objects.TvShows.TvShowMethods.ExternalIds))
            Else
                APIResultE = APIResult
            End If

            If APIResult Is Nothing OrElse APIResultE Is Nothing Then
                Return Nothing
            End If

            Dim Result As TMDbLib.Objects.TvShows.TvShow = APIResult.Result
            Dim ResultE As TMDbLib.Objects.TvShows.TvShow = APIResultE.Result

            If (Result Is Nothing AndAlso Not _SpecialSettings.FallBackToEng) OrElse (Result Is Nothing AndAlso ResultE Is Nothing) OrElse
                (Not Result.Id > 0 AndAlso Not _SpecialSettings.FallBackToEng) OrElse (Not Result.Id > 0 AndAlso Not ResultE.Id > 0) Then
                logger.Error(String.Format("Can't scrape or tv show not found: [{0}]", iTMDB))
                Return Nothing
            End If

            nTVShow.Scrapersource = "TMDB"

            'IDs
            nTVShow.TMDB = Result.Id
            If Result.ExternalIds.TvdbId IsNot Nothing Then nTVShow.TVDB = CInt(Result.ExternalIds.TvdbId)
            If Result.ExternalIds.ImdbId IsNot Nothing Then nTVShow.IMDB = Result.ExternalIds.ImdbId

            'Actors
            If tScrapeOptions.bMainActors Then
                If Result.Credits IsNot Nothing AndAlso Result.Credits.Cast IsNot Nothing Then
                    For Each aCast As TMDbLib.Objects.TvShows.Cast In Result.Credits.Cast
                        nTVShow.Actors.Add(New MediaContainers.Person With {.Name = aCast.Name,
                                                                           .Role = aCast.Character,
                                                                           .URLOriginal = If(Not String.IsNullOrEmpty(aCast.ProfilePath), String.Concat(_TMDBApi.Config.Images.BaseUrl, "original", aCast.ProfilePath), String.Empty),
                                                                           .TMDB = CStr(aCast.Id)})
                    Next
                End If
            End If

            'Certifications
            If tScrapeOptions.bMainCertifications Then
                If Result.ContentRatings IsNot Nothing AndAlso Result.ContentRatings.Results IsNot Nothing AndAlso Result.ContentRatings.Results.Count > 0 Then
                    For Each aCountry In Result.ContentRatings.Results
                        If Not String.IsNullOrEmpty(aCountry.Rating) Then
                            Dim CertificationLanguage = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.abbreviation = aCountry.Iso_3166_1.ToLower)
                            If CertificationLanguage IsNot Nothing AndAlso CertificationLanguage.name IsNot Nothing AndAlso Not String.IsNullOrEmpty(CertificationLanguage.name) Then
                                nTVShow.Certifications.Add(String.Concat(CertificationLanguage.name, ":", aCountry.Rating))
                            Else
                                logger.Warn("Unhandled certification language encountered: {0}", aCountry.Iso_3166_1.ToLower)
                            End If
                        End If
                    Next
                End If
            End If

            'Countries 'TODO: Change from OriginCountry to ProductionCountries (not yet supported by API)
            'If FilteredOptions.bMainCountry Then
            '    If Show.OriginCountry IsNot Nothing AndAlso Show.OriginCountry.Count > 0 Then
            '        For Each aCountry As String In Show.OriginCountry
            '            nShow.Countries.Add(aCountry)
            '        Next
            '    End If
            'End If

            'Creators
            If tScrapeOptions.bMainCreators Then
                If Result.CreatedBy IsNot Nothing Then
                    For Each aCreator As TMDbLib.Objects.TvShows.CreatedBy In Result.CreatedBy
                        nTVShow.Creators.Add(aCreator.Name)
                    Next
                End If
            End If

            'Genres
            If tScrapeOptions.bMainGenres Then
                Dim aGenres As List(Of TMDbLib.Objects.General.Genre) = Nothing
                If Result.Genres Is Nothing OrElse (Result.Genres IsNot Nothing AndAlso Result.Genres.Count = 0) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Genres IsNot Nothing AndAlso ResultE.Genres.Count > 0 Then
                        aGenres = ResultE.Genres
                    End If
                Else
                    aGenres = Result.Genres
                End If

                If aGenres IsNot Nothing Then
                    For Each tGenre As TMDbLib.Objects.General.Genre In aGenres
                        nTVShow.Genres.Add(tGenre.Name)
                    Next
                End If
            End If

            'OriginalTitle
            If tScrapeOptions.bMainOriginalTitle Then
                If Result.OriginalName Is Nothing OrElse (Result.OriginalName IsNot Nothing AndAlso String.IsNullOrEmpty(Result.OriginalName)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.OriginalName IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.OriginalName) Then
                        nTVShow.OriginalTitle = ResultE.OriginalName
                    End If
                Else
                    nTVShow.OriginalTitle = ResultE.OriginalName
                End If
            End If

            'Plot
            If tScrapeOptions.bMainPlot Then
                If Result.Overview Is Nothing OrElse (Result.Overview IsNot Nothing AndAlso String.IsNullOrEmpty(Result.Overview)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Overview IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.Overview) Then
                        nTVShow.Plot = ResultE.Overview
                    End If
                Else
                    nTVShow.Plot = Result.Overview
                End If
            End If

            'Posters (only for SearchResult dialog, auto fallback to "en" by TMDB)
            If GetPoster Then
                If Result.PosterPath IsNot Nothing AndAlso Not String.IsNullOrEmpty(Result.PosterPath) Then
                    _sPoster = String.Concat(_TMDBApi.Config.Images.BaseUrl, "w92", Result.PosterPath)
                Else
                    _sPoster = String.Empty
                End If
            End If

            'Premiered
            If tScrapeOptions.bMainPremiered Then
                Dim ScrapedDate As String = String.Empty
                If Result.FirstAirDate Is Nothing OrElse (Result.FirstAirDate IsNot Nothing AndAlso String.IsNullOrEmpty(CStr(Result.FirstAirDate))) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.FirstAirDate IsNot Nothing AndAlso Not String.IsNullOrEmpty(CStr(ResultE.FirstAirDate)) Then
                        ScrapedDate = CStr(ResultE.FirstAirDate)
                    End If
                Else
                    ScrapedDate = CStr(Result.FirstAirDate)
                End If
                If Not String.IsNullOrEmpty(ScrapedDate) Then
                    Dim RelDate As Date
                    If Date.TryParse(ScrapedDate, RelDate) Then
                        'always save date in same date format not depending on users language setting!
                        nTVShow.Premiered = RelDate.ToString("yyyy-MM-dd")
                    Else
                        nTVShow.Premiered = ScrapedDate
                    End If
                End If
            End If

            'Rating
            If tScrapeOptions.bMainRating Then
                nTVShow.Rating = CStr(Result.VoteAverage)
                nTVShow.Votes = CStr(Result.VoteCount)
            End If

            'Runtime
            If tScrapeOptions.bMainRuntime Then
                If Result.EpisodeRunTime Is Nothing OrElse Result.EpisodeRunTime.Count = 0 Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.EpisodeRunTime IsNot Nothing AndAlso ResultE.EpisodeRunTime.Count > 0 Then
                        nTVShow.Runtime = CStr(ResultE.EpisodeRunTime.Item(0))
                    End If
                Else
                    nTVShow.Runtime = CStr(Result.EpisodeRunTime.Item(0))
                End If
            End If

            'Status
            If tScrapeOptions.bMainStatus Then
                If Result.Status Is Nothing OrElse (Result.Status IsNot Nothing AndAlso String.IsNullOrEmpty(Result.Status)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Status IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.Status) Then
                        nTVShow.Status = ResultE.Status
                    End If
                Else
                    nTVShow.Status = Result.Status
                End If
            End If

            'Studios
            If tScrapeOptions.bMainStudios Then
                If Result.Networks IsNot Nothing AndAlso Result.Networks.Count > 0 Then
                    For Each aStudio In Result.Networks
                        nTVShow.Studios.Add(aStudio.Name)
                    Next
                End If
            End If

            'Title
            If tScrapeOptions.bMainTitle Then
                If Result.Name Is Nothing OrElse (Result.Name IsNot Nothing AndAlso String.IsNullOrEmpty(Result.Name)) Then
                    If _SpecialSettings.FallBackToEng AndAlso ResultE.Name IsNot Nothing AndAlso Not String.IsNullOrEmpty(ResultE.Name) Then
                        nTVShow.Title = ResultE.Name
                    End If
                Else
                    nTVShow.Title = Result.Name
                End If
            End If

            ''Trailer
            'If Options.bTrailer Then
            '    Dim aTrailers As List(Of TMDbLib.Objects.TvShows.Video) = Nothing
            '    If Show.Videos Is Nothing OrElse (Show.Videos IsNot Nothing AndAlso Show.Videos.Results.Count = 0) Then
            '        If _MySettings.FallBackEng AndAlso ShowE.Videos IsNot Nothing AndAlso ShowE.Videos.Results.Count > 0 Then
            '            aTrailers = ShowE.Videos.Results
            '        End If
            '    Else
            '        aTrailers = Show.Videos.Results
            '    End If

            '    If aTrailers IsNot Nothing AndAlso aTrailers IsNot Nothing AndAlso aTrailers.Count > 0 Then
            '        nShow.Trailer = "http://www.youtube.com/watch?hd=1&v=" & aTrailers.Item(0).Key
            '    End If
            'End If

            'Seasons and Episodes
            If tScrapeModifiers.withEpisodes OrElse tScrapeModifiers.withSeasons Then
                For Each aSeason As TMDbLib.Objects.Search.SearchTvSeason In Result.Seasons
                    GetInfo_TVSeason(nTVShow, Result.Id, aSeason.SeasonNumber, tScrapeModifiers, tScrapeOptions)
                Next
            End If

            Return nTVShow
        End Function

        Public Function GetTMDBbyTVDB(ByVal iTVDB As Integer) As Integer
            Dim iTMDB As Integer = -1

            Try
                Dim APIResult As Task(Of TMDbLib.Objects.Find.FindContainer)
                APIResult = Task.Run(Function() _TMDBApi.FindAsync(TMDbLib.Objects.Find.FindExternalSource.TvDb, CStr(iTVDB)))

                If APIResult IsNot Nothing AndAlso APIResult.Exception Is Nothing AndAlso APIResult.Result IsNot Nothing AndAlso
                    APIResult.Result.TvResults IsNot Nothing AndAlso APIResult.Result.TvResults.Count > 0 Then
                    iTMDB = APIResult.Result.TvResults.Item(0).Id
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            Return iTMDB
        End Function

        Public Function ScrapeMovie(ByVal strID As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
            Dim nAddonResult As New Interfaces.AddonResult
            nAddonResult.ScraperResult_Data = GetInfo_Movie(strID, tScrapeOptions, False)
            nAddonResult.ScraperResult_ImageContainer = GetImages_Movie_MovieSet(strID, tScrapeModifiers, Enums.ContentType.Movie)
            Return nAddonResult
        End Function

        Public Function ScrapeMovieset(ByVal strID As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
            Dim nAddonResult As New Interfaces.AddonResult
            nAddonResult.ScraperResult_Data = GetInfo_MovieSet(strID, tScrapeOptions, False)
            nAddonResult.ScraperResult_ImageContainer = GetImages_Movie_MovieSet(strID, tScrapeModifiers, Enums.ContentType.MovieSet)
            Return nAddonResult
        End Function

        Public Function ScrapeTVEpisode(ByVal iShowID As Integer, ByVal strAired As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
            Dim nAddonResult As New Interfaces.AddonResult
            nAddonResult.ScraperResult_Data = GetInfo_TVEpisode(iShowID, strAired, tScrapeOptions)
            nAddonResult.ScraperResult_ImageContainer = GetImages_TVEpisode(iShowID, nAddonResult.ScraperResult_Data.Season, nAddonResult.ScraperResult_Data.Episode, tScrapeModifiers)
            Return nAddonResult
        End Function

        Public Function ScrapeTVEpisode(ByVal iShowID As Integer, ByVal iSeason As Integer, iEpisode As Integer, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
            Dim nAddonResult As New Interfaces.AddonResult
            nAddonResult.ScraperResult_Data = GetInfo_TVEpisode(iShowID, iSeason, iEpisode, tScrapeOptions)
            nAddonResult.ScraperResult_ImageContainer = GetImages_TVEpisode(iShowID, iSeason, iEpisode, tScrapeModifiers)
            Return nAddonResult
        End Function

        Public Function ScrapeTVSeason(ByVal iShowID As Integer, ByVal iSeason As Integer, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
            Dim nAddonResult As New Interfaces.AddonResult
            nAddonResult.ScraperResult_Data = GetInfo_TVSeason(iShowID, iSeason, tScrapeOptions)
            nAddonResult.ScraperResult_ImageContainer = GetImages_TVShow(iShowID, tScrapeModifiers)
            Return nAddonResult
        End Function

        Public Function ScrapeTVShow(ByVal iShowID As Integer, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
            Dim nAddonResult As New Interfaces.AddonResult
            nAddonResult.ScraperResult_Data = GetInfo_TVShow(iShowID, tScrapeModifiers, tScrapeOptions, False)
            nAddonResult.ScraperResult_ImageContainer = GetImages_TVShow(iShowID, tScrapeModifiers)
            Return nAddonResult
        End Function

        Public Function SearchMovie(ByVal strTitle As String, ByVal strYear As String) As List(Of MediaContainers.MainDetails)
            If String.IsNullOrEmpty(strTitle) Then Return New List(Of MediaContainers.MainDetails)

            Dim nSearchResults As New List(Of MediaContainers.MainDetails)
            Dim Page As Integer = 1
            Dim Movies As TMDbLib.Objects.General.SearchContainer(Of TMDbLib.Objects.Search.SearchMovie)
            Dim TotP As Integer
            Dim aE As Boolean
            Dim iYear As Integer = 0

            Integer.TryParse(strYear, iYear)

            Dim APIResult As Task(Of TMDbLib.Objects.General.SearchContainer(Of TMDbLib.Objects.Search.SearchMovie))
            APIResult = Task.Run(Function() _TMDBApi.SearchMovieAsync(strTitle, Page, _SpecialSettings.IncludeAdultItems, iYear))

            Movies = APIResult.Result

            If Movies.TotalResults = 0 AndAlso _SpecialSettings.FallBackToEng Then
                APIResult = Task.Run(Function() _TMDBApiE.SearchMovieAsync(strTitle, Page, _SpecialSettings.IncludeAdultItems, iYear))
                Movies = APIResult.Result
                aE = True
            End If

            'try -1 year if no search result was found
            If Movies.TotalResults = 0 AndAlso iYear > 0 AndAlso _SpecialSettings.SearchDeviant Then
                APIResult = Task.Run(Function() _TMDBApiE.SearchMovieAsync(strTitle, Page, _SpecialSettings.IncludeAdultItems, iYear - 1))
                Movies = APIResult.Result

                If Movies.TotalResults = 0 AndAlso _SpecialSettings.FallBackToEng Then
                    APIResult = Task.Run(Function() _TMDBApiE.SearchMovieAsync(strTitle, Page, _SpecialSettings.IncludeAdultItems, iYear - 1))
                    Movies = APIResult.Result
                    aE = True
                End If

                'still no search result, try +1 year
                If Movies.TotalResults = 0 Then
                    APIResult = Task.Run(Function() _TMDBApiE.SearchMovieAsync(strTitle, Page, _SpecialSettings.IncludeAdultItems, iYear + 1))
                    Movies = APIResult.Result

                    If Movies.TotalResults = 0 AndAlso _SpecialSettings.FallBackToEng Then
                        APIResult = Task.Run(Function() _TMDBApiE.SearchMovieAsync(strTitle, Page, _SpecialSettings.IncludeAdultItems, iYear + 1))
                        Movies = APIResult.Result
                        aE = True
                    End If
                End If
            End If

            If Movies.TotalResults > 0 Then
                TotP = Movies.TotalPages
                While Page <= TotP AndAlso Page <= 3
                    If Movies.Results IsNot Nothing Then
                        For Each aMovie In Movies.Results
                            Dim tOriginalTitle As String = String.Empty
                            Dim tPlot As String = String.Empty
                            Dim tThumbPoster As MediaContainers.Image = New MediaContainers.Image
                            Dim tTitle As String = String.Empty
                            Dim tYear As String = String.Empty

                            If aMovie.OriginalTitle IsNot Nothing Then tOriginalTitle = aMovie.OriginalTitle
                            If aMovie.Overview IsNot Nothing Then tPlot = aMovie.Overview
                            If aMovie.PosterPath IsNot Nothing Then
                                tThumbPoster.URLOriginal = _TMDBApi.Config.Images.BaseUrl & "original" & aMovie.PosterPath
                                tThumbPoster.URLThumb = _TMDBApi.Config.Images.BaseUrl & "w185" & aMovie.PosterPath
                            End If
                            If aMovie.ReleaseDate IsNot Nothing AndAlso Not String.IsNullOrEmpty(CStr(aMovie.ReleaseDate)) Then tYear = CStr(aMovie.ReleaseDate.Value.Year)
                            If aMovie.Title IsNot Nothing Then tTitle = aMovie.Title

                            Dim lNewMovie As MediaContainers.MainDetails = New MediaContainers.MainDetails With {.OriginalTitle = tOriginalTitle,
                                                                                                     .Plot = tPlot,
                                                                                                     .Title = tTitle,
                                                                                                     .ThumbPoster = tThumbPoster,
                                                                                                     .TMDB = aMovie.Id,
                                                                                                     .Year = tYear}
                            nSearchResults.Add(lNewMovie)
                        Next
                    End If
                    Page = Page + 1
                    If aE Then
                        APIResult = Task.Run(Function() _TMDBApiE.SearchMovieAsync(strTitle, Page, _SpecialSettings.IncludeAdultItems, iYear))
                        Movies = APIResult.Result
                    Else
                        APIResult = Task.Run(Function() _TMDBApi.SearchMovieAsync(strTitle, Page, _SpecialSettings.IncludeAdultItems, iYear))
                        Movies = APIResult.Result
                    End If
                End While
            End If

            Return nSearchResults
        End Function

        Public Function SearchMovieSet(ByVal strTitle As String) As List(Of MediaContainers.MainDetails)
            If String.IsNullOrEmpty(strTitle) Then Return New List(Of MediaContainers.MainDetails)

            Dim nSearchResults As New List(Of MediaContainers.MainDetails)
            Dim Page As Integer = 1
            Dim MovieSets As TMDbLib.Objects.General.SearchContainer(Of TMDbLib.Objects.Search.SearchCollection)
            Dim TotP As Integer
            Dim aE As Boolean

            Dim APIResult As Task(Of TMDbLib.Objects.General.SearchContainer(Of TMDbLib.Objects.Search.SearchCollection))
            APIResult = Task.Run(Function() _TMDBApi.SearchCollectionAsync(strTitle, Page))

            MovieSets = APIResult.Result

            If MovieSets.TotalResults = 0 AndAlso _SpecialSettings.FallBackToEng Then
                APIResult = Task.Run(Function() _TMDBApiE.SearchCollectionAsync(strTitle, Page))
                MovieSets = APIResult.Result
                aE = True
            End If

            If MovieSets.TotalResults > 0 Then
                Dim t2 As String = String.Empty
                TotP = MovieSets.TotalPages
                While Page <= TotP AndAlso Page <= 3
                    If MovieSets.Results IsNot Nothing Then
                        For Each aMovieSet In MovieSets.Results
                            If aMovieSet.Name IsNot Nothing AndAlso Not String.IsNullOrEmpty(aMovieSet.Name) Then
                                t2 = aMovieSet.Name
                            End If
                            nSearchResults.Add(New MediaContainers.MainDetails With {
                                          .TMDB = aMovieSet.Id,
                                          .Title = t2})
                        Next
                    End If
                    Page = Page + 1
                    If aE Then
                        APIResult = Task.Run(Function() _TMDBApiE.SearchCollectionAsync(strTitle, Page))
                        MovieSets = APIResult.Result
                    Else
                        APIResult = Task.Run(Function() _TMDBApi.SearchCollectionAsync(strTitle, Page))
                        MovieSets = APIResult.Result
                    End If
                End While
            End If

            Return nSearchResults
        End Function

        Public Function SearchTVShow(ByVal strTitle As String) As List(Of MediaContainers.MainDetails)
            If String.IsNullOrEmpty(strTitle) Then Return New List(Of MediaContainers.MainDetails)

            Dim nSearchResults As New List(Of MediaContainers.MainDetails)
            Dim Page As Integer = 1
            Dim Shows As TMDbLib.Objects.General.SearchContainer(Of TMDbLib.Objects.Search.SearchTv)
            Dim TotP As Integer
            Dim aE As Boolean

            Dim APIResult As Task(Of TMDbLib.Objects.General.SearchContainer(Of TMDbLib.Objects.Search.SearchTv))
            APIResult = Task.Run(Function() _TMDBApi.SearchTvShowAsync(strTitle, Page))

            Shows = APIResult.Result

            If Shows.TotalResults = 0 AndAlso _SpecialSettings.FallBackToEng Then
                APIResult = Task.Run(Function() _TMDBApiE.SearchTvShowAsync(strTitle, Page))
                Shows = APIResult.Result
                aE = True
            End If

            If Shows.TotalResults > 0 Then
                Dim t1 As String = String.Empty
                Dim t2 As String = String.Empty
                TotP = Shows.TotalPages
                While Page <= TotP AndAlso Page <= 3
                    If Shows.Results IsNot Nothing Then
                        For Each aShow In Shows.Results
                            If aShow.Name Is Nothing OrElse (aShow.Name IsNot Nothing AndAlso String.IsNullOrEmpty(aShow.Name)) Then
                                If aShow.OriginalName IsNot Nothing AndAlso Not String.IsNullOrEmpty(aShow.OriginalName) Then
                                    t1 = aShow.OriginalName
                                End If
                            Else
                                t1 = aShow.Name
                            End If
                            If aShow.FirstAirDate IsNot Nothing AndAlso Not String.IsNullOrEmpty(CStr(aShow.FirstAirDate)) Then
                                t2 = CStr(aShow.FirstAirDate.Value.Year)
                            End If
                            Dim lNewShow As MediaContainers.MainDetails = New MediaContainers.MainDetails With {.Title = t1, .Premiered = t2}
                            lNewShow.TMDB = aShow.Id
                            nSearchResults.Add(lNewShow)
                        Next
                    End If
                    Page = Page + 1
                    If aE Then
                        APIResult = Task.Run(Function() _TMDBApiE.SearchTvShowAsync(strTitle, Page))
                        Shows = APIResult.Result
                    Else
                        APIResult = Task.Run(Function() _TMDBApi.SearchTvShowAsync(strTitle, Page))
                        Shows = APIResult.Result
                    End If
                End While
            End If

            Return nSearchResults
        End Function

#End Region 'Methods

#Region "Nested Types"

#End Region 'Nested Types

    End Class

End Namespace

