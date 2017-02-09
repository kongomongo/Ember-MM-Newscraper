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

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.MovieSet
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
        With Master.eSettings
            cbBannerPrefSize.SelectedValue = .MovieSetBannerPrefSize
            cbClearArtPrefSize.SelectedValue = .MovieSetClearArtPrefSize
            cbClearLogoPrefSize.SelectedValue = .MovieSetClearLogoPrefSize
            cbDiscArtPrefSize.SelectedValue = .MovieSetDiscArtPrefSize
            cbFanartPrefSize.SelectedValue = .MovieSetFanartPrefSize
            cbLandscapePrefSize.SelectedValue = .MovieSetLandscapePrefSize
            cbPosterPrefSize.SelectedValue = .MovieSetPosterPrefSize
            chkBannerKeepExisting.Checked = .MovieSetBannerKeepExisting
            chkBannerPrefSizeOnly.Checked = .MovieSetBannerPrefSizeOnly
            txtBannerHeight.Text = .MovieSetBannerHeight.ToString
            txtBannerWidth.Text = .MovieSetBannerWidth.ToString
            chkClearArtKeepExisting.Checked = .MovieSetClearArtKeepExisting
            chkClearArtPrefSizeOnly.Checked = .MovieSetClearArtPrefSizeOnly
            chkClearLogoKeepExisting.Checked = .MovieSetClearLogoKeepExisting
            chkClearLogoPrefSizeOnly.Checked = .MovieSetClearLogoPrefSizeOnly
            chkDiscArtKeepExisting.Checked = .MovieSetDiscArtKeepExisting
            chkDiscArtPrefSizeOnly.Checked = .MovieSetDiscArtPrefSizeOnly
            chkFanartKeepExisting.Checked = .MovieSetFanartKeepExisting
            chkFanartPrefSizeOnly.Checked = .MovieSetFanartPrefSizeOnly
            txtFanartHeight.Text = .MovieSetFanartHeight.ToString
            txtFanartWidth.Text = .MovieSetFanartWidth.ToString
            chkMovieSetImagesCacheEnabled.Checked = .MovieSetImagesCacheEnabled
            chkMovieSetImagesDisplayImageSelect.Checked = .MovieSetImagesDisplayImageSelect
            chkMovieSetImagesForceLanguage.Checked = .MovieSetImagesForceLanguage
            If .MovieSetImagesMediaLanguageOnly Then
                chkMovieSetImagesMediaLanguageOnly.Checked = True
                chkMovieSetImagesGetBlankImages.Checked = .MovieSetImagesGetBlankImages
                chkMovieSetImagesGetEnglishImages.Checked = .MovieSetImagesGetEnglishImages
            End If
            chkLandscapeKeepExisting.Checked = .MovieSetLandscapeKeepExisting
            chkLandscapePrefSizeOnly.Checked = .MovieSetLandscapePrefSizeOnly
            chkPosterKeepExisting.Checked = .MovieSetPosterKeepExisting
            chkPosterPrefSizeOnly.Checked = .MovieSetPosterPrefSizeOnly
            txtPosterHeight.Text = .MovieSetPosterHeight.ToString
            txtPosterWidth.Text = .MovieSetPosterWidth.ToString

            Try
                cbMovieSetImagesForcedLanguage.Items.Clear()
                cbMovieSetImagesForcedLanguage.Items.AddRange((From lLang In APIXML.ScraperLanguagesXML.Languages Select lLang.Name).Distinct.ToArray)
                If cbMovieSetImagesForcedLanguage.Items.Count > 0 Then
                    If Not String.IsNullOrEmpty(.MovieSetImagesForcedLanguage) Then
                        Dim tLanguage As languageProperty = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = .MovieSetImagesForcedLanguage)
                        If tLanguage IsNot Nothing Then
                            cbMovieSetImagesForcedLanguage.Text = tLanguage.Name
                        Else
                            tLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation.StartsWith(.MovieSetImagesForcedLanguage))
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
        With Master.eSettings
            .MovieSetBannerHeight = If(Not String.IsNullOrEmpty(txtBannerHeight.Text), Convert.ToInt32(txtBannerHeight.Text), 0)
            .MovieSetBannerKeepExisting = chkBannerKeepExisting.Checked
            .MovieSetBannerPrefSize = CType(cbBannerPrefSize.SelectedItem, KeyValuePair(Of String, Enums.MovieBannerSize)).Value
            .MovieSetBannerPrefSizeOnly = chkBannerPrefSizeOnly.Checked
            .MovieSetBannerWidth = If(Not String.IsNullOrEmpty(txtBannerWidth.Text), Convert.ToInt32(txtBannerWidth.Text), 0)
            .MovieSetClearArtKeepExisting = chkClearArtKeepExisting.Checked
            .MovieSetClearArtPrefSize = CType(cbClearArtPrefSize.SelectedItem, KeyValuePair(Of String, Enums.MovieClearArtSize)).Value
            .MovieSetClearArtPrefSizeOnly = chkClearArtPrefSizeOnly.Checked
            .MovieSetClearLogoKeepExisting = chkClearLogoKeepExisting.Checked
            .MovieSetClearLogoPrefSize = CType(cbClearLogoPrefSize.SelectedItem, KeyValuePair(Of String, Enums.MovieClearLogoSize)).Value
            .MovieSetClearLogoPrefSizeOnly = chkClearLogoPrefSizeOnly.Checked
            .MovieSetDiscArtKeepExisting = chkDiscArtKeepExisting.Checked
            .MovieSetDiscArtPrefSize = CType(cbDiscArtPrefSize.SelectedItem, KeyValuePair(Of String, Enums.MovieDiscArtSize)).Value
            .MovieSetDiscArtPrefSizeOnly = chkDiscArtPrefSizeOnly.Checked
            .MovieSetFanartHeight = If(Not String.IsNullOrEmpty(txtFanartHeight.Text), Convert.ToInt32(txtFanartHeight.Text), 0)
            .MovieSetFanartKeepExisting = chkFanartKeepExisting.Checked
            .MovieSetFanartPrefSize = CType(cbFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.MovieFanartSize)).Value
            .MovieSetFanartPrefSizeOnly = chkFanartPrefSizeOnly.Checked
            .MovieSetFanartWidth = If(Not String.IsNullOrEmpty(txtFanartWidth.Text), Convert.ToInt32(txtFanartWidth.Text), 0)
            .MovieSetImagesCacheEnabled = chkMovieSetImagesCacheEnabled.Checked
            .MovieSetImagesDisplayImageSelect = chkMovieSetImagesDisplayImageSelect.Checked
            If Not String.IsNullOrEmpty(cbMovieSetImagesForcedLanguage.Text) Then
                .MovieSetImagesForcedLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Name = cbMovieSetImagesForcedLanguage.Text).Abbrevation_MainLanguage
            End If
            .MovieSetImagesForceLanguage = chkMovieSetImagesForceLanguage.Checked
            .MovieSetImagesGetBlankImages = chkMovieSetImagesGetBlankImages.Checked
            .MovieSetImagesGetEnglishImages = chkMovieSetImagesGetEnglishImages.Checked
            .MovieSetImagesMediaLanguageOnly = chkMovieSetImagesMediaLanguageOnly.Checked
            .MovieSetLandscapeKeepExisting = chkLandscapeKeepExisting.Checked
            .MovieSetLandscapePrefSize = CType(cbLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.MovieLandscapeSize)).Value
            .MovieSetLandscapePrefSizeOnly = chkLandscapePrefSizeOnly.Checked
            .MovieSetPosterHeight = If(Not String.IsNullOrEmpty(txtPosterHeight.Text), Convert.ToInt32(txtPosterHeight.Text), 0)
            .MovieSetPosterKeepExisting = chkPosterKeepExisting.Checked
            .MovieSetPosterPrefSizeOnly = chkPosterPrefSizeOnly.Checked
            .MovieSetPosterPrefSize = CType(cbPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.MoviePosterSize)).Value
            .MovieSetPosterWidth = If(Not String.IsNullOrEmpty(txtPosterWidth.Text), Convert.ToInt32(txtPosterWidth.Text), 0)
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
        Dim items As New Dictionary(Of String, Enums.MovieBannerSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.MovieBannerSize.Any)
        items.Add("1000x185", Enums.MovieBannerSize.HD185)
        cbBannerPrefSize.DataSource = items.ToList
        cbBannerPrefSize.DisplayMember = "Key"
        cbBannerPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadClearArtSizes()
        Dim items As New Dictionary(Of String, Enums.MovieClearArtSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.MovieClearArtSize.Any)
        items.Add("1000x562", Enums.MovieClearArtSize.HD562)
        items.Add("500x281", Enums.MovieClearArtSize.SD281)
        cbClearArtPrefSize.DataSource = items.ToList
        cbClearArtPrefSize.DisplayMember = "Key"
        cbClearArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadClearLogoSizes()
        Dim items As New Dictionary(Of String, Enums.MovieClearLogoSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.MovieClearLogoSize.Any)
        items.Add("800x310", Enums.MovieClearLogoSize.HD310)
        items.Add("400x155", Enums.MovieClearLogoSize.SD155)
        cbClearLogoPrefSize.DataSource = items.ToList
        cbClearLogoPrefSize.DisplayMember = "Key"
        cbClearLogoPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadDiscArtSizes()
        Dim items As New Dictionary(Of String, Enums.MovieDiscArtSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.MovieDiscArtSize.Any)
        items.Add("1000x1000", Enums.MovieDiscArtSize.HD1000)
        cbDiscArtPrefSize.DataSource = items.ToList
        cbDiscArtPrefSize.DisplayMember = "Key"
        cbDiscArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadFanartSizes()
        Dim items As New Dictionary(Of String, Enums.MovieFanartSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.MovieFanartSize.Any)
        items.Add("3840x2160", Enums.MovieFanartSize.UHD2160)
        items.Add("2560x1440", Enums.MovieFanartSize.QHD1440)
        items.Add("1920x1080", Enums.MovieFanartSize.HD1080)
        items.Add("1280x720", Enums.MovieFanartSize.HD720)
        items.Add("Thumb", Enums.MovieFanartSize.Thumb)
        cbFanartPrefSize.DataSource = items.ToList
        cbFanartPrefSize.DisplayMember = "Key"
        cbFanartPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadLandscapeSizes()
        Dim items As New Dictionary(Of String, Enums.MovieLandscapeSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.MovieLandscapeSize.Any)
        items.Add("1000x562", Enums.MovieLandscapeSize.HD562)
        cbLandscapePrefSize.DataSource = items.ToList
        cbLandscapePrefSize.DisplayMember = "Key"
        cbLandscapePrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadPosterSizes()
        Dim items As New Dictionary(Of String, Enums.MoviePosterSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.MoviePosterSize.Any)
        items.Add("2000x3000", Enums.MoviePosterSize.HD3000)
        items.Add("1400x2100", Enums.MoviePosterSize.HD2100)
        items.Add("1000x1500", Enums.MoviePosterSize.HD1500)
        items.Add("1000x1426", Enums.MoviePosterSize.HD1426)
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

        clsAPITemp.ConvertToScraperGridView(dgvBanner, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.MovieSet_Image_Banner)))
        clsAPITemp.ConvertToScraperGridView(dgvClearArt, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.MovieSet_Image_ClearArt)))
        clsAPITemp.ConvertToScraperGridView(dgvClearLogo, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.MovieSet_Image_ClearLogo)))
        clsAPITemp.ConvertToScraperGridView(dgvDiscArt, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.MovieSet_Image_DiscArt)))
        clsAPITemp.ConvertToScraperGridView(dgvFanart, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.MovieSet_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvLandscape, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.MovieSet_Image_Landscape)))
        clsAPITemp.ConvertToScraperGridView(dgvPoster, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.MovieSet_Image_Poster)))
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