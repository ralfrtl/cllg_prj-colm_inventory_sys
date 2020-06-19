Public Class Dummy2

    Private sw As Stopwatch
    Private frameLock As Integer = 60
    Private fps As Integer = 0

    Private a As Boolean = False
    Private w As Boolean = False
    Private d As Boolean = False
    Private s As Boolean = False

    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
        If e.KeyData = Keys.A Then
            a = False
        End If
        If e.KeyData = Keys.W Then
            w = False
        End If
        If e.KeyData = Keys.D Then
            d = False
        End If
        If e.KeyData = Keys.S Then
            s = False
        End If

        MyBase.OnKeyUp(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.DrawString("Software Game loop/2D renderer/Animation timer", Me.Font, Brushes.White, New Rectangle(0, Me.ClientSize.Height - 20, Me.Width, 20), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.A Then
            a = True
        End If
        If keyData = Keys.W Then
            w = True
        End If
        If keyData = Keys.D Then
            d = True
        End If
        If keyData = Keys.S Then
            s = True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        Me.Invalidate()
        lblFPS.Location = New Point(0, 0)
    End Sub

    Private Async Sub Dummy2_Load(sender As Object, e As EventArgs) Handles Me.Load
        sw = Stopwatch.StartNew

        WatchFPS()

        Dim last As Double = sw.ElapsedMilliseconds
        Dim now As Double = sw.ElapsedMilliseconds
        Dim unproccesed As Double = now - last
        Dim render As Boolean = False

        While sw.IsRunning
            render = False
            last = now
            now = sw.ElapsedMilliseconds
            unproccesed += now - last

            While unproccesed >= (1000 / frameLock)
                render = True
                onUpdate()
                unproccesed -= (1000 / frameLock)
            End While

            If render Then
                onRender()
                fps += 1
            Else
                Await Threading.Tasks.Task.Delay(1)
            End If
        End While

        sw.Stop()
    End Sub

    Private Async Sub WatchFPS()
        While sw.IsRunning
            lblFPS.Text = "FPS : " & fps
            fps = 0
            Await Threading.Tasks.Task.Delay(1000)
        End While
    End Sub

    Private Sub onUpdate()
        '   Update here
        Dim speed As Integer = 2

        If lblFPS.Location.X - speed < 0 Then
            a = False
        End If
        If lblFPS.Location.X + speed > Me.ClientSize.Width - lblFPS.Width Then
            d = False
        End If
        If lblFPS.Location.Y - speed < 0 Then
            w = False
        End If
        If lblFPS.Location.Y + speed > Me.ClientSize.Height - lblFPS.Height Then
            s = False
        End If
    End Sub

    Private Sub onRender()
        '   Render here
        Dim speed As Integer = 2

        If a Then
            lblFPS.Location = lblFPS.Location - New Point(speed, 0)
        End If
        If w Then
            lblFPS.Location = lblFPS.Location - New Point(0, speed)
        End If
        If d Then
            lblFPS.Location = lblFPS.Location + New Point(speed, 0)
        End If
        If s Then
            lblFPS.Location = lblFPS.Location + New Point(0, speed)
        End If
    End Sub

End Class