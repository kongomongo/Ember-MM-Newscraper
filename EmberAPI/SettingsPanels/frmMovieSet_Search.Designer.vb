<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovieSet_Search
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
        Me.pnlMovieSetSearch = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMovieSetSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMovieSetSearch
        '
        Me.pnlMovieSetSearch.Controls.Add(Me.Label1)
        Me.pnlMovieSetSearch.Location = New System.Drawing.Point(47, 85)
        Me.pnlMovieSetSearch.Name = "pnlMovieSetSearch"
        Me.pnlMovieSetSearch.Size = New System.Drawing.Size(200, 100)
        Me.pnlMovieSetSearch.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'frmMovieSet_Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.pnlMovieSetSearch)
        Me.Name = "frmMovieSet_Search"
        Me.Text = "frmMovieset_Search"
        Me.pnlMovieSetSearch.ResumeLayout(False)
        Me.pnlMovieSetSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMovieSetSearch As Windows.Forms.Panel
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
