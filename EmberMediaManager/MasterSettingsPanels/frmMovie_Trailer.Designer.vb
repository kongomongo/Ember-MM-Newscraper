<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovie_Trailer
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
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieTrailerOpts = New System.Windows.Forms.GroupBox()
        Me.tblTrailer = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMinQual = New System.Windows.Forms.Label()
        Me.cbPrefVideoQual = New System.Windows.Forms.ComboBox()
        Me.cbMinVideoQual = New System.Windows.Forms.ComboBox()
        Me.lblPrefQual = New System.Windows.Forms.Label()
        Me.lblDefaultSearch = New System.Windows.Forms.Label()
        Me.chkKeepExisting = New System.Windows.Forms.CheckBox()
        Me.txtDefaultSearch = New System.Windows.Forms.TextBox()
        Me.dgvTrailer = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieTrailerOpts.SuspendLayout()
        Me.tblTrailer.SuspendLayout()
        CType(Me.dgvTrailer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.BackColor = System.Drawing.Color.White
        Me.pnlSettings.Controls.Add(Me.tblSettings)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(573, 299)
        Me.pnlSettings.TabIndex = 22
        Me.pnlSettings.Visible = False
        '
        'tblSettings
        '
        Me.tblSettings.AutoScroll = True
        Me.tblSettings.AutoSize = True
        Me.tblSettings.ColumnCount = 2
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.Controls.Add(Me.gbMovieTrailerOpts, 0, 0)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 2
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.Size = New System.Drawing.Size(573, 299)
        Me.tblSettings.TabIndex = 2
        '
        'gbMovieTrailerOpts
        '
        Me.gbMovieTrailerOpts.AutoSize = True
        Me.gbMovieTrailerOpts.Controls.Add(Me.tblTrailer)
        Me.gbMovieTrailerOpts.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbMovieTrailerOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieTrailerOpts.Name = "gbMovieTrailerOpts"
        Me.gbMovieTrailerOpts.Size = New System.Drawing.Size(357, 149)
        Me.gbMovieTrailerOpts.TabIndex = 1
        Me.gbMovieTrailerOpts.TabStop = False
        Me.gbMovieTrailerOpts.Text = "Trailers"
        '
        'tblTrailer
        '
        Me.tblTrailer.AutoSize = True
        Me.tblTrailer.ColumnCount = 2
        Me.tblTrailer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTrailer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTrailer.Controls.Add(Me.lblMinQual, 0, 2)
        Me.tblTrailer.Controls.Add(Me.cbPrefVideoQual, 1, 1)
        Me.tblTrailer.Controls.Add(Me.cbMinVideoQual, 1, 2)
        Me.tblTrailer.Controls.Add(Me.lblPrefQual, 0, 1)
        Me.tblTrailer.Controls.Add(Me.lblDefaultSearch, 0, 3)
        Me.tblTrailer.Controls.Add(Me.chkKeepExisting, 0, 0)
        Me.tblTrailer.Controls.Add(Me.txtDefaultSearch, 1, 3)
        Me.tblTrailer.Controls.Add(Me.dgvTrailer, 1, 4)
        Me.tblTrailer.Controls.Add(Me.Label1, 0, 4)
        Me.tblTrailer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTrailer.Location = New System.Drawing.Point(3, 18)
        Me.tblTrailer.Name = "tblTrailer"
        Me.tblTrailer.RowCount = 6
        Me.tblTrailer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTrailer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTrailer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTrailer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTrailer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTrailer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTrailer.Size = New System.Drawing.Size(351, 128)
        Me.tblTrailer.TabIndex = 2
        '
        'lblMinQual
        '
        Me.lblMinQual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMinQual.AutoSize = True
        Me.lblMinQual.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinQual.Location = New System.Drawing.Point(3, 57)
        Me.lblMinQual.Name = "lblMinQual"
        Me.lblMinQual.Size = New System.Drawing.Size(97, 13)
        Me.lblMinQual.TabIndex = 8
        Me.lblMinQual.Text = "Minimum Quality:"
        '
        'cbPrefVideoQual
        '
        Me.cbPrefVideoQual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbPrefVideoQual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrefVideoQual.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbPrefVideoQual.FormattingEnabled = True
        Me.cbPrefVideoQual.Location = New System.Drawing.Point(148, 26)
        Me.cbPrefVideoQual.Name = "cbPrefVideoQual"
        Me.cbPrefVideoQual.Size = New System.Drawing.Size(200, 21)
        Me.cbPrefVideoQual.TabIndex = 7
        '
        'cbMinVideoQual
        '
        Me.cbMinVideoQual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbMinVideoQual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMinVideoQual.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbMinVideoQual.FormattingEnabled = True
        Me.cbMinVideoQual.Location = New System.Drawing.Point(148, 53)
        Me.cbMinVideoQual.Name = "cbMinVideoQual"
        Me.cbMinVideoQual.Size = New System.Drawing.Size(200, 21)
        Me.cbMinVideoQual.TabIndex = 9
        '
        'lblPrefQual
        '
        Me.lblPrefQual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPrefQual.AutoSize = True
        Me.lblPrefQual.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrefQual.Location = New System.Drawing.Point(3, 30)
        Me.lblPrefQual.Name = "lblPrefQual"
        Me.lblPrefQual.Size = New System.Drawing.Size(96, 13)
        Me.lblPrefQual.TabIndex = 6
        Me.lblPrefQual.Text = "Preferred Quality:"
        '
        'lblDefaultSearch
        '
        Me.lblDefaultSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDefaultSearch.AutoSize = True
        Me.lblDefaultSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultSearch.Location = New System.Drawing.Point(3, 84)
        Me.lblDefaultSearch.Name = "lblDefaultSearch"
        Me.lblDefaultSearch.Size = New System.Drawing.Size(139, 13)
        Me.lblDefaultSearch.TabIndex = 11
        Me.lblDefaultSearch.Text = "Default Search Parameter:"
        '
        'chkKeepExisting
        '
        Me.chkKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkKeepExisting.AutoSize = True
        Me.chkKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKeepExisting.Location = New System.Drawing.Point(3, 3)
        Me.chkKeepExisting.Name = "chkKeepExisting"
        Me.chkKeepExisting.Size = New System.Drawing.Size(94, 17)
        Me.chkKeepExisting.TabIndex = 4
        Me.chkKeepExisting.Text = "Keep existing"
        Me.chkKeepExisting.UseVisualStyleBackColor = True
        '
        'txtDefaultSearch
        '
        Me.txtDefaultSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDefaultSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtDefaultSearch.Location = New System.Drawing.Point(148, 80)
        Me.txtDefaultSearch.Name = "txtDefaultSearch"
        Me.txtDefaultSearch.Size = New System.Drawing.Size(200, 22)
        Me.txtDefaultSearch.TabIndex = 10
        '
        'dgvTrailer
        '
        Me.dgvTrailer.Location = New System.Drawing.Point(148, 105)
        Me.dgvTrailer.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.dgvTrailer.Name = "dgvTrailer"
        Me.dgvTrailer.Size = New System.Drawing.Size(100, 23)
        Me.dgvTrailer.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Sources"
        '
        'frmMovie_Trailer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 299)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovie_Trailer"
        Me.Text = "frmMovie_Trailers"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieTrailerOpts.ResumeLayout(False)
        Me.gbMovieTrailerOpts.PerformLayout()
        Me.tblTrailer.ResumeLayout(False)
        Me.tblTrailer.PerformLayout()
        CType(Me.dgvTrailer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieTrailerOpts As Windows.Forms.GroupBox
    Friend WithEvents tblTrailer As Windows.Forms.TableLayoutPanel
    Friend WithEvents txtDefaultSearch As Windows.Forms.TextBox
    Friend WithEvents lblDefaultSearch As Windows.Forms.Label
    Friend WithEvents chkKeepExisting As Windows.Forms.CheckBox
    Friend WithEvents cbMinVideoQual As Windows.Forms.ComboBox
    Friend WithEvents lblMinQual As Windows.Forms.Label
    Friend WithEvents lblPrefQual As Windows.Forms.Label
    Friend WithEvents cbPrefVideoQual As Windows.Forms.ComboBox
    Friend WithEvents dgvTrailer As DataGridView
    Friend WithEvents Label1 As Label
End Class
