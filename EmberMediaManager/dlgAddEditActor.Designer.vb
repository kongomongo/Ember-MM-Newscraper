<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAddEditActor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgAddEditActor))
        Me.tblBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtRole = New System.Windows.Forms.TextBox()
        Me.txtThumb = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.lblThumb = New System.Windows.Forms.Label()
        Me.pbActLoad = New System.Windows.Forms.PictureBox()
        Me.pbActors = New System.Windows.Forms.PictureBox()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.bwDownloadPic = New System.ComponentModel.BackgroundWorker()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.tbpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.rbActor = New System.Windows.Forms.RadioButton()
        Me.rbGuestStar = New System.Windows.Forms.RadioButton()
        Me.tblBottom.SuspendLayout()
        CType(Me.pbActLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbActors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.tbpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblBottom
        '
        Me.tblBottom.AutoSize = True
        Me.tblBottom.ColumnCount = 3
        Me.tblBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblBottom.Controls.Add(Me.btnOK, 1, 0)
        Me.tblBottom.Controls.Add(Me.btnCancel, 2, 0)
        Me.tblBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblBottom.Location = New System.Drawing.Point(0, 0)
        Me.tblBottom.Name = "tblBottom"
        Me.tblBottom.RowCount = 1
        Me.tblBottom.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblBottom.Size = New System.Drawing.Size(667, 29)
        Me.tblBottom.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.Enabled = False
        Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOK.Location = New System.Drawing.Point(524, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(67, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(597, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(67, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtName.Location = New System.Drawing.Point(3, 46)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(174, 22)
        Me.txtName.TabIndex = 1
        '
        'txtRole
        '
        Me.txtRole.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtRole.Location = New System.Drawing.Point(183, 46)
        Me.txtRole.Name = "txtRole"
        Me.txtRole.Size = New System.Drawing.Size(174, 22)
        Me.txtRole.TabIndex = 3
        '
        'txtThumb
        '
        Me.tbpMain.SetColumnSpan(Me.txtThumb, 2)
        Me.txtThumb.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtThumb.Location = New System.Drawing.Point(3, 94)
        Me.txtThumb.Name = "txtThumb"
        Me.txtThumb.Size = New System.Drawing.Size(354, 22)
        Me.txtThumb.TabIndex = 5
        '
        'lblName
        '
        Me.lblName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblName.Location = New System.Drawing.Point(3, 30)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Actor Name:"
        '
        'lblRole
        '
        Me.lblRole.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRole.AutoSize = True
        Me.lblRole.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblRole.Location = New System.Drawing.Point(183, 30)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(64, 13)
        Me.lblRole.TabIndex = 2
        Me.lblRole.Text = "Actor Role:"
        '
        'lblThumb
        '
        Me.lblThumb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblThumb.AutoSize = True
        Me.lblThumb.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblThumb.Location = New System.Drawing.Point(3, 78)
        Me.lblThumb.Name = "lblThumb"
        Me.lblThumb.Size = New System.Drawing.Size(110, 13)
        Me.lblThumb.TabIndex = 4
        Me.lblThumb.Text = "Actor Thumb (URL):"
        '
        'pbActLoad
        '
        Me.pbActLoad.Image = CType(resources.GetObject("pbActLoad.Image"), System.Drawing.Image)
        Me.pbActLoad.Location = New System.Drawing.Point(168, 126)
        Me.pbActLoad.Name = "pbActLoad"
        Me.pbActLoad.Size = New System.Drawing.Size(41, 39)
        Me.pbActLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbActLoad.TabIndex = 28
        Me.pbActLoad.TabStop = False
        Me.pbActLoad.Visible = False
        '
        'pbActors
        '
        Me.pbActors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbActors.Location = New System.Drawing.Point(147, 93)
        Me.pbActors.Name = "pbActors"
        Me.pbActors.Size = New System.Drawing.Size(81, 106)
        Me.pbActors.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbActors.TabIndex = 29
        Me.pbActors.TabStop = False
        '
        'btnVerify
        '
        Me.btnVerify.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnVerify.Location = New System.Drawing.Point(11, 176)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(114, 23)
        Me.btnVerify.TabIndex = 6
        Me.btnVerify.Text = "Verify Thumb URL"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'bwDownloadPic
        '
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.tbpMain)
        Me.pnlMain.Controls.Add(Me.btnVerify)
        Me.pnlMain.Controls.Add(Me.pbActLoad)
        Me.pnlMain.Controls.Add(Me.pbActors)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(667, 465)
        Me.pnlMain.TabIndex = 1
        '
        'pnlBottom
        '
        Me.pnlBottom.AutoSize = True
        Me.pnlBottom.Controls.Add(Me.tblBottom)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 465)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(667, 29)
        Me.pnlBottom.TabIndex = 2
        '
        'tbpMain
        '
        Me.tbpMain.AutoSize = True
        Me.tbpMain.ColumnCount = 2
        Me.tbpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbpMain.Controls.Add(Me.rbActor, 0, 0)
        Me.tbpMain.Controls.Add(Me.rbGuestStar, 1, 0)
        Me.tbpMain.Controls.Add(Me.lblName, 0, 1)
        Me.tbpMain.Controls.Add(Me.lblRole, 1, 1)
        Me.tbpMain.Controls.Add(Me.txtThumb, 0, 4)
        Me.tbpMain.Controls.Add(Me.lblThumb, 0, 3)
        Me.tbpMain.Controls.Add(Me.txtName, 0, 2)
        Me.tbpMain.Controls.Add(Me.txtRole, 1, 2)
        Me.tbpMain.Location = New System.Drawing.Point(266, 74)
        Me.tbpMain.Name = "tbpMain"
        Me.tbpMain.RowCount = 6
        Me.tbpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tbpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tbpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tbpMain.Size = New System.Drawing.Size(360, 139)
        Me.tbpMain.TabIndex = 30
        '
        'rbActor
        '
        Me.rbActor.AutoSize = True
        Me.rbActor.Checked = True
        Me.rbActor.Enabled = False
        Me.rbActor.Location = New System.Drawing.Point(3, 3)
        Me.rbActor.Name = "rbActor"
        Me.rbActor.Size = New System.Drawing.Size(52, 17)
        Me.rbActor.TabIndex = 0
        Me.rbActor.TabStop = True
        Me.rbActor.Text = "Actor"
        Me.rbActor.UseVisualStyleBackColor = True
        '
        'rbGuestStar
        '
        Me.rbGuestStar.AutoSize = True
        Me.rbGuestStar.Enabled = False
        Me.rbGuestStar.Location = New System.Drawing.Point(183, 3)
        Me.rbGuestStar.Name = "rbGuestStar"
        Me.rbGuestStar.Size = New System.Drawing.Size(78, 17)
        Me.rbGuestStar.TabIndex = 1
        Me.rbGuestStar.Text = "Guest Star"
        Me.rbGuestStar.UseVisualStyleBackColor = True
        '
        'dlgAddEditActor
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(667, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlBottom)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 280)
        Me.Name = "dlgAddEditActor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "New Actor"
        Me.tblBottom.ResumeLayout(False)
        CType(Me.pbActLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbActors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.tbpMain.ResumeLayout(False)
        Me.tbpMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblBottom As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtRole As System.Windows.Forms.TextBox
    Friend WithEvents txtThumb As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents lblThumb As System.Windows.Forms.Label
    Friend WithEvents pbActLoad As System.Windows.Forms.PictureBox
    Friend WithEvents pbActors As System.Windows.Forms.PictureBox
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents bwDownloadPic As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents tbpMain As TableLayoutPanel
    Friend WithEvents rbActor As RadioButton
    Friend WithEvents rbGuestStar As RadioButton
End Class
