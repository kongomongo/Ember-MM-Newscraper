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
Imports TraktApiSharp

Namespace TrakttvScraper

    Public Class Scraper

#Region "Fields"

        Shared logger As Logger = LogManager.GetCurrentClassLogger()
        Private _apiTrakt As New TraktClient("80a5418f493f058bc6fdfdc6d0a154731dea3fc628241e3dee29846c59f5d0f0",
                                             "e097b8c0b24ffddffb165b260166f9d7f7cd8e1617964bb51b393478772728e5")
        Private _SpecialSettings As Trakttv_Data.SpecialSettings
        Private _newTokenCreated As Boolean

#End Region 'Fields

#Region "Properties"

        ReadOnly Property AccessToken() As String
            Get
                Return _SpecialSettings.AccessToken
            End Get
        End Property

        ReadOnly Property NewTokenCreated() As Boolean
            Get
                Return _newTokenCreated
            End Get
        End Property

        ReadOnly Property RefreshToken() As String
            Get
                Return _SpecialSettings.RefreshToken
            End Get
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub New(ByRef tSpecialSettings As Trakttv_Data.SpecialSettings)
            _SpecialSettings = tSpecialSettings
            Try
                CreateAPI()
                tSpecialSettings.AccessToken = _SpecialSettings.AccessToken
                tSpecialSettings.CreatedAt = _SpecialSettings.CreatedAt
                tSpecialSettings.ExpiresInSeconds = _SpecialSettings.ExpiresInSeconds
                tSpecialSettings.RefreshToken = _SpecialSettings.RefreshToken
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End Sub

        Public Function CheckConnection() As Boolean
            If _apiTrakt.Authorization.IsExpired OrElse Not _apiTrakt.Authorization.IsValid Then
                CreateAPI()
            End If
            If Not _apiTrakt.Authorization.IsExpired AndAlso _apiTrakt.Authorization.IsValid Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Sub CreateAPI()
            'Default lifetime of an AccessToken is 90 days. So we set the default CreatedAt age to 91 days to get shure that the default value is to old and a new AccessToken has to be created.
            Dim dCreatedAt As Date = Date.Today.AddDays(-91)
            Dim iCreatedAt As Long = 0
            Dim iExpiresIn As Integer = 0

            Integer.TryParse(_SpecialSettings.ExpiresInSeconds, iExpiresIn)
            If Long.TryParse(_SpecialSettings.CreatedAt, iCreatedAt) Then
                dCreatedAt = Functions.ConvertFromUnixTimestamp(iCreatedAt)
            End If

            _apiTrakt.Authorization = Authentication.TraktAuthorization.CreateWith(dCreatedAt, _SpecialSettings.AccessToken, _SpecialSettings.RefreshToken)
            Dim CheckAuthentication = Task.Run(Function() _apiTrakt.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(True))
            While Not CheckAuthentication.IsCompleted
                Threading.Thread.Sleep(50)
            End While

            If _apiTrakt.Authorization.IsExpired OrElse Not _apiTrakt.Authorization.IsValid Then
                Dim strAuthUrl As String = _apiTrakt.OAuth.CreateAuthorizationUrl
                If Not String.IsNullOrEmpty(strAuthUrl) Then
                    Using dAuthorize As New frmAuthorize
                        If dAuthorize.ShowDialog(strAuthUrl) = DialogResult.OK Then
                            Dim APIResult = Task.Run(Function() _apiTrakt.OAuth.GetAuthorizationAsync(dAuthorize.Result))
                            While Not APIResult.IsCompleted
                                Threading.Thread.Sleep(50)
                            End While
                            If APIResult.Exception Is Nothing AndAlso APIResult.Result IsNot Nothing Then
                                _SpecialSettings.AccessToken = _apiTrakt.Authorization.AccessToken
                                _SpecialSettings.CreatedAt = Functions.ConvertToUnixTimestamp(_apiTrakt.Authorization.Created).ToString
                                _SpecialSettings.ExpiresInSeconds = _apiTrakt.Authorization.ExpiresInSeconds.ToString
                                _SpecialSettings.RefreshToken = _apiTrakt.Authorization.RefreshToken
                            End If
                            _newTokenCreated = True
                        End If
                    End Using
                End If
            ElseIf CheckAuthentication.Result.First Then
                'AccessToken has been refreshed with RefreshToken
                _SpecialSettings.AccessToken = _apiTrakt.Authorization.AccessToken
                _SpecialSettings.CreatedAt = Functions.ConvertToUnixTimestamp(_apiTrakt.Authorization.Created).ToString
                _SpecialSettings.ExpiresInSeconds = _apiTrakt.Authorization.ExpiresInSeconds.ToString
                _SpecialSettings.RefreshToken = _apiTrakt.Authorization.RefreshToken
                _newTokenCreated = True
            End If
        End Sub

        Public Async Function GetInfo_Movie(ByVal uintTraktID As Task(Of UInteger), ByVal tFilteredOptions As Structures.ScrapeOptions) As Task(Of MediaContainers.MainDetails)
            If uintTraktID.Result = 0 Then Return Nothing

            Dim nMovie As New MediaContainers.MainDetails
            nMovie.Scrapersource = "TRAKTTV"

            If CheckConnection() Then
                'Main Rating
                If tFilteredOptions.bMainRating Then
                    Dim nGlobalRating = Await _apiTrakt.Movies.GetMovieRatingsAsync(CStr(uintTraktID.Result))
                    If nGlobalRating IsNot Nothing AndAlso nGlobalRating.Rating IsNot Nothing AndAlso nGlobalRating.Votes IsNot Nothing Then
                        nMovie.Rating = CStr(Math.Round(nGlobalRating.Rating.Value, 1))
                        nMovie.Votes = CStr(nGlobalRating.Votes)
                    End If
                End If

                'Main UserRating
                If tFilteredOptions.bMainUserRating Then
                    Dim nPersonalRatedMovies = Await _apiTrakt.Sync.GetRatingsAsync(TraktApiSharp.Enums.TraktRatingsItemType.Movie)
                    If nPersonalRatedMovies IsNot Nothing AndAlso nPersonalRatedMovies.Count > 0 Then
                        Dim tMovie = nPersonalRatedMovies.FirstOrDefault(Function(f) f.Movie.Ids.Trakt = uintTraktID.Result)
                        If tMovie IsNot Nothing Then
                            nMovie.UserRating = CInt(tMovie.Rating)
                        End If
                    End If
                End If
            End If

            Return nMovie
        End Function

        Public Async Function GetInfo_TVEpisode(ByVal uintTVShowTraktID As Task(Of UInteger), ByVal intSeason As Integer, ByVal intEpisode As Integer, ByVal tFilteredOptions As Structures.ScrapeOptions) As Task(Of MediaContainers.MainDetails)
            If uintTVShowTraktID.Result = 0 Then Return Nothing

            Dim nTVEpisode As New MediaContainers.MainDetails
            nTVEpisode.Scrapersource = "TRAKTTV"
            nTVEpisode.Episode = intEpisode
            nTVEpisode.Season = intSeason

            If CheckConnection() Then
                'Episode Rating
                If tFilteredOptions.bEpisodeRating Then
                    Dim nGlobalRating = Await _apiTrakt.Episodes.GetEpisodeRatingsAsync(CStr(uintTVShowTraktID.Result), intSeason, intEpisode)
                    If nGlobalRating IsNot Nothing AndAlso nGlobalRating.Rating IsNot Nothing AndAlso nGlobalRating.Votes IsNot Nothing Then
                        nTVEpisode.Rating = CStr(Math.Round(nGlobalRating.Rating.Value, 1))
                        nTVEpisode.Votes = CStr(nGlobalRating.Votes)
                    End If
                End If

                'Episode UserRating
                If tFilteredOptions.bEpisodeUserRating Then
                    Dim nPersonalRatedTVEpisodes = Await _apiTrakt.Sync.GetRatingsAsync(TraktApiSharp.Enums.TraktRatingsItemType.Episode)
                    If nPersonalRatedTVEpisodes IsNot Nothing AndAlso nPersonalRatedTVEpisodes.Count > 0 Then
                        Dim tTVEpisode = nPersonalRatedTVEpisodes.FirstOrDefault(Function(f) f.Show.Ids.Trakt = uintTVShowTraktID.Result AndAlso
                                                                                 f.Episode.Number IsNot Nothing AndAlso
                                                                                 CInt(f.Episode.Number) = intEpisode AndAlso
                                                                                 f.Episode.SeasonNumber IsNot Nothing AndAlso
                                                                                 CInt(f.Episode.SeasonNumber) = intSeason)
                        If tTVEpisode IsNot Nothing Then
                            nTVEpisode.UserRating = CInt(tTVEpisode.Rating)
                        End If
                    End If
                End If
            End If

            Return nTVEpisode
        End Function

        Public Async Function GetInfo_TVShow(ByVal uintTraktID As Task(Of UInteger), ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal FilteredOptions As Structures.ScrapeOptions, ByVal lstEpisodes As List(Of Database.DBElement)) As Task(Of MediaContainers.MainDetails)
            If uintTraktID.Result = 0 Then Return Nothing

            Dim nTVShow As New MediaContainers.MainDetails
            nTVShow.Scrapersource = "TRAKTTV"

            If CheckConnection() Then
                'Main Rating
                If FilteredOptions.bMainRating Then
                    Dim nGlobalRating = Await _apiTrakt.Shows.GetShowRatingsAsync(CStr(uintTraktID.Result))
                    If nGlobalRating IsNot Nothing AndAlso nGlobalRating.Rating IsNot Nothing AndAlso nGlobalRating.Votes IsNot Nothing Then
                        nTVShow.Rating = CStr(Math.Round(nGlobalRating.Rating.Value, 1))
                        nTVShow.Votes = CStr(nGlobalRating.Votes)
                    End If
                End If

                'Main UserRating
                If FilteredOptions.bMainUserRating Then
                    Dim nPersonalRatedTVShows = Await _apiTrakt.Sync.GetRatingsAsync(TraktApiSharp.Enums.TraktRatingsItemType.Show)
                    If nPersonalRatedTVShows IsNot Nothing AndAlso nPersonalRatedTVShows.Count > 0 Then
                        Dim tTVShow = nPersonalRatedTVShows.FirstOrDefault(Function(f) f.Show.Ids.Trakt = uintTraktID.Result)
                        If tTVShow IsNot Nothing Then
                            nTVShow.UserRating = CInt(tTVShow.Rating)
                        End If
                    End If
                End If

                'Episodes
                If tScrapeModifiers.withEpisodes AndAlso lstEpisodes.Count > 0 AndAlso (FilteredOptions.bEpisodeRating OrElse FilteredOptions.bEpisodeUserRating) Then
                    'looks like there is no way to get all episodes for a tv show. so we scrape only local existing episodes
                    For Each nDBElement As Database.DBElement In lstEpisodes
                        Try
                            Dim nEpisode As MediaContainers.MainDetails = Await GetInfo_TVEpisode(uintTraktID, nDBElement.MainDetails.Season, nDBElement.MainDetails.Episode, FilteredOptions)
                            If nEpisode IsNot Nothing Then
                                nTVShow.KnownEpisodes.Add(nEpisode)
                            End If
                        Catch ex As Exception
                            logger.Info(String.Format("[TrakttvScraper] [GetInfo_TVShow] S{0}E{1}: {2}", nDBElement.MainDetails.Season, nDBElement.MainDetails.Episode, ex.Message))
                        End Try
                    Next
                End If
            End If

            Return nTVShow
        End Function

        Public Async Function GetTraktID(ByVal tDBElement As Database.DBElement, Optional bForceTVShowID As Boolean = False) As Task(Of UInteger)
            Dim nSearchResults As Objects.Basic.TraktPaginationListResult(Of Objects.Basic.TraktSearchResult) = Nothing
            Dim nContentType As Enums.ContentType = If(bForceTVShowID, Enums.ContentType.TVShow, tDBElement.ContentType)

            If CheckConnection() Then
                Select Case nContentType
                    Case Enums.ContentType.Movie
                        'search by IMDB ID
                        If tDBElement.MainDetails.IMDBSpecified Then
                            nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.ImDB, tDBElement.MainDetails.IMDB, TraktApiSharp.Enums.TraktSearchResultType.Movie)
                        End If
                        'search by TMDB ID
                        If nSearchResults.Items.Count = 0 AndAlso tDBElement.MainDetails.TMDBSpecified Then
                            nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TmDB, tDBElement.MainDetails.TMDB, TraktApiSharp.Enums.TraktSearchResultType.Movie)
                        End If
                        If nSearchResults.Items.Count = 1 Then
                            Return nSearchResults.Items(0).Movie.Ids.Trakt
                        Else
                            logger.Info(String.Format("[TrakttvScraper] [GetTraktID] Could not scrape TraktID from trakt.tv! IMDB: {0} / TMDB: {1}", tDBElement.MainDetails.IMDB, tDBElement.MainDetails.TMDB))
                        End If
                    Case Enums.ContentType.TVEpisode
                        'search by TVDB ID
                        If tDBElement.MainDetails.TVDBSpecified Then
                            nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TvDB, tDBElement.MainDetails.TVDB, TraktApiSharp.Enums.TraktSearchResultType.Episode)
                        End If
                        'search by IMDB ID
                        If nSearchResults.Items.Count = 0 AndAlso tDBElement.MainDetails.IMDBSpecified Then
                            nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.ImDB, tDBElement.MainDetails.IMDB, TraktApiSharp.Enums.TraktSearchResultType.Episode)
                        End If
                        'search by TMDB ID
                        If nSearchResults.Items.Count = 0 AndAlso tDBElement.MainDetails.TMDBSpecified Then
                            nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TmDB, tDBElement.MainDetails.TMDB, TraktApiSharp.Enums.TraktSearchResultType.Episode)
                        End If
                        If nSearchResults.Items.Count = 1 Then
                            Return nSearchResults.Items(0).Episode.Ids.Trakt
                        Else
                            logger.Info(String.Format("[TrakttvScraper] [GetTraktID] Could not scrape TraktID from trakt.tv! TVDB: {0} / IMDB: {1} / TMDB: {2}", tDBElement.MainDetails.TVDB, tDBElement.MainDetails.IMDB, tDBElement.MainDetails.TMDB))
                        End If
                    Case Enums.ContentType.TVShow
                        'search by TVDB ID
                        If tDBElement.MainDetails.TVDBSpecified Then
                            nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TvDB, tDBElement.MainDetails.TVDB, TraktApiSharp.Enums.TraktSearchResultType.Show)
                        End If
                        'search by IMDB ID
                        If nSearchResults.Items.Count = 0 AndAlso tDBElement.MainDetails.IMDBSpecified Then
                            nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.ImDB, tDBElement.MainDetails.IMDB, TraktApiSharp.Enums.TraktSearchResultType.Show)
                        End If
                        'search by TMDB ID
                        If nSearchResults.Items.Count = 0 AndAlso tDBElement.MainDetails.TMDBSpecified Then
                            nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TmDB, tDBElement.MainDetails.TMDB, TraktApiSharp.Enums.TraktSearchResultType.Show)
                        End If
                        If nSearchResults.Items.Count = 1 Then
                            Return nSearchResults.Items(0).Show.Ids.Trakt
                        Else
                            logger.Info(String.Format("[TrakttvScraper] [GetTraktID] Could not scrape TraktID from trakt.tv! TVDB: {0} / IMDB: {1} / TMDB: {2}", tDBElement.MainDetails.TVDB, tDBElement.MainDetails.IMDB, tDBElement.MainDetails.TMDB))
                        End If
                End Select
            End If

            Return 0
        End Function

#End Region 'Methods

#Region "Nested Types"

#End Region 'Nested Types

    End Class

End Namespace