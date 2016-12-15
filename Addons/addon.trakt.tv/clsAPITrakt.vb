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
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Public Class clsAPITrakt

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()
    Private _apiTrakt As New TraktClient("80a5418f493f058bc6fdfdc6d0a154731dea3fc628241e3dee29846c59f5d0f0", "e097b8c0b24ffddffb165b260166f9d7f7cd8e1617964bb51b393478772728e5")
    Private _AddonSettings As New Addon.AddonSettings
    Private _newTokenCreated As Boolean

#End Region 'Fields

#Region "Delegates"

    Public Delegate Function ShowProgress(ByVal iProgress As Integer, ByVal strMessage As String) As Boolean

#End Region 'Delegates

#Region "Properties"

    ReadOnly Property AccessToken() As String
        Get
            Return _AddonSettings.APIAccessToken
        End Get
    End Property

    ReadOnly Property NewTokenCreated() As Boolean
        Get
            Return _newTokenCreated
        End Get
    End Property

    ReadOnly Property RefreshToken() As String
        Get
            Return _AddonSettings.APIRefreshToken
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Public Sub New(ByRef tSpecialSettings As Addon.AddonSettings)
        _AddonSettings = tSpecialSettings
        Try
            CreateAPI()
            tSpecialSettings.APIAccessToken = _AddonSettings.APIAccessToken
            tSpecialSettings.APICreatedAt = _AddonSettings.APICreatedAt
            tSpecialSettings.APIExpiresInSeconds = _AddonSettings.APIExpiresInSeconds
            tSpecialSettings.APIRefreshToken = _AddonSettings.APIRefreshToken
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Function CheckConnection() As Boolean
        If _apiTrakt.Authorization.AccessToken Is Nothing OrElse String.IsNullOrEmpty(_apiTrakt.Authorization.AccessToken) OrElse _apiTrakt.Authorization.IsExpired Then
            CreateAPI()
        End If
        If _apiTrakt.Authorization.AccessToken IsNot Nothing AndAlso Not String.IsNullOrEmpty(_apiTrakt.Authorization.AccessToken) Then ' AndAlso Not _apiTrakt.Authorization.IsExpired Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CreateAPI()
        Dim bIsExpired As Boolean = True
        'Default lifetime of an AccessToken is 90 days. So we set the default CreatedAt age to 91 days to get shure that the default value is to old and a new AccessToken has to be created.
        Dim dCreatedAt As Date = Date.Today.AddDays(-91)
        Dim iCreatedAt As Long = 0
        Dim iExpiresIn As Integer = 0

        Integer.TryParse(_AddonSettings.APIExpiresInSeconds, iExpiresIn)
        If Long.TryParse(_AddonSettings.APICreatedAt, iCreatedAt) Then
            dCreatedAt = Functions.ConvertFromUnixTimestamp(iCreatedAt)
        End If

        'calculation actual ExiresIn value
        bIsExpired = dCreatedAt.AddSeconds(iExpiresIn) <= Date.Today

        _apiTrakt.Authorization.AccessToken = _AddonSettings.APIAccessToken
        _apiTrakt.Authorization.RefreshToken = _AddonSettings.APIRefreshToken

        If (bIsExpired OrElse String.IsNullOrEmpty(_apiTrakt.Authorization.AccessToken)) AndAlso Not String.IsNullOrEmpty(_apiTrakt.Authorization.RefreshToken) Then
            _apiTrakt.Authorization.AccessToken = String.Empty
            _apiTrakt.OAuth.RefreshAuthorizationAsync()
            _newTokenCreated = True
            While _apiTrakt.Authorization.AccessToken Is Nothing OrElse String.IsNullOrEmpty(_apiTrakt.Authorization.AccessToken)
                Threading.Thread.Sleep(100)
            End While
            _AddonSettings.APIAccessToken = _apiTrakt.Authorization.AccessToken
            _AddonSettings.APICreatedAt = Functions.ConvertToUnixTimestamp(_apiTrakt.Authorization.Created.Date).ToString
            _AddonSettings.APIExpiresInSeconds = _apiTrakt.Authorization.ExpiresInSeconds.ToString
            _AddonSettings.APIRefreshToken = _apiTrakt.Authorization.RefreshToken
        End If

        If String.IsNullOrEmpty(_apiTrakt.Authorization.AccessToken) Then
            Dim strActivationURL = _apiTrakt.OAuth.CreateAuthorizationUrl()
            Using dAuthorize As New frmAuthorize
                If dAuthorize.ShowDialog(strActivationURL) = DialogResult.OK Then
                    _apiTrakt.OAuth.GetAuthorizationAsync(dAuthorize.Result)
                    _newTokenCreated = True
                    While _apiTrakt.Authorization.AccessToken Is Nothing OrElse String.IsNullOrEmpty(_apiTrakt.Authorization.AccessToken)
                        Threading.Thread.Sleep(100)
                    End While
                    _AddonSettings.APIAccessToken = _apiTrakt.Authorization.AccessToken
                    _AddonSettings.APICreatedAt = Functions.ConvertToUnixTimestamp(_apiTrakt.Authorization.Created.Date).ToString
                    _AddonSettings.APIExpiresInSeconds = _apiTrakt.Authorization.ExpiresInSeconds.ToString
                    _AddonSettings.APIRefreshToken = _apiTrakt.Authorization.RefreshToken
                End If
            End Using
        End If
    End Sub

    Public Function AddToCollection(ByVal tCollectionItems As Objects.Post.Syncs.Collection.TraktSyncCollectionPost) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionPostResponse
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.AddCollectionItemsAsync(tCollectionItems))
            If APIResult.Exception Is Nothing Then
                logger.Info(String.Format("[APITrakt] [AddToCollection] [Added] Episodes: {0} | Movies: {1}",
                                          APIResult.Result.Added.Episodes.Value,
                                          APIResult.Result.Added.Movies.Value))
                logger.Info(String.Format("[APITrakt] [AddToCollection] [Not Found] Episodes: {0} | Movies: {1}",
                                          APIResult.Result.NotFound.Episodes.Count,
                                          APIResult.Result.NotFound.Movies.Count))
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function AddToCollection_Movie(ByVal tTraktMovie As Objects.Get.Movies.TraktMovie, Optional dCollectedAt As Date = Nothing) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionPostResponse
        Dim nCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        nCollectionItems.AddMovie(tTraktMovie, dCollectedAt)
        Return AddToCollection(nCollectionItems.Build)
    End Function

    Public Function AddToCollection_Movie(ByVal tDBElement As Database.DBElement, Optional ByVal bUseDateNow As Boolean = False) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionPostResponse
        Dim nTraktMovie = GetMovie(tDBElement)
        Dim nCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        nCollectionItems.AddMovie(nTraktMovie, If(bUseDateNow, Nothing, Functions.ConvertFromUnixTimestamp(tDBElement.DateAdded)))
        Return AddToCollection(nCollectionItems.Build)
    End Function

    Public Function AddToCollection_Movies(ByVal tTraktMovies As List(Of Objects.Get.Movies.TraktMovie)) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionPostResponse
        Dim nCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        For Each nMovie In tTraktMovies
            nCollectionItems.AddMovie(nMovie)
        Next
        Return AddToCollection(nCollectionItems.Build)
    End Function

    Public Function AddToCollection_TVEpisode(ByVal tTraktEpisode As Objects.Get.Shows.Episodes.TraktEpisode, Optional dCollectedAt As Date = Nothing) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionPostResponse
        Dim nCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        nCollectionItems.AddEpisode(tTraktEpisode, dCollectedAt)
        Return AddToCollection(nCollectionItems.Build)
    End Function

    Public Function AddToCollection_TVEpisodes(ByVal tTraktEpisodes As List(Of Objects.Get.Shows.Episodes.TraktEpisode)) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionPostResponse
        Dim nCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        For Each nTVEpisode In tTraktEpisodes
            nCollectionItems.AddEpisode(nTVEpisode)
        Next
        Return AddToCollection(nCollectionItems.Build)
    End Function

    Public Function AddToCollection_TVShow(ByVal tTraktShow As Objects.Get.Shows.TraktShow, Optional dCollectedAt As Date = Nothing) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionPostResponse
        Dim nCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        nCollectionItems.AddShow(tTraktShow, dCollectedAt)
        Return AddToCollection(nCollectionItems.Build)
    End Function

    Public Function AddToCollection_TVShows(ByVal tTraktShows As List(Of Objects.Get.Shows.TraktShow)) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionPostResponse
        Dim nCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        For Each nTVShow In tTraktShows
            nCollectionItems.AddShow(nTVShow)
        Next
        Return AddToCollection(nCollectionItems.Build)
    End Function

    Public Function AddToWatchedHistory(ByVal tCollectionItems As Objects.Post.Syncs.History.TraktSyncHistoryPost) As Objects.Post.Syncs.History.Responses.TraktSyncHistoryPostResponse
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.AddWatchedHistoryItemsAsync(tCollectionItems))
            If APIResult.Exception Is Nothing Then
                logger.Info(String.Format("[APITrakt] [AddToWatchedHistory] [Added] Episodes: {0} | Movies: {1}",
                                          APIResult.Result.Added.Episodes.Value,
                                          APIResult.Result.Added.Movies.Value))
                logger.Info(String.Format("[APITrakt] [AddToWatchedHistory] [Not Found] Episodes: {0} | Movies: {1}",
                                          APIResult.Result.NotFound.Episodes.Count,
                                          APIResult.Result.NotFound.Movies.Count))
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' Adds a single movie to the user watched history
    ''' </summary>
    ''' <param name="tTraktMovie"></param>
    ''' <param name="dCollectedAt">Has to be UTC DateTime</param>
    ''' <returns>Response</returns>
    Public Function AddToWatchedHistory_Movie(ByVal tTraktMovie As Objects.Get.Movies.TraktMovie, Optional dCollectedAt As Date = Nothing) As Objects.Post.Syncs.History.Responses.TraktSyncHistoryPostResponse
        Dim nHistoryItems As New Objects.Post.Syncs.History.TraktSyncHistoryPostBuilder
        nHistoryItems.AddMovie(tTraktMovie, dCollectedAt)
        Return AddToWatchedHistory(nHistoryItems.Build)
    End Function

    Public Function AddToWatchedHistory_Movie(ByVal tDBElement As Database.DBElement, Optional ByVal bUseDateNow As Boolean = False) As Objects.Post.Syncs.History.Responses.TraktSyncHistoryPostResponse
        Dim nTraktMovie = GetMovie(tDBElement)
        Dim nHistoryItems As New Objects.Post.Syncs.History.TraktSyncHistoryPostBuilder
        nHistoryItems.AddMovie(nTraktMovie, If(bUseDateNow, Nothing, Functions.ConvertFromUnixTimestamp(tDBElement.DateAdded).ToUniversalTime))
        Return AddToWatchedHistory(nHistoryItems.Build)
    End Function

    Public Function GetCollection_Movies() As IEnumerable(Of Objects.Get.Collection.TraktCollectionMovie)
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.GetCollectionMoviesAsync())
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCollection_TVShows() As IEnumerable(Of Objects.Get.Collection.TraktCollectionShow)
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.GetCollectionShowsAsync())
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Async Function GetID_Trakt(ByVal tDBElement As Database.DBElement, Optional bForceTVShowID As Boolean = False) As Task(Of UInteger)
        Dim nSearchResults As Objects.Basic.TraktPaginationListResult(Of Objects.Basic.TraktSearchResult) = Nothing
        Dim nContentType As Enums.ContentType = If(bForceTVShowID, Enums.ContentType.TVShow, tDBElement.ContentType)

        If CheckConnection() Then
            Select Case nContentType
                Case Enums.ContentType.Movie
                    'search by IMDB ID
                    If tDBElement.MainDetails.IMDBSpecified Then
                        nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.ImDB, tDBElement.MainDetails.IMDB, TraktApiSharp.Enums.TraktSearchResultType.Movie)
                        'If nSearchResults.Exception IsNot Nothing Then Return 0
                    End If
                    'search by TMDB ID
                    If (nSearchResults Is Nothing OrElse nSearchResults.Items.Count = 0) AndAlso tDBElement.MainDetails.TMDBSpecified Then
                        nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TmDB, CStr(tDBElement.MainDetails.TMDB), TraktApiSharp.Enums.TraktSearchResultType.Movie)
                        'If nSearchResults.Exception IsNot Nothing Then Return 0
                    End If
                    If nSearchResults IsNot Nothing AndAlso nSearchResults.Items.Count = 1 Then
                        Return nSearchResults.Items(0).Movie.Ids.Trakt
                    Else
                        logger.Info(String.Format("[GetID_Trakt] Could not scrape TraktID from trakt.tv! IMDB: {0} / TMDB: {1}", tDBElement.MainDetails.IMDB, tDBElement.MainDetails.TMDB))
                    End If
                Case Enums.ContentType.TVEpisode
                    'search by TVDB ID
                    If tDBElement.MainDetails.TVDBSpecified Then
                        nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TvDB, CStr(tDBElement.MainDetails.TVDB), TraktApiSharp.Enums.TraktSearchResultType.Episode)
                        'If nSearchResults.Exception IsNot Nothing Then Return 0
                    End If
                    'search by IMDB ID
                    If (nSearchResults Is Nothing OrElse nSearchResults.Items.Count = 0) AndAlso tDBElement.MainDetails.IMDBSpecified Then
                        nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.ImDB, tDBElement.MainDetails.IMDB, TraktApiSharp.Enums.TraktSearchResultType.Episode)
                        'If nSearchResults.Exception IsNot Nothing Then Return 0
                    End If
                    'search by TMDB ID
                    If (nSearchResults Is Nothing OrElse nSearchResults.Items.Count = 0) AndAlso tDBElement.MainDetails.TMDBSpecified Then
                        nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TmDB, CStr(tDBElement.MainDetails.TMDB), TraktApiSharp.Enums.TraktSearchResultType.Episode)
                        'If nSearchResults.Exception IsNot Nothing Then Return 0
                    End If
                    If nSearchResults IsNot Nothing AndAlso nSearchResults.Items.Count = 1 Then
                        Return nSearchResults.Items(0).Episode.Ids.Trakt
                    Else
                        logger.Info(String.Format("[GetID_Trakt] Could not scrape TraktID from trakt.tv! TVDB: {0} / IMDB: {1} / TMDB: {2}", tDBElement.MainDetails.TVDB, tDBElement.MainDetails.IMDB, tDBElement.MainDetails.TMDB))
                    End If
                Case Enums.ContentType.TVShow
                    'search by TVDB ID
                    If tDBElement.MainDetails.TVDBSpecified Then
                        nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TvDB, CStr(tDBElement.MainDetails.TVDB), TraktApiSharp.Enums.TraktSearchResultType.Show)
                        'If nSearchResults.Exception IsNot Nothing Then Return 0
                    End If
                    'search by IMDB ID
                    If (nSearchResults Is Nothing OrElse nSearchResults.Items.Count = 0) AndAlso tDBElement.MainDetails.IMDBSpecified Then
                        nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.ImDB, tDBElement.MainDetails.IMDB, TraktApiSharp.Enums.TraktSearchResultType.Show)
                        'If nSearchResults.Exception IsNot Nothing Then Return 0
                    End If
                    'search by TMDB ID
                    If (nSearchResults Is Nothing OrElse nSearchResults.Items.Count = 0) AndAlso tDBElement.MainDetails.TMDBSpecified Then
                        nSearchResults = Await _apiTrakt.Search.GetIdLookupResultsAsync(TraktApiSharp.Enums.TraktSearchIdType.TmDB, CStr(tDBElement.MainDetails.TMDB), TraktApiSharp.Enums.TraktSearchResultType.Show)
                        'If nSearchResults.Exception IsNot Nothing Then Return 0
                    End If
                    If nSearchResults IsNot Nothing AndAlso nSearchResults.Items.Count = 1 Then
                        Return nSearchResults.Items(0).Show.Ids.Trakt
                    Else
                        logger.Info(String.Format("[GetID_Trakt] Could not scrape TraktID from trakt.tv! TVDB: {0} / IMDB: {1} / TMDB: {2}", tDBElement.MainDetails.TVDB, tDBElement.MainDetails.IMDB, tDBElement.MainDetails.TMDB))
                    End If
            End Select
        End If

        Return 0
    End Function

    Public Async Function GetInfo_Movie(ByVal uintTraktID As Task(Of UInteger), ByVal tFilteredOptions As Structures.ScrapeOptions) As Task(Of MediaContainers.MainDetails)
        If uintTraktID.Result = 0 Then Return Nothing

        Dim nMovie As New MediaContainers.MainDetails
        nMovie.Scrapersource = "Trakt.tv"

        If CheckConnection() Then
            'Rating
            If tFilteredOptions.bMainRating Then
                Dim nGlobalRating = Await _apiTrakt.Movies.GetMovieRatingsAsync(CStr(uintTraktID.Result))
                If nGlobalRating IsNot Nothing AndAlso nGlobalRating.Rating IsNot Nothing AndAlso nGlobalRating.Votes IsNot Nothing Then
                    nMovie.Rating = CStr(Math.Round(nGlobalRating.Rating.Value, 1))
                    nMovie.Votes = CStr(nGlobalRating.Votes)
                End If
            End If

            'UserRating
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
        nTVEpisode.Scrapersource = "Trakt.tv"
        nTVEpisode.Episode = intEpisode
        nTVEpisode.Season = intSeason

        If CheckConnection() Then
            'Rating
            If tFilteredOptions.bEpisodeRating Then
                Dim nGlobalRating = Await _apiTrakt.Episodes.GetEpisodeRatingsAsync(CStr(uintTVShowTraktID.Result), intSeason, intEpisode)
                If nGlobalRating IsNot Nothing AndAlso nGlobalRating.Rating IsNot Nothing AndAlso nGlobalRating.Votes IsNot Nothing Then
                    nTVEpisode.Rating = CStr(Math.Round(nGlobalRating.Rating.Value, 1))
                    nTVEpisode.Votes = CStr(nGlobalRating.Votes)
                End If
            End If

            'UserRating
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
        nTVShow.Scrapersource = "Trakt.tv"

        If CheckConnection() Then
            'Rating
            If FilteredOptions.bMainRating Then
                Dim nGlobalRating = Await _apiTrakt.Shows.GetShowRatingsAsync(CStr(uintTraktID.Result))
                If nGlobalRating IsNot Nothing AndAlso nGlobalRating.Rating IsNot Nothing AndAlso nGlobalRating.Votes IsNot Nothing Then
                    nTVShow.Rating = CStr(Math.Round(nGlobalRating.Rating.Value, 1))
                    nTVShow.Votes = CStr(nGlobalRating.Votes)
                End If
            End If

            'UserRating
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

    Public Function GetMovie(ByVal strTraktIDOrSlug As String) As Objects.Get.Movies.TraktMovie
        If String.IsNullOrEmpty(strTraktIDOrSlug) OrElse strTraktIDOrSlug = "0" Then Return Nothing

        If CheckConnection() Then
            Dim nOptions As New Requests.Params.TraktExtendedInfo

            Dim APIResult = Task.Run(Function() _apiTrakt.Movies.GetMovieAsync(strTraktIDOrSlug))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetMovie(ByVal tDBElement As Database.DBElement) As Objects.Get.Movies.TraktMovie
        Return GetMovie(GetID_Trakt(tDBElement).ToString)
    End Function

    Public Function GetTVShow(ByVal strTraktIDOrSlug As String) As Objects.Get.Shows.TraktShow
        If String.IsNullOrEmpty(strTraktIDOrSlug) OrElse strTraktIDOrSlug = "0" Then Return Nothing

        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Shows.GetShowAsync(strTraktIDOrSlug))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetProgress_TVShows(ByVal strTraktIDOrSlug As String) As Objects.Get.Shows.TraktShowWatchedProgress
        If String.IsNullOrEmpty(strTraktIDOrSlug) OrElse strTraktIDOrSlug = "0" Then Return Nothing

        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Shows.GetShowWatchedProgressAsync(strTraktIDOrSlug, True, True, True))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetRated_Movies() As IEnumerable(Of Objects.Get.Ratings.TraktRatingsItem)
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.GetRatingsAsync(TraktApiSharp.Enums.TraktRatingsItemType.Movie))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetRated_TVEpisodes() As IEnumerable(Of Objects.Get.Ratings.TraktRatingsItem)
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.GetRatingsAsync(TraktApiSharp.Enums.TraktRatingsItemType.Episode))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetRated_TVShows() As IEnumerable(Of Objects.Get.Ratings.TraktRatingsItem)
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.GetRatingsAsync(TraktApiSharp.Enums.TraktRatingsItemType.Show))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetWatched_Movies() As IEnumerable(Of Objects.Get.Watched.TraktWatchedMovie)
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.GetWatchedMoviesAsync())
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetWatched_TVShows(Optional ByVal bGetFullInformation As Boolean = False) As IEnumerable(Of Objects.Get.Watched.TraktWatchedShow)
        If CheckConnection() Then
            Dim nOptions As Requests.Params.TraktExtendedInfo = Nothing
            If bGetFullInformation Then
                nOptions = New Requests.Params.TraktExtendedInfo With {.Full = True}
            End If
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.GetWatchedShowsAsync(nOptions))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function GetWatchedAndRated_Movies() As List(Of WatchedAndRatedMovie)
        Return GetWatchedAndRated_Movies(GetWatched_Movies(), GetRated_Movies())
    End Function

    Public Function GetWatchedAndRated_Movies(ByVal tWatchedMovies As IEnumerable(Of Objects.Get.Watched.TraktWatchedMovie), ByVal tRatedMovies As IEnumerable(Of Objects.Get.Ratings.TraktRatingsItem)) As List(Of WatchedAndRatedMovie)
        If tWatchedMovies Is Nothing AndAlso tRatedMovies Is Nothing Then Return Nothing

        Dim lstWatchedAndRatedMovies As New List(Of WatchedAndRatedMovie)

        'add a watched movies and search for personal rating
        For Each nWatched In tWatchedMovies
            Dim nWatchedAndRatedMovie As New WatchedAndRatedMovie
            nWatchedAndRatedMovie.LastWatchedAt = nWatched.LastWatchedAt
            nWatchedAndRatedMovie.Movie = nWatched.Movie
            nWatchedAndRatedMovie.Plays = CInt(nWatched.Plays)

            'search rating for this movie
            Dim nRated = tRatedMovies.FirstOrDefault(Function(f) (f.Movie.Ids.Trakt = nWatched.Movie.Ids.Trakt))
            If nRated IsNot Nothing Then
                nWatchedAndRatedMovie.RatedAt = nRated.RatedAt
                nWatchedAndRatedMovie.Rating = CInt(nRated.Rating)
            End If

            lstWatchedAndRatedMovies.Add(nWatchedAndRatedMovie)
        Next

        'add movies that has been rated but not watched
        For Each nRated In tRatedMovies
            Dim nMovie = lstWatchedAndRatedMovies.FirstOrDefault(Function(f) f.Movie.Ids.Trakt = nRated.Movie.Ids.Trakt)
            If nMovie Is Nothing Then
                lstWatchedAndRatedMovies.Add(New WatchedAndRatedMovie With {
                                        .Movie = nRated.Movie,
                                        .RatedAt = nRated.RatedAt,
                                        .Rating = CInt(nRated.Rating)})
            End If
        Next

        Return lstWatchedAndRatedMovies
    End Function

    Public Function GetWatchedAndRated_TVShows() As List(Of WatchedAndRatedTVShow)
        Return GetWatchedAndRated_TVShows(GetWatched_TVShows(True), GetRated_TVShows())
    End Function

    Public Function GetWatchedAndRated_TVShows(ByVal tWatchedTVShows As IEnumerable(Of Objects.Get.Watched.TraktWatchedShow), ByVal tRatedTVShows As IEnumerable(Of Objects.Get.Ratings.TraktRatingsItem)) As List(Of WatchedAndRatedTVShow)
        If tWatchedTVShows Is Nothing AndAlso tRatedTVShows Is Nothing Then Return Nothing

        Dim lstWatchedAndRatedTVShows As New List(Of WatchedAndRatedTVShow)

        'add a watched tv shows and search for personal rating
        For Each nWatched In tWatchedTVShows
            Dim nWatchedAndRatedTVShow As New WatchedAndRatedTVShow
            nWatchedAndRatedTVShow.LastWatchedAt = nWatched.LastWatchedAt
            nWatchedAndRatedTVShow.Seasons = nWatched.Seasons
            nWatchedAndRatedTVShow.Show = nWatched.Show
            nWatchedAndRatedTVShow.Plays = CInt(nWatched.Plays)

            'search rating for this tv show
            Dim nRated = tRatedTVShows.FirstOrDefault(Function(f) (f.Show.Ids.Trakt = nWatched.Show.Ids.Trakt))
            If nRated IsNot Nothing Then
                nWatchedAndRatedTVShow.RatedAt = nRated.RatedAt
                nWatchedAndRatedTVShow.Rating = CInt(nRated.Rating)
            End If

            lstWatchedAndRatedTVShows.Add(nWatchedAndRatedTVShow)
        Next

        'add tv shows that has been rated but not watched
        For Each nRated In tRatedTVShows
            Dim nTVShow = lstWatchedAndRatedTVShows.FirstOrDefault(Function(f) f.Show.Ids.Trakt = nRated.Show.Ids.Trakt)
            If nTVShow Is Nothing Then
                lstWatchedAndRatedTVShows.Add(New WatchedAndRatedTVShow With {
                                        .RatedAt = nRated.RatedAt,
                                        .Rating = CInt(nRated.Rating),
                                        .Show = nRated.Show})
            End If
        Next

        'calculate watched episodes
        For Each nTVShow In lstWatchedAndRatedTVShows
            Dim iWatched As Integer = 0
            For Each nSeason In nTVShow.Seasons
                For Each nEpisode In nSeason.Episodes
                    If nEpisode.Plays IsNot Nothing AndAlso nEpisode.Plays > 0 Then
                        iWatched += 1
                    End If
                Next
            Next
            nTVShow.WatchedEpisodes = iWatched
        Next

        Return lstWatchedAndRatedTVShows
    End Function

    Public Function GetWatchedHistory_Movie(ByVal uintTraktID As UInteger) As IEnumerable(Of Objects.Get.History.TraktHistoryItem)
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.GetWatchedHistoryAsync(TraktApiSharp.Enums.TraktSyncItemType.Movie, uintTraktID))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function RemoveFromCollection(ByVal tCollectionItems As Objects.Post.Syncs.Collection.TraktSyncCollectionPost) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionRemovePostResponse
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.RemoveCollectionItemsAsync(tCollectionItems))
            If APIResult.Exception Is Nothing Then
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function RemoveFromCollection_Movie(ByVal tTraktMovie As Objects.Get.Movies.TraktMovie) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionRemovePostResponse
        Dim tCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        tCollectionItems.AddMovie(tTraktMovie)
        Return RemoveFromCollection(tCollectionItems.Build)
    End Function

    Public Function RemoveFromCollection_Movie(ByVal tDBElement As Database.DBElement) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionRemovePostResponse
        Dim nTraktMovie = GetMovie(tDBElement)
        Dim tCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        tCollectionItems.AddMovie(nTraktMovie)
        Return RemoveFromCollection(tCollectionItems.Build)
    End Function

    Public Function RemoveFromCollection_Movies(ByVal tTraktMovies As List(Of Objects.Get.Movies.TraktMovie)) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionRemovePostResponse
        Dim tCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        For Each nMovie In tTraktMovies
            tCollectionItems.AddMovie(nMovie)
        Next
        Return RemoveFromCollection(tCollectionItems.Build)
    End Function

    Public Function RemoveFromCollection_TVEpisode(ByVal tTraktEpisode As Objects.Get.Shows.Episodes.TraktEpisode) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionRemovePostResponse
        Dim tCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        tCollectionItems.AddEpisode(tTraktEpisode)
        Return RemoveFromCollection(tCollectionItems.Build)
    End Function

    Public Function RemoveFromCollection_TVEpisodes(ByVal tTraktEpisodes As List(Of Objects.Get.Shows.Episodes.TraktEpisode)) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionRemovePostResponse
        Dim tCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        For Each nTVEpisode In tTraktEpisodes
            tCollectionItems.AddEpisode(nTVEpisode)
        Next
        Return RemoveFromCollection(tCollectionItems.Build)
    End Function

    Public Function RemoveFromCollection_TVShow(ByVal tTraktShow As Objects.Get.Shows.TraktShow) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionRemovePostResponse
        Dim tCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        tCollectionItems.AddShow(tTraktShow)
        Return RemoveFromCollection(tCollectionItems.Build)
    End Function

    Public Function RemoveFromCollection_TVShows(ByVal tTraktShows As List(Of Objects.Get.Shows.TraktShow)) As Objects.Post.Syncs.Collection.Responses.TraktSyncCollectionRemovePostResponse
        Dim tCollectionItems As New Objects.Post.Syncs.Collection.TraktSyncCollectionPostBuilder
        For Each nTVShow In tTraktShows
            tCollectionItems.AddShow(nTVShow)
        Next
        Return RemoveFromCollection(tCollectionItems.Build)
    End Function

    Public Function RemoveFromWatchedHistory(ByVal tHistoryItems As Objects.Post.Syncs.History.TraktSyncHistoryRemovePost) As Objects.Post.Syncs.History.Responses.TraktSyncHistoryRemovePostResponse
        If CheckConnection() Then
            Dim APIResult = Task.Run(Function() _apiTrakt.Sync.RemoveWatchedHistoryItemsAsync(tHistoryItems))
            If APIResult.Exception Is Nothing Then
                logger.Info(String.Format("[APITrakt] [RemoveFromWatchedHistory] [Removed] Episodes: {0} | Movies: {1}",
                                          APIResult.Result.Deleted.Episodes.Value,
                                          APIResult.Result.Deleted.Movies.Value))
                logger.Info(String.Format("[APITrakt] [RemoveFromWatchedHistory] [Not Found] Episodes: {0} | Movies: {1}",
                                          APIResult.Result.NotFound.Episodes.Count,
                                          APIResult.Result.NotFound.Movies.Count))
                Return APIResult.Result
            End If
        End If
        Return Nothing
    End Function

    Public Function RemoveFromWatchedHistory_Movie(ByVal tTraktMovie As Objects.Get.Movies.TraktMovie) As Objects.Post.Syncs.History.Responses.TraktSyncHistoryRemovePostResponse
        Dim tWatchedHistoryItems As New Objects.Post.Syncs.History.TraktSyncHistoryRemovePostBuilder
        tWatchedHistoryItems.AddMovie(tTraktMovie)
        Return RemoveFromWatchedHistory(tWatchedHistoryItems.Build)
    End Function

    Public Sub SaveWatchedStateToEmber_Movies(ByVal mywatchedmovies As IEnumerable(Of Objects.Get.Watched.TraktWatchedMovie), Optional ByVal sfunction As ShowProgress = Nothing)
        Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MyVideosDBConn.BeginTransaction()
            Dim i As Integer = 0
            'filter watched movies at trakt.tv to movies with an Unique ID only
            For Each watchedMovie In mywatchedmovies.Where(Function(f) f.Movie.Ids.Imdb IsNot Nothing OrElse
                                                                  f.Movie.Ids.Tmdb IsNot Nothing)
                Using SQLCommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                    Dim DateTimeLastPlayedUnix As Double = -1
                    Try
                        Dim DateTimeLastPlayed As Date = Date.ParseExact(watchedMovie.LastWatchedAt.ToString, "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture)
                        DateTimeLastPlayedUnix = Functions.ConvertToUnixTimestamp(DateTimeLastPlayed)
                    Catch ex As Exception
                        DateTimeLastPlayedUnix = -1
                    End Try

                    'build query, search only with known Unique IDs
                    Dim UniqueIDs As New List(Of String)
                    If watchedMovie.Movie.Ids.Imdb IsNot Nothing Then UniqueIDs.Add(String.Format("IMDB = {0}", Regex.Replace(watchedMovie.Movie.Ids.Imdb, "tt", String.Empty).Trim))
                    If watchedMovie.Movie.Ids.Tmdb IsNot Nothing Then UniqueIDs.Add(String.Format("TMDB = {0}", watchedMovie.Movie.Ids.Tmdb))

                    SQLCommand.CommandText = String.Format("SELECT DISTINCT idMovie FROM movie WHERE ((Playcount IS NULL OR NOT Playcount = {0}) OR (iLastPlayed IS NULL OR NOT iLastPlayed = {1})) AND ({2});", watchedMovie.Plays, DateTimeLastPlayedUnix, String.Join(" OR ", UniqueIDs.ToArray))
                    Using SQLreader As SQLite.SQLiteDataReader = SQLCommand.ExecuteReader()
                        While SQLreader.Read
                            Dim tmpMovie As Database.DBElement = Master.DB.Load_Movie(Convert.ToInt64(SQLreader("idMovie")))
                            tmpMovie.MainDetails.PlayCount = CInt(watchedMovie.Plays)
                            tmpMovie.MainDetails.LastPlayed = watchedMovie.LastWatchedAt.ToString
                            Master.DB.Save_Movie(tmpMovie, True, True, False, True, False)
                        End While
                    End Using
                End Using
                i += 1
                If sfunction IsNot Nothing Then
                    sfunction(i, watchedMovie.Movie.Title)
                End If
            Next
            SQLtransaction.Commit()
        End Using
    End Sub

    Public Sub SaveWatchedStateToEmber_TVEpisodes(ByVal myWatchedEpisodes As IEnumerable(Of Objects.Get.Watched.TraktWatchedShowEpisode), Optional ByVal sfunction As ShowProgress = Nothing)
        'Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MyVideosDBConn.BeginTransaction()
        '    Dim i As Integer = 0
        '    'filter watched tv shows at trakt.tv to tv shows with an Unique ID only
        '    For Each watchedTVShow In myWatchedEpisodes.Where(Function(f) f.Show.Ids.Imdb IsNot Nothing OrElse
        '                                                          f.Show.Ids.Tmdb IsNot Nothing OrElse
        '                                                          f.Show.Ids.Tvdb IsNot Nothing)
        '        For Each watchedTVSeason In watchedTVShow.Seasons
        '            For Each watchedTVEpisode In watchedTVSeason.Episodes
        '                Using SQLCommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
        '                    Dim DateTimeLastPlayedUnix As Double = -1
        '                    Try
        '                        Dim DateTimeLastPlayed As Date = Date.ParseExact(Functions.ConvertToProperDateTime(watchedTVEpisode.WatchedAt), "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture)
        '                        DateTimeLastPlayedUnix = Functions.ConvertToUnixTimestamp(DateTimeLastPlayed)
        '                    Catch ex As Exception
        '                        DateTimeLastPlayedUnix = -1
        '                    End Try

        '                    'build query, search only with known Unique IDs
        '                    Dim UniqueIDs As New List(Of String)
        '                    If watchedTVShow.Show.Ids.Tvdb IsNot Nothing Then UniqueIDs.Add(String.Format("tvshow.TVDB = {0}", watchedTVShow.Show.Ids.Tvdb))
        '                    If watchedTVShow.Show.Ids.Imdb IsNot Nothing Then UniqueIDs.Add(String.Format("tvshow.strIMDB = '{0}'", watchedTVShow.Show.Ids.Imdb))
        '                    If watchedTVShow.Show.Ids.Tmdb IsNot Nothing Then UniqueIDs.Add(String.Format("tvshow.strTMDB = {0}", watchedTVShow.Show.Ids.Tmdb))

        '                    SQLCommand.CommandText = String.Concat("SELECT DISTINCT episode.idEpisode FROM episode INNER JOIN tvshow ON (episode.idShow = tvshow.idShow) ",
        '                                                           "WHERE NOT idFile = -1 ",
        '                                                           "AND (episode.Season = ", watchedTVSeason.Number, " AND episode.Episode = ", watchedTVEpisode.Number, ") ",
        '                                                           "AND ((episode.Playcount IS NULL OR NOT episode.Playcount = ", watchedTVEpisode.Plays, ") ",
        '                                                           "OR (episode.iLastPlayed IS NULL OR NOT episode.iLastPlayed = ", DateTimeLastPlayedUnix, ")) ",
        '                                                           "AND (", String.Join(" OR ", UniqueIDs.ToArray), ");")

        '                    Using SQLreader As SQLite.SQLiteDataReader = SQLCommand.ExecuteReader()
        '                        While SQLreader.Read
        '                            Dim tmpTVEpisode As Database.DBElement = Master.DB.Load_TVEpisode(Convert.ToInt64(SQLreader("idEpisode")), True)
        '                            tmpTVEpisode.TVEpisode.Playcount = watchedTVEpisode.Plays
        '                            tmpTVEpisode.TVEpisode.LastPlayed = Functions.ConvertToProperDateTime(watchedTVEpisode.WatchedAt)
        '                            Master.DB.Save_TVEpisode(tmpTVEpisode, True, True, False, False, True)
        '                        End While
        '                    End Using
        '                End Using
        '            Next
        '        Next
        '        i += 1
        '        If sfunction IsNot Nothing Then
        '            sfunction(i, watchedTVShow.Show.Title)
        '        End If
        '    Next
        '    SQLtransaction.Commit()
        'End Using
    End Sub

    Public Function SetWatchedState_Movie(ByRef tDBElement As Database.DBElement) As Boolean
        If Not tDBElement.MainDetails.AnyUniqueIDSpecified Then Return False

        If CheckConnection() Then
            Dim strIMDBID As String = tDBElement.MainDetails.IMDB
            Dim intTMDBID As Integer = tDBElement.MainDetails.TMDB

            Dim lWatchedMovies = GetWatched_Movies()
            If lWatchedMovies IsNot Nothing AndAlso lWatchedMovies.Count > 0 Then
                Dim tMovie = lWatchedMovies.FirstOrDefault(Function(f) (f.Movie.Ids.Imdb IsNot Nothing AndAlso f.Movie.Ids.Imdb = strIMDBID) OrElse
                                                  (f.Movie.Ids.Tmdb IsNot Nothing AndAlso CInt(f.Movie.Ids.Tmdb) = intTMDBID))
                If tMovie IsNot Nothing Then
                    tDBElement.MainDetails.LastPlayed = tMovie.LastWatchedAt.ToString
                    tDBElement.MainDetails.PlayCount = CInt(tMovie.Plays)
                    Return True
                End If
            End If
        End If

        Return False
    End Function

    Public Function SetWatchedState_TVEpisode(ByRef tDBElement As Database.DBElement) As Boolean
        If Not tDBElement.MainDetails.AnyUniqueIDSpecified Then Return False

        'If CheckConnection() Then
        '    Dim strIMDBID As String = tDBElement.TVShow.IMDB
        '    Dim intTMDBID As Integer = -1
        '    Dim intTVDBID As Integer = -1
        '    Integer.TryParse(tDBElement.TVShow.TMDB, intTMDBID)
        '    Integer.TryParse(tDBElement.TVShow.TVDB, intTVDBID)

        '    Dim lWatchedTVEpisodes = GetWatched_TVShows()
        '    If lWatchedTVEpisodes IsNot Nothing AndAlso lWatchedTVEpisodes.Count > 0 Then
        '        Dim tTVShow = lWatchedTVEpisodes.FirstOrDefault(Function(f) (f.Show.Ids.Tvdb IsNot Nothing AndAlso CInt(f.Show.Ids.Tvdb) = intTVDBID) OrElse
        '                                                           (f.Show.Ids.Imdb IsNot Nothing AndAlso f.Show.Ids.Imdb = strIMDBID) OrElse
        '                                                           (f.Show.Ids.Tmdb IsNot Nothing AndAlso CInt(f.Show.Ids.Tmdb) = intTMDBID))
        '        If tTVShow IsNot Nothing Then
        '            Select Case tDBElement.ContentType
        '                Case Enums.ContentType.TVEpisode
        '                    Dim intEpisode = tDBElement.TVEpisode.Episode
        '                    Dim intSeason = tDBElement.TVEpisode.Season

        '                    Dim tTVEpisode = tTVShow.Seasons.FirstOrDefault(Function(f) f.Number = intSeason).Episodes.FirstOrDefault(Function(f) f.Number = intEpisode)
        '                    If tTVEpisode IsNot Nothing Then
        '                        tDBElement.TVEpisode.LastPlayed = Functions.ConvertToProperDateTime(tTVEpisode.WatchedAt)
        '                        tDBElement.TVEpisode.Playcount = tTVEpisode.Plays
        '                        Return True
        '                    End If
        '                Case Enums.ContentType.TVShow
        '                    For Each tEpisode As Database.DBElement In tDBElement.Episodes.Where(Function(f) f.FilenameSpecified)
        '                        Dim intEpisode = tEpisode.TVEpisode.Episode
        '                        Dim intSeason = tEpisode.TVEpisode.Season

        '                        Dim tTVEpisode = tTVShow.Seasons.FirstOrDefault(Function(f) f.Number = intSeason).Episodes.FirstOrDefault(Function(f) f.Number = intEpisode)
        '                        If tTVEpisode IsNot Nothing Then
        '                            tEpisode.TVEpisode.LastPlayed = Functions.ConvertToProperDateTime(tTVEpisode.WatchedAt)
        '                            tEpisode.TVEpisode.Playcount = tTVEpisode.Plays
        '                        End If
        '                    Next
        '                    Return True
        '            End Select
        '        End If
        '    End If
        'End If

        Return False
    End Function

    Public Sub SyncToEmber_All(Optional ByVal sfunction As ShowProgress = Nothing)
        SyncToEmber_Movies(sfunction)
        SyncToEmber_TVEpisodes(sfunction)
    End Sub

    Public Sub SyncToEmber_Movies(Optional ByVal sfunction As ShowProgress = Nothing)
        Dim WatchedMovies = GetWatched_Movies()
        If WatchedMovies IsNot Nothing Then
            SaveWatchedStateToEmber_Movies(WatchedMovies, sfunction)
        End If
    End Sub

    Public Sub SyncToEmber_TVEpisodes(Optional ByVal sfunction As ShowProgress = Nothing)
        'Dim WatchedTVEpisodes = GetWatched_TVShows()
        'If WatchedTVEpisodes IsNot Nothing Then
        '    SaveWatchedStateToEmber_TVEpisodes(WatchedTVEpisodes, sfunction)
        'End If
    End Sub

    Public Sub SyncTo_Trakt(ByVal tDBElement As Database.DBElement)
        Select Case tDBElement.ContentType
            Case Enums.ContentType.Movie
                SyncToTrakt_LastPlayed(tDBElement)
        End Select
    End Sub

    Public Sub SyncToTrakt_LastPlayed(ByVal tDBElement As Database.DBElement, Optional tTraktItem As Objects.Get.Movies.TraktMovie = Nothing)
        Dim nTraktItem As Objects.Get.Movies.TraktMovie
        If tTraktItem IsNot Nothing Then
            'use submitted TraktMovie
            nTraktItem = tTraktItem
        Else
            'search on Trakt
            nTraktItem = GetMovie(tDBElement)
        End If

        If nTraktItem IsNot Nothing Then
            If tDBElement.MainDetails.LastPlayedSpecified Then
                Dim dLastPlayed As New Date
                If Date.TryParse(tDBElement.MainDetails.LastPlayed, dLastPlayed) Then
                    'Trakt always use UTC
                    dLastPlayed = dLastPlayed.ToUniversalTime
                    'get watched history from Trakt
                    Dim nHistoryItems = GetWatchedHistory_Movie(nTraktItem.Ids.Trakt)
                    If nHistoryItems IsNot Nothing Then
                        'check if the date already exist in the history
                        Dim bAlreadyInHistory As Boolean = nHistoryItems.Where(Function(f) f.WatchedAt IsNot Nothing AndAlso
                                                                                   CDate(f.WatchedAt) = dLastPlayed).Count > 0
                        If Not bAlreadyInHistory Then
                            'add to Trakt watched history
                            AddToWatchedHistory_Movie(nTraktItem, dLastPlayed)
                        End If
                    End If
                End If
            Else
                'remove from Trakt watched history
                RemoveFromWatchedHistory_Movie(nTraktItem)
            End If
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class WatchedAndRatedMovie
        Public LastWatchedAt As Date?
        Public Movie As Objects.Get.Movies.TraktMovie
        Public Plays As Integer
        Public RatedAt As Date?
        Public Rating As Integer
    End Class

    Public Class WatchedAndRatedTVEpisode
        Public LastWatchedAt As Date?
        Public Episode As Objects.Get.Shows.Episodes.TraktEpisode
        Public Plays As Integer
        Public RatedAt As Date?
        Public Rating As Integer
    End Class

    Public Class WatchedAndRatedTVShow
        Public LastWatchedAt As Date?
        Public Seasons As IEnumerable(Of Objects.Get.Watched.TraktWatchedShowSeason)
        Public Show As Objects.Get.Shows.TraktShow
        Public Plays As Integer
        Public RatedAt As Date?
        Public Rating As Integer
        Public WatchedEpisodes As Integer
    End Class

#End Region 'Nested Types

End Class
