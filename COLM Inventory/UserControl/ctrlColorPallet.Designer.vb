<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlColorPallet
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.clrDlg = New System.Windows.Forms.ColorDialog()
        Me.lblColor1 = New System.Windows.Forms.Label()
        Me.lblColor2 = New System.Windows.Forms.Label()
        Me.btnColor1 = New System.Windows.Forms.Button()
        Me.btnColor2 = New System.Windows.Forms.Button()
        Me.pnlColor1 = New System.Windows.Forms.Panel()
        Me.pnlColor2 = New System.Windows.Forms.Panel()
        Me.btnSwtich = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'clrDlg
        '
        Me.clrDlg.FullOpen = True
        Me.clrDlg.SolidColorOnly = True
        '
        'lblColor1
        '
        Me.lblColor1.AutoSize = True
        Me.lblColor1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblColor1.ForeColor = System.Drawing.Color.Black
        Me.lblColor1.Location = New System.Drawing.Point(30, 10)
        Me.lblColor1.Margin = New System.Windows.Forms.Padding(0)
        Me.lblColor1.MinimumSize = New System.Drawing.Size(0, 20)
        Me.lblColor1.Name = "lblColor1"
        Me.lblColor1.Size = New System.Drawing.Size(95, 20)
        Me.lblColor1.TabIndex = 0
        Me.lblColor1.Text = "255, 255, 255"
        '
        'lblColor2
        '
        Me.lblColor2.AutoSize = True
        Me.lblColor2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblColor2.ForeColor = System.Drawing.Color.Black
        Me.lblColor2.Location = New System.Drawing.Point(30, 35)
        Me.lblColor2.Margin = New System.Windows.Forms.Padding(0)
        Me.lblColor2.MinimumSize = New System.Drawing.Size(0, 20)
        Me.lblColor2.Name = "lblColor2"
        Me.lblColor2.Size = New System.Drawing.Size(78, 20)
        Me.lblColor2.TabIndex = 0
        Me.lblColor2.Text = "255, 0, 0, 0"
        '
        'btnColor1
        '
        Me.btnColor1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnColor1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnColor1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnColor1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColor1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnColor1.ForeColor = System.Drawing.Color.Black
        Me.btnColor1.Location = New System.Drawing.Point(190, 10)
        Me.btnColor1.Margin = New System.Windows.Forms.Padding(0)
        Me.btnColor1.Name = "btnColor1"
        Me.btnColor1.Size = New System.Drawing.Size(30, 20)
        Me.btnColor1.TabIndex = 0
        Me.btnColor1.Text = "..."
        Me.btnColor1.UseCompatibleTextRendering = True
        Me.btnColor1.UseVisualStyleBackColor = True
        '
        'btnColor2
        '
        Me.btnColor2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnColor2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnColor2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnColor2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColor2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnColor2.ForeColor = System.Drawing.Color.Black
        Me.btnColor2.Location = New System.Drawing.Point(190, 35)
        Me.btnColor2.Margin = New System.Windows.Forms.Padding(0)
        Me.btnColor2.Name = "btnColor2"
        Me.btnColor2.Size = New System.Drawing.Size(30, 20)
        Me.btnColor2.TabIndex = 1
        Me.btnColor2.Text = "..."
        Me.btnColor2.UseCompatibleTextRendering = True
        Me.btnColor2.UseVisualStyleBackColor = True
        '
        'pnlColor1
        '
        Me.pnlColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColor1.ForeColor = System.Drawing.Color.Black
        Me.pnlColor1.Location = New System.Drawing.Point(10, 10)
        Me.pnlColor1.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlColor1.Name = "pnlColor1"
        Me.pnlColor1.Size = New System.Drawing.Size(20, 20)
        Me.pnlColor1.TabIndex = 0
        '
        'pnlColor2
        '
        Me.pnlColor2.BackColor = System.Drawing.Color.Black
        Me.pnlColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColor2.ForeColor = System.Drawing.Color.Black
        Me.pnlColor2.Location = New System.Drawing.Point(10, 35)
        Me.pnlColor2.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlColor2.Name = "pnlColor2"
        Me.pnlColor2.Size = New System.Drawing.Size(20, 20)
        Me.pnlColor2.TabIndex = 0
        '
        'btnSwtich
        '
        Me.btnSwtich.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSwtich.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSwtich.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSwtich.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSwtich.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSwtich.ForeColor = System.Drawing.Color.Black
        Me.btnSwtich.Location = New System.Drawing.Point(225, 10)
        Me.btnSwtich.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSwtich.Name = "btnSwtich"
        Me.btnSwtich.Size = New System.Drawing.Size(15, 45)
        Me.btnSwtich.TabIndex = 2
        Me.btnSwtich.Text = ")"
        Me.btnSwtich.UseCompatibleTextRendering = True
        Me.btnSwtich.UseVisualStyleBackColor = True
        '
        'ctrlColorPallet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.btnSwtich)
        Me.Controls.Add(Me.pnlColor1)
        Me.Controls.Add(Me.lblColor1)
        Me.Controls.Add(Me.btnColor1)
        Me.Controls.Add(Me.pnlColor2)
        Me.Controls.Add(Me.lblColor2)
        Me.Controls.Add(Me.btnColor2)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Name = "ctrlColorPallet"
        Me.Size = New System.Drawing.Size(250, 400)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents clrDlg As ColorDialog
    Private WithEvents lblColor1 As Label
    Private WithEvents lblColor2 As Label
    Private WithEvents btnColor1 As Button
    Private WithEvents btnColor2 As Button
    Private WithEvents pnlColor1 As Panel
    Private WithEvents pnlColor2 As Panel
    Private WithEvents btnSwtich As Button
End Class
