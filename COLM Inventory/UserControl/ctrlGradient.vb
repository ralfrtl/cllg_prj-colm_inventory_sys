Imports System.Drawing.Drawing2D

Public Class ctrlGradient : Inherits Panel

    Private angleVal As Single = 0
    Private color1Val As Color = Color.Black
    Private color2Val As Color = Color.White
    Private midIntensityVal As Single = 0.5F
    Private midPositionVal As Single = 0.5F

    Public Property Angle As Single
        Get
            Return angleVal
        End Get
        Set(value As Single)
            angleVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property Color1 As Color
        Get
            Return color1Val
        End Get
        Set(value As Color)
            color1Val = value
            Me.Invalidate()
        End Set
    End Property

    Public Property Color2 As Color
        Get
            Return color2Val
        End Get
        Set(value As Color)
            color2Val = value
            Me.Invalidate()
        End Set
    End Property

    Public Property MidIntensity As Single
        Get
            Return midIntensityVal
        End Get
        Set(value As Single)
            midIntensityVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property MidPosition As Single
        Get
            Return midPositionVal
        End Get
        Set(value As Single)
            midPositionVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        With e.Graphics
            .SmoothingMode = SmoothingMode.AntiAlias

            Dim rec As New Rectangle(0, 0, Me.Width + 1, Me.Height + 1)

            Using lgb As New LinearGradientBrush(rec, Me.Color1, Me.Color2, Me.Angle, True)
                Dim relativeIntensities As Single() = {0.0F, Me.MidIntensity, 1.0F}
                Dim relativePositions As Single() = {0.0F, Me.MidPosition, 1.0F}
                Dim blend As New Blend With {
                    .Factors = relativeIntensities,
                    .Positions = relativePositions
                }
                lgb.Blend = blend

                .FillRectangle(lgb, Me.DisplayRectangle)
            End Using
        End With

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        Me.Invalidate()

        MyBase.OnSizeChanged(e)
    End Sub

End Class
