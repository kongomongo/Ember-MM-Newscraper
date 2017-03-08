<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovie_GUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovie_GUI))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieGeneralMiscOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieGeneralMiscOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieClickScrapeAsk = New System.Windows.Forms.CheckBox()
        Me.chkMovieClickScrape = New System.Windows.Forms.CheckBox()
        Me.gbMovieGeneralMediaListSortTokensOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieGeneralSortTokensOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieSortTokenReset = New System.Windows.Forms.Button()
        Me.btnMovieSortTokenRemove = New System.Windows.Forms.Button()
        Me.lstMovieSortTokens = New System.Windows.Forms.ListBox()
        Me.btnMovieSortTokenAdd = New System.Windows.Forms.Button()
        Me.txtMovieSortToken = New System.Windows.Forms.TextBox()
        Me.gbMovieGeneralMediaListSorting = New System.Windows.Forms.GroupBox()
        Me.tblMovieGeneralMediaListSorting = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieGeneralMediaListSortingDown = New System.Windows.Forms.Button()
        Me.btnMovieGeneralMediaListSortingUp = New System.Windows.Forms.Button()
        Me.lvMovieGeneralMediaListSorting = New System.Windows.Forms.ListView()
        Me.colMovieGeneralMediaListSortingDisplayIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieGeneralMediaListSortingColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieGeneralMediaListSortingLabel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieGeneralMediaListSortingHide = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnMovieGeneralMediaListSortingReset = New System.Windows.Forms.Button()
        Me.gbMovieGeneralCustomMarker = New System.Windows.Forms.GroupBox()
        Me.tblMovieGeneralCustomMarker = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieGeneralCustomMarker4 = New System.Windows.Forms.Button()
        Me.lblMovieGeneralCustomMarker1 = New System.Windows.Forms.Label()
        Me.btnMovieGeneralCustomMarker3 = New System.Windows.Forms.Button()
        Me.txtMovieGeneralCustomMarker4 = New System.Windows.Forms.TextBox()
        Me.btnMovieGeneralCustomMarker2 = New System.Windows.Forms.Button()
        Me.lblMovieGeneralCustomMarker2 = New System.Windows.Forms.Label()
        Me.btnMovieGeneralCustomMarker1 = New System.Windows.Forms.Button()
        Me.lblMovieGeneralCustomMarker4 = New System.Windows.Forms.Label()
        Me.txtMovieGeneralCustomMarker3 = New System.Windows.Forms.TextBox()
        Me.lblMovieGeneralCustomMarker3 = New System.Windows.Forms.Label()
        Me.txtMovieGeneralCustomMarker1 = New System.Windows.Forms.TextBox()
        Me.txtMovieGeneralCustomMarker2 = New System.Windows.Forms.TextBox()
        Me.gbMovieGeneralCustomScrapeButton = New System.Windows.Forms.GroupBox()
        Me.tblMovieGeneralCustomScrapeButton = New System.Windows.Forms.TableLayoutPanel()
        Me.cbMovieGeneralCustomScrapeButtonScrapeType = New System.Windows.Forms.ComboBox()
        Me.cbMovieGeneralCustomScrapeButtonModifierType = New System.Windows.Forms.ComboBox()
        Me.txtMovieGeneralCustomScrapeButtonScrapeType = New System.Windows.Forms.Label()
        Me.txtMovieGeneralCustomScrapeButtonModifierType = New System.Windows.Forms.Label()
        Me.rbMovieGeneralCustomScrapeButtonEnabled = New System.Windows.Forms.RadioButton()
        Me.rbMovieGeneralCustomScrapeButtonDisabled = New System.Windows.Forms.RadioButton()
        Me.lblMovieLanguageOverlay = New System.Windows.Forms.Label()
        Me.cbMovieLanguageOverlay = New System.Windows.Forms.ComboBox()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieGeneralMiscOpts.SuspendLayout()
        Me.tblMovieGeneralMiscOpts.SuspendLayout()
        Me.gbMovieGeneralMediaListSortTokensOpts.SuspendLayout()
        Me.tblMovieGeneralSortTokensOpts.SuspendLayout()
        Me.gbMovieGeneralMediaListSorting.SuspendLayout()
        Me.tblMovieGeneralMediaListSorting.SuspendLayout()
        Me.gbMovieGeneralCustomMarker.SuspendLayout()
        Me.tblMovieGeneralCustomMarker.SuspendLayout()
        Me.gbMovieGeneralCustomScrapeButton.SuspendLayout()
        Me.tblMovieGeneralCustomScrapeButton.SuspendLayout()
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
        Me.pnlSettings.Size = New System.Drawing.Size(527, 540)
        Me.pnlSettings.TabIndex = 16
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
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblSettings.Controls.Add(Me.gbMovieGeneralMediaListSortTokensOpts, 1, 2)
        Me.tblSettings.Controls.Add(Me.gbMovieGeneralMiscOpts, 0, 0)
        Me.tblSettings.Controls.Add(Me.gbMovieGeneralCustomMarker, 1, 3)
        Me.tblSettings.Controls.Add(Me.gbMovieGeneralCustomScrapeButton, 0, 1)
        Me.tblSettings.Controls.Add(Me.gbMovieGeneralMediaListSorting, 0, 2)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 5
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblSettings.Size = New System.Drawing.Size(527, 540)
        Me.tblSettings.TabIndex = 10
        '
        'gbMovieGeneralMiscOpts
        '
        Me.gbMovieGeneralMiscOpts.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.gbMovieGeneralMiscOpts, 2)
        Me.gbMovieGeneralMiscOpts.Controls.Add(Me.tblMovieGeneralMiscOpts)
        Me.gbMovieGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieGeneralMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieGeneralMiscOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieGeneralMiscOpts.Name = "gbMovieGeneralMiscOpts"
        Me.gbMovieGeneralMiscOpts.Size = New System.Drawing.Size(497, 94)
        Me.gbMovieGeneralMiscOpts.TabIndex = 1
        Me.gbMovieGeneralMiscOpts.TabStop = False
        Me.gbMovieGeneralMiscOpts.Text = "Miscellaneous"
        '
        'tblMovieGeneralMiscOpts
        '
        Me.tblMovieGeneralMiscOpts.AutoSize = True
        Me.tblMovieGeneralMiscOpts.ColumnCount = 3
        Me.tblMovieGeneralMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMiscOpts.Controls.Add(Me.cbMovieLanguageOverlay, 1, 0)
        Me.tblMovieGeneralMiscOpts.Controls.Add(Me.lblMovieLanguageOverlay, 0, 0)
        Me.tblMovieGeneralMiscOpts.Controls.Add(Me.chkMovieClickScrapeAsk, 0, 2)
        Me.tblMovieGeneralMiscOpts.Controls.Add(Me.chkMovieClickScrape, 0, 1)
        Me.tblMovieGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieGeneralMiscOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieGeneralMiscOpts.Name = "tblMovieGeneralMiscOpts"
        Me.tblMovieGeneralMiscOpts.RowCount = 4
        Me.tblMovieGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralMiscOpts.Size = New System.Drawing.Size(491, 73)
        Me.tblMovieGeneralMiscOpts.TabIndex = 10
        '
        'chkMovieClickScrapeAsk
        '
        Me.chkMovieClickScrapeAsk.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieClickScrapeAsk.AutoSize = True
        Me.chkMovieClickScrapeAsk.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkMovieClickScrapeAsk.Location = New System.Drawing.Point(3, 53)
        Me.chkMovieClickScrapeAsk.Name = "chkMovieClickScrapeAsk"
        Me.chkMovieClickScrapeAsk.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkMovieClickScrapeAsk.Size = New System.Drawing.Size(147, 17)
        Me.chkMovieClickScrapeAsk.TabIndex = 64
        Me.chkMovieClickScrapeAsk.Text = "Ask On Click Scrape"
        Me.chkMovieClickScrapeAsk.UseVisualStyleBackColor = True
        '
        'chkMovieClickScrape
        '
        Me.chkMovieClickScrape.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieClickScrape.AutoSize = True
        Me.chkMovieClickScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkMovieClickScrape.Location = New System.Drawing.Point(3, 30)
        Me.chkMovieClickScrape.Name = "chkMovieClickScrape"
        Me.chkMovieClickScrape.Size = New System.Drawing.Size(125, 17)
        Me.chkMovieClickScrape.TabIndex = 65
        Me.chkMovieClickScrape.Text = "Enable Click Scrape"
        Me.chkMovieClickScrape.UseVisualStyleBackColor = True
        '
        'gbMovieGeneralMediaListSortTokensOpts
        '
        Me.gbMovieGeneralMediaListSortTokensOpts.AutoSize = True
        Me.gbMovieGeneralMediaListSortTokensOpts.Controls.Add(Me.tblMovieGeneralSortTokensOpts)
        Me.gbMovieGeneralMediaListSortTokensOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieGeneralMediaListSortTokensOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieGeneralMediaListSortTokensOpts.Location = New System.Drawing.Point(221, 207)
        Me.gbMovieGeneralMediaListSortTokensOpts.Name = "gbMovieGeneralMediaListSortTokensOpts"
        Me.gbMovieGeneralMediaListSortTokensOpts.Size = New System.Drawing.Size(279, 156)
        Me.gbMovieGeneralMediaListSortTokensOpts.TabIndex = 71
        Me.gbMovieGeneralMediaListSortTokensOpts.TabStop = False
        Me.gbMovieGeneralMediaListSortTokensOpts.Text = "Sort Tokens to Ignore"
        '
        'tblMovieGeneralSortTokensOpts
        '
        Me.tblMovieGeneralSortTokensOpts.AutoSize = True
        Me.tblMovieGeneralSortTokensOpts.ColumnCount = 5
        Me.tblMovieGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralSortTokensOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralSortTokensOpts.Controls.Add(Me.btnMovieSortTokenReset, 3, 1)
        Me.tblMovieGeneralSortTokensOpts.Controls.Add(Me.btnMovieSortTokenRemove, 2, 1)
        Me.tblMovieGeneralSortTokensOpts.Controls.Add(Me.lstMovieSortTokens, 0, 0)
        Me.tblMovieGeneralSortTokensOpts.Controls.Add(Me.btnMovieSortTokenAdd, 1, 1)
        Me.tblMovieGeneralSortTokensOpts.Controls.Add(Me.txtMovieSortToken, 0, 1)
        Me.tblMovieGeneralSortTokensOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieGeneralSortTokensOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieGeneralSortTokensOpts.Name = "tblMovieGeneralSortTokensOpts"
        Me.tblMovieGeneralSortTokensOpts.RowCount = 3
        Me.tblMovieGeneralSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralSortTokensOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralSortTokensOpts.Size = New System.Drawing.Size(273, 135)
        Me.tblMovieGeneralSortTokensOpts.TabIndex = 11
        '
        'btnMovieSortTokenReset
        '
        Me.btnMovieSortTokenReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieSortTokenReset.Image = CType(resources.GetObject("btnMovieSortTokenReset.Image"), System.Drawing.Image)
        Me.btnMovieSortTokenReset.Location = New System.Drawing.Point(180, 109)
        Me.btnMovieSortTokenReset.Name = "btnMovieSortTokenReset"
        Me.btnMovieSortTokenReset.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSortTokenReset.TabIndex = 9
        Me.btnMovieSortTokenReset.UseVisualStyleBackColor = True
        '
        'btnMovieSortTokenRemove
        '
        Me.btnMovieSortTokenRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieSortTokenRemove.Image = CType(resources.GetObject("btnMovieSortTokenRemove.Image"), System.Drawing.Image)
        Me.btnMovieSortTokenRemove.Location = New System.Drawing.Point(99, 109)
        Me.btnMovieSortTokenRemove.Name = "btnMovieSortTokenRemove"
        Me.btnMovieSortTokenRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSortTokenRemove.TabIndex = 3
        Me.btnMovieSortTokenRemove.UseVisualStyleBackColor = True
        '
        'lstMovieSortTokens
        '
        Me.tblMovieGeneralSortTokensOpts.SetColumnSpan(Me.lstMovieSortTokens, 4)
        Me.lstMovieSortTokens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMovieSortTokens.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstMovieSortTokens.FormattingEnabled = True
        Me.lstMovieSortTokens.Location = New System.Drawing.Point(3, 3)
        Me.lstMovieSortTokens.Name = "lstMovieSortTokens"
        Me.lstMovieSortTokens.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstMovieSortTokens.Size = New System.Drawing.Size(200, 100)
        Me.lstMovieSortTokens.Sorted = True
        Me.lstMovieSortTokens.TabIndex = 0
        '
        'btnMovieSortTokenAdd
        '
        Me.btnMovieSortTokenAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieSortTokenAdd.Image = CType(resources.GetObject("btnMovieSortTokenAdd.Image"), System.Drawing.Image)
        Me.btnMovieSortTokenAdd.Location = New System.Drawing.Point(70, 109)
        Me.btnMovieSortTokenAdd.Name = "btnMovieSortTokenAdd"
        Me.btnMovieSortTokenAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieSortTokenAdd.TabIndex = 2
        Me.btnMovieSortTokenAdd.UseVisualStyleBackColor = True
        '
        'txtMovieSortToken
        '
        Me.txtMovieSortToken.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSortToken.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieSortToken.Location = New System.Drawing.Point(3, 109)
        Me.txtMovieSortToken.Name = "txtMovieSortToken"
        Me.txtMovieSortToken.Size = New System.Drawing.Size(61, 22)
        Me.txtMovieSortToken.TabIndex = 1
        '
        'gbMovieGeneralMediaListSorting
        '
        Me.gbMovieGeneralMediaListSorting.AutoSize = True
        Me.gbMovieGeneralMediaListSorting.Controls.Add(Me.tblMovieGeneralMediaListSorting)
        Me.gbMovieGeneralMediaListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieGeneralMediaListSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbMovieGeneralMediaListSorting.Location = New System.Drawing.Point(3, 207)
        Me.gbMovieGeneralMediaListSorting.Name = "gbMovieGeneralMediaListSorting"
        Me.tblSettings.SetRowSpan(Me.gbMovieGeneralMediaListSorting, 2)
        Me.gbMovieGeneralMediaListSorting.Size = New System.Drawing.Size(212, 306)
        Me.gbMovieGeneralMediaListSorting.TabIndex = 14
        Me.gbMovieGeneralMediaListSorting.TabStop = False
        Me.gbMovieGeneralMediaListSorting.Text = "Movie List Sorting"
        '
        'tblMovieGeneralMediaListSorting
        '
        Me.tblMovieGeneralMediaListSorting.AutoSize = True
        Me.tblMovieGeneralMediaListSorting.ColumnCount = 6
        Me.tblMovieGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMediaListSorting.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralMediaListSorting.Controls.Add(Me.btnMovieGeneralMediaListSortingDown, 2, 1)
        Me.tblMovieGeneralMediaListSorting.Controls.Add(Me.btnMovieGeneralMediaListSortingUp, 1, 1)
        Me.tblMovieGeneralMediaListSorting.Controls.Add(Me.lvMovieGeneralMediaListSorting, 0, 0)
        Me.tblMovieGeneralMediaListSorting.Controls.Add(Me.btnMovieGeneralMediaListSortingReset, 4, 1)
        Me.tblMovieGeneralMediaListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieGeneralMediaListSorting.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieGeneralMediaListSorting.Name = "tblMovieGeneralMediaListSorting"
        Me.tblMovieGeneralMediaListSorting.RowCount = 3
        Me.tblMovieGeneralMediaListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralMediaListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralMediaListSorting.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralMediaListSorting.Size = New System.Drawing.Size(206, 285)
        Me.tblMovieGeneralMediaListSorting.TabIndex = 0
        '
        'btnMovieGeneralMediaListSortingDown
        '
        Me.btnMovieGeneralMediaListSortingDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMovieGeneralMediaListSortingDown.Image = CType(resources.GetObject("btnMovieGeneralMediaListSortingDown.Image"), System.Drawing.Image)
        Me.btnMovieGeneralMediaListSortingDown.Location = New System.Drawing.Point(91, 259)
        Me.btnMovieGeneralMediaListSortingDown.Name = "btnMovieGeneralMediaListSortingDown"
        Me.btnMovieGeneralMediaListSortingDown.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieGeneralMediaListSortingDown.TabIndex = 12
        Me.btnMovieGeneralMediaListSortingDown.UseVisualStyleBackColor = True
        '
        'btnMovieGeneralMediaListSortingUp
        '
        Me.btnMovieGeneralMediaListSortingUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMovieGeneralMediaListSortingUp.Image = CType(resources.GetObject("btnMovieGeneralMediaListSortingUp.Image"), System.Drawing.Image)
        Me.btnMovieGeneralMediaListSortingUp.Location = New System.Drawing.Point(62, 259)
        Me.btnMovieGeneralMediaListSortingUp.Name = "btnMovieGeneralMediaListSortingUp"
        Me.btnMovieGeneralMediaListSortingUp.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieGeneralMediaListSortingUp.TabIndex = 13
        Me.btnMovieGeneralMediaListSortingUp.UseVisualStyleBackColor = True
        '
        'lvMovieGeneralMediaListSorting
        '
        Me.lvMovieGeneralMediaListSorting.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMovieGeneralMediaListSortingDisplayIndex, Me.colMovieGeneralMediaListSortingColumn, Me.colMovieGeneralMediaListSortingLabel, Me.colMovieGeneralMediaListSortingHide})
        Me.tblMovieGeneralMediaListSorting.SetColumnSpan(Me.lvMovieGeneralMediaListSorting, 5)
        Me.lvMovieGeneralMediaListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvMovieGeneralMediaListSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvMovieGeneralMediaListSorting.FullRowSelect = True
        Me.lvMovieGeneralMediaListSorting.HideSelection = False
        Me.lvMovieGeneralMediaListSorting.Location = New System.Drawing.Point(3, 3)
        Me.lvMovieGeneralMediaListSorting.Name = "lvMovieGeneralMediaListSorting"
        Me.lvMovieGeneralMediaListSorting.Size = New System.Drawing.Size(200, 250)
        Me.lvMovieGeneralMediaListSorting.TabIndex = 10
        Me.lvMovieGeneralMediaListSorting.UseCompatibleStateImageBehavior = False
        Me.lvMovieGeneralMediaListSorting.View = System.Windows.Forms.View.Details
        '
        'colMovieGeneralMediaListSortingDisplayIndex
        '
        Me.colMovieGeneralMediaListSortingDisplayIndex.Text = "DisplayIndex"
        Me.colMovieGeneralMediaListSortingDisplayIndex.Width = 0
        '
        'colMovieGeneralMediaListSortingColumn
        '
        Me.colMovieGeneralMediaListSortingColumn.Text = "DBName"
        Me.colMovieGeneralMediaListSortingColumn.Width = 0
        '
        'colMovieGeneralMediaListSortingLabel
        '
        Me.colMovieGeneralMediaListSortingLabel.Text = "Column"
        Me.colMovieGeneralMediaListSortingLabel.Width = 110
        '
        'colMovieGeneralMediaListSortingHide
        '
        Me.colMovieGeneralMediaListSortingHide.Text = "Hide"
        '
        'btnMovieGeneralMediaListSortingReset
        '
        Me.btnMovieGeneralMediaListSortingReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieGeneralMediaListSortingReset.Image = CType(resources.GetObject("btnMovieGeneralMediaListSortingReset.Image"), System.Drawing.Image)
        Me.btnMovieGeneralMediaListSortingReset.Location = New System.Drawing.Point(180, 259)
        Me.btnMovieGeneralMediaListSortingReset.Name = "btnMovieGeneralMediaListSortingReset"
        Me.btnMovieGeneralMediaListSortingReset.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieGeneralMediaListSortingReset.TabIndex = 11
        Me.btnMovieGeneralMediaListSortingReset.UseVisualStyleBackColor = True
        '
        'gbMovieGeneralCustomMarker
        '
        Me.gbMovieGeneralCustomMarker.AutoSize = True
        Me.gbMovieGeneralCustomMarker.Controls.Add(Me.tblMovieGeneralCustomMarker)
        Me.gbMovieGeneralCustomMarker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieGeneralCustomMarker.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieGeneralCustomMarker.Location = New System.Drawing.Point(221, 369)
        Me.gbMovieGeneralCustomMarker.Name = "gbMovieGeneralCustomMarker"
        Me.gbMovieGeneralCustomMarker.Size = New System.Drawing.Size(279, 144)
        Me.gbMovieGeneralCustomMarker.TabIndex = 9
        Me.gbMovieGeneralCustomMarker.TabStop = False
        Me.gbMovieGeneralCustomMarker.Text = "Custom Marker"
        '
        'tblMovieGeneralCustomMarker
        '
        Me.tblMovieGeneralCustomMarker.AutoSize = True
        Me.tblMovieGeneralCustomMarker.ColumnCount = 4
        Me.tblMovieGeneralCustomMarker.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralCustomMarker.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralCustomMarker.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralCustomMarker.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.btnMovieGeneralCustomMarker4, 2, 3)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.lblMovieGeneralCustomMarker1, 0, 0)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.btnMovieGeneralCustomMarker3, 2, 2)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.txtMovieGeneralCustomMarker4, 1, 3)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.btnMovieGeneralCustomMarker2, 2, 1)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.lblMovieGeneralCustomMarker2, 0, 1)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.btnMovieGeneralCustomMarker1, 2, 0)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.lblMovieGeneralCustomMarker4, 0, 3)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.txtMovieGeneralCustomMarker3, 1, 2)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.lblMovieGeneralCustomMarker3, 0, 2)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.txtMovieGeneralCustomMarker1, 1, 0)
        Me.tblMovieGeneralCustomMarker.Controls.Add(Me.txtMovieGeneralCustomMarker2, 1, 1)
        Me.tblMovieGeneralCustomMarker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieGeneralCustomMarker.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieGeneralCustomMarker.Name = "tblMovieGeneralCustomMarker"
        Me.tblMovieGeneralCustomMarker.RowCount = 5
        Me.tblMovieGeneralCustomMarker.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomMarker.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomMarker.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomMarker.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomMarker.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomMarker.Size = New System.Drawing.Size(273, 123)
        Me.tblMovieGeneralCustomMarker.TabIndex = 10
        '
        'btnMovieGeneralCustomMarker4
        '
        Me.btnMovieGeneralCustomMarker4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieGeneralCustomMarker4.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnMovieGeneralCustomMarker4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMovieGeneralCustomMarker4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnMovieGeneralCustomMarker4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMovieGeneralCustomMarker4.Location = New System.Drawing.Point(206, 87)
        Me.btnMovieGeneralCustomMarker4.Name = "btnMovieGeneralCustomMarker4"
        Me.btnMovieGeneralCustomMarker4.Size = New System.Drawing.Size(24, 22)
        Me.btnMovieGeneralCustomMarker4.TabIndex = 24
        Me.btnMovieGeneralCustomMarker4.UseVisualStyleBackColor = False
        '
        'lblMovieGeneralCustomMarker1
        '
        Me.lblMovieGeneralCustomMarker1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieGeneralCustomMarker1.AutoSize = True
        Me.lblMovieGeneralCustomMarker1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieGeneralCustomMarker1.Location = New System.Drawing.Point(3, 7)
        Me.lblMovieGeneralCustomMarker1.Name = "lblMovieGeneralCustomMarker1"
        Me.lblMovieGeneralCustomMarker1.Size = New System.Drawing.Size(55, 13)
        Me.lblMovieGeneralCustomMarker1.TabIndex = 0
        Me.lblMovieGeneralCustomMarker1.Text = "Custom 1"
        '
        'btnMovieGeneralCustomMarker3
        '
        Me.btnMovieGeneralCustomMarker3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieGeneralCustomMarker3.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnMovieGeneralCustomMarker3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMovieGeneralCustomMarker3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnMovieGeneralCustomMarker3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMovieGeneralCustomMarker3.Location = New System.Drawing.Point(206, 59)
        Me.btnMovieGeneralCustomMarker3.Name = "btnMovieGeneralCustomMarker3"
        Me.btnMovieGeneralCustomMarker3.Size = New System.Drawing.Size(24, 22)
        Me.btnMovieGeneralCustomMarker3.TabIndex = 21
        Me.btnMovieGeneralCustomMarker3.UseVisualStyleBackColor = False
        '
        'txtMovieGeneralCustomMarker4
        '
        Me.txtMovieGeneralCustomMarker4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieGeneralCustomMarker4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtMovieGeneralCustomMarker4.Location = New System.Drawing.Point(64, 87)
        Me.txtMovieGeneralCustomMarker4.Name = "txtMovieGeneralCustomMarker4"
        Me.txtMovieGeneralCustomMarker4.Size = New System.Drawing.Size(136, 22)
        Me.txtMovieGeneralCustomMarker4.TabIndex = 23
        '
        'btnMovieGeneralCustomMarker2
        '
        Me.btnMovieGeneralCustomMarker2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieGeneralCustomMarker2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnMovieGeneralCustomMarker2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMovieGeneralCustomMarker2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnMovieGeneralCustomMarker2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMovieGeneralCustomMarker2.Location = New System.Drawing.Point(206, 31)
        Me.btnMovieGeneralCustomMarker2.Name = "btnMovieGeneralCustomMarker2"
        Me.btnMovieGeneralCustomMarker2.Size = New System.Drawing.Size(24, 22)
        Me.btnMovieGeneralCustomMarker2.TabIndex = 18
        Me.btnMovieGeneralCustomMarker2.UseVisualStyleBackColor = False
        '
        'lblMovieGeneralCustomMarker2
        '
        Me.lblMovieGeneralCustomMarker2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieGeneralCustomMarker2.AutoSize = True
        Me.lblMovieGeneralCustomMarker2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieGeneralCustomMarker2.Location = New System.Drawing.Point(3, 35)
        Me.lblMovieGeneralCustomMarker2.Name = "lblMovieGeneralCustomMarker2"
        Me.lblMovieGeneralCustomMarker2.Size = New System.Drawing.Size(55, 13)
        Me.lblMovieGeneralCustomMarker2.TabIndex = 16
        Me.lblMovieGeneralCustomMarker2.Text = "Custom 2"
        '
        'btnMovieGeneralCustomMarker1
        '
        Me.btnMovieGeneralCustomMarker1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieGeneralCustomMarker1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnMovieGeneralCustomMarker1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMovieGeneralCustomMarker1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnMovieGeneralCustomMarker1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMovieGeneralCustomMarker1.Location = New System.Drawing.Point(206, 3)
        Me.btnMovieGeneralCustomMarker1.Name = "btnMovieGeneralCustomMarker1"
        Me.btnMovieGeneralCustomMarker1.Size = New System.Drawing.Size(24, 22)
        Me.btnMovieGeneralCustomMarker1.TabIndex = 15
        Me.btnMovieGeneralCustomMarker1.UseVisualStyleBackColor = False
        '
        'lblMovieGeneralCustomMarker4
        '
        Me.lblMovieGeneralCustomMarker4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieGeneralCustomMarker4.AutoSize = True
        Me.lblMovieGeneralCustomMarker4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieGeneralCustomMarker4.Location = New System.Drawing.Point(3, 91)
        Me.lblMovieGeneralCustomMarker4.Name = "lblMovieGeneralCustomMarker4"
        Me.lblMovieGeneralCustomMarker4.Size = New System.Drawing.Size(55, 13)
        Me.lblMovieGeneralCustomMarker4.TabIndex = 22
        Me.lblMovieGeneralCustomMarker4.Text = "Custom 4"
        '
        'txtMovieGeneralCustomMarker3
        '
        Me.txtMovieGeneralCustomMarker3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieGeneralCustomMarker3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtMovieGeneralCustomMarker3.Location = New System.Drawing.Point(64, 59)
        Me.txtMovieGeneralCustomMarker3.Name = "txtMovieGeneralCustomMarker3"
        Me.txtMovieGeneralCustomMarker3.Size = New System.Drawing.Size(136, 22)
        Me.txtMovieGeneralCustomMarker3.TabIndex = 20
        '
        'lblMovieGeneralCustomMarker3
        '
        Me.lblMovieGeneralCustomMarker3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieGeneralCustomMarker3.AutoSize = True
        Me.lblMovieGeneralCustomMarker3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieGeneralCustomMarker3.Location = New System.Drawing.Point(3, 63)
        Me.lblMovieGeneralCustomMarker3.Name = "lblMovieGeneralCustomMarker3"
        Me.lblMovieGeneralCustomMarker3.Size = New System.Drawing.Size(55, 13)
        Me.lblMovieGeneralCustomMarker3.TabIndex = 19
        Me.lblMovieGeneralCustomMarker3.Text = "Custom 3"
        '
        'txtMovieGeneralCustomMarker1
        '
        Me.txtMovieGeneralCustomMarker1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieGeneralCustomMarker1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtMovieGeneralCustomMarker1.Location = New System.Drawing.Point(64, 3)
        Me.txtMovieGeneralCustomMarker1.Name = "txtMovieGeneralCustomMarker1"
        Me.txtMovieGeneralCustomMarker1.Size = New System.Drawing.Size(136, 22)
        Me.txtMovieGeneralCustomMarker1.TabIndex = 1
        '
        'txtMovieGeneralCustomMarker2
        '
        Me.txtMovieGeneralCustomMarker2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieGeneralCustomMarker2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtMovieGeneralCustomMarker2.Location = New System.Drawing.Point(64, 31)
        Me.txtMovieGeneralCustomMarker2.Name = "txtMovieGeneralCustomMarker2"
        Me.txtMovieGeneralCustomMarker2.Size = New System.Drawing.Size(136, 22)
        Me.txtMovieGeneralCustomMarker2.TabIndex = 17
        '
        'gbMovieGeneralCustomScrapeButton
        '
        Me.gbMovieGeneralCustomScrapeButton.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.gbMovieGeneralCustomScrapeButton, 2)
        Me.gbMovieGeneralCustomScrapeButton.Controls.Add(Me.tblMovieGeneralCustomScrapeButton)
        Me.gbMovieGeneralCustomScrapeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieGeneralCustomScrapeButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieGeneralCustomScrapeButton.Location = New System.Drawing.Point(3, 103)
        Me.gbMovieGeneralCustomScrapeButton.Name = "gbMovieGeneralCustomScrapeButton"
        Me.gbMovieGeneralCustomScrapeButton.Size = New System.Drawing.Size(497, 98)
        Me.gbMovieGeneralCustomScrapeButton.TabIndex = 11
        Me.gbMovieGeneralCustomScrapeButton.TabStop = False
        Me.gbMovieGeneralCustomScrapeButton.Text = "Scrape Button"
        '
        'tblMovieGeneralCustomScrapeButton
        '
        Me.tblMovieGeneralCustomScrapeButton.AutoSize = True
        Me.tblMovieGeneralCustomScrapeButton.ColumnCount = 2
        Me.tblMovieGeneralCustomScrapeButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralCustomScrapeButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblMovieGeneralCustomScrapeButton.Controls.Add(Me.cbMovieGeneralCustomScrapeButtonScrapeType, 1, 1)
        Me.tblMovieGeneralCustomScrapeButton.Controls.Add(Me.cbMovieGeneralCustomScrapeButtonModifierType, 1, 2)
        Me.tblMovieGeneralCustomScrapeButton.Controls.Add(Me.txtMovieGeneralCustomScrapeButtonScrapeType, 0, 1)
        Me.tblMovieGeneralCustomScrapeButton.Controls.Add(Me.txtMovieGeneralCustomScrapeButtonModifierType, 0, 2)
        Me.tblMovieGeneralCustomScrapeButton.Controls.Add(Me.rbMovieGeneralCustomScrapeButtonEnabled, 1, 0)
        Me.tblMovieGeneralCustomScrapeButton.Controls.Add(Me.rbMovieGeneralCustomScrapeButtonDisabled, 0, 0)
        Me.tblMovieGeneralCustomScrapeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieGeneralCustomScrapeButton.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieGeneralCustomScrapeButton.Name = "tblMovieGeneralCustomScrapeButton"
        Me.tblMovieGeneralCustomScrapeButton.RowCount = 4
        Me.tblMovieGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomScrapeButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralCustomScrapeButton.Size = New System.Drawing.Size(491, 77)
        Me.tblMovieGeneralCustomScrapeButton.TabIndex = 0
        '
        'cbMovieGeneralCustomScrapeButtonScrapeType
        '
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.Enabled = False
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.FormattingEnabled = True
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.Location = New System.Drawing.Point(159, 26)
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.Name = "cbMovieGeneralCustomScrapeButtonScrapeType"
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.Size = New System.Drawing.Size(329, 21)
        Me.cbMovieGeneralCustomScrapeButtonScrapeType.TabIndex = 1
        '
        'cbMovieGeneralCustomScrapeButtonModifierType
        '
        Me.cbMovieGeneralCustomScrapeButtonModifierType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbMovieGeneralCustomScrapeButtonModifierType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovieGeneralCustomScrapeButtonModifierType.Enabled = False
        Me.cbMovieGeneralCustomScrapeButtonModifierType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMovieGeneralCustomScrapeButtonModifierType.FormattingEnabled = True
        Me.cbMovieGeneralCustomScrapeButtonModifierType.Location = New System.Drawing.Point(159, 53)
        Me.cbMovieGeneralCustomScrapeButtonModifierType.Name = "cbMovieGeneralCustomScrapeButtonModifierType"
        Me.cbMovieGeneralCustomScrapeButtonModifierType.Size = New System.Drawing.Size(329, 21)
        Me.cbMovieGeneralCustomScrapeButtonModifierType.TabIndex = 2
        '
        'txtMovieGeneralCustomScrapeButtonScrapeType
        '
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.AutoSize = True
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.Enabled = False
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.Location = New System.Drawing.Point(3, 30)
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.Name = "txtMovieGeneralCustomScrapeButtonScrapeType"
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.Size = New System.Drawing.Size(66, 13)
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.TabIndex = 3
        Me.txtMovieGeneralCustomScrapeButtonScrapeType.Text = "Scrape Type"
        '
        'txtMovieGeneralCustomScrapeButtonModifierType
        '
        Me.txtMovieGeneralCustomScrapeButtonModifierType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieGeneralCustomScrapeButtonModifierType.AutoSize = True
        Me.txtMovieGeneralCustomScrapeButtonModifierType.Enabled = False
        Me.txtMovieGeneralCustomScrapeButtonModifierType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieGeneralCustomScrapeButtonModifierType.Location = New System.Drawing.Point(3, 57)
        Me.txtMovieGeneralCustomScrapeButtonModifierType.Name = "txtMovieGeneralCustomScrapeButtonModifierType"
        Me.txtMovieGeneralCustomScrapeButtonModifierType.Size = New System.Drawing.Size(76, 13)
        Me.txtMovieGeneralCustomScrapeButtonModifierType.TabIndex = 4
        Me.txtMovieGeneralCustomScrapeButtonModifierType.Text = "Modifier Type"
        '
        'rbMovieGeneralCustomScrapeButtonEnabled
        '
        Me.rbMovieGeneralCustomScrapeButtonEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbMovieGeneralCustomScrapeButtonEnabled.AutoSize = True
        Me.rbMovieGeneralCustomScrapeButtonEnabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMovieGeneralCustomScrapeButtonEnabled.Location = New System.Drawing.Point(159, 3)
        Me.rbMovieGeneralCustomScrapeButtonEnabled.Name = "rbMovieGeneralCustomScrapeButtonEnabled"
        Me.rbMovieGeneralCustomScrapeButtonEnabled.Size = New System.Drawing.Size(150, 17)
        Me.rbMovieGeneralCustomScrapeButtonEnabled.TabIndex = 5
        Me.rbMovieGeneralCustomScrapeButtonEnabled.TabStop = True
        Me.rbMovieGeneralCustomScrapeButtonEnabled.Text = "Custom Scrape Function"
        Me.rbMovieGeneralCustomScrapeButtonEnabled.UseVisualStyleBackColor = True
        '
        'rbMovieGeneralCustomScrapeButtonDisabled
        '
        Me.rbMovieGeneralCustomScrapeButtonDisabled.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbMovieGeneralCustomScrapeButtonDisabled.AutoSize = True
        Me.rbMovieGeneralCustomScrapeButtonDisabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMovieGeneralCustomScrapeButtonDisabled.Location = New System.Drawing.Point(3, 3)
        Me.rbMovieGeneralCustomScrapeButtonDisabled.Name = "rbMovieGeneralCustomScrapeButtonDisabled"
        Me.rbMovieGeneralCustomScrapeButtonDisabled.Size = New System.Drawing.Size(150, 17)
        Me.rbMovieGeneralCustomScrapeButtonDisabled.TabIndex = 6
        Me.rbMovieGeneralCustomScrapeButtonDisabled.TabStop = True
        Me.rbMovieGeneralCustomScrapeButtonDisabled.Text = "Open Drop Down Menu"
        Me.rbMovieGeneralCustomScrapeButtonDisabled.UseVisualStyleBackColor = True
        '
        'lblMovieLanguageOverlay
        '
        Me.lblMovieLanguageOverlay.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieLanguageOverlay.AutoSize = True
        Me.lblMovieLanguageOverlay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieLanguageOverlay.Location = New System.Drawing.Point(3, 7)
        Me.lblMovieLanguageOverlay.Name = "lblMovieLanguageOverlay"
        Me.lblMovieLanguageOverlay.Size = New System.Drawing.Size(297, 13)
        Me.lblMovieLanguageOverlay.TabIndex = 16
        Me.lblMovieLanguageOverlay.Text = "Display best Audio Stream with the following Language:"
        '
        'cbMovieLanguageOverlay
        '
        Me.cbMovieLanguageOverlay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbMovieLanguageOverlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovieLanguageOverlay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbMovieLanguageOverlay.FormattingEnabled = True
        Me.cbMovieLanguageOverlay.Location = New System.Drawing.Point(306, 3)
        Me.cbMovieLanguageOverlay.Name = "cbMovieLanguageOverlay"
        Me.cbMovieLanguageOverlay.Size = New System.Drawing.Size(174, 21)
        Me.cbMovieLanguageOverlay.Sorted = True
        Me.cbMovieLanguageOverlay.TabIndex = 17
        '
        'frmMovie_GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 540)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovie_GUI"
        Me.Text = "frmMovie_GUI"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieGeneralMiscOpts.ResumeLayout(False)
        Me.gbMovieGeneralMiscOpts.PerformLayout()
        Me.tblMovieGeneralMiscOpts.ResumeLayout(False)
        Me.tblMovieGeneralMiscOpts.PerformLayout()
        Me.gbMovieGeneralMediaListSortTokensOpts.ResumeLayout(False)
        Me.gbMovieGeneralMediaListSortTokensOpts.PerformLayout()
        Me.tblMovieGeneralSortTokensOpts.ResumeLayout(False)
        Me.tblMovieGeneralSortTokensOpts.PerformLayout()
        Me.gbMovieGeneralMediaListSorting.ResumeLayout(False)
        Me.gbMovieGeneralMediaListSorting.PerformLayout()
        Me.tblMovieGeneralMediaListSorting.ResumeLayout(False)
        Me.gbMovieGeneralCustomMarker.ResumeLayout(False)
        Me.gbMovieGeneralCustomMarker.PerformLayout()
        Me.tblMovieGeneralCustomMarker.ResumeLayout(False)
        Me.tblMovieGeneralCustomMarker.PerformLayout()
        Me.gbMovieGeneralCustomScrapeButton.ResumeLayout(False)
        Me.gbMovieGeneralCustomScrapeButton.PerformLayout()
        Me.tblMovieGeneralCustomScrapeButton.ResumeLayout(False)
        Me.tblMovieGeneralCustomScrapeButton.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieGeneralMiscOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieGeneralMiscOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieClickScrapeAsk As Windows.Forms.CheckBox
    Friend WithEvents chkMovieClickScrape As Windows.Forms.CheckBox
    Friend WithEvents gbMovieGeneralMediaListSortTokensOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieGeneralSortTokensOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieSortTokenReset As Windows.Forms.Button
    Friend WithEvents btnMovieSortTokenRemove As Windows.Forms.Button
    Friend WithEvents lstMovieSortTokens As Windows.Forms.ListBox
    Friend WithEvents btnMovieSortTokenAdd As Windows.Forms.Button
    Friend WithEvents txtMovieSortToken As Windows.Forms.TextBox
    Friend WithEvents gbMovieGeneralMediaListSorting As Windows.Forms.GroupBox
    Friend WithEvents tblMovieGeneralMediaListSorting As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieGeneralMediaListSortingDown As Windows.Forms.Button
    Friend WithEvents btnMovieGeneralMediaListSortingUp As Windows.Forms.Button
    Friend WithEvents lvMovieGeneralMediaListSorting As Windows.Forms.ListView
    Friend WithEvents colMovieGeneralMediaListSortingDisplayIndex As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieGeneralMediaListSortingColumn As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieGeneralMediaListSortingLabel As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieGeneralMediaListSortingHide As Windows.Forms.ColumnHeader
    Friend WithEvents btnMovieGeneralMediaListSortingReset As Windows.Forms.Button
    Friend WithEvents gbMovieGeneralCustomMarker As Windows.Forms.GroupBox
    Friend WithEvents tblMovieGeneralCustomMarker As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieGeneralCustomMarker4 As Windows.Forms.Button
    Friend WithEvents lblMovieGeneralCustomMarker1 As Windows.Forms.Label
    Friend WithEvents btnMovieGeneralCustomMarker3 As Windows.Forms.Button
    Friend WithEvents txtMovieGeneralCustomMarker4 As Windows.Forms.TextBox
    Friend WithEvents btnMovieGeneralCustomMarker2 As Windows.Forms.Button
    Friend WithEvents lblMovieGeneralCustomMarker2 As Windows.Forms.Label
    Friend WithEvents btnMovieGeneralCustomMarker1 As Windows.Forms.Button
    Friend WithEvents lblMovieGeneralCustomMarker4 As Windows.Forms.Label
    Friend WithEvents txtMovieGeneralCustomMarker3 As Windows.Forms.TextBox
    Friend WithEvents lblMovieGeneralCustomMarker3 As Windows.Forms.Label
    Friend WithEvents txtMovieGeneralCustomMarker1 As Windows.Forms.TextBox
    Friend WithEvents txtMovieGeneralCustomMarker2 As Windows.Forms.TextBox
    Friend WithEvents lblMovieLanguageOverlay As Windows.Forms.Label
    Friend WithEvents cbMovieLanguageOverlay As Windows.Forms.ComboBox
    Friend WithEvents gbMovieGeneralCustomScrapeButton As Windows.Forms.GroupBox
    Friend WithEvents tblMovieGeneralCustomScrapeButton As Windows.Forms.TableLayoutPanel
    Friend WithEvents cbMovieGeneralCustomScrapeButtonScrapeType As Windows.Forms.ComboBox
    Friend WithEvents cbMovieGeneralCustomScrapeButtonModifierType As Windows.Forms.ComboBox
    Friend WithEvents txtMovieGeneralCustomScrapeButtonScrapeType As Windows.Forms.Label
    Friend WithEvents txtMovieGeneralCustomScrapeButtonModifierType As Windows.Forms.Label
    Friend WithEvents rbMovieGeneralCustomScrapeButtonEnabled As Windows.Forms.RadioButton
    Friend WithEvents rbMovieGeneralCustomScrapeButtonDisabled As Windows.Forms.RadioButton
    Friend WithEvents cdColor As Windows.Forms.ColorDialog
End Class
