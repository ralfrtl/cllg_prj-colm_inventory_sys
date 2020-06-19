<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmViewItem
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
        Me.fpnlItemDetails = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblItemID = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.lblUnitType = New System.Windows.Forms.Label()
        Me.fpnlLowThreshold = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblLowThresholdText = New System.Windows.Forms.Label()
        Me.lblLowThresholdNotifier = New System.Windows.Forms.Label()
        Me.lblLowThreshold = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblAvailable = New System.Windows.Forms.Label()
        Me.lblBorrowed = New System.Windows.Forms.Label()
        Me.lblStationed = New System.Windows.Forms.Label()
        Me.lblReserved = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblGood = New System.Windows.Forms.Label()
        Me.lblDamaged = New System.Windows.Forms.Label()
        Me.lblMaintenance = New System.Windows.Forms.Label()
        Me.lblReplacement = New System.Windows.Forms.Label()
        Me.fpnlButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.tltp = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbContainer = New COLM_Inventory.ctrlTabControl()
        Me.tbpgReservation = New System.Windows.Forms.TabPage()
        Me.ctrlReservationContent = New COLM_Inventory.ctrlReservation()
        Me.tbpgInventory = New System.Windows.Forms.TabPage()
        Me.ctrlInventoryContent = New COLM_Inventory.ctrlInventory()
        Me.tbpgConsume = New System.Windows.Forms.TabPage()
        Me.ctrlConsumeContent = New COLM_Inventory.ctrlConsume()
        Me.tbpgBorrow = New System.Windows.Forms.TabPage()
        Me.ctrlBorrowContent = New COLM_Inventory.ctrlBorrow()
        Me.tbpgStation = New System.Windows.Forms.TabPage()
        Me.ctrlStationContent = New COLM_Inventory.ctrlStation()
        Me.fpnlItemDetails.SuspendLayout()
        Me.fpnlLowThreshold.SuspendLayout()
        Me.fpnlButtons.SuspendLayout()
        Me.tbContainer.SuspendLayout()
        Me.tbpgReservation.SuspendLayout()
        Me.tbpgInventory.SuspendLayout()
        Me.tbpgConsume.SuspendLayout()
        Me.tbpgBorrow.SuspendLayout()
        Me.tbpgStation.SuspendLayout()
        Me.SuspendLayout()
        '
        'fpnlItemDetails
        '
        Me.fpnlItemDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fpnlItemDetails.AutoScroll = True
        Me.fpnlItemDetails.Controls.Add(Me.lblName)
        Me.fpnlItemDetails.Controls.Add(Me.lblItemID)
        Me.fpnlItemDetails.Controls.Add(Me.lblDescription)
        Me.fpnlItemDetails.Controls.Add(Me.lblItemType)
        Me.fpnlItemDetails.Controls.Add(Me.lblUnitType)
        Me.fpnlItemDetails.Controls.Add(Me.fpnlLowThreshold)
        Me.fpnlItemDetails.Controls.Add(Me.lblQuantity)
        Me.fpnlItemDetails.Controls.Add(Me.lblTotal)
        Me.fpnlItemDetails.Controls.Add(Me.lblAvailable)
        Me.fpnlItemDetails.Controls.Add(Me.lblReserved)
        Me.fpnlItemDetails.Controls.Add(Me.lblBorrowed)
        Me.fpnlItemDetails.Controls.Add(Me.lblStationed)
        Me.fpnlItemDetails.Controls.Add(Me.lblStatus)
        Me.fpnlItemDetails.Controls.Add(Me.lblGood)
        Me.fpnlItemDetails.Controls.Add(Me.lblDamaged)
        Me.fpnlItemDetails.Controls.Add(Me.lblMaintenance)
        Me.fpnlItemDetails.Controls.Add(Me.lblReplacement)
        Me.fpnlItemDetails.Controls.Add(Me.fpnlButtons)
        Me.fpnlItemDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.fpnlItemDetails.Location = New System.Drawing.Point(0, 0)
        Me.fpnlItemDetails.Margin = New System.Windows.Forms.Padding(0)
        Me.fpnlItemDetails.Name = "fpnlItemDetails"
        Me.fpnlItemDetails.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.fpnlItemDetails.Size = New System.Drawing.Size(250, 561)
        Me.fpnlItemDetails.TabIndex = 1
        Me.fpnlItemDetails.TabStop = True
        Me.fpnlItemDetails.WrapContents = False
        '
        'lblName
        '
        Me.lblName.AutoEllipsis = True
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Green
        Me.lblName.Location = New System.Drawing.Point(15, 11)
        Me.lblName.Margin = New System.Windows.Forms.Padding(0, 11, 0, 11)
        Me.lblName.MaximumSize = New System.Drawing.Size(220, 38)
        Me.lblName.MinimumSize = New System.Drawing.Size(220, 38)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(220, 38)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblName.UseCompatibleTextRendering = True
        '
        'lblItemID
        '
        Me.lblItemID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblItemID.AutoEllipsis = True
        Me.lblItemID.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblItemID.Location = New System.Drawing.Point(15, 60)
        Me.lblItemID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemID.Name = "lblItemID"
        Me.lblItemID.Size = New System.Drawing.Size(220, 20)
        Me.lblItemID.TabIndex = 0
        Me.lblItemID.Text = "ID :"
        Me.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDescription.AutoEllipsis = True
        Me.lblDescription.Location = New System.Drawing.Point(15, 90)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(220, 40)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "Description"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemType
        '
        Me.lblItemType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblItemType.AutoEllipsis = True
        Me.lblItemType.Location = New System.Drawing.Point(15, 140)
        Me.lblItemType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(220, 20)
        Me.lblItemType.TabIndex = 0
        Me.lblItemType.Text = "Item type :"
        Me.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitType
        '
        Me.lblUnitType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUnitType.AutoEllipsis = True
        Me.lblUnitType.Location = New System.Drawing.Point(15, 160)
        Me.lblUnitType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUnitType.Name = "lblUnitType"
        Me.lblUnitType.Size = New System.Drawing.Size(220, 20)
        Me.lblUnitType.TabIndex = 0
        Me.lblUnitType.Text = "Unit type :"
        Me.lblUnitType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fpnlLowThreshold
        '
        Me.fpnlLowThreshold.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fpnlLowThreshold.Controls.Add(Me.lblLowThresholdText)
        Me.fpnlLowThreshold.Controls.Add(Me.lblLowThresholdNotifier)
        Me.fpnlLowThreshold.Controls.Add(Me.lblLowThreshold)
        Me.fpnlLowThreshold.Location = New System.Drawing.Point(15, 180)
        Me.fpnlLowThreshold.Margin = New System.Windows.Forms.Padding(0)
        Me.fpnlLowThreshold.Name = "fpnlLowThreshold"
        Me.fpnlLowThreshold.Size = New System.Drawing.Size(220, 20)
        Me.fpnlLowThreshold.TabIndex = 0
        '
        'lblLowThresholdText
        '
        Me.lblLowThresholdText.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLowThresholdText.Location = New System.Drawing.Point(0, 0)
        Me.lblLowThresholdText.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLowThresholdText.Name = "lblLowThresholdText"
        Me.lblLowThresholdText.Size = New System.Drawing.Size(103, 20)
        Me.lblLowThresholdText.TabIndex = 0
        Me.lblLowThresholdText.Text = "Low threshold :"
        Me.lblLowThresholdText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLowThresholdNotifier
        '
        Me.lblLowThresholdNotifier.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLowThresholdNotifier.Location = New System.Drawing.Point(103, 2)
        Me.lblLowThresholdNotifier.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLowThresholdNotifier.Name = "lblLowThresholdNotifier"
        Me.lblLowThresholdNotifier.Size = New System.Drawing.Size(15, 15)
        Me.lblLowThresholdNotifier.TabIndex = 0
        Me.lblLowThresholdNotifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLowThreshold
        '
        Me.lblLowThreshold.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLowThreshold.AutoEllipsis = True
        Me.lblLowThreshold.Location = New System.Drawing.Point(118, 0)
        Me.lblLowThreshold.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLowThreshold.Name = "lblLowThreshold"
        Me.lblLowThreshold.Size = New System.Drawing.Size(102, 20)
        Me.lblLowThreshold.TabIndex = 0
        Me.lblLowThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQuantity
        '
        Me.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblQuantity.ForeColor = System.Drawing.Color.Green
        Me.lblQuantity.Location = New System.Drawing.Point(15, 210)
        Me.lblQuantity.Margin = New System.Windows.Forms.Padding(0, 10, 0, 5)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(220, 20)
        Me.lblQuantity.TabIndex = 0
        Me.lblQuantity.Text = "Quantity"
        Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotal.AutoEllipsis = True
        Me.lblTotal.Location = New System.Drawing.Point(15, 235)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(220, 20)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "Total :"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAvailable
        '
        Me.lblAvailable.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAvailable.AutoEllipsis = True
        Me.lblAvailable.Location = New System.Drawing.Point(15, 255)
        Me.lblAvailable.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAvailable.Name = "lblAvailable"
        Me.lblAvailable.Size = New System.Drawing.Size(220, 20)
        Me.lblAvailable.TabIndex = 0
        Me.lblAvailable.Text = "Available :"
        Me.lblAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBorrowed
        '
        Me.lblBorrowed.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBorrowed.AutoEllipsis = True
        Me.lblBorrowed.Location = New System.Drawing.Point(15, 295)
        Me.lblBorrowed.Margin = New System.Windows.Forms.Padding(0)
        Me.lblBorrowed.Name = "lblBorrowed"
        Me.lblBorrowed.Size = New System.Drawing.Size(220, 20)
        Me.lblBorrowed.TabIndex = 0
        Me.lblBorrowed.Text = "Borrowed :"
        Me.lblBorrowed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStationed
        '
        Me.lblStationed.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStationed.AutoEllipsis = True
        Me.lblStationed.Location = New System.Drawing.Point(15, 315)
        Me.lblStationed.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStationed.Name = "lblStationed"
        Me.lblStationed.Size = New System.Drawing.Size(220, 20)
        Me.lblStationed.TabIndex = 0
        Me.lblStationed.Text = "Stationed :"
        Me.lblStationed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReserved
        '
        Me.lblReserved.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblReserved.AutoEllipsis = True
        Me.lblReserved.Location = New System.Drawing.Point(15, 275)
        Me.lblReserved.Margin = New System.Windows.Forms.Padding(0)
        Me.lblReserved.Name = "lblReserved"
        Me.lblReserved.Size = New System.Drawing.Size(220, 20)
        Me.lblReserved.TabIndex = 0
        Me.lblReserved.Text = "Reserved :"
        Me.lblReserved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStatus.ForeColor = System.Drawing.Color.Green
        Me.lblStatus.Location = New System.Drawing.Point(15, 345)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(0, 10, 0, 5)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(220, 20)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGood
        '
        Me.lblGood.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblGood.AutoEllipsis = True
        Me.lblGood.Location = New System.Drawing.Point(15, 370)
        Me.lblGood.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGood.Name = "lblGood"
        Me.lblGood.Size = New System.Drawing.Size(220, 20)
        Me.lblGood.TabIndex = 0
        Me.lblGood.Text = "Good :"
        Me.lblGood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDamaged
        '
        Me.lblDamaged.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDamaged.AutoEllipsis = True
        Me.lblDamaged.Location = New System.Drawing.Point(15, 390)
        Me.lblDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDamaged.Name = "lblDamaged"
        Me.lblDamaged.Size = New System.Drawing.Size(220, 20)
        Me.lblDamaged.TabIndex = 0
        Me.lblDamaged.Text = "Damaged :"
        Me.lblDamaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaintenance
        '
        Me.lblMaintenance.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMaintenance.AutoEllipsis = True
        Me.lblMaintenance.Location = New System.Drawing.Point(15, 410)
        Me.lblMaintenance.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMaintenance.Name = "lblMaintenance"
        Me.lblMaintenance.Size = New System.Drawing.Size(220, 20)
        Me.lblMaintenance.TabIndex = 0
        Me.lblMaintenance.Text = "Under maintenance :"
        Me.lblMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReplacement
        '
        Me.lblReplacement.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblReplacement.AutoEllipsis = True
        Me.lblReplacement.Location = New System.Drawing.Point(15, 430)
        Me.lblReplacement.Margin = New System.Windows.Forms.Padding(0)
        Me.lblReplacement.Name = "lblReplacement"
        Me.lblReplacement.Size = New System.Drawing.Size(220, 20)
        Me.lblReplacement.TabIndex = 0
        Me.lblReplacement.Text = "For replacement :"
        Me.lblReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fpnlButtons
        '
        Me.fpnlButtons.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fpnlButtons.Controls.Add(Me.btnEdit)
        Me.fpnlButtons.Controls.Add(Me.btnDelete)
        Me.fpnlButtons.Location = New System.Drawing.Point(15, 460)
        Me.fpnlButtons.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.fpnlButtons.Name = "fpnlButtons"
        Me.fpnlButtons.Size = New System.Drawing.Size(220, 30)
        Me.fpnlButtons.TabIndex = 0
        Me.fpnlButtons.TabStop = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.ForeColor = System.Drawing.Color.Green
        Me.btnEdit.Location = New System.Drawing.Point(0, 0)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 30)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "Edit"
        Me.tltp.SetToolTip(Me.btnEdit, "(Ctrl + Shift + Alt + E)")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.Color.Red
        Me.btnDelete.Location = New System.Drawing.Point(65, 0)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 30)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.tltp.SetToolTip(Me.btnDelete, "(Ctrl + Shift + Alt + D)")
        '
        'tbContainer
        '
        Me.tbContainer.ActiveBGColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tbContainer.ActiveFGColor = System.Drawing.Color.White
        Me.tbContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbContainer.BodyColor = System.Drawing.Color.White
        Me.tbContainer.Controls.Add(Me.tbpgReservation)
        Me.tbContainer.Controls.Add(Me.tbpgInventory)
        Me.tbContainer.Controls.Add(Me.tbpgConsume)
        Me.tbContainer.Controls.Add(Me.tbpgBorrow)
        Me.tbContainer.Controls.Add(Me.tbpgStation)
        Me.tbContainer.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.tbContainer.HeaderColor = System.Drawing.Color.White
        Me.tbContainer.HotTrack = True
        Me.tbContainer.HoverBGColor = System.Drawing.Color.Green
        Me.tbContainer.HoverFGColor = System.Drawing.Color.White
        Me.tbContainer.InActiveBGColor = System.Drawing.Color.White
        Me.tbContainer.InActiveFGColor = System.Drawing.Color.Green
        Me.tbContainer.ItemSize = New System.Drawing.Size(0, 30)
        Me.tbContainer.Location = New System.Drawing.Point(246, 0)
        Me.tbContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.tbContainer.Name = "tbContainer"
        Me.tbContainer.Padding = New System.Drawing.Point(15, 0)
        Me.tbContainer.SelectedIndex = 0
        Me.tbContainer.Size = New System.Drawing.Size(658, 564)
        Me.tbContainer.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.tbContainer.TabIndex = 0
        '
        'tbpgReservation
        '
        Me.tbpgReservation.BackColor = System.Drawing.Color.White
        Me.tbpgReservation.Controls.Add(Me.ctrlReservationContent)
        Me.tbpgReservation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgReservation.Location = New System.Drawing.Point(4, 34)
        Me.tbpgReservation.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgReservation.Name = "tbpgReservation"
        Me.tbpgReservation.Size = New System.Drawing.Size(650, 526)
        Me.tbpgReservation.TabIndex = 4
        Me.tbpgReservation.Text = "Reservation"
        '
        'ctrlReservationContent
        '
        Me.ctrlReservationContent.BackColor = System.Drawing.Color.White
        Me.ctrlReservationContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlReservationContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlReservationContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlReservationContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlReservationContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlReservationContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlReservationContent.Name = "ctrlReservationContent"
        Me.ctrlReservationContent.ShowItemColumn = False
        Me.ctrlReservationContent.Size = New System.Drawing.Size(650, 526)
        Me.ctrlReservationContent.TabIndex = 0
        '
        'tbpgInventory
        '
        Me.tbpgInventory.BackColor = System.Drawing.Color.White
        Me.tbpgInventory.Controls.Add(Me.ctrlInventoryContent)
        Me.tbpgInventory.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgInventory.Location = New System.Drawing.Point(4, 34)
        Me.tbpgInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgInventory.Name = "tbpgInventory"
        Me.tbpgInventory.Size = New System.Drawing.Size(650, 526)
        Me.tbpgInventory.TabIndex = 5
        Me.tbpgInventory.Text = "Inventory"
        '
        'ctrlInventoryContent
        '
        Me.ctrlInventoryContent.BackColor = System.Drawing.Color.White
        Me.ctrlInventoryContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlInventoryContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlInventoryContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlInventoryContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlInventoryContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlInventoryContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlInventoryContent.Name = "ctrlInventoryContent"
        Me.ctrlInventoryContent.Size = New System.Drawing.Size(650, 526)
        Me.ctrlInventoryContent.TabIndex = 0
        '
        'tbpgConsume
        '
        Me.tbpgConsume.BackColor = System.Drawing.Color.White
        Me.tbpgConsume.Controls.Add(Me.ctrlConsumeContent)
        Me.tbpgConsume.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgConsume.Location = New System.Drawing.Point(4, 34)
        Me.tbpgConsume.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgConsume.Name = "tbpgConsume"
        Me.tbpgConsume.Size = New System.Drawing.Size(650, 526)
        Me.tbpgConsume.TabIndex = 1
        Me.tbpgConsume.Text = "Consume"
        '
        'ctrlConsumeContent
        '
        Me.ctrlConsumeContent.BackColor = System.Drawing.Color.White
        Me.ctrlConsumeContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlConsumeContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlConsumeContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlConsumeContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlConsumeContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlConsumeContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlConsumeContent.Name = "ctrlConsumeContent"
        Me.ctrlConsumeContent.Size = New System.Drawing.Size(650, 526)
        Me.ctrlConsumeContent.TabIndex = 0
        '
        'tbpgBorrow
        '
        Me.tbpgBorrow.BackColor = System.Drawing.Color.White
        Me.tbpgBorrow.Controls.Add(Me.ctrlBorrowContent)
        Me.tbpgBorrow.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgBorrow.Location = New System.Drawing.Point(4, 34)
        Me.tbpgBorrow.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgBorrow.Name = "tbpgBorrow"
        Me.tbpgBorrow.Size = New System.Drawing.Size(650, 526)
        Me.tbpgBorrow.TabIndex = 2
        Me.tbpgBorrow.Text = "Borrow"
        '
        'ctrlBorrowContent
        '
        Me.ctrlBorrowContent.BackColor = System.Drawing.Color.White
        Me.ctrlBorrowContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlBorrowContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlBorrowContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlBorrowContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlBorrowContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlBorrowContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlBorrowContent.Name = "ctrlBorrowContent"
        Me.ctrlBorrowContent.Size = New System.Drawing.Size(650, 526)
        Me.ctrlBorrowContent.TabIndex = 0
        '
        'tbpgStation
        '
        Me.tbpgStation.BackColor = System.Drawing.Color.White
        Me.tbpgStation.Controls.Add(Me.ctrlStationContent)
        Me.tbpgStation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tbpgStation.Location = New System.Drawing.Point(4, 34)
        Me.tbpgStation.Margin = New System.Windows.Forms.Padding(0)
        Me.tbpgStation.Name = "tbpgStation"
        Me.tbpgStation.Size = New System.Drawing.Size(650, 526)
        Me.tbpgStation.TabIndex = 3
        Me.tbpgStation.Text = "Station"
        '
        'ctrlStationContent
        '
        Me.ctrlStationContent.BackColor = System.Drawing.Color.White
        Me.ctrlStationContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrlStationContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctrlStationContent.ForeColor = System.Drawing.Color.Black
        Me.ctrlStationContent.Location = New System.Drawing.Point(0, 0)
        Me.ctrlStationContent.Margin = New System.Windows.Forms.Padding(0)
        Me.ctrlStationContent.MinimumSize = New System.Drawing.Size(650, 0)
        Me.ctrlStationContent.Name = "ctrlStationContent"
        Me.ctrlStationContent.Size = New System.Drawing.Size(650, 526)
        Me.ctrlStationContent.TabIndex = 0
        '
        'frmViewItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(900, 560)
        Me.Controls.Add(Me.fpnlItemDetails)
        Me.Controls.Add(Me.tbContainer)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MinimumSize = New System.Drawing.Size(250, 100)
        Me.Name = "frmViewItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Item"
        Me.fpnlItemDetails.ResumeLayout(False)
        Me.fpnlItemDetails.PerformLayout()
        Me.fpnlLowThreshold.ResumeLayout(False)
        Me.fpnlButtons.ResumeLayout(False)
        Me.tbContainer.ResumeLayout(False)
        Me.tbpgReservation.ResumeLayout(False)
        Me.tbpgInventory.ResumeLayout(False)
        Me.tbpgConsume.ResumeLayout(False)
        Me.tbpgBorrow.ResumeLayout(False)
        Me.tbpgStation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblQuantity As Label
    Private WithEvents lblStatus As Label
    Private WithEvents btnEdit As Button
    Private WithEvents btnDelete As Button
    Private WithEvents fpnlButtons As FlowLayoutPanel
    Private WithEvents lblLowThresholdText As Label
    Private WithEvents lblLowThresholdNotifier As Label
    Private WithEvents lblName As Label
    Private WithEvents lblItemID As Label
    Private WithEvents lblDescription As Label
    Private WithEvents lblItemType As Label
    Private WithEvents lblUnitType As Label
    Private WithEvents lblLowThreshold As Label
    Private WithEvents lblTotal As Label
    Private WithEvents lblAvailable As Label
    Private WithEvents lblBorrowed As Label
    Private WithEvents lblStationed As Label
    Private WithEvents lblReserved As Label
    Private WithEvents lblGood As Label
    Private WithEvents lblDamaged As Label
    Private WithEvents lblMaintenance As Label
    Private WithEvents lblReplacement As Label
    Private WithEvents fpnlLowThreshold As FlowLayoutPanel
    Private WithEvents tltp As ToolTip
    Private WithEvents ctrlConsumeContent As ctrlConsume
    Private WithEvents ctrlInventoryContent As ctrlInventory
    Private WithEvents tbContainer As ctrlTabControl
    Private WithEvents tbpgInventory As TabPage
    Private WithEvents tbpgConsume As TabPage
    Private WithEvents tbpgReservation As TabPage
    Private WithEvents tbpgStation As TabPage
    Private WithEvents tbpgBorrow As TabPage
    Private WithEvents fpnlItemDetails As FlowLayoutPanel
    Private WithEvents ctrlBorrowContent As ctrlBorrow
    Private WithEvents ctrlStationContent As ctrlStation
    Private WithEvents ctrlReservationContent As ctrlReservation
End Class
