<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUseInventory
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
        Me.lblDamaged = New System.Windows.Forms.Label()
        Me.numGood = New System.Windows.Forms.NumericUpDown()
        Me.btnUse = New System.Windows.Forms.Button()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblAction = New System.Windows.Forms.Label()
        Me.lblGood = New System.Windows.Forms.Label()
        Me.cmbAction = New System.Windows.Forms.ComboBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.btnSelectCustomer = New System.Windows.Forms.Button()
        Me.btnSelectInventory = New System.Windows.Forms.Button()
        Me.pnlItem = New System.Windows.Forms.Panel()
        Me.lblItemID = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.lblItemDescription = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.lblUnitType = New System.Windows.Forms.Label()
        Me.lblItemIDVal = New System.Windows.Forms.Label()
        Me.lblItemNameVal = New System.Windows.Forms.Label()
        Me.lblItemDescriptionVal = New System.Windows.Forms.Label()
        Me.lblItemTypeVal = New System.Windows.Forms.Label()
        Me.lblUnitTypeVal = New System.Windows.Forms.Label()
        Me.pnlCustomer = New System.Windows.Forms.Panel()
        Me.lblCustomerID = New System.Windows.Forms.Label()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.lblCustomerDepartment = New System.Windows.Forms.Label()
        Me.lblCustomerPosition = New System.Windows.Forms.Label()
        Me.lblCustomerOffense = New System.Windows.Forms.Label()
        Me.lblCustomerIDVal = New System.Windows.Forms.Label()
        Me.lblCustomerNameVal = New System.Windows.Forms.Label()
        Me.lblCustomerDepartmentVal = New System.Windows.Forms.Label()
        Me.lblCustomerPositionVal = New System.Windows.Forms.Label()
        Me.lblCustomerOffenseVal = New System.Windows.Forms.Label()
        Me.pnlInventory = New System.Windows.Forms.Panel()
        Me.lblInventoryID = New System.Windows.Forms.Label()
        Me.lblInventoryInformation = New System.Windows.Forms.Label()
        Me.lblInventoryInvoice = New System.Windows.Forms.Label()
        Me.lblInventoryGood = New System.Windows.Forms.Label()
        Me.lblInventoryDamaged = New System.Windows.Forms.Label()
        Me.lblInventoryIDVal = New System.Windows.Forms.Label()
        Me.lblInventoryInformationVal = New System.Windows.Forms.Label()
        Me.lblInventoryInvoiceVal = New System.Windows.Forms.Label()
        Me.lblInventoryGoodVal = New System.Windows.Forms.Label()
        Me.lblInventoryDamagedVal = New System.Windows.Forms.Label()
        Me.numDamaged = New System.Windows.Forms.NumericUpDown()
        CType(Me.numGood, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlItem.SuspendLayout()
        Me.pnlCustomer.SuspendLayout()
        Me.pnlInventory.SuspendLayout()
        CType(Me.numDamaged, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDamaged
        '
        Me.lblDamaged.AutoSize = True
        Me.lblDamaged.Location = New System.Drawing.Point(262, 448)
        Me.lblDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDamaged.Name = "lblDamaged"
        Me.lblDamaged.Size = New System.Drawing.Size(68, 19)
        Me.lblDamaged.TabIndex = 0
        Me.lblDamaged.Text = "Damaged"
        Me.lblDamaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numGood
        '
        Me.numGood.BackColor = System.Drawing.Color.White
        Me.numGood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numGood.ForeColor = System.Drawing.Color.Black
        Me.numGood.Location = New System.Drawing.Point(338, 415)
        Me.numGood.Margin = New System.Windows.Forms.Padding(10, 0, 0, 5)
        Me.numGood.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numGood.Name = "numGood"
        Me.numGood.Size = New System.Drawing.Size(200, 25)
        Me.numGood.TabIndex = 4
        Me.numGood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numGood.ThousandsSeparator = True
        '
        'btnUse
        '
        Me.btnUse.AutoEllipsis = True
        Me.btnUse.BackColor = System.Drawing.Color.Green
        Me.btnUse.FlatAppearance.BorderSize = 0
        Me.btnUse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnUse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUse.ForeColor = System.Drawing.Color.White
        Me.btnUse.Location = New System.Drawing.Point(670, 500)
        Me.btnUse.Margin = New System.Windows.Forms.Padding(0)
        Me.btnUse.Name = "btnUse"
        Me.btnUse.Size = New System.Drawing.Size(100, 30)
        Me.btnUse.TabIndex = 6
        Me.btnUse.Text = "Use"
        Me.btnUse.UseVisualStyleBackColor = False
        '
        'err
        '
        Me.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.err.ContainerControl = Me
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.Location = New System.Drawing.Point(282, 358)
        Me.lblAction.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(48, 19)
        Me.lblAction.TabIndex = 0
        Me.lblAction.Text = "Action"
        Me.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGood
        '
        Me.lblGood.AutoSize = True
        Me.lblGood.Location = New System.Drawing.Point(287, 418)
        Me.lblGood.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGood.Name = "lblGood"
        Me.lblGood.Size = New System.Drawing.Size(43, 19)
        Me.lblGood.TabIndex = 0
        Me.lblGood.Text = "Good"
        Me.lblGood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAction
        '
        Me.cmbAction.BackColor = System.Drawing.Color.White
        Me.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAction.ForeColor = System.Drawing.Color.Black
        Me.cmbAction.FormattingEnabled = True
        Me.cmbAction.Location = New System.Drawing.Point(338, 355)
        Me.cmbAction.Margin = New System.Windows.Forms.Padding(10, 0, 0, 5)
        Me.cmbAction.Name = "cmbAction"
        Me.cmbAction.Size = New System.Drawing.Size(200, 25)
        Me.cmbAction.TabIndex = 2
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(269, 388)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(61, 19)
        Me.lblLocation.TabIndex = 0
        Me.lblLocation.Text = "Location"
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.White
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.Enabled = False
        Me.txtLocation.ForeColor = System.Drawing.Color.Black
        Me.txtLocation.Location = New System.Drawing.Point(338, 385)
        Me.txtLocation.Margin = New System.Windows.Forms.Padding(10, 0, 0, 5)
        Me.txtLocation.MaxLength = 120
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(200, 25)
        Me.txtLocation.TabIndex = 3
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.ForeColor = System.Drawing.Color.Green
        Me.lblItem.Location = New System.Drawing.Point(30, 30)
        Me.lblItem.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(37, 19)
        Me.lblItem.TabIndex = 0
        Me.lblItem.Text = "Item"
        Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.ForeColor = System.Drawing.Color.Green
        Me.lblCustomer.Location = New System.Drawing.Point(30, 140)
        Me.lblCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(69, 19)
        Me.lblCustomer.TabIndex = 0
        Me.lblCustomer.Text = "Customer"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInventory
        '
        Me.lblInventory.AutoSize = True
        Me.lblInventory.ForeColor = System.Drawing.Color.Green
        Me.lblInventory.Location = New System.Drawing.Point(30, 225)
        Me.lblInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(68, 19)
        Me.lblInventory.TabIndex = 0
        Me.lblInventory.Text = "Inventory"
        Me.lblInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSelectCustomer
        '
        Me.btnSelectCustomer.AutoEllipsis = True
        Me.btnSelectCustomer.BackColor = System.Drawing.Color.Green
        Me.btnSelectCustomer.FlatAppearance.BorderSize = 0
        Me.btnSelectCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnSelectCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnSelectCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectCustomer.ForeColor = System.Drawing.Color.White
        Me.btnSelectCustomer.Location = New System.Drawing.Point(670, 140)
        Me.btnSelectCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSelectCustomer.Name = "btnSelectCustomer"
        Me.btnSelectCustomer.Size = New System.Drawing.Size(100, 20)
        Me.btnSelectCustomer.TabIndex = 0
        Me.btnSelectCustomer.Text = "Select"
        Me.btnSelectCustomer.UseCompatibleTextRendering = True
        Me.btnSelectCustomer.UseVisualStyleBackColor = False
        '
        'btnSelectInventory
        '
        Me.btnSelectInventory.AutoEllipsis = True
        Me.btnSelectInventory.BackColor = System.Drawing.Color.Green
        Me.btnSelectInventory.FlatAppearance.BorderSize = 0
        Me.btnSelectInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnSelectInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnSelectInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectInventory.ForeColor = System.Drawing.Color.White
        Me.btnSelectInventory.Location = New System.Drawing.Point(670, 225)
        Me.btnSelectInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSelectInventory.Name = "btnSelectInventory"
        Me.btnSelectInventory.Size = New System.Drawing.Size(100, 20)
        Me.btnSelectInventory.TabIndex = 1
        Me.btnSelectInventory.Text = "Select"
        Me.btnSelectInventory.UseCompatibleTextRendering = True
        Me.btnSelectInventory.UseVisualStyleBackColor = False
        '
        'pnlItem
        '
        Me.pnlItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.pnlItem.Controls.Add(Me.lblItemID)
        Me.pnlItem.Controls.Add(Me.lblItemName)
        Me.pnlItem.Controls.Add(Me.lblItemDescription)
        Me.pnlItem.Controls.Add(Me.lblItemType)
        Me.pnlItem.Controls.Add(Me.lblUnitType)
        Me.pnlItem.Controls.Add(Me.lblItemIDVal)
        Me.pnlItem.Controls.Add(Me.lblItemNameVal)
        Me.pnlItem.Controls.Add(Me.lblItemDescriptionVal)
        Me.pnlItem.Controls.Add(Me.lblItemTypeVal)
        Me.pnlItem.Controls.Add(Me.lblUnitTypeVal)
        Me.pnlItem.Location = New System.Drawing.Point(30, 55)
        Me.pnlItem.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlItem.Name = "pnlItem"
        Me.pnlItem.Size = New System.Drawing.Size(741, 75)
        Me.pnlItem.TabIndex = 0
        '
        'lblItemID
        '
        Me.lblItemID.AutoEllipsis = True
        Me.lblItemID.Location = New System.Drawing.Point(0, 0)
        Me.lblItemID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemID.Name = "lblItemID"
        Me.lblItemID.Size = New System.Drawing.Size(100, 20)
        Me.lblItemID.TabIndex = 0
        Me.lblItemID.Text = "ID"
        '
        'lblItemName
        '
        Me.lblItemName.AutoEllipsis = True
        Me.lblItemName.Location = New System.Drawing.Point(100, 0)
        Me.lblItemName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(200, 20)
        Me.lblItemName.TabIndex = 0
        Me.lblItemName.Text = "Name"
        '
        'lblItemDescription
        '
        Me.lblItemDescription.AutoEllipsis = True
        Me.lblItemDescription.Location = New System.Drawing.Point(300, 0)
        Me.lblItemDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemDescription.Name = "lblItemDescription"
        Me.lblItemDescription.Size = New System.Drawing.Size(200, 20)
        Me.lblItemDescription.TabIndex = 0
        Me.lblItemDescription.Text = "Description"
        '
        'lblItemType
        '
        Me.lblItemType.AutoEllipsis = True
        Me.lblItemType.Location = New System.Drawing.Point(500, 0)
        Me.lblItemType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(120, 20)
        Me.lblItemType.TabIndex = 0
        Me.lblItemType.Text = "Item type"
        '
        'lblUnitType
        '
        Me.lblUnitType.AutoEllipsis = True
        Me.lblUnitType.Location = New System.Drawing.Point(620, 0)
        Me.lblUnitType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUnitType.Name = "lblUnitType"
        Me.lblUnitType.Size = New System.Drawing.Size(120, 20)
        Me.lblUnitType.TabIndex = 0
        Me.lblUnitType.Text = "Unit type"
        '
        'lblItemIDVal
        '
        Me.lblItemIDVal.AutoEllipsis = True
        Me.lblItemIDVal.BackColor = System.Drawing.Color.White
        Me.lblItemIDVal.Location = New System.Drawing.Point(1, 20)
        Me.lblItemIDVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemIDVal.Name = "lblItemIDVal"
        Me.lblItemIDVal.Size = New System.Drawing.Size(99, 54)
        Me.lblItemIDVal.TabIndex = 0
        Me.lblItemIDVal.UseCompatibleTextRendering = True
        '
        'lblItemNameVal
        '
        Me.lblItemNameVal.AutoEllipsis = True
        Me.lblItemNameVal.BackColor = System.Drawing.Color.White
        Me.lblItemNameVal.Location = New System.Drawing.Point(101, 20)
        Me.lblItemNameVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemNameVal.Name = "lblItemNameVal"
        Me.lblItemNameVal.Size = New System.Drawing.Size(199, 54)
        Me.lblItemNameVal.TabIndex = 0
        Me.lblItemNameVal.UseCompatibleTextRendering = True
        '
        'lblItemDescriptionVal
        '
        Me.lblItemDescriptionVal.AutoEllipsis = True
        Me.lblItemDescriptionVal.BackColor = System.Drawing.Color.White
        Me.lblItemDescriptionVal.Location = New System.Drawing.Point(301, 20)
        Me.lblItemDescriptionVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemDescriptionVal.Name = "lblItemDescriptionVal"
        Me.lblItemDescriptionVal.Size = New System.Drawing.Size(199, 54)
        Me.lblItemDescriptionVal.TabIndex = 0
        Me.lblItemDescriptionVal.UseCompatibleTextRendering = True
        '
        'lblItemTypeVal
        '
        Me.lblItemTypeVal.AutoEllipsis = True
        Me.lblItemTypeVal.BackColor = System.Drawing.Color.White
        Me.lblItemTypeVal.Location = New System.Drawing.Point(501, 20)
        Me.lblItemTypeVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemTypeVal.Name = "lblItemTypeVal"
        Me.lblItemTypeVal.Size = New System.Drawing.Size(119, 54)
        Me.lblItemTypeVal.TabIndex = 0
        Me.lblItemTypeVal.UseCompatibleTextRendering = True
        '
        'lblUnitTypeVal
        '
        Me.lblUnitTypeVal.AutoEllipsis = True
        Me.lblUnitTypeVal.BackColor = System.Drawing.Color.White
        Me.lblUnitTypeVal.Location = New System.Drawing.Point(621, 20)
        Me.lblUnitTypeVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUnitTypeVal.Name = "lblUnitTypeVal"
        Me.lblUnitTypeVal.Size = New System.Drawing.Size(119, 54)
        Me.lblUnitTypeVal.TabIndex = 0
        Me.lblUnitTypeVal.UseCompatibleTextRendering = True
        '
        'pnlCustomer
        '
        Me.pnlCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.pnlCustomer.Controls.Add(Me.lblCustomerID)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerName)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerDepartment)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerPosition)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerOffense)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerIDVal)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerNameVal)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerDepartmentVal)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerPositionVal)
        Me.pnlCustomer.Controls.Add(Me.lblCustomerOffenseVal)
        Me.pnlCustomer.Location = New System.Drawing.Point(30, 165)
        Me.pnlCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCustomer.Name = "pnlCustomer"
        Me.pnlCustomer.Size = New System.Drawing.Size(741, 50)
        Me.pnlCustomer.TabIndex = 0
        '
        'lblCustomerID
        '
        Me.lblCustomerID.AutoEllipsis = True
        Me.lblCustomerID.Location = New System.Drawing.Point(0, 0)
        Me.lblCustomerID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(100, 20)
        Me.lblCustomerID.TabIndex = 0
        Me.lblCustomerID.Text = "ID"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoEllipsis = True
        Me.lblCustomerName.Location = New System.Drawing.Point(100, 0)
        Me.lblCustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(200, 20)
        Me.lblCustomerName.TabIndex = 0
        Me.lblCustomerName.Text = "Name"
        '
        'lblCustomerDepartment
        '
        Me.lblCustomerDepartment.AutoEllipsis = True
        Me.lblCustomerDepartment.Location = New System.Drawing.Point(300, 0)
        Me.lblCustomerDepartment.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerDepartment.Name = "lblCustomerDepartment"
        Me.lblCustomerDepartment.Size = New System.Drawing.Size(150, 20)
        Me.lblCustomerDepartment.TabIndex = 0
        Me.lblCustomerDepartment.Text = "Department"
        '
        'lblCustomerPosition
        '
        Me.lblCustomerPosition.AutoEllipsis = True
        Me.lblCustomerPosition.Location = New System.Drawing.Point(450, 0)
        Me.lblCustomerPosition.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerPosition.Name = "lblCustomerPosition"
        Me.lblCustomerPosition.Size = New System.Drawing.Size(150, 20)
        Me.lblCustomerPosition.TabIndex = 0
        Me.lblCustomerPosition.Text = "Position"
        '
        'lblCustomerOffense
        '
        Me.lblCustomerOffense.AutoEllipsis = True
        Me.lblCustomerOffense.Location = New System.Drawing.Point(600, 0)
        Me.lblCustomerOffense.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerOffense.Name = "lblCustomerOffense"
        Me.lblCustomerOffense.Size = New System.Drawing.Size(140, 20)
        Me.lblCustomerOffense.TabIndex = 0
        Me.lblCustomerOffense.Text = "No. of offense(s)"
        '
        'lblCustomerIDVal
        '
        Me.lblCustomerIDVal.AutoEllipsis = True
        Me.lblCustomerIDVal.BackColor = System.Drawing.Color.White
        Me.lblCustomerIDVal.Location = New System.Drawing.Point(1, 20)
        Me.lblCustomerIDVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerIDVal.Name = "lblCustomerIDVal"
        Me.lblCustomerIDVal.Size = New System.Drawing.Size(99, 29)
        Me.lblCustomerIDVal.TabIndex = 0
        Me.lblCustomerIDVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCustomerIDVal.UseCompatibleTextRendering = True
        '
        'lblCustomerNameVal
        '
        Me.lblCustomerNameVal.AutoEllipsis = True
        Me.lblCustomerNameVal.BackColor = System.Drawing.Color.White
        Me.lblCustomerNameVal.Location = New System.Drawing.Point(101, 20)
        Me.lblCustomerNameVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerNameVal.Name = "lblCustomerNameVal"
        Me.lblCustomerNameVal.Size = New System.Drawing.Size(199, 29)
        Me.lblCustomerNameVal.TabIndex = 0
        Me.lblCustomerNameVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCustomerNameVal.UseCompatibleTextRendering = True
        '
        'lblCustomerDepartmentVal
        '
        Me.lblCustomerDepartmentVal.AutoEllipsis = True
        Me.lblCustomerDepartmentVal.BackColor = System.Drawing.Color.White
        Me.lblCustomerDepartmentVal.Location = New System.Drawing.Point(301, 20)
        Me.lblCustomerDepartmentVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerDepartmentVal.Name = "lblCustomerDepartmentVal"
        Me.lblCustomerDepartmentVal.Size = New System.Drawing.Size(149, 29)
        Me.lblCustomerDepartmentVal.TabIndex = 0
        Me.lblCustomerDepartmentVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCustomerDepartmentVal.UseCompatibleTextRendering = True
        '
        'lblCustomerPositionVal
        '
        Me.lblCustomerPositionVal.AutoEllipsis = True
        Me.lblCustomerPositionVal.BackColor = System.Drawing.Color.White
        Me.lblCustomerPositionVal.Location = New System.Drawing.Point(451, 20)
        Me.lblCustomerPositionVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerPositionVal.Name = "lblCustomerPositionVal"
        Me.lblCustomerPositionVal.Size = New System.Drawing.Size(149, 29)
        Me.lblCustomerPositionVal.TabIndex = 0
        Me.lblCustomerPositionVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCustomerPositionVal.UseCompatibleTextRendering = True
        '
        'lblCustomerOffenseVal
        '
        Me.lblCustomerOffenseVal.AutoEllipsis = True
        Me.lblCustomerOffenseVal.BackColor = System.Drawing.Color.White
        Me.lblCustomerOffenseVal.Location = New System.Drawing.Point(601, 20)
        Me.lblCustomerOffenseVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerOffenseVal.Name = "lblCustomerOffenseVal"
        Me.lblCustomerOffenseVal.Size = New System.Drawing.Size(139, 29)
        Me.lblCustomerOffenseVal.TabIndex = 0
        Me.lblCustomerOffenseVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCustomerOffenseVal.UseCompatibleTextRendering = True
        '
        'pnlInventory
        '
        Me.pnlInventory.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.pnlInventory.Controls.Add(Me.lblInventoryID)
        Me.pnlInventory.Controls.Add(Me.lblInventoryInformation)
        Me.pnlInventory.Controls.Add(Me.lblInventoryInvoice)
        Me.pnlInventory.Controls.Add(Me.lblInventoryGood)
        Me.pnlInventory.Controls.Add(Me.lblInventoryDamaged)
        Me.pnlInventory.Controls.Add(Me.lblInventoryIDVal)
        Me.pnlInventory.Controls.Add(Me.lblInventoryInformationVal)
        Me.pnlInventory.Controls.Add(Me.lblInventoryInvoiceVal)
        Me.pnlInventory.Controls.Add(Me.lblInventoryGoodVal)
        Me.pnlInventory.Controls.Add(Me.lblInventoryDamagedVal)
        Me.pnlInventory.Location = New System.Drawing.Point(30, 250)
        Me.pnlInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlInventory.Name = "pnlInventory"
        Me.pnlInventory.Size = New System.Drawing.Size(741, 75)
        Me.pnlInventory.TabIndex = 0
        '
        'lblInventoryID
        '
        Me.lblInventoryID.AutoEllipsis = True
        Me.lblInventoryID.Location = New System.Drawing.Point(0, 0)
        Me.lblInventoryID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryID.Name = "lblInventoryID"
        Me.lblInventoryID.Size = New System.Drawing.Size(100, 20)
        Me.lblInventoryID.TabIndex = 0
        Me.lblInventoryID.Text = "ID"
        '
        'lblInventoryInformation
        '
        Me.lblInventoryInformation.AutoEllipsis = True
        Me.lblInventoryInformation.Location = New System.Drawing.Point(100, 0)
        Me.lblInventoryInformation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryInformation.Name = "lblInventoryInformation"
        Me.lblInventoryInformation.Size = New System.Drawing.Size(200, 20)
        Me.lblInventoryInformation.TabIndex = 0
        Me.lblInventoryInformation.Text = "Information"
        '
        'lblInventoryInvoice
        '
        Me.lblInventoryInvoice.AutoEllipsis = True
        Me.lblInventoryInvoice.Location = New System.Drawing.Point(300, 0)
        Me.lblInventoryInvoice.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryInvoice.Name = "lblInventoryInvoice"
        Me.lblInventoryInvoice.Size = New System.Drawing.Size(200, 20)
        Me.lblInventoryInvoice.TabIndex = 0
        Me.lblInventoryInvoice.Text = "Invoice"
        '
        'lblInventoryGood
        '
        Me.lblInventoryGood.AutoEllipsis = True
        Me.lblInventoryGood.Location = New System.Drawing.Point(500, 0)
        Me.lblInventoryGood.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryGood.Name = "lblInventoryGood"
        Me.lblInventoryGood.Size = New System.Drawing.Size(120, 20)
        Me.lblInventoryGood.TabIndex = 0
        Me.lblInventoryGood.Text = "Good"
        '
        'lblInventoryDamaged
        '
        Me.lblInventoryDamaged.AutoEllipsis = True
        Me.lblInventoryDamaged.Location = New System.Drawing.Point(620, 0)
        Me.lblInventoryDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryDamaged.Name = "lblInventoryDamaged"
        Me.lblInventoryDamaged.Size = New System.Drawing.Size(120, 20)
        Me.lblInventoryDamaged.TabIndex = 0
        Me.lblInventoryDamaged.Text = "Damaged"
        '
        'lblInventoryIDVal
        '
        Me.lblInventoryIDVal.AutoEllipsis = True
        Me.lblInventoryIDVal.BackColor = System.Drawing.Color.White
        Me.lblInventoryIDVal.Location = New System.Drawing.Point(1, 20)
        Me.lblInventoryIDVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryIDVal.Name = "lblInventoryIDVal"
        Me.lblInventoryIDVal.Size = New System.Drawing.Size(99, 54)
        Me.lblInventoryIDVal.TabIndex = 0
        Me.lblInventoryIDVal.UseCompatibleTextRendering = True
        '
        'lblInventoryInformationVal
        '
        Me.lblInventoryInformationVal.AutoEllipsis = True
        Me.lblInventoryInformationVal.BackColor = System.Drawing.Color.White
        Me.lblInventoryInformationVal.Location = New System.Drawing.Point(101, 20)
        Me.lblInventoryInformationVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryInformationVal.Name = "lblInventoryInformationVal"
        Me.lblInventoryInformationVal.Size = New System.Drawing.Size(199, 54)
        Me.lblInventoryInformationVal.TabIndex = 0
        Me.lblInventoryInformationVal.UseCompatibleTextRendering = True
        '
        'lblInventoryInvoiceVal
        '
        Me.lblInventoryInvoiceVal.AutoEllipsis = True
        Me.lblInventoryInvoiceVal.BackColor = System.Drawing.Color.White
        Me.lblInventoryInvoiceVal.Location = New System.Drawing.Point(301, 20)
        Me.lblInventoryInvoiceVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryInvoiceVal.Name = "lblInventoryInvoiceVal"
        Me.lblInventoryInvoiceVal.Size = New System.Drawing.Size(199, 54)
        Me.lblInventoryInvoiceVal.TabIndex = 0
        Me.lblInventoryInvoiceVal.UseCompatibleTextRendering = True
        '
        'lblInventoryGoodVal
        '
        Me.lblInventoryGoodVal.AutoEllipsis = True
        Me.lblInventoryGoodVal.BackColor = System.Drawing.Color.White
        Me.lblInventoryGoodVal.Location = New System.Drawing.Point(501, 20)
        Me.lblInventoryGoodVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryGoodVal.Name = "lblInventoryGoodVal"
        Me.lblInventoryGoodVal.Size = New System.Drawing.Size(119, 54)
        Me.lblInventoryGoodVal.TabIndex = 0
        Me.lblInventoryGoodVal.UseCompatibleTextRendering = True
        '
        'lblInventoryDamagedVal
        '
        Me.lblInventoryDamagedVal.AutoEllipsis = True
        Me.lblInventoryDamagedVal.BackColor = System.Drawing.Color.White
        Me.lblInventoryDamagedVal.Location = New System.Drawing.Point(621, 20)
        Me.lblInventoryDamagedVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryDamagedVal.Name = "lblInventoryDamagedVal"
        Me.lblInventoryDamagedVal.Size = New System.Drawing.Size(119, 54)
        Me.lblInventoryDamagedVal.TabIndex = 0
        Me.lblInventoryDamagedVal.UseCompatibleTextRendering = True
        '
        'numDamaged
        '
        Me.numDamaged.BackColor = System.Drawing.Color.White
        Me.numDamaged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numDamaged.ForeColor = System.Drawing.Color.Black
        Me.numDamaged.Location = New System.Drawing.Point(338, 445)
        Me.numDamaged.Margin = New System.Windows.Forms.Padding(10, 0, 0, 5)
        Me.numDamaged.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDamaged.Name = "numDamaged"
        Me.numDamaged.Size = New System.Drawing.Size(200, 25)
        Me.numDamaged.TabIndex = 5
        Me.numDamaged.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numDamaged.ThousandsSeparator = True
        '
        'frmUseInventory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 560)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.pnlItem)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.btnSelectCustomer)
        Me.Controls.Add(Me.pnlCustomer)
        Me.Controls.Add(Me.lblInventory)
        Me.Controls.Add(Me.btnSelectInventory)
        Me.Controls.Add(Me.pnlInventory)
        Me.Controls.Add(Me.lblAction)
        Me.Controls.Add(Me.cmbAction)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.lblGood)
        Me.Controls.Add(Me.numGood)
        Me.Controls.Add(Me.lblDamaged)
        Me.Controls.Add(Me.numDamaged)
        Me.Controls.Add(Me.btnUse)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUseInventory"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Use Inventory"
        CType(Me.numGood, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlItem.ResumeLayout(False)
        Me.pnlCustomer.ResumeLayout(False)
        Me.pnlInventory.ResumeLayout(False)
        CType(Me.numDamaged, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblDamaged As Label
    Private WithEvents numGood As NumericUpDown
    Private WithEvents btnUse As Button
    Private WithEvents err As ErrorProvider
    Private WithEvents lblAction As Label
    Private WithEvents lblGood As Label
    Private WithEvents cmbAction As ComboBox
    Private WithEvents lblLocation As Label
    Private WithEvents txtLocation As TextBox
    Private WithEvents lblInventory As Label
    Private WithEvents lblCustomer As Label
    Private WithEvents lblItem As Label
    Private WithEvents btnSelectCustomer As Button
    Private WithEvents btnSelectInventory As Button
    Private WithEvents pnlItem As Panel
    Private WithEvents lblItemID As Label
    Private WithEvents lblItemIDVal As Label
    Private WithEvents lblUnitType As Label
    Private WithEvents lblItemType As Label
    Private WithEvents lblItemDescription As Label
    Private WithEvents lblItemName As Label
    Private WithEvents lblUnitTypeVal As Label
    Private WithEvents lblItemTypeVal As Label
    Private WithEvents lblItemDescriptionVal As Label
    Private WithEvents lblItemNameVal As Label
    Private WithEvents pnlCustomer As Panel
    Private WithEvents lblCustomerOffenseVal As Label
    Private WithEvents lblCustomerPositionVal As Label
    Private WithEvents lblCustomerDepartmentVal As Label
    Private WithEvents lblCustomerNameVal As Label
    Private WithEvents lblCustomerIDVal As Label
    Private WithEvents lblCustomerOffense As Label
    Private WithEvents lblCustomerPosition As Label
    Private WithEvents lblCustomerDepartment As Label
    Private WithEvents lblCustomerName As Label
    Private WithEvents lblCustomerID As Label
    Private WithEvents pnlInventory As Panel
    Private WithEvents lblInventoryDamagedVal As Label
    Private WithEvents lblInventoryGoodVal As Label
    Private WithEvents lblInventoryInvoiceVal As Label
    Private WithEvents lblInventoryInformationVal As Label
    Private WithEvents lblInventoryIDVal As Label
    Private WithEvents lblInventoryDamaged As Label
    Private WithEvents lblInventoryGood As Label
    Private WithEvents lblInventoryInvoice As Label
    Private WithEvents lblInventoryInformation As Label
    Private WithEvents lblInventoryID As Label
    Private WithEvents numDamaged As NumericUpDown
End Class
