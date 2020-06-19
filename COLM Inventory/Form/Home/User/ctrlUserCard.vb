
Public Class ctrlUserCard

    Private hovered As Boolean = False
    Private parentContainer As ctrlUser

    Friend userDetails As UserDetails

    Public Sub New(userDetails As UserDetails)
        If userDetails Is Nothing Then Throw New ArgumentNullException("userDetails")
        Me.userDetails = userDetails

        InitializeComponent()

        Me.DoubleBuffered = True
        PrintRecord()

        For Each control As Control In Me.Controls
            AddHandler control.MouseDown, AddressOf ctrlUserCard_MouseDown
            AddHandler control.MouseEnter, AddressOf ctrlUserCard_MouseEnter
            AddHandler control.MouseLeave, AddressOf ctrlUserCard_MouseLeave
        Next
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        parentContainer = TryCast(Me.Parent.Parent, ctrlUser)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim alpha As Single = 2
        If hovered Then alpha = 5

        For i As Integer = 1 To 10
            e.Graphics.DrawRectangle(New Pen(Color.FromArgb(alpha * i, Color.Black), 1) With {.Alignment = Drawing2D.PenAlignment.Inset},
                                     New Rectangle(-1 + i, -1 + i, Me.Width + 1 - i * 2, Me.Height + 1 - i * 2))
        Next

        If parentContainer IsNot Nothing Then
            If parentContainer.SelectedCard Is Me Then
                If Me.Focused Then
                    e.Graphics.DrawRectangle(New Pen(Color.Green, 2), New Rectangle(11, 11, Me.Width - 22, Me.Height - 22))
                    e.Graphics.DrawRectangle(New Pen(Color.Green, 2), New Rectangle(11, 11, Me.Width - 22, Me.Height - 22))
                Else
                    e.Graphics.DrawRectangle(New Pen(Color.Green, 1), New Rectangle(10, 10, Me.Width - 21, Me.Height - 21))
                End If
            End If
        End If
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)

        If Not Me.Visible Then
            If parentContainer IsNot Nothing Then
                If parentContainer.SelectedCard Is Me Then
                    parentContainer.SelectedCard = Nothing
                End If
            End If

            Me.Dispose()
        End If
    End Sub

    Private Sub ctrlUserCard_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Me.Select()
    End Sub

    Private Sub ctrlUserCard_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If parentContainer IsNot Nothing Then
            parentContainer.SelectedCard = Me
        End If

        Me.Invalidate()
    End Sub

    Private Sub ctrlUserCard_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Invalidate()
    End Sub

    Private Sub ctrlUserCard_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        hovered = True
        Me.Invalidate()
    End Sub

    Private Sub ctrlUserCard_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        hovered = False
        Me.Invalidate()
    End Sub

    Private Sub PrintRecord()
        lblUsername.Text = userDetails.Username & "#" & userDetails.UserID

        If Not userDetails.Active Then
            lblActive.Text = "Deactivated"
            lblActive.ForeColor = Color.FromArgb(250, 30, 30)
        Else
            lblActive.Text = "Active"
            lblActive.ForeColor = lblActive.Parent.ForeColor
        End If

        Dim strike As New Font(Me.Font, FontStyle.Strikeout)
        lblPermissionName.Text = userDetails.Permission.PermissionName
        If Not userDetails.Permission.AccessUser Then lblAccessUser.Font = strike
        If Not userDetails.Permission.AccessPermission Then lblAccessPermission.Font = strike
        If Not userDetails.Permission.AccessCustomer Then lblAccessCustomer.Font = strike
        If Not userDetails.Permission.AccessItem Then lblAccessItem.Font = strike
        If Not userDetails.Permission.AccessInventory Then lblAccessInventory.Font = strike
        If Not userDetails.Permission.AccessReservation Then lblAccessReservation.Font = strike
        If Not userDetails.Permission.AccessConsume Then lblAccessConsume.Font = strike
        If Not userDetails.Permission.AccessBorrow Then lblAccessBorrow.Font = strike
        If Not userDetails.Permission.AccessStation Then lblAccessStation.Font = strike
    End Sub

End Class
