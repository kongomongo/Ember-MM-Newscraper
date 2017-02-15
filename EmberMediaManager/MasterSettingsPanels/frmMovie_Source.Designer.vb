<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovie_Source
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovie_Source))
        Me.chkMovieGeneralMarkNew = New System.Windows.Forms.CheckBox()
        Me.gbMovieGeneralFiltersOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieGeneralFiltersOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMovieFilterRemove = New System.Windows.Forms.Button()
        Me.btnMovieFilterDown = New System.Windows.Forms.Button()
        Me.btnMovieFilterUp = New System.Windows.Forms.Button()
        Me.chkMovieProperCase = New System.Windows.Forms.CheckBox()
        Me.lstMovieFilters = New System.Windows.Forms.ListBox()
        Me.btnMovieFilterAdd = New System.Windows.Forms.Button()
        Me.txtMovieFilter = New System.Windows.Forms.TextBox()
        Me.btnMovieFilterReset = New System.Windows.Forms.Button()
        Me.chkMovieLevTolerance = New System.Windows.Forms.CheckBox()
        Me.lblMovieLevTolerance = New System.Windows.Forms.Label()
        Me.txtMovieLevTolerance = New System.Windows.Forms.TextBox()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieSourcesMiscOpts = New System.Windows.Forms.GroupBox()
        Me.tblMovieSourcesMiscOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieCleanDB = New System.Windows.Forms.CheckBox()
        Me.chkMovieScanOrderModify = New System.Windows.Forms.CheckBox()
        Me.lblMovieSkipLessThan = New System.Windows.Forms.Label()
        Me.chkMovieGeneralIgnoreLastScan = New System.Windows.Forms.CheckBox()
        Me.chkMovieSortBeforeScan = New System.Windows.Forms.CheckBox()
        Me.txtMovieSkipLessThan = New System.Windows.Forms.TextBox()
        Me.lblMovieSkipLessThanMB = New System.Windows.Forms.Label()
        Me.chkMovieSkipStackedSizeCheck = New System.Windows.Forms.CheckBox()
        Me.gbSources = New System.Windows.Forms.GroupBox()
        Me.tblMovieSourcesDefaultsOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.lvMovieSources = New System.Windows.Forms.ListView()
        Me.colMovieSourcesID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSourcesName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSourcesPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSourcesLanguage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSourcesRecur = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSourcesFolder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSourcesSingle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSourcesExclude = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovieSourcesGetYear = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnMovieSourceRemove = New System.Windows.Forms.Button()
        Me.btnMovieSourceEdit = New System.Windows.Forms.Button()
        Me.btnMovieSourceAdd = New System.Windows.Forms.Button()
        Me.lblMovieSourcesDefaultsLanguage = New System.Windows.Forms.Label()
        Me.cbMovieGeneralLang = New System.Windows.Forms.ComboBox()
        Me.gbMovieGeneralFiltersOpts.SuspendLayout()
        Me.tblMovieGeneralFiltersOpts.SuspendLayout()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieSourcesMiscOpts.SuspendLayout()
        Me.tblMovieSourcesMiscOpts.SuspendLayout()
        Me.gbSources.SuspendLayout()
        Me.tblMovieSourcesDefaultsOpts.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkMovieGeneralMarkNew
        '
        Me.chkMovieGeneralMarkNew.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieGeneralMarkNew.AutoSize = True
        Me.chkMovieGeneralMarkNew.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieGeneralMarkNew.Location = New System.Drawing.Point(3, 146)
        Me.chkMovieGeneralMarkNew.Name = "chkMovieGeneralMarkNew"
        Me.chkMovieGeneralMarkNew.Size = New System.Drawing.Size(117, 17)
        Me.chkMovieGeneralMarkNew.TabIndex = 1
        Me.chkMovieGeneralMarkNew.Text = "Mark New Movies"
        Me.chkMovieGeneralMarkNew.UseVisualStyleBackColor = True
        '
        'gbMovieGeneralFiltersOpts
        '
        Me.gbMovieGeneralFiltersOpts.AutoSize = True
        Me.gbMovieGeneralFiltersOpts.Controls.Add(Me.tblMovieGeneralFiltersOpts)
        Me.gbMovieGeneralFiltersOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieGeneralFiltersOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieGeneralFiltersOpts.Location = New System.Drawing.Point(3, 213)
        Me.gbMovieGeneralFiltersOpts.Name = "gbMovieGeneralFiltersOpts"
        Me.gbMovieGeneralFiltersOpts.Size = New System.Drawing.Size(232, 215)
        Me.gbMovieGeneralFiltersOpts.TabIndex = 7
        Me.gbMovieGeneralFiltersOpts.TabStop = False
        Me.gbMovieGeneralFiltersOpts.Text = "Folder/File Name Filters"
        '
        'tblMovieGeneralFiltersOpts
        '
        Me.tblMovieGeneralFiltersOpts.AutoSize = True
        Me.tblMovieGeneralFiltersOpts.ColumnCount = 6
        Me.tblMovieGeneralFiltersOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralFiltersOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralFiltersOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralFiltersOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralFiltersOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralFiltersOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieGeneralFiltersOpts.Controls.Add(Me.btnMovieFilterRemove, 4, 2)
        Me.tblMovieGeneralFiltersOpts.Controls.Add(Me.btnMovieFilterDown, 3, 2)
        Me.tblMovieGeneralFiltersOpts.Controls.Add(Me.btnMovieFilterUp, 2, 2)
        Me.tblMovieGeneralFiltersOpts.Controls.Add(Me.chkMovieProperCase, 0, 0)
        Me.tblMovieGeneralFiltersOpts.Controls.Add(Me.lstMovieFilters, 0, 1)
        Me.tblMovieGeneralFiltersOpts.Controls.Add(Me.btnMovieFilterAdd, 1, 2)
        Me.tblMovieGeneralFiltersOpts.Controls.Add(Me.txtMovieFilter, 0, 2)
        Me.tblMovieGeneralFiltersOpts.Controls.Add(Me.btnMovieFilterReset, 4, 0)
        Me.tblMovieGeneralFiltersOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieGeneralFiltersOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieGeneralFiltersOpts.Name = "tblMovieGeneralFiltersOpts"
        Me.tblMovieGeneralFiltersOpts.RowCount = 4
        Me.tblMovieGeneralFiltersOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralFiltersOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralFiltersOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralFiltersOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieGeneralFiltersOpts.Size = New System.Drawing.Size(226, 194)
        Me.tblMovieGeneralFiltersOpts.TabIndex = 10
        '
        'btnMovieFilterRemove
        '
        Me.btnMovieFilterRemove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieFilterRemove.Image = CType(resources.GetObject("btnMovieFilterRemove.Image"), System.Drawing.Image)
        Me.btnMovieFilterRemove.Location = New System.Drawing.Point(200, 158)
        Me.btnMovieFilterRemove.Name = "btnMovieFilterRemove"
        Me.btnMovieFilterRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieFilterRemove.TabIndex = 6
        Me.btnMovieFilterRemove.UseVisualStyleBackColor = True
        '
        'btnMovieFilterDown
        '
        Me.btnMovieFilterDown.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieFilterDown.Image = CType(resources.GetObject("btnMovieFilterDown.Image"), System.Drawing.Image)
        Me.btnMovieFilterDown.Location = New System.Drawing.Point(171, 158)
        Me.btnMovieFilterDown.Name = "btnMovieFilterDown"
        Me.btnMovieFilterDown.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieFilterDown.TabIndex = 5
        Me.btnMovieFilterDown.UseVisualStyleBackColor = True
        '
        'btnMovieFilterUp
        '
        Me.btnMovieFilterUp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieFilterUp.Image = CType(resources.GetObject("btnMovieFilterUp.Image"), System.Drawing.Image)
        Me.btnMovieFilterUp.Location = New System.Drawing.Point(142, 158)
        Me.btnMovieFilterUp.Name = "btnMovieFilterUp"
        Me.btnMovieFilterUp.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieFilterUp.TabIndex = 4
        Me.btnMovieFilterUp.UseVisualStyleBackColor = True
        '
        'chkMovieProperCase
        '
        Me.chkMovieProperCase.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieProperCase.AutoSize = True
        Me.tblMovieGeneralFiltersOpts.SetColumnSpan(Me.chkMovieProperCase, 4)
        Me.chkMovieProperCase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieProperCase.Location = New System.Drawing.Point(3, 6)
        Me.chkMovieProperCase.Name = "chkMovieProperCase"
        Me.chkMovieProperCase.Size = New System.Drawing.Size(181, 17)
        Me.chkMovieProperCase.TabIndex = 0
        Me.chkMovieProperCase.Text = "Convert Names to Proper Case"
        Me.chkMovieProperCase.UseVisualStyleBackColor = True
        '
        'lstMovieFilters
        '
        Me.tblMovieGeneralFiltersOpts.SetColumnSpan(Me.lstMovieFilters, 5)
        Me.lstMovieFilters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMovieFilters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lstMovieFilters.FormattingEnabled = True
        Me.lstMovieFilters.Location = New System.Drawing.Point(3, 32)
        Me.lstMovieFilters.Name = "lstMovieFilters"
        Me.lstMovieFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstMovieFilters.Size = New System.Drawing.Size(220, 120)
        Me.lstMovieFilters.TabIndex = 1
        '
        'btnMovieFilterAdd
        '
        Me.btnMovieFilterAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMovieFilterAdd.Image = CType(resources.GetObject("btnMovieFilterAdd.Image"), System.Drawing.Image)
        Me.btnMovieFilterAdd.Location = New System.Drawing.Point(113, 158)
        Me.btnMovieFilterAdd.Name = "btnMovieFilterAdd"
        Me.btnMovieFilterAdd.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieFilterAdd.TabIndex = 3
        Me.btnMovieFilterAdd.UseVisualStyleBackColor = True
        '
        'txtMovieFilter
        '
        Me.txtMovieFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieFilter.Location = New System.Drawing.Point(3, 158)
        Me.txtMovieFilter.Name = "txtMovieFilter"
        Me.txtMovieFilter.Size = New System.Drawing.Size(104, 22)
        Me.txtMovieFilter.TabIndex = 2
        '
        'btnMovieFilterReset
        '
        Me.btnMovieFilterReset.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnMovieFilterReset.Image = CType(resources.GetObject("btnMovieFilterReset.Image"), System.Drawing.Image)
        Me.btnMovieFilterReset.Location = New System.Drawing.Point(200, 3)
        Me.btnMovieFilterReset.Name = "btnMovieFilterReset"
        Me.btnMovieFilterReset.Size = New System.Drawing.Size(23, 23)
        Me.btnMovieFilterReset.TabIndex = 8
        Me.btnMovieFilterReset.UseVisualStyleBackColor = True
        '
        'chkMovieLevTolerance
        '
        Me.chkMovieLevTolerance.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieLevTolerance.AutoSize = True
        Me.chkMovieLevTolerance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieLevTolerance.Location = New System.Drawing.Point(3, 171)
        Me.chkMovieLevTolerance.Name = "chkMovieLevTolerance"
        Me.chkMovieLevTolerance.Size = New System.Drawing.Size(178, 17)
        Me.chkMovieLevTolerance.TabIndex = 75
        Me.chkMovieLevTolerance.Text = "Check Title Match Confidence"
        Me.chkMovieLevTolerance.UseVisualStyleBackColor = True
        '
        'lblMovieLevTolerance
        '
        Me.lblMovieLevTolerance.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMovieLevTolerance.AutoSize = True
        Me.lblMovieLevTolerance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieLevTolerance.Location = New System.Drawing.Point(502, 388)
        Me.lblMovieLevTolerance.Name = "lblMovieLevTolerance"
        Me.lblMovieLevTolerance.Size = New System.Drawing.Size(110, 13)
        Me.lblMovieLevTolerance.TabIndex = 76
        Me.lblMovieLevTolerance.Text = "Mismatch Tolerance:"
        Me.lblMovieLevTolerance.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtMovieLevTolerance
        '
        Me.txtMovieLevTolerance.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieLevTolerance.Enabled = False
        Me.txtMovieLevTolerance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieLevTolerance.Location = New System.Drawing.Point(187, 169)
        Me.txtMovieLevTolerance.Name = "txtMovieLevTolerance"
        Me.txtMovieLevTolerance.Size = New System.Drawing.Size(50, 22)
        Me.txtMovieLevTolerance.TabIndex = 77
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.BackColor = System.Drawing.Color.White
        Me.pnlSettings.Controls.Add(Me.tblSettings)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(870, 459)
        Me.pnlSettings.TabIndex = 78
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
        Me.tblSettings.Controls.Add(Me.gbMovieGeneralFiltersOpts, 0, 1)
        Me.tblSettings.Controls.Add(Me.gbMovieSourcesMiscOpts, 1, 1)
        Me.tblSettings.Controls.Add(Me.gbSources, 0, 0)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 3
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblSettings.Size = New System.Drawing.Size(870, 459)
        Me.tblSettings.TabIndex = 9
        '
        'gbMovieSourcesMiscOpts
        '
        Me.gbMovieSourcesMiscOpts.AutoSize = True
        Me.gbMovieSourcesMiscOpts.Controls.Add(Me.tblMovieSourcesMiscOpts)
        Me.gbMovieSourcesMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieSourcesMiscOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbMovieSourcesMiscOpts.Location = New System.Drawing.Point(241, 213)
        Me.gbMovieSourcesMiscOpts.Name = "gbMovieSourcesMiscOpts"
        Me.gbMovieSourcesMiscOpts.Size = New System.Drawing.Size(605, 215)
        Me.gbMovieSourcesMiscOpts.TabIndex = 4
        Me.gbMovieSourcesMiscOpts.TabStop = False
        Me.gbMovieSourcesMiscOpts.Text = "Miscellaneous Options"
        '
        'tblMovieSourcesMiscOpts
        '
        Me.tblMovieSourcesMiscOpts.AutoSize = True
        Me.tblMovieSourcesMiscOpts.ColumnCount = 4
        Me.tblMovieSourcesMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSourcesMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSourcesMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSourcesMiscOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.chkMovieCleanDB, 0, 5)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.txtMovieLevTolerance, 1, 7)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.chkMovieLevTolerance, 0, 7)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.chkMovieScanOrderModify, 0, 4)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.lblMovieSkipLessThan, 0, 0)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.chkMovieGeneralIgnoreLastScan, 0, 3)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.chkMovieSortBeforeScan, 0, 2)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.txtMovieSkipLessThan, 1, 0)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.chkMovieGeneralMarkNew, 0, 6)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.lblMovieSkipLessThanMB, 2, 0)
        Me.tblMovieSourcesMiscOpts.Controls.Add(Me.chkMovieSkipStackedSizeCheck, 0, 1)
        Me.tblMovieSourcesMiscOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSourcesMiscOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSourcesMiscOpts.Name = "tblMovieSourcesMiscOpts"
        Me.tblMovieSourcesMiscOpts.RowCount = 9
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesMiscOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieSourcesMiscOpts.Size = New System.Drawing.Size(599, 194)
        Me.tblMovieSourcesMiscOpts.TabIndex = 9
        '
        'chkMovieCleanDB
        '
        Me.chkMovieCleanDB.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieCleanDB.AutoSize = True
        Me.tblMovieSourcesMiscOpts.SetColumnSpan(Me.chkMovieCleanDB, 3)
        Me.chkMovieCleanDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieCleanDB.Location = New System.Drawing.Point(3, 123)
        Me.chkMovieCleanDB.Name = "chkMovieCleanDB"
        Me.chkMovieCleanDB.Size = New System.Drawing.Size(218, 17)
        Me.chkMovieCleanDB.TabIndex = 9
        Me.chkMovieCleanDB.Text = "Clean database after updating library"
        Me.chkMovieCleanDB.UseVisualStyleBackColor = True
        '
        'chkMovieScanOrderModify
        '
        Me.chkMovieScanOrderModify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieScanOrderModify.AutoSize = True
        Me.tblMovieSourcesMiscOpts.SetColumnSpan(Me.chkMovieScanOrderModify, 3)
        Me.chkMovieScanOrderModify.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieScanOrderModify.Location = New System.Drawing.Point(3, 100)
        Me.chkMovieScanOrderModify.Name = "chkMovieScanOrderModify"
        Me.chkMovieScanOrderModify.Size = New System.Drawing.Size(186, 17)
        Me.chkMovieScanOrderModify.TabIndex = 8
        Me.chkMovieScanOrderModify.Text = "Scan in order of last write time."
        Me.chkMovieScanOrderModify.UseVisualStyleBackColor = True
        '
        'lblMovieSkipLessThan
        '
        Me.lblMovieSkipLessThan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSkipLessThan.AutoSize = True
        Me.lblMovieSkipLessThan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSkipLessThan.Location = New System.Drawing.Point(3, 7)
        Me.lblMovieSkipLessThan.Name = "lblMovieSkipLessThan"
        Me.lblMovieSkipLessThan.Size = New System.Drawing.Size(122, 13)
        Me.lblMovieSkipLessThan.TabIndex = 0
        Me.lblMovieSkipLessThan.Text = "Skip files smaller than:"
        '
        'chkMovieGeneralIgnoreLastScan
        '
        Me.chkMovieGeneralIgnoreLastScan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieGeneralIgnoreLastScan.AutoSize = True
        Me.tblMovieSourcesMiscOpts.SetColumnSpan(Me.chkMovieGeneralIgnoreLastScan, 3)
        Me.chkMovieGeneralIgnoreLastScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieGeneralIgnoreLastScan.Location = New System.Drawing.Point(3, 77)
        Me.chkMovieGeneralIgnoreLastScan.Name = "chkMovieGeneralIgnoreLastScan"
        Me.chkMovieGeneralIgnoreLastScan.Size = New System.Drawing.Size(254, 17)
        Me.chkMovieGeneralIgnoreLastScan.TabIndex = 7
        Me.chkMovieGeneralIgnoreLastScan.Text = "Always scan all media when updating library"
        Me.chkMovieGeneralIgnoreLastScan.UseVisualStyleBackColor = True
        '
        'chkMovieSortBeforeScan
        '
        Me.chkMovieSortBeforeScan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSortBeforeScan.AutoSize = True
        Me.tblMovieSourcesMiscOpts.SetColumnSpan(Me.chkMovieSortBeforeScan, 3)
        Me.chkMovieSortBeforeScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSortBeforeScan.Location = New System.Drawing.Point(3, 54)
        Me.chkMovieSortBeforeScan.Name = "chkMovieSortBeforeScan"
        Me.chkMovieSortBeforeScan.Size = New System.Drawing.Size(273, 17)
        Me.chkMovieSortBeforeScan.TabIndex = 6
        Me.chkMovieSortBeforeScan.Text = "Sort files into folders before each library update"
        Me.chkMovieSortBeforeScan.UseVisualStyleBackColor = True
        '
        'txtMovieSkipLessThan
        '
        Me.txtMovieSkipLessThan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMovieSkipLessThan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovieSkipLessThan.Location = New System.Drawing.Point(187, 3)
        Me.txtMovieSkipLessThan.Name = "txtMovieSkipLessThan"
        Me.txtMovieSkipLessThan.Size = New System.Drawing.Size(50, 22)
        Me.txtMovieSkipLessThan.TabIndex = 1
        '
        'lblMovieSkipLessThanMB
        '
        Me.lblMovieSkipLessThanMB.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSkipLessThanMB.AutoSize = True
        Me.lblMovieSkipLessThanMB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovieSkipLessThanMB.Location = New System.Drawing.Point(243, 7)
        Me.lblMovieSkipLessThanMB.Name = "lblMovieSkipLessThanMB"
        Me.lblMovieSkipLessThanMB.Size = New System.Drawing.Size(24, 13)
        Me.lblMovieSkipLessThanMB.TabIndex = 2
        Me.lblMovieSkipLessThanMB.Text = "MB"
        '
        'chkMovieSkipStackedSizeCheck
        '
        Me.chkMovieSkipStackedSizeCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieSkipStackedSizeCheck.AutoSize = True
        Me.tblMovieSourcesMiscOpts.SetColumnSpan(Me.chkMovieSkipStackedSizeCheck, 3)
        Me.chkMovieSkipStackedSizeCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieSkipStackedSizeCheck.Location = New System.Drawing.Point(3, 31)
        Me.chkMovieSkipStackedSizeCheck.Name = "chkMovieSkipStackedSizeCheck"
        Me.chkMovieSkipStackedSizeCheck.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.chkMovieSkipStackedSizeCheck.Size = New System.Drawing.Size(208, 17)
        Me.chkMovieSkipStackedSizeCheck.TabIndex = 3
        Me.chkMovieSkipStackedSizeCheck.Text = "Skip Size Check of Stacked Files"
        Me.chkMovieSkipStackedSizeCheck.UseVisualStyleBackColor = True
        '
        'gbSources
        '
        Me.gbSources.AutoSize = True
        Me.tblSettings.SetColumnSpan(Me.gbSources, 2)
        Me.gbSources.Controls.Add(Me.tblMovieSourcesDefaultsOpts)
        Me.gbSources.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbSources.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSources.Location = New System.Drawing.Point(3, 3)
        Me.gbSources.Name = "gbSources"
        Me.gbSources.Size = New System.Drawing.Size(843, 204)
        Me.gbSources.TabIndex = 9
        Me.gbSources.TabStop = False
        Me.gbSources.Text = "Sources"
        '
        'tblMovieSourcesDefaultsOpts
        '
        Me.tblMovieSourcesDefaultsOpts.AutoSize = True
        Me.tblMovieSourcesDefaultsOpts.ColumnCount = 4
        Me.tblMovieSourcesDefaultsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSourcesDefaultsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSourcesDefaultsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSourcesDefaultsOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieSourcesDefaultsOpts.Controls.Add(Me.btnMovieSourceRemove, 2, 3)
        Me.tblMovieSourcesDefaultsOpts.Controls.Add(Me.btnMovieSourceEdit, 2, 2)
        Me.tblMovieSourcesDefaultsOpts.Controls.Add(Me.btnMovieSourceAdd, 2, 1)
        Me.tblMovieSourcesDefaultsOpts.Controls.Add(Me.lvMovieSources, 0, 1)
        Me.tblMovieSourcesDefaultsOpts.Controls.Add(Me.lblMovieSourcesDefaultsLanguage, 0, 0)
        Me.tblMovieSourcesDefaultsOpts.Controls.Add(Me.cbMovieGeneralLang, 1, 0)
        Me.tblMovieSourcesDefaultsOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieSourcesDefaultsOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieSourcesDefaultsOpts.Name = "tblMovieSourcesDefaultsOpts"
        Me.tblMovieSourcesDefaultsOpts.RowCount = 5
        Me.tblMovieSourcesDefaultsOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesDefaultsOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesDefaultsOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesDefaultsOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesDefaultsOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieSourcesDefaultsOpts.Size = New System.Drawing.Size(837, 183)
        Me.tblMovieSourcesDefaultsOpts.TabIndex = 0
        '
        'lvMovieSources
        '
        Me.lvMovieSources.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMovieSourcesID, Me.colMovieSourcesName, Me.colMovieSourcesPath, Me.colMovieSourcesLanguage, Me.colMovieSourcesRecur, Me.colMovieSourcesFolder, Me.colMovieSourcesSingle, Me.colMovieSourcesExclude, Me.colMovieSourcesGetYear})
        Me.tblMovieSourcesDefaultsOpts.SetColumnSpan(Me.lvMovieSources, 2)
        Me.lvMovieSources.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvMovieSources.FullRowSelect = True
        Me.lvMovieSources.HideSelection = False
        Me.lvMovieSources.Location = New System.Drawing.Point(3, 30)
        Me.lvMovieSources.Name = "lvMovieSources"
        Me.tblMovieSourcesDefaultsOpts.SetRowSpan(Me.lvMovieSources, 3)
        Me.lvMovieSources.Size = New System.Drawing.Size(721, 150)
        Me.lvMovieSources.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvMovieSources.TabIndex = 0
        Me.lvMovieSources.UseCompatibleStateImageBehavior = False
        Me.lvMovieSources.View = System.Windows.Forms.View.Details
        '
        'colMovieSourcesID
        '
        Me.colMovieSourcesID.Text = "ID"
        Me.colMovieSourcesID.Width = 0
        '
        'colMovieSourcesName
        '
        Me.colMovieSourcesName.Text = "Name"
        Me.colMovieSourcesName.Width = 100
        '
        'colMovieSourcesPath
        '
        Me.colMovieSourcesPath.Text = "Path"
        Me.colMovieSourcesPath.Width = 130
        '
        'colMovieSourcesLanguage
        '
        Me.colMovieSourcesLanguage.Text = "Language"
        Me.colMovieSourcesLanguage.Width = 80
        '
        'colMovieSourcesRecur
        '
        Me.colMovieSourcesRecur.Text = "Recursive"
        '
        'colMovieSourcesFolder
        '
        Me.colMovieSourcesFolder.Text = "Use Folder Name"
        Me.colMovieSourcesFolder.Width = 110
        '
        'colMovieSourcesSingle
        '
        Me.colMovieSourcesSingle.Text = "Single Video"
        Me.colMovieSourcesSingle.Width = 90
        '
        'colMovieSourcesExclude
        '
        Me.colMovieSourcesExclude.Text = "Exclude"
        '
        'colMovieSourcesGetYear
        '
        Me.colMovieSourcesGetYear.Text = "Get Year"
        '
        'btnMovieSourceRemove
        '
        Me.btnMovieSourceRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMovieSourceRemove.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovieSourceRemove.Image = CType(resources.GetObject("btnMovieSourceRemove.Image"), System.Drawing.Image)
        Me.btnMovieSourceRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMovieSourceRemove.Location = New System.Drawing.Point(730, 157)
        Me.btnMovieSourceRemove.Name = "btnMovieSourceRemove"
        Me.btnMovieSourceRemove.Size = New System.Drawing.Size(104, 23)
        Me.btnMovieSourceRemove.TabIndex = 3
        Me.btnMovieSourceRemove.Text = "Remove"
        Me.btnMovieSourceRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMovieSourceRemove.UseVisualStyleBackColor = True
        '
        'btnMovieSourceEdit
        '
        Me.btnMovieSourceEdit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovieSourceEdit.Image = CType(resources.GetObject("btnMovieSourceEdit.Image"), System.Drawing.Image)
        Me.btnMovieSourceEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMovieSourceEdit.Location = New System.Drawing.Point(730, 59)
        Me.btnMovieSourceEdit.Name = "btnMovieSourceEdit"
        Me.btnMovieSourceEdit.Size = New System.Drawing.Size(104, 23)
        Me.btnMovieSourceEdit.TabIndex = 2
        Me.btnMovieSourceEdit.Text = "Edit Source"
        Me.btnMovieSourceEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMovieSourceEdit.UseVisualStyleBackColor = True
        '
        'btnMovieSourceAdd
        '
        Me.btnMovieSourceAdd.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovieSourceAdd.Image = CType(resources.GetObject("btnMovieSourceAdd.Image"), System.Drawing.Image)
        Me.btnMovieSourceAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMovieSourceAdd.Location = New System.Drawing.Point(730, 30)
        Me.btnMovieSourceAdd.Name = "btnMovieSourceAdd"
        Me.btnMovieSourceAdd.Size = New System.Drawing.Size(104, 23)
        Me.btnMovieSourceAdd.TabIndex = 1
        Me.btnMovieSourceAdd.Text = "Add Source"
        Me.btnMovieSourceAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMovieSourceAdd.UseVisualStyleBackColor = True
        '
        'lblMovieSourcesDefaultsLanguage
        '
        Me.lblMovieSourcesDefaultsLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMovieSourcesDefaultsLanguage.AutoSize = True
        Me.lblMovieSourcesDefaultsLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMovieSourcesDefaultsLanguage.Location = New System.Drawing.Point(3, 7)
        Me.lblMovieSourcesDefaultsLanguage.Name = "lblMovieSourcesDefaultsLanguage"
        Me.lblMovieSourcesDefaultsLanguage.Size = New System.Drawing.Size(188, 13)
        Me.lblMovieSourcesDefaultsLanguage.TabIndex = 8
        Me.lblMovieSourcesDefaultsLanguage.Text = "Default Language for new Sources:"
        Me.lblMovieSourcesDefaultsLanguage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbMovieGeneralLang
        '
        Me.cbMovieGeneralLang.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbMovieGeneralLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovieGeneralLang.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbMovieGeneralLang.Location = New System.Drawing.Point(197, 3)
        Me.cbMovieGeneralLang.Name = "cbMovieGeneralLang"
        Me.cbMovieGeneralLang.Size = New System.Drawing.Size(160, 21)
        Me.cbMovieGeneralLang.TabIndex = 12
        '
        'frmMovie_Source
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 459)
        Me.Controls.Add(Me.pnlSettings)
        Me.Controls.Add(Me.lblMovieLevTolerance)
        Me.Name = "frmMovie_Source"
        Me.Text = "frmMovieSource"
        Me.gbMovieGeneralFiltersOpts.ResumeLayout(False)
        Me.gbMovieGeneralFiltersOpts.PerformLayout()
        Me.tblMovieGeneralFiltersOpts.ResumeLayout(False)
        Me.tblMovieGeneralFiltersOpts.PerformLayout()
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieSourcesMiscOpts.ResumeLayout(False)
        Me.gbMovieSourcesMiscOpts.PerformLayout()
        Me.tblMovieSourcesMiscOpts.ResumeLayout(False)
        Me.tblMovieSourcesMiscOpts.PerformLayout()
        Me.gbSources.ResumeLayout(False)
        Me.gbSources.PerformLayout()
        Me.tblMovieSourcesDefaultsOpts.ResumeLayout(False)
        Me.tblMovieSourcesDefaultsOpts.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkMovieGeneralMarkNew As Windows.Forms.CheckBox
    Friend WithEvents gbMovieGeneralFiltersOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieGeneralFiltersOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMovieFilterRemove As Windows.Forms.Button
    Friend WithEvents btnMovieFilterDown As Windows.Forms.Button
    Friend WithEvents btnMovieFilterUp As Windows.Forms.Button
    Friend WithEvents chkMovieProperCase As Windows.Forms.CheckBox
    Friend WithEvents lstMovieFilters As Windows.Forms.ListBox
    Friend WithEvents btnMovieFilterAdd As Windows.Forms.Button
    Friend WithEvents txtMovieFilter As Windows.Forms.TextBox
    Friend WithEvents btnMovieFilterReset As Windows.Forms.Button
    Friend WithEvents chkMovieLevTolerance As Windows.Forms.CheckBox
    Friend WithEvents lblMovieLevTolerance As Windows.Forms.Label
    Friend WithEvents txtMovieLevTolerance As Windows.Forms.TextBox
    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents lvMovieSources As Windows.Forms.ListView
    Friend WithEvents colMovieSourcesID As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSourcesName As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSourcesPath As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSourcesLanguage As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSourcesRecur As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSourcesFolder As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSourcesSingle As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSourcesExclude As Windows.Forms.ColumnHeader
    Friend WithEvents colMovieSourcesGetYear As Windows.Forms.ColumnHeader
    Friend WithEvents btnMovieSourceAdd As Windows.Forms.Button
    Friend WithEvents btnMovieSourceEdit As Windows.Forms.Button
    Friend WithEvents btnMovieSourceRemove As Windows.Forms.Button
    Friend WithEvents gbMovieSourcesMiscOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSourcesMiscOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieCleanDB As Windows.Forms.CheckBox
    Friend WithEvents chkMovieScanOrderModify As Windows.Forms.CheckBox
    Friend WithEvents lblMovieSkipLessThan As Windows.Forms.Label
    Friend WithEvents chkMovieGeneralIgnoreLastScan As Windows.Forms.CheckBox
    Friend WithEvents chkMovieSortBeforeScan As Windows.Forms.CheckBox
    Friend WithEvents txtMovieSkipLessThan As Windows.Forms.TextBox
    Friend WithEvents lblMovieSkipLessThanMB As Windows.Forms.Label
    Friend WithEvents chkMovieSkipStackedSizeCheck As Windows.Forms.CheckBox
    Friend WithEvents gbSources As Windows.Forms.GroupBox
    Friend WithEvents tblMovieSourcesDefaultsOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents cbMovieGeneralLang As Windows.Forms.ComboBox
    Friend WithEvents lblMovieSourcesDefaultsLanguage As Windows.Forms.Label
End Class
