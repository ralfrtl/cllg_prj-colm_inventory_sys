<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddItem
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.lblUnitType = New System.Windows.Forms.Label()
        Me.lblLowThreshold = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.cmbItemType = New System.Windows.Forms.ComboBox()
        Me.txtUnitType = New System.Windows.Forms.TextBox()
        Me.numLowThreshold = New System.Windows.Forms.NumericUpDown()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        CType(Me.numLowThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(81, 33)
        Me.lblName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(45, 19)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(48, 63)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(78, 19)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "Description"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemType
        '
        Me.lblItemType.AutoSize = True
        Me.lblItemType.Location = New System.Drawing.Point(58, 168)
        Me.lblItemType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(68, 19)
        Me.lblItemType.TabIndex = 0
        Me.lblItemType.Text = "Item type"
        Me.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitType
        '
        Me.lblUnitType.AutoSize = True
        Me.lblUnitType.Location = New System.Drawing.Point(60, 198)
        Me.lblUnitType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUnitType.Name = "lblUnitType"
        Me.lblUnitType.Size = New System.Drawing.Size(66, 19)
        Me.lblUnitType.TabIndex = 0
        Me.lblUnitType.Text = "Unit type"
        Me.lblUnitType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLowThreshold
        '
        Me.lblLowThreshold.AutoSize = True
        Me.lblLowThreshold.Location = New System.Drawing.Point(30, 228)
        Me.lblLowThreshold.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLowThreshold.Name = "lblLowThreshold"
        Me.lblLowThreshold.Size = New System.Drawing.Size(96, 19)
        Me.lblLowThreshold.TabIndex = 0
        Me.lblLowThreshold.Text = "Low threshold"
        Me.lblLowThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.Location = New System.Drawing.Point(134, 30)
        Me.txtName.Margin = New System.Windows.Forms.Padding(0)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(200, 25)
        Me.txtName.TabIndex = 0
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.Location = New System.Drawing.Point(134, 60)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDescription.MaxLength = 120
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(200, 100)
        Me.txtDescription.TabIndex = 1
        '
        'cmbItemType
        '
        Me.cmbItemType.BackColor = System.Drawing.Color.White
        Me.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemType.ForeColor = System.Drawing.Color.Black
        Me.cmbItemType.FormattingEnabled = True
        Me.cmbItemType.Items.AddRange(New Object() {"Asset", "Asset - Bulk", "Consumable"})
        Me.cmbItemType.Location = New System.Drawing.Point(134, 165)
        Me.cmbItemType.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbItemType.Name = "cmbItemType"
        Me.cmbItemType.Size = New System.Drawing.Size(200, 25)
        Me.cmbItemType.TabIndex = 2
        '
        'txtUnitType
        '
        Me.txtUnitType.BackColor = System.Drawing.Color.White
        Me.txtUnitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitType.ForeColor = System.Drawing.Color.Black
        Me.txtUnitType.Location = New System.Drawing.Point(134, 195)
        Me.txtUnitType.Margin = New System.Windows.Forms.Padding(0)
        Me.txtUnitType.MaxLength = 50
        Me.txtUnitType.Name = "txtUnitType"
        Me.txtUnitType.Size = New System.Drawing.Size(200, 25)
        Me.txtUnitType.TabIndex = 3
        '
        'numLowThreshold
        '
        Me.numLowThreshold.BackColor = System.Drawing.Color.White
        Me.numLowThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numLowThreshold.ForeColor = System.Drawing.Color.Black
        Me.numLowThreshold.Location = New System.Drawing.Point(134, 225)
        Me.numLowThreshold.Margin = New System.Windows.Forms.Padding(0)
        Me.numLowThreshold.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numLowThreshold.Name = "numLowThreshold"
        Me.numLowThreshold.Size = New System.Drawing.Size(200, 25)
        Me.numLowThreshold.TabIndex = 4
        Me.numLowThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numLowThreshold.ThousandsSeparator = True
        '
        'err
        '
        Me.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.err.ContainerControl = Me
        '
        'btnAdd
        '
        Me.btnAdd.AutoEllipsis = True
        Me.btnAdd.BackColor = System.Drawing.Color.Green
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(234, 280)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'frmAddItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(364, 340)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblItemType)
        Me.Controls.Add(Me.cmbItemType)
        Me.Controls.Add(Me.lblUnitType)
        Me.Controls.Add(Me.txtUnitType)
        Me.Controls.Add(Me.lblLowThreshold)
        Me.Controls.Add(Me.numLowThreshold)
        Me.Controls.Add(Me.btnAdd)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddItem"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Item"
        CType(Me.numLowThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblName As Label
    Private WithEvents lblDescription As Label
    Private WithEvents lblItemType As Label
    Private WithEvents lblUnitType As Label
    Private WithEvents lblLowThreshold As Label
    Private WithEvents txtName As TextBox
    Private WithEvents txtDescription As TextBox
    Private WithEvents cmbItemType As ComboBox
    Private WithEvents txtUnitType As TextBox
    Private WithEvents numLowThreshold As NumericUpDown
    Private WithEvents err As ErrorProvider
    Private WithEvents btnAdd As Button
End Class
