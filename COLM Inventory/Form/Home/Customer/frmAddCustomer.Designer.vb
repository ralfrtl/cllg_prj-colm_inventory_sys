﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddCustomer
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
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblPostion = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.txtDeparment = New System.Windows.Forms.TextBox()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(46, 33)
        Me.lblFirstName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(73, 19)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "First name"
        Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFirstName
        '
        Me.txtFirstName.BackColor = System.Drawing.Color.White
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.ForeColor = System.Drawing.Color.Black
        Me.txtFirstName.Location = New System.Drawing.Point(127, 30)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFirstName.MaxLength = 50
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(200, 25)
        Me.txtFirstName.TabIndex = 0
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
        Me.btnAdd.Location = New System.Drawing.Point(227, 205)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'lblMiddleName
        '
        Me.lblMiddleName.AutoSize = True
        Me.lblMiddleName.Location = New System.Drawing.Point(30, 63)
        Me.lblMiddleName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(89, 19)
        Me.lblMiddleName.TabIndex = 0
        Me.lblMiddleName.Text = "Middle name"
        Me.lblMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMiddleName
        '
        Me.txtMiddleName.BackColor = System.Drawing.Color.White
        Me.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMiddleName.ForeColor = System.Drawing.Color.Black
        Me.txtMiddleName.Location = New System.Drawing.Point(127, 60)
        Me.txtMiddleName.Margin = New System.Windows.Forms.Padding(0)
        Me.txtMiddleName.MaxLength = 50
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(200, 25)
        Me.txtMiddleName.TabIndex = 1
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(47, 93)
        Me.lblLastName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(72, 19)
        Me.lblLastName.TabIndex = 0
        Me.lblLastName.Text = "Last name"
        Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastName
        '
        Me.txtLastName.BackColor = System.Drawing.Color.White
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastName.ForeColor = System.Drawing.Color.Black
        Me.txtLastName.Location = New System.Drawing.Point(127, 90)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLastName.MaxLength = 50
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(200, 25)
        Me.txtLastName.TabIndex = 2
        '
        'lblPostion
        '
        Me.lblPostion.AutoSize = True
        Me.lblPostion.Location = New System.Drawing.Point(62, 123)
        Me.lblPostion.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPostion.Name = "lblPostion"
        Me.lblPostion.Size = New System.Drawing.Size(57, 19)
        Me.lblPostion.TabIndex = 0
        Me.lblPostion.Text = "Position"
        Me.lblPostion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPosition
        '
        Me.txtPosition.BackColor = System.Drawing.Color.White
        Me.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosition.ForeColor = System.Drawing.Color.Black
        Me.txtPosition.Location = New System.Drawing.Point(127, 120)
        Me.txtPosition.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPosition.MaxLength = 50
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(200, 25)
        Me.txtPosition.TabIndex = 3
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Location = New System.Drawing.Point(36, 153)
        Me.lblDepartment.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(83, 19)
        Me.lblDepartment.TabIndex = 0
        Me.lblDepartment.Text = "Department"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeparment
        '
        Me.txtDeparment.BackColor = System.Drawing.Color.White
        Me.txtDeparment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeparment.ForeColor = System.Drawing.Color.Black
        Me.txtDeparment.Location = New System.Drawing.Point(127, 150)
        Me.txtDeparment.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDeparment.MaxLength = 50
        Me.txtDeparment.Name = "txtDeparment"
        Me.txtDeparment.Size = New System.Drawing.Size(200, 25)
        Me.txtDeparment.TabIndex = 4
        '
        'frmAddCustomer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(357, 265)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblMiddleName)
        Me.Controls.Add(Me.txtMiddleName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.lblPostion)
        Me.Controls.Add(Me.txtPosition)
        Me.Controls.Add(Me.lblDepartment)
        Me.Controls.Add(Me.txtDeparment)
        Me.Controls.Add(Me.btnAdd)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.COLM_Inventory.My.Resources.Resources.LogoIco
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddCustomer"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Customer"
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblFirstName As Label
    Private WithEvents txtFirstName As TextBox
    Private WithEvents err As ErrorProvider
    Private WithEvents btnAdd As Button
    Private WithEvents lblDepartment As Label
    Private WithEvents txtDeparment As TextBox
    Private WithEvents lblPostion As Label
    Private WithEvents txtPosition As TextBox
    Private WithEvents lblLastName As Label
    Private WithEvents txtLastName As TextBox
    Private WithEvents lblMiddleName As Label
    Private WithEvents txtMiddleName As TextBox
End Class
