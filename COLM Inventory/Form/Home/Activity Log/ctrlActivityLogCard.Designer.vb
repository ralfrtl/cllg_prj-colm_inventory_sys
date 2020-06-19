<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlActivityLogCard
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
        Me.lblActivity = New System.Windows.Forms.Label()
        Me.lblLogID = New System.Windows.Forms.Label()
        Me.lblUsernameVal = New System.Windows.Forms.Label()
        Me.lblPermissionName = New System.Windows.Forms.Label()
        Me.lblTimestamp = New System.Windows.Forms.Label()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPermissionNameVal = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblActivity
        '
        Me.lblActivity.AutoEllipsis = True
        Me.lblActivity.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblActivity.ForeColor = System.Drawing.Color.Green
        Me.lblActivity.Location = New System.Drawing.Point(25, 25)
        Me.lblActivity.Margin = New System.Windows.Forms.Padding(0)
        Me.lblActivity.Name = "lblActivity"
        Me.lblActivity.Size = New System.Drawing.Size(320, 30)
        Me.lblActivity.TabIndex = 0
        Me.lblActivity.Text = "Username"
        Me.lblActivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLogID
        '
        Me.lblLogID.AutoEllipsis = True
        Me.lblLogID.Location = New System.Drawing.Point(25, 55)
        Me.lblLogID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLogID.Name = "lblLogID"
        Me.lblLogID.Size = New System.Drawing.Size(320, 20)
        Me.lblLogID.TabIndex = 0
        Me.lblLogID.Text = "Log ID : "
        Me.lblLogID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsernameVal
        '
        Me.lblUsernameVal.AutoEllipsis = True
        Me.lblUsernameVal.Location = New System.Drawing.Point(355, 45)
        Me.lblUsernameVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUsernameVal.Name = "lblUsernameVal"
        Me.lblUsernameVal.Size = New System.Drawing.Size(200, 20)
        Me.lblUsernameVal.TabIndex = 0
        '
        'lblPermissionName
        '
        Me.lblPermissionName.AutoEllipsis = True
        Me.lblPermissionName.ForeColor = System.Drawing.Color.Green
        Me.lblPermissionName.Location = New System.Drawing.Point(355, 70)
        Me.lblPermissionName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPermissionName.Name = "lblPermissionName"
        Me.lblPermissionName.Size = New System.Drawing.Size(200, 20)
        Me.lblPermissionName.TabIndex = 0
        Me.lblPermissionName.Text = "Permission name"
        '
        'lblTimestamp
        '
        Me.lblTimestamp.AutoEllipsis = True
        Me.lblTimestamp.Location = New System.Drawing.Point(25, 75)
        Me.lblTimestamp.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTimestamp.Name = "lblTimestamp"
        Me.lblTimestamp.Size = New System.Drawing.Size(320, 20)
        Me.lblTimestamp.TabIndex = 0
        Me.lblTimestamp.Text = "Timestamp : "
        Me.lblTimestamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDetails
        '
        Me.lblDetails.AutoEllipsis = True
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Location = New System.Drawing.Point(565, 25)
        Me.lblDetails.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDetails.MaximumSize = New System.Drawing.Size(255, 0)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(0, 19)
        Me.lblDetails.TabIndex = 0
        '
        'lblUsername
        '
        Me.lblUsername.AutoEllipsis = True
        Me.lblUsername.ForeColor = System.Drawing.Color.Green
        Me.lblUsername.Location = New System.Drawing.Point(355, 25)
        Me.lblUsername.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(200, 20)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username"
        '
        'lblPermissionNameVal
        '
        Me.lblPermissionNameVal.AutoEllipsis = True
        Me.lblPermissionNameVal.Location = New System.Drawing.Point(355, 90)
        Me.lblPermissionNameVal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPermissionNameVal.Name = "lblPermissionNameVal"
        Me.lblPermissionNameVal.Size = New System.Drawing.Size(200, 20)
        Me.lblPermissionNameVal.TabIndex = 0
        '
        'ctrlActivityLogCard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblActivity)
        Me.Controls.Add(Me.lblLogID)
        Me.Controls.Add(Me.lblTimestamp)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblUsernameVal)
        Me.Controls.Add(Me.lblPermissionName)
        Me.Controls.Add(Me.lblPermissionNameVal)
        Me.Controls.Add(Me.lblDetails)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.MinimumSize = New System.Drawing.Size(850, 0)
        Me.Name = "ctrlActivityLogCard"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 25, 25)
        Me.Size = New System.Drawing.Size(850, 135)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents lblActivity As Label
    Private WithEvents lblLogID As Label
    Private WithEvents lblUsernameVal As Label
    Private WithEvents lblPermissionName As Label
    Private WithEvents lblTimestamp As Label
    Private WithEvents lblDetails As Label
    Private WithEvents lblUsername As Label
    Private WithEvents lblPermissionNameVal As Label
End Class
