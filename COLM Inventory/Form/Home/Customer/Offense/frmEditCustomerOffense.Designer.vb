<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditCustomerOffense
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.lblInformation = New System.Windows.Forms.Label()
        Me.txtInformation = New System.Windows.Forms.TextBox()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.lblSettled = New System.Windows.Forms.Label()
        Me.sbtnSettled = New COLM_Inventory.ctrlSwitch()
        Me.lblOffenseID = New System.Windows.Forms.Label()
        Me.txtOffenseID = New System.Windows.Forms.TextBox()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInformation
        '
        Me.lblInformation.AutoSize = True
        Me.lblInformation.Location = New System.Drawing.Point(30, 63)
        Me.lblInformation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(81, 19)
        Me.lblInformation.TabIndex = 0
        Me.lblInformation.Text = "Information"
        Me.lblInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInformation
        '
        Me.txtInformation.BackColor = System.Drawing.Color.White
        Me.txtInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInformation.ForeColor = System.Drawing.Color.Black
        Me.txtInformation.Location = New System.Drawing.Point(119, 60)
        Me.txtInformation.Margin = New System.Windows.Forms.Padding(0)
        Me.txtInformation.MaxLength = 120
        Me.txtInformation.Multiline = True
        Me.txtInformation.Name = "txtInformation"
        Me.txtInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInformation.Size = New System.Drawing.Size(200, 100)
        Me.txtInformation.TabIndex = 0
        '
        'err
        '
        Me.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.err.ContainerControl = Me
        '
        'btnEdit
        '
        Me.btnEdit.AutoEllipsis = True
        Me.btnEdit.BackColor = System.Drawing.Color.Green
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(219, 220)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'lblSettled
        '
        Me.lblSettled.AutoSize = True
        Me.lblSettled.Location = New System.Drawing.Point(60, 168)
        Me.lblSettled.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSettled.Name = "lblSettled"
        Me.lblSettled.Size = New System.Drawing.Size(51, 19)
        Me.lblSettled.TabIndex = 0
        Me.lblSettled.Text = "Settled"
        Me.lblSettled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbtnSettled
        '
        Me.sbtnSettled.AutoEllipsis = True
        Me.sbtnSettled.Location = New System.Drawing.Point(119, 165)
        Me.sbtnSettled.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnSettled.Name = "sbtnSettled"
        Me.sbtnSettled.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnSettled.OnColor = System.Drawing.Color.Green
        Me.sbtnSettled.Size = New System.Drawing.Size(200, 25)
        Me.sbtnSettled.TabIndex = 1
        Me.sbtnSettled.UseVisualStyleBackColor = True
        '
        'lblOffenseID
        '
        Me.lblOffenseID.AutoSize = True
        Me.lblOffenseID.Location = New System.Drawing.Point(37, 33)
        Me.lblOffenseID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOffenseID.Name = "lblOffenseID"
        Me.lblOffenseID.Size = New System.Drawing.Size(74, 19)
        Me.lblOffenseID.TabIndex = 0
        Me.lblOffenseID.Text = "Offense ID"
        Me.lblOffenseID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOffenseID
        '
        Me.txtOffenseID.BackColor = System.Drawing.Color.White
        Me.txtOffenseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOffenseID.ForeColor = System.Drawing.Color.Black
        Me.txtOffenseID.Location = New System.Drawing.Point(119, 30)
        Me.txtOffenseID.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOffenseID.Name = "txtOffenseID"
        Me.txtOffenseID.ReadOnly = True
        Me.txtOffenseID.Size = New System.Drawing.Size(200, 25)
        Me.txtOffenseID.TabIndex = 0
        Me.txtOffenseID.TabStop = False
        '
        'frmEditCustomerOffense
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(349, 280)
        Me.Controls.Add(Me.lblOffenseID)
        Me.Controls.Add(Me.txtOffenseID)
        Me.Controls.Add(Me.lblInformation)
        Me.Controls.Add(Me.txtInformation)
        Me.Controls.Add(Me.lblSettled)
        Me.Controls.Add(Me.sbtnSettled)
        Me.Controls.Add(Me.btnEdit)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditCustomerOffense"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Customer Offense"
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblInformation As Label
    Private WithEvents txtInformation As TextBox
    Private WithEvents err As ErrorProvider
    Private WithEvents btnEdit As Button
    Private WithEvents lblSettled As Label
    Private WithEvents sbtnSettled As ctrlSwitch
    Private WithEvents lblOffenseID As Label
    Private WithEvents txtOffenseID As TextBox
End Class
