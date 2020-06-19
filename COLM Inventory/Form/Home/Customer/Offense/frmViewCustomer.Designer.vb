<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmViewCustomer
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.colOffenseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInformation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSettled = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAddOffense = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlRibbon = New System.Windows.Forms.Panel()
        Me.btnEditOffense = New System.Windows.Forms.Button()
        Me.txtSearch = New COLM_Inventory.ctrlPaddedTextBox()
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.tltp = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.fpnlICustomerDetails = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblCustomerID = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblOffense = New System.Windows.Forms.Label()
        Me.fpnlButtons = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRibbon.SuspendLayout()
        Me.fpnlICustomerDetails.SuspendLayout()
        Me.fpnlButtons.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOffenseID, Me.colInformation, Me.colSettled})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
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
        Me.dgv.Location = New System.Drawing.Point(250, 45)
        Me.dgv.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(650, 515)
        Me.dgv.TabIndex = 1
        '
        'colOffenseID
        '
        Me.colOffenseID.HeaderText = "ID"
        Me.colOffenseID.Name = "colOffenseID"
        Me.colOffenseID.ReadOnly = True
        '
        'colInformation
        '
        Me.colInformation.HeaderText = "Information"
        Me.colInformation.Name = "colInformation"
        Me.colInformation.ReadOnly = True
        Me.colInformation.Width = 400
        '
        'colSettled
        '
        Me.colSettled.HeaderText = "Settled"
        Me.colSettled.Name = "colSettled"
        Me.colSettled.ReadOnly = True
        '
        'btnAddOffense
        '
        Me.btnAddOffense.AutoSize = True
        Me.btnAddOffense.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddOffense.FlatAppearance.BorderSize = 0
        Me.btnAddOffense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAddOffense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAddOffense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddOffense.ForeColor = System.Drawing.Color.White
        Me.btnAddOffense.Image = Global.COLM_Inventory.My.Resources.Resources.AddRecord
        Me.btnAddOffense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddOffense.Location = New System.Drawing.Point(5, 5)
        Me.btnAddOffense.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAddOffense.MinimumSize = New System.Drawing.Size(0, 30)
        Me.btnAddOffense.Name = "btnAddOffense"
        Me.btnAddOffense.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnAddOffense.Size = New System.Drawing.Size(69, 30)
        Me.btnAddOffense.TabIndex = 0
        Me.btnAddOffense.Text = " Add"
        Me.btnAddOffense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.tltp.SetToolTip(Me.btnAddOffense, "(Ctrl + Shift + A)")
        Me.btnAddOffense.UseVisualStyleBackColor = False
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
        Me.btnSearch.Location = New System.Drawing.Point(615, 5)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(30, 30)
        Me.btnSearch.TabIndex = 4
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
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(151, 5)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(30, 30)
        Me.btnRefresh.TabIndex = 2
        Me.tltp.SetToolTip(Me.btnRefresh, "Refresh (F5)")
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'pnlRibbon
        '
        Me.pnlRibbon.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlRibbon.Controls.Add(Me.btnAddOffense)
        Me.pnlRibbon.Controls.Add(Me.btnEditOffense)
        Me.pnlRibbon.Controls.Add(Me.btnRefresh)
        Me.pnlRibbon.Controls.Add(Me.txtSearch)
        Me.pnlRibbon.Controls.Add(Me.btnSearch)
        Me.pnlRibbon.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRibbon.ForeColor = System.Drawing.Color.White
        Me.pnlRibbon.Location = New System.Drawing.Point(250, 0)
        Me.pnlRibbon.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRibbon.Name = "pnlRibbon"
        Me.pnlRibbon.Size = New System.Drawing.Size(650, 40)
        Me.pnlRibbon.TabIndex = 0
        '
        'btnEditOffense
        '
        Me.btnEditOffense.AutoSize = True
        Me.btnEditOffense.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEditOffense.FlatAppearance.BorderSize = 0
        Me.btnEditOffense.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEditOffense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEditOffense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEditOffense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditOffense.Image = Global.COLM_Inventory.My.Resources.Resources.EditRecord
        Me.btnEditOffense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditOffense.Location = New System.Drawing.Point(79, 5)
        Me.btnEditOffense.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEditOffense.MinimumSize = New System.Drawing.Size(0, 30)
        Me.btnEditOffense.Name = "btnEditOffense"
        Me.btnEditOffense.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnEditOffense.Size = New System.Drawing.Size(67, 30)
        Me.btnEditOffense.TabIndex = 1
        Me.btnEditOffense.Text = " Edit"
        Me.btnEditOffense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.tltp.SetToolTip(Me.btnEditOffense, "(Ctrl + Shift + E)")
        Me.btnEditOffense.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.BorderColor = System.Drawing.Color.Green
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.FocusedBorderColor = System.Drawing.Color.Green
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.Location = New System.Drawing.Point(415, 5)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSearch.MinimumSize = New System.Drawing.Size(47, 30)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Padding = New System.Windows.Forms.Padding(10, 6, 5, 6)
        Me.txtSearch.Size = New System.Drawing.Size(200, 30)
        Me.txtSearch.TabIndex = 3
        Me.tltp.SetToolTip(Me.txtSearch, "Search (Ctrl + Shift + S)")
        '
        'lblDiv
        '
        Me.lblDiv.BackColor = System.Drawing.Color.Green
        Me.lblDiv.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDiv.Location = New System.Drawing.Point(250, 40)
        Me.lblDiv.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(650, 5)
        Me.lblDiv.TabIndex = 0
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
        'fpnlICustomerDetails
        '
        Me.fpnlICustomerDetails.AutoScroll = True
        Me.fpnlICustomerDetails.Controls.Add(Me.lblFullName)
        Me.fpnlICustomerDetails.Controls.Add(Me.lblCustomerID)
        Me.fpnlICustomerDetails.Controls.Add(Me.lblPosition)
        Me.fpnlICustomerDetails.Controls.Add(Me.lblDepartment)
        Me.fpnlICustomerDetails.Controls.Add(Me.lblOffense)
        Me.fpnlICustomerDetails.Controls.Add(Me.fpnlButtons)
        Me.fpnlICustomerDetails.Dock = System.Windows.Forms.DockStyle.Left
        Me.fpnlICustomerDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.fpnlICustomerDetails.Location = New System.Drawing.Point(0, 0)
        Me.fpnlICustomerDetails.Margin = New System.Windows.Forms.Padding(0)
        Me.fpnlICustomerDetails.Name = "fpnlICustomerDetails"
        Me.fpnlICustomerDetails.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.fpnlICustomerDetails.Size = New System.Drawing.Size(250, 560)
        Me.fpnlICustomerDetails.TabIndex = 2
        Me.fpnlICustomerDetails.TabStop = True
        Me.fpnlICustomerDetails.WrapContents = False
        '
        'lblFullName
        '
        Me.lblFullName.AutoEllipsis = True
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullName.ForeColor = System.Drawing.Color.Green
        Me.lblFullName.Location = New System.Drawing.Point(15, 11)
        Me.lblFullName.Margin = New System.Windows.Forms.Padding(0, 11, 0, 11)
        Me.lblFullName.MaximumSize = New System.Drawing.Size(220, 38)
        Me.lblFullName.MinimumSize = New System.Drawing.Size(220, 38)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(220, 38)
        Me.lblFullName.TabIndex = 0
        Me.lblFullName.Text = "Full name"
        Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFullName.UseCompatibleTextRendering = True
        '
        'lblCustomerID
        '
        Me.lblCustomerID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCustomerID.AutoEllipsis = True
        Me.lblCustomerID.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCustomerID.Location = New System.Drawing.Point(15, 60)
        Me.lblCustomerID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(220, 20)
        Me.lblCustomerID.TabIndex = 0
        Me.lblCustomerID.Text = "ID :"
        Me.lblCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPosition.AutoEllipsis = True
        Me.lblPosition.Location = New System.Drawing.Point(15, 80)
        Me.lblPosition.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(220, 20)
        Me.lblPosition.TabIndex = 0
        Me.lblPosition.Text = "Position :"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepartment
        '
        Me.lblDepartment.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDepartment.AutoEllipsis = True
        Me.lblDepartment.Location = New System.Drawing.Point(15, 100)
        Me.lblDepartment.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(220, 20)
        Me.lblDepartment.TabIndex = 0
        Me.lblDepartment.Text = "Department :"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOffense
        '
        Me.lblOffense.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOffense.AutoEllipsis = True
        Me.lblOffense.Location = New System.Drawing.Point(15, 120)
        Me.lblOffense.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOffense.Name = "lblOffense"
        Me.lblOffense.Size = New System.Drawing.Size(220, 20)
        Me.lblOffense.TabIndex = 0
        Me.lblOffense.Text = "No. of offense(s) :"
        Me.lblOffense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fpnlButtons
        '
        Me.fpnlButtons.Controls.Add(Me.btnEdit)
        Me.fpnlButtons.Controls.Add(Me.btnDelete)
        Me.fpnlButtons.Location = New System.Drawing.Point(15, 150)
        Me.fpnlButtons.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.fpnlButtons.Name = "fpnlButtons"
        Me.fpnlButtons.Size = New System.Drawing.Size(220, 30)
        Me.fpnlButtons.TabIndex = 0
        Me.fpnlButtons.TabStop = True
        '
        'frmViewCustomer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(900, 560)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.lblDiv)
        Me.Controls.Add(Me.pnlRibbon)
        Me.Controls.Add(Me.fpnlICustomerDetails)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.Name = "frmViewCustomer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Customer"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRibbon.ResumeLayout(False)
        Me.pnlRibbon.PerformLayout()
        Me.fpnlICustomerDetails.ResumeLayout(False)
        Me.fpnlICustomerDetails.PerformLayout()
        Me.fpnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents dgv As DataGridView
    Private WithEvents btnAddOffense As Button
    Private WithEvents txtSearch As ctrlPaddedTextBox
    Private WithEvents btnSearch As Button
    Private WithEvents btnRefresh As Button
    Private WithEvents pnlRibbon As Panel
    Private WithEvents lblDiv As Label
    Private WithEvents tltp As ToolTip
    Private WithEvents btnEditOffense As Button
    Private WithEvents fpnlICustomerDetails As FlowLayoutPanel
    Private WithEvents lblFullName As Label
    Private WithEvents lblCustomerID As Label
    Private WithEvents lblPosition As Label
    Private WithEvents lblDepartment As Label
    Private WithEvents fpnlButtons As FlowLayoutPanel
    Private WithEvents btnEdit As Button
    Private WithEvents btnDelete As Button
    Private WithEvents lblOffense As Label
    Private WithEvents colOffenseID As DataGridViewTextBoxColumn
    Private WithEvents colInformation As DataGridViewTextBoxColumn
    Private WithEvents colSettled As DataGridViewTextBoxColumn
End Class
