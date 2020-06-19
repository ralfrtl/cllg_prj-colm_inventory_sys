Imports System.ComponentModel

Public Class ctrlTitleBar : Inherits Panel

    Private cursorOnClient As Point
    Private movableBoundsMargin As Integer = 0
    Private iconLocation As Point
    Private titleVal As String = "Title Bar"
    Private titleIconVal As Image = Nothing

    Public Property DoubleClickMaximized As Boolean = True
    Public Property FormMovable As Boolean = True

    Public Property Icon As Image
        Get
            Return titleIconVal
        End Get
        Set(value As Image)
            titleIconVal = value
            Me.Invalidate()
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    Public Property Title As String
        Get
            Return titleVal
        End Get
        Set(value As String)
            titleVal = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(200, 30)
    End Sub

    Protected Overrides Sub OnDoubleClick(e As EventArgs)
        If Me.DoubleClickMaximized Then
            If Me.FindForm.WindowState = FormWindowState.Normal Then
                Me.FindForm.MaximumSize = Screen.GetWorkingArea(Me).Size
                Me.FindForm.WindowState = FormWindowState.Maximized
            ElseIf Me.FindForm.WindowState = FormWindowState.Maximized Then
                Me.FindForm.WindowState = FormWindowState.Normal
            End If
        End If

        MyBase.OnDoubleClick(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If Me.FormMovable Then
            If e.Button = MouseButtons.None Then
                cursorOnClient = Cursor.Position - Me.FindForm.Location
            ElseIf e.Button = MouseButtons.Left Then
                If Me.FindForm.WindowState = FormWindowState.Maximized Then
                    Me.FindForm.SuspendLayout()
                    Me.FindForm.WindowState = FormWindowState.Normal

                    If cursorOnClient.X > (Me.FindForm.Width * 0.6) Then
                        cursorOnClient = New Point(Me.FindForm.Width / 2, cursorOnClient.Y)
                    End If

                    Me.FindForm.Location = Cursor.Position - cursorOnClient
                    Me.FindForm.ResumeLayout()
                End If

                Me.FindForm.Location = Cursor.Position - cursorOnClient
            End If
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If Me.FormMovable Then
            If Me.FindForm.WindowState = FormWindowState.Normal Then
                If Me.FindForm.Location.Y > Screen.GetWorkingArea(Me).Bottom - movableBoundsMargin Then
                    Me.FindForm.Location = New Point(Me.FindForm.Location.X, Screen.GetWorkingArea(Me).Bottom - movableBoundsMargin)
                End If
                If Me.FindForm.Location.X > Screen.GetWorkingArea(Me).Right - movableBoundsMargin Then
                    Me.FindForm.Location = New Point(Screen.GetWorkingArea(Me).Right - movableBoundsMargin, Me.FindForm.Location.Y)
                End If
                If Me.FindForm.Location.Y < Screen.FromControl(Me).Bounds.Y Then
                    Me.FindForm.Location = New Point(Me.FindForm.Location.X, Screen.FromControl(Me).Bounds.Y)
                End If
                If Me.FindForm.Location.X < -(If(Screen.GetBounds(Me).X < 0, -Screen.GetBounds(Me).X, Screen.GetBounds(Me).X) + Me.FindForm.Width - movableBoundsMargin) Then
                    Me.FindForm.Location = New Point(-(If(Screen.GetBounds(Me).X < 0, -Screen.GetBounds(Me).X, Screen.GetBounds(Me).X) + Me.FindForm.Width - movableBoundsMargin), Me.FindForm.Location.Y)
                End If
            End If
        End If

        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        With e.Graphics
            If Me.Icon IsNot Nothing Then
                .DrawImage(Me.Icon, New Rectangle(0, 0, 30, 30))
                .DrawString(Me.Title, Me.Font, New SolidBrush(Me.ForeColor), New Rectangle(30, 0, Me.Width - 40, 30), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
            Else
                .DrawString(Me.Title, Me.Font, New SolidBrush(Me.ForeColor), New Rectangle(10, 0, Me.Width - 10, 30), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
            End If
        End With

        MyBase.OnPaint(e)
    End Sub

End Class
