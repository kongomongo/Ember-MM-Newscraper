<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Catch ex As Exception
        End Try
        Try
            'Finally
            MyBase.Dispose(disposing)
        Catch ex As Exception
        End Try
    End Sub

    Delegate Sub DelegateSub(ByVal b As Boolean)

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgSettings))
        Me.gbFileSystemCleanFiles = New System.Windows.Forms.GroupBox()
        Me.tcFileSystemCleaner = New System.Windows.Forms.TabControl()
        Me.tpFileSystemCleanerStandard = New System.Windows.Forms.TabPage()
        Me.chkCleanFolderJPG = New System.Windows.Forms.CheckBox()
        Me.chkCleanExtrathumbs = New System.Windows.Forms.CheckBox()
        Me.chkCleanMovieTBN = New System.Windows.Forms.CheckBox()
        Me.chkCleanMovieNameJPG = New System.Windows.Forms.CheckBox()
        Me.chkCleanMovieTBNb = New System.Windows.Forms.CheckBox()
        Me.chkCleanMovieJPG = New System.Windows.Forms.CheckBox()
        Me.chkCleanFanartJPG = New System.Windows.Forms.CheckBox()
        Me.chkCleanPosterJPG = New System.Windows.Forms.CheckBox()
        Me.chkCleanMovieFanartJPG = New System.Windows.Forms.CheckBox()
        Me.chkCleanPosterTBN = New System.Windows.Forms.CheckBox()
        Me.chkCleanMovieNFO = New System.Windows.Forms.CheckBox()
        Me.chkCleanDotFanartJPG = New System.Windows.Forms.CheckBox()
        Me.chkCleanMovieNFOb = New System.Windows.Forms.CheckBox()
        Me.tpFileSystemCleanerExpert = New System.Windows.Forms.TabPage()
        Me.chkFileSystemCleanerWhitelist = New System.Windows.Forms.CheckBox()
        Me.lblFileSystemCleanerWhitelist = New System.Windows.Forms.Label()
        Me.btnFileSystemCleanerWhitelistRemove = New System.Windows.Forms.Button()
        Me.btnFileSystemCleanerWhitelistAdd = New System.Windows.Forms.Button()
        Me.txtFileSystemCleanerWhitelist = New System.Windows.Forms.TextBox()
        Me.lstFileSystemCleanerWhitelist = New System.Windows.Forms.ListBox()
        Me.lblFileSystemCleanerWarning = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ilSettings = New System.Windows.Forms.ImageList(Me.components)
        Me.tvSettingsList = New System.Windows.Forms.TreeView()
        Me.pnlFileSystem = New System.Windows.Forms.Panel()
        Me.tblFileSystem = New System.Windows.Forms.TableLayoutPanel()
        Me.gbFileSystemValidVideoExts = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemValidVideoExts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemValidVideoExtsRemove = New System.Windows.Forms.Button()
        Me.btnFileSystemValidVideoExtsReset = New System.Windows.Forms.Button()
        Me.btnFileSystemValidVideoExtsAdd = New System.Windows.Forms.Button()
        Me.lstFileSystemValidVideoExts = New System.Windows.Forms.ListBox()
        Me.txtFileSystemValidVideoExts = New System.Windows.Forms.TextBox()
        Me.gbFileSystemNoStackExts = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemNoStackExts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemNoStackExtsRemove = New System.Windows.Forms.Button()
        Me.lstFileSystemNoStackExts = New System.Windows.Forms.ListBox()
        Me.btnFileSystemNoStackExtsAdd = New System.Windows.Forms.Button()
        Me.txtFileSystemNoStackExts = New System.Windows.Forms.TextBox()
        Me.gbFileSystemExcludedDirs = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemExcludedDirs = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemExcludedDirsRemove = New System.Windows.Forms.Button()
        Me.lstFileSystemExcludedDirs = New System.Windows.Forms.ListBox()
        Me.btnFileSystemExcludedDirsAdd = New System.Windows.Forms.Button()
        Me.txtFileSystemExcludedDirs = New System.Windows.Forms.TextBox()
        Me.gbFileSystemValidSubtitlesExts = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemValidSubtitlesExts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemValidSubtitlesExtsRemove = New System.Windows.Forms.Button()
        Me.btnFileSystemValidSubtitlesExtsReset = New System.Windows.Forms.Button()
        Me.btnFileSystemValidSubtitlesExtsAdd = New System.Windows.Forms.Button()
        Me.lstFileSystemValidSubtitlesExts = New System.Windows.Forms.ListBox()
        Me.txtFileSystemValidSubtitlesExts = New System.Windows.Forms.TextBox()
        Me.gbFileSystemValidThemeExts = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemValidThemeExts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemValidThemeExtsRemove = New System.Windows.Forms.Button()
        Me.btnFileSystemValidThemeExtsReset = New System.Windows.Forms.Button()
        Me.btnFileSystemValidThemeExtsAdd = New System.Windows.Forms.Button()
        Me.lstFileSystemValidThemeExts = New System.Windows.Forms.ListBox()
        Me.txtFileSystemValidThemeExts = New System.Windows.Forms.TextBox()
        Me.lblSettingsCurrent = New System.Windows.Forms.Label()
        Me.pnlSettingsCurrent = New System.Windows.Forms.Panel()
        Me.pbSettingsCurrent = New System.Windows.Forms.PictureBox()
        Me.pnlTVGeneral = New System.Windows.Forms.Panel()
        Me.tblTVGeneral = New System.Windows.Forms.TableLayoutPanel()
        Me.gbTVGeneralCustomScrapeButton = New System.Windows.Forms.GroupBox()
        Me.tblTVGeneralCustomScrapeButton = New System.Windows.Forms.TableLayoutPanel()
        Me.cbTVGeneralCustomScrapeButtonScrapeType = New System.Windows.Forms.ComboBox()
        Me.cbTVGeneralCustomScrapeButtonModifierType = New System.Windows.Forms.ComboBox()
        Me.txtTVGeneralCustomScrapeButtonScrapeType = New System.Windows.Forms.Label()
        Me.txtTVGeneralCustomScrapeButtonModifierType = New System.Windows.Forms.Label()
        Me.rbTVGeneralCustomScrapeButtonEnabled = New System.Windows.Forms.RadioButton()
        Me.rbTVGeneralCustomScrapeButtonDisabled = New System.Windows.Forms.RadioButton()
        Me.gbTVGeneralMiscOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVGeneralMiscOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkTVGeneralMarkNewEpisodes = New System.Windows.Forms.CheckBox()
        Me.chkTVGeneralMarkNewShows = New System.Windows.Forms.CheckBox()
        Me.chkTVGeneralClickScrape = New System.Windows.Forms.CheckBox()
        Me.chkTVGeneralClickScrapeAsk = New System.Windows.Forms.CheckBox()
        Me.gbTVGeneralMediaListOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVGeneralMediaListOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.gbTVGeneralEpisodeListSorting = New System.Windows.Forms.GroupBox()
        Me.tblTVGeneralEpisodeListSorting = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTVGeneralEpisodeListSortingDown = New System.Windows.Forms.Button()
        Me.btnTVGeneralEpisodeListSortingUp = New System.Windows.Forms.Button()
        Me.lvTVGeneralEpisodeListSorting = New System.Windows.Forms.ListView()
        Me.colTVGeneralEpisodeListSortingDisplayIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralEpisodeListSortingColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralEpisodeListSortingLabel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralEpisodeListSortingHide = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnTVGeneralEpisodeListSortingReset = New System.Windows.Forms.Button()
        Me.gbTVGeneralSeasonListSortingOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVGeneralSeasonListSorting = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTVGeneralSeasonListSortingDown = New System.Windows.Forms.Button()
        Me.btnTVGeneralSeasonListSortingUp = New System.Windows.Forms.Button()
        Me.lvTVGeneralSeasonListSorting = New System.Windows.Forms.ListView()
        Me.colTVGeneralSeasonListSortingDisplayIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralSeasonListSortingColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralSeasonListSortingLabel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralSeasonListSortingHide = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnTVGeneralSeasonListSortingReset = New System.Windows.Forms.Button()
        Me.gbTVGeneralShowListSortingOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVGeneralShowListSorting = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTVGeneralShowListSortingDown = New System.Windows.Forms.Button()
        Me.btnTVGeneralShowListSortingUp = New System.Windows.Forms.Button()
        Me.lvTVGeneralShowListSorting = New System.Windows.Forms.ListView()
        Me.colTVGeneralShowListSortingDisplayIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralShowListSortingColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralShowListSortingLabel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTVGeneralShowListSortingHide = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnTVGeneralShowListSortingReset = New System.Windows.Forms.Button()
        Me.chkTVDisplayMissingEpisodes = New System.Windows.Forms.CheckBox()
        Me.chkTVDisplayStatus = New System.Windows.Forms.CheckBox()
        Me.gbTVGeneralMediaListSortTokensOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVGeneralMediaListSortTokensOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTVSortTokenReset = New System.Windows.Forms.Button()
        Me.btnTVSortTokenRemove = New System.Windows.Forms.Button()
        Me.lstTVSortTokens = New System.Windows.Forms.ListBox()
        Me.btnTVSortTokenAdd = New System.Windows.Forms.Button()
        Me.txtTVSortToken = New System.Windows.Forms.TextBox()
        Me.gbTVGeneralMainWindowOpts = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTVLanguageOverlay = New System.Windows.Forms.Label()
        Me.cbTVLanguageOverlay = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.fbdBrowse = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlTVScraper = New System.Windows.Forms.Panel()
        Me.tblTVScraper = New System.Windows.Forms.TableLayoutPanel()
        Me.gbTVScraperCertificationOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVScraperCertificationOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkTVScraperShowCertOnlyValue = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowCertFSK = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowCertForMPAAFallback = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowCertForMPAA = New System.Windows.Forms.CheckBox()
        Me.txtTVScraperShowMPAANotRated = New System.Windows.Forms.TextBox()
        Me.lblTVScraperShowMPAANotRated = New System.Windows.Forms.Label()
        Me.gbTVScraperGlobalOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVScraperGlobalOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkTVLockEpisodeRuntime = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowRuntime = New System.Windows.Forms.CheckBox()
        Me.cbTVScraperShowCertLang = New System.Windows.Forms.ComboBox()
        Me.chkTVLockEpisodeRating = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowStudio = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowStatus = New System.Windows.Forms.CheckBox()
        Me.chkTVLockEpisodePlot = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowGenre = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowPlot = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodeActors = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowRating = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodeRuntime = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodeCredits = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalHeaderShows = New System.Windows.Forms.Label()
        Me.chkTVScraperEpisodeDirector = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowStatus = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodePlot = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowRuntime = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodeAired = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodeRating = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowActors = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowRating = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowStudio = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalHeaderEpisodes = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalHeaderShowsLock = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalHeaderEpisodesLock = New System.Windows.Forms.Label()
        Me.chkTVScraperShowPremiered = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalActors = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalAired = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalCredits = New System.Windows.Forms.Label()
        Me.chkTVScraperShowPlot = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowMPAA = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowEpiGuideURL = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperShowGenre = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalEpisodeGuideURL = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalGenres = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalMPAA = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalPlot = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalPremiered = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalRating = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalRuntime = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalStatus = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalStudios = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalDirectors = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalTitle = New System.Windows.Forms.Label()
        Me.chkTVScraperShowTitle = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowTitle = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodeTitle = New System.Windows.Forms.CheckBox()
        Me.chkTVLockEpisodeTitle = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalGuestStars = New System.Windows.Forms.Label()
        Me.chkTVScraperEpisodeGuestStars = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalLanguageA = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalLanguageV = New System.Windows.Forms.Label()
        Me.chkTVLockEpisodeLanguageA = New System.Windows.Forms.CheckBox()
        Me.chkTVLockEpisodeLanguageV = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalHeaderShowsLimit = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalCertifications = New System.Windows.Forms.Label()
        Me.chkTVScraperShowCert = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowCert = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalOriginalTitle = New System.Windows.Forms.Label()
        Me.chkTVScraperShowOriginalTitle = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowOriginalTitle = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowMPAA = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalCreators = New System.Windows.Forms.Label()
        Me.chkTVScraperShowCreators = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowCreators = New System.Windows.Forms.CheckBox()
        Me.chkTVLockSeasonPlot = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperSeasonPlot = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalHeaderSeasonsLock = New System.Windows.Forms.Label()
        Me.lblTVScraperGlobalHeaderSeasons = New System.Windows.Forms.Label()
        Me.chkTVScraperSeasonAired = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperSeasonTitle = New System.Windows.Forms.CheckBox()
        Me.chkTVLockSeasonTitle = New System.Windows.Forms.CheckBox()
        Me.lblTVScraperGlobalUserRating = New System.Windows.Forms.Label()
        Me.chkTVScraperShowUserRating = New System.Windows.Forms.CheckBox()
        Me.chkTVLockShowUserRating = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodeUserRating = New System.Windows.Forms.CheckBox()
        Me.chkTVLockEpisodeUserRating = New System.Windows.Forms.CheckBox()
        Me.gbTVScraperMetaDataOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVScraperMetaDataOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.gbTVScraperDefFIExtOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVScraperDefFIExtOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTVScraperDefFIExtRemove = New System.Windows.Forms.Button()
        Me.txtTVScraperDefFIExt = New System.Windows.Forms.TextBox()
        Me.btnTVScraperDefFIExtEdit = New System.Windows.Forms.Button()
        Me.lstTVScraperDefFIExt = New System.Windows.Forms.ListBox()
        Me.btnTVScraperDefFIExtAdd = New System.Windows.Forms.Button()
        Me.lblTVScraperDefFIExt = New System.Windows.Forms.Label()
        Me.chkTVScraperMetaDataScan = New System.Windows.Forms.CheckBox()
        Me.gbTVScraperDurationFormatOpts = New System.Windows.Forms.GroupBox()
        Me.tblgbTVScraperDurationFormatOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkTVScraperUseMDDuration = New System.Windows.Forms.CheckBox()
        Me.txtTVScraperDurationRuntimeFormat = New System.Windows.Forms.TextBox()
        Me.lblTVScraperDurationRuntimeFormat = New System.Windows.Forms.Label()
        Me.gbTVScraperMiscOpts = New System.Windows.Forms.GroupBox()
        Me.tblTVScraperMiscOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkTVScraperUseSRuntimeForEp = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperCleanFields = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperUseDisplaySeasonEpisode = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperEpisodeGuestStarsToActors = New System.Windows.Forms.CheckBox()
        Me.chkTVScraperCastWithImg = New System.Windows.Forms.CheckBox()
        Me.tsSettingsTopMenu = New System.Windows.Forms.ToolStrip()
        Me.pnlSettingsMain = New System.Windows.Forms.Panel()
        Me.gbSettingsHelp = New System.Windows.Forms.GroupBox()
        Me.pbSettingsHelpLogo = New System.Windows.Forms.PictureBox()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.pnlSettingsHelp = New System.Windows.Forms.Panel()
        Me.fileBrowse = New System.Windows.Forms.OpenFileDialog()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.pnlMovieSetGeneral = New System.Windows.Forms.Panel()
        Me.tblMovieSetGeneral = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetGeneralCustomScrapeButton = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetGeneralCustomScrapeButton = New System.Windows.Forms.TableLayoutPanel()
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType = New System.Windows.Forms.ComboBox()
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType = New System.Windows.Forms.ComboBox()
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType = New System.Windows.Forms.Label()
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType = New System.Windows.Forms.Label()
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled = New System.Windows.Forms.RadioButton()
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled = New System.Windows.Forms.RadioButton()
        Me.gbMovieSetGeneralMediaListOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetGeneralMediaListOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetGeneralMediaListSorting = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetGeneralMediaListSorting = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieSetGeneralMediaListSortingDown = New System.Windows.Forms.Button()
        Me.btnMovieSetGeneralMediaListSortingUp = New System.Windows.Forms.Button()
        Me.lvMovieSetGeneralMediaListSorting = New System.Windows.Forms.ListView()
        Me.colMovieSetGeneralMediaListSortingDisplayIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSetGeneralMediaListSortingColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSetGeneralMediaListSortingLabel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSetGeneralMediaListSortingHide = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnMovieSetGeneralMediaListSortingReset = New System.Windows.Forms.Button()
        Me.gbMovieSetGeneralMediaListSortTokensOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetGeneralSortTokensOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieSetSortTokenReset = New System.Windows.Forms.Button()
        Me.btnMovieSetSortTokenRemove = New System.Windows.Forms.Button()
        Me.lstMovieSetSortTokens = New System.Windows.Forms.ListBox()
        Me.btnMovieSetSortTokenAdd = New System.Windows.Forms.Button()
        Me.txtMovieSetSortToken = New System.Windows.Forms.TextBox()
        Me.gbMovieSetGeneralMiscOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetGeneralMiscOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieSetClickScrapeAsk = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetClickScrape = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetGeneralMarkNew = New System.Windows.Forms.CheckBox()
        Me.scSettings = New System.Windows.Forms.SplitContainer()
        Me.tblSettingsCurrent = New System.Windows.Forms.TableLayoutPanel()
        Me.scSettingsBody = New System.Windows.Forms.SplitContainer()
        Me.scSettingsMain = New System.Windows.Forms.SplitContainer()
        Me.tblSettingsFooter = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.CheckBox16 = New System.Windows.Forms.CheckBox()
        Me.CheckBox17 = New System.Windows.Forms.CheckBox()
        Me.CheckBox18 = New System.Windows.Forms.CheckBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox19 = New System.Windows.Forms.CheckBox()
        Me.CheckBox20 = New System.Windows.Forms.CheckBox()
        Me.CheckBox21 = New System.Windows.Forms.CheckBox()
        Me.CheckBox22 = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.CheckBox23 = New System.Windows.Forms.CheckBox()
        Me.CheckBox24 = New System.Windows.Forms.CheckBox()
        Me.CheckBox25 = New System.Windows.Forms.CheckBox()
        Me.CheckBox26 = New System.Windows.Forms.CheckBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CheckBox27 = New System.Windows.Forms.CheckBox()
        Me.CheckBox28 = New System.Windows.Forms.CheckBox()
        Me.CheckBox29 = New System.Windows.Forms.CheckBox()
        Me.CheckBox30 = New System.Windows.Forms.CheckBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox34 = New System.Windows.Forms.CheckBox()
        Me.CheckBox35 = New System.Windows.Forms.CheckBox()
        Me.CheckBox36 = New System.Windows.Forms.CheckBox()
        Me.ComboBox10 = New System.Windows.Forms.ComboBox()
        Me.CheckBox37 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.CheckBox13 = New System.Windows.Forms.CheckBox()
        Me.CheckBox14 = New System.Windows.Forms.CheckBox()
        Me.CheckBox15 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.CheckBox31 = New System.Windows.Forms.CheckBox()
        Me.CheckBox32 = New System.Windows.Forms.CheckBox()
        Me.CheckBox33 = New System.Windows.Forms.CheckBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel31 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox69 = New System.Windows.Forms.CheckBox()
        Me.TextBox44 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel30 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel29 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel16 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel15 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel20 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel18 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel24 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel22 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel23 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox62 = New System.Windows.Forms.CheckBox()
        Me.CheckBox63 = New System.Windows.Forms.CheckBox()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel28 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel26 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.TextBox35 = New System.Windows.Forms.TextBox()
        Me.TextBox36 = New System.Windows.Forms.TextBox()
        Me.TextBox37 = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.TextBox38 = New System.Windows.Forms.TextBox()
        Me.TextBox39 = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.TextBox40 = New System.Windows.Forms.TextBox()
        Me.TextBox41 = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.TextBox42 = New System.Windows.Forms.TextBox()
        Me.TextBox43 = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel25 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox65 = New System.Windows.Forms.CheckBox()
        Me.CheckBox66 = New System.Windows.Forms.CheckBox()
        Me.TextBox34 = New System.Windows.Forms.TextBox()
        Me.CheckBox64 = New System.Windows.Forms.CheckBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel27 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox67 = New System.Windows.Forms.CheckBox()
        Me.CheckBox68 = New System.Windows.Forms.CheckBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox53 = New System.Windows.Forms.CheckBox()
        Me.CheckBox43 = New System.Windows.Forms.CheckBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.CheckBox52 = New System.Windows.Forms.CheckBox()
        Me.CheckBox42 = New System.Windows.Forms.CheckBox()
        Me.CheckBox56 = New System.Windows.Forms.CheckBox()
        Me.CheckBox54 = New System.Windows.Forms.CheckBox()
        Me.CheckBox55 = New System.Windows.Forms.CheckBox()
        Me.CheckBox59 = New System.Windows.Forms.CheckBox()
        Me.CheckBox40 = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel19 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox57 = New System.Windows.Forms.CheckBox()
        Me.CheckBox58 = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CheckBox38 = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CheckBox39 = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.CheckBox41 = New System.Windows.Forms.CheckBox()
        Me.CheckBox44 = New System.Windows.Forms.CheckBox()
        Me.CheckBox45 = New System.Windows.Forms.CheckBox()
        Me.CheckBox46 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel21 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox60 = New System.Windows.Forms.CheckBox()
        Me.CheckBox61 = New System.Windows.Forms.CheckBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.CheckBox51 = New System.Windows.Forms.CheckBox()
        Me.CheckBox47 = New System.Windows.Forms.CheckBox()
        Me.CheckBox48 = New System.Windows.Forms.CheckBox()
        Me.CheckBox49 = New System.Windows.Forms.CheckBox()
        Me.CheckBox50 = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel17 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.gbFileSystemCleanFiles.SuspendLayout()
        Me.tcFileSystemCleaner.SuspendLayout()
        Me.tpFileSystemCleanerStandard.SuspendLayout()
        Me.tpFileSystemCleanerExpert.SuspendLayout()
        Me.pnlFileSystem.SuspendLayout()
        Me.tblFileSystem.SuspendLayout()
        Me.gbFileSystemValidVideoExts.SuspendLayout()
        Me.tblFileSystemValidVideoExts.SuspendLayout()
        Me.gbFileSystemNoStackExts.SuspendLayout()
        Me.tblFileSystemNoStackExts.SuspendLayout()
        Me.gbFileSystemExcludedDirs.SuspendLayout()
        Me.tblFileSystemExcludedDirs.SuspendLayout()
        Me.gbFileSystemValidSubtitlesExts.SuspendLayout()
        Me.tblFileSystemValidSubtitlesExts.SuspendLayout()
        Me.gbFileSystemValidThemeExts.SuspendLayout()
        Me.tblFileSystemValidThemeExts.SuspendLayout()
        Me.pnlSettingsCurrent.SuspendLayout()
        CType(Me.pbSettingsCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTVGeneral.SuspendLayout()
        Me.tblTVGeneral.SuspendLayout()
        Me.gbTVGeneralCustomScrapeButton.SuspendLayout()
        Me.tblTVGeneralCustomScrapeButton.SuspendLayout()
        Me.gbTVGeneralMiscOpts.SuspendLayout()
        Me.tblTVGeneralMiscOpts.SuspendLayout()
        Me.gbTVGeneralMediaListOpts.SuspendLayout()
        Me.tblTVGeneralMediaListOpts.SuspendLayout()
        Me.gbTVGeneralEpisodeListSorting.SuspendLayout()
        Me.tblTVGeneralEpisodeListSorting.SuspendLayout()
        Me.gbTVGeneralSeasonListSortingOpts.SuspendLayout()
        Me.tblTVGeneralSeasonListSorting.SuspendLayout()
        Me.gbTVGeneralShowListSortingOpts.SuspendLayout()
        Me.tblTVGeneralShowListSorting.SuspendLayout()
        Me.gbTVGeneralMediaListSortTokensOpts.SuspendLayout()
        Me.tblTVGeneralMediaListSortTokensOpts.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.pnlTVScraper.SuspendLayout()
        Me.tblTVScraper.SuspendLayout()
        Me.gbTVScraperCertificationOpts.SuspendLayout()
        Me.tblTVScraperCertificationOpts.SuspendLayout()
        Me.gbTVScraperGlobalOpts.SuspendLayout()
        Me.tblTVScraperGlobalOpts.SuspendLayout()
        Me.gbTVScraperMetaDataOpts.SuspendLayout()
        Me.tblTVScraperMetaDataOpts.SuspendLayout()
        Me.gbTVScraperDefFIExtOpts.SuspendLayout()
        Me.tblTVScraperDefFIExtOpts.SuspendLayout()
        Me.gbTVScraperDurationFormatOpts.SuspendLayout()
        Me.tblgbTVScraperDurationFormatOpts.SuspendLayout()
        Me.gbTVScraperMiscOpts.SuspendLayout()
        Me.tblTVScraperMiscOpts.SuspendLayout()
        Me.gbSettingsHelp.SuspendLayout()
        CType(Me.pbSettingsHelpLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSettingsHelp.SuspendLayout()
        Me.pnlMovieSetGeneral.SuspendLayout()
        Me.tblMovieSetGeneral.SuspendLayout()
        Me.gbMovieSetGeneralCustomScrapeButton.SuspendLayout()
        Me.tblMovieSetGeneralCustomScrapeButton.SuspendLayout()
        Me.gbMovieSetGeneralMediaListOpts.SuspendLayout()
        Me.tblMovieSetGeneralMediaListOpts.SuspendLayout()
        Me.gbMovieSetGeneralMediaListSorting.SuspendLayout()
        Me.tblMovieSetGeneralMediaListSorting.SuspendLayout()
        Me.gbMovieSetGeneralMediaListSortTokensOpts.SuspendLayout()
        Me.tblMovieSetGeneralSortTokensOpts.SuspendLayout()
        Me.gbMovieSetGeneralMiscOpts.SuspendLayout()
        Me.tblMovieSetGeneralMiscOpts.SuspendLayout()
        CType(Me.scSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSettings.Panel1.SuspendLayout()
        Me.scSettings.Panel2.SuspendLayout()
        Me.scSettings.SuspendLayout()
        Me.tblSettingsCurrent.SuspendLayout()
        CType(Me.scSettingsBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSettingsBody.Panel1.SuspendLayout()
        Me.scSettingsBody.Panel2.SuspendLayout()
        Me.scSettingsBody.SuspendLayout()
        CType(Me.scSettingsMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSettingsMain.Panel1.SuspendLayout()
        Me.scSettingsMain.Panel2.SuspendLayout()
        Me.scSettingsMain.SuspendLayout()
        Me.tblSettingsFooter.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbFileSystemCleanFiles
        '
        Me.gbFileSystemCleanFiles.AutoSize = True
        Me.gbFileSystemCleanFiles.Controls.Add(Me.tcFileSystemCleaner)
        Me.gbFileSystemCleanFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemCleanFiles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemCleanFiles.Location = New System.Drawing.Point(339, 134)
        Me.gbFileSystemCleanFiles.Name = "gbFileSystemCleanFiles"
        Me.tblFileSystem.SetRowSpan(Me.gbFileSystemCleanFiles, 2)
        Me.gbFileSystemCleanFiles.Size = New System.Drawing.Size(192, 215)
        Me.gbFileSystemCleanFiles.TabIndex = 2
        Me.gbFileSystemCleanFiles.TabStop = False
        Me.gbFileSystemCleanFiles.Text = "Clean Files"
        Me.gbFileSystemCleanFiles.Visible = False
        '
        'tcFileSystemCleaner
        '
        Me.tcFileSystemCleaner.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcFileSystemCleaner.Controls.Add(Me.tpFileSystemCleanerStandard)
        Me.tcFileSystemCleaner.Controls.Add(Me.tpFileSystemCleanerExpert)
        Me.tcFileSystemCleaner.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tcFileSystemCleaner.Location = New System.Drawing.Point(6, 19)
        Me.tcFileSystemCleaner.Name = "tcFileSystemCleaner"
        Me.tcFileSystemCleaner.SelectedIndex = 0
        Me.tcFileSystemCleaner.Size = New System.Drawing.Size(180, 161)
        Me.tcFileSystemCleaner.TabIndex = 0
        '
        'tpFileSystemCleanerStandard
        '
        Me.tpFileSystemCleanerStandard.BackColor = System.Drawing.Color.White
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanFolderJPG)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanExtrathumbs)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanMovieTBN)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanMovieNameJPG)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanMovieTBNb)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanMovieJPG)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanFanartJPG)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanPosterJPG)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanMovieFanartJPG)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanPosterTBN)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanMovieNFO)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanDotFanartJPG)
        Me.tpFileSystemCleanerStandard.Controls.Add(Me.chkCleanMovieNFOb)
        Me.tpFileSystemCleanerStandard.Location = New System.Drawing.Point(4, 25)
        Me.tpFileSystemCleanerStandard.Name = "tpFileSystemCleanerStandard"
        Me.tpFileSystemCleanerStandard.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFileSystemCleanerStandard.Size = New System.Drawing.Size(172, 132)
        Me.tpFileSystemCleanerStandard.TabIndex = 0
        Me.tpFileSystemCleanerStandard.Text = "Standard"
        Me.tpFileSystemCleanerStandard.UseVisualStyleBackColor = True
        '
        'chkCleanFolderJPG
        '
        Me.chkCleanFolderJPG.AutoSize = True
        Me.chkCleanFolderJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanFolderJPG.Location = New System.Drawing.Point(7, 10)
        Me.chkCleanFolderJPG.Name = "chkCleanFolderJPG"
        Me.chkCleanFolderJPG.Size = New System.Drawing.Size(81, 17)
        Me.chkCleanFolderJPG.TabIndex = 0
        Me.chkCleanFolderJPG.Text = "/folder.jpg"
        Me.chkCleanFolderJPG.UseVisualStyleBackColor = True
        '
        'chkCleanExtrathumbs
        '
        Me.chkCleanExtrathumbs.AutoSize = True
        Me.chkCleanExtrathumbs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanExtrathumbs.Location = New System.Drawing.Point(7, 238)
        Me.chkCleanExtrathumbs.Name = "chkCleanExtrathumbs"
        Me.chkCleanExtrathumbs.Size = New System.Drawing.Size(98, 17)
        Me.chkCleanExtrathumbs.TabIndex = 12
        Me.chkCleanExtrathumbs.Text = "/extrathumbs/"
        Me.chkCleanExtrathumbs.UseVisualStyleBackColor = True
        '
        'chkCleanMovieTBN
        '
        Me.chkCleanMovieTBN.AutoSize = True
        Me.chkCleanMovieTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanMovieTBN.Location = New System.Drawing.Point(7, 29)
        Me.chkCleanMovieTBN.Name = "chkCleanMovieTBN"
        Me.chkCleanMovieTBN.Size = New System.Drawing.Size(81, 17)
        Me.chkCleanMovieTBN.TabIndex = 1
        Me.chkCleanMovieTBN.Text = "/movie.tbn"
        Me.chkCleanMovieTBN.UseVisualStyleBackColor = True
        '
        'chkCleanMovieNameJPG
        '
        Me.chkCleanMovieNameJPG.AutoSize = True
        Me.chkCleanMovieNameJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanMovieNameJPG.Location = New System.Drawing.Point(7, 124)
        Me.chkCleanMovieNameJPG.Name = "chkCleanMovieNameJPG"
        Me.chkCleanMovieNameJPG.Size = New System.Drawing.Size(96, 17)
        Me.chkCleanMovieNameJPG.TabIndex = 6
        Me.chkCleanMovieNameJPG.Text = "/<movie>.jpg"
        Me.chkCleanMovieNameJPG.UseVisualStyleBackColor = True
        '
        'chkCleanMovieTBNb
        '
        Me.chkCleanMovieTBNb.AutoSize = True
        Me.chkCleanMovieTBNb.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanMovieTBNb.Location = New System.Drawing.Point(7, 48)
        Me.chkCleanMovieTBNb.Name = "chkCleanMovieTBNb"
        Me.chkCleanMovieTBNb.Size = New System.Drawing.Size(97, 17)
        Me.chkCleanMovieTBNb.TabIndex = 2
        Me.chkCleanMovieTBNb.Text = "/<movie>.tbn"
        Me.chkCleanMovieTBNb.UseVisualStyleBackColor = True
        '
        'chkCleanMovieJPG
        '
        Me.chkCleanMovieJPG.AutoSize = True
        Me.chkCleanMovieJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanMovieJPG.Location = New System.Drawing.Point(7, 105)
        Me.chkCleanMovieJPG.Name = "chkCleanMovieJPG"
        Me.chkCleanMovieJPG.Size = New System.Drawing.Size(80, 17)
        Me.chkCleanMovieJPG.TabIndex = 5
        Me.chkCleanMovieJPG.Text = "/movie.jpg"
        Me.chkCleanMovieJPG.UseVisualStyleBackColor = True
        '
        'chkCleanFanartJPG
        '
        Me.chkCleanFanartJPG.AutoSize = True
        Me.chkCleanFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanFanartJPG.Location = New System.Drawing.Point(7, 143)
        Me.chkCleanFanartJPG.Name = "chkCleanFanartJPG"
        Me.chkCleanFanartJPG.Size = New System.Drawing.Size(81, 17)
        Me.chkCleanFanartJPG.TabIndex = 7
        Me.chkCleanFanartJPG.Text = "/fanart.jpg"
        Me.chkCleanFanartJPG.UseVisualStyleBackColor = True
        '
        'chkCleanPosterJPG
        '
        Me.chkCleanPosterJPG.AutoSize = True
        Me.chkCleanPosterJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanPosterJPG.Location = New System.Drawing.Point(7, 86)
        Me.chkCleanPosterJPG.Name = "chkCleanPosterJPG"
        Me.chkCleanPosterJPG.Size = New System.Drawing.Size(83, 17)
        Me.chkCleanPosterJPG.TabIndex = 4
        Me.chkCleanPosterJPG.Text = "/poster.jpg"
        Me.chkCleanPosterJPG.UseVisualStyleBackColor = True
        '
        'chkCleanMovieFanartJPG
        '
        Me.chkCleanMovieFanartJPG.AutoSize = True
        Me.chkCleanMovieFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanMovieFanartJPG.Location = New System.Drawing.Point(7, 162)
        Me.chkCleanMovieFanartJPG.Name = "chkCleanMovieFanartJPG"
        Me.chkCleanMovieFanartJPG.Size = New System.Drawing.Size(131, 17)
        Me.chkCleanMovieFanartJPG.TabIndex = 8
        Me.chkCleanMovieFanartJPG.Text = "/<movie>-fanart.jpg"
        Me.chkCleanMovieFanartJPG.UseVisualStyleBackColor = True
        '
        'chkCleanPosterTBN
        '
        Me.chkCleanPosterTBN.AutoSize = True
        Me.chkCleanPosterTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanPosterTBN.Location = New System.Drawing.Point(7, 67)
        Me.chkCleanPosterTBN.Name = "chkCleanPosterTBN"
        Me.chkCleanPosterTBN.Size = New System.Drawing.Size(84, 17)
        Me.chkCleanPosterTBN.TabIndex = 3
        Me.chkCleanPosterTBN.Text = "/poster.tbn"
        Me.chkCleanPosterTBN.UseVisualStyleBackColor = True
        '
        'chkCleanMovieNFO
        '
        Me.chkCleanMovieNFO.AutoSize = True
        Me.chkCleanMovieNFO.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanMovieNFO.Location = New System.Drawing.Point(7, 200)
        Me.chkCleanMovieNFO.Name = "chkCleanMovieNFO"
        Me.chkCleanMovieNFO.Size = New System.Drawing.Size(81, 17)
        Me.chkCleanMovieNFO.TabIndex = 10
        Me.chkCleanMovieNFO.Text = "/movie.nfo"
        Me.chkCleanMovieNFO.UseVisualStyleBackColor = True
        '
        'chkCleanDotFanartJPG
        '
        Me.chkCleanDotFanartJPG.AutoSize = True
        Me.chkCleanDotFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanDotFanartJPG.Location = New System.Drawing.Point(7, 181)
        Me.chkCleanDotFanartJPG.Name = "chkCleanDotFanartJPG"
        Me.chkCleanDotFanartJPG.Size = New System.Drawing.Size(130, 17)
        Me.chkCleanDotFanartJPG.TabIndex = 9
        Me.chkCleanDotFanartJPG.Text = "/<movie>.fanart.jpg"
        Me.chkCleanDotFanartJPG.UseVisualStyleBackColor = True
        '
        'chkCleanMovieNFOb
        '
        Me.chkCleanMovieNFOb.AutoSize = True
        Me.chkCleanMovieNFOb.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCleanMovieNFOb.Location = New System.Drawing.Point(7, 219)
        Me.chkCleanMovieNFOb.Name = "chkCleanMovieNFOb"
        Me.chkCleanMovieNFOb.Size = New System.Drawing.Size(97, 17)
        Me.chkCleanMovieNFOb.TabIndex = 11
        Me.chkCleanMovieNFOb.Text = "/<movie>.nfo"
        Me.chkCleanMovieNFOb.UseVisualStyleBackColor = True
        '
        'tpFileSystemCleanerExpert
        '
        Me.tpFileSystemCleanerExpert.BackColor = System.Drawing.Color.White
        Me.tpFileSystemCleanerExpert.Controls.Add(Me.chkFileSystemCleanerWhitelist)
        Me.tpFileSystemCleanerExpert.Controls.Add(Me.lblFileSystemCleanerWhitelist)
        Me.tpFileSystemCleanerExpert.Controls.Add(Me.btnFileSystemCleanerWhitelistRemove)
        Me.tpFileSystemCleanerExpert.Controls.Add(Me.btnFileSystemCleanerWhitelistAdd)
        Me.tpFileSystemCleanerExpert.Controls.Add(Me.txtFileSystemCleanerWhitelist)
        Me.tpFileSystemCleanerExpert.Controls.Add(Me.lstFileSystemCleanerWhitelist)
        Me.tpFileSystemCleanerExpert.Controls.Add(Me.lblFileSystemCleanerWarning)
        Me.tpFileSystemCleanerExpert.Location = New System.Drawing.Point(4, 25)
        Me.tpFileSystemCleanerExpert.Name = "tpFileSystemCleanerExpert"
        Me.tpFileSystemCleanerExpert.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFileSystemCleanerExpert.Size = New System.Drawing.Size(172, 132)
        Me.tpFileSystemCleanerExpert.TabIndex = 1
        Me.tpFileSystemCleanerExpert.Text = "Expert"
        Me.tpFileSystemCleanerExpert.UseVisualStyleBackColor = True
        '
        'chkFileSystemCleanerWhitelist
        '
        Me.chkFileSystemCleanerWhitelist.AutoSize = True
        Me.chkFileSystemCleanerWhitelist.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFileSystemCleanerWhitelist.Location = New System.Drawing.Point(4, 85)
        Me.chkFileSystemCleanerWhitelist.Name = "chkFileSystemCleanerWhitelist"
        Me.chkFileSystemCleanerWhitelist.Size = New System.Drawing.Size(163, 17)
        Me.chkFileSystemCleanerWhitelist.TabIndex = 1
        Me.chkFileSystemCleanerWhitelist.Text = "Whitelist Video Extensions"
        Me.chkFileSystemCleanerWhitelist.UseVisualStyleBackColor = True
        '
        'lblFileSystemCleanerWhitelist
        '
        Me.lblFileSystemCleanerWhitelist.AutoSize = True
        Me.lblFileSystemCleanerWhitelist.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileSystemCleanerWhitelist.Location = New System.Drawing.Point(19, 107)
        Me.lblFileSystemCleanerWhitelist.Name = "lblFileSystemCleanerWhitelist"
        Me.lblFileSystemCleanerWhitelist.Size = New System.Drawing.Size(127, 13)
        Me.lblFileSystemCleanerWhitelist.TabIndex = 2
        Me.lblFileSystemCleanerWhitelist.Text = "Whitelisted Extensions:"
        '
        'btnFileSystemCleanerWhitelistRemove
        '
        Me.btnFileSystemCleanerWhitelistRemove.Image = CType(resources.GetObject("btnFileSystemCleanerWhitelistRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemCleanerWhitelistRemove.Location = New System.Drawing.Point(134, 251)
        Me.btnFileSystemCleanerWhitelistRemove.Name = "btnFileSystemCleanerWhitelistRemove"
        Me.btnFileSystemCleanerWhitelistRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemCleanerWhitelistRemove.TabIndex = 6
        Me.btnFileSystemCleanerWhitelistRemove.UseVisualStyleBackColor = True
        '
        'btnFileSystemCleanerWhitelistAdd
        '
        Me.btnFileSystemCleanerWhitelistAdd.Image = CType(resources.GetObject("btnFileSystemCleanerWhitelistAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemCleanerWhitelistAdd.Location = New System.Drawing.Point(82, 251)
        Me.btnFileSystemCleanerWhitelistAdd.Name = "btnFileSystemCleanerWhitelistAdd"
        Me.btnFileSystemCleanerWhitelistAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemCleanerWhitelistAdd.TabIndex = 5
        Me.btnFileSystemCleanerWhitelistAdd.UseVisualStyleBackColor = True
        '
        'txtFileSystemCleanerWhitelist
        '
        Me.txtFileSystemCleanerWhitelist.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemCleanerWhitelist.Location = New System.Drawing.Point(20, 252)
        Me.txtFileSystemCleanerWhitelist.Name = "txtFileSystemCleanerWhitelist"
        Me.txtFileSystemCleanerWhitelist.Size = New System.Drawing.Size(61, 22)
        Me.txtFileSystemCleanerWhitelist.TabIndex = 4
        '
        'lstFileSystemCleanerWhitelist
        '
        Me.lstFileSystemCleanerWhitelist.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemCleanerWhitelist.FormattingEnabled = True
        Me.lstFileSystemCleanerWhitelist.Location = New System.Drawing.Point(19, 126)
        Me.lstFileSystemCleanerWhitelist.Name = "lstFileSystemCleanerWhitelist"
        Me.lstFileSystemCleanerWhitelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemCleanerWhitelist.Size = New System.Drawing.Size(138, 108)
        Me.lstFileSystemCleanerWhitelist.TabIndex = 3
        '
        'lblFileSystemCleanerWarning
        '
        Me.lblFileSystemCleanerWarning.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblFileSystemCleanerWarning.ForeColor = System.Drawing.Color.Red
        Me.lblFileSystemCleanerWarning.Location = New System.Drawing.Point(6, 10)
        Me.lblFileSystemCleanerWarning.Name = "lblFileSystemCleanerWarning"
        Me.lblFileSystemCleanerWarning.Size = New System.Drawing.Size(160, 68)
        Me.lblFileSystemCleanerWarning.TabIndex = 0
        Me.lblFileSystemCleanerWarning.Text = "WARNING: Using the Expert Mode Cleaner could potentially delete wanted files. Tak" &
    "e care when using this tool."
        Me.lblFileSystemCleanerWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOK.Location = New System.Drawing.Point(1569, 41)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Enabled = False
        Me.btnApply.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnApply.Location = New System.Drawing.Point(1408, 41)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(74, 23)
        Me.btnApply.TabIndex = 2
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1488, 41)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(74, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ilSettings
        '
        Me.ilSettings.ImageStream = CType(resources.GetObject("ilSettings.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilSettings.TransparentColor = System.Drawing.Color.Transparent
        Me.ilSettings.Images.SetKeyName(0, "process.png")
        Me.ilSettings.Images.SetKeyName(1, "comments.png")
        Me.ilSettings.Images.SetKeyName(2, "film.png")
        Me.ilSettings.Images.SetKeyName(3, "copy_paste.png")
        Me.ilSettings.Images.SetKeyName(4, "attachment.png")
        Me.ilSettings.Images.SetKeyName(5, "folder_full.png")
        Me.ilSettings.Images.SetKeyName(6, "image.png")
        Me.ilSettings.Images.SetKeyName(7, "television.ico")
        Me.ilSettings.Images.SetKeyName(8, "favorite_film.png")
        Me.ilSettings.Images.SetKeyName(9, "settingscheck.png")
        Me.ilSettings.Images.SetKeyName(10, "settingsx.png")
        Me.ilSettings.Images.SetKeyName(11, "note.png")
        '
        'tvSettingsList
        '
        Me.tvSettingsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvSettingsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvSettingsList.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvSettingsList.FullRowSelect = True
        Me.tvSettingsList.HideSelection = False
        Me.tvSettingsList.ImageIndex = 0
        Me.tvSettingsList.ImageList = Me.ilSettings
        Me.tvSettingsList.Location = New System.Drawing.Point(5, 0)
        Me.tvSettingsList.Name = "tvSettingsList"
        Me.tvSettingsList.SelectedImageIndex = 0
        Me.tvSettingsList.ShowLines = False
        Me.tvSettingsList.ShowPlusMinus = False
        Me.tvSettingsList.Size = New System.Drawing.Size(242, 1006)
        Me.tvSettingsList.TabIndex = 7
        '
        'pnlFileSystem
        '
        Me.pnlFileSystem.AutoSize = True
        Me.pnlFileSystem.BackColor = System.Drawing.Color.White
        Me.pnlFileSystem.Controls.Add(Me.tblFileSystem)
        Me.pnlFileSystem.Location = New System.Drawing.Point(900, 900)
        Me.pnlFileSystem.Name = "pnlFileSystem"
        Me.pnlFileSystem.Size = New System.Drawing.Size(534, 496)
        Me.pnlFileSystem.TabIndex = 17
        Me.pnlFileSystem.Visible = False
        '
        'tblFileSystem
        '
        Me.tblFileSystem.AutoScroll = True
        Me.tblFileSystem.AutoSize = True
        Me.tblFileSystem.ColumnCount = 4
        Me.tblFileSystem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystem.Controls.Add(Me.gbFileSystemValidVideoExts, 0, 0)
        Me.tblFileSystem.Controls.Add(Me.gbFileSystemNoStackExts, 2, 0)
        Me.tblFileSystem.Controls.Add(Me.gbFileSystemExcludedDirs, 0, 3)
        Me.tblFileSystem.Controls.Add(Me.gbFileSystemValidSubtitlesExts, 1, 0)
        Me.tblFileSystem.Controls.Add(Me.gbFileSystemValidThemeExts, 1, 2)
        Me.tblFileSystem.Controls.Add(Me.gbFileSystemCleanFiles, 2, 1)
        Me.tblFileSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystem.Location = New System.Drawing.Point(0, 0)
        Me.tblFileSystem.Name = "tblFileSystem"
        Me.tblFileSystem.RowCount = 5
        Me.tblFileSystem.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystem.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystem.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystem.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystem.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystem.Size = New System.Drawing.Size(534, 496)
        Me.tblFileSystem.TabIndex = 6
        '
        'gbFileSystemValidVideoExts
        '
        Me.gbFileSystemValidVideoExts.AutoSize = True
        Me.gbFileSystemValidVideoExts.Controls.Add(Me.tblFileSystemValidVideoExts)
        Me.gbFileSystemValidVideoExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemValidVideoExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemValidVideoExts.Location = New System.Drawing.Point(3, 3)
        Me.gbFileSystemValidVideoExts.Name = "gbFileSystemValidVideoExts"
        Me.tblFileSystem.SetRowSpan(Me.gbFileSystemValidVideoExts, 3)
        Me.gbFileSystemValidVideoExts.Size = New System.Drawing.Size(162, 346)
        Me.gbFileSystemValidVideoExts.TabIndex = 0
        Me.gbFileSystemValidVideoExts.TabStop = False
        Me.gbFileSystemValidVideoExts.Text = "Valid Video Extensions"
        '
        'tblFileSystemValidVideoExts
        '
        Me.tblFileSystemValidVideoExts.AutoSize = True
        Me.tblFileSystemValidVideoExts.ColumnCount = 4
        Me.tblFileSystemValidVideoExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidVideoExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidVideoExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidVideoExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.btnFileSystemValidVideoExtsRemove, 2, 2)
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.btnFileSystemValidVideoExtsReset, 2, 0)
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.btnFileSystemValidVideoExtsAdd, 1, 2)
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.lstFileSystemValidVideoExts, 0, 1)
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.txtFileSystemValidVideoExts, 0, 2)
        Me.tblFileSystemValidVideoExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemValidVideoExts.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemValidVideoExts.Name = "tblFileSystemValidVideoExts"
        Me.tblFileSystemValidVideoExts.RowCount = 4
        Me.tblFileSystemValidVideoExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidVideoExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidVideoExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidVideoExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidVideoExts.Size = New System.Drawing.Size(156, 325)
        Me.tblFileSystemValidVideoExts.TabIndex = 7
        '
        'btnFileSystemValidVideoExtsRemove
        '
        Me.btnFileSystemValidVideoExtsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidVideoExtsRemove.Image = CType(resources.GetObject("btnFileSystemValidVideoExtsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemValidVideoExtsRemove.Location = New System.Drawing.Point(130, 298)
        Me.btnFileSystemValidVideoExtsRemove.Name = "btnFileSystemValidVideoExtsRemove"
        Me.btnFileSystemValidVideoExtsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidVideoExtsRemove.TabIndex = 3
        Me.btnFileSystemValidVideoExtsRemove.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidVideoExtsReset
        '
        Me.btnFileSystemValidVideoExtsReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidVideoExtsReset.Image = CType(resources.GetObject("btnFileSystemValidVideoExtsReset.Image"), System.Drawing.Image)
        Me.btnFileSystemValidVideoExtsReset.Location = New System.Drawing.Point(130, 3)
        Me.btnFileSystemValidVideoExtsReset.Name = "btnFileSystemValidVideoExtsReset"
        Me.btnFileSystemValidVideoExtsReset.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidVideoExtsReset.TabIndex = 4
        Me.btnFileSystemValidVideoExtsReset.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidVideoExtsAdd
        '
        Me.btnFileSystemValidVideoExtsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemValidVideoExtsAdd.Image = CType(resources.GetObject("btnFileSystemValidVideoExtsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemValidVideoExtsAdd.Location = New System.Drawing.Point(59, 298)
        Me.btnFileSystemValidVideoExtsAdd.Name = "btnFileSystemValidVideoExtsAdd"
        Me.btnFileSystemValidVideoExtsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidVideoExtsAdd.TabIndex = 2
        Me.btnFileSystemValidVideoExtsAdd.UseVisualStyleBackColor = True
        '
        'lstFileSystemValidVideoExts
        '
        Me.tblFileSystemValidVideoExts.SetColumnSpan(Me.lstFileSystemValidVideoExts, 3)
        Me.lstFileSystemValidVideoExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemValidVideoExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemValidVideoExts.FormattingEnabled = True
        Me.lstFileSystemValidVideoExts.Location = New System.Drawing.Point(3, 32)
        Me.lstFileSystemValidVideoExts.Name = "lstFileSystemValidVideoExts"
        Me.lstFileSystemValidVideoExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemValidVideoExts.Size = New System.Drawing.Size(150, 260)
        Me.lstFileSystemValidVideoExts.Sorted = True
        Me.lstFileSystemValidVideoExts.TabIndex = 0
        '
        'txtFileSystemValidVideoExts
        '
        Me.txtFileSystemValidVideoExts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemValidVideoExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemValidVideoExts.Location = New System.Drawing.Point(3, 298)
        Me.txtFileSystemValidVideoExts.Name = "txtFileSystemValidVideoExts"
        Me.txtFileSystemValidVideoExts.Size = New System.Drawing.Size(50, 22)
        Me.txtFileSystemValidVideoExts.TabIndex = 1
        '
        'gbFileSystemNoStackExts
        '
        Me.gbFileSystemNoStackExts.AutoSize = True
        Me.gbFileSystemNoStackExts.Controls.Add(Me.tblFileSystemNoStackExts)
        Me.gbFileSystemNoStackExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemNoStackExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemNoStackExts.Location = New System.Drawing.Point(339, 3)
        Me.gbFileSystemNoStackExts.Name = "gbFileSystemNoStackExts"
        Me.gbFileSystemNoStackExts.Size = New System.Drawing.Size(192, 125)
        Me.gbFileSystemNoStackExts.TabIndex = 1
        Me.gbFileSystemNoStackExts.TabStop = False
        Me.gbFileSystemNoStackExts.Text = "No Stack Extensions"
        '
        'tblFileSystemNoStackExts
        '
        Me.tblFileSystemNoStackExts.AutoSize = True
        Me.tblFileSystemNoStackExts.ColumnCount = 4
        Me.tblFileSystemNoStackExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemNoStackExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemNoStackExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemNoStackExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemNoStackExts.Controls.Add(Me.btnFileSystemNoStackExtsRemove, 2, 1)
        Me.tblFileSystemNoStackExts.Controls.Add(Me.lstFileSystemNoStackExts, 0, 0)
        Me.tblFileSystemNoStackExts.Controls.Add(Me.btnFileSystemNoStackExtsAdd, 1, 1)
        Me.tblFileSystemNoStackExts.Controls.Add(Me.txtFileSystemNoStackExts, 0, 1)
        Me.tblFileSystemNoStackExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemNoStackExts.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemNoStackExts.Name = "tblFileSystemNoStackExts"
        Me.tblFileSystemNoStackExts.RowCount = 3
        Me.tblFileSystemNoStackExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemNoStackExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemNoStackExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemNoStackExts.Size = New System.Drawing.Size(186, 104)
        Me.tblFileSystemNoStackExts.TabIndex = 9
        '
        'btnFileSystemNoStackExtsRemove
        '
        Me.btnFileSystemNoStackExtsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemNoStackExtsRemove.Image = CType(resources.GetObject("btnFileSystemNoStackExtsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemNoStackExtsRemove.Location = New System.Drawing.Point(160, 78)
        Me.btnFileSystemNoStackExtsRemove.Name = "btnFileSystemNoStackExtsRemove"
        Me.btnFileSystemNoStackExtsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemNoStackExtsRemove.TabIndex = 3
        Me.btnFileSystemNoStackExtsRemove.UseVisualStyleBackColor = True
        '
        'lstFileSystemNoStackExts
        '
        Me.tblFileSystemNoStackExts.SetColumnSpan(Me.lstFileSystemNoStackExts, 3)
        Me.lstFileSystemNoStackExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemNoStackExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemNoStackExts.FormattingEnabled = True
        Me.lstFileSystemNoStackExts.Location = New System.Drawing.Point(3, 3)
        Me.lstFileSystemNoStackExts.Name = "lstFileSystemNoStackExts"
        Me.lstFileSystemNoStackExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemNoStackExts.Size = New System.Drawing.Size(180, 69)
        Me.lstFileSystemNoStackExts.Sorted = True
        Me.lstFileSystemNoStackExts.TabIndex = 0
        '
        'btnFileSystemNoStackExtsAdd
        '
        Me.btnFileSystemNoStackExtsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemNoStackExtsAdd.Image = CType(resources.GetObject("btnFileSystemNoStackExtsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemNoStackExtsAdd.Location = New System.Drawing.Point(59, 78)
        Me.btnFileSystemNoStackExtsAdd.Name = "btnFileSystemNoStackExtsAdd"
        Me.btnFileSystemNoStackExtsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemNoStackExtsAdd.TabIndex = 2
        Me.btnFileSystemNoStackExtsAdd.UseVisualStyleBackColor = True
        '
        'txtFileSystemNoStackExts
        '
        Me.txtFileSystemNoStackExts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemNoStackExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemNoStackExts.Location = New System.Drawing.Point(3, 78)
        Me.txtFileSystemNoStackExts.Name = "txtFileSystemNoStackExts"
        Me.txtFileSystemNoStackExts.Size = New System.Drawing.Size(50, 22)
        Me.txtFileSystemNoStackExts.TabIndex = 1
        '
        'gbFileSystemExcludedDirs
        '
        Me.gbFileSystemExcludedDirs.AutoSize = True
        Me.tblFileSystem.SetColumnSpan(Me.gbFileSystemExcludedDirs, 3)
        Me.gbFileSystemExcludedDirs.Controls.Add(Me.tblFileSystemExcludedDirs)
        Me.gbFileSystemExcludedDirs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemExcludedDirs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbFileSystemExcludedDirs.Location = New System.Drawing.Point(3, 355)
        Me.gbFileSystemExcludedDirs.Name = "gbFileSystemExcludedDirs"
        Me.gbFileSystemExcludedDirs.Size = New System.Drawing.Size(528, 138)
        Me.gbFileSystemExcludedDirs.TabIndex = 4
        Me.gbFileSystemExcludedDirs.TabStop = False
        Me.gbFileSystemExcludedDirs.Text = "Excluded Directories"
        '
        'tblFileSystemExcludedDirs
        '
        Me.tblFileSystemExcludedDirs.AutoSize = True
        Me.tblFileSystemExcludedDirs.ColumnCount = 4
        Me.tblFileSystemExcludedDirs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemExcludedDirs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemExcludedDirs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemExcludedDirs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemExcludedDirs.Controls.Add(Me.btnFileSystemExcludedDirsRemove, 2, 1)
        Me.tblFileSystemExcludedDirs.Controls.Add(Me.lstFileSystemExcludedDirs, 0, 0)
        Me.tblFileSystemExcludedDirs.Controls.Add(Me.btnFileSystemExcludedDirsAdd, 1, 1)
        Me.tblFileSystemExcludedDirs.Controls.Add(Me.txtFileSystemExcludedDirs, 0, 1)
        Me.tblFileSystemExcludedDirs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemExcludedDirs.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemExcludedDirs.Name = "tblFileSystemExcludedDirs"
        Me.tblFileSystemExcludedDirs.RowCount = 3
        Me.tblFileSystemExcludedDirs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemExcludedDirs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemExcludedDirs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemExcludedDirs.Size = New System.Drawing.Size(522, 117)
        Me.tblFileSystemExcludedDirs.TabIndex = 7
        '
        'btnFileSystemExcludedDirsRemove
        '
        Me.btnFileSystemExcludedDirsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemExcludedDirsRemove.Image = CType(resources.GetObject("btnFileSystemExcludedDirsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemExcludedDirsRemove.Location = New System.Drawing.Point(490, 91)
        Me.btnFileSystemExcludedDirsRemove.Name = "btnFileSystemExcludedDirsRemove"
        Me.btnFileSystemExcludedDirsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemExcludedDirsRemove.TabIndex = 6
        Me.btnFileSystemExcludedDirsRemove.UseVisualStyleBackColor = True
        '
        'lstFileSystemExcludedDirs
        '
        Me.tblFileSystemExcludedDirs.SetColumnSpan(Me.lstFileSystemExcludedDirs, 3)
        Me.lstFileSystemExcludedDirs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemExcludedDirs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemExcludedDirs.FormattingEnabled = True
        Me.lstFileSystemExcludedDirs.Location = New System.Drawing.Point(3, 3)
        Me.lstFileSystemExcludedDirs.Name = "lstFileSystemExcludedDirs"
        Me.lstFileSystemExcludedDirs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemExcludedDirs.Size = New System.Drawing.Size(510, 82)
        Me.lstFileSystemExcludedDirs.Sorted = True
        Me.lstFileSystemExcludedDirs.TabIndex = 1
        '
        'btnFileSystemExcludedDirsAdd
        '
        Me.btnFileSystemExcludedDirsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemExcludedDirsAdd.Image = CType(resources.GetObject("btnFileSystemExcludedDirsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemExcludedDirsAdd.Location = New System.Drawing.Point(419, 91)
        Me.btnFileSystemExcludedDirsAdd.Name = "btnFileSystemExcludedDirsAdd"
        Me.btnFileSystemExcludedDirsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemExcludedDirsAdd.TabIndex = 5
        Me.btnFileSystemExcludedDirsAdd.UseVisualStyleBackColor = True
        '
        'txtFileSystemExcludedDirs
        '
        Me.txtFileSystemExcludedDirs.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemExcludedDirs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemExcludedDirs.Location = New System.Drawing.Point(3, 91)
        Me.txtFileSystemExcludedDirs.Name = "txtFileSystemExcludedDirs"
        Me.txtFileSystemExcludedDirs.Size = New System.Drawing.Size(410, 22)
        Me.txtFileSystemExcludedDirs.TabIndex = 4
        '
        'gbFileSystemValidSubtitlesExts
        '
        Me.gbFileSystemValidSubtitlesExts.AutoSize = True
        Me.gbFileSystemValidSubtitlesExts.Controls.Add(Me.tblFileSystemValidSubtitlesExts)
        Me.gbFileSystemValidSubtitlesExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemValidSubtitlesExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemValidSubtitlesExts.Location = New System.Drawing.Point(171, 3)
        Me.gbFileSystemValidSubtitlesExts.Name = "gbFileSystemValidSubtitlesExts"
        Me.tblFileSystem.SetRowSpan(Me.gbFileSystemValidSubtitlesExts, 2)
        Me.gbFileSystemValidSubtitlesExts.Size = New System.Drawing.Size(162, 170)
        Me.gbFileSystemValidSubtitlesExts.TabIndex = 5
        Me.gbFileSystemValidSubtitlesExts.TabStop = False
        Me.gbFileSystemValidSubtitlesExts.Text = "Valid Subtitles Extensions"
        '
        'tblFileSystemValidSubtitlesExts
        '
        Me.tblFileSystemValidSubtitlesExts.AutoSize = True
        Me.tblFileSystemValidSubtitlesExts.ColumnCount = 4
        Me.tblFileSystemValidSubtitlesExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidSubtitlesExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidSubtitlesExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidSubtitlesExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.btnFileSystemValidSubtitlesExtsRemove, 2, 2)
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.btnFileSystemValidSubtitlesExtsReset, 2, 0)
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.btnFileSystemValidSubtitlesExtsAdd, 1, 2)
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.lstFileSystemValidSubtitlesExts, 0, 1)
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.txtFileSystemValidSubtitlesExts, 0, 2)
        Me.tblFileSystemValidSubtitlesExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemValidSubtitlesExts.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemValidSubtitlesExts.Name = "tblFileSystemValidSubtitlesExts"
        Me.tblFileSystemValidSubtitlesExts.RowCount = 4
        Me.tblFileSystemValidSubtitlesExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidSubtitlesExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidSubtitlesExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidSubtitlesExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidSubtitlesExts.Size = New System.Drawing.Size(156, 149)
        Me.tblFileSystemValidSubtitlesExts.TabIndex = 8
        '
        'btnFileSystemValidSubtitlesExtsRemove
        '
        Me.btnFileSystemValidSubtitlesExtsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidSubtitlesExtsRemove.Image = CType(resources.GetObject("btnFileSystemValidSubtitlesExtsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemValidSubtitlesExtsRemove.Location = New System.Drawing.Point(130, 123)
        Me.btnFileSystemValidSubtitlesExtsRemove.Name = "btnFileSystemValidSubtitlesExtsRemove"
        Me.btnFileSystemValidSubtitlesExtsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidSubtitlesExtsRemove.TabIndex = 3
        Me.btnFileSystemValidSubtitlesExtsRemove.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidSubtitlesExtsReset
        '
        Me.btnFileSystemValidSubtitlesExtsReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidSubtitlesExtsReset.Image = CType(resources.GetObject("btnFileSystemValidSubtitlesExtsReset.Image"), System.Drawing.Image)
        Me.btnFileSystemValidSubtitlesExtsReset.Location = New System.Drawing.Point(130, 3)
        Me.btnFileSystemValidSubtitlesExtsReset.Name = "btnFileSystemValidSubtitlesExtsReset"
        Me.btnFileSystemValidSubtitlesExtsReset.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidSubtitlesExtsReset.TabIndex = 5
        Me.btnFileSystemValidSubtitlesExtsReset.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidSubtitlesExtsAdd
        '
        Me.btnFileSystemValidSubtitlesExtsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemValidSubtitlesExtsAdd.Image = CType(resources.GetObject("btnFileSystemValidSubtitlesExtsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemValidSubtitlesExtsAdd.Location = New System.Drawing.Point(59, 123)
        Me.btnFileSystemValidSubtitlesExtsAdd.Name = "btnFileSystemValidSubtitlesExtsAdd"
        Me.btnFileSystemValidSubtitlesExtsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidSubtitlesExtsAdd.TabIndex = 2
        Me.btnFileSystemValidSubtitlesExtsAdd.UseVisualStyleBackColor = True
        '
        'lstFileSystemValidSubtitlesExts
        '
        Me.tblFileSystemValidSubtitlesExts.SetColumnSpan(Me.lstFileSystemValidSubtitlesExts, 3)
        Me.lstFileSystemValidSubtitlesExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemValidSubtitlesExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemValidSubtitlesExts.FormattingEnabled = True
        Me.lstFileSystemValidSubtitlesExts.Location = New System.Drawing.Point(3, 32)
        Me.lstFileSystemValidSubtitlesExts.Name = "lstFileSystemValidSubtitlesExts"
        Me.lstFileSystemValidSubtitlesExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemValidSubtitlesExts.Size = New System.Drawing.Size(150, 85)
        Me.lstFileSystemValidSubtitlesExts.Sorted = True
        Me.lstFileSystemValidSubtitlesExts.TabIndex = 0
        '
        'txtFileSystemValidSubtitlesExts
        '
        Me.txtFileSystemValidSubtitlesExts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemValidSubtitlesExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemValidSubtitlesExts.Location = New System.Drawing.Point(3, 123)
        Me.txtFileSystemValidSubtitlesExts.Name = "txtFileSystemValidSubtitlesExts"
        Me.txtFileSystemValidSubtitlesExts.Size = New System.Drawing.Size(50, 22)
        Me.txtFileSystemValidSubtitlesExts.TabIndex = 1
        '
        'gbFileSystemValidThemeExts
        '
        Me.gbFileSystemValidThemeExts.AutoSize = True
        Me.gbFileSystemValidThemeExts.Controls.Add(Me.tblFileSystemValidThemeExts)
        Me.gbFileSystemValidThemeExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemValidThemeExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemValidThemeExts.Location = New System.Drawing.Point(171, 179)
        Me.gbFileSystemValidThemeExts.Name = "gbFileSystemValidThemeExts"
        Me.gbFileSystemValidThemeExts.Size = New System.Drawing.Size(162, 170)
        Me.gbFileSystemValidThemeExts.TabIndex = 3
        Me.gbFileSystemValidThemeExts.TabStop = False
        Me.gbFileSystemValidThemeExts.Text = "Valid Theme Extensions"
        '
        'tblFileSystemValidThemeExts
        '
        Me.tblFileSystemValidThemeExts.AutoSize = True
        Me.tblFileSystemValidThemeExts.ColumnCount = 4
        Me.tblFileSystemValidThemeExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidThemeExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidThemeExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidThemeExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.btnFileSystemValidThemeExtsRemove, 2, 2)
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.btnFileSystemValidThemeExtsReset, 2, 0)
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.btnFileSystemValidThemeExtsAdd, 1, 2)
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.lstFileSystemValidThemeExts, 0, 1)
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.txtFileSystemValidThemeExts, 0, 2)
        Me.tblFileSystemValidThemeExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemValidThemeExts.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemValidThemeExts.Name = "tblFileSystemValidThemeExts"
        Me.tblFileSystemValidThemeExts.RowCount = 4
        Me.tblFileSystemValidThemeExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidThemeExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidThemeExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidThemeExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidThemeExts.Size = New System.Drawing.Size(156, 149)
        Me.tblFileSystemValidThemeExts.TabIndex = 9
        '
        'btnFileSystemValidThemeExtsRemove
        '
        Me.btnFileSystemValidThemeExtsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidThemeExtsRemove.Image = CType(resources.GetObject("btnFileSystemValidThemeExtsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemValidThemeExtsRemove.Location = New System.Drawing.Point(130, 123)
        Me.btnFileSystemValidThemeExtsRemove.Name = "btnFileSystemValidThemeExtsRemove"
        Me.btnFileSystemValidThemeExtsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidThemeExtsRemove.TabIndex = 3
        Me.btnFileSystemValidThemeExtsRemove.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidThemeExtsReset
        '
        Me.btnFileSystemValidThemeExtsReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidThemeExtsReset.Image = CType(resources.GetObject("btnFileSystemValidThemeExtsReset.Image"), System.Drawing.Image)
        Me.btnFileSystemValidThemeExtsReset.Location = New System.Drawing.Point(130, 3)
        Me.btnFileSystemValidThemeExtsReset.Name = "btnFileSystemValidThemeExtsReset"
        Me.btnFileSystemValidThemeExtsReset.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidThemeExtsReset.TabIndex = 4
        Me.btnFileSystemValidThemeExtsReset.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidThemeExtsAdd
        '
        Me.btnFileSystemValidThemeExtsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemValidThemeExtsAdd.Image = CType(resources.GetObject("btnFileSystemValidThemeExtsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemValidThemeExtsAdd.Location = New System.Drawing.Point(59, 123)
        Me.btnFileSystemValidThemeExtsAdd.Name = "btnFileSystemValidThemeExtsAdd"
        Me.btnFileSystemValidThemeExtsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidThemeExtsAdd.TabIndex = 2
        Me.btnFileSystemValidThemeExtsAdd.UseVisualStyleBackColor = True
        '
        'lstFileSystemValidThemeExts
        '
        Me.tblFileSystemValidThemeExts.SetColumnSpan(Me.lstFileSystemValidThemeExts, 3)
        Me.lstFileSystemValidThemeExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemValidThemeExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemValidThemeExts.FormattingEnabled = True
        Me.lstFileSystemValidThemeExts.Location = New System.Drawing.Point(3, 32)
        Me.lstFileSystemValidThemeExts.Name = "lstFileSystemValidThemeExts"
        Me.lstFileSystemValidThemeExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemValidThemeExts.Size = New System.Drawing.Size(150, 85)
        Me.lstFileSystemValidThemeExts.Sorted = True
        Me.lstFileSystemValidThemeExts.TabIndex = 0
        '
        'txtFileSystemValidThemeExts
        '
        Me.txtFileSystemValidThemeExts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemValidThemeExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemValidThemeExts.Location = New System.Drawing.Point(3, 123)
        Me.txtFileSystemValidThemeExts.Name = "txtFileSystemValidThemeExts"
        Me.txtFileSystemValidThemeExts.Size = New System.Drawing.Size(50, 22)
        Me.txtFileSystemValidThemeExts.TabIndex = 1
        '
        'lblSettingsCurrent
        '
        Me.lblSettingsCurrent.BackColor = System.Drawing.Color.Transparent
        Me.lblSettingsCurrent.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettingsCurrent.ForeColor = System.Drawing.Color.White
        Me.lblSettingsCurrent.Location = New System.Drawing.Point(26, -1)
        Me.lblSettingsCurrent.Name = "lblSettingsCurrent"
        Me.lblSettingsCurrent.Size = New System.Drawing.Size(969, 25)
        Me.lblSettingsCurrent.TabIndex = 0
        Me.lblSettingsCurrent.Text = "General"
        '
        'pnlSettingsCurrent
        '
        Me.pnlSettingsCurrent.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlSettingsCurrent.Controls.Add(Me.pbSettingsCurrent)
        Me.pnlSettingsCurrent.Controls.Add(Me.lblSettingsCurrent)
        Me.pnlSettingsCurrent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsCurrent.Location = New System.Drawing.Point(5, 3)
        Me.pnlSettingsCurrent.Name = "pnlSettingsCurrent"
        Me.pnlSettingsCurrent.Size = New System.Drawing.Size(1644, 27)
        Me.pnlSettingsCurrent.TabIndex = 5
        '
        'pbSettingsCurrent
        '
        Me.pbSettingsCurrent.Location = New System.Drawing.Point(2, 0)
        Me.pbSettingsCurrent.Name = "pbSettingsCurrent"
        Me.pbSettingsCurrent.Size = New System.Drawing.Size(24, 24)
        Me.pbSettingsCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSettingsCurrent.TabIndex = 2
        Me.pbSettingsCurrent.TabStop = False
        '
        'pnlTVGeneral
        '
        Me.pnlTVGeneral.AutoSize = True
        Me.pnlTVGeneral.BackColor = System.Drawing.Color.White
        Me.pnlTVGeneral.Controls.Add(Me.tblTVGeneral)
        Me.pnlTVGeneral.Location = New System.Drawing.Point(10, 10)
        Me.pnlTVGeneral.Name = "pnlTVGeneral"
        Me.pnlTVGeneral.Size = New System.Drawing.Size(962, 597)
        Me.pnlTVGeneral.TabIndex = 20
        Me.pnlTVGeneral.Visible = False
        '
        'tblTVGeneral
        '
        Me.tblTVGeneral.AutoScroll = True
        Me.tblTVGeneral.AutoSize = True
        Me.tblTVGeneral.ColumnCount = 4
        Me.tblTVGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneral.Controls.Add(Me.gbTVGeneralCustomScrapeButton, 2, 3)
        Me.tblTVGeneral.Controls.Add(Me.gbTVGeneralMiscOpts, 0, 0)
        Me.tblTVGeneral.Controls.Add(Me.gbTVGeneralMediaListOpts, 0, 1)
        Me.tblTVGeneral.Controls.Add(Me.gbTVGeneralMainWindowOpts, 2, 0)
        Me.tblTVGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneral.Location = New System.Drawing.Point(0, 0)
        Me.tblTVGeneral.Name = "tblTVGeneral"
        Me.tblTVGeneral.RowCount = 5
        Me.tblTVGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneral.Size = New System.Drawing.Size(962, 597)
        Me.tblTVGeneral.TabIndex = 5
        '
        'gbTVGeneralCustomScrapeButton
        '
        Me.gbTVGeneralCustomScrapeButton.AutoSize = True
        Me.gbTVGeneralCustomScrapeButton.Controls.Add(Me.tblTVGeneralCustomScrapeButton)
        Me.gbTVGeneralCustomScrapeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralCustomScrapeButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTVGeneralCustomScrapeButton.Location = New System.Drawing.Point(451, 478)
        Me.gbTVGeneralCustomScrapeButton.Name = "gbTVGeneralCustomScrapeButton"
        Me.gbTVGeneralCustomScrapeButton.Size = New System.Drawing.Size(497, 98)
        Me.gbTVGeneralCustomScrapeButton.TabIndex = 13
        Me.gbTVGeneralCustomScrapeButton.TabStop = False
        Me.gbTVGeneralCustomScrapeButton.Text = "Scrape Button"
        '
        'tblTVGeneralCustomScrapeButton
        '
        Me.tblTVGeneralCustomScrapeButton.AutoSize = True
        Me.tblTVGeneralCustomScrapeButton.ColumnCount = 2
        Me.tblTVGeneralCustomScrapeButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralCustomScrapeButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblTVGeneralCustomScrapeButton.Controls.Add(Me.cbTVGeneralCustomScrapeButtonScrapeType, 1, 1)
        Me.tblTVGeneralCustomScrapeButton.Controls.Add(Me.cbTVGeneralCustomScrapeButtonModifierType, 1, 2)
        Me.tblTVGeneralCustomScrapeButton.Controls.Add(Me.txtTVGeneralCustomScrapeButtonScrapeType, 0, 1)
        Me.tblTVGeneralCustomScrapeButton.Controls.Add(Me.txtTVGeneralCustomScrapeButtonModifierType, 0, 2)
        Me.tblTVGeneralCustomScrapeButton.Controls.Add(Me.rbTVGeneralCustomScrapeButtonEnabled, 1, 0)
        Me.tblTVGeneralCustomScrapeButton.Controls.Add(Me.rbTVGeneralCustomScrapeButtonDisabled, 0, 0)
        Me.tblTVGeneralCustomScrapeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneralCustomScrapeButton.Location = New System.Drawing.Point(3, 18)
        Me.tblTVGeneralCustomScrapeButton.Name = "tblTVGeneralCustomScrapeButton"
        Me.tblTVGeneralCustomScrapeButton.RowCount = 4
        Me.tblTVGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralCustomScrapeButton.Size = New System.Drawing.Size(491, 77)
        Me.tblTVGeneralCustomScrapeButton.TabIndex = 0
        '
        'cbTVGeneralCustomScrapeButtonScrapeType
        '
        Me.cbTVGeneralCustomScrapeButtonScrapeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbTVGeneralCustomScrapeButtonScrapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVGeneralCustomScrapeButtonScrapeType.Enabled = False
        Me.cbTVGeneralCustomScrapeButtonScrapeType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTVGeneralCustomScrapeButtonScrapeType.FormattingEnabled = True
        Me.cbTVGeneralCustomScrapeButtonScrapeType.Location = New System.Drawing.Point(159, 26)
        Me.cbTVGeneralCustomScrapeButtonScrapeType.Name = "cbTVGeneralCustomScrapeButtonScrapeType"
        Me.cbTVGeneralCustomScrapeButtonScrapeType.Size = New System.Drawing.Size(329, 21)
        Me.cbTVGeneralCustomScrapeButtonScrapeType.TabIndex = 1
        '
        'cbTVGeneralCustomScrapeButtonModifierType
        '
        Me.cbTVGeneralCustomScrapeButtonModifierType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbTVGeneralCustomScrapeButtonModifierType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVGeneralCustomScrapeButtonModifierType.Enabled = False
        Me.cbTVGeneralCustomScrapeButtonModifierType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTVGeneralCustomScrapeButtonModifierType.FormattingEnabled = True
        Me.cbTVGeneralCustomScrapeButtonModifierType.Location = New System.Drawing.Point(159, 53)
        Me.cbTVGeneralCustomScrapeButtonModifierType.Name = "cbTVGeneralCustomScrapeButtonModifierType"
        Me.cbTVGeneralCustomScrapeButtonModifierType.Size = New System.Drawing.Size(329, 21)
        Me.cbTVGeneralCustomScrapeButtonModifierType.TabIndex = 2
        '
        'txtTVGeneralCustomScrapeButtonScrapeType
        '
        Me.txtTVGeneralCustomScrapeButtonScrapeType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTVGeneralCustomScrapeButtonScrapeType.AutoSize = True
        Me.txtTVGeneralCustomScrapeButtonScrapeType.Enabled = False
        Me.txtTVGeneralCustomScrapeButtonScrapeType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTVGeneralCustomScrapeButtonScrapeType.Location = New System.Drawing.Point(3, 30)
        Me.txtTVGeneralCustomScrapeButtonScrapeType.Name = "txtTVGeneralCustomScrapeButtonScrapeType"
        Me.txtTVGeneralCustomScrapeButtonScrapeType.Size = New System.Drawing.Size(66, 13)
        Me.txtTVGeneralCustomScrapeButtonScrapeType.TabIndex = 3
        Me.txtTVGeneralCustomScrapeButtonScrapeType.Text = "Scrape Type"
        '
        'txtTVGeneralCustomScrapeButtonModifierType
        '
        Me.txtTVGeneralCustomScrapeButtonModifierType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTVGeneralCustomScrapeButtonModifierType.AutoSize = True
        Me.txtTVGeneralCustomScrapeButtonModifierType.Enabled = False
        Me.txtTVGeneralCustomScrapeButtonModifierType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTVGeneralCustomScrapeButtonModifierType.Location = New System.Drawing.Point(3, 57)
        Me.txtTVGeneralCustomScrapeButtonModifierType.Name = "txtTVGeneralCustomScrapeButtonModifierType"
        Me.txtTVGeneralCustomScrapeButtonModifierType.Size = New System.Drawing.Size(76, 13)
        Me.txtTVGeneralCustomScrapeButtonModifierType.TabIndex = 4
        Me.txtTVGeneralCustomScrapeButtonModifierType.Text = "Modifier Type"
        '
        'rbTVGeneralCustomScrapeButtonEnabled
        '
        Me.rbTVGeneralCustomScrapeButtonEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbTVGeneralCustomScrapeButtonEnabled.AutoSize = True
        Me.rbTVGeneralCustomScrapeButtonEnabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTVGeneralCustomScrapeButtonEnabled.Location = New System.Drawing.Point(159, 3)
        Me.rbTVGeneralCustomScrapeButtonEnabled.Name = "rbTVGeneralCustomScrapeButtonEnabled"
        Me.rbTVGeneralCustomScrapeButtonEnabled.Size = New System.Drawing.Size(150, 17)
        Me.rbTVGeneralCustomScrapeButtonEnabled.TabIndex = 5
        Me.rbTVGeneralCustomScrapeButtonEnabled.TabStop = True
        Me.rbTVGeneralCustomScrapeButtonEnabled.Text = "Custom Scrape Function"
        Me.rbTVGeneralCustomScrapeButtonEnabled.UseVisualStyleBackColor = True
        '
        'rbTVGeneralCustomScrapeButtonDisabled
        '
        Me.rbTVGeneralCustomScrapeButtonDisabled.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbTVGeneralCustomScrapeButtonDisabled.AutoSize = True
        Me.rbTVGeneralCustomScrapeButtonDisabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTVGeneralCustomScrapeButtonDisabled.Location = New System.Drawing.Point(3, 3)
        Me.rbTVGeneralCustomScrapeButtonDisabled.Name = "rbTVGeneralCustomScrapeButtonDisabled"
        Me.rbTVGeneralCustomScrapeButtonDisabled.Size = New System.Drawing.Size(150, 17)
        Me.rbTVGeneralCustomScrapeButtonDisabled.TabIndex = 6
        Me.rbTVGeneralCustomScrapeButtonDisabled.TabStop = True
        Me.rbTVGeneralCustomScrapeButtonDisabled.Text = "Open Drop Down Menu"
        Me.rbTVGeneralCustomScrapeButtonDisabled.UseVisualStyleBackColor = True
        '
        'gbTVGeneralMiscOpts
        '
        Me.gbTVGeneralMiscOpts.AutoSize = True
        Me.gbTVGeneralMiscOpts.Controls.Add(Me.tblTVGeneralMiscOpts)
        Me.gbTVGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbTVGeneralMiscOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbTVGeneralMiscOpts.Name = "gbTVGeneralMiscOpts"
        Me.gbTVGeneralMiscOpts.Size = New System.Drawing.Size(292, 67)
        Me.gbTVGeneralMiscOpts.TabIndex = 0
        Me.gbTVGeneralMiscOpts.TabStop = False
        Me.gbTVGeneralMiscOpts.Text = "Miscellaneous"
        '
        'tblTVGeneralMiscOpts
        '
        Me.tblTVGeneralMiscOpts.AutoSize = True
        Me.tblTVGeneralMiscOpts.ColumnCount = 3
        Me.tblTVGeneralMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.chkTVGeneralMarkNewEpisodes, 0, 1)
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.chkTVGeneralMarkNewShows, 0, 0)
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.chkTVGeneralClickScrape, 1, 0)
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.chkTVGeneralClickScrapeAsk, 1, 1)
        Me.tblTVGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneralMiscOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVGeneralMiscOpts.Name = "tblTVGeneralMiscOpts"
        Me.tblTVGeneralMiscOpts.RowCount = 3
        Me.tblTVGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMiscOpts.Size = New System.Drawing.Size(286, 46)
        Me.tblTVGeneralMiscOpts.TabIndex = 74
        '
        'chkTVGeneralMarkNewEpisodes
        '
        Me.chkTVGeneralMarkNewEpisodes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVGeneralMarkNewEpisodes.AutoSize = True
        Me.chkTVGeneralMarkNewEpisodes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVGeneralMarkNewEpisodes.Location = New System.Drawing.Point(3, 26)
        Me.chkTVGeneralMarkNewEpisodes.Name = "chkTVGeneralMarkNewEpisodes"
        Me.chkTVGeneralMarkNewEpisodes.Size = New System.Drawing.Size(127, 17)
        Me.chkTVGeneralMarkNewEpisodes.TabIndex = 4
        Me.chkTVGeneralMarkNewEpisodes.Text = "Mark New Episodes"
        Me.chkTVGeneralMarkNewEpisodes.UseVisualStyleBackColor = True
        '
        'chkTVGeneralMarkNewShows
        '
        Me.chkTVGeneralMarkNewShows.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVGeneralMarkNewShows.AutoSize = True
        Me.chkTVGeneralMarkNewShows.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVGeneralMarkNewShows.Location = New System.Drawing.Point(3, 3)
        Me.chkTVGeneralMarkNewShows.Name = "chkTVGeneralMarkNewShows"
        Me.chkTVGeneralMarkNewShows.Size = New System.Drawing.Size(115, 17)
        Me.chkTVGeneralMarkNewShows.TabIndex = 3
        Me.chkTVGeneralMarkNewShows.Text = "Mark New Shows"
        Me.chkTVGeneralMarkNewShows.UseVisualStyleBackColor = True
        '
        'chkTVGeneralClickScrape
        '
        Me.chkTVGeneralClickScrape.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVGeneralClickScrape.AutoSize = True
        Me.chkTVGeneralClickScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkTVGeneralClickScrape.Location = New System.Drawing.Point(136, 3)
        Me.chkTVGeneralClickScrape.Name = "chkTVGeneralClickScrape"
        Me.chkTVGeneralClickScrape.Size = New System.Drawing.Size(125, 17)
        Me.chkTVGeneralClickScrape.TabIndex = 66
        Me.chkTVGeneralClickScrape.Text = "Enable Click Scrape"
        Me.chkTVGeneralClickScrape.UseVisualStyleBackColor = True
        '
        'chkTVGeneralClickScrapeAsk
        '
        Me.chkTVGeneralClickScrapeAsk.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVGeneralClickScrapeAsk.AutoSize = True
        Me.chkTVGeneralClickScrapeAsk.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkTVGeneralClickScrapeAsk.Location = New System.Drawing.Point(136, 26)
        Me.chkTVGeneralClickScrapeAsk.Name = "chkTVGeneralClickScrapeAsk"
        Me.chkTVGeneralClickScrapeAsk.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkTVGeneralClickScrapeAsk.Size = New System.Drawing.Size(147, 17)
        Me.chkTVGeneralClickScrapeAsk.TabIndex = 67
        Me.chkTVGeneralClickScrapeAsk.Text = "Ask On Click Scrape"
        Me.chkTVGeneralClickScrapeAsk.UseVisualStyleBackColor = True
        '
        'gbTVGeneralMediaListOpts
        '
        Me.gbTVGeneralMediaListOpts.AutoSize = True
        Me.tblTVGeneral.SetColumnSpan(Me.gbTVGeneralMediaListOpts, 2)
        Me.gbTVGeneralMediaListOpts.Controls.Add(Me.tblTVGeneralMediaListOpts)
        Me.gbTVGeneralMediaListOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralMediaListOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbTVGeneralMediaListOpts.Location = New System.Drawing.Point(3, 76)
        Me.gbTVGeneralMediaListOpts.Name = "gbTVGeneralMediaListOpts"
        Me.tblTVGeneral.SetRowSpan(Me.gbTVGeneralMediaListOpts, 3)
        Me.gbTVGeneralMediaListOpts.Size = New System.Drawing.Size(442, 500)
        Me.gbTVGeneralMediaListOpts.TabIndex = 1
        Me.gbTVGeneralMediaListOpts.TabStop = False
        Me.gbTVGeneralMediaListOpts.Text = "Media List Options"
        '
        'tblTVGeneralMediaListOpts
        '
        Me.tblTVGeneralMediaListOpts.AutoSize = True
        Me.tblTVGeneralMediaListOpts.ColumnCount = 3
        Me.tblTVGeneralMediaListOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMediaListOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMediaListOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMediaListOpts.Controls.Add(Me.gbTVGeneralEpisodeListSorting, 1, 5)
        Me.tblTVGeneralMediaListOpts.Controls.Add(Me.gbTVGeneralSeasonListSortingOpts, 1, 4)
        Me.tblTVGeneralMediaListOpts.Controls.Add(Me.gbTVGeneralShowListSortingOpts, 0, 4)
        Me.tblTVGeneralMediaListOpts.Controls.Add(Me.chkTVDisplayMissingEpisodes, 0, 1)
        Me.tblTVGeneralMediaListOpts.Controls.Add(Me.chkTVDisplayStatus, 0, 0)
        Me.tblTVGeneralMediaListOpts.Controls.Add(Me.gbTVGeneralMediaListSortTokensOpts, 1, 0)
        Me.tblTVGeneralMediaListOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneralMediaListOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVGeneralMediaListOpts.Name = "tblTVGeneralMediaListOpts"
        Me.tblTVGeneralMediaListOpts.RowCount = 7
        Me.tblTVGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListOpts.Size = New System.Drawing.Size(436, 479)
        Me.tblTVGeneralMediaListOpts.TabIndex = 74
        '
        'gbTVGeneralEpisodeListSorting
        '
        Me.gbTVGeneralEpisodeListSorting.AutoSize = True
        Me.gbTVGeneralEpisodeListSorting.Controls.Add(Me.tblTVGeneralEpisodeListSorting)
        Me.gbTVGeneralEpisodeListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralEpisodeListSorting.Location = New System.Drawing.Point(221, 295)
        Me.gbTVGeneralEpisodeListSorting.Name = "gbTVGeneralEpisodeListSorting"
        Me.gbTVGeneralEpisodeListSorting.Size = New System.Drawing.Size(212, 181)
        Me.gbTVGeneralEpisodeListSorting.TabIndex = 76
        Me.gbTVGeneralEpisodeListSorting.TabStop = False
        Me.gbTVGeneralEpisodeListSorting.Text = "Episode List Sorting"
        '
        'tblTVGeneralEpisodeListSorting
        '
        Me.tblTVGeneralEpisodeListSorting.AutoSize = True
        Me.tblTVGeneralEpisodeListSorting.ColumnCount = 6
        Me.tblTVGeneralEpisodeListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralEpisodeListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralEpisodeListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralEpisodeListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralEpisodeListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralEpisodeListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralEpisodeListSorting.Controls.Add(Me.btnTVGeneralEpisodeListSortingDown, 2, 1)
        Me.tblTVGeneralEpisodeListSorting.Controls.Add(Me.btnTVGeneralEpisodeListSortingUp, 1, 1)
        Me.tblTVGeneralEpisodeListSorting.Controls.Add(Me.lvTVGeneralEpisodeListSorting, 0, 0)
        Me.tblTVGeneralEpisodeListSorting.Controls.Add(Me.btnTVGeneralEpisodeListSortingReset, 4, 1)
        Me.tblTVGeneralEpisodeListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneralEpisodeListSorting.Location = New System.Drawing.Point(3, 18)
        Me.tblTVGeneralEpisodeListSorting.Name = "tblTVGeneralEpisodeListSorting"
        Me.tblTVGeneralEpisodeListSorting.RowCount = 3
        Me.tblTVGeneralEpisodeListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralEpisodeListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralEpisodeListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralEpisodeListSorting.Size = New System.Drawing.Size(206, 160)
        Me.tblTVGeneralEpisodeListSorting.TabIndex = 0
        '
        'btnTVGeneralEpisodeListSortingDown
        '
        Me.btnTVGeneralEpisodeListSortingDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTVGeneralEpisodeListSortingDown.Image = CType(resources.GetObject("btnTVGeneralEpisodeListSortingDown.Image"), System.Drawing.Image)
        Me.btnTVGeneralEpisodeListSortingDown.Location = New System.Drawing.Point(91, 134)
        Me.btnTVGeneralEpisodeListSortingDown.Name = "btnTVGeneralEpisodeListSortingDown"
        Me.btnTVGeneralEpisodeListSortingDown.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralEpisodeListSortingDown.TabIndex = 12
        Me.btnTVGeneralEpisodeListSortingDown.UseVisualStyleBackColor = True
        '
        'btnTVGeneralEpisodeListSortingUp
        '
        Me.btnTVGeneralEpisodeListSortingUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTVGeneralEpisodeListSortingUp.Image = CType(resources.GetObject("btnTVGeneralEpisodeListSortingUp.Image"), System.Drawing.Image)
        Me.btnTVGeneralEpisodeListSortingUp.Location = New System.Drawing.Point(62, 134)
        Me.btnTVGeneralEpisodeListSortingUp.Name = "btnTVGeneralEpisodeListSortingUp"
        Me.btnTVGeneralEpisodeListSortingUp.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralEpisodeListSortingUp.TabIndex = 13
        Me.btnTVGeneralEpisodeListSortingUp.UseVisualStyleBackColor = True
        '
        'lvTVGeneralEpisodeListSorting
        '
        Me.lvTVGeneralEpisodeListSorting.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTVGeneralEpisodeListSortingDisplayIndex, Me.colTVGeneralEpisodeListSortingColumn, Me.colTVGeneralEpisodeListSortingLabel, Me.colTVGeneralEpisodeListSortingHide})
        Me.tblTVGeneralEpisodeListSorting.SetColumnSpan(Me.lvTVGeneralEpisodeListSorting, 5)
        Me.lvTVGeneralEpisodeListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTVGeneralEpisodeListSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvTVGeneralEpisodeListSorting.FullRowSelect = True
        Me.lvTVGeneralEpisodeListSorting.HideSelection = False
        Me.lvTVGeneralEpisodeListSorting.Location = New System.Drawing.Point(3, 3)
        Me.lvTVGeneralEpisodeListSorting.Name = "lvTVGeneralEpisodeListSorting"
        Me.lvTVGeneralEpisodeListSorting.Size = New System.Drawing.Size(200, 125)
        Me.lvTVGeneralEpisodeListSorting.TabIndex = 10
        Me.lvTVGeneralEpisodeListSorting.UseCompatibleStateImageBehavior = False
        Me.lvTVGeneralEpisodeListSorting.View = System.Windows.Forms.View.Details
        '
        'colTVGeneralEpisodeListSortingDisplayIndex
        '
        Me.colTVGeneralEpisodeListSortingDisplayIndex.Text = "DisplayIndex"
        Me.colTVGeneralEpisodeListSortingDisplayIndex.Width = 0
        '
        'colTVGeneralEpisodeListSortingColumn
        '
        Me.colTVGeneralEpisodeListSortingColumn.Text = "DBName"
        Me.colTVGeneralEpisodeListSortingColumn.Width = 0
        '
        'colTVGeneralEpisodeListSortingLabel
        '
        Me.colTVGeneralEpisodeListSortingLabel.Text = "Column"
        Me.colTVGeneralEpisodeListSortingLabel.Width = 110
        '
        'colTVGeneralEpisodeListSortingHide
        '
        Me.colTVGeneralEpisodeListSortingHide.Text = "Hide"
        '
        'btnTVGeneralEpisodeListSortingReset
        '
        Me.btnTVGeneralEpisodeListSortingReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnTVGeneralEpisodeListSortingReset.Image = CType(resources.GetObject("btnTVGeneralEpisodeListSortingReset.Image"), System.Drawing.Image)
        Me.btnTVGeneralEpisodeListSortingReset.Location = New System.Drawing.Point(180, 134)
        Me.btnTVGeneralEpisodeListSortingReset.Name = "btnTVGeneralEpisodeListSortingReset"
        Me.btnTVGeneralEpisodeListSortingReset.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralEpisodeListSortingReset.TabIndex = 11
        Me.btnTVGeneralEpisodeListSortingReset.UseVisualStyleBackColor = True
        '
        'gbTVGeneralSeasonListSortingOpts
        '
        Me.gbTVGeneralSeasonListSortingOpts.AutoSize = True
        Me.gbTVGeneralSeasonListSortingOpts.Controls.Add(Me.tblTVGeneralSeasonListSorting)
        Me.gbTVGeneralSeasonListSortingOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralSeasonListSortingOpts.Location = New System.Drawing.Point(221, 108)
        Me.gbTVGeneralSeasonListSortingOpts.Name = "gbTVGeneralSeasonListSortingOpts"
        Me.gbTVGeneralSeasonListSortingOpts.Size = New System.Drawing.Size(212, 181)
        Me.gbTVGeneralSeasonListSortingOpts.TabIndex = 75
        Me.gbTVGeneralSeasonListSortingOpts.TabStop = False
        Me.gbTVGeneralSeasonListSortingOpts.Text = "Season List Sorting"
        '
        'tblTVGeneralSeasonListSorting
        '
        Me.tblTVGeneralSeasonListSorting.AutoSize = True
        Me.tblTVGeneralSeasonListSorting.ColumnCount = 6
        Me.tblTVGeneralSeasonListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralSeasonListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralSeasonListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralSeasonListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralSeasonListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralSeasonListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralSeasonListSorting.Controls.Add(Me.btnTVGeneralSeasonListSortingDown, 2, 1)
        Me.tblTVGeneralSeasonListSorting.Controls.Add(Me.btnTVGeneralSeasonListSortingUp, 1, 1)
        Me.tblTVGeneralSeasonListSorting.Controls.Add(Me.lvTVGeneralSeasonListSorting, 0, 0)
        Me.tblTVGeneralSeasonListSorting.Controls.Add(Me.btnTVGeneralSeasonListSortingReset, 4, 1)
        Me.tblTVGeneralSeasonListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneralSeasonListSorting.Location = New System.Drawing.Point(3, 18)
        Me.tblTVGeneralSeasonListSorting.Name = "tblTVGeneralSeasonListSorting"
        Me.tblTVGeneralSeasonListSorting.RowCount = 3
        Me.tblTVGeneralSeasonListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralSeasonListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralSeasonListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralSeasonListSorting.Size = New System.Drawing.Size(206, 160)
        Me.tblTVGeneralSeasonListSorting.TabIndex = 0
        '
        'btnTVGeneralSeasonListSortingDown
        '
        Me.btnTVGeneralSeasonListSortingDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTVGeneralSeasonListSortingDown.Image = CType(resources.GetObject("btnTVGeneralSeasonListSortingDown.Image"), System.Drawing.Image)
        Me.btnTVGeneralSeasonListSortingDown.Location = New System.Drawing.Point(91, 134)
        Me.btnTVGeneralSeasonListSortingDown.Name = "btnTVGeneralSeasonListSortingDown"
        Me.btnTVGeneralSeasonListSortingDown.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralSeasonListSortingDown.TabIndex = 12
        Me.btnTVGeneralSeasonListSortingDown.UseVisualStyleBackColor = True
        '
        'btnTVGeneralSeasonListSortingUp
        '
        Me.btnTVGeneralSeasonListSortingUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTVGeneralSeasonListSortingUp.Image = CType(resources.GetObject("btnTVGeneralSeasonListSortingUp.Image"), System.Drawing.Image)
        Me.btnTVGeneralSeasonListSortingUp.Location = New System.Drawing.Point(62, 134)
        Me.btnTVGeneralSeasonListSortingUp.Name = "btnTVGeneralSeasonListSortingUp"
        Me.btnTVGeneralSeasonListSortingUp.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralSeasonListSortingUp.TabIndex = 13
        Me.btnTVGeneralSeasonListSortingUp.UseVisualStyleBackColor = True
        '
        'lvTVGeneralSeasonListSorting
        '
        Me.lvTVGeneralSeasonListSorting.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTVGeneralSeasonListSortingDisplayIndex, Me.colTVGeneralSeasonListSortingColumn, Me.colTVGeneralSeasonListSortingLabel, Me.colTVGeneralSeasonListSortingHide})
        Me.tblTVGeneralSeasonListSorting.SetColumnSpan(Me.lvTVGeneralSeasonListSorting, 5)
        Me.lvTVGeneralSeasonListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTVGeneralSeasonListSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvTVGeneralSeasonListSorting.FullRowSelect = True
        Me.lvTVGeneralSeasonListSorting.HideSelection = False
        Me.lvTVGeneralSeasonListSorting.Location = New System.Drawing.Point(3, 3)
        Me.lvTVGeneralSeasonListSorting.Name = "lvTVGeneralSeasonListSorting"
        Me.lvTVGeneralSeasonListSorting.Size = New System.Drawing.Size(200, 125)
        Me.lvTVGeneralSeasonListSorting.TabIndex = 10
        Me.lvTVGeneralSeasonListSorting.UseCompatibleStateImageBehavior = False
        Me.lvTVGeneralSeasonListSorting.View = System.Windows.Forms.View.Details
        '
        'colTVGeneralSeasonListSortingDisplayIndex
        '
        Me.colTVGeneralSeasonListSortingDisplayIndex.Text = "DisplayIndex"
        Me.colTVGeneralSeasonListSortingDisplayIndex.Width = 0
        '
        'colTVGeneralSeasonListSortingColumn
        '
        Me.colTVGeneralSeasonListSortingColumn.Text = "DBName"
        Me.colTVGeneralSeasonListSortingColumn.Width = 0
        '
        'colTVGeneralSeasonListSortingLabel
        '
        Me.colTVGeneralSeasonListSortingLabel.Text = "Column"
        Me.colTVGeneralSeasonListSortingLabel.Width = 110
        '
        'colTVGeneralSeasonListSortingHide
        '
        Me.colTVGeneralSeasonListSortingHide.Text = "Hide"
        '
        'btnTVGeneralSeasonListSortingReset
        '
        Me.btnTVGeneralSeasonListSortingReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnTVGeneralSeasonListSortingReset.Image = CType(resources.GetObject("btnTVGeneralSeasonListSortingReset.Image"), System.Drawing.Image)
        Me.btnTVGeneralSeasonListSortingReset.Location = New System.Drawing.Point(180, 134)
        Me.btnTVGeneralSeasonListSortingReset.Name = "btnTVGeneralSeasonListSortingReset"
        Me.btnTVGeneralSeasonListSortingReset.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralSeasonListSortingReset.TabIndex = 11
        Me.btnTVGeneralSeasonListSortingReset.UseVisualStyleBackColor = True
        '
        'gbTVGeneralShowListSortingOpts
        '
        Me.gbTVGeneralShowListSortingOpts.AutoSize = True
        Me.gbTVGeneralShowListSortingOpts.Controls.Add(Me.tblTVGeneralShowListSorting)
        Me.gbTVGeneralShowListSortingOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralShowListSortingOpts.Location = New System.Drawing.Point(3, 108)
        Me.gbTVGeneralShowListSortingOpts.Name = "gbTVGeneralShowListSortingOpts"
        Me.tblTVGeneralMediaListOpts.SetRowSpan(Me.gbTVGeneralShowListSortingOpts, 2)
        Me.gbTVGeneralShowListSortingOpts.Size = New System.Drawing.Size(212, 368)
        Me.gbTVGeneralShowListSortingOpts.TabIndex = 74
        Me.gbTVGeneralShowListSortingOpts.TabStop = False
        Me.gbTVGeneralShowListSortingOpts.Text = "Show List Sorting"
        '
        'tblTVGeneralShowListSorting
        '
        Me.tblTVGeneralShowListSorting.AutoSize = True
        Me.tblTVGeneralShowListSorting.ColumnCount = 6
        Me.tblTVGeneralShowListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralShowListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralShowListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralShowListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralShowListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralShowListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralShowListSorting.Controls.Add(Me.btnTVGeneralShowListSortingDown, 2, 1)
        Me.tblTVGeneralShowListSorting.Controls.Add(Me.btnTVGeneralShowListSortingUp, 1, 1)
        Me.tblTVGeneralShowListSorting.Controls.Add(Me.lvTVGeneralShowListSorting, 0, 0)
        Me.tblTVGeneralShowListSorting.Controls.Add(Me.btnTVGeneralShowListSortingReset, 4, 1)
        Me.tblTVGeneralShowListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneralShowListSorting.Location = New System.Drawing.Point(3, 18)
        Me.tblTVGeneralShowListSorting.Name = "tblTVGeneralShowListSorting"
        Me.tblTVGeneralShowListSorting.RowCount = 3
        Me.tblTVGeneralShowListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralShowListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralShowListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralShowListSorting.Size = New System.Drawing.Size(206, 347)
        Me.tblTVGeneralShowListSorting.TabIndex = 0
        '
        'btnTVGeneralShowListSortingDown
        '
        Me.btnTVGeneralShowListSortingDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTVGeneralShowListSortingDown.Image = CType(resources.GetObject("btnTVGeneralShowListSortingDown.Image"), System.Drawing.Image)
        Me.btnTVGeneralShowListSortingDown.Location = New System.Drawing.Point(91, 321)
        Me.btnTVGeneralShowListSortingDown.Name = "btnTVGeneralShowListSortingDown"
        Me.btnTVGeneralShowListSortingDown.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralShowListSortingDown.TabIndex = 12
        Me.btnTVGeneralShowListSortingDown.UseVisualStyleBackColor = True
        '
        'btnTVGeneralShowListSortingUp
        '
        Me.btnTVGeneralShowListSortingUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTVGeneralShowListSortingUp.Image = CType(resources.GetObject("btnTVGeneralShowListSortingUp.Image"), System.Drawing.Image)
        Me.btnTVGeneralShowListSortingUp.Location = New System.Drawing.Point(62, 321)
        Me.btnTVGeneralShowListSortingUp.Name = "btnTVGeneralShowListSortingUp"
        Me.btnTVGeneralShowListSortingUp.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralShowListSortingUp.TabIndex = 13
        Me.btnTVGeneralShowListSortingUp.UseVisualStyleBackColor = True
        '
        'lvTVGeneralShowListSorting
        '
        Me.lvTVGeneralShowListSorting.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTVGeneralShowListSortingDisplayIndex, Me.colTVGeneralShowListSortingColumn, Me.colTVGeneralShowListSortingLabel, Me.colTVGeneralShowListSortingHide})
        Me.tblTVGeneralShowListSorting.SetColumnSpan(Me.lvTVGeneralShowListSorting, 5)
        Me.lvTVGeneralShowListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTVGeneralShowListSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvTVGeneralShowListSorting.FullRowSelect = True
        Me.lvTVGeneralShowListSorting.HideSelection = False
        Me.lvTVGeneralShowListSorting.Location = New System.Drawing.Point(3, 3)
        Me.lvTVGeneralShowListSorting.Name = "lvTVGeneralShowListSorting"
        Me.lvTVGeneralShowListSorting.Size = New System.Drawing.Size(200, 312)
        Me.lvTVGeneralShowListSorting.TabIndex = 10
        Me.lvTVGeneralShowListSorting.UseCompatibleStateImageBehavior = False
        Me.lvTVGeneralShowListSorting.View = System.Windows.Forms.View.Details
        '
        'colTVGeneralShowListSortingDisplayIndex
        '
        Me.colTVGeneralShowListSortingDisplayIndex.Text = "DisplayIndex"
        Me.colTVGeneralShowListSortingDisplayIndex.Width = 0
        '
        'colTVGeneralShowListSortingColumn
        '
        Me.colTVGeneralShowListSortingColumn.Text = "DBName"
        Me.colTVGeneralShowListSortingColumn.Width = 0
        '
        'colTVGeneralShowListSortingLabel
        '
        Me.colTVGeneralShowListSortingLabel.Text = "Column"
        Me.colTVGeneralShowListSortingLabel.Width = 110
        '
        'colTVGeneralShowListSortingHide
        '
        Me.colTVGeneralShowListSortingHide.Text = "Hide"
        '
        'btnTVGeneralShowListSortingReset
        '
        Me.btnTVGeneralShowListSortingReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnTVGeneralShowListSortingReset.Image = CType(resources.GetObject("btnTVGeneralShowListSortingReset.Image"), System.Drawing.Image)
        Me.btnTVGeneralShowListSortingReset.Location = New System.Drawing.Point(180, 321)
        Me.btnTVGeneralShowListSortingReset.Name = "btnTVGeneralShowListSortingReset"
        Me.btnTVGeneralShowListSortingReset.Size = New System.Drawing.Size(23, 23)
        Me.btnTVGeneralShowListSortingReset.TabIndex = 11
        Me.btnTVGeneralShowListSortingReset.UseVisualStyleBackColor = True
        '
        'chkTVDisplayMissingEpisodes
        '
        Me.chkTVDisplayMissingEpisodes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVDisplayMissingEpisodes.AutoSize = True
        Me.chkTVDisplayMissingEpisodes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVDisplayMissingEpisodes.Location = New System.Drawing.Point(3, 26)
        Me.chkTVDisplayMissingEpisodes.Name = "chkTVDisplayMissingEpisodes"
        Me.chkTVDisplayMissingEpisodes.Size = New System.Drawing.Size(155, 17)
        Me.chkTVDisplayMissingEpisodes.TabIndex = 3
        Me.chkTVDisplayMissingEpisodes.Text = "Display Missing Episodes"
        Me.chkTVDisplayMissingEpisodes.UseVisualStyleBackColor = True
        '
        'chkTVDisplayStatus
        '
        Me.chkTVDisplayStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVDisplayStatus.AutoSize = True
        Me.chkTVDisplayStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVDisplayStatus.Location = New System.Drawing.Point(3, 3)
        Me.chkTVDisplayStatus.Name = "chkTVDisplayStatus"
        Me.chkTVDisplayStatus.Size = New System.Drawing.Size(155, 17)
        Me.chkTVDisplayStatus.TabIndex = 73
        Me.chkTVDisplayStatus.Text = "Display Status in List Title"
        Me.chkTVDisplayStatus.UseVisualStyleBackColor = True
        '
        'gbTVGeneralMediaListSortTokensOpts
        '
        Me.gbTVGeneralMediaListSortTokensOpts.AutoSize = True
        Me.gbTVGeneralMediaListSortTokensOpts.Controls.Add(Me.tblTVGeneralMediaListSortTokensOpts)
        Me.gbTVGeneralMediaListSortTokensOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralMediaListSortTokensOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbTVGeneralMediaListSortTokensOpts.Location = New System.Drawing.Point(221, 3)
        Me.gbTVGeneralMediaListSortTokensOpts.Name = "gbTVGeneralMediaListSortTokensOpts"
        Me.tblTVGeneralMediaListOpts.SetRowSpan(Me.gbTVGeneralMediaListSortTokensOpts, 3)
        Me.gbTVGeneralMediaListSortTokensOpts.Size = New System.Drawing.Size(212, 99)
        Me.gbTVGeneralMediaListSortTokensOpts.TabIndex = 72
        Me.gbTVGeneralMediaListSortTokensOpts.TabStop = False
        Me.gbTVGeneralMediaListSortTokensOpts.Text = "Sort Tokens to Ignore"
        '
        'tblTVGeneralMediaListSortTokensOpts
        '
        Me.tblTVGeneralMediaListSortTokensOpts.AutoSize = True
        Me.tblTVGeneralMediaListSortTokensOpts.ColumnCount = 5
        Me.tblTVGeneralMediaListSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMediaListSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMediaListSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMediaListSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMediaListSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVGeneralMediaListSortTokensOpts.Controls.Add(Me.btnTVSortTokenReset, 3, 1)
        Me.tblTVGeneralMediaListSortTokensOpts.Controls.Add(Me.btnTVSortTokenRemove, 2, 1)
        Me.tblTVGeneralMediaListSortTokensOpts.Controls.Add(Me.lstTVSortTokens, 0, 0)
        Me.tblTVGeneralMediaListSortTokensOpts.Controls.Add(Me.btnTVSortTokenAdd, 1, 1)
        Me.tblTVGeneralMediaListSortTokensOpts.Controls.Add(Me.txtTVSortToken, 0, 1)
        Me.tblTVGeneralMediaListSortTokensOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneralMediaListSortTokensOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVGeneralMediaListSortTokensOpts.Name = "tblTVGeneralMediaListSortTokensOpts"
        Me.tblTVGeneralMediaListSortTokensOpts.RowCount = 3
        Me.tblTVGeneralMediaListSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMediaListSortTokensOpts.Size = New System.Drawing.Size(206, 78)
        Me.tblTVGeneralMediaListSortTokensOpts.TabIndex = 74
        '
        'btnTVSortTokenReset
        '
        Me.btnTVSortTokenReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnTVSortTokenReset.Image = CType(resources.GetObject("btnTVSortTokenReset.Image"), System.Drawing.Image)
        Me.btnTVSortTokenReset.Location = New System.Drawing.Point(180, 52)
        Me.btnTVSortTokenReset.Name = "btnTVSortTokenReset"
        Me.btnTVSortTokenReset.Size = New System.Drawing.Size(23, 23)
        Me.btnTVSortTokenReset.TabIndex = 11
        Me.btnTVSortTokenReset.UseVisualStyleBackColor = True
        '
        'btnTVSortTokenRemove
        '
        Me.btnTVSortTokenRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnTVSortTokenRemove.Image = CType(resources.GetObject("btnTVSortTokenRemove.Image"), System.Drawing.Image)
        Me.btnTVSortTokenRemove.Location = New System.Drawing.Point(128, 52)
        Me.btnTVSortTokenRemove.Name = "btnTVSortTokenRemove"
        Me.btnTVSortTokenRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnTVSortTokenRemove.TabIndex = 3
        Me.btnTVSortTokenRemove.UseVisualStyleBackColor = True
        '
        'lstTVSortTokens
        '
        Me.tblTVGeneralMediaListSortTokensOpts.SetColumnSpan(Me.lstTVSortTokens, 4)
        Me.lstTVSortTokens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstTVSortTokens.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstTVSortTokens.FormattingEnabled = True
        Me.lstTVSortTokens.Location = New System.Drawing.Point(3, 3)
        Me.lstTVSortTokens.Name = "lstTVSortTokens"
        Me.lstTVSortTokens.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstTVSortTokens.Size = New System.Drawing.Size(200, 43)
        Me.lstTVSortTokens.Sorted = True
        Me.lstTVSortTokens.TabIndex = 0
        '
        'btnTVSortTokenAdd
        '
        Me.btnTVSortTokenAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnTVSortTokenAdd.Image = CType(resources.GetObject("btnTVSortTokenAdd.Image"), System.Drawing.Image)
        Me.btnTVSortTokenAdd.Location = New System.Drawing.Point(99, 52)
        Me.btnTVSortTokenAdd.Name = "btnTVSortTokenAdd"
        Me.btnTVSortTokenAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnTVSortTokenAdd.TabIndex = 2
        Me.btnTVSortTokenAdd.UseVisualStyleBackColor = True
        '
        'txtTVSortToken
        '
        Me.txtTVSortToken.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTVSortToken.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTVSortToken.Location = New System.Drawing.Point(3, 52)
        Me.txtTVSortToken.Name = "txtTVSortToken"
        Me.txtTVSortToken.Size = New System.Drawing.Size(90, 22)
        Me.txtTVSortToken.TabIndex = 1
        '
        'gbTVGeneralMainWindowOpts
        '
        Me.gbTVGeneralMainWindowOpts.AutoSize = True
        Me.gbTVGeneralMainWindowOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralMainWindowOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTVGeneralMainWindowOpts.Location = New System.Drawing.Point(451, 3)
        Me.gbTVGeneralMainWindowOpts.Name = "gbTVGeneralMainWindowOpts"
        Me.gbTVGeneralMainWindowOpts.Size = New System.Drawing.Size(497, 67)
        Me.gbTVGeneralMainWindowOpts.TabIndex = 4
        Me.gbTVGeneralMainWindowOpts.TabStop = False
        Me.gbTVGeneralMainWindowOpts.Text = "Main Window"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.lblTVLanguageOverlay, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbTVLanguageOverlay, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(512, 349)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'lblTVLanguageOverlay
        '
        Me.lblTVLanguageOverlay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVLanguageOverlay.AutoSize = True
        Me.lblTVLanguageOverlay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVLanguageOverlay.Location = New System.Drawing.Point(3, 0)
        Me.lblTVLanguageOverlay.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblTVLanguageOverlay.Name = "lblTVLanguageOverlay"
        Me.lblTVLanguageOverlay.Size = New System.Drawing.Size(240, 26)
        Me.lblTVLanguageOverlay.TabIndex = 1
        Me.lblTVLanguageOverlay.Text = "Display best Audio Stream with the following Language:"
        Me.lblTVLanguageOverlay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbTVLanguageOverlay
        '
        Me.cbTVLanguageOverlay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbTVLanguageOverlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVLanguageOverlay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbTVLanguageOverlay.FormattingEnabled = True
        Me.cbTVLanguageOverlay.Location = New System.Drawing.Point(36, 29)
        Me.cbTVLanguageOverlay.Name = "cbTVLanguageOverlay"
        Me.cbTVLanguageOverlay.Size = New System.Drawing.Size(174, 21)
        Me.cbTVLanguageOverlay.Sorted = True
        Me.cbTVLanguageOverlay.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoScroll = True
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 238)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'pnlTVScraper
        '
        Me.pnlTVScraper.AutoSize = True
        Me.pnlTVScraper.BackColor = System.Drawing.Color.White
        Me.pnlTVScraper.Controls.Add(Me.tblTVScraper)
        Me.pnlTVScraper.Location = New System.Drawing.Point(900, 900)
        Me.pnlTVScraper.Name = "pnlTVScraper"
        Me.pnlTVScraper.Size = New System.Drawing.Size(827, 566)
        Me.pnlTVScraper.TabIndex = 19
        Me.pnlTVScraper.Visible = False
        '
        'tblTVScraper
        '
        Me.tblTVScraper.AutoScroll = True
        Me.tblTVScraper.AutoSize = True
        Me.tblTVScraper.ColumnCount = 3
        Me.tblTVScraper.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraper.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraper.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraper.Controls.Add(Me.gbTVScraperCertificationOpts, 1, 2)
        Me.tblTVScraper.Controls.Add(Me.gbTVScraperGlobalOpts, 0, 0)
        Me.tblTVScraper.Controls.Add(Me.gbTVScraperMetaDataOpts, 1, 0)
        Me.tblTVScraper.Controls.Add(Me.gbTVScraperMiscOpts, 1, 1)
        Me.tblTVScraper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVScraper.Location = New System.Drawing.Point(0, 0)
        Me.tblTVScraper.Name = "tblTVScraper"
        Me.tblTVScraper.RowCount = 4
        Me.tblTVScraper.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraper.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraper.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraper.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraper.Size = New System.Drawing.Size(827, 566)
        Me.tblTVScraper.TabIndex = 6
        '
        'gbTVScraperCertificationOpts
        '
        Me.gbTVScraperCertificationOpts.AutoSize = True
        Me.gbTVScraperCertificationOpts.Controls.Add(Me.tblTVScraperCertificationOpts)
        Me.gbTVScraperCertificationOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVScraperCertificationOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTVScraperCertificationOpts.Location = New System.Drawing.Point(377, 362)
        Me.gbTVScraperCertificationOpts.Name = "gbTVScraperCertificationOpts"
        Me.gbTVScraperCertificationOpts.Size = New System.Drawing.Size(446, 141)
        Me.gbTVScraperCertificationOpts.TabIndex = 78
        Me.gbTVScraperCertificationOpts.TabStop = False
        Me.gbTVScraperCertificationOpts.Text = "Certification"
        '
        'tblTVScraperCertificationOpts
        '
        Me.tblTVScraperCertificationOpts.AutoSize = True
        Me.tblTVScraperCertificationOpts.ColumnCount = 2
        Me.tblTVScraperCertificationOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperCertificationOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperCertificationOpts.Controls.Add(Me.chkTVScraperShowCertOnlyValue, 0, 3)
        Me.tblTVScraperCertificationOpts.Controls.Add(Me.chkTVScraperShowCertFSK, 0, 2)
        Me.tblTVScraperCertificationOpts.Controls.Add(Me.chkTVScraperShowCertForMPAAFallback, 0, 1)
        Me.tblTVScraperCertificationOpts.Controls.Add(Me.chkTVScraperShowCertForMPAA, 0, 0)
        Me.tblTVScraperCertificationOpts.Controls.Add(Me.txtTVScraperShowMPAANotRated, 1, 4)
        Me.tblTVScraperCertificationOpts.Controls.Add(Me.lblTVScraperShowMPAANotRated, 0, 4)
        Me.tblTVScraperCertificationOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVScraperCertificationOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVScraperCertificationOpts.Name = "tblTVScraperCertificationOpts"
        Me.tblTVScraperCertificationOpts.RowCount = 6
        Me.tblTVScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperCertificationOpts.Size = New System.Drawing.Size(440, 120)
        Me.tblTVScraperCertificationOpts.TabIndex = 78
        '
        'chkTVScraperShowCertOnlyValue
        '
        Me.chkTVScraperShowCertOnlyValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVScraperShowCertOnlyValue.AutoSize = True
        Me.tblTVScraperCertificationOpts.SetColumnSpan(Me.chkTVScraperShowCertOnlyValue, 2)
        Me.chkTVScraperShowCertOnlyValue.Enabled = False
        Me.chkTVScraperShowCertOnlyValue.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowCertOnlyValue.Location = New System.Drawing.Point(3, 72)
        Me.chkTVScraperShowCertOnlyValue.Name = "chkTVScraperShowCertOnlyValue"
        Me.chkTVScraperShowCertOnlyValue.Size = New System.Drawing.Size(229, 17)
        Me.chkTVScraperShowCertOnlyValue.TabIndex = 66
        Me.chkTVScraperShowCertOnlyValue.Text = "MPAA: Save only number (only for YAMJ)"
        Me.chkTVScraperShowCertOnlyValue.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowCertFSK
        '
        Me.chkTVScraperShowCertFSK.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVScraperShowCertFSK.AutoSize = True
        Me.tblTVScraperCertificationOpts.SetColumnSpan(Me.chkTVScraperShowCertFSK, 2)
        Me.chkTVScraperShowCertFSK.Enabled = False
        Me.chkTVScraperShowCertFSK.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowCertFSK.Location = New System.Drawing.Point(3, 49)
        Me.chkTVScraperShowCertFSK.Name = "chkTVScraperShowCertFSK"
        Me.chkTVScraperShowCertFSK.Size = New System.Drawing.Size(212, 17)
        Me.chkTVScraperShowCertFSK.TabIndex = 67
        Me.chkTVScraperShowCertFSK.Text = "Use MPAA as Fallback for FSK Rating"
        Me.chkTVScraperShowCertFSK.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowCertForMPAAFallback
        '
        Me.chkTVScraperShowCertForMPAAFallback.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVScraperShowCertForMPAAFallback.AutoSize = True
        Me.tblTVScraperCertificationOpts.SetColumnSpan(Me.chkTVScraperShowCertForMPAAFallback, 2)
        Me.chkTVScraperShowCertForMPAAFallback.Enabled = False
        Me.chkTVScraperShowCertForMPAAFallback.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowCertForMPAAFallback.Location = New System.Drawing.Point(3, 26)
        Me.chkTVScraperShowCertForMPAAFallback.Name = "chkTVScraperShowCertForMPAAFallback"
        Me.chkTVScraperShowCertForMPAAFallback.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkTVScraperShowCertForMPAAFallback.Size = New System.Drawing.Size(175, 17)
        Me.chkTVScraperShowCertForMPAAFallback.TabIndex = 68
        Me.chkTVScraperShowCertForMPAAFallback.Text = "Only if no MPAA is found"
        Me.chkTVScraperShowCertForMPAAFallback.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowCertForMPAA
        '
        Me.chkTVScraperShowCertForMPAA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVScraperShowCertForMPAA.AutoSize = True
        Me.tblTVScraperCertificationOpts.SetColumnSpan(Me.chkTVScraperShowCertForMPAA, 2)
        Me.chkTVScraperShowCertForMPAA.Enabled = False
        Me.chkTVScraperShowCertForMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowCertForMPAA.Location = New System.Drawing.Point(3, 3)
        Me.chkTVScraperShowCertForMPAA.Name = "chkTVScraperShowCertForMPAA"
        Me.chkTVScraperShowCertForMPAA.Size = New System.Drawing.Size(230, 17)
        Me.chkTVScraperShowCertForMPAA.TabIndex = 6
        Me.chkTVScraperShowCertForMPAA.Text = "Use Certification for MPAA (XBMC users)"
        Me.chkTVScraperShowCertForMPAA.UseVisualStyleBackColor = True
        '
        'txtTVScraperShowMPAANotRated
        '
        Me.txtTVScraperShowMPAANotRated.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTVScraperShowMPAANotRated.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTVScraperShowMPAANotRated.Location = New System.Drawing.Point(198, 95)
        Me.txtTVScraperShowMPAANotRated.Name = "txtTVScraperShowMPAANotRated"
        Me.txtTVScraperShowMPAANotRated.Size = New System.Drawing.Size(239, 22)
        Me.txtTVScraperShowMPAANotRated.TabIndex = 69
        '
        'lblTVScraperShowMPAANotRated
        '
        Me.lblTVScraperShowMPAANotRated.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperShowMPAANotRated.AutoSize = True
        Me.lblTVScraperShowMPAANotRated.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTVScraperShowMPAANotRated.Location = New System.Drawing.Point(3, 99)
        Me.lblTVScraperShowMPAANotRated.Name = "lblTVScraperShowMPAANotRated"
        Me.lblTVScraperShowMPAANotRated.Size = New System.Drawing.Size(189, 13)
        Me.lblTVScraperShowMPAANotRated.TabIndex = 68
        Me.lblTVScraperShowMPAANotRated.Text = "MPAA value if no rating is available:"
        '
        'gbTVScraperGlobalOpts
        '
        Me.gbTVScraperGlobalOpts.AutoSize = True
        Me.gbTVScraperGlobalOpts.Controls.Add(Me.tblTVScraperGlobalOpts)
        Me.gbTVScraperGlobalOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVScraperGlobalOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbTVScraperGlobalOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbTVScraperGlobalOpts.Name = "gbTVScraperGlobalOpts"
        Me.tblTVScraper.SetRowSpan(Me.gbTVScraperGlobalOpts, 3)
        Me.gbTVScraperGlobalOpts.Size = New System.Drawing.Size(368, 500)
        Me.gbTVScraperGlobalOpts.TabIndex = 3
        Me.gbTVScraperGlobalOpts.TabStop = False
        Me.gbTVScraperGlobalOpts.Text = "Scraper Fields - Global"
        '
        'tblTVScraperGlobalOpts
        '
        Me.tblTVScraperGlobalOpts.AutoSize = True
        Me.tblTVScraperGlobalOpts.ColumnCount = 9
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockEpisodeRuntime, 7, 17)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowRuntime, 2, 17)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.cbTVScraperShowCertLang, 3, 4)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockEpisodeRating, 7, 15)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowStudio, 2, 19)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowStatus, 2, 18)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockEpisodePlot, 7, 13)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowGenre, 2, 9)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowPlot, 2, 13)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeActors, 6, 2)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowRating, 2, 15)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeRuntime, 6, 17)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeCredits, 6, 6)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalHeaderShows, 1, 0)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeDirector, 6, 7)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowStatus, 1, 18)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodePlot, 6, 13)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowRuntime, 1, 17)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeAired, 6, 3)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeRating, 6, 15)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowActors, 1, 2)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowRating, 1, 15)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowStudio, 1, 19)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalHeaderEpisodes, 6, 0)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalHeaderShowsLock, 2, 1)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalHeaderEpisodesLock, 7, 1)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowPremiered, 1, 14)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalActors, 0, 2)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalAired, 0, 3)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalCredits, 0, 6)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowPlot, 1, 13)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowMPAA, 1, 11)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowEpiGuideURL, 1, 8)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowGenre, 1, 9)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalEpisodeGuideURL, 0, 8)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalGenres, 0, 9)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalMPAA, 0, 11)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalPlot, 0, 13)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalPremiered, 0, 14)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalRating, 0, 15)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalRuntime, 0, 17)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalStatus, 0, 18)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalStudios, 0, 19)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalDirectors, 0, 7)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalTitle, 0, 20)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowTitle, 1, 20)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowTitle, 2, 20)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeTitle, 6, 20)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockEpisodeTitle, 7, 20)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalGuestStars, 0, 10)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeGuestStars, 6, 10)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalLanguageA, 0, 21)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalLanguageV, 0, 22)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockEpisodeLanguageA, 7, 21)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockEpisodeLanguageV, 7, 22)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalHeaderShowsLimit, 3, 1)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalCertifications, 0, 4)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowCert, 1, 4)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowCert, 2, 4)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalOriginalTitle, 0, 12)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowOriginalTitle, 1, 12)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowOriginalTitle, 2, 12)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowMPAA, 2, 11)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalCreators, 0, 5)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowCreators, 1, 5)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowCreators, 2, 5)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockSeasonPlot, 5, 13)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperSeasonPlot, 4, 13)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalHeaderSeasonsLock, 5, 1)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalHeaderSeasons, 4, 0)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperSeasonAired, 4, 3)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperSeasonTitle, 4, 20)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockSeasonTitle, 5, 20)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.lblTVScraperGlobalUserRating, 0, 16)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperShowUserRating, 1, 16)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockShowUserRating, 2, 16)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVScraperEpisodeUserRating, 6, 16)
        Me.tblTVScraperGlobalOpts.Controls.Add(Me.chkTVLockEpisodeUserRating, 7, 16)
        Me.tblTVScraperGlobalOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVScraperGlobalOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVScraperGlobalOpts.Name = "tblTVScraperGlobalOpts"
        Me.tblTVScraperGlobalOpts.RowCount = 24
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperGlobalOpts.Size = New System.Drawing.Size(362, 479)
        Me.tblTVScraperGlobalOpts.TabIndex = 6
        '
        'chkTVLockEpisodeRuntime
        '
        Me.chkTVLockEpisodeRuntime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockEpisodeRuntime.AutoSize = True
        Me.chkTVLockEpisodeRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockEpisodeRuntime.Location = New System.Drawing.Point(335, 350)
        Me.chkTVLockEpisodeRuntime.Name = "chkTVLockEpisodeRuntime"
        Me.chkTVLockEpisodeRuntime.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockEpisodeRuntime.TabIndex = 3
        Me.chkTVLockEpisodeRuntime.UseVisualStyleBackColor = True
        '
        'chkTVLockShowRuntime
        '
        Me.chkTVLockShowRuntime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowRuntime.AutoSize = True
        Me.chkTVLockShowRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowRuntime.Location = New System.Drawing.Point(143, 350)
        Me.chkTVLockShowRuntime.Name = "chkTVLockShowRuntime"
        Me.chkTVLockShowRuntime.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowRuntime.TabIndex = 6
        Me.chkTVLockShowRuntime.UseVisualStyleBackColor = True
        '
        'cbTVScraperShowCertLang
        '
        Me.cbTVScraperShowCertLang.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbTVScraperShowCertLang.DropDownHeight = 200
        Me.cbTVScraperShowCertLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVScraperShowCertLang.DropDownWidth = 110
        Me.cbTVScraperShowCertLang.Enabled = False
        Me.cbTVScraperShowCertLang.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbTVScraperShowCertLang.FormattingEnabled = True
        Me.cbTVScraperShowCertLang.IntegralHeight = False
        Me.cbTVScraperShowCertLang.Items.AddRange(New Object() {"Argentina", "Australia", "Belgium", "Brazil", "Canada", "Finland", "France", "Germany", "Hong Kong", "Hungary", "Iceland", "Ireland", "Netherlands", "New Zealand", "Peru", "Poland", "Portugal", "Serbia", "Singapore", "South Korea", "Spain", "Sweden", "Switzerland", "Turkey", "UK", "USA"})
        Me.cbTVScraperShowCertLang.Location = New System.Drawing.Point(172, 83)
        Me.cbTVScraperShowCertLang.Name = "cbTVScraperShowCertLang"
        Me.cbTVScraperShowCertLang.Size = New System.Drawing.Size(70, 21)
        Me.cbTVScraperShowCertLang.Sorted = True
        Me.cbTVScraperShowCertLang.TabIndex = 5
        '
        'chkTVLockEpisodeRating
        '
        Me.chkTVLockEpisodeRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockEpisodeRating.AutoSize = True
        Me.chkTVLockEpisodeRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockEpisodeRating.Location = New System.Drawing.Point(335, 310)
        Me.chkTVLockEpisodeRating.Name = "chkTVLockEpisodeRating"
        Me.chkTVLockEpisodeRating.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockEpisodeRating.TabIndex = 2
        Me.chkTVLockEpisodeRating.UseVisualStyleBackColor = True
        '
        'chkTVLockShowStudio
        '
        Me.chkTVLockShowStudio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowStudio.AutoSize = True
        Me.chkTVLockShowStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowStudio.Location = New System.Drawing.Point(143, 390)
        Me.chkTVLockShowStudio.Name = "chkTVLockShowStudio"
        Me.chkTVLockShowStudio.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowStudio.TabIndex = 4
        Me.chkTVLockShowStudio.UseVisualStyleBackColor = True
        '
        'chkTVLockShowStatus
        '
        Me.chkTVLockShowStatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowStatus.AutoSize = True
        Me.chkTVLockShowStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowStatus.Location = New System.Drawing.Point(143, 370)
        Me.chkTVLockShowStatus.Name = "chkTVLockShowStatus"
        Me.chkTVLockShowStatus.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowStatus.TabIndex = 5
        Me.chkTVLockShowStatus.UseVisualStyleBackColor = True
        '
        'chkTVLockEpisodePlot
        '
        Me.chkTVLockEpisodePlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockEpisodePlot.AutoSize = True
        Me.chkTVLockEpisodePlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockEpisodePlot.Location = New System.Drawing.Point(335, 270)
        Me.chkTVLockEpisodePlot.Name = "chkTVLockEpisodePlot"
        Me.chkTVLockEpisodePlot.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockEpisodePlot.TabIndex = 1
        Me.chkTVLockEpisodePlot.UseVisualStyleBackColor = True
        '
        'chkTVLockShowGenre
        '
        Me.chkTVLockShowGenre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowGenre.AutoSize = True
        Me.chkTVLockShowGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowGenre.Location = New System.Drawing.Point(143, 190)
        Me.chkTVLockShowGenre.Name = "chkTVLockShowGenre"
        Me.chkTVLockShowGenre.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowGenre.TabIndex = 3
        Me.chkTVLockShowGenre.UseVisualStyleBackColor = True
        '
        'chkTVLockShowPlot
        '
        Me.chkTVLockShowPlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowPlot.AutoSize = True
        Me.chkTVLockShowPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowPlot.Location = New System.Drawing.Point(143, 270)
        Me.chkTVLockShowPlot.Name = "chkTVLockShowPlot"
        Me.chkTVLockShowPlot.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowPlot.TabIndex = 1
        Me.chkTVLockShowPlot.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodeActors
        '
        Me.chkTVScraperEpisodeActors.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeActors.AutoSize = True
        Me.chkTVScraperEpisodeActors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeActors.Location = New System.Drawing.Point(306, 43)
        Me.chkTVScraperEpisodeActors.Name = "chkTVScraperEpisodeActors"
        Me.chkTVScraperEpisodeActors.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeActors.TabIndex = 0
        Me.chkTVScraperEpisodeActors.UseVisualStyleBackColor = True
        '
        'chkTVLockShowRating
        '
        Me.chkTVLockShowRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowRating.AutoSize = True
        Me.chkTVLockShowRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowRating.Location = New System.Drawing.Point(143, 310)
        Me.chkTVLockShowRating.Name = "chkTVLockShowRating"
        Me.chkTVLockShowRating.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowRating.TabIndex = 2
        Me.chkTVLockShowRating.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodeRuntime
        '
        Me.chkTVScraperEpisodeRuntime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeRuntime.AutoSize = True
        Me.chkTVScraperEpisodeRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeRuntime.Location = New System.Drawing.Point(306, 350)
        Me.chkTVScraperEpisodeRuntime.Name = "chkTVScraperEpisodeRuntime"
        Me.chkTVScraperEpisodeRuntime.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeRuntime.TabIndex = 9
        Me.chkTVScraperEpisodeRuntime.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodeCredits
        '
        Me.chkTVScraperEpisodeCredits.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeCredits.AutoSize = True
        Me.chkTVScraperEpisodeCredits.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeCredits.Location = New System.Drawing.Point(306, 130)
        Me.chkTVScraperEpisodeCredits.Name = "chkTVScraperEpisodeCredits"
        Me.chkTVScraperEpisodeCredits.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeCredits.TabIndex = 8
        Me.chkTVScraperEpisodeCredits.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalHeaderShows
        '
        Me.lblTVScraperGlobalHeaderShows.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVScraperGlobalHeaderShows.AutoSize = True
        Me.tblTVScraperGlobalOpts.SetColumnSpan(Me.lblTVScraperGlobalHeaderShows, 3)
        Me.lblTVScraperGlobalHeaderShows.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVScraperGlobalHeaderShows.Location = New System.Drawing.Point(157, 3)
        Me.lblTVScraperGlobalHeaderShows.Name = "lblTVScraperGlobalHeaderShows"
        Me.lblTVScraperGlobalHeaderShows.Size = New System.Drawing.Size(41, 13)
        Me.lblTVScraperGlobalHeaderShows.TabIndex = 0
        Me.lblTVScraperGlobalHeaderShows.Text = "Shows"
        '
        'chkTVScraperEpisodeDirector
        '
        Me.chkTVScraperEpisodeDirector.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeDirector.AutoSize = True
        Me.chkTVScraperEpisodeDirector.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeDirector.Location = New System.Drawing.Point(306, 150)
        Me.chkTVScraperEpisodeDirector.Name = "chkTVScraperEpisodeDirector"
        Me.chkTVScraperEpisodeDirector.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeDirector.TabIndex = 7
        Me.chkTVScraperEpisodeDirector.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowStatus
        '
        Me.chkTVScraperShowStatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowStatus.AutoSize = True
        Me.chkTVScraperShowStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowStatus.Location = New System.Drawing.Point(114, 370)
        Me.chkTVScraperShowStatus.Name = "chkTVScraperShowStatus"
        Me.chkTVScraperShowStatus.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowStatus.TabIndex = 9
        Me.chkTVScraperShowStatus.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodePlot
        '
        Me.chkTVScraperEpisodePlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodePlot.AutoSize = True
        Me.chkTVScraperEpisodePlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodePlot.Location = New System.Drawing.Point(306, 270)
        Me.chkTVScraperEpisodePlot.Name = "chkTVScraperEpisodePlot"
        Me.chkTVScraperEpisodePlot.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodePlot.TabIndex = 6
        Me.chkTVScraperEpisodePlot.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowRuntime
        '
        Me.chkTVScraperShowRuntime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowRuntime.AutoSize = True
        Me.chkTVScraperShowRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowRuntime.Location = New System.Drawing.Point(114, 350)
        Me.chkTVScraperShowRuntime.Name = "chkTVScraperShowRuntime"
        Me.chkTVScraperShowRuntime.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowRuntime.TabIndex = 10
        Me.chkTVScraperShowRuntime.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodeAired
        '
        Me.chkTVScraperEpisodeAired.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeAired.AutoSize = True
        Me.chkTVScraperEpisodeAired.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeAired.Location = New System.Drawing.Point(306, 63)
        Me.chkTVScraperEpisodeAired.Name = "chkTVScraperEpisodeAired"
        Me.chkTVScraperEpisodeAired.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeAired.TabIndex = 4
        Me.chkTVScraperEpisodeAired.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodeRating
        '
        Me.chkTVScraperEpisodeRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeRating.AutoSize = True
        Me.chkTVScraperEpisodeRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeRating.Location = New System.Drawing.Point(306, 310)
        Me.chkTVScraperEpisodeRating.Name = "chkTVScraperEpisodeRating"
        Me.chkTVScraperEpisodeRating.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeRating.TabIndex = 5
        Me.chkTVScraperEpisodeRating.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowActors
        '
        Me.chkTVScraperShowActors.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowActors.AutoSize = True
        Me.chkTVScraperShowActors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowActors.Location = New System.Drawing.Point(114, 43)
        Me.chkTVScraperShowActors.Name = "chkTVScraperShowActors"
        Me.chkTVScraperShowActors.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowActors.TabIndex = 8
        Me.chkTVScraperShowActors.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowRating
        '
        Me.chkTVScraperShowRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowRating.AutoSize = True
        Me.chkTVScraperShowRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowRating.Location = New System.Drawing.Point(114, 310)
        Me.chkTVScraperShowRating.Name = "chkTVScraperShowRating"
        Me.chkTVScraperShowRating.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowRating.TabIndex = 6
        Me.chkTVScraperShowRating.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowStudio
        '
        Me.chkTVScraperShowStudio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowStudio.AutoSize = True
        Me.chkTVScraperShowStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowStudio.Location = New System.Drawing.Point(114, 390)
        Me.chkTVScraperShowStudio.Name = "chkTVScraperShowStudio"
        Me.chkTVScraperShowStudio.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowStudio.TabIndex = 7
        Me.chkTVScraperShowStudio.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalHeaderEpisodes
        '
        Me.lblTVScraperGlobalHeaderEpisodes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVScraperGlobalHeaderEpisodes.AutoSize = True
        Me.tblTVScraperGlobalOpts.SetColumnSpan(Me.lblTVScraperGlobalHeaderEpisodes, 2)
        Me.lblTVScraperGlobalHeaderEpisodes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVScraperGlobalHeaderEpisodes.Location = New System.Drawing.Point(306, 3)
        Me.lblTVScraperGlobalHeaderEpisodes.Name = "lblTVScraperGlobalHeaderEpisodes"
        Me.lblTVScraperGlobalHeaderEpisodes.Size = New System.Drawing.Size(53, 13)
        Me.lblTVScraperGlobalHeaderEpisodes.TabIndex = 0
        Me.lblTVScraperGlobalHeaderEpisodes.Text = "Episodes"
        '
        'lblTVScraperGlobalHeaderShowsLock
        '
        Me.lblTVScraperGlobalHeaderShowsLock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVScraperGlobalHeaderShowsLock.AutoSize = True
        Me.lblTVScraperGlobalHeaderShowsLock.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVScraperGlobalHeaderShowsLock.Location = New System.Drawing.Point(135, 23)
        Me.lblTVScraperGlobalHeaderShowsLock.Name = "lblTVScraperGlobalHeaderShowsLock"
        Me.lblTVScraperGlobalHeaderShowsLock.Size = New System.Drawing.Size(31, 13)
        Me.lblTVScraperGlobalHeaderShowsLock.TabIndex = 1
        Me.lblTVScraperGlobalHeaderShowsLock.Text = "Lock"
        '
        'lblTVScraperGlobalHeaderEpisodesLock
        '
        Me.lblTVScraperGlobalHeaderEpisodesLock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVScraperGlobalHeaderEpisodesLock.AutoSize = True
        Me.lblTVScraperGlobalHeaderEpisodesLock.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVScraperGlobalHeaderEpisodesLock.Location = New System.Drawing.Point(327, 23)
        Me.lblTVScraperGlobalHeaderEpisodesLock.Name = "lblTVScraperGlobalHeaderEpisodesLock"
        Me.lblTVScraperGlobalHeaderEpisodesLock.Size = New System.Drawing.Size(31, 13)
        Me.lblTVScraperGlobalHeaderEpisodesLock.TabIndex = 1
        Me.lblTVScraperGlobalHeaderEpisodesLock.Text = "Lock"
        '
        'chkTVScraperShowPremiered
        '
        Me.chkTVScraperShowPremiered.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowPremiered.AutoSize = True
        Me.chkTVScraperShowPremiered.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowPremiered.Location = New System.Drawing.Point(114, 290)
        Me.chkTVScraperShowPremiered.Name = "chkTVScraperShowPremiered"
        Me.chkTVScraperShowPremiered.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowPremiered.TabIndex = 5
        Me.chkTVScraperShowPremiered.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalActors
        '
        Me.lblTVScraperGlobalActors.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalActors.AutoSize = True
        Me.lblTVScraperGlobalActors.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalActors.Location = New System.Drawing.Point(3, 43)
        Me.lblTVScraperGlobalActors.Name = "lblTVScraperGlobalActors"
        Me.lblTVScraperGlobalActors.Size = New System.Drawing.Size(39, 13)
        Me.lblTVScraperGlobalActors.TabIndex = 2
        Me.lblTVScraperGlobalActors.Text = "Actors"
        '
        'lblTVScraperGlobalAired
        '
        Me.lblTVScraperGlobalAired.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalAired.AutoSize = True
        Me.lblTVScraperGlobalAired.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalAired.Location = New System.Drawing.Point(3, 63)
        Me.lblTVScraperGlobalAired.Name = "lblTVScraperGlobalAired"
        Me.lblTVScraperGlobalAired.Size = New System.Drawing.Size(34, 13)
        Me.lblTVScraperGlobalAired.TabIndex = 2
        Me.lblTVScraperGlobalAired.Text = "Aired"
        '
        'lblTVScraperGlobalCredits
        '
        Me.lblTVScraperGlobalCredits.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalCredits.AutoSize = True
        Me.lblTVScraperGlobalCredits.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalCredits.Location = New System.Drawing.Point(3, 130)
        Me.lblTVScraperGlobalCredits.Name = "lblTVScraperGlobalCredits"
        Me.lblTVScraperGlobalCredits.Size = New System.Drawing.Size(43, 13)
        Me.lblTVScraperGlobalCredits.TabIndex = 2
        Me.lblTVScraperGlobalCredits.Text = "Credits"
        '
        'chkTVScraperShowPlot
        '
        Me.chkTVScraperShowPlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowPlot.AutoSize = True
        Me.chkTVScraperShowPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowPlot.Location = New System.Drawing.Point(114, 270)
        Me.chkTVScraperShowPlot.Name = "chkTVScraperShowPlot"
        Me.chkTVScraperShowPlot.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowPlot.TabIndex = 4
        Me.chkTVScraperShowPlot.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowMPAA
        '
        Me.chkTVScraperShowMPAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowMPAA.AutoSize = True
        Me.chkTVScraperShowMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowMPAA.Location = New System.Drawing.Point(114, 230)
        Me.chkTVScraperShowMPAA.Name = "chkTVScraperShowMPAA"
        Me.chkTVScraperShowMPAA.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowMPAA.TabIndex = 3
        Me.chkTVScraperShowMPAA.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowEpiGuideURL
        '
        Me.chkTVScraperShowEpiGuideURL.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowEpiGuideURL.AutoSize = True
        Me.chkTVScraperShowEpiGuideURL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowEpiGuideURL.Location = New System.Drawing.Point(114, 170)
        Me.chkTVScraperShowEpiGuideURL.Name = "chkTVScraperShowEpiGuideURL"
        Me.chkTVScraperShowEpiGuideURL.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowEpiGuideURL.TabIndex = 1
        Me.chkTVScraperShowEpiGuideURL.UseVisualStyleBackColor = True
        '
        'chkTVScraperShowGenre
        '
        Me.chkTVScraperShowGenre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowGenre.AutoSize = True
        Me.chkTVScraperShowGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowGenre.Location = New System.Drawing.Point(114, 190)
        Me.chkTVScraperShowGenre.Name = "chkTVScraperShowGenre"
        Me.chkTVScraperShowGenre.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowGenre.TabIndex = 2
        Me.chkTVScraperShowGenre.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalEpisodeGuideURL
        '
        Me.lblTVScraperGlobalEpisodeGuideURL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalEpisodeGuideURL.AutoSize = True
        Me.lblTVScraperGlobalEpisodeGuideURL.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalEpisodeGuideURL.Location = New System.Drawing.Point(3, 170)
        Me.lblTVScraperGlobalEpisodeGuideURL.Name = "lblTVScraperGlobalEpisodeGuideURL"
        Me.lblTVScraperGlobalEpisodeGuideURL.Size = New System.Drawing.Size(105, 13)
        Me.lblTVScraperGlobalEpisodeGuideURL.TabIndex = 2
        Me.lblTVScraperGlobalEpisodeGuideURL.Text = "Episode Guide URL"
        '
        'lblTVScraperGlobalGenres
        '
        Me.lblTVScraperGlobalGenres.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalGenres.AutoSize = True
        Me.lblTVScraperGlobalGenres.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalGenres.Location = New System.Drawing.Point(3, 190)
        Me.lblTVScraperGlobalGenres.Name = "lblTVScraperGlobalGenres"
        Me.lblTVScraperGlobalGenres.Size = New System.Drawing.Size(43, 13)
        Me.lblTVScraperGlobalGenres.TabIndex = 2
        Me.lblTVScraperGlobalGenres.Text = "Genres"
        '
        'lblTVScraperGlobalMPAA
        '
        Me.lblTVScraperGlobalMPAA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalMPAA.AutoSize = True
        Me.lblTVScraperGlobalMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalMPAA.Location = New System.Drawing.Point(3, 230)
        Me.lblTVScraperGlobalMPAA.Name = "lblTVScraperGlobalMPAA"
        Me.lblTVScraperGlobalMPAA.Size = New System.Drawing.Size(36, 13)
        Me.lblTVScraperGlobalMPAA.TabIndex = 2
        Me.lblTVScraperGlobalMPAA.Text = "MPAA"
        '
        'lblTVScraperGlobalPlot
        '
        Me.lblTVScraperGlobalPlot.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalPlot.AutoSize = True
        Me.lblTVScraperGlobalPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalPlot.Location = New System.Drawing.Point(3, 270)
        Me.lblTVScraperGlobalPlot.Name = "lblTVScraperGlobalPlot"
        Me.lblTVScraperGlobalPlot.Size = New System.Drawing.Size(27, 13)
        Me.lblTVScraperGlobalPlot.TabIndex = 2
        Me.lblTVScraperGlobalPlot.Text = "Plot"
        '
        'lblTVScraperGlobalPremiered
        '
        Me.lblTVScraperGlobalPremiered.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalPremiered.AutoSize = True
        Me.lblTVScraperGlobalPremiered.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalPremiered.Location = New System.Drawing.Point(3, 290)
        Me.lblTVScraperGlobalPremiered.Name = "lblTVScraperGlobalPremiered"
        Me.lblTVScraperGlobalPremiered.Size = New System.Drawing.Size(58, 13)
        Me.lblTVScraperGlobalPremiered.TabIndex = 2
        Me.lblTVScraperGlobalPremiered.Text = "Premiered"
        '
        'lblTVScraperGlobalRating
        '
        Me.lblTVScraperGlobalRating.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalRating.AutoSize = True
        Me.lblTVScraperGlobalRating.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalRating.Location = New System.Drawing.Point(3, 310)
        Me.lblTVScraperGlobalRating.Name = "lblTVScraperGlobalRating"
        Me.lblTVScraperGlobalRating.Size = New System.Drawing.Size(41, 13)
        Me.lblTVScraperGlobalRating.TabIndex = 2
        Me.lblTVScraperGlobalRating.Text = "Rating"
        '
        'lblTVScraperGlobalRuntime
        '
        Me.lblTVScraperGlobalRuntime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalRuntime.AutoSize = True
        Me.lblTVScraperGlobalRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalRuntime.Location = New System.Drawing.Point(3, 350)
        Me.lblTVScraperGlobalRuntime.Name = "lblTVScraperGlobalRuntime"
        Me.lblTVScraperGlobalRuntime.Size = New System.Drawing.Size(50, 13)
        Me.lblTVScraperGlobalRuntime.TabIndex = 2
        Me.lblTVScraperGlobalRuntime.Text = "Runtime"
        '
        'lblTVScraperGlobalStatus
        '
        Me.lblTVScraperGlobalStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalStatus.AutoSize = True
        Me.lblTVScraperGlobalStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalStatus.Location = New System.Drawing.Point(3, 370)
        Me.lblTVScraperGlobalStatus.Name = "lblTVScraperGlobalStatus"
        Me.lblTVScraperGlobalStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblTVScraperGlobalStatus.TabIndex = 2
        Me.lblTVScraperGlobalStatus.Text = "Status"
        '
        'lblTVScraperGlobalStudios
        '
        Me.lblTVScraperGlobalStudios.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalStudios.AutoSize = True
        Me.lblTVScraperGlobalStudios.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalStudios.Location = New System.Drawing.Point(3, 390)
        Me.lblTVScraperGlobalStudios.Name = "lblTVScraperGlobalStudios"
        Me.lblTVScraperGlobalStudios.Size = New System.Drawing.Size(46, 13)
        Me.lblTVScraperGlobalStudios.TabIndex = 2
        Me.lblTVScraperGlobalStudios.Text = "Studios"
        '
        'lblTVScraperGlobalDirectors
        '
        Me.lblTVScraperGlobalDirectors.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalDirectors.AutoSize = True
        Me.lblTVScraperGlobalDirectors.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalDirectors.Location = New System.Drawing.Point(3, 150)
        Me.lblTVScraperGlobalDirectors.Name = "lblTVScraperGlobalDirectors"
        Me.lblTVScraperGlobalDirectors.Size = New System.Drawing.Size(53, 13)
        Me.lblTVScraperGlobalDirectors.TabIndex = 2
        Me.lblTVScraperGlobalDirectors.Text = "Directors"
        '
        'lblTVScraperGlobalTitle
        '
        Me.lblTVScraperGlobalTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalTitle.AutoSize = True
        Me.lblTVScraperGlobalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalTitle.Location = New System.Drawing.Point(3, 410)
        Me.lblTVScraperGlobalTitle.Name = "lblTVScraperGlobalTitle"
        Me.lblTVScraperGlobalTitle.Size = New System.Drawing.Size(28, 13)
        Me.lblTVScraperGlobalTitle.TabIndex = 2
        Me.lblTVScraperGlobalTitle.Text = "Title"
        '
        'chkTVScraperShowTitle
        '
        Me.chkTVScraperShowTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowTitle.AutoSize = True
        Me.chkTVScraperShowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowTitle.Location = New System.Drawing.Point(114, 410)
        Me.chkTVScraperShowTitle.Name = "chkTVScraperShowTitle"
        Me.chkTVScraperShowTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowTitle.TabIndex = 0
        Me.chkTVScraperShowTitle.UseVisualStyleBackColor = True
        '
        'chkTVLockShowTitle
        '
        Me.chkTVLockShowTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowTitle.AutoSize = True
        Me.chkTVLockShowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowTitle.Location = New System.Drawing.Point(143, 410)
        Me.chkTVLockShowTitle.Name = "chkTVLockShowTitle"
        Me.chkTVLockShowTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowTitle.TabIndex = 0
        Me.chkTVLockShowTitle.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodeTitle
        '
        Me.chkTVScraperEpisodeTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeTitle.AutoSize = True
        Me.chkTVScraperEpisodeTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeTitle.Location = New System.Drawing.Point(306, 410)
        Me.chkTVScraperEpisodeTitle.Name = "chkTVScraperEpisodeTitle"
        Me.chkTVScraperEpisodeTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeTitle.TabIndex = 0
        Me.chkTVScraperEpisodeTitle.UseVisualStyleBackColor = True
        '
        'chkTVLockEpisodeTitle
        '
        Me.chkTVLockEpisodeTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockEpisodeTitle.AutoSize = True
        Me.chkTVLockEpisodeTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockEpisodeTitle.Location = New System.Drawing.Point(335, 410)
        Me.chkTVLockEpisodeTitle.Name = "chkTVLockEpisodeTitle"
        Me.chkTVLockEpisodeTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockEpisodeTitle.TabIndex = 0
        Me.chkTVLockEpisodeTitle.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalGuestStars
        '
        Me.lblTVScraperGlobalGuestStars.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalGuestStars.AutoSize = True
        Me.lblTVScraperGlobalGuestStars.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalGuestStars.Location = New System.Drawing.Point(3, 210)
        Me.lblTVScraperGlobalGuestStars.Name = "lblTVScraperGlobalGuestStars"
        Me.lblTVScraperGlobalGuestStars.Size = New System.Drawing.Size(65, 13)
        Me.lblTVScraperGlobalGuestStars.TabIndex = 2
        Me.lblTVScraperGlobalGuestStars.Text = "Guest Stars"
        '
        'chkTVScraperEpisodeGuestStars
        '
        Me.chkTVScraperEpisodeGuestStars.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeGuestStars.AutoSize = True
        Me.chkTVScraperEpisodeGuestStars.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeGuestStars.Location = New System.Drawing.Point(306, 210)
        Me.chkTVScraperEpisodeGuestStars.Name = "chkTVScraperEpisodeGuestStars"
        Me.chkTVScraperEpisodeGuestStars.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeGuestStars.TabIndex = 3
        Me.chkTVScraperEpisodeGuestStars.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalLanguageA
        '
        Me.lblTVScraperGlobalLanguageA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalLanguageA.AutoSize = True
        Me.lblTVScraperGlobalLanguageA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTVScraperGlobalLanguageA.Location = New System.Drawing.Point(3, 430)
        Me.lblTVScraperGlobalLanguageA.Name = "lblTVScraperGlobalLanguageA"
        Me.lblTVScraperGlobalLanguageA.Size = New System.Drawing.Size(98, 13)
        Me.lblTVScraperGlobalLanguageA.TabIndex = 12
        Me.lblTVScraperGlobalLanguageA.Text = "Language (Audio)"
        '
        'lblTVScraperGlobalLanguageV
        '
        Me.lblTVScraperGlobalLanguageV.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalLanguageV.AutoSize = True
        Me.lblTVScraperGlobalLanguageV.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTVScraperGlobalLanguageV.Location = New System.Drawing.Point(3, 450)
        Me.lblTVScraperGlobalLanguageV.Name = "lblTVScraperGlobalLanguageV"
        Me.lblTVScraperGlobalLanguageV.Size = New System.Drawing.Size(97, 13)
        Me.lblTVScraperGlobalLanguageV.TabIndex = 13
        Me.lblTVScraperGlobalLanguageV.Text = "Language (Video)"
        '
        'chkTVLockEpisodeLanguageA
        '
        Me.chkTVLockEpisodeLanguageA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockEpisodeLanguageA.AutoSize = True
        Me.chkTVLockEpisodeLanguageA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkTVLockEpisodeLanguageA.Location = New System.Drawing.Point(335, 430)
        Me.chkTVLockEpisodeLanguageA.Name = "chkTVLockEpisodeLanguageA"
        Me.chkTVLockEpisodeLanguageA.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockEpisodeLanguageA.TabIndex = 14
        Me.chkTVLockEpisodeLanguageA.UseVisualStyleBackColor = True
        '
        'chkTVLockEpisodeLanguageV
        '
        Me.chkTVLockEpisodeLanguageV.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockEpisodeLanguageV.AutoSize = True
        Me.chkTVLockEpisodeLanguageV.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkTVLockEpisodeLanguageV.Location = New System.Drawing.Point(335, 450)
        Me.chkTVLockEpisodeLanguageV.Name = "chkTVLockEpisodeLanguageV"
        Me.chkTVLockEpisodeLanguageV.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockEpisodeLanguageV.TabIndex = 15
        Me.chkTVLockEpisodeLanguageV.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalHeaderShowsLimit
        '
        Me.lblTVScraperGlobalHeaderShowsLimit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVScraperGlobalHeaderShowsLimit.AutoSize = True
        Me.lblTVScraperGlobalHeaderShowsLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVScraperGlobalHeaderShowsLimit.Location = New System.Drawing.Point(190, 23)
        Me.lblTVScraperGlobalHeaderShowsLimit.Name = "lblTVScraperGlobalHeaderShowsLimit"
        Me.lblTVScraperGlobalHeaderShowsLimit.Size = New System.Drawing.Size(33, 13)
        Me.lblTVScraperGlobalHeaderShowsLimit.TabIndex = 1
        Me.lblTVScraperGlobalHeaderShowsLimit.Text = "Limit"
        '
        'lblTVScraperGlobalCertifications
        '
        Me.lblTVScraperGlobalCertifications.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalCertifications.AutoSize = True
        Me.lblTVScraperGlobalCertifications.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalCertifications.Location = New System.Drawing.Point(3, 87)
        Me.lblTVScraperGlobalCertifications.Name = "lblTVScraperGlobalCertifications"
        Me.lblTVScraperGlobalCertifications.Size = New System.Drawing.Size(75, 13)
        Me.lblTVScraperGlobalCertifications.TabIndex = 2
        Me.lblTVScraperGlobalCertifications.Text = "Certifications"
        '
        'chkTVScraperShowCert
        '
        Me.chkTVScraperShowCert.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowCert.AutoSize = True
        Me.chkTVScraperShowCert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowCert.Location = New System.Drawing.Point(114, 86)
        Me.chkTVScraperShowCert.Name = "chkTVScraperShowCert"
        Me.chkTVScraperShowCert.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowCert.TabIndex = 8
        Me.chkTVScraperShowCert.UseVisualStyleBackColor = True
        '
        'chkTVLockShowCert
        '
        Me.chkTVLockShowCert.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowCert.AutoSize = True
        Me.chkTVLockShowCert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowCert.Location = New System.Drawing.Point(143, 86)
        Me.chkTVLockShowCert.Name = "chkTVLockShowCert"
        Me.chkTVLockShowCert.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowCert.TabIndex = 3
        Me.chkTVLockShowCert.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalOriginalTitle
        '
        Me.lblTVScraperGlobalOriginalTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalOriginalTitle.AutoSize = True
        Me.lblTVScraperGlobalOriginalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalOriginalTitle.Location = New System.Drawing.Point(3, 250)
        Me.lblTVScraperGlobalOriginalTitle.Name = "lblTVScraperGlobalOriginalTitle"
        Me.lblTVScraperGlobalOriginalTitle.Size = New System.Drawing.Size(73, 13)
        Me.lblTVScraperGlobalOriginalTitle.TabIndex = 2
        Me.lblTVScraperGlobalOriginalTitle.Text = "Original Title"
        '
        'chkTVScraperShowOriginalTitle
        '
        Me.chkTVScraperShowOriginalTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowOriginalTitle.AutoSize = True
        Me.chkTVScraperShowOriginalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowOriginalTitle.Location = New System.Drawing.Point(114, 250)
        Me.chkTVScraperShowOriginalTitle.Name = "chkTVScraperShowOriginalTitle"
        Me.chkTVScraperShowOriginalTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowOriginalTitle.TabIndex = 3
        Me.chkTVScraperShowOriginalTitle.UseVisualStyleBackColor = True
        '
        'chkTVLockShowOriginalTitle
        '
        Me.chkTVLockShowOriginalTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowOriginalTitle.AutoSize = True
        Me.chkTVLockShowOriginalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowOriginalTitle.Location = New System.Drawing.Point(143, 250)
        Me.chkTVLockShowOriginalTitle.Name = "chkTVLockShowOriginalTitle"
        Me.chkTVLockShowOriginalTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowOriginalTitle.TabIndex = 1
        Me.chkTVLockShowOriginalTitle.UseVisualStyleBackColor = True
        '
        'chkTVLockShowMPAA
        '
        Me.chkTVLockShowMPAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowMPAA.AutoSize = True
        Me.chkTVLockShowMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowMPAA.Location = New System.Drawing.Point(143, 230)
        Me.chkTVLockShowMPAA.Name = "chkTVLockShowMPAA"
        Me.chkTVLockShowMPAA.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowMPAA.TabIndex = 1
        Me.chkTVLockShowMPAA.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalCreators
        '
        Me.lblTVScraperGlobalCreators.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalCreators.AutoSize = True
        Me.lblTVScraperGlobalCreators.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalCreators.Location = New System.Drawing.Point(3, 110)
        Me.lblTVScraperGlobalCreators.Name = "lblTVScraperGlobalCreators"
        Me.lblTVScraperGlobalCreators.Size = New System.Drawing.Size(50, 13)
        Me.lblTVScraperGlobalCreators.TabIndex = 2
        Me.lblTVScraperGlobalCreators.Text = "Creators"
        '
        'chkTVScraperShowCreators
        '
        Me.chkTVScraperShowCreators.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowCreators.AutoSize = True
        Me.chkTVScraperShowCreators.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowCreators.Location = New System.Drawing.Point(114, 110)
        Me.chkTVScraperShowCreators.Name = "chkTVScraperShowCreators"
        Me.chkTVScraperShowCreators.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowCreators.TabIndex = 8
        Me.chkTVScraperShowCreators.UseVisualStyleBackColor = True
        '
        'chkTVLockShowCreators
        '
        Me.chkTVLockShowCreators.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowCreators.AutoSize = True
        Me.chkTVLockShowCreators.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowCreators.Location = New System.Drawing.Point(143, 110)
        Me.chkTVLockShowCreators.Name = "chkTVLockShowCreators"
        Me.chkTVLockShowCreators.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowCreators.TabIndex = 3
        Me.chkTVLockShowCreators.UseVisualStyleBackColor = True
        '
        'chkTVLockSeasonPlot
        '
        Me.chkTVLockSeasonPlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockSeasonPlot.AutoSize = True
        Me.chkTVLockSeasonPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockSeasonPlot.Location = New System.Drawing.Point(277, 270)
        Me.chkTVLockSeasonPlot.Name = "chkTVLockSeasonPlot"
        Me.chkTVLockSeasonPlot.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockSeasonPlot.TabIndex = 1
        Me.chkTVLockSeasonPlot.UseVisualStyleBackColor = True
        '
        'chkTVScraperSeasonPlot
        '
        Me.chkTVScraperSeasonPlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperSeasonPlot.AutoSize = True
        Me.chkTVScraperSeasonPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperSeasonPlot.Location = New System.Drawing.Point(248, 270)
        Me.chkTVScraperSeasonPlot.Name = "chkTVScraperSeasonPlot"
        Me.chkTVScraperSeasonPlot.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperSeasonPlot.TabIndex = 4
        Me.chkTVScraperSeasonPlot.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalHeaderSeasonsLock
        '
        Me.lblTVScraperGlobalHeaderSeasonsLock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVScraperGlobalHeaderSeasonsLock.AutoSize = True
        Me.lblTVScraperGlobalHeaderSeasonsLock.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVScraperGlobalHeaderSeasonsLock.Location = New System.Drawing.Point(269, 23)
        Me.lblTVScraperGlobalHeaderSeasonsLock.Name = "lblTVScraperGlobalHeaderSeasonsLock"
        Me.lblTVScraperGlobalHeaderSeasonsLock.Size = New System.Drawing.Size(31, 13)
        Me.lblTVScraperGlobalHeaderSeasonsLock.TabIndex = 1
        Me.lblTVScraperGlobalHeaderSeasonsLock.Text = "Lock"
        '
        'lblTVScraperGlobalHeaderSeasons
        '
        Me.lblTVScraperGlobalHeaderSeasons.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVScraperGlobalHeaderSeasons.AutoSize = True
        Me.tblTVScraperGlobalOpts.SetColumnSpan(Me.lblTVScraperGlobalHeaderSeasons, 2)
        Me.lblTVScraperGlobalHeaderSeasons.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVScraperGlobalHeaderSeasons.Location = New System.Drawing.Point(252, 3)
        Me.lblTVScraperGlobalHeaderSeasons.Name = "lblTVScraperGlobalHeaderSeasons"
        Me.lblTVScraperGlobalHeaderSeasons.Size = New System.Drawing.Size(44, 13)
        Me.lblTVScraperGlobalHeaderSeasons.TabIndex = 0
        Me.lblTVScraperGlobalHeaderSeasons.Text = "Season"
        '
        'chkTVScraperSeasonAired
        '
        Me.chkTVScraperSeasonAired.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperSeasonAired.AutoSize = True
        Me.chkTVScraperSeasonAired.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperSeasonAired.Location = New System.Drawing.Point(248, 63)
        Me.chkTVScraperSeasonAired.Name = "chkTVScraperSeasonAired"
        Me.chkTVScraperSeasonAired.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperSeasonAired.TabIndex = 4
        Me.chkTVScraperSeasonAired.UseVisualStyleBackColor = True
        '
        'chkTVScraperSeasonTitle
        '
        Me.chkTVScraperSeasonTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperSeasonTitle.AutoSize = True
        Me.chkTVScraperSeasonTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperSeasonTitle.Location = New System.Drawing.Point(248, 410)
        Me.chkTVScraperSeasonTitle.Name = "chkTVScraperSeasonTitle"
        Me.chkTVScraperSeasonTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperSeasonTitle.TabIndex = 4
        Me.chkTVScraperSeasonTitle.UseVisualStyleBackColor = True
        '
        'chkTVLockSeasonTitle
        '
        Me.chkTVLockSeasonTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockSeasonTitle.AutoSize = True
        Me.chkTVLockSeasonTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockSeasonTitle.Location = New System.Drawing.Point(277, 410)
        Me.chkTVLockSeasonTitle.Name = "chkTVLockSeasonTitle"
        Me.chkTVLockSeasonTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockSeasonTitle.TabIndex = 1
        Me.chkTVLockSeasonTitle.UseVisualStyleBackColor = True
        '
        'lblTVScraperGlobalUserRating
        '
        Me.lblTVScraperGlobalUserRating.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperGlobalUserRating.AutoSize = True
        Me.lblTVScraperGlobalUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTVScraperGlobalUserRating.Location = New System.Drawing.Point(3, 330)
        Me.lblTVScraperGlobalUserRating.Name = "lblTVScraperGlobalUserRating"
        Me.lblTVScraperGlobalUserRating.Size = New System.Drawing.Size(67, 13)
        Me.lblTVScraperGlobalUserRating.TabIndex = 2
        Me.lblTVScraperGlobalUserRating.Text = "User Rating"
        '
        'chkTVScraperShowUserRating
        '
        Me.chkTVScraperShowUserRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperShowUserRating.AutoSize = True
        Me.chkTVScraperShowUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperShowUserRating.Location = New System.Drawing.Point(114, 330)
        Me.chkTVScraperShowUserRating.Name = "chkTVScraperShowUserRating"
        Me.chkTVScraperShowUserRating.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperShowUserRating.TabIndex = 6
        Me.chkTVScraperShowUserRating.UseVisualStyleBackColor = True
        '
        'chkTVLockShowUserRating
        '
        Me.chkTVLockShowUserRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockShowUserRating.AutoSize = True
        Me.chkTVLockShowUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockShowUserRating.Location = New System.Drawing.Point(143, 330)
        Me.chkTVLockShowUserRating.Name = "chkTVLockShowUserRating"
        Me.chkTVLockShowUserRating.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockShowUserRating.TabIndex = 2
        Me.chkTVLockShowUserRating.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodeUserRating
        '
        Me.chkTVScraperEpisodeUserRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVScraperEpisodeUserRating.AutoSize = True
        Me.chkTVScraperEpisodeUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperEpisodeUserRating.Location = New System.Drawing.Point(306, 330)
        Me.chkTVScraperEpisodeUserRating.Name = "chkTVScraperEpisodeUserRating"
        Me.chkTVScraperEpisodeUserRating.Size = New System.Drawing.Size(15, 14)
        Me.chkTVScraperEpisodeUserRating.TabIndex = 5
        Me.chkTVScraperEpisodeUserRating.UseVisualStyleBackColor = True
        '
        'chkTVLockEpisodeUserRating
        '
        Me.chkTVLockEpisodeUserRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkTVLockEpisodeUserRating.AutoSize = True
        Me.chkTVLockEpisodeUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVLockEpisodeUserRating.Location = New System.Drawing.Point(335, 330)
        Me.chkTVLockEpisodeUserRating.Name = "chkTVLockEpisodeUserRating"
        Me.chkTVLockEpisodeUserRating.Size = New System.Drawing.Size(15, 14)
        Me.chkTVLockEpisodeUserRating.TabIndex = 2
        Me.chkTVLockEpisodeUserRating.UseVisualStyleBackColor = True
        '
        'gbTVScraperMetaDataOpts
        '
        Me.gbTVScraperMetaDataOpts.AutoSize = True
        Me.gbTVScraperMetaDataOpts.Controls.Add(Me.tblTVScraperMetaDataOpts)
        Me.gbTVScraperMetaDataOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVScraperMetaDataOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbTVScraperMetaDataOpts.Location = New System.Drawing.Point(377, 3)
        Me.gbTVScraperMetaDataOpts.Name = "gbTVScraperMetaDataOpts"
        Me.gbTVScraperMetaDataOpts.Size = New System.Drawing.Size(446, 211)
        Me.gbTVScraperMetaDataOpts.TabIndex = 2
        Me.gbTVScraperMetaDataOpts.TabStop = False
        Me.gbTVScraperMetaDataOpts.Text = "Meta Data"
        '
        'tblTVScraperMetaDataOpts
        '
        Me.tblTVScraperMetaDataOpts.AutoSize = True
        Me.tblTVScraperMetaDataOpts.ColumnCount = 3
        Me.tblTVScraperMetaDataOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperMetaDataOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperMetaDataOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperMetaDataOpts.Controls.Add(Me.gbTVScraperDefFIExtOpts, 1, 0)
        Me.tblTVScraperMetaDataOpts.Controls.Add(Me.chkTVScraperMetaDataScan, 0, 0)
        Me.tblTVScraperMetaDataOpts.Controls.Add(Me.gbTVScraperDurationFormatOpts, 0, 1)
        Me.tblTVScraperMetaDataOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVScraperMetaDataOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVScraperMetaDataOpts.Name = "tblTVScraperMetaDataOpts"
        Me.tblTVScraperMetaDataOpts.RowCount = 4
        Me.tblTVScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMetaDataOpts.Size = New System.Drawing.Size(440, 190)
        Me.tblTVScraperMetaDataOpts.TabIndex = 6
        '
        'gbTVScraperDefFIExtOpts
        '
        Me.gbTVScraperDefFIExtOpts.AutoSize = True
        Me.gbTVScraperDefFIExtOpts.Controls.Add(Me.tblTVScraperDefFIExtOpts)
        Me.gbTVScraperDefFIExtOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbTVScraperDefFIExtOpts.Location = New System.Drawing.Point(257, 3)
        Me.gbTVScraperDefFIExtOpts.Name = "gbTVScraperDefFIExtOpts"
        Me.tblTVScraperMetaDataOpts.SetRowSpan(Me.gbTVScraperDefFIExtOpts, 3)
        Me.gbTVScraperDefFIExtOpts.Size = New System.Drawing.Size(180, 184)
        Me.gbTVScraperDefFIExtOpts.TabIndex = 3
        Me.gbTVScraperDefFIExtOpts.TabStop = False
        Me.gbTVScraperDefFIExtOpts.Text = "Defaults by File Type"
        '
        'tblTVScraperDefFIExtOpts
        '
        Me.tblTVScraperDefFIExtOpts.AutoSize = True
        Me.tblTVScraperDefFIExtOpts.ColumnCount = 5
        Me.tblTVScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperDefFIExtOpts.Controls.Add(Me.btnTVScraperDefFIExtRemove, 3, 2)
        Me.tblTVScraperDefFIExtOpts.Controls.Add(Me.txtTVScraperDefFIExt, 0, 2)
        Me.tblTVScraperDefFIExtOpts.Controls.Add(Me.btnTVScraperDefFIExtEdit, 2, 2)
        Me.tblTVScraperDefFIExtOpts.Controls.Add(Me.lstTVScraperDefFIExt, 0, 0)
        Me.tblTVScraperDefFIExtOpts.Controls.Add(Me.btnTVScraperDefFIExtAdd, 1, 2)
        Me.tblTVScraperDefFIExtOpts.Controls.Add(Me.lblTVScraperDefFIExt, 0, 1)
        Me.tblTVScraperDefFIExtOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVScraperDefFIExtOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVScraperDefFIExtOpts.Name = "tblTVScraperDefFIExtOpts"
        Me.tblTVScraperDefFIExtOpts.RowCount = 4
        Me.tblTVScraperDefFIExtOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperDefFIExtOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTVScraperDefFIExtOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperDefFIExtOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperDefFIExtOpts.Size = New System.Drawing.Size(174, 163)
        Me.tblTVScraperDefFIExtOpts.TabIndex = 7
        '
        'btnTVScraperDefFIExtRemove
        '
        Me.btnTVScraperDefFIExtRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnTVScraperDefFIExtRemove.Enabled = False
        Me.btnTVScraperDefFIExtRemove.Image = CType(resources.GetObject("btnTVScraperDefFIExtRemove.Image"), System.Drawing.Image)
        Me.btnTVScraperDefFIExtRemove.Location = New System.Drawing.Point(148, 137)
        Me.btnTVScraperDefFIExtRemove.Name = "btnTVScraperDefFIExtRemove"
        Me.btnTVScraperDefFIExtRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnTVScraperDefFIExtRemove.TabIndex = 4
        Me.btnTVScraperDefFIExtRemove.UseVisualStyleBackColor = True
        '
        'txtTVScraperDefFIExt
        '
        Me.txtTVScraperDefFIExt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTVScraperDefFIExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTVScraperDefFIExt.Location = New System.Drawing.Point(3, 137)
        Me.txtTVScraperDefFIExt.Name = "txtTVScraperDefFIExt"
        Me.txtTVScraperDefFIExt.Size = New System.Drawing.Size(80, 22)
        Me.txtTVScraperDefFIExt.TabIndex = 2
        '
        'btnTVScraperDefFIExtEdit
        '
        Me.btnTVScraperDefFIExtEdit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnTVScraperDefFIExtEdit.Enabled = False
        Me.btnTVScraperDefFIExtEdit.Image = CType(resources.GetObject("btnTVScraperDefFIExtEdit.Image"), System.Drawing.Image)
        Me.btnTVScraperDefFIExtEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTVScraperDefFIExtEdit.Location = New System.Drawing.Point(118, 137)
        Me.btnTVScraperDefFIExtEdit.Name = "btnTVScraperDefFIExtEdit"
        Me.btnTVScraperDefFIExtEdit.Size = New System.Drawing.Size(23, 23)
        Me.btnTVScraperDefFIExtEdit.TabIndex = 3
        Me.btnTVScraperDefFIExtEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTVScraperDefFIExtEdit.UseVisualStyleBackColor = True
        '
        'lstTVScraperDefFIExt
        '
        Me.tblTVScraperDefFIExtOpts.SetColumnSpan(Me.lstTVScraperDefFIExt, 4)
        Me.lstTVScraperDefFIExt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstTVScraperDefFIExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstTVScraperDefFIExt.FormattingEnabled = True
        Me.lstTVScraperDefFIExt.Location = New System.Drawing.Point(3, 3)
        Me.lstTVScraperDefFIExt.Name = "lstTVScraperDefFIExt"
        Me.lstTVScraperDefFIExt.Size = New System.Drawing.Size(168, 108)
        Me.lstTVScraperDefFIExt.TabIndex = 0
        '
        'btnTVScraperDefFIExtAdd
        '
        Me.btnTVScraperDefFIExtAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnTVScraperDefFIExtAdd.Enabled = False
        Me.btnTVScraperDefFIExtAdd.Image = CType(resources.GetObject("btnTVScraperDefFIExtAdd.Image"), System.Drawing.Image)
        Me.btnTVScraperDefFIExtAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTVScraperDefFIExtAdd.Location = New System.Drawing.Point(89, 137)
        Me.btnTVScraperDefFIExtAdd.Name = "btnTVScraperDefFIExtAdd"
        Me.btnTVScraperDefFIExtAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnTVScraperDefFIExtAdd.TabIndex = 29
        Me.btnTVScraperDefFIExtAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTVScraperDefFIExtAdd.UseVisualStyleBackColor = True
        '
        'lblTVScraperDefFIExt
        '
        Me.lblTVScraperDefFIExt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVScraperDefFIExt.AutoSize = True
        Me.lblTVScraperDefFIExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVScraperDefFIExt.Location = New System.Drawing.Point(3, 117)
        Me.lblTVScraperDefFIExt.Name = "lblTVScraperDefFIExt"
        Me.lblTVScraperDefFIExt.Size = New System.Drawing.Size(53, 13)
        Me.lblTVScraperDefFIExt.TabIndex = 1
        Me.lblTVScraperDefFIExt.Text = "File Type:"
        '
        'chkTVScraperMetaDataScan
        '
        Me.chkTVScraperMetaDataScan.AutoSize = True
        Me.chkTVScraperMetaDataScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperMetaDataScan.Location = New System.Drawing.Point(3, 3)
        Me.chkTVScraperMetaDataScan.Name = "chkTVScraperMetaDataScan"
        Me.chkTVScraperMetaDataScan.Size = New System.Drawing.Size(106, 17)
        Me.chkTVScraperMetaDataScan.TabIndex = 0
        Me.chkTVScraperMetaDataScan.Text = "Scan Meta Data"
        Me.chkTVScraperMetaDataScan.UseVisualStyleBackColor = True
        '
        'gbTVScraperDurationFormatOpts
        '
        Me.gbTVScraperDurationFormatOpts.AutoSize = True
        Me.gbTVScraperDurationFormatOpts.Controls.Add(Me.tblgbTVScraperDurationFormatOpts)
        Me.gbTVScraperDurationFormatOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTVScraperDurationFormatOpts.Location = New System.Drawing.Point(3, 26)
        Me.gbTVScraperDurationFormatOpts.Name = "gbTVScraperDurationFormatOpts"
        Me.gbTVScraperDurationFormatOpts.Size = New System.Drawing.Size(248, 72)
        Me.gbTVScraperDurationFormatOpts.TabIndex = 4
        Me.gbTVScraperDurationFormatOpts.TabStop = False
        Me.gbTVScraperDurationFormatOpts.Text = "Duration Format"
        '
        'tblgbTVScraperDurationFormatOpts
        '
        Me.tblgbTVScraperDurationFormatOpts.AutoSize = True
        Me.tblgbTVScraperDurationFormatOpts.ColumnCount = 3
        Me.tblgbTVScraperDurationFormatOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblgbTVScraperDurationFormatOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblgbTVScraperDurationFormatOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblgbTVScraperDurationFormatOpts.Controls.Add(Me.chkTVScraperUseMDDuration, 0, 0)
        Me.tblgbTVScraperDurationFormatOpts.Controls.Add(Me.txtTVScraperDurationRuntimeFormat, 0, 1)
        Me.tblgbTVScraperDurationFormatOpts.Controls.Add(Me.lblTVScraperDurationRuntimeFormat, 1, 0)
        Me.tblgbTVScraperDurationFormatOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblgbTVScraperDurationFormatOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblgbTVScraperDurationFormatOpts.Name = "tblgbTVScraperDurationFormatOpts"
        Me.tblgbTVScraperDurationFormatOpts.RowCount = 3
        Me.tblgbTVScraperDurationFormatOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblgbTVScraperDurationFormatOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblgbTVScraperDurationFormatOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblgbTVScraperDurationFormatOpts.Size = New System.Drawing.Size(242, 51)
        Me.tblgbTVScraperDurationFormatOpts.TabIndex = 6
        '
        'chkTVScraperUseMDDuration
        '
        Me.chkTVScraperUseMDDuration.AutoSize = True
        Me.chkTVScraperUseMDDuration.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperUseMDDuration.Location = New System.Drawing.Point(3, 3)
        Me.chkTVScraperUseMDDuration.Name = "chkTVScraperUseMDDuration"
        Me.chkTVScraperUseMDDuration.Size = New System.Drawing.Size(158, 17)
        Me.chkTVScraperUseMDDuration.TabIndex = 1
        Me.chkTVScraperUseMDDuration.Text = "Use Duration for Runtime"
        Me.chkTVScraperUseMDDuration.UseVisualStyleBackColor = True
        '
        'txtTVScraperDurationRuntimeFormat
        '
        Me.txtTVScraperDurationRuntimeFormat.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtTVScraperDurationRuntimeFormat.Location = New System.Drawing.Point(3, 26)
        Me.txtTVScraperDurationRuntimeFormat.Name = "txtTVScraperDurationRuntimeFormat"
        Me.txtTVScraperDurationRuntimeFormat.Size = New System.Drawing.Size(160, 22)
        Me.txtTVScraperDurationRuntimeFormat.TabIndex = 0
        '
        'lblTVScraperDurationRuntimeFormat
        '
        Me.lblTVScraperDurationRuntimeFormat.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTVScraperDurationRuntimeFormat.AutoSize = True
        Me.lblTVScraperDurationRuntimeFormat.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.lblTVScraperDurationRuntimeFormat.Location = New System.Drawing.Point(169, 7)
        Me.lblTVScraperDurationRuntimeFormat.Name = "lblTVScraperDurationRuntimeFormat"
        Me.tblgbTVScraperDurationFormatOpts.SetRowSpan(Me.lblTVScraperDurationRuntimeFormat, 2)
        Me.lblTVScraperDurationRuntimeFormat.Size = New System.Drawing.Size(70, 36)
        Me.lblTVScraperDurationRuntimeFormat.TabIndex = 24
        Me.lblTVScraperDurationRuntimeFormat.Text = "<h>=Hours" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<m>=Minutes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<s>=Seconds"
        Me.lblTVScraperDurationRuntimeFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbTVScraperMiscOpts
        '
        Me.gbTVScraperMiscOpts.AutoSize = True
        Me.gbTVScraperMiscOpts.Controls.Add(Me.tblTVScraperMiscOpts)
        Me.gbTVScraperMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVScraperMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTVScraperMiscOpts.Location = New System.Drawing.Point(377, 220)
        Me.gbTVScraperMiscOpts.Name = "gbTVScraperMiscOpts"
        Me.gbTVScraperMiscOpts.Size = New System.Drawing.Size(446, 136)
        Me.gbTVScraperMiscOpts.TabIndex = 5
        Me.gbTVScraperMiscOpts.TabStop = False
        Me.gbTVScraperMiscOpts.Text = "Miscellaneous"
        '
        'tblTVScraperMiscOpts
        '
        Me.tblTVScraperMiscOpts.AutoSize = True
        Me.tblTVScraperMiscOpts.ColumnCount = 2
        Me.tblTVScraperMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTVScraperMiscOpts.Controls.Add(Me.chkTVScraperUseSRuntimeForEp, 0, 2)
        Me.tblTVScraperMiscOpts.Controls.Add(Me.chkTVScraperCleanFields, 0, 0)
        Me.tblTVScraperMiscOpts.Controls.Add(Me.chkTVScraperUseDisplaySeasonEpisode, 0, 3)
        Me.tblTVScraperMiscOpts.Controls.Add(Me.chkTVScraperEpisodeGuestStarsToActors, 0, 4)
        Me.tblTVScraperMiscOpts.Controls.Add(Me.chkTVScraperCastWithImg, 0, 1)
        Me.tblTVScraperMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVScraperMiscOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVScraperMiscOpts.Name = "tblTVScraperMiscOpts"
        Me.tblTVScraperMiscOpts.RowCount = 6
        Me.tblTVScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVScraperMiscOpts.Size = New System.Drawing.Size(440, 115)
        Me.tblTVScraperMiscOpts.TabIndex = 6
        '
        'chkTVScraperUseSRuntimeForEp
        '
        Me.chkTVScraperUseSRuntimeForEp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVScraperUseSRuntimeForEp.AutoSize = True
        Me.chkTVScraperUseSRuntimeForEp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperUseSRuntimeForEp.Location = New System.Drawing.Point(3, 49)
        Me.chkTVScraperUseSRuntimeForEp.Name = "chkTVScraperUseSRuntimeForEp"
        Me.chkTVScraperUseSRuntimeForEp.Size = New System.Drawing.Size(379, 17)
        Me.chkTVScraperUseSRuntimeForEp.TabIndex = 1
        Me.chkTVScraperUseSRuntimeForEp.Text = "Use Show Runtime for Episodes if no Episode Runtime can be found"
        Me.chkTVScraperUseSRuntimeForEp.UseVisualStyleBackColor = True
        '
        'chkTVScraperCleanFields
        '
        Me.chkTVScraperCleanFields.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVScraperCleanFields.AutoSize = True
        Me.chkTVScraperCleanFields.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperCleanFields.Location = New System.Drawing.Point(3, 3)
        Me.chkTVScraperCleanFields.Name = "chkTVScraperCleanFields"
        Me.chkTVScraperCleanFields.Size = New System.Drawing.Size(147, 17)
        Me.chkTVScraperCleanFields.TabIndex = 79
        Me.chkTVScraperCleanFields.Text = "Cleanup disabled fields"
        Me.chkTVScraperCleanFields.UseVisualStyleBackColor = True
        '
        'chkTVScraperUseDisplaySeasonEpisode
        '
        Me.chkTVScraperUseDisplaySeasonEpisode.AutoSize = True
        Me.chkTVScraperUseDisplaySeasonEpisode.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkTVScraperUseDisplaySeasonEpisode.Location = New System.Drawing.Point(3, 72)
        Me.chkTVScraperUseDisplaySeasonEpisode.Name = "chkTVScraperUseDisplaySeasonEpisode"
        Me.chkTVScraperUseDisplaySeasonEpisode.Size = New System.Drawing.Size(358, 17)
        Me.chkTVScraperUseDisplaySeasonEpisode.TabIndex = 2
        Me.chkTVScraperUseDisplaySeasonEpisode.Text = "Add <displayseason> and <displayepisode> to special episodes"
        Me.chkTVScraperUseDisplaySeasonEpisode.UseVisualStyleBackColor = True
        '
        'chkTVScraperEpisodeGuestStarsToActors
        '
        Me.chkTVScraperEpisodeGuestStarsToActors.AutoSize = True
        Me.chkTVScraperEpisodeGuestStarsToActors.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkTVScraperEpisodeGuestStarsToActors.Location = New System.Drawing.Point(3, 95)
        Me.chkTVScraperEpisodeGuestStarsToActors.Name = "chkTVScraperEpisodeGuestStarsToActors"
        Me.chkTVScraperEpisodeGuestStarsToActors.Size = New System.Drawing.Size(219, 17)
        Me.chkTVScraperEpisodeGuestStarsToActors.TabIndex = 2
        Me.chkTVScraperEpisodeGuestStarsToActors.Text = "Add Episode Guest Stars to Actors list"
        Me.chkTVScraperEpisodeGuestStarsToActors.UseVisualStyleBackColor = True
        '
        'chkTVScraperCastWithImg
        '
        Me.chkTVScraperCastWithImg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVScraperCastWithImg.AutoSize = True
        Me.chkTVScraperCastWithImg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVScraperCastWithImg.Location = New System.Drawing.Point(3, 26)
        Me.chkTVScraperCastWithImg.Name = "chkTVScraperCastWithImg"
        Me.chkTVScraperCastWithImg.Size = New System.Drawing.Size(189, 17)
        Me.chkTVScraperCastWithImg.TabIndex = 80
        Me.chkTVScraperCastWithImg.Text = "Scrape Only Actors With Images"
        Me.chkTVScraperCastWithImg.UseVisualStyleBackColor = True
        '
        'tsSettingsTopMenu
        '
        Me.tsSettingsTopMenu.AllowMerge = False
        Me.tsSettingsTopMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsSettingsTopMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsSettingsTopMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tsSettingsTopMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsSettingsTopMenu.Name = "tsSettingsTopMenu"
        Me.tsSettingsTopMenu.Size = New System.Drawing.Size(1654, 25)
        Me.tsSettingsTopMenu.Stretch = True
        Me.tsSettingsTopMenu.TabIndex = 4
        Me.tsSettingsTopMenu.Text = "ToolStrip1"
        '
        'pnlSettingsMain
        '
        Me.pnlSettingsMain.BackColor = System.Drawing.Color.White
        Me.pnlSettingsMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsMain.Name = "pnlSettingsMain"
        Me.pnlSettingsMain.Size = New System.Drawing.Size(1398, 1006)
        Me.pnlSettingsMain.TabIndex = 9
        '
        'gbSettingsHelp
        '
        Me.gbSettingsHelp.BackColor = System.Drawing.Color.White
        Me.gbSettingsHelp.Controls.Add(Me.pbSettingsHelpLogo)
        Me.gbSettingsHelp.Controls.Add(Me.lblHelp)
        Me.gbSettingsHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbSettingsHelp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSettingsHelp.Location = New System.Drawing.Point(0, 0)
        Me.gbSettingsHelp.Name = "gbSettingsHelp"
        Me.gbSettingsHelp.Size = New System.Drawing.Size(1116, 66)
        Me.gbSettingsHelp.TabIndex = 0
        Me.gbSettingsHelp.TabStop = False
        Me.gbSettingsHelp.Text = "     Help"
        '
        'pbSettingsHelpLogo
        '
        Me.pbSettingsHelpLogo.Image = CType(resources.GetObject("pbSettingsHelpLogo.Image"), System.Drawing.Image)
        Me.pbSettingsHelpLogo.Location = New System.Drawing.Point(6, 0)
        Me.pbSettingsHelpLogo.Name = "pbSettingsHelpLogo"
        Me.pbSettingsHelpLogo.Size = New System.Drawing.Size(16, 16)
        Me.pbSettingsHelpLogo.TabIndex = 1
        Me.pbSettingsHelpLogo.TabStop = False
        '
        'lblHelp
        '
        Me.lblHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHelp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp.Location = New System.Drawing.Point(3, 18)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(1110, 45)
        Me.lblHelp.TabIndex = 0
        '
        'pnlSettingsHelp
        '
        Me.pnlSettingsHelp.BackColor = System.Drawing.Color.White
        Me.pnlSettingsHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSettingsHelp.Controls.Add(Me.gbSettingsHelp)
        Me.pnlSettingsHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsHelp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSettingsHelp.Location = New System.Drawing.Point(3, 3)
        Me.pnlSettingsHelp.Name = "pnlSettingsHelp"
        Me.pnlSettingsHelp.Size = New System.Drawing.Size(1118, 68)
        Me.pnlSettingsHelp.TabIndex = 8
        '
        'pnlMovieSetGeneral
        '
        Me.pnlMovieSetGeneral.AutoSize = True
        Me.pnlMovieSetGeneral.BackColor = System.Drawing.Color.White
        Me.pnlMovieSetGeneral.Controls.Add(Me.tblMovieSetGeneral)
        Me.pnlMovieSetGeneral.Location = New System.Drawing.Point(900, 900)
        Me.pnlMovieSetGeneral.Name = "pnlMovieSetGeneral"
        Me.pnlMovieSetGeneral.Size = New System.Drawing.Size(733, 570)
        Me.pnlMovieSetGeneral.TabIndex = 24
        Me.pnlMovieSetGeneral.Visible = False
        '
        'tblMovieSetGeneral
        '
        Me.tblMovieSetGeneral.AutoScroll = True
        Me.tblMovieSetGeneral.AutoSize = True
        Me.tblMovieSetGeneral.ColumnCount = 3
        Me.tblMovieSetGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneral.Controls.Add(Me.gbMovieSetGeneralCustomScrapeButton, 1, 0)
        Me.tblMovieSetGeneral.Controls.Add(Me.gbMovieSetGeneralMediaListOpts, 0, 1)
        Me.tblMovieSetGeneral.Controls.Add(Me.gbMovieSetGeneralMiscOpts, 0, 0)
        Me.tblMovieSetGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetGeneral.Location = New System.Drawing.Point(0, 0)
        Me.tblMovieSetGeneral.Name = "tblMovieSetGeneral"
        Me.tblMovieSetGeneral.RowCount = 3
        Me.tblMovieSetGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneral.Size = New System.Drawing.Size(733, 570)
        Me.tblMovieSetGeneral.TabIndex = 6
        '
        'gbMovieSetGeneralCustomScrapeButton
        '
        Me.gbMovieSetGeneralCustomScrapeButton.AutoSize = True
        Me.gbMovieSetGeneralCustomScrapeButton.Controls.Add(Me.tblMovieSetGeneralCustomScrapeButton)
        Me.gbMovieSetGeneralCustomScrapeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetGeneralCustomScrapeButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieSetGeneralCustomScrapeButton.Location = New System.Drawing.Point(233, 3)
        Me.gbMovieSetGeneralCustomScrapeButton.Name = "gbMovieSetGeneralCustomScrapeButton"
        Me.gbMovieSetGeneralCustomScrapeButton.Size = New System.Drawing.Size(497, 98)
        Me.gbMovieSetGeneralCustomScrapeButton.TabIndex = 12
        Me.gbMovieSetGeneralCustomScrapeButton.TabStop = False
        Me.gbMovieSetGeneralCustomScrapeButton.Text = "Scrape Button"
        '
        'tblMovieSetGeneralCustomScrapeButton
        '
        Me.tblMovieSetGeneralCustomScrapeButton.AutoSize = True
        Me.tblMovieSetGeneralCustomScrapeButton.ColumnCount = 2
        Me.tblMovieSetGeneralCustomScrapeButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralCustomScrapeButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblMovieSetGeneralCustomScrapeButton.Controls.Add(Me.cbMovieSetGeneralCustomScrapeButtonScrapeType, 1, 1)
        Me.tblMovieSetGeneralCustomScrapeButton.Controls.Add(Me.cbMovieSetGeneralCustomScrapeButtonModifierType, 1, 2)
        Me.tblMovieSetGeneralCustomScrapeButton.Controls.Add(Me.txtMovieSetGeneralCustomScrapeButtonScrapeType, 0, 1)
        Me.tblMovieSetGeneralCustomScrapeButton.Controls.Add(Me.txtMovieSetGeneralCustomScrapeButtonModifierType, 0, 2)
        Me.tblMovieSetGeneralCustomScrapeButton.Controls.Add(Me.rbMovieSetGeneralCustomScrapeButtonEnabled, 1, 0)
        Me.tblMovieSetGeneralCustomScrapeButton.Controls.Add(Me.rbMovieSetGeneralCustomScrapeButtonDisabled, 0, 0)
        Me.tblMovieSetGeneralCustomScrapeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetGeneralCustomScrapeButton.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetGeneralCustomScrapeButton.Name = "tblMovieSetGeneralCustomScrapeButton"
        Me.tblMovieSetGeneralCustomScrapeButton.RowCount = 4
        Me.tblMovieSetGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralCustomScrapeButton.Size = New System.Drawing.Size(491, 77)
        Me.tblMovieSetGeneralCustomScrapeButton.TabIndex = 0
        '
        'cbMovieSetGeneralCustomScrapeButtonScrapeType
        '
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.Enabled = False
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.FormattingEnabled = True
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.Location = New System.Drawing.Point(159, 26)
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.Name = "cbMovieSetGeneralCustomScrapeButtonScrapeType"
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.Size = New System.Drawing.Size(329, 21)
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType.TabIndex = 1
        '
        'cbMovieSetGeneralCustomScrapeButtonModifierType
        '
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.Enabled = False
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.FormattingEnabled = True
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.Location = New System.Drawing.Point(159, 53)
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.Name = "cbMovieSetGeneralCustomScrapeButtonModifierType"
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.Size = New System.Drawing.Size(329, 21)
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType.TabIndex = 2
        '
        'txtMovieSetGeneralCustomScrapeButtonScrapeType
        '
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.AutoSize = True
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.Enabled = False
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.Location = New System.Drawing.Point(3, 30)
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.Name = "txtMovieSetGeneralCustomScrapeButtonScrapeType"
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.Size = New System.Drawing.Size(66, 13)
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.TabIndex = 3
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType.Text = "Scrape Type"
        '
        'txtMovieSetGeneralCustomScrapeButtonModifierType
        '
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.AutoSize = True
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.Enabled = False
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.Location = New System.Drawing.Point(3, 57)
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.Name = "txtMovieSetGeneralCustomScrapeButtonModifierType"
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.Size = New System.Drawing.Size(76, 13)
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.TabIndex = 4
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType.Text = "Modifier Type"
        '
        'rbMovieSetGeneralCustomScrapeButtonEnabled
        '
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.AutoSize = True
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.Location = New System.Drawing.Point(159, 3)
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.Name = "rbMovieSetGeneralCustomScrapeButtonEnabled"
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.Size = New System.Drawing.Size(150, 17)
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.TabIndex = 5
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.TabStop = True
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.Text = "Custom Scrape Function"
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled.UseVisualStyleBackColor = True
        '
        'rbMovieSetGeneralCustomScrapeButtonDisabled
        '
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.AutoSize = True
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.Location = New System.Drawing.Point(3, 3)
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.Name = "rbMovieSetGeneralCustomScrapeButtonDisabled"
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.Size = New System.Drawing.Size(150, 17)
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.TabIndex = 6
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.TabStop = True
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.Text = "Open Drop Down Menu"
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled.UseVisualStyleBackColor = True
        '
        'gbMovieSetGeneralMediaListOpts
        '
        Me.gbMovieSetGeneralMediaListOpts.AutoSize = True
        Me.gbMovieSetGeneralMediaListOpts.Controls.Add(Me.tblMovieSetGeneralMediaListOpts)
        Me.gbMovieSetGeneralMediaListOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetGeneralMediaListOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieSetGeneralMediaListOpts.Location = New System.Drawing.Point(3, 107)
        Me.gbMovieSetGeneralMediaListOpts.Name = "gbMovieSetGeneralMediaListOpts"
        Me.gbMovieSetGeneralMediaListOpts.Size = New System.Drawing.Size(224, 438)
        Me.gbMovieSetGeneralMediaListOpts.TabIndex = 4
        Me.gbMovieSetGeneralMediaListOpts.TabStop = False
        Me.gbMovieSetGeneralMediaListOpts.Text = "Media List Options"
        '
        'tblMovieSetGeneralMediaListOpts
        '
        Me.tblMovieSetGeneralMediaListOpts.AutoSize = True
        Me.tblMovieSetGeneralMediaListOpts.ColumnCount = 2
        Me.tblMovieSetGeneralMediaListOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMediaListOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMediaListOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.Controls.Add(Me.gbMovieSetGeneralMediaListSorting, 0, 1)
        Me.tblMovieSetGeneralMediaListOpts.Controls.Add(Me.gbMovieSetGeneralMediaListSortTokensOpts, 0, 0)
        Me.tblMovieSetGeneralMediaListOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetGeneralMediaListOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetGeneralMediaListOpts.Name = "tblMovieSetGeneralMediaListOpts"
        Me.tblMovieSetGeneralMediaListOpts.RowCount = 3
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetGeneralMediaListOpts.Size = New System.Drawing.Size(218, 417)
        Me.tblMovieSetGeneralMediaListOpts.TabIndex = 7
        '
        'gbMovieSetGeneralMediaListSorting
        '
        Me.gbMovieSetGeneralMediaListSorting.AutoSize = True
        Me.tblMovieSetGeneralMediaListOpts.SetColumnSpan(Me.gbMovieSetGeneralMediaListSorting, 2)
        Me.gbMovieSetGeneralMediaListSorting.Controls.Add(Me.tblMovieSetGeneralMediaListSorting)
        Me.gbMovieSetGeneralMediaListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetGeneralMediaListSorting.Location = New System.Drawing.Point(3, 108)
        Me.gbMovieSetGeneralMediaListSorting.Name = "gbMovieSetGeneralMediaListSorting"
        Me.gbMovieSetGeneralMediaListSorting.Size = New System.Drawing.Size(212, 306)
        Me.gbMovieSetGeneralMediaListSorting.TabIndex = 84
        Me.gbMovieSetGeneralMediaListSorting.TabStop = False
        Me.gbMovieSetGeneralMediaListSorting.Text = "Media List Sorting"
        '
        'tblMovieSetGeneralMediaListSorting
        '
        Me.tblMovieSetGeneralMediaListSorting.AutoSize = True
        Me.tblMovieSetGeneralMediaListSorting.ColumnCount = 6
        Me.tblMovieSetGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMediaListSorting.Controls.Add(Me.btnMovieSetGeneralMediaListSortingDown, 2, 1)
        Me.tblMovieSetGeneralMediaListSorting.Controls.Add(Me.btnMovieSetGeneralMediaListSortingUp, 1, 1)
        Me.tblMovieSetGeneralMediaListSorting.Controls.Add(Me.lvMovieSetGeneralMediaListSorting, 0, 0)
        Me.tblMovieSetGeneralMediaListSorting.Controls.Add(Me.btnMovieSetGeneralMediaListSortingReset, 4, 1)
        Me.tblMovieSetGeneralMediaListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetGeneralMediaListSorting.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetGeneralMediaListSorting.Name = "tblMovieSetGeneralMediaListSorting"
        Me.tblMovieSetGeneralMediaListSorting.RowCount = 3
        Me.tblMovieSetGeneralMediaListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMediaListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMediaListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMediaListSorting.Size = New System.Drawing.Size(206, 285)
        Me.tblMovieSetGeneralMediaListSorting.TabIndex = 0
        '
        'btnMovieSetGeneralMediaListSortingDown
        '
        Me.btnMovieSetGeneralMediaListSortingDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMovieSetGeneralMediaListSortingDown.Image = CType(resources.GetObject("btnMovieSetGeneralMediaListSortingDown.Image"), System.Drawing.Image)
        Me.btnMovieSetGeneralMediaListSortingDown.Location = New System.Drawing.Point(91, 259)
        Me.btnMovieSetGeneralMediaListSortingDown.Name = "btnMovieSetGeneralMediaListSortingDown"
        Me.btnMovieSetGeneralMediaListSortingDown.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSetGeneralMediaListSortingDown.TabIndex = 12
        Me.btnMovieSetGeneralMediaListSortingDown.UseVisualStyleBackColor = True
        '
        'btnMovieSetGeneralMediaListSortingUp
        '
        Me.btnMovieSetGeneralMediaListSortingUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMovieSetGeneralMediaListSortingUp.Image = CType(resources.GetObject("btnMovieSetGeneralMediaListSortingUp.Image"), System.Drawing.Image)
        Me.btnMovieSetGeneralMediaListSortingUp.Location = New System.Drawing.Point(62, 259)
        Me.btnMovieSetGeneralMediaListSortingUp.Name = "btnMovieSetGeneralMediaListSortingUp"
        Me.btnMovieSetGeneralMediaListSortingUp.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSetGeneralMediaListSortingUp.TabIndex = 13
        Me.btnMovieSetGeneralMediaListSortingUp.UseVisualStyleBackColor = True
        '
        'lvMovieSetGeneralMediaListSorting
        '
        Me.lvMovieSetGeneralMediaListSorting.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMovieSetGeneralMediaListSortingDisplayIndex, Me.colMovieSetGeneralMediaListSortingColumn, Me.colMovieSetGeneralMediaListSortingLabel, Me.colMovieSetGeneralMediaListSortingHide})
        Me.tblMovieSetGeneralMediaListSorting.SetColumnSpan(Me.lvMovieSetGeneralMediaListSorting, 5)
        Me.lvMovieSetGeneralMediaListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvMovieSetGeneralMediaListSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvMovieSetGeneralMediaListSorting.FullRowSelect = True
        Me.lvMovieSetGeneralMediaListSorting.HideSelection = False
        Me.lvMovieSetGeneralMediaListSorting.Location = New System.Drawing.Point(3, 3)
        Me.lvMovieSetGeneralMediaListSorting.Name = "lvMovieSetGeneralMediaListSorting"
        Me.lvMovieSetGeneralMediaListSorting.Size = New System.Drawing.Size(200, 250)
        Me.lvMovieSetGeneralMediaListSorting.TabIndex = 10
        Me.lvMovieSetGeneralMediaListSorting.UseCompatibleStateImageBehavior = False
        Me.lvMovieSetGeneralMediaListSorting.View = System.Windows.Forms.View.Details
        '
        'colMovieSetGeneralMediaListSortingDisplayIndex
        '
        Me.colMovieSetGeneralMediaListSortingDisplayIndex.Text = "DisplayIndex"
        Me.colMovieSetGeneralMediaListSortingDisplayIndex.Width = 0
        '
        'colMovieSetGeneralMediaListSortingColumn
        '
        Me.colMovieSetGeneralMediaListSortingColumn.Text = "DBName"
        Me.colMovieSetGeneralMediaListSortingColumn.Width = 0
        '
        'colMovieSetGeneralMediaListSortingLabel
        '
        Me.colMovieSetGeneralMediaListSortingLabel.Text = "Column"
        Me.colMovieSetGeneralMediaListSortingLabel.Width = 110
        '
        'colMovieSetGeneralMediaListSortingHide
        '
        Me.colMovieSetGeneralMediaListSortingHide.Text = "Hide"
        '
        'btnMovieSetGeneralMediaListSortingReset
        '
        Me.btnMovieSetGeneralMediaListSortingReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieSetGeneralMediaListSortingReset.Image = CType(resources.GetObject("btnMovieSetGeneralMediaListSortingReset.Image"), System.Drawing.Image)
        Me.btnMovieSetGeneralMediaListSortingReset.Location = New System.Drawing.Point(180, 259)
        Me.btnMovieSetGeneralMediaListSortingReset.Name = "btnMovieSetGeneralMediaListSortingReset"
        Me.btnMovieSetGeneralMediaListSortingReset.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSetGeneralMediaListSortingReset.TabIndex = 11
        Me.btnMovieSetGeneralMediaListSortingReset.UseVisualStyleBackColor = True
        '
        'gbMovieSetGeneralMediaListSortTokensOpts
        '
        Me.gbMovieSetGeneralMediaListSortTokensOpts.AutoSize = True
        Me.tblMovieSetGeneralMediaListOpts.SetColumnSpan(Me.gbMovieSetGeneralMediaListSortTokensOpts, 2)
        Me.gbMovieSetGeneralMediaListSortTokensOpts.Controls.Add(Me.tblMovieSetGeneralSortTokensOpts)
        Me.gbMovieSetGeneralMediaListSortTokensOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetGeneralMediaListSortTokensOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieSetGeneralMediaListSortTokensOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetGeneralMediaListSortTokensOpts.Name = "gbMovieSetGeneralMediaListSortTokensOpts"
        Me.gbMovieSetGeneralMediaListSortTokensOpts.Size = New System.Drawing.Size(212, 99)
        Me.gbMovieSetGeneralMediaListSortTokensOpts.TabIndex = 83
        Me.gbMovieSetGeneralMediaListSortTokensOpts.TabStop = False
        Me.gbMovieSetGeneralMediaListSortTokensOpts.Text = "Sort Tokens to Ignore"
        '
        'tblMovieSetGeneralSortTokensOpts
        '
        Me.tblMovieSetGeneralSortTokensOpts.AutoSize = True
        Me.tblMovieSetGeneralSortTokensOpts.ColumnCount = 5
        Me.tblMovieSetGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralSortTokensOpts.Controls.Add(Me.btnMovieSetSortTokenReset, 3, 1)
        Me.tblMovieSetGeneralSortTokensOpts.Controls.Add(Me.btnMovieSetSortTokenRemove, 2, 1)
        Me.tblMovieSetGeneralSortTokensOpts.Controls.Add(Me.lstMovieSetSortTokens, 0, 0)
        Me.tblMovieSetGeneralSortTokensOpts.Controls.Add(Me.btnMovieSetSortTokenAdd, 1, 1)
        Me.tblMovieSetGeneralSortTokensOpts.Controls.Add(Me.txtMovieSetSortToken, 0, 1)
        Me.tblMovieSetGeneralSortTokensOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetGeneralSortTokensOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetGeneralSortTokensOpts.Name = "tblMovieSetGeneralSortTokensOpts"
        Me.tblMovieSetGeneralSortTokensOpts.RowCount = 3
        Me.tblMovieSetGeneralSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralSortTokensOpts.Size = New System.Drawing.Size(206, 78)
        Me.tblMovieSetGeneralSortTokensOpts.TabIndex = 8
        '
        'btnMovieSetSortTokenReset
        '
        Me.btnMovieSetSortTokenReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieSetSortTokenReset.Image = CType(resources.GetObject("btnMovieSetSortTokenReset.Image"), System.Drawing.Image)
        Me.btnMovieSetSortTokenReset.Location = New System.Drawing.Point(180, 52)
        Me.btnMovieSetSortTokenReset.Name = "btnMovieSetSortTokenReset"
        Me.btnMovieSetSortTokenReset.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSetSortTokenReset.TabIndex = 10
        Me.btnMovieSetSortTokenReset.UseVisualStyleBackColor = True
        '
        'btnMovieSetSortTokenRemove
        '
        Me.btnMovieSetSortTokenRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieSetSortTokenRemove.Image = CType(resources.GetObject("btnMovieSetSortTokenRemove.Image"), System.Drawing.Image)
        Me.btnMovieSetSortTokenRemove.Location = New System.Drawing.Point(99, 52)
        Me.btnMovieSetSortTokenRemove.Name = "btnMovieSetSortTokenRemove"
        Me.btnMovieSetSortTokenRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSetSortTokenRemove.TabIndex = 3
        Me.btnMovieSetSortTokenRemove.UseVisualStyleBackColor = True
        '
        'lstMovieSetSortTokens
        '
        Me.tblMovieSetGeneralSortTokensOpts.SetColumnSpan(Me.lstMovieSetSortTokens, 4)
        Me.lstMovieSetSortTokens.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstMovieSetSortTokens.FormattingEnabled = True
        Me.lstMovieSetSortTokens.Location = New System.Drawing.Point(3, 3)
        Me.lstMovieSetSortTokens.Name = "lstMovieSetSortTokens"
        Me.lstMovieSetSortTokens.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstMovieSetSortTokens.Size = New System.Drawing.Size(200, 43)
        Me.lstMovieSetSortTokens.Sorted = True
        Me.lstMovieSetSortTokens.TabIndex = 0
        '
        'btnMovieSetSortTokenAdd
        '
        Me.btnMovieSetSortTokenAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieSetSortTokenAdd.Image = CType(resources.GetObject("btnMovieSetSortTokenAdd.Image"), System.Drawing.Image)
        Me.btnMovieSetSortTokenAdd.Location = New System.Drawing.Point(70, 52)
        Me.btnMovieSetSortTokenAdd.Name = "btnMovieSetSortTokenAdd"
        Me.btnMovieSetSortTokenAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSetSortTokenAdd.TabIndex = 2
        Me.btnMovieSetSortTokenAdd.UseVisualStyleBackColor = True
        '
        'txtMovieSetSortToken
        '
        Me.txtMovieSetSortToken.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetSortToken.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieSetSortToken.Location = New System.Drawing.Point(3, 52)
        Me.txtMovieSetSortToken.Name = "txtMovieSetSortToken"
        Me.txtMovieSetSortToken.Size = New System.Drawing.Size(61, 22)
        Me.txtMovieSetSortToken.TabIndex = 1
        '
        'gbMovieSetGeneralMiscOpts
        '
        Me.gbMovieSetGeneralMiscOpts.AutoSize = True
        Me.gbMovieSetGeneralMiscOpts.Controls.Add(Me.tblMovieSetGeneralMiscOpts)
        Me.gbMovieSetGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetGeneralMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieSetGeneralMiscOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetGeneralMiscOpts.Name = "gbMovieSetGeneralMiscOpts"
        Me.gbMovieSetGeneralMiscOpts.Size = New System.Drawing.Size(224, 98)
        Me.gbMovieSetGeneralMiscOpts.TabIndex = 1
        Me.gbMovieSetGeneralMiscOpts.TabStop = False
        Me.gbMovieSetGeneralMiscOpts.Text = "Miscellaneous"
        '
        'tblMovieSetGeneralMiscOpts
        '
        Me.tblMovieSetGeneralMiscOpts.AutoSize = True
        Me.tblMovieSetGeneralMiscOpts.ColumnCount = 2
        Me.tblMovieSetGeneralMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetGeneralMiscOpts.Controls.Add(Me.chkMovieSetClickScrapeAsk, 0, 2)
        Me.tblMovieSetGeneralMiscOpts.Controls.Add(Me.chkMovieSetClickScrape, 0, 1)
        Me.tblMovieSetGeneralMiscOpts.Controls.Add(Me.chkMovieSetGeneralMarkNew, 0, 0)
        Me.tblMovieSetGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetGeneralMiscOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetGeneralMiscOpts.Name = "tblMovieSetGeneralMiscOpts"
        Me.tblMovieSetGeneralMiscOpts.RowCount = 4
        Me.tblMovieSetGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetGeneralMiscOpts.Size = New System.Drawing.Size(218, 77)
        Me.tblMovieSetGeneralMiscOpts.TabIndex = 7
        '
        'chkMovieSetClickScrapeAsk
        '
        Me.chkMovieSetClickScrapeAsk.AutoSize = True
        Me.chkMovieSetClickScrapeAsk.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkMovieSetClickScrapeAsk.Location = New System.Drawing.Point(3, 49)
        Me.chkMovieSetClickScrapeAsk.Name = "chkMovieSetClickScrapeAsk"
        Me.chkMovieSetClickScrapeAsk.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkMovieSetClickScrapeAsk.Size = New System.Drawing.Size(147, 17)
        Me.chkMovieSetClickScrapeAsk.TabIndex = 64
        Me.chkMovieSetClickScrapeAsk.Text = "Ask On Click Scrape"
        Me.chkMovieSetClickScrapeAsk.UseVisualStyleBackColor = True
        '
        'chkMovieSetClickScrape
        '
        Me.chkMovieSetClickScrape.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSetClickScrape.AutoSize = True
        Me.chkMovieSetClickScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkMovieSetClickScrape.Location = New System.Drawing.Point(3, 26)
        Me.chkMovieSetClickScrape.Name = "chkMovieSetClickScrape"
        Me.chkMovieSetClickScrape.Size = New System.Drawing.Size(125, 17)
        Me.chkMovieSetClickScrape.TabIndex = 65
        Me.chkMovieSetClickScrape.Text = "Enable Click Scrape"
        Me.chkMovieSetClickScrape.UseVisualStyleBackColor = True
        '
        'chkMovieSetGeneralMarkNew
        '
        Me.chkMovieSetGeneralMarkNew.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSetGeneralMarkNew.AutoSize = True
        Me.chkMovieSetGeneralMarkNew.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetGeneralMarkNew.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieSetGeneralMarkNew.Name = "chkMovieSetGeneralMarkNew"
        Me.chkMovieSetGeneralMarkNew.Size = New System.Drawing.Size(133, 17)
        Me.chkMovieSetGeneralMarkNew.TabIndex = 66
        Me.chkMovieSetGeneralMarkNew.Text = "Mark New MovieSets"
        Me.chkMovieSetGeneralMarkNew.UseVisualStyleBackColor = True
        '
        'scSettings
        '
        Me.scSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSettings.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scSettings.IsSplitterFixed = True
        Me.scSettings.Location = New System.Drawing.Point(0, 0)
        Me.scSettings.Name = "scSettings"
        Me.scSettings.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scSettings.Panel1
        '
        Me.scSettings.Panel1.Controls.Add(Me.tblSettingsCurrent)
        Me.scSettings.Panel1.Controls.Add(Me.tsSettingsTopMenu)
        '
        'scSettings.Panel2
        '
        Me.scSettings.Panel2.Controls.Add(Me.scSettingsBody)
        Me.scSettings.Size = New System.Drawing.Size(1654, 1173)
        Me.scSettings.SplitterDistance = 85
        Me.scSettings.TabIndex = 28
        '
        'tblSettingsCurrent
        '
        Me.tblSettingsCurrent.ColumnCount = 1
        Me.tblSettingsCurrent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblSettingsCurrent.Controls.Add(Me.pnlSettingsCurrent, 0, 0)
        Me.tblSettingsCurrent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblSettingsCurrent.Location = New System.Drawing.Point(0, 25)
        Me.tblSettingsCurrent.Name = "tblSettingsCurrent"
        Me.tblSettingsCurrent.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.tblSettingsCurrent.RowCount = 1
        Me.tblSettingsCurrent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblSettingsCurrent.Size = New System.Drawing.Size(1654, 33)
        Me.tblSettingsCurrent.TabIndex = 6
        '
        'scSettingsBody
        '
        Me.scSettingsBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSettingsBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.scSettingsBody.IsSplitterFixed = True
        Me.scSettingsBody.Location = New System.Drawing.Point(0, 0)
        Me.scSettingsBody.Name = "scSettingsBody"
        Me.scSettingsBody.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scSettingsBody.Panel1
        '
        Me.scSettingsBody.Panel1.Controls.Add(Me.scSettingsMain)
        '
        'scSettingsBody.Panel2
        '
        Me.scSettingsBody.Panel2.Controls.Add(Me.tblSettingsFooter)
        Me.scSettingsBody.Panel2.Padding = New System.Windows.Forms.Padding(2, 0, 5, 0)
        Me.scSettingsBody.Size = New System.Drawing.Size(1654, 1084)
        Me.scSettingsBody.SplitterDistance = 1006
        Me.scSettingsBody.TabIndex = 99
        '
        'scSettingsMain
        '
        Me.scSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSettingsMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.scSettingsMain.Name = "scSettingsMain"
        '
        'scSettingsMain.Panel1
        '
        Me.scSettingsMain.Panel1.Controls.Add(Me.tvSettingsList)
        Me.scSettingsMain.Panel1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        '
        'scSettingsMain.Panel2
        '
        Me.scSettingsMain.Panel2.Controls.Add(Me.pnlSettingsMain)
        Me.scSettingsMain.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.scSettingsMain.Size = New System.Drawing.Size(1654, 1006)
        Me.scSettingsMain.SplitterDistance = 247
        Me.scSettingsMain.TabIndex = 0
        '
        'tblSettingsFooter
        '
        Me.tblSettingsFooter.ColumnCount = 5
        Me.tblSettingsFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tblSettingsFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblSettingsFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tblSettingsFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tblSettingsFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.tblSettingsFooter.Controls.Add(Me.btnApply, 2, 0)
        Me.tblSettingsFooter.Controls.Add(Me.btnCancel, 3, 0)
        Me.tblSettingsFooter.Controls.Add(Me.pnlSettingsHelp, 0, 0)
        Me.tblSettingsFooter.Controls.Add(Me.btnOK, 4, 0)
        Me.tblSettingsFooter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsFooter.Location = New System.Drawing.Point(2, 0)
        Me.tblSettingsFooter.Name = "tblSettingsFooter"
        Me.tblSettingsFooter.RowCount = 1
        Me.tblSettingsFooter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblSettingsFooter.Size = New System.Drawing.Size(1647, 74)
        Me.tblSettingsFooter.TabIndex = 0
        '
        'TableLayoutPanel14
        '
        Me.TableLayoutPanel14.AutoScroll = True
        Me.TableLayoutPanel14.AutoSize = True
        Me.TableLayoutPanel14.ColumnCount = 2
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel14.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        Me.TableLayoutPanel14.RowCount = 3
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.Size = New System.Drawing.Size(157, 46)
        Me.TableLayoutPanel14.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 194)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trailers"
        '
        'GroupBox4
        '
        Me.GroupBox4.AutoSize = True
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.MinimumSize = New System.Drawing.Size(150, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(150, 5)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ArtworkDownloader"
        '
        'GroupBox8
        '
        Me.GroupBox8.AutoSize = True
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(106, 105)
        Me.GroupBox8.TabIndex = 4
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Defaults"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.AutoSize = True
        Me.TableLayoutPanel8.ColumnCount = 4
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 8
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(464, 146)
        Me.TableLayoutPanel8.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "NFO"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Poster"
        '
        'ComboBox6
        '
        Me.ComboBox6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(3, 23)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(148, 21)
        Me.ComboBox6.TabIndex = 1
        '
        'CheckBox16
        '
        Me.CheckBox16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox16.AutoSize = True
        Me.CheckBox16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox16.Location = New System.Drawing.Point(328, 204)
        Me.CheckBox16.Name = "CheckBox16"
        Me.CheckBox16.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox16.TabIndex = 16
        Me.CheckBox16.Text = "Keep existing"
        Me.CheckBox16.UseVisualStyleBackColor = True
        '
        'CheckBox17
        '
        Me.CheckBox17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox17.AutoSize = True
        Me.CheckBox17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox17.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox17.Name = "CheckBox17"
        Me.CheckBox17.Size = New System.Drawing.Size(174, 17)
        Me.CheckBox17.TabIndex = 1
        Me.CheckBox17.Text = "Protect DVD/Bluray Structure"
        Me.CheckBox17.UseVisualStyleBackColor = True
        '
        'CheckBox18
        '
        Me.CheckBox18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox18.AutoSize = True
        Me.CheckBox18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox18.Location = New System.Drawing.Point(70, 43)
        Me.CheckBox18.Name = "CheckBox18"
        Me.CheckBox18.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox18.TabIndex = 10
        Me.CheckBox18.Text = "Only"
        Me.CheckBox18.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.TextBox3.Location = New System.Drawing.Point(3, 3)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(218, 22)
        Me.TextBox3.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Trailer"
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(3, 3)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(46, 22)
        Me.TextBox4.TabIndex = 2
        '
        'GroupBox10
        '
        Me.GroupBox10.AutoSize = True
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(163, 21)
        Me.GroupBox10.TabIndex = 12
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Optional Settings"
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.AutoSize = True
        Me.TableLayoutPanel10.ColumnCount = 3
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 4
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(512, 349)
        Me.TableLayoutPanel10.TabIndex = 19
        '
        'GroupBox9
        '
        Me.GroupBox9.AutoSize = True
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(6, 21)
        Me.GroupBox9.TabIndex = 13
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Optional Images"
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.AutoSize = True
        Me.TableLayoutPanel9.ColumnCount = 3
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 3
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(255, 51)
        Me.TableLayoutPanel9.TabIndex = 20
        '
        'CheckBox19
        '
        Me.CheckBox19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox19.AutoSize = True
        Me.CheckBox19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox19.Location = New System.Drawing.Point(70, 66)
        Me.CheckBox19.Name = "CheckBox19"
        Me.CheckBox19.Size = New System.Drawing.Size(227, 17)
        Me.CheckBox19.TabIndex = 11
        Me.CheckBox19.Text = "Create thumbs instead of using fanarts"
        Me.CheckBox19.UseVisualStyleBackColor = True
        '
        'CheckBox20
        '
        Me.CheckBox20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox20.AutoSize = True
        Me.CheckBox20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox20.Location = New System.Drawing.Point(123, 89)
        Me.CheckBox20.Name = "CheckBox20"
        Me.CheckBox20.Size = New System.Drawing.Size(121, 17)
        Me.CheckBox20.TabIndex = 11
        Me.CheckBox20.Text = "Remove Black Bars"
        Me.CheckBox20.UseVisualStyleBackColor = True
        '
        'CheckBox21
        '
        Me.CheckBox21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox21.AutoSize = True
        Me.CheckBox21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox21.Location = New System.Drawing.Point(72, 112)
        Me.CheckBox21.Name = "CheckBox21"
        Me.CheckBox21.Size = New System.Drawing.Size(222, 17)
        Me.CheckBox21.TabIndex = 11
        Me.CheckBox21.Text = "Only create thumbs if no fanart found"
        Me.CheckBox21.UseVisualStyleBackColor = True
        '
        'CheckBox22
        '
        Me.CheckBox22.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox22.AutoSize = True
        Me.CheckBox22.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox22.Location = New System.Drawing.Point(141, 135)
        Me.CheckBox22.Name = "CheckBox22"
        Me.CheckBox22.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox22.TabIndex = 11
        Me.CheckBox22.Text = "No Spoilers"
        Me.CheckBox22.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "ClearArt"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Enabled"
        '
        'ComboBox7
        '
        Me.ComboBox7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(3, 23)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(148, 21)
        Me.ComboBox7.TabIndex = 1
        '
        'CheckBox23
        '
        Me.CheckBox23.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox23.AutoSize = True
        Me.CheckBox23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox23.Location = New System.Drawing.Point(117, 66)
        Me.CheckBox23.Name = "CheckBox23"
        Me.CheckBox23.Size = New System.Drawing.Size(133, 17)
        Me.CheckBox23.TabIndex = 11
        Me.CheckBox23.Text = "Automatically Resize:"
        Me.CheckBox23.UseVisualStyleBackColor = True
        '
        'CheckBox24
        '
        Me.CheckBox24.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox24.AutoSize = True
        Me.CheckBox24.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox24.Location = New System.Drawing.Point(53, 3)
        Me.CheckBox24.Name = "CheckBox24"
        Me.CheckBox24.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox24.TabIndex = 8
        Me.CheckBox24.Text = "Only"
        Me.CheckBox24.UseVisualStyleBackColor = True
        '
        'CheckBox25
        '
        Me.CheckBox25.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox25.AutoSize = True
        Me.CheckBox25.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox25.Location = New System.Drawing.Point(57, 26)
        Me.CheckBox25.Name = "CheckBox25"
        Me.CheckBox25.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox25.TabIndex = 6
        Me.CheckBox25.Text = "Keep existing"
        Me.CheckBox25.UseVisualStyleBackColor = True
        '
        'CheckBox26
        '
        Me.CheckBox26.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox26.AutoSize = True
        Me.CheckBox26.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox26.Location = New System.Drawing.Point(68, 49)
        Me.CheckBox26.Name = "CheckBox26"
        Me.CheckBox26.Size = New System.Drawing.Size(195, 17)
        Me.CheckBox26.TabIndex = 5
        Me.CheckBox26.Text = "Preselect in ""Image Select"" dialog"
        Me.CheckBox26.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(53, 3)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(210, 22)
        Me.TextBox5.TabIndex = 7
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(53, 31)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(210, 22)
        Me.TextBox6.TabIndex = 6
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(53, 31)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(210, 22)
        Me.TextBox7.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "ClearLogo"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "DiscArt"
        '
        'GroupBox11
        '
        Me.GroupBox11.AutoSize = True
        Me.GroupBox11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(6, 21)
        Me.GroupBox11.TabIndex = 11
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Optional Images"
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.AutoSize = True
        Me.TableLayoutPanel11.ColumnCount = 3
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 6
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(100, 100)
        Me.TableLayoutPanel11.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Landscape"
        '
        'ComboBox8
        '
        Me.ComboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox8.FormattingEnabled = True
        Me.ComboBox8.Location = New System.Drawing.Point(3, 23)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(148, 21)
        Me.ComboBox8.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(70, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Kodi Interface"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CheckBox27
        '
        Me.CheckBox27.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox27.AutoSize = True
        Me.CheckBox27.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox27.Location = New System.Drawing.Point(99, 72)
        Me.CheckBox27.Name = "CheckBox27"
        Me.CheckBox27.Size = New System.Drawing.Size(133, 17)
        Me.CheckBox27.TabIndex = 7
        Me.CheckBox27.Text = "Automatically Resize:"
        Me.CheckBox27.UseVisualStyleBackColor = True
        '
        'CheckBox28
        '
        Me.CheckBox28.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox28.AutoSize = True
        Me.CheckBox28.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox28.Location = New System.Drawing.Point(118, 95)
        Me.CheckBox28.Name = "CheckBox28"
        Me.CheckBox28.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox28.TabIndex = 9
        Me.CheckBox28.Text = "Keep existing"
        Me.CheckBox28.UseVisualStyleBackColor = True
        '
        'CheckBox29
        '
        Me.CheckBox29.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox29.AutoSize = True
        Me.CheckBox29.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox29.Location = New System.Drawing.Point(142, 3)
        Me.CheckBox29.Name = "CheckBox29"
        Me.CheckBox29.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox29.TabIndex = 8
        Me.CheckBox29.Text = "Only"
        Me.CheckBox29.UseVisualStyleBackColor = True
        '
        'CheckBox30
        '
        Me.CheckBox30.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox30.AutoSize = True
        Me.CheckBox30.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox30.Location = New System.Drawing.Point(3, 38)
        Me.CheckBox30.Name = "CheckBox30"
        Me.CheckBox30.Size = New System.Drawing.Size(181, 17)
        Me.CheckBox30.TabIndex = 4
        Me.CheckBox30.Text = "Store themes in sub directorys"
        Me.CheckBox30.UseVisualStyleBackColor = True
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(57, 44)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(210, 22)
        Me.TextBox8.TabIndex = 5
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(57, 72)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(210, 22)
        Me.TextBox9.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Banner"
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Banner"
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(57, 31)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(210, 22)
        Me.TextBox10.TabIndex = 9
        '
        'GroupBox13
        '
        Me.GroupBox13.AutoSize = True
        Me.GroupBox13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(6, 21)
        Me.GroupBox13.TabIndex = 11
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Optional Images"
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.AutoSize = True
        Me.TableLayoutPanel13.ColumnCount = 3
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 4
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(154, 74)
        Me.TableLayoutPanel13.TabIndex = 9
        '
        'CheckBox34
        '
        Me.CheckBox34.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox34.AutoSize = True
        Me.CheckBox34.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox34.Location = New System.Drawing.Point(53, 36)
        Me.CheckBox34.Name = "CheckBox34"
        Me.CheckBox34.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.CheckBox34.Size = New System.Drawing.Size(160, 17)
        Me.CheckBox34.TabIndex = 14
        Me.CheckBox34.Text = "Also Get Blank Images"
        Me.CheckBox34.UseVisualStyleBackColor = True
        '
        'CheckBox35
        '
        Me.CheckBox35.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox35.AutoSize = True
        Me.CheckBox35.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox35.Location = New System.Drawing.Point(53, 36)
        Me.CheckBox35.Name = "CheckBox35"
        Me.CheckBox35.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.CheckBox35.Size = New System.Drawing.Size(169, 17)
        Me.CheckBox35.TabIndex = 14
        Me.CheckBox35.Text = "Also Get English Images"
        Me.CheckBox35.UseVisualStyleBackColor = True
        '
        'CheckBox36
        '
        Me.CheckBox36.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox36.AutoSize = True
        Me.CheckBox36.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox36.Location = New System.Drawing.Point(53, 23)
        Me.CheckBox36.Name = "CheckBox36"
        Me.CheckBox36.Size = New System.Drawing.Size(237, 17)
        Me.CheckBox36.TabIndex = 15
        Me.CheckBox36.Text = "Only Get Images for the Media Language"
        Me.CheckBox36.UseVisualStyleBackColor = True
        '
        'ComboBox10
        '
        Me.ComboBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox10.FormattingEnabled = True
        Me.ComboBox10.Location = New System.Drawing.Point(246, 3)
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(523, 21)
        Me.ComboBox10.TabIndex = 1
        '
        'CheckBox37
        '
        Me.CheckBox37.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox37.AutoSize = True
        Me.CheckBox37.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox37.Location = New System.Drawing.Point(327, 59)
        Me.CheckBox37.Name = "CheckBox37"
        Me.CheckBox37.Size = New System.Drawing.Size(108, 17)
        Me.CheckBox37.TabIndex = 12
        Me.CheckBox37.Text = "Force Language"
        Me.CheckBox37.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(885, 225)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(6, 5)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Optional Settings"
        '
        'GroupBox3
        '
        Me.GroupBox3.AutoSize = True
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(885, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1164, 200)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Extended Images"
        '
        'GroupBox5
        '
        Me.GroupBox5.AutoSize = True
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 146)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(367, 153)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "TvTunes"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 7
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(361, 132)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(358, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Eden"
        '
        'CheckBox10
        '
        Me.CheckBox10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox10.Location = New System.Drawing.Point(328, 135)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox10.TabIndex = 15
        Me.CheckBox10.Text = "Keep existing"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'ComboBox4
        '
        Me.ComboBox4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(3, 23)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(148, 21)
        Me.ComboBox4.TabIndex = 1
        '
        'CheckBox11
        '
        Me.CheckBox11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox11.Location = New System.Drawing.Point(131, 158)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox11.TabIndex = 0
        Me.CheckBox11.Text = "Only"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.AutoSize = True
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(6, 5)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Defaults"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.AutoSize = True
        Me.TableLayoutPanel6.ColumnCount = 4
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 7
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(361, 148)
        Me.TableLayoutPanel6.TabIndex = 9
        '
        'CheckBox12
        '
        Me.CheckBox12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox12.Location = New System.Drawing.Point(328, 158)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox12.TabIndex = 13
        Me.CheckBox12.Text = "Keep existing"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.AutoSize = True
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupBox7.Location = New System.Drawing.Point(479, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(261, 56)
        Me.GroupBox7.TabIndex = 18
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Optional Settings"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.AutoSize = True
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 3
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(512, 349)
        Me.TableLayoutPanel7.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Extrafanarts"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Extrathumbs"
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(3, 23)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(148, 21)
        Me.ComboBox5.TabIndex = 1
        '
        'CheckBox13
        '
        Me.CheckBox13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox13.AutoSize = True
        Me.CheckBox13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox13.Location = New System.Drawing.Point(109, 181)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox13.TabIndex = 1
        Me.CheckBox13.Text = "Keep Existing"
        Me.CheckBox13.UseVisualStyleBackColor = True
        '
        'CheckBox14
        '
        Me.CheckBox14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox14.AutoSize = True
        Me.CheckBox14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox14.Location = New System.Drawing.Point(308, 181)
        Me.CheckBox14.Name = "CheckBox14"
        Me.CheckBox14.Size = New System.Drawing.Size(133, 17)
        Me.CheckBox14.TabIndex = 14
        Me.CheckBox14.Text = "Automatically Resize:"
        Me.CheckBox14.UseVisualStyleBackColor = True
        '
        'CheckBox15
        '
        Me.CheckBox15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox15.AutoSize = True
        Me.CheckBox15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox15.Location = New System.Drawing.Point(131, 204)
        Me.CheckBox15.Name = "CheckBox15"
        Me.CheckBox15.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox15.TabIndex = 3
        Me.CheckBox15.Text = "Only"
        Me.CheckBox15.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(3, 133)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(195, 22)
        Me.TextBox1.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Fanart"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(3, 72)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(200, 22)
        Me.TextBox2.TabIndex = 2
        '
        'GroupBox12
        '
        Me.GroupBox12.AutoSize = True
        Me.GroupBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(286, 3)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(163, 67)
        Me.GroupBox12.TabIndex = 10
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Optional Settings"
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.AutoSize = True
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 2
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(512, 349)
        Me.TableLayoutPanel12.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "ClearArt"
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 46)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 13)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "ClearLogo"
        '
        'ComboBox9
        '
        Me.ComboBox9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(3, 23)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(148, 21)
        Me.ComboBox9.TabIndex = 1
        '
        'CheckBox31
        '
        Me.CheckBox31.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox31.AutoSize = True
        Me.CheckBox31.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox31.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox31.Name = "CheckBox31"
        Me.CheckBox31.Size = New System.Drawing.Size(187, 17)
        Me.CheckBox31.TabIndex = 6
        Me.CheckBox31.Text = "Store themes in movie directory"
        Me.CheckBox31.UseVisualStyleBackColor = True
        '
        'CheckBox32
        '
        Me.CheckBox32.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox32.AutoSize = True
        Me.CheckBox32.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox32.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox32.Name = "CheckBox32"
        Me.CheckBox32.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox32.TabIndex = 0
        Me.CheckBox32.Text = "Enabled"
        Me.CheckBox32.UseVisualStyleBackColor = True
        '
        'CheckBox33
        '
        Me.CheckBox33.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox33.AutoSize = True
        Me.CheckBox33.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox33.Location = New System.Drawing.Point(3, 49)
        Me.CheckBox33.Name = "CheckBox33"
        Me.CheckBox33.Size = New System.Drawing.Size(182, 17)
        Me.CheckBox33.TabIndex = 1
        Me.CheckBox33.Text = "Store themes in a custom path"
        Me.CheckBox33.UseVisualStyleBackColor = True
        '
        'TextBox11
        '
        Me.TextBox11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(57, 115)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(210, 22)
        Me.TextBox11.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(3, 69)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 13)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "DiscArt"
        '
        'TextBox12
        '
        Me.TextBox12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(70, 59)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(210, 22)
        Me.TextBox12.TabIndex = 8
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(3, 66)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(125, 21)
        Me.ComboBox1.TabIndex = 9
        '
        'ComboBox3
        '
        Me.ComboBox3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(3, 23)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(148, 21)
        Me.ComboBox3.TabIndex = 1
        '
        'ComboBox2
        '
        Me.ComboBox2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(3, 46)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(125, 21)
        Me.ComboBox2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Preferred Quality:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CheckBox8
        '
        Me.CheckBox8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox8.Location = New System.Drawing.Point(328, 112)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox8.TabIndex = 19
        Me.CheckBox8.Text = "Keep existing"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox9.Location = New System.Drawing.Point(131, 135)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox9.TabIndex = 2
        Me.CheckBox9.Text = "Only"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Minimum Quality:"
        '
        'CheckBox6
        '
        Me.CheckBox6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox6.Location = New System.Drawing.Point(328, 89)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox6.TabIndex = 20
        Me.CheckBox6.Text = "Keep existing"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox7.Location = New System.Drawing.Point(131, 112)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox7.TabIndex = 11
        Me.CheckBox7.Text = "Only"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(3, 6)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(181, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Convert Names to Proper Case"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CheckBox2.Location = New System.Drawing.Point(86, 43)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(286, 17)
        Me.CheckBox2.TabIndex = 18
        Me.CheckBox2.Text = "Display ""Image Select"" dialog while single scraping"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(86, 43)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(140, 17)
        Me.CheckBox3.TabIndex = 10
        Me.CheckBox3.Text = "Enable Image Caching"
        Me.CheckBox3.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Default Search Parameter:"
        '
        'CheckBox4
        '
        Me.CheckBox4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox4.Location = New System.Drawing.Point(109, 66)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox4.TabIndex = 4
        Me.CheckBox4.Text = "Keep existing"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox5.Location = New System.Drawing.Point(131, 89)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox5.TabIndex = 12
        Me.CheckBox5.Text = "Only"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel31
        '
        Me.TableLayoutPanel31.AutoSize = True
        Me.TableLayoutPanel31.ColumnCount = 3
        Me.TableLayoutPanel31.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel31.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel31.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel31.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel31.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel31.Name = "TableLayoutPanel31"
        Me.TableLayoutPanel31.RowCount = 3
        Me.TableLayoutPanel31.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel31.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel31.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel31.Size = New System.Drawing.Size(287, 51)
        Me.TableLayoutPanel31.TabIndex = 9
        '
        'CheckBox69
        '
        Me.CheckBox69.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox69.AutoSize = True
        Me.CheckBox69.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox69.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox69.Name = "CheckBox69"
        Me.CheckBox69.Size = New System.Drawing.Size(264, 17)
        Me.CheckBox69.TabIndex = 2
        Me.CheckBox69.Text = "Automatically Save Fanart To Backdrops Folder"
        Me.CheckBox69.UseVisualStyleBackColor = True
        '
        'TextBox44
        '
        Me.TextBox44.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox44.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox44.Location = New System.Drawing.Point(3, 3)
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Size = New System.Drawing.Size(250, 22)
        Me.TextBox44.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(32, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(23, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Location = New System.Drawing.Point(6, 18)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(520, 375)
        Me.TabControl2.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(512, 349)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Kodi"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(512, 349)
        Me.TabPage2.TabIndex = 5
        Me.TabPage2.Text = "Kodi Addons"
        Me.TabPage2.UseVisualStyleBackColor = True
        Me.TabPage2.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(512, 349)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "NMT"
        Me.TabPage3.UseVisualStyleBackColor = True
        Me.TabPage3.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(512, 349)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "Boxee"
        Me.TabPage4.UseVisualStyleBackColor = True
        Me.TabPage4.Visible = False
        '
        'TabPage9
        '
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(512, 349)
        Me.TabPage9.TabIndex = 2
        Me.TabPage9.Text = "Expert"
        Me.TabPage9.UseVisualStyleBackColor = True
        Me.TabPage9.Visible = False
        '
        'TableLayoutPanel30
        '
        Me.TableLayoutPanel30.AutoSize = True
        Me.TableLayoutPanel30.ColumnCount = 2
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel30.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel30.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel30.Name = "TableLayoutPanel30"
        Me.TableLayoutPanel30.RowCount = 2
        Me.TableLayoutPanel30.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel30.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel30.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel30.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel30.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel30.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel30.Size = New System.Drawing.Size(512, 349)
        Me.TableLayoutPanel30.TabIndex = 0
        '
        'GroupBox17
        '
        Me.GroupBox17.AutoSize = True
        Me.GroupBox17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox17.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupBox17.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(6, 21)
        Me.GroupBox17.TabIndex = 7
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Expert Settings"
        '
        'TableLayoutPanel29
        '
        Me.TableLayoutPanel29.AutoSize = True
        Me.TableLayoutPanel29.ColumnCount = 2
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel29.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel29.Name = "TableLayoutPanel29"
        Me.TableLayoutPanel29.RowCount = 3
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel29.Size = New System.Drawing.Size(0, 0)
        Me.TableLayoutPanel29.TabIndex = 9
        '
        'TabControl1
        '
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(480, 290)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(472, 264)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.Text = "Single"
        Me.TabPage5.UseVisualStyleBackColor = True
        Me.TabPage5.Visible = False
        '
        'TableLayoutPanel16
        '
        Me.TableLayoutPanel16.AutoSize = True
        Me.TableLayoutPanel16.ColumnCount = 3
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel16.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel16.Name = "TableLayoutPanel16"
        Me.TableLayoutPanel16.RowCount = 4
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel16.Size = New System.Drawing.Size(472, 264)
        Me.TableLayoutPanel16.TabIndex = 0
        '
        'TableLayoutPanel15
        '
        Me.TableLayoutPanel15.AutoSize = True
        Me.TableLayoutPanel15.ColumnCount = 3
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel15.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel15.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel15.Name = "TableLayoutPanel15"
        Me.TableLayoutPanel15.RowCount = 10
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel15.Size = New System.Drawing.Size(1, 174)
        Me.TableLayoutPanel15.TabIndex = 9
        '
        'Label37
        '
        Me.Label37.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(3, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(44, 13)
        Me.Label37.TabIndex = 17
        Me.Label37.Text = "Banner"
        '
        'Label38
        '
        Me.Label38.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(3, 63)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(37, 13)
        Me.Label38.TabIndex = 13
        Me.Label38.Text = "Trailer"
        '
        'Label39
        '
        Me.Label39.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(3, 28)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(48, 13)
        Me.Label39.TabIndex = 28
        Me.Label39.Text = "ClearArt"
        '
        'Label40
        '
        Me.Label40.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(3, 104)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(39, 13)
        Me.Label40.TabIndex = 10
        Me.Label40.Text = "Poster"
        '
        'Label41
        '
        Me.Label41.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(3, 91)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(61, 13)
        Me.Label41.TabIndex = 19
        Me.Label41.Text = "Landscape"
        '
        'Label42
        '
        Me.Label42.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(3, 119)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(30, 13)
        Me.Label42.TabIndex = 9
        Me.Label42.Text = "NFO"
        '
        'Label43
        '
        Me.Label43.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(3, 56)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(59, 13)
        Me.Label43.TabIndex = 12
        Me.Label43.Text = "ClearLogo"
        '
        'TextBox13
        '
        Me.TextBox13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox13.Location = New System.Drawing.Point(70, 87)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(210, 20)
        Me.TextBox13.TabIndex = 10
        '
        'Label44
        '
        Me.Label44.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(3, 91)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(43, 13)
        Me.Label44.TabIndex = 18
        Me.Label44.Text = "DiscArt"
        '
        'Label45
        '
        Me.Label45.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(3, 119)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(40, 13)
        Me.Label45.TabIndex = 11
        Me.Label45.Text = "Fanart"
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(472, 264)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "Multi"
        Me.TabPage6.UseVisualStyleBackColor = True
        Me.TabPage6.Visible = False
        '
        'TableLayoutPanel20
        '
        Me.TableLayoutPanel20.AutoSize = True
        Me.TableLayoutPanel20.ColumnCount = 3
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel20.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel20.Name = "TableLayoutPanel20"
        Me.TableLayoutPanel20.RowCount = 4
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel20.Size = New System.Drawing.Size(472, 264)
        Me.TableLayoutPanel20.TabIndex = 0
        '
        'TableLayoutPanel18
        '
        Me.TableLayoutPanel18.AutoSize = True
        Me.TableLayoutPanel18.ColumnCount = 3
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel18.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel18.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel18.Name = "TableLayoutPanel18"
        Me.TableLayoutPanel18.RowCount = 10
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel18.Size = New System.Drawing.Size(1, 55)
        Me.TableLayoutPanel18.TabIndex = 9
        '
        'Label46
        '
        Me.Label46.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(3, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(44, 13)
        Me.Label46.TabIndex = 40
        Me.Label46.Text = "Banner"
        '
        'TextBox15
        '
        Me.TextBox15.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox15.Location = New System.Drawing.Point(53, 3)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(210, 20)
        Me.TextBox15.TabIndex = 5
        '
        'TextBox16
        '
        Me.TextBox16.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox16.Location = New System.Drawing.Point(53, 31)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(210, 20)
        Me.TextBox16.TabIndex = 2
        '
        'Label47
        '
        Me.Label47.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(3, 56)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(37, 13)
        Me.Label47.TabIndex = 39
        Me.Label47.Text = "Trailer"
        '
        'Label48
        '
        Me.Label48.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(3, 28)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(48, 13)
        Me.Label48.TabIndex = 51
        Me.Label48.Text = "ClearArt"
        '
        'TextBox17
        '
        Me.TextBox17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox17.Location = New System.Drawing.Point(57, 44)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(210, 20)
        Me.TextBox17.TabIndex = 3
        '
        'TextBox18
        '
        Me.TextBox18.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox18.Location = New System.Drawing.Point(57, 72)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(210, 20)
        Me.TextBox18.TabIndex = 9
        '
        'Label49
        '
        Me.Label49.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(3, 104)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(39, 13)
        Me.Label49.TabIndex = 36
        Me.Label49.Text = "Poster"
        '
        'TextBox19
        '
        Me.TextBox19.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox19.Location = New System.Drawing.Point(57, 31)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(210, 20)
        Me.TextBox19.TabIndex = 7
        '
        'TextBox20
        '
        Me.TextBox20.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox20.Location = New System.Drawing.Point(57, 115)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(210, 20)
        Me.TextBox20.TabIndex = 1
        '
        'Label50
        '
        Me.Label50.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(3, 91)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(61, 13)
        Me.Label50.TabIndex = 42
        Me.Label50.Text = "Landscape"
        '
        'Label51
        '
        Me.Label51.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(3, 119)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(30, 13)
        Me.Label51.TabIndex = 35
        Me.Label51.Text = "NFO"
        '
        'Label52
        '
        Me.Label52.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(3, 56)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(59, 13)
        Me.Label52.TabIndex = 38
        Me.Label52.Text = "ClearLogo"
        '
        'TextBox21
        '
        Me.TextBox21.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox21.Location = New System.Drawing.Point(70, 59)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(210, 20)
        Me.TextBox21.TabIndex = 6
        '
        'TextBox22
        '
        Me.TextBox22.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox22.Location = New System.Drawing.Point(70, 87)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(210, 20)
        Me.TextBox22.TabIndex = 8
        '
        'Label53
        '
        Me.Label53.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(3, 91)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(43, 13)
        Me.Label53.TabIndex = 41
        Me.Label53.Text = "DiscArt"
        '
        'Label54
        '
        Me.Label54.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(3, 119)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(40, 13)
        Me.Label54.TabIndex = 37
        Me.Label54.Text = "Fanart"
        '
        'TextBox23
        '
        Me.TextBox23.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox23.Location = New System.Drawing.Point(70, 227)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(210, 20)
        Me.TextBox23.TabIndex = 4
        '
        'TabPage7
        '
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(472, 264)
        Me.TabPage7.TabIndex = 2
        Me.TabPage7.Text = "VIDEO_TS"
        Me.TabPage7.UseVisualStyleBackColor = True
        Me.TabPage7.Visible = False
        '
        'TableLayoutPanel24
        '
        Me.TableLayoutPanel24.AutoSize = True
        Me.TableLayoutPanel24.ColumnCount = 3
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel24.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel24.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel24.Name = "TableLayoutPanel24"
        Me.TableLayoutPanel24.RowCount = 4
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel24.Size = New System.Drawing.Size(472, 264)
        Me.TableLayoutPanel24.TabIndex = 0
        '
        'TableLayoutPanel22
        '
        Me.TableLayoutPanel22.AutoSize = True
        Me.TableLayoutPanel22.ColumnCount = 3
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel22.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel22.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel22.Name = "TableLayoutPanel22"
        Me.TableLayoutPanel22.RowCount = 10
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel22.Size = New System.Drawing.Size(1, 101)
        Me.TableLayoutPanel22.TabIndex = 9
        '
        'Label55
        '
        Me.Label55.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(3, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(44, 13)
        Me.Label55.TabIndex = 40
        Me.Label55.Text = "Banner"
        '
        'TextBox25
        '
        Me.TextBox25.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox25.Location = New System.Drawing.Point(53, 3)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(210, 20)
        Me.TextBox25.TabIndex = 5
        '
        'TextBox26
        '
        Me.TextBox26.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox26.Location = New System.Drawing.Point(53, 31)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(210, 20)
        Me.TextBox26.TabIndex = 4
        '
        'TextBox27
        '
        Me.TextBox27.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox27.Location = New System.Drawing.Point(53, 31)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(210, 20)
        Me.TextBox27.TabIndex = 2
        '
        'Label56
        '
        Me.Label56.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(3, 63)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(37, 13)
        Me.Label56.TabIndex = 39
        Me.Label56.Text = "Trailer"
        '
        'Label57
        '
        Me.Label57.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(3, 28)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(48, 13)
        Me.Label57.TabIndex = 51
        Me.Label57.Text = "ClearArt"
        '
        'TextBox28
        '
        Me.TextBox28.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox28.Location = New System.Drawing.Point(57, 44)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(210, 20)
        Me.TextBox28.TabIndex = 3
        '
        'TextBox29
        '
        Me.TextBox29.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox29.Location = New System.Drawing.Point(57, 72)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New System.Drawing.Size(210, 20)
        Me.TextBox29.TabIndex = 9
        '
        'Label58
        '
        Me.Label58.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(3, 104)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(39, 13)
        Me.Label58.TabIndex = 36
        Me.Label58.Text = "Poster"
        '
        'TextBox30
        '
        Me.TextBox30.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox30.Location = New System.Drawing.Point(57, 31)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(210, 20)
        Me.TextBox30.TabIndex = 7
        '
        'TextBox31
        '
        Me.TextBox31.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox31.Location = New System.Drawing.Point(57, 115)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New System.Drawing.Size(210, 20)
        Me.TextBox31.TabIndex = 1
        '
        'Label59
        '
        Me.Label59.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(3, 91)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(61, 13)
        Me.Label59.TabIndex = 42
        Me.Label59.Text = "Landscape"
        '
        'Label60
        '
        Me.Label60.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(3, 119)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(30, 13)
        Me.Label60.TabIndex = 35
        Me.Label60.Text = "NFO"
        '
        'Label61
        '
        Me.Label61.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(3, 56)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(59, 13)
        Me.Label61.TabIndex = 38
        Me.Label61.Text = "ClearLogo"
        '
        'TextBox32
        '
        Me.TextBox32.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox32.Location = New System.Drawing.Point(70, 59)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New System.Drawing.Size(210, 20)
        Me.TextBox32.TabIndex = 6
        '
        'TextBox33
        '
        Me.TextBox33.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox33.Location = New System.Drawing.Point(70, 87)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New System.Drawing.Size(210, 20)
        Me.TextBox33.TabIndex = 8
        '
        'Label62
        '
        Me.Label62.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(3, 91)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(43, 13)
        Me.Label62.TabIndex = 41
        Me.Label62.Text = "DiscArt"
        '
        'Label63
        '
        Me.Label63.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(3, 119)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(40, 13)
        Me.Label63.TabIndex = 37
        Me.Label63.Text = "Fanart"
        '
        'GroupBox14
        '
        Me.GroupBox14.AutoSize = True
        Me.GroupBox14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox14.Location = New System.Drawing.Point(286, 3)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(163, 21)
        Me.GroupBox14.TabIndex = 10
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Optional Settings"
        '
        'TableLayoutPanel23
        '
        Me.TableLayoutPanel23.AutoSize = True
        Me.TableLayoutPanel23.ColumnCount = 2
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel23.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel23.Name = "TableLayoutPanel23"
        Me.TableLayoutPanel23.RowCount = 3
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel23.Size = New System.Drawing.Size(157, 0)
        Me.TableLayoutPanel23.TabIndex = 9
        '
        'CheckBox62
        '
        Me.CheckBox62.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox62.AutoSize = True
        Me.CheckBox62.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox62.Name = "CheckBox62"
        Me.CheckBox62.Size = New System.Drawing.Size(153, 30)
        Me.CheckBox62.TabIndex = 3
        Me.CheckBox62.Text = "Recognize VIDEO_TS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "without VIDEO_TS folder"
        Me.CheckBox62.UseVisualStyleBackColor = True
        '
        'CheckBox63
        '
        Me.CheckBox63.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox63.AutoSize = True
        Me.CheckBox63.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox63.Name = "CheckBox63"
        Me.CheckBox63.Size = New System.Drawing.Size(121, 17)
        Me.CheckBox63.TabIndex = 2
        Me.CheckBox63.Text = "Use Base Directory"
        Me.CheckBox63.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(472, 264)
        Me.TabPage8.TabIndex = 3
        Me.TabPage8.Text = "BDMV"
        Me.TabPage8.UseVisualStyleBackColor = True
        Me.TabPage8.Visible = False
        '
        'TableLayoutPanel28
        '
        Me.TableLayoutPanel28.AutoSize = True
        Me.TableLayoutPanel28.ColumnCount = 3
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel28.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel28.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel28.Name = "TableLayoutPanel28"
        Me.TableLayoutPanel28.RowCount = 4
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel28.Size = New System.Drawing.Size(472, 264)
        Me.TableLayoutPanel28.TabIndex = 0
        '
        'TableLayoutPanel26
        '
        Me.TableLayoutPanel26.AutoSize = True
        Me.TableLayoutPanel26.ColumnCount = 2
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel26.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel26.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel26.Name = "TableLayoutPanel26"
        Me.TableLayoutPanel26.RowCount = 10
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel26.Size = New System.Drawing.Size(1, 101)
        Me.TableLayoutPanel26.TabIndex = 9
        '
        'Label64
        '
        Me.Label64.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(3, 0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(44, 13)
        Me.Label64.TabIndex = 40
        Me.Label64.Text = "Banner"
        '
        'TextBox35
        '
        Me.TextBox35.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox35.Location = New System.Drawing.Point(53, 3)
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New System.Drawing.Size(210, 20)
        Me.TextBox35.TabIndex = 5
        '
        'TextBox36
        '
        Me.TextBox36.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox36.Location = New System.Drawing.Point(53, 31)
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New System.Drawing.Size(210, 20)
        Me.TextBox36.TabIndex = 4
        '
        'TextBox37
        '
        Me.TextBox37.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox37.Location = New System.Drawing.Point(53, 31)
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New System.Drawing.Size(210, 20)
        Me.TextBox37.TabIndex = 2
        '
        'Label65
        '
        Me.Label65.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(3, 63)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(37, 13)
        Me.Label65.TabIndex = 39
        Me.Label65.Text = "Trailer"
        '
        'Label66
        '
        Me.Label66.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(3, 28)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(48, 13)
        Me.Label66.TabIndex = 51
        Me.Label66.Text = "ClearArt"
        '
        'TextBox38
        '
        Me.TextBox38.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox38.Location = New System.Drawing.Point(57, 44)
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New System.Drawing.Size(210, 20)
        Me.TextBox38.TabIndex = 3
        '
        'TextBox39
        '
        Me.TextBox39.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox39.Location = New System.Drawing.Point(57, 72)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Size = New System.Drawing.Size(210, 20)
        Me.TextBox39.TabIndex = 9
        '
        'Label67
        '
        Me.Label67.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(3, 104)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(39, 13)
        Me.Label67.TabIndex = 36
        Me.Label67.Text = "Poster"
        '
        'TextBox40
        '
        Me.TextBox40.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox40.Location = New System.Drawing.Point(57, 31)
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New System.Drawing.Size(210, 20)
        Me.TextBox40.TabIndex = 7
        '
        'TextBox41
        '
        Me.TextBox41.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox41.Location = New System.Drawing.Point(57, 115)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New System.Drawing.Size(210, 20)
        Me.TextBox41.TabIndex = 1
        '
        'Label68
        '
        Me.Label68.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(3, 91)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(61, 13)
        Me.Label68.TabIndex = 42
        Me.Label68.Text = "Landscape"
        '
        'Label69
        '
        Me.Label69.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(3, 119)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(30, 13)
        Me.Label69.TabIndex = 35
        Me.Label69.Text = "NFO"
        '
        'Label70
        '
        Me.Label70.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(3, 56)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(59, 13)
        Me.Label70.TabIndex = 38
        Me.Label70.Text = "ClearLogo"
        '
        'TextBox42
        '
        Me.TextBox42.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox42.Location = New System.Drawing.Point(70, 59)
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New System.Drawing.Size(210, 20)
        Me.TextBox42.TabIndex = 6
        '
        'TextBox43
        '
        Me.TextBox43.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox43.Location = New System.Drawing.Point(70, 87)
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.Size = New System.Drawing.Size(210, 20)
        Me.TextBox43.TabIndex = 8
        '
        'Label71
        '
        Me.Label71.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(3, 91)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(43, 13)
        Me.Label71.TabIndex = 41
        Me.Label71.Text = "DiscArt"
        '
        'Label72
        '
        Me.Label72.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(3, 119)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(40, 13)
        Me.Label72.TabIndex = 37
        Me.Label72.Text = "Fanart"
        '
        'GroupBox15
        '
        Me.GroupBox15.AutoSize = True
        Me.GroupBox15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox15.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(6, 21)
        Me.GroupBox15.TabIndex = 1
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Optional Images"
        '
        'TableLayoutPanel25
        '
        Me.TableLayoutPanel25.AutoSize = True
        Me.TableLayoutPanel25.ColumnCount = 3
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel25.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel25.Name = "TableLayoutPanel25"
        Me.TableLayoutPanel25.RowCount = 4
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel25.Size = New System.Drawing.Size(127, 0)
        Me.TableLayoutPanel25.TabIndex = 9
        '
        'CheckBox65
        '
        Me.CheckBox65.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox65.AutoSize = True
        Me.CheckBox65.Location = New System.Drawing.Point(3, 31)
        Me.CheckBox65.Name = "CheckBox65"
        Me.CheckBox65.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox65.TabIndex = 4
        Me.CheckBox65.Text = "Extrafanarts"
        Me.CheckBox65.UseVisualStyleBackColor = True
        '
        'CheckBox66
        '
        Me.CheckBox66.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox66.AutoSize = True
        Me.CheckBox66.Location = New System.Drawing.Point(3, 54)
        Me.CheckBox66.Name = "CheckBox66"
        Me.CheckBox66.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox66.TabIndex = 3
        Me.CheckBox66.Text = "Extrathumbs"
        Me.CheckBox66.UseVisualStyleBackColor = True
        '
        'TextBox34
        '
        Me.TextBox34.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox34.Location = New System.Drawing.Point(3, 3)
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New System.Drawing.Size(46, 20)
        Me.TextBox34.TabIndex = 2
        '
        'CheckBox64
        '
        Me.CheckBox64.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox64.AutoSize = True
        Me.CheckBox64.Location = New System.Drawing.Point(3, 5)
        Me.CheckBox64.Name = "CheckBox64"
        Me.CheckBox64.Size = New System.Drawing.Size(96, 17)
        Me.CheckBox64.TabIndex = 1
        Me.CheckBox64.Text = "Actor Thumbs"
        Me.CheckBox64.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.AutoSize = True
        Me.GroupBox16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox16.Location = New System.Drawing.Point(286, 3)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(160, 21)
        Me.GroupBox16.TabIndex = 10
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Optional Settings"
        '
        'TableLayoutPanel27
        '
        Me.TableLayoutPanel27.AutoSize = True
        Me.TableLayoutPanel27.ColumnCount = 2
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel27.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel27.Name = "TableLayoutPanel27"
        Me.TableLayoutPanel27.RowCount = 2
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel27.Size = New System.Drawing.Size(154, 0)
        Me.TableLayoutPanel27.TabIndex = 9
        '
        'CheckBox67
        '
        Me.CheckBox67.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox67.AutoSize = True
        Me.CheckBox67.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox67.Name = "CheckBox67"
        Me.CheckBox67.Size = New System.Drawing.Size(121, 17)
        Me.CheckBox67.TabIndex = 2
        Me.CheckBox67.Text = "Use Base Directory"
        Me.CheckBox67.UseVisualStyleBackColor = True
        '
        'CheckBox68
        '
        Me.CheckBox68.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox68.AutoSize = True
        Me.CheckBox68.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox68.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox68.Name = "CheckBox68"
        Me.CheckBox68.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox68.TabIndex = 1
        Me.CheckBox68.Text = "Enabled"
        Me.CheckBox68.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(3, 23)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(49, 13)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Enabled"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox53
        '
        Me.CheckBox53.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox53.AutoSize = True
        Me.CheckBox53.Location = New System.Drawing.Point(3, 54)
        Me.CheckBox53.Name = "CheckBox53"
        Me.CheckBox53.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox53.TabIndex = 3
        Me.CheckBox53.Text = "Extrathumbs"
        Me.CheckBox53.UseVisualStyleBackColor = True
        '
        'CheckBox43
        '
        Me.CheckBox43.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox43.AutoSize = True
        Me.CheckBox43.Location = New System.Drawing.Point(373, 37)
        Me.CheckBox43.Name = "CheckBox43"
        Me.CheckBox43.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox43.TabIndex = 15
        Me.CheckBox43.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(3, 43)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(40, 13)
        Me.Label34.TabIndex = 10
        Me.Label34.Text = "Fanart"
        '
        'CheckBox52
        '
        Me.CheckBox52.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox52.AutoSize = True
        Me.CheckBox52.Location = New System.Drawing.Point(3, 31)
        Me.CheckBox52.Name = "CheckBox52"
        Me.CheckBox52.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox52.TabIndex = 4
        Me.CheckBox52.Text = "Extrafanarts"
        Me.CheckBox52.UseVisualStyleBackColor = True
        '
        'CheckBox42
        '
        Me.CheckBox42.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox42.AutoSize = True
        Me.CheckBox42.Location = New System.Drawing.Point(169, 59)
        Me.CheckBox42.Name = "CheckBox42"
        Me.CheckBox42.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox42.TabIndex = 13
        Me.CheckBox42.UseVisualStyleBackColor = True
        '
        'CheckBox56
        '
        Me.CheckBox56.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox56.AutoSize = True
        Me.CheckBox56.Location = New System.Drawing.Point(3, 5)
        Me.CheckBox56.Name = "CheckBox56"
        Me.CheckBox56.Size = New System.Drawing.Size(96, 17)
        Me.CheckBox56.TabIndex = 1
        Me.CheckBox56.Text = "Actor Thumbs"
        Me.CheckBox56.UseVisualStyleBackColor = True
        '
        'CheckBox54
        '
        Me.CheckBox54.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox54.AutoSize = True
        Me.CheckBox54.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox54.Name = "CheckBox54"
        Me.CheckBox54.Size = New System.Drawing.Size(128, 17)
        Me.CheckBox54.TabIndex = 3
        Me.CheckBox54.Text = "also save unstacked"
        Me.CheckBox54.UseVisualStyleBackColor = True
        '
        'CheckBox55
        '
        Me.CheckBox55.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox55.AutoSize = True
        Me.CheckBox55.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox55.Name = "CheckBox55"
        Me.CheckBox55.Size = New System.Drawing.Size(116, 17)
        Me.CheckBox55.TabIndex = 2
        Me.CheckBox55.Text = "Stack <filename>"
        Me.CheckBox55.UseVisualStyleBackColor = True
        '
        'CheckBox59
        '
        Me.CheckBox59.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox59.AutoSize = True
        Me.CheckBox59.Location = New System.Drawing.Point(3, 5)
        Me.CheckBox59.Name = "CheckBox59"
        Me.CheckBox59.Size = New System.Drawing.Size(96, 17)
        Me.CheckBox59.TabIndex = 1
        Me.CheckBox59.Text = "Actor Thumbs"
        Me.CheckBox59.UseVisualStyleBackColor = True
        '
        'CheckBox40
        '
        Me.CheckBox40.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox40.AutoSize = True
        Me.CheckBox40.Location = New System.Drawing.Point(373, 72)
        Me.CheckBox40.Name = "CheckBox40"
        Me.CheckBox40.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox40.TabIndex = 11
        Me.CheckBox40.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel19
        '
        Me.TableLayoutPanel19.AutoSize = True
        Me.TableLayoutPanel19.ColumnCount = 2
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel19.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel19.Name = "TableLayoutPanel19"
        Me.TableLayoutPanel19.RowCount = 3
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel19.Size = New System.Drawing.Size(157, 0)
        Me.TableLayoutPanel19.TabIndex = 9
        '
        'CheckBox57
        '
        Me.CheckBox57.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox57.AutoSize = True
        Me.CheckBox57.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox57.Name = "CheckBox57"
        Me.CheckBox57.Size = New System.Drawing.Size(128, 17)
        Me.CheckBox57.TabIndex = 3
        Me.CheckBox57.Text = "also save unstacked"
        Me.CheckBox57.UseVisualStyleBackColor = True
        '
        'CheckBox58
        '
        Me.CheckBox58.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox58.AutoSize = True
        Me.CheckBox58.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox58.Name = "CheckBox58"
        Me.CheckBox58.Size = New System.Drawing.Size(116, 17)
        Me.CheckBox58.TabIndex = 2
        Me.CheckBox58.Text = "Stack <filename>"
        Me.CheckBox58.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 13)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "Enabled"
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(158, 3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 13)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "YAMJ"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(3, 117)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(37, 13)
        Me.Label31.TabIndex = 10
        Me.Label31.Text = "Trailer"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.Ember_Media_Manager.My.Resources.Resources.tvtunes
        Me.PictureBox2.Location = New System.Drawing.Point(10, 3)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Ember_Media_Manager.My.Resources.Resources.ad
        Me.PictureBox1.Location = New System.Drawing.Point(278, 3)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 97)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Landscape"
        '
        'Label36
        '
        Me.Label36.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(3, 83)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(39, 13)
        Me.Label36.TabIndex = 10
        Me.Label36.Text = "Poster"
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 20)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(44, 13)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "Banner"
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(3, 20)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Enabled"
        '
        'CheckBox38
        '
        Me.CheckBox38.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox38.AutoSize = True
        Me.CheckBox38.Location = New System.Drawing.Point(169, 60)
        Me.CheckBox38.Name = "CheckBox38"
        Me.CheckBox38.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox38.TabIndex = 12
        Me.CheckBox38.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(365, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(32, 13)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "NMJ"
        '
        'CheckBox39
        '
        Me.CheckBox39.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox39.AutoSize = True
        Me.CheckBox39.Location = New System.Drawing.Point(169, 59)
        Me.CheckBox39.Name = "CheckBox39"
        Me.CheckBox39.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox39.TabIndex = 11
        Me.CheckBox39.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(3, 56)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(40, 13)
        Me.Label28.TabIndex = 10
        Me.Label28.Text = "Fanart"
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(3, 72)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "NFO"
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(3, 94)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(39, 13)
        Me.Label30.TabIndex = 10
        Me.Label30.Text = "Poster"
        '
        'CheckBox41
        '
        Me.CheckBox41.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox41.AutoSize = True
        Me.CheckBox41.Location = New System.Drawing.Point(373, 59)
        Me.CheckBox41.Name = "CheckBox41"
        Me.CheckBox41.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox41.TabIndex = 13
        Me.CheckBox41.UseVisualStyleBackColor = True
        '
        'CheckBox44
        '
        Me.CheckBox44.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox44.AutoSize = True
        Me.CheckBox44.Location = New System.Drawing.Point(373, 23)
        Me.CheckBox44.Name = "CheckBox44"
        Me.CheckBox44.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox44.TabIndex = 16
        Me.CheckBox44.UseVisualStyleBackColor = True
        '
        'CheckBox45
        '
        Me.CheckBox45.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox45.AutoSize = True
        Me.CheckBox45.Location = New System.Drawing.Point(169, 23)
        Me.CheckBox45.Name = "CheckBox45"
        Me.CheckBox45.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox45.TabIndex = 16
        Me.CheckBox45.UseVisualStyleBackColor = True
        '
        'CheckBox46
        '
        Me.CheckBox46.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox46.AutoSize = True
        Me.CheckBox46.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CheckBox46.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox46.Name = "CheckBox46"
        Me.CheckBox46.Size = New System.Drawing.Size(121, 17)
        Me.CheckBox46.TabIndex = 0
        Me.CheckBox46.Text = "Use .watched Files"
        Me.CheckBox46.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(3, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel21
        '
        Me.TableLayoutPanel21.AutoSize = True
        Me.TableLayoutPanel21.ColumnCount = 3
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel21.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel21.Name = "TableLayoutPanel21"
        Me.TableLayoutPanel21.RowCount = 4
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel21.Size = New System.Drawing.Size(159, 0)
        Me.TableLayoutPanel21.TabIndex = 9
        '
        'CheckBox60
        '
        Me.CheckBox60.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox60.AutoSize = True
        Me.CheckBox60.Location = New System.Drawing.Point(3, 31)
        Me.CheckBox60.Name = "CheckBox60"
        Me.CheckBox60.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox60.TabIndex = 4
        Me.CheckBox60.Text = "Extrafanarts"
        Me.CheckBox60.UseVisualStyleBackColor = True
        '
        'CheckBox61
        '
        Me.CheckBox61.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox61.AutoSize = True
        Me.CheckBox61.Location = New System.Drawing.Point(3, 54)
        Me.CheckBox61.Name = "CheckBox61"
        Me.CheckBox61.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox61.TabIndex = 3
        Me.CheckBox61.Text = "Extrathumbs"
        Me.CheckBox61.UseVisualStyleBackColor = True
        '
        'TextBox24
        '
        Me.TextBox24.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox24.Location = New System.Drawing.Point(3, 3)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(46, 20)
        Me.TextBox24.TabIndex = 2
        '
        'CheckBox51
        '
        Me.CheckBox51.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox51.AutoSize = True
        Me.CheckBox51.Location = New System.Drawing.Point(3, 5)
        Me.CheckBox51.Name = "CheckBox51"
        Me.CheckBox51.Size = New System.Drawing.Size(96, 17)
        Me.CheckBox51.TabIndex = 1
        Me.CheckBox51.Text = "Actor Thumbs"
        Me.CheckBox51.UseVisualStyleBackColor = True
        '
        'CheckBox47
        '
        Me.CheckBox47.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox47.AutoSize = True
        Me.CheckBox47.Location = New System.Drawing.Point(3, 23)
        Me.CheckBox47.Name = "CheckBox47"
        Me.CheckBox47.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox47.TabIndex = 12
        Me.CheckBox47.UseVisualStyleBackColor = True
        '
        'CheckBox48
        '
        Me.CheckBox48.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox48.AutoSize = True
        Me.CheckBox48.Location = New System.Drawing.Point(3, 23)
        Me.CheckBox48.Name = "CheckBox48"
        Me.CheckBox48.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox48.TabIndex = 13
        Me.CheckBox48.UseVisualStyleBackColor = True
        '
        'CheckBox49
        '
        Me.CheckBox49.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox49.AutoSize = True
        Me.CheckBox49.Location = New System.Drawing.Point(3, 43)
        Me.CheckBox49.Name = "CheckBox49"
        Me.CheckBox49.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox49.TabIndex = 11
        Me.CheckBox49.UseVisualStyleBackColor = True
        '
        'CheckBox50
        '
        Me.CheckBox50.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckBox50.AutoSize = True
        Me.CheckBox50.Location = New System.Drawing.Point(3, 23)
        Me.CheckBox50.Name = "CheckBox50"
        Me.CheckBox50.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox50.TabIndex = 16
        Me.CheckBox50.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(58, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(39, 13)
        Me.Label33.TabIndex = 1
        Me.Label33.Text = "Boxee"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label35
        '
        Me.Label35.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(3, 63)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(30, 13)
        Me.Label35.TabIndex = 10
        Me.Label35.Text = "NFO"
        '
        'TextBox14
        '
        Me.TextBox14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox14.Location = New System.Drawing.Point(3, 3)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(46, 20)
        Me.TextBox14.TabIndex = 2
        '
        'TableLayoutPanel17
        '
        Me.TableLayoutPanel17.AutoSize = True
        Me.TableLayoutPanel17.ColumnCount = 3
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel17.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel17.Name = "TableLayoutPanel17"
        Me.TableLayoutPanel17.RowCount = 2
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel17.Size = New System.Drawing.Size(134, 0)
        Me.TableLayoutPanel17.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(320, 159)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Location = New System.Drawing.Point(3, 32)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(314, 95)
        Me.ListBox1.TabIndex = 1
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(3, 32)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(103, 133)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(23, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.UseVisualStyleBackColor = True
        '
        'dlgSettings
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1654, 1173)
        Me.Controls.Add(Me.pnlTVGeneral)
        Me.Controls.Add(Me.pnlTVScraper)
        Me.Controls.Add(Me.pnlFileSystem)
        Me.Controls.Add(Me.pnlMovieSetGeneral)
        Me.Controls.Add(Me.scSettings)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "dlgSettings"
        Me.Text = "Settings"
        Me.gbFileSystemCleanFiles.ResumeLayout(False)
        Me.tcFileSystemCleaner.ResumeLayout(False)
        Me.tpFileSystemCleanerStandard.ResumeLayout(False)
        Me.tpFileSystemCleanerStandard.PerformLayout()
        Me.tpFileSystemCleanerExpert.ResumeLayout(False)
        Me.tpFileSystemCleanerExpert.PerformLayout()
        Me.pnlFileSystem.ResumeLayout(False)
        Me.pnlFileSystem.PerformLayout()
        Me.tblFileSystem.ResumeLayout(False)
        Me.tblFileSystem.PerformLayout()
        Me.gbFileSystemValidVideoExts.ResumeLayout(False)
        Me.gbFileSystemValidVideoExts.PerformLayout()
        Me.tblFileSystemValidVideoExts.ResumeLayout(False)
        Me.tblFileSystemValidVideoExts.PerformLayout()
        Me.gbFileSystemNoStackExts.ResumeLayout(False)
        Me.gbFileSystemNoStackExts.PerformLayout()
        Me.tblFileSystemNoStackExts.ResumeLayout(False)
        Me.tblFileSystemNoStackExts.PerformLayout()
        Me.gbFileSystemExcludedDirs.ResumeLayout(False)
        Me.gbFileSystemExcludedDirs.PerformLayout()
        Me.tblFileSystemExcludedDirs.ResumeLayout(False)
        Me.tblFileSystemExcludedDirs.PerformLayout()
        Me.gbFileSystemValidSubtitlesExts.ResumeLayout(False)
        Me.gbFileSystemValidSubtitlesExts.PerformLayout()
        Me.tblFileSystemValidSubtitlesExts.ResumeLayout(False)
        Me.tblFileSystemValidSubtitlesExts.PerformLayout()
        Me.gbFileSystemValidThemeExts.ResumeLayout(False)
        Me.gbFileSystemValidThemeExts.PerformLayout()
        Me.tblFileSystemValidThemeExts.ResumeLayout(False)
        Me.tblFileSystemValidThemeExts.PerformLayout()
        Me.pnlSettingsCurrent.ResumeLayout(False)
        CType(Me.pbSettingsCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTVGeneral.ResumeLayout(False)
        Me.pnlTVGeneral.PerformLayout()
        Me.tblTVGeneral.ResumeLayout(False)
        Me.tblTVGeneral.PerformLayout()
        Me.gbTVGeneralCustomScrapeButton.ResumeLayout(False)
        Me.gbTVGeneralCustomScrapeButton.PerformLayout()
        Me.tblTVGeneralCustomScrapeButton.ResumeLayout(False)
        Me.tblTVGeneralCustomScrapeButton.PerformLayout()
        Me.gbTVGeneralMiscOpts.ResumeLayout(False)
        Me.gbTVGeneralMiscOpts.PerformLayout()
        Me.tblTVGeneralMiscOpts.ResumeLayout(False)
        Me.tblTVGeneralMiscOpts.PerformLayout()
        Me.gbTVGeneralMediaListOpts.ResumeLayout(False)
        Me.gbTVGeneralMediaListOpts.PerformLayout()
        Me.tblTVGeneralMediaListOpts.ResumeLayout(False)
        Me.tblTVGeneralMediaListOpts.PerformLayout()
        Me.gbTVGeneralEpisodeListSorting.ResumeLayout(False)
        Me.gbTVGeneralEpisodeListSorting.PerformLayout()
        Me.tblTVGeneralEpisodeListSorting.ResumeLayout(False)
        Me.gbTVGeneralSeasonListSortingOpts.ResumeLayout(False)
        Me.gbTVGeneralSeasonListSortingOpts.PerformLayout()
        Me.tblTVGeneralSeasonListSorting.ResumeLayout(False)
        Me.gbTVGeneralShowListSortingOpts.ResumeLayout(False)
        Me.gbTVGeneralShowListSortingOpts.PerformLayout()
        Me.tblTVGeneralShowListSorting.ResumeLayout(False)
        Me.gbTVGeneralMediaListSortTokensOpts.ResumeLayout(False)
        Me.gbTVGeneralMediaListSortTokensOpts.PerformLayout()
        Me.tblTVGeneralMediaListSortTokensOpts.ResumeLayout(False)
        Me.tblTVGeneralMediaListSortTokensOpts.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.pnlTVScraper.ResumeLayout(False)
        Me.pnlTVScraper.PerformLayout()
        Me.tblTVScraper.ResumeLayout(False)
        Me.tblTVScraper.PerformLayout()
        Me.gbTVScraperCertificationOpts.ResumeLayout(False)
        Me.gbTVScraperCertificationOpts.PerformLayout()
        Me.tblTVScraperCertificationOpts.ResumeLayout(False)
        Me.tblTVScraperCertificationOpts.PerformLayout()
        Me.gbTVScraperGlobalOpts.ResumeLayout(False)
        Me.gbTVScraperGlobalOpts.PerformLayout()
        Me.tblTVScraperGlobalOpts.ResumeLayout(False)
        Me.tblTVScraperGlobalOpts.PerformLayout()
        Me.gbTVScraperMetaDataOpts.ResumeLayout(False)
        Me.gbTVScraperMetaDataOpts.PerformLayout()
        Me.tblTVScraperMetaDataOpts.ResumeLayout(False)
        Me.tblTVScraperMetaDataOpts.PerformLayout()
        Me.gbTVScraperDefFIExtOpts.ResumeLayout(False)
        Me.gbTVScraperDefFIExtOpts.PerformLayout()
        Me.tblTVScraperDefFIExtOpts.ResumeLayout(False)
        Me.tblTVScraperDefFIExtOpts.PerformLayout()
        Me.gbTVScraperDurationFormatOpts.ResumeLayout(False)
        Me.gbTVScraperDurationFormatOpts.PerformLayout()
        Me.tblgbTVScraperDurationFormatOpts.ResumeLayout(False)
        Me.tblgbTVScraperDurationFormatOpts.PerformLayout()
        Me.gbTVScraperMiscOpts.ResumeLayout(False)
        Me.gbTVScraperMiscOpts.PerformLayout()
        Me.tblTVScraperMiscOpts.ResumeLayout(False)
        Me.tblTVScraperMiscOpts.PerformLayout()
        Me.gbSettingsHelp.ResumeLayout(False)
        CType(Me.pbSettingsHelpLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSettingsHelp.ResumeLayout(False)
        Me.pnlMovieSetGeneral.ResumeLayout(False)
        Me.pnlMovieSetGeneral.PerformLayout()
        Me.tblMovieSetGeneral.ResumeLayout(False)
        Me.tblMovieSetGeneral.PerformLayout()
        Me.gbMovieSetGeneralCustomScrapeButton.ResumeLayout(False)
        Me.gbMovieSetGeneralCustomScrapeButton.PerformLayout()
        Me.tblMovieSetGeneralCustomScrapeButton.ResumeLayout(False)
        Me.tblMovieSetGeneralCustomScrapeButton.PerformLayout()
        Me.gbMovieSetGeneralMediaListOpts.ResumeLayout(False)
        Me.gbMovieSetGeneralMediaListOpts.PerformLayout()
        Me.tblMovieSetGeneralMediaListOpts.ResumeLayout(False)
        Me.tblMovieSetGeneralMediaListOpts.PerformLayout()
        Me.gbMovieSetGeneralMediaListSorting.ResumeLayout(False)
        Me.gbMovieSetGeneralMediaListSorting.PerformLayout()
        Me.tblMovieSetGeneralMediaListSorting.ResumeLayout(False)
        Me.gbMovieSetGeneralMediaListSortTokensOpts.ResumeLayout(False)
        Me.gbMovieSetGeneralMediaListSortTokensOpts.PerformLayout()
        Me.tblMovieSetGeneralSortTokensOpts.ResumeLayout(False)
        Me.tblMovieSetGeneralSortTokensOpts.PerformLayout()
        Me.gbMovieSetGeneralMiscOpts.ResumeLayout(False)
        Me.gbMovieSetGeneralMiscOpts.PerformLayout()
        Me.tblMovieSetGeneralMiscOpts.ResumeLayout(False)
        Me.tblMovieSetGeneralMiscOpts.PerformLayout()
        Me.scSettings.Panel1.ResumeLayout(False)
        Me.scSettings.Panel1.PerformLayout()
        Me.scSettings.Panel2.ResumeLayout(False)
        CType(Me.scSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSettings.ResumeLayout(False)
        Me.tblSettingsCurrent.ResumeLayout(False)
        Me.scSettingsBody.Panel1.ResumeLayout(False)
        Me.scSettingsBody.Panel2.ResumeLayout(False)
        CType(Me.scSettingsBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSettingsBody.ResumeLayout(False)
        Me.scSettingsMain.Panel1.ResumeLayout(False)
        Me.scSettingsMain.Panel2.ResumeLayout(False)
        CType(Me.scSettingsMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSettingsMain.ResumeLayout(False)
        Me.tblSettingsFooter.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbFileSystemCleanFiles As System.Windows.Forms.GroupBox
    Friend WithEvents chkCleanFolderJPG As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanFanartJPG As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanMovieTBNb As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanMovieTBN As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanMovieNFOb As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanMovieNFO As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanMovieFanartJPG As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanMovieNameJPG As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanMovieJPG As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanPosterJPG As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanPosterTBN As System.Windows.Forms.CheckBox
    Friend WithEvents chkCleanDotFanartJPG As System.Windows.Forms.CheckBox
    Friend WithEvents ilSettings As System.Windows.Forms.ImageList
    Friend WithEvents tvSettingsList As System.Windows.Forms.TreeView
    Friend WithEvents lblSettingsCurrent As System.Windows.Forms.Label
    Friend WithEvents pnlSettingsCurrent As System.Windows.Forms.Panel
    Friend WithEvents chkCleanExtrathumbs As System.Windows.Forms.CheckBox
    Friend WithEvents pnlFileSystem As System.Windows.Forms.Panel
    Friend WithEvents gbFileSystemValidVideoExts As System.Windows.Forms.GroupBox
    Friend WithEvents btnFileSystemValidVideoExtsRemove As System.Windows.Forms.Button
    Friend WithEvents btnFileSystemValidVideoExtsAdd As System.Windows.Forms.Button
    Friend WithEvents txtFileSystemValidVideoExts As System.Windows.Forms.TextBox
    Friend WithEvents lstFileSystemValidVideoExts As System.Windows.Forms.ListBox
    Friend WithEvents tcFileSystemCleaner As System.Windows.Forms.TabControl
    Friend WithEvents tpFileSystemCleanerStandard As System.Windows.Forms.TabPage
    Friend WithEvents tpFileSystemCleanerExpert As System.Windows.Forms.TabPage
    Friend WithEvents lblFileSystemCleanerWarning As System.Windows.Forms.Label
    Friend WithEvents btnFileSystemCleanerWhitelistRemove As System.Windows.Forms.Button
    Friend WithEvents btnFileSystemCleanerWhitelistAdd As System.Windows.Forms.Button
    Friend WithEvents txtFileSystemCleanerWhitelist As System.Windows.Forms.TextBox
    Friend WithEvents lstFileSystemCleanerWhitelist As System.Windows.Forms.ListBox
    Friend WithEvents lblFileSystemCleanerWhitelist As System.Windows.Forms.Label
    Friend WithEvents chkFileSystemCleanerWhitelist As System.Windows.Forms.CheckBox
    Friend WithEvents gbFileSystemNoStackExts As System.Windows.Forms.GroupBox
    Friend WithEvents btnFileSystemNoStackExtsRemove As System.Windows.Forms.Button
    Friend WithEvents btnFileSystemNoStackExtsAdd As System.Windows.Forms.Button
    Friend WithEvents txtFileSystemNoStackExts As System.Windows.Forms.TextBox
    Friend WithEvents lstFileSystemNoStackExts As System.Windows.Forms.ListBox
    Friend WithEvents fbdBrowse As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents pnlTVGeneral As System.Windows.Forms.Panel
    Friend WithEvents pnlTVScraper As System.Windows.Forms.Panel
    Friend WithEvents gbTVGeneralMiscOpts As System.Windows.Forms.GroupBox
    Friend WithEvents gbTVGeneralMediaListOpts As System.Windows.Forms.GroupBox
    Friend WithEvents chkTVDisplayMissingEpisodes As System.Windows.Forms.CheckBox
    Friend WithEvents gbTVScraperMetaDataOpts As System.Windows.Forms.GroupBox
    Friend WithEvents gbTVScraperDefFIExtOpts As System.Windows.Forms.GroupBox
    Friend WithEvents lstTVScraperDefFIExt As System.Windows.Forms.ListBox
    Friend WithEvents txtTVScraperDefFIExt As System.Windows.Forms.TextBox
    Friend WithEvents lblTVScraperDefFIExt As System.Windows.Forms.Label
    Friend WithEvents btnTVScraperDefFIExtRemove As System.Windows.Forms.Button
    Friend WithEvents btnTVScraperDefFIExtEdit As System.Windows.Forms.Button
    Friend WithEvents btnTVScraperDefFIExtAdd As System.Windows.Forms.Button
    Friend WithEvents cbTVLanguageOverlay As System.Windows.Forms.ComboBox
    Friend WithEvents lblTVLanguageOverlay As System.Windows.Forms.Label
    Friend WithEvents chkTVScraperMetaDataScan As System.Windows.Forms.CheckBox
    Friend WithEvents gbTVScraperGlobalOpts As System.Windows.Forms.GroupBox
    Friend WithEvents chkTVLockEpisodePlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowStudio As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockEpisodeRating As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockEpisodeTitle As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowPlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowGenre As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowRating As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowTitle As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowEpiGuideURL As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowMPAA As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowPlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowGenre As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowTitle As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodeTitle As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowRating As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowActors As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowStudio As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowPremiered As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodeActors As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodeCredits As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodeDirector As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodePlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodeRating As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodeAired As System.Windows.Forms.CheckBox
    Friend WithEvents tsSettingsTopMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents pnlSettingsMain As System.Windows.Forms.Panel
    Friend WithEvents pbSettingsCurrent As System.Windows.Forms.PictureBox
    Friend WithEvents gbSettingsHelp As System.Windows.Forms.GroupBox
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents pnlSettingsHelp As System.Windows.Forms.Panel
    Friend WithEvents pbSettingsHelpLogo As System.Windows.Forms.PictureBox
    Friend WithEvents chkTVGeneralMarkNewShows As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVGeneralMarkNewEpisodes As System.Windows.Forms.CheckBox
    Friend WithEvents btnFileSystemValidVideoExtsReset As System.Windows.Forms.Button
    Friend WithEvents gbTVScraperDurationFormatOpts As System.Windows.Forms.GroupBox
    Friend WithEvents chkTVScraperUseMDDuration As System.Windows.Forms.CheckBox
    Friend WithEvents txtTVScraperDurationRuntimeFormat As System.Windows.Forms.TextBox
    Friend WithEvents fileBrowse As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblTVScraperDurationRuntimeFormat As System.Windows.Forms.Label
    Friend WithEvents chkTVLockShowStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowStatus As System.Windows.Forms.CheckBox
    Friend WithEvents gbFileSystemValidThemeExts As System.Windows.Forms.GroupBox
    Friend WithEvents btnFileSystemValidThemeExtsReset As System.Windows.Forms.Button
    Friend WithEvents btnFileSystemValidThemeExtsRemove As System.Windows.Forms.Button
    Friend WithEvents btnFileSystemValidThemeExtsAdd As System.Windows.Forms.Button
    Friend WithEvents txtFileSystemValidThemeExts As System.Windows.Forms.TextBox
    Friend WithEvents lstFileSystemValidThemeExts As System.Windows.Forms.ListBox
    Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
    Friend WithEvents pnlMovieSetGeneral As System.Windows.Forms.Panel
    Friend WithEvents gbMovieSetGeneralMiscOpts As System.Windows.Forms.GroupBox
    Friend WithEvents chkMovieSetClickScrape As System.Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetClickScrapeAsk As System.Windows.Forms.CheckBox
    Friend WithEvents gbMovieSetGeneralMediaListOpts As System.Windows.Forms.GroupBox
    Friend WithEvents gbMovieSetGeneralMediaListSortTokensOpts As System.Windows.Forms.GroupBox
    Friend WithEvents btnMovieSetSortTokenRemove As System.Windows.Forms.Button
    Friend WithEvents btnMovieSetSortTokenAdd As System.Windows.Forms.Button
    Friend WithEvents txtMovieSetSortToken As System.Windows.Forms.TextBox
    Friend WithEvents lstMovieSetSortTokens As System.Windows.Forms.ListBox
    Friend WithEvents chkTVScraperShowRuntime As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowRuntime As System.Windows.Forms.CheckBox
    Friend WithEvents gbTVGeneralMediaListSortTokensOpts As System.Windows.Forms.GroupBox
    Friend WithEvents btnTVSortTokenRemove As System.Windows.Forms.Button
    Friend WithEvents btnTVSortTokenAdd As System.Windows.Forms.Button
    Friend WithEvents txtTVSortToken As System.Windows.Forms.TextBox
    Friend WithEvents lstTVSortTokens As System.Windows.Forms.ListBox
    Friend WithEvents chkTVDisplayStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodeRuntime As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockEpisodeRuntime As System.Windows.Forms.CheckBox
    Friend WithEvents gbTVScraperMiscOpts As System.Windows.Forms.GroupBox
    Friend WithEvents chkTVScraperUseSRuntimeForEp As System.Windows.Forms.CheckBox
    Friend WithEvents gbFileSystemExcludedDirs As System.Windows.Forms.GroupBox
    Friend WithEvents btnFileSystemExcludedDirsRemove As System.Windows.Forms.Button
    Friend WithEvents btnFileSystemExcludedDirsAdd As System.Windows.Forms.Button
    Friend WithEvents txtFileSystemExcludedDirs As System.Windows.Forms.TextBox
    Friend WithEvents lstFileSystemExcludedDirs As System.Windows.Forms.ListBox
    Friend WithEvents gbFileSystemValidSubtitlesExts As System.Windows.Forms.GroupBox
    Friend WithEvents btnFileSystemValidSubtitlesExtsRemove As System.Windows.Forms.Button
    Friend WithEvents btnFileSystemValidSubtitlesExtsAdd As System.Windows.Forms.Button
    Friend WithEvents txtFileSystemValidSubtitlesExts As System.Windows.Forms.TextBox
    Friend WithEvents lstFileSystemValidSubtitlesExts As System.Windows.Forms.ListBox
    Friend WithEvents btnFileSystemValidSubtitlesExtsReset As System.Windows.Forms.Button
    Friend WithEvents scSettings As System.Windows.Forms.SplitContainer
    Friend WithEvents scSettingsBody As System.Windows.Forms.SplitContainer
    Friend WithEvents scSettingsMain As System.Windows.Forms.SplitContainer
    Friend WithEvents tblSettingsFooter As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblSettingsCurrent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieSetGeneralMarkNew As System.Windows.Forms.CheckBox
    Friend WithEvents tblMovieSetGeneralMediaListOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblMovieSetGeneral As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblMovieSetGeneralMiscOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblMovieSetGeneralSortTokensOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblFileSystemValidVideoExts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblFileSystem As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblFileSystemValidThemeExts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblFileSystemNoStackExts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblFileSystemValidSubtitlesExts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblFileSystemExcludedDirs As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblTVGeneralMiscOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblTVGeneralMediaListOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblTVGeneralMediaListSortTokensOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblTVGeneral As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblTVScraperGlobalOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTVScraperGlobalHeaderShows As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalHeaderEpisodes As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalHeaderShowsLock As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalHeaderEpisodesLock As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalActors As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalAired As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalCredits As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalEpisodeGuideURL As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalGenres As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalMPAA As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalPlot As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalPremiered As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalRating As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalRuntime As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalStatus As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalStudios As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalTitle As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalDirectors As System.Windows.Forms.Label
    Friend WithEvents tblTVScraperMiscOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblgbTVScraperDurationFormatOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblTVScraperMetaDataOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblTVScraperDefFIExtOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblTVScraper As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetGeneralMediaListSorting As System.Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetGeneralMediaListSorting As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieSetGeneralMediaListSortingDown As System.Windows.Forms.Button
    Friend WithEvents btnMovieSetGeneralMediaListSortingUp As System.Windows.Forms.Button
    Friend WithEvents lvMovieSetGeneralMediaListSorting As System.Windows.Forms.ListView
    Friend WithEvents colMovieSetGeneralMediaListSortingDisplayIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSetGeneralMediaListSortingColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSetGeneralMediaListSortingLabel As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSetGeneralMediaListSortingHide As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnMovieSetGeneralMediaListSortingReset As System.Windows.Forms.Button
    Friend WithEvents gbTVGeneralShowListSortingOpts As System.Windows.Forms.GroupBox
    Friend WithEvents tblTVGeneralShowListSorting As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTVGeneralShowListSortingDown As System.Windows.Forms.Button
    Friend WithEvents btnTVGeneralShowListSortingUp As System.Windows.Forms.Button
    Friend WithEvents lvTVGeneralShowListSorting As System.Windows.Forms.ListView
    Friend WithEvents colTVGeneralShowListSortingDisplayIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralShowListSortingColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralShowListSortingLabel As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralShowListSortingHide As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnTVGeneralShowListSortingReset As System.Windows.Forms.Button
    Friend WithEvents gbTVGeneralEpisodeListSorting As System.Windows.Forms.GroupBox
    Friend WithEvents tblTVGeneralEpisodeListSorting As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTVGeneralEpisodeListSortingDown As System.Windows.Forms.Button
    Friend WithEvents btnTVGeneralEpisodeListSortingUp As System.Windows.Forms.Button
    Friend WithEvents lvTVGeneralEpisodeListSorting As System.Windows.Forms.ListView
    Friend WithEvents colTVGeneralEpisodeListSortingDisplayIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralEpisodeListSortingColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralEpisodeListSortingLabel As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralEpisodeListSortingHide As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnTVGeneralEpisodeListSortingReset As System.Windows.Forms.Button
    Friend WithEvents gbTVGeneralSeasonListSortingOpts As System.Windows.Forms.GroupBox
    Friend WithEvents tblTVGeneralSeasonListSorting As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTVGeneralSeasonListSortingDown As System.Windows.Forms.Button
    Friend WithEvents btnTVGeneralSeasonListSortingUp As System.Windows.Forms.Button
    Friend WithEvents lvTVGeneralSeasonListSorting As System.Windows.Forms.ListView
    Friend WithEvents colTVGeneralSeasonListSortingDisplayIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralSeasonListSortingColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralSeasonListSortingLabel As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralSeasonListSortingHide As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnTVGeneralSeasonListSortingReset As System.Windows.Forms.Button
    Friend WithEvents btnTVSortTokenReset As System.Windows.Forms.Button
    Friend WithEvents btnMovieSetSortTokenReset As System.Windows.Forms.Button
    Friend WithEvents lblTVScraperGlobalGuestStars As System.Windows.Forms.Label
    Friend WithEvents chkTVScraperEpisodeGuestStars As System.Windows.Forms.CheckBox
    Friend WithEvents lblTVScraperGlobalLanguageA As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalLanguageV As System.Windows.Forms.Label
    Friend WithEvents chkTVLockEpisodeLanguageA As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockEpisodeLanguageV As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

    Friend WithEvents gbTVScraperCertificationOpts As System.Windows.Forms.GroupBox
    Friend WithEvents tblTVScraperCertificationOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkTVScraperShowCertOnlyValue As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowCertFSK As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowCertForMPAAFallback As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperShowCertForMPAA As System.Windows.Forms.CheckBox
    Friend WithEvents txtTVScraperShowMPAANotRated As System.Windows.Forms.TextBox
    Friend WithEvents lblTVScraperShowMPAANotRated As System.Windows.Forms.Label
    Friend WithEvents cbTVScraperShowCertLang As System.Windows.Forms.ComboBox
    Friend WithEvents lblTVScraperGlobalHeaderShowsLimit As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalCertifications As System.Windows.Forms.Label
    Friend WithEvents chkTVScraperShowCert As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowCert As System.Windows.Forms.CheckBox
    Friend WithEvents lblTVScraperGlobalOriginalTitle As System.Windows.Forms.Label
    Friend WithEvents chkTVScraperShowOriginalTitle As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowOriginalTitle As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowMPAA As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperUseDisplaySeasonEpisode As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperCleanFields As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVGeneralClickScrape As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVGeneralClickScrapeAsk As System.Windows.Forms.CheckBox
    Friend WithEvents lblTVScraperGlobalCreators As System.Windows.Forms.Label
    Friend WithEvents chkTVScraperShowCreators As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockShowCreators As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockSeasonPlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperSeasonPlot As System.Windows.Forms.CheckBox
    Friend WithEvents lblTVScraperGlobalHeaderSeasonsLock As System.Windows.Forms.Label
    Friend WithEvents lblTVScraperGlobalHeaderSeasons As System.Windows.Forms.Label
    Friend WithEvents chkTVScraperSeasonAired As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperEpisodeGuestStarsToActors As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVScraperSeasonTitle As System.Windows.Forms.CheckBox
    Friend WithEvents chkTVLockSeasonTitle As System.Windows.Forms.CheckBox
    Friend WithEvents gbTVGeneralMainWindowOpts As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetGeneralCustomScrapeButton As GroupBox
    Friend WithEvents tblMovieSetGeneralCustomScrapeButton As TableLayoutPanel
    Friend WithEvents cbMovieSetGeneralCustomScrapeButtonScrapeType As ComboBox
    Friend WithEvents cbMovieSetGeneralCustomScrapeButtonModifierType As ComboBox
    Friend WithEvents txtMovieSetGeneralCustomScrapeButtonScrapeType As Label
    Friend WithEvents txtMovieSetGeneralCustomScrapeButtonModifierType As Label
    Friend WithEvents rbMovieSetGeneralCustomScrapeButtonEnabled As RadioButton
    Friend WithEvents rbMovieSetGeneralCustomScrapeButtonDisabled As RadioButton
    Friend WithEvents gbTVGeneralCustomScrapeButton As GroupBox
    Friend WithEvents tblTVGeneralCustomScrapeButton As TableLayoutPanel
    Friend WithEvents cbTVGeneralCustomScrapeButtonScrapeType As ComboBox
    Friend WithEvents cbTVGeneralCustomScrapeButtonModifierType As ComboBox
    Friend WithEvents txtTVGeneralCustomScrapeButtonScrapeType As Label
    Friend WithEvents txtTVGeneralCustomScrapeButtonModifierType As Label
    Friend WithEvents rbTVGeneralCustomScrapeButtonEnabled As RadioButton
    Friend WithEvents rbTVGeneralCustomScrapeButtonDisabled As RadioButton
    Friend WithEvents lblTVScraperGlobalUserRating As Label
    Friend WithEvents chkTVScraperShowUserRating As CheckBox
    Friend WithEvents chkTVLockShowUserRating As CheckBox
    Friend WithEvents chkTVScraperEpisodeUserRating As CheckBox
    Friend WithEvents chkTVLockEpisodeUserRating As CheckBox
    Friend WithEvents chkTVScraperCastWithImg As CheckBox
    Friend WithEvents TableLayoutPanel14 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents CheckBox16 As CheckBox
    Friend WithEvents CheckBox17 As CheckBox
    Friend WithEvents CheckBox18 As CheckBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents CheckBox19 As CheckBox
    Friend WithEvents CheckBox20 As CheckBox
    Friend WithEvents CheckBox21 As CheckBox
    Friend WithEvents CheckBox22 As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboBox7 As ComboBox
    Friend WithEvents CheckBox23 As CheckBox
    Friend WithEvents CheckBox24 As CheckBox
    Friend WithEvents CheckBox25 As CheckBox
    Friend WithEvents CheckBox26 As CheckBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents TableLayoutPanel11 As TableLayoutPanel
    Friend WithEvents Label15 As Label
    Friend WithEvents ComboBox8 As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents CheckBox27 As CheckBox
    Friend WithEvents CheckBox28 As CheckBox
    Friend WithEvents CheckBox29 As CheckBox
    Friend WithEvents CheckBox30 As CheckBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents TableLayoutPanel13 As TableLayoutPanel
    Friend WithEvents CheckBox34 As CheckBox
    Friend WithEvents CheckBox35 As CheckBox
    Friend WithEvents CheckBox36 As CheckBox
    Friend WithEvents ComboBox10 As ComboBox
    Friend WithEvents CheckBox37 As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox10 As CheckBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents CheckBox11 As CheckBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents CheckBox12 As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents CheckBox13 As CheckBox
    Friend WithEvents CheckBox14 As CheckBox
    Friend WithEvents CheckBox15 As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents TableLayoutPanel12 As TableLayoutPanel
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents ComboBox9 As ComboBox
    Friend WithEvents CheckBox31 As CheckBox
    Friend WithEvents CheckBox32 As CheckBox
    Friend WithEvents CheckBox33 As CheckBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox9 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents TableLayoutPanel31 As TableLayoutPanel
    Friend WithEvents CheckBox69 As CheckBox
    Friend WithEvents TextBox44 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents TableLayoutPanel30 As TableLayoutPanel
    Friend WithEvents GroupBox17 As GroupBox
    Friend WithEvents TableLayoutPanel29 As TableLayoutPanel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TableLayoutPanel16 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel15 As TableLayoutPanel
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TableLayoutPanel20 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel18 As TableLayoutPanel
    Friend WithEvents Label46 As Label
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents TextBox18 As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents TextBox19 As TextBox
    Friend WithEvents TextBox20 As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents TextBox21 As TextBox
    Friend WithEvents TextBox22 As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents TextBox23 As TextBox
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TableLayoutPanel24 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel22 As TableLayoutPanel
    Friend WithEvents Label55 As Label
    Friend WithEvents TextBox25 As TextBox
    Friend WithEvents TextBox26 As TextBox
    Friend WithEvents TextBox27 As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents TextBox28 As TextBox
    Friend WithEvents TextBox29 As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents TextBox30 As TextBox
    Friend WithEvents TextBox31 As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents TextBox32 As TextBox
    Friend WithEvents TextBox33 As TextBox
    Friend WithEvents Label62 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents TableLayoutPanel23 As TableLayoutPanel
    Friend WithEvents CheckBox62 As CheckBox
    Friend WithEvents CheckBox63 As CheckBox
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents TableLayoutPanel28 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel26 As TableLayoutPanel
    Friend WithEvents Label64 As Label
    Friend WithEvents TextBox35 As TextBox
    Friend WithEvents TextBox36 As TextBox
    Friend WithEvents TextBox37 As TextBox
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents TextBox38 As TextBox
    Friend WithEvents TextBox39 As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents TextBox40 As TextBox
    Friend WithEvents TextBox41 As TextBox
    Friend WithEvents Label68 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents TextBox42 As TextBox
    Friend WithEvents TextBox43 As TextBox
    Friend WithEvents Label71 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents TableLayoutPanel25 As TableLayoutPanel
    Friend WithEvents CheckBox65 As CheckBox
    Friend WithEvents CheckBox66 As CheckBox
    Friend WithEvents TextBox34 As TextBox
    Friend WithEvents CheckBox64 As CheckBox
    Friend WithEvents GroupBox16 As GroupBox
    Friend WithEvents TableLayoutPanel27 As TableLayoutPanel
    Friend WithEvents CheckBox67 As CheckBox
    Friend WithEvents CheckBox68 As CheckBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox53 As CheckBox
    Friend WithEvents CheckBox43 As CheckBox
    Friend WithEvents Label34 As Label
    Friend WithEvents CheckBox52 As CheckBox
    Friend WithEvents CheckBox42 As CheckBox
    Friend WithEvents CheckBox56 As CheckBox
    Friend WithEvents CheckBox54 As CheckBox
    Friend WithEvents CheckBox55 As CheckBox
    Friend WithEvents CheckBox59 As CheckBox
    Friend WithEvents CheckBox40 As CheckBox
    Friend WithEvents TableLayoutPanel19 As TableLayoutPanel
    Friend WithEvents CheckBox57 As CheckBox
    Friend WithEvents CheckBox58 As CheckBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents CheckBox38 As CheckBox
    Friend WithEvents Label27 As Label
    Friend WithEvents CheckBox39 As CheckBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents CheckBox41 As CheckBox
    Friend WithEvents CheckBox44 As CheckBox
    Friend WithEvents CheckBox45 As CheckBox
    Friend WithEvents CheckBox46 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents TableLayoutPanel21 As TableLayoutPanel
    Friend WithEvents CheckBox60 As CheckBox
    Friend WithEvents CheckBox61 As CheckBox
    Friend WithEvents TextBox24 As TextBox
    Friend WithEvents CheckBox51 As CheckBox
    Friend WithEvents CheckBox47 As CheckBox
    Friend WithEvents CheckBox48 As CheckBox
    Friend WithEvents CheckBox49 As CheckBox
    Friend WithEvents CheckBox50 As CheckBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents TableLayoutPanel17 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class