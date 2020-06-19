﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlCustomer
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
        Me.cbtnCustomerID = New System.Windows.Forms.CheckBox()
        Me.cbtnFirstName = New System.Windows.Forms.CheckBox()
        Me.cbtnMiddleName = New System.Windows.Forms.CheckBox()
        Me.cbtnLastName = New System.Windows.Forms.CheckBox()
        Me.cbtnPosition = New System.Windows.Forms.CheckBox()
        Me.cbtnDepartment = New System.Windows.Forms.CheckBox()
        Me.cbtnOffense = New System.Windows.Forms.CheckBox()
        Me.tltp = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.fpnlCardList = New System.Windows.Forms.FlowLayoutPanel()
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
        Me.pnlFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlFilter.Location = New System.Drawing.Point(293, 40)
        Me.pnlFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(315, 98)
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
        'fpnlCardList
        '
        Me.fpnlCardList.AutoScroll = True
        Me.fpnlCardList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fpnlCardList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.fpnlCardList.Location = New System.Drawing.Point(0, 150)
        Me.fpnlCardList.Margin = New System.Windows.Forms.Padding(0)
        Me.fpnlCardList.Name = "fpnlCardList"
        Me.fpnlCardList.Size = New System.Drawing.Size(900, 350)
        Me.fpnlCardList.TabIndex = 1
        Me.fpnlCardList.TabStop = True
        Me.fpnlCardList.WrapContents = False
        '
        'ctrlCustomer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.fpnlCardList)
        Me.Controls.Add(Me.lblDiv)
        Me.Controls.Add(Me.pnlRibbon)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlCustomer"
        Me.Size = New System.Drawing.Size(900, 500)
        Me.pnlRibbon.ResumeLayout(False)
        Me.pnlRibbon.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        CType(Me.numTop, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents txtSearch As ctrlPaddedTextBox
    Private WithEvents cbtnMore As CheckBox
    Private WithEvents pnlFilter As Panel
    Private WithEvents cbtnFilter As CheckBox
    Private WithEvents cbtnMatchWholeWord As CheckBox
    Private WithEvents cbtnDepartment As CheckBox
    Private WithEvents cbtnPosition As CheckBox
    Private WithEvents cbtnCustomerID As CheckBox
    Private WithEvents cbtnLastName As CheckBox
    Private WithEvents cbtnMiddleName As CheckBox
    Private WithEvents cbtnFirstName As CheckBox
    Private WithEvents cbtnOffense As CheckBox
    Private WithEvents lblDiv As Label
    Friend WithEvents colConsumeID As DataGridViewTextBoxColumn
    Private WithEvents btnDelete As Button
    Private WithEvents fpnlCardList As FlowLayoutPanel
End Class
