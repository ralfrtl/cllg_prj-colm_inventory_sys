Class ctrlTabControl : Inherits TabControl

    Private hotTrackIndex As Integer = -1
    Private activeBGColorVal As Color = Color.Black
    Private activeFGColorVal As Color = Color.White
    Private bodyColorVal As Color = Color.White
    Private headerColorVal As Color = Color.White
    Private hoverBGColorVal As Color = Color.Gray
    Private hoverFGColorVal As Color = Color.White
    Private inActiveBGColorVal As Color = Color.White
    Private inActiveFGColorVal As Color = Color.Black

    Public Property ActiveBGColor As Color
        Get
            Return activeBGColorVal
        End Get
        Set(value As Color)
            activeBGColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ActiveFGColor As Color
        Get
            Return activeFGColorVal
        End Get
        Set(value As Color)
            activeFGColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BodyColor As Color
        Get
            Return bodyColorVal
        End Get
        Set(value As Color)
            bodyColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property HeaderColor As Color
        Get
            Return headerColorVal
        End Get
        Set(value As Color)
            headerColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property HoverBGColor As Color
        Get
            Return hoverBGColorVal
        End Get
        Set(value As Color)
            hoverBGColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property HoverFGColor As Color
        Get
            Return hoverFGColorVal
        End Get
        Set(value As Color)
            hoverFGColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property InActiveBGColor As Color
        Get
            Return inActiveBGColorVal
        End Get
        Set(value As Color)
            inActiveBGColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property InActiveFGColor As Color
        Get
            Return inActiveFGColorVal
        End Get
        Set(value As Color)
            inActiveFGColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()

        Me.Alignment = TabAlignment.Top
        Me.Appearance = TabAppearance.Normal
        Me.DoubleBuffered = True
        Me.Multiline = False
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)

        If SelectedTab IsNot Nothing And Not DesignMode Then
            Me.SelectedTab.SelectNextControl(Me.SelectedTab, True, False, True, False)
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        hotTrackIndex = -1

        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If Me.HotTrack Then
            For i As Integer = 0 To Me.TabPages.Count - 1
                If Me.GetTabRect(i).Contains(e.X, e.Y) Then
                    hotTrackIndex = i
                End If
            Next
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        With e.Graphics
            .Clear(Me.BodyColor)

            If Me.SelectedTab IsNot Nothing Then
                .FillRectangle(New SolidBrush(Me.HeaderColor), New Rectangle(New Point(0, 0), New Size(Me.Width, Me.SelectedTab.Location.Y)))

                For index As Integer = 0 To Me.TabCount - 1
                    Dim TabRectangle As New Rectangle(Me.GetTabRect(index).X + IIf(index = 0, 2, 0), -2, Me.GetTabRect(index).Width - IIf(index = 0, 2, 0), Me.SelectedTab.Location.Y + 2)

                    If index = Me.SelectedIndex Then
                        .FillRectangle(New SolidBrush(Me.activeBGColorVal), TabRectangle)
                        .DrawString(Me.SelectedTab.Text, Me.Font, New SolidBrush(Me.ActiveFGColor), TabRectangle, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    Else
                        .FillRectangle(New SolidBrush(Me.InActiveBGColor), TabRectangle)
                        .DrawString(Me.TabPages(index).Text, Me.Font, New SolidBrush(Me.InActiveFGColor), TabRectangle, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If

                    If Me.HotTrack Then
                        If index = hotTrackIndex And index <> Me.SelectedIndex Then
                            .FillRectangle(New SolidBrush(Me.HoverBGColor), TabRectangle)
                            .DrawString(Me.TabPages(index).Text, Me.Font, New SolidBrush(Me.HoverFGColor), TabRectangle, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                        End If
                    End If
                Next
            End If
        End With

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
        MyBase.OnSelectedIndexChanged(e)

        If SelectedTab IsNot Nothing And Not DesignMode Then
            Me.SelectedTab.SelectNextControl(Me.SelectedTab, True, False, True, False)
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.D1) Then
            Me.SelectedIndex = 0
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D2) Then
            Me.SelectedIndex = 1
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D3) Then
            Me.SelectedIndex = 2
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D4) Then
            Me.SelectedIndex = 3
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D5) Then
            Me.SelectedIndex = 4
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D6) Then
            Me.SelectedIndex = 5
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D7) Then
            Me.SelectedIndex = 6
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D8) Then
            Me.SelectedIndex = 7
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D9) Then
            Me.SelectedIndex = 8
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
