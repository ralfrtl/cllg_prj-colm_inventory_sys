
Friend Class frmNotificationList : Inherits Form

    Private Class NotificationListItem : Inherits UserControl

        Private currentActiveForm As Form
        Private tltp As New ToolTip
        Private lblTemp As New Label
        Private Message As String
        Private BG As Color
        Private FG As Color

        Private WithEvents tmr As New Timers.Timer
        Dim sw As Stopwatch
        Dim timeStart As Double
        Private x As Integer = 200

        Public Sub New(message As String, backcolor As Color, forecolor As Color)
            Me.SuspendLayout()

            Me.Message = message
            Me.BG = backcolor
            Me.FG = forecolor

            With lblTemp
                .AutoEllipsis = True
                .AutoSize = True
                .Font = New Font(Me.Font.FontFamily, 10.0!)
                .Location = New Point(0, 0)
                .MaximumSize = New Size(200, 75)
                .MinimumSize = New Size(200, 30)
                .Padding = New Padding(28, 5, 5, 5)
                .TabStop = False
                .Text = message
                .TextAlign = ContentAlignment.MiddleLeft
                .UseCompatibleTextRendering = True
            End With

            With Me
                .AutoScaleMode = AutoScaleMode.None
                .BackColor = Color.Magenta
                .Controls.Add(lblTemp)
                .Cursor = Cursors.Hand
                .DoubleBuffered = True
                .Font = New Font("Segoe UI", 10.0!)
                .ForeColor = forecolor
                .Margin = New Padding(0, 1, 0, 1)
                .Size = lblTemp.Size
                .TabStop = False
                .ResumeLayout()
            End With

            Me.Controls.Remove(lblTemp)
            lblTemp.Dispose()
        End Sub

        Protected Overrides Async Sub OnLoad(e As EventArgs)
            MyBase.OnLoad(e)

            tmr.Interval = 1
            tmr.Start()
            sw = Stopwatch.StartNew
            timeStart = sw.ElapsedMilliseconds

            Await Threading.Tasks.Task.Delay(500)

            tmr.Stop()
            tmr.Dispose()
            tmr = Nothing
            sw.Stop()
            sw = Nothing

            Await Threading.Tasks.Task.Delay(6000)

            Me.Dispose()
        End Sub

        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            MyBase.OnMouseUp(e)

            Me.Dispose()

            If currentActiveForm IsNot Nothing Then
                currentActiveForm.Select()
            End If
        End Sub

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)

            currentActiveForm = Form.ActiveForm
        End Sub

        Private Sub NotificationListItem_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
            With e.Graphics
                .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                Using lgb As New Drawing2D.LinearGradientBrush(New Rectangle(x, 0, Me.Width, Me.Height), BG, Color.FromArgb(255, ColorMath.Mix(BG, Color.FromArgb(50, FG))), 35, True)
                    Dim relativeIntensities As Single() = {0.0F, 0.5F, 1.0F}
                    Dim relativePositions As Single() = {0.0F, 0.75F, 1.0F}
                    Dim blend As New Drawing2D.Blend With {
                        .Factors = relativeIntensities,
                        .Positions = relativePositions
                    }
                    lgb.Blend = blend

                    .FillRectangle(lgb, New Rectangle(x - 1, -1, Me.Width + 1, Me.Height + 1))
                End Using

                .DrawRectangle(New Pen(Color.FromArgb(50, FG), 1) With {.Alignment = Drawing2D.PenAlignment.Inset}, New Rectangle(x, 0, Me.Width - 1, Me.Height - 1))
                .DrawImage(My.Resources.LogoPng, New Rectangle(x + 5, 5, 20, 20))
                .DrawString(Message, Me.Font, New SolidBrush(FG), New Rectangle(x + 28, 5, Me.Width - 33, Me.Height - 10), New StringFormat() With {.Trimming = StringTrimming.EllipsisWord, .Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
            End With
        End Sub

        Private Sub tmr_Elapsed(sender As Object, e As EventArgs) Handles tmr.Elapsed
            x = Easing.Calculate(Easing.Effect.OutExpo, sw.ElapsedMilliseconds - timeStart, 300, Me.Width, -Me.Width)
            Me.Invalidate()
        End Sub

    End Class

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams

            'cp.ClassStyle = cp.ClassStyle Or WindowsMessage.ClassStyles.CS_DropShadow

            '   This conflicts with WndProc()
            'cp.Style = cp.Style Or WindowsMessage.WindowStyles.WS_SYSMENU

            'cp.Style = cp.Style Or WindowsMessage.WindowStyles.WS_MINIMIZEBOX

            cp.ExStyle = cp.ExStyle Or WindowsMessage.WindowStylesEx.WS_EX_TOOLWINDOW

            Return cp
        End Get
    End Property

    Private fpnlNotificationList As New FlowLayoutPanel

    Public Sub New()

        fpnlNotificationList.BackColor = Color.Magenta
        fpnlNotificationList.Dock = DockStyle.Fill
        fpnlNotificationList.TabStop = False

        With Me
            .AutoScaleMode = AutoScaleMode.None
            .BackColor = Color.Magenta
            .Controls.Add(fpnlNotificationList)
            .DoubleBuffered = True
            .FormBorderStyle = FormBorderStyle.None
            .ShowIcon = False
            .ShowInTaskbar = False
            .TabStop = False
            .TopMost = True
            .TransparencyKey = Color.Magenta
        End With

    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)

        For Each form As Form In Application.OpenForms
            If form IsNot Me Then
                form.Select()
                Exit For
            End If
        Next
    End Sub

    Public Sub Add(message As String, backcolor As Color, forecolor As Color, activeForm As Form)
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - 210, Screen.PrimaryScreen.Bounds.Top + 30)
        Me.Size = New Size(210, Screen.PrimaryScreen.WorkingArea.Height - 30)

        If Not Me.Visible Then
            Me.Show()
        End If

        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - 210, Screen.PrimaryScreen.Bounds.Top + 30)
        Me.Size = New Size(210, Screen.PrimaryScreen.WorkingArea.Height - 30)

        BEEP_ALERT()

        Dim newCtrlNotif As New NotificationListItem(message, backcolor, forecolor)
        fpnlNotificationList.Controls.Add(newCtrlNotif)
    End Sub

