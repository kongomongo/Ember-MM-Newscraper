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
Imports System.IO
Imports System.Xml.Serialization

Public Class Addon
    Implements Interfaces.Addon

#Region "Delegates"

    Public Delegate Sub Delegate_AddToolsStripItem(control As ToolStripMenuItem, value As ToolStripItem)
    Public Delegate Sub Delegate_RemoveToolsStripItem(control As ToolStripMenuItem, value As ToolStripItem)

#End Region 'Delegates

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()
    Private _xmlSettingsPath As String = Path.Combine(Master.SettingsPath, "Interface.Trakt.xml")
    Private _settingspanel As frmSettingsPanel
    Private _AssemblyName As String = String.Empty
    Private WithEvents cmnuTrayToolsTrakt As New ToolStripMenuItem
    Private WithEvents mnuMainToolsTrakt As New ToolStripMenuItem
    Private _enabled As Boolean = False
    Private _name As String = "Trakt.tv"
    Private _SpecialSettings As New SpecialSettings
    Private _TraktAPI As clsAPITrakt

#End Region 'Fields

#Region "Events"

    Public Event EnabledChanged(ByVal strName As String, ByVal bEnabled As Boolean) Implements Interfaces.Addon.EnabledChanged
    Public Event GenericEvent(ByVal mType As Enums.AddonEventType, ByRef _params As List(Of Object)) Implements Interfaces.Addon.GenericEvent
    Public Event NeedsRestart() Implements Interfaces.Addon.NeedsRestart
    Public Event SettingsChanged() Implements Interfaces.Addon.SettingsChanged

#End Region 'Events

