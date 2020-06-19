<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddPermission
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
        Me.lblPermissionName = New System.Windows.Forms.Label()
        Me.txtPermissionName = New System.Windows.Forms.TextBox()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.sbtnAccessUser = New COLM_Inventory.ctrlSwitch()
        Me.sbtnAccessPermission = New COLM_Inventory.ctrlSwitch()
        Me.sbtnAccessCustomer = New COLM_Inventory.ctrlSwitch()
        Me.sbtnAccessItem = New COLM_Inventory.ctrlSwitch()
        Me.sbtnAccessInventory = New COLM_Inventory.ctrlSwitch()
        Me.sbtnAccessReservation = New COLM_Inventory.ctrlSwitch()
        Me.sbtnAccessConsume = New COLM_Inventory.ctrlSwitch()
        Me.sbtnAccessBorrow = New COLM_Inventory.ctrlSwitch()
        Me.sbtnAccessStation = New COLM_Inventory.ctrlSwitch()
        Me.lblAccessUser = New System.Windows.Forms.Label()
        Me.lblAccessPermission = New System.Windows.Forms.Label()
        Me.lblAccessCustomer = New System.Windows.Forms.Label()
        Me.lblAccessItem = New System.Windows.Forms.Label()
        Me.lblAccessInventory = New System.Windows.Forms.Label()
        Me.lblAccessReservation = New System.Windows.Forms.Label()
        Me.lblAccessConsume = New System.Windows.Forms.Label()
        Me.lblAccessBorrow = New System.Windows.Forms.Label()
        Me.lblAccessStation = New System.Windows.Forms.Label()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPermissionName
        '
        Me.lblPermissionName.AutoSize = True
        Me.lblPermissionName.Location = New System.Drawing.Point(39, 33)
        Me.lblPermissionName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPermissionName.Name = "lblPermissionName"
        Me.lblPermissionName.Size = New System.Drawing.Size(112, 19)
        Me.lblPermissionName.TabIndex = 0
        Me.lblPermissionName.Text = "Permission name"
        Me.lblPermissionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPermissionName
        '
        Me.txtPermissionName.BackColor = System.Drawing.Color.White
        Me.txtPermissionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPermissionName.ForeColor = System.Drawing.Color.Black
        Me.txtPermissionName.Location = New System.Drawing.Point(159, 30)
        Me.txtPermissionName.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPermissionName.MaxLength = 50
        Me.txtPermissionName.Name = "txtPermissionName"
        Me.txtPermissionName.Size = New System.Drawing.Size(200, 25)
        Me.txtPermissionName.TabIndex = 0
        '
        'err
        '
        Me.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.err.ContainerControl = Me
        '
        'btnAdd
        '
        Me.btnAdd.AutoEllipsis = True
        Me.btnAdd.BackColor = System.Drawing.Color.Green
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(259, 355)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'sbtnAccessUser
        '
        Me.sbtnAccessUser.AutoEllipsis = True
        Me.sbtnAccessUser.Location = New System.Drawing.Point(159, 60)
        Me.sbtnAccessUser.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessUser.Name = "sbtnAccessUser"
        Me.sbtnAccessUser.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessUser.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessUser.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessUser.TabIndex = 1
        Me.sbtnAccessUser.UseVisualStyleBackColor = False
        '
        'sbtnAccessPermission
        '
        Me.sbtnAccessPermission.AutoEllipsis = True
        Me.sbtnAccessPermission.Location = New System.Drawing.Point(159, 90)
        Me.sbtnAccessPermission.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessPermission.Name = "sbtnAccessPermission"
        Me.sbtnAccessPermission.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessPermission.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessPermission.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessPermission.TabIndex = 2
        Me.sbtnAccessPermission.UseVisualStyleBackColor = False
        '
        'sbtnAccessCustomer
        '
        Me.sbtnAccessCustomer.AutoEllipsis = True
        Me.sbtnAccessCustomer.Location = New System.Drawing.Point(159, 120)
        Me.sbtnAccessCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessCustomer.Name = "sbtnAccessCustomer"
        Me.sbtnAccessCustomer.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessCustomer.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessCustomer.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessCustomer.TabIndex = 3
        Me.sbtnAccessCustomer.UseVisualStyleBackColor = False
        '
        'sbtnAccessItem
        '
        Me.sbtnAccessItem.AutoEllipsis = True
        Me.sbtnAccessItem.Location = New System.Drawing.Point(159, 150)
        Me.sbtnAccessItem.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessItem.Name = "sbtnAccessItem"
        Me.sbtnAccessItem.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessItem.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessItem.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessItem.TabIndex = 4
        Me.sbtnAccessItem.UseVisualStyleBackColor = False
        '
        'sbtnAccessInventory
        '
        Me.sbtnAccessInventory.AutoEllipsis = True
        Me.sbtnAccessInventory.Location = New System.Drawing.Point(159, 180)
        Me.sbtnAccessInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessInventory.Name = "sbtnAccessInventory"
        Me.sbtnAccessInventory.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessInventory.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessInventory.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessInventory.TabIndex = 5
        Me.sbtnAccessInventory.UseVisualStyleBackColor = False
        '
        'sbtnAccessReservation
        '
        Me.sbtnAccessReservation.AutoEllipsis = True
        Me.sbtnAccessReservation.Location = New System.Drawing.Point(159, 210)
        Me.sbtnAccessReservation.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessReservation.Name = "sbtnAccessReservation"
        Me.sbtnAccessReservation.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessReservation.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessReservation.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessReservation.TabIndex = 6
        Me.sbtnAccessReservation.UseVisualStyleBackColor = False
        '
        'sbtnAccessConsume
        '
        Me.sbtnAccessConsume.AutoEllipsis = True
        Me.sbtnAccessConsume.Location = New System.Drawing.Point(159, 240)
        Me.sbtnAccessConsume.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessConsume.Name = "sbtnAccessConsume"
        Me.sbtnAccessConsume.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessConsume.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessConsume.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessConsume.TabIndex = 7
        Me.sbtnAccessConsume.UseVisualStyleBackColor = False
        '
        'sbtnAccessBorrow
        '
        Me.sbtnAccessBorrow.AutoEllipsis = True
        Me.sbtnAccessBorrow.Location = New System.Drawing.Point(159, 270)
        Me.sbtnAccessBorrow.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessBorrow.Name = "sbtnAccessBorrow"
        Me.sbtnAccessBorrow.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessBorrow.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessBorrow.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessBorrow.TabIndex = 8
        Me.sbtnAccessBorrow.UseVisualStyleBackColor = False
        '
        'sbtnAccessStation
        '
        Me.sbtnAccessStation.AutoEllipsis = True
        Me.sbtnAccessStation.Location = New System.Drawing.Point(159, 300)
        Me.sbtnAccessStation.Margin = New System.Windows.Forms.Padding(0)
        Me.sbtnAccessStation.Name = "sbtnAccessStation"
        Me.sbtnAccessStation.OffColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.sbtnAccessStation.OnColor = System.Drawing.Color.Green
        Me.sbtnAccessStation.Size = New System.Drawing.Size(200, 25)
        Me.sbtnAccessStation.TabIndex = 9
        Me.sbtnAccessStation.UseVisualStyleBackColor = False
        '
        'lblAccessUser
        '
        Me.lblAccessUser.AutoSize = True
        Me.lblAccessUser.Location = New System.Drawing.Point(72, 63)
        Me.lblAccessUser.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessUser.Name = "lblAccessUser"
        Me.lblAccessUser.Size = New System.Drawing.Size(79, 19)
        Me.lblAccessUser.TabIndex = 0
        Me.lblAccessUser.Text = "Access user"
        Me.lblAccessUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessPermission
        '
        Me.lblAccessPermission.AutoSize = True
        Me.lblAccessPermission.Location = New System.Drawing.Point(32, 93)
        Me.lblAccessPermission.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessPermission.Name = "lblAccessPermission"
        Me.lblAccessPermission.Size = New System.Drawing.Size(119, 19)
        Me.lblAccessPermission.TabIndex = 0
        Me.lblAccessPermission.Text = "Access permission"
        Me.lblAccessPermission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessCustomer
        '
        Me.lblAccessCustomer.AutoSize = True
        Me.lblAccessCustomer.Location = New System.Drawing.Point(41, 123)
        Me.lblAccessCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessCustomer.Name = "lblAccessCustomer"
        Me.lblAccessCustomer.Size = New System.Drawing.Size(110, 19)
        Me.lblAccessCustomer.TabIndex = 0
        Me.lblAccessCustomer.Text = "Access customer"
        Me.lblAccessCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessItem
        '
        Me.lblAccessItem.AutoSize = True
        Me.lblAccessItem.Location = New System.Drawing.Point(71, 153)
        Me.lblAccessItem.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessItem.Name = "lblAccessItem"
        Me.lblAccessItem.Size = New System.Drawing.Size(80, 19)
        Me.lblAccessItem.TabIndex = 0
        Me.lblAccessItem.Text = "Access item"
        Me.lblAccessItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessInventory
        '
        Me.lblAccessInventory.AutoSize = True
        Me.lblAccessInventory.Location = New System.Drawing.Point(40, 183)
        Me.lblAccessInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessInventory.Name = "lblAccessInventory"
        Me.lblAccessInventory.Size = New System.Drawing.Size(111, 19)
        Me.lblAccessInventory.TabIndex = 0
        Me.lblAccessInventory.Text = "Access inventory"
        Me.lblAccessInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessReservation
        '
        Me.lblAccessReservation.AutoSize = True
        Me.lblAccessReservation.Location = New System.Drawing.Point(30, 213)
        Me.lblAccessReservation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessReservation.Name = "lblAccessReservation"
        Me.lblAccessReservation.Size = New System.Drawing.Size(121, 19)
        Me.lblAccessReservation.TabIndex = 0
        Me.lblAccessReservation.Text = "Access reservation"
        Me.lblAccessReservation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessConsume
        '
        Me.lblAccessConsume.AutoSize = True
        Me.lblAccessConsume.Location = New System.Drawing.Point(43, 243)
        Me.lblAccessConsume.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessConsume.Name = "lblAccessConsume"
        Me.lblAccessConsume.Size = New System.Drawing.Size(108, 19)
        Me.lblAccessConsume.TabIndex = 0
        Me.lblAccessConsume.Text = "Access consume"
        Me.lblAccessConsume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessBorrow
        '
        Me.lblAccessBorrow.AutoSize = True
        Me.lblAccessBorrow.Location = New System.Drawing.Point(54, 273)
        Me.lblAccessBorrow.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessBorrow.Name = "lblAccessBorrow"
        Me.lblAccessBorrow.Size = New System.Drawing.Size(97, 19)
        Me.lblAccessBorrow.TabIndex = 0
        Me.lblAccessBorrow.Text = "Access borrow"
        Me.lblAccessBorrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessStation
        '
        Me.lblAccessStation.AutoSize = True
        Me.lblAccessStation.Location = New System.Drawing.Point(56, 303)
        Me.lblAccessStation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessStation.Name = "lblAccessStation"
        Me.lblAccessStation.Size = New System.Drawing.Size(95, 19)
        Me.lblAccessStation.TabIndex = 0
        Me.lblAccessStation.Text = "Access station"
        Me.lblAccessStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAddPermission
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(389, 415)
        Me.Controls.Add(Me.lblPermissionName)
        Me.Controls.Add(Me.txtPermissionName)
        Me.Controls.Add(Me.lblAccessUser)
        Me.Controls.Add(Me.sbtnAccessUser)
        Me.Controls.Add(Me.lblAccessPermission)
        Me.Controls.Add(Me.sbtnAccessPermission)
        Me.Controls.Add(Me.lblAccessCustomer)
        Me.Controls.Add(Me.sbtnAccessCustomer)
        Me.Controls.Add(Me.lblAccessItem)
        Me.Controls.Add(Me.sbtnAccessItem)
        Me.Controls.Add(Me.lblAccessInventory)
        Me.Controls.Add(Me.sbtnAccessInventory)
        Me.Controls.Add(Me.lblAccessReservation)
        Me.Controls.Add(Me.sbtnAccessReservation)
        Me.Controls.Add(Me.lblAccessConsume)
        Me.Controls.Add(Me.sbtnAccessConsume)
        Me.Controls.Add(Me.lblAccessBorrow)
        Me.Controls.Add(Me.sbtnAccessBorrow)
        Me.Controls.Add(Me.lblAccessStation)
        Me.Controls.Add(Me.sbtnAccessStation)
        Me.Controls.Add(Me.btnAdd)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddPermission"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Permission"
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblPermissionName As Label
    Private WithEvents txtPermissionName As TextBox
    Private WithEvents err As ErrorProvider
    Private WithEvents btnAdd As Button
    Private WithEvents sbtnAccessStation As ctrlSwitch
    Private WithEvents sbtnAccessBorrow As ctrlSwitch
    Private WithEvents sbtnAccessConsume As ctrlSwitch
    Private WithEvents sbtnAccessReservation As ctrlSwitch
    Private WithEvents sbtnAccessInventory As ctrlSwitch
    Private WithEvents sbtnAccessItem As ctrlSwitch
    Private WithEvents sbtnAccessCustomer As ctrlSwitch
    Private WithEvents sbtnAccessPermission As ctrlSwitch
    Private WithEvents sbtnAccessUser As ctrlSwitch
    Private WithEvents lblAccessStation As Label
    Private WithEvents lblAccessBorrow As Label
    Private WithEvents lblAccessConsume As Label
    Private WithEvents lblAccessReservation As Label
    Private WithEvents lblAccessInventory As Label
    Private WithEvents lblAccessItem As Label
    Private WithEvents lblAccessCustomer As Label
    Private WithEvents lblAccessPermission As Label
    Private WithEvents lblAccessUser As Label
End Class
