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
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.pnlSettingsMain = New System.Windows.Forms.Panel()
        Me.tbllSettingsMain = New System.Windows.Forms.TableLayoutPanel()
        Me.gbWatchList = New System.Windows.Forms.GroupBox()
        Me.tblWatchList = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvWatchList = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colURL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlSettingsTop = New System.Windows.Forms.Panel()
        Me.tblSettingsTop = New System.Windows.Forms.TableLayoutPanel()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.pnlSettings.SuspendLayout()
        Me.pnlSettingsMain.SuspendLayout()
        Me.tbllSettingsMain.SuspendLayout()
        Me.gbWatchList.SuspendLayout()
        Me.tblWatchList.SuspendLayout()
        CType(Me.dgvWatchList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSettingsTop.SuspendLayout()
        Me.tblSettingsTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.BackColor = System.Drawing.Color.White
        Me.pnlSettings.Controls.Add(Me.pnlSettingsMain)
        Me.pnlSettings.Controls.Add(Me.pnlSettingsTop)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(695, 516)
        Me.pnlSettings.TabIndex = 84
        '
        'pnlSettingsMain
        '
        Me.pnlSettingsMain.AutoSize = True
        Me.pnlSettingsMain.Controls.Add(Me.tbllSettingsMain)
        Me.pnlSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsMain.Location = New System.Drawing.Point(0, 23)
        Me.pnlSettingsMain.Name = "pnlSettingsMain"
        Me.pnlSettingsMain.Size = New System.Drawing.Size(695, 493)
        Me.pnlSettingsMain.TabIndex = 5
        '
        'tbllSettingsMain
        '
        Me.tbllSettingsMain.AutoScroll = True
        Me.tbllSettingsMain.AutoSize = True
        Me.tbllSettingsMain.ColumnCount = 2
        Me.tbllSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbllSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbllSettingsMain.Controls.Add(Me.gbWatchList, 0, 0)
        Me.tbllSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbllSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.tbllSettingsMain.Name = "tbllSettingsMain"
        Me.tbllSettingsMain.RowCount = 2
        Me.tbllSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbllSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbllSettingsMain.Size = New System.Drawing.Size(695, 493)
        Me.tbllSettingsMain.TabIndex = 1
        '
        'gbWatchList
        '
        Me.gbWatchList.AutoSize = True
        Me.gbWatchList.Controls.Add(Me.tblWatchList)
        Me.gbWatchList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbWatchList.Location = New System.Drawing.Point(3, 3)
        Me.gbWatchList.Name = "gbWatchList"
        Me.gbWatchList.Size = New System.Drawing.Size(612, 227)
        Me.gbWatchList.TabIndex = 0
        Me.gbWatchList.TabStop = False
        Me.gbWatchList.Text = "WatchList"
        '
        'tblWatchList
        '
        Me.tblWatchList.AutoSize = True
        Me.tblWatchList.ColumnCount = 2
        Me.tblWatchList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblWatchList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblWatchList.Controls.Add(Me.dgvWatchList, 0, 0)
        Me.tblWatchList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblWatchList.Location = New System.Drawing.Point(3, 18)
        Me.tblWatchList.Name = "tblWatchList"
        Me.tblWatchList.RowCount = 2
        Me.tblWatchList.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblWatchList.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblWatchList.Size = New System.Drawing.Size(606, 206)
        Me.tblWatchList.TabIndex = 0
        '
        'dgvWatchList
        '
        Me.dgvWatchList.AllowUserToAddRows = False
        Me.dgvWatchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWatchList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colTitle, Me.colURL})
        Me.dgvWatchList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWatchList.Location = New System.Drawing.Point(3, 3)
        Me.dgvWatchList.Name = "dgvWatchList"
        Me.dgvWatchList.Size = New System.Drawing.Size(600, 200)
        Me.dgvWatchList.TabIndex = 0
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 50
        '
        'colTitle
        '
        Me.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTitle.HeaderText = "Title"
        Me.colTitle.MinimumWidth = 100
        Me.colTitle.Name = "colTitle"
        Me.colTitle.ReadOnly = True
        '
        'colURL
        '
        Me.colURL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colURL.HeaderText = "URL"
        Me.colURL.MinimumWidth = 100
        Me.colURL.Name = "colURL"
        '
        'pnlSettingsTop
        '
        Me.pnlSettingsTop.AutoSize = True
        Me.pnlSettingsTop.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlSettingsTop.Controls.Add(Me.tblSettingsTop)
        Me.pnlSettingsTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsTop.Name = "pnlSettingsTop"
        Me.pnlSettingsTop.Size = New System.Drawing.Size(695, 23)
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
        Me.tblSettingsTop.Size = New System.Drawing.Size(695, 23)
        Me.tblSettingsTop.TabIndex = 5
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
        'frmSettingsPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(695, 516)
        Me.Controls.Add(Me.pnlSettings)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettingsPanel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings for Kodi Interface"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.pnlSettingsMain.ResumeLayout(False)
        Me.pnlSettingsMain.PerformLayout()
        Me.tbllSettingsMain.ResumeLayout(False)
        Me.tbllSettingsMain.PerformLayout()
        Me.gbWatchList.ResumeLayout(False)
        Me.gbWatchList.PerformLayout()
        Me.tblWatchList.ResumeLayout(False)
        CType(Me.dgvWatchList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSettingsTop.ResumeLayout(False)
        Me.pnlSettingsTop.PerformLayout()
        Me.tblSettingsTop.ResumeLayout(False)
        Me.tblSettingsTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSettings As System.Windows.Forms.Panel
    Friend WithEvents pnlSettingsTop As System.Windows.Forms.Panel
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSettingsMain As System.Windows.Forms.Panel
    Friend WithEvents tblSettingsTop As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbllSettingsMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbWatchList As GroupBox
    Friend WithEvents tblWatchList As TableLayoutPanel
    Friend WithEvents dgvWatchList As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colTitle As DataGridViewTextBoxColumn
    Friend WithEvents colURL As DataGridViewTextBoxColumn
End Class
