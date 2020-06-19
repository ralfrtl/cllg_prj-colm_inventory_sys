<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHome
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
        Me.pnlNoConnection = New System.Windows.Forms.Panel()
        Me.lblNoConnection = New System.Windows.Forms.Label()
        Me.tbContainer = New COLM_Inventory.ctrlTabControl()
        Me.tbpgDashboard = New System.Windows.Forms.TabPage()
        Me.ctrlDashboardContent = New COLM_Inventory.ctrlDashboard()
        Me.tbpgItemAndInventory = New System.Windows.Forms.TabPage()
        Me.ctrlItemContent = New COLM_Inventory.ctrlItem()
        Me.tbpgCustomer = New System.Windows.Forms.TabPage()
        Me.ctrlCustomerContent = New COLM_Inventory.ctrlCustomer()
        Me.tbpgUser = New System.Windows.Forms.TabPage()
        Me.ctrlUserContent = New COLM_Inventory.ctrlUser()
        Me.tbpgPermission = New System.Windows.Forms.TabPage()
        Me.ctrlPermissionContent = New COLM_Inventory.ctrlPermission()
        Me.tbpgActivityLog = New System.Windows.Forms.TabPage()
        Me.ctrlActivityLogContent = New COLM_Inventory.ctrlActivityLog()
        Me.pnlNoConnection.SuspendLayout()
        Me.tbContainer.SuspendLayout()
        Me.tbpgDashboard.SuspendLayout()
        Me.tbpgItemAndInventory.SuspendLayout()
        Me.tbpgCustomer.SuspendLayout()
        Me.tbpgUser.SuspendLayout()
        Me.tbpgPermission.SuspendLayout()
        Me.tbpgActivityLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlNoConnection
        '
        Me.pnlNoConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlNoConnection.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.pnlNoConnection.Controls.Add(Me.lblNoConnection)
        Me.pnlNoConnection.ForeColor = System.Drawing.Color.White
        Me.pnlNoConnection.Location = New System.Drawing.Point(20, 511)
        Me.pnlNoConnection.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNoConnection.Name = "pnlNoConnection"
        Me.pnlNoConnection.Size = New System.Drawing.Size(860, 30)
        Me.pnlNoConnection.TabIndex = 0
        Me.pnlNoConnection.Visible = False
        '
        'lblNoConnection
        '
        Me.lblNoConnection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoConnection.ForeColor = System.Drawing.Color.White
        Me.lblNoConnection.Location = New System.Drawing.Point(0, 0)
        Me.lblNoConnection.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNoConnection.Name = "lblNoConnection"
        Me.lblNoConnection.Size = New System.Drawing.Size(860, 30)
        Me.lblNoConnection.TabIndex = 0
        Me.lblNoConnection.Text = "No connection."
        Me.lblNoConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoConnection.UseCompatibleTextRendering = True
        '
        'tbContainer
        '
        Me.tbContainer.ActiveBGColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tbContainer.ActiveFGColor = System.Drawing.Color.White
        Me.tbContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbContainer.BodyColor = System.Drawing.Color.White
        Me.tbContainer.Controls.Add(Me.tbpgDashboard)
        Me.tbContainer.Controls.Add(Me.tbpgItemAndInventory)
        Me.tbContainer.Controls.Add(Me.tbpgCustomer)
        Me.tbContainer.Controls.Add(Me.tbpgUser)
        Me.tbContainer.Controls.Add(Me.tbpgPermission)
        Me.tbContainer.Controls.Add(Me.tbpgActivityLog)
        Me.tbContainer.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.tbContainer.HeaderColor = System.Drawing.Color.White
        Me.tbContainer.HotTrack = True
        Me.tbContainer.HoverBGColor = System.Drawing.Color.Green
        Me.tbContainer.HoverFGColor = System.Drawing.Color.White
        Me.tbContainer.InActiveBGColor = System.Drawing.Color.White
        Me.tbContainer.InActiveFGColor = System.Drawing.Color.Green
        Me.tbContainer.ItemSize = New System.Drawing.Size(0, 30)
        Me.tbContainer.Location = New System.Drawing.Point(-4, 0)
        Me.tbContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.tbContainer.Name = "tbContainer"
        Me.tbContainer.Padding = New System.Drawing.Point(15, 0)
        Me.tbContainer.SelectedIndex = 0
        Me.tbContainer.Size = New System.Drawing.Size(908, 564)
        Me.tbContainer.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.tbContainer.TabIndex = 0
        '
        'tbpgDashboard
        '
        Me.tbpgDashboard.BackColor = System.Drawing.Color.White
        Me.tbpgDashboard.Controls.Add(Me.ctrlDashboardContent)
        Me.tbpgDashboard.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgDashboard.Location = New System.Drawing.Point(4, 34)
        Me.tbpgDashboard.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgDashboard.Name = "tbpgDashboard"
        Me.tbpgDashboard.Size = New System.Drawing.Size(900, 526)
        Me.tbpgDashboard.TabIndex = 0
        Me.tbpgDashboard.Text = "Dashboard"
        '
        'ctrlDashboardContent
        '
        Me.ctrlDashboardContent.BackColor = System.Drawing.Color.White
        Me.ctrlDashboardContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlDashboardContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlDashboardContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlDashboardContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlDashboardContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlDashboardContent.Name = "ctrlDashboardContent"
        Me.ctrlDashboardContent.Size = New System.Drawing.Size(900, 526)
        Me.ctrlDashboardContent.TabIndex = 0
        Me.ctrlDashboardContent.TabStop = False
        '
        'tbpgItemAndInventory
        '
        Me.tbpgItemAndInventory.BackColor = System.Drawing.Color.White
        Me.tbpgItemAndInventory.Controls.Add(Me.ctrlItemContent)
        Me.tbpgItemAndInventory.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgItemAndInventory.Location = New System.Drawing.Point(4, 34)
        Me.tbpgItemAndInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgItemAndInventory.Name = "tbpgItemAndInventory"
        Me.tbpgItemAndInventory.Size = New System.Drawing.Size(900, 526)
        Me.tbpgItemAndInventory.TabIndex = 1
        Me.tbpgItemAndInventory.Text = "Item and Inventory"
        '
        'ctrlItemContent
        '
        Me.ctrlItemContent.BackColor = System.Drawing.Color.White
        Me.ctrlItemContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlItemContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlItemContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlItemContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlItemContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlItemContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlItemContent.Name = "ctrlItemContent"
        Me.ctrlItemContent.Size = New System.Drawing.Size(900, 526)
        Me.ctrlItemContent.TabIndex = 0
        '
        'tbpgCustomer
        '
        Me.tbpgCustomer.BackColor = System.Drawing.Color.White
        Me.tbpgCustomer.Controls.Add(Me.ctrlCustomerContent)
        Me.tbpgCustomer.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgCustomer.Location = New System.Drawing.Point(4, 34)
        Me.tbpgCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgCustomer.Name = "tbpgCustomer"
        Me.tbpgCustomer.Size = New System.Drawing.Size(900, 526)
        Me.tbpgCustomer.TabIndex = 3
        Me.tbpgCustomer.Text = "Customer"
        '
        'ctrlCustomerContent
        '
        Me.ctrlCustomerContent.BackColor = System.Drawing.Color.White
        Me.ctrlCustomerContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlCustomerContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlCustomerContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlCustomerContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlCustomerContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlCustomerContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlCustomerContent.Name = "ctrlCustomerContent"
        Me.ctrlCustomerContent.Size = New System.Drawing.Size(900, 526)
        Me.ctrlCustomerContent.TabIndex = 0
        '
        'tbpgUser
        '
        Me.tbpgUser.BackColor = System.Drawing.Color.White
        Me.tbpgUser.Controls.Add(Me.ctrlUserContent)
        Me.tbpgUser.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgUser.Location = New System.Drawing.Point(4, 34)
        Me.tbpgUser.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgUser.Name = "tbpgUser"
        Me.tbpgUser.Size = New System.Drawing.Size(900, 526)
        Me.tbpgUser.TabIndex = 5
        Me.tbpgUser.Text = "User"
        '
        'ctrlUserContent
        '
        Me.ctrlUserContent.BackColor = System.Drawing.Color.White
        Me.ctrlUserContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlUserContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlUserContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlUserContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlUserContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlUserContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlUserContent.Name = "ctrlUserContent"
        Me.ctrlUserContent.Size = New System.Drawing.Size(900, 526)
        Me.ctrlUserContent.TabIndex = 0
        '
        'tbpgPermission
        '
        Me.tbpgPermission.BackColor = System.Drawing.Color.White
        Me.tbpgPermission.Controls.Add(Me.ctrlPermissionContent)
        Me.tbpgPermission.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgPermission.Location = New System.Drawing.Point(4, 34)
        Me.tbpgPermission.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgPermission.Name = "tbpgPermission"
        Me.tbpgPermission.Size = New System.Drawing.Size(900, 526)
        Me.tbpgPermission.TabIndex = 6
        Me.tbpgPermission.Text = "Permission"
        '
        'ctrlPermissionContent
        '
        Me.ctrlPermissionContent.BackColor = System.Drawing.Color.White
        Me.ctrlPermissionContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlPermissionContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlPermissionContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlPermissionContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlPermissionContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlPermissionContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlPermissionContent.Name = "ctrlPermissionContent"
        Me.ctrlPermissionContent.Size = New System.Drawing.Size(900, 526)
        Me.ctrlPermissionContent.TabIndex = 0
        '
        'tbpgActivityLog
        '
        Me.tbpgActivityLog.BackColor = System.Drawing.Color.White
        Me.tbpgActivityLog.Controls.Add(Me.ctrlActivityLogContent)
        Me.tbpgActivityLog.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgActivityLog.Location = New System.Drawing.Point(4, 34)
        Me.tbpgActivityLog.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgActivityLog.Name = "tbpgActivityLog"
        Me.tbpgActivityLog.Size = New System.Drawing.Size(900, 526)
        Me.tbpgActivityLog.TabIndex = 4
        Me.tbpgActivityLog.Text = "Activity Log"
        '
        'ctrlActivityLogContent
        '
        Me.ctrlActivityLogContent.BackColor = System.Drawing.Color.White
        Me.ctrlActivityLogContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlActivityLogContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlActivityLogContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlActivityLogContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlActivityLogContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlActivityLogContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlActivityLogContent.Name = "ctrlActivityLogContent"
        Me.ctrlActivityLogContent.Size = New System.Drawing.Size(900, 526)
        Me.ctrlActivityLogContent.TabIndex = 0
        '
        'frmHome
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(900, 560)
        Me.Controls.Add(Me.pnlNoConnection)
        Me.Controls.Add(Me.tbContainer)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MinimumSize = New System.Drawing.Size(350, 100)
        Me.Name = "frmHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Management"
        Me.pnlNoConnection.ResumeLayout(False)
        Me.tbContainer.ResumeLayout(False)
        Me.tbpgDashboard.ResumeLayout(False)
        Me.tbpgItemAndInventory.ResumeLayout(False)
        Me.tbpgCustomer.ResumeLayout(False)
        Me.tbpgUser.ResumeLayout(False)
        Me.tbpgPermission.ResumeLayout(False)
        Me.tbpgActivityLog.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents tbContainer As ctrlTabControl
    Private WithEvents tbpgDashboard As TabPage
    Private WithEvents tbpgItemAndInventory As TabPage
    Private WithEvents ctrlDashboardContent As ctrlDashboard
    Private WithEvents pnlNoConnection As Panel
    Private WithEvents lblNoConnection As Label
    Private WithEvents ctrlItemContent As ctrlItem
    Private WithEvents tbpgCustomer As TabPage
    Private WithEvents ctrlCustomerContent As ctrlCustomer
    Private WithEvents tbpgUser As TabPage
    Private WithEvents tbpgActivityLog As TabPage
    Private WithEvents tbpgPermission As TabPage
    Private WithEvents ctrlUserContent As ctrlUser
    Private WithEvents ctrlPermissionContent As ctrlPermission
    Private WithEvents ctrlActivityLogContent As ctrlActivityLog
End Class
