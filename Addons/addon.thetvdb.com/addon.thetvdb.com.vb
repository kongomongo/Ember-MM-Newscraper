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
    Private _shortname As String = "TVDB"

    Private _settings As New XMLAddonSettings
    Private _settingspanel As frmSettingsPanel

    Private _strPrivateAPIKey As String = String.Empty

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
                                                      Enums.AddonEventType.Scrape_TVEpisode,
                                                      Enums.AddonEventType.Scrape_TVSeason,
                                                      Enums.AddonEventType.Scrape_TVShow,
                                                      Enums.AddonEventType.Search_TVShow
                                                      })
        End Get
    End Property

    Public ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibilities
        Get
            Return New List(Of Enums.ScraperCapatibility)(New Enums.ScraperCapatibility() {
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Actors,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Aired,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Directors,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_GuestStars,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Plot,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Rating,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Title,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Writers,
                                                       Enums.ScraperCapatibility.TVEpisode_Image_Poster,
                                                       Enums.ScraperCapatibility.TVSeason_Image_Banner,
                                                       Enums.ScraperCapatibility.TVSeason_Image_Poster,
                                                       Enums.ScraperCapatibility.TVShow_Data_Actors,
                                                       Enums.ScraperCapatibility.TVShow_Data_EpisodeGuide,
                                                       Enums.ScraperCapatibility.TVShow_Data_Genres,
                                                       Enums.ScraperCapatibility.TVShow_Data_MPAA,
                                                       Enums.ScraperCapatibility.TVShow_Data_Plot,
                                                       Enums.ScraperCapatibility.TVShow_Data_Premiered,
                                                       Enums.ScraperCapatibility.TVShow_Data_Rating,
                                                       Enums.ScraperCapatibility.TVShow_Data_Runtime,
                                                       Enums.ScraperCapatibility.TVShow_Data_Status,
                                                       Enums.ScraperCapatibility.TVShow_Data_Studios,
                                                       Enums.ScraperCapatibility.TVShow_Data_Title,
                                                       Enums.ScraperCapatibility.TVShow_Image_Banner,
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
        _settingspanel.txtAPIKey.Text = _strPrivateAPIKey

        nSettingsPanel.ImageIndex = -1
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "TVDB_"
        nSettingsPanel.Title = "TVDB"
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.NeedsRestart, AddressOf Handle_NeedsRestart
        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        Return nSettingsPanel
    End Function

    Sub LoadSettings()
        'Global
        _strPrivateAPIKey = _settings.GetStringSetting("APIKey", String.Empty)
    End Sub

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        logger.Trace("[TVDB] [Run] [Start]")
        Dim nModuleResult As New Interfaces.AddonResult

        LoadSettings()

        Dim Settings As New AddonSettings
        Settings.APIKey = If(Not String.IsNullOrEmpty(_strPrivateAPIKey), _strPrivateAPIKey, "353783CE455412FD")
        Settings.Language = tDBElement.Language_Main

        Dim _scraper As New Scraper(Settings)

        Select Case eAddonEventType
            Case Enums.AddonEventType.Scrape_TVEpisode
                If tDBElement.TVShowDetails.TVDBSpecified Then
                    If tDBElement.MainDetails.SeasonSpecified AndAlso tDBElement.MainDetails.EpisodeSpecified Then
                        nModuleResult = _scraper.GetInfo_TVEpisode(tDBElement.TVShowDetails.TVDB, tDBElement.MainDetails.Season, tDBElement.MainDetails.Episode, tDBElement.Ordering, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                    ElseIf tDBElement.MainDetails.AiredSpecified Then
                        nModuleResult = _scraper.GetInfo_TVEpisode(tDBElement.TVShowDetails.TVDB, tDBElement.MainDetails.Aired, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions)
                    Else
                        logger.Trace("[TVDB] [Run] [Abort] No Season- or Episodenumber and also no AiredDate available")
                    End If
                Else
                    logger.Trace("[TVDB] [Run] [Abort] No TV Show TVDB ID available")
                End If
            Case Enums.AddonEventType.Scrape_TVShow
                If tDBElement.MainDetails.TVDBSpecified Then
                    nModuleResult = _scraper.Scrape_TVShow(tDBElement.MainDetails.TVDB, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions, False)
                ElseIf tDBElement.MainDetails.IMDBSpecified Then
                    Dim iTVDB As Integer = _scraper.GetTVDBbyIMDB(tDBElement.MainDetails.IMDB)
                    nModuleResult = _scraper.Scrape_TVShow(iTVDB, tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions, False)
                End If
            Case Enums.AddonEventType.Search_TVShow
                If tDBElement.MainDetails.TitleSpecified Then
                    nModuleResult.SearchResults = _scraper.Search_TVShow(tDBElement.MainDetails.Title)
                End If
        End Select

        logger.Trace("[TVDB] [Run] [Done]")
        Return nModuleResult
    End Function

    Sub SaveSettings()
        'Global
        _settings.SetStringSetting("APIKey", _settingspanel.txtAPIKey.Text)
        _settings.Save()
    End Sub

    Public Sub SaveSetup() Implements Interfaces.Addon.SaveSetup
        SaveSettings()
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure AddonSettings

#Region "Fields"

        Dim APIKey As String
        Dim Language As String

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class