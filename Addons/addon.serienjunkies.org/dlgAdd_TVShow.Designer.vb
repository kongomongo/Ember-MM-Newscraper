<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAdd_TVShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgAdd_TVShow))
        Me.txtTVShowTitle = New System.Windows.Forms.TextBox()
        Me.lblTVShowTitle = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.tblMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lblURL = New System.Windows.Forms.Label()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnOpenURL = New System.Windows.Forms.Button()
        Me.btnSkip = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.tblMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTVShowTitle
        '
        Me.txtTVShowTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTVShowTitle.Location = New System.Drawing.Point(83, 4)
        Me.txtTVShowTitle.Name = "txtTVShowTitle"
        Me.txtTVShowTitle.ReadOnly = True
        Me.txtTVShowTitle.Size = New System.Drawing.Size(187, 20)
        Me.txtTVShowTitle.TabIndex = 0
        '
        'lblTVShowTitle
        '
        Me.lblTVShowTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTVShowTitle.AutoSize = True
        Me.lblTVShowTitle.Location = New System.Drawing.Point(3, 8)
        Me.lblTVShowTitle.Name = "lblTVShowTitle"
        Me.lblTVShowTitle.Size = New System.Drawing.Size(74, 13)
        Me.lblTVShowTitle.TabIndex = 1
        Me.lblTVShowTitle.Text = "TV Show Title"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.btnCancel)
        Me.pnlMain.Controls.Add(Me.btnSkip)
        Me.pnlMain.Controls.Add(Me.btnAdd)
        Me.pnlMain.Controls.Add(Me.tblMain)
        Me.pnlMain.Location = New System.Drawing.Point(12, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(360, 166)
        Me.pnlMain.TabIndex = 2
        '
        'tblMain
        '
        Me.tblMain.ColumnCount = 3
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMain.Controls.Add(Me.lblTVShowTitle, 0, 0)
        Me.tblMain.Controls.Add(Me.txtTVShowTitle, 1, 0)
        Me.tblMain.Controls.Add(Me.lblURL, 0, 1)
        Me.tblMain.Controls.Add(Me.txtURL, 1, 1)
        Me.tblMain.Controls.Add(Me.btnOpenURL, 2, 1)
        Me.tblMain.Controls.Add(Me.btnSearch, 2, 0)
        Me.tblMain.Location = New System.Drawing.Point(3, 3)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowCount = 2
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMain.Size = New System.Drawing.Size(354, 123)
        Me.tblMain.TabIndex = 0
        '
        'lblURL
        '
        Me.lblURL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblURL.AutoSize = True
        Me.lblURL.Location = New System.Drawing.Point(3, 69)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(55, 13)
        Me.lblURL.TabIndex = 2
        Me.lblURL.Text = "Main URL"
        '
        'txtURL
        '
        Me.txtURL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtURL.Location = New System.Drawing.Point(83, 66)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(187, 20)
        Me.txtURL.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAdd.Location = New System.Drawing.Point(198, 132)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnOpenURL
        '
        Me.btnOpenURL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnOpenURL.Location = New System.Drawing.Point(276, 64)
        Me.btnOpenURL.Name = "btnOpenURL"
        Me.btnOpenURL.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenURL.TabIndex = 4
        Me.btnOpenURL.Text = "Open"
        Me.btnOpenURL.UseVisualStyleBackColor = True
        '
        'btnSkip
        '
        Me.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.btnSkip.Location = New System.Drawing.Point(5, 132)
        Me.btnSkip.Name = "btnSkip"
        Me.btnSkip.Size = New System.Drawing.Size(75, 23)
        Me.btnSkip.TabIndex = 2
        Me.btnSkip.Text = "Skip"
        Me.btnSkip.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(279, 132)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSearch.Location = New System.Drawing.Point(276, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dlgAdd_TVShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 187)
        Me.Controls.Add(Me.pnlMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "dlgAdd_TVShow"
        Me.Text = "Add TV Show to WatchList"
        Me.pnlMain.ResumeLayout(False)
        Me.tblMain.ResumeLayout(False)
        Me.tblMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtTVShowTitle As TextBox
    Friend WithEvents lblTVShowTitle As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents tblMain As TableLayoutPanel
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblURL As Label
    Friend WithEvents txtURL As TextBox
    Friend WithEvents btnOpenURL As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSkip As Button
    Friend WithEvents btnSearch As Button
End Class
