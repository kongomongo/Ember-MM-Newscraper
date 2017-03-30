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
Imports System.Windows.Forms

Public Class frmMovieSet_Image
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Movieset
    Dim _intImageIndex As Integer = 6
    Dim _intOrder As Integer = 400
    Dim _strName As String = "MovieSet_Image"
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
        With Master.eSettings.Movieset.ImageSettings
            cbBannerPrefSize.SelectedValue = .Banner.PrefSize
            cbClearArtPrefSize.SelectedValue = .ClearArt.PrefSize
            cbClearLogoPrefSize.SelectedValue = .ClearLogo.PrefSize
            cbDiscArtPrefSize.SelectedValue = .DiscArt.PrefSize
            cbFanartPrefSize.SelectedValue = .Fanart.PrefSize
            cbLandscapePrefSize.SelectedValue = .Landscape.PrefSize
            cbPosterPrefSize.SelectedValue = .Poster.PrefSize
            chkBannerKeepExisting.Checked = .Banner.KeepExisting
            chkBannerPrefSizeOnly.Checked = .Banner.PrefSizeOnly
            txtBannerHeight.Text = .Banner.MaxHeight.ToString
            txtBannerWidth.Text = .Banner.MaxWidth.ToString
            chkClearArtKeepExisting.Checked = .ClearArt.KeepExisting
            chkClearArtPrefSizeOnly.Checked = .ClearArt.PrefSizeOnly
            chkClearLogoKeepExisting.Checked = .ClearLogo.KeepExisting
            chkClearLogoPrefSizeOnly.Checked = .ClearLogo.PrefSizeOnly
            chkDiscArtKeepExisting.Checked = .DiscArt.KeepExisting
            chkDiscArtPrefSizeOnly.Checked = .DiscArt.PrefSizeOnly
            chkFanartKeepExisting.Checked = .Fanart.KeepExisting
            chkFanartPrefSizeOnly.Checked = .Fanart.PrefSizeOnly
            txtFanartHeight.Text = .Fanart.MaxHeight.ToString
            txtFanartWidth.Text = .Fanart.MaxWidth.ToString
            chkMovieSetImagesCacheEnabled.Checked = .CacheEnabled
            chkMovieSetImagesDisplayImageSelect.Checked = .DisplayImageSelectDialog
            chkMovieSetImagesForceLanguage.Checked = .Language.ForceLanguage
            If .Language.GetMediaLanguageOnly Then
                chkMovieSetImagesMediaLanguageOnly.Checked = True
                chkMovieSetImagesGetBlankImages.Checked = .Language.GetBlankImages
                chkMovieSetImagesGetEnglishImages.Checked = .Language.GetEnglishImages
            End If
            chkLandscapeKeepExisting.Checked = .Landscape.KeepExisting
            chkLandscapePrefSizeOnly.Checked = .Landscape.PrefSizeOnly
            chkPosterKeepExisting.Checked = .Poster.KeepExisting
            chkPosterPrefSizeOnly.Checked = .Poster.PrefSizeOnly
            txtPosterHeight.Text = .Poster.MaxHeight.ToString
            txtPosterWidth.Text = .Poster.MaxWidth.ToString

            Try
                cbMovieSetImagesForcedLanguage.Items.Clear()
                cbMovieSetImagesForcedLanguage.Items.AddRange((From lLang In APIXML.ScraperLanguagesXML.Languages Select lLang.Name).Distinct.ToArray)
                If cbMovieSetImagesForcedLanguage.Items.Count > 0 Then
                    If Not String.IsNullOrEmpty(.Language.ForcedLanguage) Then
                        Dim tLanguage As languageProperty = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = .Language.ForcedLanguage)
                        If tLanguage IsNot Nothing Then
                            cbMovieSetImagesForcedLanguage.Text = tLanguage.Name
                        Else
                            tLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation.StartsWith(.Language.ForcedLanguage))
                            If tLanguage IsNot Nothing Then
                                cbMovieSetImagesForcedLanguage.Text = tLanguage.Name
                            Else
                                cbMovieSetImagesForcedLanguage.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = "en").Name
                            End If
                        End If
                    Else
                        cbMovieSetImagesForcedLanguage.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = "en").Name
                    End If
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.Movieset.ImageSettings
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
            .Fanart.MaxHeight = If(Not String.IsNullOrEmpty(txtFanartHeight.Text), Convert.ToInt32(txtFanartHeight.Text), 0)
            .Fanart.KeepExisting = chkFanartKeepExisting.Checked
            .Fanart.PrefSize = CType(cbFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Fanart.PrefSizeOnly = chkFanartPrefSizeOnly.Checked
            .Fanart.MaxWidth = If(Not String.IsNullOrEmpty(txtFanartWidth.Text), Convert.ToInt32(txtFanartWidth.Text), 0)
            .CacheEnabled = chkMovieSetImagesCacheEnabled.Checked
            .DisplayImageSelectDialog = chkMovieSetImagesDisplayImageSelect.Checked
            If Not String.IsNullOrEmpty(cbMovieSetImagesForcedLanguage.Text) Then
                .Language.ForcedLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Name = cbMovieSetImagesForcedLanguage.Text).Abbrevation_MainLanguage
            End If
            .Language.ForceLanguage = chkMovieSetImagesForceLanguage.Checked
            .Language.GetBlankImages = chkMovieSetImagesGetBlankImages.Checked
            .Language.GetEnglishImages = chkMovieSetImagesGetEnglishImages.Checked
            .Language.GetMediaLanguageOnly = chkMovieSetImagesMediaLanguageOnly.Checked
            .Landscape.KeepExisting = chkLandscapeKeepExisting.Checked
            .Landscape.PrefSize = CType(cbLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Landscape.PrefSizeOnly = chkLandscapePrefSizeOnly.Checked
            .Poster.MaxHeight = If(Not String.IsNullOrEmpty(txtPosterHeight.Text), Convert.ToInt32(txtPosterHeight.Text), 0)
            .Poster.KeepExisting = chkPosterKeepExisting.Checked
            .Poster.PrefSizeOnly = chkPosterPrefSizeOnly.Checked
            .Poster.PrefSize = CType(cbPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Poster.MaxWidth = If(Not String.IsNullOrEmpty(txtPosterWidth.Text), Convert.ToInt32(txtPosterWidth.Text), 0)
        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub chkMovieSetImagesForceLanguage_CheckedChanged(sender As Object, e As EventArgs) Handles chkMovieSetImagesForceLanguage.CheckedChanged
        EnableApplyButton()

        cbMovieSetImagesForcedLanguage.Enabled = chkMovieSetImagesForceLanguage.Checked
    End Sub

    Private Sub chkMovieSetImagesMediaLanguageOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkMovieSetImagesMediaLanguageOnly.CheckedChanged
        EnableApplyButton()

        chkMovieSetImagesGetBlankImages.Enabled = chkMovieSetImagesMediaLanguageOnly.Checked
        chkMovieSetImagesGetEnglishImages.Enabled = chkMovieSetImagesMediaLanguageOnly.Checked

        If Not chkMovieSetImagesMediaLanguageOnly.Checked Then
            chkMovieSetImagesGetBlankImages.Checked = False
            chkMovieSetImagesGetEnglishImages.Checked = False
        End If
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub LoadBannerSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x185", Enums.ImageSize.HD185)
        cbBannerPrefSize.DataSource = items.ToList
        cbBannerPrefSize.DisplayMember = "Key"
        cbBannerPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadClearArtSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x562", Enums.ImageSize.HD562)
        items.Add("500x281", Enums.ImageSize.SD281)
        cbClearArtPrefSize.DataSource = items.ToList
        cbClearArtPrefSize.DisplayMember = "Key"
        cbClearArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadClearLogoSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("800x310", Enums.ImageSize.HD310)
        items.Add("400x155", Enums.ImageSize.SD155)
        cbClearLogoPrefSize.DataSource = items.ToList
        cbClearLogoPrefSize.DisplayMember = "Key"
        cbClearLogoPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadDiscArtSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x1000", Enums.ImageSize.HD1000)
        cbDiscArtPrefSize.DataSource = items.ToList
        cbDiscArtPrefSize.DisplayMember = "Key"
        cbDiscArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadFanartSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("3840x2160", Enums.ImageSize.UHD2160)
        items.Add("2560x1440", Enums.ImageSize.QHD1440)
        items.Add("1920x1080", Enums.ImageSize.HD1080)
        items.Add("1280x720", Enums.ImageSize.HD720)
        items.Add("Thumb", Enums.ImageSize.Thumb)
        cbFanartPrefSize.DataSource = items.ToList
        cbFanartPrefSize.DisplayMember = "Key"
        cbFanartPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadLandscapeSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x562", Enums.ImageSize.HD562)
        cbLandscapePrefSize.DataSource = items.ToList
        cbLandscapePrefSize.DisplayMember = "Key"
        cbLandscapePrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadPosterSizes()
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
        chkMovieSetImagesGetBlankImages.Text = Master.eLang.GetString(1207, "Also Get Blank Images")
        chkMovieSetImagesGetEnglishImages.Text = Master.eLang.GetString(737, "Also Get English Images")
        lblBanner.Text = Master.eLang.GetString(838, "Banner")
        lblClearArt.Text = Master.eLang.GetString(1096, "ClearArt")
        lblClearLogo.Text = Master.eLang.GetString(1097, "ClearLogo")
        lblDiscArt.Text = Master.eLang.GetString(1098, "DiscArt")
        chkMovieSetImagesDisplayImageSelect.Text = Master.eLang.GetString(499, "Display ""Image Select"" dialog while single scraping")
        chkMovieSetImagesCacheEnabled.Text = Master.eLang.GetString(249, "Enable Image Caching")
        lblFanart.Text = Master.eLang.GetString(149, "Fanart")
        chkMovieSetImagesForceLanguage.Text = Master.eLang.GetString(1034, "Force Language")
        gbMovieSetImagesOpts.Text = Master.eLang.GetString(497, "Images")
        lblLandscape.Text = Master.eLang.GetString(1059, "Landscape")
        chkMovieSetImagesMediaLanguageOnly.Text = Master.eLang.GetString(736, "Only Get Images for the Media Language")
        lblPoster.Text = Master.eLang.GetString(148, "Poster")
        gbMovieSetImagesLanguageOpts.Text = Master.eLang.GetString(741, "Preferred Language")

        lblKeepExisting.Text = Master.eLang.GetString(971, "Keep existing")
        lblHeight.Text = Master.eLang.GetString(480, "Max Height:")
        lblWidth.Text = Master.eLang.GetString(479, "Max Width:")
        lblOnly.Text = Master.eLang.GetString(145, "Only")
        lblPreferredSize.Text = Master.eLang.GetString(482, "Preferred Size")

        LoadBannerSizes()
        LoadClearArtSizes()
        LoadClearLogoSizes()
        LoadDiscArtSizes()
        LoadFanartSizes()
        LoadLandscapeSizes()
        LoadPosterSizes()

        clsAPITemp.ConvertToScraperGridView(dgvBanner, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Image_Banner)))
        clsAPITemp.ConvertToScraperGridView(dgvClearArt, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Image_ClearArt)))
        clsAPITemp.ConvertToScraperGridView(dgvClearLogo, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Image_ClearLogo)))
        clsAPITemp.ConvertToScraperGridView(dgvDiscArt, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Image_DiscArt)))
        clsAPITemp.ConvertToScraperGridView(dgvFanart, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvLandscape, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Image_Landscape)))
        clsAPITemp.ConvertToScraperGridView(dgvPoster, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Image_Poster)))
    End Sub

    Private Sub Handle_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _
            txtBannerHeight.KeyPress,
            txtBannerWidth.KeyPress,
            txtFanartHeight.KeyPress,
            txtFanartWidth.KeyPress,
            txtPosterHeight.KeyPress,
            txtPosterWidth.KeyPress
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
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