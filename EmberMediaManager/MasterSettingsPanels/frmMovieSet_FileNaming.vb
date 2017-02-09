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
Imports System.Windows.Forms

Public Class frmMovieSet_FileNaming
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.MovieSet
    Dim _intImageIndex As Integer = 3
    Dim _intOrder As Integer = 200
    Dim _strName As String = "MovieSet_FileNaming"
    Dim _strTitle As String = Master.eLang.GetString(471, "File Naming")

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

#Region "Interface Methodes"

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
        With Master.eSettings
            chkMovieSetCleanDB.Checked = .MovieSetCleanDB
            chkMovieSetCleanFiles.Checked = .MovieSetCleanFiles

            '********* Kodi Extended Images settings ***********
            chkMovieSetUseExtended.Checked = .MovieSetUseExtended
            chkMovieSetBannerExtended.Checked = .MovieSetBannerExtended
            chkMovieSetClearArtExtended.Checked = .MovieSetClearArtExtended
            chkMovieSetClearLogoExtended.Checked = .MovieSetClearLogoExtended
            chkMovieSetDiscArtExtended.Checked = .MovieSetDiscArtExtended
            chkMovieSetFanartExtended.Checked = .MovieSetFanartExtended
            chkMovieSetLandscapeExtended.Checked = .MovieSetLandscapeExtended
            chkMovieSetPosterExtended.Checked = .MovieSetPosterExtended
            txtMovieSetPathExtended.Text = .MovieSetPathExtended

            '**************** XBMC MSAA settings ***************
            chkMovieSetUseMSAA.Checked = .MovieSetUseMSAA
            chkMovieSetBannerMSAA.Checked = .MovieSetBannerMSAA
            chkMovieSetClearArtMSAA.Checked = .MovieSetClearArtMSAA
            chkMovieSetClearLogoMSAA.Checked = .MovieSetClearLogoMSAA
            chkMovieSetFanartMSAA.Checked = .MovieSetFanartMSAA
            chkMovieSetLandscapeMSAA.Checked = .MovieSetLandscapeMSAA
            chkMovieSetPosterMSAA.Checked = .MovieSetPosterMSAA
            txtMovieSetPathMSAA.Text = .MovieSetPathMSAA

            '***************** Expert settings *****************
            chkMovieSetUseExpert.Checked = .MovieSetUseExpert

            '***************** Expert Single ******************
            txtMovieSetBannerExpertSingle.Text = .MovieSetBannerExpertSingle
            txtMovieSetClearArtExpertSingle.Text = .MovieSetClearArtExpertSingle
            txtMovieSetClearLogoExpertSingle.Text = .MovieSetClearLogoExpertSingle
            txtMovieSetDiscArtExpertSingle.Text = .MovieSetDiscArtExpertSingle
            txtMovieSetFanartExpertSingle.Text = .MovieSetFanartExpertSingle
            txtMovieSetLandscapeExpertSingle.Text = .MovieSetLandscapeExpertSingle
            txtMovieSetNFOExpertSingle.Text = .MovieSetNFOExpertSingle
            txtMovieSetPathExpertSingle.Text = .MovieSetPathExpertSingle
            txtMovieSetPosterExpertSingle.Text = .MovieSetPosterExpertSingle
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings
            .MovieSetCleanDB = chkMovieSetCleanDB.Checked
            .MovieSetCleanFiles = chkMovieSetCleanFiles.Checked

            '**************** XBMC MSAA settings ***************
            .MovieSetUseMSAA = chkMovieSetUseMSAA.Checked
            .MovieSetBannerMSAA = chkMovieSetBannerMSAA.Checked
            .MovieSetClearArtMSAA = chkMovieSetClearArtMSAA.Checked
            .MovieSetClearLogoMSAA = chkMovieSetClearLogoMSAA.Checked
            .MovieSetFanartMSAA = chkMovieSetFanartMSAA.Checked
            .MovieSetLandscapeMSAA = chkMovieSetLandscapeMSAA.Checked
            .MovieSetPathMSAA = txtMovieSetPathMSAA.Text
            .MovieSetPosterMSAA = chkMovieSetPosterMSAA.Checked

            '********* XBMC Extended Images settings ***********
            .MovieSetUseExtended = chkMovieSetUseExtended.Checked
            .MovieSetBannerExtended = chkMovieSetBannerExtended.Checked
            .MovieSetClearArtExtended = chkMovieSetClearArtExtended.Checked
            .MovieSetClearLogoExtended = chkMovieSetClearLogoExtended.Checked
            .MovieSetDiscArtExtended = chkMovieSetDiscArtExtended.Checked
            .MovieSetFanartExtended = chkMovieSetFanartExtended.Checked
            .MovieSetLandscapeExtended = chkMovieSetLandscapeExtended.Checked
            .MovieSetPathExtended = txtMovieSetPathExtended.Text
            .MovieSetPosterExtended = chkMovieSetPosterExtended.Checked

            '***************** Expert settings ****************
            .MovieSetUseExpert = chkMovieSetUseExpert.Checked

            '***************** Expert Single ******************
            .MovieSetBannerExpertSingle = txtMovieSetBannerExpertSingle.Text
            .MovieSetClearArtExpertSingle = txtMovieSetClearArtExpertSingle.Text
            .MovieSetClearLogoExpertSingle = txtMovieSetClearLogoExpertSingle.Text
            .MovieSetDiscArtExpertSingle = txtMovieSetDiscArtExpertSingle.Text
            .MovieSetFanartExpertSingle = txtMovieSetFanartExpertSingle.Text
            .MovieSetLandscapeExpertSingle = txtMovieSetLandscapeExpertSingle.Text
            .MovieSetNFOExpertSingle = txtMovieSetNFOExpertSingle.Text
            .MovieSetPathExpertSingle = txtMovieSetPathExpertSingle.Text
            .MovieSetPosterExpertSingle = txtMovieSetPosterExpertSingle.Text
        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub btnMovieSetPathExtendedBrowse_Click(sender As Object, e As EventArgs) Handles btnMovieSetPathExtendedBrowse.Click
        Try
            With fbdBrowse
                fbdBrowse.Description = Master.eLang.GetString(1030, "Select the folder where you wish to store your movie sets images...")
                If .ShowDialog = DialogResult.OK Then
                    If Not String.IsNullOrEmpty(.SelectedPath.ToString) AndAlso Directory.Exists(.SelectedPath) Then
                        txtMovieSetPathExtended.Text = .SelectedPath.ToString
                    End If
                End If
            End With
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnMovieSetPathMSAABrowse_Click(sender As Object, e As EventArgs) Handles btnMovieSetPathMSAABrowse.Click
        Try
            With fbdBrowse
                fbdBrowse.Description = Master.eLang.GetString(1030, "Select the folder where you wish to store your movie sets images...")
                If .ShowDialog = DialogResult.OK Then
                    If Not String.IsNullOrEmpty(.SelectedPath.ToString) AndAlso Directory.Exists(.SelectedPath) Then
                        txtMovieSetPathMSAA.Text = .SelectedPath.ToString
                    End If
                End If
            End With
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnMovieSetPathExpertSingleBrowse_Click(sender As Object, e As EventArgs) Handles btnMovieSetPathExpertSingleBrowse.Click
        Try
            With fbdBrowse
                fbdBrowse.Description = Master.eLang.GetString(1030, "Select the folder where you wish to store your movie sets images...")
                If .ShowDialog = DialogResult.OK Then
                    If Not String.IsNullOrEmpty(.SelectedPath.ToString) AndAlso Directory.Exists(.SelectedPath) Then
                        txtMovieSetPathExpertSingle.Text = .SelectedPath.ToString
                    End If
                End If
            End With
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub chkMovieSetUseExpert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieSetUseExpert.CheckedChanged
        EnableApplyButton()

        btnMovieSetPathExpertSingleBrowse.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetBannerExpertSingle.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetClearArtExpertSingle.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetClearLogoExpertSingle.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetDiscArtExpertSingle.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetFanartExpertSingle.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetLandscapeExpertSingle.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetNFOExpertSingle.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetPathExpertSingle.Enabled = chkMovieSetUseExpert.Checked
        txtMovieSetPosterExpertSingle.Enabled = chkMovieSetUseExpert.Checked
    End Sub

    Private Sub chkMovieSetUseExtended_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieSetUseExtended.CheckedChanged
        EnableApplyButton()

        btnMovieSetPathExtendedBrowse.Enabled = chkMovieSetUseExtended.Checked
        chkMovieSetBannerExtended.Enabled = chkMovieSetUseExtended.Checked
        chkMovieSetClearArtExtended.Enabled = chkMovieSetUseExtended.Checked
        chkMovieSetClearLogoExtended.Enabled = chkMovieSetUseExtended.Checked
        chkMovieSetDiscArtExtended.Enabled = chkMovieSetUseExtended.Checked
        chkMovieSetFanartExtended.Enabled = chkMovieSetUseExtended.Checked
        chkMovieSetLandscapeExtended.Enabled = chkMovieSetUseExtended.Checked
        chkMovieSetPosterExtended.Enabled = chkMovieSetUseExtended.Checked
        txtMovieSetPathExtended.Enabled = chkMovieSetUseExtended.Checked

        If Not chkMovieSetUseExtended.Checked Then
            chkMovieSetBannerExtended.Checked = False
            chkMovieSetClearArtExtended.Checked = False
            chkMovieSetClearLogoExtended.Checked = False
            chkMovieSetDiscArtExtended.Checked = False
            chkMovieSetFanartExtended.Checked = False
            chkMovieSetLandscapeExtended.Checked = False
            chkMovieSetPosterExtended.Checked = False
        Else
            chkMovieSetBannerExtended.Checked = True
            chkMovieSetClearArtExtended.Checked = True
            chkMovieSetClearLogoExtended.Checked = True
            chkMovieSetDiscArtExtended.Checked = True
            chkMovieSetFanartExtended.Checked = True
            chkMovieSetLandscapeExtended.Checked = True
            chkMovieSetPosterExtended.Checked = True
        End If
    End Sub

    Private Sub chkMovieSetUseMSAA_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieSetUseMSAA.CheckedChanged
        EnableApplyButton()

        btnMovieSetPathMSAABrowse.Enabled = chkMovieSetUseMSAA.Checked
        chkMovieSetBannerMSAA.Enabled = chkMovieSetUseMSAA.Checked
        chkMovieSetClearArtMSAA.Enabled = chkMovieSetUseMSAA.Checked
        chkMovieSetClearLogoMSAA.Enabled = chkMovieSetUseMSAA.Checked
        chkMovieSetFanartMSAA.Enabled = chkMovieSetUseMSAA.Checked
        chkMovieSetLandscapeMSAA.Enabled = chkMovieSetUseMSAA.Checked
        chkMovieSetPosterMSAA.Enabled = chkMovieSetUseMSAA.Checked
        txtMovieSetPathMSAA.Enabled = chkMovieSetUseMSAA.Checked

        If Not chkMovieSetUseMSAA.Checked Then
            chkMovieSetBannerMSAA.Checked = False
            chkMovieSetClearArtMSAA.Checked = False
            chkMovieSetClearLogoMSAA.Checked = False
            chkMovieSetFanartMSAA.Checked = False
            chkMovieSetLandscapeMSAA.Checked = False
            chkMovieSetPosterMSAA.Checked = False
        Else
            chkMovieSetBannerMSAA.Checked = True
            chkMovieSetClearArtMSAA.Checked = True
            chkMovieSetClearLogoMSAA.Checked = True
            chkMovieSetFanartMSAA.Checked = True
            chkMovieSetLandscapeMSAA.Checked = True
            chkMovieSetPosterMSAA.Checked = True
        End If
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub pbMSAAInfo_Click(sender As Object, e As EventArgs) Handles pbMSAAInfo.Click
        If Master.isWindows Then
            Process.Start("http://forum.xbmc.org/showthread.php?tid=153502")
        Else
            Using Explorer As New Process
                Explorer.StartInfo.FileName = "xdg-open"
                Explorer.StartInfo.Arguments = "http://forum.xbmc.org/showthread.php?tid=153502"
                Explorer.Start()
            End Using
        End If
    End Sub

    Private Sub SetUp()
        tpMovieSetSourcesFilenamingExpert.Text = Master.eLang.GetString(439, "Expert")
        gbMovieSetSourcesFilenamingExpertOpts.Text = Master.eLang.GetString(1181, "Expert Settings")
        gbMovieSetSourcesFilenamingKodiExtendedOpts.Text = Master.eLang.GetString(822, "Extended Images")
        gbMovieSetSourcesFilenamingOpts.Text = Master.eLang.GetString(471, "File Naming")
        gbMovieSetSourcesMiscOpts.Text = Master.eLang.GetString(429, "Miscellaneous")
        chkMovieSetCleanFiles.Text = Master.eLang.GetString(1276, "Remove Images and NFOs with MovieSets")
        tpMovieSetFilenamingExpertSingle.Text = Master.eLang.GetString(879, "Single Folder")
        chkMovieSetCleanDB.Text = Master.eLang.GetString(668, "Clean database after updating library")

        'Banner
        Dim strBanner As String = Master.eLang.GetString(838, "Banner")
        lblMovieSetSourcesFilenamingExpertSingleBanner.Text = strBanner
        lblMovieSetSourcesFilenamingKodiExtendedBanner.Text = strBanner
        lblMovieSetSourcesFilenamingKodiMSAABanner.Text = strBanner

        'ClearArt
        Dim strClearArt As String = Master.eLang.GetString(1096, "ClearArt")
        lblMovieSetSourcesFilenamingExpertSingleClearArt.Text = strClearArt
        lblMovieSetSourcesFilenamingKodiExtendedClearArt.Text = strClearArt
        lblMovieSetSourcesFilenamingKodiMSAAClearArt.Text = strClearArt

        'ClearLogo
        Dim strClearLogo As String = Master.eLang.GetString(1097, "ClearLogo")
        lblMovieSetSourcesClearLogoExpertSingle.Text = strClearLogo
        lblMovieSetSourcesFilenamingKodiExtendedClearLogo.Text = strClearLogo
        lblMovieSetSourcesFilenamingKodiMSAAClearLogo.Text = strClearLogo

        'DiscArt
        Dim strDiscArt As String = Master.eLang.GetString(1098, "DiscArt")
        lblMovieSetSourcesFilenamingExpertSingleDiscArt.Text = strDiscArt
        lblMovieSetSourcesFilenamingKodiExtendedDiscArt.Text = strDiscArt

        'Enabled
        Dim strEnabled As String = Master.eLang.GetString(774, "Enabled")
        lblMovieSetSourcesFilenamingKodiExtendedEnabled.Text = strEnabled
        lblMovieSetSourcesFilenamingKodiMSAAEnabled.Text = strEnabled
        chkMovieSetUseExpert.Text = strEnabled

        'Fanart
        Dim strFanart As String = Master.eLang.GetString(149, "Fanart")
        lblMovieSetSourcesFilenamingExpertSingleFanart.Text = strFanart
        lblMovieSetSourcesFilenamingKodiExtendedFanart.Text = strFanart
        lblMovieSetSourcesFilenamingKodiMSAAFanart.Text = strFanart

        'Landscape
        Dim strLandscape As String = Master.eLang.GetString(1059, "Landscape")
        lblMovieSetLandscapeExpertSingle.Text = strLandscape
        lblMovieSetSourcesFilenamingKodiExtendedLandscape.Text = strLandscape
        lblMovieSetSourcesFilenamingKodiMSAALandscape.Text = strLandscape

        'NFO
        Dim strNFO As String = Master.eLang.GetString(150, "NFO")
        lblMovieSetSourcesFilenamingExpertSingleNFO.Text = strNFO

        'Path
        Dim strPath As String = Master.eLang.GetString(410, "Path")
        lblMovieSetPathExpertSingle.Text = strPath
        lblMovieSetSourcesFilenamingKodiExtendedPath.Text = strPath
        lblMovieSetSourcesFilenamingKodiMSAAPath.Text = strPath

        'Poster
        Dim strPoster As String = Master.eLang.GetString(148, "Poster")
        lblMovieSetPosterExpertSingle.Text = strPoster
        lblMovieSetSourcesFilenamingKodiExtendedPoster.Text = strPoster
        lblMovieSetSourcesFilenamingKodiMSAAPoster.Text = strPoster
    End Sub

#End Region 'Methods

End Class