
Public Class ctrlPermissionCard

    Private hovered As Boolean = False
    Private parentContainer As ctrlPermission

    Friend permissionDetails As PermissionDetails

    Public Sub New(permissionDetails As PermissionDetails)
        If permissionDetails Is Nothing Then Throw New ArgumentNullException("permissionDetails")
        Me.permissionDetails = permissionDetails

        InitializeComponent()

        Me.DoubleBuffered = True
        PrintRecord()

        For Each control As Control In Me.Controls
            AddHandler control.MouseDown, AddressOf ctrlPermissionCard_MouseDown
            AddHandler control.MouseEnter, AddressOf ctrlPermissionCard_MouseEnter
            AddHandler control.MouseLeave, AddressOf ctrlPermissionCard_MouseLeave
        Next
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        parentContainer = TryCast(Me.Parent.Parent, ctrlPermission)
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

    Private Sub ctrlPermissionCard_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Me.Select()
    End Sub

    Private Sub ctrlPermissionCard_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If parentContainer IsNot Nothing Then
            parentContainer.SelectedCard = Me
        End If

        Me.Invalidate()
    End Sub

    Private Sub ctrlPermissionCard_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Invalidate()
    End Sub

    Private Sub ctrlPermissionCard_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        hovered = True
        Me.Invalidate()
    End Sub

    Private Sub ctrlPermissionCard_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        hovered = False
        Me.Invalidate()
    End Sub

    Private Sub PrintRecord()
        Dim strike As New Font(Me.Font, FontStyle.Strikeout)
        lblPermissionName.Text = permissionDetails.PermissionName
        If Not permissionDetails.AccessUser Then lblAccessUser.Font = strike
        If Not permissionDetails.AccessPermission Then lblAccessPermission.Font = strike
        If Not permissionDetails.AccessCustomer Then lblAccessCustomer.Font = strike
        If Not permissionDetails.AccessItem Then lblAccessItem.Font = strike
        If Not permissionDetails.AccessInventory Then lblAccessInventory.Font = strike
        If Not permissionDetails.AccessReservation Then lblAccessReservation.Font = strike
        If Not permissionDetails.AccessConsume Then lblAccessConsume.Font = strike
        If Not permissionDetails.AccessBorrow Then lblAccessBorrow.Font = strike
        If Not permissionDetails.AccessStation Then lblAccessStation.Font = strike
    End Sub

End Class
