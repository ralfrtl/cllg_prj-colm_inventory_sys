
Public Class ctrlItemCard

    Private hovered As Boolean = False
    Private parentContainer As ctrlItem
    Private WithEvents frmView As frmViewItem

    Friend itemDetails As ItemDetails

    Public Sub New(itemDetails As ItemDetails)
        If itemDetails Is Nothing Then Throw New ArgumentNullException("itemDetails")
        Me.itemDetails = itemDetails

        InitializeComponent()

        Me.DoubleBuffered = True
        PrintRecord()

        For Each control As Control In Me.Controls
            AddHandler control.MouseDown, AddressOf ctrlItemCard_MouseDown
            AddHandler control.DoubleClick, AddressOf ctrlItemCard_DoubleClick
            AddHandler control.MouseEnter, AddressOf ctrlItemCard_MouseEnter
            AddHandler control.MouseLeave, AddressOf ctrlItemCard_MouseLeave
        Next
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        parentContainer = TryCast(Me.Parent.Parent, ctrlItem)
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
            ctrlItemCard_DoubleClick(Nothing, Nothing)
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

    Private Sub ctrlItemCard_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Me.Select()
    End Sub

    Private Sub ctrlItemCard_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        Me.Select()

        If frmView Is Nothing Then
            frmView = New frmViewItem(Me)
            frmView.Show()
        Else
            frmView.Select()
        End If
    End Sub

    Private Sub ctrlItemCard_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If parentContainer IsNot Nothing Then
            parentContainer.SelectedCard = Me
        End If

        Me.Invalidate()
    End Sub

    Private Sub ctrlItemCard_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Invalidate()
    End Sub

    Private Sub ctrlItemCard_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        hovered = True
        Me.Invalidate()
    End Sub

    Private Sub ctrlItemCard_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        hovered = False
        Me.Invalidate()
    End Sub

    Private Sub viewItem_Disposed(sender As Object, e As EventArgs) Handles frmView.Disposed
        frmView = Nothing
    End Sub

    Friend Sub PrintRecord()
        With itemDetails
            lblName.Text = .Name
            lblItemID.Text = "ID : " & .ItemID
            lblDescription.Text = .Description
            lblItemType.Text = "Item type : " & .ItemType
            lblUnitType.Text = "Unit type : " & .UnitType
            lblLowThreshold.Text = "Low threshold : " & .LowThreshold
            lblTotal.Text = "Total : " & .Total
            lblAvailable.Text = "Available : " & .Available
            lblReserved.Text = "Reserved : " & .Reserved
            lblBorrowed.Text = "Borrowed : " & IIf(.ItemType = "Asset" Or .ItemType = "Asset - Bulk", .Borrowed, "N/A")
            lblStationed.Text = "Stationed : " & IIf(.ItemType = "Asset" Or .ItemType = "Asset - Bulk", .Stationed, "N/A")
            lblGood.Text = "Good : " & .Good
            lblDamaged.Text = "Damaged : " & .Damaged
            lblMaintenance.Text = "Under maintenance : " & IIf(.ItemType = "Asset" Or .ItemType = "Asset - Bulk", .Maintenance, "N/A")
            lblReplacement.Text = "For replacement : " & .Replacement

            If .LowThreshold = 0 Then
                lblLowThresholdNotifier.BackColor = Color.FromArgb(225, 225, 225)
            ElseIf .Available = 0 Then
                lblLowThresholdNotifier.BackColor = Color.FromArgb(230, 50, 50)
            ElseIf .Available <= .LowThreshold Then
                lblLowThresholdNotifier.BackColor = Color.FromArgb(250, 230, 50)
            Else
                lblLowThresholdNotifier.BackColor = Color.Green
            End If
        End With
    End Sub

End Class
