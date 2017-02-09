<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovieSet_Image
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
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetImagesLanguageOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetImagesLanguageOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieSetImagesGetBlankImages = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetImagesGetEnglishImages = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetImagesMediaLanguageOnly = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetImagesForceLanguage = New System.Windows.Forms.CheckBox()
        Me.cbMovieSetImagesForcedLanguage = New System.Windows.Forms.ComboBox()
        Me.gbMovieSetImagesOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetImagesOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieSetImagesCacheEnabled = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetImagesDisplayImageSelect = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtFanartWidth = New System.Windows.Forms.TextBox()
        Me.txtBannerWidth = New System.Windows.Forms.TextBox()
        Me.txtFanartHeight = New System.Windows.Forms.TextBox()
        Me.txtPosterWidth = New System.Windows.Forms.TextBox()
        Me.chkClearArtKeepExisting = New System.Windows.Forms.CheckBox()
        Me.txtBannerHeight = New System.Windows.Forms.TextBox()
        Me.lblImageType = New System.Windows.Forms.Label()
        Me.txtPosterHeight = New System.Windows.Forms.TextBox()
        Me.chkClearLogoKeepExisting = New System.Windows.Forms.CheckBox()
        Me.chkBannerKeepExisting = New System.Windows.Forms.CheckBox()
        Me.chkPosterKeepExisting = New System.Windows.Forms.CheckBox()
        Me.chkFanartKeepExisting = New System.Windows.Forms.CheckBox()
        Me.chkDiscArtKeepExisting = New System.Windows.Forms.CheckBox()
        Me.chkLandscapeKeepExisting = New System.Windows.Forms.CheckBox()
        Me.chkLandscapePrefSizeOnly = New System.Windows.Forms.CheckBox()
        Me.chkDiscArtPrefSizeOnly = New System.Windows.Forms.CheckBox()
        Me.chkClearLogoPrefSizeOnly = New System.Windows.Forms.CheckBox()
        Me.chkClearArtPrefSizeOnly = New System.Windows.Forms.CheckBox()
        Me.cbLandscapePrefSize = New System.Windows.Forms.ComboBox()
        Me.cbDiscArtPrefSize = New System.Windows.Forms.ComboBox()
        Me.cbClearLogoPrefSize = New System.Windows.Forms.ComboBox()
        Me.lblPreferredSize = New System.Windows.Forms.Label()
        Me.chkFanartPrefSizeOnly = New System.Windows.Forms.CheckBox()
        Me.chkBannerPrefSizeOnly = New System.Windows.Forms.CheckBox()
        Me.chkPosterPrefSizeOnly = New System.Windows.Forms.CheckBox()
        Me.cbClearArtPrefSize = New System.Windows.Forms.ComboBox()
        Me.lblOnly = New System.Windows.Forms.Label()
        Me.cbFanartPrefSize = New System.Windows.Forms.ComboBox()
        Me.cbBannerPrefSize = New System.Windows.Forms.ComboBox()
        Me.cbPosterPrefSize = New System.Windows.Forms.ComboBox()
        Me.lblKeepExisting = New System.Windows.Forms.Label()
        Me.lblBanner = New System.Windows.Forms.Label()
        Me.lblClearArt = New System.Windows.Forms.Label()
        Me.lblClearLogo = New System.Windows.Forms.Label()
        Me.lblDiscArt = New System.Windows.Forms.Label()
        Me.lblLandscape = New System.Windows.Forms.Label()
        Me.lblPoster = New System.Windows.Forms.Label()
        Me.lblFanart = New System.Windows.Forms.Label()
        Me.dgvBanner = New System.Windows.Forms.DataGridView()
        Me.dgvClearArt = New System.Windows.Forms.DataGridView()
        Me.dgvClearLogo = New System.Windows.Forms.DataGridView()
        Me.dgvDiscArt = New System.Windows.Forms.DataGridView()
        Me.dgvFanart = New System.Windows.Forms.DataGridView()
        Me.dgvLandscape = New System.Windows.Forms.DataGridView()
        Me.dgvPoster = New System.Windows.Forms.DataGridView()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieSetImagesLanguageOpts.SuspendLayout()
        Me.tblMovieSetImagesLanguageOpts.SuspendLayout()
        Me.gbMovieSetImagesOpts.SuspendLayout()
        Me.tblMovieSetImagesOpts.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvClearArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvClearLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDiscArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFanart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLandscape, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPoster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.BackColor = System.Drawing.Color.White
        Me.pnlSettings.Controls.Add(Me.tblSettings)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(792, 354)
        Me.pnlSettings.TabIndex = 28
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
        Me.tblSettings.Controls.Add(Me.gbMovieSetImagesLanguageOpts, 1, 0)
        Me.tblSettings.Controls.Add(Me.gbMovieSetImagesOpts, 0, 0)
        Me.tblSettings.Controls.Add(Me.GroupBox1, 0, 1)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 3
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.Size = New System.Drawing.Size(792, 354)
        Me.tblSettings.TabIndex = 16
        '
        'gbMovieSetImagesLanguageOpts
        '
        Me.gbMovieSetImagesLanguageOpts.AutoSize = True
        Me.gbMovieSetImagesLanguageOpts.Controls.Add(Me.tblMovieSetImagesLanguageOpts)
        Me.gbMovieSetImagesLanguageOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetImagesLanguageOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieSetImagesLanguageOpts.Location = New System.Drawing.Point(307, 3)
        Me.gbMovieSetImagesLanguageOpts.Name = "gbMovieSetImagesLanguageOpts"
        Me.gbMovieSetImagesLanguageOpts.Size = New System.Drawing.Size(457, 117)
        Me.gbMovieSetImagesLanguageOpts.TabIndex = 18
        Me.gbMovieSetImagesLanguageOpts.TabStop = False
        Me.gbMovieSetImagesLanguageOpts.Text = "Preferred Language"
        '
        'tblMovieSetImagesLanguageOpts
        '
        Me.tblMovieSetImagesLanguageOpts.AutoSize = True
        Me.tblMovieSetImagesLanguageOpts.ColumnCount = 2
        Me.tblMovieSetImagesLanguageOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetImagesLanguageOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetImagesLanguageOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSetImagesLanguageOpts.Controls.Add(Me.chkMovieSetImagesGetBlankImages, 0, 3)
        Me.tblMovieSetImagesLanguageOpts.Controls.Add(Me.chkMovieSetImagesGetEnglishImages, 0, 2)
        Me.tblMovieSetImagesLanguageOpts.Controls.Add(Me.chkMovieSetImagesMediaLanguageOnly, 0, 1)
        Me.tblMovieSetImagesLanguageOpts.Controls.Add(Me.chkMovieSetImagesForceLanguage, 0, 0)
        Me.tblMovieSetImagesLanguageOpts.Controls.Add(Me.cbMovieSetImagesForcedLanguage, 1, 0)
        Me.tblMovieSetImagesLanguageOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetImagesLanguageOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetImagesLanguageOpts.Name = "tblMovieSetImagesLanguageOpts"
        Me.tblMovieSetImagesLanguageOpts.RowCount = 5
        Me.tblMovieSetImagesLanguageOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetImagesLanguageOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetImagesLanguageOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetImagesLanguageOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetImagesLanguageOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetImagesLanguageOpts.Size = New System.Drawing.Size(451, 96)
        Me.tblMovieSetImagesLanguageOpts.TabIndex = 97
        '
        'chkMovieSetImagesGetBlankImages
        '
        Me.chkMovieSetImagesGetBlankImages.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSetImagesGetBlankImages.AutoSize = True
        Me.chkMovieSetImagesGetBlankImages.Enabled = False
        Me.chkMovieSetImagesGetBlankImages.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetImagesGetBlankImages.Location = New System.Drawing.Point(3, 76)
        Me.chkMovieSetImagesGetBlankImages.Name = "chkMovieSetImagesGetBlankImages"
        Me.chkMovieSetImagesGetBlankImages.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkMovieSetImagesGetBlankImages.Size = New System.Drawing.Size(160, 17)
        Me.chkMovieSetImagesGetBlankImages.TabIndex = 17
        Me.chkMovieSetImagesGetBlankImages.Text = "Also Get Blank Images"
        Me.chkMovieSetImagesGetBlankImages.UseVisualStyleBackColor = True
        '
        'chkMovieSetImagesGetEnglishImages
        '
        Me.chkMovieSetImagesGetEnglishImages.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSetImagesGetEnglishImages.AutoSize = True
        Me.chkMovieSetImagesGetEnglishImages.Enabled = False
        Me.chkMovieSetImagesGetEnglishImages.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetImagesGetEnglishImages.Location = New System.Drawing.Point(3, 53)
        Me.chkMovieSetImagesGetEnglishImages.Name = "chkMovieSetImagesGetEnglishImages"
        Me.chkMovieSetImagesGetEnglishImages.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkMovieSetImagesGetEnglishImages.Size = New System.Drawing.Size(169, 17)
        Me.chkMovieSetImagesGetEnglishImages.TabIndex = 4
        Me.chkMovieSetImagesGetEnglishImages.Text = "Also Get English Images"
        Me.chkMovieSetImagesGetEnglishImages.UseVisualStyleBackColor = True
        '
        'chkMovieSetImagesMediaLanguageOnly
        '
        Me.chkMovieSetImagesMediaLanguageOnly.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSetImagesMediaLanguageOnly.AutoSize = True
        Me.chkMovieSetImagesMediaLanguageOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetImagesMediaLanguageOnly.Location = New System.Drawing.Point(3, 30)
        Me.chkMovieSetImagesMediaLanguageOnly.Name = "chkMovieSetImagesMediaLanguageOnly"
        Me.chkMovieSetImagesMediaLanguageOnly.Size = New System.Drawing.Size(237, 17)
        Me.chkMovieSetImagesMediaLanguageOnly.TabIndex = 15
        Me.chkMovieSetImagesMediaLanguageOnly.Text = "Only Get Images for the Media Language"
        Me.chkMovieSetImagesMediaLanguageOnly.UseVisualStyleBackColor = True
        '
        'chkMovieSetImagesForceLanguage
        '
        Me.chkMovieSetImagesForceLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSetImagesForceLanguage.AutoSize = True
        Me.chkMovieSetImagesForceLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetImagesForceLanguage.Location = New System.Drawing.Point(3, 5)
        Me.chkMovieSetImagesForceLanguage.Name = "chkMovieSetImagesForceLanguage"
        Me.chkMovieSetImagesForceLanguage.Size = New System.Drawing.Size(108, 17)
        Me.chkMovieSetImagesForceLanguage.TabIndex = 15
        Me.chkMovieSetImagesForceLanguage.Text = "Force Language"
        Me.chkMovieSetImagesForceLanguage.UseVisualStyleBackColor = True
        '
        'cbMovieSetImagesForcedLanguage
        '
        Me.cbMovieSetImagesForcedLanguage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbMovieSetImagesForcedLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovieSetImagesForcedLanguage.Enabled = False
        Me.cbMovieSetImagesForcedLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbMovieSetImagesForcedLanguage.FormattingEnabled = True
        Me.cbMovieSetImagesForcedLanguage.Location = New System.Drawing.Point(246, 3)
        Me.cbMovieSetImagesForcedLanguage.Name = "cbMovieSetImagesForcedLanguage"
        Me.cbMovieSetImagesForcedLanguage.Size = New System.Drawing.Size(202, 21)
        Me.cbMovieSetImagesForcedLanguage.TabIndex = 1
        '
        'gbMovieSetImagesOpts
        '
        Me.gbMovieSetImagesOpts.AutoSize = True
        Me.gbMovieSetImagesOpts.Controls.Add(Me.tblMovieSetImagesOpts)
        Me.gbMovieSetImagesOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetImagesOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieSetImagesOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetImagesOpts.Name = "gbMovieSetImagesOpts"
        Me.gbMovieSetImagesOpts.Size = New System.Drawing.Size(298, 117)
        Me.gbMovieSetImagesOpts.TabIndex = 16
        Me.gbMovieSetImagesOpts.TabStop = False
        Me.gbMovieSetImagesOpts.Text = "Images"
        '
        'tblMovieSetImagesOpts
        '
        Me.tblMovieSetImagesOpts.AutoSize = True
        Me.tblMovieSetImagesOpts.ColumnCount = 2
        Me.tblMovieSetImagesOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetImagesOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetImagesOpts.Controls.Add(Me.chkMovieSetImagesCacheEnabled, 0, 1)
        Me.tblMovieSetImagesOpts.Controls.Add(Me.chkMovieSetImagesDisplayImageSelect, 0, 0)
        Me.tblMovieSetImagesOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetImagesOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetImagesOpts.Name = "tblMovieSetImagesOpts"
        Me.tblMovieSetImagesOpts.RowCount = 3
        Me.tblMovieSetImagesOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetImagesOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetImagesOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetImagesOpts.Size = New System.Drawing.Size(292, 96)
        Me.tblMovieSetImagesOpts.TabIndex = 17
        '
        'chkMovieSetImagesCacheEnabled
        '
        Me.chkMovieSetImagesCacheEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSetImagesCacheEnabled.AutoSize = True
        Me.chkMovieSetImagesCacheEnabled.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkMovieSetImagesCacheEnabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetImagesCacheEnabled.Location = New System.Drawing.Point(3, 26)
        Me.chkMovieSetImagesCacheEnabled.Name = "chkMovieSetImagesCacheEnabled"
        Me.chkMovieSetImagesCacheEnabled.Size = New System.Drawing.Size(140, 17)
        Me.chkMovieSetImagesCacheEnabled.TabIndex = 4
        Me.chkMovieSetImagesCacheEnabled.Text = "Enable Image Caching"
        Me.chkMovieSetImagesCacheEnabled.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkMovieSetImagesCacheEnabled.UseVisualStyleBackColor = True
        '
        'chkMovieSetImagesDisplayImageSelect
        '
        Me.chkMovieSetImagesDisplayImageSelect.AutoSize = True
        Me.chkMovieSetImagesDisplayImageSelect.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkMovieSetImagesDisplayImageSelect.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieSetImagesDisplayImageSelect.Name = "chkMovieSetImagesDisplayImageSelect"
        Me.chkMovieSetImagesDisplayImageSelect.Size = New System.Drawing.Size(286, 17)
        Me.chkMovieSetImagesDisplayImageSelect.TabIndex = 3
        Me.chkMovieSetImagesDisplayImageSelect.Text = "Display ""Image Select"" dialog while single scraping"
        Me.chkMovieSetImagesDisplayImageSelect.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(761, 202)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtFanartWidth, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBannerWidth, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFanartHeight, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPosterWidth, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.chkClearArtKeepExisting, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBannerHeight, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImageType, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPosterHeight, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.chkClearLogoKeepExisting, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chkBannerKeepExisting, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPosterKeepExisting, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.chkFanartKeepExisting, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.chkDiscArtKeepExisting, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chkLandscapeKeepExisting, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.chkLandscapePrefSizeOnly, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.chkDiscArtPrefSizeOnly, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chkClearLogoPrefSizeOnly, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chkClearArtPrefSizeOnly, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbLandscapePrefSize, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cbDiscArtPrefSize, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cbClearLogoPrefSize, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPreferredSize, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkFanartPrefSizeOnly, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.chkBannerPrefSizeOnly, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPosterPrefSizeOnly, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.cbClearArtPrefSize, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOnly, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbFanartPrefSize, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cbBannerPrefSize, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbPosterPrefSize, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblKeepExisting, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBanner, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblClearArt, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblClearLogo, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDiscArt, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLandscape, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPoster, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFanart, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvBanner, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvClearArt, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvClearLogo, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDiscArt, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvFanart, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvLandscape, 6, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvPoster, 6, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblWidth, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHeight, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(755, 181)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtFanartWidth
        '
        Me.txtFanartWidth.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtFanartWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFanartWidth.Location = New System.Drawing.Point(297, 112)
        Me.txtFanartWidth.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFanartWidth.Name = "txtFanartWidth"
        Me.txtFanartWidth.Size = New System.Drawing.Size(34, 22)
        Me.txtFanartWidth.TabIndex = 6
        '
        'txtBannerWidth
        '
        Me.txtBannerWidth.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBannerWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBannerWidth.Location = New System.Drawing.Point(297, 20)
        Me.txtBannerWidth.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBannerWidth.Name = "txtBannerWidth"
        Me.txtBannerWidth.Size = New System.Drawing.Size(34, 22)
        Me.txtBannerWidth.TabIndex = 6
        '
        'txtFanartHeight
        '
        Me.txtFanartHeight.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtFanartHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFanartHeight.Location = New System.Drawing.Point(370, 112)
        Me.txtFanartHeight.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFanartHeight.Name = "txtFanartHeight"
        Me.txtFanartHeight.Size = New System.Drawing.Size(34, 22)
        Me.txtFanartHeight.TabIndex = 8
        '
        'txtPosterWidth
        '
        Me.txtPosterWidth.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtPosterWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosterWidth.Location = New System.Drawing.Point(297, 158)
        Me.txtPosterWidth.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPosterWidth.Name = "txtPosterWidth"
        Me.txtPosterWidth.Size = New System.Drawing.Size(34, 22)
        Me.txtPosterWidth.TabIndex = 6
        '
        'chkClearArtKeepExisting
        '
        Me.chkClearArtKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkClearArtKeepExisting.AutoSize = True
        Me.chkClearArtKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearArtKeepExisting.Location = New System.Drawing.Point(230, 47)
        Me.chkClearArtKeepExisting.Name = "chkClearArtKeepExisting"
        Me.chkClearArtKeepExisting.Size = New System.Drawing.Size(15, 14)
        Me.chkClearArtKeepExisting.TabIndex = 4
        Me.chkClearArtKeepExisting.UseVisualStyleBackColor = True
        '
        'txtBannerHeight
        '
        Me.txtBannerHeight.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBannerHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBannerHeight.Location = New System.Drawing.Point(370, 20)
        Me.txtBannerHeight.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBannerHeight.Name = "txtBannerHeight"
        Me.txtBannerHeight.Size = New System.Drawing.Size(34, 22)
        Me.txtBannerHeight.TabIndex = 8
        '
        'lblImageType
        '
        Me.lblImageType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblImageType.AutoSize = True
        Me.lblImageType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageType.Location = New System.Drawing.Point(3, 3)
        Me.lblImageType.Name = "lblImageType"
        Me.lblImageType.Size = New System.Drawing.Size(67, 13)
        Me.lblImageType.TabIndex = 0
        Me.lblImageType.Text = "Image Type"
        '
        'txtPosterHeight
        '
        Me.txtPosterHeight.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtPosterHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosterHeight.Location = New System.Drawing.Point(370, 158)
        Me.txtPosterHeight.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPosterHeight.Name = "txtPosterHeight"
        Me.txtPosterHeight.Size = New System.Drawing.Size(34, 22)
        Me.txtPosterHeight.TabIndex = 8
        '
        'chkClearLogoKeepExisting
        '
        Me.chkClearLogoKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkClearLogoKeepExisting.AutoSize = True
        Me.chkClearLogoKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearLogoKeepExisting.Location = New System.Drawing.Point(230, 70)
        Me.chkClearLogoKeepExisting.Name = "chkClearLogoKeepExisting"
        Me.chkClearLogoKeepExisting.Size = New System.Drawing.Size(15, 14)
        Me.chkClearLogoKeepExisting.TabIndex = 4
        Me.chkClearLogoKeepExisting.UseVisualStyleBackColor = True
        '
        'chkBannerKeepExisting
        '
        Me.chkBannerKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkBannerKeepExisting.AutoSize = True
        Me.chkBannerKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBannerKeepExisting.Location = New System.Drawing.Point(230, 24)
        Me.chkBannerKeepExisting.Name = "chkBannerKeepExisting"
        Me.chkBannerKeepExisting.Size = New System.Drawing.Size(15, 14)
        Me.chkBannerKeepExisting.TabIndex = 3
        Me.chkBannerKeepExisting.UseVisualStyleBackColor = True
        '
        'chkPosterKeepExisting
        '
        Me.chkPosterKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkPosterKeepExisting.AutoSize = True
        Me.chkPosterKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPosterKeepExisting.Location = New System.Drawing.Point(230, 162)
        Me.chkPosterKeepExisting.Name = "chkPosterKeepExisting"
        Me.chkPosterKeepExisting.Size = New System.Drawing.Size(15, 14)
        Me.chkPosterKeepExisting.TabIndex = 3
        Me.chkPosterKeepExisting.UseVisualStyleBackColor = True
        '
        'chkFanartKeepExisting
        '
        Me.chkFanartKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkFanartKeepExisting.AutoSize = True
        Me.chkFanartKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFanartKeepExisting.Location = New System.Drawing.Point(230, 116)
        Me.chkFanartKeepExisting.Name = "chkFanartKeepExisting"
        Me.chkFanartKeepExisting.Size = New System.Drawing.Size(15, 14)
        Me.chkFanartKeepExisting.TabIndex = 3
        Me.chkFanartKeepExisting.UseVisualStyleBackColor = True
        '
        'chkDiscArtKeepExisting
        '
        Me.chkDiscArtKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkDiscArtKeepExisting.AutoSize = True
        Me.chkDiscArtKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDiscArtKeepExisting.Location = New System.Drawing.Point(230, 93)
        Me.chkDiscArtKeepExisting.Name = "chkDiscArtKeepExisting"
        Me.chkDiscArtKeepExisting.Size = New System.Drawing.Size(15, 14)
        Me.chkDiscArtKeepExisting.TabIndex = 4
        Me.chkDiscArtKeepExisting.UseVisualStyleBackColor = True
        '
        'chkLandscapeKeepExisting
        '
        Me.chkLandscapeKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkLandscapeKeepExisting.AutoSize = True
        Me.chkLandscapeKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLandscapeKeepExisting.Location = New System.Drawing.Point(230, 139)
        Me.chkLandscapeKeepExisting.Name = "chkLandscapeKeepExisting"
        Me.chkLandscapeKeepExisting.Size = New System.Drawing.Size(15, 14)
        Me.chkLandscapeKeepExisting.TabIndex = 4
        Me.chkLandscapeKeepExisting.UseVisualStyleBackColor = True
        '
        'chkLandscapePrefSizeOnly
        '
        Me.chkLandscapePrefSizeOnly.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkLandscapePrefSizeOnly.AutoSize = True
        Me.chkLandscapePrefSizeOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLandscapePrefSizeOnly.Location = New System.Drawing.Point(170, 139)
        Me.chkLandscapePrefSizeOnly.Name = "chkLandscapePrefSizeOnly"
        Me.chkLandscapePrefSizeOnly.Size = New System.Drawing.Size(15, 14)
        Me.chkLandscapePrefSizeOnly.TabIndex = 2
        Me.chkLandscapePrefSizeOnly.UseVisualStyleBackColor = True
        '
        'chkDiscArtPrefSizeOnly
        '
        Me.chkDiscArtPrefSizeOnly.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkDiscArtPrefSizeOnly.AutoSize = True
        Me.chkDiscArtPrefSizeOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDiscArtPrefSizeOnly.Location = New System.Drawing.Point(170, 93)
        Me.chkDiscArtPrefSizeOnly.Name = "chkDiscArtPrefSizeOnly"
        Me.chkDiscArtPrefSizeOnly.Size = New System.Drawing.Size(15, 14)
        Me.chkDiscArtPrefSizeOnly.TabIndex = 2
        Me.chkDiscArtPrefSizeOnly.UseVisualStyleBackColor = True
        '
        'chkClearLogoPrefSizeOnly
        '
        Me.chkClearLogoPrefSizeOnly.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkClearLogoPrefSizeOnly.AutoSize = True
        Me.chkClearLogoPrefSizeOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearLogoPrefSizeOnly.Location = New System.Drawing.Point(170, 70)
        Me.chkClearLogoPrefSizeOnly.Name = "chkClearLogoPrefSizeOnly"
        Me.chkClearLogoPrefSizeOnly.Size = New System.Drawing.Size(15, 14)
        Me.chkClearLogoPrefSizeOnly.TabIndex = 2
        Me.chkClearLogoPrefSizeOnly.UseVisualStyleBackColor = True
        '
        'chkClearArtPrefSizeOnly
        '
        Me.chkClearArtPrefSizeOnly.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkClearArtPrefSizeOnly.AutoSize = True
        Me.chkClearArtPrefSizeOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearArtPrefSizeOnly.Location = New System.Drawing.Point(170, 47)
        Me.chkClearArtPrefSizeOnly.Name = "chkClearArtPrefSizeOnly"
        Me.chkClearArtPrefSizeOnly.Size = New System.Drawing.Size(15, 14)
        Me.chkClearArtPrefSizeOnly.TabIndex = 2
        Me.chkClearArtPrefSizeOnly.UseVisualStyleBackColor = True
        '
        'cbLandscapePrefSize
        '
        Me.cbLandscapePrefSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbLandscapePrefSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLandscapePrefSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbLandscapePrefSize.FormattingEnabled = True
        Me.cbLandscapePrefSize.Location = New System.Drawing.Point(76, 136)
        Me.cbLandscapePrefSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbLandscapePrefSize.Name = "cbLandscapePrefSize"
        Me.cbLandscapePrefSize.Size = New System.Drawing.Size(80, 21)
        Me.cbLandscapePrefSize.TabIndex = 1
        '
        'cbDiscArtPrefSize
        '
        Me.cbDiscArtPrefSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbDiscArtPrefSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDiscArtPrefSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbDiscArtPrefSize.FormattingEnabled = True
        Me.cbDiscArtPrefSize.Location = New System.Drawing.Point(76, 90)
        Me.cbDiscArtPrefSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbDiscArtPrefSize.Name = "cbDiscArtPrefSize"
        Me.cbDiscArtPrefSize.Size = New System.Drawing.Size(80, 21)
        Me.cbDiscArtPrefSize.TabIndex = 1
        '
        'cbClearLogoPrefSize
        '
        Me.cbClearLogoPrefSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbClearLogoPrefSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbClearLogoPrefSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbClearLogoPrefSize.FormattingEnabled = True
        Me.cbClearLogoPrefSize.Location = New System.Drawing.Point(76, 67)
        Me.cbClearLogoPrefSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbClearLogoPrefSize.Name = "cbClearLogoPrefSize"
        Me.cbClearLogoPrefSize.Size = New System.Drawing.Size(80, 21)
        Me.cbClearLogoPrefSize.TabIndex = 1
        '
        'lblPreferredSize
        '
        Me.lblPreferredSize.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPreferredSize.AutoSize = True
        Me.lblPreferredSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreferredSize.Location = New System.Drawing.Point(77, 3)
        Me.lblPreferredSize.Name = "lblPreferredSize"
        Me.lblPreferredSize.Size = New System.Drawing.Size(78, 13)
        Me.lblPreferredSize.TabIndex = 0
        Me.lblPreferredSize.Text = "Preferred Size"
        '
        'chkFanartPrefSizeOnly
        '
        Me.chkFanartPrefSizeOnly.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkFanartPrefSizeOnly.AutoSize = True
        Me.chkFanartPrefSizeOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFanartPrefSizeOnly.Location = New System.Drawing.Point(170, 116)
        Me.chkFanartPrefSizeOnly.Name = "chkFanartPrefSizeOnly"
        Me.chkFanartPrefSizeOnly.Size = New System.Drawing.Size(15, 14)
        Me.chkFanartPrefSizeOnly.TabIndex = 2
        Me.chkFanartPrefSizeOnly.UseVisualStyleBackColor = True
        '
        'chkBannerPrefSizeOnly
        '
        Me.chkBannerPrefSizeOnly.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkBannerPrefSizeOnly.AutoSize = True
        Me.chkBannerPrefSizeOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBannerPrefSizeOnly.Location = New System.Drawing.Point(170, 24)
        Me.chkBannerPrefSizeOnly.Name = "chkBannerPrefSizeOnly"
        Me.chkBannerPrefSizeOnly.Size = New System.Drawing.Size(15, 14)
        Me.chkBannerPrefSizeOnly.TabIndex = 2
        Me.chkBannerPrefSizeOnly.UseVisualStyleBackColor = True
        '
        'chkPosterPrefSizeOnly
        '
        Me.chkPosterPrefSizeOnly.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkPosterPrefSizeOnly.AutoSize = True
        Me.chkPosterPrefSizeOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPosterPrefSizeOnly.Location = New System.Drawing.Point(170, 162)
        Me.chkPosterPrefSizeOnly.Name = "chkPosterPrefSizeOnly"
        Me.chkPosterPrefSizeOnly.Size = New System.Drawing.Size(15, 14)
        Me.chkPosterPrefSizeOnly.TabIndex = 2
        Me.chkPosterPrefSizeOnly.UseVisualStyleBackColor = True
        '
        'cbClearArtPrefSize
        '
        Me.cbClearArtPrefSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbClearArtPrefSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbClearArtPrefSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbClearArtPrefSize.FormattingEnabled = True
        Me.cbClearArtPrefSize.Location = New System.Drawing.Point(76, 44)
        Me.cbClearArtPrefSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbClearArtPrefSize.Name = "cbClearArtPrefSize"
        Me.cbClearArtPrefSize.Size = New System.Drawing.Size(80, 21)
        Me.cbClearArtPrefSize.TabIndex = 1
        '
        'lblOnly
        '
        Me.lblOnly.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblOnly.AutoSize = True
        Me.lblOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnly.Location = New System.Drawing.Point(162, 3)
        Me.lblOnly.Name = "lblOnly"
        Me.lblOnly.Size = New System.Drawing.Size(31, 13)
        Me.lblOnly.TabIndex = 0
        Me.lblOnly.Text = "Only"
        '
        'cbFanartPrefSize
        '
        Me.cbFanartPrefSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbFanartPrefSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFanartPrefSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbFanartPrefSize.FormattingEnabled = True
        Me.cbFanartPrefSize.Location = New System.Drawing.Point(76, 113)
        Me.cbFanartPrefSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbFanartPrefSize.Name = "cbFanartPrefSize"
        Me.cbFanartPrefSize.Size = New System.Drawing.Size(80, 21)
        Me.cbFanartPrefSize.TabIndex = 1
        '
        'cbBannerPrefSize
        '
        Me.cbBannerPrefSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbBannerPrefSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBannerPrefSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbBannerPrefSize.FormattingEnabled = True
        Me.cbBannerPrefSize.Location = New System.Drawing.Point(76, 21)
        Me.cbBannerPrefSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbBannerPrefSize.Name = "cbBannerPrefSize"
        Me.cbBannerPrefSize.Size = New System.Drawing.Size(80, 21)
        Me.cbBannerPrefSize.TabIndex = 1
        '
        'cbPosterPrefSize
        '
        Me.cbPosterPrefSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPosterPrefSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbPosterPrefSize.FormattingEnabled = True
        Me.cbPosterPrefSize.Location = New System.Drawing.Point(76, 158)
        Me.cbPosterPrefSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbPosterPrefSize.Name = "cbPosterPrefSize"
        Me.cbPosterPrefSize.Size = New System.Drawing.Size(80, 21)
        Me.cbPosterPrefSize.TabIndex = 1
        '
        'lblKeepExisting
        '
        Me.lblKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblKeepExisting.AutoSize = True
        Me.lblKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeepExisting.Location = New System.Drawing.Point(199, 3)
        Me.lblKeepExisting.Name = "lblKeepExisting"
        Me.lblKeepExisting.Size = New System.Drawing.Size(77, 13)
        Me.lblKeepExisting.TabIndex = 0
        Me.lblKeepExisting.Text = "Keep Existing"
        '
        'lblBanner
        '
        Me.lblBanner.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBanner.AutoSize = True
        Me.lblBanner.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanner.Location = New System.Drawing.Point(3, 25)
        Me.lblBanner.Name = "lblBanner"
        Me.lblBanner.Size = New System.Drawing.Size(44, 13)
        Me.lblBanner.TabIndex = 1
        Me.lblBanner.Text = "Banner"
        '
        'lblClearArt
        '
        Me.lblClearArt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblClearArt.AutoSize = True
        Me.lblClearArt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClearArt.Location = New System.Drawing.Point(3, 48)
        Me.lblClearArt.Name = "lblClearArt"
        Me.lblClearArt.Size = New System.Drawing.Size(48, 13)
        Me.lblClearArt.TabIndex = 1
        Me.lblClearArt.Text = "ClearArt"
        '
        'lblClearLogo
        '
        Me.lblClearLogo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblClearLogo.AutoSize = True
        Me.lblClearLogo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClearLogo.Location = New System.Drawing.Point(3, 71)
        Me.lblClearLogo.Name = "lblClearLogo"
        Me.lblClearLogo.Size = New System.Drawing.Size(59, 13)
        Me.lblClearLogo.TabIndex = 1
        Me.lblClearLogo.Text = "ClearLogo"
        '
        'lblDiscArt
        '
        Me.lblDiscArt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDiscArt.AutoSize = True
        Me.lblDiscArt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscArt.Location = New System.Drawing.Point(3, 94)
        Me.lblDiscArt.Name = "lblDiscArt"
        Me.lblDiscArt.Size = New System.Drawing.Size(43, 13)
        Me.lblDiscArt.TabIndex = 1
        Me.lblDiscArt.Text = "DiscArt"
        '
        'lblLandscape
        '
        Me.lblLandscape.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLandscape.AutoSize = True
        Me.lblLandscape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLandscape.Location = New System.Drawing.Point(3, 140)
        Me.lblLandscape.Name = "lblLandscape"
        Me.lblLandscape.Size = New System.Drawing.Size(61, 13)
        Me.lblLandscape.TabIndex = 1
        Me.lblLandscape.Text = "Landscape"
        '
        'lblPoster
        '
        Me.lblPoster.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPoster.AutoSize = True
        Me.lblPoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoster.Location = New System.Drawing.Point(3, 163)
        Me.lblPoster.Name = "lblPoster"
        Me.lblPoster.Size = New System.Drawing.Size(39, 13)
        Me.lblPoster.TabIndex = 1
        Me.lblPoster.Text = "Poster"
        '
        'lblFanart
        '
        Me.lblFanart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFanart.AutoSize = True
        Me.lblFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFanart.Location = New System.Drawing.Point(3, 117)
        Me.lblFanart.Name = "lblFanart"
        Me.lblFanart.Size = New System.Drawing.Size(40, 13)
        Me.lblFanart.TabIndex = 1
        Me.lblFanart.Text = "Fanart"
        '
        'dgvBanner
        '
        Me.dgvBanner.Location = New System.Drawing.Point(424, 20)
        Me.dgvBanner.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvBanner.Name = "dgvBanner"
        Me.dgvBanner.Size = New System.Drawing.Size(100, 23)
        Me.dgvBanner.TabIndex = 71
        '
        'dgvClearArt
        '
        Me.dgvClearArt.Location = New System.Drawing.Point(424, 43)
        Me.dgvClearArt.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvClearArt.Name = "dgvClearArt"
        Me.dgvClearArt.Size = New System.Drawing.Size(100, 23)
        Me.dgvClearArt.TabIndex = 71
        '
        'dgvClearLogo
        '
        Me.dgvClearLogo.Location = New System.Drawing.Point(424, 66)
        Me.dgvClearLogo.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvClearLogo.Name = "dgvClearLogo"
        Me.dgvClearLogo.Size = New System.Drawing.Size(100, 23)
        Me.dgvClearLogo.TabIndex = 71
        '
        'dgvDiscArt
        '
        Me.dgvDiscArt.Location = New System.Drawing.Point(424, 89)
        Me.dgvDiscArt.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvDiscArt.Name = "dgvDiscArt"
        Me.dgvDiscArt.Size = New System.Drawing.Size(100, 23)
        Me.dgvDiscArt.TabIndex = 71
        '
        'dgvFanart
        '
        Me.dgvFanart.Location = New System.Drawing.Point(424, 112)
        Me.dgvFanart.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvFanart.Name = "dgvFanart"
        Me.dgvFanart.Size = New System.Drawing.Size(100, 23)
        Me.dgvFanart.TabIndex = 71
        '
        'dgvLandscape
        '
        Me.dgvLandscape.Location = New System.Drawing.Point(424, 135)
        Me.dgvLandscape.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvLandscape.Name = "dgvLandscape"
        Me.dgvLandscape.Size = New System.Drawing.Size(100, 23)
        Me.dgvLandscape.TabIndex = 71
        '
        'dgvPoster
        '
        Me.dgvPoster.Location = New System.Drawing.Point(424, 158)
        Me.dgvPoster.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvPoster.Name = "dgvPoster"
        Me.dgvPoster.Size = New System.Drawing.Size(100, 23)
        Me.dgvPoster.TabIndex = 71
        '
        'lblWidth
        '
        Me.lblWidth.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.Location = New System.Drawing.Point(282, 3)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(65, 13)
        Me.lblWidth.TabIndex = 0
        Me.lblWidth.Text = "Max Width"
        '
        'lblHeight
        '
        Me.lblHeight.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(353, 3)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(68, 13)
        Me.lblHeight.TabIndex = 0
        Me.lblHeight.Text = "Max Height"
        '
        'frmMovieSet_Image
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 354)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovieSet_Image"
        Me.Text = "frmMovieSet_Image"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieSetImagesLanguageOpts.ResumeLayout(False)
        Me.gbMovieSetImagesLanguageOpts.PerformLayout()
        Me.tblMovieSetImagesLanguageOpts.ResumeLayout(False)
        Me.tblMovieSetImagesLanguageOpts.PerformLayout()
        Me.gbMovieSetImagesOpts.ResumeLayout(False)
        Me.gbMovieSetImagesOpts.PerformLayout()
        Me.tblMovieSetImagesOpts.ResumeLayout(False)
        Me.tblMovieSetImagesOpts.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvBanner, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvClearArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvClearLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDiscArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFanart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLandscape, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPoster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetImagesLanguageOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetImagesLanguageOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieSetImagesGetBlankImages As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetImagesGetEnglishImages As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetImagesMediaLanguageOnly As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetImagesForceLanguage As Windows.Forms.CheckBox
    Friend WithEvents cbMovieSetImagesForcedLanguage As Windows.Forms.ComboBox
    Friend WithEvents gbMovieSetImagesOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetImagesOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieSetImagesCacheEnabled As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetImagesDisplayImageSelect As Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtFanartWidth As TextBox
    Friend WithEvents txtBannerWidth As TextBox
    Friend WithEvents txtFanartHeight As TextBox
    Friend WithEvents txtPosterWidth As TextBox
    Friend WithEvents chkClearArtKeepExisting As CheckBox
    Friend WithEvents txtBannerHeight As TextBox
    Friend WithEvents lblImageType As Label
    Friend WithEvents txtPosterHeight As TextBox
    Friend WithEvents chkClearLogoKeepExisting As CheckBox
    Friend WithEvents chkBannerKeepExisting As CheckBox
    Friend WithEvents chkPosterKeepExisting As CheckBox
    Friend WithEvents chkFanartKeepExisting As CheckBox
    Friend WithEvents chkDiscArtKeepExisting As CheckBox
    Friend WithEvents chkLandscapeKeepExisting As CheckBox
    Friend WithEvents chkLandscapePrefSizeOnly As CheckBox
    Friend WithEvents chkDiscArtPrefSizeOnly As CheckBox
    Friend WithEvents chkClearLogoPrefSizeOnly As CheckBox
    Friend WithEvents chkClearArtPrefSizeOnly As CheckBox
    Friend WithEvents cbLandscapePrefSize As ComboBox
    Friend WithEvents cbDiscArtPrefSize As ComboBox
    Friend WithEvents cbClearLogoPrefSize As ComboBox
    Friend WithEvents lblPreferredSize As Label
    Friend WithEvents chkFanartPrefSizeOnly As CheckBox
    Friend WithEvents chkBannerPrefSizeOnly As CheckBox
    Friend WithEvents chkPosterPrefSizeOnly As CheckBox
    Friend WithEvents cbClearArtPrefSize As ComboBox
    Friend WithEvents lblOnly As Label
    Friend WithEvents cbFanartPrefSize As ComboBox
    Friend WithEvents cbBannerPrefSize As ComboBox
    Friend WithEvents cbPosterPrefSize As ComboBox
    Friend WithEvents lblKeepExisting As Label
    Friend WithEvents lblBanner As Label
    Friend WithEvents lblClearArt As Label
    Friend WithEvents lblClearLogo As Label
    Friend WithEvents lblDiscArt As Label
    Friend WithEvents lblLandscape As Label
    Friend WithEvents lblPoster As Label
    Friend WithEvents lblFanart As Label
    Friend WithEvents dgvBanner As DataGridView
    Friend WithEvents dgvClearArt As DataGridView
    Friend WithEvents dgvClearLogo As DataGridView
    Friend WithEvents dgvDiscArt As DataGridView
    Friend WithEvents dgvFanart As DataGridView
    Friend WithEvents dgvLandscape As DataGridView
    Friend WithEvents dgvPoster As DataGridView
    Friend WithEvents lblWidth As Label
    Friend WithEvents lblHeight As Label
End Class
