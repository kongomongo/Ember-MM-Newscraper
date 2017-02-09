<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovie_Theme
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
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.tblSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.gbMovieThemeOpts = New System.Windows.Forms.GroupBox()
        Me.tblTheme = New System.Windows.Forms.TableLayoutPanel()
        Me.chkKeepExisting = New System.Windows.Forms.CheckBox()
        Me.lblDefaultSearch = New System.Windows.Forms.Label()
        Me.txtDefaultSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvTheme = New System.Windows.Forms.DataGridView()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieThemeOpts.SuspendLayout()
        Me.tblTheme.SuspendLayout()
        CType(Me.dgvTheme, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlSettings.Size = New System.Drawing.Size(408, 278)
        Me.pnlSettings.TabIndex = 23
        Me.pnlSettings.Visible = False
        '
        'tblSettings
        '
        Me.tblSettings.AutoScroll = True
        Me.tblSettings.AutoSize = True
        Me.tblSettings.ColumnCount = 2
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettings.Controls.Add(Me.gbMovieThemeOpts, 0, 0)
        Me.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettings.Location = New System.Drawing.Point(0, 0)
        Me.tblSettings.Name = "tblSettings"
        Me.tblSettings.RowCount = 2
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettings.Size = New System.Drawing.Size(408, 278)
        Me.tblSettings.TabIndex = 3
        '
        'gbMovieThemeOpts
        '
        Me.gbMovieThemeOpts.AutoSize = True
        Me.gbMovieThemeOpts.Controls.Add(Me.tblTheme)
        Me.gbMovieThemeOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieThemeOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieThemeOpts.Name = "gbMovieThemeOpts"
        Me.gbMovieThemeOpts.Size = New System.Drawing.Size(357, 95)
        Me.gbMovieThemeOpts.TabIndex = 2
        Me.gbMovieThemeOpts.TabStop = False
        Me.gbMovieThemeOpts.Text = "Themes"
        '
        'tblTheme
        '
        Me.tblTheme.AutoSize = True
        Me.tblTheme.ColumnCount = 3
        Me.tblTheme.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTheme.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTheme.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTheme.Controls.Add(Me.chkKeepExisting, 0, 0)
        Me.tblTheme.Controls.Add(Me.lblDefaultSearch, 0, 1)
        Me.tblTheme.Controls.Add(Me.txtDefaultSearch, 1, 1)
        Me.tblTheme.Controls.Add(Me.Label1, 0, 2)
        Me.tblTheme.Controls.Add(Me.dgvTheme, 1, 2)
        Me.tblTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTheme.Location = New System.Drawing.Point(3, 18)
        Me.tblTheme.Name = "tblTheme"
        Me.tblTheme.RowCount = 4
        Me.tblTheme.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTheme.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTheme.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTheme.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTheme.Size = New System.Drawing.Size(351, 74)
        Me.tblTheme.TabIndex = 3
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
        'lblDefaultSearch
        '
        Me.lblDefaultSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDefaultSearch.AutoSize = True
        Me.lblDefaultSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultSearch.Location = New System.Drawing.Point(3, 30)
        Me.lblDefaultSearch.Name = "lblDefaultSearch"
        Me.lblDefaultSearch.Size = New System.Drawing.Size(139, 13)
        Me.lblDefaultSearch.TabIndex = 11
        Me.lblDefaultSearch.Text = "Default Search Parameter:"
        '
        'txtDefaultSearch
        '
        Me.txtDefaultSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDefaultSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtDefaultSearch.Location = New System.Drawing.Point(148, 26)
        Me.txtDefaultSearch.Name = "txtDefaultSearch"
        Me.txtDefaultSearch.Size = New System.Drawing.Size(200, 22)
        Me.txtDefaultSearch.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Sources"
        '
        'dgvTheme
        '
        Me.dgvTheme.Location = New System.Drawing.Point(148, 51)
        Me.dgvTheme.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.dgvTheme.Name = "dgvTheme"
        Me.dgvTheme.Size = New System.Drawing.Size(100, 23)
        Me.dgvTheme.TabIndex = 71
        '
        'frmMovie_Theme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 278)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovie_Theme"
        Me.Text = "frmMovie_Themes"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieThemeOpts.ResumeLayout(False)
        Me.gbMovieThemeOpts.PerformLayout()
        Me.tblTheme.ResumeLayout(False)
        Me.tblTheme.PerformLayout()
        CType(Me.dgvTheme, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieThemeOpts As Windows.Forms.GroupBox
    Friend WithEvents tblTheme As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkKeepExisting As Windows.Forms.CheckBox
    Friend WithEvents lblDefaultSearch As Label
    Friend WithEvents txtDefaultSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvTheme As DataGridView
End Class
