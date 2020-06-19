<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditInventory
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
        Me.lblInformation = New System.Windows.Forms.Label()
        Me.lblReceiptNo = New System.Windows.Forms.Label()
        Me.lblDateReceived = New System.Windows.Forms.Label()
        Me.lblCostPerUnit = New System.Windows.Forms.Label()
        Me.lblGood = New System.Windows.Forms.Label()
        Me.txtInformation = New System.Windows.Forms.TextBox()
        Me.numCostPerUnit = New System.Windows.Forms.NumericUpDown()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtReceiptNo = New System.Windows.Forms.TextBox()
        Me.numGood = New System.Windows.Forms.NumericUpDown()
        Me.numDamaged = New System.Windows.Forms.NumericUpDown()
        Me.numMaintenance = New System.Windows.Forms.NumericUpDown()
        Me.numReplacement = New System.Windows.Forms.NumericUpDown()
        Me.dtpDateReceived = New System.Windows.Forms.DateTimePicker()
        Me.lblDamaged = New System.Windows.Forms.Label()
        Me.lblMaintenance = New System.Windows.Forms.Label()
        Me.lblReplacement = New System.Windows.Forms.Label()
        Me.lblItemID = New System.Windows.Forms.Label()
        Me.txtItemID = New System.Windows.Forms.TextBox()
        Me.lblInventoryID = New System.Windows.Forms.Label()
        Me.txtInventoryID = New System.Windows.Forms.TextBox()
        Me.lblStore = New System.Windows.Forms.Label()
        Me.txtStore = New System.Windows.Forms.TextBox()
        CType(Me.numCostPerUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGood, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDamaged, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numReplacement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInformation
        '
        Me.lblInformation.AutoSize = True
        Me.lblInformation.Location = New System.Drawing.Point(78, 93)
        Me.lblInformation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(81, 19)
        Me.lblInformation.TabIndex = 0
        Me.lblInformation.Text = "Information"
        Me.lblInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.AutoSize = True
        Me.lblReceiptNo.Location = New System.Drawing.Point(81, 228)
        Me.lblReceiptNo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(78, 19)
        Me.lblReceiptNo.TabIndex = 0
        Me.lblReceiptNo.Text = "Receipt No."
        Me.lblReceiptNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDateReceived
        '
        Me.lblDateReceived.AutoSize = True
        Me.lblDateReceived.Location = New System.Drawing.Point(67, 258)
        Me.lblDateReceived.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDateReceived.Name = "lblDateReceived"
        Me.lblDateReceived.Size = New System.Drawing.Size(92, 19)
        Me.lblDateReceived.TabIndex = 0
        Me.lblDateReceived.Text = "Date received"
        Me.lblDateReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostPerUnit
        '
        Me.lblCostPerUnit.AutoSize = True
        Me.lblCostPerUnit.Location = New System.Drawing.Point(70, 288)
        Me.lblCostPerUnit.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCostPerUnit.Name = "lblCostPerUnit"
        Me.lblCostPerUnit.Size = New System.Drawing.Size(89, 19)
        Me.lblCostPerUnit.TabIndex = 0
        Me.lblCostPerUnit.Text = "Cost per unit"
        Me.lblCostPerUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGood
        '
        Me.lblGood.AutoSize = True
        Me.lblGood.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblGood.ForeColor = System.Drawing.Color.Black
        Me.lblGood.Location = New System.Drawing.Point(116, 318)
        Me.lblGood.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGood.Name = "lblGood"
        Me.lblGood.Size = New System.Drawing.Size(43, 19)
        Me.lblGood.TabIndex = 0
        Me.lblGood.Text = "Good"
        Me.lblGood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInformation
        '
        Me.txtInformation.BackColor = System.Drawing.Color.White
        Me.txtInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInformation.ForeColor = System.Drawing.Color.Black
        Me.txtInformation.Location = New System.Drawing.Point(167, 90)
        Me.txtInformation.Margin = New System.Windows.Forms.Padding(0)
        Me.txtInformation.MaxLength = 500
        Me.txtInformation.Multiline = True
        Me.txtInformation.Name = "txtInformation"
        Me.txtInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInformation.Size = New System.Drawing.Size(200, 100)
        Me.txtInformation.TabIndex = 0
        '
        'numCostPerUnit
        '
        Me.numCostPerUnit.BackColor = System.Drawing.Color.White
        Me.numCostPerUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numCostPerUnit.DecimalPlaces = 2
        Me.numCostPerUnit.ForeColor = System.Drawing.Color.Black
        Me.numCostPerUnit.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numCostPerUnit.Location = New System.Drawing.Point(167, 285)
        Me.numCostPerUnit.Margin = New System.Windows.Forms.Padding(0)
        Me.numCostPerUnit.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numCostPerUnit.Name = "numCostPerUnit"
        Me.numCostPerUnit.Size = New System.Drawing.Size(200, 25)
        Me.numCostPerUnit.TabIndex = 4
        Me.numCostPerUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numCostPerUnit.ThousandsSeparator = True
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
        Me.btnEdit.Location = New System.Drawing.Point(267, 460)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'err
        '
        Me.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.err.ContainerControl = Me
        '
        'txtReceiptNo
        '
        Me.txtReceiptNo.BackColor = System.Drawing.Color.White
        Me.txtReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceiptNo.ForeColor = System.Drawing.Color.Black
        Me.txtReceiptNo.Location = New System.Drawing.Point(167, 225)
        Me.txtReceiptNo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtReceiptNo.MaxLength = 50
        Me.txtReceiptNo.Name = "txtReceiptNo"
        Me.txtReceiptNo.Size = New System.Drawing.Size(200, 25)
        Me.txtReceiptNo.TabIndex = 2
        '
        'numGood
        '
        Me.numGood.BackColor = System.Drawing.Color.White
        Me.numGood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numGood.ForeColor = System.Drawing.Color.Black
        Me.numGood.Location = New System.Drawing.Point(167, 315)
        Me.numGood.Margin = New System.Windows.Forms.Padding(0)
        Me.numGood.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numGood.Name = "numGood"
        Me.numGood.Size = New System.Drawing.Size(200, 25)
        Me.numGood.TabIndex = 5
        Me.numGood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numGood.ThousandsSeparator = True
        '
        'numDamaged
        '
        Me.numDamaged.BackColor = System.Drawing.Color.White
        Me.numDamaged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numDamaged.ForeColor = System.Drawing.Color.Black
        Me.numDamaged.Location = New System.Drawing.Point(167, 345)
        Me.numDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.numDamaged.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numDamaged.Name = "numDamaged"
        Me.numDamaged.Size = New System.Drawing.Size(200, 25)
        Me.numDamaged.TabIndex = 6
        Me.numDamaged.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numDamaged.ThousandsSeparator = True
        '
        'numMaintenance
        '
        Me.numMaintenance.BackColor = System.Drawing.Color.White
        Me.numMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numMaintenance.ForeColor = System.Drawing.Color.Black
        Me.numMaintenance.Location = New System.Drawing.Point(167, 375)
        Me.numMaintenance.Margin = New System.Windows.Forms.Padding(0)
        Me.numMaintenance.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numMaintenance.Name = "numMaintenance"
        Me.numMaintenance.Size = New System.Drawing.Size(200, 25)
        Me.numMaintenance.TabIndex = 7
        Me.numMaintenance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numMaintenance.ThousandsSeparator = True
        '
        'numReplacement
        '
        Me.numReplacement.BackColor = System.Drawing.Color.White
        Me.numReplacement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numReplacement.ForeColor = System.Drawing.Color.Black
        Me.numReplacement.Location = New System.Drawing.Point(167, 405)
        Me.numReplacement.Margin = New System.Windows.Forms.Padding(0)
        Me.numReplacement.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numReplacement.Name = "numReplacement"
        Me.numReplacement.Size = New System.Drawing.Size(200, 25)
        Me.numReplacement.TabIndex = 8
        Me.numReplacement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numReplacement.ThousandsSeparator = True
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.CustomFormat = "MMM-dd-yyyy hh:mm:ss tt"
        Me.dtpDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateReceived.Location = New System.Drawing.Point(167, 255)
        Me.dtpDateReceived.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(200, 25)
        Me.dtpDateReceived.TabIndex = 3
        Me.dtpDateReceived.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'lblDamaged
        '
        Me.lblDamaged.AutoSize = True
        Me.lblDamaged.Location = New System.Drawing.Point(91, 348)
        Me.lblDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDamaged.Name = "lblDamaged"
        Me.lblDamaged.Size = New System.Drawing.Size(68, 19)
        Me.lblDamaged.TabIndex = 0
        Me.lblDamaged.Text = "Damaged"
        Me.lblDamaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaintenance
        '
        Me.lblMaintenance.AutoSize = True
        Me.lblMaintenance.Location = New System.Drawing.Point(30, 378)
        Me.lblMaintenance.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMaintenance.Name = "lblMaintenance"
        Me.lblMaintenance.Size = New System.Drawing.Size(129, 19)
        Me.lblMaintenance.TabIndex = 0
        Me.lblMaintenance.Text = "Under maintenance"
        Me.lblMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReplacement
        '
        Me.lblReplacement.AutoSize = True
        Me.lblReplacement.Location = New System.Drawing.Point(51, 408)
        Me.lblReplacement.Margin = New System.Windows.Forms.Padding(0)
        Me.lblReplacement.Name = "lblReplacement"
        Me.lblReplacement.Size = New System.Drawing.Size(108, 19)
        Me.lblReplacement.TabIndex = 0
        Me.lblReplacement.Text = "For replacement"
        Me.lblReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemID
        '
        Me.lblItemID.AutoSize = True
        Me.lblItemID.Location = New System.Drawing.Point(104, 33)
        Me.lblItemID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemID.Name = "lblItemID"
        Me.lblItemID.Size = New System.Drawing.Size(55, 19)
        Me.lblItemID.TabIndex = 0
        Me.lblItemID.Text = "Item ID"
        Me.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemID
        '
        Me.txtItemID.BackColor = System.Drawing.Color.White
        Me.txtItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemID.ForeColor = System.Drawing.Color.Black
        Me.txtItemID.Location = New System.Drawing.Point(167, 30)
        Me.txtItemID.Margin = New System.Windows.Forms.Padding(0)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.ReadOnly = True
        Me.txtItemID.Size = New System.Drawing.Size(200, 25)
        Me.txtItemID.TabIndex = 0
        Me.txtItemID.TabStop = False
        '
        'lblInventoryID
        '
        Me.lblInventoryID.AutoSize = True
        Me.lblInventoryID.Location = New System.Drawing.Point(73, 63)
        Me.lblInventoryID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventoryID.Name = "lblInventoryID"
        Me.lblInventoryID.Size = New System.Drawing.Size(86, 19)
        Me.lblInventoryID.TabIndex = 0
        Me.lblInventoryID.Text = "Inventory ID"
        Me.lblInventoryID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInventoryID
        '
        Me.txtInventoryID.BackColor = System.Drawing.Color.White
        Me.txtInventoryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryID.ForeColor = System.Drawing.Color.Black
        Me.txtInventoryID.Location = New System.Drawing.Point(167, 60)
        Me.txtInventoryID.Margin = New System.Windows.Forms.Padding(0)
        Me.txtInventoryID.Name = "txtInventoryID"
        Me.txtInventoryID.ReadOnly = True
        Me.txtInventoryID.Size = New System.Drawing.Size(200, 25)
        Me.txtInventoryID.TabIndex = 0
        Me.txtInventoryID.TabStop = False
        '
        'lblStore
        '
        Me.lblStore.AutoSize = True
        Me.lblStore.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblStore.ForeColor = System.Drawing.Color.Black
        Me.lblStore.Location = New System.Drawing.Point(118, 198)
        Me.lblStore.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(41, 19)
        Me.lblStore.TabIndex = 0
        Me.lblStore.Text = "Store"
        Me.lblStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStore
        '
        Me.txtStore.BackColor = System.Drawing.Color.White
        Me.txtStore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStore.ForeColor = System.Drawing.Color.Black
        Me.txtStore.Location = New System.Drawing.Point(167, 195)
        Me.txtStore.Margin = New System.Windows.Forms.Padding(0)
        Me.txtStore.MaxLength = 50
        Me.txtStore.Name = "txtStore"
        Me.txtStore.Size = New System.Drawing.Size(200, 25)
        Me.txtStore.TabIndex = 1
        '
        'frmEditInventory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(397, 520)
        Me.Controls.Add(Me.lblItemID)
        Me.Controls.Add(Me.txtItemID)
        Me.Controls.Add(Me.lblInventoryID)
        Me.Controls.Add(Me.txtInventoryID)
        Me.Controls.Add(Me.lblInformation)
        Me.Controls.Add(Me.txtInformation)
        Me.Controls.Add(Me.lblStore)
        Me.Controls.Add(Me.txtStore)
        Me.Controls.Add(Me.lblReceiptNo)
        Me.Controls.Add(Me.txtReceiptNo)
        Me.Controls.Add(Me.lblDateReceived)
        Me.Controls.Add(Me.dtpDateReceived)
        Me.Controls.Add(Me.lblCostPerUnit)
        Me.Controls.Add(Me.numCostPerUnit)
        Me.Controls.Add(Me.lblGood)
        Me.Controls.Add(Me.numGood)
        Me.Controls.Add(Me.lblDamaged)
        Me.Controls.Add(Me.numDamaged)
        Me.Controls.Add(Me.lblMaintenance)
        Me.Controls.Add(Me.numMaintenance)
        Me.Controls.Add(Me.lblReplacement)
        Me.Controls.Add(Me.numReplacement)
        Me.Controls.Add(Me.btnEdit)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditInventory"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Inventory"
        CType(Me.numCostPerUnit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGood, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDamaged, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numReplacement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblInformation As Label
    Private WithEvents lblReceiptNo As Label
    Private WithEvents lblDateReceived As Label
    Private WithEvents lblCostPerUnit As Label
    Private WithEvents lblGood As Label
    Private WithEvents txtInformation As TextBox
    Private WithEvents numCostPerUnit As NumericUpDown
    Private WithEvents btnEdit As Button
    Private WithEvents err As ErrorProvider
    Private WithEvents numReplacement As NumericUpDown
    Private WithEvents numMaintenance As NumericUpDown
    Private WithEvents numDamaged As NumericUpDown
    Private WithEvents numGood As NumericUpDown
    Private WithEvents txtReceiptNo As TextBox
    Private WithEvents lblReplacement As Label
    Private WithEvents lblMaintenance As Label
    Private WithEvents lblDamaged As Label
    Private WithEvents dtpDateReceived As DateTimePicker
    Private WithEvents lblItemID As Label
    Private WithEvents txtItemID As TextBox
    Private WithEvents lblInventoryID As Label
    Private WithEvents txtInventoryID As TextBox
    Private WithEvents lblStore As Label
    Private WithEvents txtStore As TextBox
End Class
