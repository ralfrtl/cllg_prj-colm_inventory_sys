
Public Class Bezier

    Public Shared Function Easing(time As Integer, durarion As Integer, points() As Integer) As Integer
        Return Nth(time * (1 / IIf(durarion = 0, 1, durarion)), points)
    End Function

    Public Shared Function Linear(t As Single, p0 As Integer, p1 As Integer) As Decimal
        Return (1 - t) * p0 + t * p1
    End Function

    Public Shared Function Quadratic(t As Single, p0 As Integer, p1 As Integer, p2 As Integer) As Decimal
        '2 (p2 - 2p1 + p0)
        Return Math.Pow(1 - t, 2) * p0 + 2 * (1 - t) * t * p1 + Math.Pow(t, 2) * p2
    End Function

    Public Shared Function Cubic(t As Single, p0 As Integer, p1 As Integer, p2 As Integer, p3 As Integer) As Decimal
        '6 (1 - t) (p2 - 2p1 + p0) + 6t (p3 - 2p2 + p1)
        Return Math.Pow(1 - t, 3) * p0 + 3 * Math.Pow(1 - t, 2) * t * p1 + 3 * (1 - t) * Math.Pow(t, 2) * p2 + Math.Pow(t, 3) * p3
    End Function

    Public Shared Function Nth(t As Single, p() As Integer) As Decimal
        Select Case p.Length
            Case 0
                Return Nothing
            Case 1
                Return p(0)
            Case 2
                Return Linear(t, p(0), p(1))
            Case 3
                Return Quadratic(t, p(0), p(1), p(2))
            Case 4
                Return Cubic(t, p(0), p(1), p(2), p(3))
        End Select

        Dim ret As Decimal = 0
        Dim n As Integer = p.Length - 1

        For i As Decimal = 0 To n
            ret += (NCI(n, i) * Math.Pow(1 - t, n - i) * Math.Pow(t, i) * p(i))
        Next

        Return ret

        'n Summation i = 0 : (nCi) (1 - t)^n - i t^i Pi
    End Function

    Private Shared Function NCI(n As Integer, i As Integer) As Decimal
        Return Factorial(n) / (Factorial(i) * Factorial(n - i))
    End Function

    Private Shared Function Factorial(num As Integer) As Decimal
        If num = 0 Then Return 1

        Dim ret As Decimal = num

        For i As Decimal = num - 1 To 2 Step -1
            ret *= i
        Next

        Return ret
    End Function

End Class
