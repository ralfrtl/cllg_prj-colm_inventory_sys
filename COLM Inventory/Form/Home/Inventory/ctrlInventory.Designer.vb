<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlInventory
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlRibbon = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtSearch = New COLM_Inventory.ctrlPaddedTextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cbtnMore = New System.Windows.Forms.CheckBox()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.cbtnFilter = New System.Windows.Forms.CheckBox()
        Me.cbtnMatchWholeWord = New System.Windows.Forms.CheckBox()
        Me.cbtnMatchEveryField = New System.Windows.Forms.CheckBox()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.numTop = New System.Windows.Forms.NumericUpDown()
        Me.lblPreview = New System.Windows.Forms.Label()
        Me.cbtnInventoryID = New System.Windows.Forms.CheckBox()
        Me.cbtnInformation = New System.Windows.Forms.CheckBox()
        Me.cbtnStore = New System.Windows.Forms.CheckBox()
        Me.cbtnReceiptNo = New System.Windows.Forms.CheckBox()
        Me.cbtnDateReceived = New System.Windows.Forms.CheckBox()
        Me.cbtnCostPerUnit = New System.Windows.Forms.CheckBox()
        Me.cbtnGood = New System.Windows.Forms.CheckBox()
        Me.cbtnDamaged = New System.Windows.Forms.CheckBox()
        Me.cbtnMaintenance = New System.Windows.Forms.CheckBox()
        Me.cbtnReplacement = New System.Windows.Forms.CheckBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.colInventoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInformation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostPerUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGood = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDamaged = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMaintenance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReplacement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tltp = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.pnlRibbon.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        CType(Me.numTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlRibbon
        '
        Me.pnlRibbon.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlRibbon.Controls.Add(Me.btnAdd)
        Me.pnlRibbon.Controls.Add(Me.btnEdit)
        Me.pnlRibbon.Controls.Add(Me.btnDelete)
        Me.pnlRibbon.Controls.Add(Me.btnRefresh)
        Me.pnlRibbon.Controls.Add(Me.txtSearch)
        Me.pnlRibbon.Controls.Add(Me.btnSearch)
        Me.pnlRibbon.Controls.Add(Me.cbtnMore)
        Me.pnlRibbon.Controls.Add(Me.pnlFilter)
        Me.pnlRibbon.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRibbon.ForeColor = System.Drawing.Color.White
        Me.pnlRibbon.Location = New System.Drawing.Point(0, 0)
        Me.pnlRibbon.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRibbon.Name = "pnlRibbon"
        Me.pnlRibbon.Size = New System.Drawing.Size(900, 145)
        Me.pnlRibbon.TabIndex = 0
        Me.pnlRibbon.TabStop = True
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Image = Global.COLM_Inventory.My.Resources.Resources.AddRecord
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(5, 5)
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
        'btnEdit
        '
        Me.btnEdit.AutoSize = True
        Me.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Image = Global.COLM_Inventory.My.Resources.Resources.EditRecord
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(79, 5)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEdit.MinimumSize = New System.Drawing.Size(0, 30)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnEdit.Size = New System.Drawing.Size(67, 30)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = " Edit"
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.tltp.SetToolTip(Me.btnEdit, "(Ctrl + Shift + E)")
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.AutoSize = True
        Me.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Image = Global.COLM_Inventory.My.Resources.Resources.DeleteRecord
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(151, 5)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDelete.MinimumSize = New System.Drawing.Size(0, 30)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDelete.Size = New System.Drawing.Size(83, 30)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = " Delete"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.tltp.SetToolTip(Me.btnDelete, "(Ctrl + Shift + D)")
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImage = Global.COLM_Inventory.My.Resources.Resources.Refresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(239, 5)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(30, 30)
        Me.btnRefresh.TabIndex = 3
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
        Me.txtSearch.Location = New System.Drawing.Point(630, 5)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSearch.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Padding = New System.Windows.Forms.Padding(10, 6, 5, 6)
        Me.txtSearch.Size = New System.Drawing.Size(200, 30)
        Me.txtSearch.TabIndex = 4
        Me.tltp.SetToolTip(Me.txtSearch, "Search (Ctrl + Shift + S)")
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
        Me.btnSearch.Location = New System.Drawing.Point(830, 5)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(30, 30)
        Me.btnSearch.TabIndex = 5
        Me.tltp.SetToolTip(Me.btnSearch, "Search")
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cbtnMore
        '
        Me.cbtnMore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbtnMore.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbtnMore.BackgroundImage = Global.COLM_Inventory.My.Resources.Resources.Options
        Me.cbtnMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cbtnMore.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbtnMore.FlatAppearance.BorderSize = 0
        Me.cbtnMore.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cbtnMore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cbtnMore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cbtnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbtnMore.Location = New System.Drawing.Point(865, 5)
        Me.cbtnMore.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnMore.Name = "cbtnMore"
        Me.cbtnMore.Size = New System.Drawing.Size(30, 30)
        Me.cbtnMore.TabIndex = 6
        Me.tltp.SetToolTip(Me.cbtnMore, "More (Ctrl + Shift + M)")
        Me.cbtnMore.UseVisualStyleBackColor = True
        '
        'pnlFilter
        '
        Me.pnlFilter.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlFilter.AutoSize = True
        Me.pnlFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFilter.Controls.Add(Me.cbtnFilter)
        Me.pnlFilter.Controls.Add(Me.cbtnMatchWholeWord)
        Me.pnlFilter.Controls.Add(Me.cbtnMatchEveryField)
        Me.pnlFilter.Controls.Add(Me.lblTop)
        Me.pnlFilter.Controls.Add(Me.numTop)
        Me.pnlFilter.Controls.Add(Me.lblPreview)
        Me.pnlFilter.Controls.Add(Me.cbtnInventoryID)
        Me.pnlFilter.Controls.Add(Me.cbtnInformation)
        Me.pnlFilter.Controls.Add(Me.cbtnStore)
        Me.pnlFilter.Controls.Add(Me.cbtnReceiptNo)
        Me.pnlFilter.Controls.Add(Me.cbtnDateReceived)
        Me.pnlFilter.Controls.Add(Me.cbtnCostPerUnit)
        Me.pnlFilter.Controls.Add(Me.cbtnGood)
        Me.pnlFilter.Controls.Add(Me.cbtnDamaged)
        Me.pnlFilter.Controls.Add(Me.cbtnMaintenance)
        Me.pnlFilter.Controls.Add(Me.cbtnReplacement)
        Me.pnlFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlFilter.Location = New System.Drawing.Point(227, 40)
        Me.pnlFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(447, 98)
        Me.pnlFilter.TabIndex = 7
        Me.pnlFilter.TabStop = True
        '
        'cbtnFilter
        '
        Me.cbtnFilter.AutoSize = True
        Me.cbtnFilter.Location = New System.Drawing.Point(5, 0)
        Me.cbtnFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnFilter.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnFilter.Name = "cbtnFilter"
        Me.cbtnFilter.Size = New System.Drawing.Size(99, 20)
        Me.cbtnFilter.TabIndex = 0
        Me.cbtnFilter.Text = "Advance filter"
        Me.cbtnFilter.UseVisualStyleBackColor = True
        '
        'cbtnMatchWholeWord
        '
        Me.cbtnMatchWholeWord.AutoSize = True
        Me.cbtnMatchWholeWord.Location = New System.Drawing.Point(5, 20)
        Me.cbtnMatchWholeWord.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnMatchWholeWord.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnMatchWholeWord.Name = "cbtnMatchWholeWord"
        Me.cbtnMatchWholeWord.Size = New System.Drawing.Size(125, 20)
        Me.cbtnMatchWholeWord.TabIndex = 1
        Me.cbtnMatchWholeWord.Text = "Match whole word"
        Me.cbtnMatchWholeWord.UseVisualStyleBackColor = True
        '
        'cbtnMatchEveryField
        '
        Me.cbtnMatchEveryField.AutoSize = True
        Me.cbtnMatchEveryField.Location = New System.Drawing.Point(5, 40)
        Me.cbtnMatchEveryField.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnMatchEveryField.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnMatchEveryField.Name = "cbtnMatchEveryField"
        Me.cbtnMatchEveryField.Size = New System.Drawing.Size(117, 20)
        Me.cbtnMatchEveryField.TabIndex = 2
        Me.cbtnMatchEveryField.Text = "Match every field"
        Me.cbtnMatchEveryField.UseVisualStyleBackColor = True
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.Location = New System.Drawing.Point(5, 64)
        Me.lblTop.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(30, 15)
        Me.lblTop.TabIndex = 0
        Me.lblTop.Text = "Top:"
        Me.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numTop
        '
        Me.numTop.BackColor = System.Drawing.Color.White
        Me.numTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numTop.ForeColor = System.Drawing.Color.Black
        Me.numTop.Location = New System.Drawing.Point(35, 60)
        Me.numTop.Margin = New System.Windows.Forms.Padding(0)
        Me.numTop.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numTop.Name = "numTop"
        Me.numTop.Size = New System.Drawing.Size(50, 23)
        Me.numTop.TabIndex = 3
        Me.numTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numTop.ThousandsSeparator = True
        Me.tltp.SetToolTip(Me.numTop, "Set 0 as the value to show all results.")
        Me.numTop.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'lblPreview
        '
        Me.lblPreview.AutoEllipsis = True
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Location = New System.Drawing.Point(5, 83)
        Me.lblPreview.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(48, 15)
        Me.lblPreview.TabIndex = 0
        Me.lblPreview.Text = "Preview"
        Me.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbtnInventoryID
        '
        Me.cbtnInventoryID.AutoSize = True
        Me.cbtnInventoryID.Location = New System.Drawing.Point(130, 0)
        Me.cbtnInventoryID.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnInventoryID.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnInventoryID.Name = "cbtnInventoryID"
        Me.cbtnInventoryID.Size = New System.Drawing.Size(90, 20)
        Me.cbtnInventoryID.TabIndex = 4
        Me.cbtnInventoryID.Text = "Inventory ID"
        Me.cbtnInventoryID.UseVisualStyleBackColor = True
        '
        'cbtnInformation
        '
        Me.cbtnInformation.AutoSize = True
        Me.cbtnInformation.Location = New System.Drawing.Point(130, 20)
        Me.cbtnInformation.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnInformation.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnInformation.Name = "cbtnInformation"
        Me.cbtnInformation.Size = New System.Drawing.Size(89, 20)
        Me.cbtnInformation.TabIndex = 5
        Me.cbtnInformation.Text = "Information"
        Me.cbtnInformation.UseVisualStyleBackColor = True
        '
        'cbtnStore
        '
        Me.cbtnStore.AutoSize = True
        Me.cbtnStore.Location = New System.Drawing.Point(220, 0)
        Me.cbtnStore.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnStore.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnStore.Name = "cbtnStore"
        Me.cbtnStore.Size = New System.Drawing.Size(53, 20)
        Me.cbtnStore.TabIndex = 6
        Me.cbtnStore.Text = "Store"
        Me.cbtnStore.UseVisualStyleBackColor = True
        '
        'cbtnReceiptNo
        '
        Me.cbtnReceiptNo.AutoSize = True
        Me.cbtnReceiptNo.Location = New System.Drawing.Point(220, 20)
        Me.cbtnReceiptNo.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnReceiptNo.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnReceiptNo.Name = "cbtnReceiptNo"
        Me.cbtnReceiptNo.Size = New System.Drawing.Size(84, 20)
        Me.cbtnReceiptNo.TabIndex = 7
        Me.cbtnReceiptNo.Text = "Receipt No"
        Me.cbtnReceiptNo.UseVisualStyleBackColor = True
        '
        'cbtnDateReceived
        '
        Me.cbtnDateReceived.AutoSize = True
        Me.cbtnDateReceived.Location = New System.Drawing.Point(220, 40)
        Me.cbtnDateReceived.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnDateReceived.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnDateReceived.Name = "cbtnDateReceived"
        Me.cbtnDateReceived.Size = New System.Drawing.Size(97, 20)
        Me.cbtnDateReceived.TabIndex = 8
        Me.cbtnDateReceived.Text = "Data received"
        Me.cbtnDateReceived.UseVisualStyleBackColor = True
        '
        'cbtnCostPerUnit
        '
        Me.cbtnCostPerUnit.AutoSize = True
        Me.cbtnCostPerUnit.Location = New System.Drawing.Point(220, 60)
        Me.cbtnCostPerUnit.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnCostPerUnit.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnCostPerUnit.Name = "cbtnCostPerUnit"
        Me.cbtnCostPerUnit.Size = New System.Drawing.Size(94, 20)
        Me.cbtnCostPerUnit.TabIndex = 9
        Me.cbtnCostPerUnit.Text = "Cost per unit"
        Me.cbtnCostPerUnit.UseVisualStyleBackColor = True
        '
        'cbtnGood
        '
        Me.cbtnGood.AutoSize = True
        Me.cbtnGood.Location = New System.Drawing.Point(317, 0)
        Me.cbtnGood.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnGood.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnGood.Name = "cbtnGood"
        Me.cbtnGood.Size = New System.Drawing.Size(55, 20)
        Me.cbtnGood.TabIndex = 10
        Me.cbtnGood.Text = "Good"
        Me.cbtnGood.UseVisualStyleBackColor = True
        '
        'cbtnDamaged
        '
        Me.cbtnDamaged.AutoSize = True
        Me.cbtnDamaged.Location = New System.Drawing.Point(317, 20)
        Me.cbtnDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnDamaged.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnDamaged.Name = "cbtnDamaged"
        Me.cbtnDamaged.Size = New System.Drawing.Size(77, 20)
        Me.cbtnDamaged.TabIndex = 11
        Me.cbtnDamaged.Text = "Damaged"
        Me.cbtnDamaged.UseVisualStyleBackColor = True
        '
        'cbtnMaintenance
        '
        Me.cbtnMaintenance.AutoSize = True
        Me.cbtnMaintenance.Location = New System.Drawing.Point(317, 40)
        Me.cbtnMaintenance.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnMaintenance.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnMaintenance.Name = "cbtnMaintenance"
        Me.cbtnMaintenance.Size = New System.Drawing.Size(130, 20)
        Me.cbtnMaintenance.TabIndex = 12
        Me.cbtnMaintenance.Text = "Under maintenance"
        Me.cbtnMaintenance.UseVisualStyleBackColor = True
        '
        'cbtnReplacement
        '
        Me.cbtnReplacement.AutoSize = True
        Me.cbtnReplacement.Location = New System.Drawing.Point(317, 60)
        Me.cbtnReplacement.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnReplacement.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnReplacement.Name = "cbtnReplacement"
        Me.cbtnReplacement.Size = New System.Drawing.Size(112, 20)
        Me.cbtnReplacement.TabIndex = 13
        Me.cbtnReplacement.Text = "For replacement"
        Me.cbtnReplacement.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToOrderColumns = True
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
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInventoryID, Me.colInformation, Me.colStore, Me.colReceiptNo, Me.colDateReceived, Me.colCostPerUnit, Me.colStatus, Me.colGood, Me.colDamaged, Me.colMaintenance, Me.colReplacement})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(0, 150)
        Me.dgv.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(900, 350)
        Me.dgv.TabIndex = 1
        '
        'colInventoryID
        '
        Me.colInventoryID.HeaderText = "ID"
        Me.colInventoryID.Name = "colInventoryID"
        Me.colInventoryID.ReadOnly = True
        '
        'colInformation
        '
        Me.colInformation.HeaderText = "Information"
        Me.colInformation.Name = "colInformation"
        Me.colInformation.ReadOnly = True
        Me.colInformation.Width = 200
        '
        'colStore
        '
        Me.colStore.HeaderText = "Store"
        Me.colStore.Name = "colStore"
        Me.colStore.ReadOnly = True
        '
        'colReceiptNo
        '
        Me.colReceiptNo.HeaderText = "Receipt No"
        Me.colReceiptNo.Name = "colReceiptNo"
        Me.colReceiptNo.ReadOnly = True
        '
        'colDateReceived
        '
        Me.colDateReceived.HeaderText = "Date received"
        Me.colDateReceived.Name = "colDateReceived"
        Me.colDateReceived.ReadOnly = True
        Me.colDateReceived.Width = 200
        '
        'colCostPerUnit
        '
        Me.colCostPerUnit.HeaderText = "Cost per unit"
        Me.colCostPerUnit.Name = "colCostPerUnit"
        Me.colCostPerUnit.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.Visible = False
        Me.colStatus.Width = 150
        '
        'colGood
        '
        Me.colGood.HeaderText = "Good"
        Me.colGood.Name = "colGood"
        Me.colGood.ReadOnly = True
        Me.colGood.Visible = False
        '
        'colDamaged
        '
        Me.colDamaged.HeaderText = "Damaged"
        Me.colDamaged.Name = "colDamaged"
        Me.colDamaged.ReadOnly = True
        Me.colDamaged.Visible = False
        '
        'colMaintenance
        '
        Me.colMaintenance.HeaderText = "Under maintenance"
        Me.colMaintenance.Name = "colMaintenance"
        Me.colMaintenance.ReadOnly = True
        Me.colMaintenance.Visible = False
        '
        'colReplacement
        '
        Me.colReplacement.HeaderText = "For replacement"
        Me.colReplacement.Name = "colReplacement"
        Me.colReplacement.ReadOnly = True
        Me.colReplacement.Visible = False
        '
        'lblDiv
        '
        Me.lblDiv.BackColor = System.Drawing.Color.Green
        Me.lblDiv.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDiv.Location = New System.Drawing.Point(0, 145)
        Me.lblDiv.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(900, 5)
        Me.lblDiv.TabIndex = 0
        '
        'ctrlInventory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.lblDiv)
        Me.Controls.Add(Me.pnlRibbon)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlInventory"
        Me.Size = New System.Drawing.Size(900, 500)
        Me.pnlRibbon.ResumeLayout(False)
        Me.pnlRibbon.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        CType(Me.numTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlRibbon As Panel
    Private WithEvents btnAdd As Button
    Private WithEvents btnRefresh As Button
    Private WithEvents btnEdit As Button
    Private WithEvents btnDelete As Button
    Private WithEvents btnSearch As Button
    Private WithEvents cbtnMatchEveryField As CheckBox
    Private WithEvents lblPreview As Label
    Private WithEvents tltp As ToolTip
    Private WithEvents dgv As DataGridView
    Private WithEvents txtSearch As ctrlPaddedTextBox
    Private WithEvents cbtnMore As CheckBox
    Private WithEvents pnlFilter As Panel
    Private WithEvents cbtnFilter As CheckBox
    Private WithEvents cbtnMatchWholeWord As CheckBox
    Private WithEvents cbtnInventoryID As CheckBox
    Private WithEvents cbtnInformation As CheckBox
    Private WithEvents cbtnReceiptNo As CheckBox
    Private WithEvents cbtnDateReceived As CheckBox
    Private WithEvents cbtnCostPerUnit As CheckBox
    Private WithEvents cbtnGood As CheckBox
    Private WithEvents cbtnDamaged As CheckBox
    Private WithEvents cbtnMaintenance As CheckBox
    Private WithEvents cbtnReplacement As CheckBox
    Private WithEvents lblTop As Label
    Private WithEvents numTop As NumericUpDown
    Private WithEvents cbtnStore As CheckBox
    Private WithEvents lblDiv As Label
    Private WithEvents colInventoryID As DataGridViewTextBoxColumn
    Private WithEvents colInformation As DataGridViewTextBoxColumn
    Private WithEvents colStore As DataGridViewTextBoxColumn
    Private WithEvents colReceiptNo As DataGridViewTextBoxColumn
    Private WithEvents colDateReceived As DataGridViewTextBoxColumn
    Private WithEvents colCostPerUnit As DataGridViewTextBoxColumn
    Private WithEvents colStatus As DataGridViewTextBoxColumn
    Private WithEvents colGood As DataGridViewTextBoxColumn
    Private WithEvents colDamaged As DataGridViewTextBoxColumn
    Private WithEvents colMaintenance As DataGridViewTextBoxColumn
    Private WithEvents colReplacement As DataGridViewTextBoxColumn
End Class
