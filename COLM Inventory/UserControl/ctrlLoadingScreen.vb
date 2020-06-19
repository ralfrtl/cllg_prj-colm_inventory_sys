
Public Class ctrlLoadingScreen : Inherits UserControl

    Private cancelAction As Action = Nothing
    Private messageVal As String = ""

    Private WithEvents tmr As New Timers.Timer
    Private sw As Stopwatch
    Private x As Integer = 70
    Private begining As Double = 0
    Private change As Double = 140

    Public Property Message As String
        Get
            Return messageVal
        End Get
        Set(value As String)
            messageVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
    End Sub

    ''' <summary>
    ''' Covers a control while waiting for a task to finish.
    ''' </summary>
    ''' <param name="control">The control that will be covered.</param>
    ''' <param name="message">The message to show while waiting.</param>
    Public Sub New(control As Control, message As String)
        InitializeComponents(control, message, Nothing)
    End Sub

    ''' <summary>
    ''' Covers a control while waiting for a task to finish.
    ''' </summary>
    ''' <param name="control">The control that will be covered.</param>
    ''' <param name="message">The message to show while waiting.</param>
    ''' <param name="cancelAction">This action will be executed when the ESC key is pressed.</param>
    Public Sub New(control As Control, message As String, cancelAction As Action)
        InitializeComponents(control, message, cancelAction)
    End Sub

    Private Sub InitializeComponents(control As Control, message As String, cancelAction As Action)
        If message IsNot Nothing Then
            Me.Message = message
        End If

        Me.cancelAction = cancelAction

        AddHandler control.SizeChanged, Sub()
                                            Me.Location = New Point(0, 0)
                                            Me.MinimumSize = control.ClientSize
                                            Me.Size = control.ClientSize
                                        End Sub

        Me.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Bottom
        Me.BackColor = Color.White
        Me.Location = New Point(0, 0)
        Me.MinimumSize = control.ClientSize
        Me.Size = control.ClientSize
        control.Controls.Add(Me)
        Me.BringToFront()
    End Sub

    Protected Overrides Sub CreateHandle()
        Me.DoubleBuffered = True
        Me.Margin = New Padding(0)
        Me.ResizeRedraw = True
        Me.UseWaitCursor = True
        tmr.Interval = 1

        MyBase.CreateHandle()
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        MyBase.Dispose(disposing)

        tmr.Stop()

        If sw Is Nothing Then Exit Sub

        sw.Stop()
        sw = Nothing
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not DesignMode Then Me.Select() : tmr.Start()
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)

        Me.Select()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim rec As New Rectangle((Me.Width - 150) / 2, (Me.Height - 100) / 2, 150, 100)

        e.Graphics.DrawString(Message, New Font(Me.Font.FontFamily, 15.0!), Brushes.Green, New Rectangle(rec.X, rec.Y, 150, 50), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center, .Trimming = StringTrimming.EllipsisWord})
        e.Graphics.FillRectangle(Brushes.Green, New Rectangle(rec.X + x, rec.Y + 55, 10, 10))

        If cancelAction IsNot Nothing Then
            e.Graphics.DrawString("Press ESC to cancel.", New Font(Me.Font.FontFamily, 8.0!), Brushes.Gray, New Rectangle(rec.X, rec.Y + 70, 150, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center, .Trimming = StringTrimming.EllipsisWord})
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            If cancelAction IsNot Nothing Then
                cancelAction()
            End If
        End If

        Return True
    End Function

    Private Sub tmr_Elapsed(sender As Object, e As EventArgs) Handles tmr.Elapsed
        If sw Is Nothing Then sw = Stopwatch.StartNew
        If Not sw.IsRunning Then Exit Sub

        If sw.ElapsedMilliseconds > 800 Then
            begining = (begining - 140) * -1
            change *= -1
            sw = Stopwatch.StartNew
        End If

        x = Easing.Calculate(Easing.Effect.InOutExpo, sw.ElapsedMilliseconds, 800, begining, change)
        Me.Invalidate()
    End Sub

End Class
