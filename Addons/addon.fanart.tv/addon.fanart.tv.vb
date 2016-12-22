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
    Private _shortname As String = "Fanart.tv"

    Private _settings As New XMLAddonSettings
    Private _settingspanel As frmSettingsPanel
    Private _addonsettings As New AddonSettings

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
                                                      Enums.AddonEventType.Scrape_TVSeason,
                                                      Enums.AddonEventType.Scrape_TVShow
                                                      })
        End Get
    End Property

    Public ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibilities
        Get
            Return New List(Of Enums.ScraperCapatibility)(New Enums.ScraperCapatibility() {
                                                       Enums.ScraperCapatibility.Movie_Image_Banner,
                                                       Enums.ScraperCapatibility.Movie_Image_ClearArt,
                                                       Enums.ScraperCapatibility.Movie_Image_ClearLogo,
                                                       Enums.ScraperCapatibility.Movie_Image_DiscArt,
                                                       Enums.ScraperCapatibility.Movie_Image_Fanart,
                                                       Enums.ScraperCapatibility.Movie_Image_Landscape,
                                                       Enums.ScraperCapatibility.Movie_Image_Poster,
                                                       Enums.ScraperCapatibility.MovieSet_Image_Banner,
                                                       Enums.ScraperCapatibility.MovieSet_Image_ClearArt,
                                                       Enums.ScraperCapatibility.MovieSet_Image_ClearLogo,
                                                       Enums.ScraperCapatibility.MovieSet_Image_DiscArt,
                                                       Enums.ScraperCapatibility.MovieSet_Image_Fanart,
                                                       Enums.ScraperCapatibility.MovieSet_Image_Landscape,
                                                       Enums.ScraperCapatibility.MovieSet_Image_Poster,
                                                       Enums.ScraperCapatibility.TVSeason_Image_Banner,
                                                       Enums.ScraperCapatibility.TVSeason_Image_Landscape,
                                                       Enums.ScraperCapatibility.TVSeason_Image_Poster,
                                                       Enums.ScraperCapatibility.TVShow_Image_Banner,
                                                       Enums.ScraperCapatibility.TVShow_Image_CharacterArt,
                                                       Enums.ScraperCapatibility.TVShow_Image_ClearArt,
                                                       Enums.ScraperCapatibility.TVShow_Image_ClearLogo,
                                                       Enums.ScraperCapatibility.TVShow_Image_Fanart,
                                                       Enums.ScraperCapatibility.TVShow_Image_Landscape,
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
        _settingspanel.txtApiKey.Text = _addonsettings.APIKey

        'nSettingsPanel.Image = If(Me._ScraperEnabled_Movie, 9, 10)
        nSettingsPanel.ImageIndex = -1
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "FanartTV_"
        nSettingsPanel.Text = "FanartTV"
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.NeedsRestart, AddressOf Handle_NeedsRestart
        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        Return nSettingsPanel
    End Function

    Public Sub LoadSettings()
        'Global
        _addonsettings.APIKey = _settings.GetStringSetting("APIKey", String.Empty)
    End Sub

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        logger.Trace("[FanartTV] [Run] [Start]")
        Dim nModuleResult As New Interfaces.AddonResult

        LoadSettings()

        Dim _scraper As New Scraper(_addonsettings)

        Select Case eAddonEventType
            Case Enums.AddonEventType.Scrape_Movie
                If tDBElement.MainDetails.TMDBSpecified Then
                    nModuleResult.ScraperResult_ImageContainer = _scraper.GetImages_Movie_MovieSet(CStr(tDBElement.MainDetails.TMDB), tDBElement.ScrapeModifiers)
                ElseIf tDBElement.MainDetails.IMDBSpecified Then
                    nModuleResult.ScraperResult_ImageContainer = _scraper.GetImages_Movie_MovieSet(tDBElement.MainDetails.IMDB, tDBElement.ScrapeModifiers)
                Else
                    logger.Trace(String.Concat("[FanartTV] [Run] [Abort] No TMDB and IMDB ID exist to search: ", tDBElement.ListTitle))
                End If
            Case Enums.AddonEventType.Scrape_MovieSet
                'If String.IsNullOrEmpty(tDBElement.MainDetails.TMDB) AndAlso tDBElement.MoviesInSetSpecified Then
                '    tDBElement.MainDetails.TMDB = ModulesManager.Instance.GetMovieCollectionID(tDBElement.MoviesInSet.Item(0).DBMovie.MainDetails.IMDB)
                'End If

                If tDBElement.MainDetails.TMDBSpecified Then
                    nModuleResult.ScraperResult_ImageContainer = _scraper.GetImages_Movie_MovieSet(CStr(tDBElement.MainDetails.TMDB), tDBElement.ScrapeModifiers)
                End If
            Case Enums.AddonEventType.Scrape_TVSeason, Enums.AddonEventType.Scrape_TVShow
                If tDBElement.TVShowDetails.TVDBSpecified Then
                    nModuleResult.ScraperResult_ImageContainer = _scraper.GetImages_TV(CStr(tDBElement.TVShowDetails.TVDB), tDBElement.ScrapeModifiers)
                Else
                    logger.Trace(String.Concat("[FanartTV] [Run] [Abort] No TVDB ID exist to search: ", tDBElement.ListTitle))
                End If
        End Select

        logger.Trace("[FanartTV] [Run] [Done]")
        Return nModuleResult
    End Function

    Public Sub SaveSettings()
        _settings.SetStringSetting("APIKey", _addonsettings.APIKey)
        _settings.Save()
    End Sub

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        'Global
        _addonsettings.APIKey = _settingspanel.txtApiKey.Text

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

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class