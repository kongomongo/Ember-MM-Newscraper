<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovie_Data
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovie_Data))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.pnlSettingsMain = New System.Windows.Forms.Panel()
        Me.tblSettingsMain = New System.Windows.Forms.TableLayoutPanel()
        Me.gbScraperSettings = New System.Windows.Forms.GroupBox()
        Me.tblMovieScraperGlobalOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvSearchAdditional = New System.Windows.Forms.DataGridView()
        Me.dgvSearchInitial = New System.Windows.Forms.DataGridView()
        Me.lblSearchAdditional = New System.Windows.Forms.Label()
        Me.lblSearchInitial = New System.Windows.Forms.Label()
        Me.chkMovieLockCollectionID = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalHeaderLock = New System.Windows.Forms.Label()
        Me.lblMovieScraperGlobalHeaderLimit = New System.Windows.Forms.Label()
        Me.cbMovieScraperCertLang = New System.Windows.Forms.ComboBox()
        Me.chkMovieLockRating = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockTitle = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalTitle = New System.Windows.Forms.Label()
        Me.lblMovieScraperGlobalRating = New System.Windows.Forms.Label()
        Me.lblMovieScraperGlobalCollectionID = New System.Windows.Forms.Label()
        Me.lblMovieScraperGlobalLanguageA = New System.Windows.Forms.Label()
        Me.lblMovieScraperGlobalLanguageV = New System.Windows.Forms.Label()
        Me.lblMovieScraperGlobalCollections = New System.Windows.Forms.Label()
        Me.chkMovieLockLanguageA = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockLanguageV = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperTitle = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperRating = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperCollectionID = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockCollections = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalOriginalTitle = New System.Windows.Forms.Label()
        Me.chkMovieScraperOriginalTitle = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockOriginalTitle = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalYear = New System.Windows.Forms.Label()
        Me.chkMovieScraperYear = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockYear = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalReleaseDate = New System.Windows.Forms.Label()
        Me.chkMovieScraperRelease = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockReleaseDate = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalPlot = New System.Windows.Forms.Label()
        Me.chkMovieScraperPlot = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockPlot = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalOutline = New System.Windows.Forms.Label()
        Me.chkMovieScraperOutline = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockOutline = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalTagline = New System.Windows.Forms.Label()
        Me.chkMovieScraperTagline = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockTagline = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalTop250 = New System.Windows.Forms.Label()
        Me.chkMovieScraperTop250 = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockTop250 = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalMPAA = New System.Windows.Forms.Label()
        Me.chkMovieScraperMPAA = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockMPAA = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalCertifications = New System.Windows.Forms.Label()
        Me.chkMovieScraperCert = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockCert = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalRuntime = New System.Windows.Forms.Label()
        Me.chkMovieScraperRuntime = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockRuntime = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalStudios = New System.Windows.Forms.Label()
        Me.chkMovieScraperStudio = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockStudio = New System.Windows.Forms.CheckBox()
        Me.txtMovieScraperStudioLimit = New System.Windows.Forms.TextBox()
        Me.lblMovieScraperGlobalTags = New System.Windows.Forms.Label()
        Me.chkMovieScraperTags = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockTags = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalTrailer = New System.Windows.Forms.Label()
        Me.chkMovieScraperTrailer = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockTrailer = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalGenres = New System.Windows.Forms.Label()
        Me.chkMovieScraperGenre = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockGenre = New System.Windows.Forms.CheckBox()
        Me.txtMovieScraperGenreLimit = New System.Windows.Forms.TextBox()
        Me.lblMovieScraperGlobalActors = New System.Windows.Forms.Label()
        Me.chkMovieScraperCast = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockActors = New System.Windows.Forms.CheckBox()
        Me.txtMovieScraperCastLimit = New System.Windows.Forms.TextBox()
        Me.lblMovieScraperGlobalCountries = New System.Windows.Forms.Label()
        Me.chkMovieScraperCountry = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockCountry = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalDirectors = New System.Windows.Forms.Label()
        Me.chkMovieScraperDirector = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockDirector = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalCredits = New System.Windows.Forms.Label()
        Me.chkMovieScraperCredits = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockCredits = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperGlobalUserRating = New System.Windows.Forms.Label()
        Me.chkMovieScraperUserRating = New System.Windows.Forms.CheckBox()
        Me.chkMovieLockUserRating = New System.Windows.Forms.CheckBox()
        Me.dgvTitle = New System.Windows.Forms.DataGridView()
        Me.dgvOriginalTitle = New System.Windows.Forms.DataGridView()
        Me.dgvYear = New System.Windows.Forms.DataGridView()
        Me.dgvReleaseDate = New System.Windows.Forms.DataGridView()
        Me.dgvPlot = New System.Windows.Forms.DataGridView()
        Me.dgvOutline = New System.Windows.Forms.DataGridView()
        Me.dgvTagline = New System.Windows.Forms.DataGridView()
        Me.dgvRating = New System.Windows.Forms.DataGridView()
        Me.dgvUserRating = New System.Windows.Forms.DataGridView()
        Me.dgvTop250 = New System.Windows.Forms.DataGridView()
        Me.dgvMPAA = New System.Windows.Forms.DataGridView()
        Me.dgvCertifications = New System.Windows.Forms.DataGridView()
        Me.dgvRuntime = New System.Windows.Forms.DataGridView()
        Me.dgvTags = New System.Windows.Forms.DataGridView()
        Me.dgvTrailer = New System.Windows.Forms.DataGridView()
        Me.dgvGenres = New System.Windows.Forms.DataGridView()
        Me.dgvActors = New System.Windows.Forms.DataGridView()
        Me.dgvDirectors = New System.Windows.Forms.DataGridView()
        Me.dgvCredits = New System.Windows.Forms.DataGridView()
        Me.dgvCoutries = New System.Windows.Forms.DataGridView()
        Me.dgvStudios = New System.Windows.Forms.DataGridView()
        Me.dgvCollectionID = New System.Windows.Forms.DataGridView()
        Me.lblFields = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.gbMovieScraperCertificationOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieScraperCertificationOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieScraperCertOnlyValue = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperCertForMPAAFallback = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperCertForMPAA = New System.Windows.Forms.CheckBox()
        Me.txtMovieScraperMPAANotRated = New System.Windows.Forms.TextBox()
        Me.lblMovieScraperMPAANotRated = New System.Windows.Forms.Label()
        Me.gbMovieScraperMiscOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieScraperMiscOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieScraperCleanPlotOutline = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperCleanFields = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperStudioWithImg = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperCastWithImg = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperDetailView = New System.Windows.Forms.CheckBox()
        Me.lblMovieScraperOutlineLimit = New System.Windows.Forms.Label()
        Me.txtMovieScraperOutlineLimit = New System.Windows.Forms.TextBox()
        Me.chkMovieScraperPlotForOutline = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperXBMCTrailerFormat = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperPlotForOutlineIfEmpty = New System.Windows.Forms.CheckBox()
        Me.gbMovieScraperMetaDataOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieScraperMetaDataOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieScraperDefFIExtOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieScraperDefFIExtOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieScraperDefFIExtRemove = New System.Windows.Forms.Button()
        Me.txtMovieScraperDefFIExt = New System.Windows.Forms.TextBox()
        Me.btnMovieScraperDefFIExtEdit = New System.Windows.Forms.Button()
        Me.lstMovieScraperDefFIExt = New System.Windows.Forms.ListBox()
        Me.btnMovieScraperDefFIExtAdd = New System.Windows.Forms.Button()
        Me.lblMovieScraperDefFIExt = New System.Windows.Forms.Label()
        Me.chkMovieScraperMetaDataScan = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperMetaDataIFOScan = New System.Windows.Forms.CheckBox()
        Me.gbMovieScraperDurationFormatOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieScraperDurationFormatOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMovieScraperDurationRuntimeFormat = New System.Windows.Forms.Label()
        Me.chkMovieScraperUseMDDuration = New System.Windows.Forms.CheckBox()
        Me.txtMovieScraperDurationRuntimeFormat = New System.Windows.Forms.TextBox()
        Me.gbMovieScraperCollectionOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieScraperCollectionOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieScraperCollectionsYAMJCompatibleSets = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperCollectionsAuto = New System.Windows.Forms.CheckBox()
        Me.chkMovieScraperCollectionsExtendedInfo = New System.Windows.Forms.CheckBox()
        Me.pnlSettingsTop = New System.Windows.Forms.Panel()
        Me.tblSettingsTop = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSelectSetting = New System.Windows.Forms.Label()
        Me.cbSelectSetting = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlSettings.SuspendLayout()
        Me.pnlSettingsMain.SuspendLayout()
        Me.tblSettingsMain.SuspendLayout()
        Me.gbScraperSettings.SuspendLayout()
        Me.tblMovieScraperGlobalOpts.SuspendLayout()
        CType(Me.dgvSearchAdditional, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSearchInitial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOriginalTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReleaseDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOutline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTagline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUserRating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTop250, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMPAA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCertifications, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRuntime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTrailer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGenres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvActors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDirectors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCredits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCoutries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStudios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCollectionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMovieScraperCertificationOpts.SuspendLayout()
        Me.tblMovieScraperCertificationOpts.SuspendLayout()
        Me.gbMovieScraperMiscOpts.SuspendLayout()
        Me.tblMovieScraperMiscOpts.SuspendLayout()
        Me.gbMovieScraperMetaDataOpts.SuspendLayout()
        Me.tblMovieScraperMetaDataOpts.SuspendLayout()
        Me.gbMovieScraperDefFIExtOpts.SuspendLayout()
        Me.tblMovieScraperDefFIExtOpts.SuspendLayout()
        Me.gbMovieScraperDurationFormatOpts.SuspendLayout()
        Me.tblMovieScraperDurationFormatOpts.SuspendLayout()
        Me.gbMovieScraperCollectionOpts.SuspendLayout()
        Me.tblMovieScraperCollectionOpts.SuspendLayout()
        Me.pnlSettingsTop.SuspendLayout()
        Me.tblSettingsTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.BackColor = System.Drawing.Color.White
        Me.pnlSettings.Controls.Add(Me.pnlSettingsMain)
        Me.pnlSettings.Controls.Add(Me.pnlSettingsTop)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(932, 721)
        Me.pnlSettings.TabIndex = 15
        Me.pnlSettings.Visible = False
        '
        'pnlSettingsMain
        '
        Me.pnlSettingsMain.AutoSize = True
        Me.pnlSettingsMain.Controls.Add(Me.tblSettingsMain)
        Me.pnlSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsMain.Location = New System.Drawing.Point(0, 29)
        Me.pnlSettingsMain.Name = "pnlSettingsMain"
        Me.pnlSettingsMain.Size = New System.Drawing.Size(932, 692)
        Me.pnlSettingsMain.TabIndex = 71
        '
        'tblSettingsMain
        '
        Me.tblSettingsMain.AutoScroll = True
        Me.tblSettingsMain.AutoSize = True
        Me.tblSettingsMain.ColumnCount = 3
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.Controls.Add(Me.gbScraperSettings, 0, 0)
        Me.tblSettingsMain.Controls.Add(Me.gbMovieScraperCertificationOpts, 1, 2)
        Me.tblSettingsMain.Controls.Add(Me.gbMovieScraperMiscOpts, 1, 1)
        Me.tblSettingsMain.Controls.Add(Me.gbMovieScraperMetaDataOpts, 1, 0)
        Me.tblSettingsMain.Controls.Add(Me.gbMovieScraperCollectionOpts, 1, 3)
        Me.tblSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsMain.Name = "tblSettingsMain"
        Me.tblSettingsMain.RowCount = 5
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.Size = New System.Drawing.Size(932, 692)
        Me.tblSettingsMain.TabIndex = 69
        '
        'gbScraperSettings
        '
        Me.gbScraperSettings.AutoSize = True
        Me.gbScraperSettings.Controls.Add(Me.tblMovieScraperGlobalOpts)
        Me.gbScraperSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbScraperSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbScraperSettings.Location = New System.Drawing.Point(3, 3)
        Me.gbScraperSettings.Name = "gbScraperSettings"
        Me.tblSettingsMain.SetRowSpan(Me.gbScraperSettings, 4)
        Me.gbScraperSettings.Size = New System.Drawing.Size(343, 673)
        Me.gbScraperSettings.TabIndex = 1
        Me.gbScraperSettings.TabStop = False
        Me.gbScraperSettings.Text = "Scraper Settings"
        '
        'tblMovieScraperGlobalOpts
        '
        Me.tblMovieScraperGlobalOpts.AutoScroll = True
        Me.tblMovieScraperGlobalOpts.AutoSize = True
        Me.tblMovieScraperGlobalOpts.ColumnCount = 6
        Me.tblMovieScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperGlobalOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvSearchAdditional, 4, 2)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvSearchInitial, 4, 1)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblSearchAdditional, 0, 2)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblSearchInitial, 0, 1)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockCollectionID, 2, 25)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalHeaderLock, 2, 3)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalHeaderLimit, 3, 3)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.cbMovieScraperCertLang, 3, 15)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockRating, 2, 11)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockTitle, 2, 4)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalTitle, 0, 4)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalRating, 0, 11)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalCollectionID, 0, 25)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalLanguageA, 0, 27)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalLanguageV, 0, 28)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalCollections, 0, 26)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockLanguageA, 2, 27)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockLanguageV, 2, 28)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperTitle, 1, 4)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperRating, 1, 11)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperCollectionID, 1, 25)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockCollections, 2, 26)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalOriginalTitle, 0, 5)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperOriginalTitle, 1, 5)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockOriginalTitle, 2, 5)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalYear, 0, 6)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperYear, 1, 6)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockYear, 2, 6)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalReleaseDate, 0, 7)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperRelease, 1, 7)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockReleaseDate, 2, 7)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalPlot, 0, 8)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperPlot, 1, 8)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockPlot, 2, 8)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalOutline, 0, 9)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperOutline, 1, 9)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockOutline, 2, 9)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalTagline, 0, 10)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperTagline, 1, 10)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockTagline, 2, 10)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalTop250, 0, 13)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperTop250, 1, 13)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockTop250, 2, 13)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalMPAA, 0, 14)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperMPAA, 1, 14)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockMPAA, 2, 14)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalCertifications, 0, 15)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperCert, 1, 15)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockCert, 2, 15)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalRuntime, 0, 16)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperRuntime, 1, 16)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockRuntime, 2, 16)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalStudios, 0, 24)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperStudio, 1, 24)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockStudio, 2, 24)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.txtMovieScraperStudioLimit, 3, 24)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalTags, 0, 17)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperTags, 1, 17)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockTags, 2, 17)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalTrailer, 0, 18)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperTrailer, 1, 18)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockTrailer, 2, 18)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalGenres, 0, 19)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperGenre, 1, 19)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockGenre, 2, 19)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.txtMovieScraperGenreLimit, 3, 19)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalActors, 0, 20)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperCast, 1, 20)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockActors, 2, 20)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.txtMovieScraperCastLimit, 3, 20)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalCountries, 0, 23)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperCountry, 1, 23)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockCountry, 2, 23)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalDirectors, 0, 21)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperDirector, 1, 21)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockDirector, 2, 21)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalCredits, 0, 22)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperCredits, 1, 22)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockCredits, 2, 22)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblMovieScraperGlobalUserRating, 0, 12)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieScraperUserRating, 1, 12)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.chkMovieLockUserRating, 2, 12)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvTitle, 4, 4)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvOriginalTitle, 4, 5)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvYear, 4, 6)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvReleaseDate, 4, 7)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvPlot, 4, 8)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvOutline, 4, 9)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvTagline, 4, 10)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvRating, 4, 11)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvUserRating, 4, 12)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvTop250, 4, 13)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvMPAA, 4, 14)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvCertifications, 4, 15)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvRuntime, 4, 16)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvTags, 4, 17)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvTrailer, 4, 18)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvGenres, 4, 19)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvActors, 4, 20)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvDirectors, 4, 21)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvCredits, 4, 22)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvCoutries, 4, 23)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvStudios, 4, 24)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.dgvCollectionID, 4, 25)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblFields, 0, 3)
        Me.tblMovieScraperGlobalOpts.Controls.Add(Me.lblSearch, 0, 0)
        Me.tblMovieScraperGlobalOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieScraperGlobalOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieScraperGlobalOpts.Name = "tblMovieScraperGlobalOpts"
        Me.tblMovieScraperGlobalOpts.RowCount = 30
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperGlobalOpts.Size = New System.Drawing.Size(337, 652)
        Me.tblMovieScraperGlobalOpts.TabIndex = 0
        '
        'dgvSearchAdditional
        '
        Me.dgvSearchAdditional.Location = New System.Drawing.Point(237, 43)
        Me.dgvSearchAdditional.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvSearchAdditional.Name = "dgvSearchAdditional"
        Me.dgvSearchAdditional.Size = New System.Drawing.Size(100, 23)
        Me.dgvSearchAdditional.TabIndex = 70
        '
        'dgvSearchInitial
        '
        Me.dgvSearchInitial.Location = New System.Drawing.Point(237, 20)
        Me.dgvSearchInitial.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvSearchInitial.Name = "dgvSearchInitial"
        Me.dgvSearchInitial.Size = New System.Drawing.Size(100, 23)
        Me.dgvSearchInitial.TabIndex = 70
        '
        'lblSearchAdditional
        '
        Me.lblSearchAdditional.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSearchAdditional.AutoSize = True
        Me.lblSearchAdditional.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchAdditional.Location = New System.Drawing.Point(3, 48)
        Me.lblSearchAdditional.Name = "lblSearchAdditional"
        Me.lblSearchAdditional.Size = New System.Drawing.Size(90, 13)
        Me.lblSearchAdditional.TabIndex = 0
        Me.lblSearchAdditional.Text = "Additional Search"
        '
        'lblSearchInitial
        '
        Me.lblSearchInitial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSearchInitial.AutoSize = True
        Me.lblSearchInitial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchInitial.Location = New System.Drawing.Point(3, 25)
        Me.lblSearchInitial.Name = "lblSearchInitial"
        Me.lblSearchInitial.Size = New System.Drawing.Size(68, 13)
        Me.lblSearchInitial.TabIndex = 0
        Me.lblSearchInitial.Text = "Initial Search"
        '
        'chkMovieLockCollectionID
        '
        Me.chkMovieLockCollectionID.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockCollectionID.AutoSize = True
        Me.chkMovieLockCollectionID.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockCollectionID.Location = New System.Drawing.Point(135, 573)
        Me.chkMovieLockCollectionID.Name = "chkMovieLockCollectionID"
        Me.chkMovieLockCollectionID.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockCollectionID.TabIndex = 5
        Me.chkMovieLockCollectionID.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalHeaderLock
        '
        Me.lblMovieScraperGlobalHeaderLock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMovieScraperGlobalHeaderLock.AutoSize = True
        Me.lblMovieScraperGlobalHeaderLock.Location = New System.Drawing.Point(127, 69)
        Me.lblMovieScraperGlobalHeaderLock.Name = "lblMovieScraperGlobalHeaderLock"
        Me.lblMovieScraperGlobalHeaderLock.Size = New System.Drawing.Size(31, 13)
        Me.lblMovieScraperGlobalHeaderLock.TabIndex = 12
        Me.lblMovieScraperGlobalHeaderLock.Text = "Lock"
        '
        'lblMovieScraperGlobalHeaderLimit
        '
        Me.lblMovieScraperGlobalHeaderLimit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMovieScraperGlobalHeaderLimit.AutoSize = True
        Me.lblMovieScraperGlobalHeaderLimit.Location = New System.Drawing.Point(182, 69)
        Me.lblMovieScraperGlobalHeaderLimit.Name = "lblMovieScraperGlobalHeaderLimit"
        Me.lblMovieScraperGlobalHeaderLimit.Size = New System.Drawing.Size(33, 13)
        Me.lblMovieScraperGlobalHeaderLimit.TabIndex = 14
        Me.lblMovieScraperGlobalHeaderLimit.Text = "Limit"
        '
        'cbMovieScraperCertLang
        '
        Me.cbMovieScraperCertLang.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbMovieScraperCertLang.DropDownHeight = 200
        Me.cbMovieScraperCertLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovieScraperCertLang.DropDownWidth = 110
        Me.cbMovieScraperCertLang.Enabled = False
        Me.cbMovieScraperCertLang.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbMovieScraperCertLang.FormattingEnabled = True
        Me.cbMovieScraperCertLang.IntegralHeight = False
        Me.cbMovieScraperCertLang.Items.AddRange(New Object() {"Argentina", "Australia", "Belgium", "Brazil", "Canada", "Finland", "France", "Germany", "Hong Kong", "Hungary", "Iceland", "Ireland", "Netherlands", "New Zealand", "Peru", "Poland", "Portugal", "Serbia", "Singapore", "South Korea", "Spain", "Sweden", "Switzerland", "Turkey", "UK", "USA"})
        Me.cbMovieScraperCertLang.Location = New System.Drawing.Point(164, 339)
        Me.cbMovieScraperCertLang.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbMovieScraperCertLang.Name = "cbMovieScraperCertLang"
        Me.cbMovieScraperCertLang.Size = New System.Drawing.Size(70, 21)
        Me.cbMovieScraperCertLang.Sorted = True
        Me.cbMovieScraperCertLang.TabIndex = 5
        '
        'chkMovieLockRating
        '
        Me.chkMovieLockRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockRating.AutoSize = True
        Me.chkMovieLockRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockRating.Location = New System.Drawing.Point(135, 251)
        Me.chkMovieLockRating.Name = "chkMovieLockRating"
        Me.chkMovieLockRating.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockRating.TabIndex = 4
        Me.chkMovieLockRating.UseVisualStyleBackColor = True
        '
        'chkMovieLockTitle
        '
        Me.chkMovieLockTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockTitle.Location = New System.Drawing.Point(135, 89)
        Me.chkMovieLockTitle.Name = "chkMovieLockTitle"
        Me.chkMovieLockTitle.Size = New System.Drawing.Size(14, 17)
        Me.chkMovieLockTitle.TabIndex = 3
        Me.chkMovieLockTitle.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalTitle
        '
        Me.lblMovieScraperGlobalTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalTitle.AutoSize = True
        Me.lblMovieScraperGlobalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalTitle.Location = New System.Drawing.Point(3, 91)
        Me.lblMovieScraperGlobalTitle.Name = "lblMovieScraperGlobalTitle"
        Me.lblMovieScraperGlobalTitle.Size = New System.Drawing.Size(28, 13)
        Me.lblMovieScraperGlobalTitle.TabIndex = 67
        Me.lblMovieScraperGlobalTitle.Text = "Title"
        '
        'lblMovieScraperGlobalRating
        '
        Me.lblMovieScraperGlobalRating.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalRating.AutoSize = True
        Me.lblMovieScraperGlobalRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalRating.Location = New System.Drawing.Point(3, 252)
        Me.lblMovieScraperGlobalRating.Name = "lblMovieScraperGlobalRating"
        Me.lblMovieScraperGlobalRating.Size = New System.Drawing.Size(41, 13)
        Me.lblMovieScraperGlobalRating.TabIndex = 68
        Me.lblMovieScraperGlobalRating.Text = "Rating"
        '
        'lblMovieScraperGlobalCollectionID
        '
        Me.lblMovieScraperGlobalCollectionID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalCollectionID.AutoSize = True
        Me.lblMovieScraperGlobalCollectionID.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalCollectionID.Location = New System.Drawing.Point(3, 574)
        Me.lblMovieScraperGlobalCollectionID.Name = "lblMovieScraperGlobalCollectionID"
        Me.lblMovieScraperGlobalCollectionID.Size = New System.Drawing.Size(73, 13)
        Me.lblMovieScraperGlobalCollectionID.TabIndex = 68
        Me.lblMovieScraperGlobalCollectionID.Text = "Collection ID"
        '
        'lblMovieScraperGlobalLanguageA
        '
        Me.lblMovieScraperGlobalLanguageA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalLanguageA.AutoSize = True
        Me.lblMovieScraperGlobalLanguageA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalLanguageA.Location = New System.Drawing.Point(3, 615)
        Me.lblMovieScraperGlobalLanguageA.Name = "lblMovieScraperGlobalLanguageA"
        Me.lblMovieScraperGlobalLanguageA.Size = New System.Drawing.Size(97, 13)
        Me.lblMovieScraperGlobalLanguageA.TabIndex = 68
        Me.lblMovieScraperGlobalLanguageA.Text = "Language (audio)"
        '
        'lblMovieScraperGlobalLanguageV
        '
        Me.lblMovieScraperGlobalLanguageV.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalLanguageV.AutoSize = True
        Me.lblMovieScraperGlobalLanguageV.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalLanguageV.Location = New System.Drawing.Point(3, 635)
        Me.lblMovieScraperGlobalLanguageV.Name = "lblMovieScraperGlobalLanguageV"
        Me.lblMovieScraperGlobalLanguageV.Size = New System.Drawing.Size(95, 13)
        Me.lblMovieScraperGlobalLanguageV.TabIndex = 68
        Me.lblMovieScraperGlobalLanguageV.Text = "Language (video)"
        '
        'lblMovieScraperGlobalCollections
        '
        Me.lblMovieScraperGlobalCollections.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalCollections.AutoSize = True
        Me.lblMovieScraperGlobalCollections.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalCollections.Location = New System.Drawing.Point(3, 595)
        Me.lblMovieScraperGlobalCollections.Name = "lblMovieScraperGlobalCollections"
        Me.lblMovieScraperGlobalCollections.Size = New System.Drawing.Size(64, 13)
        Me.lblMovieScraperGlobalCollections.TabIndex = 68
        Me.lblMovieScraperGlobalCollections.Text = "Collections"
        '
        'chkMovieLockLanguageA
        '
        Me.chkMovieLockLanguageA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockLanguageA.AutoSize = True
        Me.chkMovieLockLanguageA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockLanguageA.Location = New System.Drawing.Point(135, 615)
        Me.chkMovieLockLanguageA.Name = "chkMovieLockLanguageA"
        Me.chkMovieLockLanguageA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockLanguageA.TabIndex = 48
        Me.chkMovieLockLanguageA.UseVisualStyleBackColor = True
        '
        'chkMovieLockLanguageV
        '
        Me.chkMovieLockLanguageV.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockLanguageV.AutoSize = True
        Me.chkMovieLockLanguageV.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockLanguageV.Location = New System.Drawing.Point(135, 635)
        Me.chkMovieLockLanguageV.Name = "chkMovieLockLanguageV"
        Me.chkMovieLockLanguageV.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockLanguageV.TabIndex = 47
        Me.chkMovieLockLanguageV.UseVisualStyleBackColor = True
        '
        'chkMovieScraperTitle
        '
        Me.chkMovieScraperTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperTitle.AutoSize = True
        Me.chkMovieScraperTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperTitle.Location = New System.Drawing.Point(106, 90)
        Me.chkMovieScraperTitle.Name = "chkMovieScraperTitle"
        Me.chkMovieScraperTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperTitle.TabIndex = 0
        Me.chkMovieScraperTitle.UseVisualStyleBackColor = True
        '
        'chkMovieScraperRating
        '
        Me.chkMovieScraperRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperRating.AutoSize = True
        Me.chkMovieScraperRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperRating.Location = New System.Drawing.Point(106, 251)
        Me.chkMovieScraperRating.Name = "chkMovieScraperRating"
        Me.chkMovieScraperRating.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperRating.TabIndex = 4
        Me.chkMovieScraperRating.UseVisualStyleBackColor = True
        '
        'chkMovieScraperCollectionID
        '
        Me.chkMovieScraperCollectionID.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperCollectionID.AutoSize = True
        Me.chkMovieScraperCollectionID.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCollectionID.Location = New System.Drawing.Point(106, 573)
        Me.chkMovieScraperCollectionID.Name = "chkMovieScraperCollectionID"
        Me.chkMovieScraperCollectionID.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperCollectionID.TabIndex = 26
        Me.chkMovieScraperCollectionID.UseVisualStyleBackColor = True
        '
        'chkMovieLockCollections
        '
        Me.chkMovieLockCollections.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockCollections.AutoSize = True
        Me.chkMovieLockCollections.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockCollections.Location = New System.Drawing.Point(135, 595)
        Me.chkMovieLockCollections.Name = "chkMovieLockCollections"
        Me.chkMovieLockCollections.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockCollections.TabIndex = 66
        Me.chkMovieLockCollections.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalOriginalTitle
        '
        Me.lblMovieScraperGlobalOriginalTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalOriginalTitle.AutoSize = True
        Me.lblMovieScraperGlobalOriginalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalOriginalTitle.Location = New System.Drawing.Point(3, 114)
        Me.lblMovieScraperGlobalOriginalTitle.Name = "lblMovieScraperGlobalOriginalTitle"
        Me.lblMovieScraperGlobalOriginalTitle.Size = New System.Drawing.Size(73, 13)
        Me.lblMovieScraperGlobalOriginalTitle.TabIndex = 68
        Me.lblMovieScraperGlobalOriginalTitle.Text = "Original Title"
        '
        'chkMovieScraperOriginalTitle
        '
        Me.chkMovieScraperOriginalTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperOriginalTitle.AutoSize = True
        Me.chkMovieScraperOriginalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperOriginalTitle.Location = New System.Drawing.Point(106, 113)
        Me.chkMovieScraperOriginalTitle.Name = "chkMovieScraperOriginalTitle"
        Me.chkMovieScraperOriginalTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperOriginalTitle.TabIndex = 29
        Me.chkMovieScraperOriginalTitle.UseVisualStyleBackColor = True
        '
        'chkMovieLockOriginalTitle
        '
        Me.chkMovieLockOriginalTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockOriginalTitle.AutoSize = True
        Me.chkMovieLockOriginalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockOriginalTitle.Location = New System.Drawing.Point(135, 113)
        Me.chkMovieLockOriginalTitle.Name = "chkMovieLockOriginalTitle"
        Me.chkMovieLockOriginalTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockOriginalTitle.TabIndex = 65
        Me.chkMovieLockOriginalTitle.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalYear
        '
        Me.lblMovieScraperGlobalYear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalYear.AutoSize = True
        Me.lblMovieScraperGlobalYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalYear.Location = New System.Drawing.Point(3, 137)
        Me.lblMovieScraperGlobalYear.Name = "lblMovieScraperGlobalYear"
        Me.lblMovieScraperGlobalYear.Size = New System.Drawing.Size(27, 13)
        Me.lblMovieScraperGlobalYear.TabIndex = 68
        Me.lblMovieScraperGlobalYear.Text = "Year"
        '
        'chkMovieScraperYear
        '
        Me.chkMovieScraperYear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperYear.AutoSize = True
        Me.chkMovieScraperYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperYear.Location = New System.Drawing.Point(106, 136)
        Me.chkMovieScraperYear.Name = "chkMovieScraperYear"
        Me.chkMovieScraperYear.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperYear.TabIndex = 1
        Me.chkMovieScraperYear.UseVisualStyleBackColor = True
        '
        'chkMovieLockYear
        '
        Me.chkMovieLockYear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockYear.AutoSize = True
        Me.chkMovieLockYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockYear.Location = New System.Drawing.Point(135, 136)
        Me.chkMovieLockYear.Name = "chkMovieLockYear"
        Me.chkMovieLockYear.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockYear.TabIndex = 52
        Me.chkMovieLockYear.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalReleaseDate
        '
        Me.lblMovieScraperGlobalReleaseDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalReleaseDate.AutoSize = True
        Me.lblMovieScraperGlobalReleaseDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalReleaseDate.Location = New System.Drawing.Point(3, 160)
        Me.lblMovieScraperGlobalReleaseDate.Name = "lblMovieScraperGlobalReleaseDate"
        Me.lblMovieScraperGlobalReleaseDate.Size = New System.Drawing.Size(73, 13)
        Me.lblMovieScraperGlobalReleaseDate.TabIndex = 68
        Me.lblMovieScraperGlobalReleaseDate.Text = "Release Date"
        '
        'chkMovieScraperRelease
        '
        Me.chkMovieScraperRelease.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperRelease.AutoSize = True
        Me.chkMovieScraperRelease.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperRelease.Location = New System.Drawing.Point(106, 159)
        Me.chkMovieScraperRelease.Name = "chkMovieScraperRelease"
        Me.chkMovieScraperRelease.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperRelease.TabIndex = 3
        Me.chkMovieScraperRelease.UseVisualStyleBackColor = True
        '
        'chkMovieLockReleaseDate
        '
        Me.chkMovieLockReleaseDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockReleaseDate.AutoSize = True
        Me.chkMovieLockReleaseDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockReleaseDate.Location = New System.Drawing.Point(135, 159)
        Me.chkMovieLockReleaseDate.Name = "chkMovieLockReleaseDate"
        Me.chkMovieLockReleaseDate.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockReleaseDate.TabIndex = 55
        Me.chkMovieLockReleaseDate.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalPlot
        '
        Me.lblMovieScraperGlobalPlot.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalPlot.AutoSize = True
        Me.lblMovieScraperGlobalPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalPlot.Location = New System.Drawing.Point(3, 183)
        Me.lblMovieScraperGlobalPlot.Name = "lblMovieScraperGlobalPlot"
        Me.lblMovieScraperGlobalPlot.Size = New System.Drawing.Size(27, 13)
        Me.lblMovieScraperGlobalPlot.TabIndex = 68
        Me.lblMovieScraperGlobalPlot.Text = "Plot"
        '
        'chkMovieScraperPlot
        '
        Me.chkMovieScraperPlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperPlot.AutoSize = True
        Me.chkMovieScraperPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperPlot.Location = New System.Drawing.Point(106, 182)
        Me.chkMovieScraperPlot.Name = "chkMovieScraperPlot"
        Me.chkMovieScraperPlot.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperPlot.TabIndex = 12
        Me.chkMovieScraperPlot.UseVisualStyleBackColor = True
        '
        'chkMovieLockPlot
        '
        Me.chkMovieLockPlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockPlot.AutoSize = True
        Me.chkMovieLockPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockPlot.Location = New System.Drawing.Point(135, 182)
        Me.chkMovieLockPlot.Name = "chkMovieLockPlot"
        Me.chkMovieLockPlot.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockPlot.TabIndex = 0
        Me.chkMovieLockPlot.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalOutline
        '
        Me.lblMovieScraperGlobalOutline.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalOutline.AutoSize = True
        Me.lblMovieScraperGlobalOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalOutline.Location = New System.Drawing.Point(3, 206)
        Me.lblMovieScraperGlobalOutline.Name = "lblMovieScraperGlobalOutline"
        Me.lblMovieScraperGlobalOutline.Size = New System.Drawing.Size(46, 13)
        Me.lblMovieScraperGlobalOutline.TabIndex = 68
        Me.lblMovieScraperGlobalOutline.Text = "Outline"
        '
        'chkMovieScraperOutline
        '
        Me.chkMovieScraperOutline.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperOutline.AutoSize = True
        Me.chkMovieScraperOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperOutline.Location = New System.Drawing.Point(106, 205)
        Me.chkMovieScraperOutline.Name = "chkMovieScraperOutline"
        Me.chkMovieScraperOutline.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperOutline.TabIndex = 11
        Me.chkMovieScraperOutline.UseVisualStyleBackColor = True
        '
        'chkMovieLockOutline
        '
        Me.chkMovieLockOutline.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockOutline.AutoSize = True
        Me.chkMovieLockOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockOutline.Location = New System.Drawing.Point(135, 205)
        Me.chkMovieLockOutline.Name = "chkMovieLockOutline"
        Me.chkMovieLockOutline.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockOutline.TabIndex = 1
        Me.chkMovieLockOutline.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalTagline
        '
        Me.lblMovieScraperGlobalTagline.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalTagline.AutoSize = True
        Me.lblMovieScraperGlobalTagline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalTagline.Location = New System.Drawing.Point(3, 229)
        Me.lblMovieScraperGlobalTagline.Name = "lblMovieScraperGlobalTagline"
        Me.lblMovieScraperGlobalTagline.Size = New System.Drawing.Size(43, 13)
        Me.lblMovieScraperGlobalTagline.TabIndex = 68
        Me.lblMovieScraperGlobalTagline.Text = "Tagline"
        '
        'chkMovieScraperTagline
        '
        Me.chkMovieScraperTagline.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperTagline.AutoSize = True
        Me.chkMovieScraperTagline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperTagline.Location = New System.Drawing.Point(106, 228)
        Me.chkMovieScraperTagline.Name = "chkMovieScraperTagline"
        Me.chkMovieScraperTagline.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperTagline.TabIndex = 8
        Me.chkMovieScraperTagline.UseVisualStyleBackColor = True
        '
        'chkMovieLockTagline
        '
        Me.chkMovieLockTagline.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockTagline.AutoSize = True
        Me.chkMovieLockTagline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockTagline.Location = New System.Drawing.Point(135, 228)
        Me.chkMovieLockTagline.Name = "chkMovieLockTagline"
        Me.chkMovieLockTagline.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockTagline.TabIndex = 3
        Me.chkMovieLockTagline.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalTop250
        '
        Me.lblMovieScraperGlobalTop250.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalTop250.AutoSize = True
        Me.lblMovieScraperGlobalTop250.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalTop250.Location = New System.Drawing.Point(3, 298)
        Me.lblMovieScraperGlobalTop250.Name = "lblMovieScraperGlobalTop250"
        Me.lblMovieScraperGlobalTop250.Size = New System.Drawing.Size(46, 13)
        Me.lblMovieScraperGlobalTop250.TabIndex = 68
        Me.lblMovieScraperGlobalTop250.Text = "Top 250"
        '
        'chkMovieScraperTop250
        '
        Me.chkMovieScraperTop250.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperTop250.AutoSize = True
        Me.chkMovieScraperTop250.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperTop250.Location = New System.Drawing.Point(106, 297)
        Me.chkMovieScraperTop250.Name = "chkMovieScraperTop250"
        Me.chkMovieScraperTop250.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperTop250.TabIndex = 23
        Me.chkMovieScraperTop250.UseVisualStyleBackColor = True
        '
        'chkMovieLockTop250
        '
        Me.chkMovieLockTop250.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockTop250.AutoSize = True
        Me.chkMovieLockTop250.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockTop250.Location = New System.Drawing.Point(135, 297)
        Me.chkMovieLockTop250.Name = "chkMovieLockTop250"
        Me.chkMovieLockTop250.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockTop250.TabIndex = 61
        Me.chkMovieLockTop250.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalMPAA
        '
        Me.lblMovieScraperGlobalMPAA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalMPAA.AutoSize = True
        Me.lblMovieScraperGlobalMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalMPAA.Location = New System.Drawing.Point(3, 321)
        Me.lblMovieScraperGlobalMPAA.Name = "lblMovieScraperGlobalMPAA"
        Me.lblMovieScraperGlobalMPAA.Size = New System.Drawing.Size(36, 13)
        Me.lblMovieScraperGlobalMPAA.TabIndex = 68
        Me.lblMovieScraperGlobalMPAA.Text = "MPAA"
        '
        'chkMovieScraperMPAA
        '
        Me.chkMovieScraperMPAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperMPAA.AutoSize = True
        Me.chkMovieScraperMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperMPAA.Location = New System.Drawing.Point(106, 320)
        Me.chkMovieScraperMPAA.Name = "chkMovieScraperMPAA"
        Me.chkMovieScraperMPAA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperMPAA.TabIndex = 24
        Me.chkMovieScraperMPAA.UseVisualStyleBackColor = True
        '
        'chkMovieLockMPAA
        '
        Me.chkMovieLockMPAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockMPAA.AutoSize = True
        Me.chkMovieLockMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockMPAA.Location = New System.Drawing.Point(135, 320)
        Me.chkMovieLockMPAA.Name = "chkMovieLockMPAA"
        Me.chkMovieLockMPAA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockMPAA.TabIndex = 49
        Me.chkMovieLockMPAA.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalCertifications
        '
        Me.lblMovieScraperGlobalCertifications.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalCertifications.AutoSize = True
        Me.lblMovieScraperGlobalCertifications.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalCertifications.Location = New System.Drawing.Point(3, 344)
        Me.lblMovieScraperGlobalCertifications.Name = "lblMovieScraperGlobalCertifications"
        Me.lblMovieScraperGlobalCertifications.Size = New System.Drawing.Size(75, 13)
        Me.lblMovieScraperGlobalCertifications.TabIndex = 68
        Me.lblMovieScraperGlobalCertifications.Text = "Certifications"
        '
        'chkMovieScraperCert
        '
        Me.chkMovieScraperCert.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperCert.AutoSize = True
        Me.chkMovieScraperCert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCert.Location = New System.Drawing.Point(106, 343)
        Me.chkMovieScraperCert.Name = "chkMovieScraperCert"
        Me.chkMovieScraperCert.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperCert.TabIndex = 24
        Me.chkMovieScraperCert.UseVisualStyleBackColor = True
        '
        'chkMovieLockCert
        '
        Me.chkMovieLockCert.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockCert.AutoSize = True
        Me.chkMovieLockCert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockCert.Location = New System.Drawing.Point(135, 343)
        Me.chkMovieLockCert.Name = "chkMovieLockCert"
        Me.chkMovieLockCert.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockCert.TabIndex = 49
        Me.chkMovieLockCert.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalRuntime
        '
        Me.lblMovieScraperGlobalRuntime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalRuntime.AutoSize = True
        Me.lblMovieScraperGlobalRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalRuntime.Location = New System.Drawing.Point(3, 367)
        Me.lblMovieScraperGlobalRuntime.Name = "lblMovieScraperGlobalRuntime"
        Me.lblMovieScraperGlobalRuntime.Size = New System.Drawing.Size(50, 13)
        Me.lblMovieScraperGlobalRuntime.TabIndex = 68
        Me.lblMovieScraperGlobalRuntime.Text = "Runtime"
        '
        'chkMovieScraperRuntime
        '
        Me.chkMovieScraperRuntime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperRuntime.AutoSize = True
        Me.chkMovieScraperRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperRuntime.Location = New System.Drawing.Point(106, 366)
        Me.chkMovieScraperRuntime.Name = "chkMovieScraperRuntime"
        Me.chkMovieScraperRuntime.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperRuntime.TabIndex = 13
        Me.chkMovieScraperRuntime.UseVisualStyleBackColor = True
        '
        'chkMovieLockRuntime
        '
        Me.chkMovieLockRuntime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockRuntime.AutoSize = True
        Me.chkMovieLockRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockRuntime.Location = New System.Drawing.Point(135, 366)
        Me.chkMovieLockRuntime.Name = "chkMovieLockRuntime"
        Me.chkMovieLockRuntime.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockRuntime.TabIndex = 51
        Me.chkMovieLockRuntime.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalStudios
        '
        Me.lblMovieScraperGlobalStudios.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalStudios.AutoSize = True
        Me.lblMovieScraperGlobalStudios.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalStudios.Location = New System.Drawing.Point(3, 551)
        Me.lblMovieScraperGlobalStudios.Name = "lblMovieScraperGlobalStudios"
        Me.lblMovieScraperGlobalStudios.Size = New System.Drawing.Size(46, 13)
        Me.lblMovieScraperGlobalStudios.TabIndex = 68
        Me.lblMovieScraperGlobalStudios.Text = "Studios"
        '
        'chkMovieScraperStudio
        '
        Me.chkMovieScraperStudio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperStudio.AutoSize = True
        Me.chkMovieScraperStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperStudio.Location = New System.Drawing.Point(106, 550)
        Me.chkMovieScraperStudio.Name = "chkMovieScraperStudio"
        Me.chkMovieScraperStudio.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperStudio.TabIndex = 14
        Me.chkMovieScraperStudio.UseVisualStyleBackColor = True
        '
        'chkMovieLockStudio
        '
        Me.chkMovieLockStudio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockStudio.AutoSize = True
        Me.chkMovieLockStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockStudio.Location = New System.Drawing.Point(135, 550)
        Me.chkMovieLockStudio.Name = "chkMovieLockStudio"
        Me.chkMovieLockStudio.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockStudio.TabIndex = 54
        Me.chkMovieLockStudio.UseVisualStyleBackColor = True
        '
        'txtMovieScraperStudioLimit
        '
        Me.txtMovieScraperStudioLimit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMovieScraperStudioLimit.Enabled = False
        Me.txtMovieScraperStudioLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieScraperStudioLimit.Location = New System.Drawing.Point(179, 546)
        Me.txtMovieScraperStudioLimit.Margin = New System.Windows.Forms.Padding(0)
        Me.txtMovieScraperStudioLimit.Name = "txtMovieScraperStudioLimit"
        Me.txtMovieScraperStudioLimit.Size = New System.Drawing.Size(39, 22)
        Me.txtMovieScraperStudioLimit.TabIndex = 30
        '
        'lblMovieScraperGlobalTags
        '
        Me.lblMovieScraperGlobalTags.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalTags.AutoSize = True
        Me.lblMovieScraperGlobalTags.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalTags.Location = New System.Drawing.Point(3, 390)
        Me.lblMovieScraperGlobalTags.Name = "lblMovieScraperGlobalTags"
        Me.lblMovieScraperGlobalTags.Size = New System.Drawing.Size(29, 13)
        Me.lblMovieScraperGlobalTags.TabIndex = 68
        Me.lblMovieScraperGlobalTags.Text = "Tags"
        '
        'chkMovieScraperTags
        '
        Me.chkMovieScraperTags.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperTags.AutoSize = True
        Me.chkMovieScraperTags.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperTags.Location = New System.Drawing.Point(106, 389)
        Me.chkMovieScraperTags.Name = "chkMovieScraperTags"
        Me.chkMovieScraperTags.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperTags.TabIndex = 27
        Me.chkMovieScraperTags.UseVisualStyleBackColor = True
        '
        'chkMovieLockTags
        '
        Me.chkMovieLockTags.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockTags.AutoSize = True
        Me.chkMovieLockTags.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockTags.Location = New System.Drawing.Point(135, 389)
        Me.chkMovieLockTags.Name = "chkMovieLockTags"
        Me.chkMovieLockTags.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockTags.TabIndex = 64
        Me.chkMovieLockTags.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalTrailer
        '
        Me.lblMovieScraperGlobalTrailer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalTrailer.AutoSize = True
        Me.lblMovieScraperGlobalTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalTrailer.Location = New System.Drawing.Point(3, 413)
        Me.lblMovieScraperGlobalTrailer.Name = "lblMovieScraperGlobalTrailer"
        Me.lblMovieScraperGlobalTrailer.Size = New System.Drawing.Size(37, 13)
        Me.lblMovieScraperGlobalTrailer.TabIndex = 68
        Me.lblMovieScraperGlobalTrailer.Text = "Trailer"
        '
        'chkMovieScraperTrailer
        '
        Me.chkMovieScraperTrailer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperTrailer.AutoSize = True
        Me.chkMovieScraperTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperTrailer.Location = New System.Drawing.Point(106, 412)
        Me.chkMovieScraperTrailer.Name = "chkMovieScraperTrailer"
        Me.chkMovieScraperTrailer.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperTrailer.TabIndex = 5
        Me.chkMovieScraperTrailer.UseVisualStyleBackColor = True
        '
        'chkMovieLockTrailer
        '
        Me.chkMovieLockTrailer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockTrailer.AutoSize = True
        Me.chkMovieLockTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockTrailer.Location = New System.Drawing.Point(135, 412)
        Me.chkMovieLockTrailer.Name = "chkMovieLockTrailer"
        Me.chkMovieLockTrailer.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockTrailer.TabIndex = 46
        Me.chkMovieLockTrailer.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalGenres
        '
        Me.lblMovieScraperGlobalGenres.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalGenres.AutoSize = True
        Me.lblMovieScraperGlobalGenres.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalGenres.Location = New System.Drawing.Point(3, 436)
        Me.lblMovieScraperGlobalGenres.Name = "lblMovieScraperGlobalGenres"
        Me.lblMovieScraperGlobalGenres.Size = New System.Drawing.Size(43, 13)
        Me.lblMovieScraperGlobalGenres.TabIndex = 68
        Me.lblMovieScraperGlobalGenres.Text = "Genres"
        '
        'chkMovieScraperGenre
        '
        Me.chkMovieScraperGenre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperGenre.AutoSize = True
        Me.chkMovieScraperGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperGenre.Location = New System.Drawing.Point(106, 435)
        Me.chkMovieScraperGenre.Name = "chkMovieScraperGenre"
        Me.chkMovieScraperGenre.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperGenre.TabIndex = 10
        Me.chkMovieScraperGenre.UseVisualStyleBackColor = True
        '
        'chkMovieLockGenre
        '
        Me.chkMovieLockGenre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockGenre.AutoSize = True
        Me.chkMovieLockGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockGenre.Location = New System.Drawing.Point(135, 435)
        Me.chkMovieLockGenre.Name = "chkMovieLockGenre"
        Me.chkMovieLockGenre.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockGenre.TabIndex = 7
        Me.chkMovieLockGenre.UseVisualStyleBackColor = True
        '
        'txtMovieScraperGenreLimit
        '
        Me.txtMovieScraperGenreLimit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMovieScraperGenreLimit.Enabled = False
        Me.txtMovieScraperGenreLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieScraperGenreLimit.Location = New System.Drawing.Point(179, 431)
        Me.txtMovieScraperGenreLimit.Margin = New System.Windows.Forms.Padding(0)
        Me.txtMovieScraperGenreLimit.Name = "txtMovieScraperGenreLimit"
        Me.txtMovieScraperGenreLimit.Size = New System.Drawing.Size(39, 22)
        Me.txtMovieScraperGenreLimit.TabIndex = 21
        '
        'lblMovieScraperGlobalActors
        '
        Me.lblMovieScraperGlobalActors.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalActors.AutoSize = True
        Me.lblMovieScraperGlobalActors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalActors.Location = New System.Drawing.Point(3, 459)
        Me.lblMovieScraperGlobalActors.Name = "lblMovieScraperGlobalActors"
        Me.lblMovieScraperGlobalActors.Size = New System.Drawing.Size(39, 13)
        Me.lblMovieScraperGlobalActors.TabIndex = 68
        Me.lblMovieScraperGlobalActors.Text = "Actors"
        '
        'chkMovieScraperCast
        '
        Me.chkMovieScraperCast.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperCast.AutoSize = True
        Me.chkMovieScraperCast.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCast.Location = New System.Drawing.Point(106, 458)
        Me.chkMovieScraperCast.Name = "chkMovieScraperCast"
        Me.chkMovieScraperCast.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperCast.TabIndex = 7
        Me.chkMovieScraperCast.UseVisualStyleBackColor = True
        '
        'chkMovieLockActors
        '
        Me.chkMovieLockActors.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockActors.AutoSize = True
        Me.chkMovieLockActors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockActors.Location = New System.Drawing.Point(135, 458)
        Me.chkMovieLockActors.Name = "chkMovieLockActors"
        Me.chkMovieLockActors.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockActors.TabIndex = 50
        Me.chkMovieLockActors.UseVisualStyleBackColor = True
        '
        'txtMovieScraperCastLimit
        '
        Me.txtMovieScraperCastLimit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMovieScraperCastLimit.Enabled = False
        Me.txtMovieScraperCastLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieScraperCastLimit.Location = New System.Drawing.Point(179, 454)
        Me.txtMovieScraperCastLimit.Margin = New System.Windows.Forms.Padding(0)
        Me.txtMovieScraperCastLimit.Name = "txtMovieScraperCastLimit"
        Me.txtMovieScraperCastLimit.Size = New System.Drawing.Size(39, 22)
        Me.txtMovieScraperCastLimit.TabIndex = 19
        '
        'lblMovieScraperGlobalCountries
        '
        Me.lblMovieScraperGlobalCountries.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalCountries.AutoSize = True
        Me.lblMovieScraperGlobalCountries.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalCountries.Location = New System.Drawing.Point(3, 528)
        Me.lblMovieScraperGlobalCountries.Name = "lblMovieScraperGlobalCountries"
        Me.lblMovieScraperGlobalCountries.Size = New System.Drawing.Size(57, 13)
        Me.lblMovieScraperGlobalCountries.TabIndex = 68
        Me.lblMovieScraperGlobalCountries.Text = "Countries"
        '
        'chkMovieScraperCountry
        '
        Me.chkMovieScraperCountry.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperCountry.AutoSize = True
        Me.chkMovieScraperCountry.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCountry.Location = New System.Drawing.Point(106, 527)
        Me.chkMovieScraperCountry.Name = "chkMovieScraperCountry"
        Me.chkMovieScraperCountry.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperCountry.TabIndex = 25
        Me.chkMovieScraperCountry.UseVisualStyleBackColor = True
        '
        'chkMovieLockCountry
        '
        Me.chkMovieLockCountry.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockCountry.AutoSize = True
        Me.chkMovieLockCountry.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockCountry.Location = New System.Drawing.Point(135, 527)
        Me.chkMovieLockCountry.Name = "chkMovieLockCountry"
        Me.chkMovieLockCountry.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockCountry.TabIndex = 63
        Me.chkMovieLockCountry.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalDirectors
        '
        Me.lblMovieScraperGlobalDirectors.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalDirectors.AutoSize = True
        Me.lblMovieScraperGlobalDirectors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalDirectors.Location = New System.Drawing.Point(3, 482)
        Me.lblMovieScraperGlobalDirectors.Name = "lblMovieScraperGlobalDirectors"
        Me.lblMovieScraperGlobalDirectors.Size = New System.Drawing.Size(53, 13)
        Me.lblMovieScraperGlobalDirectors.TabIndex = 68
        Me.lblMovieScraperGlobalDirectors.Text = "Directors"
        '
        'chkMovieScraperDirector
        '
        Me.chkMovieScraperDirector.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperDirector.AutoSize = True
        Me.chkMovieScraperDirector.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperDirector.Location = New System.Drawing.Point(106, 481)
        Me.chkMovieScraperDirector.Name = "chkMovieScraperDirector"
        Me.chkMovieScraperDirector.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperDirector.TabIndex = 9
        Me.chkMovieScraperDirector.UseVisualStyleBackColor = True
        '
        'chkMovieLockDirector
        '
        Me.chkMovieLockDirector.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockDirector.AutoSize = True
        Me.chkMovieLockDirector.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockDirector.Location = New System.Drawing.Point(135, 481)
        Me.chkMovieLockDirector.Name = "chkMovieLockDirector"
        Me.chkMovieLockDirector.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockDirector.TabIndex = 57
        Me.chkMovieLockDirector.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalCredits
        '
        Me.lblMovieScraperGlobalCredits.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalCredits.AutoSize = True
        Me.lblMovieScraperGlobalCredits.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalCredits.Location = New System.Drawing.Point(3, 505)
        Me.lblMovieScraperGlobalCredits.Name = "lblMovieScraperGlobalCredits"
        Me.lblMovieScraperGlobalCredits.Size = New System.Drawing.Size(43, 13)
        Me.lblMovieScraperGlobalCredits.TabIndex = 68
        Me.lblMovieScraperGlobalCredits.Text = "Credits"
        '
        'chkMovieScraperCredits
        '
        Me.chkMovieScraperCredits.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperCredits.AutoSize = True
        Me.chkMovieScraperCredits.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCredits.Location = New System.Drawing.Point(106, 504)
        Me.chkMovieScraperCredits.Name = "chkMovieScraperCredits"
        Me.chkMovieScraperCredits.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperCredits.TabIndex = 15
        Me.chkMovieScraperCredits.UseVisualStyleBackColor = True
        '
        'chkMovieLockCredits
        '
        Me.chkMovieLockCredits.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockCredits.AutoSize = True
        Me.chkMovieLockCredits.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockCredits.Location = New System.Drawing.Point(135, 504)
        Me.chkMovieLockCredits.Name = "chkMovieLockCredits"
        Me.chkMovieLockCredits.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockCredits.TabIndex = 58
        Me.chkMovieLockCredits.UseVisualStyleBackColor = True
        '
        'lblMovieScraperGlobalUserRating
        '
        Me.lblMovieScraperGlobalUserRating.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperGlobalUserRating.AutoSize = True
        Me.lblMovieScraperGlobalUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperGlobalUserRating.Location = New System.Drawing.Point(3, 275)
        Me.lblMovieScraperGlobalUserRating.Name = "lblMovieScraperGlobalUserRating"
        Me.lblMovieScraperGlobalUserRating.Size = New System.Drawing.Size(67, 13)
        Me.lblMovieScraperGlobalUserRating.TabIndex = 68
        Me.lblMovieScraperGlobalUserRating.Text = "User Rating"
        '
        'chkMovieScraperUserRating
        '
        Me.chkMovieScraperUserRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieScraperUserRating.AutoSize = True
        Me.chkMovieScraperUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperUserRating.Location = New System.Drawing.Point(106, 274)
        Me.chkMovieScraperUserRating.Name = "chkMovieScraperUserRating"
        Me.chkMovieScraperUserRating.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieScraperUserRating.TabIndex = 4
        Me.chkMovieScraperUserRating.UseVisualStyleBackColor = True
        '
        'chkMovieLockUserRating
        '
        Me.chkMovieLockUserRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieLockUserRating.AutoSize = True
        Me.chkMovieLockUserRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLockUserRating.Location = New System.Drawing.Point(135, 274)
        Me.chkMovieLockUserRating.Name = "chkMovieLockUserRating"
        Me.chkMovieLockUserRating.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieLockUserRating.TabIndex = 4
        Me.chkMovieLockUserRating.UseVisualStyleBackColor = True
        '
        'dgvTitle
        '
        Me.dgvTitle.Location = New System.Drawing.Point(237, 86)
        Me.dgvTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvTitle.Name = "dgvTitle"
        Me.dgvTitle.Size = New System.Drawing.Size(100, 23)
        Me.dgvTitle.TabIndex = 70
        '
        'dgvOriginalTitle
        '
        Me.dgvOriginalTitle.Location = New System.Drawing.Point(237, 109)
        Me.dgvOriginalTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvOriginalTitle.Name = "dgvOriginalTitle"
        Me.dgvOriginalTitle.Size = New System.Drawing.Size(100, 23)
        Me.dgvOriginalTitle.TabIndex = 70
        '
        'dgvYear
        '
        Me.dgvYear.Location = New System.Drawing.Point(237, 132)
        Me.dgvYear.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvYear.Name = "dgvYear"
        Me.dgvYear.Size = New System.Drawing.Size(100, 23)
        Me.dgvYear.TabIndex = 70
        '
        'dgvReleaseDate
        '
        Me.dgvReleaseDate.Location = New System.Drawing.Point(237, 155)
        Me.dgvReleaseDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvReleaseDate.Name = "dgvReleaseDate"
        Me.dgvReleaseDate.Size = New System.Drawing.Size(100, 23)
        Me.dgvReleaseDate.TabIndex = 70
        '
        'dgvPlot
        '
        Me.dgvPlot.Location = New System.Drawing.Point(237, 178)
        Me.dgvPlot.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvPlot.Name = "dgvPlot"
        Me.dgvPlot.Size = New System.Drawing.Size(100, 23)
        Me.dgvPlot.TabIndex = 70
        '
        'dgvOutline
        '
        Me.dgvOutline.Location = New System.Drawing.Point(237, 201)
        Me.dgvOutline.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvOutline.Name = "dgvOutline"
        Me.dgvOutline.Size = New System.Drawing.Size(100, 23)
        Me.dgvOutline.TabIndex = 70
        '
        'dgvTagline
        '
        Me.dgvTagline.Location = New System.Drawing.Point(237, 224)
        Me.dgvTagline.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvTagline.Name = "dgvTagline"
        Me.dgvTagline.Size = New System.Drawing.Size(100, 23)
        Me.dgvTagline.TabIndex = 70
        '
        'dgvRating
        '
        Me.dgvRating.Location = New System.Drawing.Point(237, 247)
        Me.dgvRating.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvRating.Name = "dgvRating"
        Me.dgvRating.Size = New System.Drawing.Size(100, 23)
        Me.dgvRating.TabIndex = 70
        '
        'dgvUserRating
        '
        Me.dgvUserRating.Location = New System.Drawing.Point(237, 270)
        Me.dgvUserRating.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvUserRating.Name = "dgvUserRating"
        Me.dgvUserRating.Size = New System.Drawing.Size(100, 23)
        Me.dgvUserRating.TabIndex = 70
        '
        'dgvTop250
        '
        Me.dgvTop250.Location = New System.Drawing.Point(237, 293)
        Me.dgvTop250.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvTop250.Name = "dgvTop250"
        Me.dgvTop250.Size = New System.Drawing.Size(100, 23)
        Me.dgvTop250.TabIndex = 70
        '
        'dgvMPAA
        '
        Me.dgvMPAA.Location = New System.Drawing.Point(237, 316)
        Me.dgvMPAA.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvMPAA.Name = "dgvMPAA"
        Me.dgvMPAA.Size = New System.Drawing.Size(100, 23)
        Me.dgvMPAA.TabIndex = 70
        '
        'dgvCertifications
        '
        Me.dgvCertifications.Location = New System.Drawing.Point(237, 339)
        Me.dgvCertifications.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvCertifications.Name = "dgvCertifications"
        Me.dgvCertifications.Size = New System.Drawing.Size(100, 23)
        Me.dgvCertifications.TabIndex = 70
        '
        'dgvRuntime
        '
        Me.dgvRuntime.Location = New System.Drawing.Point(237, 362)
        Me.dgvRuntime.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvRuntime.Name = "dgvRuntime"
        Me.dgvRuntime.Size = New System.Drawing.Size(100, 23)
        Me.dgvRuntime.TabIndex = 70
        '
        'dgvTags
        '
        Me.dgvTags.Location = New System.Drawing.Point(237, 385)
        Me.dgvTags.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvTags.Name = "dgvTags"
        Me.dgvTags.Size = New System.Drawing.Size(100, 23)
        Me.dgvTags.TabIndex = 70
        '
        'dgvTrailer
        '
        Me.dgvTrailer.Location = New System.Drawing.Point(237, 408)
        Me.dgvTrailer.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvTrailer.Name = "dgvTrailer"
        Me.dgvTrailer.Size = New System.Drawing.Size(100, 23)
        Me.dgvTrailer.TabIndex = 70
        '
        'dgvGenres
        '
        Me.dgvGenres.Location = New System.Drawing.Point(237, 431)
        Me.dgvGenres.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvGenres.Name = "dgvGenres"
        Me.dgvGenres.Size = New System.Drawing.Size(100, 23)
        Me.dgvGenres.TabIndex = 70
        '
        'dgvActors
        '
        Me.dgvActors.Location = New System.Drawing.Point(237, 454)
        Me.dgvActors.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvActors.Name = "dgvActors"
        Me.dgvActors.Size = New System.Drawing.Size(100, 23)
        Me.dgvActors.TabIndex = 70
        '
        'dgvDirectors
        '
        Me.dgvDirectors.Location = New System.Drawing.Point(237, 477)
        Me.dgvDirectors.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvDirectors.Name = "dgvDirectors"
        Me.dgvDirectors.Size = New System.Drawing.Size(100, 23)
        Me.dgvDirectors.TabIndex = 70
        '
        'dgvCredits
        '
        Me.dgvCredits.Location = New System.Drawing.Point(237, 500)
        Me.dgvCredits.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvCredits.Name = "dgvCredits"
        Me.dgvCredits.Size = New System.Drawing.Size(100, 23)
        Me.dgvCredits.TabIndex = 70
        '
        'dgvCoutries
        '
        Me.dgvCoutries.Location = New System.Drawing.Point(237, 523)
        Me.dgvCoutries.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvCoutries.Name = "dgvCoutries"
        Me.dgvCoutries.Size = New System.Drawing.Size(100, 23)
        Me.dgvCoutries.TabIndex = 70
        '
        'dgvStudios
        '
        Me.dgvStudios.Location = New System.Drawing.Point(237, 546)
        Me.dgvStudios.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvStudios.Name = "dgvStudios"
        Me.dgvStudios.Size = New System.Drawing.Size(100, 23)
        Me.dgvStudios.TabIndex = 70
        '
        'dgvCollectionID
        '
        Me.dgvCollectionID.Location = New System.Drawing.Point(237, 569)
        Me.dgvCollectionID.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvCollectionID.Name = "dgvCollectionID"
        Me.dgvCollectionID.Size = New System.Drawing.Size(100, 23)
        Me.dgvCollectionID.TabIndex = 70
        '
        'lblFields
        '
        Me.lblFields.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFields.AutoSize = True
        Me.lblFields.Location = New System.Drawing.Point(33, 69)
        Me.lblFields.Name = "lblFields"
        Me.lblFields.Size = New System.Drawing.Size(37, 13)
        Me.lblFields.TabIndex = 71
        Me.lblFields.Text = "Fields"
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(31, 3)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(41, 13)
        Me.lblSearch.TabIndex = 71
        Me.lblSearch.Text = "Search"
        '
        'gbMovieScraperCertificationOpts
        '
        Me.gbMovieScraperCertificationOpts.AutoSize = True
        Me.gbMovieScraperCertificationOpts.Controls.Add(Me.tblMovieScraperCertificationOpts)
        Me.gbMovieScraperCertificationOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieScraperCertificationOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieScraperCertificationOpts.Location = New System.Drawing.Point(352, 388)
        Me.gbMovieScraperCertificationOpts.Name = "gbMovieScraperCertificationOpts"
        Me.gbMovieScraperCertificationOpts.Size = New System.Drawing.Size(446, 118)
        Me.gbMovieScraperCertificationOpts.TabIndex = 77
        Me.gbMovieScraperCertificationOpts.TabStop = False
        Me.gbMovieScraperCertificationOpts.Text = "Certification"
        '
        'tblMovieScraperCertificationOpts
        '
        Me.tblMovieScraperCertificationOpts.AutoSize = True
        Me.tblMovieScraperCertificationOpts.ColumnCount = 2
        Me.tblMovieScraperCertificationOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperCertificationOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperCertificationOpts.Controls.Add(Me.chkMovieScraperCertOnlyValue, 0, 3)
        Me.tblMovieScraperCertificationOpts.Controls.Add(Me.chkMovieScraperCertForMPAAFallback, 0, 1)
        Me.tblMovieScraperCertificationOpts.Controls.Add(Me.chkMovieScraperCertForMPAA, 0, 0)
        Me.tblMovieScraperCertificationOpts.Controls.Add(Me.txtMovieScraperMPAANotRated, 1, 4)
        Me.tblMovieScraperCertificationOpts.Controls.Add(Me.lblMovieScraperMPAANotRated, 0, 4)
        Me.tblMovieScraperCertificationOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieScraperCertificationOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieScraperCertificationOpts.Name = "tblMovieScraperCertificationOpts"
        Me.tblMovieScraperCertificationOpts.RowCount = 6
        Me.tblMovieScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCertificationOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCertificationOpts.Size = New System.Drawing.Size(440, 97)
        Me.tblMovieScraperCertificationOpts.TabIndex = 78
        '
        'chkMovieScraperCertOnlyValue
        '
        Me.chkMovieScraperCertOnlyValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperCertOnlyValue.AutoSize = True
        Me.tblMovieScraperCertificationOpts.SetColumnSpan(Me.chkMovieScraperCertOnlyValue, 2)
        Me.chkMovieScraperCertOnlyValue.Enabled = False
        Me.chkMovieScraperCertOnlyValue.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCertOnlyValue.Location = New System.Drawing.Point(3, 49)
        Me.chkMovieScraperCertOnlyValue.Name = "chkMovieScraperCertOnlyValue"
        Me.chkMovieScraperCertOnlyValue.Size = New System.Drawing.Size(152, 17)
        Me.chkMovieScraperCertOnlyValue.TabIndex = 66
        Me.chkMovieScraperCertOnlyValue.Text = "MPAA: Save only number"
        Me.chkMovieScraperCertOnlyValue.UseVisualStyleBackColor = True
        '
        'chkMovieScraperCertForMPAAFallback
        '
        Me.chkMovieScraperCertForMPAAFallback.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperCertForMPAAFallback.AutoSize = True
        Me.tblMovieScraperCertificationOpts.SetColumnSpan(Me.chkMovieScraperCertForMPAAFallback, 2)
        Me.chkMovieScraperCertForMPAAFallback.Enabled = False
        Me.chkMovieScraperCertForMPAAFallback.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCertForMPAAFallback.Location = New System.Drawing.Point(3, 26)
        Me.chkMovieScraperCertForMPAAFallback.Name = "chkMovieScraperCertForMPAAFallback"
        Me.chkMovieScraperCertForMPAAFallback.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkMovieScraperCertForMPAAFallback.Size = New System.Drawing.Size(175, 17)
        Me.chkMovieScraperCertForMPAAFallback.TabIndex = 68
        Me.chkMovieScraperCertForMPAAFallback.Text = "Only if no MPAA is found"
        Me.chkMovieScraperCertForMPAAFallback.UseVisualStyleBackColor = True
        '
        'chkMovieScraperCertForMPAA
        '
        Me.chkMovieScraperCertForMPAA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperCertForMPAA.AutoSize = True
        Me.tblMovieScraperCertificationOpts.SetColumnSpan(Me.chkMovieScraperCertForMPAA, 2)
        Me.chkMovieScraperCertForMPAA.Enabled = False
        Me.chkMovieScraperCertForMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCertForMPAA.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieScraperCertForMPAA.Name = "chkMovieScraperCertForMPAA"
        Me.chkMovieScraperCertForMPAA.Size = New System.Drawing.Size(161, 17)
        Me.chkMovieScraperCertForMPAA.TabIndex = 6
        Me.chkMovieScraperCertForMPAA.Text = "Use Certification for MPAA"
        Me.chkMovieScraperCertForMPAA.UseVisualStyleBackColor = True
        '
        'txtMovieScraperMPAANotRated
        '
        Me.txtMovieScraperMPAANotRated.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMovieScraperMPAANotRated.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieScraperMPAANotRated.Location = New System.Drawing.Point(198, 72)
        Me.txtMovieScraperMPAANotRated.Name = "txtMovieScraperMPAANotRated"
        Me.txtMovieScraperMPAANotRated.Size = New System.Drawing.Size(239, 22)
        Me.txtMovieScraperMPAANotRated.TabIndex = 69
        '
        'lblMovieScraperMPAANotRated
        '
        Me.lblMovieScraperMPAANotRated.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperMPAANotRated.AutoSize = True
        Me.lblMovieScraperMPAANotRated.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieScraperMPAANotRated.Location = New System.Drawing.Point(3, 76)
        Me.lblMovieScraperMPAANotRated.Name = "lblMovieScraperMPAANotRated"
        Me.lblMovieScraperMPAANotRated.Size = New System.Drawing.Size(189, 13)
        Me.lblMovieScraperMPAANotRated.TabIndex = 68
        Me.lblMovieScraperMPAANotRated.Text = "MPAA value if no rating is available:"
        '
        'gbMovieScraperMiscOpts
        '
        Me.gbMovieScraperMiscOpts.AutoSize = True
        Me.gbMovieScraperMiscOpts.Controls.Add(Me.tblMovieScraperMiscOpts)
        Me.gbMovieScraperMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieScraperMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieScraperMiscOpts.Location = New System.Drawing.Point(352, 172)
        Me.gbMovieScraperMiscOpts.Name = "gbMovieScraperMiscOpts"
        Me.gbMovieScraperMiscOpts.Size = New System.Drawing.Size(446, 210)
        Me.gbMovieScraperMiscOpts.TabIndex = 0
        Me.gbMovieScraperMiscOpts.TabStop = False
        Me.gbMovieScraperMiscOpts.Text = "Miscellaneous"
        '
        'tblMovieScraperMiscOpts
        '
        Me.tblMovieScraperMiscOpts.AutoSize = True
        Me.tblMovieScraperMiscOpts.ColumnCount = 4
        Me.tblMovieScraperMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.chkMovieScraperCleanPlotOutline, 0, 6)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.chkMovieScraperCleanFields, 0, 0)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.chkMovieScraperStudioWithImg, 0, 3)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.chkMovieScraperCastWithImg, 0, 2)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.chkMovieScraperDetailView, 0, 1)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.lblMovieScraperOutlineLimit, 1, 4)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.txtMovieScraperOutlineLimit, 2, 4)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.chkMovieScraperPlotForOutline, 0, 4)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.chkMovieScraperXBMCTrailerFormat, 0, 7)
        Me.tblMovieScraperMiscOpts.Controls.Add(Me.chkMovieScraperPlotForOutlineIfEmpty, 0, 5)
        Me.tblMovieScraperMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieScraperMiscOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieScraperMiscOpts.Name = "tblMovieScraperMiscOpts"
        Me.tblMovieScraperMiscOpts.RowCount = 9
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMiscOpts.Size = New System.Drawing.Size(440, 189)
        Me.tblMovieScraperMiscOpts.TabIndex = 78
        '
        'chkMovieScraperCleanPlotOutline
        '
        Me.chkMovieScraperCleanPlotOutline.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperCleanPlotOutline.AutoSize = True
        Me.tblMovieScraperMiscOpts.SetColumnSpan(Me.chkMovieScraperCleanPlotOutline, 3)
        Me.chkMovieScraperCleanPlotOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCleanPlotOutline.Location = New System.Drawing.Point(3, 146)
        Me.chkMovieScraperCleanPlotOutline.Name = "chkMovieScraperCleanPlotOutline"
        Me.chkMovieScraperCleanPlotOutline.Size = New System.Drawing.Size(121, 17)
        Me.chkMovieScraperCleanPlotOutline.TabIndex = 76
        Me.chkMovieScraperCleanPlotOutline.Text = "Clean Plot/Outline"
        Me.chkMovieScraperCleanPlotOutline.UseVisualStyleBackColor = True
        '
        'chkMovieScraperCleanFields
        '
        Me.chkMovieScraperCleanFields.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperCleanFields.AutoSize = True
        Me.chkMovieScraperCleanFields.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCleanFields.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieScraperCleanFields.Name = "chkMovieScraperCleanFields"
        Me.chkMovieScraperCleanFields.Size = New System.Drawing.Size(147, 17)
        Me.chkMovieScraperCleanFields.TabIndex = 79
        Me.chkMovieScraperCleanFields.Text = "Cleanup disabled fields"
        Me.chkMovieScraperCleanFields.UseVisualStyleBackColor = True
        '
        'chkMovieScraperStudioWithImg
        '
        Me.chkMovieScraperStudioWithImg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperStudioWithImg.AutoSize = True
        Me.tblMovieScraperMiscOpts.SetColumnSpan(Me.chkMovieScraperStudioWithImg, 3)
        Me.chkMovieScraperStudioWithImg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperStudioWithImg.Location = New System.Drawing.Point(3, 72)
        Me.chkMovieScraperStudioWithImg.Name = "chkMovieScraperStudioWithImg"
        Me.chkMovieScraperStudioWithImg.Size = New System.Drawing.Size(196, 17)
        Me.chkMovieScraperStudioWithImg.TabIndex = 82
        Me.chkMovieScraperStudioWithImg.Text = "Scrape Only Studios With Images"
        Me.chkMovieScraperStudioWithImg.UseVisualStyleBackColor = True
        '
        'chkMovieScraperCastWithImg
        '
        Me.chkMovieScraperCastWithImg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperCastWithImg.AutoSize = True
        Me.tblMovieScraperMiscOpts.SetColumnSpan(Me.chkMovieScraperCastWithImg, 3)
        Me.chkMovieScraperCastWithImg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCastWithImg.Location = New System.Drawing.Point(3, 49)
        Me.chkMovieScraperCastWithImg.Name = "chkMovieScraperCastWithImg"
        Me.chkMovieScraperCastWithImg.Size = New System.Drawing.Size(189, 17)
        Me.chkMovieScraperCastWithImg.TabIndex = 1
        Me.chkMovieScraperCastWithImg.Text = "Scrape Only Actors With Images"
        Me.chkMovieScraperCastWithImg.UseVisualStyleBackColor = True
        '
        'chkMovieScraperDetailView
        '
        Me.chkMovieScraperDetailView.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperDetailView.AutoSize = True
        Me.tblMovieScraperMiscOpts.SetColumnSpan(Me.chkMovieScraperDetailView, 3)
        Me.chkMovieScraperDetailView.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperDetailView.Location = New System.Drawing.Point(3, 26)
        Me.chkMovieScraperDetailView.Name = "chkMovieScraperDetailView"
        Me.chkMovieScraperDetailView.Size = New System.Drawing.Size(219, 17)
        Me.chkMovieScraperDetailView.TabIndex = 78
        Me.chkMovieScraperDetailView.Text = "Show scraped results in detailed view"
        Me.chkMovieScraperDetailView.UseVisualStyleBackColor = True
        '
        'lblMovieScraperOutlineLimit
        '
        Me.lblMovieScraperOutlineLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperOutlineLimit.AutoSize = True
        Me.lblMovieScraperOutlineLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieScraperOutlineLimit.Location = New System.Drawing.Point(199, 99)
        Me.lblMovieScraperOutlineLimit.Name = "lblMovieScraperOutlineLimit"
        Me.lblMovieScraperOutlineLimit.Size = New System.Drawing.Size(34, 13)
        Me.lblMovieScraperOutlineLimit.TabIndex = 70
        Me.lblMovieScraperOutlineLimit.Text = "Limit:"
        Me.lblMovieScraperOutlineLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMovieScraperOutlineLimit
        '
        Me.txtMovieScraperOutlineLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieScraperOutlineLimit.Enabled = False
        Me.txtMovieScraperOutlineLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieScraperOutlineLimit.Location = New System.Drawing.Point(239, 95)
        Me.txtMovieScraperOutlineLimit.Name = "txtMovieScraperOutlineLimit"
        Me.txtMovieScraperOutlineLimit.Size = New System.Drawing.Size(54, 22)
        Me.txtMovieScraperOutlineLimit.TabIndex = 69
        '
        'chkMovieScraperPlotForOutline
        '
        Me.chkMovieScraperPlotForOutline.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperPlotForOutline.AutoSize = True
        Me.chkMovieScraperPlotForOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperPlotForOutline.Location = New System.Drawing.Point(3, 97)
        Me.chkMovieScraperPlotForOutline.Name = "chkMovieScraperPlotForOutline"
        Me.chkMovieScraperPlotForOutline.Size = New System.Drawing.Size(134, 17)
        Me.chkMovieScraperPlotForOutline.TabIndex = 68
        Me.chkMovieScraperPlotForOutline.Text = "Use Plot  for Outline "
        Me.chkMovieScraperPlotForOutline.UseVisualStyleBackColor = True
        '
        'chkMovieScraperXBMCTrailerFormat
        '
        Me.chkMovieScraperXBMCTrailerFormat.AutoSize = True
        Me.tblMovieScraperMiscOpts.SetColumnSpan(Me.chkMovieScraperXBMCTrailerFormat, 3)
        Me.chkMovieScraperXBMCTrailerFormat.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkMovieScraperXBMCTrailerFormat.Location = New System.Drawing.Point(3, 169)
        Me.chkMovieScraperXBMCTrailerFormat.Name = "chkMovieScraperXBMCTrailerFormat"
        Me.chkMovieScraperXBMCTrailerFormat.Size = New System.Drawing.Size(302, 17)
        Me.chkMovieScraperXBMCTrailerFormat.TabIndex = 83
        Me.chkMovieScraperXBMCTrailerFormat.Text = "Save YouTube-Trailer-Links in XBMC compatible format"
        Me.chkMovieScraperXBMCTrailerFormat.UseVisualStyleBackColor = True
        '
        'chkMovieScraperPlotForOutlineIfEmpty
        '
        Me.chkMovieScraperPlotForOutlineIfEmpty.AutoSize = True
        Me.chkMovieScraperPlotForOutlineIfEmpty.Enabled = False
        Me.chkMovieScraperPlotForOutlineIfEmpty.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkMovieScraperPlotForOutlineIfEmpty.Location = New System.Drawing.Point(3, 123)
        Me.chkMovieScraperPlotForOutlineIfEmpty.Name = "chkMovieScraperPlotForOutlineIfEmpty"
        Me.chkMovieScraperPlotForOutlineIfEmpty.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkMovieScraperPlotForOutlineIfEmpty.Size = New System.Drawing.Size(190, 17)
        Me.chkMovieScraperPlotForOutlineIfEmpty.TabIndex = 84
        Me.chkMovieScraperPlotForOutlineIfEmpty.Text = "Only if Plot Outline is empty"
        Me.chkMovieScraperPlotForOutlineIfEmpty.UseVisualStyleBackColor = True
        '
        'gbMovieScraperMetaDataOpts
        '
        Me.gbMovieScraperMetaDataOpts.AutoSize = True
        Me.gbMovieScraperMetaDataOpts.Controls.Add(Me.tblMovieScraperMetaDataOpts)
        Me.gbMovieScraperMetaDataOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieScraperMetaDataOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieScraperMetaDataOpts.Location = New System.Drawing.Point(352, 3)
        Me.gbMovieScraperMetaDataOpts.Name = "gbMovieScraperMetaDataOpts"
        Me.gbMovieScraperMetaDataOpts.Size = New System.Drawing.Size(446, 163)
        Me.gbMovieScraperMetaDataOpts.TabIndex = 63
        Me.gbMovieScraperMetaDataOpts.TabStop = False
        Me.gbMovieScraperMetaDataOpts.Text = "Meta Data"
        '
        'tblMovieScraperMetaDataOpts
        '
        Me.tblMovieScraperMetaDataOpts.AutoSize = True
        Me.tblMovieScraperMetaDataOpts.ColumnCount = 3
        Me.tblMovieScraperMetaDataOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperMetaDataOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperMetaDataOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperMetaDataOpts.Controls.Add(Me.gbMovieScraperDefFIExtOpts, 1, 0)
        Me.tblMovieScraperMetaDataOpts.Controls.Add(Me.chkMovieScraperMetaDataScan, 0, 0)
        Me.tblMovieScraperMetaDataOpts.Controls.Add(Me.chkMovieScraperMetaDataIFOScan, 0, 1)
        Me.tblMovieScraperMetaDataOpts.Controls.Add(Me.gbMovieScraperDurationFormatOpts, 0, 2)
        Me.tblMovieScraperMetaDataOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieScraperMetaDataOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieScraperMetaDataOpts.Name = "tblMovieScraperMetaDataOpts"
        Me.tblMovieScraperMetaDataOpts.RowCount = 5
        Me.tblMovieScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMetaDataOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperMetaDataOpts.Size = New System.Drawing.Size(440, 142)
        Me.tblMovieScraperMetaDataOpts.TabIndex = 78
        '
        'gbMovieScraperDefFIExtOpts
        '
        Me.gbMovieScraperDefFIExtOpts.AutoSize = True
        Me.gbMovieScraperDefFIExtOpts.Controls.Add(Me.tblMovieScraperDefFIExtOpts)
        Me.gbMovieScraperDefFIExtOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieScraperDefFIExtOpts.Location = New System.Drawing.Point(257, 3)
        Me.gbMovieScraperDefFIExtOpts.Name = "gbMovieScraperDefFIExtOpts"
        Me.tblMovieScraperMetaDataOpts.SetRowSpan(Me.gbMovieScraperDefFIExtOpts, 4)
        Me.gbMovieScraperDefFIExtOpts.Size = New System.Drawing.Size(180, 136)
        Me.gbMovieScraperDefFIExtOpts.TabIndex = 8
        Me.gbMovieScraperDefFIExtOpts.TabStop = False
        Me.gbMovieScraperDefFIExtOpts.Text = "Defaults by File Type"
        '
        'tblMovieScraperDefFIExtOpts
        '
        Me.tblMovieScraperDefFIExtOpts.AutoSize = True
        Me.tblMovieScraperDefFIExtOpts.ColumnCount = 5
        Me.tblMovieScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperDefFIExtOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperDefFIExtOpts.Controls.Add(Me.btnMovieScraperDefFIExtRemove, 3, 2)
        Me.tblMovieScraperDefFIExtOpts.Controls.Add(Me.txtMovieScraperDefFIExt, 0, 2)
        Me.tblMovieScraperDefFIExtOpts.Controls.Add(Me.btnMovieScraperDefFIExtEdit, 2, 2)
        Me.tblMovieScraperDefFIExtOpts.Controls.Add(Me.lstMovieScraperDefFIExt, 0, 0)
        Me.tblMovieScraperDefFIExtOpts.Controls.Add(Me.btnMovieScraperDefFIExtAdd, 1, 2)
        Me.tblMovieScraperDefFIExtOpts.Controls.Add(Me.lblMovieScraperDefFIExt, 0, 1)
        Me.tblMovieScraperDefFIExtOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieScraperDefFIExtOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieScraperDefFIExtOpts.Name = "tblMovieScraperDefFIExtOpts"
        Me.tblMovieScraperDefFIExtOpts.RowCount = 4
        Me.tblMovieScraperDefFIExtOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperDefFIExtOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieScraperDefFIExtOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperDefFIExtOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperDefFIExtOpts.Size = New System.Drawing.Size(174, 115)
        Me.tblMovieScraperDefFIExtOpts.TabIndex = 78
        '
        'btnMovieScraperDefFIExtRemove
        '
        Me.btnMovieScraperDefFIExtRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieScraperDefFIExtRemove.Enabled = False
        Me.btnMovieScraperDefFIExtRemove.Image = CType(resources.GetObject("btnMovieScraperDefFIExtRemove.Image"), System.Drawing.Image)
        Me.btnMovieScraperDefFIExtRemove.Location = New System.Drawing.Point(148, 89)
        Me.btnMovieScraperDefFIExtRemove.Name = "btnMovieScraperDefFIExtRemove"
        Me.btnMovieScraperDefFIExtRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieScraperDefFIExtRemove.TabIndex = 31
        Me.btnMovieScraperDefFIExtRemove.UseVisualStyleBackColor = True
        '
        'txtMovieScraperDefFIExt
        '
        Me.txtMovieScraperDefFIExt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieScraperDefFIExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieScraperDefFIExt.Location = New System.Drawing.Point(3, 89)
        Me.txtMovieScraperDefFIExt.Name = "txtMovieScraperDefFIExt"
        Me.txtMovieScraperDefFIExt.Size = New System.Drawing.Size(80, 22)
        Me.txtMovieScraperDefFIExt.TabIndex = 33
        '
        'btnMovieScraperDefFIExtEdit
        '
        Me.btnMovieScraperDefFIExtEdit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieScraperDefFIExtEdit.Enabled = False
        Me.btnMovieScraperDefFIExtEdit.Image = CType(resources.GetObject("btnMovieScraperDefFIExtEdit.Image"), System.Drawing.Image)
        Me.btnMovieScraperDefFIExtEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMovieScraperDefFIExtEdit.Location = New System.Drawing.Point(118, 89)
        Me.btnMovieScraperDefFIExtEdit.Name = "btnMovieScraperDefFIExtEdit"
        Me.btnMovieScraperDefFIExtEdit.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieScraperDefFIExtEdit.TabIndex = 30
        Me.btnMovieScraperDefFIExtEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMovieScraperDefFIExtEdit.UseVisualStyleBackColor = True
        '
        'lstMovieScraperDefFIExt
        '
        Me.tblMovieScraperDefFIExtOpts.SetColumnSpan(Me.lstMovieScraperDefFIExt, 4)
        Me.lstMovieScraperDefFIExt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMovieScraperDefFIExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstMovieScraperDefFIExt.FormattingEnabled = True
        Me.lstMovieScraperDefFIExt.Location = New System.Drawing.Point(3, 3)
        Me.lstMovieScraperDefFIExt.Name = "lstMovieScraperDefFIExt"
        Me.lstMovieScraperDefFIExt.Size = New System.Drawing.Size(168, 60)
        Me.lstMovieScraperDefFIExt.TabIndex = 34
        '
        'btnMovieScraperDefFIExtAdd
        '
        Me.btnMovieScraperDefFIExtAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieScraperDefFIExtAdd.Enabled = False
        Me.btnMovieScraperDefFIExtAdd.Image = CType(resources.GetObject("btnMovieScraperDefFIExtAdd.Image"), System.Drawing.Image)
        Me.btnMovieScraperDefFIExtAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMovieScraperDefFIExtAdd.Location = New System.Drawing.Point(89, 89)
        Me.btnMovieScraperDefFIExtAdd.Name = "btnMovieScraperDefFIExtAdd"
        Me.btnMovieScraperDefFIExtAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieScraperDefFIExtAdd.TabIndex = 29
        Me.btnMovieScraperDefFIExtAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMovieScraperDefFIExtAdd.UseVisualStyleBackColor = True
        '
        'lblMovieScraperDefFIExt
        '
        Me.lblMovieScraperDefFIExt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieScraperDefFIExt.AutoSize = True
        Me.tblMovieScraperDefFIExtOpts.SetColumnSpan(Me.lblMovieScraperDefFIExt, 4)
        Me.lblMovieScraperDefFIExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieScraperDefFIExt.Location = New System.Drawing.Point(3, 69)
        Me.lblMovieScraperDefFIExt.Name = "lblMovieScraperDefFIExt"
        Me.lblMovieScraperDefFIExt.Size = New System.Drawing.Size(53, 13)
        Me.lblMovieScraperDefFIExt.TabIndex = 32
        Me.lblMovieScraperDefFIExt.Text = "File Type:"
        '
        'chkMovieScraperMetaDataScan
        '
        Me.chkMovieScraperMetaDataScan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperMetaDataScan.AutoSize = True
        Me.chkMovieScraperMetaDataScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperMetaDataScan.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieScraperMetaDataScan.Name = "chkMovieScraperMetaDataScan"
        Me.chkMovieScraperMetaDataScan.Size = New System.Drawing.Size(106, 17)
        Me.chkMovieScraperMetaDataScan.TabIndex = 7
        Me.chkMovieScraperMetaDataScan.Text = "Scan Meta Data"
        Me.chkMovieScraperMetaDataScan.UseVisualStyleBackColor = True
        '
        'chkMovieScraperMetaDataIFOScan
        '
        Me.chkMovieScraperMetaDataIFOScan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperMetaDataIFOScan.AutoSize = True
        Me.chkMovieScraperMetaDataIFOScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperMetaDataIFOScan.Location = New System.Drawing.Point(3, 26)
        Me.chkMovieScraperMetaDataIFOScan.Name = "chkMovieScraperMetaDataIFOScan"
        Me.chkMovieScraperMetaDataIFOScan.Size = New System.Drawing.Size(123, 17)
        Me.chkMovieScraperMetaDataIFOScan.TabIndex = 18
        Me.chkMovieScraperMetaDataIFOScan.Text = "Enable IFO Parsing"
        Me.chkMovieScraperMetaDataIFOScan.UseVisualStyleBackColor = True
        '
        'gbMovieScraperDurationFormatOpts
        '
        Me.gbMovieScraperDurationFormatOpts.AutoSize = True
        Me.gbMovieScraperDurationFormatOpts.Controls.Add(Me.tblMovieScraperDurationFormatOpts)
        Me.gbMovieScraperDurationFormatOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieScraperDurationFormatOpts.Location = New System.Drawing.Point(3, 49)
        Me.gbMovieScraperDurationFormatOpts.Name = "gbMovieScraperDurationFormatOpts"
        Me.gbMovieScraperDurationFormatOpts.Size = New System.Drawing.Size(248, 72)
        Me.gbMovieScraperDurationFormatOpts.TabIndex = 9
        Me.gbMovieScraperDurationFormatOpts.TabStop = False
        Me.gbMovieScraperDurationFormatOpts.Text = "Duration Format"
        '
        'tblMovieScraperDurationFormatOpts
        '
        Me.tblMovieScraperDurationFormatOpts.AutoSize = True
        Me.tblMovieScraperDurationFormatOpts.ColumnCount = 3
        Me.tblMovieScraperDurationFormatOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperDurationFormatOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperDurationFormatOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperDurationFormatOpts.Controls.Add(Me.lblMovieScraperDurationRuntimeFormat, 1, 0)
        Me.tblMovieScraperDurationFormatOpts.Controls.Add(Me.chkMovieScraperUseMDDuration, 0, 0)
        Me.tblMovieScraperDurationFormatOpts.Controls.Add(Me.txtMovieScraperDurationRuntimeFormat, 0, 1)
        Me.tblMovieScraperDurationFormatOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieScraperDurationFormatOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieScraperDurationFormatOpts.Name = "tblMovieScraperDurationFormatOpts"
        Me.tblMovieScraperDurationFormatOpts.RowCount = 3
        Me.tblMovieScraperDurationFormatOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperDurationFormatOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperDurationFormatOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperDurationFormatOpts.Size = New System.Drawing.Size(242, 51)
        Me.tblMovieScraperDurationFormatOpts.TabIndex = 78
        '
        'lblMovieScraperDurationRuntimeFormat
        '
        Me.lblMovieScraperDurationRuntimeFormat.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMovieScraperDurationRuntimeFormat.AutoSize = True
        Me.lblMovieScraperDurationRuntimeFormat.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.lblMovieScraperDurationRuntimeFormat.Location = New System.Drawing.Point(169, 7)
        Me.lblMovieScraperDurationRuntimeFormat.Name = "lblMovieScraperDurationRuntimeFormat"
        Me.tblMovieScraperDurationFormatOpts.SetRowSpan(Me.lblMovieScraperDurationRuntimeFormat, 2)
        Me.lblMovieScraperDurationRuntimeFormat.Size = New System.Drawing.Size(70, 36)
        Me.lblMovieScraperDurationRuntimeFormat.TabIndex = 23
        Me.lblMovieScraperDurationRuntimeFormat.Text = "<h>=Hours" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<m>=Minutes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<s>=Seconds"
        Me.lblMovieScraperDurationRuntimeFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkMovieScraperUseMDDuration
        '
        Me.chkMovieScraperUseMDDuration.AutoSize = True
        Me.chkMovieScraperUseMDDuration.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperUseMDDuration.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieScraperUseMDDuration.Name = "chkMovieScraperUseMDDuration"
        Me.chkMovieScraperUseMDDuration.Size = New System.Drawing.Size(158, 17)
        Me.chkMovieScraperUseMDDuration.TabIndex = 8
        Me.chkMovieScraperUseMDDuration.Text = "Use Duration for Runtime"
        Me.chkMovieScraperUseMDDuration.UseVisualStyleBackColor = True
        '
        'txtMovieScraperDurationRuntimeFormat
        '
        Me.txtMovieScraperDurationRuntimeFormat.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieScraperDurationRuntimeFormat.Location = New System.Drawing.Point(3, 26)
        Me.txtMovieScraperDurationRuntimeFormat.Name = "txtMovieScraperDurationRuntimeFormat"
        Me.txtMovieScraperDurationRuntimeFormat.Size = New System.Drawing.Size(160, 22)
        Me.txtMovieScraperDurationRuntimeFormat.TabIndex = 22
        '
        'gbMovieScraperCollectionOpts
        '
        Me.gbMovieScraperCollectionOpts.AutoSize = True
        Me.gbMovieScraperCollectionOpts.Controls.Add(Me.tblMovieScraperCollectionOpts)
        Me.gbMovieScraperCollectionOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieScraperCollectionOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieScraperCollectionOpts.Location = New System.Drawing.Point(352, 512)
        Me.gbMovieScraperCollectionOpts.Name = "gbMovieScraperCollectionOpts"
        Me.gbMovieScraperCollectionOpts.Size = New System.Drawing.Size(446, 164)
        Me.gbMovieScraperCollectionOpts.TabIndex = 78
        Me.gbMovieScraperCollectionOpts.TabStop = False
        Me.gbMovieScraperCollectionOpts.Text = "Collection"
        '
        'tblMovieScraperCollectionOpts
        '
        Me.tblMovieScraperCollectionOpts.AutoSize = True
        Me.tblMovieScraperCollectionOpts.ColumnCount = 2
        Me.tblMovieScraperCollectionOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperCollectionOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieScraperCollectionOpts.Controls.Add(Me.chkMovieScraperCollectionsYAMJCompatibleSets, 0, 2)
        Me.tblMovieScraperCollectionOpts.Controls.Add(Me.chkMovieScraperCollectionsAuto, 0, 0)
        Me.tblMovieScraperCollectionOpts.Controls.Add(Me.chkMovieScraperCollectionsExtendedInfo, 0, 1)
        Me.tblMovieScraperCollectionOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieScraperCollectionOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieScraperCollectionOpts.Name = "tblMovieScraperCollectionOpts"
        Me.tblMovieScraperCollectionOpts.RowCount = 4
        Me.tblMovieScraperCollectionOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCollectionOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCollectionOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCollectionOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieScraperCollectionOpts.Size = New System.Drawing.Size(440, 143)
        Me.tblMovieScraperCollectionOpts.TabIndex = 0
        '
        'chkMovieScraperCollectionsYAMJCompatibleSets
        '
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.AutoSize = True
        Me.tblMovieScraperCollectionOpts.SetColumnSpan(Me.chkMovieScraperCollectionsYAMJCompatibleSets, 2)
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.Location = New System.Drawing.Point(3, 49)
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.Name = "chkMovieScraperCollectionsYAMJCompatibleSets"
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.Size = New System.Drawing.Size(203, 17)
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.TabIndex = 2
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.Text = "Save YAMJ Compatible Sets to NFO"
        Me.chkMovieScraperCollectionsYAMJCompatibleSets.UseVisualStyleBackColor = True
        '
        'chkMovieScraperCollectionsAuto
        '
        Me.chkMovieScraperCollectionsAuto.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScraperCollectionsAuto.AutoSize = True
        Me.chkMovieScraperCollectionsAuto.Enabled = False
        Me.chkMovieScraperCollectionsAuto.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCollectionsAuto.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieScraperCollectionsAuto.Name = "chkMovieScraperCollectionsAuto"
        Me.chkMovieScraperCollectionsAuto.Size = New System.Drawing.Size(226, 17)
        Me.chkMovieScraperCollectionsAuto.TabIndex = 0
        Me.chkMovieScraperCollectionsAuto.Text = "Add Movie automatically to Collections"
        Me.chkMovieScraperCollectionsAuto.UseVisualStyleBackColor = True
        '
        'chkMovieScraperCollectionsExtendedInfo
        '
        Me.chkMovieScraperCollectionsExtendedInfo.AutoSize = True
        Me.chkMovieScraperCollectionsExtendedInfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScraperCollectionsExtendedInfo.Location = New System.Drawing.Point(3, 26)
        Me.chkMovieScraperCollectionsExtendedInfo.Name = "chkMovieScraperCollectionsExtendedInfo"
        Me.chkMovieScraperCollectionsExtendedInfo.Size = New System.Drawing.Size(411, 17)
        Me.chkMovieScraperCollectionsExtendedInfo.TabIndex = 1
        Me.chkMovieScraperCollectionsExtendedInfo.Text = "Save extended Collection information to NFO (Kodi 16.0 ""Jarvis"" and newer)"
        Me.chkMovieScraperCollectionsExtendedInfo.UseVisualStyleBackColor = True
        '
        'pnlSettingsTop
        '
        Me.pnlSettingsTop.AutoSize = True
        Me.pnlSettingsTop.Controls.Add(Me.tblSettingsTop)
        Me.pnlSettingsTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsTop.Name = "pnlSettingsTop"
        Me.pnlSettingsTop.Size = New System.Drawing.Size(932, 29)
        Me.pnlSettingsTop.TabIndex = 70
        '
        'tblSettingsTop
        '
        Me.tblSettingsTop.AutoSize = True
        Me.tblSettingsTop.ColumnCount = 5
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.Controls.Add(Me.lblSelectSetting, 0, 0)
        Me.tblSettingsTop.Controls.Add(Me.cbSelectSetting, 1, 0)
        Me.tblSettingsTop.Controls.Add(Me.Button1, 2, 0)
        Me.tblSettingsTop.Controls.Add(Me.Button3, 3, 0)
        Me.tblSettingsTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsTop.Name = "tblSettingsTop"
        Me.tblSettingsTop.RowCount = 1
        Me.tblSettingsTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.tblSettingsTop.Size = New System.Drawing.Size(932, 29)
        Me.tblSettingsTop.TabIndex = 0
        '
        'lblSelectSetting
        '
        Me.lblSelectSetting.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSelectSetting.AutoSize = True
        Me.lblSelectSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectSetting.Location = New System.Drawing.Point(3, 8)
        Me.lblSelectSetting.Name = "lblSelectSetting"
        Me.lblSelectSetting.Size = New System.Drawing.Size(87, 13)
        Me.lblSelectSetting.TabIndex = 79
        Me.lblSelectSetting.Text = "Select Setting"
        '
        'cbSelectSetting
        '
        Me.cbSelectSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSelectSetting.FormattingEnabled = True
        Me.cbSelectSetting.Location = New System.Drawing.Point(96, 3)
        Me.cbSelectSetting.Name = "cbSelectSetting"
        Me.cbSelectSetting.Size = New System.Drawing.Size(180, 21)
        Me.cbSelectSetting.TabIndex = 80
        '
        'Button1
        '
        Me.Button1.Image = Global.Ember_Media_Manager.My.Resources.Resources.save
        Me.Button1.Location = New System.Drawing.Point(282, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 81
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = Global.Ember_Media_Manager.My.Resources.Resources.menuAdd
        Me.Button3.Location = New System.Drawing.Point(311, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(23, 23)
        Me.Button3.TabIndex = 81
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmMovie_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 721)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovie_Data"
        Me.Text = "frmMovie_Data"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.pnlSettingsMain.ResumeLayout(False)
        Me.pnlSettingsMain.PerformLayout()
        Me.tblSettingsMain.ResumeLayout(False)
        Me.tblSettingsMain.PerformLayout()
        Me.gbScraperSettings.ResumeLayout(False)
        Me.gbScraperSettings.PerformLayout()
        Me.tblMovieScraperGlobalOpts.ResumeLayout(False)
        Me.tblMovieScraperGlobalOpts.PerformLayout()
        CType(Me.dgvSearchAdditional, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSearchInitial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOriginalTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReleaseDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPlot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOutline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTagline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUserRating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTop250, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMPAA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCertifications, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRuntime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTrailer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGenres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvActors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDirectors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCredits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCoutries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStudios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCollectionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMovieScraperCertificationOpts.ResumeLayout(False)
        Me.gbMovieScraperCertificationOpts.PerformLayout()
        Me.tblMovieScraperCertificationOpts.ResumeLayout(False)
        Me.tblMovieScraperCertificationOpts.PerformLayout()
        Me.gbMovieScraperMiscOpts.ResumeLayout(False)
        Me.gbMovieScraperMiscOpts.PerformLayout()
        Me.tblMovieScraperMiscOpts.ResumeLayout(False)
        Me.tblMovieScraperMiscOpts.PerformLayout()
        Me.gbMovieScraperMetaDataOpts.ResumeLayout(False)
        Me.gbMovieScraperMetaDataOpts.PerformLayout()
        Me.tblMovieScraperMetaDataOpts.ResumeLayout(False)
        Me.tblMovieScraperMetaDataOpts.PerformLayout()
        Me.gbMovieScraperDefFIExtOpts.ResumeLayout(False)
        Me.gbMovieScraperDefFIExtOpts.PerformLayout()
        Me.tblMovieScraperDefFIExtOpts.ResumeLayout(False)
        Me.tblMovieScraperDefFIExtOpts.PerformLayout()
        Me.gbMovieScraperDurationFormatOpts.ResumeLayout(False)
        Me.gbMovieScraperDurationFormatOpts.PerformLayout()
        Me.tblMovieScraperDurationFormatOpts.ResumeLayout(False)
        Me.tblMovieScraperDurationFormatOpts.PerformLayout()
        Me.gbMovieScraperCollectionOpts.ResumeLayout(False)
        Me.gbMovieScraperCollectionOpts.PerformLayout()
        Me.tblMovieScraperCollectionOpts.ResumeLayout(False)
        Me.tblMovieScraperCollectionOpts.PerformLayout()
        Me.pnlSettingsTop.ResumeLayout(False)
        Me.pnlSettingsTop.PerformLayout()
        Me.tblSettingsTop.ResumeLayout(False)
        Me.tblSettingsTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettingsMain As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbScraperSettings As Windows.Forms.GroupBox
    Friend WithEvents tblMovieScraperGlobalOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieLockCollectionID As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalHeaderLock As Windows.Forms.Label
    Friend WithEvents lblMovieScraperGlobalHeaderLimit As Windows.Forms.Label
    Friend WithEvents cbMovieScraperCertLang As Windows.Forms.ComboBox
    Friend WithEvents chkMovieLockRating As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockTitle As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalTitle As Windows.Forms.Label
    Friend WithEvents lblMovieScraperGlobalRating As Windows.Forms.Label
    Friend WithEvents lblMovieScraperGlobalCollectionID As Windows.Forms.Label
    Friend WithEvents lblMovieScraperGlobalLanguageA As Windows.Forms.Label
    Friend WithEvents lblMovieScraperGlobalLanguageV As Windows.Forms.Label
    Friend WithEvents lblMovieScraperGlobalCollections As Windows.Forms.Label
    Friend WithEvents chkMovieLockLanguageA As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockLanguageV As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperTitle As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperRating As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperCollectionID As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockCollections As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalOriginalTitle As Windows.Forms.Label
    Friend WithEvents chkMovieScraperOriginalTitle As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockOriginalTitle As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalYear As Windows.Forms.Label
    Friend WithEvents chkMovieScraperYear As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockYear As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalReleaseDate As Windows.Forms.Label
    Friend WithEvents chkMovieScraperRelease As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockReleaseDate As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalPlot As Windows.Forms.Label
    Friend WithEvents chkMovieScraperPlot As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockPlot As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalOutline As Windows.Forms.Label
    Friend WithEvents chkMovieScraperOutline As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockOutline As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalTagline As Windows.Forms.Label
    Friend WithEvents chkMovieScraperTagline As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockTagline As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalTop250 As Windows.Forms.Label
    Friend WithEvents chkMovieScraperTop250 As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockTop250 As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalMPAA As Windows.Forms.Label
    Friend WithEvents chkMovieScraperMPAA As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockMPAA As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalCertifications As Windows.Forms.Label
    Friend WithEvents chkMovieScraperCert As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockCert As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalRuntime As Windows.Forms.Label
    Friend WithEvents chkMovieScraperRuntime As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockRuntime As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalStudios As Windows.Forms.Label
    Friend WithEvents chkMovieScraperStudio As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockStudio As Windows.Forms.CheckBox
    Friend WithEvents txtMovieScraperStudioLimit As Windows.Forms.TextBox
    Friend WithEvents lblMovieScraperGlobalTags As Windows.Forms.Label
    Friend WithEvents chkMovieScraperTags As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockTags As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalTrailer As Windows.Forms.Label
    Friend WithEvents chkMovieScraperTrailer As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockTrailer As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalGenres As Windows.Forms.Label
    Friend WithEvents chkMovieScraperGenre As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockGenre As Windows.Forms.CheckBox
    Friend WithEvents txtMovieScraperGenreLimit As Windows.Forms.TextBox
    Friend WithEvents lblMovieScraperGlobalActors As Windows.Forms.Label
    Friend WithEvents chkMovieScraperCast As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockActors As Windows.Forms.CheckBox
    Friend WithEvents txtMovieScraperCastLimit As Windows.Forms.TextBox
    Friend WithEvents lblMovieScraperGlobalCountries As Windows.Forms.Label
    Friend WithEvents chkMovieScraperCountry As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockCountry As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalDirectors As Windows.Forms.Label
    Friend WithEvents chkMovieScraperDirector As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockDirector As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalCredits As Windows.Forms.Label
    Friend WithEvents chkMovieScraperCredits As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockCredits As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperGlobalUserRating As Windows.Forms.Label
    Friend WithEvents chkMovieScraperUserRating As Windows.Forms.CheckBox
    Friend WithEvents chkMovieLockUserRating As Windows.Forms.CheckBox
    Friend WithEvents gbMovieScraperCertificationOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieScraperCertificationOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieScraperCertOnlyValue As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperCertForMPAAFallback As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperCertForMPAA As Windows.Forms.CheckBox
    Friend WithEvents txtMovieScraperMPAANotRated As Windows.Forms.TextBox
    Friend WithEvents lblMovieScraperMPAANotRated As Windows.Forms.Label
    Friend WithEvents gbMovieScraperMiscOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieScraperMiscOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieScraperCleanPlotOutline As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperCleanFields As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperStudioWithImg As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperCastWithImg As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperDetailView As Windows.Forms.CheckBox
    Friend WithEvents lblMovieScraperOutlineLimit As Windows.Forms.Label
    Friend WithEvents txtMovieScraperOutlineLimit As Windows.Forms.TextBox
    Friend WithEvents chkMovieScraperPlotForOutline As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperXBMCTrailerFormat As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperPlotForOutlineIfEmpty As Windows.Forms.CheckBox
    Friend WithEvents gbMovieScraperMetaDataOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieScraperMetaDataOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieScraperDefFIExtOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieScraperDefFIExtOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieScraperDefFIExtRemove As Windows.Forms.Button
    Friend WithEvents txtMovieScraperDefFIExt As Windows.Forms.TextBox
    Friend WithEvents btnMovieScraperDefFIExtEdit As Windows.Forms.Button
    Friend WithEvents lstMovieScraperDefFIExt As Windows.Forms.ListBox
    Friend WithEvents btnMovieScraperDefFIExtAdd As Windows.Forms.Button
    Friend WithEvents lblMovieScraperDefFIExt As Windows.Forms.Label
    Friend WithEvents chkMovieScraperMetaDataScan As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperMetaDataIFOScan As Windows.Forms.CheckBox
    Friend WithEvents gbMovieScraperDurationFormatOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieScraperDurationFormatOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMovieScraperDurationRuntimeFormat As Windows.Forms.Label
    Friend WithEvents chkMovieScraperUseMDDuration As Windows.Forms.CheckBox
    Friend WithEvents txtMovieScraperDurationRuntimeFormat As Windows.Forms.TextBox
    Friend WithEvents gbMovieScraperCollectionOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieScraperCollectionOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieScraperCollectionsYAMJCompatibleSets As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperCollectionsAuto As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScraperCollectionsExtendedInfo As Windows.Forms.CheckBox
    Friend WithEvents dgvTitle As DataGridView
    Friend WithEvents dgvOriginalTitle As DataGridView
    Friend WithEvents dgvYear As DataGridView
    Friend WithEvents dgvReleaseDate As DataGridView
    Friend WithEvents dgvPlot As DataGridView
    Friend WithEvents dgvOutline As DataGridView
    Friend WithEvents dgvTagline As DataGridView
    Friend WithEvents dgvRating As DataGridView
    Friend WithEvents dgvUserRating As DataGridView
    Friend WithEvents dgvTop250 As DataGridView
    Friend WithEvents dgvMPAA As DataGridView
    Friend WithEvents dgvCertifications As DataGridView
    Friend WithEvents dgvRuntime As DataGridView
    Friend WithEvents dgvTags As DataGridView
    Friend WithEvents dgvTrailer As DataGridView
    Friend WithEvents dgvGenres As DataGridView
    Friend WithEvents dgvActors As DataGridView
    Friend WithEvents dgvDirectors As DataGridView
    Friend WithEvents dgvCredits As DataGridView
    Friend WithEvents dgvCoutries As DataGridView
    Friend WithEvents dgvStudios As DataGridView
    Friend WithEvents dgvCollectionID As DataGridView
    Friend WithEvents lblSelectSetting As Label
    Friend WithEvents cbSelectSetting As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents pnlSettingsMain As Panel
    Friend WithEvents pnlSettingsTop As Panel
    Friend WithEvents tblSettingsTop As TableLayoutPanel
    Friend WithEvents lblSearchInitial As Label
    Friend WithEvents lblSearchAdditional As Label
    Friend WithEvents dgvSearchInitial As DataGridView
    Friend WithEvents dgvSearchAdditional As DataGridView
    Friend WithEvents lblFields As Label
    Friend WithEvents lblSearch As Label
End Class
