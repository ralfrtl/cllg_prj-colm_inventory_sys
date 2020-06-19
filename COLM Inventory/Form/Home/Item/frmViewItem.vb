
Public Class frmViewItem

    Private cts As New Threading.CancellationTokenSource

    Friend WithEvents parentCard As ctrlItemCard

    Public Sub New(parentCard As ctrlItemCard)
        If parentCard Is Nothing Then Throw New ArgumentNullException("parentCard")
        Me.parentCard = parentCard

        InitializeComponent()

        If Not ACCESS_ITEM Then
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Protected Overrides Async Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Await LoadItem()
        ctrlReservationContent.SelectList()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.Shift Or Keys.Alt Or Keys.E) Then
            btnEdit_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.Alt Or Keys.D) Then
            btnDelete_Click(Nothing, Nothing)
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub parentCard_Disposed(sender As Object, e As EventArgs) Handles parentCard.Disposed
        Me.Dispose()
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_ITEM Then Exit Sub

        Using editItem As New frmEditItem(parentCard.itemDetails)
            editItem.ShowDialog()
            Dim currentTab As TabPage = tbContainer.SelectedTab
            Await LoadItem()
            tbContainer.SelectedTab = currentTab
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_ITEM Then Exit Sub

        Using deleteItem As New frmDeleteItem(parentCard.itemDetails)
            If deleteItem.ShowDialog = DialogResult.OK Then
                parentCard.Dispose()
            End If
        End Using
    End Sub

    Friend Async Function LoadItem() As Threading.Tasks.Task
        Using l As New ctrlLoadingScreen(Me, "Loading", Sub()
                                                            Me.Hide()
                                                            Me.Close()
                                                        End Sub)
            If Not Await LoadRecord() Then Exit Function

            PrintRecord()
            parentCard.PrintRecord()
            tbContainer.TabPages.Clear()

            tbContainer.TabPages.Add(tbpgReservation)
            tbContainer.TabPages.Add(tbpgInventory)

            If parentCard.itemDetails.ItemType = "Consumable" Then
                tbContainer.TabPages.Add(tbpgConsume)
            ElseIf parentCard.itemDetails.ItemType = "Asset" Or parentCard.itemDetails.ItemType = "Asset - Bulk" Then
                tbContainer.TabPages.Add(tbpgBorrow)
                tbContainer.TabPages.Add(tbpgStation)
            End If
        End Using
    End Function

    Private Async Function LoadRecord() As Threading.Tasks.Task(Of Boolean)
        Await parentCard.itemDetails.LoadRecord(cts.Token)

        If parentCard.itemDetails.IsCancelled Then
            Return False
        ElseIf parentCard.itemDetails.IsDisconnected Or parentCard.itemDetails.IsFaulted Then
            Notification.Show("Failed to load item details.", Color.FromArgb(230, 50, 50))
        ElseIf Not parentCard.itemDetails.Exists Then
            Notification.Show(String.Format(CODE_NOT_EXISTS, "item#" & parentCard.itemDetails.ItemID), Color.FromArgb(230, 50, 50))
            parentCard.Dispose()
            Return False
        End If

        Return True
    End Function

    Private Sub PrintRecord()
        With parentCard.itemDetails
            lblName.Text = .Name
            lblItemID.Text = "ID : " & .ItemID
            lblDescription.Text = .Description
            lblItemType.Text = "Item type : " & .ItemType
            lblUnitType.Text = "Unit type : " & .UnitType
            lblLowThreshold.Text = .LowThreshold
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

    Friend Sub SelectTab(tabOf As Tab)
        Select Case tabOf
            Case Tab.Reservation
                tbContainer.SelectedTab = tbpgReservation
            Case Tab.Inventory
                tbContainer.SelectedTab = tbpgInventory
            Case Tab.Consume
                If parentCard.itemDetails.ItemType = "Consumable" Then tbContainer.SelectedTab = tbpgConsume
            Case Tab.Borrow
                If parentCard.itemDetails.ItemType = "Asset" Or parentCard.itemDetails.ItemType = "Asset - Bulk" Then tbContainer.SelectedTab = tbpgBorrow
            Case Tab.Station
                If parentCard.itemDetails.ItemType = "Asset" Or parentCard.itemDetails.ItemType = "Asset - Bulk" Then tbContainer.SelectedTab = tbpgStation
        End Select
    End Sub

    Public Enum Tab
        Reservation
        Inventory
        Consume
        Borrow
        Station
    End Enum

End Class
