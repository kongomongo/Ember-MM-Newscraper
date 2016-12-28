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

Public Class Addon
    Implements Interfaces.Addon

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _assemblyname As String
    Private _enabled As Boolean = True
    Private _shortname As String = "TMDB"

    Private _settings As New XMLAddonSettings
    Private _settingspanel As frmSettingsPanel

    Private _strPrivateAPIKey As String = String.Empty
    Private _AddonSettings_Movie As New AddonSettings
    Private _AddonSettings_MovieSet As New AddonSettings
    Private _AddonSettings_TV As New AddonSettings

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal eType As Enums.AddonEventType, ByRef _params As List(Of Object)) Implements Interfaces.Addon.GenericEvent
    Public Event NeedsRestart() Implements Interfaces.Addon.NeedsRestart
    Public Event SettingsChanged() Implements Interfaces.Addon.SettingsChanged
    Public Event StateChanged(ByVal strName As String, ByVal bEnabled As Boolean) Implements Interfaces.Addon.StateChanged

#End Region 'Events

#Region "Properties"

    Public Property Enabled() As Boolean Implements Interfaces.Addon.Enabled
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            _enabled = value
        End Set
    End Property

    Public ReadOnly Property Capabilities_AddonEventTypes() As List(Of Enums.AddonEventType) Implements Interfaces.Addon.Capabilities_AddonEventTypes
        Get
            Return New List(Of Enums.AddonEventType)(New Enums.AddonEventType() {
                                                      Enums.AddonEventType.Scrape_Movie,
                                                      Enums.AddonEventType.Scrape_MovieSet,
                                                      Enums.AddonEventType.Scrape_TVEpisode,
                                                      Enums.AddonEventType.Scrape_TVSeason,
                                                      Enums.AddonEventType.Scrape_TVShow,
                                                      Enums.AddonEventType.Search_Movie,
                                                      Enums.AddonEventType.Search_MovieSet,
                                                      Enums.AddonEventType.Search_TVShow
                                                      })
        End Get
    End Property

    Public ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibilities
        Get
            Return New List(Of Enums.ScraperCapatibility)(New Enums.ScraperCapatibility() {
                                                       Enums.ScraperCapatibility.Movie_Data_Actors,
                                                       Enums.ScraperCapatibility.Movie_Data_Certifications,
                                                       Enums.ScraperCapatibility.Movie_Data_CollectionID,
                                                       Enums.ScraperCapatibility.Movie_Data_Countries,
                                                       Enums.ScraperCapatibility.Movie_Data_Directors,
                                                       Enums.ScraperCapatibility.Movie_Data_Genres,
                                                       Enums.ScraperCapatibility.Movie_Data_OriginalTitle,
                                                       Enums.ScraperCapatibility.Movie_Data_Plot,
                                                       Enums.ScraperCapatibility.Movie_Data_Rating,
                                                       Enums.ScraperCapatibility.Movie_Data_ReleaseDate,
                                                       Enums.ScraperCapatibility.Movie_Data_Runtime,
                                                       Enums.ScraperCapatibility.Movie_Data_Studios,
                                                       Enums.ScraperCapatibility.Movie_Data_Tagline,
                                                       Enums.ScraperCapatibility.Movie_Data_Title,
                                                       Enums.ScraperCapatibility.Movie_Data_Trailer,
                                                       Enums.ScraperCapatibility.Movie_Data_Writers,
                                                       Enums.ScraperCapatibility.Movie_Data_Year,
                                                       Enums.ScraperCapatibility.Movie_Image_Fanart,
                                                       Enums.ScraperCapatibility.Movie_Image_Poster,
                                                       Enums.ScraperCapatibility.MovieSet_Data_Plot,
                                                       Enums.ScraperCapatibility.MovieSet_Data_Title,
                                                       Enums.ScraperCapatibility.MovieSet_Image_Fanart,
                                                       Enums.ScraperCapatibility.MovieSet_Image_Poster,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Actors,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Aired,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Directors,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_GuestStars,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Plot,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Rating,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Title,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Writers,
                                                       Enums.ScraperCapatibility.TVEpisode_Image_Poster,
                                                       Enums.ScraperCapatibility.TVSeason_Data_Aired,
                                                       Enums.ScraperCapatibility.TVSeason_Data_Plot,
                                                       Enums.ScraperCapatibility.TVSeason_Data_Title,
                                                       Enums.ScraperCapatibility.TVSeason_Image_Poster,
                                                       Enums.ScraperCapatibility.TVShow_Data_Actors,
                                                       Enums.ScraperCapatibility.TVShow_Data_Certification,
                                                       Enums.ScraperCapatibility.TVShow_Data_Countries,
                                                       Enums.ScraperCapatibility.TVShow_Data_Creators,
                                                       Enums.ScraperCapatibility.TVShow_Data_Genres,
                                                       Enums.ScraperCapatibility.TVShow_Data_OriginalTitle,
                                                       Enums.ScraperCapatibility.TVShow_Data_Plot,
                                                       Enums.ScraperCapatibility.TVShow_Data_Premiered,
                                                       Enums.ScraperCapatibility.TVShow_Data_Rating,
                                                       Enums.ScraperCapatibility.TVShow_Data_Runtime,
                                                       Enums.ScraperCapatibility.TVShow_Data_Status,
                                                       Enums.ScraperCapatibility.TVShow_Data_Studios,
                                                       Enums.ScraperCapatibility.TVShow_Data_Title,
                                                       Enums.ScraperCapatibility.TVShow_Image_Fanart,
                                                       Enums.ScraperCapatibility.TVShow_Image_Poster
                                                       })
        End Get
    End Property

    Public ReadOnly Property IsBusy() As Boolean Implements Interfaces.Addon.IsBusy
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property Shortname() As String Implements Interfaces.Addon.Shortname
        Get
            Return _shortname
        End Get
    End Property

    Public ReadOnly Property Version() As String Implements Interfaces.Addon.Version
        Get
            Return Diagnostics.FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Private Sub Handle_NeedsRestart()
        RaiseEvent NeedsRestart()
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _assemblyname = strAssemblyName
        LoadSettings()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        LoadSettings()
        Dim nSettingsPanel As New Containers.SettingsPanel
        _settingspanel = New frmSettingsPanel
        _settingspanel.chkFallBackToEng_Movie.Checked = _AddonSettings_Movie.FallBackToEng
        _settingspanel.chkFallBackToEng_MovieSet.Checked = _AddonSettings_MovieSet.FallBackToEng
        _settingspanel.chkFallBackToEng_TV.Checked = _AddonSettings_TV.FallBackToEng
        _settingspanel.chkIncludeAdultItems_Movie.Checked = _AddonSettings_Movie.IncludeAdultItems
        _settingspanel.chkIncludeAdultItems_MovieSet.Checked = _AddonSettings_MovieSet.IncludeAdultItems
        _settingspanel.chkIncludeAdultItems_TV.Checked = _AddonSettings_TV.IncludeAdultItems
        _settingspanel.chkSearchDeviant_Movie.Checked = _AddonSettings_Movie.SearchDeviant
        _settingspanel.txtAPIKey.Text = _strPrivateAPIKey

        nSettingsPanel.Image = My.Resources.logo_stacked_blue
        nSettingsPanel.ImageIndex = -1
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "TMDB_"
        nSettingsPanel.Title = "TMDB"
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.NeedsRestart, AddressOf Handle_NeedsRestart
        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        Return nSettingsPanel
    End Function

    Public Sub LoadSettings()
        'Global
        _strPrivateAPIKey = _settings.GetStringSetting("APIKey", String.Empty)

        'Movie
        _AddonSettings_Movie.APIKey = If(String.IsNullOrEmpty(_strPrivateAPIKey), "44810eefccd9cb1fa1d57e7b0d67b08d", _strPrivateAPIKey)
        _AddonSettings_Movie.FallBackToEng = _settings.GetBooleanSetting("FallBackToEn", False, Enums.ContentType.Movie)
        _AddonSettings_Movie.IncludeAdultItems = _settings.GetBooleanSetting("IncludeAdultItems", False, Enums.ContentType.Movie)
        _AddonSettings_Movie.SearchDeviant = _settings.GetBooleanSetting("SearchDeviant", False, Enums.ContentType.Movie)

        'MovieSet
        _AddonSettings_MovieSet.APIKey = If(String.IsNullOrEmpty(_strPrivateAPIKey), "44810eefccd9cb1fa1d57e7b0d67b08d", _strPrivateAPIKey)
        _AddonSettings_MovieSet.FallBackToEng = _settings.GetBooleanSetting("FallBackToEn", False, Enums.ContentType.MovieSet)
        _AddonSettings_MovieSet.IncludeAdultItems = _settings.GetBooleanSetting("IncludeAdultItems", False, Enums.ContentType.MovieSet)

        'TV
        _AddonSettings_TV.APIKey = If(String.IsNullOrEmpty(_strPrivateAPIKey), "44810eefccd9cb1fa1d57e7b0d67b08d", _strPrivateAPIKey)
        _AddonSettings_TV.FallBackToEng = _settings.GetBooleanSetting("FallBackToEn", False, Enums.ContentType.TV)
        _AddonSettings_TV.IncludeAdultItems = _settings.GetBooleanSetting("IncludeAdultItems", False, Enums.ContentType.TV)
    End Sub
    ''' <summary>
    '''  Scrape MovieDetails from TMDB
    ''' </summary>
    ''' <param name="tDBElement">Movie to be scraped. DBMovie as ByRef to use existing data for identifing movie and to fill with IMDB/TMDB ID for next scraper</param>
    ''' <returns>Database.DBElement Object (nMovie) which contains the scraped data</returns>
    ''' <remarks></remarks>
    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        logger.Trace("[TMDB] [Run] [Start]")
        Dim nModuleResult As New Interfaces.AddonResult

        LoadSettings()

        Dim ScraperSettings As New AddonSettings

        Select Case tDBElement.ContentType
            Case Enums.ContentType.Movie
                ScraperSettings = _AddonSettings_Movie
            Case Enums.ContentType.MovieSet
                ScraperSettings = _AddonSettings_MovieSet
            Case Enums.ContentType.TV, Enums.ContentType.TVEpisode, Enums.ContentType.TVSeason, Enums.ContentType.TVShow
                ScraperSettings = _AddonSettings_TV
        End Select

        ScraperSettings.PrefLanguage = tDBElement.Language
        Dim _scraper As New Scraper(ScraperSettings)

        Select Case eAddonEventType
            Case Enums.AddonEventType.Scrape_Movie
                If tDBElement.MainDetails.TMDBSpecified Then
                    nModuleResult = _scraper.Scrape_Movie(CStr(tDBElement.MainDetails.TMDB), tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                ElseIf tDBElement.MainDetails.IMDBSpecified Then
                    nModuleResult = _scraper.Scrape_Movie(tDBElement.MainDetails.IMDB, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                End If
            Case Enums.AddonEventType.Scrape_MovieSet
                If tDBElement.MainDetails.TMDBSpecified Then
                    nModuleResult = _scraper.Scrape_Movieset(CStr(tDBElement.MainDetails.TMDB), tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                End If
            Case Enums.AddonEventType.Scrape_TVEpisode
                Dim iShowID As Integer = -1
                If tDBElement.TVShowDetails.TMDBSpecified Then
                    iShowID = tDBElement.TVShowDetails.TMDB
                ElseIf tDBElement.TVShowDetails.TVDBSpecified Then
                    iShowID = _scraper.GetTMDBbyTVDB(tDBElement.TVShowDetails.TVDB, Enums.ContentType.TVShow)
                End If
                If Not iShowID = -1 AndAlso tDBElement.MainDetails.SeasonSpecified AndAlso tDBElement.MainDetails.EpisodeSpecified Then
                    nModuleResult = _scraper.ScrapeTVEpisode(iShowID, tDBElement.MainDetails.Season, tDBElement.MainDetails.Episode, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                ElseIf Not iShowID = -1 AndAlso tDBElement.MainDetails.AiredSpecified Then
                    nModuleResult = _scraper.Scrape_TVEpisode(iShowID, tDBElement.MainDetails.Aired, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                End If
            Case Enums.AddonEventType.Scrape_TVSeason
                Dim iShowID As Integer = -1
                If tDBElement.TVShowDetails.TMDBSpecified Then
                    iShowID = tDBElement.TVShowDetails.TMDB
                ElseIf tDBElement.TVShowDetails.TVDBSpecified Then
                    iShowID = _scraper.GetTMDBbyTVDB(tDBElement.TVShowDetails.TVDB, Enums.ContentType.TVShow)
                End If
                If Not iShowID = -1 AndAlso tDBElement.MainDetails.SeasonSpecified Then
                    nModuleResult = _scraper.Scrape_TVSeason(iShowID, tDBElement.MainDetails.Season, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                End If
            Case Enums.AddonEventType.Scrape_TVShow
                Dim iShowID As Integer = -1
                If tDBElement.TVShowDetails.TMDBSpecified Then
                    iShowID = tDBElement.TVShowDetails.TMDB
                ElseIf tDBElement.TVShowDetails.TVDBSpecified Then
                    iShowID = _scraper.GetTMDBbyTVDB(tDBElement.TVShowDetails.TVDB, Enums.ContentType.TVShow)
                End If
                If Not iShowID = -1 Then
                    nModuleResult = _scraper.ScrapeTVShow(iShowID, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                End If
            Case Enums.AddonEventType.Search_Movie
                If tDBElement.MainDetails.TitleSpecified Then
                    nModuleResult.SearchResults = _scraper.Search_Movie(tDBElement.MainDetails.Title, tDBElement.MainDetails.Year)
                End If
            Case Enums.AddonEventType.Search_MovieSet
                If tDBElement.MainDetails.TitleSpecified Then
                    nModuleResult.SearchResults = _scraper.Search_MovieSet(tDBElement.MainDetails.Title)
                End If
            Case Enums.AddonEventType.Search_TVShow
                If tDBElement.MainDetails.TitleSpecified Then
                    nModuleResult.SearchResults = _scraper.Search_TVShow(tDBElement.MainDetails.Title)
                End If
        End Select

        logger.Trace("[TMDB] [Run] [Done]")
        Return nModuleResult
    End Function

    Public Sub SaveSettings()
        'Global
        _settings.SetStringSetting("APIKey", _settingspanel.txtAPIKey.Text)

        'Movie
        _settings.SetBooleanSetting("FallBackToEn", _AddonSettings_Movie.FallBackToEng, , Enums.ContentType.Movie)
        _settings.SetBooleanSetting("IncludeAdultItems", _AddonSettings_Movie.IncludeAdultItems, , Enums.ContentType.Movie)
        _settings.SetBooleanSetting("SearchDeviant", _AddonSettings_Movie.SearchDeviant, , Enums.ContentType.Movie)

        'MovieSet
        _settings.SetBooleanSetting("FallBackToEn", _AddonSettings_MovieSet.FallBackToEng, , Enums.ContentType.MovieSet)
        _settings.SetBooleanSetting("IncludeAdultItems", _AddonSettings_MovieSet.IncludeAdultItems, , Enums.ContentType.MovieSet)

        'TV
        _settings.SetBooleanSetting("FallBackToEn", _AddonSettings_TV.FallBackToEng, , Enums.ContentType.TV)
        _settings.SetBooleanSetting("IncludeAdultItems", _AddonSettings_TV.IncludeAdultItems, , Enums.ContentType.TV)

        _settings.Save()
    End Sub

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        'Movie
        _AddonSettings_Movie.FallBackToEng = _settingspanel.chkFallBackToEng_Movie.Checked
        _AddonSettings_Movie.IncludeAdultItems = _settingspanel.chkIncludeAdultItems_Movie.Checked
        _AddonSettings_Movie.SearchDeviant = _settingspanel.chkSearchDeviant_Movie.Checked

        'MovieSet
        _AddonSettings_MovieSet.FallBackToEng = _settingspanel.chkFallBackToEng_MovieSet.Checked
        _AddonSettings_MovieSet.IncludeAdultItems = _settingspanel.chkIncludeAdultItems_MovieSet.Checked

        'TV
        _AddonSettings_TV.FallBackToEng = _settingspanel.chkFallBackToEng_TV.Checked
        _AddonSettings_TV.IncludeAdultItems = _settingspanel.chkIncludeAdultItems_TV.Checked

        SaveSettings()
        If bDoDispose Then
            RemoveHandler _settingspanel.NeedsRestart, AddressOf Handle_NeedsRestart
            RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
            _settingspanel.Dispose()
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure AddonSettings

#Region "Fields"

        Dim APIKey As String
        Dim FallBackToEng As Boolean
        Dim IncludeAdultItems As Boolean
        Dim PrefLanguage As String
        Dim SearchDeviant As Boolean

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class