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
        Me.pnlSettingsTop = New System.Windows.Forms.Panel()
        Me.tblSettingsTop = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.pnlSettingsMain = New System.Windows.Forms.Panel()
        Me.tblSettingsMain = New System.Windows.Forms.TableLayoutPanel()
        Me.gbScraperOpts = New System.Windows.Forms.GroupBox()
        Me.tblScraperOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkPopularTitles = New System.Windows.Forms.CheckBox()
        Me.chkFallBackworldwide = New System.Windows.Forms.CheckBox()
        Me.lblForceTitleLanguage = New System.Windows.Forms.Label()
        Me.cbForceTitleLanguage = New System.Windows.Forms.ComboBox()
        Me.chkPartialTitles = New System.Windows.Forms.CheckBox()
        Me.chkTvTitles = New System.Windows.Forms.CheckBox()
        Me.chkVideoTitles = New System.Windows.Forms.CheckBox()
        Me.chkShortTitles = New System.Windows.Forms.CheckBox()
        Me.pnlSettingBottom = New System.Windows.Forms.Panel()
        Me.tblSettingsBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.tblScraperFieldsOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkStudiowithDistributors = New System.Windows.Forms.CheckBox()
        Me.chkStudios = New System.Windows.Forms.CheckBox()
        Me.gbScraperFieldsOpts = New System.Windows.Forms.GroupBox()
        Me.pnlSettingsTop.SuspendLayout()
        Me.pnlSettings.SuspendLayout()
        Me.pnlSettingsMain.SuspendLayout()
        Me.tblSettingsMain.SuspendLayout()
        Me.gbScraperOpts.SuspendLayout()
        Me.tblScraperOpts.SuspendLayout()
        Me.pnlSettingBottom.SuspendLayout()
        Me.tblScraperFieldsOpts.SuspendLayout()
        Me.gbScraperFieldsOpts.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSettingsTop
        '
        Me.pnlSettingsTop.AutoSize = True
        Me.pnlSettingsTop.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlSettingsTop.Controls.Add(Me.tblSettingsTop)
        Me.pnlSettingsTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsTop.Name = "pnlSettingsTop"
        Me.pnlSettingsTop.Size = New System.Drawing.Size(414, 0)
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
        Me.tblSettingsTop.Size = New System.Drawing.Size(414, 0)
        Me.tblSettingsTop.TabIndex = 98
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.Controls.Add(Me.pnlSettingsMain)
        Me.pnlSettings.Controls.Add(Me.pnlSettingBottom)
        Me.pnlSettings.Controls.Add(Me.pnlSettingsTop)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(414, 245)
        Me.pnlSettings.TabIndex = 0
        '
        'pnlSettingsMain
        '
        Me.pnlSettingsMain.AutoSize = True
        Me.pnlSettingsMain.Controls.Add(Me.tblSettingsMain)
        Me.pnlSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsMain.Name = "pnlSettingsMain"
        Me.pnlSettingsMain.Size = New System.Drawing.Size(414, 245)
        Me.pnlSettingsMain.TabIndex = 100
        '
        'tblSettingsMain
        '
        Me.tblSettingsMain.AutoScroll = True
        Me.tblSettingsMain.AutoSize = True
        Me.tblSettingsMain.ColumnCount = 2
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.Controls.Add(Me.gbScraperFieldsOpts, 0, 0)
        Me.tblSettingsMain.Controls.Add(Me.gbScraperOpts, 0, 1)
        Me.tblSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsMain.Name = "tblSettingsMain"
        Me.tblSettingsMain.RowCount = 3
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.Size = New System.Drawing.Size(414, 245)
        Me.tblSettingsMain.TabIndex = 98
        '
        'gbScraperOpts
        '
        Me.gbScraperOpts.AutoSize = True
        Me.gbScraperOpts.Controls.Add(Me.tblScraperOpts)
        Me.gbScraperOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbScraperOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbScraperOpts.Location = New System.Drawing.Point(3, 76)
        Me.gbScraperOpts.Name = "gbScraperOpts"
        Me.gbScraperOpts.Size = New System.Drawing.Size(372, 140)
        Me.gbScraperOpts.TabIndex = 97
        Me.gbScraperOpts.TabStop = False
        Me.gbScraperOpts.Text = "Scraper Options"
        '
        'tblScraperOpts
        '
        Me.tblScraperOpts.AutoSize = True
        Me.tblScraperOpts.ColumnCount = 4
        Me.tblScraperOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperOpts.Controls.Add(Me.chkPopularTitles, 0, 0)
        Me.tblScraperOpts.Controls.Add(Me.chkFallBackworldwide, 1, 1)
        Me.tblScraperOpts.Controls.Add(Me.lblForceTitleLanguage, 1, 0)
        Me.tblScraperOpts.Controls.Add(Me.cbForceTitleLanguage, 2, 0)
        Me.tblScraperOpts.Controls.Add(Me.chkPartialTitles, 0, 1)
        Me.tblScraperOpts.Controls.Add(Me.chkTvTitles, 0, 2)
        Me.tblScraperOpts.Controls.Add(Me.chkVideoTitles, 0, 3)
        Me.tblScraperOpts.Controls.Add(Me.chkShortTitles, 0, 4)
        Me.tblScraperOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblScraperOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblScraperOpts.Name = "tblScraperOpts"
        Me.tblScraperOpts.RowCount = 5
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScraperOpts.Size = New System.Drawing.Size(366, 119)
        Me.tblScraperOpts.TabIndex = 1
        '
        'chkPopularTitles
        '
        Me.chkPopularTitles.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkPopularTitles.AutoSize = True
        Me.chkPopularTitles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPopularTitles.Location = New System.Drawing.Point(3, 5)
        Me.chkPopularTitles.Name = "chkPopularTitles"
        Me.chkPopularTitles.Size = New System.Drawing.Size(95, 17)
        Me.chkPopularTitles.TabIndex = 0
        Me.chkPopularTitles.Text = "Popular Titles"
        Me.chkPopularTitles.UseVisualStyleBackColor = True
        '
        'chkFallBackworldwide
        '
        Me.chkFallBackworldwide.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkFallBackworldwide.AutoSize = True
        Me.tblScraperOpts.SetColumnSpan(Me.chkFallBackworldwide, 2)
        Me.chkFallBackworldwide.Enabled = False
        Me.chkFallBackworldwide.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFallBackworldwide.Location = New System.Drawing.Point(110, 30)
        Me.chkFallBackworldwide.Name = "chkFallBackworldwide"
        Me.chkFallBackworldwide.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkFallBackworldwide.Size = New System.Drawing.Size(189, 17)
        Me.chkFallBackworldwide.TabIndex = 78
        Me.chkFallBackworldwide.Text = "Fall back on worldwide title"
        Me.chkFallBackworldwide.UseVisualStyleBackColor = True
        '
        'lblForceTitleLanguage
        '
        Me.lblForceTitleLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblForceTitleLanguage.AutoSize = True
        Me.lblForceTitleLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblForceTitleLanguage.Location = New System.Drawing.Point(110, 7)
        Me.lblForceTitleLanguage.Name = "lblForceTitleLanguage"
        Me.lblForceTitleLanguage.Size = New System.Drawing.Size(116, 13)
        Me.lblForceTitleLanguage.TabIndex = 4
        Me.lblForceTitleLanguage.Text = "Force Title Language:"
        '
        'cbForceTitleLanguage
        '
        Me.cbForceTitleLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbForceTitleLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbForceTitleLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbForceTitleLanguage.FormattingEnabled = True
        Me.cbForceTitleLanguage.Items.AddRange(New Object() {"", "Argentina", "Australia", "Azerbaijan", "Belgium", "Brazil", "Bulgaria (Bulgarian title)", "Canada (English title)", "Canada (French title)", "Chile", "China (Mandarin title)", "Colombia", "Croatia", "Czech Republic", "Denmark", "Estonia", "Finland", "Finland (Swedish title)", "France", "Georgia", "Germany", "Greece", "Hong Kong", "Hong Kong (Cantonese title)", "Hong Kong (Mandarin title)", "Hungary", "Iceland", "India (Hindi title)", "Ireland", "Israel (Hebrew title)", "Italy", "Japan", "Japan (English title)", "Latvia", "Lithuania", "Mexico", "Netherlands", "New Zealand", "Panama", "Peru", "Poland", "Portugal", "Romania", "Russia", "Serbia", "Singapore", "Slovakia", "Slovenia", "South Korea", "Spain", "Sweden", "Switzerland", "Taiwan", "Turkey (Turkish title)", "UK", "Ukraine", "Uruguay", "USA", "Venezuela", "Vietnam"})
        Me.cbForceTitleLanguage.Location = New System.Drawing.Point(232, 3)
        Me.cbForceTitleLanguage.Name = "cbForceTitleLanguage"
        Me.cbForceTitleLanguage.Size = New System.Drawing.Size(131, 21)
        Me.cbForceTitleLanguage.Sorted = True
        Me.cbForceTitleLanguage.TabIndex = 77
        '
        'chkPartialTitles
        '
        Me.chkPartialTitles.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkPartialTitles.AutoSize = True
        Me.chkPartialTitles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPartialTitles.Location = New System.Drawing.Point(3, 30)
        Me.chkPartialTitles.Name = "chkPartialTitles"
        Me.chkPartialTitles.Size = New System.Drawing.Size(87, 17)
        Me.chkPartialTitles.TabIndex = 1
        Me.chkPartialTitles.Text = "Partial Titles"
        Me.chkPartialTitles.UseVisualStyleBackColor = True
        '
        'chkTvTitles
        '
        Me.chkTvTitles.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTvTitles.AutoSize = True
        Me.chkTvTitles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTvTitles.Location = New System.Drawing.Point(3, 53)
        Me.chkTvTitles.Name = "chkTvTitles"
        Me.chkTvTitles.Size = New System.Drawing.Size(101, 17)
        Me.chkTvTitles.TabIndex = 2
        Me.chkTvTitles.Text = "TV Movie Titles"
        Me.chkTvTitles.UseVisualStyleBackColor = True
        '
        'chkVideoTitles
        '
        Me.chkVideoTitles.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkVideoTitles.AutoSize = True
        Me.chkVideoTitles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVideoTitles.Location = New System.Drawing.Point(3, 76)
        Me.chkVideoTitles.Name = "chkVideoTitles"
        Me.chkVideoTitles.Size = New System.Drawing.Size(85, 17)
        Me.chkVideoTitles.TabIndex = 3
        Me.chkVideoTitles.Text = "Video Titles"
        Me.chkVideoTitles.UseVisualStyleBackColor = True
        '
        'chkShortTitles
        '
        Me.chkShortTitles.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkShortTitles.AutoSize = True
        Me.chkShortTitles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShortTitles.Location = New System.Drawing.Point(3, 99)
        Me.chkShortTitles.Name = "chkShortTitles"
        Me.chkShortTitles.Size = New System.Drawing.Size(83, 17)
        Me.chkShortTitles.TabIndex = 80
        Me.chkShortTitles.Text = "Short Titles"
        Me.chkShortTitles.UseVisualStyleBackColor = True
        '
        'pnlSettingBottom
        '
        Me.pnlSettingBottom.AutoSize = True
        Me.pnlSettingBottom.Controls.Add(Me.tblSettingsBottom)
        Me.pnlSettingBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSettingBottom.Location = New System.Drawing.Point(0, 245)
        Me.pnlSettingBottom.Name = "pnlSettingBottom"
        Me.pnlSettingBottom.Size = New System.Drawing.Size(414, 0)
        Me.pnlSettingBottom.TabIndex = 99
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
        Me.tblSettingsBottom.Size = New System.Drawing.Size(414, 0)
        Me.tblSettingsBottom.TabIndex = 0
        '
        'tblScraperFieldsOpts
        '
        Me.tblScraperFieldsOpts.AutoSize = True
        Me.tblScraperFieldsOpts.ColumnCount = 4
        Me.tblScraperFieldsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperFieldsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperFieldsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperFieldsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperFieldsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScraperFieldsOpts.Controls.Add(Me.chkStudios, 0, 0)
        Me.tblScraperFieldsOpts.Controls.Add(Me.chkStudiowithDistributors, 0, 1)
        Me.tblScraperFieldsOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblScraperFieldsOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblScraperFieldsOpts.Name = "tblScraperFieldsOpts"
        Me.tblScraperFieldsOpts.RowCount = 3
        Me.tblScraperFieldsOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperFieldsOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperFieldsOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperFieldsOpts.Size = New System.Drawing.Size(366, 46)
        Me.tblScraperFieldsOpts.TabIndex = 1
        '
        'chkStudiowithDistributors
        '
        Me.chkStudiowithDistributors.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkStudiowithDistributors.AutoSize = True
        Me.chkStudiowithDistributors.Enabled = False
        Me.chkStudiowithDistributors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStudiowithDistributors.Location = New System.Drawing.Point(3, 26)
        Me.chkStudiowithDistributors.Name = "chkStudiowithDistributors"
        Me.chkStudiowithDistributors.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkStudiowithDistributors.Size = New System.Drawing.Size(148, 17)
        Me.chkStudiowithDistributors.TabIndex = 82
        Me.chkStudiowithDistributors.Text = "include Distributors"
        Me.chkStudiowithDistributors.UseVisualStyleBackColor = True
        '
        'chkStudios
        '
        Me.chkStudios.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkStudios.AutoSize = True
        Me.chkStudios.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStudios.Location = New System.Drawing.Point(3, 3)
        Me.chkStudios.Name = "chkStudios"
        Me.chkStudios.Size = New System.Drawing.Size(65, 17)
        Me.chkStudios.TabIndex = 8
        Me.chkStudios.Text = "Studios"
        Me.chkStudios.UseVisualStyleBackColor = True
        '
        'gbScraperFieldsOpts
        '
        Me.gbScraperFieldsOpts.AutoSize = True
        Me.gbScraperFieldsOpts.Controls.Add(Me.tblScraperFieldsOpts)
        Me.gbScraperFieldsOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbScraperFieldsOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbScraperFieldsOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbScraperFieldsOpts.Name = "gbScraperFieldsOpts"
        Me.gbScraperFieldsOpts.Size = New System.Drawing.Size(372, 67)
        Me.gbScraperFieldsOpts.TabIndex = 3
        Me.gbScraperFieldsOpts.TabStop = False
        Me.gbScraperFieldsOpts.Text = "Scraper Fields - Scraper specific"
        '
        'frmSettingsPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(414, 245)
        Me.Controls.Add(Me.pnlSettings)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettingsPanel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scraper Setup"
        Me.pnlSettingsTop.ResumeLayout(False)
        Me.pnlSettingsTop.PerformLayout()
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.pnlSettingsMain.ResumeLayout(False)
        Me.pnlSettingsMain.PerformLayout()
        Me.tblSettingsMain.ResumeLayout(False)
        Me.tblSettingsMain.PerformLayout()
        Me.gbScraperOpts.ResumeLayout(False)
        Me.gbScraperOpts.PerformLayout()
        Me.tblScraperOpts.ResumeLayout(False)
        Me.tblScraperOpts.PerformLayout()
        Me.pnlSettingBottom.ResumeLayout(False)
        Me.pnlSettingBottom.PerformLayout()
        Me.tblScraperFieldsOpts.ResumeLayout(False)
        Me.tblScraperFieldsOpts.PerformLayout()
        Me.gbScraperFieldsOpts.ResumeLayout(False)
        Me.gbScraperFieldsOpts.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSettingsTop As System.Windows.Forms.Panel
    Friend WithEvents pnlSettings As System.Windows.Forms.Panel
    Friend WithEvents gbScraperOpts As System.Windows.Forms.GroupBox
    Friend WithEvents chkTvTitles As System.Windows.Forms.CheckBox
    Friend WithEvents chkPartialTitles As System.Windows.Forms.CheckBox
    Friend WithEvents chkPopularTitles As System.Windows.Forms.CheckBox
    Friend WithEvents chkVideoTitles As System.Windows.Forms.CheckBox
    Friend WithEvents chkShortTitles As System.Windows.Forms.CheckBox
    Friend WithEvents chkFallBackworldwide As System.Windows.Forms.CheckBox
    Friend WithEvents cbForceTitleLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblForceTitleLanguage As System.Windows.Forms.Label
    Friend WithEvents tblScraperOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblSettingsTop As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblSettingsMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlSettingBottom As System.Windows.Forms.Panel
    Friend WithEvents tblSettingsBottom As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlSettingsMain As System.Windows.Forms.Panel
    Friend WithEvents gbScraperFieldsOpts As System.Windows.Forms.GroupBox
    Friend WithEvents tblScraperFieldsOpts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkStudios As System.Windows.Forms.CheckBox
    Friend WithEvents chkStudiowithDistributors As System.Windows.Forms.CheckBox
End Class
