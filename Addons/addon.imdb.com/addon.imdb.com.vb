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
    Private _shortname As String = "IMDB"

    Private _settings As New XMLAddonSettings
    Private _settingspanel As frmSettingsPanel
    Private _addonsettings As New AddonSettings
    Private _addonsettings_TV As New AddonSettings

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
                                                      Enums.AddonEventType.Scrape_TVEpisode,
                                                      Enums.AddonEventType.Scrape_TVSeason,
                                                      Enums.AddonEventType.Scrape_TVShow,
                                                      Enums.AddonEventType.Search_Movie,
                                                      Enums.AddonEventType.Search_TVShow
                                                      })
        End Get
    End Property

    Public ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibilities
        Get
            Return New List(Of Enums.ScraperCapatibility)(New Enums.ScraperCapatibility() {
                                                       Enums.ScraperCapatibility.Movie_Data_Actors,
                                                       Enums.ScraperCapatibility.Movie_Data_Certifications,
                                                       Enums.ScraperCapatibility.Movie_Data_Countries,
                                                       Enums.ScraperCapatibility.Movie_Data_Directors,
                                                       Enums.ScraperCapatibility.Movie_Data_Genres,
                                                       Enums.ScraperCapatibility.Movie_Data_MPAA,
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
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Actors,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Aired,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Directors,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Plot,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Rating,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Title,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Writers,
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
                                                       Enums.ScraperCapatibility.TVShow_Data_Studios,
                                                       Enums.ScraperCapatibility.TVShow_Data_Title
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

    Public Sub DoDispose() Implements Interfaces.Addon.DoDispose
        RemoveHandler _settingspanel.NeedsRestart, AddressOf Handle_NeedsRestart
        RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        _settingspanel.Dispose()
    End Sub

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

        _settingspanel.cbForceTitleLanguage.Text = _addonsettings.ForceTitleLanguage
        _settingspanel.chkFallBackworldwide.Checked = _addonsettings.FallBackWorldwide
        _settingspanel.chkPartialTitles.Checked = _addonsettings.SearchPartialTitles
        _settingspanel.chkPopularTitles.Checked = _addonsettings.SearchPopularTitles
        _settingspanel.chkTvTitles.Checked = _addonsettings.SearchTvTitles
        _settingspanel.chkVideoTitles.Checked = _addonsettings.SearchVideoTitles
        _settingspanel.chkShortTitles.Checked = _addonsettings.SearchShortTitles
        _settingspanel.chkStudiowithDistributors.Checked = _addonsettings.StudioWithDistributors

        nSettingsPanel.Image = My.Resources.logo
        nSettingsPanel.ImageIndex = -1
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "IMDB_"
        nSettingsPanel.Title = "IMDB"
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.NeedsRestart, AddressOf Handle_NeedsRestart
        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        Return nSettingsPanel
    End Function

    Sub LoadSettings()
        'Movie
        _addonsettings.FallBackWorldwide = _settings.GetBooleanSetting("FallBackWorldwide", False, Enums.ContentType.Movie)
        _addonsettings.ForceTitleLanguage = _settings.GetStringSetting("ForceTitleLanguage", String.Empty, Enums.ContentType.Movie)
        _addonsettings.SearchPartialTitles = _settings.GetBooleanSetting("SearchPartialTitles", True, Enums.ContentType.Movie)
        _addonsettings.SearchPopularTitles = _settings.GetBooleanSetting("SearchPopularTitles", True, Enums.ContentType.Movie)
        _addonsettings.SearchTvTitles = _settings.GetBooleanSetting("SearchTvTitles", False, Enums.ContentType.Movie)
        _addonsettings.SearchVideoTitles = _settings.GetBooleanSetting("SearchVideoTitles", False, Enums.ContentType.Movie)
        _addonsettings.SearchShortTitles = _settings.GetBooleanSetting("SearchShortTitles", False, Enums.ContentType.Movie)
        _addonsettings.StudioWithDistributors = _settings.GetBooleanSetting("StudioWithDistributors", False, Enums.ContentType.Movie)
    End Sub

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        logger.Trace("[IMDB] [Run] [Start]")
        Dim nModuleResult As New Interfaces.AddonResult

        LoadSettings()

        Dim _scraper As New Scraper(_addonsettings)

        Select Case eAddonEventType
            Case Enums.AddonEventType.Scrape_Movie
                If tDBElement.MainDetails.IMDBSpecified Then
                    nModuleResult.ScraperResult_Data = _scraper.GetInfo_Movie(tDBElement.MainDetails.IMDB, tDBElement.ScrapeOptions)
                End If
            Case Enums.AddonEventType.Scrape_TVEpisode
                If tDBElement.MainDetails.IMDBSpecified Then
                    nModuleResult.ScraperResult_Data = _scraper.GetInfo_TVEpisode(tDBElement.MainDetails.IMDB, tDBElement.ScrapeOptions)
                ElseIf tDBElement.TVShowDetails.IMDBSpecified AndAlso tDBElement.MainDetails.SeasonSpecified AndAlso tDBElement.MainDetails.EpisodeSpecified Then
                    nModuleResult.ScraperResult_Data = _scraper.GetInfo_TVEpisode(tDBElement.TVShowDetails.IMDB, tDBElement.MainDetails.Season, tDBElement.MainDetails.Episode, tDBElement.ScrapeOptions)
                Else
                    logger.Trace("[IMDB_Data] [Scraper_TVEpisode] [Abort] No Episode and TV Show IMDB ID available")
                End If
            Case Enums.AddonEventType.Search_TVShow
                If tDBElement.MainDetails.IMDBSpecified Then
                    nModuleResult.ScraperResult_Data = _scraper.GetInfo_TVShow(tDBElement.MainDetails.IMDB, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions, False)
                End If
            Case Enums.AddonEventType.Scrape_Movie
            Case Enums.AddonEventType.Scrape_TVShow
        End Select

        logger.Trace("[IMDB] [Run] [Done]")
        Return nModuleResult
    End Function

    Public Sub SaveSettings()
        'Movie
        _settings.SetBooleanSetting("FallBackWorldwide", _addonsettings.FallBackWorldwide, , Enums.ContentType.Movie)
        _settings.SetBooleanSetting("SearchPartialTitles", _addonsettings.SearchPartialTitles, , Enums.ContentType.Movie)
        _settings.SetBooleanSetting("SearchPopularTitles", _addonsettings.SearchPopularTitles, , Enums.ContentType.Movie)
        _settings.SetBooleanSetting("SearchTvTitles", _addonsettings.SearchTvTitles, , Enums.ContentType.Movie)
        _settings.SetBooleanSetting("SearchVideoTitles", _addonsettings.SearchVideoTitles, , Enums.ContentType.Movie)
        _settings.SetBooleanSetting("SearchShortTitles", _addonsettings.SearchShortTitles, , Enums.ContentType.Movie)
        _settings.SetBooleanSetting("StudiowithDistributors", _addonsettings.StudioWithDistributors, , Enums.ContentType.Movie)
        _settings.SetStringSetting("ForceTitleLanguage", _addonsettings.ForceTitleLanguage, , Enums.ContentType.Movie)

        _settings.Save()
    End Sub

    Public Sub SaveSetup() Implements Interfaces.Addon.SaveSetup
        'Movie
        _addonsettings.FallBackWorldwide = _settingspanel.chkFallBackworldwide.Checked
        _addonsettings.ForceTitleLanguage = _settingspanel.cbForceTitleLanguage.Text
        _addonsettings.SearchPartialTitles = _settingspanel.chkPartialTitles.Checked
        _addonsettings.SearchPopularTitles = _settingspanel.chkPopularTitles.Checked
        _addonsettings.SearchTvTitles = _settingspanel.chkTvTitles.Checked
        _addonsettings.SearchVideoTitles = _settingspanel.chkVideoTitles.Checked
        _addonsettings.SearchShortTitles = _settingspanel.chkShortTitles.Checked
        _addonsettings.StudioWithDistributors = _settingspanel.chkStudiowithDistributors.Checked

        SaveSettings()
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure AddonSettings

#Region "Fields"

        Dim FallBackWorldwide As Boolean
        Dim ForceTitleLanguage As String
        Dim SearchPartialTitles As Boolean
        Dim SearchPopularTitles As Boolean
        Dim SearchTvTitles As Boolean
        Dim SearchVideoTitles As Boolean
        Dim SearchShortTitles As Boolean
        Dim StudioWithDistributors As Boolean

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class