#Region "Properties"

    Property Enabled() As Boolean Implements Interfaces.Addon.Enabled
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
                                                      Enums.AddonEventType.Sync_Movie})
        End Get
    End Property

    ReadOnly Property Capabilities_ScraperCapatibility() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibility
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

    ReadOnly Property Name() As String Implements Interfaces.Addon.Name
        Get
            Return _name
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

    Public Sub Enable()
        _TraktAPI = New clsAPITrakt(_SpecialSettings)
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

    Private Sub Handle_EnabledChanged(ByVal bEnabled As Boolean)
        RaiseEvent EnabledChanged(_name, bEnabled)
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _AssemblyName = strAssemblyName
        LoadSettings()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        LoadSettings()
        Dim SPanel As New Containers.SettingsPanel
        _settingspanel = New frmSettingsPanel
        _settingspanel.chkEnabled.Checked = _enabled
        _settingspanel.chkGetShowProgress.Checked = _SpecialSettings.GetShowProgress
        _settingspanel.chkGetWatchedState.Checked = _SpecialSettings.GetWatchedState
        _settingspanel.chkGetWatchedStateBeforeEdit_Movie.Checked = _SpecialSettings.GetWatchedStateBeforeEdit_Movie
        _settingspanel.chkGetWatchedStateBeforeEdit_TVEpisode.Checked = _SpecialSettings.GetWatchedStateBeforeEdit_TVEpisode
        _settingspanel.chkGetWatchedStateScraperMulti_Movie.Checked = _SpecialSettings.GetWatchedStateScraperMulti_Movie
        _settingspanel.chkGetWatchedStateScraperMulti_TVEpisode.Checked = _SpecialSettings.GetWatchedStateScraperMulti_TVEpisode
        _settingspanel.chkGetWatchedStateScraperSingle_Movie.Checked = _SpecialSettings.GetWatchedStateScraperSingle_Movie
        _settingspanel.chkGetWatchedStateScraperSingle_TVEpisode.Checked = _SpecialSettings.GetWatchedStateScraperSingle_TVEpisode

        SPanel.ImageIndex = If(_enabled, 9, 10)
        SPanel.Name = _name
        SPanel.Panel = _settingspanel.pnlSettings
        SPanel.Prefix = "Trakt_"
        SPanel.Text = "Trakt.tv"
        SPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.EnabledChanged, AddressOf Handle_EnabledChanged
        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        Return SPanel
    End Function

    Public Sub LoadSettings()
        _SpecialSettings.Clear()
        If File.Exists(_xmlSettingsPath) Then
            Dim xmlSer As XmlSerializer = Nothing
            Using xmlSR As StreamReader = New StreamReader(_xmlSettingsPath)
                xmlSer = New XmlSerializer(GetType(SpecialSettings))
                _SpecialSettings = DirectCast(xmlSer.Deserialize(xmlSR), SpecialSettings)
            End Using
        End If
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
        Select Case eAddonEventType
            Case Enums.AddonEventType.BeforeEdit_Movie
                If _SpecialSettings.GetWatchedState AndAlso _SpecialSettings.GetWatchedStateBeforeEdit_Movie AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_Movie(tDBElement)
                End If
            Case Enums.AddonEventType.BeforeEdit_TVEpisode
                If _SpecialSettings.GetWatchedState AndAlso _SpecialSettings.GetWatchedStateBeforeEdit_TVEpisode AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_TVEpisode(tDBElement)
                End If
            'Case Enums.ModuleEventType.CommandLine
            '    _TraktAPI.SyncToEmber_All()
            Case Enums.AddonEventType.DuringScrapingMulti_Movie
                If _SpecialSettings.GetWatchedState AndAlso _SpecialSettings.GetWatchedStateScraperMulti_Movie AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_Movie(tDBElement)
                End If
            Case Enums.AddonEventType.Remove_Movie
                If _SpecialSettings.CollectionRemove_Movie AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.RemoveFromCollection_Movie(tDBElement)
                End If
            Case Enums.AddonEventType.DuringScrapingMulti_TVShow, Enums.AddonEventType.DuringScrapingMulti_TVEpisode
                If _SpecialSettings.GetWatchedState AndAlso _SpecialSettings.GetWatchedStateScraperMulti_TVEpisode AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_TVEpisode(tDBElement)
                End If
            Case Enums.AddonEventType.DuringScrapingSingle_Movie
                If _SpecialSettings.GetWatchedState AndAlso _SpecialSettings.GetWatchedStateScraperSingle_Movie AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_Movie(tDBElement)
                End If
            Case Enums.AddonEventType.DuringScrapingSingle_TVShow, Enums.AddonEventType.DuringScrapingSingle_TVEpisode
                If _SpecialSettings.GetWatchedState AndAlso _SpecialSettings.GetWatchedStateScraperSingle_TVEpisode AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SetWatchedState_TVEpisode(tDBElement)
                End If
            Case Enums.AddonEventType.Sync_Movie
                If False AndAlso tDBElement IsNot Nothing Then
                    _TraktAPI.SyncTo_Trakt(tDBElement)
                End If
        End Select

        Return New Interfaces.AddonResult
    End Function

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        Enabled = _settingspanel.chkEnabled.Checked
        _SpecialSettings.GetShowProgress = _settingspanel.chkGetShowProgress.Checked
        _SpecialSettings.GetWatchedState = _settingspanel.chkGetWatchedState.Checked
        _SpecialSettings.GetWatchedStateBeforeEdit_Movie = _settingspanel.chkGetWatchedStateBeforeEdit_Movie.Checked
        _SpecialSettings.GetWatchedStateBeforeEdit_TVEpisode = _settingspanel.chkGetWatchedStateBeforeEdit_TVEpisode.Checked
        _SpecialSettings.GetWatchedStateScraperMulti_Movie = _settingspanel.chkGetWatchedStateScraperMulti_Movie.Checked
        _SpecialSettings.GetWatchedStateScraperMulti_TVEpisode = _settingspanel.chkGetWatchedStateScraperMulti_TVEpisode.Checked
        _SpecialSettings.GetWatchedStateScraperSingle_Movie = _settingspanel.chkGetWatchedStateScraperSingle_Movie.Checked
        _SpecialSettings.GetWatchedStateScraperSingle_TVEpisode = _settingspanel.chkGetWatchedStateScraperSingle_TVEpisode.Checked

        SaveSettings()

        If bDoDispose Then
            RemoveHandler _settingspanel.EnabledChanged, AddressOf Handle_EnabledChanged
            RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
            _settingspanel.Dispose()
        End If
    End Sub

    Public Sub SaveSettings()
        If Not File.Exists(_xmlSettingsPath) OrElse (Not CBool(File.GetAttributes(_xmlSettingsPath) And FileAttributes.ReadOnly)) Then
            If File.Exists(_xmlSettingsPath) Then
                Dim fAtt As FileAttributes = File.GetAttributes(_xmlSettingsPath)
                Try
                    File.SetAttributes(_xmlSettingsPath, FileAttributes.Normal)
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                End Try
            End If
            Using xmlSW As New StreamWriter(_xmlSettingsPath)
                Dim xmlSer As New XmlSerializer(GetType(SpecialSettings))
                xmlSer.Serialize(xmlSW, _SpecialSettings)
            End Using
        End If
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

    <Serializable()>
    <XmlRoot("interface.trakt")>
    Class SpecialSettings

#Region "Fields"

        Private _collectionremove_movie As Boolean
        Private _getshowprogress As Boolean
        Private _getwatchedstate As Boolean
        Private _getwatchedstatebeforeedit_movie As Boolean
        Private _getwatchedstatebeforeedit_tvepisode As Boolean
        Private _getwatchedstatescrapermulti_movie As Boolean
        Private _getwatchedstatescrapermulti_tvepisode As Boolean
        Private _getwatchedstatescrapersingle_movie As Boolean
        Private _getwatchedstatescrapersingle_tvepisode As Boolean
        Private _synctotrakt_movie As Boolean

