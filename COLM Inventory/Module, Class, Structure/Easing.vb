Public Class Easing

    ''' <summary>
    ''' Calculate an easing frame.
    ''' </summary>
    ''' <param name="effect">The easing effect to be used.</param>
    ''' <param name="t">The frame time at which to calculate.</param>
    ''' <param name="b">The value at which the easing animation started.</param>
    ''' <param name="d">The duration or total frames of easing animation.</param>
    ''' <param name="s">Sensitivity of the easing animation. This is not applicable to all easing effect.</param>
    ''' 
    ''' <returns>A double precision number that represents the frame.</returns>
    Public Shared Function Calculate(effect As Easing.Effect, t As Double, d As Double, b As Double, c As Double, Optional s As Single = 1.70158F) As Double
        Select Case effect
            Case Effect.Linear
                Return Linear(t, b, c, d, s)
                Exit Select
            Case Effect.InSine
                Return InSine(t, b, c, d, s)
                Exit Select
            Case Effect.OutSine
                Return OutSine(t, b, c, d, s)
                Exit Select
            Case Effect.InOutSine
                Return InOutSine(t, b, c, d, s)
                Exit Select
            Case Effect.InQuad
                Return InQuad(t, b, c, d, s)
                Exit Select
            Case Effect.OutQuad
                Return OutQuad(t, b, c, d, s)
                Exit Select
            Case Effect.InOutQuad
                Return InOutQuad(t, b, c, d, s)
                Exit Select
            Case Effect.InCubic
                Return InCubic(t, b, c, d, s)
                Exit Select
            Case Effect.OutCubic
                Return OutCubic(t, b, c, d, s)
                Exit Select
            Case Effect.InOutCubic
                Return InOutCubic(t, b, c, d, s)
                Exit Select
            Case Effect.InQuart
                Return InQuart(t, b, c, d, s)
                Exit Select
            Case Effect.OutQuart
                Return OutQuart(t, b, c, d, s)
                Exit Select
            Case Effect.InOutQuart
                Return InOutQuart(t, b, c, d, s)
                Exit Select
            Case Effect.InQuint
                Return InQuint(t, b, c, d, s)
                Exit Select
            Case Effect.OutQuint
                Return OutQuint(t, b, c, d, s)
                Exit Select
            Case Effect.InOutQuint
                Return InOutQuint(t, b, c, d, s)
                Exit Select
            Case Effect.InExpo
                Return InExpo(t, b, c, d, s)
                Exit Select
            Case Effect.OutExpo
                Return OutExpo(t, b, c, d, s)
                Exit Select
            Case Effect.InOutExpo
                Return InOutExpo(t, b, c, d, s)
                Exit Select
            Case Effect.InCirc
                Return InCirc(t, b, c, d, s)
                Exit Select
            Case Effect.OutCirc
                Return OutCirc(t, b, c, d, s)
                Exit Select
            Case Effect.InOutCirc
                Return InOutCirc(t, b, c, d, s)
                Exit Select
            Case Effect.InBounce
                Return InBounce(t, b, c, d, s)
                Exit Select
            Case Effect.OutBounce
                Return OutBounce(t, b, c, d, s)
                Exit Select
            Case Effect.InOutBounce
                Return InOutBounce(t, b, c, d, s)
                Exit Select
            Case Effect.InBack
                Return InBack(t, b, c, d, s)
                Exit Select
            Case Effect.OutBack
                Return OutBack(t, b, c, d, s)
                Exit Select
            Case Effect.InOutBack
                Return InOutBack(t, b, c, d, s)
                Exit Select
            Case Effect.InElastic
                Return InElastic(t, b, c, d, s)
                Exit Select
            Case Effect.OutElastic
                Return OutElastic(t, b, c, d, s)
                Exit Select
            Case Effect.InOutElastic
                Return InOutElastic(t, b, c, d, s)
                Exit Select
            Case Else
                Return Nothing
                Exit Select
        End Select
    End Function

    '   Linear
    Public Shared Function Linear(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        Return c * t / d + b
    End Function

    '   Sine
    Public Shared Function InSine(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        Return -c * Math.Cos(t / d * (Math.PI / 2)) + c + b
    End Function

    Public Shared Function OutSine(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        Return c * Math.Sin(t / d * (Math.PI / 2)) + b
    End Function

    Public Shared Function InOutSine(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        Return -c / 2 * (Math.Cos(Math.PI * t / d) - 1) + b
    End Function

    '   Quad
    Public Shared Function InQuad(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d
        Return c * t * t + b
    End Function

    Public Shared Function OutQuad(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d
        Return -c * t * (t - 2) + b
    End Function

    Public Shared Function InOutQuad(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d / 2
        If (t < 1) Then
            Return c / 2 * t * t + b
        End If
        t -= 1
        Return -c / 2 * (t * (t - 2) - 1) + b
    End Function

    '   Cubic
    Public Shared Function InCubic(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d
        Return c * t * t * t + b
    End Function

    Public Shared Function OutCubic(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t = (t / d) - 1
        Return c * (t * t * t + 1) + b
    End Function

    Public Shared Function InOutCubic(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d / 2
        If (t < 1) Then
            Return c / 2 * t * t * t + b
        End If
        t -= 2
        Return c / 2 * (t * t * t + 2) + b
    End Function

    '   Quart
    Public Shared Function InQuart(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d
        Return c * t * t * t * t + b
    End Function

    Public Shared Function OutQuart(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t = (t / d) - 1
        Return -c * (t * t * t * t - 1) + b
    End Function

    Public Shared Function InOutQuart(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d / 2
        If (t < 1) Then
            Return c / 2 * t * t * t * t + b
        End If
        t -= 2
        Return -c / 2 * (t * t * t * t - 2) + b
    End Function

    '   Quint
    Public Shared Function InQuint(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d
        Return c * t * t * t * t * t + b
    End Function

    Public Shared Function OutQuint(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t = (t / d) - 1
        Return c * (t * t * t * t * t + 1) + b
    End Function

    Public Shared Function InOutQuint(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d / 2
        If (t < 1) Then
            Return c / 2 * t * t * t * t * t + b
        End If
        t -= 2
        Return c / 2 * (t * t * t * t * t + 2) + b
    End Function

    '   Expo
    Public Shared Function InExpo(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        Return If(t = 0, b, c * Math.Pow(2, 10 * (t / d - 1)) + b)
    End Function

    Public Shared Function OutExpo(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        Return If(t = d, b + c, c * (-Math.Pow(2, -10 * t / d) + 1) + b)
    End Function

    Public Shared Function InOutExpo(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        If (t = 0) Then
            Return b
        End If
        If (t = d) Then
            Return b + c
        End If
        t = t / (d / 2)
        If (t < 1) Then
            Return c / 2 * Math.Pow(2, 10 * (t - 1)) + b
        End If
        Return c / 2 * (-Math.Pow(2, -10 * (t - 1)) + 2) + b
    End Function

    '   Circ
    Public Shared Function InCirc(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d
        Return -c * (Math.Sqrt(1 - t * t) - 1) + b
    End Function

    Public Shared Function OutCirc(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t = t / d - 1
        Return c * Math.Sqrt(1 - t * t) + b
    End Function

    Public Shared Function InOutCirc(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t = t / (d / 2)
        If (t < 1) Then
            Return -c / 2 * (Math.Sqrt(1 - t * t) - 1) + b
        End If
        t -= 2
        Return c / 2 * (Math.Sqrt(1 - t * t) + 1) + b
    End Function

    '   Bounce
    Public Shared Function InBounce(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        Return c - OutBounce(d - t, 0, c, d) + b
    End Function

    Public Shared Function OutBounce(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d
        If (t < (1 / 2.75F)) Then
            Return c * (7.5625F * t * t) + b
        ElseIf (t < (2 / 2.75F)) Then
            t -= (1.5F / 2.75F)
            Return c * (7.5625F * t * t + 0.75F) + b
        ElseIf (t < (2.5 / 2.75)) Then
            t -= (2.25F / 2.75F)
            Return c * (7.5625F * t * t + 0.9375F) + b
        Else
            t -= (2.625F / 2.75F)
            Return c * (7.5625F * t * t + 0.984375F) + b
        End If
    End Function

    Public Shared Function InOutBounce(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        If (t < d / 2) Then
            Return InBounce(t * 2, 0, c, d) * 0.5F + b
        Else
            Return OutBounce(t * 2 - d, 0, c, d) * 0.5F + c * 0.5F + b
        End If
    End Function

    '   Back
    Public Shared Function InBack(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t /= d
        s *= 2 'Sensitivity
        Return c * t * t * ((s + 1) * t - s) + b
    End Function

    Public Shared Function OutBack(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t = (t / d) - 1
        s *= 2 'Sensitivity
        Return c * (t * t * ((s + 1) * t + s) + 1) + b
    End Function

    Public Shared Function InOutBack(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single
        t = t / (d / 2)
        s *= 2 'Sensitivity
        If (t < 1) Then
            Return c / 2 * (t * t * ((s + 1) * t - s)) + b
        End If
        t -= 2
        Return c / 2 * (t * t * ((s + 1) * t + s) + 2) + b
    End Function

    '   Elastic
    Public Shared Function InElastic(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single

        Dim p As Single = d * 0.3F 'Sensitivity
        Dim a As Single = c
        If t = 0 Then
            Return b
        End If
        t /= d
        If t = 1 Then
            Return b + c
        End If
        If a < Math.Abs(c) Then
            a = c
            s = p / 4
        Else
            s = p / (2 * Math.PI) * Math.Asin(c / a)
        End If
        t -= 1
        Return -(a * Math.Pow(2, 10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b

    End Function

    Public Shared Function OutElastic(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single

        Dim p As Single = d * 0.3F 'Sensitivity
        Dim a As Single = c
        If (t = 0) Then
            Return b
        End If
        t /= d
        If (t = 1) Then
            Return b + c
        End If
        If a < Math.Abs(c) Then
            a = c
            s = p / 4
        Else
            s = p / (2 * Math.PI) * Math.Asin(c / a)
        End If
        Return a * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p) + c + b

    End Function

    Public Shared Function InOutElastic(t As Single, b As Single, c As Single, d As Single, Optional s As Single = 1.70158F) As Single

        Dim p As Single = d * (0.3F * 1.5F) 'Sensitivity
        Dim a As Single = c
        If (t = 0) Then
            Return b
        End If
        t /= d / 2
        If (t = 2) Then
            Return b + c
        End If
        If (a < Math.Abs(c)) Then
            a = c
            s = p / 4
        Else
            s = p / (2 * Math.PI) * Math.Asin(c / a)
        End If
        If (t < 1) Then
            t -= 1
            Return -0.5F * (a * Math.Pow(2, 10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b
        End If
        t -= 1
        Return a * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p) * 0.5F + c + b

    End Function

    Public Enum Effect
        Linear
        InSine
        OutSine
        InOutSine
        InQuad
        OutQuad
        InOutQuad
        InCubic
        OutCubic
        InOutCubic
        InQuart
        OutQuart
        InOutQuart
        InQuint
        OutQuint
        InOutQuint
        InExpo
        OutExpo
        InOutExpo
        InCirc
        OutCirc
        InOutCirc
        InBounce
        OutBounce
        InOutBounce
        InBack
        OutBack
        InOutBack
        InElastic
        OutElastic
        InOutElastic
    End Enum

End Class
