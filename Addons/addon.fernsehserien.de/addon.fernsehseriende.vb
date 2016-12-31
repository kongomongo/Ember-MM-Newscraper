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
    Private _enabled As Boolean = False
    Private _shortname As String = "Fernsehserien.de"
    Private _settingspanel As frmSettingsPanel

    Private _addonsettings As New AddonSettings
    Private _settings As New XMLAddonSettings

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
                                                     Enums.AddonEventType.BeforeScraping_TVEpisode
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

    Private Sub Handle_StateChanged(ByVal bEnabled As Boolean)
        RaiseEvent StateChanged(_shortname, bEnabled)
    End Sub

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _assemblyname = strAssemblyName
        LoadSettings()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        Dim nSettingsPanel As New Containers.SettingsPanel
        _settingspanel = New frmSettingsPanel
        _settingspanel.chkEnabled.Checked = _enabled
        _settingspanel.Stations = _addonsettings.Stations
        _settingspanel.txtRegexFilename.Text = _addonsettings.RegexFilename
        _settingspanel.txtTimeOffset.Text = CStr(_addonsettings.TimeOffset)

        nSettingsPanel.ImageIndex = If(_enabled, 9, 10)
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "Fernsehserien.de_"
        nSettingsPanel.Title = "Fernsehserien.de"
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.NeedsRestart, AddressOf Handle_NeedsRestart
        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        AddHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
        Return nSettingsPanel
    End Function

    Public Sub LoadSettings()
        _addonsettings = New AddonSettings
        _addonsettings.TimeOffset = _settings.GetIntegerSetting("TimeOffset", 10)
        _addonsettings.RegexFilename = _settings.GetStringSetting("RegexFilename", "(?<YEAR>\d{4})-(?<MONTH>\d\d?)-(?<DAY>\d\d?)_(?<HOUR>\d\d?)-(?<MINUTE>\d\d?).*?_(?<STATION>.*?)_.*?")

        Dim lstStations As List(Of AdvancedSettingsComplexSettingsTableItem) = _settings.GetComplexSetting("Stations")
        If lstStations IsNot Nothing Then
            For Each nStation In lstStations
                _addonsettings.Stations.Add(nStation.Value)
            Next
        End If
    End Sub

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        logger.Trace("[FernsehserienDE] [Run] [Start]")
        Dim nModuleResult As New Interfaces.AddonResult

        LoadSettings()

        Dim nScraper As New clsFernsehserienDE(_addonsettings)

        Select Case eAddonEventType
            Case Enums.AddonEventType.BeforeScraping_TVEpisode
                If tDBElement.ContentType = Enums.ContentType.TVEpisode Then
                    nScraper.GetInfo_TVEpisode(tDBElement)
                End If
        End Select

        logger.Trace("[FernsehserienDE] [Run] [Done]")
        Return nModuleResult
    End Function

    Public Sub SaveSettings()
        _settings = New XMLAddonSettings
        _settings.SetIntegerSetting("TimeOffset", _addonsettings.TimeOffset)
        _settings.SetStringSetting("RegexFilename", _addonsettings.RegexFilename)

        Dim nStations As New List(Of AdvancedSettingsComplexSettingsTableItem)
        For Each strStation In _addonsettings.Stations
            nStations.Add(New AdvancedSettingsComplexSettingsTableItem With {
                        .Name = String.Empty,
                        .Value = strStation
                        })
        Next
        If nStations IsNot Nothing Then
            _settings.SetComplexSetting("Stations", nStations)
        End If

        _settings.Save()
    End Sub

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        Enabled = _settingspanel.chkEnabled.Checked
        _addonsettings.RegexFilename = _settingspanel.txtRegexFilename.Text
        _addonsettings.Stations = _settingspanel.Stations
        _addonsettings.TimeOffset = If(Integer.TryParse(_settingspanel.txtTimeOffset.Text.Trim, 0), CInt(_settingspanel.txtTimeOffset.Text.Trim), 5)

        SaveSettings()
        If bDoDispose Then
            RemoveHandler _settingspanel.NeedsRestart, AddressOf Handle_NeedsRestart
            RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
            RemoveHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
            _settingspanel.Dispose()
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class AddonSettings

#Region "Fields"

        Public RegexFilename As String
        Public TimeOffset As Integer
        Public Stations As New List(Of String)

#End Region 'Fields

    End Class

#End Region 'Nested Types

End Class