#End Region 'Fields

#Region "Properties"

        <XmlIgnore>
        Public Property AccessToken() As String
            Get
                Return AdvancedSettings.GetSetting("AccessToken", String.Empty, "scraper.Data.Trakttv")
            End Get
            Set(ByVal value As String)
                Using settings = New AdvancedSettings()
                    settings.SetSetting("AccessToken", value, "scraper.Data.Trakttv")
                End Using
            End Set
        End Property

        <XmlElement("collectionremove_movie")>
        Public Property CollectionRemove_Movie() As Boolean
            Get
                Return _collectionremove_movie
            End Get
            Set(ByVal value As Boolean)
                _collectionremove_movie = value
            End Set
        End Property

        <XmlIgnore>
        Public Property CreatedAt() As String
            Get
                Return AdvancedSettings.GetSetting("CreatedAt", "0", "scraper.Data.Trakttv")
            End Get
            Set(ByVal value As String)
                Using settings = New AdvancedSettings()
                    settings.SetSetting("CreatedAt", value, "scraper.Data.Trakttv")
                End Using
            End Set
        End Property

        <XmlIgnore>
        Public Property ExpiresInSeconds() As String
            Get
                Return AdvancedSettings.GetSetting("ExpiresInSeconds", "0", "scraper.Data.Trakttv")
            End Get
            Set(ByVal value As String)
                Using settings = New AdvancedSettings()
                    settings.SetSetting("ExpiresInSeconds", value, "scraper.Data.Trakttv")
                End Using
            End Set
        End Property

        <XmlElement("getshowprogress")>
        Public Property GetShowProgress() As Boolean
            Get
                Return _getshowprogress
            End Get
            Set(ByVal value As Boolean)
                _getshowprogress = value
            End Set
        End Property

        <XmlElement("getwatchedstate")>
        Public Property GetWatchedState() As Boolean
            Get
                Return _getwatchedstate
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstate = value
            End Set
        End Property

        <XmlElement("getwatchedstatebeforeedit_movie")>
        Public Property GetWatchedStateBeforeEdit_Movie() As Boolean
            Get
                Return _getwatchedstatebeforeedit_movie
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatebeforeedit_movie = value
            End Set
        End Property

        <XmlElement("getwatchedstatebeforeedit_tvepisode")>
        Public Property GetWatchedStateBeforeEdit_TVEpisode() As Boolean
            Get
                Return _getwatchedstatebeforeedit_tvepisode
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatebeforeedit_tvepisode = value
            End Set
        End Property

        <XmlElement("getwatchedstatescrapermulti_movie")>
        Public Property GetWatchedStateScraperMulti_Movie() As Boolean
            Get
                Return _getwatchedstatescrapermulti_movie
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatescrapermulti_movie = value
            End Set
        End Property

        <XmlElement("getwatchedstatescrapermulti_tvepisode")>
        Public Property GetWatchedStateScraperMulti_TVEpisode() As Boolean
            Get
                Return _getwatchedstatescrapermulti_tvepisode
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatescrapermulti_tvepisode = value
            End Set
        End Property

        <XmlElement("getwatchedstatescrapersingle_movie")>
        Public Property GetWatchedStateScraperSingle_Movie() As Boolean
            Get
                Return _getwatchedstatescrapersingle_movie
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatescrapersingle_movie = value
            End Set
        End Property

        <XmlElement("getwatchedstatescrapersingle_tvepisode")>
        Public Property GetWatchedStateScraperSingle_TVEpisode() As Boolean
            Get
                Return _getwatchedstatescrapersingle_tvepisode
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatescrapersingle_tvepisode = value
            End Set
        End Property

        <XmlIgnore>
        Public Property RefreshToken() As String
            Get
                Return AdvancedSettings.GetSetting("RefreshToken", String.Empty, "scraper.Data.Trakttv")
            End Get
            Set(ByVal value As String)
                Using settings = New AdvancedSettings()
                    settings.SetSetting("RefreshToken", value, "scraper.Data.Trakttv")
                End Using
            End Set
        End Property

        <XmlElement("synctotrakt_movie")>
        Public Property SyncToTrakt_Movie() As Boolean
            Get
                Return _synctotrakt_movie
            End Get
            Set(ByVal value As Boolean)
                _synctotrakt_movie = value
            End Set
        End Property

#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub Clear()
            _collectionremove_movie = False
            _getshowprogress = False
            _getwatchedstate = False
            _getwatchedstatebeforeedit_movie = False
            _getwatchedstatebeforeedit_tvepisode = False
            _getwatchedstatescrapermulti_movie = False
            _getwatchedstatescrapermulti_tvepisode = False
            _getwatchedstatescrapersingle_movie = False
            _getwatchedstatescrapersingle_tvepisode = False
            _synctotrakt_movie = False
        End Sub

#End Region 'Methods

    End Class
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






