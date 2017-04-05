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
Imports System.IO
Imports System.Windows.Forms

Public Class frmTV_FileNaming
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.TV
    Dim _intImageIndex As Integer = 3
    Dim _intOrder As Integer = 300
    Dim _strName As String = "TV_FileNaming"
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
        With Master.eSettings.TV.Filenaming.TVEpisode
            '***************** Boxee settings ****************** 
            chkTVEpisodeNFOBoxee.Checked = .Boxee.NFO
            chkTVEpisodePosterBoxee.Checked = .Boxee.Poster

            '***************** Expert Episode *******************
            chkTVEpisodeActorThumbsExpert.Checked = .Expert.Actorthumbs
            txtTVEpisodeActorThumbsExtExpert.Text = .Expert.ActorthumbsExt
            txtTVEpisodeFanartExpert.Text = .Expert.Fanart
            txtTVEpisodeNFOExpert.Text = .Expert.NFO
            txtTVEpisodePosterExpert.Text = .Expert.Poster

            '*************** Kodi settings *************** 
            chkTVEpisodeActorThumbsFrodo.Checked = .Kodi.Actorthumbs
            chkTVEpisodeNFOFrodo.Checked = .Kodi.NFO
            chkTVEpisodePosterFrodo.Checked = .Kodi.Poster

            '****************** YAMJ settings ******************
            chkTVEpisodeNFOYAMJ.Checked = .YAMJ.NFO
            chkTVEpisodePosterYAMJ.Checked = .YAMJ.Poster
        End With

        With Master.eSettings.TV.Filenaming.TVSeason
            '******** ArtworkDownloader settings ********** 
            chkTVSeasonLandscapeAD.Checked = .ArtworkDownloader.Landscape

            '***************** Boxee settings ****************** 
            chkTVSeasonPosterBoxee.Checked = .Boxee.Poster

            '***************** Expert AllSeasons ****************
            txtTVAllSeasonsBannerExpert.Text = .Expert.AllSeasonsBanner
            txtTVAllSeasonsFanartExpert.Text = .Expert.AllSeasonsFanart
            txtTVAllSeasonsLandscapeExpert.Text = .Expert.AllSeasonsLandscape
            txtTVAllSeasonsPosterExpert.Text = .Expert.AllSeasonsPoster

            '***************** Expert Season *******************
            txtTVSeasonBannerExpert.Text = .Expert.Banner
            txtTVSeasonFanartExpert.Text = .Expert.Fanart
            txtTVSeasonLandscapeExpert.Text = .Expert.Landscape
            txtTVSeasonPosterExpert.Text = .Expert.Poster

            '*************** Kodi settings *************** 
            chkTVSeasonBannerFrodo.Checked = .Kodi.Banner
            chkTVSeasonFanartFrodo.Checked = .Kodi.Fanart
            chkTVSeasonPosterFrodo.Checked = .Kodi.Poster

            '********* Kodi Extended Images settings *********** 
            chkTVSeasonLandscapeExtended.Checked = .KodiExtended.Landscape

            '****************** YAMJ settings ******************
            chkTVSeasonBannerYAMJ.Checked = .YAMJ.Banner
            chkTVSeasonFanartYAMJ.Checked = .YAMJ.Fanart
            chkTVSeasonPosterYAMJ.Checked = .YAMJ.Poster
        End With

        With Master.eSettings.TV.Filenaming.TVShow
            '******** ArtworkDownloader settings ********** 
            chkTVShowCharacterArtAD.Checked = .ArtworkDownloader.CharacterArt
            chkTVShowClearArtAD.Checked = .ArtworkDownloader.ClearArt
            chkTVShowClearLogoAD.Checked = .ArtworkDownloader.ClearLogo
            chkTVShowLandscapeAD.Checked = .ArtworkDownloader.Landscape

            '***************** Boxee settings ****************** 
            chkTVShowBannerBoxee.Checked = .Boxee.Banner
            chkTVShowFanartBoxee.Checked = .Boxee.Fanart
            chkTVShowNFOBoxee.Checked = .Boxee.NFO
            chkTVShowPosterBoxee.Checked = .Boxee.Poster

            '***************** Expert Show *********************
            chkTVShowActorThumbsExpert.Checked = .Expert.Actorthumbs
            txtTVShowActorThumbsExtExpert.Text = .Expert.ActorthumbsExt
            txtTVShowBannerExpert.Text = .Expert.Banner
            txtTVShowCharacterArtExpert.Text = .Expert.CharacterArt
            txtTVShowClearArtExpert.Text = .Expert.ClearArt
            txtTVShowClearLogoExpert.Text = .Expert.ClearLogo
            chkTVShowExtrafanartsExpert.Checked = .Expert.Extrafanarts
            txtTVShowFanartExpert.Text = .Expert.Fanart
            txtTVShowLandscapeExpert.Text = .Expert.Landscape
            txtTVShowNFOExpert.Text = .Expert.NFO
            txtTVShowPosterExpert.Text = .Expert.Poster

            '*************** Kodi settings *************** 
            chkTVShowActorThumbsFrodo.Checked = .Kodi.Actorthumbs
            chkTVShowBannerFrodo.Checked = .Kodi.Banner
            chkTVShowExtrafanartsFrodo.Checked = .Kodi.Extrafanarts
            chkTVShowFanartFrodo.Checked = .Kodi.Fanart
            chkTVShowNFOFrodo.Checked = .Kodi.NFO
            chkTVShowPosterFrodo.Checked = .Kodi.Poster

            '********* Kodi Extended Images settings *********** 
            chkTVShowCharacterArtExtended.Checked = .KodiExtended.CharacterArt
            chkTVShowClearArtExtended.Checked = .KodiExtended.ClearArt
            chkTVShowClearLogoExtended.Checked = .KodiExtended.ClearLogo
            chkTVShowLandscapeExtended.Checked = .KodiExtended.Landscape

            '************* TvTunes settings *************** 
            chkTVShowThemeTvTunesCustom.Checked = .TvTunes.Custom
            chkTVShowThemeTvTunesShowPath.Checked = .TvTunes.TVShowPath
            chkTVShowThemeTvTunesSub.Checked = .TvTunes.Subdirectory
            txtTVShowThemeTvTunesCustomPath.Text = .TvTunes.CustomPath
            txtTVShowThemeTvTunesSubDir.Text = .TvTunes.SubdirectoryPath

            '****************** YAMJ settings ******************
            chkTVShowBannerYAMJ.Checked = .YAMJ.Banner
            chkTVShowFanartYAMJ.Checked = .YAMJ.Fanart
            chkTVShowNFOYAMJ.Checked = .YAMJ.NFO
            chkTVShowPosterYAMJ.Checked = .YAMJ.Poster
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.TV.Filenaming.TVEpisode
            '***************** Boxee settings ****************** 
            .Boxee.NFO = chkTVEpisodeNFOBoxee.Checked
            .Boxee.Poster = chkTVEpisodePosterBoxee.Checked

            '***************** Expert Episode *******************
            .Expert.Actorthumbs = chkTVEpisodeActorThumbsExpert.Checked
            .Expert.ActorthumbsExt = txtTVEpisodeActorThumbsExtExpert.Text
            .Expert.Fanart = txtTVEpisodeFanartExpert.Text
            .Expert.NFO = txtTVEpisodeNFOExpert.Text
            .Expert.Poster = txtTVEpisodePosterExpert.Text

            '*************** Kodi settings *************** 
            .Kodi.Actorthumbs = chkTVEpisodeActorThumbsFrodo.Checked
            .Kodi.NFO = chkTVEpisodeNFOFrodo.Checked
            .Kodi.Poster = chkTVEpisodePosterFrodo.Checked

            '****************** YAMJ settings ****************** 
            .YAMJ.NFO = chkTVEpisodeNFOYAMJ.Checked
            .YAMJ.Poster = chkTVEpisodePosterYAMJ.Checked

        End With

        With Master.eSettings.TV.Filenaming.TVSeason
            '************* ArtworkDownloader settings ************** 
            .ArtworkDownloader.Landscape = chkTVSeasonLandscapeAD.Checked

            '***************** Boxee settings ****************** 
            .Boxee.Poster = chkTVSeasonPosterBoxee.Checked

            '***************** Expert AllSeasons ****************
            .Expert.AllSeasonsBanner = txtTVAllSeasonsBannerExpert.Text
            .Expert.AllSeasonsFanart = txtTVAllSeasonsFanartExpert.Text
            .Expert.AllSeasonsLandscape = txtTVAllSeasonsLandscapeExpert.Text
            .Expert.AllSeasonsPoster = txtTVAllSeasonsPosterExpert.Text

            '***************** Expert Season ********************
            .Expert.Banner = txtTVSeasonBannerExpert.Text
            .Expert.Fanart = txtTVSeasonFanartExpert.Text
            .Expert.Landscape = txtTVSeasonLandscapeExpert.Text
            .Expert.Poster = txtTVSeasonPosterExpert.Text

            '*************** Kodi settings *************** 
            .Kodi.Banner = chkTVSeasonBannerFrodo.Checked
            .Kodi.Fanart = chkTVSeasonFanartFrodo.Checked
            .Kodi.Poster = chkTVSeasonPosterFrodo.Checked

            '********* Kodi Extended Images settings *********** 
            .KodiExtended.Landscape = chkTVSeasonLandscapeExtended.Checked

            '****************** YAMJ settings ****************** 
            .YAMJ.Banner = chkTVSeasonBannerYAMJ.Checked
            .YAMJ.Fanart = chkTVSeasonFanartYAMJ.Checked
            .YAMJ.Poster = chkTVSeasonPosterYAMJ.Checked

        End With

        With Master.eSettings.TV.Filenaming.TVShow
            '************* ArtworkDownloader settings ************** 
            .ArtworkDownloader.CharacterArt = chkTVShowCharacterArtAD.Checked
            .ArtworkDownloader.ClearArt = chkTVShowClearArtAD.Checked
            .ArtworkDownloader.ClearLogo = chkTVShowClearLogoAD.Checked
            .ArtworkDownloader.Landscape = chkTVShowLandscapeAD.Checked

            '***************** Boxee settings ****************** 
            .Boxee.Banner = chkTVShowBannerBoxee.Checked
            .Boxee.Fanart = chkTVShowFanartBoxee.Checked
            .Boxee.NFO = chkTVShowNFOBoxee.Checked
            .Boxee.Poster = chkTVShowPosterBoxee.Checked

            '***************** Expert Show **********************
            .Expert.Actorthumbs = chkTVShowActorThumbsExpert.Checked
            .Expert.ActorthumbsExt = txtTVShowActorThumbsExtExpert.Text
            .Expert.Banner = txtTVShowBannerExpert.Text
            .Expert.CharacterArt = txtTVShowCharacterArtExpert.Text
            .Expert.ClearArt = txtTVShowClearArtExpert.Text
            .Expert.ClearLogo = txtTVShowClearLogoExpert.Text
            .Expert.Extrafanarts = chkTVShowExtrafanartsExpert.Checked
            .Expert.Fanart = txtTVShowFanartExpert.Text
            .Expert.Landscape = txtTVShowLandscapeExpert.Text
            .Expert.NFO = txtTVShowNFOExpert.Text
            .Expert.Poster = txtTVShowPosterExpert.Text

            '*************** Kodi settings *************** 
            .Kodi.Actorthumbs = chkTVShowActorThumbsFrodo.Checked
            .Kodi.Banner = chkTVShowBannerFrodo.Checked
            .Kodi.Extrafanarts = chkTVShowExtrafanartsFrodo.Checked
            .Kodi.Fanart = chkTVShowFanartFrodo.Checked
            .Kodi.NFO = chkTVShowNFOFrodo.Checked
            .Kodi.Poster = chkTVShowPosterFrodo.Checked

            '********* Kodi Extended Images settings *********** 
            .KodiExtended.CharacterArt = chkTVShowCharacterArtExtended.Checked
            .KodiExtended.ClearArt = chkTVShowClearArtExtended.Checked
            .KodiExtended.ClearLogo = chkTVShowClearLogoExtended.Checked
            .KodiExtended.Landscape = chkTVShowLandscapeExtended.Checked

            '************** TvTunes settings ************** 
            .TvTunes.Custom = chkTVShowThemeTvTunesCustom.Checked
            .TvTunes.CustomPath = txtTVShowThemeTvTunesCustomPath.Text
            .TvTunes.TVShowPath = chkTVShowThemeTvTunesShowPath.Checked
            .TvTunes.Subdirectory = chkTVShowThemeTvTunesSub.Checked
            .TvTunes.SubdirectoryPath = txtTVShowThemeTvTunesSubDir.Text

            '****************** YAMJ settings ****************** 
            .YAMJ.Banner = chkTVShowBannerYAMJ.Checked
            .YAMJ.Fanart = chkTVShowFanartYAMJ.Checked
            .YAMJ.NFO = chkTVShowNFOYAMJ.Checked
            .YAMJ.Poster = chkTVShowPosterYAMJ.Checked
        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub btnTVShowThemeTvTunesCustomPathBrowse_Click(sender As Object, e As EventArgs) Handles btnTVShowThemeTvTunesCustomPathBrowse.Click
        With fbdBrowse
            fbdBrowse.Description = Master.eLang.GetString(1077, "Select the folder where you wish to store your themes...")
            If .ShowDialog = DialogResult.OK Then
                If Not String.IsNullOrEmpty(.SelectedPath.ToString) AndAlso Directory.Exists(.SelectedPath) Then
                    txtTVShowThemeTvTunesCustomPath.Text = .SelectedPath.ToString
                End If
            End If
        End With
    End Sub

    Private Sub chkTVUseExpert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVUseExpert.CheckedChanged
        EnableApplyButton()

        chkTVEpisodeActorThumbsExpert.Enabled = chkTVUseExpert.Checked
        chkTVShowActorThumbsExpert.Enabled = chkTVUseExpert.Checked
        chkTVShowExtrafanartsExpert.Enabled = chkTVUseExpert.Checked
        txtTVAllSeasonsBannerExpert.Enabled = chkTVUseExpert.Checked
        txtTVAllSeasonsFanartExpert.Enabled = chkTVUseExpert.Checked
        txtTVAllSeasonsLandscapeExpert.Enabled = chkTVUseExpert.Checked
        txtTVAllSeasonsPosterExpert.Enabled = chkTVUseExpert.Checked
        txtTVEpisodeActorThumbsExtExpert.Enabled = chkTVUseExpert.Checked
        txtTVEpisodeFanartExpert.Enabled = chkTVUseExpert.Checked
        txtTVEpisodeNFOExpert.Enabled = chkTVUseExpert.Checked
        txtTVEpisodePosterExpert.Enabled = chkTVUseExpert.Checked
        txtTVSeasonBannerExpert.Enabled = chkTVUseExpert.Checked
        txtTVSeasonFanartExpert.Enabled = chkTVUseExpert.Checked
        txtTVSeasonLandscapeExpert.Enabled = chkTVUseExpert.Checked
        txtTVSeasonPosterExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowActorThumbsExtExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowBannerExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowCharacterArtExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowClearArtExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowClearLogoExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowFanartExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowLandscapeExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowNFOExpert.Enabled = chkTVUseExpert.Checked
        txtTVShowPosterExpert.Enabled = chkTVUseExpert.Checked
    End Sub

    Private Sub chkTVShowThemeTvTunesCustom_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVShowThemeTvTunesCustom.CheckedChanged
        EnableApplyButton()

        txtTVShowThemeTvTunesCustomPath.Enabled = chkTVShowThemeTvTunesCustom.Checked
        btnTVShowThemeTvTunesCustomPathBrowse.Enabled = chkTVShowThemeTvTunesCustom.Checked

        If chkTVShowThemeTvTunesCustom.Checked Then
            chkTVShowThemeTvTunesShowPath.Enabled = False
            chkTVShowThemeTvTunesShowPath.Checked = False
            chkTVShowThemeTvTunesSub.Enabled = False
            chkTVShowThemeTvTunesSub.Checked = False
        End If

        If Not chkTVShowThemeTvTunesCustom.Checked AndAlso chkTVShowThemeTvTunesEnabled.Checked Then
            chkTVShowThemeTvTunesShowPath.Enabled = True
            chkTVShowThemeTvTunesSub.Enabled = True
        End If
    End Sub

    Private Sub chkTVShowThemeTvTunesEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVShowThemeTvTunesEnabled.CheckedChanged
        EnableApplyButton()

        chkTVShowThemeTvTunesCustom.Enabled = chkTVShowThemeTvTunesEnabled.Checked
        chkTVShowThemeTvTunesShowPath.Enabled = chkTVShowThemeTvTunesEnabled.Checked
        chkTVShowThemeTvTunesSub.Enabled = chkTVShowThemeTvTunesEnabled.Checked

        If Not chkTVShowThemeTvTunesEnabled.Checked Then
            chkTVShowThemeTvTunesCustom.Checked = False
            chkTVShowThemeTvTunesShowPath.Checked = False
            chkTVShowThemeTvTunesSub.Checked = False
        Else
            chkTVShowThemeTvTunesShowPath.Checked = True
        End If
    End Sub

    Private Sub chkTVShowThemeTvTunesTVShowPath_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVShowThemeTvTunesShowPath.CheckedChanged
        EnableApplyButton()

        If chkTVShowThemeTvTunesShowPath.Checked Then
            chkTVShowThemeTvTunesCustom.Enabled = False
            chkTVShowThemeTvTunesCustom.Checked = False
            chkTVShowThemeTvTunesSub.Enabled = False
            chkTVShowThemeTvTunesSub.Checked = False
        End If

        If Not chkTVShowThemeTvTunesShowPath.Checked AndAlso chkTVShowThemeTvTunesEnabled.Checked Then
            chkTVShowThemeTvTunesCustom.Enabled = True
            chkTVShowThemeTvTunesSub.Enabled = True
        End If
    End Sub

    Private Sub chkTVShowThemeTvTunesSub_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVShowThemeTvTunesSub.CheckedChanged
        EnableApplyButton()

        txtTVShowThemeTvTunesSubDir.Enabled = chkTVShowThemeTvTunesSub.Checked

        If chkTVShowThemeTvTunesSub.Checked Then
            chkTVShowThemeTvTunesCustom.Enabled = False
            chkTVShowThemeTvTunesCustom.Checked = False
            chkTVShowThemeTvTunesShowPath.Enabled = False
            chkTVShowThemeTvTunesShowPath.Checked = False
        End If

        If Not chkTVShowThemeTvTunesSub.Checked AndAlso chkTVShowThemeTvTunesEnabled.Checked Then
            chkTVShowThemeTvTunesCustom.Enabled = True
            chkTVShowThemeTvTunesShowPath.Enabled = True
        End If
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub pbTVSourcesADInfo_Click(sender As Object, e As EventArgs) Handles pbTVSourcesADInfo.Click
        If Master.isWindows Then
            Process.Start("http://kodi.wiki/view/Add-on:Artwork_Downloader#Filenaming")
        Else
            Using Explorer As New Process
                Explorer.StartInfo.FileName = "xdg-open"
                Explorer.StartInfo.Arguments = "http://kodi.wiki/view/Add-on:Artwork_Downloader#Filenaming"
                Explorer.Start()
            End Using
        End If
    End Sub

    Private Sub pbTVSourcesTvTunesInfo_Click(sender As Object, e As EventArgs) Handles pbTVSourcesTvTunesInfo.Click
        If Master.isWindows Then
            Process.Start("http://kodi.wiki/view/Add-on:TvTunes")
        Else
            Using Explorer As New Process
                Explorer.StartInfo.FileName = "xdg-open"
                Explorer.StartInfo.Arguments = "http://kodi.wiki/view/Add-on:TvTunes"
                Explorer.Start()
            End Using
        End If
    End Sub

    Private Sub SetUp()
        tpTVSourcesFilenamingExpertAllSeasons.Text = Master.eLang.GetString(1202, "All Seasons")
        tpTVSourcesFilenamingExpert.Text = Master.eLang.GetString(439, "Expert")
        gbTVSourcesFilenamingExpertOpts.Text = Master.eLang.GetString(1181, "Expert Settings")
        gbTVSourcesFilenamingKodiExtendedOpts.Text = Master.eLang.GetString(822, "Extended Images")
        gbTVSourcesFilenamingOpts.Text = Master.eLang.GetString(471, "File Naming")
        chkTVShowThemeTvTunesCustom.Text = Master.eLang.GetString(1259, "Store themes in a custom path")
        chkTVShowThemeTvTunesSub.Text = Master.eLang.GetString(1260, "Store themes in sub directories")
        chkTVShowThemeTvTunesShowPath.Text = Master.eLang.GetString(1265, "Store themes in tv show directory")

        'Actor Thumbs
        Dim strActorThumbs As String = Master.eLang.GetString(991, "Actor Thumbs")
        chkTVEpisodeActorThumbsExpert.Text = strActorThumbs
        chkTVShowActorThumbsExpert.Text = strActorThumbs
        lblTVSourcesFilenamingKodiDefaultsActorThumbs.Text = strActorThumbs

        'Banner
        Dim strBanner As String = Master.eLang.GetString(838, "Banner")
        lblTVSourcesFilenamingExpertAllSeasonsBanner.Text = strBanner
        lblTVSourcesFilenamingExpertSeasonBanner.Text = strBanner
        lblTVSourcesFilenamingExpertShowBanner.Text = strBanner
        lblTVSourcesFilenamingBoxeeDefaultsBanner.Text = strBanner
        lblTVSourcesFilenamingKodiDefaultsBanner.Text = strBanner
        lblTVSourcesFilenamingNMTDefaultsBanner.Text = strBanner

        'CharacterArt
        Dim strCharacterArt As String = Master.eLang.GetString(1140, "CharacterArt")
        lblTVShowCharacterArtExpert.Text = strCharacterArt
        lblTVSourcesFilenamingKodiADCharacterArt.Text = strCharacterArt
        lblTVSourcesFilenamingKodiExtendedCharacterArt.Text = strCharacterArt

        'ClearArt
        Dim strClearArt As String = Master.eLang.GetString(1096, "ClearArt")
        lblTVSourcesFilenamingExpertClearArt.Text = strClearArt
        lblTVSourcesFileNamingKodiADClearArt.Text = strClearArt
        lblTVSourcesFileNamingKodiExtendedClearArt.Text = strClearArt

        'ClearLogo
        Dim strClearLogo As String = Master.eLang.GetString(1097, "ClearLogo")
        lblTVSourcesFilenamingExpertClearLogo.Text = strClearLogo
        lblTVSourcesFilenamingKodiADClearLogo.Text = strClearLogo
        lblTVSourcesFilenamingKodiExtendedClearLogo.Text = strClearLogo

        'Defaults
        Dim strDefaults As String = Master.eLang.GetString(713, "Defaults")
        gbTVSourcesFilenamingBoxeeDefaultsOpts.Text = strDefaults
        gbTVSourcesFilenamingNMTDefaultsOpts.Text = strDefaults
        gbTVSourcesFilenamingKodiDefaultsOpts.Text = strDefaults

        'Enabled
        Dim strEnabled As String = Master.eLang.GetString(774, "Enabled")
        chkTVShowThemeTvTunesEnabled.Text = strEnabled
        chkTVUseExpert.Text = strEnabled

        'Episode
        Dim strEpisode As String = Master.eLang.GetString(727, "Episode")
        lblTVSourcesFilenamingBoxeeDefaultsHeaderBoxeeEpisode.Text = strEpisode
        lblTVSourcesFilenamingKodiDefaultsHeaderFrodoHelixEpisode.Text = strEpisode
        lblTVSourcesFilenamingNMTDefaultsHeaderNMJEpisode.Text = strEpisode
        lblTVSourcesFilenamingNMTDefaultsHeaderYAMJEpisode.Text = strEpisode
        tpTVSourcesFilenamingExpertEpisode.Text = strEpisode

        'Extrafanarts
        Dim strExtrafanarts As String = Master.eLang.GetString(992, "Extrafanarts")
        chkTVShowExtrafanartsExpert.Text = strExtrafanarts
        lblTVSourcesFilenamingKodiDefaultsExtrafanarts.Text = strExtrafanarts

        'Fanart
        Dim strFanart As String = Master.eLang.GetString(149, "Fanart")
        lblTVSourcesFilenamingExpertAllSeasonsFanart.Text = strFanart
        lblTVSourcesFilenamingExpertEpisodeFanart.Text = strFanart
        lblTVSourcesFilenamingExpertSeasonFanart.Text = strFanart
        lblTVSourcesFilenamingExpertShowFanart.Text = strFanart
        lblTVSourcesFilenamingBoxeeDefaultsFanart.Text = strFanart
        lblTVSourcesFilenamingKodiDefaultsFanart.Text = strFanart
        lblTVSourcesFilenamingNMTDefaultsFanart.Text = strFanart

        'Landscape
        Dim strLandscape As String = Master.eLang.GetString(1059, "Landscape")
        lblTVSourcesFilenamingExpertAllSeasonsLandscape.Text = strLandscape
        lblTVSourcesFilenamingExpertSeasonLandscape.Text = strLandscape
        lblTVSourcesFilenamingExpertShowLandscape.Text = strLandscape

        'NFO
        Dim strNFO As String = Master.eLang.GetString(150, "NFO")
        lblTVSourcesFilenamingExpertEpisodeNFO.Text = strNFO
        lblTVSourcesFilenamingExpertShowNFO.Text = strNFO
        lblTVSourcesFilenamingKodiDefaultsNFO.Text = strNFO

        'Optional Images
        Dim strOptionalImages As String = Master.eLang.GetString(267, "Optional Images")
        gbTVSourcesFilenamingExpertEpisodeImagesOpts.Text = strOptionalImages
        gbTVSourcesFilenamingExpertShowImagesOpts.Text = strOptionalImages

        'Poster
        Dim strPoster As String = Master.eLang.GetString(148, "Poster")
        lblTVSourcesFilenamingBoxeeDefaultsPoster.Text = strPoster
        lblTVSourcesFilenamingKodiDefaultsPoster.Text = strPoster
        lblTVSourcesFilenamingNMTDefaultsPoster.Text = strPoster
        lblTVAllSeasonsPosterExpert.Text = strPoster
        lblTVEpisodePosterExpert.Text = strPoster
        lblTVSeasonPosterExpert.Text = strPoster
        lblTVShowPosterExpert.Text = strPoster

        'Season
        Dim strSeason As String = Master.eLang.GetString(650, "Season")
        lblTVSourcesFilenamingBoxeeDefaultsHeaderBoxeeSeason.Text = strSeason
        lblTVSourcesFilenamingNMTDefaultsHeaderNMJSeason.Text = strSeason
        lblTVSourcesFilenamingKodiDefaultsHeaderFrodoHelixSeason.Text = strSeason
        lblTVSourcesFilenamingNMTDefaultsHeaderYAMJSeason.Text = strSeason
        tpTVSourcesFilenamingExpertSeason.Text = strSeason

        'Season Landscape
        Dim strSeasonLandscape As String = Master.eLang.GetString(1018, "Season Landscape")
        lblTVSourcesFilenamingKodiADSeasonLandscape.Text = strSeasonLandscape
        lblTVSourcesFilenamingKodiExtendedSeasonLandscape.Text = strSeasonLandscape

        'TV Show
        Dim strTVShow As String = Master.eLang.GetString(700, "TV Show")
        lblTVSourcesFilenamingBoxeeDefaultsHeaderBoxeeTVShow.Text = strTVShow
        lblTVSourcesFilenamingKodiDefaultsHeaderFrodoHelixTVShow.Text = strTVShow
        lblTVSourcesFilenamingNMTDefaultsHeaderNMJTVShow.Text = strTVShow
        lblTVSourcesFilenamingNMTDefaultsHeaderYAMJTVShow.Text = strTVShow
        tpTVSourcesFilenamingExpertTVShow.Text = strTVShow

        'TV Show Landscape
        Dim strTVShowLandscape As String = Master.eLang.GetString(1010, "TV Show Landscape")
        lblTVSourcesFilenamingKodiADTVShowLandscape.Text = strTVShowLandscape
        lblTVSourcesFilenamingKodiExtendedTVShowLandscape.Text = strTVShowLandscape

    End Sub

#End Region 'Methods

End Class