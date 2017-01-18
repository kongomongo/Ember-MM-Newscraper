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
        Me.tblMovieThemeOpts = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMovieThemeKeepExisting = New System.Windows.Forms.CheckBox()
        Me.pnlSettings.SuspendLayout()
        Me.tblSettings.SuspendLayout()
        Me.gbMovieThemeOpts.SuspendLayout()
        Me.tblMovieThemeOpts.SuspendLayout()
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
        Me.pnlSettings.Size = New System.Drawing.Size(284, 261)
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
        Me.tblSettings.Size = New System.Drawing.Size(284, 261)
        Me.tblSettings.TabIndex = 3
        '
        'gbMovieThemeOpts
        '
        Me.gbMovieThemeOpts.AutoSize = True
        Me.gbMovieThemeOpts.Controls.Add(Me.tblMovieThemeOpts)
        Me.gbMovieThemeOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMovieThemeOpts.Location = New System.Drawing.Point(3, 3)
        Me.gbMovieThemeOpts.Name = "gbMovieThemeOpts"
        Me.gbMovieThemeOpts.Size = New System.Drawing.Size(106, 44)
        Me.gbMovieThemeOpts.TabIndex = 2
        Me.gbMovieThemeOpts.TabStop = False
        Me.gbMovieThemeOpts.Text = "Themes"
        '
        'tblMovieThemeOpts
        '
        Me.tblMovieThemeOpts.AutoSize = True
        Me.tblMovieThemeOpts.ColumnCount = 2
        Me.tblMovieThemeOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieThemeOpts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMovieThemeOpts.Controls.Add(Me.chkMovieThemeKeepExisting, 0, 0)
        Me.tblMovieThemeOpts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMovieThemeOpts.Location = New System.Drawing.Point(3, 18)
        Me.tblMovieThemeOpts.Name = "tblMovieThemeOpts"
        Me.tblMovieThemeOpts.RowCount = 2
        Me.tblMovieThemeOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieThemeOpts.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblMovieThemeOpts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMovieThemeOpts.Size = New System.Drawing.Size(100, 23)
        Me.tblMovieThemeOpts.TabIndex = 3
        '
        'chkMovieThemeKeepExisting
        '
        Me.chkMovieThemeKeepExisting.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkMovieThemeKeepExisting.AutoSize = True
        Me.chkMovieThemeKeepExisting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMovieThemeKeepExisting.Location = New System.Drawing.Point(3, 3)
        Me.chkMovieThemeKeepExisting.Name = "chkMovieThemeKeepExisting"
        Me.chkMovieThemeKeepExisting.Size = New System.Drawing.Size(94, 17)
        Me.chkMovieThemeKeepExisting.TabIndex = 4
        Me.chkMovieThemeKeepExisting.Text = "Keep existing"
        Me.chkMovieThemeKeepExisting.UseVisualStyleBackColor = True
        '
        'frmMovie_Theme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.pnlSettings)
        Me.Name = "frmMovie_Theme"
        Me.Text = "frmMovie_Themes"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.tblSettings.ResumeLayout(False)
        Me.tblSettings.PerformLayout()
        Me.gbMovieThemeOpts.ResumeLayout(False)
        Me.gbMovieThemeOpts.PerformLayout()
        Me.tblMovieThemeOpts.ResumeLayout(False)
        Me.tblMovieThemeOpts.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSettings As Windows.Forms.Panel
    Friend WithEvents tblSettings As Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMovieThemeOpts As Windows.Forms.GroupBox
    Friend WithEvents tblMovieThemeOpts As Windows.Forms.TableLayoutPanel
    Friend WithEvents chkMovieThemeKeepExisting As Windows.Forms.CheckBox
End Class
