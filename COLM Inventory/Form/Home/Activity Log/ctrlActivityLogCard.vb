
Public Class ctrlActivityLogCard

    Private activityLogDetails As ActivityLogDetails

    Public Sub New(activityLogDetails As ActivityLogDetails)
        If activityLogDetails Is Nothing Then Throw New ArgumentNullException("activityLogDetails")
        Me.activityLogDetails = activityLogDetails

        InitializeComponent()

        Me.DoubleBuffered = True
        PrintRecord()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        For i As Integer = 1 To 10
            e.Graphics.DrawRectangle(New Pen(Color.FromArgb(2 * i, Color.Black), 1) With {.Alignment = Drawing2D.PenAlignment.Inset},
                                     New Rectangle(-1 + i, -1 + i, Me.Width + 1 - i * 2, Me.Height + 1 - i * 2))
        Next
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)

        If Not Me.Visible Then Me.Dispose()
    End Sub

    Private Sub PrintRecord()
        lblActivity.Text = activityLogDetails.Activity
        lblLogID.Text = "Log ID : " & activityLogDetails.LogID
        lblTimestamp.Text = "Timestamp : " & activityLogDetails.Timestamp
        lblUsernameVal.Text = activityLogDetails.Username
        lblPermissionNameVal.Text = activityLogDetails.PermissionName
        lblDetails.Text = activityLogDetails.Details
    End Sub

End Class
