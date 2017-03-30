<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovieSet_GUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovieSet_GUI))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSetGeneralCustomScrapeButton = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetGeneralCustomScrapeButton = New System.Windows.Forms.TableLayoutPanel()
        Me.cbMovieSetGeneralCustomScrapeButtonScrapeType = New System.Windows.Forms.ComboBox()
        Me.cbMovieSetGeneralCustomScrapeButtonModifierType = New System.Windows.Forms.ComboBox()
        Me.txtMovieSetGeneralCustomScrapeButtonScrapeType = New System.Windows.Forms.Label()
        Me.txtMovieSetGeneralCustomScrapeButtonModifierType = New System.Windows.Forms.Label()
        Me.rbMovieSetGeneralCustomScrapeButtonEnabled = New System.Windows.Forms.RadioButton()
        Me.rbMovieSetGeneralCustomScrapeButtonDisabled = New System.Windows.Forms.RadioButton()
        Me.gbMovieSetGeneralMiscOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSetGeneralMiscOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieSetClickScrapeAsk = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetClickScrape = New System.Windows.Forms.CheckBox()
        Me.chkMovieSetGeneralMarkNew = New System.Windows.Forms.CheckBox()
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
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieSetGeneralCustomScrapeButton.SuspendLayout()
        Me.tblMovieSetGeneralCustomScrapeButton.SuspendLayout()
        Me.gbMovieSetGeneralMiscOpts.SuspendLayout()
        Me.tblMovieSetGeneralMiscOpts.SuspendLayout()
        Me.gbMovieSetGeneralMediaListSorting.SuspendLayout()
        Me.tblMovieSetGeneralMediaListSorting.SuspendLayout()
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
        Me.pnlSettings.Size = New System.Drawing.Size(651, 584)
        Me.pnlSettings.TabIndex = 25
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
        Me.tblSettings.Controls.Add(Me.gbMovieSetGeneralCustomScrapeButton, 0, 1)
        Me.tblSettings.Controls.Add(Me.gbMovieSetGeneralMiscOpts, 0, 0)
        Me.tblSettings.Controls.Add(Me.gbMovieSetGeneralMediaListSorting, 0, 2)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 5
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.Size = New System.Drawing.Size(651, 584)
        Me.tblSettings.TabIndex = 6
        '
        'gbMovieSetGeneralCustomScrapeButton
        '
        Me.gbMovieSetGeneralCustomScrapeButton.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.gbMovieSetGeneralCustomScrapeButton, 2)
        Me.gbMovieSetGeneralCustomScrapeButton.Controls.Add(Me.tblMovieSetGeneralCustomScrapeButton)
        Me.gbMovieSetGeneralCustomScrapeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetGeneralCustomScrapeButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovieSetGeneralCustomScrapeButton.Location = New System.Drawing.Point(3, 99)
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
        'gbMovieSetGeneralMiscOpts
        '
        Me.gbMovieSetGeneralMiscOpts.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.gbMovieSetGeneralMiscOpts, 2)
        Me.gbMovieSetGeneralMiscOpts.Controls.Add(Me.tblMovieSetGeneralMiscOpts)
        Me.gbMovieSetGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetGeneralMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieSetGeneralMiscOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieSetGeneralMiscOpts.Name = "gbMovieSetGeneralMiscOpts"
        Me.gbMovieSetGeneralMiscOpts.Size = New System.Drawing.Size(497, 90)
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
        Me.tblMovieSetGeneralMiscOpts.Size = New System.Drawing.Size(491, 69)
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
        'gbMovieSetGeneralMediaListSorting
        '
        Me.gbMovieSetGeneralMediaListSorting.AutoSize = True
        Me.gbMovieSetGeneralMediaListSorting.Controls.Add(Me.tblMovieSetGeneralMediaListSorting)
        Me.gbMovieSetGeneralMediaListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSetGeneralMediaListSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbMovieSetGeneralMediaListSorting.Location = New System.Drawing.Point(3, 203)
        Me.gbMovieSetGeneralMediaListSorting.Name = "gbMovieSetGeneralMediaListSorting"
        Me.tblSettings.SetRowSpan(Me.gbMovieSetGeneralMediaListSorting, 2)
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
        'frmMovieSet_GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 584)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovieSet_GUI"
        Me.Text = "frmMovieSet_GUI"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieSetGeneralCustomScrapeButton.ResumeLayout(False)
        Me.gbMovieSetGeneralCustomScrapeButton.PerformLayout()
        Me.tblMovieSetGeneralCustomScrapeButton.ResumeLayout(False)
        Me.tblMovieSetGeneralCustomScrapeButton.PerformLayout()
        Me.gbMovieSetGeneralMiscOpts.ResumeLayout(False)
        Me.gbMovieSetGeneralMiscOpts.PerformLayout()
        Me.tblMovieSetGeneralMiscOpts.ResumeLayout(False)
        Me.tblMovieSetGeneralMiscOpts.PerformLayout()
        Me.gbMovieSetGeneralMediaListSorting.ResumeLayout(False)
        Me.gbMovieSetGeneralMediaListSorting.PerformLayout()
        Me.tblMovieSetGeneralMediaListSorting.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieSetGeneralCustomScrapeButton As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetGeneralCustomScrapeButton As Windows.Forms.TableLayoutPanel
    Friend WithEvents cbMovieSetGeneralCustomScrapeButtonScrapeType As Windows.Forms.ComboBox
    Friend WithEvents cbMovieSetGeneralCustomScrapeButtonModifierType As Windows.Forms.ComboBox
    Friend WithEvents txtMovieSetGeneralCustomScrapeButtonScrapeType As Windows.Forms.Label
    Friend WithEvents txtMovieSetGeneralCustomScrapeButtonModifierType As Windows.Forms.Label
    Friend WithEvents rbMovieSetGeneralCustomScrapeButtonEnabled As Windows.Forms.RadioButton
    Friend WithEvents rbMovieSetGeneralCustomScrapeButtonDisabled As Windows.Forms.RadioButton
    Friend WithEvents gbMovieSetGeneralMediaListSorting As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetGeneralMediaListSorting As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieSetGeneralMediaListSortingDown As Windows.Forms.Button
    Friend WithEvents btnMovieSetGeneralMediaListSortingUp As Windows.Forms.Button
    Friend WithEvents lvMovieSetGeneralMediaListSorting As Windows.Forms.ListView
    Friend WithEvents colMovieSetGeneralMediaListSortingDisplayIndex As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSetGeneralMediaListSortingColumn As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSetGeneralMediaListSortingLabel As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSetGeneralMediaListSortingHide As Windows.Forms.ColumnHeader
    Friend WithEvents btnMovieSetGeneralMediaListSortingReset As Windows.Forms.Button
    Friend WithEvents gbMovieSetGeneralMiscOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSetGeneralMiscOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieSetClickScrapeAsk As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetClickScrape As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSetGeneralMarkNew As Windows.Forms.CheckBox
End Class
