<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlReservation
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.cbtnCustomerID = New System.Windows.Forms.CheckBox()
        Me.cbtnFirstName = New System.Windows.Forms.CheckBox()
        Me.cbtnMiddleName = New System.Windows.Forms.CheckBox()
        Me.cbtnLastName = New System.Windows.Forms.CheckBox()
        Me.cbtnPosition = New System.Windows.Forms.CheckBox()
        Me.cbtnDepartment = New System.Windows.Forms.CheckBox()
        Me.cbtnOffense = New System.Windows.Forms.CheckBox()
        Me.cbtnItemID = New System.Windows.Forms.CheckBox()
        Me.cbtnName = New System.Windows.Forms.CheckBox()
        Me.cbtnDescription = New System.Windows.Forms.CheckBox()
        Me.cbtnItemType = New System.Windows.Forms.CheckBox()
        Me.cbtnUnitType = New System.Windows.Forms.CheckBox()
        Me.cbtnLowThreshold = New System.Windows.Forms.CheckBox()
        Me.cbtnReservationID = New System.Windows.Forms.CheckBox()
        Me.cbtnQuantityNeeded = New System.Windows.Forms.CheckBox()
        Me.cbtnDateNeeded = New System.Windows.Forms.CheckBox()
        Me.cbtnExpired = New System.Windows.Forms.CheckBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.colReservationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomerID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMiddleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOffense = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLowThreshold = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantityNeeded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateNeeded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpired = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.pnlFilter.Controls.Add(Me.cbtnCustomerID)
        Me.pnlFilter.Controls.Add(Me.cbtnFirstName)
        Me.pnlFilter.Controls.Add(Me.cbtnMiddleName)
        Me.pnlFilter.Controls.Add(Me.cbtnLastName)
        Me.pnlFilter.Controls.Add(Me.cbtnPosition)
        Me.pnlFilter.Controls.Add(Me.cbtnDepartment)
        Me.pnlFilter.Controls.Add(Me.cbtnOffense)
        Me.pnlFilter.Controls.Add(Me.cbtnItemID)
        Me.pnlFilter.Controls.Add(Me.cbtnName)
        Me.pnlFilter.Controls.Add(Me.cbtnDescription)
        Me.pnlFilter.Controls.Add(Me.cbtnItemType)
        Me.pnlFilter.Controls.Add(Me.cbtnUnitType)
        Me.pnlFilter.Controls.Add(Me.cbtnLowThreshold)
        Me.pnlFilter.Controls.Add(Me.cbtnReservationID)
        Me.pnlFilter.Controls.Add(Me.cbtnQuantityNeeded)
        Me.pnlFilter.Controls.Add(Me.cbtnDateNeeded)
        Me.pnlFilter.Controls.Add(Me.cbtnExpired)
        Me.pnlFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlFilter.Location = New System.Drawing.Point(144, 40)
        Me.pnlFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(612, 98)
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
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Location = New System.Drawing.Point(5, 83)
        Me.lblPreview.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(48, 15)
        Me.lblPreview.TabIndex = 0
        Me.lblPreview.Text = "Preview"
        Me.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbtnCustomerID
        '
        Me.cbtnCustomerID.AutoSize = True
        Me.cbtnCustomerID.Location = New System.Drawing.Point(130, 0)
        Me.cbtnCustomerID.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnCustomerID.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnCustomerID.Name = "cbtnCustomerID"
        Me.cbtnCustomerID.Size = New System.Drawing.Size(92, 20)
        Me.cbtnCustomerID.TabIndex = 4
        Me.cbtnCustomerID.Text = "Customer ID"
        Me.cbtnCustomerID.UseVisualStyleBackColor = True
        '
        'cbtnFirstName
        '
        Me.cbtnFirstName.AutoSize = True
        Me.cbtnFirstName.Location = New System.Drawing.Point(130, 20)
        Me.cbtnFirstName.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnFirstName.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnFirstName.Name = "cbtnFirstName"
        Me.cbtnFirstName.Size = New System.Drawing.Size(81, 20)
        Me.cbtnFirstName.TabIndex = 5
        Me.cbtnFirstName.Text = "First name"
        Me.cbtnFirstName.UseVisualStyleBackColor = True
        '
        'cbtnMiddleName
        '
        Me.cbtnMiddleName.AutoSize = True
        Me.cbtnMiddleName.Location = New System.Drawing.Point(130, 40)
        Me.cbtnMiddleName.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnMiddleName.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnMiddleName.Name = "cbtnMiddleName"
        Me.cbtnMiddleName.Size = New System.Drawing.Size(96, 20)
        Me.cbtnMiddleName.TabIndex = 6
        Me.cbtnMiddleName.Text = "Middle name"
        Me.cbtnMiddleName.UseVisualStyleBackColor = True
        '
        'cbtnLastName
        '
        Me.cbtnLastName.AutoSize = True
        Me.cbtnLastName.Location = New System.Drawing.Point(130, 60)
        Me.cbtnLastName.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnLastName.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnLastName.Name = "cbtnLastName"
        Me.cbtnLastName.Size = New System.Drawing.Size(80, 20)
        Me.cbtnLastName.TabIndex = 7
        Me.cbtnLastName.Text = "Last name"
        Me.cbtnLastName.UseVisualStyleBackColor = True
        '
        'cbtnPosition
        '
        Me.cbtnPosition.AutoSize = True
        Me.cbtnPosition.Location = New System.Drawing.Point(226, 0)
        Me.cbtnPosition.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnPosition.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnPosition.Name = "cbtnPosition"
        Me.cbtnPosition.Size = New System.Drawing.Size(69, 20)
        Me.cbtnPosition.TabIndex = 8
        Me.cbtnPosition.Text = "Position"
        Me.cbtnPosition.UseVisualStyleBackColor = True
        '
        'cbtnDepartment
        '
        Me.cbtnDepartment.AutoSize = True
        Me.cbtnDepartment.Location = New System.Drawing.Point(226, 20)
        Me.cbtnDepartment.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnDepartment.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnDepartment.Name = "cbtnDepartment"
        Me.cbtnDepartment.Size = New System.Drawing.Size(89, 20)
        Me.cbtnDepartment.TabIndex = 9
        Me.cbtnDepartment.Text = "Department"
        Me.cbtnDepartment.UseVisualStyleBackColor = True
        '
        'cbtnOffense
        '
        Me.cbtnOffense.AutoSize = True
        Me.cbtnOffense.Location = New System.Drawing.Point(226, 40)
        Me.cbtnOffense.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnOffense.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnOffense.Name = "cbtnOffense"
        Me.cbtnOffense.Size = New System.Drawing.Size(67, 20)
        Me.cbtnOffense.TabIndex = 10
        Me.cbtnOffense.Text = "Offense"
        Me.cbtnOffense.UseVisualStyleBackColor = True
        '
        'cbtnItemID
        '
        Me.cbtnItemID.AutoSize = True
        Me.cbtnItemID.Location = New System.Drawing.Point(315, 0)
        Me.cbtnItemID.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnItemID.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnItemID.Name = "cbtnItemID"
        Me.cbtnItemID.Size = New System.Drawing.Size(64, 20)
        Me.cbtnItemID.TabIndex = 11
        Me.cbtnItemID.Text = "Item ID"
        Me.cbtnItemID.UseVisualStyleBackColor = True
        '
        'cbtnName
        '
        Me.cbtnName.AutoSize = True
        Me.cbtnName.Location = New System.Drawing.Point(315, 20)
        Me.cbtnName.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnName.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnName.Name = "cbtnName"
        Me.cbtnName.Size = New System.Drawing.Size(58, 20)
        Me.cbtnName.TabIndex = 12
        Me.cbtnName.Text = "Name"
        Me.cbtnName.UseVisualStyleBackColor = True
        '
        'cbtnDescription
        '
        Me.cbtnDescription.AutoSize = True
        Me.cbtnDescription.Location = New System.Drawing.Point(315, 40)
        Me.cbtnDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnDescription.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnDescription.Name = "cbtnDescription"
        Me.cbtnDescription.Size = New System.Drawing.Size(86, 20)
        Me.cbtnDescription.TabIndex = 13
        Me.cbtnDescription.Text = "Description"
        Me.cbtnDescription.UseVisualStyleBackColor = True
        '
        'cbtnItemType
        '
        Me.cbtnItemType.AutoSize = True
        Me.cbtnItemType.Location = New System.Drawing.Point(401, 0)
        Me.cbtnItemType.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnItemType.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnItemType.Name = "cbtnItemType"
        Me.cbtnItemType.Size = New System.Drawing.Size(76, 20)
        Me.cbtnItemType.TabIndex = 14
        Me.cbtnItemType.Text = "Item type"
        Me.cbtnItemType.UseVisualStyleBackColor = True
        '
        'cbtnUnitType
        '
        Me.cbtnUnitType.AutoSize = True
        Me.cbtnUnitType.Location = New System.Drawing.Point(401, 20)
        Me.cbtnUnitType.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnUnitType.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnUnitType.Name = "cbtnUnitType"
        Me.cbtnUnitType.Size = New System.Drawing.Size(74, 20)
        Me.cbtnUnitType.TabIndex = 15
        Me.cbtnUnitType.Text = "Unit type"
        Me.cbtnUnitType.UseVisualStyleBackColor = True
        '
        'cbtnLowThreshold
        '
        Me.cbtnLowThreshold.AutoSize = True
        Me.cbtnLowThreshold.Location = New System.Drawing.Point(401, 40)
        Me.cbtnLowThreshold.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnLowThreshold.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnLowThreshold.Name = "cbtnLowThreshold"
        Me.cbtnLowThreshold.Size = New System.Drawing.Size(97, 20)
        Me.cbtnLowThreshold.TabIndex = 16
        Me.cbtnLowThreshold.Text = "Low theshold"
        Me.cbtnLowThreshold.UseVisualStyleBackColor = True
        '
        'cbtnReservationID
        '
        Me.cbtnReservationID.AutoSize = True
        Me.cbtnReservationID.Location = New System.Drawing.Point(498, 0)
        Me.cbtnReservationID.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnReservationID.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnReservationID.Name = "cbtnReservationID"
        Me.cbtnReservationID.Size = New System.Drawing.Size(101, 20)
        Me.cbtnReservationID.TabIndex = 17
        Me.cbtnReservationID.Text = "Reservation ID"
        Me.cbtnReservationID.UseVisualStyleBackColor = True
        '
        'cbtnQuantityNeeded
        '
        Me.cbtnQuantityNeeded.AutoSize = True
        Me.cbtnQuantityNeeded.Location = New System.Drawing.Point(498, 20)
        Me.cbtnQuantityNeeded.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnQuantityNeeded.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnQuantityNeeded.Name = "cbtnQuantityNeeded"
        Me.cbtnQuantityNeeded.Size = New System.Drawing.Size(114, 20)
        Me.cbtnQuantityNeeded.TabIndex = 18
        Me.cbtnQuantityNeeded.Text = "Quantity needed"
        Me.cbtnQuantityNeeded.UseVisualStyleBackColor = True
        '
        'cbtnDateNeeded
        '
        Me.cbtnDateNeeded.AutoSize = True
        Me.cbtnDateNeeded.Location = New System.Drawing.Point(498, 40)
        Me.cbtnDateNeeded.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnDateNeeded.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnDateNeeded.Name = "cbtnDateNeeded"
        Me.cbtnDateNeeded.Size = New System.Drawing.Size(92, 20)
        Me.cbtnDateNeeded.TabIndex = 19
        Me.cbtnDateNeeded.Text = "Date needed"
        Me.cbtnDateNeeded.UseVisualStyleBackColor = True
        '
        'cbtnExpired
        '
        Me.cbtnExpired.AutoSize = True
        Me.cbtnExpired.Location = New System.Drawing.Point(498, 60)
        Me.cbtnExpired.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnExpired.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnExpired.Name = "cbtnExpired"
        Me.cbtnExpired.Size = New System.Drawing.Size(64, 20)
        Me.cbtnExpired.TabIndex = 20
        Me.cbtnExpired.Text = "Expired"
        Me.cbtnExpired.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReservationID, Me.colCustomer, Me.colCustomerID, Me.colFirstName, Me.colMiddleName, Me.colLastName, Me.colPosition, Me.colDepartment, Me.colOffense, Me.colItem, Me.colItemID, Me.colName, Me.colDescription, Me.colItemType, Me.colUnitType, Me.colLowThreshold, Me.colQuantityNeeded, Me.colDateNeeded, Me.colExpired})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(0, 150)
        Me.dgv.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(900, 350)
        Me.dgv.TabIndex = 1
        '
        'colReservationID
        '
        Me.colReservationID.HeaderText = "ID"
        Me.colReservationID.Name = "colReservationID"
        Me.colReservationID.ReadOnly = True
        '
        'colCustomer
        '
        Me.colCustomer.HeaderText = "Reserved by"
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.ReadOnly = True
        Me.colCustomer.Width = 200
        '
        'colCustomerID
        '
        Me.colCustomerID.HeaderText = "CustomerID"
        Me.colCustomerID.Name = "colCustomerID"
        Me.colCustomerID.ReadOnly = True
        Me.colCustomerID.Visible = False
        '
        'colFirstName
        '
        Me.colFirstName.HeaderText = "First"
        Me.colFirstName.Name = "colFirstName"
        Me.colFirstName.ReadOnly = True
        Me.colFirstName.Visible = False
        '
        'colMiddleName
        '
        Me.colMiddleName.HeaderText = "Middle"
        Me.colMiddleName.Name = "colMiddleName"
        Me.colMiddleName.ReadOnly = True
        Me.colMiddleName.Visible = False
        '
        'colLastName
        '
        Me.colLastName.HeaderText = "Last"
        Me.colLastName.Name = "colLastName"
        Me.colLastName.ReadOnly = True
        Me.colLastName.Visible = False
        '
        'colPosition
        '
        Me.colPosition.HeaderText = "Position"
        Me.colPosition.Name = "colPosition"
        Me.colPosition.ReadOnly = True
        Me.colPosition.Visible = False
        '
        'colDepartment
        '
        Me.colDepartment.HeaderText = "Department"
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.ReadOnly = True
        Me.colDepartment.Visible = False
        '
        'colOffense
        '
        Me.colOffense.HeaderText = "Offense"
        Me.colOffense.Name = "colOffense"
        Me.colOffense.ReadOnly = True
        Me.colOffense.Visible = False
        '
        'colItem
        '
        Me.colItem.HeaderText = "Item"
        Me.colItem.Name = "colItem"
        Me.colItem.ReadOnly = True
        Me.colItem.Width = 200
        '
        'colItemID
        '
        Me.colItemID.HeaderText = "ItemID"
        Me.colItemID.Name = "colItemID"
        Me.colItemID.ReadOnly = True
        Me.colItemID.Visible = False
        '
        'colName
        '
        Me.colName.HeaderText = "Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        Me.colName.Visible = False
        '
        'colDescription
        '
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Visible = False
        Me.colDescription.Width = 200
        '
        'colItemType
        '
        Me.colItemType.HeaderText = "Item type"
        Me.colItemType.Name = "colItemType"
        Me.colItemType.ReadOnly = True
        Me.colItemType.Visible = False
        '
        'colUnitType
        '
        Me.colUnitType.HeaderText = "Unit type"
        Me.colUnitType.Name = "colUnitType"
        Me.colUnitType.ReadOnly = True
        Me.colUnitType.Visible = False
        '
        'colLowThreshold
        '
        Me.colLowThreshold.HeaderText = "Low threshold"
        Me.colLowThreshold.Name = "colLowThreshold"
        Me.colLowThreshold.ReadOnly = True
        Me.colLowThreshold.Visible = False
        '
        'colQuantityNeeded
        '
        Me.colQuantityNeeded.HeaderText = "Quantity needed"
        Me.colQuantityNeeded.Name = "colQuantityNeeded"
        Me.colQuantityNeeded.ReadOnly = True
        '
        'colDateNeeded
        '
        Me.colDateNeeded.HeaderText = "Date needed"
        Me.colDateNeeded.Name = "colDateNeeded"
        Me.colDateNeeded.ReadOnly = True
        Me.colDateNeeded.Width = 200
        '
        'colExpired
        '
        Me.colExpired.HeaderText = "Expired"
        Me.colExpired.Name = "colExpired"
        Me.colExpired.ReadOnly = True
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
        'ctrlReservation
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.lblDiv)
        Me.Controls.Add(Me.pnlRibbon)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlReservation"
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
    Private WithEvents btnSearch As Button
    Private WithEvents cbtnMatchEveryField As CheckBox
    Private WithEvents lblTop As Label
    Private WithEvents numTop As NumericUpDown
    Private WithEvents lblPreview As Label
    Private WithEvents tltp As ToolTip
    Private WithEvents dgv As DataGridView
    Private WithEvents txtSearch As ctrlPaddedTextBox
    Private WithEvents cbtnMore As CheckBox
    Private WithEvents pnlFilter As Panel
    Private WithEvents cbtnFilter As CheckBox
    Private WithEvents cbtnMatchWholeWord As CheckBox
    Private WithEvents cbtnItemID As CheckBox
    Private WithEvents cbtnDescription As CheckBox
    Private WithEvents cbtnItemType As CheckBox
    Private WithEvents cbtnUnitType As CheckBox
    Private WithEvents cbtnName As CheckBox
    Private WithEvents cbtnDepartment As CheckBox
    Private WithEvents cbtnPosition As CheckBox
    Private WithEvents cbtnCustomerID As CheckBox
    Private WithEvents cbtnQuantityNeeded As CheckBox
    Private WithEvents cbtnLastName As CheckBox
    Private WithEvents cbtnMiddleName As CheckBox
    Private WithEvents cbtnFirstName As CheckBox
    Private WithEvents cbtnReservationID As CheckBox
    Private WithEvents cbtnOffense As CheckBox
    Private WithEvents lblDiv As Label
    Private WithEvents cbtnDateNeeded As CheckBox
    Friend WithEvents colConsumeID As DataGridViewTextBoxColumn
    Private WithEvents cbtnLowThreshold As CheckBox
    Private WithEvents cbtnExpired As CheckBox
    Private WithEvents colReservationID As DataGridViewTextBoxColumn
    Private WithEvents colCustomer As DataGridViewTextBoxColumn
    Private WithEvents colCustomerID As DataGridViewTextBoxColumn
    Private WithEvents colFirstName As DataGridViewTextBoxColumn
    Private WithEvents colMiddleName As DataGridViewTextBoxColumn
    Private WithEvents colLastName As DataGridViewTextBoxColumn
    Private WithEvents colPosition As DataGridViewTextBoxColumn
    Private WithEvents colDepartment As DataGridViewTextBoxColumn
    Private WithEvents colOffense As DataGridViewTextBoxColumn
    Private WithEvents colItem As DataGridViewTextBoxColumn
    Private WithEvents colItemID As DataGridViewTextBoxColumn
    Private WithEvents colName As DataGridViewTextBoxColumn
    Private WithEvents colDescription As DataGridViewTextBoxColumn
    Private WithEvents colItemType As DataGridViewTextBoxColumn
    Private WithEvents colUnitType As DataGridViewTextBoxColumn
    Private WithEvents colLowThreshold As DataGridViewTextBoxColumn
    Private WithEvents colQuantityNeeded As DataGridViewTextBoxColumn
    Private WithEvents colDateNeeded As DataGridViewTextBoxColumn
    Private WithEvents colExpired As DataGridViewTextBoxColumn
    Private WithEvents btnDelete As Button
End Class
