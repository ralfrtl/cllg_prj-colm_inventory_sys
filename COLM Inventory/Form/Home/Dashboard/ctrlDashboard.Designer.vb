<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDashboard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pnlRibbon = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.fpnlQuantity = New System.Windows.Forms.FlowLayoutPanel()
        Me.fpnlUsage = New System.Windows.Forms.FlowLayoutPanel()
        Me.fpnlThreshold = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblThreshold = New System.Windows.Forms.Label()
        Me.lblUsage = New System.Windows.Forms.Label()
        Me.fpnlCardList = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.crdItem = New COLM_Inventory.ctrlDashboardCard()
        Me.crdInventory = New COLM_Inventory.ctrlDashboardCard()
        Me.crdAsset = New COLM_Inventory.ctrlDashboardCard()
        Me.crdAssetBulk = New COLM_Inventory.ctrlDashboardCard()
        Me.crdConsumable = New COLM_Inventory.ctrlDashboardCard()
        Me.crdReserved = New COLM_Inventory.ctrlDashboardCard()
        Me.crdBorrowed = New COLM_Inventory.ctrlDashboardCard()
        Me.crdStationed = New COLM_Inventory.ctrlDashboardCard()
        Me.crdLow = New COLM_Inventory.ctrlDashboardCard()
        Me.crdOut = New COLM_Inventory.ctrlDashboardCard()
        Me.pnlRibbon.SuspendLayout()
        Me.fpnlQuantity.SuspendLayout()
        Me.fpnlUsage.SuspendLayout()
        Me.fpnlThreshold.SuspendLayout()
        Me.fpnlCardList.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlRibbon
        '
        Me.pnlRibbon.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlRibbon.Controls.Add(Me.btnRefresh)
        Me.pnlRibbon.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRibbon.ForeColor = System.Drawing.Color.White
        Me.pnlRibbon.Location = New System.Drawing.Point(0, 0)
        Me.pnlRibbon.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRibbon.Name = "pnlRibbon"
        Me.pnlRibbon.Size = New System.Drawing.Size(900, 40)
        Me.pnlRibbon.TabIndex = 0
        Me.pnlRibbon.TabStop = True
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImage = Global.COLM_Inventory.My.Resources.Resources.Refresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(5, 5)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(30, 30)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'fpnlQuantity
        '
        Me.fpnlQuantity.AutoSize = True
        Me.fpnlQuantity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fpnlQuantity.Controls.Add(Me.crdItem)
        Me.fpnlQuantity.Controls.Add(Me.crdInventory)
        Me.fpnlQuantity.Controls.Add(Me.crdAsset)
        Me.fpnlQuantity.Controls.Add(Me.crdAssetBulk)
        Me.fpnlQuantity.Controls.Add(Me.crdConsumable)
        Me.fpnlQuantity.Location = New System.Drawing.Point(0, 64)
        Me.fpnlQuantity.Margin = New System.Windows.Forms.Padding(0)
        Me.fpnlQuantity.Name = "fpnlQuantity"
        Me.fpnlQuantity.Size = New System.Drawing.Size(630, 420)
        Me.fpnlQuantity.TabIndex = 0
        '
        'fpnlUsage
        '
        Me.fpnlUsage.AutoSize = True
        Me.fpnlUsage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fpnlUsage.Controls.Add(Me.crdReserved)
        Me.fpnlUsage.Controls.Add(Me.crdBorrowed)
        Me.fpnlUsage.Controls.Add(Me.crdStationed)
        Me.fpnlUsage.Location = New System.Drawing.Point(0, 548)
        Me.fpnlUsage.Margin = New System.Windows.Forms.Padding(0)
        Me.fpnlUsage.Name = "fpnlUsage"
        Me.fpnlUsage.Size = New System.Drawing.Size(630, 280)
        Me.fpnlUsage.TabIndex = 0
        '
        'fpnlThreshold
        '
        Me.fpnlThreshold.AutoSize = True
        Me.fpnlThreshold.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.fpnlThreshold.Controls.Add(Me.crdLow)
        Me.fpnlThreshold.Controls.Add(Me.crdOut)
        Me.fpnlThreshold.Location = New System.Drawing.Point(0, 892)
        Me.fpnlThreshold.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.fpnlThreshold.Name = "fpnlThreshold"
        Me.fpnlThreshold.Size = New System.Drawing.Size(630, 140)
        Me.fpnlThreshold.TabIndex = 0
        '
        'lblThreshold
        '
        Me.lblThreshold.AutoSize = True
        Me.lblThreshold.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblThreshold.Font = New System.Drawing.Font("Segoe UI", 30.0!)
        Me.lblThreshold.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblThreshold.Location = New System.Drawing.Point(0, 838)
        Me.lblThreshold.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblThreshold.MaximumSize = New System.Drawing.Size(330, 0)
        Me.lblThreshold.MinimumSize = New System.Drawing.Size(330, 0)
        Me.lblThreshold.Name = "lblThreshold"
        Me.lblThreshold.Size = New System.Drawing.Size(330, 54)
        Me.lblThreshold.TabIndex = 0
        Me.lblThreshold.Text = "Threshold"
        Me.lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUsage
        '
        Me.lblUsage.AutoSize = True
        Me.lblUsage.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblUsage.Font = New System.Drawing.Font("Segoe UI", 30.0!)
        Me.lblUsage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUsage.Location = New System.Drawing.Point(0, 494)
        Me.lblUsage.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblUsage.MaximumSize = New System.Drawing.Size(330, 0)
        Me.lblUsage.MinimumSize = New System.Drawing.Size(330, 0)
        Me.lblUsage.Name = "lblUsage"
        Me.lblUsage.Size = New System.Drawing.Size(330, 54)
        Me.lblUsage.TabIndex = 0
        Me.lblUsage.Text = "Usage"
        Me.lblUsage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fpnlCardList
        '
        Me.fpnlCardList.AutoScroll = True
        Me.fpnlCardList.Controls.Add(Me.lblQuantity)
        Me.fpnlCardList.Controls.Add(Me.fpnlQuantity)
        Me.fpnlCardList.Controls.Add(Me.lblUsage)
        Me.fpnlCardList.Controls.Add(Me.fpnlUsage)
        Me.fpnlCardList.Controls.Add(Me.lblThreshold)
        Me.fpnlCardList.Controls.Add(Me.fpnlThreshold)
        Me.fpnlCardList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fpnlCardList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.fpnlCardList.ForeColor = System.Drawing.Color.White
        Me.fpnlCardList.Location = New System.Drawing.Point(0, 45)
        Me.fpnlCardList.Margin = New System.Windows.Forms.Padding(0)
        Me.fpnlCardList.Name = "fpnlCardList"
        Me.fpnlCardList.Size = New System.Drawing.Size(900, 455)
        Me.fpnlCardList.TabIndex = 0
        Me.fpnlCardList.WrapContents = False
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblQuantity.Font = New System.Drawing.Font("Segoe UI", 30.0!)
        Me.lblQuantity.ForeColor = System.Drawing.Color.Green
        Me.lblQuantity.Location = New System.Drawing.Point(0, 10)
        Me.lblQuantity.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblQuantity.MaximumSize = New System.Drawing.Size(330, 0)
        Me.lblQuantity.MinimumSize = New System.Drawing.Size(330, 0)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(330, 54)
        Me.lblQuantity.TabIndex = 0
        Me.lblQuantity.Text = "Quantity"
        Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiv
        '
        Me.lblDiv.BackColor = System.Drawing.Color.Green
        Me.lblDiv.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDiv.Location = New System.Drawing.Point(0, 40)
        Me.lblDiv.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(900, 5)
        Me.lblDiv.TabIndex = 0
        '
        'crdItem
        '
        Me.crdItem.BackColor = System.Drawing.Color.White
        Me.crdItem.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.crdItem.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.crdItem.Description = "Item"
        Me.crdItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdItem.ForeColor = System.Drawing.Color.White
        Me.crdItem.Location = New System.Drawing.Point(15, 10)
        Me.crdItem.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdItem.Name = "crdItem"
        Me.crdItem.Size = New System.Drawing.Size(300, 130)
        Me.crdItem.TabIndex = 0
        Me.crdItem.TabStop = False
        Me.crdItem.Text = "0"
        '
        'crdInventory
        '
        Me.crdInventory.BackColor = System.Drawing.Color.White
        Me.crdInventory.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.crdInventory.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.crdInventory.Description = "Inventory"
        Me.crdInventory.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdInventory.ForeColor = System.Drawing.Color.White
        Me.crdInventory.Location = New System.Drawing.Point(330, 10)
        Me.crdInventory.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdInventory.Name = "crdInventory"
        Me.crdInventory.Size = New System.Drawing.Size(300, 130)
        Me.crdInventory.TabIndex = 0
        Me.crdInventory.TabStop = False
        Me.crdInventory.Text = "0"
        '
        'crdAsset
        '
        Me.crdAsset.BackColor = System.Drawing.Color.White
        Me.crdAsset.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.crdAsset.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.crdAsset.Description = "Asset"
        Me.crdAsset.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdAsset.ForeColor = System.Drawing.Color.White
        Me.crdAsset.Location = New System.Drawing.Point(15, 150)
        Me.crdAsset.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdAsset.Name = "crdAsset"
        Me.crdAsset.Size = New System.Drawing.Size(300, 130)
        Me.crdAsset.TabIndex = 0
        Me.crdAsset.TabStop = False
        Me.crdAsset.Text = "0"
        '
        'crdAssetBulk
        '
        Me.crdAssetBulk.BackColor = System.Drawing.Color.White
        Me.crdAssetBulk.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.crdAssetBulk.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.crdAssetBulk.Description = "Asset - Bulk"
        Me.crdAssetBulk.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdAssetBulk.ForeColor = System.Drawing.Color.White
        Me.crdAssetBulk.Location = New System.Drawing.Point(330, 150)
        Me.crdAssetBulk.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdAssetBulk.Name = "crdAssetBulk"
        Me.crdAssetBulk.Size = New System.Drawing.Size(300, 130)
        Me.crdAssetBulk.TabIndex = 0
        Me.crdAssetBulk.TabStop = False
        Me.crdAssetBulk.Text = "0"
        '
        'crdConsumable
        '
        Me.crdConsumable.BackColor = System.Drawing.Color.White
        Me.crdConsumable.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.crdConsumable.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.crdConsumable.Description = "Consumable"
        Me.crdConsumable.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdConsumable.ForeColor = System.Drawing.Color.White
        Me.crdConsumable.Location = New System.Drawing.Point(15, 290)
        Me.crdConsumable.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdConsumable.Name = "crdConsumable"
        Me.crdConsumable.Size = New System.Drawing.Size(300, 130)
        Me.crdConsumable.TabIndex = 0
        Me.crdConsumable.TabStop = False
        Me.crdConsumable.Text = "0"
        '
        'crdReserved
        '
        Me.crdReserved.BackColor = System.Drawing.Color.White
        Me.crdReserved.Color1 = System.Drawing.Color.MidnightBlue
        Me.crdReserved.Color2 = System.Drawing.Color.DodgerBlue
        Me.crdReserved.Description = "Reserved"
        Me.crdReserved.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdReserved.ForeColor = System.Drawing.Color.White
        Me.crdReserved.Location = New System.Drawing.Point(15, 10)
        Me.crdReserved.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdReserved.Name = "crdReserved"
        Me.crdReserved.Size = New System.Drawing.Size(300, 130)
        Me.crdReserved.TabIndex = 0
        Me.crdReserved.TabStop = False
        Me.crdReserved.Text = "0"
        '
        'crdBorrowed
        '
        Me.crdBorrowed.BackColor = System.Drawing.Color.White
        Me.crdBorrowed.Color1 = System.Drawing.Color.MidnightBlue
        Me.crdBorrowed.Color2 = System.Drawing.Color.DodgerBlue
        Me.crdBorrowed.Description = "Borrowed"
        Me.crdBorrowed.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdBorrowed.ForeColor = System.Drawing.Color.White
        Me.crdBorrowed.Location = New System.Drawing.Point(330, 10)
        Me.crdBorrowed.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdBorrowed.Name = "crdBorrowed"
        Me.crdBorrowed.Size = New System.Drawing.Size(300, 130)
        Me.crdBorrowed.TabIndex = 0
        Me.crdBorrowed.TabStop = False
        Me.crdBorrowed.Text = "0"
        '
        'crdStationed
        '
        Me.crdStationed.BackColor = System.Drawing.Color.White
        Me.crdStationed.Color1 = System.Drawing.Color.MidnightBlue
        Me.crdStationed.Color2 = System.Drawing.Color.DodgerBlue
        Me.crdStationed.Description = "Stationed"
        Me.crdStationed.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdStationed.ForeColor = System.Drawing.Color.White
        Me.crdStationed.Location = New System.Drawing.Point(15, 150)
        Me.crdStationed.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdStationed.Name = "crdStationed"
        Me.crdStationed.Size = New System.Drawing.Size(300, 130)
        Me.crdStationed.TabIndex = 0
        Me.crdStationed.TabStop = False
        Me.crdStationed.Text = "0"
        '
        'crdLow
        '
        Me.crdLow.BackColor = System.Drawing.Color.White
        Me.crdLow.Color1 = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.crdLow.Color2 = System.Drawing.Color.Red
        Me.crdLow.Description = "Low in stock"
        Me.crdLow.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdLow.ForeColor = System.Drawing.Color.White
        Me.crdLow.Location = New System.Drawing.Point(15, 10)
        Me.crdLow.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdLow.Name = "crdLow"
        Me.crdLow.Size = New System.Drawing.Size(300, 130)
        Me.crdLow.TabIndex = 0
        Me.crdLow.TabStop = False
        Me.crdLow.Text = "0"
        '
        'crdOut
        '
        Me.crdOut.BackColor = System.Drawing.Color.White
        Me.crdOut.Color1 = System.Drawing.Color.Red
        Me.crdOut.Color2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.crdOut.Description = "Out of stock"
        Me.crdOut.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.crdOut.ForeColor = System.Drawing.Color.White
        Me.crdOut.Location = New System.Drawing.Point(330, 10)
        Me.crdOut.Margin = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.crdOut.Name = "crdOut"
        Me.crdOut.Size = New System.Drawing.Size(300, 130)
        Me.crdOut.TabIndex = 0
        Me.crdOut.TabStop = False
        Me.crdOut.Text = "0"
        '
        'ctrlDashboard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.fpnlCardList)
        Me.Controls.Add(Me.lblDiv)
        Me.Controls.Add(Me.pnlRibbon)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlDashboard"
        Me.Size = New System.Drawing.Size(900, 500)
        Me.pnlRibbon.ResumeLayout(False)
        Me.fpnlQuantity.ResumeLayout(False)
        Me.fpnlUsage.ResumeLayout(False)
        Me.fpnlThreshold.ResumeLayout(False)
        Me.fpnlCardList.ResumeLayout(False)
        Me.fpnlCardList.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents crdInventory As ctrlDashboardCard
    Private WithEvents crdItem As ctrlDashboardCard
    Private WithEvents crdAsset As ctrlDashboardCard
    Private WithEvents crdBorrowed As ctrlDashboardCard
    Private WithEvents crdStationed As ctrlDashboardCard
    Private WithEvents crdReserved As ctrlDashboardCard
    Private WithEvents crdLow As ctrlDashboardCard
    Private WithEvents crdOut As ctrlDashboardCard
    Private WithEvents pnlRibbon As Panel
    Private WithEvents lblThreshold As Label
    Private WithEvents lblUsage As Label
    Private WithEvents btnRefresh As Button
    Private WithEvents fpnlQuantity As FlowLayoutPanel
    Private WithEvents fpnlUsage As FlowLayoutPanel
    Private WithEvents fpnlThreshold As FlowLayoutPanel
    Private WithEvents fpnlCardList As FlowLayoutPanel
    Private WithEvents lblDiv As Label
    Private WithEvents crdAssetBulk As ctrlDashboardCard
    Private WithEvents crdConsumable As ctrlDashboardCard
    Private WithEvents lblQuantity As Label
End Class
