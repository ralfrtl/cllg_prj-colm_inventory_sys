Public Class Dummy4

    Private time As String
    Private frames As Integer

    Private xp() As Integer = {50, 50, 400}   'X axis is the value used in the animation/easing
    Private yp() As Integer = {50, 400} 'Y axis represents time therefore it can be calculated as linear

    Private points As New List(Of Point)
    Private recs As New List(Of Rectangle)

    Private x As Integer = 50
    Private h As Integer = 50
    Private d As Integer = 1000

    Protected Overrides Async Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)

        frames = 0
        points = New List(Of Point)
        recs = New List(Of Rectangle)
        x = 50
        h = 50

        Dim SW As Stopwatch = Stopwatch.StartNew
        Dim timeStart As Double = SW.ElapsedMilliseconds
        While SW.ElapsedMilliseconds - timeStart <= d
            time = SW.ElapsedMilliseconds - timeStart
            frames += 1
            x = Bezier.Easing(SW.ElapsedMilliseconds - timeStart, d, xp)
            h = Bezier.Easing(SW.ElapsedMilliseconds - timeStart, d, yp)
            points.Add(New Point(Bezier.Easing(SW.ElapsedMilliseconds - timeStart, d, xp),
                                 Bezier.Easing(SW.ElapsedMilliseconds - timeStart, d, yp)))
            Await Threading.Tasks.Task.Delay(1)
            Me.Invalidate()
        End While
        SW.Stop()

    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.DrawString(time & " milliseconds", Me.Font, Brushes.White, New Point(0, 0))
        e.Graphics.DrawString("Total frames: " & frames, Me.Font, Brushes.White, New Point(0, 20))

        If points.Count > 1 Then
            e.Graphics.DrawCurve(New Pen(Brushes.Cyan, 2), points.ToArray)
        End If

        If recs.Count > 0 Then
            e.Graphics.FillRectangles(Brushes.Cyan, recs.ToArray)
        End If

        e.Graphics.FillRectangle(Brushes.LightGray, New Rectangle(x, 50, 2, xp(xp.Length - 1) - xp(0)))
        e.Graphics.FillRectangle(Brushes.Red, New Rectangle(x, 50, 2, h - 49))
        e.Graphics.DrawString("Applying bezier curves in animation/easing", Me.Font, Brushes.White, New Rectangle(0, Me.ClientSize.Height - 20, Me.Width, 20), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    End Sub

End Class