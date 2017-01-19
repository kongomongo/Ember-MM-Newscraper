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

Public Class Addon
    Implements Interfaces.Addon

#Region "Delegates"

    Public Delegate Sub Delegate_AddToolsStripItem(control As ToolStripMenuItem, value As ToolStripItem)
    Public Delegate Sub Delegate_RemoveToolsStripItem(control As ToolStripMenuItem, value As ToolStripItem)

#End Region 'Delegates

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _assemblyname As String
    Private _enabled As Boolean = False
    Private _shortname As String = "WebsiteCreator"

    Private _addonsettings As New AddonSettings
    Private _settings As New XMLAddonSettings
    Private _settingspanel As frmSettingsPanel

    Private WithEvents mnuMainToolsWebCreator As New ToolStripMenuItem
    Private WithEvents cmnuTrayToolsWebCreator As New ToolStripMenuItem

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
                                                     Enums.AddonEventType.CommandLine
                                                     })
        End Get
    End Property

    Public ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibilities
        Get
            Return New List(Of Enums.ScraperCapatibility)
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
            Return FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

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
        _settingspanel.chkExportMissingEpisodes.Checked = _addonsettings.ExportMissingEpisodes
        _settingspanel.txtExportPath.Text = _addonsettings.ExportPath

        nSettingsPanel.ImageIndex = If(_enabled, 9, 10)
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "WebsiteCreator_"
        nSettingsPanel.Title = Master.eLang.GetString(335, "Website Creator")
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        AddHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
        Return nSettingsPanel
    End Function

    Public Sub LoadSettings()
        _addonsettings.DefaultTemplate = _settings.GetStringSetting("DefaultTemplate", "template")
        _addonsettings.ExportPath = _settings.GetStringSetting("ExportPath", String.Empty)
        _addonsettings.ExportMissingEpisodes = _settings.GetBooleanSetting("ExportMissingEpisodes", False)
    End Sub

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        Select Case eAddonEventType
            Case Enums.AddonEventType.CommandLine
                Dim strTemplatePath As String = String.Empty
                Dim strBuildPath As String = String.Empty

                If lstParams IsNot Nothing Then
                    For Each tParameter In lstParams
                        'check if tParameter is a path or template name
                        If Not String.IsNullOrEmpty(Path.GetPathRoot(tParameter.ToString)) Then
                            strBuildPath = tParameter.ToString
                        Else
                            'search in Ember custom templates
                            Dim diCustom As DirectoryInfo = New DirectoryInfo(Path.Combine(Master.SettingsPath, "Templates"))
                            If diCustom.Exists Then
                                For Each i As DirectoryInfo In diCustom.GetDirectories
                                    If Not (i.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden AndAlso i.Name = tParameter.ToString Then
                                        strTemplatePath = i.FullName
                                    End If
                                Next
                            End If

                            If String.IsNullOrEmpty(strTemplatePath) Then
                                'search in Ember default templates
                                Dim diDefault As DirectoryInfo = New DirectoryInfo(Path.Combine(Functions.AppPath, "Addons", "Templates"))
                                If diDefault.Exists Then
                                    For Each i As DirectoryInfo In diDefault.GetDirectories
                                        If Not (i.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden AndAlso i.Name = tParameter.ToString Then
                                            strTemplatePath = i.FullName
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    Next
                End If

                If String.IsNullOrEmpty(strBuildPath) Then
                    strBuildPath = _addonsettings.ExportPath
                End If

                If String.IsNullOrEmpty(strTemplatePath) Then
                    strTemplatePath = _addonsettings.DefaultTemplate
                End If

                Dim lstMovieList As New List(Of Database.DBElement)
                ' Load nfo movies using path from DB
                Using SQLNewcommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                    SQLNewcommand.CommandText = String.Concat("SELECT idMovie FROM movielist ORDER BY SortedTitle COLLATE NOCASE;")
                    Using SQLreader As SQLite.SQLiteDataReader = SQLNewcommand.ExecuteReader()
                        While SQLreader.Read()
                            lstMovieList.Add(Master.DB.Load_Movie(Convert.ToInt32(SQLreader("idMovie"))))
                        End While
                    End Using
                End Using

                Dim lstTVShowList As New List(Of Database.DBElement)
                ' Load nfo tv shows using path from DB
                Using SQLNewcommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                    SQLNewcommand.CommandText = String.Concat("SELECT idShow FROM tvshowlist ORDER BY SortedTitle COLLATE NOCASE;")
                    Using SQLreader As SQLite.SQLiteDataReader = SQLNewcommand.ExecuteReader()
                        While SQLreader.Read()
                            lstTVShowList.Add(Master.DB.Load_TVShow(Convert.ToInt32(SQLreader("idShow")), True, True, _addonsettings.ExportMissingEpisodes))
                        End While
                    End Using
                End Using

                Dim nWebsiteCreator As New clsAPIWebsiteCreator
                nWebsiteCreator.CreateTemplate(strTemplatePath, lstMovieList, lstTVShowList, strBuildPath, Nothing)
        End Select

        Return New Interfaces.AddonResult
    End Function

    Sub Disable()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        RemoveToolsStripItem(tsi, mnuMainToolsWebCreator)

        'cmnuTrayTools
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        RemoveToolsStripItem(tsi, cmnuTrayToolsWebCreator)
    End Sub

    Public Sub RemoveToolsStripItem(control As ToolStripMenuItem, value As ToolStripItem)
        If control.Owner.InvokeRequired Then
            control.Owner.Invoke(New Delegate_RemoveToolsStripItem(AddressOf RemoveToolsStripItem), New Object() {control, value})
        Else
            control.DropDownItems.Remove(value)
        End If
    End Sub

    Sub Enable()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools
        mnuMainToolsWebCreator.Image = New Bitmap(My.Resources.icon)
        mnuMainToolsWebCreator.Text = Master.eLang.GetString(335, "Website Creator")
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        AddToolsStripItem(tsi, mnuMainToolsWebCreator)

        'cmnuTrayTools
        cmnuTrayToolsWebCreator.Image = New Bitmap(My.Resources.icon)
        cmnuTrayToolsWebCreator.Text = Master.eLang.GetString(335, "Website Creator")
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        AddToolsStripItem(tsi, cmnuTrayToolsWebCreator)
    End Sub

    Public Sub AddToolsStripItem(control As ToolStripMenuItem, value As ToolStripItem)
        If control.Owner.InvokeRequired Then
            control.Owner.Invoke(New Delegate_AddToolsStripItem(AddressOf AddToolsStripItem), New Object() {control, value})
        Else
            control.DropDownItems.Add(value)
        End If
    End Sub

    Private Sub MyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainToolsWebCreator.Click, cmnuTrayToolsWebCreator.Click
        RaiseEvent GenericEvent(Enums.AddonEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", False}))
        LoadSettings()
        Using dExportMovies As New dlgCreateWebsite(_addonsettings)
            dExportMovies.ShowDialog()
        End Using

        RaiseEvent GenericEvent(Enums.AddonEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", True}))
    End Sub

    Public Sub SaveSettings()
        _settings.SetBooleanSetting("ExportMissingEpisodes", _addonsettings.ExportMissingEpisodes)
        _settings.SetStringSetting("DefaultTemplate", _addonsettings.DefaultTemplate)
        _settings.SetStringSetting("ExportPath", _addonsettings.ExportPath)
        _settings.Save()
    End Sub

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        Enabled = _settingspanel.chkEnabled.Checked
        _addonsettings.DefaultTemplate = _settingspanel.txtExportPath.Text
        _addonsettings.ExportMissingEpisodes = _settingspanel.chkExportMissingEpisodes.Checked
        SaveSettings()
        If bDoDispose Then
            RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
            RemoveHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
            _settingspanel.Dispose()
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class AddonSettings

#Region "Fields"

        Public DefaultTemplate As String = String.Empty
        Public ExportPath As String = String.Empty
        Public ExportMissingEpisodes As Boolean

#End Region 'Fields

    End Class

#End Region 'Nested Types

End Class