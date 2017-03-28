<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption_FileSystem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOption_FileSystem))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbFileSystemValidVideoExts = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemValidVideoExts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemValidVideoExtsRemove = New System.Windows.Forms.Button()
        Me.btnFileSystemValidVideoExtsReset = New System.Windows.Forms.Button()
        Me.btnFileSystemValidVideoExtsAdd = New System.Windows.Forms.Button()
        Me.lstFileSystemValidVideoExts = New System.Windows.Forms.ListBox()
        Me.txtFileSystemValidVideoExts = New System.Windows.Forms.TextBox()
        Me.gbFileSystemNoStackExts = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemNoStackExts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemNoStackExtsRemove = New System.Windows.Forms.Button()
        Me.lstFileSystemNoStackExts = New System.Windows.Forms.ListBox()
        Me.btnFileSystemNoStackExtsAdd = New System.Windows.Forms.Button()
        Me.txtFileSystemNoStackExts = New System.Windows.Forms.TextBox()
        Me.gbFileSystemExcludedDirs = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemExcludedDirs = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemExcludedDirsRemove = New System.Windows.Forms.Button()
        Me.lstFileSystemExcludedDirs = New System.Windows.Forms.ListBox()
        Me.btnFileSystemExcludedDirsAdd = New System.Windows.Forms.Button()
        Me.txtFileSystemExcludedDirs = New System.Windows.Forms.TextBox()
        Me.gbFileSystemValidSubtitleExts = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemValidSubtitlesExts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemValidSubtitlesExtsRemove = New System.Windows.Forms.Button()
        Me.btnFileSystemValidSubtitlesExtsReset = New System.Windows.Forms.Button()
        Me.btnFileSystemValidSubtitlesExtsAdd = New System.Windows.Forms.Button()
        Me.lstFileSystemValidSubtitlesExts = New System.Windows.Forms.ListBox()
        Me.txtFileSystemValidSubtitlesExts = New System.Windows.Forms.TextBox()
        Me.gbFileSystemValidThemeExts = New System.Windows.Forms.GroupBox()
        Me.tblFileSystemValidThemeExts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFileSystemValidThemeExtsRemove = New System.Windows.Forms.Button()
        Me.btnFileSystemValidThemeExtsReset = New System.Windows.Forms.Button()
        Me.btnFileSystemValidThemeExtsAdd = New System.Windows.Forms.Button()
        Me.lstFileSystemValidThemeExts = New System.Windows.Forms.ListBox()
        Me.txtFileSystemValidThemeExts = New System.Windows.Forms.TextBox()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbFileSystemValidVideoExts.SuspendLayout()
        Me.tblFileSystemValidVideoExts.SuspendLayout()
        Me.gbFileSystemNoStackExts.SuspendLayout()
        Me.tblFileSystemNoStackExts.SuspendLayout()
        Me.gbFileSystemExcludedDirs.SuspendLayout()
        Me.tblFileSystemExcludedDirs.SuspendLayout()
        Me.gbFileSystemValidSubtitleExts.SuspendLayout()
        Me.tblFileSystemValidSubtitlesExts.SuspendLayout()
        Me.gbFileSystemValidThemeExts.SuspendLayout()
        Me.tblFileSystemValidThemeExts.SuspendLayout()
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
        Me.pnlSettings.Size = New System.Drawing.Size(558, 521)
        Me.pnlSettings.TabIndex = 18
        Me.pnlSettings.Visible = False
        '
        'tblSettings
        '
        Me.tblSettings.AutoScroll = True
        Me.tblSettings.AutoSize = True
        Me.tblSettings.ColumnCount = 4
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.Controls.Add(Me.gbFileSystemValidVideoExts, 0, 0)
        Me.tblSettings.Controls.Add(Me.gbFileSystemNoStackExts, 2, 0)
        Me.tblSettings.Controls.Add(Me.gbFileSystemExcludedDirs, 0, 3)
        Me.tblSettings.Controls.Add(Me.gbFileSystemValidSubtitleExts, 1, 0)
        Me.tblSettings.Controls.Add(Me.gbFileSystemValidThemeExts, 1, 2)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 5
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.Size = New System.Drawing.Size(558, 521)
        Me.tblSettings.TabIndex = 6
        '
        'gbFileSystemValidVideoExts
        '
        Me.gbFileSystemValidVideoExts.AutoSize = True
        Me.gbFileSystemValidVideoExts.Controls.Add(Me.tblFileSystemValidVideoExts)
        Me.gbFileSystemValidVideoExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemValidVideoExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemValidVideoExts.Location = New System.Drawing.Point(3, 3)
        Me.gbFileSystemValidVideoExts.Name = "gbFileSystemValidVideoExts"
        Me.tblSettings.SetRowSpan(Me.gbFileSystemValidVideoExts, 3)
        Me.gbFileSystemValidVideoExts.Size = New System.Drawing.Size(162, 346)
        Me.gbFileSystemValidVideoExts.TabIndex = 0
        Me.gbFileSystemValidVideoExts.TabStop = False
        Me.gbFileSystemValidVideoExts.Text = "Valid Video Extensions"
        '
        'tblFileSystemValidVideoExts
        '
        Me.tblFileSystemValidVideoExts.AutoSize = True
        Me.tblFileSystemValidVideoExts.ColumnCount = 4
        Me.tblFileSystemValidVideoExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidVideoExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidVideoExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidVideoExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.btnFileSystemValidVideoExtsRemove, 2, 2)
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.btnFileSystemValidVideoExtsReset, 2, 0)
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.btnFileSystemValidVideoExtsAdd, 1, 2)
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.lstFileSystemValidVideoExts, 0, 1)
        Me.tblFileSystemValidVideoExts.Controls.Add(Me.txtFileSystemValidVideoExts, 0, 2)
        Me.tblFileSystemValidVideoExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemValidVideoExts.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemValidVideoExts.Name = "tblFileSystemValidVideoExts"
        Me.tblFileSystemValidVideoExts.RowCount = 4
        Me.tblFileSystemValidVideoExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidVideoExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidVideoExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidVideoExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidVideoExts.Size = New System.Drawing.Size(156, 325)
        Me.tblFileSystemValidVideoExts.TabIndex = 7
        '
        'btnFileSystemValidVideoExtsRemove
        '
        Me.btnFileSystemValidVideoExtsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidVideoExtsRemove.Image = CType(resources.GetObject("btnFileSystemValidVideoExtsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemValidVideoExtsRemove.Location = New System.Drawing.Point(130, 298)
        Me.btnFileSystemValidVideoExtsRemove.Name = "btnFileSystemValidVideoExtsRemove"
        Me.btnFileSystemValidVideoExtsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidVideoExtsRemove.TabIndex = 3
        Me.btnFileSystemValidVideoExtsRemove.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidVideoExtsReset
        '
        Me.btnFileSystemValidVideoExtsReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidVideoExtsReset.Image = CType(resources.GetObject("btnFileSystemValidVideoExtsReset.Image"), System.Drawing.Image)
        Me.btnFileSystemValidVideoExtsReset.Location = New System.Drawing.Point(130, 3)
        Me.btnFileSystemValidVideoExtsReset.Name = "btnFileSystemValidVideoExtsReset"
        Me.btnFileSystemValidVideoExtsReset.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidVideoExtsReset.TabIndex = 4
        Me.btnFileSystemValidVideoExtsReset.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidVideoExtsAdd
        '
        Me.btnFileSystemValidVideoExtsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemValidVideoExtsAdd.Image = CType(resources.GetObject("btnFileSystemValidVideoExtsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemValidVideoExtsAdd.Location = New System.Drawing.Point(59, 298)
        Me.btnFileSystemValidVideoExtsAdd.Name = "btnFileSystemValidVideoExtsAdd"
        Me.btnFileSystemValidVideoExtsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidVideoExtsAdd.TabIndex = 2
        Me.btnFileSystemValidVideoExtsAdd.UseVisualStyleBackColor = True
        '
        'lstFileSystemValidVideoExts
        '
        Me.tblFileSystemValidVideoExts.SetColumnSpan(Me.lstFileSystemValidVideoExts, 3)
        Me.lstFileSystemValidVideoExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemValidVideoExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemValidVideoExts.FormattingEnabled = True
        Me.lstFileSystemValidVideoExts.Location = New System.Drawing.Point(3, 32)
        Me.lstFileSystemValidVideoExts.Name = "lstFileSystemValidVideoExts"
        Me.lstFileSystemValidVideoExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemValidVideoExts.Size = New System.Drawing.Size(150, 260)
        Me.lstFileSystemValidVideoExts.Sorted = True
        Me.lstFileSystemValidVideoExts.TabIndex = 0
        '
        'txtFileSystemValidVideoExts
        '
        Me.txtFileSystemValidVideoExts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemValidVideoExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemValidVideoExts.Location = New System.Drawing.Point(3, 298)
        Me.txtFileSystemValidVideoExts.Name = "txtFileSystemValidVideoExts"
        Me.txtFileSystemValidVideoExts.Size = New System.Drawing.Size(50, 22)
        Me.txtFileSystemValidVideoExts.TabIndex = 1
        '
        'gbFileSystemNoStackExts
        '
        Me.gbFileSystemNoStackExts.AutoSize = True
        Me.gbFileSystemNoStackExts.Controls.Add(Me.tblFileSystemNoStackExts)
        Me.gbFileSystemNoStackExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemNoStackExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemNoStackExts.Location = New System.Drawing.Point(339, 3)
        Me.gbFileSystemNoStackExts.Name = "gbFileSystemNoStackExts"
        Me.gbFileSystemNoStackExts.Size = New System.Drawing.Size(192, 125)
        Me.gbFileSystemNoStackExts.TabIndex = 1
        Me.gbFileSystemNoStackExts.TabStop = False
        Me.gbFileSystemNoStackExts.Text = "No Stack Extensions"
        '
        'tblFileSystemNoStackExts
        '
        Me.tblFileSystemNoStackExts.AutoSize = True
        Me.tblFileSystemNoStackExts.ColumnCount = 4
        Me.tblFileSystemNoStackExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemNoStackExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemNoStackExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemNoStackExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemNoStackExts.Controls.Add(Me.btnFileSystemNoStackExtsRemove, 2, 1)
        Me.tblFileSystemNoStackExts.Controls.Add(Me.lstFileSystemNoStackExts, 0, 0)
        Me.tblFileSystemNoStackExts.Controls.Add(Me.btnFileSystemNoStackExtsAdd, 1, 1)
        Me.tblFileSystemNoStackExts.Controls.Add(Me.txtFileSystemNoStackExts, 0, 1)
        Me.tblFileSystemNoStackExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemNoStackExts.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemNoStackExts.Name = "tblFileSystemNoStackExts"
        Me.tblFileSystemNoStackExts.RowCount = 3
        Me.tblFileSystemNoStackExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemNoStackExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemNoStackExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemNoStackExts.Size = New System.Drawing.Size(186, 104)
        Me.tblFileSystemNoStackExts.TabIndex = 9
        '
        'btnFileSystemNoStackExtsRemove
        '
        Me.btnFileSystemNoStackExtsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemNoStackExtsRemove.Image = CType(resources.GetObject("btnFileSystemNoStackExtsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemNoStackExtsRemove.Location = New System.Drawing.Point(160, 78)
        Me.btnFileSystemNoStackExtsRemove.Name = "btnFileSystemNoStackExtsRemove"
        Me.btnFileSystemNoStackExtsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemNoStackExtsRemove.TabIndex = 3
        Me.btnFileSystemNoStackExtsRemove.UseVisualStyleBackColor = True
        '
        'lstFileSystemNoStackExts
        '
        Me.tblFileSystemNoStackExts.SetColumnSpan(Me.lstFileSystemNoStackExts, 3)
        Me.lstFileSystemNoStackExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemNoStackExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemNoStackExts.FormattingEnabled = True
        Me.lstFileSystemNoStackExts.Location = New System.Drawing.Point(3, 3)
        Me.lstFileSystemNoStackExts.Name = "lstFileSystemNoStackExts"
        Me.lstFileSystemNoStackExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemNoStackExts.Size = New System.Drawing.Size(180, 69)
        Me.lstFileSystemNoStackExts.Sorted = True
        Me.lstFileSystemNoStackExts.TabIndex = 0
        '
        'btnFileSystemNoStackExtsAdd
        '
        Me.btnFileSystemNoStackExtsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemNoStackExtsAdd.Image = CType(resources.GetObject("btnFileSystemNoStackExtsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemNoStackExtsAdd.Location = New System.Drawing.Point(59, 78)
        Me.btnFileSystemNoStackExtsAdd.Name = "btnFileSystemNoStackExtsAdd"
        Me.btnFileSystemNoStackExtsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemNoStackExtsAdd.TabIndex = 2
        Me.btnFileSystemNoStackExtsAdd.UseVisualStyleBackColor = True
        '
        'txtFileSystemNoStackExts
        '
        Me.txtFileSystemNoStackExts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemNoStackExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemNoStackExts.Location = New System.Drawing.Point(3, 78)
        Me.txtFileSystemNoStackExts.Name = "txtFileSystemNoStackExts"
        Me.txtFileSystemNoStackExts.Size = New System.Drawing.Size(50, 22)
        Me.txtFileSystemNoStackExts.TabIndex = 1
        '
        'gbFileSystemExcludedDirs
        '
        Me.gbFileSystemExcludedDirs.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.gbFileSystemExcludedDirs, 3)
        Me.gbFileSystemExcludedDirs.Controls.Add(Me.tblFileSystemExcludedDirs)
        Me.gbFileSystemExcludedDirs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemExcludedDirs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbFileSystemExcludedDirs.Location = New System.Drawing.Point(3, 355)
        Me.gbFileSystemExcludedDirs.Name = "gbFileSystemExcludedDirs"
        Me.gbFileSystemExcludedDirs.Size = New System.Drawing.Size(528, 138)
        Me.gbFileSystemExcludedDirs.TabIndex = 4
        Me.gbFileSystemExcludedDirs.TabStop = False
        Me.gbFileSystemExcludedDirs.Text = "Excluded Directories"
        '
        'tblFileSystemExcludedDirs
        '
        Me.tblFileSystemExcludedDirs.AutoSize = True
        Me.tblFileSystemExcludedDirs.ColumnCount = 4
        Me.tblFileSystemExcludedDirs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemExcludedDirs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemExcludedDirs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemExcludedDirs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemExcludedDirs.Controls.Add(Me.btnFileSystemExcludedDirsRemove, 2, 1)
        Me.tblFileSystemExcludedDirs.Controls.Add(Me.lstFileSystemExcludedDirs, 0, 0)
        Me.tblFileSystemExcludedDirs.Controls.Add(Me.btnFileSystemExcludedDirsAdd, 1, 1)
        Me.tblFileSystemExcludedDirs.Controls.Add(Me.txtFileSystemExcludedDirs, 0, 1)
        Me.tblFileSystemExcludedDirs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemExcludedDirs.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemExcludedDirs.Name = "tblFileSystemExcludedDirs"
        Me.tblFileSystemExcludedDirs.RowCount = 3
        Me.tblFileSystemExcludedDirs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemExcludedDirs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemExcludedDirs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemExcludedDirs.Size = New System.Drawing.Size(522, 117)
        Me.tblFileSystemExcludedDirs.TabIndex = 7
        '
        'btnFileSystemExcludedDirsRemove
        '
        Me.btnFileSystemExcludedDirsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemExcludedDirsRemove.Image = CType(resources.GetObject("btnFileSystemExcludedDirsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemExcludedDirsRemove.Location = New System.Drawing.Point(490, 91)
        Me.btnFileSystemExcludedDirsRemove.Name = "btnFileSystemExcludedDirsRemove"
        Me.btnFileSystemExcludedDirsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemExcludedDirsRemove.TabIndex = 6
        Me.btnFileSystemExcludedDirsRemove.UseVisualStyleBackColor = True
        '
        'lstFileSystemExcludedDirs
        '
        Me.tblFileSystemExcludedDirs.SetColumnSpan(Me.lstFileSystemExcludedDirs, 3)
        Me.lstFileSystemExcludedDirs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemExcludedDirs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemExcludedDirs.FormattingEnabled = True
        Me.lstFileSystemExcludedDirs.Location = New System.Drawing.Point(3, 3)
        Me.lstFileSystemExcludedDirs.Name = "lstFileSystemExcludedDirs"
        Me.lstFileSystemExcludedDirs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemExcludedDirs.Size = New System.Drawing.Size(510, 82)
        Me.lstFileSystemExcludedDirs.Sorted = True
        Me.lstFileSystemExcludedDirs.TabIndex = 1
        '
        'btnFileSystemExcludedDirsAdd
        '
        Me.btnFileSystemExcludedDirsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemExcludedDirsAdd.Image = CType(resources.GetObject("btnFileSystemExcludedDirsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemExcludedDirsAdd.Location = New System.Drawing.Point(419, 91)
        Me.btnFileSystemExcludedDirsAdd.Name = "btnFileSystemExcludedDirsAdd"
        Me.btnFileSystemExcludedDirsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemExcludedDirsAdd.TabIndex = 5
        Me.btnFileSystemExcludedDirsAdd.UseVisualStyleBackColor = True
        '
        'txtFileSystemExcludedDirs
        '
        Me.txtFileSystemExcludedDirs.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemExcludedDirs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemExcludedDirs.Location = New System.Drawing.Point(3, 91)
        Me.txtFileSystemExcludedDirs.Name = "txtFileSystemExcludedDirs"
        Me.txtFileSystemExcludedDirs.Size = New System.Drawing.Size(410, 22)
        Me.txtFileSystemExcludedDirs.TabIndex = 4
        '
        'gbFileSystemValidSubtitlesExts
        '
        Me.gbFileSystemValidSubtitleExts.AutoSize = True
        Me.gbFileSystemValidSubtitleExts.Controls.Add(Me.tblFileSystemValidSubtitlesExts)
        Me.gbFileSystemValidSubtitleExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemValidSubtitleExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemValidSubtitleExts.Location = New System.Drawing.Point(171, 3)
        Me.gbFileSystemValidSubtitleExts.Name = "gbFileSystemValidSubtitlesExts"
        Me.tblSettings.SetRowSpan(Me.gbFileSystemValidSubtitleExts, 2)
        Me.gbFileSystemValidSubtitleExts.Size = New System.Drawing.Size(162, 170)
        Me.gbFileSystemValidSubtitleExts.TabIndex = 5
        Me.gbFileSystemValidSubtitleExts.TabStop = False
        Me.gbFileSystemValidSubtitleExts.Text = "Valid Subtitles Extensions"
        '
        'tblFileSystemValidSubtitlesExts
        '
        Me.tblFileSystemValidSubtitlesExts.AutoSize = True
        Me.tblFileSystemValidSubtitlesExts.ColumnCount = 4
        Me.tblFileSystemValidSubtitlesExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidSubtitlesExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidSubtitlesExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidSubtitlesExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.btnFileSystemValidSubtitlesExtsRemove, 2, 2)
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.btnFileSystemValidSubtitlesExtsReset, 2, 0)
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.btnFileSystemValidSubtitlesExtsAdd, 1, 2)
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.lstFileSystemValidSubtitlesExts, 0, 1)
        Me.tblFileSystemValidSubtitlesExts.Controls.Add(Me.txtFileSystemValidSubtitlesExts, 0, 2)
        Me.tblFileSystemValidSubtitlesExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemValidSubtitlesExts.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemValidSubtitlesExts.Name = "tblFileSystemValidSubtitlesExts"
        Me.tblFileSystemValidSubtitlesExts.RowCount = 4
        Me.tblFileSystemValidSubtitlesExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidSubtitlesExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidSubtitlesExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidSubtitlesExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidSubtitlesExts.Size = New System.Drawing.Size(156, 149)
        Me.tblFileSystemValidSubtitlesExts.TabIndex = 8
        '
        'btnFileSystemValidSubtitlesExtsRemove
        '
        Me.btnFileSystemValidSubtitlesExtsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidSubtitlesExtsRemove.Image = CType(resources.GetObject("btnFileSystemValidSubtitlesExtsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemValidSubtitlesExtsRemove.Location = New System.Drawing.Point(130, 123)
        Me.btnFileSystemValidSubtitlesExtsRemove.Name = "btnFileSystemValidSubtitlesExtsRemove"
        Me.btnFileSystemValidSubtitlesExtsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidSubtitlesExtsRemove.TabIndex = 3
        Me.btnFileSystemValidSubtitlesExtsRemove.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidSubtitlesExtsReset
        '
        Me.btnFileSystemValidSubtitlesExtsReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidSubtitlesExtsReset.Image = CType(resources.GetObject("btnFileSystemValidSubtitlesExtsReset.Image"), System.Drawing.Image)
        Me.btnFileSystemValidSubtitlesExtsReset.Location = New System.Drawing.Point(130, 3)
        Me.btnFileSystemValidSubtitlesExtsReset.Name = "btnFileSystemValidSubtitlesExtsReset"
        Me.btnFileSystemValidSubtitlesExtsReset.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidSubtitlesExtsReset.TabIndex = 5
        Me.btnFileSystemValidSubtitlesExtsReset.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidSubtitlesExtsAdd
        '
        Me.btnFileSystemValidSubtitlesExtsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemValidSubtitlesExtsAdd.Image = CType(resources.GetObject("btnFileSystemValidSubtitlesExtsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemValidSubtitlesExtsAdd.Location = New System.Drawing.Point(59, 123)
        Me.btnFileSystemValidSubtitlesExtsAdd.Name = "btnFileSystemValidSubtitlesExtsAdd"
        Me.btnFileSystemValidSubtitlesExtsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidSubtitlesExtsAdd.TabIndex = 2
        Me.btnFileSystemValidSubtitlesExtsAdd.UseVisualStyleBackColor = True
        '
        'lstFileSystemValidSubtitlesExts
        '
        Me.tblFileSystemValidSubtitlesExts.SetColumnSpan(Me.lstFileSystemValidSubtitlesExts, 3)
        Me.lstFileSystemValidSubtitlesExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemValidSubtitlesExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemValidSubtitlesExts.FormattingEnabled = True
        Me.lstFileSystemValidSubtitlesExts.Location = New System.Drawing.Point(3, 32)
        Me.lstFileSystemValidSubtitlesExts.Name = "lstFileSystemValidSubtitlesExts"
        Me.lstFileSystemValidSubtitlesExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemValidSubtitlesExts.Size = New System.Drawing.Size(150, 85)
        Me.lstFileSystemValidSubtitlesExts.Sorted = True
        Me.lstFileSystemValidSubtitlesExts.TabIndex = 0
        '
        'txtFileSystemValidSubtitlesExts
        '
        Me.txtFileSystemValidSubtitlesExts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemValidSubtitlesExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemValidSubtitlesExts.Location = New System.Drawing.Point(3, 123)
        Me.txtFileSystemValidSubtitlesExts.Name = "txtFileSystemValidSubtitlesExts"
        Me.txtFileSystemValidSubtitlesExts.Size = New System.Drawing.Size(50, 22)
        Me.txtFileSystemValidSubtitlesExts.TabIndex = 1
        '
        'gbFileSystemValidThemeExts
        '
        Me.gbFileSystemValidThemeExts.AutoSize = True
        Me.gbFileSystemValidThemeExts.Controls.Add(Me.tblFileSystemValidThemeExts)
        Me.gbFileSystemValidThemeExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFileSystemValidThemeExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbFileSystemValidThemeExts.Location = New System.Drawing.Point(171, 179)
        Me.gbFileSystemValidThemeExts.Name = "gbFileSystemValidThemeExts"
        Me.gbFileSystemValidThemeExts.Size = New System.Drawing.Size(162, 170)
        Me.gbFileSystemValidThemeExts.TabIndex = 3
        Me.gbFileSystemValidThemeExts.TabStop = False
        Me.gbFileSystemValidThemeExts.Text = "Valid Theme Extensions"
        '
        'tblFileSystemValidThemeExts
        '
        Me.tblFileSystemValidThemeExts.AutoSize = True
        Me.tblFileSystemValidThemeExts.ColumnCount = 4
        Me.tblFileSystemValidThemeExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidThemeExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidThemeExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidThemeExts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.btnFileSystemValidThemeExtsRemove, 2, 2)
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.btnFileSystemValidThemeExtsReset, 2, 0)
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.btnFileSystemValidThemeExtsAdd, 1, 2)
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.lstFileSystemValidThemeExts, 0, 1)
        Me.tblFileSystemValidThemeExts.Controls.Add(Me.txtFileSystemValidThemeExts, 0, 2)
        Me.tblFileSystemValidThemeExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFileSystemValidThemeExts.Location = New System.Drawing.Point(3, 18)
        Me.tblFileSystemValidThemeExts.Name = "tblFileSystemValidThemeExts"
        Me.tblFileSystemValidThemeExts.RowCount = 4
        Me.tblFileSystemValidThemeExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidThemeExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidThemeExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidThemeExts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFileSystemValidThemeExts.Size = New System.Drawing.Size(156, 149)
        Me.tblFileSystemValidThemeExts.TabIndex = 9
        '
        'btnFileSystemValidThemeExtsRemove
        '
        Me.btnFileSystemValidThemeExtsRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidThemeExtsRemove.Image = CType(resources.GetObject("btnFileSystemValidThemeExtsRemove.Image"), System.Drawing.Image)
        Me.btnFileSystemValidThemeExtsRemove.Location = New System.Drawing.Point(130, 123)
        Me.btnFileSystemValidThemeExtsRemove.Name = "btnFileSystemValidThemeExtsRemove"
        Me.btnFileSystemValidThemeExtsRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidThemeExtsRemove.TabIndex = 3
        Me.btnFileSystemValidThemeExtsRemove.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidThemeExtsReset
        '
        Me.btnFileSystemValidThemeExtsReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFileSystemValidThemeExtsReset.Image = CType(resources.GetObject("btnFileSystemValidThemeExtsReset.Image"), System.Drawing.Image)
        Me.btnFileSystemValidThemeExtsReset.Location = New System.Drawing.Point(130, 3)
        Me.btnFileSystemValidThemeExtsReset.Name = "btnFileSystemValidThemeExtsReset"
        Me.btnFileSystemValidThemeExtsReset.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidThemeExtsReset.TabIndex = 4
        Me.btnFileSystemValidThemeExtsReset.UseVisualStyleBackColor = True
        '
        'btnFileSystemValidThemeExtsAdd
        '
        Me.btnFileSystemValidThemeExtsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFileSystemValidThemeExtsAdd.Image = CType(resources.GetObject("btnFileSystemValidThemeExtsAdd.Image"), System.Drawing.Image)
        Me.btnFileSystemValidThemeExtsAdd.Location = New System.Drawing.Point(59, 123)
        Me.btnFileSystemValidThemeExtsAdd.Name = "btnFileSystemValidThemeExtsAdd"
        Me.btnFileSystemValidThemeExtsAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnFileSystemValidThemeExtsAdd.TabIndex = 2
        Me.btnFileSystemValidThemeExtsAdd.UseVisualStyleBackColor = True
        '
        'lstFileSystemValidThemeExts
        '
        Me.tblFileSystemValidThemeExts.SetColumnSpan(Me.lstFileSystemValidThemeExts, 3)
        Me.lstFileSystemValidThemeExts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileSystemValidThemeExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstFileSystemValidThemeExts.FormattingEnabled = True
        Me.lstFileSystemValidThemeExts.Location = New System.Drawing.Point(3, 32)
        Me.lstFileSystemValidThemeExts.Name = "lstFileSystemValidThemeExts"
        Me.lstFileSystemValidThemeExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileSystemValidThemeExts.Size = New System.Drawing.Size(150, 85)
        Me.lstFileSystemValidThemeExts.Sorted = True
        Me.lstFileSystemValidThemeExts.TabIndex = 0
        '
        'txtFileSystemValidThemeExts
        '
        Me.txtFileSystemValidThemeExts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFileSystemValidThemeExts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSystemValidThemeExts.Location = New System.Drawing.Point(3, 123)
        Me.txtFileSystemValidThemeExts.Name = "txtFileSystemValidThemeExts"
        Me.txtFileSystemValidThemeExts.Size = New System.Drawing.Size(50, 22)
        Me.txtFileSystemValidThemeExts.TabIndex = 1
        '
        'frmOption_FileSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 521)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmOption_FileSystem"
        Me.Text = "frmOption_FileSystem"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbFileSystemValidVideoExts.ResumeLayout(False)
        Me.gbFileSystemValidVideoExts.PerformLayout()
        Me.tblFileSystemValidVideoExts.ResumeLayout(False)
        Me.tblFileSystemValidVideoExts.PerformLayout()
        Me.gbFileSystemNoStackExts.ResumeLayout(False)
        Me.gbFileSystemNoStackExts.PerformLayout()
        Me.tblFileSystemNoStackExts.ResumeLayout(False)
        Me.tblFileSystemNoStackExts.PerformLayout()
        Me.gbFileSystemExcludedDirs.ResumeLayout(False)
        Me.gbFileSystemExcludedDirs.PerformLayout()
        Me.tblFileSystemExcludedDirs.ResumeLayout(False)
        Me.tblFileSystemExcludedDirs.PerformLayout()
        Me.gbFileSystemValidSubtitleExts.ResumeLayout(False)
        Me.gbFileSystemValidSubtitleExts.PerformLayout()
        Me.tblFileSystemValidSubtitlesExts.ResumeLayout(False)
        Me.tblFileSystemValidSubtitlesExts.PerformLayout()
        Me.gbFileSystemValidThemeExts.ResumeLayout(False)
        Me.gbFileSystemValidThemeExts.PerformLayout()
        Me.tblFileSystemValidThemeExts.ResumeLayout(False)
        Me.tblFileSystemValidThemeExts.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbFileSystemValidVideoExts As Windows.Forms.GroupBox
    Friend WithEvents tblFileSystemValidVideoExts As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFileSystemValidVideoExtsRemove As Windows.Forms.Button
    Friend WithEvents btnFileSystemValidVideoExtsReset As Windows.Forms.Button
    Friend WithEvents btnFileSystemValidVideoExtsAdd As Windows.Forms.Button
    Friend WithEvents lstFileSystemValidVideoExts As Windows.Forms.ListBox
    Friend WithEvents txtFileSystemValidVideoExts As Windows.Forms.TextBox
    Friend WithEvents gbFileSystemNoStackExts As Windows.Forms.GroupBox
    Friend WithEvents tblFileSystemNoStackExts As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFileSystemNoStackExtsRemove As Windows.Forms.Button
    Friend WithEvents lstFileSystemNoStackExts As Windows.Forms.ListBox
    Friend WithEvents btnFileSystemNoStackExtsAdd As Windows.Forms.Button
    Friend WithEvents txtFileSystemNoStackExts As Windows.Forms.TextBox
    Friend WithEvents gbFileSystemExcludedDirs As Windows.Forms.GroupBox
    Friend WithEvents tblFileSystemExcludedDirs As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFileSystemExcludedDirsRemove As Windows.Forms.Button
    Friend WithEvents lstFileSystemExcludedDirs As Windows.Forms.ListBox
    Friend WithEvents btnFileSystemExcludedDirsAdd As Windows.Forms.Button
    Friend WithEvents txtFileSystemExcludedDirs As Windows.Forms.TextBox
    Friend WithEvents gbFileSystemValidSubtitleExts As Windows.Forms.GroupBox
    Friend WithEvents tblFileSystemValidSubtitlesExts As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFileSystemValidSubtitlesExtsRemove As Windows.Forms.Button
    Friend WithEvents btnFileSystemValidSubtitlesExtsReset As Windows.Forms.Button
    Friend WithEvents btnFileSystemValidSubtitlesExtsAdd As Windows.Forms.Button
    Friend WithEvents lstFileSystemValidSubtitlesExts As Windows.Forms.ListBox
    Friend WithEvents txtFileSystemValidSubtitlesExts As Windows.Forms.TextBox
    Friend WithEvents gbFileSystemValidThemeExts As Windows.Forms.GroupBox
    Friend WithEvents tblFileSystemValidThemeExts As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFileSystemValidThemeExtsRemove As Windows.Forms.Button
    Friend WithEvents btnFileSystemValidThemeExtsReset As Windows.Forms.Button
    Friend WithEvents btnFileSystemValidThemeExtsAdd As Windows.Forms.Button
    Friend WithEvents lstFileSystemValidThemeExts As Windows.Forms.ListBox
    Friend WithEvents txtFileSystemValidThemeExts As Windows.Forms.TextBox
End Class
