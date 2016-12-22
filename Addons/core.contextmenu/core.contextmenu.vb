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

#Region "Fields"

    Private _assemblyname As String = String.Empty
    Private _enabled As Boolean = True
    Private _shortname As String = "ContextMenu"
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

    Private Sub Handle_NeedsRestart()
        RaiseEvent NeedsRestart()
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _assemblyname = strAssemblyName
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        Dim SPanel As New Containers.SettingsPanel
        _settingspanel = New frmSettingsPanel

        SPanel.Image = My.Resources.ContextMenu
        SPanel.ImageIndex = -1
        SPanel.Name = Master.eLang.GetString(1395, "Context Menu")
        SPanel.Panel = _settingspanel.pnlSettings
        SPanel.Prefix = "ContextMenu_"
        SPanel.Text = Master.eLang.GetString(1395, "Context Menu")
        SPanel.Type = Enums.SettingsPanelType.Core

        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        Return SPanel
    End Function

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        Return New Interfaces.AddonResult
    End Function

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        Return
    End Sub

#End Region 'Methods

End Class
