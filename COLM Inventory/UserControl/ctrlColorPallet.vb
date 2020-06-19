Public Class ctrlColorPallet

    Private color1Val As Color = Color.White
    Private color2Val As Color = Color.Black
    Private switchValuesVal As Boolean = True

    Public Property Color1 As Color
        Get
            Return color1Val
        End Get
        Set(value As Color)
            color1Val = Color.FromArgb(255, value)
            pnlColor1.BackColor = Color.FromArgb(255, value)
            lblColor1.Text = value.R & ", " & value.G & ", " & value.B
            Me.Invalidate()
        End Set
    End Property

    Public Property Color2 As Color
        Get
            Return color2Val
        End Get
        Set(value As Color)
            color2Val = value
            pnlColor2.BackColor = Color.FromArgb(255, value)
            lblColor2.Text = value.A & ", " & value.R & ", " & value.G & ", " & value.B
            Me.Invalidate()
        End Set
    End Property

    Public Property SwitchValues As Boolean
        Get
            Return switchValuesVal
        End Get
        Set(value As Boolean)
            switchValuesVal = True
            btnSwitch_Click(Nothing, Nothing)
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim h As Integer = 400 - 70

        With e.Graphics
            .FillRectangle(New SolidBrush(color1Val),
                               New Rectangle(10, 60, 100, h * 0.1))
            .DrawString("1 - " & color1Val.R & ", " & color1Val.G & ", " & color1Val.B, Me.Font, Brushes.Black, New Rectangle(120, 60, 120, h * 0.1))

            For i As Single = 0.1 To 1 Step 0.1
                Dim c As Color = Color.FromArgb(Bezier.Nth(i, {color1Val.R, color1Val.R, color2Val.R}),
                                                Bezier.Nth(i, {color1Val.G, color1Val.G, color2Val.G}),
                                                Bezier.Nth(i, {color1Val.B, color1Val.B, color2Val.B}))
                .FillRectangle(New SolidBrush(c),
                               New Rectangle(10, 60 + h * i, 100, h * i))
                .DrawString(Math.Round(i * 10 + 1) & " - " & c.R & ", " & c.G & ", " & c.B, Me.Font, Brushes.Black, New Rectangle(120, 60 + h * i, 120, h * i))
            Next
        End With
    End Sub

    Private Sub btnColor1_Click(sender As Object, e As EventArgs) Handles btnColor1.Click
        If clrDlg.ShowDialog = DialogResult.OK Then
            Me.Color1 = Color.FromArgb(255, clrDlg.Color)
        End If
    End Sub

    Private Sub btnColor2_Click(sender As Object, e As EventArgs) Handles btnColor2.Click
        If clrDlg.ShowDialog = DialogResult.OK Then
            Me.Color2 = clrDlg.Color
        End If
    End Sub

    Private Sub btnSwitch_Click(sender As Object, e As EventArgs) Handles btnSwtich.Click
        Dim colorTemp = Me.Color1
        Me.Color1 = Me.Color2
        Me.Color2 = Color.FromArgb(Me.Color2.A, colorTemp)
    End Sub

End Class
