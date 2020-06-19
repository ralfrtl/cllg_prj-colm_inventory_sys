<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlUserCard
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
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblActive = New System.Windows.Forms.Label()
        Me.lblAccessUser = New System.Windows.Forms.Label()
        Me.lblAccessPermission = New System.Windows.Forms.Label()
        Me.lblAccessInventory = New System.Windows.Forms.Label()
        Me.lblAccessItem = New System.Windows.Forms.Label()
        Me.lblAccessBorrow = New System.Windows.Forms.Label()
        Me.lblAccessConsume = New System.Windows.Forms.Label()
        Me.lblAccessCustomer = New System.Windows.Forms.Label()
        Me.lblAccessReservation = New System.Windows.Forms.Label()
        Me.lblAccessStation = New System.Windows.Forms.Label()
        Me.lblPermissionName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblUsername
        '
        Me.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblUsername.AutoEllipsis = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.Green
        Me.lblUsername.Location = New System.Drawing.Point(25, 25)
        Me.lblUsername.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(320, 30)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username#UserID"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblActive
        '
        Me.lblActive.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblActive.AutoEllipsis = True
        Me.lblActive.Location = New System.Drawing.Point(25, 55)
        Me.lblActive.Margin = New System.Windows.Forms.Padding(0)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(320, 20)
        Me.lblActive.TabIndex = 0
        Me.lblActive.Text = "Active"
        Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessUser
        '
        Me.lblAccessUser.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessUser.AutoEllipsis = True
        Me.lblAccessUser.Location = New System.Drawing.Point(355, 30)
        Me.lblAccessUser.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessUser.Name = "lblAccessUser"
        Me.lblAccessUser.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessUser.TabIndex = 0
        Me.lblAccessUser.Text = "Access user"
        Me.lblAccessUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessPermission
        '
        Me.lblAccessPermission.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessPermission.AutoEllipsis = True
        Me.lblAccessPermission.Location = New System.Drawing.Point(355, 50)
        Me.lblAccessPermission.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessPermission.Name = "lblAccessPermission"
        Me.lblAccessPermission.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessPermission.TabIndex = 0
        Me.lblAccessPermission.Text = "Access permission"
        Me.lblAccessPermission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessInventory
        '
        Me.lblAccessInventory.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessInventory.AutoEllipsis = True
        Me.lblAccessInventory.Location = New System.Drawing.Point(515, 50)
        Me.lblAccessInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessInventory.Name = "lblAccessInventory"
        Me.lblAccessInventory.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessInventory.TabIndex = 0
        Me.lblAccessInventory.Text = "Access inventory"
        Me.lblAccessInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessItem
        '
        Me.lblAccessItem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessItem.AutoEllipsis = True
        Me.lblAccessItem.Location = New System.Drawing.Point(515, 30)
        Me.lblAccessItem.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessItem.Name = "lblAccessItem"
        Me.lblAccessItem.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessItem.TabIndex = 0
        Me.lblAccessItem.Text = "Access item"
        Me.lblAccessItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessBorrow
        '
        Me.lblAccessBorrow.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessBorrow.AutoEllipsis = True
        Me.lblAccessBorrow.Location = New System.Drawing.Point(675, 50)
        Me.lblAccessBorrow.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessBorrow.Name = "lblAccessBorrow"
        Me.lblAccessBorrow.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessBorrow.TabIndex = 0
        Me.lblAccessBorrow.Text = "Access borrow"
        Me.lblAccessBorrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessConsume
        '
        Me.lblAccessConsume.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessConsume.AutoEllipsis = True
        Me.lblAccessConsume.Location = New System.Drawing.Point(675, 30)
        Me.lblAccessConsume.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessConsume.Name = "lblAccessConsume"
        Me.lblAccessConsume.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessConsume.TabIndex = 0
        Me.lblAccessConsume.Text = "Access consume"
        Me.lblAccessConsume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessCustomer
        '
        Me.lblAccessCustomer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessCustomer.AutoEllipsis = True
        Me.lblAccessCustomer.Location = New System.Drawing.Point(355, 70)
        Me.lblAccessCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessCustomer.Name = "lblAccessCustomer"
        Me.lblAccessCustomer.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessCustomer.TabIndex = 0
        Me.lblAccessCustomer.Text = "Access customer"
        Me.lblAccessCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessReservation
        '
        Me.lblAccessReservation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessReservation.AutoEllipsis = True
        Me.lblAccessReservation.Location = New System.Drawing.Point(515, 70)
        Me.lblAccessReservation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessReservation.Name = "lblAccessReservation"
        Me.lblAccessReservation.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessReservation.TabIndex = 0
        Me.lblAccessReservation.Text = "Access reservation"
        Me.lblAccessReservation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccessStation
        '
        Me.lblAccessStation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccessStation.AutoEllipsis = True
        Me.lblAccessStation.Location = New System.Drawing.Point(675, 70)
        Me.lblAccessStation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAccessStation.Name = "lblAccessStation"
        Me.lblAccessStation.Size = New System.Drawing.Size(150, 20)
        Me.lblAccessStation.TabIndex = 0
        Me.lblAccessStation.Text = "Access station"
        Me.lblAccessStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPermissionName
        '
        Me.lblPermissionName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPermissionName.AutoEllipsis = True
        Me.lblPermissionName.Location = New System.Drawing.Point(25, 75)
        Me.lblPermissionName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPermissionName.Name = "lblPermissionName"
        Me.lblPermissionName.Size = New System.Drawing.Size(320, 20)
        Me.lblPermissionName.TabIndex = 0
        Me.lblPermissionName.Text = "Permission name :"
        Me.lblPermissionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctrlUserCard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblActive)
        Me.Controls.Add(Me.lblPermissionName)
        Me.Controls.Add(Me.lblAccessUser)
        Me.Controls.Add(Me.lblAccessPermission)
        Me.Controls.Add(Me.lblAccessCustomer)
        Me.Controls.Add(Me.lblAccessItem)
        Me.Controls.Add(Me.lblAccessInventory)
        Me.Controls.Add(Me.lblAccessReservation)
        Me.Controls.Add(Me.lblAccessConsume)
        Me.Controls.Add(Me.lblAccessBorrow)
        Me.Controls.Add(Me.lblAccessStation)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlUserCard"
        Me.Size = New System.Drawing.Size(850, 120)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents lblUsername As Label
    Private WithEvents lblActive As Label
    Private WithEvents lblAccessUser As Label
    Private WithEvents lblAccessPermission As Label
    Private WithEvents lblAccessInventory As Label
    Private WithEvents lblAccessItem As Label
    Private WithEvents lblAccessBorrow As Label
    Private WithEvents lblAccessConsume As Label
    Private WithEvents lblAccessCustomer As Label
    Private WithEvents lblAccessReservation As Label
    Private WithEvents lblAccessStation As Label
    Private WithEvents lblPermissionName As Label
End Class
