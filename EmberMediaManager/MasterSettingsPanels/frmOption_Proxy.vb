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
Imports System.Net

Public Class frmOption_Proxy
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Options
    Dim _intImageIndex As Integer = 1
    Dim _intOrder As Integer = 300
    Dim _strName As String = "Option_Proxy"
    Dim _strTitle As String = Master.eLang.GetString(421, "Connection")

#End Region 'Fields

#Region "Events"

    Public Event NeedsDBClean_Movie() Implements Interfaces.MasterSettingsPanel.NeedsDBClean_Movie
    Public Event NeedsDBClean_TV() Implements Interfaces.MasterSettingsPanel.NeedsDBClean_TV
    Public Event NeedsDBUpdate_Movie() Implements Interfaces.MasterSettingsPanel.NeedsDBUpdate_Movie
    Public Event NeedsDBUpdate_TV() Implements Interfaces.MasterSettingsPanel.NeedsDBUpdate_TV
    Public Event NeedsReload_Movie() Implements Interfaces.MasterSettingsPanel.NeedsReload_Movie
    Public Event NeedsReload_MovieSet() Implements Interfaces.MasterSettingsPanel.NeedsReload_MovieSet
    Public Event NeedsReload_TVEpisode() Implements Interfaces.MasterSettingsPanel.NeedsReload_TVEpisode
    Public Event NeedsReload_TVShow() Implements Interfaces.MasterSettingsPanel.NeedsReload_TVShow
    Public Event NeedsRestart() Implements Interfaces.MasterSettingsPanel.NeedsRestart
    Public Event SettingsChanged() Implements Interfaces.MasterSettingsPanel.SettingsChanged

#End Region 'Events

#Region "Properties"

    Public ReadOnly Property Order() As Integer Implements Interfaces.MasterSettingsPanel.Order
        Get
            Return _intOrder
        End Get
    End Property

#End Region 'Properties

#Region "Handles"

    Private Sub Handle_NeedsDBClean_Movie()
        RaiseEvent NeedsDBClean_Movie()
    End Sub

    Private Sub Handle_NeedsDBClean_TV()
        RaiseEvent NeedsDBClean_TV()
    End Sub

    Private Sub Handle_NeedsDBUpdate_Movie()
        RaiseEvent NeedsDBUpdate_Movie()
    End Sub

    Private Sub Handle_NeedsDBUpdate_TV()
        RaiseEvent NeedsDBUpdate_TV()
    End Sub

    Private Sub Handle_NeedsReload_Movie()
        RaiseEvent NeedsReload_Movie()
    End Sub

    Private Sub Handle_NeedsReload_MovieSet()
        RaiseEvent NeedsReload_MovieSet()
    End Sub

    Private Sub Handle_NeedsReload_TVEpisode()
        RaiseEvent NeedsReload_TVEpisode()
    End Sub

    Private Sub Handle_NeedsReload_TVShow()
        RaiseEvent NeedsReload_TVShow()
    End Sub

    Private Sub Handle_NeedsRestart()
        RaiseEvent NeedsRestart()
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

#End Region 'Handles

#Region "Constructors"

    Public Sub New()
        InitializeComponent()
        SetUp()
    End Sub

#End Region 'Constructors 

