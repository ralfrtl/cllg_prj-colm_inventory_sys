Imports System.ComponentModel

<DefaultEvent("OnTextBoxKeyUp")>
Public Class ctrlPaddedTextBox

    Public Event OnTextBoxKeyUp(sender As Object, e As KeyEventArgs)

    Private autoFixVal As Boolean = True
    Private borderColorVal As Color = Color.Black
    Private focusedBorderColorVal As Color = Color.Gray
    Private borderThicknessVal As Integer = 0

    ''' <summary>
    ''' This will inflate the control depending on the values of the control's minimum size and actual size and the textbox' width and location.
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(True)>
    Public Property AutoFix As Boolean
        Get
            Return autoFixVal
        End Get
        Set(value As Boolean)
            autoFixVal = value
            Fix()
        End Set
    End Property

    Public Overrides Property BackColor As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(value As Color)
            MyBase.BackColor = value
            TextBox.BackColor = value
        End Set
    End Property

    <DefaultValue(GetType(Color), "Black")>
    Public Property BorderColor As Color
        Get
            Return borderColorVal
        End Get
        Set(value As Color)
            borderColorVal = value
            Me.Invalidate()
        End Set
    End Property

    <DefaultValue(0)>
    Public Property BorderThickness As Integer
        Get
            Return borderThicknessVal
        End Get
        Set(value As Integer)
            borderThicknessVal = value
            Fix()
        End Set
    End Property

    <DefaultValue(GetType(Color), "Gray")>
    Public Property FocusedBorderColor As Color
        Get
            Return focusedBorderColorVal
        End Get
        Set(value As Color)
            focusedBorderColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
            TextBox.Font = value
            Fix()
        End Set
    End Property

    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(value As Color)
            MyBase.ForeColor = value
            TextBox.ForeColor = value
        End Set
    End Property

    Public Overrides Property MinimumSize As Size
        Get
            Return MyBase.MinimumSize
        End Get
        Set(value As Size)
            MyBase.MinimumSize = value
            Fix()
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    Public Overrides Property Text As String
        Get
            Return TextBox.Text
        End Get
        Set(value As String)
            TextBox.Text = value
        End Set
    End Property

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()

        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnAutoSizeChanged(e As EventArgs)
        MyBase.OnAutoSizeChanged(e)

        If AutoFix Then
            Me.AutoSize = False
        End If
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)

        TextBox.Select()
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)

        TextBox.Select()
    End Sub

    Protected Overrides Sub OnPaddingChanged(e As EventArgs)
        MyBase.OnPaddingChanged(e)

        Fix()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If Me.BorderThickness > 0 Then
            If TextBox.Focused Then
                e.Graphics.DrawRectangle(New Pen(Me.FocusedBorderColor, Me.BorderThickness) With {.Alignment = Drawing2D.PenAlignment.Inset}, New Rectangle(0, 0, Me.Width - IIf(Me.BorderThickness = 1, 1, 0), Me.Height - IIf(Me.BorderThickness = 1, 1, 0)))
            Else
                e.Graphics.DrawRectangle(New Pen(Me.BorderColor, Me.BorderThickness) With {.Alignment = Drawing2D.PenAlignment.Inset}, New Rectangle(0, 0, Me.Width - IIf(Me.BorderThickness = 1, 1, 0), Me.Height - IIf(Me.BorderThickness = 1, 1, 0)))
            End If
        End If

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)

        Fix()
    End Sub

    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs) Handles TextBox.GotFocus
        Me.Invalidate()
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox.KeyUp
        RaiseEvent OnTextBoxKeyUp(sender, e)
    End Sub

    Private Sub TextBox_LocationChanged(sender As Object, e As EventArgs) Handles TextBox.LocationChanged
        Fix()
    End Sub

    Private Sub TextBox_LostFocus(sender As Object, e As EventArgs) Handles TextBox.LostFocus
        Me.Invalidate()
    End Sub

    Private Sub TextBox_SizeChanged(sender As Object, e As EventArgs) Handles TextBox.SizeChanged
        Fix()
    End Sub

    Private Sub Fix()
        If Not Me.AutoFix Then Exit Sub

        TextBox.Size = New Size(Me.Width - Me.Padding.Left - Me.Padding.Right - Me.BorderThickness * 2, TextBox.Height)
        TextBox.Location = New Point(Me.Padding.Left + Me.BorderThickness, Me.Padding.Top + Me.BorderThickness)

        If Me.MinimumSize.Height < TextBox.Height + Me.Padding.Top + Me.Padding.Bottom + Me.BorderThickness * 2 Then
            Me.MinimumSize = New Size(Me.MinimumSize.Width, TextBox.Height + Me.Padding.Top + Me.Padding.Bottom + Me.BorderThickness * 2)
        End If

        Me.Invalidate()
    End Sub

End Class
