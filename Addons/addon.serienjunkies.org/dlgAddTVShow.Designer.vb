<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAddTVShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgAddTVShow))
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.tblMain = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSkip = New System.Windows.Forms.Button()
        Me.lblURL = New System.Windows.Forms.Label()
        Me.btnOpenURL = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtURL = New EmberAPI.FormUtils.TextBox_with_Watermark()
        Me.pnlMain.SuspendLayout()
        Me.tblMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTitle.Location = New System.Drawing.Point(84, 4)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(300, 20)
        Me.txtTitle.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(3, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(27, 13)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Title"
        '
        'pnlMain
        '
        Me.pnlMain.AutoSize = True
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.tblMain)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(481, 102)
        Me.pnlMain.TabIndex = 2
        '
        'tblMain
        '
        Me.tblMain.AutoSize = True
        Me.tblMain.ColumnCount = 4
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.Controls.Add(Me.btnCancel, 0, 2)
        Me.tblMain.Controls.Add(Me.lblTitle, 0, 0)
        Me.tblMain.Controls.Add(Me.btnAdd, 1, 2)
        Me.tblMain.Controls.Add(Me.btnSkip, 2, 2)
        Me.tblMain.Controls.Add(Me.txtTitle, 1, 0)
        Me.tblMain.Controls.Add(Me.lblURL, 0, 1)
        Me.tblMain.Controls.Add(Me.btnOpenURL, 2, 1)
        Me.tblMain.Controls.Add(Me.btnSearch, 2, 0)
        Me.tblMain.Controls.Add(Me.txtURL, 1, 1)
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 0)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowCount = 4
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.Size = New System.Drawing.Size(481, 102)
        Me.tblMain.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(3, 61)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAdd.Location = New System.Drawing.Point(196, 61)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnSkip
        '
        Me.btnSkip.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.btnSkip.Location = New System.Drawing.Point(390, 61)
        Me.btnSkip.Name = "btnSkip"
        Me.btnSkip.Size = New System.Drawing.Size(75, 23)
        Me.btnSkip.TabIndex = 5
        Me.btnSkip.Text = "Skip"
        Me.btnSkip.UseVisualStyleBackColor = True
        '
        'lblURL
        '
        Me.lblURL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblURL.AutoSize = True
        Me.lblURL.Location = New System.Drawing.Point(3, 37)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(55, 13)
        Me.lblURL.TabIndex = 2
        Me.lblURL.Text = "Main URL"
        '
        'btnOpenURL
        '
        Me.btnOpenURL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnOpenURL.Enabled = False
        Me.btnOpenURL.Location = New System.Drawing.Point(390, 32)
        Me.btnOpenURL.Name = "btnOpenURL"
        Me.btnOpenURL.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenURL.TabIndex = 4
        Me.btnOpenURL.Text = "Open"
        Me.btnOpenURL.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSearch.Location = New System.Drawing.Point(390, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(84, 32)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(300, 20)
        Me.txtURL.TabIndex = 1
        Me.txtURL.WatermarkColor = System.Drawing.Color.Gray
        Me.txtURL.WatermarkText = "http://serienjunkies.org/serie/<TITLE>"
        '
        'dlgAddTVShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(481, 102)
        Me.Controls.Add(Me.pnlMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "dlgAddTVShow"
        Me.Text = "Add TV Show to WatchList"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.tblMain.ResumeLayout(False)
        Me.tblMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTitle As TextBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents tblMain As TableLayoutPanel
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblURL As Label
    Friend WithEvents btnOpenURL As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSkip As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtURL As EmberAPI.FormUtils.TextBox_with_Watermark
End Class
