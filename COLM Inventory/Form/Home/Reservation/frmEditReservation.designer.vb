<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditReservation
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
        Me.lblQuantityNeeded = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.btnSelectCustomer = New System.Windows.Forms.Button()
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
        Me.numQuantityNeeded = New System.Windows.Forms.NumericUpDown()
        Me.dtpDateNeeded = New System.Windows.Forms.DateTimePicker()
        Me.lblDateNeeded = New System.Windows.Forms.Label()
        Me.lblQuantityNeededDiff = New System.Windows.Forms.Label()
        Me.lblReservationID = New System.Windows.Forms.Label()
        Me.txtReservationID = New System.Windows.Forms.TextBox()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlItem.SuspendLayout()
        Me.pnlCustomer.SuspendLayout()
        CType(Me.numQuantityNeeded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblQuantityNeeded
        '
        Me.lblQuantityNeeded.AutoSize = True
        Me.lblQuantityNeeded.Location = New System.Drawing.Point(240, 278)
        Me.lblQuantityNeeded.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQuantityNeeded.Name = "lblQuantityNeeded"
        Me.lblQuantityNeeded.Size = New System.Drawing.Size(112, 19)
        Me.lblQuantityNeeded.TabIndex = 0
        Me.lblQuantityNeeded.Text = "Quantity needed"
        Me.lblQuantityNeeded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.lblCustomer.Size = New System.Drawing.Size(83, 19)
        Me.lblCustomer.TabIndex = 0
        Me.lblCustomer.Text = "Reserved by"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'numQuantityNeeded
        '
        Me.numQuantityNeeded.BackColor = System.Drawing.Color.White
        Me.numQuantityNeeded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numQuantityNeeded.ForeColor = System.Drawing.Color.Black
        Me.numQuantityNeeded.Location = New System.Drawing.Point(360, 275)
        Me.numQuantityNeeded.Margin = New System.Windows.Forms.Padding(10, 0, 0, 5)
        Me.numQuantityNeeded.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numQuantityNeeded.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQuantityNeeded.Name = "numQuantityNeeded"
        Me.numQuantityNeeded.Size = New System.Drawing.Size(200, 25)
        Me.numQuantityNeeded.TabIndex = 1
        Me.numQuantityNeeded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numQuantityNeeded.ThousandsSeparator = True
        Me.numQuantityNeeded.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dtpDateNeeded
        '
        Me.dtpDateNeeded.CustomFormat = "MMM-dd-yyyy hh:mm:ss tt"
        Me.dtpDateNeeded.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateNeeded.Location = New System.Drawing.Point(360, 305)
        Me.dtpDateNeeded.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpDateNeeded.Name = "dtpDateNeeded"
        Me.dtpDateNeeded.Size = New System.Drawing.Size(200, 25)
        Me.dtpDateNeeded.TabIndex = 2
        Me.dtpDateNeeded.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'lblDateNeeded
        '
        Me.lblDateNeeded.AutoSize = True
        Me.lblDateNeeded.Location = New System.Drawing.Point(265, 308)
        Me.lblDateNeeded.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDateNeeded.Name = "lblDateNeeded"
        Me.lblDateNeeded.Size = New System.Drawing.Size(87, 19)
        Me.lblDateNeeded.TabIndex = 0
        Me.lblDateNeeded.Text = "Date needed"
        Me.lblDateNeeded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQuantityNeededDiff
        '
        Me.lblQuantityNeededDiff.AutoSize = True
        Me.lblQuantityNeededDiff.ForeColor = System.Drawing.Color.DimGray
        Me.lblQuantityNeededDiff.Location = New System.Drawing.Point(560, 278)
        Me.lblQuantityNeededDiff.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQuantityNeededDiff.Name = "lblQuantityNeededDiff"
        Me.lblQuantityNeededDiff.Size = New System.Drawing.Size(0, 19)
        Me.lblQuantityNeededDiff.TabIndex = 0
        Me.lblQuantityNeededDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReservationID
        '
        Me.lblReservationID.AutoSize = True
        Me.lblReservationID.Location = New System.Drawing.Point(254, 248)
        Me.lblReservationID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblReservationID.Name = "lblReservationID"
        Me.lblReservationID.Size = New System.Drawing.Size(98, 19)
        Me.lblReservationID.TabIndex = 0
        Me.lblReservationID.Text = "Reservation ID"
        Me.lblReservationID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReservationID
        '
        Me.txtReservationID.BackColor = System.Drawing.Color.White
        Me.txtReservationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReservationID.ForeColor = System.Drawing.Color.Black
        Me.txtReservationID.Location = New System.Drawing.Point(360, 245)
        Me.txtReservationID.Margin = New System.Windows.Forms.Padding(0)
        Me.txtReservationID.Name = "txtReservationID"
        Me.txtReservationID.ReadOnly = True
        Me.txtReservationID.Size = New System.Drawing.Size(200, 25)
        Me.txtReservationID.TabIndex = 0
        Me.txtReservationID.TabStop = False
        '
        'frmEditReservation
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 420)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.pnlItem)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.btnSelectCustomer)
        Me.Controls.Add(Me.pnlCustomer)
        Me.Controls.Add(Me.lblReservationID)
        Me.Controls.Add(Me.txtReservationID)
        Me.Controls.Add(Me.lblQuantityNeeded)
        Me.Controls.Add(Me.numQuantityNeeded)
        Me.Controls.Add(Me.lblQuantityNeededDiff)
        Me.Controls.Add(Me.lblDateNeeded)
        Me.Controls.Add(Me.dtpDateNeeded)
        Me.Controls.Add(Me.btnEdit)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditReservation"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Item Reservation"
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlItem.ResumeLayout(False)
        Me.pnlCustomer.ResumeLayout(False)
        CType(Me.numQuantityNeeded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblQuantityNeeded As Label
    Private WithEvents btnEdit As Button
    Private WithEvents err As ErrorProvider
    Private WithEvents lblCustomer As Label
    Private WithEvents lblItem As Label
    Private WithEvents btnSelectCustomer As Button
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
    Private WithEvents numQuantityNeeded As NumericUpDown
    Private WithEvents dtpDateNeeded As DateTimePicker
    Private WithEvents lblDateNeeded As Label
    Private WithEvents lblQuantityNeededDiff As Label
    Private WithEvents lblReservationID As Label
    Private WithEvents txtReservationID As TextBox
End Class
