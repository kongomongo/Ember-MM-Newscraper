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
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.pnlSettingsMain = New System.Windows.Forms.Panel()
        Me.tblSettingsMain = New System.Windows.Forms.TableLayoutPanel()
        Me.gbFilenameSettings = New System.Windows.Forms.GroupBox()
        Me.tblFilename = New System.Windows.Forms.TableLayoutPanel()
        Me.txtRegexFilename = New System.Windows.Forms.TextBox()
        Me.lblRegexFilename = New System.Windows.Forms.Label()
        Me.lblRegexHint = New System.Windows.Forms.Label()
        Me.gbRegexTest = New System.Windows.Forms.GroupBox()
        Me.tblRegexTest = New System.Windows.Forms.TableLayoutPanel()
        Me.txtRegexTestExampleFilename = New System.Windows.Forms.TextBox()
        Me.lblRegexTestExampleFilename = New System.Windows.Forms.Label()
        Me.btnRegexTest = New System.Windows.Forms.Button()
        Me.lblRegexTestYear = New System.Windows.Forms.Label()
        Me.lblRegexTestMonth = New System.Windows.Forms.Label()
        Me.lblRegexTestDay = New System.Windows.Forms.Label()
        Me.lblRegexTestStation = New System.Windows.Forms.Label()
        Me.lblRegexTestHour = New System.Windows.Forms.Label()
        Me.lblRegexTestMinute = New System.Windows.Forms.Label()
        Me.lblRegexTestResult = New System.Windows.Forms.Label()
        Me.lblRegexTestResultValue = New System.Windows.Forms.Label()
        Me.lblRegexTestYearValue = New System.Windows.Forms.Label()
        Me.lblRegexTestMonthValue = New System.Windows.Forms.Label()
        Me.lblRegexTestDayValue = New System.Windows.Forms.Label()
        Me.lblRegexTestStationValue = New System.Windows.Forms.Label()
        Me.lblRegexTestHourValue = New System.Windows.Forms.Label()
        Me.lblRegexTestMinuteValue = New System.Windows.Forms.Label()
        Me.gbTimeSettings = New System.Windows.Forms.GroupBox()
        Me.tblTimeSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTimeOffset = New System.Windows.Forms.Label()
        Me.txtTimeOffset = New System.Windows.Forms.TextBox()
        Me.gpStationSettings = New System.Windows.Forms.GroupBox()
        Me.tblStationSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGetAllStations = New System.Windows.Forms.Button()
        Me.pnlSettingsTop.SuspendLayout()
        Me.tblSettingsTop.SuspendLayout()
        Me.pnlSettings.SuspendLayout()
        Me.pnlSettingsMain.SuspendLayout()
        Me.tblSettingsMain.SuspendLayout()
        Me.gbFilenameSettings.SuspendLayout()
        Me.tblFilename.SuspendLayout()
        Me.gbRegexTest.SuspendLayout()
        Me.tblRegexTest.SuspendLayout()
        Me.gbTimeSettings.SuspendLayout()
        Me.tblTimeSettings.SuspendLayout()
        Me.gpStationSettings.SuspendLayout()
        Me.tblStationSettings.SuspendLayout()
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
        Me.pnlSettingsTop.Size = New System.Drawing.Size(922, 23)
        Me.pnlSettingsTop.TabIndex = 0
        '
        'tblSettingsTop
        '
        Me.tblSettingsTop.AutoSize = True
        Me.tblSettingsTop.ColumnCount = 2
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.Controls.Add(Me.chkEnabled, 0, 0)
        Me.tblSettingsTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsTop.Name = "tblSettingsTop"
        Me.tblSettingsTop.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.tblSettingsTop.RowCount = 2
        Me.tblSettingsTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsTop.Size = New System.Drawing.Size(922, 23)
        Me.tblSettingsTop.TabIndex = 10
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(8, 3)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(68, 17)
        Me.chkEnabled.TabIndex = 0
        Me.chkEnabled.Text = "Enabled"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.Controls.Add(Me.pnlSettingsMain)
        Me.pnlSettings.Controls.Add(Me.pnlSettingsTop)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(922, 573)
        Me.pnlSettings.TabIndex = 0
        '
        'pnlSettingsMain
        '
        Me.pnlSettingsMain.AutoSize = True
        Me.pnlSettingsMain.Controls.Add(Me.tblSettingsMain)
        Me.pnlSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsMain.Location = New System.Drawing.Point(0, 23)
        Me.pnlSettingsMain.Name = "pnlSettingsMain"
        Me.pnlSettingsMain.Size = New System.Drawing.Size(922, 550)
        Me.pnlSettingsMain.TabIndex = 10
        '
        'tblSettingsMain
        '
        Me.tblSettingsMain.AutoSize = True
        Me.tblSettingsMain.ColumnCount = 3
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.Controls.Add(Me.gbFilenameSettings, 0, 0)
        Me.tblSettingsMain.Controls.Add(Me.gbTimeSettings, 0, 1)
        Me.tblSettingsMain.Controls.Add(Me.gpStationSettings, 1, 0)
        Me.tblSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsMain.Name = "tblSettingsMain"
        Me.tblSettingsMain.RowCount = 4
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.Size = New System.Drawing.Size(922, 550)
        Me.tblSettingsMain.TabIndex = 0
        '
        'gbFilenameSettings
        '
        Me.gbFilenameSettings.AutoSize = True
        Me.gbFilenameSettings.Controls.Add(Me.tblFilename)
        Me.gbFilenameSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFilenameSettings.Location = New System.Drawing.Point(3, 3)
        Me.gbFilenameSettings.Name = "gbFilenameSettings"
        Me.gbFilenameSettings.Size = New System.Drawing.Size(516, 342)
        Me.gbFilenameSettings.TabIndex = 0
        Me.gbFilenameSettings.TabStop = False
        Me.gbFilenameSettings.Text = "File Name Settings"
        '
        'tblFilename
        '
        Me.tblFilename.AutoSize = True
        Me.tblFilename.ColumnCount = 2
        Me.tblFilename.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFilename.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblFilename.Controls.Add(Me.txtRegexFilename, 1, 0)
        Me.tblFilename.Controls.Add(Me.lblRegexFilename, 0, 0)
        Me.tblFilename.Controls.Add(Me.lblRegexHint, 1, 1)
        Me.tblFilename.Controls.Add(Me.gbRegexTest, 0, 2)
        Me.tblFilename.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFilename.Location = New System.Drawing.Point(3, 18)
        Me.tblFilename.Name = "tblFilename"
        Me.tblFilename.RowCount = 3
        Me.tblFilename.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFilename.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFilename.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblFilename.Size = New System.Drawing.Size(510, 321)
        Me.tblFilename.TabIndex = 0
        '
        'txtRegexFilename
        '
        Me.txtRegexFilename.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRegexFilename.Location = New System.Drawing.Point(50, 3)
        Me.txtRegexFilename.Name = "txtRegexFilename"
        Me.txtRegexFilename.Size = New System.Drawing.Size(457, 22)
        Me.txtRegexFilename.TabIndex = 0
        '
        'lblRegexFilename
        '
        Me.lblRegexFilename.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexFilename.AutoSize = True
        Me.lblRegexFilename.Location = New System.Drawing.Point(3, 7)
        Me.lblRegexFilename.Name = "lblRegexFilename"
        Me.lblRegexFilename.Size = New System.Drawing.Size(41, 13)
        Me.lblRegexFilename.TabIndex = 1
        Me.lblRegexFilename.Text = "Regex:"
        '
        'lblRegexHint
        '
        Me.lblRegexHint.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexHint.AutoSize = True
        Me.lblRegexHint.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblRegexHint.Location = New System.Drawing.Point(50, 31)
        Me.lblRegexHint.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRegexHint.Name = "lblRegexHint"
        Me.lblRegexHint.Size = New System.Drawing.Size(242, 91)
        Me.lblRegexHint.TabIndex = 2
        Me.lblRegexHint.Text = "The regex must contain the following groups:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<YEAR>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<MONTH>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<DAY>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<STATION>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "<HOUR>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<MINUTE>"
        '
        'gbRegexTest
        '
        Me.gbRegexTest.AutoSize = True
        Me.tblFilename.SetColumnSpan(Me.gbRegexTest, 2)
        Me.gbRegexTest.Controls.Add(Me.tblRegexTest)
        Me.gbRegexTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbRegexTest.Location = New System.Drawing.Point(3, 128)
        Me.gbRegexTest.Name = "gbRegexTest"
        Me.gbRegexTest.Size = New System.Drawing.Size(504, 190)
        Me.gbRegexTest.TabIndex = 3
        Me.gbRegexTest.TabStop = False
        Me.gbRegexTest.Text = "Regex Test"
        '
        'tblRegexTest
        '
        Me.tblRegexTest.AutoSize = True
        Me.tblRegexTest.ColumnCount = 3
        Me.tblRegexTest.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblRegexTest.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblRegexTest.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblRegexTest.Controls.Add(Me.txtRegexTestExampleFilename, 1, 0)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestExampleFilename, 0, 0)
        Me.tblRegexTest.Controls.Add(Me.btnRegexTest, 2, 0)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestYear, 0, 2)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestMonth, 0, 3)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestDay, 0, 4)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestStation, 0, 5)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestHour, 0, 6)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestMinute, 0, 7)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestResult, 0, 1)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestResultValue, 1, 1)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestYearValue, 1, 2)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestMonthValue, 1, 3)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestDayValue, 1, 4)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestStationValue, 1, 5)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestHourValue, 1, 6)
        Me.tblRegexTest.Controls.Add(Me.lblRegexTestMinuteValue, 1, 7)
        Me.tblRegexTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblRegexTest.Location = New System.Drawing.Point(3, 18)
        Me.tblRegexTest.Name = "tblRegexTest"
        Me.tblRegexTest.RowCount = 9
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblRegexTest.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblRegexTest.Size = New System.Drawing.Size(498, 169)
        Me.tblRegexTest.TabIndex = 0
        '
        'txtRegexTestExampleFilename
        '
        Me.txtRegexTestExampleFilename.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRegexTestExampleFilename.Location = New System.Drawing.Point(114, 3)
        Me.txtRegexTestExampleFilename.Name = "txtRegexTestExampleFilename"
        Me.txtRegexTestExampleFilename.Size = New System.Drawing.Size(300, 22)
        Me.txtRegexTestExampleFilename.TabIndex = 0
        '
        'lblRegexTestExampleFilename
        '
        Me.lblRegexTestExampleFilename.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestExampleFilename.AutoSize = True
        Me.lblRegexTestExampleFilename.Location = New System.Drawing.Point(3, 8)
        Me.lblRegexTestExampleFilename.Name = "lblRegexTestExampleFilename"
        Me.lblRegexTestExampleFilename.Size = New System.Drawing.Size(105, 13)
        Me.lblRegexTestExampleFilename.TabIndex = 1
        Me.lblRegexTestExampleFilename.Text = "Example File Name:"
        '
        'btnRegexTest
        '
        Me.btnRegexTest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnRegexTest.Location = New System.Drawing.Point(420, 3)
        Me.btnRegexTest.Name = "btnRegexTest"
        Me.btnRegexTest.Size = New System.Drawing.Size(75, 23)
        Me.btnRegexTest.TabIndex = 2
        Me.btnRegexTest.Text = "Run Test"
        Me.btnRegexTest.UseVisualStyleBackColor = True
        '
        'lblRegexTestYear
        '
        Me.lblRegexTestYear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestYear.AutoSize = True
        Me.lblRegexTestYear.Location = New System.Drawing.Point(3, 52)
        Me.lblRegexTestYear.Name = "lblRegexTestYear"
        Me.lblRegexTestYear.Size = New System.Drawing.Size(48, 13)
        Me.lblRegexTestYear.TabIndex = 3
        Me.lblRegexTestYear.Text = "<YEAR>"
        '
        'lblRegexTestMonth
        '
        Me.lblRegexTestMonth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestMonth.AutoSize = True
        Me.lblRegexTestMonth.Location = New System.Drawing.Point(3, 72)
        Me.lblRegexTestMonth.Name = "lblRegexTestMonth"
        Me.lblRegexTestMonth.Size = New System.Drawing.Size(63, 13)
        Me.lblRegexTestMonth.TabIndex = 3
        Me.lblRegexTestMonth.Text = "<MONTH>"
        '
        'lblRegexTestDay
        '
        Me.lblRegexTestDay.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestDay.AutoSize = True
        Me.lblRegexTestDay.Location = New System.Drawing.Point(3, 92)
        Me.lblRegexTestDay.Name = "lblRegexTestDay"
        Me.lblRegexTestDay.Size = New System.Drawing.Size(42, 13)
        Me.lblRegexTestDay.TabIndex = 3
        Me.lblRegexTestDay.Text = "<DAY>"
        '
        'lblRegexTestStation
        '
        Me.lblRegexTestStation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestStation.AutoSize = True
        Me.lblRegexTestStation.Location = New System.Drawing.Point(3, 112)
        Me.lblRegexTestStation.Name = "lblRegexTestStation"
        Me.lblRegexTestStation.Size = New System.Drawing.Size(64, 13)
        Me.lblRegexTestStation.TabIndex = 3
        Me.lblRegexTestStation.Text = "<STATION>"
        '
        'lblRegexTestHour
        '
        Me.lblRegexTestHour.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestHour.AutoSize = True
        Me.lblRegexTestHour.Location = New System.Drawing.Point(3, 132)
        Me.lblRegexTestHour.Name = "lblRegexTestHour"
        Me.lblRegexTestHour.Size = New System.Drawing.Size(55, 13)
        Me.lblRegexTestHour.TabIndex = 3
        Me.lblRegexTestHour.Text = "<HOUR>"
        '
        'lblRegexTestMinute
        '
        Me.lblRegexTestMinute.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestMinute.AutoSize = True
        Me.lblRegexTestMinute.Location = New System.Drawing.Point(3, 152)
        Me.lblRegexTestMinute.Name = "lblRegexTestMinute"
        Me.lblRegexTestMinute.Size = New System.Drawing.Size(63, 13)
        Me.lblRegexTestMinute.TabIndex = 3
        Me.lblRegexTestMinute.Text = "<MINUTE>"
        '
        'lblRegexTestResult
        '
        Me.lblRegexTestResult.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestResult.AutoSize = True
        Me.lblRegexTestResult.Location = New System.Drawing.Point(3, 32)
        Me.lblRegexTestResult.Name = "lblRegexTestResult"
        Me.lblRegexTestResult.Size = New System.Drawing.Size(64, 13)
        Me.lblRegexTestResult.TabIndex = 4
        Me.lblRegexTestResult.Text = "Test Result:"
        '
        'lblRegexTestResultValue
        '
        Me.lblRegexTestResultValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestResultValue.AutoSize = True
        Me.lblRegexTestResultValue.Location = New System.Drawing.Point(114, 32)
        Me.lblRegexTestResultValue.Name = "lblRegexTestResultValue"
        Me.lblRegexTestResultValue.Size = New System.Drawing.Size(60, 13)
        Me.lblRegexTestResultValue.TabIndex = 5
        Me.lblRegexTestResultValue.Text = "not tested"
        '
        'lblRegexTestYearValue
        '
        Me.lblRegexTestYearValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestYearValue.AutoSize = True
        Me.lblRegexTestYearValue.Location = New System.Drawing.Point(114, 52)
        Me.lblRegexTestYearValue.Name = "lblRegexTestYearValue"
        Me.lblRegexTestYearValue.Size = New System.Drawing.Size(60, 13)
        Me.lblRegexTestYearValue.TabIndex = 5
        Me.lblRegexTestYearValue.Text = "not tested"
        '
        'lblRegexTestMonthValue
        '
        Me.lblRegexTestMonthValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestMonthValue.AutoSize = True
        Me.lblRegexTestMonthValue.Location = New System.Drawing.Point(114, 72)
        Me.lblRegexTestMonthValue.Name = "lblRegexTestMonthValue"
        Me.lblRegexTestMonthValue.Size = New System.Drawing.Size(60, 13)
        Me.lblRegexTestMonthValue.TabIndex = 5
        Me.lblRegexTestMonthValue.Text = "not tested"
        '
        'lblRegexTestDayValue
        '
        Me.lblRegexTestDayValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestDayValue.AutoSize = True
        Me.lblRegexTestDayValue.Location = New System.Drawing.Point(114, 92)
        Me.lblRegexTestDayValue.Name = "lblRegexTestDayValue"
        Me.lblRegexTestDayValue.Size = New System.Drawing.Size(60, 13)
        Me.lblRegexTestDayValue.TabIndex = 5
        Me.lblRegexTestDayValue.Text = "not tested"
        '
        'lblRegexTestStationValue
        '
        Me.lblRegexTestStationValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestStationValue.AutoSize = True
        Me.lblRegexTestStationValue.Location = New System.Drawing.Point(114, 112)
        Me.lblRegexTestStationValue.Name = "lblRegexTestStationValue"
        Me.lblRegexTestStationValue.Size = New System.Drawing.Size(60, 13)
        Me.lblRegexTestStationValue.TabIndex = 5
        Me.lblRegexTestStationValue.Text = "not tested"
        '
        'lblRegexTestHourValue
        '
        Me.lblRegexTestHourValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestHourValue.AutoSize = True
        Me.lblRegexTestHourValue.Location = New System.Drawing.Point(114, 132)
        Me.lblRegexTestHourValue.Name = "lblRegexTestHourValue"
        Me.lblRegexTestHourValue.Size = New System.Drawing.Size(60, 13)
        Me.lblRegexTestHourValue.TabIndex = 5
        Me.lblRegexTestHourValue.Text = "not tested"
        '
        'lblRegexTestMinuteValue
        '
        Me.lblRegexTestMinuteValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRegexTestMinuteValue.AutoSize = True
        Me.lblRegexTestMinuteValue.Location = New System.Drawing.Point(114, 152)
        Me.lblRegexTestMinuteValue.Name = "lblRegexTestMinuteValue"
        Me.lblRegexTestMinuteValue.Size = New System.Drawing.Size(60, 13)
        Me.lblRegexTestMinuteValue.TabIndex = 5
        Me.lblRegexTestMinuteValue.Text = "not tested"
        '
        'gbTimeSettings
        '
        Me.gbTimeSettings.AutoSize = True
        Me.gbTimeSettings.Controls.Add(Me.tblTimeSettings)
        Me.gbTimeSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTimeSettings.Location = New System.Drawing.Point(3, 351)
        Me.gbTimeSettings.Name = "gbTimeSettings"
        Me.gbTimeSettings.Size = New System.Drawing.Size(516, 49)
        Me.gbTimeSettings.TabIndex = 1
        Me.gbTimeSettings.TabStop = False
        Me.gbTimeSettings.Text = "Time Settings"
        '
        'tblTimeSettings
        '
        Me.tblTimeSettings.AutoSize = True
        Me.tblTimeSettings.ColumnCount = 3
        Me.tblTimeSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTimeSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTimeSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTimeSettings.Controls.Add(Me.lblTimeOffset, 0, 0)
        Me.tblTimeSettings.Controls.Add(Me.txtTimeOffset, 1, 0)
        Me.tblTimeSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTimeSettings.Location = New System.Drawing.Point(3, 18)
        Me.tblTimeSettings.Name = "tblTimeSettings"
        Me.tblTimeSettings.RowCount = 2
        Me.tblTimeSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTimeSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTimeSettings.Size = New System.Drawing.Size(510, 28)
        Me.tblTimeSettings.TabIndex = 0
        '
        'lblTimeOffset
        '
        Me.lblTimeOffset.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTimeOffset.AutoSize = True
        Me.lblTimeOffset.Location = New System.Drawing.Point(3, 7)
        Me.lblTimeOffset.Name = "lblTimeOffset"
        Me.lblTimeOffset.Size = New System.Drawing.Size(128, 13)
        Me.lblTimeOffset.TabIndex = 0
        Me.lblTimeOffset.Text = "Time Offset (in minutes)"
        '
        'txtTimeOffset
        '
        Me.txtTimeOffset.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTimeOffset.Location = New System.Drawing.Point(137, 3)
        Me.txtTimeOffset.Name = "txtTimeOffset"
        Me.txtTimeOffset.Size = New System.Drawing.Size(50, 22)
        Me.txtTimeOffset.TabIndex = 1
        '
        'gpStationSettings
        '
        Me.gpStationSettings.Controls.Add(Me.tblStationSettings)
        Me.gpStationSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpStationSettings.Location = New System.Drawing.Point(525, 3)
        Me.gpStationSettings.Name = "gpStationSettings"
        Me.gpStationSettings.Size = New System.Drawing.Size(280, 342)
        Me.gpStationSettings.TabIndex = 2
        Me.gpStationSettings.TabStop = False
        Me.gpStationSettings.Text = "Station Settings"
        '
        'tblStationSettings
        '
        Me.tblStationSettings.AutoSize = True
        Me.tblStationSettings.ColumnCount = 2
        Me.tblStationSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblStationSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblStationSettings.Controls.Add(Me.btnGetAllStations, 0, 0)
        Me.tblStationSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblStationSettings.Location = New System.Drawing.Point(3, 18)
        Me.tblStationSettings.Name = "tblStationSettings"
        Me.tblStationSettings.RowCount = 2
        Me.tblStationSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblStationSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblStationSettings.Size = New System.Drawing.Size(274, 321)
        Me.tblStationSettings.TabIndex = 0
        '
        'btnGetAllStations
        '
        Me.btnGetAllStations.Location = New System.Drawing.Point(3, 3)
        Me.btnGetAllStations.Name = "btnGetAllStations"
        Me.btnGetAllStations.Size = New System.Drawing.Size(128, 23)
        Me.btnGetAllStations.TabIndex = 0
        Me.btnGetAllStations.Text = "Get All Stations"
        Me.btnGetAllStations.UseVisualStyleBackColor = True
        '
        'frmSettingsPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(922, 573)
        Me.Controls.Add(Me.pnlSettings)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettingsPanel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SettingsPanel"
        Me.pnlSettingsTop.ResumeLayout(False)
        Me.pnlSettingsTop.PerformLayout()
        Me.tblSettingsTop.ResumeLayout(False)
        Me.tblSettingsTop.PerformLayout()
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.pnlSettingsMain.ResumeLayout(False)
        Me.pnlSettingsMain.PerformLayout()
        Me.tblSettingsMain.ResumeLayout(False)
        Me.tblSettingsMain.PerformLayout()
        Me.gbFilenameSettings.ResumeLayout(False)
        Me.gbFilenameSettings.PerformLayout()
        Me.tblFilename.ResumeLayout(False)
        Me.tblFilename.PerformLayout()
        Me.gbRegexTest.ResumeLayout(False)
        Me.gbRegexTest.PerformLayout()
        Me.tblRegexTest.ResumeLayout(False)
        Me.tblRegexTest.PerformLayout()
        Me.gbTimeSettings.ResumeLayout(False)
        Me.gbTimeSettings.PerformLayout()
        Me.tblTimeSettings.ResumeLayout(False)
        Me.tblTimeSettings.PerformLayout()
        Me.gpStationSettings.ResumeLayout(False)
        Me.gpStationSettings.PerformLayout()
        Me.tblStationSettings.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSettingsTop As System.Windows.Forms.Panel
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSettings As System.Windows.Forms.Panel
    Friend WithEvents tblSettingsTop As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlSettingsMain As System.Windows.Forms.Panel
    Friend WithEvents tblSettingsMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbFilenameSettings As System.Windows.Forms.GroupBox
    Friend WithEvents tblFilename As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtRegexFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblRegexFilename As System.Windows.Forms.Label
    Friend WithEvents gbTimeSettings As System.Windows.Forms.GroupBox
    Friend WithEvents tblTimeSettings As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTimeOffset As System.Windows.Forms.Label
    Friend WithEvents txtTimeOffset As System.Windows.Forms.TextBox
    Friend WithEvents lblRegexHint As System.Windows.Forms.Label
    Friend WithEvents gbRegexTest As System.Windows.Forms.GroupBox
    Friend WithEvents tblRegexTest As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtRegexTestExampleFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblRegexTestExampleFilename As System.Windows.Forms.Label
    Friend WithEvents btnRegexTest As System.Windows.Forms.Button
    Friend WithEvents lblRegexTestYear As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestMonth As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestDay As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestStation As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestHour As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestMinute As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestResult As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestResultValue As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestYearValue As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestMonthValue As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestDayValue As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestStationValue As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestHourValue As System.Windows.Forms.Label
    Friend WithEvents lblRegexTestMinuteValue As System.Windows.Forms.Label
    Friend WithEvents gpStationSettings As System.Windows.Forms.GroupBox
    Friend WithEvents tblStationSettings As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGetAllStations As System.Windows.Forms.Button
End Class