End Class

Public Class Notification

    ''' <summary>
    ''' Shows a notification in the left side of the primary screen.
    ''' </summary>
    ''' <param name="message">The message to be shown.</param>
    ''' <param name="backcolor">Backcolor of the notification.</param>
    ''' <param name="forecolor">Forecolor of the text in the notification.</param>
    Public Shared Sub Show(message As String, Optional backcolor As Color = Nothing, Optional forecolor As Color = Nothing)
        If backcolor = Color.Magenta Then
            Throw New Exception("Color.Magenta is a reserved color used by this class.")
        ElseIf backcolor = Nothing Or backcolor = Color.Transparent Then
            backcolor = Color.FromArgb(20, 20, 20)
        Else
            backcolor = Color.FromArgb(255, backcolor)
        End If

        If forecolor = Color.Magenta Then
            Throw New Exception("Color.Magenta is a reserved color used by this class.")
        ElseIf forecolor = Nothing Or forecolor = Color.Transparent Or forecolor = Color.Magenta Then
            forecolor = Color.FromArgb(224, 224, 224)
        Else
            forecolor = Color.FromArgb(255, forecolor)
        End If

        Dim currentlyActiveForm As Form = Form.ActiveForm

        frmNotificationList.Add(message, backcolor, forecolor, Form.ActiveForm)

        If currentlyActiveForm IsNot Nothing Then
            currentlyActiveForm.Select()
        End If
    End Sub

End Class
