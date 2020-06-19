<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlCustomerCard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblCustomerID = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblPositionVal = New System.Windows.Forms.Label()
        Me.lblDepartmentVal = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblOffenseVal = New System.Windows.Forms.Label()
        Me.lblOffense = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblFullName
        '
        Me.lblFullName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFullName.AutoEllipsis = True
        Me.lblFullName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblFullName.ForeColor = System.Drawing.Color.Green
        Me.lblFullName.Location = New System.Drawing.Point(25, 25)
        Me.lblFullName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(320, 30)
        Me.lblFullName.TabIndex = 0
        Me.lblFullName.Text = "Full name"
        Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustomerID
        '
        Me.lblCustomerID.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCustomerID.AutoEllipsis = True
        Me.lblCustomerID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCustomerID.Location = New System.Drawing.Point(25, 55)
        Me.lblCustomerID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(320, 20)
        Me.lblCustomerID.TabIndex = 0
        Me.lblCustomerID.Text = "ID :"
        Me.lblCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPosition.AutoEllipsis = True
        Me.lblPosition.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPosition.ForeColor = System.Drawing.Color.Green
        Me.lblPosition.Location = New System.Drawing.Point(355, 28)
        Me.lblPosition.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(150, 20)
        Me.lblPosition.TabIndex = 0
        Me.lblPosition.Text = "Position"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPositionVal
        '
        Me.lblPositionVal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPositionVal.AutoEllipsis = True
        Me.lblPositionVal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPositionVal.Location = New System.Drawing.Point(355, 53)
        Me.lblPositionVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPositionVal.Name = "lblPositionVal"
        Me.lblPositionVal.Size = New System.Drawing.Size(150, 20)
        Me.lblPositionVal.TabIndex = 0
        Me.lblPositionVal.Text = "Position value"
        Me.lblPositionVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepartmentVal
        '
        Me.lblDepartmentVal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDepartmentVal.AutoEllipsis = True
        Me.lblDepartmentVal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDepartmentVal.Location = New System.Drawing.Point(515, 53)
        Me.lblDepartmentVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDepartmentVal.Name = "lblDepartmentVal"
        Me.lblDepartmentVal.Size = New System.Drawing.Size(150, 20)
        Me.lblDepartmentVal.TabIndex = 0
        Me.lblDepartmentVal.Text = "Department value"
        Me.lblDepartmentVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepartment
        '
        Me.lblDepartment.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDepartment.AutoEllipsis = True
        Me.lblDepartment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDepartment.ForeColor = System.Drawing.Color.Green
        Me.lblDepartment.Location = New System.Drawing.Point(515, 28)
        Me.lblDepartment.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(150, 20)
        Me.lblDepartment.TabIndex = 0
        Me.lblDepartment.Text = "Department"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOffenseVal
        '
        Me.lblOffenseVal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblOffenseVal.AutoEllipsis = True
        Me.lblOffenseVal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOffenseVal.Location = New System.Drawing.Point(675, 53)
        Me.lblOffenseVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOffenseVal.Name = "lblOffenseVal"
        Me.lblOffenseVal.Size = New System.Drawing.Size(150, 20)
        Me.lblOffenseVal.TabIndex = 0
        Me.lblOffenseVal.Text = "Offense value"
        Me.lblOffenseVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOffense
        '
        Me.lblOffense.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblOffense.AutoEllipsis = True
        Me.lblOffense.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOffense.ForeColor = System.Drawing.Color.Green
        Me.lblOffense.Location = New System.Drawing.Point(675, 28)
        Me.lblOffense.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOffense.Name = "lblOffense"
        Me.lblOffense.Size = New System.Drawing.Size(150, 20)
        Me.lblOffense.TabIndex = 0
        Me.lblOffense.Text = "No. of offense(s)"
        Me.lblOffense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctrlCustomerCard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblCustomerID)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.lblPositionVal)
        Me.Controls.Add(Me.lblDepartment)
        Me.Controls.Add(Me.lblDepartmentVal)
        Me.Controls.Add(Me.lblOffense)
        Me.Controls.Add(Me.lblOffenseVal)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlCustomerCard"
        Me.Size = New System.Drawing.Size(850, 100)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents lblFullName As Label
    Private WithEvents lblCustomerID As Label
    Private WithEvents lblPosition As Label
    Private WithEvents lblPositionVal As Label
    Private WithEvents lblDepartmentVal As Label
    Private WithEvents lblDepartment As Label
    Private WithEvents lblOffenseVal As Label
    Private WithEvents lblOffense As Label
End Class
