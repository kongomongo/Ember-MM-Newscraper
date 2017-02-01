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
Imports System.Drawing
Imports System.Xml.Serialization

Public Class Addon
    Implements Interfaces.Addon

#Region "Delegates"

    Public Delegate Sub Delegate_AddToolsStripItem(control As ToolStripMenuItem, value As ToolStripItem)
    Public Delegate Sub Delegate_RemoveToolsStripItem(control As ToolStripMenuItem, value As ToolStripItem)

#End Region 'Delegates

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _assemblyname As String = String.Empty
    Private _enabled As Boolean = False
    Private _shortname As String = "Trakt.tv"

    Private _settings As New XMLAddonSettings
    Private _settingspanel As frmSettingsPanel

    Private WithEvents cmnuTrayToolsTrakt As New ToolStripMenuItem
    Private WithEvents mnuMainToolsTrakt As New ToolStripMenuItem
    Private _AddonSettings As New AddonSettings
    Private _TraktAPI As clsAPITrakt

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
            If _enabled = value Then Return
            _enabled = value
            If _enabled Then
                Enable()
            Else
                Disable()
            End If
        End Set
    End Property

    Public ReadOnly Property Capabilities_AddonEventTypes() As List(Of Enums.AddonEventType) Implements Interfaces.Addon.Capabilities_AddonEventTypes
        Get
            Return New List(Of Enums.AddonEventType)(New Enums.AddonEventType() {
                                                      Enums.AddonEventType.BeforeEdit_Movie,
                                                      Enums.AddonEventType.BeforeEdit_TVEpisode,
                                                      Enums.AddonEventType.BeforeEdit_TVShow,
                                                      Enums.AddonEventType.CommandLine,
                                                      Enums.AddonEventType.Generic,
                                                      Enums.AddonEventType.Remove_Movie,
                                                      Enums.AddonEventType.Remove_TVEpisode,
                                                      Enums.AddonEventType.Remove_TVSeason,
                                                      Enums.AddonEventType.Remove_TVShow,
                                                      Enums.AddonEventType.DuringScrapingMulti_Movie,
                                                      Enums.AddonEventType.DuringScrapingMulti_TVEpisode,
                                                      Enums.AddonEventType.DuringScrapingMulti_TVSeason,
                                                      Enums.AddonEventType.DuringScrapingMulti_TVShow,
                                                      Enums.AddonEventType.DuringScrapingSingle_Movie,
                                                      Enums.AddonEventType.DuringScrapingSingle_TVEpisode,
                                                      Enums.AddonEventType.DuringScrapingSingle_TVSeason,
                                                      Enums.AddonEventType.DuringScrapingSingle_TVShow,
                                                      Enums.AddonEventType.Scrape_Movie,
                                                      Enums.AddonEventType.Scrape_TVEpisode,
                                                      Enums.AddonEventType.Scrape_TVShow,
                                                      Enums.AddonEventType.Sync_Movie})
        End Get
    End Property

    ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibilities
        Get
            Return New List(Of Enums.ScraperCapatibility)(New Enums.ScraperCapatibility() {
                                                       Enums.ScraperCapatibility.Movie_Data_Rating,
                                                       Enums.ScraperCapatibility.Movie_Data_UserRating,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_Rating,
                                                       Enums.ScraperCapatibility.TVEpisode_Data_UserRating,
                                                       Enums.ScraperCapatibility.TVShow_Data_Rating,
                                                       Enums.ScraperCapatibility.TVShow_Data_UserRating
                                                       })
        End Get
    End Property

    ReadOnly Property IsBusy() As Boolean Implements Interfaces.Addon.IsBusy
        Get
            Return False
        End Get
    End Property

    ReadOnly Property Shortname() As String Implements Interfaces.Addon.Shortname
        Get
            Return _shortname
        End Get
    End Property

    ReadOnly Property Version() As String Implements Interfaces.Addon.Version
        Get
            Return FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Private Sub Disable()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        ToolStripItem_Remove(tsi, mnuMainToolsTrakt)

        'cmnuTrayTools
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        ToolStripItem_Remove(tsi, cmnuTrayToolsTrakt)
    End Sub

    Public Sub DoDispose() Implements Interfaces.Addon.DoDispose
        RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        RemoveHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
        _settingspanel.Dispose()
    End Sub

    Public Sub Enable()
        _TraktAPI = New clsAPITrakt(_AddonSettings)
        If _TraktAPI.NewTokenCreated Then
            SaveSettings()
        End If

        Dim tsi As New ToolStripMenuItem

        'mnuMainTools menu
        mnuMainToolsTrakt.Image = New Bitmap(My.Resources.icon)
        mnuMainToolsTrakt.Text = Master.eLang.GetString(871, "Trakt.tv Manager")
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        ToolStripItem_Add(tsi, mnuMainToolsTrakt)

        'cmnuTrayTools
        cmnuTrayToolsTrakt.Image = New Bitmap(My.Resources.icon)
        cmnuTrayToolsTrakt.Text = Master.eLang.GetString(871, "Trakt.tv Manager")
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        ToolStripItem_Add(tsi, cmnuTrayToolsTrakt)
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub Handle_StateChanged(ByVal bEnabled As Boolean)
        RaiseEvent StateChanged(_shortname, bEnabled)
    End Sub

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _assemblyname = strAssemblyName
        LoadSettings()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        LoadSettings()
        Dim nSettingsPanel As New Containers.SettingsPanel
        _settingspanel = New frmSettingsPanel
        _settingspanel.chkEnabled.Checked = _enabled
        _settingspanel.chkGetShowProgress.Checked = _AddonSettings.GetProgress_TVShow
        _settingspanel.chkGetWatchedState.Checked = _AddonSettings.GetWatchedState
        _settingspanel.chkGetWatchedStateBeforeEdit_Movie.Checked = _AddonSettings.GetWatchedStateBeforeEdit_Movie
        _settingspanel.chkGetWatchedStateBeforeEdit_TVEpisode.Checked = _AddonSettings.GetWatchedStateBeforeEdit_TVEpisode
        _settingspanel.chkGetWatchedStateScraperMulti_Movie.Checked = _AddonSettings.GetWatchedStateScraperMulti_Movie
        _settingspanel.chkGetWatchedStateScraperMulti_TVEpisode.Checked = _AddonSettings.GetWatchedStateScraperMulti_TVEpisode
        _settingspanel.chkGetWatchedStateScraperSingle_Movie.Checked = _AddonSettings.GetWatchedStateScraperSingle_Movie
        _settingspanel.chkGetWatchedStateScraperSingle_TVEpisode.Checked = _AddonSettings.GetWatchedStateScraperSingle_TVEpisode

        nSettingsPanel.ImageIndex = If(_enabled, 9, 10)
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "Trakt_"
        nSettingsPanel.Title = "Trakt.tv"
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        Return nSettingsPanel
    End Function

    Public Sub LoadSettings()
        _AddonSettings.APIAccessToken = _settings.GetStringSetting("APIAccessToken", String.Empty)
        _AddonSettings.APICreatedAt = _settings.GetStringSetting("APICreatedAt", "0")
        _AddonSettings.APIExpiresInSeconds = _settings.GetStringSetting("APIExpiresInSeconds", "0")
        _AddonSettings.APIRefreshToken = _settings.GetStringSetting("APIRefreshToken", String.Empty)
        _AddonSettings.CollectionRemove_Movie = _settings.GetBooleanSetting("CollectionRemove", False, Enums.ContentType.Movie)
        _AddonSettings.GetProgress_TVShow = _settings.GetBooleanSetting("GetProgress", False, Enums.ContentType.TVShow)
        _AddonSettings.GetWatchedState = _settings.GetBooleanSetting("WatchedState", False)
        _AddonSettings.GetWatchedStateBeforeEdit_Movie = _settings.GetBooleanSetting("WatchedStateBeforeEdit", False, Enums.ContentType.Movie)
        _AddonSettings.GetWatchedStateBeforeEdit_TVEpisode = _settings.GetBooleanSetting("WatchedStateBeforeEdit", False, Enums.ContentType.TVEpisode)
        _AddonSettings.GetWatchedStateScraperMulti_Movie = _settings.GetBooleanSetting("WatchedStateScraperMulti", False, Enums.ContentType.Movie)
        _AddonSettings.GetWatchedStateScraperMulti_TVEpisode = _settings.GetBooleanSetting("WatchedStateScraperMulti", False, Enums.ContentType.TVEpisode)
        _AddonSettings.GetWatchedStateScraperSingle_Movie = _settings.GetBooleanSetting("WatchedStateScraperSingle", False, Enums.ContentType.Movie)
        _AddonSettings.GetWatchedStateScraperSingle_TVEpisode = _settings.GetBooleanSetting("WatchedStateScraperSingle", False, Enums.ContentType.TVEpisode)
        _AddonSettings.SyncToTrakt_Movie = _settings.GetBooleanSetting("SyncToTrakt", False, Enums.ContentType.Movie)
    End Sub

    Private Sub MyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainToolsTrakt.Click, cmnuTrayToolsTrakt.Click
        RaiseEvent GenericEvent(Enums.AddonEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", False}))

        Using dTrakttvManager As New dlgTrakttvManager(_TraktAPI)
            dTrakttvManager.ShowDialog()
        End Using

        RaiseEvent GenericEvent(Enums.AddonEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", True}))
        RaiseEvent GenericEvent(Enums.AddonEventType.Generic, New List(Of Object)(New Object() {"filllist", True, True, True}))
    End Sub

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run

        Dim nAddonsResult As New Interfaces.AddonResult

        Select Case eAddonEventType
            Case Enums.AddonEventType.BeforeEdit_Movie
                If _AddonSettings.GetWatchedState AndAlso _AddonSettings.GetWatchedStateBeforeEdit_Movie AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_Movie(tDBElement)
                End If
            Case Enums.AddonEventType.BeforeEdit_TVEpisode
                If _AddonSettings.GetWatchedState AndAlso _AddonSettings.GetWatchedStateBeforeEdit_TVEpisode AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_TVEpisode(tDBElement)
                End If
            'Case Enums.ModuleEventType.CommandLine
            '    _TraktAPI.SyncToEmber_All()
            Case Enums.AddonEventType.DuringScrapingMulti_Movie
                If _AddonSettings.GetWatchedState AndAlso _AddonSettings.GetWatchedStateScraperMulti_Movie AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_Movie(tDBElement)
                End If
            Case Enums.AddonEventType.Remove_Movie
                If _AddonSettings.CollectionRemove_Movie AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.RemoveFromCollection_Movie(tDBElement)
                End If
            Case Enums.AddonEventType.DuringScrapingMulti_TVShow, Enums.AddonEventType.DuringScrapingMulti_TVEpisode
                If _AddonSettings.GetWatchedState AndAlso _AddonSettings.GetWatchedStateScraperMulti_TVEpisode AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_TVEpisode(tDBElement)
                End If
            Case Enums.AddonEventType.DuringScrapingSingle_Movie
                If _AddonSettings.GetWatchedState AndAlso _AddonSettings.GetWatchedStateScraperSingle_Movie AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_Movie(tDBElement)
                End If
            Case Enums.AddonEventType.DuringScrapingSingle_TVShow, Enums.AddonEventType.DuringScrapingSingle_TVEpisode
                If _AddonSettings.GetWatchedState AndAlso _AddonSettings.GetWatchedStateScraperSingle_TVEpisode AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_TVEpisode(tDBElement)
                End If
            Case Enums.AddonEventType.Scrape_Movie
                Dim nResult = _TraktAPI.GetInfo_Movie(_TraktAPI.GetID_Trakt(tDBElement), tDBElement.ScrapeOptions)
                While Not nResult.IsCompleted
                    Threading.Thread.Sleep(50)
                End While
                If nResult.Exception Is Nothing AndAlso nResult.Result IsNot Nothing Then
                    nAddonsResult.ScraperResult_Data = nResult.Result
                ElseIf nResult.Exception IsNot Nothing Then
                    logger.Error(String.Concat("[Tracktv_Data] [Scraper_Movie]: ", nResult.Exception.InnerException.Message))
                End If
            Case Enums.AddonEventType.Scrape_TVEpisode
                Dim Result = _TraktAPI.GetInfo_TVEpisode(_TraktAPI.GetID_Trakt(tDBElement, True), tDBElement.MainDetails.Season, tDBElement.MainDetails.Episode, tDBElement.ScrapeOptions)
                While Not Result.IsCompleted
                    Threading.Thread.Sleep(50)
                End While
                If Result.Exception Is Nothing AndAlso Result.Result IsNot Nothing Then
                    nAddonsResult.ScraperResult_Data = Result.Result
                ElseIf Result.Exception IsNot Nothing Then
                    logger.Error(String.Concat("[Tracktv_Data] [Scraper_TVEpisode]: ", Result.Exception.InnerException.Message))
                End If
            Case Enums.AddonEventType.Scrape_TVShow
                Dim nResult = _TraktAPI.GetInfo_TVShow(_TraktAPI.GetID_Trakt(tDBElement), tDBElement.ScrapeModifiers, tDBElement.ScrapeOptions, tDBElement.Episodes)
                While Not nResult.IsCompleted
                    Threading.Thread.Sleep(50)
                End While
                If nResult.Exception Is Nothing AndAlso nResult.Result IsNot Nothing Then
                    nAddonsResult.ScraperResult_Data = nResult.Result
                ElseIf nResult.Exception IsNot Nothing Then
                    logger.Error(String.Concat("[Tracktv_Data] [Scraper_TV]: ", nResult.Exception.InnerException.Message))
                End If
            Case Enums.AddonEventType.Sync_Movie
                If False AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SyncTo_Trakt(tDBElement)
                End If
        End Select

        Return New Interfaces.AddonResult
    End Function

    Public Sub SaveSetup() Implements Interfaces.Addon.SaveSetup
        Enabled = _settingspanel.chkEnabled.Checked
        _AddonSettings.GetProgress_TVShow = _settingspanel.chkGetShowProgress.Checked
        _AddonSettings.GetWatchedState = _settingspanel.chkGetWatchedState.Checked
        _AddonSettings.GetWatchedStateBeforeEdit_Movie = _settingspanel.chkGetWatchedStateBeforeEdit_Movie.Checked
        _AddonSettings.GetWatchedStateBeforeEdit_TVEpisode = _settingspanel.chkGetWatchedStateBeforeEdit_TVEpisode.Checked
        _AddonSettings.GetWatchedStateScraperMulti_Movie = _settingspanel.chkGetWatchedStateScraperMulti_Movie.Checked
        _AddonSettings.GetWatchedStateScraperMulti_TVEpisode = _settingspanel.chkGetWatchedStateScraperMulti_TVEpisode.Checked
        _AddonSettings.GetWatchedStateScraperSingle_Movie = _settingspanel.chkGetWatchedStateScraperSingle_Movie.Checked
        _AddonSettings.GetWatchedStateScraperSingle_TVEpisode = _settingspanel.chkGetWatchedStateScraperSingle_TVEpisode.Checked

        SaveSettings()
    End Sub

    Public Sub SaveSettings()
        _settings.SetBooleanSetting("CollectionRemove", _AddonSettings.CollectionRemove_Movie,, Enums.ContentType.Movie)
        _settings.SetBooleanSetting("GetProgress", _AddonSettings.GetProgress_TVShow,, Enums.ContentType.TVShow)
        _settings.SetBooleanSetting("GetWatchedState", _AddonSettings.GetWatchedState)
        _settings.SetBooleanSetting("GetWatchedStateBeforeEdit", _AddonSettings.GetWatchedStateBeforeEdit_Movie,, Enums.ContentType.Movie)
        _settings.SetBooleanSetting("GetWatchedStateBeforeEdit", _AddonSettings.GetWatchedStateBeforeEdit_TVEpisode,, Enums.ContentType.TVEpisode)
        _settings.SetBooleanSetting("GetWatchedStateScraperMulti", _AddonSettings.GetWatchedStateScraperMulti_Movie,, Enums.ContentType.Movie)
        _settings.SetBooleanSetting("GetWatchedStateScraperMulti", _AddonSettings.GetWatchedStateScraperMulti_TVEpisode,, Enums.ContentType.TVEpisode)
        _settings.SetBooleanSetting("GetWatchedStateScraperSingle", _AddonSettings.GetWatchedStateScraperSingle_Movie,, Enums.ContentType.Movie)
        _settings.SetBooleanSetting("GetWatchedStateScraperSingle", _AddonSettings.GetWatchedStateScraperSingle_TVEpisode,, Enums.ContentType.TVEpisode)
        _settings.SetBooleanSetting("SyncToTrakt", _AddonSettings.SyncToTrakt_Movie,, Enums.ContentType.Movie)
        _settings.SetStringSetting("APIAccessToken", _AddonSettings.APIAccessToken)
        _settings.SetStringSetting("APICreatedAt", _AddonSettings.APICreatedAt)
        _settings.SetStringSetting("APIExpiresInSeconds", _AddonSettings.APIExpiresInSeconds)
        _settings.SetStringSetting("APIRefreshToken", _AddonSettings.APIRefreshToken)

        _settings.Save()
    End Sub

    Public Sub ToolStripItem_Add(control As ToolStripMenuItem, value As ToolStripItem)
        If control.Owner.InvokeRequired Then
            control.Owner.Invoke(New Delegate_AddToolsStripItem(AddressOf ToolStripItem_Add), New Object() {control, value})
        Else
            control.DropDownItems.Add(value)
        End If
    End Sub

    Public Sub ToolStripItem_Remove(control As ToolStripMenuItem, value As ToolStripItem)
        If control.Owner.InvokeRequired Then
            control.Owner.Invoke(New Delegate_RemoveToolsStripItem(AddressOf ToolStripItem_Remove), New Object() {control, value})
        Else
            control.DropDownItems.Remove(value)
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure AddonSettings

#Region "Fields"

        Dim APIAccessToken As String
        Dim APICreatedAt As String
        Dim APIExpiresInSeconds As String
        Dim APIRefreshToken As String
        Dim CollectionRemove_Movie As Boolean
        Dim GetProgress_TVShow As Boolean
        Dim GetWatchedState As Boolean
        Dim GetWatchedStateBeforeEdit_Movie As Boolean
        Dim GetWatchedStateBeforeEdit_TVEpisode As Boolean
        Dim GetWatchedStateScraperMulti_Movie As Boolean
        Dim GetWatchedStateScraperMulti_TVEpisode As Boolean
        Dim GetWatchedStateScraperSingle_Movie As Boolean
        Dim GetWatchedStateScraperSingle_TVEpisode As Boolean
        Dim SyncToTrakt_Movie As Boolean

#End Region 'Fields

    End Structure
    ''' <summary>
    ''' structure used to read setting file of Kodi Interface
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()>
    <XmlRoot("interface.kodi")>
    Class KodiSettings

#Region "Fields"

        Private _hosts As New List(Of Host)
        Private _sendnotifications As Boolean
        Private _syncplaycounts As Boolean
        Private _syncplaycountshost As String

#End Region 'Fields

#Region "Properties"

        <XmlElement("sendnotifications")>
        Public Property SendNotifications() As Boolean
            Get
                Return _sendnotifications
            End Get
            Set(ByVal value As Boolean)
                _sendnotifications = value
            End Set
        End Property

        <XmlElement("syncplaycounts")>
        Public Property SyncPlayCounts() As Boolean
            Get
                Return _syncplaycounts
            End Get
            Set(ByVal value As Boolean)
                _syncplaycounts = value
            End Set
        End Property

        <XmlElement("syncplaycountshost")>
        Public Property SyncPlayCountsHost() As String
            Get
                Return _syncplaycountshost
            End Get
            Set(ByVal value As String)
                _syncplaycountshost = value
            End Set
        End Property

        <XmlElement("host")>
        Public Property Hosts() As List(Of Host)
            Get
                Return _hosts
            End Get
            Set(ByVal value As List(Of Host))
                _hosts = value
            End Set
        End Property

#End Region 'Properties

    End Class

    <Serializable()>
    Class Host

#Region "Fields"

        Private _address As String
        Private _label As String
        Private _moviesetartworkspath As String
        Private _password As String
        Private _port As Integer
        Private _realtimesync As Boolean
        Private _sources As New List(Of Source)
        Private _username As String

#End Region 'Fields

#Region "Properties"

        <XmlElement("label")>
        Public Property Label() As String
            Get
                Return _label
            End Get
            Set(ByVal value As String)
                _label = value
            End Set
        End Property

        <XmlElement("address")>
        Public Property Address() As String
            Get
                Return _address
            End Get
            Set(ByVal value As String)
                _address = value
            End Set
        End Property

        <XmlElement("port")>
        Public Property Port() As Integer
            Get
                Return _port
            End Get
            Set(ByVal value As Integer)
                _port = value
            End Set
        End Property

        <XmlElement("username")>
        Public Property Username() As String
            Get
                Return _username
            End Get
            Set(ByVal value As String)
                _username = value
            End Set
        End Property

        <XmlElement("password")>
        Public Property Password() As String
            Get
                Return _password
            End Get
            Set(ByVal value As String)
                _password = value
            End Set
        End Property

        <XmlElement("realtimesync")>
        Public Property RealTimeSync() As Boolean
            Get
                Return _realtimesync
            End Get
            Set(ByVal value As Boolean)
                _realtimesync = value
            End Set
        End Property

        <XmlElement("moviesetartworkspath")>
        Public Property MovieSetArtworksPath() As String
            Get
                Return _moviesetartworkspath
            End Get
            Set(ByVal value As String)
                _moviesetartworkspath = value
            End Set
        End Property

        <XmlElement("source")>
        Public Property Sources() As List(Of Source)
            Get
                Return _sources
            End Get
            Set(ByVal value As List(Of Source))
                _sources = value
            End Set
        End Property

#End Region 'Properties

    End Class


    <Serializable()>
    Class Source

#Region "Fields"

        Private _contenttype As Enums.ContentType
        Private _localpath As String
        Private _remotepath As String

#End Region 'Fields

#Region "Properties"

        <XmlElement("contenttype")>
        Public Property ContentType() As Enums.ContentType
            Get
                Return _contenttype
            End Get
            Set(ByVal value As Enums.ContentType)
                _contenttype = value
            End Set
        End Property

        <XmlElement("localpath")>
        Public Property LocalPath() As String
            Get
                Return _localpath
            End Get
            Set(ByVal value As String)
                _localpath = value
            End Set
        End Property

        <XmlElement("remotepath")>
        Public Property RemotePath() As String
            Get
                Return _remotepath
            End Get
            Set(ByVal value As String)
                _remotepath = value
            End Set
        End Property

#End Region 'Properties

    End Class

#End Region 'Nested Types

End Class






