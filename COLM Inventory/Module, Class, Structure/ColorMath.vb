
''' <summary>
''' Similar to a standard color structure but allows negative numbers.
''' </summary>
Public Structure ColorMath

    Public Property A As Integer
    Public Property R As Integer
    Public Property G As Integer
    Public Property B As Integer

    Public Sub New(color As Color)
        Me.A = color.A
        Me.R = color.R
        Me.G = color.G
        Me.B = color.B
    End Sub

    Public Sub New(alpha As Integer, color As Color)
        If alpha < -255 Or alpha > 255 Then
            Throw New Exception("Alpha value must be between -255 and 255")
        End If

        Me.A = alpha
        Me.R = color.R
        Me.G = color.G
        Me.B = color.B
    End Sub

    Public Sub New(red As Integer, green As Integer, blue As Integer)
        If red < -255 Or red > 255 Then
            Throw New Exception("Red value must be between -255 and 255")
        End If
        If green < -255 Or green > 255 Then
            Throw New Exception("Green value must be between -255 and 255")
        End If
        If blue < -255 Or blue > 255 Then
            Throw New Exception("Blue value must be between -255 and 255")
        End If

        Me.A = 255
        Me.R = red
        Me.G = green
        Me.B = blue
    End Sub

    Public Sub New(alpha As Integer, red As Integer, green As Integer, blue As Integer)
        If alpha < -255 Or alpha > 255 Then
            Throw New Exception("Alpha value must be between -255 and 255")
        End If
        If red < -255 Or red > 255 Then
            Throw New Exception("Red value must be between -255 and 255")
        End If
        If green < -255 Or green > 255 Then
            Throw New Exception("Green value must be between -255 and 255")
        End If
        If blue < -255 Or blue > 255 Then
            Throw New Exception("Blue value must be between -255 and 255")
        End If

        Me.A = alpha
        Me.R = red
        Me.G = green
        Me.B = blue
    End Sub

    Public Shared Operator +(color1 As ColorMath, color2 As ColorMath) As ColorMath
        Return New ColorMath(color1.A + color2.A, color1.R + color2.R, color1.G + color2.G, color1.B + color2.B)
    End Operator

    Public Shared Operator -(color1 As ColorMath, color2 As ColorMath) As ColorMath
        Return New ColorMath(color1.A - color2.A, color1.R - color2.R, color1.G - color2.G, color1.B - color2.B)
    End Operator

    Public Shared Operator =(color1 As ColorMath, color2 As ColorMath) As Boolean
        Return If(color1.A = color2.A And color1.R = color2.R And color1.G = color2.G And color1.B = color2.B, True, False)
    End Operator

    Public Shared Operator <>(color1 As ColorMath, color2 As ColorMath) As Boolean
        Return If(color1.A <> color2.A Or color1.R <> color2.R Or color1.G <> color2.G Or color1.B <> color2.B, True, False)
    End Operator

    Public Function ToColor() As Color
        Return Color.FromArgb(IIf(Me.A < 0, Me.A * -1, Me.A),
                              IIf(Me.R < 0, Me.R * -1, Me.R),
                              IIf(Me.G < 0, Me.G * -1, Me.G),
                              IIf(Me.B < 0, Me.B * -1, Me.B))
    End Function

    ''' <summary>
    ''' Mixes the two colors together.
    ''' </summary>
    ''' <param name="color1">The base color of the mix.</param>
    ''' <param name="color2">The color that will be mixed on top of color1.</param>
    ''' <returns>The result of the mixture.</returns>
    Public Shared Function Mix(color1 As Color, color2 As Color) As Color
        Dim color1Math As New ColorMath(color1)
        Dim color2Math As New ColorMath(color2)
        Return New ColorMath(Math.Round(color1Math.A - ((color1Math.A - color2Math.A) * ((color2Math.A / 2.55) / 100))),
                             Math.Round(color1Math.R - ((color1Math.R - color2Math.R) * ((color2Math.A / 2.55) / 100))),
                             Math.Round(color1Math.G - ((color1Math.G - color2Math.G) * ((color2Math.A / 2.55) / 100))),
                             Math.Round(color1Math.B - ((color1Math.B - color2Math.B) * ((color2Math.A / 2.55) / 100)))).ToColor
    End Function

    ''' <summary>
    ''' Inverts the color.
    ''' </summary>
    ''' <param name="color">The color that will be inverted.</param>
    ''' <returns>The opposite of the given color from the color spectrum.</returns>
    Public Shared Function Invert(color As Color) As Color
        Return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B)
    End Function

    Public Enum ColorIntensity
        Saturated
        Flat
        Washed
        Pastel
        Muted
        Pale
        Grayscale
    End Enum

End Structure