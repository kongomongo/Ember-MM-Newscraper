<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgSearchResults
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgSearchResults))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.tblMain = New System.Windows.Forms.TableLayoutPanel()
        Me.scSearchResults = New System.Windows.Forms.SplitContainer()
        Me.tblPanelLeft = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPanelLeftTitle = New System.Windows.Forms.Label()
        Me.dgvTVShows = New System.Windows.Forms.DataGridView()
        Me.tblPanelRight = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        Me.cmnuDownload = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.lblPanelRightTitle = New System.Windows.Forms.Label()
        Me.chkOnlyMissingEpisodes = New System.Windows.Forms.CheckBox()
        Me.pnlMainTop = New System.Windows.Forms.Panel()
        Me.tblMainTop = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTopDetails = New System.Windows.Forms.Label()
        Me.lblTopTitle = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlMainBottom = New System.Windows.Forms.Panel()
        Me.tblMainBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.tblMain.SuspendLayout()
        CType(Me.scSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSearchResults.Panel1.SuspendLayout()
        Me.scSearchResults.Panel2.SuspendLayout()
        Me.scSearchResults.SuspendLayout()
        Me.tblPanelLeft.SuspendLayout()
        CType(Me.dgvTVShows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblPanelRight.SuspendLayout()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMainTop.SuspendLayout()
        Me.tblMainTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMainBottom.SuspendLayout()
        Me.tblMainBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.tblMain)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 54)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(784, 478)
        Me.pnlMain.TabIndex = 0
        '
        'tblMain
        '
        Me.tblMain.AutoSize = True
        Me.tblMain.ColumnCount = 1
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.Controls.Add(Me.scSearchResults, 0, 0)
        Me.tblMain.Controls.Add(Me.chkOnlyMissingEpisodes, 0, 1)
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 0)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowCount = 2
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.Size = New System.Drawing.Size(784, 478)
        Me.tblMain.TabIndex = 0
        '
        'scSearchResults
        '
        Me.scSearchResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSearchResults.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scSearchResults.Location = New System.Drawing.Point(3, 3)
        Me.scSearchResults.Name = "scSearchResults"
        '
        'scSearchResults.Panel1
        '
        Me.scSearchResults.Panel1.Controls.Add(Me.tblPanelLeft)
        '
        'scSearchResults.Panel2
        '
        Me.scSearchResults.Panel2.Controls.Add(Me.tblPanelRight)
        Me.scSearchResults.Size = New System.Drawing.Size(778, 449)
        Me.scSearchResults.SplitterDistance = 200
        Me.scSearchResults.TabIndex = 0
        '
        'tblPanelLeft
        '
        Me.tblPanelLeft.AutoSize = True
        Me.tblPanelLeft.ColumnCount = 1
        Me.tblPanelLeft.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblPanelLeft.Controls.Add(Me.lblPanelLeftTitle, 0, 0)
        Me.tblPanelLeft.Controls.Add(Me.dgvTVShows, 0, 1)
        Me.tblPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPanelLeft.Location = New System.Drawing.Point(0, 0)
        Me.tblPanelLeft.Name = "tblPanelLeft"
        Me.tblPanelLeft.RowCount = 2
        Me.tblPanelLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPanelLeft.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblPanelLeft.Size = New System.Drawing.Size(200, 449)
        Me.tblPanelLeft.TabIndex = 1
        '
        'lblPanelLeftTitle
        '
        Me.lblPanelLeftTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPanelLeftTitle.AutoSize = True
        Me.lblPanelLeftTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanelLeftTitle.Location = New System.Drawing.Point(68, 3)
        Me.lblPanelLeftTitle.Name = "lblPanelLeftTitle"
        Me.lblPanelLeftTitle.Size = New System.Drawing.Size(64, 13)
        Me.lblPanelLeftTitle.TabIndex = 1
        Me.lblPanelLeftTitle.Text = "TV Shows"
        '
        'dgvTVShows
        '
        Me.dgvTVShows.AllowUserToAddRows = False
        Me.dgvTVShows.AllowUserToDeleteRows = False
        Me.dgvTVShows.AllowUserToOrderColumns = True
        Me.dgvTVShows.AllowUserToResizeColumns = False
        Me.dgvTVShows.AllowUserToResizeRows = False
        Me.dgvTVShows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTVShows.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgvTVShows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTVShows.ColumnHeadersVisible = False
        Me.dgvTVShows.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTVShows.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvTVShows.Location = New System.Drawing.Point(3, 23)
        Me.dgvTVShows.MultiSelect = False
        Me.dgvTVShows.Name = "dgvTVShows"
        Me.dgvTVShows.ReadOnly = True
        Me.dgvTVShows.RowHeadersVisible = False
        Me.dgvTVShows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTVShows.Size = New System.Drawing.Size(194, 423)
        Me.dgvTVShows.TabIndex = 2
        '
        'tblPanelRight
        '
        Me.tblPanelRight.AutoSize = True
        Me.tblPanelRight.ColumnCount = 1
        Me.tblPanelRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblPanelRight.Controls.Add(Me.dgvSearchResults, 0, 1)
        Me.tblPanelRight.Controls.Add(Me.lblPanelRightTitle, 0, 0)
        Me.tblPanelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPanelRight.Location = New System.Drawing.Point(0, 0)
        Me.tblPanelRight.Name = "tblPanelRight"
        Me.tblPanelRight.RowCount = 2
        Me.tblPanelRight.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPanelRight.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblPanelRight.Size = New System.Drawing.Size(574, 449)
        Me.tblPanelRight.TabIndex = 1
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.AllowUserToAddRows = False
        Me.dgvSearchResults.AllowUserToDeleteRows = False
        Me.dgvSearchResults.AllowUserToResizeRows = False
        Me.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResults.ContextMenuStrip = Me.cmnuDownload
        Me.dgvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearchResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSearchResults.Location = New System.Drawing.Point(3, 23)
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.RowHeadersVisible = False
        Me.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearchResults.Size = New System.Drawing.Size(568, 423)
        Me.dgvSearchResults.TabIndex = 0
        '
        'cmnuDownload
        '
        Me.cmnuDownload.Name = "cmnuDownload"
        Me.cmnuDownload.Size = New System.Drawing.Size(153, 26)
        '
        'lblPanelRightTitle
        '
        Me.lblPanelRightTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPanelRightTitle.AutoSize = True
        Me.lblPanelRightTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanelRightTitle.Location = New System.Drawing.Point(240, 3)
        Me.lblPanelRightTitle.Name = "lblPanelRightTitle"
        Me.lblPanelRightTitle.Size = New System.Drawing.Size(93, 13)
        Me.lblPanelRightTitle.TabIndex = 1
        Me.lblPanelRightTitle.Text = "Search Results"
        '
        'chkOnlyMissingEpisodes
        '
        Me.chkOnlyMissingEpisodes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.chkOnlyMissingEpisodes.AutoSize = True
        Me.chkOnlyMissingEpisodes.Location = New System.Drawing.Point(624, 458)
        Me.chkOnlyMissingEpisodes.Name = "chkOnlyMissingEpisodes"
        Me.chkOnlyMissingEpisodes.Size = New System.Drawing.Size(157, 17)
        Me.chkOnlyMissingEpisodes.TabIndex = 1
        Me.chkOnlyMissingEpisodes.Text = "Show only missing episodes"
        Me.chkOnlyMissingEpisodes.UseVisualStyleBackColor = True
        '
        'pnlMainTop
        '
        Me.pnlMainTop.AutoSize = True
        Me.pnlMainTop.Controls.Add(Me.tblMainTop)
        Me.pnlMainTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMainTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainTop.Name = "pnlMainTop"
        Me.pnlMainTop.Size = New System.Drawing.Size(784, 54)
        Me.pnlMainTop.TabIndex = 1
        '
        'tblMainTop
        '
        Me.tblMainTop.AutoSize = True
        Me.tblMainTop.BackColor = System.Drawing.Color.SteelBlue
        Me.tblMainTop.ColumnCount = 2
        Me.tblMainTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMainTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMainTop.Controls.Add(Me.lblTopDetails, 1, 1)
        Me.tblMainTop.Controls.Add(Me.lblTopTitle, 1, 0)
        Me.tblMainTop.Controls.Add(Me.PictureBox1, 0, 0)
        Me.tblMainTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMainTop.Location = New System.Drawing.Point(0, 0)
        Me.tblMainTop.Name = "tblMainTop"
        Me.tblMainTop.RowCount = 2
        Me.tblMainTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMainTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMainTop.Size = New System.Drawing.Size(784, 54)
        Me.tblMainTop.TabIndex = 0
        '
        'lblTopDetails
        '
        Me.lblTopDetails.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTopDetails.AutoSize = True
        Me.lblTopDetails.BackColor = System.Drawing.Color.Transparent
        Me.lblTopDetails.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTopDetails.ForeColor = System.Drawing.Color.White
        Me.lblTopDetails.Location = New System.Drawing.Point(57, 36)
        Me.lblTopDetails.Name = "lblTopDetails"
        Me.lblTopDetails.Size = New System.Drawing.Size(32, 13)
        Me.lblTopDetails.TabIndex = 2
        Me.lblTopDetails.Text = "TEXT"
        '
        'lblTopTitle
        '
        Me.lblTopTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTopTitle.AutoSize = True
        Me.lblTopTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTopTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblTopTitle.ForeColor = System.Drawing.Color.White
        Me.lblTopTitle.Location = New System.Drawing.Point(57, 0)
        Me.lblTopTitle.Name = "lblTopTitle"
        Me.lblTopTitle.Size = New System.Drawing.Size(125, 32)
        Me.lblTopTitle.TabIndex = 1
        Me.lblTopTitle.Text = "WatchList"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.addon.serienjunkies.org.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.tblMainTop.SetRowSpan(Me.PictureBox1, 2)
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'pnlMainBottom
        '
        Me.pnlMainBottom.AutoSize = True
        Me.pnlMainBottom.Controls.Add(Me.tblMainBottom)
        Me.pnlMainBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMainBottom.Location = New System.Drawing.Point(0, 532)
        Me.pnlMainBottom.Name = "pnlMainBottom"
        Me.pnlMainBottom.Size = New System.Drawing.Size(784, 29)
        Me.pnlMainBottom.TabIndex = 2
        '
        'tblMainBottom
        '
        Me.tblMainBottom.AutoSize = True
        Me.tblMainBottom.ColumnCount = 2
        Me.tblMainBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMainBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMainBottom.Controls.Add(Me.btnClose, 1, 0)
        Me.tblMainBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMainBottom.Location = New System.Drawing.Point(0, 0)
        Me.tblMainBottom.Name = "tblMainBottom"
        Me.tblMainBottom.RowCount = 1
        Me.tblMainBottom.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMainBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMainBottom.Size = New System.Drawing.Size(784, 29)
        Me.tblMainBottom.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(706, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dlgSearchResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlMainTop)
        Me.Controls.Add(Me.pnlMainBottom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "dlgSearchResults"
        Me.Text = "Search Results"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.tblMain.ResumeLayout(False)
        Me.tblMain.PerformLayout()
        Me.scSearchResults.Panel1.ResumeLayout(False)
        Me.scSearchResults.Panel1.PerformLayout()
        Me.scSearchResults.Panel2.ResumeLayout(False)
        Me.scSearchResults.Panel2.PerformLayout()
        CType(Me.scSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSearchResults.ResumeLayout(False)
        Me.tblPanelLeft.ResumeLayout(False)
        Me.tblPanelLeft.PerformLayout()
        CType(Me.dgvTVShows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblPanelRight.ResumeLayout(False)
        Me.tblPanelRight.PerformLayout()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMainTop.ResumeLayout(False)
        Me.pnlMainTop.PerformLayout()
        Me.tblMainTop.ResumeLayout(False)
        Me.tblMainTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMainBottom.ResumeLayout(False)
        Me.pnlMainBottom.PerformLayout()
        Me.tblMainBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlMainTop As Panel
    Friend WithEvents tblMainTop As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTopTitle As Label
    Friend WithEvents lblTopDetails As Label
    Friend WithEvents tblMain As TableLayoutPanel
    Friend WithEvents scSearchResults As SplitContainer
    Friend WithEvents pnlMainBottom As Panel
    Friend WithEvents tblMainBottom As TableLayoutPanel
    Friend WithEvents btnClose As Button
    Friend WithEvents chkOnlyMissingEpisodes As CheckBox
    Friend WithEvents dgvSearchResults As DataGridView
    Friend WithEvents tblPanelLeft As TableLayoutPanel
    Friend WithEvents lblPanelLeftTitle As Label
    Friend WithEvents tblPanelRight As TableLayoutPanel
    Friend WithEvents lblPanelRightTitle As Label
    Friend WithEvents dgvTVShows As DataGridView
    Friend WithEvents cmnuDownload As ContextMenuStrip
End Class
