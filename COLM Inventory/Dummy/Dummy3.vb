Public Class Dummy3

    Dim p As New List(Of Point)
    Dim sr As Boolean = True
    Dim sg As Boolean = True
    Dim sb As Boolean = True
    Dim sc As Boolean = True
    Dim sm As Boolean = True
    Dim sy As Boolean = True
    Dim exact As Boolean = False

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If e.Button = MouseButtons.Left Then
            If p.Count < 25 Then
                p.Add(e.Location)
            End If
        ElseIf e.Button = MouseButtons.Right Then
            If p.Count > 0 Then
                p.RemoveAt(p.Count - 1)
            End If
        End If

        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Me.ResizeRedraw = True
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim pA() As Point = p.ToArray
        Dim pLen As Integer = pA.Length

        If pLen > 1 And sb Then
            e.Graphics.DrawLines(Pens.Blue, p.ToArray)

            For Each dot As Point In p.ToArray
                e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(dot.X - 2, dot.Y - 2, 4, 4))
            Next
        End If

        If pLen > 1 And sc Then
            Dim lin As New List(Of Point)

            lin.Add(p(0))
            lin.Add(New Point(Bezier.Linear(0.5, p(0).X, p(1).X),
                            Bezier.Linear(0.5, p(0).Y, p(1).Y)))
            lin.Add(p(1))

            e.Graphics.DrawCurve(Pens.Cyan, lin.ToArray)

            For Each dot As Point In lin
                e.Graphics.FillRectangle(Brushes.Cyan, New Rectangle(dot.X - 2, dot.Y - 2, 4, 4))
            Next
        End If

        If pLen > 2 And sm Then
            Dim qp() As Point = IIf(exact, CP(p.ToArray), p.ToArray)
            Dim quad As New List(Of Point)

            quad.Add(qp(0))
            quad.Add(New Point(Bezier.Quadratic(0.25, qp(0).X, qp(1).X, qp(2).X),
                            Bezier.Quadratic(0.25, qp(0).Y, qp(1).Y, qp(2).Y)))
            quad.Add(New Point(Bezier.Quadratic(0.5, qp(0).X, qp(1).X, qp(2).X),
                            Bezier.Quadratic(0.5, qp(0).Y, qp(1).Y, qp(2).Y)))
            quad.Add(New Point(Bezier.Quadratic(0.75, qp(0).X, qp(1).X, qp(2).X),
                            Bezier.Quadratic(0.75, qp(0).Y, qp(1).Y, qp(2).Y)))
            quad.Add(qp(2))

            e.Graphics.DrawCurve(Pens.Magenta, quad.ToArray)

            For Each dot As Point In quad
                e.Graphics.FillRectangle(Brushes.Magenta, New Rectangle(dot.X - 2, dot.Y - 2, 4, 4))
            Next
        End If

        If pLen > 3 And sy Then
            Dim cube As New List(Of Point)

            cube.Add(pA(0))
            cube.Add(New Point(Bezier.Cubic(0.16, pA(0).X, pA(1).X, pA(2).X, pA(3).X),
                               Bezier.Cubic(0.16, pA(0).Y, pA(1).Y, pA(2).Y, pA(3).Y)))
            cube.Add(New Point(Bezier.Cubic(0.32, pA(0).X, pA(1).X, pA(2).X, pA(3).X),
                               Bezier.Cubic(0.32, pA(0).Y, pA(1).Y, pA(2).Y, pA(3).Y)))
            cube.Add(New Point(Bezier.Cubic(0.48, pA(0).X, pA(1).X, pA(2).X, pA(3).X),
                               Bezier.Cubic(0.48, pA(0).Y, pA(1).Y, pA(2).Y, pA(3).Y)))
            cube.Add(New Point(Bezier.Cubic(0.64, pA(0).X, pA(1).X, pA(2).X, pA(3).X),
                               Bezier.Cubic(0.64, pA(0).Y, pA(1).Y, pA(2).Y, pA(3).Y)))
            cube.Add(New Point(Bezier.Cubic(0.8, pA(0).X, pA(1).X, pA(2).X, pA(3).X),
                               Bezier.Cubic(0.8, pA(0).Y, pA(1).Y, pA(2).Y, pA(3).Y)))
            cube.Add(pA(3))

            e.Graphics.DrawCurve(Pens.Yellow, cube.ToArray)

            For Each dot As Point In cube
                e.Graphics.FillRectangle(Brushes.Yellow, New Rectangle(dot.X - 2, dot.Y - 2, 4, 4))
            Next
        End If

        '   Built-in function for Bezier
        If pLen > 1 And sg Then
            If (pLen - 1) Mod 3 = 0 Then
                e.Graphics.DrawBeziers(Pens.Green, pA)
            End If
        End If

        If pLen > 1 And sr Then
            Dim atNth As New List(Of Point)
            Dim atNthX As New List(Of Integer)
            Dim atNthY As New List(Of Integer)

            For Each point As Point In pA
                atNthX.Add(point.X)
                atNthY.Add(point.Y)
            Next

            For i As Single = 0 To pLen + (pLen - 2)
                atNth.Add(New Point(Bezier.Nth(i * (1 / (pLen + (pLen - 2))), atNthX.ToArray),
                                    Bezier.Nth(i * (1 / (pLen + (pLen - 2))), atNthY.ToArray)))
            Next

            atNth.RemoveAt(atNth.Count - 1)
            atNth.Add(pA.Last)

            e.Graphics.DrawCurve(Pens.Red, atNth.ToArray)

            For Each dot As Point In atNth
                e.Graphics.FillRectangle(Brushes.Red, New Rectangle(dot.X - 2, dot.Y - 2, 4, 4))
            Next

            e.Graphics.DrawString("Anchors: " & atNth.ToArray.Length, New Font("Consolas", 9), Brushes.White, New Point(10, 15))
        End If

        If pLen > 0 Then
            e.Graphics.FillRectangle(Brushes.White, New Rectangle(pA(0).X - 2, pA(0).Y - 2, 4, 4))
        End If

        e.Graphics.DrawString("Number of points: " & pLen & " / 25", New Font("Consolas", 8), New SolidBrush(Me.ForeColor), New Point(10, 5))
        e.Graphics.DrawString("3 - Points", New Font("Consolas", 8), Brushes.Blue, New Point(10, 25))
        e.Graphics.DrawString("2 - Bulit-in bezier function", New Font("Consolas", 8), Brushes.Green, New Point(10, 35))
        e.Graphics.DrawString("1 - My bezier function / Nth", New Font("Consolas", 8), Brushes.Red, New Point(10, 45))
        e.Graphics.DrawString("4 - Linear", New Font("Consolas", 8), Brushes.Cyan, New Point(10, 55))
        e.Graphics.DrawString("5 - Quadratic", New Font("Consolas", 8), Brushes.Magenta, New Point(10, 65))
        e.Graphics.DrawString("6 - Cubic", New Font("Consolas", 8), Brushes.Yellow, New Point(10, 75))
        e.Graphics.DrawString("0 - Exact", New Font("Consolas", 8), Brushes.White, New Point(10, 85))
        e.Graphics.DrawString("Space - Reset", New Font("Consolas", 8), Brushes.White, New Point(10, 95))
        e.Graphics.DrawString("Left Click - Add point", New Font("Consolas", 8), Brushes.White, New Point(10, 105))
        e.Graphics.DrawString("Right Click - Remove point", New Font("Consolas", 8), Brushes.White, New Point(10, 115))
        e.Graphics.DrawString("Applying bezier curves in graph", Me.Font, Brushes.White, New Rectangle(0, Me.ClientSize.Height - 20, Me.Width, 20), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Space Then
            p = New List(Of Point)
        ElseIf keyData = Keys.D1 Then
            sr = Not sr
        ElseIf keyData = Keys.D2 Then
            sg = Not sg
        ElseIf keyData = Keys.D3 Then
            sb = Not sb
        ElseIf keyData = Keys.D4 Then
            sc = Not sc
        ElseIf keyData = Keys.D5 Then
            sm = Not sm
        ElseIf keyData = Keys.D6 Then
            sy = Not sy
        ElseIf keyData = Keys.D0 Then
            exact = Not exact
        End If

        Me.Invalidate()

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function CP(p() As Point) As Point()
        If p.Length < 3 Then Return p

        Dim tempP As New List(Of Point)
        tempP.Add(p(0))
        tempP.Add(New Point(p(1).X * 2 - (p(0).X + p(2).X) / 2,
                            p(1).Y * 2 - (p(0).Y + p(2).Y) / 2))
        tempP.Add(p(2))

        Return tempP.ToArray
    End Function

End Class