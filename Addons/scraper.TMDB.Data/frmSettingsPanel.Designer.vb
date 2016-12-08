<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingsPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettingsPanel))
        Me.gbGlobal = New System.Windows.Forms.GroupBox()
        Me.tblScraperOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.lblApiKey = New System.Windows.Forms.Label()
        Me.txtApiKey = New EmberAPI.FormUtils.TextBox_with_Watermark()
        Me.pbApiKeyInfo = New System.Windows.Forms.PictureBox()
        Me.chkIncludeAdultItems_Movie = New System.Windows.Forms.CheckBox()
        Me.chkFallBackToEng_Movie = New System.Windows.Forms.CheckBox()
        Me.chkSearchDeviant_Movie = New System.Windows.Forms.CheckBox()
        Me.pnlSettingsTop = New System.Windows.Forms.Panel()
        Me.tblSettingsTop = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.pnlSettingsMain = New System.Windows.Forms.Panel()
        Me.tblSettingsMain = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovie = New System.Windows.Forms.GroupBox()
        Me.tblMovie = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSet = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.chkFallBackToEng_MovieSet = New System.Windows.Forms.CheckBox()
        Me.chkIncludeAdultItems_MovieSet = New System.Windows.Forms.CheckBox()
        Me.gbTVShow = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.chkFallBackToEng_TV = New System.Windows.Forms.CheckBox()
        Me.chkIncludeAdultItems_TV = New System.Windows.Forms.CheckBox()
        Me.pnlSettingsBottom = New System.Windows.Forms.Panel()
        Me.tblSettingsBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.gbGlobal.SuspendLayout()
        Me.tblScraperOpts.SuspendLayout()
        CType(Me.pbApiKeyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSettingsTop.SuspendLayout()
        Me.pnlSettings.SuspendLayout()
        Me.pnlSettingsMain.SuspendLayout()
        Me.tblSettingsMain.SuspendLayout()
        Me.gbMovie.SuspendLayout()
        Me.tblMovie.SuspendLayout()
        Me.gbMovieSet.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbTVShow.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnlSettingsBottom.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbGlobal
        '
        Me.gbGlobal.AutoSize = True
        Me.gbGlobal.Controls.Add(Me.tblScraperOpts)
        Me.gbGlobal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbGlobal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbGlobal.Location = New System.Drawing.Point(3, 3)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Size = New System.Drawing.Size(350, 49)
        Me.gbGlobal.TabIndex = 1
        Me.gbGlobal.TabStop = False
        Me.gbGlobal.Text = "Global"
        '
        'tblScraperOpts
        '
        Me.tblScraperOpts.AutoSize = True
        Me.tblScraperOpts.ColumnCount = 4
        Me.tblScraperOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperOpts.Controls.Add(Me.lblApiKey, 0, 0)
        Me.tblScraperOpts.Controls.Add(Me.txtApiKey, 1, 0)
        Me.tblScraperOpts.Controls.Add(Me.pbApiKeyInfo, 2, 0)
        Me.tblScraperOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblScraperOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblScraperOpts.Name = "tblScraperOpts"
        Me.tblScraperOpts.RowCount = 2
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScraperOpts.Size = New System.Drawing.Size(344, 28)
        Me.tblScraperOpts.TabIndex = 98
        '
        'lblApiKey
        '
        Me.lblApiKey.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblApiKey.AutoSize = True
        Me.lblApiKey.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApiKey.Location = New System.Drawing.Point(3, 7)
        Me.lblApiKey.Name = "lblApiKey"
        Me.lblApiKey.Size = New System.Drawing.Size(80, 13)
        Me.lblApiKey.TabIndex = 0
        Me.lblApiKey.Text = "TMDB Api Key:"
        '
        'txtApiKey
        '
        Me.txtApiKey.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtApiKey.Location = New System.Drawing.Point(89, 3)
        Me.txtApiKey.Name = "txtApiKey"
        Me.txtApiKey.Size = New System.Drawing.Size(230, 22)
        Me.txtApiKey.TabIndex = 6
        Me.txtApiKey.WatermarkColor = System.Drawing.Color.Gray
        Me.txtApiKey.WatermarkText = "Ember Media Manager Embedded API Key"
        '
        'pbTMDBApiKeyInfo
        '
        Me.pbApiKeyInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pbApiKeyInfo.Image = CType(resources.GetObject("pbTMDBApiKeyInfo.Image"), System.Drawing.Image)
        Me.pbApiKeyInfo.Location = New System.Drawing.Point(325, 6)
        Me.pbApiKeyInfo.Name = "pbTMDBApiKeyInfo"
        Me.pbApiKeyInfo.Size = New System.Drawing.Size(16, 16)
        Me.pbApiKeyInfo.TabIndex = 5
        Me.pbApiKeyInfo.TabStop = False
        '
        'chkIncludeAdultItems_Movie
        '
        Me.chkIncludeAdultItems_Movie.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIncludeAdultItems_Movie.AutoSize = True
        Me.chkIncludeAdultItems_Movie.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkIncludeAdultItems_Movie.Location = New System.Drawing.Point(3, 26)
        Me.chkIncludeAdultItems_Movie.Name = "chkIncludeAdultItems_Movie"
        Me.chkIncludeAdultItems_Movie.Size = New System.Drawing.Size(125, 17)
        Me.chkIncludeAdultItems_Movie.TabIndex = 6
        Me.chkIncludeAdultItems_Movie.Text = "Include Adult Items"
        Me.chkIncludeAdultItems_Movie.UseVisualStyleBackColor = True
        '
        'chkFallBackToEng_Movie
        '
        Me.chkFallBackToEng_Movie.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkFallBackToEng_Movie.AutoSize = True
        Me.chkFallBackToEng_Movie.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFallBackToEng_Movie.Location = New System.Drawing.Point(3, 3)
        Me.chkFallBackToEng_Movie.Name = "chkFallBackToEng_Movie"
        Me.chkFallBackToEng_Movie.Size = New System.Drawing.Size(123, 17)
        Me.chkFallBackToEng_Movie.TabIndex = 4
        Me.chkFallBackToEng_Movie.Text = "Fallback to english"
        Me.chkFallBackToEng_Movie.UseVisualStyleBackColor = True
        '
        'chkSearchDeviant_Movie
        '
        Me.chkSearchDeviant_Movie.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkSearchDeviant_Movie.AutoSize = True
        Me.chkSearchDeviant_Movie.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkSearchDeviant_Movie.Location = New System.Drawing.Point(3, 49)
        Me.chkSearchDeviant_Movie.Name = "chkSearchDeviant_Movie"
        Me.chkSearchDeviant_Movie.Size = New System.Drawing.Size(265, 17)
        Me.chkSearchDeviant_Movie.TabIndex = 6
        Me.chkSearchDeviant_Movie.Text = "Search +/- 1 year if no search result was found"
        Me.chkSearchDeviant_Movie.UseVisualStyleBackColor = True
        '
        'pnlSettingsTop
        '
        Me.pnlSettingsTop.AutoSize = True
        Me.pnlSettingsTop.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlSettingsTop.Controls.Add(Me.tblSettingsTop)
        Me.pnlSettingsTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsTop.Name = "pnlSettingsTop"
        Me.pnlSettingsTop.Size = New System.Drawing.Size(388, 0)
        Me.pnlSettingsTop.TabIndex = 0
        '
        'tblSettingsTop
        '
        Me.tblSettingsTop.AutoSize = True
        Me.tblSettingsTop.ColumnCount = 5
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsTop.Name = "tblSettingsTop"
        Me.tblSettingsTop.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.tblSettingsTop.RowCount = 1
        Me.tblSettingsTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsTop.Size = New System.Drawing.Size(388, 0)
        Me.tblSettingsTop.TabIndex = 98
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.Controls.Add(Me.pnlSettingsMain)
        Me.pnlSettings.Controls.Add(Me.pnlSettingsBottom)
        Me.pnlSettings.Controls.Add(Me.pnlSettingsTop)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(388, 420)
        Me.pnlSettings.TabIndex = 0
        '
        'pnlSettingsMain
        '
        Me.pnlSettingsMain.AutoSize = True
        Me.pnlSettingsMain.Controls.Add(Me.tblSettingsMain)
        Me.pnlSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsMain.Name = "pnlSettingsMain"
        Me.pnlSettingsMain.Size = New System.Drawing.Size(388, 420)
        Me.pnlSettingsMain.TabIndex = 98
        '
        'tblSettingsMain
        '
        Me.tblSettingsMain.AutoScroll = True
        Me.tblSettingsMain.AutoSize = True
        Me.tblSettingsMain.ColumnCount = 2
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.Controls.Add(Me.gbGlobal, 0, 0)
        Me.tblSettingsMain.Controls.Add(Me.gbMovie, 0, 1)
        Me.tblSettingsMain.Controls.Add(Me.gbMovieSet, 0, 2)
        Me.tblSettingsMain.Controls.Add(Me.gbTVShow, 0, 3)
        Me.tblSettingsMain.Controls.Add(Me.pbLogo, 0, 4)
        Me.tblSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsMain.Name = "tblSettingsMain"
        Me.tblSettingsMain.RowCount = 6
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.Size = New System.Drawing.Size(388, 420)
        Me.tblSettingsMain.TabIndex = 0
        '
        'gbMovie
        '
        Me.gbMovie.AutoSize = True
        Me.gbMovie.Controls.Add(Me.tblMovie)
        Me.gbMovie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovie.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovie.Location = New System.Drawing.Point(3, 58)
        Me.gbMovie.Name = "gbMovie"
        Me.gbMovie.Size = New System.Drawing.Size(350, 90)
        Me.gbMovie.TabIndex = 2
        Me.gbMovie.TabStop = False
        Me.gbMovie.Text = "Movie"
        '
        'tblMovie
        '
        Me.tblMovie.AutoSize = True
        Me.tblMovie.ColumnCount = 2
        Me.tblMovie.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovie.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovie.Controls.Add(Me.chkFallBackToEng_Movie, 0, 0)
        Me.tblMovie.Controls.Add(Me.chkIncludeAdultItems_Movie, 0, 1)
        Me.tblMovie.Controls.Add(Me.chkSearchDeviant_Movie, 0, 2)
        Me.tblMovie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovie.Location = New System.Drawing.Point(3, 18)
        Me.tblMovie.Name = "tblMovie"
        Me.tblMovie.RowCount = 4
        Me.tblMovie.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovie.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovie.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovie.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovie.Size = New System.Drawing.Size(344, 69)
        Me.tblMovie.TabIndex = 0
        '
        'gbMovieSet
        '
        Me.gbMovieSet.AutoSize = True
        Me.gbMovieSet.Controls.Add(Me.TableLayoutPanel1)
        Me.gbMovieSet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSet.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieSet.Location = New System.Drawing.Point(3, 154)
        Me.gbMovieSet.Name = "gbMovieSet"
        Me.gbMovieSet.Size = New System.Drawing.Size(350, 67)
        Me.gbMovieSet.TabIndex = 3
        Me.gbMovieSet.TabStop = False
        Me.gbMovieSet.Text = "MovieSet"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.chkFallBackToEng_MovieSet, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkIncludeAdultItems_MovieSet, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(344, 46)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'chkFallBackToEng_MovieSet
        '
        Me.chkFallBackToEng_MovieSet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkFallBackToEng_MovieSet.AutoSize = True
        Me.chkFallBackToEng_MovieSet.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFallBackToEng_MovieSet.Location = New System.Drawing.Point(3, 3)
        Me.chkFallBackToEng_MovieSet.Name = "chkFallBackToEng_MovieSet"
        Me.chkFallBackToEng_MovieSet.Size = New System.Drawing.Size(123, 17)
        Me.chkFallBackToEng_MovieSet.TabIndex = 4
        Me.chkFallBackToEng_MovieSet.Text = "Fallback to english"
        Me.chkFallBackToEng_MovieSet.UseVisualStyleBackColor = True
        '
        'chkIncludeAdultItems_MovieSet
        '
        Me.chkIncludeAdultItems_MovieSet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIncludeAdultItems_MovieSet.AutoSize = True
        Me.chkIncludeAdultItems_MovieSet.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkIncludeAdultItems_MovieSet.Location = New System.Drawing.Point(3, 26)
        Me.chkIncludeAdultItems_MovieSet.Name = "chkIncludeAdultItems_MovieSet"
        Me.chkIncludeAdultItems_MovieSet.Size = New System.Drawing.Size(125, 17)
        Me.chkIncludeAdultItems_MovieSet.TabIndex = 6
        Me.chkIncludeAdultItems_MovieSet.Text = "Include Adult Items"
        Me.chkIncludeAdultItems_MovieSet.UseVisualStyleBackColor = True
        '
        'gbTVShow
        '
        Me.gbTVShow.AutoSize = True
        Me.gbTVShow.Controls.Add(Me.TableLayoutPanel2)
        Me.gbTVShow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVShow.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTVShow.Location = New System.Drawing.Point(3, 227)
        Me.gbTVShow.Name = "gbTVShow"
        Me.gbTVShow.Size = New System.Drawing.Size(350, 67)
        Me.gbTVShow.TabIndex = 4
        Me.gbTVShow.TabStop = False
        Me.gbTVShow.Text = "TV Show"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.chkFallBackToEng_TV, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.chkIncludeAdultItems_TV, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(344, 46)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'chkFallBackToEng_TV
        '
        Me.chkFallBackToEng_TV.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkFallBackToEng_TV.AutoSize = True
        Me.chkFallBackToEng_TV.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFallBackToEng_TV.Location = New System.Drawing.Point(3, 3)
        Me.chkFallBackToEng_TV.Name = "chkFallBackToEng_TV"
        Me.chkFallBackToEng_TV.Size = New System.Drawing.Size(123, 17)
        Me.chkFallBackToEng_TV.TabIndex = 4
        Me.chkFallBackToEng_TV.Text = "Fallback to english"
        Me.chkFallBackToEng_TV.UseVisualStyleBackColor = True
        '
        'chkIncludeAdultItems_TV
        '
        Me.chkIncludeAdultItems_TV.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIncludeAdultItems_TV.AutoSize = True
        Me.chkIncludeAdultItems_TV.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkIncludeAdultItems_TV.Location = New System.Drawing.Point(3, 26)
        Me.chkIncludeAdultItems_TV.Name = "chkIncludeAdultItems_TV"
        Me.chkIncludeAdultItems_TV.Size = New System.Drawing.Size(125, 17)
        Me.chkIncludeAdultItems_TV.TabIndex = 6
        Me.chkIncludeAdultItems_TV.Text = "Include Adult Items"
        Me.chkIncludeAdultItems_TV.UseVisualStyleBackColor = True
        '
        'pnlSettingsBottom
        '
        Me.pnlSettingsBottom.AutoSize = True
        Me.pnlSettingsBottom.Controls.Add(Me.tblSettingsBottom)
        Me.pnlSettingsBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSettingsBottom.Location = New System.Drawing.Point(0, 420)
        Me.pnlSettingsBottom.Name = "pnlSettingsBottom"
        Me.pnlSettingsBottom.Size = New System.Drawing.Size(388, 0)
        Me.pnlSettingsBottom.TabIndex = 97
        '
        'tblSettingsBottom
        '
        Me.tblSettingsBottom.AutoSize = True
        Me.tblSettingsBottom.ColumnCount = 3
        Me.tblSettingsBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsBottom.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsBottom.Name = "tblSettingsBottom"
        Me.tblSettingsBottom.RowCount = 1
        Me.tblSettingsBottom.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsBottom.Size = New System.Drawing.Size(388, 0)
        Me.tblSettingsBottom.TabIndex = 0
        '
        'PictureBox1
        '
        Me.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbLogo.Image = Global.ExternalModule.My.Resources.Resources.logo_powered_by_rectangle_blue
        Me.pbLogo.Location = New System.Drawing.Point(3, 300)
        Me.pbLogo.Name = "PictureBox1"
        Me.pbLogo.Size = New System.Drawing.Size(350, 50)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 5
        Me.pbLogo.TabStop = False
        '
        'frmSettingsPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(388, 420)
        Me.Controls.Add(Me.pnlSettings)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettingsPanel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scraper Setup"
        Me.gbGlobal.ResumeLayout(False)
        Me.gbGlobal.PerformLayout()
        Me.tblScraperOpts.ResumeLayout(False)
        Me.tblScraperOpts.PerformLayout()
        CType(Me.pbApiKeyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSettingsTop.ResumeLayout(False)
        Me.pnlSettingsTop.PerformLayout()
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.pnlSettingsMain.ResumeLayout(False)
        Me.pnlSettingsMain.PerformLayout()
        Me.tblSettingsMain.ResumeLayout(False)
        Me.tblSettingsMain.PerformLayout()
        Me.gbMovie.ResumeLayout(False)
        Me.gbMovie.PerformLayout()
        Me.tblMovie.ResumeLayout(False)
        Me.tblMovie.PerformLayout()
        Me.gbMovieSet.ResumeLayout(False)
        Me.gbMovieSet.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbTVShow.ResumeLayout(False)
        Me.gbTVShow.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.pnlSettingsBottom.ResumeLayout(False)
        Me.pnlSettingsBottom.PerformLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbGlobal As System.Windows.Forms.GroupBox
    Friend WithEvents lblApiKey As System.Windows.Forms.Label
    Friend WithEvents pnlSettingsTop As System.Windows.Forms.Panel
    Friend WithEvents pnlSettings As System.Windows.Forms.Panel
    Friend WithEvents chkFallBackToEng_Movie As System.Windows.Forms.CheckBox
    Friend WithEvents pbApiKeyInfo As System.Windows.Forms.PictureBox
    Friend WithEvents chkIncludeAdultItems_Movie As System.Windows.Forms.CheckBox
    Friend WithEvents tblSettingsBottom As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlSettingsBottom As System.Windows.Forms.Panel
    Friend WithEvents tblSettingsTop As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblScraperOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlSettingsMain As System.Windows.Forms.Panel
    Friend WithEvents tblSettingsMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkSearchDeviant_Movie As CheckBox
    Friend WithEvents gbMovie As GroupBox
    Friend WithEvents tblMovie As TableLayoutPanel
    Friend WithEvents gbMovieSet As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents chkFallBackToEng_MovieSet As CheckBox
    Friend WithEvents gbTVShow As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents chkFallBackToEng_TV As CheckBox
    Friend WithEvents chkIncludeAdultItems_TV As CheckBox
    Friend WithEvents chkIncludeAdultItems_MovieSet As CheckBox
    Friend WithEvents txtApiKey As EmberAPI.FormUtils.TextBox_with_Watermark
    Friend WithEvents pbLogo As PictureBox
End Class
