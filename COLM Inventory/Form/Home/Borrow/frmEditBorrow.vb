Imports System.Data.SqlClient

Public Class frmEditBorrow

    Private borrowDetails As BorrowDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(borrowDetails As BorrowDetails)
        If borrowDetails Is Nothing Then Throw New ArgumentNullException("borrowDetails")
        Me.borrowDetails = borrowDetails

        InitializeComponent()

        PrintCustomer()
        PrintInventory()
        txtBorrowID.Text = borrowDetails.BorrowID
        lblGood.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Async Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Await LoadRecord()
    End Sub

    Private Sub numGood_ValueChanged(sender As Object, e As EventArgs) Handles numGood.ValueChanged
        Dim diff As Integer = numGood.Value - borrowDetails.Good

        lblGoodDiff.Text = IIf(diff > 0, "+", "") & IIf(diff <> 0, diff, "")
    End Sub

    Private Sub numDamaged_ValueChanged(sender As Object, e As EventArgs) Handles numDamaged.ValueChanged
        Dim diff As Integer = numDamaged.Value - borrowDetails.Damaged

        lblDamagedDiff.Text = IIf(diff > 0, "+", "") & IIf(diff <> 0, diff, "")
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_BORROW Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()

            If borrowDetails.Good = numGood.Value And borrowDetails.Damaged = numDamaged.Value Then
                MessageBox.Show(CODE_SAME)
                Exit Sub
            End If

            If borrowDetails.Customer.Offense > 0 Then
                If MessageBox.Show("The customer that you have selected has unsettled offense(s)." & NXT & NXT & "Do you still want to proceed?") = DialogResult.OK Then
                    Await EditRecord()
                End If
            Else
                Await EditRecord()
            End If
        End Using

        lblGood.Select()
    End Sub

    Private Async Function EditRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spUpdateBorrow @Key, @BorrowID, @CustomerID, @InventoryID, @Good, @Damaged", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@BorrowID", borrowDetails.BorrowID)
                    com.Parameters.AddWithValue("@CustomerID", borrowDetails.Customer.CustomerID)
                    com.Parameters.AddWithValue("@InventoryID", borrowDetails.Inventory.InventoryID)
                    com.Parameters.AddWithValue("@Good", numGood.Value)
                    com.Parameters.AddWithValue("@Damaged", numDamaged.Value)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblBorrow_CustomerID"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "customer that is associated with this record"))
                                    Me.Close()
                                Case "FK_tblBorrow_InventoryID"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "inventory that is associated with this record"))
                                    Me.Close()

                                Case "CK_tblInventory_Good"
                                    MessageBox.Show("The inventory's quantity has been modified by a different transaction.")
                                    Await LoadRecord()
                                Case "CK_tblInventory_Damaged"
                                    MessageBox.Show("The inventory's quantity has been modified by a different transaction.")
                                    Await LoadRecord()

                                Case "ItemType"
                                    MessageBox.Show("The inventory can no longer be borrowed.")
                                    Me.Close()
                                Case "Good"
                                    err.SetError(numGood, CODE_ERR_NUM)
                                Case "Damaged"
                                    err.SetError(numDamaged, CODE_ERR_NUM)

                                Case "Not Exists"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "record"))
                                    Me.Close()
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    MessageBox.Show("Log:" & NXT & NXT &
                                                    reader("LOG"))
                                    Me.Close()
                                Case Else
                                    MessageBox.Show(CODE_ELSE & reader("RES"))
                            End Select
                        Else
                            MessageBox.Show(CODE_FAILED)
                            Me.Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Exit Function
        Catch ex As InvalidOperationException
            Notification.Show(ERR_CON, Color.FromArgb(230, 50, 50))
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show(ERR_ELSE, Color.FromArgb(230, 50, 50))
            End If
        End Try
    End Function

    Private Async Function LoadRecord() As Threading.Tasks.Task
        Using l As New ctrlLoadingScreen(Me, "Checking record", Sub() cts.Cancel())
            Await borrowDetails.LoadRecord(cts.Token)

            If borrowDetails.IsCancelled Then
                Exit Function
            ElseIf borrowDetails.IsDisconnected Or borrowDetails.IsFaulted Then
                Notification.Show("Failed to load borrowed inventory details.", Color.FromArgb(230, 50, 50))
            ElseIf borrowDetails.Exists Then
                If CType(lblInventoryGoodVal.Text, Integer) + CType(lblInventoryDamagedVal.Text, Integer) > 0 Then
                    If borrowDetails.Inventory.Good + borrowDetails.Inventory.Damaged = 0 Then
                        MessageBox.Show("Warning!" & NXT & NXT & "The inventory doesn't have any quantity for you to use.")
                    End If
                End If
            ElseIf Not borrowDetails.Exists Then
                MessageBox.Show(String.Format(CODE_NOT_EXISTS, "record"))
                Me.Close()
            End If

            PrintCustomer()
            PrintInventory()
        End Using
    End Function

    Private Sub PrintCustomer()
        lblCustomerIDVal.Text = borrowDetails.Customer.CustomerID
        lblCustomerNameVal.Text = borrowDetails.Customer.FirstName & " " & borrowDetails.Customer.MiddleName & " " & borrowDetails.Customer.LastName
        lblCustomerDepartmentVal.Text = borrowDetails.Customer.Department
        lblCustomerPositionVal.Text = borrowDetails.Customer.Position
        lblCustomerOffenseVal.Text = borrowDetails.Customer.Offense
    End Sub

    Private Sub PrintInventory()
        lblInventoryIDVal.Text = borrowDetails.Inventory.InventoryID
        lblInventoryInformationVal.Text = borrowDetails.Inventory.Information
        lblInventoryInvoiceVal.Text = "Store: " & borrowDetails.Inventory.Store & NXT & "ReceiptNo: " & borrowDetails.Inventory.ReceiptNo & NXT & "DateReceived: " & borrowDetails.Inventory.DateReceived & NXT & "CostPerUnit: " & borrowDetails.Inventory.CostPerUnit
        lblInventoryGoodVal.Text = borrowDetails.Inventory.Good
        lblInventoryDamagedVal.Text = borrowDetails.Inventory.Damaged

        numGood.Maximum = borrowDetails.Inventory.Good + borrowDetails.Good
        numDamaged.Maximum = borrowDetails.Inventory.Damaged + borrowDetails.Damaged

        numGood.Value = borrowDetails.Good
        numDamaged.Value = borrowDetails.Damaged

        numGood_ValueChanged(Nothing, Nothing)
        numDamaged_ValueChanged(Nothing, Nothing)
    End Sub

End Class
