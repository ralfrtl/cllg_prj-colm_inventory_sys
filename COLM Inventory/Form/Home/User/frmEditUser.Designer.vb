<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditUser
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
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSelectPermission = New System.Windows.Forms.Button()
        Me.pnlPermissionDetails = New System.Windows.Forms.Panel()
        Me.lblPermissionName = New System.Windows.Forms.Label()
        Me.lblAccessUser = New System.Windows.Forms.Label()
        Me.lblAccessPermission = New System.Windows.Forms.Label()
        Me.lblAccessCustomer = New System.Windows.Forms.Label()
        Me.lblAccessItem = New System.Windows.Forms.Label()
        Me.lblAccessInventory = New System.Windows.Forms.Label()
        Me.lblAccessReservation = New System.Windows.Forms.Label()
        Me.lblAccessConsume = New System.Windows.Forms.Label()
        Me.lblAccessBorrow = New System.Windows.Forms.Label()
        Me.lblAccessStation = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.sbtnActive = New COLM_Inventory.ctrlSwitch()
        Me.lblActive = New System.Windows.Forms.Label()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPermissionDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(30, 63)
        Me.lblUsername.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(71, 19)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.White
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.ForeColor = System.Drawing.Color.Black
        Me.txtUsername.Location = New System.Drawing.Point(109, 60)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(0)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(200, 25)
        Me.txtUsername.TabIndex = 0
        Me.txtUsername.TabStop = False
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
        Me.btnEdit.Location = New System.Drawing.Point(209, 391)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnSelectPermission
        '
        Me.btnSelectPermission.AutoEllipsis = True
        Me.btnSelectPermission.BackColor = System.Drawing.Color.Green
        Me.btnSelectPermission.FlatAppearance.BorderSize = 0
        Me.btnSelectPermission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnSelectPermission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnSelectPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectPermission.ForeColor = System.Drawing.Color.White
        Me.btnSelectPermission.Location = New System.Drawing.Point(209, 122)
        Me.btnSelectPermission.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSelectPermission.Name = "btnSelectPermission"
        Me.btnSelectPermission.Size = New System.Drawing.Size(100, 20)
        Me.btnSelectPermission.TabIndex = 1
        Me.btnSelectPermission.Text = "Select"
        Me.btnSelectPermission.UseCompatibleTextRendering = True
        Me.btnSelectPermission.UseVisualStyleBackColor = False
        '
        'pnlPermissionDetails
        '
        Me.pnlPermissionDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlPermissionDetails.Controls.Add(Me.lblPermissionName)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessUser)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessPermission)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessCustomer)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessItem)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessInventory)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessReservation)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessConsume)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessBorrow)
        Me.pnlPermissionDetails.Controls.Add(Me.lblAccessStation)
        Me.pnlPermissionDetails.Location = New System.Drawing.Point(30, 150)
        Me.pnlPermissionDetails.Name = "pnlPermissionDetails"
        Me.pnlPermissionDetails.Size = New System.Drawing.Size(279, 211)
        Me.pnlPermissionDetails.TabIndex = 0
        '
        'lblPermissionName
        '
        Me.lblPermissionName.AutoEllipsis = True
        Me.lblPermissionName.BackColor = System.Drawing.Color.White
        Me.lblPermissionName.Location = New System.Drawing.Point(1, 1)
        Me.lblPermissionName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPermissionName.Name = "lblPermissionName"
        Me.lblPermissionName.Size = New System.Drawing.Size(277, 20)
        Me.lblPermissionName.TabIndex = 0
        Me.lblPermissionName.Text = "Permission name : "
        Me.lblPermissionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessUser
        '
        Me.lblAccessUser.AutoEllipsis = True
        Me.lblAccessUser.BackColor = System.Drawing.Color.White
        Me.lblAccessUser.Location = New System.Drawing.Point(1, 22)
        Me.lblAccessUser.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessUser.Name = "lblAccessUser"
        Me.lblAccessUser.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessUser.TabIndex = 0
        Me.lblAccessUser.Text = "Access user : "
        Me.lblAccessUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessPermission
        '
        Me.lblAccessPermission.AutoEllipsis = True
        Me.lblAccessPermission.BackColor = System.Drawing.Color.White
        Me.lblAccessPermission.Location = New System.Drawing.Point(1, 43)
        Me.lblAccessPermission.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessPermission.Name = "lblAccessPermission"
        Me.lblAccessPermission.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessPermission.TabIndex = 0
        Me.lblAccessPermission.Text = "Access permission : "
        Me.lblAccessPermission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessCustomer
        '
        Me.lblAccessCustomer.AutoEllipsis = True
        Me.lblAccessCustomer.BackColor = System.Drawing.Color.White
        Me.lblAccessCustomer.Location = New System.Drawing.Point(1, 64)
        Me.lblAccessCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessCustomer.Name = "lblAccessCustomer"
        Me.lblAccessCustomer.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessCustomer.TabIndex = 0
        Me.lblAccessCustomer.Text = "Access customer : "
        Me.lblAccessCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessItem
        '
        Me.lblAccessItem.AutoEllipsis = True
        Me.lblAccessItem.BackColor = System.Drawing.Color.White
        Me.lblAccessItem.Location = New System.Drawing.Point(1, 85)
        Me.lblAccessItem.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessItem.Name = "lblAccessItem"
        Me.lblAccessItem.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessItem.TabIndex = 0
        Me.lblAccessItem.Text = "Access item : "
        Me.lblAccessItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessInventory
        '
        Me.lblAccessInventory.AutoEllipsis = True
        Me.lblAccessInventory.BackColor = System.Drawing.Color.White
        Me.lblAccessInventory.Location = New System.Drawing.Point(1, 106)
        Me.lblAccessInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessInventory.Name = "lblAccessInventory"
        Me.lblAccessInventory.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessInventory.TabIndex = 0
        Me.lblAccessInventory.Text = "Access inventory : "
        Me.lblAccessInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessReservation
        '
        Me.lblAccessReservation.AutoEllipsis = True
        Me.lblAccessReservation.BackColor = System.Drawing.Color.White
        Me.lblAccessReservation.Location = New System.Drawing.Point(1, 127)
        Me.lblAccessReservation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessReservation.Name = "lblAccessReservation"
        Me.lblAccessReservation.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessReservation.TabIndex = 0
        Me.lblAccessReservation.Text = "Access reservation : "
        Me.lblAccessReservation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessConsume
        '
        Me.lblAccessConsume.AutoEllipsis = True
        Me.lblAccessConsume.BackColor = System.Drawing.Color.White
        Me.lblAccessConsume.Location = New System.Drawing.Point(1, 148)
        Me.lblAccessConsume.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessConsume.Name = "lblAccessConsume"
        Me.lblAccessConsume.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessConsume.TabIndex = 0
        Me.lblAccessConsume.Text = "Access consume : "
        Me.lblAccessConsume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessBorrow
        '
        Me.lblAccessBorrow.AutoEllipsis = True
        Me.lblAccessBorrow.BackColor = System.Drawing.Color.White
        Me.lblAccessBorrow.Location = New System.Drawing.Point(1, 169)
        Me.lblAccessBorrow.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessBorrow.Name = "lblAccessBorrow"
        Me.lblAccessBorrow.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessBorrow.TabIndex = 0
        Me.lblAccessBorrow.Text = "Access borrow : "
        Me.lblAccessBorrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessStation
        '
        Me.lblAccessStation.AutoEllipsis = True
        Me.lblAccessStation.BackColor = System.Drawing.Color.White
        Me.lblAccessStation.Location = New System.Drawing.Point(1, 190)
        Me.lblAccessStation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessStation.Name = "lblAccessStation"
        Me.lblAccessStation.Size = New System.Drawing.Size(277, 20)
        Me.lblAccessStation.TabIndex = 0
        Me.lblAccessStation.Text = "Access station : "
        Me.lblAccessStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUserID
        '
        Me.txtUserID.BackColor = System.Drawing.Color.White
        Me.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserID.ForeColor = System.Drawing.Color.Black
        Me.txtUserID.Location = New System.Drawing.Point(109, 30)
        Me.txtUserID.Margin = New System.Windows.Forms.Padding(0)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.ReadOnly = True
        Me.txtUserID.Size = New System.Drawing.Size(200, 25)
        Me.txtUserID.TabIndex = 0
        Me.txtUserID.TabStop = False
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(46, 33)
        Me.lblUserID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(55, 19)
        Me.lblUserID.TabIndex = 0
        Me.lblUserID.Text = "User ID"
        Me.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbtnActive
        '
        Me.sbtnActive.AutoEllipsis = True
        Me.sbtnActive.Location = New System.Drawing.Point(109, 90)
        Me.sbtnActive.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnActive.Name = "sbtnActive"
        Me.sbtnActive.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnActive.OnColor = System.Drawing.Color.Green
        Me.sbtnActive.Size = New System.Drawing.Size(200, 25)
        Me.sbtnActive.TabIndex = 0
        Me.sbtnActive.UseVisualStyleBackColor = True
        '
        'lblActive
        '
        Me.lblActive.AutoSize = True
        Me.lblActive.Location = New System.Drawing.Point(55, 93)
        Me.lblActive.Margin = New System.Windows.Forms.Padding(0)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(46, 19)
        Me.lblActive.TabIndex = 0
        Me.lblActive.Text = "Active"
        Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmEditUser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(339, 451)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblActive)
        Me.Controls.Add(Me.sbtnActive)
        Me.Controls.Add(Me.btnSelectPermission)
        Me.Controls.Add(Me.pnlPermissionDetails)
        Me.Controls.Add(Me.btnEdit)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditUser"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit User"
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPermissionDetails.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblUsername As Label
    Private WithEvents txtUsername As TextBox
    Private WithEvents err As ErrorProvider
    Private WithEvents btnEdit As Button
    Private WithEvents btnSelectPermission As Button
    Private WithEvents lblPermissionName As Label
    Private WithEvents lblAccessStation As Label
    Private WithEvents lblAccessBorrow As Label
    Private WithEvents lblAccessConsume As Label
    Private WithEvents lblAccessReservation As Label
    Private WithEvents lblAccessInventory As Label
    Private WithEvents lblAccessItem As Label
    Private WithEvents lblAccessCustomer As Label
    Private WithEvents lblAccessPermission As Label
    Private WithEvents lblAccessUser As Label
    Private WithEvents pnlPermissionDetails As Panel
    Private WithEvents lblUserID As Label
    Private WithEvents txtUserID As TextBox
    Private WithEvents sbtnActive As ctrlSwitch
    Private WithEvents lblActive As Label
End Class
