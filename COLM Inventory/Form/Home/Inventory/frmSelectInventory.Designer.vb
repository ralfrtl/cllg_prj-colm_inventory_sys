<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectInventory
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.colInventoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInformation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostPerUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGood = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDamaged = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMaintenance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReplacement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.tltp = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtSearch = New COLM_Inventory.ctrlPaddedTextBox()
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.pnlRibbon = New System.Windows.Forms.Panel()
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
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRibbon.SuspendLayout()
        Me.pnlItem.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.AutoEllipsis = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Location = New System.Drawing.Point(560, 500)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnContinue
        '
        Me.btnContinue.AutoEllipsis = True
        Me.btnContinue.BackColor = System.Drawing.Color.Green
        Me.btnContinue.FlatAppearance.BorderSize = 0
        Me.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContinue.ForeColor = System.Drawing.Color.White
        Me.btnContinue.Location = New System.Drawing.Point(670, 500)
        Me.btnContinue.Margin = New System.Windows.Forms.Padding(0, 0, 30, 30)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(100, 30)
        Me.btnContinue.TabIndex = 3
        Me.btnContinue.Text = "Continue"
        Me.btnContinue.UseVisualStyleBackColor = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToOrderColumns = True
        Me.dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInventoryID, Me.colInformation, Me.colInvoice, Me.colStore, Me.colReceiptNo, Me.colDateReceived, Me.colCostPerUnit, Me.colGood, Me.colDamaged, Me.colMaintenance, Me.colReplacement})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(30, 160)
        Me.dgv.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(741, 310)
        Me.dgv.TabIndex = 1
        '
        'colInventoryID
        '
        Me.colInventoryID.FillWeight = 253.8071!
        Me.colInventoryID.HeaderText = "ID"
        Me.colInventoryID.Name = "colInventoryID"
        Me.colInventoryID.ReadOnly = True
        '
        'colInformation
        '
        Me.colInformation.FillWeight = 221.3485!
        Me.colInformation.HeaderText = "Information"
        Me.colInformation.Name = "colInformation"
        Me.colInformation.ReadOnly = True
        Me.colInformation.Width = 200
        '
        'colInvoice
        '
        Me.colInvoice.FillWeight = 24.75739!
        Me.colInvoice.HeaderText = "Invoice"
        Me.colInvoice.Name = "colInvoice"
        Me.colInvoice.ReadOnly = True
        Me.colInvoice.Width = 200
        '
        'colStore
        '
        Me.colStore.HeaderText = "Store"
        Me.colStore.Name = "colStore"
        Me.colStore.ReadOnly = True
        Me.colStore.Visible = False
        '
        'colReceiptNo
        '
        Me.colReceiptNo.HeaderText = "ReceiptNo"
        Me.colReceiptNo.Name = "colReceiptNo"
        Me.colReceiptNo.ReadOnly = True
        Me.colReceiptNo.Visible = False
        '
        'colDateReceived
        '
        Me.colDateReceived.HeaderText = "DateReceived"
        Me.colDateReceived.Name = "colDateReceived"
        Me.colDateReceived.ReadOnly = True
        Me.colDateReceived.Visible = False
        '
        'colCostPerUnit
        '
        Me.colCostPerUnit.HeaderText = "CostPerUnit"
        Me.colCostPerUnit.Name = "colCostPerUnit"
        Me.colCostPerUnit.ReadOnly = True
        Me.colCostPerUnit.Visible = False
        '
        'colGood
        '
        Me.colGood.FillWeight = 0.03405144!
        Me.colGood.HeaderText = "Good"
        Me.colGood.Name = "colGood"
        Me.colGood.ReadOnly = True
        Me.colGood.Width = 120
        '
        'colDamaged
        '
        Me.colDamaged.FillWeight = 0.0529868!
        Me.colDamaged.HeaderText = "Damaged"
        Me.colDamaged.Name = "colDamaged"
        Me.colDamaged.ReadOnly = True
        Me.colDamaged.Width = 120
        '
        'colMaintenance
        '
        Me.colMaintenance.HeaderText = "Maintenance"
        Me.colMaintenance.Name = "colMaintenance"
        Me.colMaintenance.ReadOnly = True
        Me.colMaintenance.Visible = False
        '
        'colReplacement
        '
        Me.colReplacement.HeaderText = "Replacement"
        Me.colReplacement.Name = "colReplacement"
        Me.colReplacement.ReadOnly = True
        Me.colReplacement.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Image = Global.COLM_Inventory.My.Resources.Resources.AddRecord
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(30, 5)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdd.MinimumSize = New System.Drawing.Size(0, 30)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnAdd.Size = New System.Drawing.Size(69, 30)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = " Add"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.tltp.SetToolTip(Me.btnAdd, "(Ctrl + Shift + A)")
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.BackgroundImage = Global.COLM_Inventory.My.Resources.Resources.Search
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.Green
        Me.btnSearch.Location = New System.Drawing.Point(740, 5)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(30, 30)
        Me.btnSearch.TabIndex = 3
        Me.tltp.SetToolTip(Me.btnSearch, "Search")
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImage = Global.COLM_Inventory.My.Resources.Resources.Refresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(104, 5)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(30, 30)
        Me.btnRefresh.TabIndex = 1
        Me.tltp.SetToolTip(Me.btnRefresh, "Refresh (F5)")
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.Location = New System.Drawing.Point(540, 5)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSearch.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Padding = New System.Windows.Forms.Padding(10, 6, 5, 6)
        Me.txtSearch.Size = New System.Drawing.Size(200, 30)
        Me.txtSearch.TabIndex = 2
        Me.tltp.SetToolTip(Me.txtSearch, "Search (Ctrl + Shift + S)")
        '
        'lblDiv
        '
        Me.lblDiv.BackColor = System.Drawing.Color.Green
        Me.lblDiv.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDiv.Location = New System.Drawing.Point(0, 40)
        Me.lblDiv.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(800, 5)
        Me.lblDiv.TabIndex = 0
        '
        'pnlRibbon
        '
        Me.pnlRibbon.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlRibbon.Controls.Add(Me.btnAdd)
        Me.pnlRibbon.Controls.Add(Me.btnRefresh)
        Me.pnlRibbon.Controls.Add(Me.txtSearch)
        Me.pnlRibbon.Controls.Add(Me.btnSearch)
        Me.pnlRibbon.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRibbon.ForeColor = System.Drawing.Color.White
        Me.pnlRibbon.Location = New System.Drawing.Point(0, 0)
        Me.pnlRibbon.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRibbon.Name = "pnlRibbon"
        Me.pnlRibbon.Size = New System.Drawing.Size(800, 40)
        Me.pnlRibbon.TabIndex = 0
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
        Me.pnlItem.Location = New System.Drawing.Point(30, 75)
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
        'frmSelectInventory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(800, 560)
        Me.Controls.Add(Me.lblDiv)
        Me.Controls.Add(Me.pnlRibbon)
        Me.Controls.Add(Me.pnlItem)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnContinue)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectInventory"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Inventory"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRibbon.ResumeLayout(False)
        Me.pnlRibbon.PerformLayout()
        Me.pnlItem.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents btnCancel As Button
    Private WithEvents btnContinue As Button
    Private WithEvents dgv As DataGridView
    Private WithEvents btnAdd As Button
    Private WithEvents txtSearch As ctrlPaddedTextBox
    Private WithEvents btnSearch As Button
    Private WithEvents btnRefresh As Button
    Private WithEvents tltp As ToolTip
    Private WithEvents lblDiv As Label
    Private WithEvents pnlRibbon As Panel
    Private WithEvents colInventoryID As DataGridViewTextBoxColumn
    Private WithEvents colInformation As DataGridViewTextBoxColumn
    Private WithEvents colInvoice As DataGridViewTextBoxColumn
    Private WithEvents colStore As DataGridViewTextBoxColumn
    Private WithEvents colReceiptNo As DataGridViewTextBoxColumn
    Private WithEvents colDateReceived As DataGridViewTextBoxColumn
    Private WithEvents colCostPerUnit As DataGridViewTextBoxColumn
    Private WithEvents colGood As DataGridViewTextBoxColumn
    Private WithEvents colDamaged As DataGridViewTextBoxColumn
    Private WithEvents colMaintenance As DataGridViewTextBoxColumn
    Private WithEvents colReplacement As DataGridViewTextBoxColumn
    Private WithEvents pnlItem As Panel
    Private WithEvents lblItemID As Label
    Private WithEvents lblItemName As Label
    Private WithEvents lblItemDescription As Label
    Private WithEvents lblItemType As Label
    Private WithEvents lblUnitType As Label
    Private WithEvents lblItemIDVal As Label
    Private WithEvents lblItemNameVal As Label
    Private WithEvents lblItemDescriptionVal As Label
    Private WithEvents lblItemTypeVal As Label
    Private WithEvents lblUnitTypeVal As Label
End Class
