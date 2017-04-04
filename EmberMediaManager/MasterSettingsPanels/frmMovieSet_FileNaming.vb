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

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Movieset
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
        With Master.eSettings.Movieset.SourceSettings
            chkMovieSetCleanDB.Checked = .CleanDB
            chkMovieSetCleanFiles.Checked = .RemoveFiles
        End With

        With Master.eSettings.Movieset.Filenaming

            '********* Kodi Extended Images settings ***********
            chkMovieSetBannerExtended.Checked = .KodiExtended.Banner
            chkMovieSetClearArtExtended.Checked = .KodiExtended.ClearArt
            chkMovieSetClearLogoExtended.Checked = .KodiExtended.ClearLogo
            chkMovieSetDiscArtExtended.Checked = .KodiExtended.DiscArt
            chkMovieSetFanartExtended.Checked = .KodiExtended.Fanart
            chkMovieSetLandscapeExtended.Checked = .KodiExtended.Landscape
            chkMovieSetPosterExtended.Checked = .KodiExtended.Poster
            txtMovieSetPathExtended.Text = .KodiExtended.Path

            '**************** Kodi MSAA settings ***************
            chkMovieSetBannerMSAA.Checked = .MovieSetArtworkAutomator.Banner
            chkMovieSetClearArtMSAA.Checked = .MovieSetArtworkAutomator.ClearArt
            chkMovieSetClearLogoMSAA.Checked = .MovieSetArtworkAutomator.ClearLogo
            chkMovieSetFanartMSAA.Checked = .MovieSetArtworkAutomator.Fanart
            chkMovieSetLandscapeMSAA.Checked = .MovieSetArtworkAutomator.Landscape
            chkMovieSetPosterMSAA.Checked = .MovieSetArtworkAutomator.Poster
            txtMovieSetPathMSAA.Text = .MovieSetArtworkAutomator.Path

            '***************** Expert settings *****************
            chkMovieSetUseExpert.Checked = .Expert.Enabled

            '***************** Expert Single ******************
            txtMovieSetBannerExpertSingle.Text = .Expert.Single.Banner
            txtMovieSetClearArtExpertSingle.Text = .Expert.Single.ClearArt
            txtMovieSetClearLogoExpertSingle.Text = .Expert.Single.ClearLogo
            txtMovieSetDiscArtExpertSingle.Text = .Expert.Single.DiscArt
            txtMovieSetFanartExpertSingle.Text = .Expert.Single.Fanart
            txtMovieSetLandscapeExpertSingle.Text = .Expert.Single.Landscape
            txtMovieSetNFOExpertSingle.Text = .Expert.Single.NFO
            txtMovieSetPathExpertSingle.Text = .Expert.Single.Path
            txtMovieSetPosterExpertSingle.Text = .Expert.Single.Poster
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.Movieset.SourceSettings
            .CleanDB = chkMovieSetCleanDB.Checked
            .RemoveFiles = chkMovieSetCleanFiles.Checked
        End With

        With Master.eSettings.Movieset.Filenaming

            '**************** Kodi MSAA settings ***************
            .MovieSetArtworkAutomator.Banner = chkMovieSetBannerMSAA.Checked
            .MovieSetArtworkAutomator.ClearArt = chkMovieSetClearArtMSAA.Checked
            .MovieSetArtworkAutomator.ClearLogo = chkMovieSetClearLogoMSAA.Checked
            .MovieSetArtworkAutomator.Fanart = chkMovieSetFanartMSAA.Checked
            .MovieSetArtworkAutomator.Landscape = chkMovieSetLandscapeMSAA.Checked
            .MovieSetArtworkAutomator.Path = txtMovieSetPathMSAA.Text
            .MovieSetArtworkAutomator.Poster = chkMovieSetPosterMSAA.Checked

            '********* XBMC Extended Images settings ***********
            .KodiExtended.Banner = chkMovieSetBannerExtended.Checked
            .KodiExtended.ClearArt = chkMovieSetClearArtExtended.Checked
            .KodiExtended.ClearLogo = chkMovieSetClearLogoExtended.Checked
            .KodiExtended.DiscArt = chkMovieSetDiscArtExtended.Checked
            .KodiExtended.Fanart = chkMovieSetFanartExtended.Checked
            .KodiExtended.Landscape = chkMovieSetLandscapeExtended.Checked
            .KodiExtended.Path = txtMovieSetPathExtended.Text
            .KodiExtended.Poster = chkMovieSetPosterExtended.Checked

            '***************** Expert settings ****************
            .Expert.Enabled = chkMovieSetUseExpert.Checked

            '***************** Expert Single ******************
            .Expert.Single.Banner = txtMovieSetBannerExpertSingle.Text
            .Expert.Single.ClearArt = txtMovieSetClearArtExpertSingle.Text
            .Expert.Single.ClearLogo = txtMovieSetClearLogoExpertSingle.Text
            .Expert.Single.DiscArt = txtMovieSetDiscArtExpertSingle.Text
            .Expert.Single.Fanart = txtMovieSetFanartExpertSingle.Text
            .Expert.Single.Landscape = txtMovieSetLandscapeExpertSingle.Text
            .Expert.Single.NFO = txtMovieSetNFOExpertSingle.Text
            .Expert.Single.Path = txtMovieSetPathExpertSingle.Text
            .Expert.Single.Poster = txtMovieSetPosterExpertSingle.Text
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
        chkMovieSetUseExpert.Text = Master.eLang.GetString(774, "Enabled")

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