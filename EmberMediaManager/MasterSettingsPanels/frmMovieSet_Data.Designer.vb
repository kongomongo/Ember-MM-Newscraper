<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovieSet_Data
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovieSet_Data))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetScraperTitleRenamerOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetScraperTitleRenamerOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieSetScraperTitleRenamerAdd = New System.Windows.Forms.Button()
        Me.btnMovieSetScraperTitleRenamerRemove = New System.Windows.Forms.Button()
        Me.dgvMovieSetScraperTitleRenamer = New System.Windows.Forms.DataGridView()
        Me.tbcMovieSetScrapedTitleRenamerFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcMovieSetScrapedTitleRenamerTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbMovieSetScraperGlobalOpts = New System.Windows.Forms.GroupBox()
        Me.tblScraperSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvSearchAdditional = New System.Windows.Forms.DataGridView()
        Me.chkMovieSetLockPlot = New System.Windows.Forms.CheckBox()
        Me.dgvTitle = New System.Windows.Forms.DataGridView()
        Me.lblSearchAdditional = New System.Windows.Forms.Label()
        Me.chkMovieSetScraperPlot = New System.Windows.Forms.CheckBox()
        Me.lblSearchInitial = New System.Windows.Forms.Label()
        Me.chkMovieSetLockTitle = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetScraperTitle = New System.Windows.Forms.CheckBox()
        Me.lblMovieSetScraperGlobalHeaderLock = New System.Windows.Forms.Label()
        Me.lblMovieSetScraperGlobalTitle = New System.Windows.Forms.Label()
        Me.lblMovieSetScraperGlobalPlot = New System.Windows.Forms.Label()
        Me.dgvPlot = New System.Windows.Forms.DataGridView()
        Me.lblFields = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.dgvSearchInitial = New System.Windows.Forms.DataGridView()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieSetScraperTitleRenamerOpts.SuspendLayout()
        Me.tblMovieSetScraperTitleRenamerOpts.SuspendLayout()
        CType(Me.dgvMovieSetScraperTitleRenamer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMovieSetScraperGlobalOpts.SuspendLayout()
        Me.tblScraperSettings.SuspendLayout()
        CType(Me.dgvSearchAdditional, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSearchInitial, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlSettings.Size = New System.Drawing.Size(519, 486)
        Me.pnlSettings.TabIndex = 27
        Me.pnlSettings.Visible = False
        '
        'tblSettings
        '
        Me.tblSettings.AutoScroll = True
        Me.tblSettings.AutoSize = True
        Me.tblSettings.ColumnCount = 2
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblSettings.Controls.Add(Me.gbMovieSetScraperTitleRenamerOpts, 0, 1)
        Me.tblSettings.Controls.Add(Me.gbMovieSetScraperGlobalOpts, 0, 0)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 3
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.Size = New System.Drawing.Size(519, 486)
        Me.tblSettings.TabIndex = 70
        '
        'gbMovieSetScraperTitleRenamerOpts
        '
        Me.gbMovieSetScraperTitleRenamerOpts.AutoSize = True
        Me.gbMovieSetScraperTitleRenamerOpts.Controls.Add(Me.tblMovieSetScraperTitleRenamerOpts)
        Me.gbMovieSetScraperTitleRenamerOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetScraperTitleRenamerOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbMovieSetScraperTitleRenamerOpts.Location = New System.Drawing.Point(3, 162)
        Me.gbMovieSetScraperTitleRenamerOpts.Name = "gbMovieSetScraperTitleRenamerOpts"
        Me.gbMovieSetScraperTitleRenamerOpts.Size = New System.Drawing.Size(314, 212)
        Me.gbMovieSetScraperTitleRenamerOpts.TabIndex = 69
        Me.gbMovieSetScraperTitleRenamerOpts.TabStop = False
        Me.gbMovieSetScraperTitleRenamerOpts.Text = "Title Renamer"
        '
        'tblMovieSetScraperTitleRenamerOpts
        '
        Me.tblMovieSetScraperTitleRenamerOpts.AutoSize = True
        Me.tblMovieSetScraperTitleRenamerOpts.ColumnCount = 3
        Me.tblMovieSetScraperTitleRenamerOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetScraperTitleRenamerOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetScraperTitleRenamerOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSetScraperTitleRenamerOpts.Controls.Add(Me.btnMovieSetScraperTitleRenamerAdd, 0, 1)
        Me.tblMovieSetScraperTitleRenamerOpts.Controls.Add(Me.btnMovieSetScraperTitleRenamerRemove, 1, 1)
        Me.tblMovieSetScraperTitleRenamerOpts.Controls.Add(Me.dgvMovieSetScraperTitleRenamer, 0, 0)
        Me.tblMovieSetScraperTitleRenamerOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSetScraperTitleRenamerOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSetScraperTitleRenamerOpts.Name = "tblMovieSetScraperTitleRenamerOpts"
        Me.tblMovieSetScraperTitleRenamerOpts.RowCount = 3
        Me.tblMovieSetScraperTitleRenamerOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetScraperTitleRenamerOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetScraperTitleRenamerOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSetScraperTitleRenamerOpts.Size = New System.Drawing.Size(308, 191)
        Me.tblMovieSetScraperTitleRenamerOpts.TabIndex = 70
        '
        'btnMovieSetScraperTitleRenamerAdd
        '
        Me.btnMovieSetScraperTitleRenamerAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMovieSetScraperTitleRenamerAdd.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovieSetScraperTitleRenamerAdd.Image = CType(resources.GetObject("btnMovieSetScraperTitleRenamerAdd.Image"), System.Drawing.Image)
        Me.btnMovieSetScraperTitleRenamerAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMovieSetScraperTitleRenamerAdd.Location = New System.Drawing.Point(3, 165)
        Me.btnMovieSetScraperTitleRenamerAdd.Name = "btnMovieSetScraperTitleRenamerAdd"
        Me.btnMovieSetScraperTitleRenamerAdd.Size = New System.Drawing.Size(87, 23)
        Me.btnMovieSetScraperTitleRenamerAdd.TabIndex = 69
        Me.btnMovieSetScraperTitleRenamerAdd.Text = "Add"
        Me.btnMovieSetScraperTitleRenamerAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMovieSetScraperTitleRenamerAdd.UseVisualStyleBackColor = True
        '
        'btnMovieSetScraperTitleRenamerRemove
        '
        Me.btnMovieSetScraperTitleRenamerRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMovieSetScraperTitleRenamerRemove.Enabled = False
        Me.btnMovieSetScraperTitleRenamerRemove.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovieSetScraperTitleRenamerRemove.Image = CType(resources.GetObject("btnMovieSetScraperTitleRenamerRemove.Image"), System.Drawing.Image)
        Me.btnMovieSetScraperTitleRenamerRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMovieSetScraperTitleRenamerRemove.Location = New System.Drawing.Point(218, 165)
        Me.btnMovieSetScraperTitleRenamerRemove.Name = "btnMovieSetScraperTitleRenamerRemove"
        Me.btnMovieSetScraperTitleRenamerRemove.Size = New System.Drawing.Size(87, 23)
        Me.btnMovieSetScraperTitleRenamerRemove.TabIndex = 70
        Me.btnMovieSetScraperTitleRenamerRemove.Text = "Remove"
        Me.btnMovieSetScraperTitleRenamerRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMovieSetScraperTitleRenamerRemove.UseVisualStyleBackColor = True
        '
        'dgvMovieSetScraperTitleRenamer
        '
        Me.dgvMovieSetScraperTitleRenamer.AllowUserToAddRows = False
        Me.dgvMovieSetScraperTitleRenamer.AllowUserToDeleteRows = False
        Me.dgvMovieSetScraperTitleRenamer.AllowUserToResizeColumns = False
        Me.dgvMovieSetScraperTitleRenamer.AllowUserToResizeRows = False
        Me.dgvMovieSetScraperTitleRenamer.BackgroundColor = System.Drawing.Color.White
        Me.dgvMovieSetScraperTitleRenamer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovieSetScraperTitleRenamer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tbcMovieSetScrapedTitleRenamerFrom, Me.tbcMovieSetScrapedTitleRenamerTo})
        Me.tblMovieSetScraperTitleRenamerOpts.SetColumnSpan(Me.dgvMovieSetScraperTitleRenamer, 2)
        Me.dgvMovieSetScraperTitleRenamer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMovieSetScraperTitleRenamer.Location = New System.Drawing.Point(3, 3)
        Me.dgvMovieSetScraperTitleRenamer.MultiSelect = False
        Me.dgvMovieSetScraperTitleRenamer.Name = "dgvMovieSetScraperTitleRenamer"
        Me.dgvMovieSetScraperTitleRenamer.RowHeadersVisible = False
        Me.dgvMovieSetScraperTitleRenamer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMovieSetScraperTitleRenamer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMovieSetScraperTitleRenamer.ShowCellErrors = False
        Me.dgvMovieSetScraperTitleRenamer.ShowCellToolTips = False
        Me.dgvMovieSetScraperTitleRenamer.ShowRowErrors = False
        Me.dgvMovieSetScraperTitleRenamer.Size = New System.Drawing.Size(302, 156)
        Me.dgvMovieSetScraperTitleRenamer.TabIndex = 68
        '
        'tbcMovieSetScrapedTitleRenamerFrom
        '
        Me.tbcMovieSetScrapedTitleRenamerFrom.FillWeight = 130.0!
        Me.tbcMovieSetScrapedTitleRenamerFrom.HeaderText = "From"
        Me.tbcMovieSetScrapedTitleRenamerFrom.Name = "tbcMovieSetScrapedTitleRenamerFrom"
        Me.tbcMovieSetScrapedTitleRenamerFrom.Width = 130
        '
        'tbcMovieSetScrapedTitleRenamerTo
        '
        Me.tbcMovieSetScrapedTitleRenamerTo.FillWeight = 150.0!
        Me.tbcMovieSetScrapedTitleRenamerTo.HeaderText = "To"
        Me.tbcMovieSetScrapedTitleRenamerTo.Name = "tbcMovieSetScrapedTitleRenamerTo"
        Me.tbcMovieSetScrapedTitleRenamerTo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tbcMovieSetScrapedTitleRenamerTo.Width = 150
        '
        'gbMovieSetScraperGlobalOpts
        '
        Me.gbMovieSetScraperGlobalOpts.AutoSize = True
        Me.gbMovieSetScraperGlobalOpts.Controls.Add(Me.tblScraperSettings)
        Me.gbMovieSetScraperGlobalOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetScraperGlobalOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieSetScraperGlobalOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetScraperGlobalOpts.MinimumSize = New System.Drawing.Size(160, 0)
        Me.gbMovieSetScraperGlobalOpts.Name = "gbMovieSetScraperGlobalOpts"
        Me.gbMovieSetScraperGlobalOpts.Size = New System.Drawing.Size(314, 153)
        Me.gbMovieSetScraperGlobalOpts.TabIndex = 67
        Me.gbMovieSetScraperGlobalOpts.TabStop = False
        Me.gbMovieSetScraperGlobalOpts.Text = "Scraper Settings"
        '
        'tblScraperSettings
        '
        Me.tblScraperSettings.AutoScroll = True
        Me.tblScraperSettings.AutoSize = True
        Me.tblScraperSettings.ColumnCount = 4
        Me.tblScraperSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblScraperSettings.Controls.Add(Me.dgvSearchAdditional, 3, 2)
        Me.tblScraperSettings.Controls.Add(Me.chkMovieSetLockPlot, 2, 5)
        Me.tblScraperSettings.Controls.Add(Me.dgvTitle, 3, 4)
        Me.tblScraperSettings.Controls.Add(Me.lblSearchAdditional, 0, 2)
        Me.tblScraperSettings.Controls.Add(Me.chkMovieSetScraperPlot, 1, 5)
        Me.tblScraperSettings.Controls.Add(Me.lblSearchInitial, 0, 1)
        Me.tblScraperSettings.Controls.Add(Me.chkMovieSetLockTitle, 2, 4)
        Me.tblScraperSettings.Controls.Add(Me.chkMovieSetScraperTitle, 1, 4)
        Me.tblScraperSettings.Controls.Add(Me.lblMovieSetScraperGlobalHeaderLock, 2, 3)
        Me.tblScraperSettings.Controls.Add(Me.lblMovieSetScraperGlobalTitle, 0, 4)
        Me.tblScraperSettings.Controls.Add(Me.lblMovieSetScraperGlobalPlot, 0, 5)
        Me.tblScraperSettings.Controls.Add(Me.dgvPlot, 3, 5)
        Me.tblScraperSettings.Controls.Add(Me.lblFields, 0, 3)
        Me.tblScraperSettings.Controls.Add(Me.lblSearch, 0, 0)
        Me.tblScraperSettings.Controls.Add(Me.dgvSearchInitial, 3, 1)
        Me.tblScraperSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblScraperSettings.Location = New System.Drawing.Point(3, 18)
        Me.tblScraperSettings.Name = "tblScraperSettings"
        Me.tblScraperSettings.RowCount = 7
        Me.tblScraperSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScraperSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScraperSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblScraperSettings.Size = New System.Drawing.Size(308, 132)
        Me.tblScraperSettings.TabIndex = 1
        '
        'dgvSearchAdditional
        '
        Me.dgvSearchAdditional.Location = New System.Drawing.Point(154, 43)
        Me.dgvSearchAdditional.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvSearchAdditional.Name = "dgvSearchAdditional"
        Me.dgvSearchAdditional.Size = New System.Drawing.Size(100, 23)
        Me.dgvSearchAdditional.TabIndex = 70
        '
        'chkMovieSetLockPlot
        '
        Me.chkMovieSetLockPlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetLockPlot.AutoSize = True
        Me.chkMovieSetLockPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetLockPlot.Location = New System.Drawing.Point(128, 113)
        Me.chkMovieSetLockPlot.Name = "chkMovieSetLockPlot"
        Me.chkMovieSetLockPlot.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetLockPlot.TabIndex = 0
        Me.chkMovieSetLockPlot.UseVisualStyleBackColor = True
        '
        'dgvTitle
        '
        Me.dgvTitle.Location = New System.Drawing.Point(154, 86)
        Me.dgvTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvTitle.Name = "dgvTitle"
        Me.dgvTitle.Size = New System.Drawing.Size(100, 23)
        Me.dgvTitle.TabIndex = 70
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
        'chkMovieSetScraperPlot
        '
        Me.chkMovieSetScraperPlot.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetScraperPlot.AutoSize = True
        Me.chkMovieSetScraperPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetScraperPlot.Location = New System.Drawing.Point(99, 113)
        Me.chkMovieSetScraperPlot.Name = "chkMovieSetScraperPlot"
        Me.chkMovieSetScraperPlot.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetScraperPlot.TabIndex = 12
        Me.chkMovieSetScraperPlot.UseVisualStyleBackColor = True
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
        'chkMovieSetLockTitle
        '
        Me.chkMovieSetLockTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetLockTitle.AutoSize = True
        Me.chkMovieSetLockTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetLockTitle.Location = New System.Drawing.Point(128, 90)
        Me.chkMovieSetLockTitle.Name = "chkMovieSetLockTitle"
        Me.chkMovieSetLockTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetLockTitle.TabIndex = 2
        Me.chkMovieSetLockTitle.UseVisualStyleBackColor = True
        '
        'chkMovieSetScraperTitle
        '
        Me.chkMovieSetScraperTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkMovieSetScraperTitle.AutoSize = True
        Me.chkMovieSetScraperTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSetScraperTitle.Location = New System.Drawing.Point(99, 90)
        Me.chkMovieSetScraperTitle.Name = "chkMovieSetScraperTitle"
        Me.chkMovieSetScraperTitle.Size = New System.Drawing.Size(15, 14)
        Me.chkMovieSetScraperTitle.TabIndex = 0
        Me.chkMovieSetScraperTitle.UseVisualStyleBackColor = True
        '
        'lblMovieSetScraperGlobalHeaderLock
        '
        Me.lblMovieSetScraperGlobalHeaderLock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMovieSetScraperGlobalHeaderLock.AutoSize = True
        Me.lblMovieSetScraperGlobalHeaderLock.Location = New System.Drawing.Point(120, 69)
        Me.lblMovieSetScraperGlobalHeaderLock.Name = "lblMovieSetScraperGlobalHeaderLock"
        Me.lblMovieSetScraperGlobalHeaderLock.Size = New System.Drawing.Size(31, 13)
        Me.lblMovieSetScraperGlobalHeaderLock.TabIndex = 12
        Me.lblMovieSetScraperGlobalHeaderLock.Text = "Lock"
        '
        'lblMovieSetScraperGlobalTitle
        '
        Me.lblMovieSetScraperGlobalTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetScraperGlobalTitle.AutoSize = True
        Me.lblMovieSetScraperGlobalTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieSetScraperGlobalTitle.Location = New System.Drawing.Point(3, 91)
        Me.lblMovieSetScraperGlobalTitle.Name = "lblMovieSetScraperGlobalTitle"
        Me.lblMovieSetScraperGlobalTitle.Size = New System.Drawing.Size(28, 13)
        Me.lblMovieSetScraperGlobalTitle.TabIndex = 67
        Me.lblMovieSetScraperGlobalTitle.Text = "Title"
        '
        'lblMovieSetScraperGlobalPlot
        '
        Me.lblMovieSetScraperGlobalPlot.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSetScraperGlobalPlot.AutoSize = True
        Me.lblMovieSetScraperGlobalPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieSetScraperGlobalPlot.Location = New System.Drawing.Point(3, 114)
        Me.lblMovieSetScraperGlobalPlot.Name = "lblMovieSetScraperGlobalPlot"
        Me.lblMovieSetScraperGlobalPlot.Size = New System.Drawing.Size(27, 13)
        Me.lblMovieSetScraperGlobalPlot.TabIndex = 68
        Me.lblMovieSetScraperGlobalPlot.Text = "Plot"
        '
        'dgvPlot
        '
        Me.dgvPlot.Location = New System.Drawing.Point(154, 109)
        Me.dgvPlot.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvPlot.Name = "dgvPlot"
        Me.dgvPlot.Size = New System.Drawing.Size(100, 23)
        Me.dgvPlot.TabIndex = 70
        '
        'lblFields
        '
        Me.lblFields.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFields.AutoSize = True
        Me.lblFields.Location = New System.Drawing.Point(29, 69)
        Me.lblFields.Name = "lblFields"
        Me.lblFields.Size = New System.Drawing.Size(37, 13)
        Me.lblFields.TabIndex = 71
        Me.lblFields.Text = "Fields"
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(27, 3)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(41, 13)
        Me.lblSearch.TabIndex = 71
        Me.lblSearch.Text = "Search"
        '
        'dgvSearchInitial
        '
        Me.dgvSearchInitial.Location = New System.Drawing.Point(154, 20)
        Me.dgvSearchInitial.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvSearchInitial.Name = "dgvSearchInitial"
        Me.dgvSearchInitial.Size = New System.Drawing.Size(100, 23)
        Me.dgvSearchInitial.TabIndex = 70
        '
        'frmMovieSet_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 486)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovieSet_Data"
        Me.Text = "frmMovieSet_Data"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieSetScraperTitleRenamerOpts.ResumeLayout(False)
        Me.gbMovieSetScraperTitleRenamerOpts.PerformLayout()
        Me.tblMovieSetScraperTitleRenamerOpts.ResumeLayout(False)
        CType(Me.dgvMovieSetScraperTitleRenamer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMovieSetScraperGlobalOpts.ResumeLayout(False)
        Me.gbMovieSetScraperGlobalOpts.PerformLayout()
        Me.tblScraperSettings.ResumeLayout(False)
        Me.tblScraperSettings.PerformLayout()
        CType(Me.dgvSearchAdditional, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPlot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSearchInitial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetScraperTitleRenamerOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetScraperTitleRenamerOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieSetScraperTitleRenamerAdd As Windows.Forms.Button
    Friend WithEvents btnMovieSetScraperTitleRenamerRemove As Windows.Forms.Button
    Friend WithEvents dgvMovieSetScraperTitleRenamer As Windows.Forms.DataGridView
    Friend WithEvents tbcMovieSetScrapedTitleRenamerFrom As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbcMovieSetScrapedTitleRenamerTo As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbMovieSetScraperGlobalOpts As Windows.Forms.GroupBox
    Friend WithEvents tblScraperSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieSetLockPlot As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetScraperPlot As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetLockTitle As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetScraperTitle As Windows.Forms.CheckBox
    Friend WithEvents lblMovieSetScraperGlobalHeaderLock As Windows.Forms.Label
    Friend WithEvents lblMovieSetScraperGlobalTitle As Windows.Forms.Label
    Friend WithEvents lblMovieSetScraperGlobalPlot As Windows.Forms.Label
    Friend WithEvents dgvTitle As DataGridView
    Friend WithEvents dgvPlot As DataGridView
    Friend WithEvents lblFields As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents dgvSearchInitial As DataGridView
    Friend WithEvents lblSearchInitial As Label
    Friend WithEvents lblSearchAdditional As Label
    Friend WithEvents dgvSearchAdditional As DataGridView
End Class
