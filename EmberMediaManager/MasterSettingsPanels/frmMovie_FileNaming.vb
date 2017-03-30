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

Public Class frmMovie_FileNaming
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Movie
    Dim _intImageIndex As Integer = 3
    Dim _intOrder As Integer = 300
    Dim _strName As String = "Movie_FileNaming"
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
        With Master.eSettings.Movie.Filenaming
            chkMovieSourcesBackdropsAuto.Checked = .BackdropsAuto
            chkProtectVTSBDMV.Checked = .ProtectVTSandBDMVStructure
            txtMovieSourcesBackdropsFolderPath.Text = .BackdropsPath
        End With

        '*********** ArtworkDownloader settings *************
        With Master.eSettings.Movie.Filenaming.ArtworkDownloader
            chkMovieUseAD.Checked = .Enabled
            chkMovieBannerAD.Checked = .Banner
            chkMovieClearArtAD.Checked = .ClearArt
            chkMovieClearLogoAD.Checked = .ClearLogo
            chkMovieDiscArtAD.Checked = .DiscArt
            chkMovieLandscapeAD.Checked = .Landscape
        End With

        '***************** Boxee settings ******************
        With Master.eSettings.Movie.Filenaming.Boxee
            chkMovieUseBoxee.Checked = .Enabled
            chkMovieFanartBoxee.Checked = .Fanart
            chkMovieNFOBoxee.Checked = .NFO
            chkMoviePosterBoxee.Checked = .Poster
        End With

        '*************** Kodi Frodo settings ***************
        With Master.eSettings.Movie.Filenaming.Kodi
            chkMovieUseFrodo.Checked = .Enabled
            chkMovieActorThumbsFrodo.Checked = .Actorthumbs
            chkMovieExtrafanartsFrodo.Checked = .Extrafanarts
            chkMovieExtrathumbsFrodo.Checked = .Extrathumbs
            chkMovieFanartFrodo.Checked = .Fanart
            chkMovieNFOFrodo.Checked = .NFO
            chkMoviePosterFrodo.Checked = .Poster
            chkMovieTrailerFrodo.Checked = .Trailer
        End With

        '********* Kodi Extended Images settings ***********
        With Master.eSettings.Movie.Filenaming.KodiExtended
            chkMovieUseExtended.Checked = .Enabled
            chkMovieBannerExtended.Checked = .Banner
            chkMovieClearArtExtended.Checked = .ClearArt
            chkMovieClearLogoExtended.Checked = .ClearLogo
            chkMovieDiscArtExtended.Checked = .DiscArt
            chkMovieLandscapeExtended.Checked = .Landscape
        End With

        '****************** NMJ settings ******************
        With Master.eSettings.Movie.Filenaming.NMJ
            chkMovieUseNMJ.Checked = .Enabled
            chkMovieBannerNMJ.Checked = .Banner
            chkMovieFanartNMJ.Checked = .Fanart
            chkMovieNFONMJ.Checked = .NFO
            chkMoviePosterNMJ.Checked = .Poster
            chkMovieTrailerNMJ.Checked = .Trailer
        End With

        '************** TvTunes settings **************
        With Master.eSettings.Movie.Filenaming.TvTunes
            chkMovieThemeTvTunesEnabled.Checked = .Enabled
            chkMovieThemeTvTunesCustom.Checked = .Custom
            chkMovieThemeTvTunesMoviePath.Checked = .MoviePath
            chkMovieThemeTvTunesSub.Checked = .Subdirectory
            txtMovieThemeTvTunesCustomPath.Text = .CustomPath
            txtMovieThemeTvTunesSubDir.Text = .SubdirectoryPath
        End With

        '*************** XBMC Eden settings ****************
        With Master.eSettings.Movie.Filenaming.XBMC
            chkMovieUseEden.Checked = .Enabled
            chkMovieActorThumbsEden.Checked = .Actorthumbs
            chkMovieExtrafanartsEden.Checked = .Extrafanarts
            chkMovieExtrathumbsEden.Checked = .Extrathumbs
            chkMovieFanartEden.Checked = .Fanart
            chkMovieNFOEden.Checked = .NFO
            chkMoviePosterEden.Checked = .Poster
            chkMovieTrailerEden.Checked = .Trailer
        End With

        '****************** YAMJ settings ******************
        With Master.eSettings.Movie.Filenaming.YAMJ
            chkMovieUseYAMJ.Checked = .Enabled
            chkMovieBannerYAMJ.Checked = .Banner
            chkMovieFanartYAMJ.Checked = .Fanart
            chkMovieNFOYAMJ.Checked = .NFO
            chkMoviePosterYAMJ.Checked = .Poster
            chkMovieTrailerYAMJ.Checked = .Trailer
            chkMovieYAMJWatchedFile.Checked = .WatchedFile
            txtMovieYAMJWatchedFolder.Text = .WatchedFilePath
        End With

        '***************** Expert settings *****************
        chkMovieUseExpert.Checked = Master.eSettings.Movie.Filenaming.Expert.Enabled

        '******************* Expert BDMV *******************
        With Master.eSettings.Movie.Filenaming.Expert.BDMV
            chkMovieActorThumbsExpertBDMV.Checked = .Actorthumbs
            chkMovieExtrafanartsExpertBDMV.Checked = .Extrafanarts
            chkMovieExtrathumbsExpertBDMV.Checked = .Extrathumbs
            txtMovieActorThumbsExtExpertBDMV.Text = .ActorthumbsExt
            txtMovieBannerExpertBDMV.Text = .Banner
            txtMovieClearArtExpertBDMV.Text = .ClearArt
            txtMovieClearLogoExpertBDMV.Text = .ClearLogo
            txtMovieDiscArtExpertBDMV.Text = .DiscArt
            txtMovieFanartExpertBDMV.Text = .Fanart
            txtMovieLandscapeExpertBDMV.Text = .Landscape
            txtMovieNFOExpertBDMV.Text = .NFO
            txtMoviePosterExpertBDMV.Text = .Poster
            txtMovieTrailerExpertBDMV.Text = .Trailer
        End With

        '******************* Expert Multi ******************
        With Master.eSettings.Movie.Filenaming.Expert.Multi
            chkMovieActorThumbsExpertMulti.Checked = .Actorthumbs
            chkMovieStackExpertMulti.Checked = .FilenameStacking
            chkMovieUnstackExpertMulti.Checked = .FilenameUnstacking
            txtMovieActorThumbsExtExpertMulti.Text = .ActorthumbsExt
            txtMovieBannerExpertMulti.Text = .Banner
            txtMovieClearArtExpertMulti.Text = .ClearArt
            txtMovieClearLogoExpertMulti.Text = .ClearLogo
            txtMovieDiscArtExpertMulti.Text = .DiscArt
            txtMovieFanartExpertMulti.Text = .Fanart
            txtMovieLandscapeExpertMulti.Text = .Landscape
            txtMovieNFOExpertMulti.Text = .NFO
            txtMoviePosterExpertMulti.Text = .Poster
            txtMovieTrailerExpertMulti.Text = .Trailer
        End With

        '***************** Expert Single *******************
        With Master.eSettings.Movie.Filenaming.Expert.Single
            chkMovieActorThumbsExpertSingle.Checked = .Actorthumbs
            chkMovieExtrafanartsExpertSingle.Checked = .Extrafanarts
            chkMovieExtrathumbsExpertSingle.Checked = .Extrathumbs
            chkMovieStackExpertSingle.Checked = .FilenameStacking
            chkMovieUnstackExpertSingle.Checked = .FilenameUnstacking
            txtMovieActorThumbsExtExpertSingle.Text = .ActorthumbsExt
            txtMovieBannerExpertSingle.Text = .Banner
            txtMovieClearArtExpertSingle.Text = .ClearArt
            txtMovieClearLogoExpertSingle.Text = .ClearLogo
            txtMovieDiscArtExpertSingle.Text = .DiscArt
            txtMovieFanartExpertSingle.Text = .Fanart
            txtMovieLandscapeExpertSingle.Text = .Landscape
            txtMovieNFOExpertSingle.Text = .NFO
            txtMoviePosterExpertSingle.Text = .Poster
            txtMovieTrailerExpertSingle.Text = .Trailer
        End With

        '******************* Expert VTS *******************
        With Master.eSettings.Movie.Filenaming.Expert.VideoTS
            chkMovieActorThumbsExpertVTS.Checked = .Actorthumbs
            chkMovieExtrafanartsExpertVTS.Checked = .Extrafanarts
            chkMovieExtrathumbsExpertVTS.Checked = .Extrathumbs
            chkMovieRecognizeVTSExpertVTS.Checked = .RecognizeVideoTS
            txtMovieActorThumbsExtExpertVTS.Text = .ActorthumbsExt
            txtMovieBannerExpertVTS.Text = .Banner
            txtMovieClearArtExpertVTS.Text = .ClearArt
            txtMovieClearLogoExpertVTS.Text = .ClearLogo
            txtMovieDiscArtExpertVTS.Text = .DiscArt
            txtMovieFanartExpertVTS.Text = .Fanart
            txtMovieLandscapeExpertVTS.Text = .Landscape
            txtMovieNFOExpertVTS.Text = .NFO
            txtMoviePosterExpertVTS.Text = .Poster
            txtMovieTrailerExpertVTS.Text = .Trailer
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.Movie.Filenaming
            .BackdropsPath = txtMovieSourcesBackdropsFolderPath.Text
            If Not String.IsNullOrEmpty(txtMovieSourcesBackdropsFolderPath.Text) Then
                .BackdropsAuto = chkMovieSourcesBackdropsAuto.Checked
            Else
                .BackdropsAuto = False
            End If
            .ProtectVTSandBDMVStructure = chkProtectVTSBDMV.Checked
        End With

        '*************** Kodi Frodo settings ***************
        With Master.eSettings.Movie.Filenaming.Kodi
            .Enabled = chkMovieUseFrodo.Checked
            .Actorthumbs = chkMovieActorThumbsFrodo.Checked
            .Extrafanarts = chkMovieExtrafanartsFrodo.Checked
            .Extrathumbs = chkMovieExtrathumbsFrodo.Checked
            .Fanart = chkMovieFanartFrodo.Checked
            .NFO = chkMovieNFOFrodo.Checked
            .Poster = chkMoviePosterFrodo.Checked
            .Trailer = chkMovieTrailerFrodo.Checked
        End With

        '*************** XBMC Eden settings ***************
        With Master.eSettings.Movie.Filenaming.XBMC
            .Enabled = chkMovieUseEden.Checked
            .Actorthumbs = chkMovieActorThumbsEden.Checked
            .Extrafanarts = chkMovieExtrafanartsEden.Checked
            .Extrathumbs = chkMovieExtrathumbsEden.Checked
            .Fanart = chkMovieFanartEden.Checked
            .NFO = chkMovieNFOEden.Checked
            .Poster = chkMoviePosterEden.Checked
            .Trailer = chkMovieTrailerEden.Checked
        End With

        '******** XBMC ArtworkDownloader settings **********
        With Master.eSettings.Movie.Filenaming.ArtworkDownloader
            .Enabled = chkMovieUseAD.Checked
            .Banner = chkMovieBannerAD.Checked
            .ClearArt = chkMovieClearArtAD.Checked
            .ClearArt = chkMovieClearLogoAD.Checked
            .DiscArt = chkMovieDiscArtAD.Checked
            .Fanart = chkMovieFanartAD.Checked
            .Landscape = chkMovieLandscapeAD.Checked
            .Poster = chkMoviePosterAD.Checked
        End With

        '********* Kodi Extended Images settings ***********
        With Master.eSettings.Movie.Filenaming.KodiExtended
            .Enabled = chkMovieUseExtended.Checked
            .Banner = chkMovieBannerExtended.Checked
            .ClearArt = chkMovieClearArtExtended.Checked
            .ClearLogo = chkMovieClearLogoExtended.Checked
            .DiscArt = chkMovieDiscArtExtended.Checked
            .Landscape = chkMovieLandscapeExtended.Checked
        End With

        '************** XBMC TvTunes settings **************
        With Master.eSettings.Movie.Filenaming.TvTunes
            .Enabled = chkMovieThemeTvTunesEnabled.Checked
            .Custom = chkMovieThemeTvTunesCustom.Checked
            .CustomPath = txtMovieThemeTvTunesCustomPath.Text
            .MoviePath = chkMovieThemeTvTunesMoviePath.Checked
            .Subdirectory = chkMovieThemeTvTunesSub.Checked
            .SubdirectoryPath = txtMovieThemeTvTunesSubDir.Text
        End With

        '****************** YAMJ settings *****************
        With Master.eSettings.Movie.Filenaming.YAMJ
            .Enabled = chkMovieUseYAMJ.Checked
            .Banner = chkMovieBannerYAMJ.Checked
            .Fanart = chkMovieFanartYAMJ.Checked
            .NFO = chkMovieNFOYAMJ.Checked
            .Poster = chkMoviePosterYAMJ.Checked
            .Trailer = chkMovieTrailerYAMJ.Checked
            .WatchedFile = chkMovieYAMJWatchedFile.Checked
            .WatchedFilePath = txtMovieYAMJWatchedFolder.Text
        End With

        '****************** NMJ settings *****************
        With Master.eSettings.Movie.Filenaming.NMJ
            .Enabled = chkMovieUseNMJ.Checked
            .Banner = chkMovieBannerNMJ.Checked
            .Fanart = chkMovieFanartNMJ.Checked
            .NFO = chkMovieNFONMJ.Checked
            .Poster = chkMoviePosterNMJ.Checked
            .Trailer = chkMovieTrailerNMJ.Checked
        End With

        '***************** Boxee settings *****************
        With Master.eSettings.Movie.Filenaming.Boxee
            .Enabled = chkMovieUseBoxee.Checked
            .Fanart = chkMovieFanartBoxee.Checked
            .NFO = chkMovieNFOBoxee.Checked
            .Poster = chkMoviePosterBoxee.Checked
        End With

        '***************** Expert settings ****************
        Master.eSettings.Movie.Filenaming.Expert.Enabled = chkMovieUseExpert.Checked

        '***************** Expert Single ******************
        With Master.eSettings.Movie.Filenaming.Expert.Single
            .Actorthumbs = chkMovieActorThumbsExpertSingle.Checked
            .ActorthumbsExt = txtMovieActorThumbsExtExpertSingle.Text
            .Banner = txtMovieBannerExpertSingle.Text
            .ClearArt = txtMovieClearArtExpertSingle.Text
            .ClearLogo = txtMovieClearLogoExpertSingle.Text
            .DiscArt = txtMovieDiscArtExpertSingle.Text
            .Extrafanarts = chkMovieExtrafanartsExpertSingle.Checked
            .Extrathumbs = chkMovieExtrathumbsExpertSingle.Checked
            .Fanart = txtMovieFanartExpertSingle.Text
            .FilenameStacking = chkMovieStackExpertSingle.Checked
            .FilenameUnstacking = chkMovieUnstackExpertSingle.Checked
            .Landscape = txtMovieLandscapeExpertSingle.Text
            .NFO = txtMovieNFOExpertSingle.Text
            .Poster = txtMoviePosterExpertSingle.Text
            .Trailer = txtMovieTrailerExpertSingle.Text
        End With

        '***************** Expert Multi ******************
        With Master.eSettings.Movie.Filenaming.Expert.Multi
            .Actorthumbs = chkMovieActorThumbsExpertMulti.Checked
            .ActorthumbsExt = txtMovieActorThumbsExtExpertMulti.Text
            .Banner = txtMovieBannerExpertMulti.Text
            .ClearArt = txtMovieClearArtExpertMulti.Text
            .ClearLogo = txtMovieClearLogoExpertMulti.Text
            .DiscArt = txtMovieDiscArtExpertMulti.Text
            .Fanart = txtMovieFanartExpertMulti.Text
            .FilenameStacking = chkMovieStackExpertMulti.Checked
            .FilenameUnstacking = chkMovieUnstackExpertMulti.Checked
            .Landscape = txtMovieLandscapeExpertMulti.Text
            .NFO = txtMovieNFOExpertMulti.Text
            .Poster = txtMoviePosterExpertMulti.Text
            .Trailer = txtMovieTrailerExpertMulti.Text
        End With

        '***************** Expert VTS ******************
        With Master.eSettings.Movie.Filenaming.Expert.VideoTS
            .Actorthumbs = chkMovieActorThumbsExpertVTS.Checked
            .ActorthumbsExt = txtMovieActorThumbsExtExpertVTS.Text
            .Banner = txtMovieBannerExpertVTS.Text
            .ClearArt = txtMovieClearArtExpertVTS.Text
            .ClearLogo = txtMovieClearLogoExpertVTS.Text
            .DiscArt = txtMovieDiscArtExpertVTS.Text
            .Extrafanarts = chkMovieExtrafanartsExpertVTS.Checked
            .Extrathumbs = chkMovieExtrathumbsExpertVTS.Checked
            .Fanart = txtMovieFanartExpertVTS.Text
            .Landscape = txtMovieLandscapeExpertVTS.Text
            .NFO = txtMovieNFOExpertVTS.Text
            .Poster = txtMoviePosterExpertVTS.Text
            .RecognizeVideoTS = chkMovieRecognizeVTSExpertVTS.Checked
            .Trailer = txtMovieTrailerExpertVTS.Text
        End With

        '***************** Expert BDMV ******************
        With Master.eSettings.Movie.Filenaming.Expert.BDMV
            .Actorthumbs = chkMovieActorThumbsExpertBDMV.Checked
            .ActorthumbsExt = txtMovieActorThumbsExtExpertBDMV.Text
            .Banner = txtMovieBannerExpertBDMV.Text
            .ClearArt = txtMovieClearArtExpertBDMV.Text
            .ClearLogo = txtMovieClearLogoExpertBDMV.Text
            .DiscArt = txtMovieDiscArtExpertBDMV.Text
            .Extrafanarts = chkMovieExtrafanartsExpertBDMV.Checked
            .Extrathumbs = chkMovieExtrathumbsExpertBDMV.Checked
            .Fanart = txtMovieFanartExpertBDMV.Text
            .Landscape = txtMovieLandscapeExpertBDMV.Text
            .NFO = txtMovieNFOExpertBDMV.Text
            .Poster = txtMoviePosterExpertBDMV.Text
            .Trailer = txtMovieTrailerExpertBDMV.Text
        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub btnMovieBackdropsPathBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSourcesBackdropsFolderPathBrowse.Click
        With fbdBrowse
            fbdBrowse.Description = Master.eLang.GetString(552, "Select the folder where you wish to store your backdrops...")
            If .ShowDialog = DialogResult.OK Then
                If Not String.IsNullOrEmpty(.SelectedPath.ToString) AndAlso Directory.Exists(.SelectedPath) Then
                    txtMovieSourcesBackdropsFolderPath.Text = .SelectedPath.ToString
                End If
            End If
        End With
    End Sub

    Private Sub btnMovieThemeTvTunesCustomPathBrowse_Click(sender As Object, e As EventArgs) Handles btnMovieThemeTvTunesCustomPathBrowse.Click
        With fbdBrowse
            fbdBrowse.Description = Master.eLang.GetString(1077, "Select the folder where you wish to store your themes...")
            If .ShowDialog = DialogResult.OK Then
                If Not String.IsNullOrEmpty(.SelectedPath.ToString) AndAlso Directory.Exists(.SelectedPath) Then
                    txtMovieThemeTvTunesCustomPath.Text = .SelectedPath.ToString
                End If
            End If
        End With
    End Sub

    Private Sub btnMovieYAMJWatchedFilesBrowse_Click(sender As Object, e As EventArgs) Handles btnMovieYAMJWatchedFilesBrowse.Click
        With fbdBrowse
            fbdBrowse.Description = Master.eLang.GetString(1029, "Select the folder where you wish to store your watched files...")
            If .ShowDialog = DialogResult.OK Then
                If Not String.IsNullOrEmpty(.SelectedPath.ToString) AndAlso Directory.Exists(.SelectedPath) Then
                    txtMovieYAMJWatchedFolder.Text = .SelectedPath.ToString
                End If
            End If
        End With
    End Sub

    Private Sub chkMovieUseAD_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieUseAD.CheckedChanged
        EnableApplyButton()

        chkMovieBannerAD.Enabled = chkMovieUseAD.Checked
        chkMovieClearArtAD.Enabled = chkMovieUseAD.Checked
        chkMovieClearLogoAD.Enabled = chkMovieUseAD.Checked
        chkMovieDiscArtAD.Enabled = chkMovieUseAD.Checked
        chkMovieFanartAD.Enabled = chkMovieUseAD.Checked
        chkMovieLandscapeAD.Enabled = chkMovieUseAD.Checked
        chkMoviePosterAD.Enabled = chkMovieUseAD.Checked

        If Not chkMovieUseAD.Checked Then
            chkMovieBannerAD.Checked = False
            chkMovieClearArtAD.Checked = False
            chkMovieClearLogoAD.Checked = False
            chkMovieDiscArtAD.Checked = False
            chkMovieFanartAD.Checked = False
            chkMovieLandscapeAD.Checked = False
            chkMoviePosterAD.Checked = False
        Else
            chkMovieBannerAD.Checked = True
            chkMovieClearArtAD.Checked = True
            chkMovieClearLogoAD.Checked = True
            chkMovieDiscArtAD.Checked = True
            chkMovieFanartAD.Checked = True
            chkMovieLandscapeAD.Checked = True
            chkMoviePosterAD.Checked = True
        End If
    End Sub

    Private Sub chkMovieUseBoxee_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieUseBoxee.CheckedChanged
        EnableApplyButton()

        chkMovieFanartBoxee.Enabled = chkMovieUseBoxee.Checked
        chkMovieNFOBoxee.Enabled = chkMovieUseBoxee.Checked
        chkMoviePosterBoxee.Enabled = chkMovieUseBoxee.Checked

        If Not chkMovieUseBoxee.Checked Then
            chkMovieFanartBoxee.Checked = False
            chkMovieNFOBoxee.Checked = False
            chkMoviePosterBoxee.Checked = False
        Else
            chkMovieFanartBoxee.Checked = True
            chkMovieNFOBoxee.Checked = True
            chkMoviePosterBoxee.Checked = True
        End If
    End Sub

    Private Sub chkMovieUseKodiExtended_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieUseExtended.CheckedChanged
        EnableApplyButton()

        chkMovieBannerExtended.Enabled = chkMovieUseExtended.Checked
        chkMovieClearArtExtended.Enabled = chkMovieUseExtended.Checked
        chkMovieClearLogoExtended.Enabled = chkMovieUseExtended.Checked
        chkMovieDiscArtExtended.Enabled = chkMovieUseExtended.Checked
        chkMovieLandscapeExtended.Enabled = chkMovieUseExtended.Checked

        If Not chkMovieUseExtended.Checked Then
            chkMovieBannerExtended.Checked = False
            chkMovieClearArtExtended.Checked = False
            chkMovieClearLogoExtended.Checked = False
            chkMovieDiscArtExtended.Checked = False
            chkMovieLandscapeExtended.Checked = False
        Else
            chkMovieBannerExtended.Checked = True
            chkMovieClearArtExtended.Checked = True
            chkMovieClearLogoExtended.Checked = True
            chkMovieDiscArtExtended.Checked = True
            chkMovieLandscapeExtended.Checked = True
        End If
    End Sub

    Private Sub chkMovieUseFrodo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieUseFrodo.CheckedChanged
        EnableApplyButton()

        chkMovieActorThumbsFrodo.Enabled = chkMovieUseFrodo.Checked
        chkMovieExtrafanartsFrodo.Enabled = chkMovieUseFrodo.Checked
        chkMovieExtrathumbsFrodo.Enabled = chkMovieUseFrodo.Checked
        chkMovieFanartFrodo.Enabled = chkMovieUseFrodo.Checked
        chkMovieNFOFrodo.Enabled = chkMovieUseFrodo.Checked
        chkMoviePosterFrodo.Enabled = chkMovieUseFrodo.Checked
        chkMovieTrailerFrodo.Enabled = chkMovieUseFrodo.Checked

        If Not chkMovieUseFrodo.Checked Then
            chkMovieActorThumbsFrodo.Checked = False
            chkMovieExtrafanartsFrodo.Checked = False
            chkMovieExtrathumbsFrodo.Checked = False
            chkMovieFanartFrodo.Checked = False
            chkMovieNFOFrodo.Checked = False
            chkMoviePosterFrodo.Checked = False
            chkMovieTrailerFrodo.Checked = False
        Else
            chkMovieActorThumbsFrodo.Checked = True
            chkMovieExtrafanartsFrodo.Checked = True
            chkMovieExtrathumbsFrodo.Checked = True
            chkMovieFanartFrodo.Checked = True
            chkMovieNFOFrodo.Checked = True
            chkMoviePosterFrodo.Checked = True
            chkMovieTrailerFrodo.Checked = True
        End If
    End Sub

    Private Sub chkMovieUseEden_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieUseEden.CheckedChanged
        EnableApplyButton()

        chkMovieActorThumbsEden.Enabled = chkMovieUseEden.Checked
        chkMovieExtrafanartsEden.Enabled = chkMovieUseEden.Checked
        chkMovieExtrathumbsEden.Enabled = chkMovieUseEden.Checked
        chkMovieFanartEden.Enabled = chkMovieUseEden.Checked
        chkMovieNFOEden.Enabled = chkMovieUseEden.Checked
        chkMoviePosterEden.Enabled = chkMovieUseEden.Checked
        chkMovieTrailerEden.Enabled = chkMovieUseEden.Checked

        If Not chkMovieUseEden.Checked Then
            chkMovieActorThumbsEden.Checked = False
            chkMovieExtrafanartsEden.Checked = False
            chkMovieExtrathumbsEden.Checked = False
            chkMovieFanartEden.Checked = False
            chkMovieNFOEden.Checked = False
            chkMoviePosterEden.Checked = False
            chkMovieTrailerEden.Checked = False
        Else
            chkMovieActorThumbsEden.Checked = True
            chkMovieExtrafanartsEden.Checked = True
            chkMovieExtrathumbsEden.Checked = True
            chkMovieFanartEden.Checked = True
            chkMovieNFOEden.Checked = True
            chkMoviePosterEden.Checked = True
            chkMovieTrailerEden.Checked = True
        End If
    End Sub

    Private Sub chkMovieUseYAMJ_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieUseYAMJ.CheckedChanged
        EnableApplyButton()

        chkMovieBannerYAMJ.Enabled = chkMovieUseYAMJ.Checked
        chkMovieFanartYAMJ.Enabled = chkMovieUseYAMJ.Checked
        chkMovieNFOYAMJ.Enabled = chkMovieUseYAMJ.Checked
        chkMoviePosterYAMJ.Enabled = chkMovieUseYAMJ.Checked
        chkMovieTrailerYAMJ.Enabled = chkMovieUseYAMJ.Checked
        chkMovieYAMJWatchedFile.Enabled = chkMovieUseYAMJ.Checked

        If Not chkMovieUseYAMJ.Checked Then
            chkMovieBannerYAMJ.Checked = False
            chkMovieFanartYAMJ.Checked = False
            chkMovieNFOYAMJ.Checked = False
            chkMoviePosterYAMJ.Checked = False
            chkMovieTrailerYAMJ.Checked = False
            chkMovieYAMJWatchedFile.Checked = False
        Else
            chkMovieBannerYAMJ.Checked = True
            chkMovieFanartYAMJ.Checked = True
            chkMovieNFOYAMJ.Checked = True
            chkMoviePosterYAMJ.Checked = True
            chkMovieTrailerYAMJ.Checked = True
        End If
    End Sub

    Private Sub chkMovieUseNMJ_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieUseNMJ.CheckedChanged
        EnableApplyButton()

        chkMovieBannerNMJ.Enabled = chkMovieUseNMJ.Checked
        chkMovieFanartNMJ.Enabled = chkMovieUseNMJ.Checked
        chkMovieNFONMJ.Enabled = chkMovieUseNMJ.Checked
        chkMoviePosterNMJ.Enabled = chkMovieUseNMJ.Checked
        chkMovieTrailerNMJ.Enabled = chkMovieUseNMJ.Checked

        If Not chkMovieUseNMJ.Checked Then
            chkMovieBannerNMJ.Checked = False
            chkMovieFanartNMJ.Checked = False
            chkMovieNFONMJ.Checked = False
            chkMoviePosterNMJ.Checked = False
            chkMovieTrailerNMJ.Checked = False
        Else
            chkMovieBannerNMJ.Checked = True
            chkMovieFanartNMJ.Checked = True
            chkMovieNFONMJ.Checked = True
            chkMoviePosterNMJ.Checked = True
            chkMovieTrailerNMJ.Checked = True
        End If
    End Sub

    Private Sub chkMovieThemeTvTunesCustom_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieThemeTvTunesCustom.CheckedChanged
        EnableApplyButton()

        txtMovieThemeTvTunesCustomPath.Enabled = chkMovieThemeTvTunesCustom.Checked
        btnMovieThemeTvTunesCustomPathBrowse.Enabled = chkMovieThemeTvTunesCustom.Checked

        If chkMovieThemeTvTunesCustom.Checked Then
            chkMovieThemeTvTunesMoviePath.Enabled = False
            chkMovieThemeTvTunesMoviePath.Checked = False
            chkMovieThemeTvTunesSub.Enabled = False
            chkMovieThemeTvTunesSub.Checked = False
        End If

        If Not chkMovieThemeTvTunesCustom.Checked AndAlso chkMovieThemeTvTunesEnabled.Checked Then
            chkMovieThemeTvTunesMoviePath.Enabled = True
            chkMovieThemeTvTunesSub.Enabled = True
        End If
    End Sub

    Private Sub chkMovieThemeTvTunesEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieThemeTvTunesEnabled.CheckedChanged
        EnableApplyButton()

        chkMovieThemeTvTunesCustom.Enabled = chkMovieThemeTvTunesEnabled.Checked
        chkMovieThemeTvTunesMoviePath.Enabled = chkMovieThemeTvTunesEnabled.Checked
        chkMovieThemeTvTunesSub.Enabled = chkMovieThemeTvTunesEnabled.Checked

        If Not chkMovieThemeTvTunesEnabled.Checked Then
            chkMovieThemeTvTunesCustom.Checked = False
            chkMovieThemeTvTunesMoviePath.Checked = False
            chkMovieThemeTvTunesSub.Checked = False
        Else
            chkMovieThemeTvTunesMoviePath.Checked = True
        End If
    End Sub

    Private Sub chkMovieThemeTvTunesMoviePath_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieThemeTvTunesMoviePath.CheckedChanged
        EnableApplyButton()

        If chkMovieThemeTvTunesMoviePath.Checked Then
            chkMovieThemeTvTunesCustom.Enabled = False
            chkMovieThemeTvTunesCustom.Checked = False
            chkMovieThemeTvTunesSub.Enabled = False
            chkMovieThemeTvTunesSub.Checked = False
        End If

        If Not chkMovieThemeTvTunesMoviePath.Checked AndAlso chkMovieThemeTvTunesEnabled.Checked Then
            chkMovieThemeTvTunesCustom.Enabled = True
            chkMovieThemeTvTunesSub.Enabled = True
        End If
    End Sub

    Private Sub chkMovieThemeTvTunesSub_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieThemeTvTunesSub.CheckedChanged
        EnableApplyButton()

        txtMovieThemeTvTunesSubDir.Enabled = chkMovieThemeTvTunesSub.Checked

        If chkMovieThemeTvTunesSub.Checked Then
            chkMovieThemeTvTunesCustom.Enabled = False
            chkMovieThemeTvTunesCustom.Checked = False
            chkMovieThemeTvTunesMoviePath.Enabled = False
            chkMovieThemeTvTunesMoviePath.Checked = False
        End If

        If Not chkMovieThemeTvTunesSub.Checked AndAlso chkMovieThemeTvTunesEnabled.Checked Then
            chkMovieThemeTvTunesCustom.Enabled = True
            chkMovieThemeTvTunesMoviePath.Enabled = True
        End If
    End Sub

    Private Sub chkMovieUseExpert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieUseExpert.CheckedChanged
        EnableApplyButton()

        chkMovieActorThumbsExpertBDMV.Enabled = chkMovieUseExpert.Checked
        chkMovieActorThumbsExpertMulti.Enabled = chkMovieUseExpert.Checked
        chkMovieActorThumbsExpertSingle.Enabled = chkMovieUseExpert.Checked
        chkMovieActorThumbsExpertVTS.Enabled = chkMovieUseExpert.Checked
        chkMovieExtrafanartsExpertBDMV.Enabled = chkMovieUseExpert.Checked
        chkMovieExtrafanartsExpertSingle.Enabled = chkMovieUseExpert.Checked
        chkMovieExtrafanartsExpertVTS.Enabled = chkMovieUseExpert.Checked
        chkMovieExtrathumbsExpertBDMV.Enabled = chkMovieUseExpert.Checked
        chkMovieExtrathumbsExpertSingle.Enabled = chkMovieUseExpert.Checked
        chkMovieExtrathumbsExpertVTS.Enabled = chkMovieUseExpert.Checked
        chkMovieRecognizeVTSExpertVTS.Enabled = chkMovieUseExpert.Checked
        chkMovieStackExpertMulti.Enabled = chkMovieUseExpert.Checked
        chkMovieStackExpertSingle.Enabled = chkMovieUseExpert.Checked
        chkMovieUnstackExpertMulti.Enabled = chkMovieStackExpertMulti.Enabled AndAlso chkMovieStackExpertMulti.Checked
        chkMovieUnstackExpertSingle.Enabled = chkMovieStackExpertSingle.Enabled AndAlso chkMovieStackExpertSingle.Checked
        txtMovieActorThumbsExtExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieActorThumbsExtExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieActorThumbsExtExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieActorThumbsExtExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMovieBannerExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieBannerExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieBannerExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieBannerExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMovieClearArtExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieClearArtExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieClearArtExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieClearArtExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMovieClearLogoExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieClearLogoExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieClearLogoExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieClearLogoExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMovieDiscArtExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieDiscArtExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieDiscArtExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieDiscArtExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMovieFanartExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieFanartExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieFanartExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieFanartExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMovieLandscapeExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieLandscapeExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieLandscapeExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieLandscapeExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMovieNFOExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieNFOExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieNFOExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieNFOExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMoviePosterExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMoviePosterExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMoviePosterExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMoviePosterExpertVTS.Enabled = chkMovieUseExpert.Checked
        txtMovieTrailerExpertBDMV.Enabled = chkMovieUseExpert.Checked
        txtMovieTrailerExpertMulti.Enabled = chkMovieUseExpert.Checked
        txtMovieTrailerExpertSingle.Enabled = chkMovieUseExpert.Checked
        txtMovieTrailerExpertVTS.Enabled = chkMovieUseExpert.Checked
    End Sub

    Private Sub chkMovieStackExpertMulti_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieStackExpertMulti.CheckedChanged
        EnableApplyButton()

        chkMovieUnstackExpertMulti.Enabled = chkMovieStackExpertMulti.Checked AndAlso chkMovieStackExpertMulti.Enabled
    End Sub

    Private Sub chkMovieStackExpertSingle_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieStackExpertSingle.CheckedChanged
        EnableApplyButton()

        chkMovieUnstackExpertSingle.Enabled = chkMovieStackExpertSingle.Checked AndAlso chkMovieStackExpertSingle.Enabled
    End Sub

    Private Sub chkMovieYAMJWatchedFile_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieYAMJWatchedFile.CheckedChanged
        EnableApplyButton()

        txtMovieYAMJWatchedFolder.Enabled = chkMovieYAMJWatchedFile.Checked
        btnMovieYAMJWatchedFilesBrowse.Enabled = chkMovieYAMJWatchedFile.Checked
    End Sub

    Private Sub EnableApplyButton() Handles _
        chkMovieActorThumbsEden.CheckedChanged,
        chkMovieActorThumbsExpertBDMV.CheckedChanged,
        chkMovieActorThumbsExpertMulti.CheckedChanged,
        chkMovieActorThumbsExpertSingle.CheckedChanged,
        chkMovieActorThumbsExpertVTS.CheckedChanged,
        chkMovieActorThumbsFrodo.CheckedChanged,
        chkMovieBannerAD.CheckedChanged,
        chkMovieBannerExtended.CheckedChanged,
        chkMovieBannerNMJ.CheckStateChanged,
        chkMovieBannerYAMJ.CheckStateChanged,
        chkMovieClearArtAD.CheckedChanged,
        chkMovieClearArtExtended.CheckedChanged,
        chkMovieClearLogoAD.CheckedChanged,
        chkMovieClearLogoExtended.CheckedChanged,
        chkMovieDiscArtAD.CheckedChanged,
        chkMovieDiscArtExtended.CheckedChanged,
        chkMovieExtrafanartsEden.CheckedChanged,
        chkMovieExtrafanartsExpertBDMV.CheckedChanged,
        chkMovieExtrafanartsExpertSingle.CheckedChanged,
        chkMovieExtrafanartsExpertVTS.CheckedChanged,
        chkMovieExtrafanartsFrodo.CheckedChanged,
        chkMovieExtrathumbsEden.CheckedChanged,
        chkMovieExtrathumbsExpertBDMV.CheckedChanged,
        chkMovieExtrathumbsExpertSingle.CheckedChanged,
        chkMovieExtrathumbsExpertVTS.CheckedChanged,
        chkMovieExtrathumbsFrodo.CheckedChanged,
        chkMovieFanartAD.CheckedChanged,
        chkMovieFanartBoxee.CheckedChanged,
        chkMovieFanartEden.CheckedChanged,
        chkMovieFanartFrodo.CheckedChanged,
        chkMovieFanartNMJ.CheckStateChanged,
        chkMovieFanartYAMJ.CheckStateChanged,
        chkMovieLandscapeAD.CheckedChanged,
        chkMovieLandscapeExtended.CheckedChanged,
        chkMovieNFOBoxee.CheckedChanged,
        chkMovieNFOEden.CheckedChanged,
        chkMovieNFOFrodo.CheckedChanged,
        chkMovieNFONMJ.CheckStateChanged,
        chkMovieNFOYAMJ.CheckStateChanged,
        chkMoviePosterAD.CheckedChanged,
        chkMoviePosterBoxee.CheckedChanged,
        chkMoviePosterEden.CheckedChanged,
        chkMoviePosterFrodo.CheckedChanged,
        chkMoviePosterNMJ.CheckStateChanged,
        chkMoviePosterYAMJ.CheckStateChanged,
        chkMovieRecognizeVTSExpertVTS.CheckedChanged,
        chkMovieTrailerEden.CheckedChanged,
        chkMovieTrailerFrodo.CheckedChanged,
        chkMovieTrailerNMJ.CheckStateChanged,
        chkMovieTrailerYAMJ.CheckStateChanged,
        chkMovieUnstackExpertMulti.CheckedChanged,
        chkMovieUnstackExpertSingle.CheckedChanged,
        chkProtectVTSBDMV.CheckedChanged,
        txtMovieActorThumbsExtExpertBDMV.TextChanged,
        txtMovieActorThumbsExtExpertMulti.TextChanged,
        txtMovieActorThumbsExtExpertSingle.TextChanged,
        txtMovieActorThumbsExtExpertVTS.TextChanged,
        txtMovieBannerExpertBDMV.TextChanged,
        txtMovieBannerExpertMulti.TextChanged,
        txtMovieBannerExpertSingle.TextChanged,
        txtMovieBannerExpertVTS.TextChanged,
        txtMovieClearArtExpertBDMV.TextChanged,
        txtMovieClearArtExpertMulti.TextChanged,
        txtMovieClearArtExpertSingle.TextChanged,
        txtMovieClearArtExpertVTS.TextChanged,
        txtMovieClearLogoExpertBDMV.TextChanged,
        txtMovieClearLogoExpertMulti.TextChanged,
        txtMovieClearLogoExpertSingle.TextChanged,
        txtMovieClearLogoExpertVTS.TextChanged,
        txtMovieDiscArtExpertBDMV.TextChanged,
        txtMovieDiscArtExpertMulti.TextChanged,
        txtMovieDiscArtExpertSingle.TextChanged,
        txtMovieDiscArtExpertVTS.TextChanged,
        txtMovieFanartExpertBDMV.TextChanged,
        txtMovieFanartExpertMulti.TextChanged,
        txtMovieFanartExpertSingle.TextChanged,
        txtMovieFanartExpertVTS.TextChanged,
        txtMovieLandscapeExpertBDMV.TextChanged,
        txtMovieLandscapeExpertMulti.TextChanged,
        txtMovieLandscapeExpertSingle.TextChanged,
        txtMovieLandscapeExpertVTS.TextChanged,
        txtMovieNFOExpertBDMV.TextChanged,
        txtMovieNFOExpertMulti.TextChanged,
        txtMovieNFOExpertSingle.TextChanged,
        txtMovieNFOExpertVTS.TextChanged,
        txtMoviePosterExpertBDMV.TextChanged,
        txtMoviePosterExpertMulti.TextChanged,
        txtMoviePosterExpertSingle.TextChanged,
        txtMoviePosterExpertVTS.TextChanged,
        txtMovieThemeTvTunesCustomPath.TextChanged,
        txtMovieThemeTvTunesSubDir.TextChanged,
        txtMovieTrailerExpertBDMV.TextChanged,
        txtMovieTrailerExpertMulti.TextChanged,
        txtMovieTrailerExpertSingle.TextChanged,
        txtMovieTrailerExpertVTS.TextChanged,
        txtMovieYAMJWatchedFolder.TextChanged

        Handle_SettingsChanged()
    End Sub

    Private Sub pbMovieSourcesADInfo_Click(sender As Object, e As EventArgs) Handles pbMovieSourcesADInfo.Click
        If Master.isWindows Then
            Process.Start("http://kodi.wiki/view/Add-on:Artwork_Downloader")
        Else
            Using Explorer As New Process
                Explorer.StartInfo.FileName = "xdg-open"
                Explorer.StartInfo.Arguments = "http://kodi.wiki/view/Add-on:Artwork_Downloader"
                Explorer.Start()
            End Using
        End If
    End Sub

    Private Sub pbMovieSourcesTvTunesInfo_Click(sender As Object, e As EventArgs) Handles pbMovieSourcesTvTunesInfo.Click
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
        'Actor Thumbs
        Dim strActorThumbs As String = Master.eLang.GetString(991, "Actor Thumbs")
        chkMovieActorThumbsExpertBDMV.Text = strActorThumbs
        chkMovieActorThumbsExpertMulti.Text = strActorThumbs
        chkMovieActorThumbsExpertSingle.Text = strActorThumbs
        chkMovieActorThumbsExpertVTS.Text = strActorThumbs
        lblMovieSourcesFilenamingKodiDefaultsActorThumbs.Text = strActorThumbs

        'also save unstacked
        Dim strAlsoSaveUnstacked As String = Master.eLang.GetString(1179, "also save unstacked")
        chkMovieUnstackExpertMulti.Text = strAlsoSaveUnstacked
        chkMovieUnstackExpertSingle.Text = strAlsoSaveUnstacked

        'Banner
        Dim strBanner As String = Master.eLang.GetString(838, "Banner")
        lblMovieSourcesFilenamingExpertBDMVBanner.Text = strBanner
        lblMovieSourcesFilenamingExpertMultiBanner.Text = strBanner
        lblMovieSourcesFilenamingExpertSingleBanner.Text = strBanner
        lblMovieSourcesFilenamingExpertVTSBanner.Text = strBanner
        lblMovieSourcesFilenamingKodiADBanner.Text = strBanner
        lblMovieSourcesFilenamingKodiExtendedBanner.Text = strBanner
        lblMovieSourcesFilenamingNMTDefaultsBanner.Text = strBanner

        'ClearArt
        Dim strClearArt As String = Master.eLang.GetString(1096, "ClearArt")
        lblMovieSourcesFilenamingExpertBDMVClearArt.Text = strClearArt
        lblMovieSourcesFilenamingExpertMultiClearArt.Text = strClearArt
        lblMovieSourcesFilenamingExpertSingleClearArt.Text = strClearArt
        lblMovieSourcesFilenamingExpertVTSClearArt.Text = strClearArt
        lblMovieSourcesFileNamingKodiADClearArt.Text = strClearArt
        lblMovieSourcesFileNamingKodiExtendedClearArt.Text = strClearArt

        'ClearLogo
        Dim strClearLogo As String = Master.eLang.GetString(1097, "ClearLogo")
        lblMovieSourcesFilenamingExpertBDMVClearLogo.Text = strClearLogo
        lblMovieSourcesFilenamingExpertMultiClearLogo.Text = strClearLogo
        lblMovieSourcesFilenamingExpertSingleClearLogo.Text = strClearLogo
        lblMovieSourcesFilenamingExpertVTSClearLogo.Text = strClearLogo
        lblMovieSourcesFilenamingKodiADClearLogo.Text = strClearLogo
        lblMovieSourcesFilenamingKodiExtendedClearLogo.Text = strClearLogo

        'Defaults
        Dim strDefaults As String = Master.eLang.GetString(713, "Defaults")
        gbMovieSourcesFilenamingBoxeeDefaultsOpts.Text = strDefaults
        gbMovieSourcesFilenamingNMTDefaultsOpts.Text = strDefaults
        gbMovieSourcesFilenamingKodiDefaultsOpts.Text = strDefaults

        'DiscArt
        Dim strDiscArt As String = Master.eLang.GetString(1098, "DiscArt")
        lblMovieSourcesFilenamingExpertBDMVDiscArt.Text = strDiscArt
        lblMovieSourcesFilenamingExpertMultiDiscArt.Text = strDiscArt
        lblMovieSourcesFilenamingExpertSingleDiscArt.Text = strDiscArt
        lblMovieSourcesFilenamingExpertVTSDiscArt.Text = strDiscArt
        lblMovieSourcesFilenamingKodiADDiscArt.Text = strDiscArt
        lblMovieSourcesFilenamingKodiExtendedDiscArt.Text = strDiscArt

        'Enabled
        Dim strEnabled As String = Master.eLang.GetString(774, "Enabled")
        lblMovieSourcesFilenamingBoxeeDefaultsEnabled.Text = strEnabled
        lblMovieSourcesFilenamingKodiADEnabled.Text = strEnabled
        lblMovieSourcesFilenamingKodiDefaultsEnabled.Text = strEnabled
        lblMovieSourcesFilenamingKodiExtendedEnabled.Text = strEnabled
        lblMovieSourcesFilenamingNMTDefaultsEnabled.Text = strEnabled
        chkMovieUseExpert.Text = strEnabled
        chkMovieThemeTvTunesEnabled.Text = strEnabled

        'Extrafanarts
        Dim strExtrafanarts As String = Master.eLang.GetString(992, "Extrafanarts")
        chkMovieExtrafanartsExpertBDMV.Text = strExtrafanarts
        chkMovieExtrafanartsExpertSingle.Text = strExtrafanarts
        chkMovieExtrafanartsExpertVTS.Text = strExtrafanarts
        lblMovieSourcesFilenamingKodiDefaultsExtrafanarts.Text = strExtrafanarts

        'Extrathumbs
        Dim strExtrathumbs As String = Master.eLang.GetString(153, "Extrathumbs")
        chkMovieExtrathumbsExpertBDMV.Text = strExtrathumbs
        chkMovieExtrathumbsExpertSingle.Text = strExtrathumbs
        chkMovieExtrathumbsExpertVTS.Text = strExtrathumbs
        lblMovieSourcesFilenamingKodiDefaultsExtrathumbs.Text = strExtrathumbs

        'Fanart
        Dim strFanart As String = Master.eLang.GetString(149, "Fanart")
        lblMovieSourcesFilenamingBoxeeDefaultsFanart.Text = strFanart
        lblMovieSourcesFilenamingExpertBDMVFanart.Text = strFanart
        lblMovieSourcesFilenamingExpertMultiFanart.Text = strFanart
        lblMovieSourcesFilenamingExpertSingleFanart.Text = strFanart
        lblMovieSourcesFilenamingExpertVTSFanart.Text = strFanart
        lblMovieSourcesFilenamingNMTDefaultsFanart.Text = strFanart
        lblMovieSourcesFilenamingKodiADFanart.Text = strFanart
        lblMovieSourcesFilenamingKodiDefaultsFanart.Text = strFanart

        'Landscape
        Dim strLandscape As String = Master.eLang.GetString(1059, "Landscape")
        lblMovieSourcesFilenamingExpertBDMVLandscape.Text = strLandscape
        lblMovieSourcesFilenamingExpertMultiLandscape.Text = strLandscape
        lblMovieSourcesFilenamingExpertSingleLandscape.Text = strLandscape
        lblMovieSourcesFilenamingExpertVTSLandscape.Text = strLandscape
        lblMovieSourcesFilenamingKodiADLandscape.Text = strLandscape
        lblMovieSourcesFilenamingKodiExtendedLandscape.Text = strLandscape

        'NFO
        Dim strNFO As String = Master.eLang.GetString(150, "NFO")
        lblMovieSourcesFilenamingBoxeeDefaultsNFO.Text = strNFO
        lblMovieSourcesFilenamingExpertBDMVNFO.Text = strNFO
        lblMovieSourcesFilenamingExpertMultiNFO.Text = strNFO
        lblMovieSourcesFilenamingExpertSingleNFO.Text = strNFO
        lblMovieSourcesFilenamingExpertVTSNFO.Text = strNFO
        lblMovieSourcesFilenamingKodiDefaultsNFO.Text = strNFO
        lblMovieSourcesFilenamingNMTDefaultsNFO.Text = strNFO

        'Optional Images
        Dim strOptionalImages As String = Master.eLang.GetString(267, "Optional Images")
        gbMovieSourcesFilenamingExpertBDMVImagesOpts.Text = strOptionalImages
        gbMovieSourcesFilenamingExpertMultiImagesOpts.Text = strOptionalImages
        gbMovieSourcesFilenamingExpertSingleImagesOpts.Text = strOptionalImages
        gbMovieSourcesFilenamingExpertVTSImagesOpts.Text = strOptionalImages

        'Optional Settings
        Dim strOptionalSettings As String = Master.eLang.GetString(1175, "Optional Settings")
        gbMovieSourcesFilenamingExpertMultiOptionalOpts.Text = strOptionalSettings
        gbMovieSourcesFilenamingExpertSingleOptionalOpts.Text = strOptionalSettings
        gbMovieSourcesFilenamingExpertVTSOptionalOpts.Text = strOptionalSettings
        gbOptionalSettings.Text = strOptionalSettings
        gbMovieSourcesFilenamingNMTOptionalOpts.Text = strOptionalSettings

        'Poster
        Dim strPoster As String = Master.eLang.GetString(148, "Poster")
        lblMovieSourcesFilenamingExpertBDMVPoster.Text = strPoster
        lblMovieSourcesFilenamingExpertMultiPoster.Text = strPoster
        lblMovieSourcesFilenamingExpertSinglePoster.Text = strPoster
        lblMovieSourcesFilenamingExpertVTSPoster.Text = strPoster
        lblMovieSourcesFilenamingBoxeeDefaultsPoster.Text = strPoster
        lblMovieSourcesFilenamingKodiDefaultsPoster.Text = strPoster
        lblMovieSourcesFilenamingKodiADPoster.Text = strPoster
        lblMovieSourcesFilenamingNMTDefaultsPoster.Text = strPoster

        'Stack <filename>
        Dim strStackFileName As String = String.Format(Master.eLang.GetString(1178, "Stack {0}filename{1}"), "<", ">")
        chkMovieStackExpertMulti.Text = strStackFileName
        chkMovieStackExpertSingle.Text = strStackFileName


        'Trailer
        Dim strTrailer As String = Master.eLang.GetString(151, "Trailer")
        lblMovieSourcesFilenamingExpertBDMVTrailer.Text = strTrailer
        lblMovieSourcesFilenamingExpertMultiTrailer.Text = strTrailer
        lblMovieSourcesFilenamingExpertSingleTrailer.Text = strTrailer
        lblMovieSourcesFilenamingExpertVTSTrailer.Text = strTrailer
        lblMovieSourcesFilenamingKodiDefaultsTrailer.Text = strTrailer
        lblMovieSourcesFilenamingNMTDefaultsTrailer.Text = strTrailer

        tpMovieSourcesFilenamingExpert.Text = Master.eLang.GetString(439, "Expert")
        gbMovieSourcesFilenamingExpertOpts.Text = Master.eLang.GetString(1181, "Expert Settings")
        gbMovieSourcesFilenamingKodiExtendedOpts.Text = Master.eLang.GetString(822, "Extended Images")
        gbMovieSourcesFilenamingOpts.Text = Master.eLang.GetString(471, "File Naming")
        chkMovieThemeTvTunesMoviePath.Text = Master.eLang.GetString(1258, "Store themes in movie directory")
        chkMovieThemeTvTunesCustom.Text = Master.eLang.GetString(1259, "Store themes in a custom path")
        chkMovieThemeTvTunesSub.Text = Master.eLang.GetString(1260, "Store themes in sub directories")
        chkMovieSourcesBackdropsAuto.Text = Master.eLang.GetString(521, "Automatically Save Fanart To Backdrops Folder")
        chkMovieRecognizeVTSExpertVTS.Text = String.Format(Master.eLang.GetString(537, "Recognize VIDEO_TS{0}without VIDEO_TS folder"), Environment.NewLine)
        chkProtectVTSBDMV.Text = Master.eLang.GetString(1176, "Protect DVD/Bluray Structure")
        chkMovieYAMJWatchedFile.Text = Master.eLang.GetString(1177, "Use .watched Files")
        gbMovieSourcesBackdropsFolderOpts.Text = Master.eLang.GetString(520, "Backdrops Folder")
    End Sub

    Private Sub txtMovieSourcesBackdropsFolderPath_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMovieSourcesBackdropsFolderPath.TextChanged
        EnableApplyButton()

        If String.IsNullOrEmpty(txtMovieSourcesBackdropsFolderPath.Text.Trim) Then
            chkMovieSourcesBackdropsAuto.Checked = False
            chkMovieSourcesBackdropsAuto.Enabled = False
        Else
            chkMovieSourcesBackdropsAuto.Enabled = True
        End If
    End Sub

#End Region 'Methods

End Class