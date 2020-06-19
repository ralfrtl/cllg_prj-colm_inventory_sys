<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditBorrow
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
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblBorrowID = New System.Windows.Forms.Label()
        Me.txtBorrowID = New System.Windows.Forms.TextBox()
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
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblInventory = New System.Windows.Forms.Label()
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
        Me.lblGood = New System.Windows.Forms.Label()
        Me.numGood = New System.Windows.Forms.NumericUpDown()
        Me.lblDamaged = New System.Windows.Forms.Label()
        Me.numDamaged = New System.Windows.Forms.NumericUpDown()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblGoodDiff = New System.Windows.Forms.Label()
        Me.lblDamagedDiff = New System.Windows.Forms.Label()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCustomer.SuspendLayout()
        Me.pnlInventory.SuspendLayout()
        CType(Me.numGood, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDamaged, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnEdit.Location = New System.Drawing.Point(670, 360)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'err
        '
        Me.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.err.ContainerControl = Me
        '
        'lblBorrowID
        '
        Me.lblBorrowID.AutoSize = True
        Me.lblBorrowID.Location = New System.Drawing.Point(261, 248)
        Me.lblBorrowID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblBorrowID.Name = "lblBorrowID"
        Me.lblBorrowID.Size = New System.Drawing.Size(71, 19)
        Me.lblBorrowID.TabIndex = 0
        Me.lblBorrowID.Text = "Borrow ID"
        Me.lblBorrowID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBorrowID
        '
        Me.txtBorrowID.BackColor = System.Drawing.Color.White
        Me.txtBorrowID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBorrowID.ForeColor = System.Drawing.Color.Black
        Me.txtBorrowID.Location = New System.Drawing.Point(340, 245)
        Me.txtBorrowID.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBorrowID.Name = "txtBorrowID"
        Me.txtBorrowID.ReadOnly = True
        Me.txtBorrowID.Size = New System.Drawing.Size(200, 25)
        Me.txtBorrowID.TabIndex = 0
        Me.txtBorrowID.TabStop = False
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
        Me.pnlCustomer.Location = New System.Drawing.Point(30, 55)
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
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.ForeColor = System.Drawing.Color.Green
        Me.lblCustomer.Location = New System.Drawing.Point(30, 30)
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
        Me.lblInventory.Location = New System.Drawing.Point(30, 115)
        Me.lblInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(68, 19)
        Me.lblInventory.TabIndex = 0
        Me.lblInventory.Text = "Inventory"
        Me.lblInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.pnlInventory.Location = New System.Drawing.Point(30, 140)
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
        'lblGood
        '
        Me.lblGood.AutoSize = True
        Me.lblGood.Location = New System.Drawing.Point(289, 278)
        Me.lblGood.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGood.Name = "lblGood"
        Me.lblGood.Size = New System.Drawing.Size(43, 19)
        Me.lblGood.TabIndex = 0
        Me.lblGood.Text = "Good"
        Me.lblGood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numGood
        '
        Me.numGood.BackColor = System.Drawing.Color.White
        Me.numGood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numGood.ForeColor = System.Drawing.Color.Black
        Me.numGood.Location = New System.Drawing.Point(340, 275)
        Me.numGood.Margin = New System.Windows.Forms.Padding(0)
        Me.numGood.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numGood.Name = "numGood"
        Me.numGood.Size = New System.Drawing.Size(200, 25)
        Me.numGood.TabIndex = 1
        Me.numGood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numGood.ThousandsSeparator = True
        '
        'lblDamaged
        '
        Me.lblDamaged.AutoSize = True
        Me.lblDamaged.Location = New System.Drawing.Point(264, 308)
        Me.lblDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDamaged.Name = "lblDamaged"
        Me.lblDamaged.Size = New System.Drawing.Size(68, 19)
        Me.lblDamaged.TabIndex = 0
        Me.lblDamaged.Text = "Damaged"
        Me.lblDamaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numDamaged
        '
        Me.numDamaged.BackColor = System.Drawing.Color.White
        Me.numDamaged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numDamaged.ForeColor = System.Drawing.Color.Black
        Me.numDamaged.Location = New System.Drawing.Point(340, 305)
        Me.numDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.numDamaged.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDamaged.Name = "numDamaged"
        Me.numDamaged.Size = New System.Drawing.Size(200, 25)
        Me.numDamaged.TabIndex = 2
        Me.numDamaged.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numDamaged.ThousandsSeparator = True
        '
        'btnRefresh
        '
        Me.btnRefresh.AutoSize = True
        Me.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.ForeColor = System.Drawing.Color.Green
        Me.btnRefresh.Location = New System.Drawing.Point(540, 245)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRefresh.MaximumSize = New System.Drawing.Size(0, 25)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(60, 25)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseCompatibleTextRendering = True
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lblGoodDiff
        '
        Me.lblGoodDiff.AutoSize = True
        Me.lblGoodDiff.ForeColor = System.Drawing.Color.DimGray
        Me.lblGoodDiff.Location = New System.Drawing.Point(540, 278)
        Me.lblGoodDiff.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGoodDiff.Name = "lblGoodDiff"
        Me.lblGoodDiff.Size = New System.Drawing.Size(0, 19)
        Me.lblGoodDiff.TabIndex = 0
        Me.lblGoodDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDamagedDiff
        '
        Me.lblDamagedDiff.AutoSize = True
        Me.lblDamagedDiff.ForeColor = System.Drawing.Color.DimGray
        Me.lblDamagedDiff.Location = New System.Drawing.Point(540, 308)
        Me.lblDamagedDiff.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDamagedDiff.Name = "lblDamagedDiff"
        Me.lblDamagedDiff.Size = New System.Drawing.Size(0, 19)
        Me.lblDamagedDiff.TabIndex = 0
        Me.lblDamagedDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmEditBorrow
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 420)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.pnlCustomer)
        Me.Controls.Add(Me.lblInventory)
        Me.Controls.Add(Me.pnlInventory)
        Me.Controls.Add(Me.lblBorrowID)
        Me.Controls.Add(Me.txtBorrowID)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lblGood)
        Me.Controls.Add(Me.numGood)
        Me.Controls.Add(Me.lblGoodDiff)
        Me.Controls.Add(Me.lblDamaged)
        Me.Controls.Add(Me.numDamaged)
        Me.Controls.Add(Me.lblDamagedDiff)
        Me.Controls.Add(Me.btnEdit)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditBorrow"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Borrowed Inventory"
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCustomer.ResumeLayout(False)
        Me.pnlInventory.ResumeLayout(False)
        CType(Me.numGood, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDamaged, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnEdit As Button
    Private WithEvents err As ErrorProvider
    Private WithEvents lblBorrowID As Label
    Private WithEvents txtBorrowID As TextBox
    Private WithEvents pnlCustomer As Panel
    Private WithEvents lblCustomerID As Label
    Private WithEvents lblCustomerName As Label
    Private WithEvents lblCustomerDepartment As Label
    Private WithEvents lblCustomerPosition As Label
    Private WithEvents lblCustomerOffense As Label
    Private WithEvents lblCustomerIDVal As Label
    Private WithEvents lblCustomerNameVal As Label
    Private WithEvents lblCustomerDepartmentVal As Label
    Private WithEvents lblCustomerPositionVal As Label
    Private WithEvents lblCustomerOffenseVal As Label
    Private WithEvents lblCustomer As Label
    Private WithEvents lblInventory As Label
    Private WithEvents pnlInventory As Panel
    Private WithEvents lblInventoryID As Label
    Private WithEvents lblInventoryInformation As Label
    Private WithEvents lblInventoryInvoice As Label
    Private WithEvents lblInventoryGood As Label
    Private WithEvents lblInventoryDamaged As Label
    Private WithEvents lblInventoryIDVal As Label
    Private WithEvents lblInventoryInformationVal As Label
    Private WithEvents lblInventoryInvoiceVal As Label
    Private WithEvents lblInventoryGoodVal As Label
    Private WithEvents lblInventoryDamagedVal As Label
    Private WithEvents lblGood As Label
    Private WithEvents numGood As NumericUpDown
    Private WithEvents lblDamaged As Label
    Private WithEvents numDamaged As NumericUpDown
    Private WithEvents btnRefresh As Button
    Private WithEvents lblDamagedDiff As Label
    Private WithEvents lblGoodDiff As Label
End Class
