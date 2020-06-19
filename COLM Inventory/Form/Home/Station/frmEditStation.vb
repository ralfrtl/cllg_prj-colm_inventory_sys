Imports System.Data.SqlClient

Public Class frmEditStation

    Private stationDetails As StationDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(stationDetails As StationDetails)
        If stationDetails Is Nothing Then Throw New ArgumentNullException("stationDetails")
        Me.stationDetails = stationDetails

        InitializeComponent()

        PrintCustomer()
        PrintInventory()
        txtStationID.Text = stationDetails.StationID
        txtLocation.Text = stationDetails.Location
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
        Dim diff As Integer = numGood.Value - stationDetails.Good

        lblGoodDiff.Text = IIf(diff > 0, "+", "") & IIf(diff <> 0, diff, "")
    End Sub

    Private Sub numDamaged_ValueChanged(sender As Object, e As EventArgs) Handles numDamaged.ValueChanged
        Dim diff As Integer = numDamaged.Value - stationDetails.Damaged

        lblDamagedDiff.Text = IIf(diff > 0, "+", "") & IIf(diff <> 0, diff, "")
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_STATION Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()

            If Not txtLocation.IsValid Then
                err.SetError(txtLocation, CODE_ERR_TEXT)
                Exit Sub
            End If

            If stationDetails.Good = numGood.Value And stationDetails.Damaged = numDamaged.Value And stationDetails.Location = txtLocation.Text Then
                MessageBox.Show(CODE_SAME)
                Exit Sub
            End If

            If stationDetails.Customer.Offense > 0 Then
                If MessageBox.Show("The customer that you selected has unsettled offense(s)." & NXT & NXT & "Do you still want to proceed?") = DialogResult.OK Then
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
                Using com As New SqlCommand("EXECUTE spUpdateStation @Key, @StationID, @CustomerID, @InventoryID, @Location, @Good, @Damaged", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@StationID", stationDetails.StationID)
                    com.Parameters.AddWithValue("@CustomerID", stationDetails.Customer.CustomerID)
                    com.Parameters.AddWithValue("@InventoryID", stationDetails.Inventory.InventoryID)
                    com.Parameters.AddWithValue("@Location", txtLocation.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@Good", numGood.Value)
                    com.Parameters.AddWithValue("@Damaged", numDamaged.Value)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblStation_CustomerID"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "customer that is associated with this record"))
                                    Me.Close()
                                Case "FK_tblStation_InventoryID"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "inventory that is associated with this record"))
                                    Me.Close()

                                Case "CK_tblInventory_Good"
                                    MessageBox.Show("The inventory's quantity has been updated by a different transaction.")
                                    Await LoadRecord()
                                Case "CK_tblInventory_Damaged"
                                    MessageBox.Show("The inventory's quantity has been updated by a different transaction.")
                                    Await LoadRecord()

                                Case "ItemType"
                                    MessageBox.Show("The inventory can no longer be stationed.")
                                    Me.Close()
                                Case "Location"
                                    err.SetError(txtLocation, CODE_ERR_TEXT)
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
            Await stationDetails.LoadRecord(cts.Token)

            If stationDetails.IsCancelled Then
                Exit Function
            ElseIf stationDetails.IsDisconnected Or stationDetails.IsFaulted Then
                Notification.Show("Failed to load stationed inventory details.", Color.FromArgb(230, 50, 50))
            ElseIf stationDetails.Exists Then
                If CType(lblInventoryGoodVal.Text, Integer) + CType(lblInventoryDamagedVal.Text, Integer) > 0 Then
                    If stationDetails.Inventory.Good + stationDetails.Inventory.Damaged = 0 Then
                        MessageBox.Show("Warning!" & NXT & NXT & "The inventory doesn't have any quantity for you to use.")
                    End If
                End If
            ElseIf Not stationDetails.Exists Then
                MessageBox.Show(String.Format(CODE_NOT_EXISTS, "record"))
                Me.Close()
            End If

            PrintCustomer()
            PrintInventory()
            txtLocation.Text = stationDetails.Location
        End Using
    End Function

    Private Sub PrintCustomer()
        lblCustomerIDVal.Text = stationDetails.Customer.CustomerID
        lblCustomerNameVal.Text = stationDetails.Customer.FirstName & " " & stationDetails.Customer.MiddleName & " " & stationDetails.Customer.LastName
        lblCustomerDepartmentVal.Text = stationDetails.Customer.Department
        lblCustomerPositionVal.Text = stationDetails.Customer.Position
        lblCustomerOffenseVal.Text = stationDetails.Customer.Offense
    End Sub

    Private Sub PrintInventory()
        lblInventoryIDVal.Text = stationDetails.Inventory.InventoryID
        lblInventoryInformationVal.Text = stationDetails.Inventory.Information
        lblInventoryInvoiceVal.Text = "Store: " & stationDetails.Inventory.Store & NXT & "ReceiptNo: " & stationDetails.Inventory.ReceiptNo & NXT & "DateReceived: " & stationDetails.Inventory.DateReceived & NXT & "CostPerUnit: " & stationDetails.Inventory.CostPerUnit
        lblInventoryGoodVal.Text = stationDetails.Inventory.Good
        lblInventoryDamagedVal.Text = stationDetails.Inventory.Damaged

        numGood.Maximum = stationDetails.Inventory.Good + stationDetails.Good
        numDamaged.Maximum = stationDetails.Inventory.Damaged + stationDetails.Damaged

        numGood.Value = stationDetails.Good
        numDamaged.Value = stationDetails.Damaged

        numGood_ValueChanged(Nothing, Nothing)
        numDamaged_ValueChanged(Nothing, Nothing)
    End Sub

End Class
