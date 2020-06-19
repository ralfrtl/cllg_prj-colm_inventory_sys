Public Class ctrlCustomerCard

    Private hovered As Boolean = False
    Private parentContainer As ctrlCustomer
    Private WithEvents frmView As frmViewCustomer

    Friend customerDetails As CustomerDetails

    Public Sub New(customerDetails As CustomerDetails)
        If customerDetails Is Nothing Then Throw New ArgumentNullException("customerDetails")
        Me.customerDetails = customerDetails

        InitializeComponent()

        Me.DoubleBuffered = True
        PrintRecord()

        For Each control As Control In Me.Controls
            AddHandler control.MouseDown, AddressOf ctrlCustomerCard_MouseDown
            AddHandler control.DoubleClick, AddressOf ctrlCustomerCard_DoubleClick
            AddHandler control.MouseEnter, AddressOf ctrlCustomerCard_MouseEnter
            AddHandler control.MouseLeave, AddressOf ctrlCustomerCard_MouseLeave
        Next
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        parentContainer = TryCast(Me.Parent.Parent, ctrlCustomer)
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
                Else
                    e.Graphics.DrawRectangle(New Pen(Color.Green, 1), New Rectangle(10, 10, Me.Width - 21, Me.Height - 21))
                End If
            End If
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Space Or keyData = Keys.Enter Then
            ctrlCustomerCard_DoubleClick(Nothing, Nothing)
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

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

    Private Sub ctrlCustomerCard_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Me.Select()
    End Sub

    Private Sub ctrlCustomerCard_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        Me.Select()

        If frmView Is Nothing Then
            frmView = New frmViewCustomer(Me)
            frmView.Show()
        Else
            frmView.Select()
        End If
    End Sub

    Private Sub ctrlCustomerCard_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If parentContainer IsNot Nothing Then
            parentContainer.SelectedCard = Me
        End If

        Me.Invalidate()
    End Sub

    Private Sub ctrlCustomerCard_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Invalidate()
    End Sub

    Private Sub ctrlCustomerCard_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        hovered = True
        Me.Invalidate()
    End Sub

    Private Sub ctrlCustomerCard_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        hovered = False
        Me.Invalidate()
    End Sub

    Private Sub viewItem_Disposed(sender As Object, e As EventArgs) Handles frmView.Disposed
        frmView = Nothing
    End Sub

    Friend Sub PrintRecord()
        lblFullName.Text = customerDetails.FirstName & " " & customerDetails.MiddleName & " " & customerDetails.LastName
        lblCustomerID.Text = "ID : " & customerDetails.CustomerID
        lblPositionVal.Text = customerDetails.Position
        lblDepartmentVal.Text = customerDetails.Department
        lblOffenseVal.Text = customerDetails.Offense
    End Sub

End Class
