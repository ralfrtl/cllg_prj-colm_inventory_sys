<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlItem
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
        Me.cbtnItemID = New System.Windows.Forms.CheckBox()
        Me.cbtnName = New System.Windows.Forms.CheckBox()
        Me.cbtnDescription = New System.Windows.Forms.CheckBox()
        Me.cbtnItemType = New System.Windows.Forms.CheckBox()
        Me.cbtnUnitType = New System.Windows.Forms.CheckBox()
        Me.cbtnLowThreshold = New System.Windows.Forms.CheckBox()
        Me.cbtnTotal = New System.Windows.Forms.CheckBox()
        Me.cbtnAvailable = New System.Windows.Forms.CheckBox()
        Me.cbtnBorrowed = New System.Windows.Forms.CheckBox()
        Me.cbtnStationed = New System.Windows.Forms.CheckBox()
        Me.cbtnReserved = New System.Windows.Forms.CheckBox()
        Me.cbtnGood = New System.Windows.Forms.CheckBox()
        Me.cbtnDamaged = New System.Windows.Forms.CheckBox()
        Me.cbtnMaintenance = New System.Windows.Forms.CheckBox()
        Me.cbtnReplacement = New System.Windows.Forms.CheckBox()
        Me.fpnlCardList = New System.Windows.Forms.FlowLayoutPanel()
        Me.tltp = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.pnlRibbon.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        CType(Me.numTop, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlFilter.Controls.Add(Me.cbtnItemID)
        Me.pnlFilter.Controls.Add(Me.cbtnName)
        Me.pnlFilter.Controls.Add(Me.cbtnDescription)
        Me.pnlFilter.Controls.Add(Me.cbtnItemType)
        Me.pnlFilter.Controls.Add(Me.cbtnUnitType)
        Me.pnlFilter.Controls.Add(Me.cbtnLowThreshold)
        Me.pnlFilter.Controls.Add(Me.cbtnTotal)
        Me.pnlFilter.Controls.Add(Me.cbtnAvailable)
        Me.pnlFilter.Controls.Add(Me.cbtnBorrowed)
        Me.pnlFilter.Controls.Add(Me.cbtnStationed)
        Me.pnlFilter.Controls.Add(Me.cbtnReserved)
        Me.pnlFilter.Controls.Add(Me.cbtnGood)
        Me.pnlFilter.Controls.Add(Me.cbtnDamaged)
        Me.pnlFilter.Controls.Add(Me.cbtnMaintenance)
        Me.pnlFilter.Controls.Add(Me.cbtnReplacement)
        Me.pnlFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlFilter.Location = New System.Drawing.Point(188, 40)
        Me.pnlFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(524, 100)
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
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Location = New System.Drawing.Point(5, 83)
        Me.lblPreview.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(48, 15)
        Me.lblPreview.TabIndex = 0
        Me.lblPreview.Text = "Preview"
        Me.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbtnItemID
        '
        Me.cbtnItemID.AutoSize = True
        Me.cbtnItemID.Location = New System.Drawing.Point(130, 0)
        Me.cbtnItemID.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnItemID.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnItemID.Name = "cbtnItemID"
        Me.cbtnItemID.Size = New System.Drawing.Size(64, 20)
        Me.cbtnItemID.TabIndex = 4
        Me.cbtnItemID.Text = "Item ID"
        Me.cbtnItemID.UseVisualStyleBackColor = True
        '
        'cbtnName
        '
        Me.cbtnName.AutoSize = True
        Me.cbtnName.Location = New System.Drawing.Point(130, 20)
        Me.cbtnName.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnName.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnName.Name = "cbtnName"
        Me.cbtnName.Size = New System.Drawing.Size(58, 20)
        Me.cbtnName.TabIndex = 5
        Me.cbtnName.Text = "Name"
        Me.cbtnName.UseVisualStyleBackColor = True
        '
        'cbtnDescription
        '
        Me.cbtnDescription.AutoSize = True
        Me.cbtnDescription.Location = New System.Drawing.Point(130, 40)
        Me.cbtnDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnDescription.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnDescription.Name = "cbtnDescription"
        Me.cbtnDescription.Size = New System.Drawing.Size(86, 20)
        Me.cbtnDescription.TabIndex = 6
        Me.cbtnDescription.Text = "Description"
        Me.cbtnDescription.UseVisualStyleBackColor = True
        '
        'cbtnItemType
        '
        Me.cbtnItemType.AutoSize = True
        Me.cbtnItemType.Location = New System.Drawing.Point(216, 0)
        Me.cbtnItemType.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnItemType.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnItemType.Name = "cbtnItemType"
        Me.cbtnItemType.Size = New System.Drawing.Size(76, 20)
        Me.cbtnItemType.TabIndex = 7
        Me.cbtnItemType.Text = "Item type"
        Me.cbtnItemType.UseVisualStyleBackColor = True
        '
        'cbtnUnitType
        '
        Me.cbtnUnitType.AutoSize = True
        Me.cbtnUnitType.Location = New System.Drawing.Point(216, 20)
        Me.cbtnUnitType.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnUnitType.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnUnitType.Name = "cbtnUnitType"
        Me.cbtnUnitType.Size = New System.Drawing.Size(74, 20)
        Me.cbtnUnitType.TabIndex = 8
        Me.cbtnUnitType.Text = "Unit type"
        Me.cbtnUnitType.UseVisualStyleBackColor = True
        '
        'cbtnLowThreshold
        '
        Me.cbtnLowThreshold.AutoSize = True
        Me.cbtnLowThreshold.Location = New System.Drawing.Point(216, 40)
        Me.cbtnLowThreshold.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnLowThreshold.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnLowThreshold.Name = "cbtnLowThreshold"
        Me.cbtnLowThreshold.Size = New System.Drawing.Size(101, 20)
        Me.cbtnLowThreshold.TabIndex = 9
        Me.cbtnLowThreshold.Text = "Low threshold"
        Me.cbtnLowThreshold.UseVisualStyleBackColor = True
        '
        'cbtnTotal
        '
        Me.cbtnTotal.AutoSize = True
        Me.cbtnTotal.Location = New System.Drawing.Point(317, 0)
        Me.cbtnTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnTotal.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnTotal.Name = "cbtnTotal"
        Me.cbtnTotal.Size = New System.Drawing.Size(52, 20)
        Me.cbtnTotal.TabIndex = 10
        Me.cbtnTotal.Text = "Total"
        Me.cbtnTotal.UseVisualStyleBackColor = True
        '
        'cbtnAvailable
        '
        Me.cbtnAvailable.AutoSize = True
        Me.cbtnAvailable.Location = New System.Drawing.Point(317, 20)
        Me.cbtnAvailable.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnAvailable.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnAvailable.Name = "cbtnAvailable"
        Me.cbtnAvailable.Size = New System.Drawing.Size(74, 20)
        Me.cbtnAvailable.TabIndex = 11
        Me.cbtnAvailable.Text = "Available"
        Me.cbtnAvailable.UseVisualStyleBackColor = True
        '
        'cbtnBorrowed
        '
        Me.cbtnBorrowed.AutoSize = True
        Me.cbtnBorrowed.Location = New System.Drawing.Point(317, 40)
        Me.cbtnBorrowed.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnBorrowed.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnBorrowed.Name = "cbtnBorrowed"
        Me.cbtnBorrowed.Size = New System.Drawing.Size(77, 20)
        Me.cbtnBorrowed.TabIndex = 12
        Me.cbtnBorrowed.Text = "Borrowed"
        Me.cbtnBorrowed.UseVisualStyleBackColor = True
        '
        'cbtnStationed
        '
        Me.cbtnStationed.AutoSize = True
        Me.cbtnStationed.Location = New System.Drawing.Point(317, 60)
        Me.cbtnStationed.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnStationed.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnStationed.Name = "cbtnStationed"
        Me.cbtnStationed.Size = New System.Drawing.Size(76, 20)
        Me.cbtnStationed.TabIndex = 13
        Me.cbtnStationed.Text = "Stationed"
        Me.cbtnStationed.UseVisualStyleBackColor = True
        '
        'cbtnReserved
        '
        Me.cbtnReserved.AutoSize = True
        Me.cbtnReserved.Location = New System.Drawing.Point(317, 80)
        Me.cbtnReserved.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnReserved.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnReserved.Name = "cbtnReserved"
        Me.cbtnReserved.Size = New System.Drawing.Size(73, 20)
        Me.cbtnReserved.TabIndex = 14
        Me.cbtnReserved.Text = "Reserved"
        Me.cbtnReserved.UseVisualStyleBackColor = True
        '
        'cbtnGood
        '
        Me.cbtnGood.AutoSize = True
        Me.cbtnGood.Location = New System.Drawing.Point(394, 0)
        Me.cbtnGood.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnGood.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnGood.Name = "cbtnGood"
        Me.cbtnGood.Size = New System.Drawing.Size(55, 20)
        Me.cbtnGood.TabIndex = 15
        Me.cbtnGood.Text = "Good"
        Me.cbtnGood.UseVisualStyleBackColor = True
        '
        'cbtnDamaged
        '
        Me.cbtnDamaged.AutoSize = True
        Me.cbtnDamaged.Location = New System.Drawing.Point(394, 20)
        Me.cbtnDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnDamaged.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnDamaged.Name = "cbtnDamaged"
        Me.cbtnDamaged.Size = New System.Drawing.Size(77, 20)
        Me.cbtnDamaged.TabIndex = 16
        Me.cbtnDamaged.Text = "Damaged"
        Me.cbtnDamaged.UseVisualStyleBackColor = True
        '
        'cbtnMaintenance
        '
        Me.cbtnMaintenance.AutoSize = True
        Me.cbtnMaintenance.Location = New System.Drawing.Point(394, 40)
        Me.cbtnMaintenance.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnMaintenance.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnMaintenance.Name = "cbtnMaintenance"
        Me.cbtnMaintenance.Size = New System.Drawing.Size(130, 20)
        Me.cbtnMaintenance.TabIndex = 17
        Me.cbtnMaintenance.Text = "Under maintenance"
        Me.cbtnMaintenance.UseVisualStyleBackColor = True
        '
        'cbtnReplacement
        '
        Me.cbtnReplacement.AutoSize = True
        Me.cbtnReplacement.Location = New System.Drawing.Point(394, 60)
        Me.cbtnReplacement.Margin = New System.Windows.Forms.Padding(0)
        Me.cbtnReplacement.MinimumSize = New System.Drawing.Size(0, 20)
        Me.cbtnReplacement.Name = "cbtnReplacement"
        Me.cbtnReplacement.Size = New System.Drawing.Size(112, 20)
        Me.cbtnReplacement.TabIndex = 18
        Me.cbtnReplacement.Text = "For replacement"
        Me.cbtnReplacement.UseVisualStyleBackColor = True
        '
        'fpnlCardList
        '
        Me.fpnlCardList.AutoScroll = True
        Me.fpnlCardList.BackColor = System.Drawing.Color.White
        Me.fpnlCardList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fpnlCardList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.fpnlCardList.Location = New System.Drawing.Point(0, 150)
        Me.fpnlCardList.Margin = New System.Windows.Forms.Padding(0)
        Me.fpnlCardList.Name = "fpnlCardList"
        Me.fpnlCardList.Size = New System.Drawing.Size(900, 343)
        Me.fpnlCardList.TabIndex = 1
        Me.fpnlCardList.TabStop = True
        Me.fpnlCardList.WrapContents = False
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
        'ctrlItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.fpnlCardList)
        Me.Controls.Add(Me.lblDiv)
        Me.Controls.Add(Me.pnlRibbon)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlItem"
        Me.Size = New System.Drawing.Size(900, 493)
        Me.pnlRibbon.ResumeLayout(False)
        Me.pnlRibbon.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        CType(Me.numTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlRibbon As Panel
    Private WithEvents fpnlCardList As FlowLayoutPanel
    Private WithEvents btnAdd As Button
    Private WithEvents btnRefresh As Button
    Private WithEvents btnSearch As Button
    Private WithEvents cbtnMore As CheckBox
    Private WithEvents cbtnMatchWholeWord As CheckBox
    Private WithEvents txtSearch As ctrlPaddedTextBox
    Private WithEvents tltp As ToolTip
    Private WithEvents lblTop As Label
    Private WithEvents numTop As NumericUpDown
    Private WithEvents pnlFilter As Panel
    Private WithEvents cbtnFilter As CheckBox
    Private WithEvents cbtnMatchEveryField As CheckBox
    Private WithEvents lblPreview As Label
    Private WithEvents cbtnItemID As CheckBox
    Private WithEvents cbtnName As CheckBox
    Private WithEvents cbtnDescription As CheckBox
    Private WithEvents cbtnItemType As CheckBox
    Private WithEvents cbtnUnitType As CheckBox
    Private WithEvents cbtnLowThreshold As CheckBox
    Private WithEvents cbtnTotal As CheckBox
    Private WithEvents cbtnAvailable As CheckBox
    Private WithEvents cbtnBorrowed As CheckBox
    Private WithEvents cbtnStationed As CheckBox
    Private WithEvents cbtnReserved As CheckBox
    Private WithEvents cbtnGood As CheckBox
    Private WithEvents cbtnDamaged As CheckBox
    Private WithEvents cbtnMaintenance As CheckBox
    Private WithEvents cbtnReplacement As CheckBox
    Private WithEvents btnEdit As Button
    Private WithEvents btnDelete As Button
    Private WithEvents lblDiv As Label
End Class
