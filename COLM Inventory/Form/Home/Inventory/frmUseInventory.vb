Imports System.Data.SqlClient

Public Class frmUseInventory

    Private itemDetails As ItemDetails
    Private customerDetails As CustomerDetails
    Private inventoryDetails As InventoryDetails
    Private cts As New Threading.CancellationTokenSource
    Private targetAction As Action

    Public Sub New(itemDetails As ItemDetails, Optional targetAction As Action = Action.None)
        If itemDetails Is Nothing Then Throw New ArgumentNullException("itemDetails")
        If targetAction = Nothing Then targetAction = Action.None
        Me.itemDetails = itemDetails
        Me.targetAction = targetAction

        InitializeComponent()

        PrintItem()
        lblCustomer.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Sub btnSelectCustomer_Click(sender As Object, e As EventArgs) Handles btnSelectCustomer.Click
        Using selectCustomer As New frmSelectCustomer()
            selectCustomer.ShowDialog()
            customerDetails = selectCustomer.SelectedCustomer
            PrintCustomer()
        End Using
    End Sub

    Private Sub btnSelectInventory_Click(sender As Object, e As EventArgs) Handles btnSelectInventory.Click
        Using selectInventory As New frmSelectInventory(itemDetails)
            selectInventory.ShowDialog()
            inventoryDetails = selectInventory.SelectedInventory
            PrintInventory()
        End Using
    End Sub

    Private Sub cmbAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAction.SelectedIndexChanged
        If cmbAction.Items.Count = 1 Then
            cmbAction.SelectedIndex = 0
        End If

        If cmbAction.Text = "Station" Then
            lblLocation.Enabled = True
            txtLocation.Enabled = True
        Else
            txtLocation.Text = ""
            lblLocation.Enabled = False
            txtLocation.Enabled = False
        End If
    End Sub

    Private Async Sub btnUse_Click(sender As Object, e As EventArgs) Handles btnUse.Click
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Adding record", Sub() cts.Cancel())
            err.Clear()
            Dim errCount As Integer = 0

            If customerDetails Is Nothing Then
                err.SetError(btnSelectCustomer, CODE_ERR)
                errCount += 1
            End If

            If inventoryDetails Is Nothing Then
                err.SetError(btnSelectInventory, CODE_ERR)
                errCount += 1
            End If

            If Not cmbAction.isValid Then
                err.SetError(cmbAction, CODE_ERR)
                errCount += 1
            End If

            If Not txtLocation.IsValid And cmbAction.Text = Action.Station.ToString Then
                err.SetError(txtLocation, CODE_ERR_TEXT)
                errCount += 1
            End If

            If errCount > 0 Then Exit Sub

            If numGood.Value + numDamaged.Value = 0 Then
                MessageBox.Show("Please specify how many quantity you would like to use.")
                Exit Sub
            End If

            Await Use()
        End Using

        lblCustomer.Select()
    End Sub

    Private Async Function Use() As Threading.Tasks.Task
        Dim query As String = ""

        If cmbAction.Text = Action.Consume.ToString Then
            query = "EXECUTE spInsertConsume @key, @CustomerID, @InventoryID, @Good, @Damaged"
        ElseIf cmbAction.Text = Action.Borrow.ToString Then
            query = "EXECUTE spInsertBorrow @key, @CustomerID, @InventoryID, @Good, @Damaged"
        ElseIf cmbAction.Text = Action.Station.ToString Then
            query = "EXECUTE spInsertStation @key, @CustomerID, @InventoryID, @Location, @Good, @Damaged"
        End If

        If query = "" Then Exit Function

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand(query, con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@CustomerID", customerDetails.CustomerID)
                    com.Parameters.AddWithValue("@InventoryID", inventoryDetails.InventoryID)
                    com.Parameters.AddWithValue("@Location", txtLocation.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@Good", numGood.Value)
                    com.Parameters.AddWithValue("@Damaged", numDamaged.Value)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Await HandleResult(reader)
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

    Private Async Function HandleResult(reader As SqlDataReader) As Threading.Tasks.Task
        Dim tableName As String = "FK_tbl" & cmbAction.Text & "_"

        Select Case reader("RES")
            Case "Not Permitted"
                MessageBox.Show(CODE_NOT_PERMITTED)
                Application.Restart()

            Case tableName & "CustomerID"
                MessageBox.Show(String.Format(CODE_NOT_EXISTS, "customer"))
                customerDetails = Nothing
                PrintCustomer()
            Case tableName & "InventoryID"
                MessageBox.Show(String.Format(CODE_NOT_EXISTS, "inventory"))
                inventoryDetails = Nothing
                PrintInventory()

            Case "CK_tblInventory_Good"
                MessageBox.Show("The inventory's quantity has been updated by a different transaction.")
                Await LoadInventory()
            Case "CK_tblInventory_Damaged"
                MessageBox.Show("The inventory's quantity has been updated by a different transaction.")
                Await LoadInventory()

            Case "ItemType"
                Select Case cmbAction.Text
                    Case Action.Consume.ToString
                        MessageBox.Show("The inventory can no longer be consumed.")
                    Case Action.Borrow.ToString
                        MessageBox.Show("The inventory can no longer be borrowed.")
                    Case Action.Station.ToString
                        MessageBox.Show("The inventory can no longer be stationed.")
                End Select

                inventoryDetails = Nothing
                PrintInventory()
            Case "Location"
                err.SetError(txtLocation, CODE_ERR_TEXT)
            Case "Good"
                err.SetError(numGood, CODE_ERR_NUM)
            Case "Damaged"
                err.SetError(numDamaged, CODE_ERR_NUM)

            Case "Failed"
                MessageBox.Show(CODE_FAILED)
                Me.Close()
            Case "Successful"
                Notification.Show(CODE_SUCCESS, Color.Green)
                MessageBox.Show("Log:" & NXT & NXT &
                                reader("LOG"))

                customerDetails = Nothing
                PrintCustomer()
                inventoryDetails = Nothing
                PrintInventory()
                cmbAction.SelectedIndex = -1
            Case Else
                MessageBox.Show(CODE_ELSE & reader("RES"))
        End Select
    End Function

    Private Async Function LoadInventory() As Threading.Tasks.Task
        Using l As New ctrlLoadingScreen(Me, "Checking inventory", Sub() cts.Cancel())
            Await inventoryDetails.LoadRecord(cts.Token)

            If inventoryDetails.IsCancelled Then
                Exit Function
            ElseIf inventoryDetails.IsDisconnected Or inventoryDetails.IsFaulted Then
                Notification.Show("Failed to load inventory details.", Color.FromArgb(230, 50, 50))
            ElseIf inventoryDetails.Exists Then
                If inventoryDetails.Good + inventoryDetails.Damaged = 0 Then
                    MessageBox.Show("The inventory doesn't have any quantity for you to use." & NXT & NXT & "Please select a different one.")
                    inventoryDetails = Nothing
                End If
            ElseIf Not inventoryDetails.Exists Then
                MessageBox.Show(String.Format(CODE_NOT_EXISTS, "inventory"))
                inventoryDetails = Nothing
            End If

            PrintInventory()
        End Using
    End Function

    Private Sub PrintItem()
        cmbAction.Items.Clear()

        lblItemIDVal.Text = itemDetails.ItemID
        lblItemNameVal.Text = itemDetails.Name
        lblItemDescriptionVal.Text = itemDetails.Description
        lblItemTypeVal.Text = itemDetails.ItemType
        lblUnitTypeVal.Text = itemDetails.UnitType

        If targetAction <> Action.None Then
            If itemDetails.ItemType = "Consumable" Then
                If ACCESS_CONSUME And targetAction = Action.Consume Then
                    cmbAction.Items.Add(Action.Consume)
                End If
            ElseIf itemDetails.ItemType = "Asset" Or itemDetails.ItemType = "Asset - Bulk" Then
                If ACCESS_BORROW And targetAction = Action.Borrow Then
                    cmbAction.Items.Add(Action.Borrow)
                ElseIf ACCESS_STATION And targetAction = Action.Station Then
                    cmbAction.Items.Add(Action.Station)
                End If
            End If
        Else
            If itemDetails.ItemType = "Consumable" Then
                If ACCESS_CONSUME Then
                    cmbAction.Items.Add(Action.Consume)
                End If
            ElseIf itemDetails.ItemType = "Asset" Or itemDetails.ItemType = "Asset - Bulk" Then
                If ACCESS_BORROW Then
                    cmbAction.Items.Add(Action.Borrow)
                End If

                If ACCESS_STATION Then
                    cmbAction.Items.Add(Action.Station)
                End If
            End If
        End If

        cmbAction_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub PrintCustomer()
        If customerDetails IsNot Nothing Then
            lblCustomerIDVal.Text = customerDetails.CustomerID
            lblCustomerNameVal.Text = customerDetails.FirstName & " " & customerDetails.MiddleName & " " & customerDetails.LastName
            lblCustomerDepartmentVal.Text = customerDetails.Department
            lblCustomerPositionVal.Text = customerDetails.Position
            lblCustomerOffenseVal.Text = customerDetails.Offense
        Else
            lblCustomerIDVal.Text = ""
            lblCustomerNameVal.Text = ""
            lblCustomerDepartmentVal.Text = ""
            lblCustomerPositionVal.Text = ""
            lblCustomerOffenseVal.Text = ""
        End If
    End Sub

    Private Sub PrintInventory()
        If inventoryDetails IsNot Nothing Then
            lblInventoryIDVal.Text = inventoryDetails.InventoryID
            lblInventoryInformationVal.Text = inventoryDetails.Information
            lblInventoryInvoiceVal.Text = "Store: " & inventoryDetails.Store & NXT & "ReceiptNo: " & inventoryDetails.ReceiptNo & NXT & "DateReceived: " & inventoryDetails.DateReceived & NXT & "CostPerUnit: " & inventoryDetails.CostPerUnit
            lblInventoryGoodVal.Text = inventoryDetails.Good
            lblInventoryDamagedVal.Text = inventoryDetails.Damaged

            numGood.Maximum = inventoryDetails.Good
            numDamaged.Maximum = inventoryDetails.Damaged
        Else
            lblInventoryIDVal.Text = ""
            lblInventoryInformationVal.Text = ""
            lblInventoryInvoiceVal.Text = ""
            lblInventoryGoodVal.Text = ""
            lblInventoryDamagedVal.Text = ""

            numGood.Maximum = 0
            numDamaged.Maximum = 0
        End If

        numGood.Value = 0
        numDamaged.Value = 0
    End Sub

    Public Enum Action
        None
        Consume
        Borrow
        Station
    End Enum

End Class
