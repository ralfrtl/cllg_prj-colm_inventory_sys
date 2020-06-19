<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
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
        Me.pnlError = New System.Windows.Forms.Panel()
        Me.lblError = New System.Windows.Forms.Label()
        Me.tpnlPassword = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.tpnlUsername = New System.Windows.Forms.TableLayoutPanel()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.grdBackground = New COLM_Inventory.ctrlGradient()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.pnlAppInfo = New System.Windows.Forms.Panel()
        Me.pnlError.SuspendLayout()
        Me.tpnlPassword.SuspendLayout()
        Me.tpnlUsername.SuspendLayout()
        Me.grdBackground.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlError
        '
        Me.pnlError.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlError.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.pnlError.Controls.Add(Me.lblError)
        Me.pnlError.ForeColor = System.Drawing.Color.White
        Me.pnlError.Location = New System.Drawing.Point(30, 420)
        Me.pnlError.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlError.Name = "pnlError"
        Me.pnlError.Size = New System.Drawing.Size(250, 30)
        Me.pnlError.TabIndex = 0
        Me.pnlError.Visible = False
        '
        'lblError
        '
        Me.lblError.AutoEllipsis = True
        Me.lblError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblError.Location = New System.Drawing.Point(0, 0)
        Me.lblError.Margin = New System.Windows.Forms.Padding(0)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(250, 30)
        Me.lblError.TabIndex = 0
        Me.lblError.Text = "err"
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblError.UseCompatibleTextRendering = True
        '
        'tpnlPassword
        '
        Me.tpnlPassword.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpnlPassword.ColumnCount = 2
        Me.tpnlPassword.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tpnlPassword.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tpnlPassword.Controls.Add(Me.lblPassword, 0, 0)
        Me.tpnlPassword.Controls.Add(Me.txtPassword, 1, 0)
        Me.tpnlPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tpnlPassword.Location = New System.Drawing.Point(15, 300)
        Me.tpnlPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.tpnlPassword.Name = "tpnlPassword"
        Me.tpnlPassword.RowCount = 1
        Me.tpnlPassword.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tpnlPassword.Size = New System.Drawing.Size(280, 30)
        Me.tpnlPassword.TabIndex = 1
        Me.tpnlPassword.TabStop = True
        '
        'lblPassword
        '
        Me.lblPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPassword.Location = New System.Drawing.Point(0, 0)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblPassword.Size = New System.Drawing.Size(90, 30)
        Me.lblPassword.TabIndex = 0
        Me.lblPassword.Text = "Password :"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(90, 6)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(0, 6, 10, 0)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(180, 18)
        Me.txtPassword.TabIndex = 0
        '
        'tpnlUsername
        '
        Me.tpnlUsername.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpnlUsername.ColumnCount = 2
        Me.tpnlUsername.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tpnlUsername.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tpnlUsername.Controls.Add(Me.lblUserName, 0, 0)
        Me.tpnlUsername.Controls.Add(Me.txtUsername, 1, 0)
        Me.tpnlUsername.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tpnlUsername.Location = New System.Drawing.Point(15, 260)
        Me.tpnlUsername.Margin = New System.Windows.Forms.Padding(0)
        Me.tpnlUsername.Name = "tpnlUsername"
        Me.tpnlUsername.RowCount = 1
        Me.tpnlUsername.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tpnlUsername.Size = New System.Drawing.Size(280, 30)
        Me.tpnlUsername.TabIndex = 0
        Me.tpnlUsername.TabStop = True
        '
        'lblUserName
        '
        Me.lblUserName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblUserName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUserName.Location = New System.Drawing.Point(0, 0)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblUserName.Size = New System.Drawing.Size(90, 30)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "Username :"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.White
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsername.ForeColor = System.Drawing.Color.Black
        Me.txtUsername.Location = New System.Drawing.Point(90, 6)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(0, 6, 10, 0)
        Me.txtUsername.MaxLength = 16
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(180, 18)
        Me.txtUsername.TabIndex = 0
        '
        'grdBackground
        '
        Me.grdBackground.Angle = 35.0!
        Me.grdBackground.Color1 = System.Drawing.Color.LimeGreen
        Me.grdBackground.Color2 = System.Drawing.Color.Cyan
        Me.grdBackground.Controls.Add(Me.btnLogin)
        Me.grdBackground.Controls.Add(Me.pnlAppInfo)
        Me.grdBackground.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBackground.Location = New System.Drawing.Point(0, 0)
        Me.grdBackground.Margin = New System.Windows.Forms.Padding(0)
        Me.grdBackground.MidIntensity = 0.5!
        Me.grdBackground.MidPosition = 0.75!
        Me.grdBackground.Name = "grdBackground"
        Me.grdBackground.Size = New System.Drawing.Size(310, 461)
        Me.grdBackground.TabIndex = 2
        Me.grdBackground.TabStop = True
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(30, 380)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(0)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(250, 30)
        Me.btnLogin.TabIndex = 0
        Me.btnLogin.Text = "L O G I N"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'pnlAppInfo
        '
        Me.pnlAppInfo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlAppInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlAppInfo.Location = New System.Drawing.Point(30, 50)
        Me.pnlAppInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAppInfo.Name = "pnlAppInfo"
        Me.pnlAppInfo.Size = New System.Drawing.Size(250, 320)
        Me.pnlAppInfo.TabIndex = 0
        '
        'frmLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(310, 461)
        Me.Controls.Add(Me.pnlError)
        Me.Controls.Add(Me.tpnlPassword)
        Me.Controls.Add(Me.tpnlUsername)
        Me.Controls.Add(Me.grdBackground)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MinimumSize = New System.Drawing.Size(310, 500)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.pnlError.ResumeLayout(False)
        Me.tpnlPassword.ResumeLayout(False)
        Me.tpnlPassword.PerformLayout()
        Me.tpnlUsername.ResumeLayout(False)
        Me.tpnlUsername.PerformLayout()
        Me.grdBackground.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents tpnlUsername As TableLayoutPanel
    Private WithEvents lblUserName As Label
    Private WithEvents txtUsername As TextBox
    Private WithEvents tpnlPassword As TableLayoutPanel
    Private WithEvents lblPassword As Label
    Private WithEvents txtPassword As TextBox
    Private WithEvents pnlAppInfo As Panel
    Private WithEvents btnLogin As Button
    Private WithEvents pnlError As Panel
    Private WithEvents lblError As Label
    Private WithEvents grdBackground As ctrlGradient
End Class
