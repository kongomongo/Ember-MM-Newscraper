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

Public Class Core
    Implements Interfaces.Addon

#Region "Delegates"

    Public Delegate Sub Delegate_SetTabPageItem(value As TabPage)
    Public Delegate Sub Delegate_RemoveTabPageItem(value As TabPage)
    Public Delegate Sub Delegate_TabPageAdd(cTabs As List(Of TabPage), tabc As System.Windows.Forms.TabControl)

#End Region 'Delegates

#Region "Fields"

    Private _assemblyname As String
    Private _enabled As Boolean = True
    Private _shortname As String = "MediaListEditor"
    Private _settingspanel As frmSettingsPanel

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
            Return
        End Set
    End Property

    Public ReadOnly Property Capabilities_AddonEventTypes() As List(Of Enums.AddonEventType) Implements Interfaces.Addon.Capabilities_AddonEventTypes
        Get
            Return New List(Of Enums.AddonEventType)
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
            Return Diagnostics.FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Private Sub Enable()
        Dim CustomTabs As List(Of AdvancedSettingsComplexSettingsTableItem) = clsXMLAdvancedSettings.GetComplexSetting("CustomTabs", "*EmberAPP")
        If CustomTabs IsNot Nothing Then
            Dim tabc As New TabControl
            Dim NewCustomTabs As New List(Of TabPage)
            tabc = AddonsManager.Instance.RuntimeObjects.MainTabControl
            For Each cTab In CustomTabs
                If Master.DB.ViewExists(cTab.Value) Then
                    Dim cTabType As Enums.ContentType = Enums.ContentType.None
                    If cTab.Value.StartsWith("movie-") Then
                        cTabType = Enums.ContentType.Movie
                    ElseIf cTab.Value.StartsWith("sets-") Then
                        cTabType = Enums.ContentType.MovieSet
                    ElseIf cTab.Value.StartsWith("tvshow-") Then
                        cTabType = Enums.ContentType.TV
                    End If
                    If Not cTabType = Enums.ContentType.None AndAlso Not String.IsNullOrEmpty(cTab.Name) Then
                        Dim NewTabPage As New TabPage
                        NewTabPage.Text = cTab.Name
                        NewTabPage.Tag = New Structures.MainTabType With {.ContentName = cTab.Name, .ContentType = cTabType, .DefaultList = cTab.Value}
                        NewCustomTabs.Add(NewTabPage)
                    End If
                End If
            Next
            TabPageAdd(NewCustomTabs, tabc)
        End If
    End Sub

    Private Sub Handle_NeedsRestart()
        RaiseEvent NeedsRestart()
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _assemblyname = strAssemblyName
        Enable()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        Dim nSettingsPanel As New Containers.SettingsPanel
        _settingspanel = New frmSettingsPanel

        nSettingsPanel.Image = My.Resources.icon
        nSettingsPanel.ImageIndex = -1
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "MediaListEditor_"
        nSettingsPanel.Title = Master.eLang.GetString(1385, "Media List Editor")
        nSettingsPanel.Type = Enums.SettingsPanelType.Core

        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        Return nSettingsPanel
    End Function

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        Return New Interfaces.AddonResult
    End Function

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        If Not _settingspanel Is Nothing Then _settingspanel.SaveChanges()

        If bDoDispose Then
            RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
            _settingspanel.Dispose()
        End If
    End Sub

    Public Sub TabPageAdd(cTabs As List(Of TabPage), tabc As System.Windows.Forms.TabControl)
        If (tabc.InvokeRequired) Then
            tabc.Invoke(New Delegate_TabPageAdd(AddressOf TabPageAdd), New Object() {cTabs, tabc})
            Exit Sub
        End If
        tabc.TabPages.AddRange(cTabs.ToArray)
    End Sub

#End Region 'Methods

End Class
