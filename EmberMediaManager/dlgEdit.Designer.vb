<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEdit))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Local Subtitles", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("1")
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblTopDetails = New System.Windows.Forms.Label()
        Me.lblTopTitle = New System.Windows.Forms.Label()
        Me.pbTopLogo = New System.Windows.Forms.PictureBox()
        Me.tcEdit = New System.Windows.Forms.TabControl()
        Me.tpDetails = New System.Windows.Forms.TabPage()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.tblDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDetailsColumn1 = New System.Windows.Forms.Panel()
        Me.tblDetailsColumn1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblDetailsMain = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPlay_Trailer = New System.Windows.Forms.Button()
        Me.txtTrailer = New System.Windows.Forms.TextBox()
        Me.lblTrailerURL = New System.Windows.Forms.Label()
        Me.txtVideoSource = New System.Windows.Forms.TextBox()
        Me.lblVideoSource = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblRating = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.lblOriginalTitle = New System.Windows.Forms.Label()
        Me.txtRating = New System.Windows.Forms.TextBox()
        Me.txtOriginalTitle = New System.Windows.Forms.TextBox()
        Me.lblSortTilte = New System.Windows.Forms.Label()
        Me.txtSortTitle = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblSeason = New System.Windows.Forms.Label()
        Me.txtSeason = New System.Windows.Forms.TextBox()
        Me.lblEpisode = New System.Windows.Forms.Label()
        Me.txtEpisode = New System.Windows.Forms.TextBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblReleaseDate = New System.Windows.Forms.Label()
        Me.btnAdd_Trailer = New System.Windows.Forms.Button()
        Me.lblTVDB = New System.Windows.Forms.Label()
        Me.txtTVDB = New System.Windows.Forms.TextBox()
        Me.txtTMDBCollection = New System.Windows.Forms.TextBox()
        Me.lblTMDBCollection = New System.Windows.Forms.Label()
        Me.lblTMDB = New System.Windows.Forms.Label()
        Me.txtTMDB = New System.Windows.Forms.TextBox()
        Me.txtIMDB = New System.Windows.Forms.TextBox()
        Me.lblIMDB = New System.Windows.Forms.Label()
        Me.lblVotes = New System.Windows.Forms.Label()
        Me.txtVotes = New System.Windows.Forms.TextBox()
        Me.lblUserRating = New System.Windows.Forms.Label()
        Me.cbUserRating = New System.Windows.Forms.ComboBox()
        Me.lblTop250 = New System.Windows.Forms.Label()
        Me.lblRuntime = New System.Windows.Forms.Label()
        Me.txtRuntime = New System.Windows.Forms.TextBox()
        Me.txtReleaseDate = New System.Windows.Forms.MaskedTextBox()
        Me.txtYear = New System.Windows.Forms.MaskedTextBox()
        Me.txtTop250 = New System.Windows.Forms.MaskedTextBox()
        Me.tblDetailsMPAA = New System.Windows.Forms.TableLayoutPanel()
        Me.lbMPAA = New System.Windows.Forms.ListBox()
        Me.lblMPAARating = New System.Windows.Forms.Label()
        Me.lblMPAADescription = New System.Windows.Forms.Label()
        Me.txtMPAADesc = New System.Windows.Forms.TextBox()
        Me.txtMPAA = New System.Windows.Forms.TextBox()
        Me.lblCertifications = New System.Windows.Forms.Label()
        Me.lbCertifications = New System.Windows.Forms.ListBox()
        Me.lblMPAA = New System.Windows.Forms.Label()
        Me.lblMPAAPreview = New System.Windows.Forms.Label()
        Me.pnlDetailsColumn2 = New System.Windows.Forms.Panel()
        Me.tblDetailsColumn2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblDetailsInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTagline = New System.Windows.Forms.Label()
        Me.txtTagline = New System.Windows.Forms.TextBox()
        Me.lblPlot = New System.Windows.Forms.Label()
        Me.txtPlot = New System.Windows.Forms.TextBox()
        Me.lblOutline = New System.Windows.Forms.Label()
        Me.txtOutline = New System.Windows.Forms.TextBox()
        Me.tblDetailsGenresTagsShowlink = New System.Windows.Forms.TableLayoutPanel()
        Me.lblGenres = New System.Windows.Forms.Label()
        Me.clbTVShowLinks = New System.Windows.Forms.CheckedListBox()
        Me.clbGenres = New System.Windows.Forms.CheckedListBox()
        Me.lblTags = New System.Windows.Forms.Label()
        Me.lblTVShowLinks = New System.Windows.Forms.Label()
        Me.clbTags = New System.Windows.Forms.CheckedListBox()
        Me.btnAdd_Genre = New System.Windows.Forms.Button()
        Me.btnAdd_Tag = New System.Windows.Forms.Button()
        Me.tblDetailsCollection = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCollection = New System.Windows.Forms.Label()
        Me.cbCollection = New System.Windows.Forms.ComboBox()
        Me.btnAdd_Collection = New System.Windows.Forms.Button()
        Me.pnlDetailsColumn3 = New System.Windows.Forms.Panel()
        Me.tblDetailsColumn3 = New System.Windows.Forms.TableLayoutPanel()
        Me.tcCrew = New System.Windows.Forms.TabControl()
        Me.tpActors = New System.Windows.Forms.TabPage()
        Me.tblActors = New System.Windows.Forms.TableLayoutPanel()
        Me.lvActors = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRole = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colThumb = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAdd_Actor = New System.Windows.Forms.Button()
        Me.btnEdit_Actor = New System.Windows.Forms.Button()
        Me.btnUp_Actor = New System.Windows.Forms.Button()
        Me.btnDown_Actor = New System.Windows.Forms.Button()
        Me.btnRemove_Actor = New System.Windows.Forms.Button()
        Me.tpSpecialGuests = New System.Windows.Forms.TabPage()
        Me.tblSpecialGuests = New System.Windows.Forms.TableLayoutPanel()
        Me.lvSpecialGuests = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAdd_SpecialGuest = New System.Windows.Forms.Button()
        Me.btnEdit_SpecialGuest = New System.Windows.Forms.Button()
        Me.btnUp_SpecialGuest = New System.Windows.Forms.Button()
        Me.btnDown_SpecialGuest = New System.Windows.Forms.Button()
        Me.btnRemove_SpecialGuest = New System.Windows.Forms.Button()
        Me.tblDetailsCrew = New System.Windows.Forms.TableLayoutPanel()
        Me.lbDirectors = New System.Windows.Forms.ListBox()
        Me.lbCreditsCreators = New System.Windows.Forms.ListBox()
        Me.lblDirectors = New System.Windows.Forms.Label()
        Me.lblCreditsCreators = New System.Windows.Forms.Label()
        Me.lblCountries = New System.Windows.Forms.Label()
        Me.lbCountries = New System.Windows.Forms.ListBox()
        Me.lblStudio = New System.Windows.Forms.Label()
        Me.lbStudios = New System.Windows.Forms.ListBox()
        Me.tpMovies = New System.Windows.Forms.TabPage()
        Me.pnlMovies = New System.Windows.Forms.Panel()
        Me.tblMovies = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSearchMovie = New System.Windows.Forms.Button()
        Me.txtSearchMovies = New System.Windows.Forms.TextBox()
        Me.btnMovieRemove = New System.Windows.Forms.Button()
        Me.btnMovieDown = New System.Windows.Forms.Button()
        Me.btnMovieUp = New System.Windows.Forms.Button()
        Me.dgvMovies = New System.Windows.Forms.DataGridView()
        Me.btnMovieAdd = New System.Windows.Forms.Button()
        Me.lvMoviesInSet = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colOrdering = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblMoviesInDB = New System.Windows.Forms.Label()
        Me.lblMoviesInMovieset = New System.Windows.Forms.Label()
        Me.tpPoster = New System.Windows.Forms.TabPage()
        Me.btnSetPosterDL = New System.Windows.Forms.Button()
        Me.btnRemovePoster = New System.Windows.Forms.Button()
        Me.lblPosterSize = New System.Windows.Forms.Label()
        Me.btnSetPosterScrape = New System.Windows.Forms.Button()
        Me.btnSetPosterLocal = New System.Windows.Forms.Button()
        Me.pbPoster = New System.Windows.Forms.PictureBox()
        Me.tpBanner = New System.Windows.Forms.TabPage()
        Me.btnSetBannerDL = New System.Windows.Forms.Button()
        Me.btnRemoveBanner = New System.Windows.Forms.Button()
        Me.lblBannerSize = New System.Windows.Forms.Label()
        Me.btnSetBannerScrape = New System.Windows.Forms.Button()
        Me.btnSetBannerLocal = New System.Windows.Forms.Button()
        Me.pbBanner = New System.Windows.Forms.PictureBox()
        Me.tpLandscape = New System.Windows.Forms.TabPage()
        Me.btnSetLandscapeDL = New System.Windows.Forms.Button()
        Me.btnRemoveLandscape = New System.Windows.Forms.Button()
        Me.lblLandscapeSize = New System.Windows.Forms.Label()
        Me.btnSetLandscapeScrape = New System.Windows.Forms.Button()
        Me.btnSetLandscapeLocal = New System.Windows.Forms.Button()
        Me.pbLandscape = New System.Windows.Forms.PictureBox()
        Me.tpClearArt = New System.Windows.Forms.TabPage()
        Me.btnSetClearArtDL = New System.Windows.Forms.Button()
        Me.btnRemoveClearArt = New System.Windows.Forms.Button()
        Me.lblClearArtSize = New System.Windows.Forms.Label()
        Me.btnSetClearArtScrape = New System.Windows.Forms.Button()
        Me.btnSetClearArtLocal = New System.Windows.Forms.Button()
        Me.pbClearArt = New System.Windows.Forms.PictureBox()
        Me.tpClearLogo = New System.Windows.Forms.TabPage()
        Me.btnSetClearLogoDL = New System.Windows.Forms.Button()
        Me.btnRemoveClearLogo = New System.Windows.Forms.Button()
        Me.lblClearLogoSize = New System.Windows.Forms.Label()
        Me.btnSetClearLogoScrape = New System.Windows.Forms.Button()
        Me.btnSetClearLogoLocal = New System.Windows.Forms.Button()
        Me.pbClearLogo = New System.Windows.Forms.PictureBox()
        Me.tpDiscArt = New System.Windows.Forms.TabPage()
        Me.btnSetDiscArtDL = New System.Windows.Forms.Button()
        Me.btnRemoveDiscArt = New System.Windows.Forms.Button()
        Me.lblDiscArtSize = New System.Windows.Forms.Label()
        Me.btnSetDiscArtScrape = New System.Windows.Forms.Button()
        Me.btnSetDiscArtLocal = New System.Windows.Forms.Button()
        Me.pbDiscArt = New System.Windows.Forms.PictureBox()
        Me.tpFanart = New System.Windows.Forms.TabPage()
        Me.btnSetFanartDL = New System.Windows.Forms.Button()
        Me.btnRemoveFanart = New System.Windows.Forms.Button()
        Me.lblFanartSize = New System.Windows.Forms.Label()
        Me.btnSetFanartScrape = New System.Windows.Forms.Button()
        Me.btnSetFanartLocal = New System.Windows.Forms.Button()
        Me.pbFanart = New System.Windows.Forms.PictureBox()
        Me.tpExtrafanarts = New System.Windows.Forms.TabPage()
        Me.btnSetExtrafanartsScrape = New System.Windows.Forms.Button()
        Me.lblExtrafanartsSize = New System.Windows.Forms.Label()
        Me.pnlExtrafanarts = New System.Windows.Forms.Panel()
        Me.pnlExtrafanartsSetAsFanart = New System.Windows.Forms.Panel()
        Me.btnExtrafanartsSetAsFanart = New System.Windows.Forms.Button()
        Me.btnExtrafanartsRefresh = New System.Windows.Forms.Button()
        Me.btnExtrafanartsRemove = New System.Windows.Forms.Button()
        Me.pbExtrafanarts = New System.Windows.Forms.PictureBox()
        Me.tpExtrathumbs = New System.Windows.Forms.TabPage()
        Me.btnSetExtrathumbsScrape = New System.Windows.Forms.Button()
        Me.lblExtrathumbsSize = New System.Windows.Forms.Label()
        Me.pnlExtrathumbs = New System.Windows.Forms.Panel()
        Me.pnlExtrathumbsSetAsFanart = New System.Windows.Forms.Panel()
        Me.btnExtrathumbsSetAsFanart = New System.Windows.Forms.Button()
        Me.btnExtrathumbsRefresh = New System.Windows.Forms.Button()
        Me.btnExtrathumbsRemove = New System.Windows.Forms.Button()
        Me.btnExtrathumbsDown = New System.Windows.Forms.Button()
        Me.btnExtrathumbsUp = New System.Windows.Forms.Button()
        Me.pbExtrathumbs = New System.Windows.Forms.PictureBox()
        Me.tpFrameExtraction = New System.Windows.Forms.TabPage()
        Me.pnlFrameExtrator = New System.Windows.Forms.Panel()
        Me.tpSubtitles = New System.Windows.Forms.TabPage()
        Me.lblSubtitlesPreview = New System.Windows.Forms.Label()
        Me.txtSubtitlesPreview = New System.Windows.Forms.TextBox()
        Me.lvSubtitles = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRemoveSubtitle = New System.Windows.Forms.Button()
        Me.btnSetSubtitleDL = New System.Windows.Forms.Button()
        Me.btnSetSubtitleScrape = New System.Windows.Forms.Button()
        Me.btnSetSubtitleLocal = New System.Windows.Forms.Button()
        Me.tpTrailer = New System.Windows.Forms.TabPage()
        Me.btnLocalTrailerPlay = New System.Windows.Forms.Button()
        Me.txtLocalTrailer = New System.Windows.Forms.TextBox()
        Me.pnlTrailerPreview = New System.Windows.Forms.Panel()
        Me.pnlTrailerPreviewNoPlayer = New System.Windows.Forms.Panel()
        Me.tblTrailerPreviewNoPlayer = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTrailerPreviewNoPlayer = New System.Windows.Forms.Label()
        Me.btnSetTrailerDL = New System.Windows.Forms.Button()
        Me.btnRemoveTrailer = New System.Windows.Forms.Button()
        Me.btnSetTrailerScrape = New System.Windows.Forms.Button()
        Me.btnSetTrailerLocal = New System.Windows.Forms.Button()
        Me.tpTheme = New System.Windows.Forms.TabPage()
        Me.btnLocalThemePlay = New System.Windows.Forms.Button()
        Me.txtLocalTheme = New System.Windows.Forms.TextBox()
        Me.pnlThemePreview = New System.Windows.Forms.Panel()
        Me.pnlThemePreviewNoPlayer = New System.Windows.Forms.Panel()
        Me.tblThemePreviewNoPlayer = New System.Windows.Forms.TableLayoutPanel()
        Me.lblThemePreviewNoPlayer = New System.Windows.Forms.Label()
        Me.btnSetThemeDL = New System.Windows.Forms.Button()
        Me.btnRemoveTheme = New System.Windows.Forms.Button()
        Me.btnSetThemeScrape = New System.Windows.Forms.Button()
        Me.btnSetThemeLocal = New System.Windows.Forms.Button()
        Me.tpMetaData = New System.Windows.Forms.TabPage()
        Me.pnlFileInfo = New System.Windows.Forms.Panel()
        Me.tpMediaStub = New System.Windows.Forms.TabPage()
        Me.lblMediaStubMessage = New System.Windows.Forms.Label()
        Me.lblMediaStubTitle = New System.Windows.Forms.Label()
        Me.txtMediaStubMessage = New System.Windows.Forms.TextBox()
        Me.txtMediaStubTitle = New System.Windows.Forms.TextBox()
        Me.ofdLocalFiles = New System.Windows.Forms.OpenFileDialog()
        Me.chkMarked = New System.Windows.Forms.CheckBox()
        Me.btnRescrape = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.tmrDelay = New System.Windows.Forms.Timer(Me.components)
        Me.chkWatched = New System.Windows.Forms.CheckBox()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsFilename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtLastPlayed = New System.Windows.Forms.TextBox()
        Me.cbLanguage = New System.Windows.Forms.ComboBox()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.pnlEdit = New System.Windows.Forms.Panel()
        Me.pnlEditMain = New System.Windows.Forms.Panel()
        Me.pnlEditTop = New System.Windows.Forms.Panel()
        Me.tblEditTop = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlEditBottom = New System.Windows.Forms.Panel()
        Me.tblEditBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.cbEpisodeSorting = New System.Windows.Forms.ComboBox()
        Me.lblEpisodeSorting = New System.Windows.Forms.Label()
        Me.cbOrdering = New System.Windows.Forms.ComboBox()
        Me.lblOrdering = New System.Windows.Forms.Label()
        Me.chkLocked = New System.Windows.Forms.CheckBox()
        CType(Me.pbTopLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcEdit.SuspendLayout()
        Me.tpDetails.SuspendLayout()
        Me.pnlDetails.SuspendLayout()
        Me.tblDetails.SuspendLayout()
        Me.pnlDetailsColumn1.SuspendLayout()
        Me.tblDetailsColumn1.SuspendLayout()
        Me.tblDetailsMain.SuspendLayout()
        Me.tblDetailsMPAA.SuspendLayout()
        Me.pnlDetailsColumn2.SuspendLayout()
        Me.tblDetailsColumn2.SuspendLayout()
        Me.tblDetailsInfo.SuspendLayout()
        Me.tblDetailsGenresTagsShowlink.SuspendLayout()
        Me.tblDetailsCollection.SuspendLayout()
        Me.pnlDetailsColumn3.SuspendLayout()
        Me.tblDetailsColumn3.SuspendLayout()
        Me.tcCrew.SuspendLayout()
        Me.tpActors.SuspendLayout()
        Me.tblActors.SuspendLayout()
        Me.tpSpecialGuests.SuspendLayout()
        Me.tblSpecialGuests.SuspendLayout()
        Me.tblDetailsCrew.SuspendLayout()
        Me.tpMovies.SuspendLayout()
        Me.pnlMovies.SuspendLayout()
        Me.tblMovies.SuspendLayout()
        CType(Me.dgvMovies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPoster.SuspendLayout()
        CType(Me.pbPoster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpBanner.SuspendLayout()
        CType(Me.pbBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpLandscape.SuspendLayout()
        CType(Me.pbLandscape, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpClearArt.SuspendLayout()
        CType(Me.pbClearArt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpClearLogo.SuspendLayout()
        CType(Me.pbClearLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDiscArt.SuspendLayout()
        CType(Me.pbDiscArt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpFanart.SuspendLayout()
        CType(Me.pbFanart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpExtrafanarts.SuspendLayout()
        Me.pnlExtrafanartsSetAsFanart.SuspendLayout()
        CType(Me.pbExtrafanarts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpExtrathumbs.SuspendLayout()
        Me.pnlExtrathumbsSetAsFanart.SuspendLayout()
        CType(Me.pbExtrathumbs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpFrameExtraction.SuspendLayout()
        Me.tpSubtitles.SuspendLayout()
        Me.tpTrailer.SuspendLayout()
        Me.pnlTrailerPreview.SuspendLayout()
        Me.pnlTrailerPreviewNoPlayer.SuspendLayout()
        Me.tblTrailerPreviewNoPlayer.SuspendLayout()
        Me.tpTheme.SuspendLayout()
        Me.pnlThemePreview.SuspendLayout()
        Me.pnlThemePreviewNoPlayer.SuspendLayout()
        Me.tblThemePreviewNoPlayer.SuspendLayout()
        Me.tpMetaData.SuspendLayout()
        Me.tpMediaStub.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.pnlEdit.SuspendLayout()
        Me.pnlEditMain.SuspendLayout()
        Me.pnlEditTop.SuspendLayout()
        Me.tblEditTop.SuspendLayout()
        Me.pnlEditBottom.SuspendLayout()
        Me.tblEditBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.AutoSize = True
        Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOK.Location = New System.Drawing.Point(974, 30)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1081, 30)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'lblTopDetails
        '
        Me.lblTopDetails.AutoSize = True
        Me.lblTopDetails.BackColor = System.Drawing.Color.Transparent
        Me.lblTopDetails.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTopDetails.ForeColor = System.Drawing.Color.White
        Me.lblTopDetails.Location = New System.Drawing.Point(57, 32)
        Me.lblTopDetails.Name = "lblTopDetails"
        Me.lblTopDetails.Size = New System.Drawing.Size(205, 13)
        Me.lblTopDetails.TabIndex = 1
        Me.lblTopDetails.Text = "Edit the details for the selected movie."
        '
        'lblTopTitle
        '
        Me.lblTopTitle.AutoSize = True
        Me.lblTopTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTopTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTopTitle.ForeColor = System.Drawing.Color.White
        Me.lblTopTitle.Location = New System.Drawing.Point(57, 0)
        Me.lblTopTitle.Name = "lblTopTitle"
        Me.lblTopTitle.Size = New System.Drawing.Size(137, 32)
        Me.lblTopTitle.TabIndex = 0
        Me.lblTopTitle.Text = "Edit Movie"
        '
        'pbTopLogo
        '
        Me.pbTopLogo.BackColor = System.Drawing.Color.Transparent
        Me.pbTopLogo.Image = CType(resources.GetObject("pbTopLogo.Image"), System.Drawing.Image)
        Me.pbTopLogo.Location = New System.Drawing.Point(3, 3)
        Me.pbTopLogo.Name = "pbTopLogo"
        Me.tblEditTop.SetRowSpan(Me.pbTopLogo, 2)
        Me.pbTopLogo.Size = New System.Drawing.Size(48, 48)
        Me.pbTopLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbTopLogo.TabIndex = 0
        Me.pbTopLogo.TabStop = False
        '
        'tcEdit
        '
        Me.tcEdit.Controls.Add(Me.tpDetails)
        Me.tcEdit.Controls.Add(Me.tpMovies)
        Me.tcEdit.Controls.Add(Me.tpPoster)
        Me.tcEdit.Controls.Add(Me.tpBanner)
        Me.tcEdit.Controls.Add(Me.tpLandscape)
        Me.tcEdit.Controls.Add(Me.tpClearArt)
        Me.tcEdit.Controls.Add(Me.tpClearLogo)
        Me.tcEdit.Controls.Add(Me.tpDiscArt)
        Me.tcEdit.Controls.Add(Me.tpFanart)
        Me.tcEdit.Controls.Add(Me.tpExtrafanarts)
        Me.tcEdit.Controls.Add(Me.tpExtrathumbs)
        Me.tcEdit.Controls.Add(Me.tpFrameExtraction)
        Me.tcEdit.Controls.Add(Me.tpSubtitles)
        Me.tcEdit.Controls.Add(Me.tpTrailer)
        Me.tcEdit.Controls.Add(Me.tpTheme)
        Me.tcEdit.Controls.Add(Me.tpMetaData)
        Me.tcEdit.Controls.Add(Me.tpMediaStub)
        Me.tcEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcEdit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tcEdit.Location = New System.Drawing.Point(0, 0)
        Me.tcEdit.Name = "tcEdit"
        Me.tcEdit.SelectedIndex = 0
        Me.tcEdit.Size = New System.Drawing.Size(1184, 552)
        Me.tcEdit.TabIndex = 3
        '
        'tpDetails
        '
        Me.tpDetails.Controls.Add(Me.pnlDetails)
        Me.tpDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpDetails.Name = "tpDetails"
        Me.tpDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDetails.Size = New System.Drawing.Size(1176, 526)
        Me.tpDetails.TabIndex = 0
        Me.tpDetails.Text = "Details"
        Me.tpDetails.UseVisualStyleBackColor = True
        '
        'pnlDetails
        '
        Me.pnlDetails.AutoSize = True
        Me.pnlDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDetails.Controls.Add(Me.tblDetails)
        Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetails.Location = New System.Drawing.Point(3, 3)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(1170, 520)
        Me.pnlDetails.TabIndex = 85
        '
        'tblDetails
        '
        Me.tblDetails.AutoSize = True
        Me.tblDetails.ColumnCount = 3
        Me.tblDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDetails.Controls.Add(Me.pnlDetailsColumn1, 0, 0)
        Me.tblDetails.Controls.Add(Me.pnlDetailsColumn2, 1, 0)
        Me.tblDetails.Controls.Add(Me.pnlDetailsColumn3, 2, 0)
        Me.tblDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetails.Location = New System.Drawing.Point(0, 0)
        Me.tblDetails.Name = "tblDetails"
        Me.tblDetails.RowCount = 1
        Me.tblDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetails.Size = New System.Drawing.Size(1170, 520)
        Me.tblDetails.TabIndex = 1
        '
        'pnlDetailsColumn1
        '
        Me.pnlDetailsColumn1.AutoSize = True
        Me.pnlDetailsColumn1.Controls.Add(Me.tblDetailsColumn1)
        Me.pnlDetailsColumn1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetailsColumn1.Location = New System.Drawing.Point(3, 3)
        Me.pnlDetailsColumn1.Name = "pnlDetailsColumn1"
        Me.pnlDetailsColumn1.Size = New System.Drawing.Size(393, 514)
        Me.pnlDetailsColumn1.TabIndex = 2
        '
        'tblDetailsColumn1
        '
        Me.tblDetailsColumn1.AutoSize = True
        Me.tblDetailsColumn1.ColumnCount = 1
        Me.tblDetailsColumn1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsColumn1.Controls.Add(Me.tblDetailsMain, 0, 0)
        Me.tblDetailsColumn1.Controls.Add(Me.tblDetailsMPAA, 0, 1)
        Me.tblDetailsColumn1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsColumn1.Location = New System.Drawing.Point(0, 0)
        Me.tblDetailsColumn1.Name = "tblDetailsColumn1"
        Me.tblDetailsColumn1.RowCount = 3
        Me.tblDetailsColumn1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn1.Size = New System.Drawing.Size(393, 514)
        Me.tblDetailsColumn1.TabIndex = 0
        '
        'tblDetailsMain
        '
        Me.tblDetailsMain.AutoSize = True
        Me.tblDetailsMain.ColumnCount = 5
        Me.tblDetailsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDetailsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsMain.Controls.Add(Me.btnPlay_Trailer, 4, 12)
        Me.tblDetailsMain.Controls.Add(Me.txtTrailer, 1, 12)
        Me.tblDetailsMain.Controls.Add(Me.lblTrailerURL, 0, 12)
        Me.tblDetailsMain.Controls.Add(Me.txtVideoSource, 1, 11)
        Me.tblDetailsMain.Controls.Add(Me.lblVideoSource, 0, 11)
        Me.tblDetailsMain.Controls.Add(Me.lblTitle, 0, 0)
        Me.tblDetailsMain.Controls.Add(Me.lblRating, 0, 6)
        Me.tblDetailsMain.Controls.Add(Me.txtTitle, 1, 0)
        Me.tblDetailsMain.Controls.Add(Me.lblOriginalTitle, 0, 1)
        Me.tblDetailsMain.Controls.Add(Me.txtRating, 1, 6)
        Me.tblDetailsMain.Controls.Add(Me.txtOriginalTitle, 1, 1)
        Me.tblDetailsMain.Controls.Add(Me.lblSortTilte, 0, 2)
        Me.tblDetailsMain.Controls.Add(Me.txtSortTitle, 1, 2)
        Me.tblDetailsMain.Controls.Add(Me.lblStatus, 0, 5)
        Me.tblDetailsMain.Controls.Add(Me.txtStatus, 1, 5)
        Me.tblDetailsMain.Controls.Add(Me.lblSeason, 0, 3)
        Me.tblDetailsMain.Controls.Add(Me.txtSeason, 1, 3)
        Me.tblDetailsMain.Controls.Add(Me.lblEpisode, 2, 3)
        Me.tblDetailsMain.Controls.Add(Me.txtEpisode, 3, 3)
        Me.tblDetailsMain.Controls.Add(Me.lblYear, 2, 4)
        Me.tblDetailsMain.Controls.Add(Me.lblReleaseDate, 0, 4)
        Me.tblDetailsMain.Controls.Add(Me.btnAdd_Trailer, 3, 12)
        Me.tblDetailsMain.Controls.Add(Me.lblTVDB, 2, 10)
        Me.tblDetailsMain.Controls.Add(Me.txtTVDB, 3, 10)
        Me.tblDetailsMain.Controls.Add(Me.txtTMDBCollection, 3, 9)
        Me.tblDetailsMain.Controls.Add(Me.lblTMDBCollection, 2, 9)
        Me.tblDetailsMain.Controls.Add(Me.lblTMDB, 2, 8)
        Me.tblDetailsMain.Controls.Add(Me.txtTMDB, 3, 8)
        Me.tblDetailsMain.Controls.Add(Me.txtIMDB, 3, 7)
        Me.tblDetailsMain.Controls.Add(Me.lblIMDB, 2, 7)
        Me.tblDetailsMain.Controls.Add(Me.lblVotes, 2, 6)
        Me.tblDetailsMain.Controls.Add(Me.txtVotes, 3, 6)
        Me.tblDetailsMain.Controls.Add(Me.lblUserRating, 0, 7)
        Me.tblDetailsMain.Controls.Add(Me.cbUserRating, 1, 7)
        Me.tblDetailsMain.Controls.Add(Me.lblTop250, 0, 8)
        Me.tblDetailsMain.Controls.Add(Me.lblRuntime, 0, 9)
        Me.tblDetailsMain.Controls.Add(Me.txtRuntime, 1, 9)
        Me.tblDetailsMain.Controls.Add(Me.txtReleaseDate, 1, 4)
        Me.tblDetailsMain.Controls.Add(Me.txtYear, 3, 4)
        Me.tblDetailsMain.Controls.Add(Me.txtTop250, 1, 8)
        Me.tblDetailsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsMain.Location = New System.Drawing.Point(3, 3)
        Me.tblDetailsMain.Name = "tblDetailsMain"
        Me.tblDetailsMain.RowCount = 13
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblDetailsMain.Size = New System.Drawing.Size(387, 365)
        Me.tblDetailsMain.TabIndex = 75
        '
        'btnPlay_Trailer
        '
        Me.btnPlay_Trailer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlay_Trailer.Image = Global.Ember_Media_Manager.My.Resources.Resources.Play_Icon
        Me.btnPlay_Trailer.Location = New System.Drawing.Point(361, 339)
        Me.btnPlay_Trailer.Name = "btnPlay_Trailer"
        Me.btnPlay_Trailer.Size = New System.Drawing.Size(23, 23)
        Me.btnPlay_Trailer.TabIndex = 21
        Me.btnPlay_Trailer.UseVisualStyleBackColor = True
        '
        'txtTrailer
        '
        Me.txtTrailer.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtTrailer, 2)
        Me.txtTrailer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtTrailer.Location = New System.Drawing.Point(87, 339)
        Me.txtTrailer.Name = "txtTrailer"
        Me.txtTrailer.Size = New System.Drawing.Size(221, 22)
        Me.txtTrailer.TabIndex = 19
        '
        'lblTrailerURL
        '
        Me.lblTrailerURL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTrailerURL.AutoSize = True
        Me.lblTrailerURL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTrailerURL.Location = New System.Drawing.Point(3, 344)
        Me.lblTrailerURL.Name = "lblTrailerURL"
        Me.lblTrailerURL.Size = New System.Drawing.Size(65, 13)
        Me.lblTrailerURL.TabIndex = 49
        Me.lblTrailerURL.Text = "Trailer URL:"
        '
        'txtVideoSource
        '
        Me.txtVideoSource.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtVideoSource, 4)
        Me.txtVideoSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVideoSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtVideoSource.Location = New System.Drawing.Point(87, 311)
        Me.txtVideoSource.Name = "txtVideoSource"
        Me.txtVideoSource.Size = New System.Drawing.Size(297, 22)
        Me.txtVideoSource.TabIndex = 18
        '
        'lblVideoSource
        '
        Me.lblVideoSource.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblVideoSource.AutoSize = True
        Me.lblVideoSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblVideoSource.Location = New System.Drawing.Point(3, 315)
        Me.lblVideoSource.Name = "lblVideoSource"
        Me.lblVideoSource.Size = New System.Drawing.Size(78, 13)
        Me.lblVideoSource.TabIndex = 47
        Me.lblVideoSource.Text = "Video Source:"
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(3, 7)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(32, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title:"
        '
        'lblRating
        '
        Me.lblRating.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating.AutoSize = True
        Me.lblRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblRating.Location = New System.Drawing.Point(3, 175)
        Me.lblRating.Name = "lblRating"
        Me.lblRating.Size = New System.Drawing.Size(44, 13)
        Me.lblRating.TabIndex = 10
        Me.lblRating.Text = "Rating:"
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtTitle, 4)
        Me.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(87, 3)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(297, 22)
        Me.txtTitle.TabIndex = 1
        '
        'lblOriginalTitle
        '
        Me.lblOriginalTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOriginalTitle.AutoSize = True
        Me.lblOriginalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblOriginalTitle.Location = New System.Drawing.Point(3, 35)
        Me.lblOriginalTitle.Name = "lblOriginalTitle"
        Me.lblOriginalTitle.Size = New System.Drawing.Size(76, 13)
        Me.lblOriginalTitle.TabIndex = 2
        Me.lblOriginalTitle.Text = "Original Title:"
        '
        'txtRating
        '
        Me.txtRating.BackColor = System.Drawing.SystemColors.Window
        Me.txtRating.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtRating.Location = New System.Drawing.Point(87, 171)
        Me.txtRating.Name = "txtRating"
        Me.txtRating.Size = New System.Drawing.Size(70, 22)
        Me.txtRating.TabIndex = 9
        '
        'txtOriginalTitle
        '
        Me.txtOriginalTitle.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtOriginalTitle, 4)
        Me.txtOriginalTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOriginalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtOriginalTitle.Location = New System.Drawing.Point(87, 31)
        Me.txtOriginalTitle.Name = "txtOriginalTitle"
        Me.txtOriginalTitle.Size = New System.Drawing.Size(297, 22)
        Me.txtOriginalTitle.TabIndex = 2
        '
        'lblSortTilte
        '
        Me.lblSortTilte.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSortTilte.AutoSize = True
        Me.lblSortTilte.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblSortTilte.Location = New System.Drawing.Point(3, 63)
        Me.lblSortTilte.Name = "lblSortTilte"
        Me.lblSortTilte.Size = New System.Drawing.Size(56, 13)
        Me.lblSortTilte.TabIndex = 4
        Me.lblSortTilte.Text = "Sort Title:"
        '
        'txtSortTitle
        '
        Me.txtSortTitle.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtSortTitle, 4)
        Me.txtSortTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSortTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtSortTitle.Location = New System.Drawing.Point(87, 59)
        Me.txtSortTitle.Name = "txtSortTitle"
        Me.txtSortTitle.Size = New System.Drawing.Size(297, 22)
        Me.txtSortTitle.TabIndex = 3
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(3, 147)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 13)
        Me.lblStatus.TabIndex = 13
        Me.lblStatus.Text = "Status:"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtStatus, 4)
        Me.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(87, 143)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(297, 22)
        Me.txtStatus.TabIndex = 8
        '
        'lblSeason
        '
        Me.lblSeason.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSeason.AutoSize = True
        Me.lblSeason.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblSeason.Location = New System.Drawing.Point(3, 91)
        Me.lblSeason.Name = "lblSeason"
        Me.lblSeason.Size = New System.Drawing.Size(47, 13)
        Me.lblSeason.TabIndex = 8
        Me.lblSeason.Text = "Season:"
        '
        'txtSeason
        '
        Me.txtSeason.BackColor = System.Drawing.SystemColors.Window
        Me.txtSeason.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSeason.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtSeason.Location = New System.Drawing.Point(87, 87)
        Me.txtSeason.Name = "txtSeason"
        Me.txtSeason.Size = New System.Drawing.Size(70, 22)
        Me.txtSeason.TabIndex = 4
        '
        'lblEpisode
        '
        Me.lblEpisode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEpisode.AutoSize = True
        Me.lblEpisode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblEpisode.Location = New System.Drawing.Point(257, 91)
        Me.lblEpisode.Name = "lblEpisode"
        Me.lblEpisode.Size = New System.Drawing.Size(51, 13)
        Me.lblEpisode.TabIndex = 8
        Me.lblEpisode.Text = "Episode:"
        '
        'txtEpisode
        '
        Me.txtEpisode.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtEpisode, 2)
        Me.txtEpisode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtEpisode.Location = New System.Drawing.Point(314, 87)
        Me.txtEpisode.Name = "txtEpisode"
        Me.txtEpisode.Size = New System.Drawing.Size(70, 22)
        Me.txtEpisode.TabIndex = 5
        '
        'lblYear
        '
        Me.lblYear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblYear.Location = New System.Drawing.Point(276, 119)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 8
        Me.lblYear.Text = "Year:"
        '
        'lblReleaseDate
        '
        Me.lblReleaseDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblReleaseDate.AutoSize = True
        Me.lblReleaseDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblReleaseDate.Location = New System.Drawing.Point(3, 119)
        Me.lblReleaseDate.Name = "lblReleaseDate"
        Me.lblReleaseDate.Size = New System.Drawing.Size(76, 13)
        Me.lblReleaseDate.TabIndex = 13
        Me.lblReleaseDate.Text = "Release Date:"
        '
        'btnAdd_Trailer
        '
        Me.btnAdd_Trailer.Image = CType(resources.GetObject("btnAdd_Trailer.Image"), System.Drawing.Image)
        Me.btnAdd_Trailer.Location = New System.Drawing.Point(314, 339)
        Me.btnAdd_Trailer.Name = "btnAdd_Trailer"
        Me.btnAdd_Trailer.Size = New System.Drawing.Size(23, 23)
        Me.btnAdd_Trailer.TabIndex = 20
        Me.btnAdd_Trailer.UseVisualStyleBackColor = True
        '
        'lblTVDB
        '
        Me.lblTVDB.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTVDB.AutoSize = True
        Me.lblTVDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTVDB.Location = New System.Drawing.Point(270, 287)
        Me.lblTVDB.Name = "lblTVDB"
        Me.lblTVDB.Size = New System.Drawing.Size(38, 13)
        Me.lblTVDB.TabIndex = 6
        Me.lblTVDB.Text = "TVDB:"
        '
        'txtTVDB
        '
        Me.txtTVDB.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtTVDB, 2)
        Me.txtTVDB.Enabled = False
        Me.txtTVDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtTVDB.Location = New System.Drawing.Point(314, 283)
        Me.txtTVDB.Name = "txtTVDB"
        Me.txtTVDB.ReadOnly = True
        Me.txtTVDB.Size = New System.Drawing.Size(70, 22)
        Me.txtTVDB.TabIndex = 17
        '
        'txtTMDBCollection
        '
        Me.txtTMDBCollection.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtTMDBCollection, 2)
        Me.txtTMDBCollection.Enabled = False
        Me.txtTMDBCollection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtTMDBCollection.Location = New System.Drawing.Point(314, 255)
        Me.txtTMDBCollection.Name = "txtTMDBCollection"
        Me.txtTMDBCollection.ReadOnly = True
        Me.txtTMDBCollection.Size = New System.Drawing.Size(70, 22)
        Me.txtTMDBCollection.TabIndex = 16
        '
        'lblTMDBCollection
        '
        Me.lblTMDBCollection.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTMDBCollection.AutoSize = True
        Me.lblTMDBCollection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTMDBCollection.Location = New System.Drawing.Point(211, 259)
        Me.lblTMDBCollection.Name = "lblTMDBCollection"
        Me.lblTMDBCollection.Size = New System.Drawing.Size(97, 13)
        Me.lblTMDBCollection.TabIndex = 6
        Me.lblTMDBCollection.Text = "TMDB Collection:"
        '
        'lblTMDB
        '
        Me.lblTMDB.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTMDB.AutoSize = True
        Me.lblTMDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTMDB.Location = New System.Drawing.Point(266, 231)
        Me.lblTMDB.Name = "lblTMDB"
        Me.lblTMDB.Size = New System.Drawing.Size(42, 13)
        Me.lblTMDB.TabIndex = 6
        Me.lblTMDB.Text = "TMDB:"
        '
        'txtTMDB
        '
        Me.txtTMDB.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtTMDB, 2)
        Me.txtTMDB.Enabled = False
        Me.txtTMDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtTMDB.Location = New System.Drawing.Point(314, 227)
        Me.txtTMDB.Name = "txtTMDB"
        Me.txtTMDB.ReadOnly = True
        Me.txtTMDB.Size = New System.Drawing.Size(70, 22)
        Me.txtTMDB.TabIndex = 14
        '
        'txtIMDB
        '
        Me.txtIMDB.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtIMDB, 2)
        Me.txtIMDB.Enabled = False
        Me.txtIMDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtIMDB.Location = New System.Drawing.Point(314, 199)
        Me.txtIMDB.Name = "txtIMDB"
        Me.txtIMDB.ReadOnly = True
        Me.txtIMDB.Size = New System.Drawing.Size(70, 22)
        Me.txtIMDB.TabIndex = 12
        '
        'lblIMDB
        '
        Me.lblIMDB.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblIMDB.AutoSize = True
        Me.lblIMDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblIMDB.Location = New System.Drawing.Point(269, 203)
        Me.lblIMDB.Name = "lblIMDB"
        Me.lblIMDB.Size = New System.Drawing.Size(39, 13)
        Me.lblIMDB.TabIndex = 6
        Me.lblIMDB.Text = "IMDB:"
        '
        'lblVotes
        '
        Me.lblVotes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblVotes.AutoSize = True
        Me.lblVotes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblVotes.Location = New System.Drawing.Point(270, 175)
        Me.lblVotes.Name = "lblVotes"
        Me.lblVotes.Size = New System.Drawing.Size(38, 13)
        Me.lblVotes.TabIndex = 17
        Me.lblVotes.Text = "Votes:"
        '
        'txtVotes
        '
        Me.txtVotes.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMain.SetColumnSpan(Me.txtVotes, 2)
        Me.txtVotes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtVotes.Location = New System.Drawing.Point(314, 171)
        Me.txtVotes.Name = "txtVotes"
        Me.txtVotes.Size = New System.Drawing.Size(70, 22)
        Me.txtVotes.TabIndex = 10
        '
        'lblUserRating
        '
        Me.lblUserRating.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUserRating.AutoSize = True
        Me.lblUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblUserRating.Location = New System.Drawing.Point(3, 203)
        Me.lblUserRating.Name = "lblUserRating"
        Me.lblUserRating.Size = New System.Drawing.Size(70, 13)
        Me.lblUserRating.TabIndex = 10
        Me.lblUserRating.Text = "User Rating:"
        '
        'cbUserRating
        '
        Me.cbUserRating.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbUserRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbUserRating.FormattingEnabled = True
        Me.cbUserRating.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cbUserRating.Location = New System.Drawing.Point(87, 199)
        Me.cbUserRating.Name = "cbUserRating"
        Me.cbUserRating.Size = New System.Drawing.Size(70, 21)
        Me.cbUserRating.TabIndex = 11
        '
        'lblTop250
        '
        Me.lblTop250.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTop250.AutoSize = True
        Me.lblTop250.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTop250.Location = New System.Drawing.Point(3, 231)
        Me.lblTop250.Name = "lblTop250"
        Me.lblTop250.Size = New System.Drawing.Size(50, 13)
        Me.lblTop250.TabIndex = 19
        Me.lblTop250.Text = "Top 250:"
        '
        'lblRuntime
        '
        Me.lblRuntime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRuntime.AutoSize = True
        Me.lblRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblRuntime.Location = New System.Drawing.Point(3, 259)
        Me.lblRuntime.Name = "lblRuntime"
        Me.lblRuntime.Size = New System.Drawing.Size(54, 13)
        Me.lblRuntime.TabIndex = 15
        Me.lblRuntime.Text = "Runtime:"
        '
        'txtRuntime
        '
        Me.txtRuntime.BackColor = System.Drawing.SystemColors.Window
        Me.txtRuntime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtRuntime.Location = New System.Drawing.Point(87, 255)
        Me.txtRuntime.Name = "txtRuntime"
        Me.txtRuntime.Size = New System.Drawing.Size(70, 22)
        Me.txtRuntime.TabIndex = 15
        '
        'txtReleaseDate
        '
        Me.txtReleaseDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtReleaseDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtReleaseDate.Location = New System.Drawing.Point(87, 115)
        Me.txtReleaseDate.Mask = "0000-00-00"
        Me.txtReleaseDate.Name = "txtReleaseDate"
        Me.txtReleaseDate.Size = New System.Drawing.Size(70, 22)
        Me.txtReleaseDate.TabIndex = 6
        '
        'txtYear
        '
        Me.tblDetailsMain.SetColumnSpan(Me.txtYear, 2)
        Me.txtYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtYear.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtYear.Location = New System.Drawing.Point(314, 115)
        Me.txtYear.Mask = "0000"
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(70, 22)
        Me.txtYear.TabIndex = 7
        '
        'txtTop250
        '
        Me.txtTop250.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtTop250.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtTop250.Location = New System.Drawing.Point(87, 227)
        Me.txtTop250.Mask = "990"
        Me.txtTop250.Name = "txtTop250"
        Me.txtTop250.Size = New System.Drawing.Size(70, 22)
        Me.txtTop250.TabIndex = 13
        '
        'tblDetailsMPAA
        '
        Me.tblDetailsMPAA.AutoSize = True
        Me.tblDetailsMPAA.ColumnCount = 4
        Me.tblDetailsColumn1.SetColumnSpan(Me.tblDetailsMPAA, 2)
        Me.tblDetailsMPAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsMPAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsMPAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsMPAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsMPAA.Controls.Add(Me.lbMPAA, 0, 1)
        Me.tblDetailsMPAA.Controls.Add(Me.lblMPAARating, 0, 0)
        Me.tblDetailsMPAA.Controls.Add(Me.lblMPAADescription, 2, 0)
        Me.tblDetailsMPAA.Controls.Add(Me.txtMPAADesc, 2, 1)
        Me.tblDetailsMPAA.Controls.Add(Me.txtMPAA, 1, 2)
        Me.tblDetailsMPAA.Controls.Add(Me.lblCertifications, 3, 0)
        Me.tblDetailsMPAA.Controls.Add(Me.lbCertifications, 3, 1)
        Me.tblDetailsMPAA.Controls.Add(Me.lblMPAA, 0, 2)
        Me.tblDetailsMPAA.Controls.Add(Me.lblMPAAPreview, 0, 3)
        Me.tblDetailsMPAA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsMPAA.Location = New System.Drawing.Point(3, 374)
        Me.tblDetailsMPAA.Name = "tblDetailsMPAA"
        Me.tblDetailsMPAA.RowCount = 4
        Me.tblDetailsMPAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMPAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMPAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMPAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsMPAA.Size = New System.Drawing.Size(387, 121)
        Me.tblDetailsMPAA.TabIndex = 82
        '
        'lbMPAA
        '
        Me.lbMPAA.BackColor = System.Drawing.SystemColors.Window
        Me.lbMPAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tblDetailsMPAA.SetColumnSpan(Me.lbMPAA, 2)
        Me.lbMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbMPAA.FormattingEnabled = True
        Me.lbMPAA.Location = New System.Drawing.Point(3, 16)
        Me.lbMPAA.Name = "lbMPAA"
        Me.lbMPAA.ScrollAlwaysVisible = True
        Me.lbMPAA.Size = New System.Drawing.Size(119, 54)
        Me.lbMPAA.TabIndex = 22
        '
        'lblMPAARating
        '
        Me.lblMPAARating.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMPAARating.AutoSize = True
        Me.tblDetailsMPAA.SetColumnSpan(Me.lblMPAARating, 2)
        Me.lblMPAARating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMPAARating.Location = New System.Drawing.Point(3, 0)
        Me.lblMPAARating.Name = "lblMPAARating"
        Me.lblMPAARating.Size = New System.Drawing.Size(80, 13)
        Me.lblMPAARating.TabIndex = 36
        Me.lblMPAARating.Text = "MPAA Rating:"
        '
        'lblMPAADescription
        '
        Me.lblMPAADescription.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMPAADescription.AutoSize = True
        Me.lblMPAADescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMPAADescription.Location = New System.Drawing.Point(128, 0)
        Me.lblMPAADescription.Name = "lblMPAADescription"
        Me.lblMPAADescription.Size = New System.Drawing.Size(69, 13)
        Me.lblMPAADescription.TabIndex = 38
        Me.lblMPAADescription.Text = "Description:"
        '
        'txtMPAADesc
        '
        Me.txtMPAADesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPAADesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtMPAADesc.Location = New System.Drawing.Point(128, 16)
        Me.txtMPAADesc.Multiline = True
        Me.txtMPAADesc.Name = "txtMPAADesc"
        Me.txtMPAADesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMPAADesc.Size = New System.Drawing.Size(120, 54)
        Me.txtMPAADesc.TabIndex = 23
        '
        'txtMPAA
        '
        Me.txtMPAA.BackColor = System.Drawing.SystemColors.Window
        Me.tblDetailsMPAA.SetColumnSpan(Me.txtMPAA, 3)
        Me.txtMPAA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtMPAA.Location = New System.Drawing.Point(52, 76)
        Me.txtMPAA.Name = "txtMPAA"
        Me.txtMPAA.Size = New System.Drawing.Size(332, 22)
        Me.txtMPAA.TabIndex = 25
        '
        'lblCertifications
        '
        Me.lblCertifications.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCertifications.AutoSize = True
        Me.lblCertifications.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblCertifications.Location = New System.Drawing.Point(254, 0)
        Me.lblCertifications.Name = "lblCertifications"
        Me.lblCertifications.Size = New System.Drawing.Size(78, 13)
        Me.lblCertifications.TabIndex = 45
        Me.lblCertifications.Text = "Certifications:"
        '
        'lbCertifications
        '
        Me.lbCertifications.BackColor = System.Drawing.SystemColors.Window
        Me.lbCertifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbCertifications.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbCertifications.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbCertifications.FormattingEnabled = True
        Me.lbCertifications.Location = New System.Drawing.Point(254, 16)
        Me.lbCertifications.Name = "lbCertifications"
        Me.lbCertifications.ScrollAlwaysVisible = True
        Me.lbCertifications.Size = New System.Drawing.Size(130, 54)
        Me.lbCertifications.TabIndex = 24
        '
        'lblMPAA
        '
        Me.lblMPAA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMPAA.AutoSize = True
        Me.lblMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMPAA.Location = New System.Drawing.Point(3, 80)
        Me.lblMPAA.Name = "lblMPAA"
        Me.lblMPAA.Size = New System.Drawing.Size(43, 13)
        Me.lblMPAA.TabIndex = 36
        Me.lblMPAA.Text = "MPAA:"
        '
        'lblMPAAPreview
        '
        Me.tblDetailsMPAA.SetColumnSpan(Me.lblMPAAPreview, 4)
        Me.lblMPAAPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMPAAPreview.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMPAAPreview.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblMPAAPreview.Location = New System.Drawing.Point(3, 101)
        Me.lblMPAAPreview.Name = "lblMPAAPreview"
        Me.lblMPAAPreview.Size = New System.Drawing.Size(381, 20)
        Me.lblMPAAPreview.TabIndex = 74
        Me.lblMPAAPreview.Text = "MPAA Preview"
        '
        'pnlDetailsColumn2
        '
        Me.pnlDetailsColumn2.AutoSize = True
        Me.pnlDetailsColumn2.Controls.Add(Me.tblDetailsColumn2)
        Me.pnlDetailsColumn2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetailsColumn2.Location = New System.Drawing.Point(402, 3)
        Me.pnlDetailsColumn2.Name = "pnlDetailsColumn2"
        Me.pnlDetailsColumn2.Size = New System.Drawing.Size(384, 514)
        Me.pnlDetailsColumn2.TabIndex = 3
        '
        'tblDetailsColumn2
        '
        Me.tblDetailsColumn2.AutoSize = True
        Me.tblDetailsColumn2.ColumnCount = 1
        Me.tblDetailsColumn2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsColumn2.Controls.Add(Me.tblDetailsInfo, 0, 0)
        Me.tblDetailsColumn2.Controls.Add(Me.tblDetailsGenresTagsShowlink, 0, 2)
        Me.tblDetailsColumn2.Controls.Add(Me.tblDetailsCollection, 0, 1)
        Me.tblDetailsColumn2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsColumn2.Location = New System.Drawing.Point(0, 0)
        Me.tblDetailsColumn2.Name = "tblDetailsColumn2"
        Me.tblDetailsColumn2.RowCount = 4
        Me.tblDetailsColumn2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn2.Size = New System.Drawing.Size(384, 514)
        Me.tblDetailsColumn2.TabIndex = 1
        '
        'tblDetailsInfo
        '
        Me.tblDetailsInfo.AutoSize = True
        Me.tblDetailsInfo.ColumnCount = 1
        Me.tblDetailsInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsInfo.Controls.Add(Me.lblTagline, 0, 0)
        Me.tblDetailsInfo.Controls.Add(Me.txtTagline, 0, 1)
        Me.tblDetailsInfo.Controls.Add(Me.lblPlot, 0, 2)
        Me.tblDetailsInfo.Controls.Add(Me.txtPlot, 0, 3)
        Me.tblDetailsInfo.Controls.Add(Me.lblOutline, 0, 4)
        Me.tblDetailsInfo.Controls.Add(Me.txtOutline, 0, 5)
        Me.tblDetailsInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsInfo.Location = New System.Drawing.Point(3, 3)
        Me.tblDetailsInfo.Name = "tblDetailsInfo"
        Me.tblDetailsInfo.RowCount = 6
        Me.tblDetailsInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsInfo.Size = New System.Drawing.Size(378, 239)
        Me.tblDetailsInfo.TabIndex = 76
        '
        'lblTagline
        '
        Me.lblTagline.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTagline.AutoSize = True
        Me.lblTagline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTagline.Location = New System.Drawing.Point(3, 0)
        Me.lblTagline.Name = "lblTagline"
        Me.lblTagline.Size = New System.Drawing.Size(47, 13)
        Me.lblTagline.TabIndex = 6
        Me.lblTagline.Text = "Tagline:"
        '
        'txtTagline
        '
        Me.txtTagline.BackColor = System.Drawing.SystemColors.Window
        Me.txtTagline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTagline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtTagline.Location = New System.Drawing.Point(3, 16)
        Me.txtTagline.Name = "txtTagline"
        Me.txtTagline.Size = New System.Drawing.Size(372, 22)
        Me.txtTagline.TabIndex = 7
        '
        'lblPlot
        '
        Me.lblPlot.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPlot.AutoSize = True
        Me.lblPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblPlot.Location = New System.Drawing.Point(3, 41)
        Me.lblPlot.Name = "lblPlot"
        Me.lblPlot.Size = New System.Drawing.Size(31, 13)
        Me.lblPlot.TabIndex = 27
        Me.lblPlot.Text = "Plot:"
        '
        'txtPlot
        '
        Me.txtPlot.AcceptsReturn = True
        Me.txtPlot.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtPlot.Location = New System.Drawing.Point(3, 57)
        Me.txtPlot.Multiline = True
        Me.txtPlot.Name = "txtPlot"
        Me.txtPlot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPlot.Size = New System.Drawing.Size(372, 80)
        Me.txtPlot.TabIndex = 28
        '
        'lblOutline
        '
        Me.lblOutline.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOutline.AutoSize = True
        Me.lblOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblOutline.Location = New System.Drawing.Point(3, 140)
        Me.lblOutline.Name = "lblOutline"
        Me.lblOutline.Size = New System.Drawing.Size(48, 13)
        Me.lblOutline.TabIndex = 25
        Me.lblOutline.Text = "Outline:"
        '
        'txtOutline
        '
        Me.txtOutline.AcceptsReturn = True
        Me.txtOutline.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtOutline.Location = New System.Drawing.Point(3, 156)
        Me.txtOutline.Multiline = True
        Me.txtOutline.Name = "txtOutline"
        Me.txtOutline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutline.Size = New System.Drawing.Size(372, 80)
        Me.txtOutline.TabIndex = 26
        '
        'tblDetailsGenresTagsShowlink
        '
        Me.tblDetailsGenresTagsShowlink.AutoSize = True
        Me.tblDetailsGenresTagsShowlink.ColumnCount = 3
        Me.tblDetailsGenresTagsShowlink.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblDetailsGenresTagsShowlink.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblDetailsGenresTagsShowlink.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblDetailsGenresTagsShowlink.Controls.Add(Me.lblGenres, 0, 0)
        Me.tblDetailsGenresTagsShowlink.Controls.Add(Me.clbTVShowLinks, 2, 1)
        Me.tblDetailsGenresTagsShowlink.Controls.Add(Me.clbGenres, 0, 1)
        Me.tblDetailsGenresTagsShowlink.Controls.Add(Me.lblTags, 1, 0)
        Me.tblDetailsGenresTagsShowlink.Controls.Add(Me.lblTVShowLinks, 2, 0)
        Me.tblDetailsGenresTagsShowlink.Controls.Add(Me.clbTags, 1, 1)
        Me.tblDetailsGenresTagsShowlink.Controls.Add(Me.btnAdd_Genre, 0, 2)
        Me.tblDetailsGenresTagsShowlink.Controls.Add(Me.btnAdd_Tag, 1, 2)
        Me.tblDetailsGenresTagsShowlink.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsGenresTagsShowlink.Location = New System.Drawing.Point(3, 283)
        Me.tblDetailsGenresTagsShowlink.Name = "tblDetailsGenresTagsShowlink"
        Me.tblDetailsGenresTagsShowlink.RowCount = 3
        Me.tblDetailsGenresTagsShowlink.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsGenresTagsShowlink.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsGenresTagsShowlink.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsGenresTagsShowlink.Size = New System.Drawing.Size(378, 148)
        Me.tblDetailsGenresTagsShowlink.TabIndex = 81
        '
        'lblGenres
        '
        Me.lblGenres.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblGenres.AutoSize = True
        Me.lblGenres.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblGenres.Location = New System.Drawing.Point(3, 0)
        Me.lblGenres.Name = "lblGenres"
        Me.lblGenres.Size = New System.Drawing.Size(46, 13)
        Me.lblGenres.TabIndex = 23
        Me.lblGenres.Text = "Genres:"
        '
        'clbTVShowLinks
        '
        Me.clbTVShowLinks.BackColor = System.Drawing.SystemColors.Window
        Me.clbTVShowLinks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbTVShowLinks.CheckOnClick = True
        Me.clbTVShowLinks.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.clbTVShowLinks.FormattingEnabled = True
        Me.clbTVShowLinks.IntegralHeight = False
        Me.clbTVShowLinks.Location = New System.Drawing.Point(255, 16)
        Me.clbTVShowLinks.Name = "clbTVShowLinks"
        Me.clbTVShowLinks.ScrollAlwaysVisible = True
        Me.clbTVShowLinks.Size = New System.Drawing.Size(120, 100)
        Me.clbTVShowLinks.TabIndex = 24
        '
        'clbGenres
        '
        Me.clbGenres.BackColor = System.Drawing.SystemColors.Window
        Me.clbGenres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbGenres.CheckOnClick = True
        Me.clbGenres.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.clbGenres.FormattingEnabled = True
        Me.clbGenres.IntegralHeight = False
        Me.clbGenres.Location = New System.Drawing.Point(3, 16)
        Me.clbGenres.Name = "clbGenres"
        Me.clbGenres.ScrollAlwaysVisible = True
        Me.clbGenres.Size = New System.Drawing.Size(119, 100)
        Me.clbGenres.TabIndex = 24
        '
        'lblTags
        '
        Me.lblTags.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTags.AutoSize = True
        Me.lblTags.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTags.Location = New System.Drawing.Point(129, 0)
        Me.lblTags.Name = "lblTags"
        Me.lblTags.Size = New System.Drawing.Size(33, 13)
        Me.lblTags.TabIndex = 23
        Me.lblTags.Text = "Tags:"
        '
        'lblTVShowLinks
        '
        Me.lblTVShowLinks.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVShowLinks.AutoSize = True
        Me.lblTVShowLinks.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTVShowLinks.Location = New System.Drawing.Point(255, 0)
        Me.lblTVShowLinks.Name = "lblTVShowLinks"
        Me.lblTVShowLinks.Size = New System.Drawing.Size(85, 13)
        Me.lblTVShowLinks.TabIndex = 36
        Me.lblTVShowLinks.Text = "TV Show Links:"
        '
        'clbTags
        '
        Me.clbTags.BackColor = System.Drawing.SystemColors.Window
        Me.clbTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbTags.CheckOnClick = True
        Me.clbTags.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.clbTags.FormattingEnabled = True
        Me.clbTags.IntegralHeight = False
        Me.clbTags.Location = New System.Drawing.Point(129, 16)
        Me.clbTags.Name = "clbTags"
        Me.clbTags.ScrollAlwaysVisible = True
        Me.clbTags.Size = New System.Drawing.Size(119, 100)
        Me.clbTags.TabIndex = 24
        '
        'btnAdd_Genre
        '
        Me.btnAdd_Genre.Image = CType(resources.GetObject("btnAdd_Genre.Image"), System.Drawing.Image)
        Me.btnAdd_Genre.Location = New System.Drawing.Point(3, 122)
        Me.btnAdd_Genre.Name = "btnAdd_Genre"
        Me.btnAdd_Genre.Size = New System.Drawing.Size(23, 23)
        Me.btnAdd_Genre.TabIndex = 53
        Me.btnAdd_Genre.UseVisualStyleBackColor = True
        '
        'btnAdd_Tag
        '
        Me.btnAdd_Tag.Image = CType(resources.GetObject("btnAdd_Tag.Image"), System.Drawing.Image)
        Me.btnAdd_Tag.Location = New System.Drawing.Point(129, 122)
        Me.btnAdd_Tag.Name = "btnAdd_Tag"
        Me.btnAdd_Tag.Size = New System.Drawing.Size(23, 23)
        Me.btnAdd_Tag.TabIndex = 53
        Me.btnAdd_Tag.UseVisualStyleBackColor = True
        '
        'tblDetailsCollection
        '
        Me.tblDetailsCollection.AutoSize = True
        Me.tblDetailsCollection.ColumnCount = 3
        Me.tblDetailsCollection.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsCollection.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDetailsCollection.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsCollection.Controls.Add(Me.lblCollection, 0, 0)
        Me.tblDetailsCollection.Controls.Add(Me.cbCollection, 1, 0)
        Me.tblDetailsCollection.Controls.Add(Me.btnAdd_Collection, 2, 0)
        Me.tblDetailsCollection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsCollection.Location = New System.Drawing.Point(3, 248)
        Me.tblDetailsCollection.Name = "tblDetailsCollection"
        Me.tblDetailsCollection.RowCount = 2
        Me.tblDetailsCollection.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsCollection.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsCollection.Size = New System.Drawing.Size(378, 29)
        Me.tblDetailsCollection.TabIndex = 80
        '
        'lblCollection
        '
        Me.lblCollection.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCollection.AutoSize = True
        Me.lblCollection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblCollection.Location = New System.Drawing.Point(3, 8)
        Me.lblCollection.Name = "lblCollection"
        Me.lblCollection.Size = New System.Drawing.Size(62, 13)
        Me.lblCollection.TabIndex = 36
        Me.lblCollection.Text = "Collection:"
        '
        'cbCollection
        '
        Me.cbCollection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCollection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbCollection.FormattingEnabled = True
        Me.cbCollection.Location = New System.Drawing.Point(71, 3)
        Me.cbCollection.Name = "cbCollection"
        Me.cbCollection.Size = New System.Drawing.Size(275, 21)
        Me.cbCollection.TabIndex = 74
        '
        'btnAdd_Collection
        '
        Me.btnAdd_Collection.Image = CType(resources.GetObject("btnAdd_Collection.Image"), System.Drawing.Image)
        Me.btnAdd_Collection.Location = New System.Drawing.Point(352, 3)
        Me.btnAdd_Collection.Name = "btnAdd_Collection"
        Me.btnAdd_Collection.Size = New System.Drawing.Size(23, 23)
        Me.btnAdd_Collection.TabIndex = 53
        Me.btnAdd_Collection.UseVisualStyleBackColor = True
        '
        'pnlDetailsColumn3
        '
        Me.pnlDetailsColumn3.AutoSize = True
        Me.pnlDetailsColumn3.Controls.Add(Me.tblDetailsColumn3)
        Me.pnlDetailsColumn3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetailsColumn3.Location = New System.Drawing.Point(792, 3)
        Me.pnlDetailsColumn3.Name = "pnlDetailsColumn3"
        Me.pnlDetailsColumn3.Size = New System.Drawing.Size(375, 514)
        Me.pnlDetailsColumn3.TabIndex = 4
        '
        'tblDetailsColumn3
        '
        Me.tblDetailsColumn3.AutoSize = True
        Me.tblDetailsColumn3.ColumnCount = 1
        Me.tblDetailsColumn3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDetailsColumn3.Controls.Add(Me.tcCrew, 0, 0)
        Me.tblDetailsColumn3.Controls.Add(Me.tblDetailsCrew, 0, 1)
        Me.tblDetailsColumn3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsColumn3.Location = New System.Drawing.Point(0, 0)
        Me.tblDetailsColumn3.Name = "tblDetailsColumn3"
        Me.tblDetailsColumn3.RowCount = 3
        Me.tblDetailsColumn3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsColumn3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblDetailsColumn3.Size = New System.Drawing.Size(375, 514)
        Me.tblDetailsColumn3.TabIndex = 0
        '
        'tcCrew
        '
        Me.tcCrew.Controls.Add(Me.tpActors)
        Me.tcCrew.Controls.Add(Me.tpSpecialGuests)
        Me.tcCrew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcCrew.Location = New System.Drawing.Point(3, 3)
        Me.tcCrew.Name = "tcCrew"
        Me.tcCrew.SelectedIndex = 0
        Me.tcCrew.Size = New System.Drawing.Size(378, 234)
        Me.tcCrew.TabIndex = 86
        '
        'tpActors
        '
        Me.tpActors.Controls.Add(Me.tblActors)
        Me.tpActors.Location = New System.Drawing.Point(4, 22)
        Me.tpActors.Name = "tpActors"
        Me.tpActors.Padding = New System.Windows.Forms.Padding(3)
        Me.tpActors.Size = New System.Drawing.Size(370, 208)
        Me.tpActors.TabIndex = 0
        Me.tpActors.Text = "Actors"
        Me.tpActors.UseVisualStyleBackColor = True
        '
        'tblActors
        '
        Me.tblActors.AutoSize = True
        Me.tblActors.ColumnCount = 7
        Me.tblActors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblActors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblActors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblActors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblActors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblActors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblActors.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblActors.Controls.Add(Me.lvActors, 0, 0)
        Me.tblActors.Controls.Add(Me.btnAdd_Actor, 0, 1)
        Me.tblActors.Controls.Add(Me.btnEdit_Actor, 1, 1)
        Me.tblActors.Controls.Add(Me.btnUp_Actor, 3, 1)
        Me.tblActors.Controls.Add(Me.btnDown_Actor, 4, 1)
        Me.tblActors.Controls.Add(Me.btnRemove_Actor, 6, 1)
        Me.tblActors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblActors.Location = New System.Drawing.Point(3, 3)
        Me.tblActors.Name = "tblActors"
        Me.tblActors.RowCount = 2
        Me.tblActors.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblActors.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblActors.Size = New System.Drawing.Size(364, 202)
        Me.tblActors.TabIndex = 83
        '
        'lvActors
        '
        Me.lvActors.BackColor = System.Drawing.SystemColors.Window
        Me.lvActors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvActors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colName, Me.colRole, Me.colThumb})
        Me.tblActors.SetColumnSpan(Me.lvActors, 7)
        Me.lvActors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvActors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvActors.FullRowSelect = True
        Me.lvActors.Location = New System.Drawing.Point(3, 3)
        Me.lvActors.Name = "lvActors"
        Me.lvActors.Size = New System.Drawing.Size(358, 167)
        Me.lvActors.TabIndex = 30
        Me.lvActors.UseCompatibleStateImageBehavior = False
        Me.lvActors.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colName
        '
        Me.colName.Text = "Name"
        Me.colName.Width = 100
        '
        'colRole
        '
        Me.colRole.Text = "Role"
        Me.colRole.Width = 100
        '
        'colThumb
        '
        Me.colThumb.Text = "Thumb"
        Me.colThumb.Width = 100
        '
        'btnAdd_Actor
        '
        Me.btnAdd_Actor.Image = CType(resources.GetObject("btnAdd_Actor.Image"), System.Drawing.Image)
        Me.btnAdd_Actor.Location = New System.Drawing.Point(3, 176)
        Me.btnAdd_Actor.Name = "btnAdd_Actor"
        Me.btnAdd_Actor.Size = New System.Drawing.Size(23, 23)
        Me.btnAdd_Actor.TabIndex = 31
        Me.btnAdd_Actor.UseVisualStyleBackColor = True
        '
        'btnEdit_Actor
        '
        Me.btnEdit_Actor.Image = CType(resources.GetObject("btnEdit_Actor.Image"), System.Drawing.Image)
        Me.btnEdit_Actor.Location = New System.Drawing.Point(32, 176)
        Me.btnEdit_Actor.Name = "btnEdit_Actor"
        Me.btnEdit_Actor.Size = New System.Drawing.Size(23, 23)
        Me.btnEdit_Actor.TabIndex = 32
        Me.btnEdit_Actor.UseVisualStyleBackColor = True
        '
        'btnUp_Actor
        '
        Me.btnUp_Actor.Image = CType(resources.GetObject("btnUp_Actor.Image"), System.Drawing.Image)
        Me.btnUp_Actor.Location = New System.Drawing.Point(170, 176)
        Me.btnUp_Actor.Name = "btnUp_Actor"
        Me.btnUp_Actor.Size = New System.Drawing.Size(23, 23)
        Me.btnUp_Actor.TabIndex = 33
        Me.btnUp_Actor.UseVisualStyleBackColor = True
        '
        'btnDown_Actor
        '
        Me.btnDown_Actor.Image = CType(resources.GetObject("btnDown_Actor.Image"), System.Drawing.Image)
        Me.btnDown_Actor.Location = New System.Drawing.Point(199, 176)
        Me.btnDown_Actor.Name = "btnDown_Actor"
        Me.btnDown_Actor.Size = New System.Drawing.Size(23, 23)
        Me.btnDown_Actor.TabIndex = 34
        Me.btnDown_Actor.UseVisualStyleBackColor = True
        '
        'btnRemove_Actor
        '
        Me.btnRemove_Actor.Image = CType(resources.GetObject("btnRemove_Actor.Image"), System.Drawing.Image)
        Me.btnRemove_Actor.Location = New System.Drawing.Point(337, 176)
        Me.btnRemove_Actor.Name = "btnRemove_Actor"
        Me.btnRemove_Actor.Size = New System.Drawing.Size(23, 23)
        Me.btnRemove_Actor.TabIndex = 35
        Me.btnRemove_Actor.UseVisualStyleBackColor = True
        '
        'tpSpecialGuests
        '
        Me.tpSpecialGuests.Controls.Add(Me.tblSpecialGuests)
        Me.tpSpecialGuests.Location = New System.Drawing.Point(4, 22)
        Me.tpSpecialGuests.Name = "tpSpecialGuests"
        Me.tpSpecialGuests.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSpecialGuests.Size = New System.Drawing.Size(370, 208)
        Me.tpSpecialGuests.TabIndex = 1
        Me.tpSpecialGuests.Text = "Special Guests"
        Me.tpSpecialGuests.UseVisualStyleBackColor = True
        '
        'tblSpecialGuests
        '
        Me.tblSpecialGuests.AutoSize = True
        Me.tblSpecialGuests.ColumnCount = 7
        Me.tblSpecialGuests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSpecialGuests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSpecialGuests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblSpecialGuests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSpecialGuests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSpecialGuests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblSpecialGuests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSpecialGuests.Controls.Add(Me.lvSpecialGuests, 0, 0)
        Me.tblSpecialGuests.Controls.Add(Me.btnAdd_SpecialGuest, 0, 1)
        Me.tblSpecialGuests.Controls.Add(Me.btnEdit_SpecialGuest, 1, 1)
        Me.tblSpecialGuests.Controls.Add(Me.btnUp_SpecialGuest, 3, 1)
        Me.tblSpecialGuests.Controls.Add(Me.btnDown_SpecialGuest, 4, 1)
        Me.tblSpecialGuests.Controls.Add(Me.btnRemove_SpecialGuest, 6, 1)
        Me.tblSpecialGuests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSpecialGuests.Location = New System.Drawing.Point(3, 3)
        Me.tblSpecialGuests.Name = "tblSpecialGuests"
        Me.tblSpecialGuests.RowCount = 2
        Me.tblSpecialGuests.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblSpecialGuests.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSpecialGuests.Size = New System.Drawing.Size(364, 202)
        Me.tblSpecialGuests.TabIndex = 87
        '
        'lvSpecialGuests
        '
        Me.lvSpecialGuests.BackColor = System.Drawing.SystemColors.Window
        Me.lvSpecialGuests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvSpecialGuests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.tblSpecialGuests.SetColumnSpan(Me.lvSpecialGuests, 7)
        Me.lvSpecialGuests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSpecialGuests.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvSpecialGuests.FullRowSelect = True
        Me.lvSpecialGuests.Location = New System.Drawing.Point(3, 3)
        Me.lvSpecialGuests.Name = "lvSpecialGuests"
        Me.lvSpecialGuests.Size = New System.Drawing.Size(358, 167)
        Me.lvSpecialGuests.TabIndex = 30
        Me.lvSpecialGuests.UseCompatibleStateImageBehavior = False
        Me.lvSpecialGuests.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ID"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Role"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Thumb"
        Me.ColumnHeader9.Width = 100
        '
        'btnAdd_SpecialGuest
        '
        Me.btnAdd_SpecialGuest.Image = CType(resources.GetObject("btnAdd_SpecialGuest.Image"), System.Drawing.Image)
        Me.btnAdd_SpecialGuest.Location = New System.Drawing.Point(3, 176)
        Me.btnAdd_SpecialGuest.Name = "btnAdd_SpecialGuest"
        Me.btnAdd_SpecialGuest.Size = New System.Drawing.Size(23, 23)
        Me.btnAdd_SpecialGuest.TabIndex = 31
        Me.btnAdd_SpecialGuest.UseVisualStyleBackColor = True
        '
        'btnEdit_SpecialGuest
        '
        Me.btnEdit_SpecialGuest.Image = CType(resources.GetObject("btnEdit_SpecialGuest.Image"), System.Drawing.Image)
        Me.btnEdit_SpecialGuest.Location = New System.Drawing.Point(32, 176)
        Me.btnEdit_SpecialGuest.Name = "btnEdit_SpecialGuest"
        Me.btnEdit_SpecialGuest.Size = New System.Drawing.Size(23, 23)
        Me.btnEdit_SpecialGuest.TabIndex = 32
        Me.btnEdit_SpecialGuest.UseVisualStyleBackColor = True
        '
        'btnUp_SpecialGuest
        '
        Me.btnUp_SpecialGuest.Image = CType(resources.GetObject("btnUp_SpecialGuest.Image"), System.Drawing.Image)
        Me.btnUp_SpecialGuest.Location = New System.Drawing.Point(170, 176)
        Me.btnUp_SpecialGuest.Name = "btnUp_SpecialGuest"
        Me.btnUp_SpecialGuest.Size = New System.Drawing.Size(23, 23)
        Me.btnUp_SpecialGuest.TabIndex = 33
        Me.btnUp_SpecialGuest.UseVisualStyleBackColor = True
        '
        'btnDown_SpecialGuest
        '
        Me.btnDown_SpecialGuest.Image = CType(resources.GetObject("btnDown_SpecialGuest.Image"), System.Drawing.Image)
        Me.btnDown_SpecialGuest.Location = New System.Drawing.Point(199, 176)
        Me.btnDown_SpecialGuest.Name = "btnDown_SpecialGuest"
        Me.btnDown_SpecialGuest.Size = New System.Drawing.Size(23, 23)
        Me.btnDown_SpecialGuest.TabIndex = 34
        Me.btnDown_SpecialGuest.UseVisualStyleBackColor = True
        '
        'btnRemove_SpecialGuest
        '
        Me.btnRemove_SpecialGuest.Image = CType(resources.GetObject("btnRemove_SpecialGuest.Image"), System.Drawing.Image)
        Me.btnRemove_SpecialGuest.Location = New System.Drawing.Point(337, 176)
        Me.btnRemove_SpecialGuest.Name = "btnRemove_SpecialGuest"
        Me.btnRemove_SpecialGuest.Size = New System.Drawing.Size(23, 23)
        Me.btnRemove_SpecialGuest.TabIndex = 35
        Me.btnRemove_SpecialGuest.UseVisualStyleBackColor = True
        '
        'tblDetailsCrew
        '
        Me.tblDetailsCrew.AutoSize = True
        Me.tblDetailsCrew.ColumnCount = 2
        Me.tblDetailsCrew.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblDetailsCrew.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblDetailsCrew.Controls.Add(Me.lbDirectors, 0, 1)
        Me.tblDetailsCrew.Controls.Add(Me.lbCreditsCreators, 0, 3)
        Me.tblDetailsCrew.Controls.Add(Me.lblDirectors, 0, 0)
        Me.tblDetailsCrew.Controls.Add(Me.lblCreditsCreators, 0, 2)
        Me.tblDetailsCrew.Controls.Add(Me.lblCountries, 1, 0)
        Me.tblDetailsCrew.Controls.Add(Me.lbCountries, 1, 1)
        Me.tblDetailsCrew.Controls.Add(Me.lblStudio, 1, 2)
        Me.tblDetailsCrew.Controls.Add(Me.lbStudios, 1, 3)
        Me.tblDetailsCrew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDetailsCrew.Location = New System.Drawing.Point(3, 243)
        Me.tblDetailsCrew.Name = "tblDetailsCrew"
        Me.tblDetailsCrew.RowCount = 4
        Me.tblDetailsCrew.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsCrew.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblDetailsCrew.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDetailsCrew.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblDetailsCrew.Size = New System.Drawing.Size(378, 172)
        Me.tblDetailsCrew.TabIndex = 84
        '
        'lbDirectors
        '
        Me.lbDirectors.BackColor = System.Drawing.SystemColors.Window
        Me.lbDirectors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbDirectors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbDirectors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbDirectors.FormattingEnabled = True
        Me.lbDirectors.Location = New System.Drawing.Point(3, 16)
        Me.lbDirectors.Name = "lbDirectors"
        Me.lbDirectors.ScrollAlwaysVisible = True
        Me.lbDirectors.Size = New System.Drawing.Size(183, 67)
        Me.lbDirectors.TabIndex = 37
        '
        'lbCreditsCreators
        '
        Me.lbCreditsCreators.BackColor = System.Drawing.SystemColors.Window
        Me.lbCreditsCreators.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbCreditsCreators.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbCreditsCreators.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbCreditsCreators.FormattingEnabled = True
        Me.lbCreditsCreators.Location = New System.Drawing.Point(3, 102)
        Me.lbCreditsCreators.Name = "lbCreditsCreators"
        Me.lbCreditsCreators.ScrollAlwaysVisible = True
        Me.lbCreditsCreators.Size = New System.Drawing.Size(183, 67)
        Me.lbCreditsCreators.TabIndex = 37
        '
        'lblDirectors
        '
        Me.lblDirectors.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDirectors.AutoSize = True
        Me.lblDirectors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblDirectors.Location = New System.Drawing.Point(3, 0)
        Me.lblDirectors.Name = "lblDirectors"
        Me.lblDirectors.Size = New System.Drawing.Size(56, 13)
        Me.lblDirectors.TabIndex = 21
        Me.lblDirectors.Text = "Directors:"
        '
        'lblCreditsCreators
        '
        Me.lblCreditsCreators.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCreditsCreators.AutoSize = True
        Me.lblCreditsCreators.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblCreditsCreators.Location = New System.Drawing.Point(3, 86)
        Me.lblCreditsCreators.Name = "lblCreditsCreators"
        Me.lblCreditsCreators.Size = New System.Drawing.Size(100, 13)
        Me.lblCreditsCreators.TabIndex = 40
        Me.lblCreditsCreators.Text = "Credits / Creators:"
        '
        'lblCountries
        '
        Me.lblCountries.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCountries.AutoSize = True
        Me.lblCountries.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblCountries.Location = New System.Drawing.Point(192, 0)
        Me.lblCountries.Name = "lblCountries"
        Me.lblCountries.Size = New System.Drawing.Size(60, 13)
        Me.lblCountries.TabIndex = 11
        Me.lblCountries.Text = "Countries:"
        '
        'lbCountries
        '
        Me.lbCountries.BackColor = System.Drawing.SystemColors.Window
        Me.lbCountries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbCountries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbCountries.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbCountries.FormattingEnabled = True
        Me.lbCountries.Location = New System.Drawing.Point(192, 16)
        Me.lbCountries.Name = "lbCountries"
        Me.lbCountries.ScrollAlwaysVisible = True
        Me.lbCountries.Size = New System.Drawing.Size(183, 67)
        Me.lbCountries.TabIndex = 37
        '
        'lblStudio
        '
        Me.lblStudio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStudio.AutoSize = True
        Me.lblStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblStudio.Location = New System.Drawing.Point(192, 86)
        Me.lblStudio.Name = "lblStudio"
        Me.lblStudio.Size = New System.Drawing.Size(44, 13)
        Me.lblStudio.TabIndex = 42
        Me.lblStudio.Text = "Studio:"
        '
        'lbStudios
        '
        Me.lbStudios.BackColor = System.Drawing.SystemColors.Window
        Me.lbStudios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbStudios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbStudios.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbStudios.FormattingEnabled = True
        Me.lbStudios.Location = New System.Drawing.Point(192, 102)
        Me.lbStudios.Name = "lbStudios"
        Me.lbStudios.ScrollAlwaysVisible = True
        Me.lbStudios.Size = New System.Drawing.Size(183, 67)
        Me.lbStudios.TabIndex = 37
        '
        'tpMovies
        '
        Me.tpMovies.Controls.Add(Me.pnlMovies)
        Me.tpMovies.Location = New System.Drawing.Point(4, 22)
        Me.tpMovies.Name = "tpMovies"
        Me.tpMovies.Size = New System.Drawing.Size(1176, 526)
        Me.tpMovies.TabIndex = 16
        Me.tpMovies.Text = "Movies"
        Me.tpMovies.UseVisualStyleBackColor = True
        '
        'pnlMovies
        '
        Me.pnlMovies.AutoSize = True
        Me.pnlMovies.Controls.Add(Me.tblMovies)
        Me.pnlMovies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMovies.Location = New System.Drawing.Point(0, 0)
        Me.pnlMovies.Name = "pnlMovies"
        Me.pnlMovies.Size = New System.Drawing.Size(1176, 526)
        Me.pnlMovies.TabIndex = 0
        '
        'tblMovies
        '
        Me.tblMovies.AutoSize = True
        Me.tblMovies.ColumnCount = 9
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovies.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovies.Controls.Add(Me.btnSearchMovie, 8, 2)
        Me.tblMovies.Controls.Add(Me.txtSearchMovies, 7, 2)
        Me.tblMovies.Controls.Add(Me.btnMovieRemove, 5, 2)
        Me.tblMovies.Controls.Add(Me.btnMovieDown, 3, 2)
        Me.tblMovies.Controls.Add(Me.btnMovieUp, 1, 2)
        Me.tblMovies.Controls.Add(Me.dgvMovies, 7, 1)
        Me.tblMovies.Controls.Add(Me.btnMovieAdd, 6, 1)
        Me.tblMovies.Controls.Add(Me.lvMoviesInSet, 0, 1)
        Me.tblMovies.Controls.Add(Me.lblMoviesInDB, 7, 0)
        Me.tblMovies.Controls.Add(Me.lblMoviesInMovieset, 0, 0)
        Me.tblMovies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovies.Location = New System.Drawing.Point(0, 0)
        Me.tblMovies.Name = "tblMovies"
        Me.tblMovies.RowCount = 4
        Me.tblMovies.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovies.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMovies.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovies.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovies.Size = New System.Drawing.Size(1176, 526)
        Me.tblMovies.TabIndex = 0
        '
        'btnSearchMovie
        '
        Me.btnSearchMovie.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSearchMovie.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSearchMovie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearchMovie.Location = New System.Drawing.Point(1040, 500)
        Me.btnSearchMovie.Name = "btnSearchMovie"
        Me.btnSearchMovie.Size = New System.Drawing.Size(124, 23)
        Me.btnSearchMovie.TabIndex = 56
        Me.btnSearchMovie.Text = "Search Movie"
        Me.btnSearchMovie.UseVisualStyleBackColor = True
        '
        'txtSearchMovies
        '
        Me.txtSearchMovies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchMovies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearchMovies.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtSearchMovies.Location = New System.Drawing.Point(686, 500)
        Me.txtSearchMovies.Name = "txtSearchMovies"
        Me.txtSearchMovies.Size = New System.Drawing.Size(348, 22)
        Me.txtSearchMovies.TabIndex = 55
        '
        'btnMovieRemove
        '
        Me.btnMovieRemove.Enabled = False
        Me.btnMovieRemove.Image = CType(resources.GetObject("btnMovieRemove.Image"), System.Drawing.Image)
        Me.btnMovieRemove.Location = New System.Drawing.Point(628, 500)
        Me.btnMovieRemove.Name = "btnMovieRemove"
        Me.btnMovieRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieRemove.TabIndex = 54
        Me.btnMovieRemove.UseVisualStyleBackColor = True
        '
        'btnMovieDown
        '
        Me.btnMovieDown.Enabled = False
        Me.btnMovieDown.Image = CType(resources.GetObject("btnMovieDown.Image"), System.Drawing.Image)
        Me.btnMovieDown.Location = New System.Drawing.Point(410, 500)
        Me.btnMovieDown.Name = "btnMovieDown"
        Me.btnMovieDown.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieDown.TabIndex = 53
        Me.btnMovieDown.UseVisualStyleBackColor = True
        Me.btnMovieDown.Visible = False
        '
        'btnMovieUp
        '
        Me.btnMovieUp.Enabled = False
        Me.btnMovieUp.Image = CType(resources.GetObject("btnMovieUp.Image"), System.Drawing.Image)
        Me.btnMovieUp.Location = New System.Drawing.Point(192, 500)
        Me.btnMovieUp.Name = "btnMovieUp"
        Me.btnMovieUp.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieUp.TabIndex = 52
        Me.btnMovieUp.UseVisualStyleBackColor = True
        Me.btnMovieUp.Visible = False
        '
        'dgvMovies
        '
        Me.dgvMovies.AllowUserToAddRows = False
        Me.dgvMovies.AllowUserToDeleteRows = False
        Me.dgvMovies.AllowUserToResizeColumns = False
        Me.dgvMovies.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.dgvMovies.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMovies.BackgroundColor = System.Drawing.Color.White
        Me.dgvMovies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMovies.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvMovies.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgvMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblMovies.SetColumnSpan(Me.dgvMovies, 2)
        Me.dgvMovies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMovies.GridColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvMovies.Location = New System.Drawing.Point(686, 23)
        Me.dgvMovies.Name = "dgvMovies"
        Me.dgvMovies.ReadOnly = True
        Me.dgvMovies.RowHeadersVisible = False
        Me.dgvMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovies.ShowCellErrors = False
        Me.dgvMovies.ShowRowErrors = False
        Me.dgvMovies.Size = New System.Drawing.Size(487, 471)
        Me.dgvMovies.StandardTab = True
        Me.dgvMovies.TabIndex = 51
        '
        'btnMovieAdd
        '
        Me.btnMovieAdd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMovieAdd.Enabled = False
        Me.btnMovieAdd.Image = CType(resources.GetObject("btnMovieAdd.Image"), System.Drawing.Image)
        Me.btnMovieAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMovieAdd.Location = New System.Drawing.Point(657, 247)
        Me.btnMovieAdd.Name = "btnMovieAdd"
        Me.btnMovieAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieAdd.TabIndex = 50
        Me.btnMovieAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMovieAdd.UseVisualStyleBackColor = True
        '
        'lvMoviesInSet
        '
        Me.lvMoviesInSet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.colOrdering, Me.colMovie})
        Me.tblMovies.SetColumnSpan(Me.lvMoviesInSet, 6)
        Me.lvMoviesInSet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvMoviesInSet.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvMoviesInSet.FullRowSelect = True
        Me.lvMoviesInSet.Location = New System.Drawing.Point(3, 23)
        Me.lvMoviesInSet.Name = "lvMoviesInSet"
        Me.lvMoviesInSet.Size = New System.Drawing.Size(648, 471)
        Me.lvMoviesInSet.TabIndex = 49
        Me.lvMoviesInSet.UseCompatibleStateImageBehavior = False
        Me.lvMoviesInSet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "ID"
        Me.ColumnHeader10.Width = 0
        '
        'colOrdering
        '
        Me.colOrdering.Text = "Ordering"
        Me.colOrdering.Width = 0
        '
        'colMovie
        '
        Me.colMovie.Text = "Movie"
        Me.colMovie.Width = 198
        '
        'lblMoviesInDB
        '
        Me.lblMoviesInDB.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMoviesInDB.AutoSize = True
        Me.tblMovies.SetColumnSpan(Me.lblMoviesInDB, 2)
        Me.lblMoviesInDB.Enabled = False
        Me.lblMoviesInDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMoviesInDB.Location = New System.Drawing.Point(686, 3)
        Me.lblMoviesInDB.Name = "lblMoviesInDB"
        Me.lblMoviesInDB.Size = New System.Drawing.Size(112, 13)
        Me.lblMoviesInDB.TabIndex = 40
        Me.lblMoviesInDB.Text = "Movies in Database:"
        Me.lblMoviesInDB.Visible = False
        '
        'lblMoviesInMovieset
        '
        Me.lblMoviesInMovieset.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMoviesInMovieset.AutoSize = True
        Me.tblMovies.SetColumnSpan(Me.lblMoviesInMovieset, 6)
        Me.lblMoviesInMovieset.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMoviesInMovieset.Location = New System.Drawing.Point(3, 3)
        Me.lblMoviesInMovieset.Name = "lblMoviesInMovieset"
        Me.lblMoviesInMovieset.Size = New System.Drawing.Size(112, 13)
        Me.lblMoviesInMovieset.TabIndex = 29
        Me.lblMoviesInMovieset.Text = "Movies in Movieset:"
        '
        'tpPoster
        '
        Me.tpPoster.Controls.Add(Me.btnSetPosterDL)
        Me.tpPoster.Controls.Add(Me.btnRemovePoster)
        Me.tpPoster.Controls.Add(Me.lblPosterSize)
        Me.tpPoster.Controls.Add(Me.btnSetPosterScrape)
        Me.tpPoster.Controls.Add(Me.btnSetPosterLocal)
        Me.tpPoster.Controls.Add(Me.pbPoster)
        Me.tpPoster.Location = New System.Drawing.Point(4, 22)
        Me.tpPoster.Name = "tpPoster"
        Me.tpPoster.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPoster.Size = New System.Drawing.Size(1176, 526)
        Me.tpPoster.TabIndex = 1
        Me.tpPoster.Text = "Poster"
        Me.tpPoster.UseVisualStyleBackColor = True
        '
        'btnSetPosterDL
        '
        Me.btnSetPosterDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetPosterDL.Image = CType(resources.GetObject("btnSetPosterDL.Image"), System.Drawing.Image)
        Me.btnSetPosterDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetPosterDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetPosterDL.Name = "btnSetPosterDL"
        Me.btnSetPosterDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetPosterDL.TabIndex = 3
        Me.btnSetPosterDL.Text = "Download"
        Me.btnSetPosterDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetPosterDL.UseVisualStyleBackColor = True
        '
        'btnRemovePoster
        '
        Me.btnRemovePoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemovePoster.Image = CType(resources.GetObject("btnRemovePoster.Image"), System.Drawing.Image)
        Me.btnRemovePoster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemovePoster.Location = New System.Drawing.Point(810, 373)
        Me.btnRemovePoster.Name = "btnRemovePoster"
        Me.btnRemovePoster.Size = New System.Drawing.Size(96, 83)
        Me.btnRemovePoster.TabIndex = 4
        Me.btnRemovePoster.Text = "Remove"
        Me.btnRemovePoster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemovePoster.UseVisualStyleBackColor = True
        '
        'lblPosterSize
        '
        Me.lblPosterSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPosterSize.Location = New System.Drawing.Point(8, 8)
        Me.lblPosterSize.Name = "lblPosterSize"
        Me.lblPosterSize.Size = New System.Drawing.Size(105, 23)
        Me.lblPosterSize.TabIndex = 0
        Me.lblPosterSize.Text = "Size: (XXXXxXXXX)"
        Me.lblPosterSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPosterSize.Visible = False
        '
        'btnSetPosterScrape
        '
        Me.btnSetPosterScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetPosterScrape.Image = CType(resources.GetObject("btnSetPosterScrape.Image"), System.Drawing.Image)
        Me.btnSetPosterScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetPosterScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetPosterScrape.Name = "btnSetPosterScrape"
        Me.btnSetPosterScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetPosterScrape.TabIndex = 2
        Me.btnSetPosterScrape.Text = "Scrape"
        Me.btnSetPosterScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetPosterScrape.UseVisualStyleBackColor = True
        '
        'btnSetPosterLocal
        '
        Me.btnSetPosterLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetPosterLocal.Image = CType(resources.GetObject("btnSetPosterLocal.Image"), System.Drawing.Image)
        Me.btnSetPosterLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetPosterLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetPosterLocal.Name = "btnSetPosterLocal"
        Me.btnSetPosterLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetPosterLocal.TabIndex = 1
        Me.btnSetPosterLocal.Text = "Local Browse"
        Me.btnSetPosterLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetPosterLocal.UseVisualStyleBackColor = True
        '
        'pbPoster
        '
        Me.pbPoster.BackColor = System.Drawing.Color.DimGray
        Me.pbPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPoster.Location = New System.Drawing.Point(6, 6)
        Me.pbPoster.Name = "pbPoster"
        Me.pbPoster.Size = New System.Drawing.Size(800, 450)
        Me.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbPoster.TabIndex = 0
        Me.pbPoster.TabStop = False
        '
        'tpBanner
        '
        Me.tpBanner.Controls.Add(Me.btnSetBannerDL)
        Me.tpBanner.Controls.Add(Me.btnRemoveBanner)
        Me.tpBanner.Controls.Add(Me.lblBannerSize)
        Me.tpBanner.Controls.Add(Me.btnSetBannerScrape)
        Me.tpBanner.Controls.Add(Me.btnSetBannerLocal)
        Me.tpBanner.Controls.Add(Me.pbBanner)
        Me.tpBanner.Location = New System.Drawing.Point(4, 22)
        Me.tpBanner.Name = "tpBanner"
        Me.tpBanner.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBanner.Size = New System.Drawing.Size(1176, 526)
        Me.tpBanner.TabIndex = 8
        Me.tpBanner.Text = "Banner"
        Me.tpBanner.UseVisualStyleBackColor = True
        '
        'btnSetBannerDL
        '
        Me.btnSetBannerDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetBannerDL.Image = CType(resources.GetObject("btnSetBannerDL.Image"), System.Drawing.Image)
        Me.btnSetBannerDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetBannerDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetBannerDL.Name = "btnSetBannerDL"
        Me.btnSetBannerDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetBannerDL.TabIndex = 9
        Me.btnSetBannerDL.Text = "Download"
        Me.btnSetBannerDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetBannerDL.UseVisualStyleBackColor = True
        '
        'btnRemoveBanner
        '
        Me.btnRemoveBanner.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveBanner.Image = CType(resources.GetObject("btnRemoveBanner.Image"), System.Drawing.Image)
        Me.btnRemoveBanner.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveBanner.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveBanner.Name = "btnRemoveBanner"
        Me.btnRemoveBanner.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveBanner.TabIndex = 10
        Me.btnRemoveBanner.Text = "Remove"
        Me.btnRemoveBanner.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveBanner.UseVisualStyleBackColor = True
        '
        'lblBannerSize
        '
        Me.lblBannerSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBannerSize.Location = New System.Drawing.Point(8, 8)
        Me.lblBannerSize.Name = "lblBannerSize"
        Me.lblBannerSize.Size = New System.Drawing.Size(105, 23)
        Me.lblBannerSize.TabIndex = 5
        Me.lblBannerSize.Text = "Size: (XXXXxXXXX)"
        Me.lblBannerSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblBannerSize.Visible = False
        '
        'btnSetBannerScrape
        '
        Me.btnSetBannerScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetBannerScrape.Image = CType(resources.GetObject("btnSetBannerScrape.Image"), System.Drawing.Image)
        Me.btnSetBannerScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetBannerScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetBannerScrape.Name = "btnSetBannerScrape"
        Me.btnSetBannerScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetBannerScrape.TabIndex = 8
        Me.btnSetBannerScrape.Text = "Scrape"
        Me.btnSetBannerScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetBannerScrape.UseVisualStyleBackColor = True
        '
        'btnSetBannerLocal
        '
        Me.btnSetBannerLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetBannerLocal.Image = CType(resources.GetObject("btnSetBannerLocal.Image"), System.Drawing.Image)
        Me.btnSetBannerLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetBannerLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetBannerLocal.Name = "btnSetBannerLocal"
        Me.btnSetBannerLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetBannerLocal.TabIndex = 7
        Me.btnSetBannerLocal.Text = "Local Browse"
        Me.btnSetBannerLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetBannerLocal.UseVisualStyleBackColor = True
        '
        'pbBanner
        '
        Me.pbBanner.BackColor = System.Drawing.Color.DimGray
        Me.pbBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBanner.Location = New System.Drawing.Point(6, 6)
        Me.pbBanner.Name = "pbBanner"
        Me.pbBanner.Size = New System.Drawing.Size(800, 450)
        Me.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbBanner.TabIndex = 6
        Me.pbBanner.TabStop = False
        '
        'tpLandscape
        '
        Me.tpLandscape.Controls.Add(Me.btnSetLandscapeDL)
        Me.tpLandscape.Controls.Add(Me.btnRemoveLandscape)
        Me.tpLandscape.Controls.Add(Me.lblLandscapeSize)
        Me.tpLandscape.Controls.Add(Me.btnSetLandscapeScrape)
        Me.tpLandscape.Controls.Add(Me.btnSetLandscapeLocal)
        Me.tpLandscape.Controls.Add(Me.pbLandscape)
        Me.tpLandscape.Location = New System.Drawing.Point(4, 22)
        Me.tpLandscape.Name = "tpLandscape"
        Me.tpLandscape.Size = New System.Drawing.Size(1176, 526)
        Me.tpLandscape.TabIndex = 9
        Me.tpLandscape.Text = "Landscape"
        Me.tpLandscape.UseVisualStyleBackColor = True
        '
        'btnSetLandscapeDL
        '
        Me.btnSetLandscapeDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetLandscapeDL.Image = CType(resources.GetObject("btnSetLandscapeDL.Image"), System.Drawing.Image)
        Me.btnSetLandscapeDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetLandscapeDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetLandscapeDL.Name = "btnSetLandscapeDL"
        Me.btnSetLandscapeDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetLandscapeDL.TabIndex = 9
        Me.btnSetLandscapeDL.Text = "Download"
        Me.btnSetLandscapeDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetLandscapeDL.UseVisualStyleBackColor = True
        '
        'btnRemoveLandscape
        '
        Me.btnRemoveLandscape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveLandscape.Image = CType(resources.GetObject("btnRemoveLandscape.Image"), System.Drawing.Image)
        Me.btnRemoveLandscape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveLandscape.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveLandscape.Name = "btnRemoveLandscape"
        Me.btnRemoveLandscape.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveLandscape.TabIndex = 10
        Me.btnRemoveLandscape.Text = "Remove"
        Me.btnRemoveLandscape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveLandscape.UseVisualStyleBackColor = True
        '
        'lblLandscapeSize
        '
        Me.lblLandscapeSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLandscapeSize.Location = New System.Drawing.Point(8, 8)
        Me.lblLandscapeSize.Name = "lblLandscapeSize"
        Me.lblLandscapeSize.Size = New System.Drawing.Size(105, 23)
        Me.lblLandscapeSize.TabIndex = 5
        Me.lblLandscapeSize.Text = "Size: (XXXXxXXXX)"
        Me.lblLandscapeSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLandscapeSize.Visible = False
        '
        'btnSetLandscapeScrape
        '
        Me.btnSetLandscapeScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetLandscapeScrape.Image = CType(resources.GetObject("btnSetLandscapeScrape.Image"), System.Drawing.Image)
        Me.btnSetLandscapeScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetLandscapeScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetLandscapeScrape.Name = "btnSetLandscapeScrape"
        Me.btnSetLandscapeScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetLandscapeScrape.TabIndex = 8
        Me.btnSetLandscapeScrape.Text = "Scrape"
        Me.btnSetLandscapeScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetLandscapeScrape.UseVisualStyleBackColor = True
        '
        'btnSetLandscapeLocal
        '
        Me.btnSetLandscapeLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetLandscapeLocal.Image = CType(resources.GetObject("btnSetLandscapeLocal.Image"), System.Drawing.Image)
        Me.btnSetLandscapeLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetLandscapeLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetLandscapeLocal.Name = "btnSetLandscapeLocal"
        Me.btnSetLandscapeLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetLandscapeLocal.TabIndex = 7
        Me.btnSetLandscapeLocal.Text = "Local Browse"
        Me.btnSetLandscapeLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetLandscapeLocal.UseVisualStyleBackColor = True
        '
        'pbLandscape
        '
        Me.pbLandscape.BackColor = System.Drawing.Color.DimGray
        Me.pbLandscape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbLandscape.Location = New System.Drawing.Point(6, 6)
        Me.pbLandscape.Name = "pbLandscape"
        Me.pbLandscape.Size = New System.Drawing.Size(800, 450)
        Me.pbLandscape.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLandscape.TabIndex = 6
        Me.pbLandscape.TabStop = False
        '
        'tpClearArt
        '
        Me.tpClearArt.Controls.Add(Me.btnSetClearArtDL)
        Me.tpClearArt.Controls.Add(Me.btnRemoveClearArt)
        Me.tpClearArt.Controls.Add(Me.lblClearArtSize)
        Me.tpClearArt.Controls.Add(Me.btnSetClearArtScrape)
        Me.tpClearArt.Controls.Add(Me.btnSetClearArtLocal)
        Me.tpClearArt.Controls.Add(Me.pbClearArt)
        Me.tpClearArt.Location = New System.Drawing.Point(4, 22)
        Me.tpClearArt.Name = "tpClearArt"
        Me.tpClearArt.Size = New System.Drawing.Size(1176, 526)
        Me.tpClearArt.TabIndex = 11
        Me.tpClearArt.Text = "ClearArt"
        Me.tpClearArt.UseVisualStyleBackColor = True
        '
        'btnSetClearArtDL
        '
        Me.btnSetClearArtDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetClearArtDL.Image = CType(resources.GetObject("btnSetClearArtDL.Image"), System.Drawing.Image)
        Me.btnSetClearArtDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetClearArtDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetClearArtDL.Name = "btnSetClearArtDL"
        Me.btnSetClearArtDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetClearArtDL.TabIndex = 9
        Me.btnSetClearArtDL.Text = "Download"
        Me.btnSetClearArtDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetClearArtDL.UseVisualStyleBackColor = True
        '
        'btnRemoveClearArt
        '
        Me.btnRemoveClearArt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveClearArt.Image = CType(resources.GetObject("btnRemoveClearArt.Image"), System.Drawing.Image)
        Me.btnRemoveClearArt.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveClearArt.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveClearArt.Name = "btnRemoveClearArt"
        Me.btnRemoveClearArt.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveClearArt.TabIndex = 10
        Me.btnRemoveClearArt.Text = "Remove"
        Me.btnRemoveClearArt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveClearArt.UseVisualStyleBackColor = True
        '
        'lblClearArtSize
        '
        Me.lblClearArtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClearArtSize.Location = New System.Drawing.Point(8, 8)
        Me.lblClearArtSize.Name = "lblClearArtSize"
        Me.lblClearArtSize.Size = New System.Drawing.Size(105, 23)
        Me.lblClearArtSize.TabIndex = 5
        Me.lblClearArtSize.Text = "Size: (XXXXxXXXX)"
        Me.lblClearArtSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblClearArtSize.Visible = False
        '
        'btnSetClearArtScrape
        '
        Me.btnSetClearArtScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetClearArtScrape.Image = CType(resources.GetObject("btnSetClearArtScrape.Image"), System.Drawing.Image)
        Me.btnSetClearArtScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetClearArtScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetClearArtScrape.Name = "btnSetClearArtScrape"
        Me.btnSetClearArtScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetClearArtScrape.TabIndex = 8
        Me.btnSetClearArtScrape.Text = "Scrape"
        Me.btnSetClearArtScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetClearArtScrape.UseVisualStyleBackColor = True
        '
        'btnSetClearArtLocal
        '
        Me.btnSetClearArtLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetClearArtLocal.Image = CType(resources.GetObject("btnSetClearArtLocal.Image"), System.Drawing.Image)
        Me.btnSetClearArtLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetClearArtLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetClearArtLocal.Name = "btnSetClearArtLocal"
        Me.btnSetClearArtLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetClearArtLocal.TabIndex = 7
        Me.btnSetClearArtLocal.Text = "Local Browse"
        Me.btnSetClearArtLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetClearArtLocal.UseVisualStyleBackColor = True
        '
        'pbClearArt
        '
        Me.pbClearArt.BackColor = System.Drawing.Color.DimGray
        Me.pbClearArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbClearArt.Location = New System.Drawing.Point(6, 6)
        Me.pbClearArt.Name = "pbClearArt"
        Me.pbClearArt.Size = New System.Drawing.Size(800, 450)
        Me.pbClearArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbClearArt.TabIndex = 6
        Me.pbClearArt.TabStop = False
        '
        'tpClearLogo
        '
        Me.tpClearLogo.Controls.Add(Me.btnSetClearLogoDL)
        Me.tpClearLogo.Controls.Add(Me.btnRemoveClearLogo)
        Me.tpClearLogo.Controls.Add(Me.lblClearLogoSize)
        Me.tpClearLogo.Controls.Add(Me.btnSetClearLogoScrape)
        Me.tpClearLogo.Controls.Add(Me.btnSetClearLogoLocal)
        Me.tpClearLogo.Controls.Add(Me.pbClearLogo)
        Me.tpClearLogo.Location = New System.Drawing.Point(4, 22)
        Me.tpClearLogo.Name = "tpClearLogo"
        Me.tpClearLogo.Size = New System.Drawing.Size(1176, 526)
        Me.tpClearLogo.TabIndex = 12
        Me.tpClearLogo.Text = "ClearLogo"
        Me.tpClearLogo.UseVisualStyleBackColor = True
        '
        'btnSetClearLogoDL
        '
        Me.btnSetClearLogoDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetClearLogoDL.Image = CType(resources.GetObject("btnSetClearLogoDL.Image"), System.Drawing.Image)
        Me.btnSetClearLogoDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetClearLogoDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetClearLogoDL.Name = "btnSetClearLogoDL"
        Me.btnSetClearLogoDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetClearLogoDL.TabIndex = 9
        Me.btnSetClearLogoDL.Text = "Download"
        Me.btnSetClearLogoDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetClearLogoDL.UseVisualStyleBackColor = True
        '
        'btnRemoveClearLogo
        '
        Me.btnRemoveClearLogo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveClearLogo.Image = CType(resources.GetObject("btnRemoveClearLogo.Image"), System.Drawing.Image)
        Me.btnRemoveClearLogo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveClearLogo.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveClearLogo.Name = "btnRemoveClearLogo"
        Me.btnRemoveClearLogo.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveClearLogo.TabIndex = 10
        Me.btnRemoveClearLogo.Text = "Remove"
        Me.btnRemoveClearLogo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveClearLogo.UseVisualStyleBackColor = True
        '
        'lblClearLogoSize
        '
        Me.lblClearLogoSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClearLogoSize.Location = New System.Drawing.Point(8, 8)
        Me.lblClearLogoSize.Name = "lblClearLogoSize"
        Me.lblClearLogoSize.Size = New System.Drawing.Size(105, 23)
        Me.lblClearLogoSize.TabIndex = 5
        Me.lblClearLogoSize.Text = "Size: (XXXXxXXXX)"
        Me.lblClearLogoSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblClearLogoSize.Visible = False
        '
        'btnSetClearLogoScrape
        '
        Me.btnSetClearLogoScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetClearLogoScrape.Image = CType(resources.GetObject("btnSetClearLogoScrape.Image"), System.Drawing.Image)
        Me.btnSetClearLogoScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetClearLogoScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetClearLogoScrape.Name = "btnSetClearLogoScrape"
        Me.btnSetClearLogoScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetClearLogoScrape.TabIndex = 8
        Me.btnSetClearLogoScrape.Text = "Scrape"
        Me.btnSetClearLogoScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetClearLogoScrape.UseVisualStyleBackColor = True
        '
        'btnSetClearLogoLocal
        '
        Me.btnSetClearLogoLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetClearLogoLocal.Image = CType(resources.GetObject("btnSetClearLogoLocal.Image"), System.Drawing.Image)
        Me.btnSetClearLogoLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetClearLogoLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetClearLogoLocal.Name = "btnSetClearLogoLocal"
        Me.btnSetClearLogoLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetClearLogoLocal.TabIndex = 7
        Me.btnSetClearLogoLocal.Text = "Local Browse"
        Me.btnSetClearLogoLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetClearLogoLocal.UseVisualStyleBackColor = True
        '
        'pbClearLogo
        '
        Me.pbClearLogo.BackColor = System.Drawing.Color.DimGray
        Me.pbClearLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbClearLogo.Location = New System.Drawing.Point(6, 6)
        Me.pbClearLogo.Name = "pbClearLogo"
        Me.pbClearLogo.Size = New System.Drawing.Size(800, 450)
        Me.pbClearLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbClearLogo.TabIndex = 6
        Me.pbClearLogo.TabStop = False
        '
        'tpDiscArt
        '
        Me.tpDiscArt.Controls.Add(Me.btnSetDiscArtDL)
        Me.tpDiscArt.Controls.Add(Me.btnRemoveDiscArt)
        Me.tpDiscArt.Controls.Add(Me.lblDiscArtSize)
        Me.tpDiscArt.Controls.Add(Me.btnSetDiscArtScrape)
        Me.tpDiscArt.Controls.Add(Me.btnSetDiscArtLocal)
        Me.tpDiscArt.Controls.Add(Me.pbDiscArt)
        Me.tpDiscArt.Location = New System.Drawing.Point(4, 22)
        Me.tpDiscArt.Name = "tpDiscArt"
        Me.tpDiscArt.Size = New System.Drawing.Size(1176, 526)
        Me.tpDiscArt.TabIndex = 10
        Me.tpDiscArt.Text = "DiscArt"
        Me.tpDiscArt.UseVisualStyleBackColor = True
        '
        'btnSetDiscArtDL
        '
        Me.btnSetDiscArtDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetDiscArtDL.Image = CType(resources.GetObject("btnSetDiscArtDL.Image"), System.Drawing.Image)
        Me.btnSetDiscArtDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetDiscArtDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetDiscArtDL.Name = "btnSetDiscArtDL"
        Me.btnSetDiscArtDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetDiscArtDL.TabIndex = 9
        Me.btnSetDiscArtDL.Text = "Download"
        Me.btnSetDiscArtDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetDiscArtDL.UseVisualStyleBackColor = True
        '
        'btnRemoveDiscArt
        '
        Me.btnRemoveDiscArt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveDiscArt.Image = CType(resources.GetObject("btnRemoveDiscArt.Image"), System.Drawing.Image)
        Me.btnRemoveDiscArt.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveDiscArt.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveDiscArt.Name = "btnRemoveDiscArt"
        Me.btnRemoveDiscArt.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveDiscArt.TabIndex = 10
        Me.btnRemoveDiscArt.Text = "Remove"
        Me.btnRemoveDiscArt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveDiscArt.UseVisualStyleBackColor = True
        '
        'lblDiscArtSize
        '
        Me.lblDiscArtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiscArtSize.Location = New System.Drawing.Point(8, 8)
        Me.lblDiscArtSize.Name = "lblDiscArtSize"
        Me.lblDiscArtSize.Size = New System.Drawing.Size(105, 23)
        Me.lblDiscArtSize.TabIndex = 5
        Me.lblDiscArtSize.Text = "Size: (XXXXxXXXX)"
        Me.lblDiscArtSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDiscArtSize.Visible = False
        '
        'btnSetDiscArtScrape
        '
        Me.btnSetDiscArtScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetDiscArtScrape.Image = CType(resources.GetObject("btnSetDiscArtScrape.Image"), System.Drawing.Image)
        Me.btnSetDiscArtScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetDiscArtScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetDiscArtScrape.Name = "btnSetDiscArtScrape"
        Me.btnSetDiscArtScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetDiscArtScrape.TabIndex = 8
        Me.btnSetDiscArtScrape.Text = "Scrape"
        Me.btnSetDiscArtScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetDiscArtScrape.UseVisualStyleBackColor = True
        '
        'btnSetDiscArtLocal
        '
        Me.btnSetDiscArtLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetDiscArtLocal.Image = CType(resources.GetObject("btnSetDiscArtLocal.Image"), System.Drawing.Image)
        Me.btnSetDiscArtLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetDiscArtLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetDiscArtLocal.Name = "btnSetDiscArtLocal"
        Me.btnSetDiscArtLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetDiscArtLocal.TabIndex = 7
        Me.btnSetDiscArtLocal.Text = "Local Browse"
        Me.btnSetDiscArtLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetDiscArtLocal.UseVisualStyleBackColor = True
        '
        'pbDiscArt
        '
        Me.pbDiscArt.BackColor = System.Drawing.Color.DimGray
        Me.pbDiscArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbDiscArt.Location = New System.Drawing.Point(6, 6)
        Me.pbDiscArt.Name = "pbDiscArt"
        Me.pbDiscArt.Size = New System.Drawing.Size(800, 450)
        Me.pbDiscArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbDiscArt.TabIndex = 6
        Me.pbDiscArt.TabStop = False
        '
        'tpFanart
        '
        Me.tpFanart.Controls.Add(Me.btnSetFanartDL)
        Me.tpFanart.Controls.Add(Me.btnRemoveFanart)
        Me.tpFanart.Controls.Add(Me.lblFanartSize)
        Me.tpFanart.Controls.Add(Me.btnSetFanartScrape)
        Me.tpFanart.Controls.Add(Me.btnSetFanartLocal)
        Me.tpFanart.Controls.Add(Me.pbFanart)
        Me.tpFanart.Location = New System.Drawing.Point(4, 22)
        Me.tpFanart.Name = "tpFanart"
        Me.tpFanart.Size = New System.Drawing.Size(1176, 526)
        Me.tpFanart.TabIndex = 2
        Me.tpFanart.Text = "Fanart"
        Me.tpFanart.UseVisualStyleBackColor = True
        '
        'btnSetFanartDL
        '
        Me.btnSetFanartDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetFanartDL.Image = CType(resources.GetObject("btnSetFanartDL.Image"), System.Drawing.Image)
        Me.btnSetFanartDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetFanartDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetFanartDL.Name = "btnSetFanartDL"
        Me.btnSetFanartDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetFanartDL.TabIndex = 3
        Me.btnSetFanartDL.Text = "Download"
        Me.btnSetFanartDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetFanartDL.UseVisualStyleBackColor = True
        '
        'btnRemoveFanart
        '
        Me.btnRemoveFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveFanart.Image = CType(resources.GetObject("btnRemoveFanart.Image"), System.Drawing.Image)
        Me.btnRemoveFanart.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveFanart.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveFanart.Name = "btnRemoveFanart"
        Me.btnRemoveFanart.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveFanart.TabIndex = 4
        Me.btnRemoveFanart.Text = "Remove"
        Me.btnRemoveFanart.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveFanart.UseVisualStyleBackColor = True
        '
        'lblFanartSize
        '
        Me.lblFanartSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFanartSize.Location = New System.Drawing.Point(8, 8)
        Me.lblFanartSize.Name = "lblFanartSize"
        Me.lblFanartSize.Size = New System.Drawing.Size(105, 23)
        Me.lblFanartSize.TabIndex = 0
        Me.lblFanartSize.Text = "Size: (XXXXxXXXX)"
        Me.lblFanartSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFanartSize.Visible = False
        '
        'btnSetFanartScrape
        '
        Me.btnSetFanartScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetFanartScrape.Image = CType(resources.GetObject("btnSetFanartScrape.Image"), System.Drawing.Image)
        Me.btnSetFanartScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetFanartScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetFanartScrape.Name = "btnSetFanartScrape"
        Me.btnSetFanartScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetFanartScrape.TabIndex = 2
        Me.btnSetFanartScrape.Text = "Scrape"
        Me.btnSetFanartScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetFanartScrape.UseVisualStyleBackColor = True
        '
        'btnSetFanartLocal
        '
        Me.btnSetFanartLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetFanartLocal.Image = CType(resources.GetObject("btnSetFanartLocal.Image"), System.Drawing.Image)
        Me.btnSetFanartLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetFanartLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetFanartLocal.Name = "btnSetFanartLocal"
        Me.btnSetFanartLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetFanartLocal.TabIndex = 1
        Me.btnSetFanartLocal.Text = "Local Browse"
        Me.btnSetFanartLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetFanartLocal.UseVisualStyleBackColor = True
        '
        'pbFanart
        '
        Me.pbFanart.BackColor = System.Drawing.Color.DimGray
        Me.pbFanart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFanart.Location = New System.Drawing.Point(6, 6)
        Me.pbFanart.Name = "pbFanart"
        Me.pbFanart.Size = New System.Drawing.Size(800, 450)
        Me.pbFanart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFanart.TabIndex = 1
        Me.pbFanart.TabStop = False
        '
        'tpExtrafanarts
        '
        Me.tpExtrafanarts.Controls.Add(Me.btnSetExtrafanartsScrape)
        Me.tpExtrafanarts.Controls.Add(Me.lblExtrafanartsSize)
        Me.tpExtrafanarts.Controls.Add(Me.pnlExtrafanarts)
        Me.tpExtrafanarts.Controls.Add(Me.pnlExtrafanartsSetAsFanart)
        Me.tpExtrafanarts.Controls.Add(Me.btnExtrafanartsRefresh)
        Me.tpExtrafanarts.Controls.Add(Me.btnExtrafanartsRemove)
        Me.tpExtrafanarts.Controls.Add(Me.pbExtrafanarts)
        Me.tpExtrafanarts.Location = New System.Drawing.Point(4, 22)
        Me.tpExtrafanarts.Name = "tpExtrafanarts"
        Me.tpExtrafanarts.Padding = New System.Windows.Forms.Padding(3)
        Me.tpExtrafanarts.Size = New System.Drawing.Size(1176, 526)
        Me.tpExtrafanarts.TabIndex = 6
        Me.tpExtrafanarts.Text = "Extrafanarts"
        Me.tpExtrafanarts.UseVisualStyleBackColor = True
        '
        'btnSetExtrafanartsScrape
        '
        Me.btnSetExtrafanartsScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetExtrafanartsScrape.Image = CType(resources.GetObject("btnSetExtrafanartsScrape.Image"), System.Drawing.Image)
        Me.btnSetExtrafanartsScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetExtrafanartsScrape.Location = New System.Drawing.Point(882, 95)
        Me.btnSetExtrafanartsScrape.Name = "btnSetExtrafanartsScrape"
        Me.btnSetExtrafanartsScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetExtrafanartsScrape.TabIndex = 17
        Me.btnSetExtrafanartsScrape.Text = "Scrape"
        Me.btnSetExtrafanartsScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetExtrafanartsScrape.UseVisualStyleBackColor = True
        '
        'lblExtrafanartsSize
        '
        Me.lblExtrafanartsSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExtrafanartsSize.Location = New System.Drawing.Point(178, 10)
        Me.lblExtrafanartsSize.Name = "lblExtrafanartsSize"
        Me.lblExtrafanartsSize.Size = New System.Drawing.Size(105, 23)
        Me.lblExtrafanartsSize.TabIndex = 16
        Me.lblExtrafanartsSize.Text = "Size: (XXXXxXXXX)"
        Me.lblExtrafanartsSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblExtrafanartsSize.Visible = False
        '
        'pnlExtrafanarts
        '
        Me.pnlExtrafanarts.AutoScroll = True
        Me.pnlExtrafanarts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExtrafanarts.Location = New System.Drawing.Point(5, 8)
        Me.pnlExtrafanarts.Name = "pnlExtrafanarts"
        Me.pnlExtrafanarts.Size = New System.Drawing.Size(165, 394)
        Me.pnlExtrafanarts.TabIndex = 15
        '
        'pnlExtrafanartsSetAsFanart
        '
        Me.pnlExtrafanartsSetAsFanart.BackColor = System.Drawing.Color.LightGray
        Me.pnlExtrafanartsSetAsFanart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExtrafanartsSetAsFanart.Controls.Add(Me.btnExtrafanartsSetAsFanart)
        Me.pnlExtrafanartsSetAsFanart.Location = New System.Drawing.Point(767, 363)
        Me.pnlExtrafanartsSetAsFanart.Name = "pnlExtrafanartsSetAsFanart"
        Me.pnlExtrafanartsSetAsFanart.Size = New System.Drawing.Size(109, 39)
        Me.pnlExtrafanartsSetAsFanart.TabIndex = 14
        '
        'btnExtrafanartsSetAsFanart
        '
        Me.btnExtrafanartsSetAsFanart.Enabled = False
        Me.btnExtrafanartsSetAsFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnExtrafanartsSetAsFanart.Image = CType(resources.GetObject("btnExtrafanartsSetAsFanart.Image"), System.Drawing.Image)
        Me.btnExtrafanartsSetAsFanart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtrafanartsSetAsFanart.Location = New System.Drawing.Point(2, 3)
        Me.btnExtrafanartsSetAsFanart.Name = "btnExtrafanartsSetAsFanart"
        Me.btnExtrafanartsSetAsFanart.Size = New System.Drawing.Size(103, 32)
        Me.btnExtrafanartsSetAsFanart.TabIndex = 0
        Me.btnExtrafanartsSetAsFanart.Text = "Set As Fanart"
        Me.btnExtrafanartsSetAsFanart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExtrafanartsSetAsFanart.UseVisualStyleBackColor = True
        '
        'btnExtrafanartsRefresh
        '
        Me.btnExtrafanartsRefresh.Image = CType(resources.GetObject("btnExtrafanartsRefresh.Image"), System.Drawing.Image)
        Me.btnExtrafanartsRefresh.Location = New System.Drawing.Point(5, 408)
        Me.btnExtrafanartsRefresh.Name = "btnExtrafanartsRefresh"
        Me.btnExtrafanartsRefresh.Size = New System.Drawing.Size(23, 23)
        Me.btnExtrafanartsRefresh.TabIndex = 12
        Me.btnExtrafanartsRefresh.UseVisualStyleBackColor = True
        '
        'btnExtrafanartsRemove
        '
        Me.btnExtrafanartsRemove.Image = CType(resources.GetObject("btnExtrafanartsRemove.Image"), System.Drawing.Image)
        Me.btnExtrafanartsRemove.Location = New System.Drawing.Point(147, 408)
        Me.btnExtrafanartsRemove.Name = "btnExtrafanartsRemove"
        Me.btnExtrafanartsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnExtrafanartsRemove.TabIndex = 13
        Me.btnExtrafanartsRemove.UseVisualStyleBackColor = True
        '
        'pbExtrafanarts
        '
        Me.pbExtrafanarts.BackColor = System.Drawing.Color.DimGray
        Me.pbExtrafanarts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbExtrafanarts.Location = New System.Drawing.Point(176, 8)
        Me.pbExtrafanarts.Name = "pbExtrafanarts"
        Me.pbExtrafanarts.Size = New System.Drawing.Size(700, 394)
        Me.pbExtrafanarts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbExtrafanarts.TabIndex = 10
        Me.pbExtrafanarts.TabStop = False
        '
        'tpExtrathumbs
        '
        Me.tpExtrathumbs.Controls.Add(Me.btnSetExtrathumbsScrape)
        Me.tpExtrathumbs.Controls.Add(Me.lblExtrathumbsSize)
        Me.tpExtrathumbs.Controls.Add(Me.pnlExtrathumbs)
        Me.tpExtrathumbs.Controls.Add(Me.pnlExtrathumbsSetAsFanart)
        Me.tpExtrathumbs.Controls.Add(Me.btnExtrathumbsRefresh)
        Me.tpExtrathumbs.Controls.Add(Me.btnExtrathumbsRemove)
        Me.tpExtrathumbs.Controls.Add(Me.btnExtrathumbsDown)
        Me.tpExtrathumbs.Controls.Add(Me.btnExtrathumbsUp)
        Me.tpExtrathumbs.Controls.Add(Me.pbExtrathumbs)
        Me.tpExtrathumbs.Location = New System.Drawing.Point(4, 22)
        Me.tpExtrathumbs.Name = "tpExtrathumbs"
        Me.tpExtrathumbs.Size = New System.Drawing.Size(1176, 526)
        Me.tpExtrathumbs.TabIndex = 4
        Me.tpExtrathumbs.Text = "Extrathumbs"
        Me.tpExtrathumbs.UseVisualStyleBackColor = True
        '
        'btnSetExtrathumbsScrape
        '
        Me.btnSetExtrathumbsScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetExtrathumbsScrape.Image = CType(resources.GetObject("btnSetExtrathumbsScrape.Image"), System.Drawing.Image)
        Me.btnSetExtrathumbsScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetExtrathumbsScrape.Location = New System.Drawing.Point(882, 95)
        Me.btnSetExtrathumbsScrape.Name = "btnSetExtrathumbsScrape"
        Me.btnSetExtrathumbsScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetExtrathumbsScrape.TabIndex = 18
        Me.btnSetExtrathumbsScrape.Text = "Scrape"
        Me.btnSetExtrathumbsScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetExtrathumbsScrape.UseVisualStyleBackColor = True
        '
        'lblExtrathumbsSize
        '
        Me.lblExtrathumbsSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExtrathumbsSize.Location = New System.Drawing.Point(178, 10)
        Me.lblExtrathumbsSize.Name = "lblExtrathumbsSize"
        Me.lblExtrathumbsSize.Size = New System.Drawing.Size(105, 23)
        Me.lblExtrathumbsSize.TabIndex = 17
        Me.lblExtrathumbsSize.Text = "Size: (XXXXxXXXX)"
        Me.lblExtrathumbsSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblExtrathumbsSize.Visible = False
        '
        'pnlExtrathumbs
        '
        Me.pnlExtrathumbs.AutoScroll = True
        Me.pnlExtrathumbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExtrathumbs.Location = New System.Drawing.Point(5, 8)
        Me.pnlExtrathumbs.Name = "pnlExtrathumbs"
        Me.pnlExtrathumbs.Size = New System.Drawing.Size(165, 394)
        Me.pnlExtrathumbs.TabIndex = 7
        '
        'pnlExtrathumbsSetAsFanart
        '
        Me.pnlExtrathumbsSetAsFanart.BackColor = System.Drawing.Color.LightGray
        Me.pnlExtrathumbsSetAsFanart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExtrathumbsSetAsFanart.Controls.Add(Me.btnExtrathumbsSetAsFanart)
        Me.pnlExtrathumbsSetAsFanart.Location = New System.Drawing.Point(767, 363)
        Me.pnlExtrathumbsSetAsFanart.Name = "pnlExtrathumbsSetAsFanart"
        Me.pnlExtrathumbsSetAsFanart.Size = New System.Drawing.Size(109, 39)
        Me.pnlExtrathumbsSetAsFanart.TabIndex = 6
        '
        'btnExtrathumbsSetAsFanart
        '
        Me.btnExtrathumbsSetAsFanart.Enabled = False
        Me.btnExtrathumbsSetAsFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnExtrathumbsSetAsFanart.Image = CType(resources.GetObject("btnExtrathumbsSetAsFanart.Image"), System.Drawing.Image)
        Me.btnExtrathumbsSetAsFanart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtrathumbsSetAsFanart.Location = New System.Drawing.Point(2, 3)
        Me.btnExtrathumbsSetAsFanart.Name = "btnExtrathumbsSetAsFanart"
        Me.btnExtrathumbsSetAsFanart.Size = New System.Drawing.Size(103, 32)
        Me.btnExtrathumbsSetAsFanart.TabIndex = 0
        Me.btnExtrathumbsSetAsFanart.Text = "Set As Fanart"
        Me.btnExtrathumbsSetAsFanart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExtrathumbsSetAsFanart.UseVisualStyleBackColor = True
        '
        'btnExtrathumbsRefresh
        '
        Me.btnExtrathumbsRefresh.Image = CType(resources.GetObject("btnExtrathumbsRefresh.Image"), System.Drawing.Image)
        Me.btnExtrathumbsRefresh.Location = New System.Drawing.Point(5, 408)
        Me.btnExtrathumbsRefresh.Name = "btnExtrathumbsRefresh"
        Me.btnExtrathumbsRefresh.Size = New System.Drawing.Size(23, 23)
        Me.btnExtrathumbsRefresh.TabIndex = 4
        Me.btnExtrathumbsRefresh.UseVisualStyleBackColor = True
        '
        'btnExtrathumbsRemove
        '
        Me.btnExtrathumbsRemove.Image = CType(resources.GetObject("btnExtrathumbsRemove.Image"), System.Drawing.Image)
        Me.btnExtrathumbsRemove.Location = New System.Drawing.Point(147, 408)
        Me.btnExtrathumbsRemove.Name = "btnExtrathumbsRemove"
        Me.btnExtrathumbsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnExtrathumbsRemove.TabIndex = 5
        Me.btnExtrathumbsRemove.UseVisualStyleBackColor = True
        '
        'btnExtrathumbsDown
        '
        Me.btnExtrathumbsDown.Enabled = False
        Me.btnExtrathumbsDown.Image = CType(resources.GetObject("btnExtrathumbsDown.Image"), System.Drawing.Image)
        Me.btnExtrathumbsDown.Location = New System.Drawing.Point(88, 408)
        Me.btnExtrathumbsDown.Name = "btnExtrathumbsDown"
        Me.btnExtrathumbsDown.Size = New System.Drawing.Size(23, 23)
        Me.btnExtrathumbsDown.TabIndex = 3
        Me.btnExtrathumbsDown.UseVisualStyleBackColor = True
        '
        'btnExtrathumbsUp
        '
        Me.btnExtrathumbsUp.Enabled = False
        Me.btnExtrathumbsUp.Image = CType(resources.GetObject("btnExtrathumbsUp.Image"), System.Drawing.Image)
        Me.btnExtrathumbsUp.Location = New System.Drawing.Point(59, 408)
        Me.btnExtrathumbsUp.Name = "btnExtrathumbsUp"
        Me.btnExtrathumbsUp.Size = New System.Drawing.Size(23, 23)
        Me.btnExtrathumbsUp.TabIndex = 2
        Me.btnExtrathumbsUp.UseVisualStyleBackColor = True
        '
        'pbExtrathumbs
        '
        Me.pbExtrathumbs.BackColor = System.Drawing.Color.DimGray
        Me.pbExtrathumbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbExtrathumbs.Location = New System.Drawing.Point(176, 8)
        Me.pbExtrathumbs.Name = "pbExtrathumbs"
        Me.pbExtrathumbs.Size = New System.Drawing.Size(700, 394)
        Me.pbExtrathumbs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbExtrathumbs.TabIndex = 2
        Me.pbExtrathumbs.TabStop = False
        '
        'tpFrameExtraction
        '
        Me.tpFrameExtraction.Controls.Add(Me.pnlFrameExtrator)
        Me.tpFrameExtraction.Location = New System.Drawing.Point(4, 22)
        Me.tpFrameExtraction.Name = "tpFrameExtraction"
        Me.tpFrameExtraction.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFrameExtraction.Size = New System.Drawing.Size(1176, 526)
        Me.tpFrameExtraction.TabIndex = 3
        Me.tpFrameExtraction.Text = "Frame Extraction"
        Me.tpFrameExtraction.UseVisualStyleBackColor = True
        '
        'pnlFrameExtrator
        '
        Me.pnlFrameExtrator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFrameExtrator.Location = New System.Drawing.Point(3, 3)
        Me.pnlFrameExtrator.Name = "pnlFrameExtrator"
        Me.pnlFrameExtrator.Size = New System.Drawing.Size(1170, 520)
        Me.pnlFrameExtrator.TabIndex = 0
        '
        'tpSubtitles
        '
        Me.tpSubtitles.Controls.Add(Me.lblSubtitlesPreview)
        Me.tpSubtitles.Controls.Add(Me.txtSubtitlesPreview)
        Me.tpSubtitles.Controls.Add(Me.lvSubtitles)
        Me.tpSubtitles.Controls.Add(Me.btnRemoveSubtitle)
        Me.tpSubtitles.Controls.Add(Me.btnSetSubtitleDL)
        Me.tpSubtitles.Controls.Add(Me.btnSetSubtitleScrape)
        Me.tpSubtitles.Controls.Add(Me.btnSetSubtitleLocal)
        Me.tpSubtitles.Location = New System.Drawing.Point(4, 22)
        Me.tpSubtitles.Name = "tpSubtitles"
        Me.tpSubtitles.Size = New System.Drawing.Size(1176, 526)
        Me.tpSubtitles.TabIndex = 15
        Me.tpSubtitles.Text = "Subtitles"
        Me.tpSubtitles.UseVisualStyleBackColor = True
        '
        'lblSubtitlesPreview
        '
        Me.lblSubtitlesPreview.AutoSize = True
        Me.lblSubtitlesPreview.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblSubtitlesPreview.Location = New System.Drawing.Point(10, 295)
        Me.lblSubtitlesPreview.Name = "lblSubtitlesPreview"
        Me.lblSubtitlesPreview.Size = New System.Drawing.Size(51, 13)
        Me.lblSubtitlesPreview.TabIndex = 37
        Me.lblSubtitlesPreview.Text = "Preview:"
        '
        'txtSubtitlesPreview
        '
        Me.txtSubtitlesPreview.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtSubtitlesPreview.Location = New System.Drawing.Point(6, 311)
        Me.txtSubtitlesPreview.Multiline = True
        Me.txtSubtitlesPreview.Name = "txtSubtitlesPreview"
        Me.txtSubtitlesPreview.ReadOnly = True
        Me.txtSubtitlesPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSubtitlesPreview.Size = New System.Drawing.Size(800, 145)
        Me.txtSubtitlesPreview.TabIndex = 11
        '
        'lvSubtitles
        '
        Me.lvSubtitles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSubtitles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvSubtitles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvSubtitles.FullRowSelect = True
        ListViewGroup1.Header = "Local Subtitles"
        ListViewGroup1.Name = "LocalSubtitles"
        Me.lvSubtitles.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1})
        Me.lvSubtitles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        ListViewItem1.Group = ListViewGroup1
        Me.lvSubtitles.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvSubtitles.Location = New System.Drawing.Point(6, 6)
        Me.lvSubtitles.MultiSelect = False
        Me.lvSubtitles.Name = "lvSubtitles"
        Me.lvSubtitles.Size = New System.Drawing.Size(800, 261)
        Me.lvSubtitles.TabIndex = 10
        Me.lvSubtitles.UseCompatibleStateImageBehavior = False
        Me.lvSubtitles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 25
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 550
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 100
        '
        'btnRemoveSubtitle
        '
        Me.btnRemoveSubtitle.Enabled = False
        Me.btnRemoveSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveSubtitle.Image = CType(resources.GetObject("btnRemoveSubtitle.Image"), System.Drawing.Image)
        Me.btnRemoveSubtitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveSubtitle.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveSubtitle.Name = "btnRemoveSubtitle"
        Me.btnRemoveSubtitle.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveSubtitle.TabIndex = 9
        Me.btnRemoveSubtitle.Text = "Remove"
        Me.btnRemoveSubtitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveSubtitle.UseVisualStyleBackColor = True
        '
        'btnSetSubtitleDL
        '
        Me.btnSetSubtitleDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetSubtitleDL.Image = CType(resources.GetObject("btnSetSubtitleDL.Image"), System.Drawing.Image)
        Me.btnSetSubtitleDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetSubtitleDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetSubtitleDL.Name = "btnSetSubtitleDL"
        Me.btnSetSubtitleDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetSubtitleDL.TabIndex = 6
        Me.btnSetSubtitleDL.Text = "Download"
        Me.btnSetSubtitleDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetSubtitleDL.UseVisualStyleBackColor = True
        '
        'btnSetSubtitleScrape
        '
        Me.btnSetSubtitleScrape.Enabled = False
        Me.btnSetSubtitleScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetSubtitleScrape.Image = CType(resources.GetObject("btnSetSubtitleScrape.Image"), System.Drawing.Image)
        Me.btnSetSubtitleScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetSubtitleScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetSubtitleScrape.Name = "btnSetSubtitleScrape"
        Me.btnSetSubtitleScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetSubtitleScrape.TabIndex = 5
        Me.btnSetSubtitleScrape.Text = "Scrape"
        Me.btnSetSubtitleScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetSubtitleScrape.UseVisualStyleBackColor = True
        '
        'btnSetSubtitleLocal
        '
        Me.btnSetSubtitleLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetSubtitleLocal.Image = CType(resources.GetObject("btnSetSubtitleLocal.Image"), System.Drawing.Image)
        Me.btnSetSubtitleLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetSubtitleLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetSubtitleLocal.Name = "btnSetSubtitleLocal"
        Me.btnSetSubtitleLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetSubtitleLocal.TabIndex = 4
        Me.btnSetSubtitleLocal.Text = "Local Browse"
        Me.btnSetSubtitleLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetSubtitleLocal.UseVisualStyleBackColor = True
        '
        'tpTrailer
        '
        Me.tpTrailer.Controls.Add(Me.btnLocalTrailerPlay)
        Me.tpTrailer.Controls.Add(Me.txtLocalTrailer)
        Me.tpTrailer.Controls.Add(Me.pnlTrailerPreview)
        Me.tpTrailer.Controls.Add(Me.btnSetTrailerDL)
        Me.tpTrailer.Controls.Add(Me.btnRemoveTrailer)
        Me.tpTrailer.Controls.Add(Me.btnSetTrailerScrape)
        Me.tpTrailer.Controls.Add(Me.btnSetTrailerLocal)
        Me.tpTrailer.Location = New System.Drawing.Point(4, 22)
        Me.tpTrailer.Name = "tpTrailer"
        Me.tpTrailer.Size = New System.Drawing.Size(1176, 526)
        Me.tpTrailer.TabIndex = 13
        Me.tpTrailer.Text = "Trailer"
        Me.tpTrailer.UseVisualStyleBackColor = True
        '
        'btnLocalTrailerPlay
        '
        Me.btnLocalTrailerPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLocalTrailerPlay.Enabled = False
        Me.btnLocalTrailerPlay.Image = Global.Ember_Media_Manager.My.Resources.Resources.Play_Icon
        Me.btnLocalTrailerPlay.Location = New System.Drawing.Point(783, 462)
        Me.btnLocalTrailerPlay.Name = "btnLocalTrailerPlay"
        Me.btnLocalTrailerPlay.Size = New System.Drawing.Size(23, 22)
        Me.btnLocalTrailerPlay.TabIndex = 53
        Me.btnLocalTrailerPlay.UseVisualStyleBackColor = True
        '
        'txtLocalTrailer
        '
        Me.txtLocalTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtLocalTrailer.Location = New System.Drawing.Point(6, 462)
        Me.txtLocalTrailer.Name = "txtLocalTrailer"
        Me.txtLocalTrailer.ReadOnly = True
        Me.txtLocalTrailer.Size = New System.Drawing.Size(771, 22)
        Me.txtLocalTrailer.TabIndex = 15
        '
        'pnlTrailerPreview
        '
        Me.pnlTrailerPreview.BackColor = System.Drawing.Color.DimGray
        Me.pnlTrailerPreview.Controls.Add(Me.pnlTrailerPreviewNoPlayer)
        Me.pnlTrailerPreview.Location = New System.Drawing.Point(6, 6)
        Me.pnlTrailerPreview.Name = "pnlTrailerPreview"
        Me.pnlTrailerPreview.Size = New System.Drawing.Size(800, 450)
        Me.pnlTrailerPreview.TabIndex = 13
        '
        'pnlTrailerPreviewNoPlayer
        '
        Me.pnlTrailerPreviewNoPlayer.BackColor = System.Drawing.Color.White
        Me.pnlTrailerPreviewNoPlayer.Controls.Add(Me.tblTrailerPreviewNoPlayer)
        Me.pnlTrailerPreviewNoPlayer.Location = New System.Drawing.Point(285, 203)
        Me.pnlTrailerPreviewNoPlayer.Name = "pnlTrailerPreviewNoPlayer"
        Me.pnlTrailerPreviewNoPlayer.Size = New System.Drawing.Size(242, 56)
        Me.pnlTrailerPreviewNoPlayer.TabIndex = 0
        '
        'tblTrailerPreviewNoPlayer
        '
        Me.tblTrailerPreviewNoPlayer.AutoSize = True
        Me.tblTrailerPreviewNoPlayer.ColumnCount = 1
        Me.tblTrailerPreviewNoPlayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblTrailerPreviewNoPlayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTrailerPreviewNoPlayer.Controls.Add(Me.lblTrailerPreviewNoPlayer, 0, 0)
        Me.tblTrailerPreviewNoPlayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTrailerPreviewNoPlayer.Location = New System.Drawing.Point(0, 0)
        Me.tblTrailerPreviewNoPlayer.Name = "tblTrailerPreviewNoPlayer"
        Me.tblTrailerPreviewNoPlayer.RowCount = 1
        Me.tblTrailerPreviewNoPlayer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblTrailerPreviewNoPlayer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.tblTrailerPreviewNoPlayer.Size = New System.Drawing.Size(242, 56)
        Me.tblTrailerPreviewNoPlayer.TabIndex = 0
        '
        'lblTrailerPreviewNoPlayer
        '
        Me.lblTrailerPreviewNoPlayer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTrailerPreviewNoPlayer.AutoSize = True
        Me.lblTrailerPreviewNoPlayer.Location = New System.Drawing.Point(52, 21)
        Me.lblTrailerPreviewNoPlayer.Name = "lblTrailerPreviewNoPlayer"
        Me.lblTrailerPreviewNoPlayer.Size = New System.Drawing.Size(137, 13)
        Me.lblTrailerPreviewNoPlayer.TabIndex = 0
        Me.lblTrailerPreviewNoPlayer.Text = "no Media Player enabled"
        '
        'btnSetTrailerDL
        '
        Me.btnSetTrailerDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetTrailerDL.Image = CType(resources.GetObject("btnSetTrailerDL.Image"), System.Drawing.Image)
        Me.btnSetTrailerDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetTrailerDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetTrailerDL.Name = "btnSetTrailerDL"
        Me.btnSetTrailerDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetTrailerDL.TabIndex = 7
        Me.btnSetTrailerDL.Text = "Download"
        Me.btnSetTrailerDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetTrailerDL.UseVisualStyleBackColor = True
        '
        'btnRemoveTrailer
        '
        Me.btnRemoveTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveTrailer.Image = CType(resources.GetObject("btnRemoveTrailer.Image"), System.Drawing.Image)
        Me.btnRemoveTrailer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveTrailer.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveTrailer.Name = "btnRemoveTrailer"
        Me.btnRemoveTrailer.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveTrailer.TabIndex = 8
        Me.btnRemoveTrailer.Text = "Remove"
        Me.btnRemoveTrailer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveTrailer.UseVisualStyleBackColor = True
        '
        'btnSetTrailerScrape
        '
        Me.btnSetTrailerScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetTrailerScrape.Image = CType(resources.GetObject("btnSetTrailerScrape.Image"), System.Drawing.Image)
        Me.btnSetTrailerScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetTrailerScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetTrailerScrape.Name = "btnSetTrailerScrape"
        Me.btnSetTrailerScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetTrailerScrape.TabIndex = 6
        Me.btnSetTrailerScrape.Text = "Scrape"
        Me.btnSetTrailerScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetTrailerScrape.UseVisualStyleBackColor = True
        '
        'btnSetTrailerLocal
        '
        Me.btnSetTrailerLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetTrailerLocal.Image = CType(resources.GetObject("btnSetTrailerLocal.Image"), System.Drawing.Image)
        Me.btnSetTrailerLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetTrailerLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetTrailerLocal.Name = "btnSetTrailerLocal"
        Me.btnSetTrailerLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetTrailerLocal.TabIndex = 5
        Me.btnSetTrailerLocal.Text = "Local Browse"
        Me.btnSetTrailerLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetTrailerLocal.UseVisualStyleBackColor = True
        '
        'tpTheme
        '
        Me.tpTheme.Controls.Add(Me.btnLocalThemePlay)
        Me.tpTheme.Controls.Add(Me.txtLocalTheme)
        Me.tpTheme.Controls.Add(Me.pnlThemePreview)
        Me.tpTheme.Controls.Add(Me.btnSetThemeDL)
        Me.tpTheme.Controls.Add(Me.btnRemoveTheme)
        Me.tpTheme.Controls.Add(Me.btnSetThemeScrape)
        Me.tpTheme.Controls.Add(Me.btnSetThemeLocal)
        Me.tpTheme.Location = New System.Drawing.Point(4, 22)
        Me.tpTheme.Name = "tpTheme"
        Me.tpTheme.Size = New System.Drawing.Size(1176, 526)
        Me.tpTheme.TabIndex = 14
        Me.tpTheme.Text = "Theme"
        Me.tpTheme.UseVisualStyleBackColor = True
        '
        'btnLocalThemePlay
        '
        Me.btnLocalThemePlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLocalThemePlay.Enabled = False
        Me.btnLocalThemePlay.Image = Global.Ember_Media_Manager.My.Resources.Resources.Play_Icon
        Me.btnLocalThemePlay.Location = New System.Drawing.Point(783, 462)
        Me.btnLocalThemePlay.Name = "btnLocalThemePlay"
        Me.btnLocalThemePlay.Size = New System.Drawing.Size(23, 22)
        Me.btnLocalThemePlay.TabIndex = 56
        Me.btnLocalThemePlay.UseVisualStyleBackColor = True
        '
        'txtLocalTheme
        '
        Me.txtLocalTheme.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtLocalTheme.Location = New System.Drawing.Point(6, 462)
        Me.txtLocalTheme.Name = "txtLocalTheme"
        Me.txtLocalTheme.ReadOnly = True
        Me.txtLocalTheme.Size = New System.Drawing.Size(771, 22)
        Me.txtLocalTheme.TabIndex = 55
        '
        'pnlThemePreview
        '
        Me.pnlThemePreview.BackColor = System.Drawing.Color.DimGray
        Me.pnlThemePreview.Controls.Add(Me.pnlThemePreviewNoPlayer)
        Me.pnlThemePreview.Location = New System.Drawing.Point(6, 6)
        Me.pnlThemePreview.Name = "pnlThemePreview"
        Me.pnlThemePreview.Size = New System.Drawing.Size(800, 450)
        Me.pnlThemePreview.TabIndex = 14
        '
        'pnlThemePreviewNoPlayer
        '
        Me.pnlThemePreviewNoPlayer.BackColor = System.Drawing.Color.White
        Me.pnlThemePreviewNoPlayer.Controls.Add(Me.tblThemePreviewNoPlayer)
        Me.pnlThemePreviewNoPlayer.Location = New System.Drawing.Point(285, 203)
        Me.pnlThemePreviewNoPlayer.Name = "pnlThemePreviewNoPlayer"
        Me.pnlThemePreviewNoPlayer.Size = New System.Drawing.Size(242, 56)
        Me.pnlThemePreviewNoPlayer.TabIndex = 0
        '
        'tblThemePreviewNoPlayer
        '
        Me.tblThemePreviewNoPlayer.AutoSize = True
        Me.tblThemePreviewNoPlayer.ColumnCount = 1
        Me.tblThemePreviewNoPlayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblThemePreviewNoPlayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblThemePreviewNoPlayer.Controls.Add(Me.lblThemePreviewNoPlayer, 0, 0)
        Me.tblThemePreviewNoPlayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblThemePreviewNoPlayer.Location = New System.Drawing.Point(0, 0)
        Me.tblThemePreviewNoPlayer.Name = "tblThemePreviewNoPlayer"
        Me.tblThemePreviewNoPlayer.RowCount = 1
        Me.tblThemePreviewNoPlayer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblThemePreviewNoPlayer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.tblThemePreviewNoPlayer.Size = New System.Drawing.Size(242, 56)
        Me.tblThemePreviewNoPlayer.TabIndex = 0
        '
        'lblThemePreviewNoPlayer
        '
        Me.lblThemePreviewNoPlayer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblThemePreviewNoPlayer.AutoSize = True
        Me.lblThemePreviewNoPlayer.Location = New System.Drawing.Point(52, 21)
        Me.lblThemePreviewNoPlayer.Name = "lblThemePreviewNoPlayer"
        Me.lblThemePreviewNoPlayer.Size = New System.Drawing.Size(137, 13)
        Me.lblThemePreviewNoPlayer.TabIndex = 0
        Me.lblThemePreviewNoPlayer.Text = "no Media Player enabled"
        '
        'btnSetThemeDL
        '
        Me.btnSetThemeDL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetThemeDL.Image = CType(resources.GetObject("btnSetThemeDL.Image"), System.Drawing.Image)
        Me.btnSetThemeDL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetThemeDL.Location = New System.Drawing.Point(810, 184)
        Me.btnSetThemeDL.Name = "btnSetThemeDL"
        Me.btnSetThemeDL.Size = New System.Drawing.Size(96, 83)
        Me.btnSetThemeDL.TabIndex = 7
        Me.btnSetThemeDL.Text = "Download"
        Me.btnSetThemeDL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetThemeDL.UseVisualStyleBackColor = True
        '
        'btnRemoveTheme
        '
        Me.btnRemoveTheme.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRemoveTheme.Image = CType(resources.GetObject("btnRemoveTheme.Image"), System.Drawing.Image)
        Me.btnRemoveTheme.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveTheme.Location = New System.Drawing.Point(810, 373)
        Me.btnRemoveTheme.Name = "btnRemoveTheme"
        Me.btnRemoveTheme.Size = New System.Drawing.Size(96, 83)
        Me.btnRemoveTheme.TabIndex = 8
        Me.btnRemoveTheme.Text = "Remove"
        Me.btnRemoveTheme.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveTheme.UseVisualStyleBackColor = True
        '
        'btnSetThemeScrape
        '
        Me.btnSetThemeScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetThemeScrape.Image = CType(resources.GetObject("btnSetThemeScrape.Image"), System.Drawing.Image)
        Me.btnSetThemeScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetThemeScrape.Location = New System.Drawing.Point(810, 95)
        Me.btnSetThemeScrape.Name = "btnSetThemeScrape"
        Me.btnSetThemeScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetThemeScrape.TabIndex = 6
        Me.btnSetThemeScrape.Text = "Scrape"
        Me.btnSetThemeScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetThemeScrape.UseVisualStyleBackColor = True
        '
        'btnSetThemeLocal
        '
        Me.btnSetThemeLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSetThemeLocal.Image = CType(resources.GetObject("btnSetThemeLocal.Image"), System.Drawing.Image)
        Me.btnSetThemeLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetThemeLocal.Location = New System.Drawing.Point(810, 6)
        Me.btnSetThemeLocal.Name = "btnSetThemeLocal"
        Me.btnSetThemeLocal.Size = New System.Drawing.Size(96, 83)
        Me.btnSetThemeLocal.TabIndex = 5
        Me.btnSetThemeLocal.Text = "Local Browse"
        Me.btnSetThemeLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetThemeLocal.UseVisualStyleBackColor = True
        '
        'tpMetaData
        '
        Me.tpMetaData.Controls.Add(Me.pnlFileInfo)
        Me.tpMetaData.Location = New System.Drawing.Point(4, 22)
        Me.tpMetaData.Name = "tpMetaData"
        Me.tpMetaData.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMetaData.Size = New System.Drawing.Size(1176, 526)
        Me.tpMetaData.TabIndex = 5
        Me.tpMetaData.Text = "Meta Data"
        Me.tpMetaData.UseVisualStyleBackColor = True
        '
        'pnlFileInfo
        '
        Me.pnlFileInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFileInfo.Location = New System.Drawing.Point(3, 3)
        Me.pnlFileInfo.Name = "pnlFileInfo"
        Me.pnlFileInfo.Size = New System.Drawing.Size(1170, 520)
        Me.pnlFileInfo.TabIndex = 0
        '
        'tpMediaStub
        '
        Me.tpMediaStub.Controls.Add(Me.lblMediaStubMessage)
        Me.tpMediaStub.Controls.Add(Me.lblMediaStubTitle)
        Me.tpMediaStub.Controls.Add(Me.txtMediaStubMessage)
        Me.tpMediaStub.Controls.Add(Me.txtMediaStubTitle)
        Me.tpMediaStub.Location = New System.Drawing.Point(4, 22)
        Me.tpMediaStub.Name = "tpMediaStub"
        Me.tpMediaStub.Size = New System.Drawing.Size(1176, 526)
        Me.tpMediaStub.TabIndex = 7
        Me.tpMediaStub.Text = "Media Stub"
        Me.tpMediaStub.UseVisualStyleBackColor = True
        '
        'lblMediaStubMessage
        '
        Me.lblMediaStubMessage.AutoSize = True
        Me.lblMediaStubMessage.Location = New System.Drawing.Point(203, 231)
        Me.lblMediaStubMessage.Name = "lblMediaStubMessage"
        Me.lblMediaStubMessage.Size = New System.Drawing.Size(56, 13)
        Me.lblMediaStubMessage.TabIndex = 3
        Me.lblMediaStubMessage.Text = "Message:"
        '
        'lblMediaStubTitle
        '
        Me.lblMediaStubTitle.AutoSize = True
        Me.lblMediaStubTitle.Location = New System.Drawing.Point(203, 170)
        Me.lblMediaStubTitle.Name = "lblMediaStubTitle"
        Me.lblMediaStubTitle.Size = New System.Drawing.Size(32, 13)
        Me.lblMediaStubTitle.TabIndex = 2
        Me.lblMediaStubTitle.Text = "Title:"
        '
        'txtMediaStubMessage
        '
        Me.txtMediaStubMessage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtMediaStubMessage.Location = New System.Drawing.Point(206, 247)
        Me.txtMediaStubMessage.Name = "txtMediaStubMessage"
        Me.txtMediaStubMessage.Size = New System.Drawing.Size(472, 22)
        Me.txtMediaStubMessage.TabIndex = 1
        '
        'txtMediaStubTitle
        '
        Me.txtMediaStubTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtMediaStubTitle.Location = New System.Drawing.Point(206, 186)
        Me.txtMediaStubTitle.Name = "txtMediaStubTitle"
        Me.txtMediaStubTitle.Size = New System.Drawing.Size(260, 22)
        Me.txtMediaStubTitle.TabIndex = 0
        '
        'chkMarked
        '
        Me.chkMarked.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMarked.AutoSize = True
        Me.chkMarked.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarked.Location = New System.Drawing.Point(3, 5)
        Me.chkMarked.Name = "chkMarked"
        Me.chkMarked.Size = New System.Drawing.Size(65, 17)
        Me.chkMarked.TabIndex = 5
        Me.chkMarked.Text = "Marked"
        Me.chkMarked.UseVisualStyleBackColor = True
        '
        'btnRescrape
        '
        Me.btnRescrape.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRescrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnRescrape.Image = CType(resources.GetObject("btnRescrape.Image"), System.Drawing.Image)
        Me.btnRescrape.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRescrape.Location = New System.Drawing.Point(684, 30)
        Me.btnRescrape.Name = "btnRescrape"
        Me.btnRescrape.Size = New System.Drawing.Size(98, 23)
        Me.btnRescrape.TabIndex = 7
        Me.btnRescrape.Text = "(Re)Scrape"
        Me.btnRescrape.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRescrape.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChange.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnChange.Image = CType(resources.GetObject("btnChange.Image"), System.Drawing.Image)
        Me.btnChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChange.Location = New System.Drawing.Point(788, 30)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(107, 23)
        Me.btnChange.TabIndex = 8
        Me.btnChange.Text = "Change"
        Me.btnChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'tmrDelay
        '
        Me.tmrDelay.Interval = 250
        '
        'chkWatched
        '
        Me.chkWatched.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkWatched.AutoSize = True
        Me.chkWatched.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWatched.Location = New System.Drawing.Point(355, 33)
        Me.chkWatched.Name = "chkWatched"
        Me.chkWatched.Size = New System.Drawing.Size(72, 17)
        Me.chkWatched.TabIndex = 6
        Me.chkWatched.Text = "Watched"
        Me.chkWatched.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFilename})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 664)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1184, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 9
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'tsFilename
        '
        Me.tsFilename.Name = "tsFilename"
        Me.tsFilename.Size = New System.Drawing.Size(55, 17)
        Me.tsFilename.Text = "Filename"
        '
        'txtLastPlayed
        '
        Me.txtLastPlayed.BackColor = System.Drawing.SystemColors.Window
        Me.txtLastPlayed.Enabled = False
        Me.txtLastPlayed.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtLastPlayed.Location = New System.Drawing.Point(433, 30)
        Me.txtLastPlayed.Name = "txtLastPlayed"
        Me.txtLastPlayed.Size = New System.Drawing.Size(118, 22)
        Me.txtLastPlayed.TabIndex = 74
        '
        'cbLanguage
        '
        Me.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbLanguage.Location = New System.Drawing.Point(433, 3)
        Me.cbLanguage.Name = "cbLanguage"
        Me.cbLanguage.Size = New System.Drawing.Size(172, 21)
        Me.cbLanguage.TabIndex = 76
        '
        'lblLanguage
        '
        Me.lblLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.Location = New System.Drawing.Point(355, 7)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(61, 13)
        Me.lblLanguage.TabIndex = 75
        Me.lblLanguage.Text = "Language:"
        '
        'pnlEdit
        '
        Me.pnlEdit.AutoSize = True
        Me.pnlEdit.Controls.Add(Me.pnlEditMain)
        Me.pnlEdit.Controls.Add(Me.pnlEditTop)
        Me.pnlEdit.Controls.Add(Me.pnlEditBottom)
        Me.pnlEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEdit.Location = New System.Drawing.Point(0, 0)
        Me.pnlEdit.Name = "pnlEdit"
        Me.pnlEdit.Size = New System.Drawing.Size(1184, 664)
        Me.pnlEdit.TabIndex = 77
        '
        'pnlEditMain
        '
        Me.pnlEditMain.Controls.Add(Me.tcEdit)
        Me.pnlEditMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEditMain.Location = New System.Drawing.Point(0, 56)
        Me.pnlEditMain.Name = "pnlEditMain"
        Me.pnlEditMain.Size = New System.Drawing.Size(1184, 552)
        Me.pnlEditMain.TabIndex = 2
        '
        'pnlEditTop
        '
        Me.pnlEditTop.AutoSize = True
        Me.pnlEditTop.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlEditTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEditTop.Controls.Add(Me.tblEditTop)
        Me.pnlEditTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEditTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlEditTop.Name = "pnlEditTop"
        Me.pnlEditTop.Size = New System.Drawing.Size(1184, 56)
        Me.pnlEditTop.TabIndex = 1
        '
        'tblEditTop
        '
        Me.tblEditTop.AutoSize = True
        Me.tblEditTop.BackColor = System.Drawing.Color.SteelBlue
        Me.tblEditTop.ColumnCount = 3
        Me.tblEditTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditTop.Controls.Add(Me.lblTopDetails, 1, 1)
        Me.tblEditTop.Controls.Add(Me.pbTopLogo, 0, 0)
        Me.tblEditTop.Controls.Add(Me.lblTopTitle, 1, 0)
        Me.tblEditTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEditTop.Location = New System.Drawing.Point(0, 0)
        Me.tblEditTop.Name = "tblEditTop"
        Me.tblEditTop.RowCount = 3
        Me.tblEditTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblEditTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblEditTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblEditTop.Size = New System.Drawing.Size(1182, 54)
        Me.tblEditTop.TabIndex = 0
        '
        'pnlEditBottom
        '
        Me.pnlEditBottom.AutoSize = True
        Me.pnlEditBottom.Controls.Add(Me.tblEditBottom)
        Me.pnlEditBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEditBottom.Location = New System.Drawing.Point(0, 608)
        Me.pnlEditBottom.Name = "pnlEditBottom"
        Me.pnlEditBottom.Size = New System.Drawing.Size(1184, 56)
        Me.pnlEditBottom.TabIndex = 0
        '
        'tblEditBottom
        '
        Me.tblEditBottom.AutoSize = True
        Me.tblEditBottom.ColumnCount = 11
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblEditBottom.Controls.Add(Me.lblLanguage, 3, 0)
        Me.tblEditBottom.Controls.Add(Me.cbEpisodeSorting, 2, 1)
        Me.tblEditBottom.Controls.Add(Me.lblEpisodeSorting, 1, 1)
        Me.tblEditBottom.Controls.Add(Me.txtLastPlayed, 4, 1)
        Me.tblEditBottom.Controls.Add(Me.cbOrdering, 2, 0)
        Me.tblEditBottom.Controls.Add(Me.cbLanguage, 4, 0)
        Me.tblEditBottom.Controls.Add(Me.chkWatched, 3, 1)
        Me.tblEditBottom.Controls.Add(Me.lblOrdering, 1, 0)
        Me.tblEditBottom.Controls.Add(Me.chkMarked, 0, 0)
        Me.tblEditBottom.Controls.Add(Me.chkLocked, 0, 1)
        Me.tblEditBottom.Controls.Add(Me.btnRescrape, 6, 1)
        Me.tblEditBottom.Controls.Add(Me.btnChange, 7, 1)
        Me.tblEditBottom.Controls.Add(Me.btnOK, 9, 1)
        Me.tblEditBottom.Controls.Add(Me.btnCancel, 10, 1)
        Me.tblEditBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEditBottom.Location = New System.Drawing.Point(0, 0)
        Me.tblEditBottom.Name = "tblEditBottom"
        Me.tblEditBottom.RowCount = 2
        Me.tblEditBottom.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblEditBottom.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblEditBottom.Size = New System.Drawing.Size(1184, 56)
        Me.tblEditBottom.TabIndex = 0
        '
        'cbEpisodeSorting
        '
        Me.cbEpisodeSorting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbEpisodeSorting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEpisodeSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbEpisodeSorting.FormattingEnabled = True
        Me.cbEpisodeSorting.Location = New System.Drawing.Point(183, 32)
        Me.cbEpisodeSorting.Name = "cbEpisodeSorting"
        Me.cbEpisodeSorting.Size = New System.Drawing.Size(166, 21)
        Me.cbEpisodeSorting.TabIndex = 5
        '
        'lblEpisodeSorting
        '
        Me.lblEpisodeSorting.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblEpisodeSorting.AutoSize = True
        Me.lblEpisodeSorting.Location = New System.Drawing.Point(74, 35)
        Me.lblEpisodeSorting.Name = "lblEpisodeSorting"
        Me.lblEpisodeSorting.Size = New System.Drawing.Size(103, 13)
        Me.lblEpisodeSorting.TabIndex = 4
        Me.lblEpisodeSorting.Text = "Episode Sorted by:"
        Me.lblEpisodeSorting.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbOrdering
        '
        Me.cbOrdering.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbOrdering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrdering.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbOrdering.FormattingEnabled = True
        Me.cbOrdering.Location = New System.Drawing.Point(183, 3)
        Me.cbOrdering.Name = "cbOrdering"
        Me.cbOrdering.Size = New System.Drawing.Size(166, 21)
        Me.cbOrdering.TabIndex = 5
        '
        'lblOrdering
        '
        Me.lblOrdering.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOrdering.AutoSize = True
        Me.lblOrdering.Location = New System.Drawing.Point(74, 7)
        Me.lblOrdering.Name = "lblOrdering"
        Me.lblOrdering.Size = New System.Drawing.Size(101, 13)
        Me.lblOrdering.TabIndex = 4
        Me.lblOrdering.Text = "Episode Ordering:"
        '
        'chkLocked
        '
        Me.chkLocked.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkLocked.AutoSize = True
        Me.chkLocked.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLocked.Location = New System.Drawing.Point(3, 33)
        Me.chkLocked.Name = "chkLocked"
        Me.chkLocked.Size = New System.Drawing.Size(62, 17)
        Me.chkLocked.TabIndex = 5
        Me.chkLocked.Text = "Locked"
        Me.chkLocked.UseVisualStyleBackColor = True
        '
        'dlgEdit
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1184, 686)
        Me.Controls.Add(Me.pnlEdit)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgEdit"
        Me.Text = "Edit"
        CType(Me.pbTopLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcEdit.ResumeLayout(False)
        Me.tpDetails.ResumeLayout(False)
        Me.tpDetails.PerformLayout()
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        Me.tblDetails.ResumeLayout(False)
        Me.tblDetails.PerformLayout()
        Me.pnlDetailsColumn1.ResumeLayout(False)
        Me.pnlDetailsColumn1.PerformLayout()
        Me.tblDetailsColumn1.ResumeLayout(False)
        Me.tblDetailsColumn1.PerformLayout()
        Me.tblDetailsMain.ResumeLayout(False)
        Me.tblDetailsMain.PerformLayout()
        Me.tblDetailsMPAA.ResumeLayout(False)
        Me.tblDetailsMPAA.PerformLayout()
        Me.pnlDetailsColumn2.ResumeLayout(False)
        Me.pnlDetailsColumn2.PerformLayout()
        Me.tblDetailsColumn2.ResumeLayout(False)
        Me.tblDetailsColumn2.PerformLayout()
        Me.tblDetailsInfo.ResumeLayout(False)
        Me.tblDetailsInfo.PerformLayout()
        Me.tblDetailsGenresTagsShowlink.ResumeLayout(False)
        Me.tblDetailsGenresTagsShowlink.PerformLayout()
        Me.tblDetailsCollection.ResumeLayout(False)
        Me.tblDetailsCollection.PerformLayout()
        Me.pnlDetailsColumn3.ResumeLayout(False)
        Me.pnlDetailsColumn3.PerformLayout()
        Me.tblDetailsColumn3.ResumeLayout(False)
        Me.tblDetailsColumn3.PerformLayout()
        Me.tcCrew.ResumeLayout(False)
        Me.tpActors.ResumeLayout(False)
        Me.tpActors.PerformLayout()
        Me.tblActors.ResumeLayout(False)
        Me.tpSpecialGuests.ResumeLayout(False)
        Me.tpSpecialGuests.PerformLayout()
        Me.tblSpecialGuests.ResumeLayout(False)
        Me.tblDetailsCrew.ResumeLayout(False)
        Me.tblDetailsCrew.PerformLayout()
        Me.tpMovies.ResumeLayout(False)
        Me.tpMovies.PerformLayout()
        Me.pnlMovies.ResumeLayout(False)
        Me.pnlMovies.PerformLayout()
        Me.tblMovies.ResumeLayout(False)
        Me.tblMovies.PerformLayout()
        CType(Me.dgvMovies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPoster.ResumeLayout(False)
        CType(Me.pbPoster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpBanner.ResumeLayout(False)
        CType(Me.pbBanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpLandscape.ResumeLayout(False)
        CType(Me.pbLandscape, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpClearArt.ResumeLayout(False)
        CType(Me.pbClearArt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpClearLogo.ResumeLayout(False)
        CType(Me.pbClearLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDiscArt.ResumeLayout(False)
        CType(Me.pbDiscArt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpFanart.ResumeLayout(False)
        CType(Me.pbFanart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpExtrafanarts.ResumeLayout(False)
        Me.pnlExtrafanartsSetAsFanart.ResumeLayout(False)
        CType(Me.pbExtrafanarts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpExtrathumbs.ResumeLayout(False)
        Me.pnlExtrathumbsSetAsFanart.ResumeLayout(False)
        CType(Me.pbExtrathumbs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpFrameExtraction.ResumeLayout(False)
        Me.tpSubtitles.ResumeLayout(False)
        Me.tpSubtitles.PerformLayout()
        Me.tpTrailer.ResumeLayout(False)
        Me.tpTrailer.PerformLayout()
        Me.pnlTrailerPreview.ResumeLayout(False)
        Me.pnlTrailerPreviewNoPlayer.ResumeLayout(False)
        Me.pnlTrailerPreviewNoPlayer.PerformLayout()
        Me.tblTrailerPreviewNoPlayer.ResumeLayout(False)
        Me.tblTrailerPreviewNoPlayer.PerformLayout()
        Me.tpTheme.ResumeLayout(False)
        Me.tpTheme.PerformLayout()
        Me.pnlThemePreview.ResumeLayout(False)
        Me.pnlThemePreviewNoPlayer.ResumeLayout(False)
        Me.pnlThemePreviewNoPlayer.PerformLayout()
        Me.tblThemePreviewNoPlayer.ResumeLayout(False)
        Me.tblThemePreviewNoPlayer.PerformLayout()
        Me.tpMetaData.ResumeLayout(False)
        Me.tpMediaStub.ResumeLayout(False)
        Me.tpMediaStub.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.pnlEdit.ResumeLayout(False)
        Me.pnlEdit.PerformLayout()
        Me.pnlEditMain.ResumeLayout(False)
        Me.pnlEditTop.ResumeLayout(False)
        Me.pnlEditTop.PerformLayout()
        Me.tblEditTop.ResumeLayout(False)
        Me.tblEditTop.PerformLayout()
        Me.pnlEditBottom.ResumeLayout(False)
        Me.pnlEditBottom.PerformLayout()
        Me.tblEditBottom.ResumeLayout(False)
        Me.tblEditBottom.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pbTopLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTopDetails As System.Windows.Forms.Label
    Friend WithEvents lblTopTitle As System.Windows.Forms.Label
    Friend WithEvents tcEdit As System.Windows.Forms.TabControl
    Friend WithEvents tpDetails As System.Windows.Forms.TabPage
    Friend WithEvents lblMPAADescription As System.Windows.Forms.Label
    Friend WithEvents txtMPAADesc As System.Windows.Forms.TextBox
    Friend WithEvents btnEdit_Actor As System.Windows.Forms.Button
    Friend WithEvents btnAdd_Actor As System.Windows.Forms.Button
    Friend WithEvents btnRemove_Actor As System.Windows.Forms.Button
    Friend WithEvents lvActors As System.Windows.Forms.ListView
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRole As System.Windows.Forms.ColumnHeader
    Friend WithEvents colThumb As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbMPAA As System.Windows.Forms.ListBox
    Friend WithEvents lblGenres As System.Windows.Forms.Label
    Friend WithEvents lblMPAARating As System.Windows.Forms.Label
    Friend WithEvents lblDirectors As System.Windows.Forms.Label
    Friend WithEvents lblTop250 As System.Windows.Forms.Label
    Friend WithEvents lblPlot As System.Windows.Forms.Label
    Friend WithEvents txtPlot As System.Windows.Forms.TextBox
    Friend WithEvents lblOutline As System.Windows.Forms.Label
    Friend WithEvents txtOutline As System.Windows.Forms.TextBox
    Friend WithEvents lblTagline As System.Windows.Forms.Label
    Friend WithEvents txtTagline As System.Windows.Forms.TextBox
    Friend WithEvents txtVotes As System.Windows.Forms.TextBox
    Friend WithEvents lblVotes As System.Windows.Forms.Label
    Friend WithEvents lblRating As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents tpPoster As System.Windows.Forms.TabPage
    Friend WithEvents tpFanart As System.Windows.Forms.TabPage
    Friend WithEvents btnSetPosterLocal As System.Windows.Forms.Button
    Friend WithEvents pbPoster As System.Windows.Forms.PictureBox
    Friend WithEvents btnSetFanartLocal As System.Windows.Forms.Button
    Friend WithEvents pbFanart As System.Windows.Forms.PictureBox
    Friend WithEvents ofdLocalFiles As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblRuntime As System.Windows.Forms.Label
    Friend WithEvents txtRuntime As System.Windows.Forms.TextBox
    Friend WithEvents lblReleaseDate As System.Windows.Forms.Label
    Friend WithEvents lblCreditsCreators As System.Windows.Forms.Label
    Friend WithEvents lblCertifications As System.Windows.Forms.Label
    Friend WithEvents lblTrailerURL As System.Windows.Forms.Label
    Friend WithEvents txtTrailer As System.Windows.Forms.TextBox
    Friend WithEvents btnSetPosterScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetFanartScrape As System.Windows.Forms.Button
    Friend WithEvents lblPosterSize As System.Windows.Forms.Label
    Friend WithEvents lblFanartSize As System.Windows.Forms.Label
    Friend WithEvents tpFrameExtraction As System.Windows.Forms.TabPage
    Friend WithEvents chkMarked As System.Windows.Forms.CheckBox
    Friend WithEvents tpExtrathumbs As System.Windows.Forms.TabPage
    Friend WithEvents pbExtrathumbs As System.Windows.Forms.PictureBox
    Friend WithEvents btnExtrathumbsDown As System.Windows.Forms.Button
    Friend WithEvents btnExtrathumbsUp As System.Windows.Forms.Button
    Friend WithEvents btnExtrathumbsRemove As System.Windows.Forms.Button
    Friend WithEvents btnRescrape As System.Windows.Forms.Button
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnRemovePoster As System.Windows.Forms.Button
    Friend WithEvents btnRemoveFanart As System.Windows.Forms.Button
    Friend WithEvents btnExtrathumbsRefresh As System.Windows.Forms.Button
    Friend WithEvents clbGenres As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlExtrathumbsSetAsFanart As System.Windows.Forms.Panel
    Friend WithEvents btnExtrathumbsSetAsFanart As System.Windows.Forms.Button
    Friend WithEvents btnAdd_Trailer As System.Windows.Forms.Button
    Friend WithEvents btnPlay_Trailer As System.Windows.Forms.Button
    Friend WithEvents btnSetPosterDL As System.Windows.Forms.Button
    Friend WithEvents btnSetFanartDL As System.Windows.Forms.Button
    Friend WithEvents tpMetaData As System.Windows.Forms.TabPage
    Friend WithEvents pnlFileInfo As System.Windows.Forms.Panel
    Friend WithEvents lblSortTilte As System.Windows.Forms.Label
    Friend WithEvents txtSortTitle As System.Windows.Forms.TextBox
    Friend WithEvents tmrDelay As System.Windows.Forms.Timer
    Friend WithEvents btnDown_Actor As System.Windows.Forms.Button
    Friend WithEvents btnUp_Actor As System.Windows.Forms.Button
    Friend WithEvents pnlFrameExtrator As System.Windows.Forms.Panel
    Friend WithEvents txtVideoSource As System.Windows.Forms.TextBox
    Friend WithEvents lblVideoSource As System.Windows.Forms.Label
    Friend WithEvents txtOriginalTitle As System.Windows.Forms.TextBox
    Friend WithEvents lblOriginalTitle As System.Windows.Forms.Label
    Friend WithEvents chkWatched As System.Windows.Forms.CheckBox
    Friend WithEvents tpExtrafanarts As System.Windows.Forms.TabPage
    Friend WithEvents pnlExtrafanartsSetAsFanart As System.Windows.Forms.Panel
    Friend WithEvents btnExtrafanartsSetAsFanart As System.Windows.Forms.Button
    Friend WithEvents btnExtrafanartsRefresh As System.Windows.Forms.Button
    Friend WithEvents btnExtrafanartsRemove As System.Windows.Forms.Button
    Friend WithEvents pbExtrafanarts As System.Windows.Forms.PictureBox
    Friend WithEvents pnlExtrathumbs As System.Windows.Forms.Panel
    Friend WithEvents pnlExtrafanarts As System.Windows.Forms.Panel
    Friend WithEvents lblExtrafanartsSize As System.Windows.Forms.Label
    Friend WithEvents lblExtrathumbsSize As System.Windows.Forms.Label
    Friend WithEvents tpMediaStub As System.Windows.Forms.TabPage
    Friend WithEvents lblMediaStubMessage As System.Windows.Forms.Label
    Friend WithEvents lblMediaStubTitle As System.Windows.Forms.Label
    Friend WithEvents txtMediaStubMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtMediaStubTitle As System.Windows.Forms.TextBox
    Friend WithEvents tpBanner As System.Windows.Forms.TabPage
    Friend WithEvents btnSetBannerDL As System.Windows.Forms.Button
    Friend WithEvents btnRemoveBanner As System.Windows.Forms.Button
    Friend WithEvents lblBannerSize As System.Windows.Forms.Label
    Friend WithEvents btnSetBannerScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetBannerLocal As System.Windows.Forms.Button
    Friend WithEvents pbBanner As System.Windows.Forms.PictureBox
    Friend WithEvents tpLandscape As System.Windows.Forms.TabPage
    Friend WithEvents btnSetLandscapeDL As System.Windows.Forms.Button
    Friend WithEvents btnRemoveLandscape As System.Windows.Forms.Button
    Friend WithEvents lblLandscapeSize As System.Windows.Forms.Label
    Friend WithEvents btnSetLandscapeScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetLandscapeLocal As System.Windows.Forms.Button
    Friend WithEvents pbLandscape As System.Windows.Forms.PictureBox
    Friend WithEvents tpClearArt As System.Windows.Forms.TabPage
    Friend WithEvents btnSetClearArtDL As System.Windows.Forms.Button
    Friend WithEvents btnRemoveClearArt As System.Windows.Forms.Button
    Friend WithEvents lblClearArtSize As System.Windows.Forms.Label
    Friend WithEvents btnSetClearArtScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetClearArtLocal As System.Windows.Forms.Button
    Friend WithEvents pbClearArt As System.Windows.Forms.PictureBox
    Friend WithEvents tpClearLogo As System.Windows.Forms.TabPage
    Friend WithEvents btnSetClearLogoDL As System.Windows.Forms.Button
    Friend WithEvents btnRemoveClearLogo As System.Windows.Forms.Button
    Friend WithEvents lblClearLogoSize As System.Windows.Forms.Label
    Friend WithEvents btnSetClearLogoScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetClearLogoLocal As System.Windows.Forms.Button
    Friend WithEvents pbClearLogo As System.Windows.Forms.PictureBox
    Friend WithEvents tpDiscArt As System.Windows.Forms.TabPage
    Friend WithEvents btnSetDiscArtDL As System.Windows.Forms.Button
    Friend WithEvents btnRemoveDiscArt As System.Windows.Forms.Button
    Friend WithEvents lblDiscArtSize As System.Windows.Forms.Label
    Friend WithEvents btnSetDiscArtScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetDiscArtLocal As System.Windows.Forms.Button
    Friend WithEvents pbDiscArt As System.Windows.Forms.PictureBox
    Friend WithEvents tpTrailer As System.Windows.Forms.TabPage
    Friend WithEvents tpTheme As System.Windows.Forms.TabPage
    Friend WithEvents btnSetTrailerDL As System.Windows.Forms.Button
    Friend WithEvents btnRemoveTrailer As System.Windows.Forms.Button
    Friend WithEvents btnSetTrailerScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetTrailerLocal As System.Windows.Forms.Button
    Friend WithEvents btnSetThemeDL As System.Windows.Forms.Button
    Friend WithEvents btnRemoveTheme As System.Windows.Forms.Button
    Friend WithEvents btnSetThemeScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetThemeLocal As System.Windows.Forms.Button
    Friend WithEvents tpSubtitles As System.Windows.Forms.TabPage
    Friend WithEvents btnRemoveSubtitle As System.Windows.Forms.Button
    Friend WithEvents btnSetSubtitleDL As System.Windows.Forms.Button
    Friend WithEvents btnSetSubtitleScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetSubtitleLocal As System.Windows.Forms.Button
    Friend WithEvents lvSubtitles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblSubtitlesPreview As System.Windows.Forms.Label
    Friend WithEvents txtSubtitlesPreview As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tsFilename As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtMPAA As System.Windows.Forms.TextBox
    Friend WithEvents pnlTrailerPreview As System.Windows.Forms.Panel
    Friend WithEvents pnlTrailerPreviewNoPlayer As System.Windows.Forms.Panel
    Friend WithEvents tblTrailerPreviewNoPlayer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTrailerPreviewNoPlayer As System.Windows.Forms.Label
    Friend WithEvents pnlThemePreview As System.Windows.Forms.Panel
    Friend WithEvents pnlThemePreviewNoPlayer As System.Windows.Forms.Panel
    Friend WithEvents tblThemePreviewNoPlayer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblThemePreviewNoPlayer As System.Windows.Forms.Label
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtLastPlayed As System.Windows.Forms.TextBox
    Friend WithEvents btnSetExtrafanartsScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetExtrathumbsScrape As System.Windows.Forms.Button
    Friend WithEvents cbLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents btnLocalTrailerPlay As Button
    Friend WithEvents txtLocalTrailer As TextBox
    Friend WithEvents btnLocalThemePlay As Button
    Friend WithEvents txtLocalTheme As TextBox
    Friend WithEvents lblUserRating As Label
    Friend WithEvents tblDetailsGenresTagsShowlink As TableLayoutPanel
    Friend WithEvents lblTags As Label
    Friend WithEvents clbTags As CheckedListBox
    Friend WithEvents txtIMDB As TextBox
    Friend WithEvents lblIMDB As Label
    Friend WithEvents lblTMDB As Label
    Friend WithEvents txtTMDB As TextBox
    Friend WithEvents lblTVDB As Label
    Friend WithEvents txtTVDB As TextBox
    Friend WithEvents lblTMDBCollection As Label
    Friend WithEvents txtTMDBCollection As TextBox
    Friend WithEvents tblDetailsInfo As TableLayoutPanel
    Friend WithEvents tblDetailsMain As TableLayoutPanel
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents lblSeason As Label
    Friend WithEvents txtSeason As TextBox
    Friend WithEvents lblEpisode As Label
    Friend WithEvents txtEpisode As TextBox
    Friend WithEvents lblTVShowLinks As Label
    Friend WithEvents tblDetailsMPAA As TableLayoutPanel
    Friend WithEvents clbTVShowLinks As CheckedListBox
    Friend WithEvents pnlEdit As Panel
    Friend WithEvents pnlEditBottom As Panel
    Friend WithEvents tblEditTop As TableLayoutPanel
    Friend WithEvents pnlEditMain As Panel
    Friend WithEvents pnlEditTop As Panel
    Friend WithEvents tblEditBottom As TableLayoutPanel
    Friend WithEvents chkLocked As CheckBox
    Friend WithEvents cbUserRating As ComboBox
    Friend WithEvents txtRating As TextBox
    Friend WithEvents lbCertifications As ListBox
    Friend WithEvents tblActors As TableLayoutPanel
    Friend WithEvents lvSpecialGuests As ListView
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents btnAdd_SpecialGuest As Button
    Friend WithEvents btnEdit_SpecialGuest As Button
    Friend WithEvents btnUp_SpecialGuest As Button
    Friend WithEvents btnDown_SpecialGuest As Button
    Friend WithEvents btnRemove_SpecialGuest As Button
    Friend WithEvents tblDetailsCrew As TableLayoutPanel
    Friend WithEvents lbDirectors As ListBox
    Friend WithEvents lbCreditsCreators As ListBox
    Friend WithEvents tblSpecialGuests As TableLayoutPanel
    Friend WithEvents tcCrew As TabControl
    Friend WithEvents tpActors As TabPage
    Friend WithEvents tpSpecialGuests As TabPage
    Friend WithEvents pnlDetails As Panel
    Friend WithEvents tblDetailsColumn3 As TableLayoutPanel
    Friend WithEvents lblCountries As Label
    Friend WithEvents lbCountries As ListBox
    Friend WithEvents lblStudio As Label
    Friend WithEvents lbStudios As ListBox
    Friend WithEvents lblMPAA As Label
    Friend WithEvents tblDetails As TableLayoutPanel
    Friend WithEvents tblDetailsColumn1 As TableLayoutPanel
    Friend WithEvents tblDetailsColumn2 As TableLayoutPanel
    Friend WithEvents tblDetailsCollection As TableLayoutPanel
    Friend WithEvents lblCollection As Label
    Friend WithEvents cbCollection As ComboBox
    Friend WithEvents btnAdd_Collection As Button
    Friend WithEvents btnAdd_Genre As Button
    Friend WithEvents btnAdd_Tag As Button
    Friend WithEvents pnlDetailsColumn1 As Panel
    Friend WithEvents pnlDetailsColumn2 As Panel
    Friend WithEvents pnlDetailsColumn3 As Panel
    Friend WithEvents lblMPAAPreview As Label
    Friend WithEvents txtReleaseDate As MaskedTextBox
    Friend WithEvents txtYear As MaskedTextBox
    Friend WithEvents txtTop250 As MaskedTextBox
    Friend WithEvents lblOrdering As Label
    Friend WithEvents lblEpisodeSorting As Label
    Friend WithEvents cbOrdering As ComboBox
    Friend WithEvents cbEpisodeSorting As ComboBox
    Friend WithEvents tpMovies As TabPage
    Friend WithEvents pnlMovies As Panel
    Friend WithEvents tblMovies As TableLayoutPanel
    Friend WithEvents lblMoviesInMovieset As Label
    Friend WithEvents lblMoviesInDB As Label
    Friend WithEvents lvMoviesInSet As ListView
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents colOrdering As ColumnHeader
    Friend WithEvents colMovie As ColumnHeader
    Friend WithEvents btnMovieAdd As Button
    Friend WithEvents dgvMovies As DataGridView
    Friend WithEvents btnMovieUp As Button
    Friend WithEvents btnMovieDown As Button
    Friend WithEvents btnMovieRemove As Button
    Friend WithEvents txtSearchMovies As TextBox
    Friend WithEvents btnSearchMovie As Button
End Class