#Region "Interface Methods"

    Public Sub DoDispose() Implements Interfaces.MasterSettingsPanel.DoDispose
        Dispose()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.MasterSettingsPanel.InjectSettingsPanel
        LoadSettings()

        Dim nSettingsPanel As New Containers.SettingsPanel With {
            .ImageIndex = _intImageIndex,
            .Name = _strName,
            .Order = _intOrder,
            .Panel = pnlSettings,
            .Prefix = _strName,
            .Title = _strTitle,
            .Type = _ePanelType
        }

        Return nSettingsPanel
    End Function

    Public Sub LoadSettings()
        With Master.eSettings.Options.Proxy
            If Not String.IsNullOrEmpty(.URI) AndAlso .Port >= 0 Then
                chkProxyEnable.Checked = True
                txtProxyURI.Text = .URI
                txtProxyPort.Text = .Port.ToString

                If Not String.IsNullOrEmpty(.Credentials.UserName) Then
                    chkProxyCredsEnable.Checked = True
                    txtProxyUsername.Text = .Credentials.UserName
                    txtProxyPassword.Text = .Credentials.Password
                    txtProxyDomain.Text = .Credentials.Domain
                End If
            End If
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.Options.Proxy
            If Not String.IsNullOrEmpty(txtProxyURI.Text) AndAlso Not String.IsNullOrEmpty(txtProxyPort.Text) Then
                .URI = txtProxyURI.Text
                .Port = Convert.ToInt32(txtProxyPort.Text)

                If Not String.IsNullOrEmpty(txtProxyUsername.Text) AndAlso Not String.IsNullOrEmpty(txtProxyPassword.Text) Then
                    .Credentials.UserName = txtProxyUsername.Text
                    .Credentials.Password = txtProxyPassword.Text
                    .Credentials.Domain = txtProxyDomain.Text
                Else
                    .Credentials = New NetworkCredential
                End If
            Else
                .URI = String.Empty
                .Port = -1
            End If
        End With
    End Sub

#End Region 'Interface Methods

#Region "Methods"

    Private Sub chkProxyCredsEnable_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkProxyCredsEnable.CheckedChanged
        EnableApplyButton()

        txtProxyDomain.Enabled = chkProxyCredsEnable.Checked
        txtProxyPassword.Enabled = chkProxyCredsEnable.Checked
        txtProxyUsername.Enabled = chkProxyCredsEnable.Checked

        If Not chkProxyCredsEnable.Checked Then
            txtProxyDomain.Text = String.Empty
            txtProxyPassword.Text = String.Empty
            txtProxyUsername.Text = String.Empty
        End If
    End Sub

    Private Sub chkProxyEnable_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkProxyEnable.CheckedChanged
        EnableApplyButton()

        gbProxyCredsOpts.Enabled = chkProxyEnable.Checked
        txtProxyPort.Enabled = chkProxyEnable.Checked
        txtProxyURI.Enabled = chkProxyEnable.Checked

        If Not chkProxyEnable.Checked Then
            chkProxyCredsEnable.Checked = False
            txtProxyDomain.Text = String.Empty
            txtProxyPassword.Text = String.Empty
            txtProxyPort.Text = String.Empty
            txtProxyURI.Text = String.Empty
            txtProxyUsername.Text = String.Empty
        End If
    End Sub

    Private Sub EnableApplyButton() Handles _
             txtProxyDomain.TextChanged,
             txtProxyPassword.TextChanged,
             txtProxyPort.TextChanged,
             txtProxyURI.TextChanged,
             txtProxyUsername.TextChanged

        Handle_SettingsChanged()
    End Sub

    Private Sub SetUp()
        chkProxyCredsEnable.Text = Master.eLang.GetString(677, "Enable Credentials")
        chkProxyEnable.Text = Master.eLang.GetString(673, "Enable Proxy")
        gbProxyCredsOpts.Text = Master.eLang.GetString(676, "Credentials")
        gbProxyOpts.Text = Master.eLang.GetString(672, "Proxy")
        lblProxyDomain.Text = String.Concat(Master.eLang.GetString(678, "Domain"), ":")
        lblProxyPassword.Text = String.Concat(Master.eLang.GetString(426, "Password"), ":")
        lblProxyPort.Text = String.Concat(Master.eLang.GetString(675, "Proxy Port"), ":")
        lblProxyURI.Text = String.Concat(Master.eLang.GetString(674, "Proxy URL"), ":")
        lblProxyUsername.Text = String.Concat(Master.eLang.GetString(425, "Username"), ":")
    End Sub

    Private Sub txtProxyPort_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtProxyPort.KeyPress
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

#End Region 'Methods

End Class