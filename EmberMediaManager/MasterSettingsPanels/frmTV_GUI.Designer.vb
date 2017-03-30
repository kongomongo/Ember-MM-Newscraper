<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTV_GUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTV_GUI))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
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
        Me.cbTVLanguageOverlay = New System.Windows.Forms.ComboBox()
        Me.lblTVLanguageOverlay = New System.Windows.Forms.Label()
        Me.chkTVGeneralClickScrape = New System.Windows.Forms.CheckBox()
        Me.chkTVDisplayMissingEpisodes = New System.Windows.Forms.CheckBox()
        Me.chkTVGeneralClickScrapeAsk = New System.Windows.Forms.CheckBox()
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
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbTVGeneralCustomScrapeButton.SuspendLayout()
        Me.tblTVGeneralCustomScrapeButton.SuspendLayout()
        Me.gbTVGeneralMiscOpts.SuspendLayout()
        Me.tblTVGeneralMiscOpts.SuspendLayout()
        Me.gbTVGeneralShowListSortingOpts.SuspendLayout()
        Me.tblTVGeneralShowListSorting.SuspendLayout()
        Me.gbTVGeneralEpisodeListSorting.SuspendLayout()
        Me.tblTVGeneralEpisodeListSorting.SuspendLayout()
        Me.gbTVGeneralSeasonListSortingOpts.SuspendLayout()
        Me.tblTVGeneralSeasonListSorting.SuspendLayout()
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
        Me.pnlSettings.Size = New System.Drawing.Size(1050, 727)
        Me.pnlSettings.TabIndex = 21
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
        Me.tblSettings.Controls.Add(Me.gbTVGeneralCustomScrapeButton, 0, 1)
        Me.tblSettings.Controls.Add(Me.gbTVGeneralMiscOpts, 0, 0)
        Me.tblSettings.Controls.Add(Me.gbTVGeneralShowListSortingOpts, 0, 3)
        Me.tblSettings.Controls.Add(Me.gbTVGeneralEpisodeListSorting, 1, 5)
        Me.tblSettings.Controls.Add(Me.gbTVGeneralSeasonListSortingOpts, 1, 4)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 7
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.Size = New System.Drawing.Size(1050, 727)
        Me.tblSettings.TabIndex = 5
        '
        'gbTVGeneralCustomScrapeButton
        '
        Me.gbTVGeneralCustomScrapeButton.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.gbTVGeneralCustomScrapeButton, 2)
        Me.gbTVGeneralCustomScrapeButton.Controls.Add(Me.tblTVGeneralCustomScrapeButton)
        Me.gbTVGeneralCustomScrapeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralCustomScrapeButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTVGeneralCustomScrapeButton.Location = New System.Drawing.Point(3, 126)
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
        Me.tblSettings.SetColumnSpan(Me.gbTVGeneralMiscOpts, 2)
        Me.gbTVGeneralMiscOpts.Controls.Add(Me.tblTVGeneralMiscOpts)
        Me.gbTVGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbTVGeneralMiscOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbTVGeneralMiscOpts.Name = "gbTVGeneralMiscOpts"
        Me.gbTVGeneralMiscOpts.Size = New System.Drawing.Size(497, 117)
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
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.cbTVLanguageOverlay, 1, 0)
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.lblTVLanguageOverlay, 0, 0)
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.chkTVGeneralClickScrape, 0, 2)
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.chkTVDisplayMissingEpisodes, 0, 1)
        Me.tblTVGeneralMiscOpts.Controls.Add(Me.chkTVGeneralClickScrapeAsk, 0, 3)
        Me.tblTVGeneralMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTVGeneralMiscOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblTVGeneralMiscOpts.Name = "tblTVGeneralMiscOpts"
        Me.tblTVGeneralMiscOpts.RowCount = 5
        Me.tblTVGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTVGeneralMiscOpts.Size = New System.Drawing.Size(491, 96)
        Me.tblTVGeneralMiscOpts.TabIndex = 74
        '
        'cbTVLanguageOverlay
        '
        Me.cbTVLanguageOverlay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbTVLanguageOverlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTVLanguageOverlay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbTVLanguageOverlay.FormattingEnabled = True
        Me.cbTVLanguageOverlay.Location = New System.Drawing.Point(306, 3)
        Me.cbTVLanguageOverlay.Name = "cbTVLanguageOverlay"
        Me.cbTVLanguageOverlay.Size = New System.Drawing.Size(174, 21)
        Me.cbTVLanguageOverlay.Sorted = True
        Me.cbTVLanguageOverlay.TabIndex = 2
        '
        'lblTVLanguageOverlay
        '
        Me.lblTVLanguageOverlay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTVLanguageOverlay.AutoSize = True
        Me.lblTVLanguageOverlay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTVLanguageOverlay.Location = New System.Drawing.Point(3, 7)
        Me.lblTVLanguageOverlay.Name = "lblTVLanguageOverlay"
        Me.lblTVLanguageOverlay.Size = New System.Drawing.Size(297, 13)
        Me.lblTVLanguageOverlay.TabIndex = 1
        Me.lblTVLanguageOverlay.Text = "Display best Audio Stream with the following Language:"
        '
        'chkTVGeneralClickScrape
        '
        Me.chkTVGeneralClickScrape.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVGeneralClickScrape.AutoSize = True
        Me.chkTVGeneralClickScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkTVGeneralClickScrape.Location = New System.Drawing.Point(3, 53)
        Me.chkTVGeneralClickScrape.Name = "chkTVGeneralClickScrape"
        Me.chkTVGeneralClickScrape.Size = New System.Drawing.Size(125, 17)
        Me.chkTVGeneralClickScrape.TabIndex = 66
        Me.chkTVGeneralClickScrape.Text = "Enable Click Scrape"
        Me.chkTVGeneralClickScrape.UseVisualStyleBackColor = True
        '
        'chkTVDisplayMissingEpisodes
        '
        Me.chkTVDisplayMissingEpisodes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVDisplayMissingEpisodes.AutoSize = True
        Me.chkTVDisplayMissingEpisodes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTVDisplayMissingEpisodes.Location = New System.Drawing.Point(3, 30)
        Me.chkTVDisplayMissingEpisodes.Name = "chkTVDisplayMissingEpisodes"
        Me.chkTVDisplayMissingEpisodes.Size = New System.Drawing.Size(155, 17)
        Me.chkTVDisplayMissingEpisodes.TabIndex = 3
        Me.chkTVDisplayMissingEpisodes.Text = "Display Missing Episodes"
        Me.chkTVDisplayMissingEpisodes.UseVisualStyleBackColor = True
        '
        'chkTVGeneralClickScrapeAsk
        '
        Me.chkTVGeneralClickScrapeAsk.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkTVGeneralClickScrapeAsk.AutoSize = True
        Me.chkTVGeneralClickScrapeAsk.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkTVGeneralClickScrapeAsk.Location = New System.Drawing.Point(3, 76)
        Me.chkTVGeneralClickScrapeAsk.Name = "chkTVGeneralClickScrapeAsk"
        Me.chkTVGeneralClickScrapeAsk.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkTVGeneralClickScrapeAsk.Size = New System.Drawing.Size(147, 17)
        Me.chkTVGeneralClickScrapeAsk.TabIndex = 67
        Me.chkTVGeneralClickScrapeAsk.Text = "Ask On Click Scrape"
        Me.chkTVGeneralClickScrapeAsk.UseVisualStyleBackColor = True
        '
        'gbTVGeneralShowListSortingOpts
        '
        Me.gbTVGeneralShowListSortingOpts.AutoSize = True
        Me.gbTVGeneralShowListSortingOpts.Controls.Add(Me.tblTVGeneralShowListSorting)
        Me.gbTVGeneralShowListSortingOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralShowListSortingOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbTVGeneralShowListSortingOpts.Location = New System.Drawing.Point(3, 230)
        Me.gbTVGeneralShowListSortingOpts.Name = "gbTVGeneralShowListSortingOpts"
        Me.tblSettings.SetRowSpan(Me.gbTVGeneralShowListSortingOpts, 3)
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
        'gbTVGeneralEpisodeListSorting
        '
        Me.gbTVGeneralEpisodeListSorting.AutoSize = True
        Me.gbTVGeneralEpisodeListSorting.Controls.Add(Me.tblTVGeneralEpisodeListSorting)
        Me.gbTVGeneralEpisodeListSorting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTVGeneralEpisodeListSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbTVGeneralEpisodeListSorting.Location = New System.Drawing.Point(221, 417)
        Me.gbTVGeneralEpisodeListSorting.Name = "gbTVGeneralEpisodeListSorting"
        Me.gbTVGeneralEpisodeListSorting.Size = New System.Drawing.Size(279, 181)
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
        Me.tblTVGeneralEpisodeListSorting.Size = New System.Drawing.Size(273, 160)
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
        Me.gbTVGeneralSeasonListSortingOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbTVGeneralSeasonListSortingOpts.Location = New System.Drawing.Point(221, 230)
        Me.gbTVGeneralSeasonListSortingOpts.Name = "gbTVGeneralSeasonListSortingOpts"
        Me.gbTVGeneralSeasonListSortingOpts.Size = New System.Drawing.Size(279, 181)
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
        Me.tblTVGeneralSeasonListSorting.Size = New System.Drawing.Size(273, 160)
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
        'frmTV_GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 727)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmTV_GUI"
        Me.Text = "frmTV_GUI"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbTVGeneralCustomScrapeButton.ResumeLayout(False)
        Me.gbTVGeneralCustomScrapeButton.PerformLayout()
        Me.tblTVGeneralCustomScrapeButton.ResumeLayout(False)
        Me.tblTVGeneralCustomScrapeButton.PerformLayout()
        Me.gbTVGeneralMiscOpts.ResumeLayout(False)
        Me.gbTVGeneralMiscOpts.PerformLayout()
        Me.tblTVGeneralMiscOpts.ResumeLayout(False)
        Me.tblTVGeneralMiscOpts.PerformLayout()
        Me.gbTVGeneralShowListSortingOpts.ResumeLayout(False)
        Me.gbTVGeneralShowListSortingOpts.PerformLayout()
        Me.tblTVGeneralShowListSorting.ResumeLayout(False)
        Me.gbTVGeneralEpisodeListSorting.ResumeLayout(False)
        Me.gbTVGeneralEpisodeListSorting.PerformLayout()
        Me.tblTVGeneralEpisodeListSorting.ResumeLayout(False)
        Me.gbTVGeneralSeasonListSortingOpts.ResumeLayout(False)
        Me.gbTVGeneralSeasonListSortingOpts.PerformLayout()
        Me.tblTVGeneralSeasonListSorting.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbTVGeneralCustomScrapeButton As Windows.Forms.GroupBox
    Friend WithEvents tblTVGeneralCustomScrapeButton As Windows.Forms.TableLayoutPanel
    Friend WithEvents cbTVGeneralCustomScrapeButtonScrapeType As Windows.Forms.ComboBox
    Friend WithEvents cbTVGeneralCustomScrapeButtonModifierType As Windows.Forms.ComboBox
    Friend WithEvents txtTVGeneralCustomScrapeButtonScrapeType As Windows.Forms.Label
    Friend WithEvents txtTVGeneralCustomScrapeButtonModifierType As Windows.Forms.Label
    Friend WithEvents rbTVGeneralCustomScrapeButtonEnabled As Windows.Forms.RadioButton
    Friend WithEvents rbTVGeneralCustomScrapeButtonDisabled As Windows.Forms.RadioButton
    Friend WithEvents gbTVGeneralMiscOpts As Windows.Forms.GroupBox
    Friend WithEvents tblTVGeneralMiscOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkTVGeneralClickScrape As Windows.Forms.CheckBox
    Friend WithEvents chkTVGeneralClickScrapeAsk As Windows.Forms.CheckBox
    Friend WithEvents gbTVGeneralEpisodeListSorting As Windows.Forms.GroupBox
    Friend WithEvents tblTVGeneralEpisodeListSorting As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTVGeneralEpisodeListSortingDown As Windows.Forms.Button
    Friend WithEvents btnTVGeneralEpisodeListSortingUp As Windows.Forms.Button
    Friend WithEvents lvTVGeneralEpisodeListSorting As Windows.Forms.ListView
    Friend WithEvents colTVGeneralEpisodeListSortingDisplayIndex As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralEpisodeListSortingColumn As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralEpisodeListSortingLabel As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralEpisodeListSortingHide As Windows.Forms.ColumnHeader
    Friend WithEvents btnTVGeneralEpisodeListSortingReset As Windows.Forms.Button
    Friend WithEvents gbTVGeneralSeasonListSortingOpts As Windows.Forms.GroupBox
    Friend WithEvents tblTVGeneralSeasonListSorting As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTVGeneralSeasonListSortingDown As Windows.Forms.Button
    Friend WithEvents btnTVGeneralSeasonListSortingUp As Windows.Forms.Button
    Friend WithEvents lvTVGeneralSeasonListSorting As Windows.Forms.ListView
    Friend WithEvents colTVGeneralSeasonListSortingDisplayIndex As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralSeasonListSortingColumn As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralSeasonListSortingLabel As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralSeasonListSortingHide As Windows.Forms.ColumnHeader
    Friend WithEvents btnTVGeneralSeasonListSortingReset As Windows.Forms.Button
    Friend WithEvents gbTVGeneralShowListSortingOpts As Windows.Forms.GroupBox
    Friend WithEvents tblTVGeneralShowListSorting As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTVGeneralShowListSortingDown As Windows.Forms.Button
    Friend WithEvents btnTVGeneralShowListSortingUp As Windows.Forms.Button
    Friend WithEvents lvTVGeneralShowListSorting As Windows.Forms.ListView
    Friend WithEvents colTVGeneralShowListSortingDisplayIndex As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralShowListSortingColumn As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralShowListSortingLabel As Windows.Forms.ColumnHeader
    Friend WithEvents colTVGeneralShowListSortingHide As Windows.Forms.ColumnHeader
    Friend WithEvents btnTVGeneralShowListSortingReset As Windows.Forms.Button
    Friend WithEvents chkTVDisplayMissingEpisodes As Windows.Forms.CheckBox
    Friend WithEvents lblTVLanguageOverlay As Windows.Forms.Label
    Friend WithEvents cbTVLanguageOverlay As Windows.Forms.ComboBox
End Class
