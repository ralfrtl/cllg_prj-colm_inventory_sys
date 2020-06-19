<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlItemCard
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblItemID = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.lblUnitType = New System.Windows.Forms.Label()
        Me.lblLowThreshold = New System.Windows.Forms.Label()
        Me.lblLowThresholdNotifier = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblAvailable = New System.Windows.Forms.Label()
        Me.lblBorrowed = New System.Windows.Forms.Label()
        Me.lblStationed = New System.Windows.Forms.Label()
        Me.lblReserved = New System.Windows.Forms.Label()
        Me.lblReplacement = New System.Windows.Forms.Label()
        Me.lblMaintenance = New System.Windows.Forms.Label()
        Me.lblDamaged = New System.Windows.Forms.Label()
        Me.lblGood = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblName.AutoEllipsis = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.Green
        Me.lblName.Location = New System.Drawing.Point(45, 25)
        Me.lblName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(410, 30)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemID
        '
        Me.lblItemID.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblItemID.AutoEllipsis = True
        Me.lblItemID.Location = New System.Drawing.Point(45, 55)
        Me.lblItemID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemID.Name = "lblItemID"
        Me.lblItemID.Size = New System.Drawing.Size(410, 20)
        Me.lblItemID.TabIndex = 0
        Me.lblItemID.Text = "ID :"
        Me.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDescription.AutoEllipsis = True
        Me.lblDescription.Location = New System.Drawing.Point(45, 75)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(410, 40)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "Description"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemType
        '
        Me.lblItemType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblItemType.AutoEllipsis = True
        Me.lblItemType.Location = New System.Drawing.Point(45, 115)
        Me.lblItemType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(410, 20)
        Me.lblItemType.TabIndex = 0
        Me.lblItemType.Text = "Item type :"
        Me.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitType
        '
        Me.lblUnitType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblUnitType.AutoEllipsis = True
        Me.lblUnitType.Location = New System.Drawing.Point(45, 135)
        Me.lblUnitType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblUnitType.Name = "lblUnitType"
        Me.lblUnitType.Size = New System.Drawing.Size(410, 20)
        Me.lblUnitType.TabIndex = 0
        Me.lblUnitType.Text = "Unit type :"
        Me.lblUnitType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLowThreshold
        '
        Me.lblLowThreshold.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLowThreshold.AutoEllipsis = True
        Me.lblLowThreshold.Location = New System.Drawing.Point(45, 155)
        Me.lblLowThreshold.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLowThreshold.Name = "lblLowThreshold"
        Me.lblLowThreshold.Size = New System.Drawing.Size(410, 20)
        Me.lblLowThreshold.TabIndex = 0
        Me.lblLowThreshold.Text = "Low threshold :"
        Me.lblLowThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLowThresholdNotifier
        '
        Me.lblLowThresholdNotifier.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLowThresholdNotifier.AutoEllipsis = True
        Me.lblLowThresholdNotifier.Location = New System.Drawing.Point(25, 25)
        Me.lblLowThresholdNotifier.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLowThresholdNotifier.Name = "lblLowThresholdNotifier"
        Me.lblLowThresholdNotifier.Size = New System.Drawing.Size(10, 150)
        Me.lblLowThresholdNotifier.TabIndex = 0
        '
        'lblQuantity
        '
        Me.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblQuantity.AutoEllipsis = True
        Me.lblQuantity.ForeColor = System.Drawing.Color.Green
        Me.lblQuantity.Location = New System.Drawing.Point(465, 35)
        Me.lblQuantity.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(150, 20)
        Me.lblQuantity.TabIndex = 0
        Me.lblQuantity.Text = "Quantity"
        Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStatus.AutoEllipsis = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Green
        Me.lblStatus.Location = New System.Drawing.Point(625, 35)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(200, 20)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTotal.AutoEllipsis = True
        Me.lblTotal.Location = New System.Drawing.Point(465, 60)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(150, 20)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "Total :"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAvailable
        '
        Me.lblAvailable.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAvailable.AutoEllipsis = True
        Me.lblAvailable.Location = New System.Drawing.Point(465, 80)
        Me.lblAvailable.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAvailable.Name = "lblAvailable"
        Me.lblAvailable.Size = New System.Drawing.Size(150, 20)
        Me.lblAvailable.TabIndex = 0
        Me.lblAvailable.Text = "Available :"
        Me.lblAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBorrowed
        '
        Me.lblBorrowed.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblBorrowed.AutoEllipsis = True
        Me.lblBorrowed.Location = New System.Drawing.Point(465, 140)
        Me.lblBorrowed.Margin = New System.Windows.Forms.Padding(0)
        Me.lblBorrowed.Name = "lblBorrowed"
        Me.lblBorrowed.Size = New System.Drawing.Size(150, 20)
        Me.lblBorrowed.TabIndex = 0
        Me.lblBorrowed.Text = "Borrowed :"
        Me.lblBorrowed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStationed
        '
        Me.lblStationed.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStationed.AutoEllipsis = True
        Me.lblStationed.Location = New System.Drawing.Point(465, 120)
        Me.lblStationed.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStationed.Name = "lblStationed"
        Me.lblStationed.Size = New System.Drawing.Size(150, 20)
        Me.lblStationed.TabIndex = 0
        Me.lblStationed.Text = "Stationed :"
        Me.lblStationed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReserved
        '
        Me.lblReserved.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblReserved.AutoEllipsis = True
        Me.lblReserved.Location = New System.Drawing.Point(465, 100)
        Me.lblReserved.Margin = New System.Windows.Forms.Padding(0)
        Me.lblReserved.Name = "lblReserved"
        Me.lblReserved.Size = New System.Drawing.Size(150, 20)
        Me.lblReserved.TabIndex = 0
        Me.lblReserved.Text = "Reserved :"
        Me.lblReserved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReplacement
        '
        Me.lblReplacement.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblReplacement.AutoEllipsis = True
        Me.lblReplacement.Location = New System.Drawing.Point(625, 120)
        Me.lblReplacement.Margin = New System.Windows.Forms.Padding(0)
        Me.lblReplacement.Name = "lblReplacement"
        Me.lblReplacement.Size = New System.Drawing.Size(200, 20)
        Me.lblReplacement.TabIndex = 0
        Me.lblReplacement.Text = "For replacement :"
        Me.lblReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaintenance
        '
        Me.lblMaintenance.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMaintenance.AutoEllipsis = True
        Me.lblMaintenance.Location = New System.Drawing.Point(625, 100)
        Me.lblMaintenance.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMaintenance.Name = "lblMaintenance"
        Me.lblMaintenance.Size = New System.Drawing.Size(200, 20)
        Me.lblMaintenance.TabIndex = 0
        Me.lblMaintenance.Text = "Under maintenance :"
        Me.lblMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDamaged
        '
        Me.lblDamaged.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDamaged.AutoEllipsis = True
        Me.lblDamaged.Location = New System.Drawing.Point(625, 80)
        Me.lblDamaged.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDamaged.Name = "lblDamaged"
        Me.lblDamaged.Size = New System.Drawing.Size(200, 20)
        Me.lblDamaged.TabIndex = 0
        Me.lblDamaged.Text = "Damaged :"
        Me.lblDamaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGood
        '
        Me.lblGood.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblGood.AutoEllipsis = True
        Me.lblGood.Location = New System.Drawing.Point(625, 60)
        Me.lblGood.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGood.Name = "lblGood"
        Me.lblGood.Size = New System.Drawing.Size(200, 20)
        Me.lblGood.TabIndex = 0
        Me.lblGood.Text = "Good :"
        Me.lblGood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctrlItemCard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblLowThresholdNotifier)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblItemID)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblItemType)
        Me.Controls.Add(Me.lblUnitType)
        Me.Controls.Add(Me.lblLowThreshold)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblAvailable)
        Me.Controls.Add(Me.lblBorrowed)
        Me.Controls.Add(Me.lblStationed)
        Me.Controls.Add(Me.lblReserved)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblGood)
        Me.Controls.Add(Me.lblDamaged)
        Me.Controls.Add(Me.lblMaintenance)
        Me.Controls.Add(Me.lblReplacement)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ctrlItemCard"
        Me.Size = New System.Drawing.Size(850, 200)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblName As Label
    Private WithEvents lblItemID As Label
    Private WithEvents lblDescription As Label
    Private WithEvents lblItemType As Label
    Private WithEvents lblUnitType As Label
    Private WithEvents lblLowThreshold As Label
    Private WithEvents lblLowThresholdNotifier As Label
    Private WithEvents lblTotal As Label
    Private WithEvents lblAvailable As Label
    Private WithEvents lblBorrowed As Label
    Private WithEvents lblStationed As Label
    Private WithEvents lblReserved As Label
    Private WithEvents lblReplacement As Label
    Private WithEvents lblMaintenance As Label
    Private WithEvents lblDamaged As Label
    Private WithEvents lblGood As Label
    Private WithEvents lblQuantity As Label
    Private WithEvents lblStatus As Label
End Class
