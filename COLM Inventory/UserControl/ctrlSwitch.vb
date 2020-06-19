Imports System.ComponentModel

Public Class ctrlSwitch : Inherits CheckBox

    Private onColorVal As Color = Color.Black
    Private offColorVal As Color = Color.Gray

    <DefaultValue(GetType(Color), "Black")>
    Property OnColor As Color
        Get
            Return onColorVal
        End Get
        Set(value As Color)
            onColorVal = value
            Me.Invalidate()
        End Set
    End Property

    <DefaultValue(GetType(Color), "Gray")>
    Public Property OffColor As Color
        Get
            Return offColorVal
        End Get
        Set(value As Color)
            offColorVal = value
            Me.Invalidate()
        End Set
    End Property

    Overrides Property AutoSize As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)
            If value Then MyBase.AutoSize = False
        End Set
    End Property

    Public Sub New()
        Me.AutoEllipsis = True
        Me.AutoSize = False
        Me.DoubleBuffered = True
        Me.ResizeRedraw = True
        Me.Size = New Size(100, 20)
    End Sub

    Protected Overrides Sub OnCheckedChanged(e As EventArgs)
        MyBase.OnCheckedChanged(e)

        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        With e.Graphics
            .Clear(Me.BackColor)
            .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim pad As Integer = 3
            Dim myRec As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
            Dim switchRec As New Rectangle(Me.ClientSize.Width - 40 - pad, (myRec.Height - 20) / 2, 40, 20)
            Dim toggleRec As New Rectangle(3, 3, 14, 14)
            Dim textRec As New Rectangle(Me.Padding.Left + pad, Me.Padding.Top + pad,
                                         myRec.Width - Me.Padding.Left - Me.Padding.Right - switchRec.Width - pad * 3,
                                         myRec.Height - Me.Padding.Top - Me.Padding.Bottom - pad * 2)

            .DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), textRec, New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .Trimming = StringTrimming.EllipsisWord})

            If Me.CheckState = CheckState.Indeterminate Then
                .FillEllipse(New SolidBrush(Me.OffColor), New Rectangle(switchRec.X, switchRec.Y, switchRec.Height, switchRec.Height))
                .FillEllipse(New SolidBrush(Me.OffColor), New Rectangle(switchRec.Right - switchRec.Height, switchRec.Y, switchRec.Height, switchRec.Height))
                .FillRectangle(New SolidBrush(Me.OffColor), New Rectangle(switchRec.X + switchRec.Height / 2, switchRec.Y, switchRec.Width - switchRec.Height, switchRec.Height))
            Else
                If Me.Checked Then
                    .FillEllipse(New SolidBrush(Me.OnColor), New Rectangle(switchRec.X, switchRec.Y, switchRec.Height, switchRec.Height))
                    .FillEllipse(New SolidBrush(Me.OnColor), New Rectangle(switchRec.Right - switchRec.Height, switchRec.Y, switchRec.Height, switchRec.Height))
                    .FillRectangle(New SolidBrush(Me.OnColor), New Rectangle(switchRec.X + switchRec.Height / 2, switchRec.Y, switchRec.Width - switchRec.Height, switchRec.Height))
                    .FillEllipse(New SolidBrush(Me.BackColor), New Rectangle(switchRec.Right - toggleRec.Right, switchRec.Y + toggleRec.Y, toggleRec.Height, toggleRec.Height))
                Else
                    .FillEllipse(New SolidBrush(Me.OffColor), New Rectangle(switchRec.X, switchRec.Y, switchRec.Height, switchRec.Height))
                    .FillEllipse(New SolidBrush(Me.OffColor), New Rectangle(switchRec.Right - switchRec.Height, switchRec.Y, switchRec.Height, switchRec.Height))
                    .FillRectangle(New SolidBrush(Me.OffColor), New Rectangle(switchRec.X + switchRec.Height / 2, switchRec.Y, switchRec.Width - switchRec.Height, switchRec.Height))
                    .FillEllipse(New SolidBrush(Me.BackColor), New Rectangle(switchRec.X + toggleRec.X, switchRec.Y + toggleRec.Y, toggleRec.Height, toggleRec.Height))
                End If
            End If

            If Me.Focused Then
                .DrawRectangle(New Pen(Color.FromArgb(100, Me.ForeColor), 1) With {.Alignment = Drawing2D.PenAlignment.Inset}, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
            End If
        End With
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)

        Me.Invalidate()
    End Sub

End Class
