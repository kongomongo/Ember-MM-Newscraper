<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovieSet_FileNaming
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovieSet_FileNaming))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetSourcesMiscOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetSourcesMiscOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieSetCleanDB = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetCleanFiles = New System.Windows.Forms.CheckBox()
        Me.gbMovieSetSourcesFilenamingOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetSourcesFileNamingOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.tcMovieSetFileNaming = New System.Windows.Forms.TabControl()
        Me.tpMovieSetFileNamingKodi = New System.Windows.Forms.TabPage()
        Me.tblMovieSetFileNamingKodi = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo = New System.Windows.Forms.Label()
        Me.lblKodiInterface = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath = New System.Windows.Forms.Label()
        Me.txtMovieSetPathExtended = New System.Windows.Forms.TextBox()
        Me.chkMovieSetClearArtExtended = New System.Windows.Forms.CheckBox()
        Me.btnMovieSetPathExtendedBrowse = New System.Windows.Forms.Button()
        Me.chkMovieSetClearLogoExtended = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetDiscArtExtended = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetFanartExtended = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetLandscapeExtended = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetPosterExtended = New System.Windows.Forms.CheckBox()
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner = New System.Windows.Forms.Label()
        Me.chkMovieSetBannerExtended = New System.Windows.Forms.CheckBox()
        Me.tpMovieSetFileNamingKodiAddons = New System.Windows.Forms.TabPage()
        Me.tblMovieSetSourcesFileNamingKodiAddons = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetMSAA = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetSourcesFileNamingMSAA = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieSetPathMSAABrowse = New System.Windows.Forms.Button()
        Me.pbMSAAInfo = New System.Windows.Forms.PictureBox()
        Me.txtMovieSetPathMSAA = New System.Windows.Forms.TextBox()
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath = New System.Windows.Forms.Label()
        Me.chkMovieSetBannerMSAA = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetClearArtMSAA = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetClearLogoMSAA = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetFanartMSAA = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetLandscapeMSAA = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetPosterMSAA = New System.Windows.Forms.CheckBox()
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster = New System.Windows.Forms.Label()
        Me.tpMovieSetSourcesFilenamingExpert = New System.Windows.Forms.TabPage()
        Me.tblMovieSetSourcesFileNamingExpert = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetSourcesFilenamingExpertOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetSourcesFileNamingExpertOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.tcMovieSetFileNamingExpert = New System.Windows.Forms.TabControl()
        Me.tpMovieSetFilenamingExpertSingle = New System.Windows.Forms.TabPage()
        Me.tblMovieSetSourcesFileNamingExpertSingle = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMovieSetSourcesFilenamingExpertSingleNFO = New System.Windows.Forms.Label()
        Me.txtMovieSetNFOExpertSingle = New System.Windows.Forms.TextBox()
        Me.lblMovieSetPosterExpertSingle = New System.Windows.Forms.Label()
        Me.txtMovieSetLandscapeExpertSingle = New System.Windows.Forms.TextBox()
        Me.txtMovieSetClearArtExpertSingle = New System.Windows.Forms.TextBox()
        Me.lblMovieSetLandscapeExpertSingle = New System.Windows.Forms.Label()
        Me.lblMovieSetSourcesFilenamingExpertSingleClearArt = New System.Windows.Forms.Label()
        Me.txtMovieSetPosterExpertSingle = New System.Windows.Forms.TextBox()
        Me.txtMovieSetClearLogoExpertSingle = New System.Windows.Forms.TextBox()
        Me.lblMovieSetSourcesFilenamingExpertSingleBanner = New System.Windows.Forms.Label()
        Me.txtMovieSetBannerExpertSingle = New System.Windows.Forms.TextBox()
        Me.lblMovieSetSourcesFilenamingExpertSingleFanart = New System.Windows.Forms.Label()
        Me.txtMovieSetFanartExpertSingle = New System.Windows.Forms.TextBox()
        Me.lblMovieSetSourcesClearLogoExpertSingle = New System.Windows.Forms.Label()
        Me.lblMovieSetPathExpertSingle = New System.Windows.Forms.Label()
        Me.txtMovieSetPathExpertSingle = New System.Windows.Forms.TextBox()
        Me.btnMovieSetPathExpertSingleBrowse = New System.Windows.Forms.Button()
        Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt = New System.Windows.Forms.Label()
        Me.txtMovieSetDiscArtExpertSingle = New System.Windows.Forms.TextBox()
        Me.chkMovieSetUseExpert = New System.Windows.Forms.CheckBox()
        Me.fbdBrowse = New System.Windows.Forms.FolderBrowserDialog()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieSetSourcesMiscOpts.SuspendLayout()
        Me.tblMovieSetSourcesMiscOpts.SuspendLayout()
        Me.gbMovieSetSourcesFilenamingOpts.SuspendLayout()
        Me.tblMovieSetSourcesFileNamingOpts.SuspendLayout()
        Me.tcMovieSetFileNaming.SuspendLayout()
        Me.tpMovieSetFileNamingKodi.SuspendLayout()
        Me.tblMovieSetFileNamingKodi.SuspendLayout()
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.SuspendLayout()
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.SuspendLayout()
        Me.tpMovieSetFileNamingKodiAddons.SuspendLayout()
        Me.tblMovieSetSourcesFileNamingKodiAddons.SuspendLayout()
        Me.gbMovieSetMSAA.SuspendLayout()
        Me.tblMovieSetSourcesFileNamingMSAA.SuspendLayout()
        CType(Me.pbMSAAInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMovieSetSourcesFilenamingExpert.SuspendLayout()
        Me.tblMovieSetSourcesFileNamingExpert.SuspendLayout()
        Me.gbMovieSetSourcesFilenamingExpertOpts.SuspendLayout()
        Me.tblMovieSetSourcesFileNamingExpertOpts.SuspendLayout()
        Me.tcMovieSetFileNamingExpert.SuspendLayout()
        Me.tpMovieSetFilenamingExpertSingle.SuspendLayout()
        Me.tblMovieSetSourcesFileNamingExpertSingle.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.BackColor = System.Drawing.Color.White
        Me.pnlSettings.Controls.Add(Me.tblSettings)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(535, 482)
        Me.pnlSettings.TabIndex = 26
        Me.pnlSettings.Visible = False
        '
        'tblSettings
        '
        Me.tblSettings.AutoScroll = True
        Me.tblSettings.AutoSize = True
        Me.tblSettings.ColumnCount = 3
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.Controls.Add(Me.gbMovieSetSourcesMiscOpts, 0, 0)
        Me.tblSettings.Controls.Add(Me.gbMovieSetSourcesFilenamingOpts, 0, 1)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 3
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.Size = New System.Drawing.Size(535, 482)
        Me.tblSettings.TabIndex = 10
        '
        'gbMovieSetSourcesMiscOpts
        '
        Me.gbMovieSetSourcesMiscOpts.AutoSize = True
        Me.gbMovieSetSourcesMiscOpts.Controls.Add(Me.tblMovieSetSourcesMiscOpts)
        Me.gbMovieSetSourcesMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetSourcesMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieSetSourcesMiscOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetSourcesMiscOpts.Name = "gbMovieSetSourcesMiscOpts"
        Me.gbMovieSetSourcesMiscOpts.Size = New System.Drawing.Size(252, 67)
        Me.gbMovieSetSourcesMiscOpts.TabIndex = 9
        Me.gbMovieSetSourcesMiscOpts.TabStop = False
        Me.gbMovieSetSourcesMiscOpts.Text = "Miscellaneous Options"
        '
        'tblMovieSetSourcesMiscOpts
        '
        Me.tblMovieSetSourcesMiscOpts.AutoSize = True
        Me.tblMovieSetSourcesMiscOpts.ColumnCount = 2
        Me.tblMovieSetSourcesMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesMiscOpts.Controls.Add(Me.chkMovieSetCleanDB, 0, 1)
        Me.tblMovieSetSourcesMiscOpts.Controls.Add(Me.chkMovieSetCleanFiles, 0, 0)
        Me.tblMovieSetSourcesMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetSourcesMiscOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetSourcesMiscOpts.Name = "tblMovieSetSourcesMiscOpts"
        Me.tblMovieSetSourcesMiscOpts.RowCount = 3
        Me.tblMovieSetSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesMiscOpts.Size = New System.Drawing.Size(246, 46)
        Me.tblMovieSetSourcesMiscOpts.TabIndex = 11
        '
        'chkMovieSetCleanDB
        '
        Me.chkMovieSetCleanDB.AutoSize = True
        Me.chkMovieSetCleanDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetCleanDB.Location = New System.Drawing.Point(3, 26)
        Me.chkMovieSetCleanDB.Name = "chkMovieSetCleanDB"
        Me.chkMovieSetCleanDB.Size = New System.Drawing.Size(218, 17)
        Me.chkMovieSetCleanDB.TabIndex = 9
        Me.chkMovieSetCleanDB.Text = "Clean database after updating library"
        Me.chkMovieSetCleanDB.UseVisualStyleBackColor = True
        '
        'chkMovieSetCleanFiles
        '
        Me.chkMovieSetCleanFiles.AutoSize = True
        Me.chkMovieSetCleanFiles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetCleanFiles.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieSetCleanFiles.Name = "chkMovieSetCleanFiles"
        Me.chkMovieSetCleanFiles.Size = New System.Drawing.Size(240, 17)
        Me.chkMovieSetCleanFiles.TabIndex = 8
        Me.chkMovieSetCleanFiles.Text = "Remove Images and NFOs with MovieSets"
        Me.chkMovieSetCleanFiles.UseVisualStyleBackColor = True
        '
        'gbMovieSetSourcesFilenamingOpts
        '
        Me.gbMovieSetSourcesFilenamingOpts.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.gbMovieSetSourcesFilenamingOpts, 2)
        Me.gbMovieSetSourcesFilenamingOpts.Controls.Add(Me.tblMovieSetSourcesFileNamingOpts)
        Me.gbMovieSetSourcesFilenamingOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetSourcesFilenamingOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieSetSourcesFilenamingOpts.Location = New System.Drawing.Point(3, 76)
        Me.gbMovieSetSourcesFilenamingOpts.Name = "gbMovieSetSourcesFilenamingOpts"
        Me.gbMovieSetSourcesFilenamingOpts.Size = New System.Drawing.Size(562, 397)
        Me.gbMovieSetSourcesFilenamingOpts.TabIndex = 8
        Me.gbMovieSetSourcesFilenamingOpts.TabStop = False
        Me.gbMovieSetSourcesFilenamingOpts.Text = "File Naming"
        '
        'tblMovieSetSourcesFileNamingOpts
        '
        Me.tblMovieSetSourcesFileNamingOpts.AutoSize = True
        Me.tblMovieSetSourcesFileNamingOpts.ColumnCount = 2
        Me.tblMovieSetSourcesFileNamingOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingOpts.Controls.Add(Me.tcMovieSetFileNaming, 0, 0)
        Me.tblMovieSetSourcesFileNamingOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetSourcesFileNamingOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetSourcesFileNamingOpts.Name = "tblMovieSetSourcesFileNamingOpts"
        Me.tblMovieSetSourcesFileNamingOpts.RowCount = 2
        Me.tblMovieSetSourcesFileNamingOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingOpts.Size = New System.Drawing.Size(556, 376)
        Me.tblMovieSetSourcesFileNamingOpts.TabIndex = 11
        '
        'tcMovieSetFileNaming
        '
        Me.tcMovieSetFileNaming.Controls.Add(Me.tpMovieSetFileNamingKodi)
        Me.tcMovieSetFileNaming.Controls.Add(Me.tpMovieSetFileNamingKodiAddons)
        Me.tcMovieSetFileNaming.Controls.Add(Me.tpMovieSetSourcesFilenamingExpert)
        Me.tcMovieSetFileNaming.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMovieSetFileNaming.Location = New System.Drawing.Point(3, 3)
        Me.tcMovieSetFileNaming.Name = "tcMovieSetFileNaming"
        Me.tcMovieSetFileNaming.SelectedIndex = 0
        Me.tcMovieSetFileNaming.Size = New System.Drawing.Size(550, 370)
        Me.tcMovieSetFileNaming.TabIndex = 7
        '
        'tpMovieSetFileNamingKodi
        '
        Me.tpMovieSetFileNamingKodi.Controls.Add(Me.tblMovieSetFileNamingKodi)
        Me.tpMovieSetFileNamingKodi.Location = New System.Drawing.Point(4, 22)
        Me.tpMovieSetFileNamingKodi.Name = "tpMovieSetFileNamingKodi"
        Me.tpMovieSetFileNamingKodi.Size = New System.Drawing.Size(542, 344)
        Me.tpMovieSetFileNamingKodi.TabIndex = 1
        Me.tpMovieSetFileNamingKodi.Text = "Kodi"
        Me.tpMovieSetFileNamingKodi.UseVisualStyleBackColor = True
        '
        'tblMovieSetFileNamingKodi
        '
        Me.tblMovieSetFileNamingKodi.AutoSize = True
        Me.tblMovieSetFileNamingKodi.ColumnCount = 2
        Me.tblMovieSetFileNamingKodi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetFileNamingKodi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetFileNamingKodi.Controls.Add(Me.gbMovieSetSourcesFilenamingKodiExtendedOpts, 0, 0)
        Me.tblMovieSetFileNamingKodi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetFileNamingKodi.Location = New System.Drawing.Point(0, 0)
        Me.tblMovieSetFileNamingKodi.Name = "tblMovieSetFileNamingKodi"
        Me.tblMovieSetFileNamingKodi.RowCount = 2
        Me.tblMovieSetFileNamingKodi.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetFileNamingKodi.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetFileNamingKodi.Size = New System.Drawing.Size(542, 344)
        Me.tblMovieSetFileNamingKodi.TabIndex = 0
        '
        'gbMovieSetSourcesFilenamingKodiExtendedOpts
        '
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.AutoSize = True
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.Controls.Add(Me.tblMovieSetSourcesFileNamingKodiExtendedOpts)
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.Name = "gbMovieSetSourcesFilenamingKodiExtendedOpts"
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.Size = New System.Drawing.Size(330, 229)
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.TabIndex = 0
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.TabStop = False
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.Text = "Extended Images"
        '
        'tblMovieSetSourcesFileNamingKodiExtendedOpts
        '
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.AutoSize = True
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.ColumnCount = 3
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt, 0, 2)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo, 0, 3)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblKodiInterface, 1, 0)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt, 0, 4)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiExtendedFanart, 0, 5)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape, 0, 6)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiExtendedPoster, 0, 7)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiExtendedPath, 0, 8)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.txtMovieSetPathExtended, 1, 8)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.chkMovieSetClearArtExtended, 1, 2)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.btnMovieSetPathExtendedBrowse, 2, 8)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.chkMovieSetClearLogoExtended, 1, 3)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.chkMovieSetDiscArtExtended, 1, 4)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.chkMovieSetFanartExtended, 1, 5)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.chkMovieSetLandscapeExtended, 1, 6)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.chkMovieSetPosterExtended, 1, 7)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiExtendedBanner, 0, 1)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Controls.Add(Me.chkMovieSetBannerExtended, 1, 1)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Name = "tblMovieSetSourcesFileNamingKodiExtendedOpts"
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowCount = 10
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.Size = New System.Drawing.Size(324, 208)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.TabIndex = 0
        '
        'lblMovieSetSourcesFilenamingKodiExtendedClearArt
        '
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt.Location = New System.Drawing.Point(3, 63)
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt.Name = "lblMovieSetSourcesFilenamingKodiExtendedClearArt"
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt.Size = New System.Drawing.Size(48, 13)
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt.TabIndex = 10
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearArt.Text = "ClearArt"
        '
        'lblMovieSetSourcesFilenamingKodiExtendedClearLogo
        '
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo.Location = New System.Drawing.Point(3, 83)
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo.Name = "lblMovieSetSourcesFilenamingKodiExtendedClearLogo"
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo.Size = New System.Drawing.Size(59, 13)
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo.TabIndex = 10
        Me.lblMovieSetSourcesFilenamingKodiExtendedClearLogo.Text = "ClearLogo"
        '
        'lblKodiInterface
        '
        Me.lblKodiInterface.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblKodiInterface.AutoSize = True
        Me.lblKodiInterface.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodiInterface.Location = New System.Drawing.Point(140, 13)
        Me.lblKodiInterface.Name = "lblKodiInterface"
        Me.lblKodiInterface.Size = New System.Drawing.Size(79, 13)
        Me.lblKodiInterface.TabIndex = 1
        Me.lblKodiInterface.Text = "Kodi Interface"
        Me.lblKodiInterface.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMovieSetSourcesFilenamingKodiExtendedDiscArt
        '
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt.Location = New System.Drawing.Point(3, 103)
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt.Name = "lblMovieSetSourcesFilenamingKodiExtendedDiscArt"
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt.Size = New System.Drawing.Size(43, 13)
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt.TabIndex = 10
        Me.lblMovieSetSourcesFilenamingKodiExtendedDiscArt.Text = "DiscArt"
        '
        'lblMovieSetSourcesFilenamingKodiExtendedFanart
        '
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart.Location = New System.Drawing.Point(3, 123)
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart.Name = "lblMovieSetSourcesFilenamingKodiExtendedFanart"
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart.Size = New System.Drawing.Size(40, 13)
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart.TabIndex = 10
        Me.lblMovieSetSourcesFilenamingKodiExtendedFanart.Text = "Fanart"
        '
        'lblMovieSetSourcesFilenamingKodiExtendedLandscape
        '
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape.Location = New System.Drawing.Point(3, 143)
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape.Name = "lblMovieSetSourcesFilenamingKodiExtendedLandscape"
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape.Size = New System.Drawing.Size(61, 13)
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape.TabIndex = 10
        Me.lblMovieSetSourcesFilenamingKodiExtendedLandscape.Text = "Landscape"
        '
        'lblMovieSetSourcesFilenamingKodiExtendedPoster
        '
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster.Location = New System.Drawing.Point(3, 163)
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster.Name = "lblMovieSetSourcesFilenamingKodiExtendedPoster"
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster.Size = New System.Drawing.Size(39, 13)
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster.TabIndex = 10
        Me.lblMovieSetSourcesFilenamingKodiExtendedPoster.Text = "Poster"
        '
        'lblMovieSetSourcesFilenamingKodiExtendedPath
        '
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath.Location = New System.Drawing.Point(3, 187)
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath.Name = "lblMovieSetSourcesFilenamingKodiExtendedPath"
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath.Size = New System.Drawing.Size(30, 13)
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath.TabIndex = 10
        Me.lblMovieSetSourcesFilenamingKodiExtendedPath.Text = "Path"
        '
        'txtMovieSetPathExtended
        '
        Me.txtMovieSetPathExtended.Location = New System.Drawing.Point(70, 183)
        Me.txtMovieSetPathExtended.Name = "txtMovieSetPathExtended"
        Me.txtMovieSetPathExtended.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetPathExtended.TabIndex = 11
        '
        'chkMovieSetClearArtExtended
        '
        Me.chkMovieSetClearArtExtended.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetClearArtExtended.AutoSize = True
        Me.chkMovieSetClearArtExtended.Location = New System.Drawing.Point(172, 63)
        Me.chkMovieSetClearArtExtended.Name = "chkMovieSetClearArtExtended"
        Me.chkMovieSetClearArtExtended.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetClearArtExtended.TabIndex = 11
        Me.chkMovieSetClearArtExtended.UseVisualStyleBackColor = True
        '
        'btnMovieSetPathExtendedBrowse
        '
        Me.btnMovieSetPathExtendedBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieSetPathExtendedBrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnMovieSetPathExtendedBrowse.Location = New System.Drawing.Point(296, 183)
        Me.btnMovieSetPathExtendedBrowse.Name = "btnMovieSetPathExtendedBrowse"
        Me.btnMovieSetPathExtendedBrowse.Size = New System.Drawing.Size(25, 22)
        Me.btnMovieSetPathExtendedBrowse.TabIndex = 31
        Me.btnMovieSetPathExtendedBrowse.Text = "..."
        Me.btnMovieSetPathExtendedBrowse.UseVisualStyleBackColor = True
        '
        'chkMovieSetClearLogoExtended
        '
        Me.chkMovieSetClearLogoExtended.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetClearLogoExtended.AutoSize = True
        Me.chkMovieSetClearLogoExtended.Location = New System.Drawing.Point(172, 83)
        Me.chkMovieSetClearLogoExtended.Name = "chkMovieSetClearLogoExtended"
        Me.chkMovieSetClearLogoExtended.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetClearLogoExtended.TabIndex = 11
        Me.chkMovieSetClearLogoExtended.UseVisualStyleBackColor = True
        '
        'chkMovieSetDiscArtExtended
        '
        Me.chkMovieSetDiscArtExtended.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetDiscArtExtended.AutoSize = True
        Me.chkMovieSetDiscArtExtended.Location = New System.Drawing.Point(172, 103)
        Me.chkMovieSetDiscArtExtended.Name = "chkMovieSetDiscArtExtended"
        Me.chkMovieSetDiscArtExtended.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetDiscArtExtended.TabIndex = 11
        Me.chkMovieSetDiscArtExtended.UseVisualStyleBackColor = True
        '
        'chkMovieSetFanartExtended
        '
        Me.chkMovieSetFanartExtended.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetFanartExtended.AutoSize = True
        Me.chkMovieSetFanartExtended.Location = New System.Drawing.Point(172, 123)
        Me.chkMovieSetFanartExtended.Name = "chkMovieSetFanartExtended"
        Me.chkMovieSetFanartExtended.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetFanartExtended.TabIndex = 11
        Me.chkMovieSetFanartExtended.UseVisualStyleBackColor = True
        '
        'chkMovieSetLandscapeExtended
        '
        Me.chkMovieSetLandscapeExtended.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetLandscapeExtended.AutoSize = True
        Me.chkMovieSetLandscapeExtended.Location = New System.Drawing.Point(172, 143)
        Me.chkMovieSetLandscapeExtended.Name = "chkMovieSetLandscapeExtended"
        Me.chkMovieSetLandscapeExtended.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetLandscapeExtended.TabIndex = 11
        Me.chkMovieSetLandscapeExtended.UseVisualStyleBackColor = True
        '
        'chkMovieSetPosterExtended
        '
        Me.chkMovieSetPosterExtended.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetPosterExtended.AutoSize = True
        Me.chkMovieSetPosterExtended.Location = New System.Drawing.Point(172, 163)
        Me.chkMovieSetPosterExtended.Name = "chkMovieSetPosterExtended"
        Me.chkMovieSetPosterExtended.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetPosterExtended.TabIndex = 11
        Me.chkMovieSetPosterExtended.UseVisualStyleBackColor = True
        '
        'lblMovieSetSourcesFilenamingKodiExtendedBanner
        '
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner.Location = New System.Drawing.Point(3, 43)
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner.Name = "lblMovieSetSourcesFilenamingKodiExtendedBanner"
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner.Size = New System.Drawing.Size(44, 13)
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner.TabIndex = 10
        Me.lblMovieSetSourcesFilenamingKodiExtendedBanner.Text = "Banner"
        '
        'chkMovieSetBannerExtended
        '
        Me.chkMovieSetBannerExtended.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetBannerExtended.AutoSize = True
        Me.chkMovieSetBannerExtended.Location = New System.Drawing.Point(172, 43)
        Me.chkMovieSetBannerExtended.Name = "chkMovieSetBannerExtended"
        Me.chkMovieSetBannerExtended.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetBannerExtended.TabIndex = 11
        Me.chkMovieSetBannerExtended.UseVisualStyleBackColor = True
        '
        'tpMovieSetFileNamingKodiAddons
        '
        Me.tpMovieSetFileNamingKodiAddons.Controls.Add(Me.tblMovieSetSourcesFileNamingKodiAddons)
        Me.tpMovieSetFileNamingKodiAddons.Location = New System.Drawing.Point(4, 22)
        Me.tpMovieSetFileNamingKodiAddons.Name = "tpMovieSetFileNamingKodiAddons"
        Me.tpMovieSetFileNamingKodiAddons.Size = New System.Drawing.Size(542, 344)
        Me.tpMovieSetFileNamingKodiAddons.TabIndex = 3
        Me.tpMovieSetFileNamingKodiAddons.Text = "Kodi Addons"
        Me.tpMovieSetFileNamingKodiAddons.UseVisualStyleBackColor = True
        '
        'tblMovieSetSourcesFileNamingKodiAddons
        '
        Me.tblMovieSetSourcesFileNamingKodiAddons.AutoSize = True
        Me.tblMovieSetSourcesFileNamingKodiAddons.ColumnCount = 2
        Me.tblMovieSetSourcesFileNamingKodiAddons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingKodiAddons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingKodiAddons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetSourcesFileNamingKodiAddons.Controls.Add(Me.gbMovieSetMSAA, 0, 0)
        Me.tblMovieSetSourcesFileNamingKodiAddons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetSourcesFileNamingKodiAddons.Location = New System.Drawing.Point(0, 0)
        Me.tblMovieSetSourcesFileNamingKodiAddons.Name = "tblMovieSetSourcesFileNamingKodiAddons"
        Me.tblMovieSetSourcesFileNamingKodiAddons.RowCount = 2
        Me.tblMovieSetSourcesFileNamingKodiAddons.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiAddons.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingKodiAddons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetSourcesFileNamingKodiAddons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetSourcesFileNamingKodiAddons.Size = New System.Drawing.Size(542, 344)
        Me.tblMovieSetSourcesFileNamingKodiAddons.TabIndex = 11
        '
        'gbMovieSetMSAA
        '
        Me.gbMovieSetMSAA.AutoSize = True
        Me.gbMovieSetMSAA.Controls.Add(Me.tblMovieSetSourcesFileNamingMSAA)
        Me.gbMovieSetMSAA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetMSAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieSetMSAA.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetMSAA.MinimumSize = New System.Drawing.Size(200, 0)
        Me.gbMovieSetMSAA.Name = "gbMovieSetMSAA"
        Me.gbMovieSetMSAA.Size = New System.Drawing.Size(310, 169)
        Me.gbMovieSetMSAA.TabIndex = 0
        Me.gbMovieSetMSAA.TabStop = False
        Me.gbMovieSetMSAA.Text = "Movie Set Artwork Automator"
        '
        'tblMovieSetSourcesFileNamingMSAA
        '
        Me.tblMovieSetSourcesFileNamingMSAA.AutoSize = True
        Me.tblMovieSetSourcesFileNamingMSAA.ColumnCount = 5
        Me.tblMovieSetSourcesFileNamingMSAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.btnMovieSetPathMSAABrowse, 3, 6)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.pbMSAAInfo, 2, 0)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.txtMovieSetPathMSAA, 1, 6)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiMSAAPath, 0, 6)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.chkMovieSetBannerMSAA, 1, 0)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.chkMovieSetClearArtMSAA, 1, 1)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.chkMovieSetClearLogoMSAA, 1, 2)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.chkMovieSetFanartMSAA, 1, 3)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.chkMovieSetLandscapeMSAA, 1, 4)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.chkMovieSetPosterMSAA, 1, 5)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiMSAABanner, 0, 0)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt, 0, 1)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo, 0, 2)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiMSAAFanart, 0, 3)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiMSAALandscape, 0, 4)
        Me.tblMovieSetSourcesFileNamingMSAA.Controls.Add(Me.lblMovieSetSourcesFilenamingKodiMSAAPoster, 0, 5)
        Me.tblMovieSetSourcesFileNamingMSAA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetSourcesFileNamingMSAA.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetSourcesFileNamingMSAA.Name = "tblMovieSetSourcesFileNamingMSAA"
        Me.tblMovieSetSourcesFileNamingMSAA.RowCount = 8
        Me.tblMovieSetSourcesFileNamingMSAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingMSAA.Size = New System.Drawing.Size(304, 148)
        Me.tblMovieSetSourcesFileNamingMSAA.TabIndex = 11
        '
        'btnMovieSetPathMSAABrowse
        '
        Me.btnMovieSetPathMSAABrowse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieSetPathMSAABrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnMovieSetPathMSAABrowse.Location = New System.Drawing.Point(276, 123)
        Me.btnMovieSetPathMSAABrowse.Name = "btnMovieSetPathMSAABrowse"
        Me.btnMovieSetPathMSAABrowse.Size = New System.Drawing.Size(25, 22)
        Me.btnMovieSetPathMSAABrowse.TabIndex = 1
        Me.btnMovieSetPathMSAABrowse.Text = "..."
        Me.btnMovieSetPathMSAABrowse.UseVisualStyleBackColor = True
        '
        'pbMSAAInfo
        '
        Me.pbMSAAInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblMovieSetSourcesFileNamingMSAA.SetColumnSpan(Me.pbMSAAInfo, 2)
        Me.pbMSAAInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbMSAAInfo.Image = CType(resources.GetObject("pbMSAAInfo.Image"), System.Drawing.Image)
        Me.pbMSAAInfo.Location = New System.Drawing.Point(221, 3)
        Me.pbMSAAInfo.Name = "pbMSAAInfo"
        Me.tblMovieSetSourcesFileNamingMSAA.SetRowSpan(Me.pbMSAAInfo, 5)
        Me.pbMSAAInfo.Size = New System.Drawing.Size(80, 80)
        Me.pbMSAAInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMSAAInfo.TabIndex = 8
        Me.pbMSAAInfo.TabStop = False
        '
        'txtMovieSetPathMSAA
        '
        Me.txtMovieSetPathMSAA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tblMovieSetSourcesFileNamingMSAA.SetColumnSpan(Me.txtMovieSetPathMSAA, 2)
        Me.txtMovieSetPathMSAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieSetPathMSAA.Location = New System.Drawing.Point(70, 123)
        Me.txtMovieSetPathMSAA.Name = "txtMovieSetPathMSAA"
        Me.txtMovieSetPathMSAA.Size = New System.Drawing.Size(200, 22)
        Me.txtMovieSetPathMSAA.TabIndex = 0
        '
        'lblMovieSetSourcesFilenamingKodiMSAAPath
        '
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath.Location = New System.Drawing.Point(3, 127)
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath.Name = "lblMovieSetSourcesFilenamingKodiMSAAPath"
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath.Size = New System.Drawing.Size(30, 13)
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath.TabIndex = 5
        Me.lblMovieSetSourcesFilenamingKodiMSAAPath.Text = "Path"
        '
        'chkMovieSetBannerMSAA
        '
        Me.chkMovieSetBannerMSAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetBannerMSAA.AutoSize = True
        Me.chkMovieSetBannerMSAA.Location = New System.Drawing.Point(70, 3)
        Me.chkMovieSetBannerMSAA.Name = "chkMovieSetBannerMSAA"
        Me.chkMovieSetBannerMSAA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetBannerMSAA.TabIndex = 8
        Me.chkMovieSetBannerMSAA.UseVisualStyleBackColor = True
        '
        'chkMovieSetClearArtMSAA
        '
        Me.chkMovieSetClearArtMSAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetClearArtMSAA.AutoSize = True
        Me.chkMovieSetClearArtMSAA.Location = New System.Drawing.Point(70, 23)
        Me.chkMovieSetClearArtMSAA.Name = "chkMovieSetClearArtMSAA"
        Me.chkMovieSetClearArtMSAA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetClearArtMSAA.TabIndex = 6
        Me.chkMovieSetClearArtMSAA.UseVisualStyleBackColor = True
        '
        'chkMovieSetClearLogoMSAA
        '
        Me.chkMovieSetClearLogoMSAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetClearLogoMSAA.AutoSize = True
        Me.chkMovieSetClearLogoMSAA.Location = New System.Drawing.Point(70, 43)
        Me.chkMovieSetClearLogoMSAA.Name = "chkMovieSetClearLogoMSAA"
        Me.chkMovieSetClearLogoMSAA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetClearLogoMSAA.TabIndex = 5
        Me.chkMovieSetClearLogoMSAA.UseVisualStyleBackColor = True
        '
        'chkMovieSetFanartMSAA
        '
        Me.chkMovieSetFanartMSAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetFanartMSAA.AutoSize = True
        Me.chkMovieSetFanartMSAA.Location = New System.Drawing.Point(70, 63)
        Me.chkMovieSetFanartMSAA.Name = "chkMovieSetFanartMSAA"
        Me.chkMovieSetFanartMSAA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetFanartMSAA.TabIndex = 2
        Me.chkMovieSetFanartMSAA.UseVisualStyleBackColor = True
        '
        'chkMovieSetLandscapeMSAA
        '
        Me.chkMovieSetLandscapeMSAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetLandscapeMSAA.AutoSize = True
        Me.chkMovieSetLandscapeMSAA.Location = New System.Drawing.Point(70, 83)
        Me.chkMovieSetLandscapeMSAA.Name = "chkMovieSetLandscapeMSAA"
        Me.chkMovieSetLandscapeMSAA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetLandscapeMSAA.TabIndex = 9
        Me.chkMovieSetLandscapeMSAA.UseVisualStyleBackColor = True
        '
        'chkMovieSetPosterMSAA
        '
        Me.chkMovieSetPosterMSAA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetPosterMSAA.AutoSize = True
        Me.chkMovieSetPosterMSAA.Location = New System.Drawing.Point(70, 103)
        Me.chkMovieSetPosterMSAA.Name = "chkMovieSetPosterMSAA"
        Me.chkMovieSetPosterMSAA.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetPosterMSAA.TabIndex = 1
        Me.chkMovieSetPosterMSAA.UseVisualStyleBackColor = True
        '
        'lblMovieSetSourcesFilenamingKodiMSAABanner
        '
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner.Location = New System.Drawing.Point(3, 3)
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner.Name = "lblMovieSetSourcesFilenamingKodiMSAABanner"
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner.Size = New System.Drawing.Size(44, 13)
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner.TabIndex = 5
        Me.lblMovieSetSourcesFilenamingKodiMSAABanner.Text = "Banner"
        '
        'lblMovieSetSourcesFilenamingKodiMSAAClearArt
        '
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt.Location = New System.Drawing.Point(3, 23)
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt.Name = "lblMovieSetSourcesFilenamingKodiMSAAClearArt"
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt.Size = New System.Drawing.Size(48, 13)
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt.TabIndex = 5
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearArt.Text = "ClearArt"
        '
        'lblMovieSetSourcesFilenamingKodiMSAAClearLogo
        '
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo.Location = New System.Drawing.Point(3, 43)
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo.Name = "lblMovieSetSourcesFilenamingKodiMSAAClearLogo"
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo.Size = New System.Drawing.Size(59, 13)
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo.TabIndex = 5
        Me.lblMovieSetSourcesFilenamingKodiMSAAClearLogo.Text = "ClearLogo"
        '
        'lblMovieSetSourcesFilenamingKodiMSAAFanart
        '
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart.Location = New System.Drawing.Point(3, 63)
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart.Name = "lblMovieSetSourcesFilenamingKodiMSAAFanart"
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart.Size = New System.Drawing.Size(40, 13)
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart.TabIndex = 5
        Me.lblMovieSetSourcesFilenamingKodiMSAAFanart.Text = "Fanart"
        '
        'lblMovieSetSourcesFilenamingKodiMSAALandscape
        '
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape.Location = New System.Drawing.Point(3, 83)
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape.Name = "lblMovieSetSourcesFilenamingKodiMSAALandscape"
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape.Size = New System.Drawing.Size(61, 13)
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape.TabIndex = 5
        Me.lblMovieSetSourcesFilenamingKodiMSAALandscape.Text = "Landscape"
        '
        'lblMovieSetSourcesFilenamingKodiMSAAPoster
        '
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster.AutoSize = True
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster.Location = New System.Drawing.Point(3, 103)
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster.Name = "lblMovieSetSourcesFilenamingKodiMSAAPoster"
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster.Size = New System.Drawing.Size(39, 13)
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster.TabIndex = 5
        Me.lblMovieSetSourcesFilenamingKodiMSAAPoster.Text = "Poster"
        '
        'tpMovieSetSourcesFilenamingExpert
        '
        Me.tpMovieSetSourcesFilenamingExpert.Controls.Add(Me.tblMovieSetSourcesFileNamingExpert)
        Me.tpMovieSetSourcesFilenamingExpert.Location = New System.Drawing.Point(4, 22)
        Me.tpMovieSetSourcesFilenamingExpert.Name = "tpMovieSetSourcesFilenamingExpert"
        Me.tpMovieSetSourcesFilenamingExpert.Size = New System.Drawing.Size(542, 344)
        Me.tpMovieSetSourcesFilenamingExpert.TabIndex = 2
        Me.tpMovieSetSourcesFilenamingExpert.Text = "Expert"
        Me.tpMovieSetSourcesFilenamingExpert.UseVisualStyleBackColor = True
        '
        'tblMovieSetSourcesFileNamingExpert
        '
        Me.tblMovieSetSourcesFileNamingExpert.AutoSize = True
        Me.tblMovieSetSourcesFileNamingExpert.ColumnCount = 2
        Me.tblMovieSetSourcesFileNamingExpert.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingExpert.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingExpert.Controls.Add(Me.gbMovieSetSourcesFilenamingExpertOpts, 1, 1)
        Me.tblMovieSetSourcesFileNamingExpert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetSourcesFileNamingExpert.Location = New System.Drawing.Point(0, 0)
        Me.tblMovieSetSourcesFileNamingExpert.Name = "tblMovieSetSourcesFileNamingExpert"
        Me.tblMovieSetSourcesFileNamingExpert.RowCount = 2
        Me.tblMovieSetSourcesFileNamingExpert.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpert.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpert.Size = New System.Drawing.Size(542, 344)
        Me.tblMovieSetSourcesFileNamingExpert.TabIndex = 10
        '
        'gbMovieSetSourcesFilenamingExpertOpts
        '
        Me.gbMovieSetSourcesFilenamingExpertOpts.AutoSize = True
        Me.gbMovieSetSourcesFilenamingExpertOpts.Controls.Add(Me.tblMovieSetSourcesFileNamingExpertOpts)
        Me.gbMovieSetSourcesFilenamingExpertOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetSourcesFilenamingExpertOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.gbMovieSetSourcesFilenamingExpertOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetSourcesFilenamingExpertOpts.Name = "gbMovieSetSourcesFilenamingExpertOpts"
        Me.gbMovieSetSourcesFilenamingExpertOpts.Size = New System.Drawing.Size(536, 340)
        Me.gbMovieSetSourcesFilenamingExpertOpts.TabIndex = 8
        Me.gbMovieSetSourcesFilenamingExpertOpts.TabStop = False
        Me.gbMovieSetSourcesFilenamingExpertOpts.Text = "Expert Settings"
        '
        'tblMovieSetSourcesFileNamingExpertOpts
        '
        Me.tblMovieSetSourcesFileNamingExpertOpts.AutoSize = True
        Me.tblMovieSetSourcesFileNamingExpertOpts.ColumnCount = 2
        Me.tblMovieSetSourcesFileNamingExpertOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingExpertOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingExpertOpts.Controls.Add(Me.tcMovieSetFileNamingExpert, 0, 1)
        Me.tblMovieSetSourcesFileNamingExpertOpts.Controls.Add(Me.chkMovieSetUseExpert, 0, 0)
        Me.tblMovieSetSourcesFileNamingExpertOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetSourcesFileNamingExpertOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetSourcesFileNamingExpertOpts.Name = "tblMovieSetSourcesFileNamingExpertOpts"
        Me.tblMovieSetSourcesFileNamingExpertOpts.RowCount = 3
        Me.tblMovieSetSourcesFileNamingExpertOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertOpts.Size = New System.Drawing.Size(530, 319)
        Me.tblMovieSetSourcesFileNamingExpertOpts.TabIndex = 10
        '
        'tcMovieSetFileNamingExpert
        '
        Me.tcMovieSetFileNamingExpert.Controls.Add(Me.tpMovieSetFilenamingExpertSingle)
        Me.tcMovieSetFileNamingExpert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMovieSetFileNamingExpert.Location = New System.Drawing.Point(3, 26)
        Me.tcMovieSetFileNamingExpert.Name = "tcMovieSetFileNamingExpert"
        Me.tcMovieSetFileNamingExpert.SelectedIndex = 0
        Me.tcMovieSetFileNamingExpert.Size = New System.Drawing.Size(508, 290)
        Me.tcMovieSetFileNamingExpert.TabIndex = 2
        '
        'tpMovieSetFilenamingExpertSingle
        '
        Me.tpMovieSetFilenamingExpertSingle.Controls.Add(Me.tblMovieSetSourcesFileNamingExpertSingle)
        Me.tpMovieSetFilenamingExpertSingle.Location = New System.Drawing.Point(4, 22)
        Me.tpMovieSetFilenamingExpertSingle.Name = "tpMovieSetFilenamingExpertSingle"
        Me.tpMovieSetFilenamingExpertSingle.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMovieSetFilenamingExpertSingle.Size = New System.Drawing.Size(500, 264)
        Me.tpMovieSetFilenamingExpertSingle.TabIndex = 0
        Me.tpMovieSetFilenamingExpertSingle.Text = "Single Folder"
        Me.tpMovieSetFilenamingExpertSingle.UseVisualStyleBackColor = True
        '
        'tblMovieSetSourcesFileNamingExpertSingle
        '
        Me.tblMovieSetSourcesFileNamingExpertSingle.AutoSize = True
        Me.tblMovieSetSourcesFileNamingExpertSingle.ColumnCount = 3
        Me.tblMovieSetSourcesFileNamingExpertSingle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetSourcesFilenamingExpertSingleNFO, 0, 6)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetNFOExpertSingle, 1, 6)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetPosterExpertSingle, 0, 7)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetLandscapeExpertSingle, 1, 5)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetClearArtExpertSingle, 1, 1)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetLandscapeExpertSingle, 0, 5)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetSourcesFilenamingExpertSingleClearArt, 0, 1)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetPosterExpertSingle, 1, 7)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetClearLogoExpertSingle, 1, 2)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetSourcesFilenamingExpertSingleBanner, 0, 0)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetBannerExpertSingle, 1, 0)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetSourcesFilenamingExpertSingleFanart, 0, 4)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetFanartExpertSingle, 1, 4)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetSourcesClearLogoExpertSingle, 0, 2)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetPathExpertSingle, 0, 8)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetPathExpertSingle, 1, 8)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.btnMovieSetPathExpertSingleBrowse, 2, 8)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt, 0, 3)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Controls.Add(Me.txtMovieSetDiscArtExpertSingle, 1, 3)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Location = New System.Drawing.Point(3, 3)
        Me.tblMovieSetSourcesFileNamingExpertSingle.Name = "tblMovieSetSourcesFileNamingExpertSingle"
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowCount = 10
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetSourcesFileNamingExpertSingle.Size = New System.Drawing.Size(494, 258)
        Me.tblMovieSetSourcesFileNamingExpertSingle.TabIndex = 10
        '
        'lblMovieSetSourcesFilenamingExpertSingleNFO
        '
        Me.lblMovieSetSourcesFilenamingExpertSingleNFO.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingExpertSingleNFO.AutoSize = True
        Me.lblMovieSetSourcesFilenamingExpertSingleNFO.Location = New System.Drawing.Point(3, 175)
        Me.lblMovieSetSourcesFilenamingExpertSingleNFO.Name = "lblMovieSetSourcesFilenamingExpertSingleNFO"
        Me.lblMovieSetSourcesFilenamingExpertSingleNFO.Size = New System.Drawing.Size(30, 13)
        Me.lblMovieSetSourcesFilenamingExpertSingleNFO.TabIndex = 9
        Me.lblMovieSetSourcesFilenamingExpertSingleNFO.Text = "NFO"
        '
        'txtMovieSetNFOExpertSingle
        '
        Me.txtMovieSetNFOExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetNFOExpertSingle.Enabled = False
        Me.txtMovieSetNFOExpertSingle.Location = New System.Drawing.Point(70, 171)
        Me.txtMovieSetNFOExpertSingle.Name = "txtMovieSetNFOExpertSingle"
        Me.txtMovieSetNFOExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetNFOExpertSingle.TabIndex = 3
        '
        'lblMovieSetPosterExpertSingle
        '
        Me.lblMovieSetPosterExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetPosterExpertSingle.AutoSize = True
        Me.lblMovieSetPosterExpertSingle.Location = New System.Drawing.Point(3, 203)
        Me.lblMovieSetPosterExpertSingle.Name = "lblMovieSetPosterExpertSingle"
        Me.lblMovieSetPosterExpertSingle.Size = New System.Drawing.Size(39, 13)
        Me.lblMovieSetPosterExpertSingle.TabIndex = 10
        Me.lblMovieSetPosterExpertSingle.Text = "Poster"
        '
        'txtMovieSetLandscapeExpertSingle
        '
        Me.txtMovieSetLandscapeExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetLandscapeExpertSingle.Enabled = False
        Me.txtMovieSetLandscapeExpertSingle.Location = New System.Drawing.Point(70, 143)
        Me.txtMovieSetLandscapeExpertSingle.Name = "txtMovieSetLandscapeExpertSingle"
        Me.txtMovieSetLandscapeExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetLandscapeExpertSingle.TabIndex = 11
        '
        'txtMovieSetClearArtExpertSingle
        '
        Me.txtMovieSetClearArtExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetClearArtExpertSingle.Enabled = False
        Me.txtMovieSetClearArtExpertSingle.Location = New System.Drawing.Point(70, 31)
        Me.txtMovieSetClearArtExpertSingle.Name = "txtMovieSetClearArtExpertSingle"
        Me.txtMovieSetClearArtExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetClearArtExpertSingle.TabIndex = 9
        '
        'lblMovieSetLandscapeExpertSingle
        '
        Me.lblMovieSetLandscapeExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetLandscapeExpertSingle.AutoSize = True
        Me.lblMovieSetLandscapeExpertSingle.Location = New System.Drawing.Point(3, 147)
        Me.lblMovieSetLandscapeExpertSingle.Name = "lblMovieSetLandscapeExpertSingle"
        Me.lblMovieSetLandscapeExpertSingle.Size = New System.Drawing.Size(61, 13)
        Me.lblMovieSetLandscapeExpertSingle.TabIndex = 19
        Me.lblMovieSetLandscapeExpertSingle.Text = "Landscape"
        '
        'lblMovieSetSourcesFilenamingExpertSingleClearArt
        '
        Me.lblMovieSetSourcesFilenamingExpertSingleClearArt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingExpertSingleClearArt.AutoSize = True
        Me.lblMovieSetSourcesFilenamingExpertSingleClearArt.Location = New System.Drawing.Point(3, 35)
        Me.lblMovieSetSourcesFilenamingExpertSingleClearArt.Name = "lblMovieSetSourcesFilenamingExpertSingleClearArt"
        Me.lblMovieSetSourcesFilenamingExpertSingleClearArt.Size = New System.Drawing.Size(48, 13)
        Me.lblMovieSetSourcesFilenamingExpertSingleClearArt.TabIndex = 28
        Me.lblMovieSetSourcesFilenamingExpertSingleClearArt.Text = "ClearArt"
        '
        'txtMovieSetPosterExpertSingle
        '
        Me.txtMovieSetPosterExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetPosterExpertSingle.Enabled = False
        Me.txtMovieSetPosterExpertSingle.Location = New System.Drawing.Point(70, 199)
        Me.txtMovieSetPosterExpertSingle.Name = "txtMovieSetPosterExpertSingle"
        Me.txtMovieSetPosterExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetPosterExpertSingle.TabIndex = 4
        '
        'txtMovieSetClearLogoExpertSingle
        '
        Me.txtMovieSetClearLogoExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetClearLogoExpertSingle.Enabled = False
        Me.txtMovieSetClearLogoExpertSingle.Location = New System.Drawing.Point(70, 59)
        Me.txtMovieSetClearLogoExpertSingle.Name = "txtMovieSetClearLogoExpertSingle"
        Me.txtMovieSetClearLogoExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetClearLogoExpertSingle.TabIndex = 8
        '
        'lblMovieSetSourcesFilenamingExpertSingleBanner
        '
        Me.lblMovieSetSourcesFilenamingExpertSingleBanner.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingExpertSingleBanner.AutoSize = True
        Me.lblMovieSetSourcesFilenamingExpertSingleBanner.Location = New System.Drawing.Point(3, 7)
        Me.lblMovieSetSourcesFilenamingExpertSingleBanner.Name = "lblMovieSetSourcesFilenamingExpertSingleBanner"
        Me.lblMovieSetSourcesFilenamingExpertSingleBanner.Size = New System.Drawing.Size(44, 13)
        Me.lblMovieSetSourcesFilenamingExpertSingleBanner.TabIndex = 17
        Me.lblMovieSetSourcesFilenamingExpertSingleBanner.Text = "Banner"
        '
        'txtMovieSetBannerExpertSingle
        '
        Me.txtMovieSetBannerExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetBannerExpertSingle.Enabled = False
        Me.txtMovieSetBannerExpertSingle.Location = New System.Drawing.Point(70, 3)
        Me.txtMovieSetBannerExpertSingle.Name = "txtMovieSetBannerExpertSingle"
        Me.txtMovieSetBannerExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetBannerExpertSingle.TabIndex = 7
        '
        'lblMovieSetSourcesFilenamingExpertSingleFanart
        '
        Me.lblMovieSetSourcesFilenamingExpertSingleFanart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingExpertSingleFanart.AutoSize = True
        Me.lblMovieSetSourcesFilenamingExpertSingleFanart.Location = New System.Drawing.Point(3, 119)
        Me.lblMovieSetSourcesFilenamingExpertSingleFanart.Name = "lblMovieSetSourcesFilenamingExpertSingleFanart"
        Me.lblMovieSetSourcesFilenamingExpertSingleFanart.Size = New System.Drawing.Size(40, 13)
        Me.lblMovieSetSourcesFilenamingExpertSingleFanart.TabIndex = 11
        Me.lblMovieSetSourcesFilenamingExpertSingleFanart.Text = "Fanart"
        '
        'txtMovieSetFanartExpertSingle
        '
        Me.txtMovieSetFanartExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetFanartExpertSingle.Enabled = False
        Me.txtMovieSetFanartExpertSingle.Location = New System.Drawing.Point(70, 115)
        Me.txtMovieSetFanartExpertSingle.Name = "txtMovieSetFanartExpertSingle"
        Me.txtMovieSetFanartExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetFanartExpertSingle.TabIndex = 5
        '
        'lblMovieSetSourcesClearLogoExpertSingle
        '
        Me.lblMovieSetSourcesClearLogoExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesClearLogoExpertSingle.AutoSize = True
        Me.lblMovieSetSourcesClearLogoExpertSingle.Location = New System.Drawing.Point(3, 63)
        Me.lblMovieSetSourcesClearLogoExpertSingle.Name = "lblMovieSetSourcesClearLogoExpertSingle"
        Me.lblMovieSetSourcesClearLogoExpertSingle.Size = New System.Drawing.Size(59, 13)
        Me.lblMovieSetSourcesClearLogoExpertSingle.TabIndex = 12
        Me.lblMovieSetSourcesClearLogoExpertSingle.Text = "ClearLogo"
        '
        'lblMovieSetPathExpertSingle
        '
        Me.lblMovieSetPathExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetPathExpertSingle.AutoSize = True
        Me.lblMovieSetPathExpertSingle.Location = New System.Drawing.Point(3, 231)
        Me.lblMovieSetPathExpertSingle.Name = "lblMovieSetPathExpertSingle"
        Me.lblMovieSetPathExpertSingle.Size = New System.Drawing.Size(30, 13)
        Me.lblMovieSetPathExpertSingle.TabIndex = 31
        Me.lblMovieSetPathExpertSingle.Text = "Path"
        '
        'txtMovieSetPathExpertSingle
        '
        Me.txtMovieSetPathExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetPathExpertSingle.Enabled = False
        Me.txtMovieSetPathExpertSingle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieSetPathExpertSingle.Location = New System.Drawing.Point(70, 227)
        Me.txtMovieSetPathExpertSingle.Name = "txtMovieSetPathExpertSingle"
        Me.txtMovieSetPathExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetPathExpertSingle.TabIndex = 29
        '
        'btnMovieSetPathExpertSingleBrowse
        '
        Me.btnMovieSetPathExpertSingleBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieSetPathExpertSingleBrowse.Enabled = False
        Me.btnMovieSetPathExpertSingleBrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnMovieSetPathExpertSingleBrowse.Location = New System.Drawing.Point(296, 227)
        Me.btnMovieSetPathExpertSingleBrowse.Name = "btnMovieSetPathExpertSingleBrowse"
        Me.btnMovieSetPathExpertSingleBrowse.Size = New System.Drawing.Size(25, 22)
        Me.btnMovieSetPathExpertSingleBrowse.TabIndex = 30
        Me.btnMovieSetPathExpertSingleBrowse.Text = "..."
        Me.btnMovieSetPathExpertSingleBrowse.UseVisualStyleBackColor = True
        '
        'lblMovieSetSourcesFilenamingExpertSingleDiscArt
        '
        Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt.AutoSize = True
        Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt.Location = New System.Drawing.Point(3, 91)
        Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt.Name = "lblMovieSetSourcesFilenamingExpertSingleDiscArt"
        Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt.Size = New System.Drawing.Size(43, 13)
        Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt.TabIndex = 11
        Me.lblMovieSetSourcesFilenamingExpertSingleDiscArt.Text = "DiscArt"
        '
        'txtMovieSetDiscArtExpertSingle
        '
        Me.txtMovieSetDiscArtExpertSingle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSetDiscArtExpertSingle.Enabled = False
        Me.txtMovieSetDiscArtExpertSingle.Location = New System.Drawing.Point(70, 87)
        Me.txtMovieSetDiscArtExpertSingle.Name = "txtMovieSetDiscArtExpertSingle"
        Me.txtMovieSetDiscArtExpertSingle.Size = New System.Drawing.Size(220, 22)
        Me.txtMovieSetDiscArtExpertSingle.TabIndex = 5
        '
        'chkMovieSetUseExpert
        '
        Me.chkMovieSetUseExpert.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSetUseExpert.AutoSize = True
        Me.chkMovieSetUseExpert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetUseExpert.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieSetUseExpert.Name = "chkMovieSetUseExpert"
        Me.chkMovieSetUseExpert.Size = New System.Drawing.Size(68, 17)
        Me.chkMovieSetUseExpert.TabIndex = 1
        Me.chkMovieSetUseExpert.Text = "Enabled"
        Me.chkMovieSetUseExpert.UseVisualStyleBackColor = True
        '
        'frmMovieSet_FileNaming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 482)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovieSet_FileNaming"
        Me.Text = "frmMovieSet_FileNaming"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieSetSourcesMiscOpts.ResumeLayout(False)
        Me.gbMovieSetSourcesMiscOpts.PerformLayout()
        Me.tblMovieSetSourcesMiscOpts.ResumeLayout(False)
        Me.tblMovieSetSourcesMiscOpts.PerformLayout()
        Me.gbMovieSetSourcesFilenamingOpts.ResumeLayout(False)
        Me.gbMovieSetSourcesFilenamingOpts.PerformLayout()
        Me.tblMovieSetSourcesFileNamingOpts.ResumeLayout(False)
        Me.tcMovieSetFileNaming.ResumeLayout(False)
        Me.tpMovieSetFileNamingKodi.ResumeLayout(False)
        Me.tpMovieSetFileNamingKodi.PerformLayout()
        Me.tblMovieSetFileNamingKodi.ResumeLayout(False)
        Me.tblMovieSetFileNamingKodi.PerformLayout()
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.ResumeLayout(False)
        Me.gbMovieSetSourcesFilenamingKodiExtendedOpts.PerformLayout()
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.ResumeLayout(False)
        Me.tblMovieSetSourcesFileNamingKodiExtendedOpts.PerformLayout()
        Me.tpMovieSetFileNamingKodiAddons.ResumeLayout(False)
        Me.tpMovieSetFileNamingKodiAddons.PerformLayout()
        Me.tblMovieSetSourcesFileNamingKodiAddons.ResumeLayout(False)
        Me.tblMovieSetSourcesFileNamingKodiAddons.PerformLayout()
        Me.gbMovieSetMSAA.ResumeLayout(False)
        Me.gbMovieSetMSAA.PerformLayout()
        Me.tblMovieSetSourcesFileNamingMSAA.ResumeLayout(False)
        Me.tblMovieSetSourcesFileNamingMSAA.PerformLayout()
        CType(Me.pbMSAAInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMovieSetSourcesFilenamingExpert.ResumeLayout(False)
        Me.tpMovieSetSourcesFilenamingExpert.PerformLayout()
        Me.tblMovieSetSourcesFileNamingExpert.ResumeLayout(False)
        Me.tblMovieSetSourcesFileNamingExpert.PerformLayout()
        Me.gbMovieSetSourcesFilenamingExpertOpts.ResumeLayout(False)
        Me.gbMovieSetSourcesFilenamingExpertOpts.PerformLayout()
        Me.tblMovieSetSourcesFileNamingExpertOpts.ResumeLayout(False)
        Me.tblMovieSetSourcesFileNamingExpertOpts.PerformLayout()
        Me.tcMovieSetFileNamingExpert.ResumeLayout(False)
        Me.tpMovieSetFilenamingExpertSingle.ResumeLayout(False)
        Me.tpMovieSetFilenamingExpertSingle.PerformLayout()
        Me.tblMovieSetSourcesFileNamingExpertSingle.ResumeLayout(False)
        Me.tblMovieSetSourcesFileNamingExpertSingle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetSourcesMiscOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetSourcesMiscOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieSetCleanDB As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetCleanFiles As Windows.Forms.CheckBox
    Friend WithEvents gbMovieSetSourcesFilenamingOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetSourcesFileNamingOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents tcMovieSetFileNaming As Windows.Forms.TabControl
    Friend WithEvents tpMovieSetFileNamingKodi As Windows.Forms.TabPage
    Friend WithEvents tblMovieSetFileNamingKodi As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetSourcesFilenamingKodiExtendedOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetSourcesFileNamingKodiExtendedOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMovieSetSourcesFilenamingKodiExtendedClearArt As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiExtendedClearLogo As Windows.Forms.Label
    Friend WithEvents lblKodiInterface As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiExtendedDiscArt As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiExtendedFanart As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiExtendedLandscape As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiExtendedPoster As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiExtendedPath As Windows.Forms.Label
    Friend WithEvents txtMovieSetPathExtended As Windows.Forms.TextBox
    Friend WithEvents chkMovieSetClearArtExtended As Windows.Forms.CheckBox
    Friend WithEvents btnMovieSetPathExtendedBrowse As Windows.Forms.Button
    Friend WithEvents chkMovieSetClearLogoExtended As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetDiscArtExtended As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetFanartExtended As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetLandscapeExtended As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetPosterExtended As Windows.Forms.CheckBox
    Friend WithEvents lblMovieSetSourcesFilenamingKodiExtendedBanner As Windows.Forms.Label
    Friend WithEvents chkMovieSetBannerExtended As Windows.Forms.CheckBox
    Friend WithEvents tpMovieSetFileNamingKodiAddons As Windows.Forms.TabPage
    Friend WithEvents tblMovieSetSourcesFileNamingKodiAddons As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetMSAA As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetSourcesFileNamingMSAA As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieSetPathMSAABrowse As Windows.Forms.Button
    Friend WithEvents pbMSAAInfo As Windows.Forms.PictureBox
    Friend WithEvents txtMovieSetPathMSAA As Windows.Forms.TextBox
    Friend WithEvents lblMovieSetSourcesFilenamingKodiMSAAPath As Windows.Forms.Label
    Friend WithEvents chkMovieSetBannerMSAA As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetClearArtMSAA As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetClearLogoMSAA As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetFanartMSAA As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetLandscapeMSAA As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetPosterMSAA As Windows.Forms.CheckBox
    Friend WithEvents lblMovieSetSourcesFilenamingKodiMSAABanner As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiMSAAClearArt As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiMSAAClearLogo As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiMSAAFanart As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiMSAALandscape As Windows.Forms.Label
    Friend WithEvents lblMovieSetSourcesFilenamingKodiMSAAPoster As Windows.Forms.Label
    Friend WithEvents tpMovieSetSourcesFilenamingExpert As Windows.Forms.TabPage
    Friend WithEvents tblMovieSetSourcesFileNamingExpert As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetSourcesFilenamingExpertOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetSourcesFileNamingExpertOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieSetUseExpert As Windows.Forms.CheckBox
    Friend WithEvents fbdBrowse As Windows.Forms.FolderBrowserDialog
    Friend WithEvents tcMovieSetFileNamingExpert As TabControl
    Friend WithEvents tpMovieSetFilenamingExpertSingle As TabPage
    Friend WithEvents tblMovieSetSourcesFileNamingExpertSingle As TableLayoutPanel
    Friend WithEvents lblMovieSetSourcesFilenamingExpertSingleNFO As Label
    Friend WithEvents txtMovieSetNFOExpertSingle As TextBox
    Friend WithEvents lblMovieSetPosterExpertSingle As Label
    Friend WithEvents txtMovieSetLandscapeExpertSingle As TextBox
    Friend WithEvents txtMovieSetClearArtExpertSingle As TextBox
    Friend WithEvents lblMovieSetLandscapeExpertSingle As Label
    Friend WithEvents lblMovieSetSourcesFilenamingExpertSingleClearArt As Label
    Friend WithEvents txtMovieSetPosterExpertSingle As TextBox
    Friend WithEvents txtMovieSetClearLogoExpertSingle As TextBox
    Friend WithEvents lblMovieSetSourcesFilenamingExpertSingleBanner As Label
    Friend WithEvents txtMovieSetBannerExpertSingle As TextBox
    Friend WithEvents lblMovieSetSourcesFilenamingExpertSingleFanart As Label
    Friend WithEvents txtMovieSetFanartExpertSingle As TextBox
    Friend WithEvents lblMovieSetSourcesClearLogoExpertSingle As Label
    Friend WithEvents lblMovieSetPathExpertSingle As Label
    Friend WithEvents txtMovieSetPathExpertSingle As TextBox
    Friend WithEvents btnMovieSetPathExpertSingleBrowse As Button
    Friend WithEvents lblMovieSetSourcesFilenamingExpertSingleDiscArt As Label
    Friend WithEvents txtMovieSetDiscArtExpertSingle As TextBox
End Class
