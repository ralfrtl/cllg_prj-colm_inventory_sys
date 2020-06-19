<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlDashboardCard
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
        Me.ctrlGrd = New COLM_Inventory.ctrlGradient()
        Me.lblText = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.ctrlGrd.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctrlGrd
        '
        Me.ctrlGrd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctrlGrd.Angle = 35.0!
        Me.ctrlGrd.Color1 = System.Drawing.Color.Gray
        Me.ctrlGrd.Color2 = System.Drawing.Color.White
        Me.ctrlGrd.Controls.Add(Me.lblText)
        Me.ctrlGrd.Controls.Add(Me.lblDescription)
        Me.ctrlGrd.Location = New System.Drawing.Point(-1, -1)
        Me.ctrlGrd.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlGrd.MidIntensity = 0.5!
        Me.ctrlGrd.MidPosition = 0.75!
        Me.ctrlGrd.Name = "ctrlGrd"
        Me.ctrlGrd.Size = New System.Drawing.Size(201, 151)
        Me.ctrlGrd.TabIndex = 1
        '
        'lblText
        '
        Me.lblText.AutoEllipsis = True
        Me.lblText.BackColor = System.Drawing.Color.Transparent
        Me.lblText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblText.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblText.ForeColor = System.Drawing.Color.Black
        Me.lblText.Location = New System.Drawing.Point(0, 0)
        Me.lblText.Margin = New System.Windows.Forms.Padding(0)
        Me.lblText.Name = "lblText"
        Me.lblText.Padding = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.lblText.Size = New System.Drawing.Size(201, 101)
        Me.lblText.TabIndex = 0
        Me.lblText.Text = "Text"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDescription
        '
        Me.lblDescription.AutoEllipsis = True
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDescription.ForeColor = System.Drawing.Color.Black
        Me.lblDescription.Location = New System.Drawing.Point(0, 101)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(201, 50)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "Description"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctrlDashboardCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ctrlGrd)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlDashboardCard"
        Me.Size = New System.Drawing.Size(200, 150)
        Me.ctrlGrd.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblDescription As Label
    Private WithEvents lblText As Label
    Private WithEvents ctrlGrd As ctrlGradient
End Class
