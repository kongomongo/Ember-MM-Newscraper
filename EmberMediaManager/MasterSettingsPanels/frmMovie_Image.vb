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

Public Class frmMovie_Image
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Movie
    Dim _intImageIndex As Integer = 6
    Dim _intOrder As Integer = 500
    Dim _strName As String = "Movie_Image"
    Dim _strTitle As String = Master.eLang.GetString(497, "Images")

    Private _bDGVWidthCalculated As Boolean

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
        With Master.eSettings.Movie.ImageSettings
            cbBannerPrefSize.SelectedValue = .Banner.PrefSize
            cbClearArtPrefSize.SelectedValue = .ClearArt.PrefSize
            cbClearLogoPrefSize.SelectedValue = .ClearLogo.PrefSize
            cbDiscArtPrefSize.SelectedValue = .DiscArt.PrefSize
            cbExtrafanartsPrefSize.SelectedValue = .Extrafanarts.PrefSize
            cbExtrathumbsPrefSize.SelectedValue = .Extrathumbs.PrefSize
            cbFanartPrefSize.SelectedValue = .Fanart.PrefSize
            cbLandscapePrefSize.SelectedValue = .Landscape.PrefSize
            cbPosterPrefSize.SelectedValue = .Poster.PrefSize
            chkActorThumbsKeepExisting.Checked = .Actorthumbs.KeepExisting
            chkBannerFixedSize.Checked = .Banner.FixedSize
            chkBannerKeepExisting.Checked = .Banner.KeepExisting
            chkBannerPrefSizeOnly.Checked = .Banner.PrefSizeOnly
            chkClearArtKeepExisting.Checked = .ClearArt.KeepExisting
            chkClearArtPrefSizeOnly.Checked = .ClearArt.PrefSizeOnly
            chkClearLogoKeepExisting.Checked = .ClearLogo.KeepExisting
            chkClearLogoPrefSizeOnly.Checked = .ClearLogo.PrefSizeOnly
            chkDiscArtKeepExisting.Checked = .DiscArt.KeepExisting
            chkDiscArtPrefSizeOnly.Checked = .DiscArt.PrefSizeOnly
            chkExtrafanartsFixedSize.Checked = .Extrafanarts.FixedSize
            chkExtrafanartsKeepExisting.Checked = .Extrafanarts.KeepExisting
            chkExtrafanartsPrefSizeOnly.Checked = .Extrafanarts.PrefSizeOnly
            chkExtrafanartsPreselect.Checked = .Extrafanarts.Preselect
            chkExtrathumbsCreator.Checked = .Extrathumbs.Creator
            chkExtrathumbsCreatorAsFallback.Checked = .Extrathumbs.CreatorAsFallback
            chkExtrathumbsCreatorNoBlackBars.Checked = .Extrathumbs.CreatorNoBlackBars
            chkExtrathumbsCreatorNoSpoilers.Checked = .Extrathumbs.CreatorNoSpoilers
            chkExtrathumbsFixedSize.Checked = .Extrathumbs.FixedSize
            chkExtrathumbsKeepExisting.Checked = .Extrathumbs.KeepExisting
            chkExtrathumbsPrefSizeOnly.Checked = .Extrathumbs.PrefSizeOnly
            chkExtrathumbsPreselect.Checked = .Extrathumbs.Preselect
            chkFanartFixedSize.Checked = .Fanart.FixedSize
            chkFanartKeepExisting.Checked = .Fanart.KeepExisting
            chkFanartPrefSizeOnly.Checked = .Fanart.PrefSizeOnly
            chkLandscapeFixedSize.Checked = .Landscape.FixedSize
            chkLandscapeKeepExisting.Checked = .Landscape.KeepExisting
            chkLandscapePrefSizeOnly.Checked = .Landscape.PrefSizeOnly
            chkMovieImagesCacheEnabled.Checked = .CacheEnabled
            chkMovieImagesDisplayImageSelect.Checked = .DisplayImageSelectDialog
            chkMovieImagesForceLanguage.Checked = .Language.ForceLanguage
            chkMovieImagesNotSaveURLToNfo.Checked = .NotSaveURLToNfo
            chkPosterFixedSize.Checked = .Poster.FixedSize
            chkPosterKeepExisting.Checked = .Poster.KeepExisting
            chkPosterPrefSizeOnly.Checked = .Poster.PrefSizeOnly
            txtActorthumbsHeight.Text = .Actorthumbs.MaxHeight.ToString
            txtActorthumbsWidth.Text = .Actorthumbs.MaxWidth.ToString
            txtBannerHeight.Text = .Banner.MaxHeight.ToString
            txtBannerWidth.Text = .Banner.MaxWidth.ToString
            txtExtrafanartsHeight.Text = .Extrafanarts.MaxHeight.ToString
            txtExtrafanartsLimit.Text = .Extrafanarts.Limit.ToString
            txtExtrafanartsWidth.Text = .Extrafanarts.MaxWidth.ToString
            txtExtrathumbsHeight.Text = .Extrathumbs.MaxHeight.ToString
            txtExtrathumbsLimit.Text = .Extrathumbs.Limit.ToString
            txtExtrathumbsWidth.Text = .Extrathumbs.MaxWidth.ToString
            txtFanartHeight.Text = .Fanart.MaxHeight.ToString
            txtFanartWidth.Text = .Fanart.MaxWidth.ToString
            txtLandscapeHeight.Text = .Landscape.MaxHeight.ToString
            txtLandscapeWidth.Text = .Landscape.MaxWidth.ToString
            txtPosterHeight.Text = .Poster.MaxHeight.ToString
            txtPosterWidth.Text = .Poster.MaxWidth.ToString

            If .Language.GetMediaLanguageOnly Then
                chkMovieImagesMediaLanguageOnly.Checked = True
                chkMovieImagesGetBlankImages.Checked = .Language.GetBlankImages
                chkMovieImagesGetEnglishImages.Checked = .Language.GetEnglishImages
            End If

            Try
                cbMovieImagesForcedLanguage.Items.Clear()
                cbMovieImagesForcedLanguage.Items.AddRange((From lLang In APIXML.ScraperLanguagesXML.Languages Select lLang.Name).Distinct.ToArray)
                If cbMovieImagesForcedLanguage.Items.Count > 0 Then
                    If .Language.ForceLanguageSpecified Then
                        Dim tLanguage As languageProperty = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = .Language.ForcedLanguage)
                        If tLanguage IsNot Nothing Then
                            cbMovieImagesForcedLanguage.Text = tLanguage.Name
                        Else
                            tLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation.StartsWith(.Language.ForcedLanguage))
                            If tLanguage IsNot Nothing Then
                                cbMovieImagesForcedLanguage.Text = tLanguage.Name
                            Else
                                cbMovieImagesForcedLanguage.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = "en").Name
                            End If
                        End If
                    Else
                        cbMovieImagesForcedLanguage.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = "en").Name
                    End If
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.Movie.ImageSettings
            .Actorthumbs.KeepExisting = chkActorThumbsKeepExisting.Checked
            .Banner.FixedSize = chkBannerFixedSize.Checked
            .Banner.MaxHeight = If(Not String.IsNullOrEmpty(txtBannerHeight.Text), Convert.ToInt32(txtBannerHeight.Text), 0)
            .Banner.KeepExisting = chkBannerKeepExisting.Checked
            .Banner.PrefSize = CType(cbBannerPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Banner.PrefSizeOnly = chkBannerPrefSizeOnly.Checked
            .Banner.MaxWidth = If(Not String.IsNullOrEmpty(txtBannerWidth.Text), Convert.ToInt32(txtBannerWidth.Text), 0)
            .ClearArt.KeepExisting = chkClearArtKeepExisting.Checked
            .ClearArt.PrefSize = CType(cbClearArtPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .ClearArt.PrefSizeOnly = chkClearArtPrefSizeOnly.Checked
            .ClearLogo.KeepExisting = chkClearLogoKeepExisting.Checked
            .ClearLogo.PrefSize = CType(cbClearLogoPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .ClearLogo.PrefSizeOnly = chkClearLogoPrefSizeOnly.Checked
            .DiscArt.KeepExisting = chkDiscArtKeepExisting.Checked
            .DiscArt.PrefSize = CType(cbDiscArtPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .DiscArt.PrefSizeOnly = chkDiscArtPrefSizeOnly.Checked
            .Extrafanarts.FixedSize = chkExtrafanartsFixedSize.Checked
            .Extrafanarts.MaxHeight = If(Not String.IsNullOrEmpty(txtExtrafanartsHeight.Text), Convert.ToInt32(txtExtrafanartsHeight.Text), 0)
            .Extrafanarts.Limit = If(Not String.IsNullOrEmpty(txtExtrafanartsLimit.Text), Convert.ToInt32(txtExtrafanartsLimit.Text), 0)
            .Extrafanarts.KeepExisting = chkExtrafanartsKeepExisting.Checked
            .Extrafanarts.PrefSize = CType(cbExtrafanartsPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Extrafanarts.PrefSizeOnly = chkExtrafanartsPrefSizeOnly.Checked
            .Extrafanarts.Preselect = chkExtrafanartsPreselect.Checked
            .Extrafanarts.MaxWidth = If(Not String.IsNullOrEmpty(txtExtrafanartsWidth.Text), Convert.ToInt32(txtExtrafanartsWidth.Text), 0)
            .Extrathumbs.Creator = chkExtrathumbsCreator.Checked
            .Extrathumbs.CreatorAsFallback = chkExtrathumbsCreatorAsFallback.Checked
            .Extrathumbs.CreatorNoBlackBars = chkExtrathumbsCreatorNoBlackBars.Checked
            .Extrathumbs.CreatorNoSpoilers = chkExtrathumbsCreatorNoSpoilers.Checked
            .Extrathumbs.FixedSize = chkExtrathumbsFixedSize.Checked
            .Extrathumbs.MaxHeight = If(Not String.IsNullOrEmpty(txtExtrathumbsHeight.Text), Convert.ToInt32(txtExtrathumbsHeight.Text), 0)
            .Extrathumbs.Limit = If(Not String.IsNullOrEmpty(txtExtrathumbsLimit.Text), Convert.ToInt32(txtExtrathumbsLimit.Text), 0)
            .Extrathumbs.KeepExisting = chkExtrathumbsKeepExisting.Checked
            .Extrathumbs.PrefSize = CType(cbExtrathumbsPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Extrathumbs.PrefSizeOnly = chkExtrathumbsPrefSizeOnly.Checked
            .Extrathumbs.Preselect = chkExtrathumbsPreselect.Checked
            .Extrathumbs.MaxWidth = If(Not String.IsNullOrEmpty(txtExtrathumbsWidth.Text), Convert.ToInt32(txtExtrathumbsWidth.Text), 0)
            .Fanart.FixedSize = chkFanartFixedSize.Checked
            .Fanart.MaxHeight = If(Not String.IsNullOrEmpty(txtFanartHeight.Text), Convert.ToInt32(txtFanartHeight.Text), 0)
            .Fanart.KeepExisting = chkFanartKeepExisting.Checked
            .Fanart.PrefSize = CType(cbFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Fanart.PrefSizeOnly = chkFanartPrefSizeOnly.Checked
            .Fanart.MaxWidth = If(Not String.IsNullOrEmpty(txtFanartWidth.Text), Convert.ToInt32(txtFanartWidth.Text), 0)
            .CacheEnabled = chkMovieImagesCacheEnabled.Checked
            .DisplayImageSelectDialog = chkMovieImagesDisplayImageSelect.Checked
            If Not String.IsNullOrEmpty(cbMovieImagesForcedLanguage.Text) Then
                .Language.ForcedLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Name = cbMovieImagesForcedLanguage.Text).Abbrevation_MainLanguage
            End If
            .Language.ForceLanguage = chkMovieImagesForceLanguage.Checked
            .Language.GetBlankImages = chkMovieImagesGetBlankImages.Checked
            .Language.GetEnglishImages = chkMovieImagesGetEnglishImages.Checked
            .Language.GetMediaLanguageOnly = chkMovieImagesMediaLanguageOnly.Checked
            .NotSaveURLToNfo = chkMovieImagesNotSaveURLToNfo.Checked
            .Landscape.FixedSize = chkLandscapeFixedSize.Checked
            .Landscape.KeepExisting = chkLandscapeKeepExisting.Checked
            .Landscape.MaxHeight = If(Not String.IsNullOrEmpty(txtLandscapeHeight.Text), Convert.ToInt32(txtLandscapeHeight.Text), 0)
            .Landscape.MaxWidth = If(Not String.IsNullOrEmpty(txtLandscapeWidth.Text), Convert.ToInt32(txtLandscapeWidth.Text), 0)
            .Landscape.PrefSize = CType(cbLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Landscape.PrefSizeOnly = chkLandscapePrefSizeOnly.Checked
            .Poster.FixedSize = chkPosterFixedSize.Checked
            .Poster.MaxHeight = If(Not String.IsNullOrEmpty(txtPosterHeight.Text), Convert.ToInt32(txtPosterHeight.Text), 0)
            .Poster.KeepExisting = chkPosterKeepExisting.Checked
            .Poster.PrefSize = CType(cbPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Poster.PrefSizeOnly = chkPosterPrefSizeOnly.Checked
            .Poster.MaxWidth = If(Not String.IsNullOrEmpty(txtPosterWidth.Text), Convert.ToInt32(txtPosterWidth.Text), 0)
        End With
    End Sub

#End Region 'Interface Methods

#Region "Methods"

    Private Sub LoadMovieBannerSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x185", Enums.ImageSize.HD185)
        cbBannerPrefSize.DataSource = items.ToList
        cbBannerPrefSize.DisplayMember = "Key"
        cbBannerPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadMovieClearArtSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x562", Enums.ImageSize.HD562)
        items.Add("500x281", Enums.ImageSize.SD281)
        cbClearArtPrefSize.DataSource = items.ToList
        cbClearArtPrefSize.DisplayMember = "Key"
        cbClearArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadMovieClearLogoSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("800x310", Enums.ImageSize.HD310)
        items.Add("400x155", Enums.ImageSize.SD155)
        cbClearLogoPrefSize.DataSource = items.ToList
        cbClearLogoPrefSize.DisplayMember = "Key"
        cbClearLogoPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadMovieDiscArtSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x1000", Enums.ImageSize.HD1000)
        cbDiscArtPrefSize.DataSource = items.ToList
        cbDiscArtPrefSize.DisplayMember = "Key"
        cbDiscArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadMovieFanartSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("3840x2160", Enums.ImageSize.UHD2160)
        items.Add("2560x1440", Enums.ImageSize.QHD1440)
        items.Add("1920x1080", Enums.ImageSize.HD1080)
        items.Add("1280x720", Enums.ImageSize.HD720)
        items.Add("Thumb", Enums.ImageSize.Thumb)
        cbExtrafanartsPrefSize.DataSource = items.ToList
        cbExtrafanartsPrefSize.DisplayMember = "Key"
        cbExtrafanartsPrefSize.ValueMember = "Value"
        cbExtrathumbsPrefSize.DataSource = items.ToList
        cbExtrathumbsPrefSize.DisplayMember = "Key"
        cbExtrathumbsPrefSize.ValueMember = "Value"
        cbFanartPrefSize.DataSource = items.ToList
        cbFanartPrefSize.DisplayMember = "Key"
        cbFanartPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadMovieLandscapeSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x562", Enums.ImageSize.HD562)
        cbLandscapePrefSize.DataSource = items.ToList
        cbLandscapePrefSize.DisplayMember = "Key"
        cbLandscapePrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadMoviePosterSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("2000x3000", Enums.ImageSize.UHD3000)
        items.Add("1400x2100", Enums.ImageSize.UHD2100)
        items.Add("1000x1500", Enums.ImageSize.HD1500)
        items.Add("1000x1426", Enums.ImageSize.HD1426)
        cbPosterPrefSize.DataSource = items.ToList
        cbPosterPrefSize.DisplayMember = "Key"
        cbPosterPrefSize.ValueMember = "Value"
    End Sub

    Private Sub SetUp()
        LoadMovieBannerSizes()
        LoadMovieClearArtSizes()
        LoadMovieClearLogoSizes()
        LoadMovieDiscArtSizes()
        LoadMovieFanartSizes()
        LoadMovieLandscapeSizes()
        LoadMoviePosterSizes()

        'Preselect in "Image Select" dialog
        Dim strPreselectInImageSelectDialog As String = Master.eLang.GetString(1023, "Preselect in ""Image Select"" dialog")
        chkExtrafanartsPreselect.Text = strPreselectInImageSelectDialog
        chkExtrathumbsPreselect.Text = strPreselectInImageSelectDialog

        lblKeepExisting.Text = Master.eLang.GetString(971, "Keep existing")
        lblLimit.Text = Master.eLang.GetString(578, "Limit")
        lblHeight.Text = Master.eLang.GetString(480, "Max Height")
        lblWidth.Text = Master.eLang.GetString(479, "Max Width")
        lblOnly.Text = Master.eLang.GetString(145, "Only")
        lblPreferredSize.Text = Master.eLang.GetString(482, "Preferred Size")
        lblBanner.Text = Master.eLang.GetString(838, "Banner")
        lblClearArt.Text = Master.eLang.GetString(1096, "ClearArt")
        lblClearLogo.Text = Master.eLang.GetString(1097, "ClearLogo")
        lblDiscArt.Text = Master.eLang.GetString(1098, "DiscArt")
        chkMovieImagesDisplayImageSelect.Text = Master.eLang.GetString(499, "Display ""Image Select"" dialog while single scraping")
        lblActorThumbs.Text = Master.eLang.GetString(991, "Actor Thumbs")
        chkMovieImagesGetBlankImages.Text = Master.eLang.GetString(1207, "Also Get Blank Images")
        chkMovieImagesGetEnglishImages.Text = Master.eLang.GetString(737, "Also Get English Images")
        chkMovieImagesNotSaveURLToNfo.Text = Master.eLang.GetString(498, "Do not save URLs to NFO")
        chkMovieImagesCacheEnabled.Text = Master.eLang.GetString(249, "Enable Image Caching")
        lblExtrafanarts.Text = Master.eLang.GetString(992, "Extrafanarts")
        lblExtrathumbs.Text = Master.eLang.GetString(153, "Extrathumbs")
        lblFanart.Text = Master.eLang.GetString(149, "Fanart")
        chkMovieImagesForceLanguage.Text = Master.eLang.GetString(1034, "Force Language")
        gbMovieImagesOpts.Text = Master.eLang.GetString(497, "Images")
        lblLandscape.Text = Master.eLang.GetString(1059, "Landscape")
        chkMovieImagesMediaLanguageOnly.Text = Master.eLang.GetString(736, "Only Get Images for the Media Language")
        lblPoster.Text = Master.eLang.GetString(148, "Poster")
        gbMovieImagesLanguageOpts.Text = Master.eLang.GetString(741, "Preferred Language")
        chkExtrathumbsCreator.Text = Master.eLang.GetString(1475, "Create thumbs instead of using fanarts")
        chkExtrathumbsCreatorNoBlackBars.Text = Master.eLang.GetString(1474, "Remove Black Bars")
        chkExtrathumbsCreatorNoSpoilers.Text = Master.eLang.GetString(1473, "No Spoilers")
        chkExtrathumbsCreatorAsFallback.Text = Master.eLang.GetString(1476, "Only create thumbs if no fanart found")
        lblFanart.Text = Master.eLang.GetString(149, "Fanart")
        gbExtrathumbsCreatorOpts.Text = Master.eLang.GetString(1477, "Create Thumbnails")

        clsAPITemp.ConvertToScraperGridView(dgvBanner, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_Banner)))
        clsAPITemp.ConvertToScraperGridView(dgvClearArt, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_ClearArt)))
        clsAPITemp.ConvertToScraperGridView(dgvClearLogo, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_ClearLogo)))
        clsAPITemp.ConvertToScraperGridView(dgvDiscArt, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_DiscArt)))
        clsAPITemp.ConvertToScraperGridView(dgvExtrafanarts, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvExtrathumbs, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvFanart, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvLandscape, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_Landscape)))
        clsAPITemp.ConvertToScraperGridView(dgvPoster, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Image_Poster)))
    End Sub

    Private Sub EnableApplyButton() Handles _
        cbBannerPrefSize.SelectedIndexChanged,
        cbClearArtPrefSize.SelectedIndexChanged,
        cbClearLogoPrefSize.SelectedIndexChanged,
        cbDiscArtPrefSize.SelectedIndexChanged,
        cbExtrafanartsPrefSize.SelectedIndexChanged,
        cbExtrathumbsPrefSize.SelectedIndexChanged,
        cbFanartPrefSize.SelectedIndexChanged,
        cbMovieImagesForcedLanguage.SelectedIndexChanged,
        cbLandscapePrefSize.SelectedIndexChanged,
        cbPosterPrefSize.SelectedIndexChanged,
        chkActorThumbsKeepExisting.CheckedChanged,
        chkBannerKeepExisting.CheckedChanged,
        chkBannerPrefSizeOnly.CheckedChanged,
        chkClearArtKeepExisting.CheckedChanged,
        chkClearArtPrefSizeOnly.CheckedChanged,
        chkClearLogoKeepExisting.CheckedChanged,
        chkClearLogoPrefSizeOnly.CheckedChanged,
        chkDiscArtKeepExisting.CheckedChanged,
        chkDiscArtPrefSizeOnly.CheckedChanged,
        chkExtrafanartsKeepExisting.CheckedChanged,
        chkExtrafanartsPrefSizeOnly.CheckedChanged,
        chkExtrafanartsPreselect.CheckedChanged,
        chkExtrathumbsCreatorNoBlackBars.CheckedChanged,
        chkExtrathumbsCreatorNoSpoilers.CheckedChanged,
        chkExtrathumbsKeepExisting.CheckedChanged,
        chkExtrathumbsPrefSizeOnly.CheckedChanged,
        chkExtrathumbsPreselect.CheckedChanged,
        chkFanartKeepExisting.CheckedChanged,
        chkFanartPrefSizeOnly.CheckedChanged,
        chkMovieImagesCacheEnabled.CheckedChanged,
        chkMovieImagesDisplayImageSelect.CheckedChanged,
        chkMovieImagesGetBlankImages.CheckedChanged,
        chkMovieImagesGetEnglishImages.CheckedChanged,
        chkMovieImagesNotSaveURLToNfo.CheckedChanged,
        chkLandscapeKeepExisting.CheckedChanged,
        chkLandscapePrefSizeOnly.CheckedChanged,
        chkPosterKeepExisting.CheckedChanged,
        chkPosterPrefSizeOnly.CheckedChanged,
        txtBannerHeight.TextChanged,
        txtBannerWidth.TextChanged,
        txtExtrafanartsHeight.TextChanged,
        txtExtrafanartsLimit.TextChanged,
        txtExtrafanartsWidth.TextChanged,
        txtExtrathumbsHeight.TextChanged,
        txtExtrathumbsLimit.TextChanged,
        txtExtrathumbsWidth.TextChanged,
        txtFanartHeight.TextChanged,
        txtFanartWidth.TextChanged,
        txtPosterHeight.TextChanged,
        txtPosterWidth.TextChanged

        Handle_SettingsChanged()
    End Sub

    Private Sub chkMovieExtrathumbsCreatorAutoThumbs_CheckedChanged(sender As Object, e As EventArgs) Handles chkExtrathumbsCreator.CheckedChanged
        EnableApplyButton()

        If chkExtrathumbsCreator.Checked = True Then
            chkExtrathumbsCreatorAsFallback.Checked = False
        End If
    End Sub

    Private Sub chkMovieExtrathumbsCreatorUseETasFA_CheckedChanged(sender As Object, e As EventArgs) Handles chkExtrathumbsCreatorAsFallback.CheckedChanged
        EnableApplyButton()

        If chkExtrathumbsCreatorAsFallback.Checked = True Then
            chkExtrathumbsCreator.Checked = False
        End If
    End Sub

    Private Sub KeyPress_Integer(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles _
        txtActorthumbsHeight.KeyPress,
        txtActorthumbsWidth.KeyPress,
        txtBannerHeight.KeyPress,
        txtBannerWidth.KeyPress,
        txtExtrafanartsHeight.KeyPress,
        txtExtrafanartsLimit.KeyPress,
        txtExtrafanartsWidth.KeyPress,
        txtExtrathumbsHeight.KeyPress,
        txtExtrathumbsLimit.KeyPress,
        txtExtrathumbsWidth.KeyPress,
        txtFanartHeight.KeyPress,
        txtFanartWidth.KeyPress,
        txtLandscapeHeight.KeyPress,
        txtLandscapeWidth.KeyPress,
        txtPosterHeight.KeyPress,
        txtPosterWidth.KeyPress

        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

    Private Sub chkMovieImagesMediaLanguageOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkMovieImagesMediaLanguageOnly.CheckedChanged
        EnableApplyButton()

        chkMovieImagesGetBlankImages.Enabled = chkMovieImagesMediaLanguageOnly.Checked
        chkMovieImagesGetEnglishImages.Enabled = chkMovieImagesMediaLanguageOnly.Checked

        If Not chkMovieImagesMediaLanguageOnly.Checked Then
            chkMovieImagesGetBlankImages.Checked = False
            chkMovieImagesGetEnglishImages.Checked = False
        End If
    End Sub

    Private Sub chkMovieImagesForceLanguage_CheckedChanged(sender As Object, e As EventArgs) Handles chkMovieImagesForceLanguage.CheckedChanged
        EnableApplyButton()

        cbMovieImagesForcedLanguage.Enabled = chkMovieImagesForceLanguage.Checked
    End Sub
    ''' <summary>
    ''' Workaround to autosize the DGV based on column widths without change the row hights
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub pnlSettings_VisibleChanged(sender As Object, e As EventArgs) Handles pnlSettings.VisibleChanged
        If Not _bDGVWidthCalculated AndAlso CType(sender, Panel).Visible Then
            TableLayoutPanel1.SuspendLayout()
            For i As Integer = 0 To TableLayoutPanel1.Controls.Count - 1
                Dim nType As Type = TableLayoutPanel1.Controls(i).GetType
                If nType.Name = "DataGridView" Then
                    Dim nDataGridView As DataGridView = CType(TableLayoutPanel1.Controls(i), DataGridView)
                    Dim intWidth As Integer = 0
                    For Each nColumn As DataGridViewColumn In nDataGridView.Columns
                        intWidth += nColumn.Width
                    Next
                    nDataGridView.Width = intWidth + 1
                End If
            Next
            TableLayoutPanel1.ResumeLayout()
            _bDGVWidthCalculated = True
        End If
    End Sub

#End Region 'Methods

End Class