Imports System.Data.SqlClient

Public Class frmEditInventory

    Private inventoryDetails As InventoryDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(inventoryDetails As InventoryDetails)
        If inventoryDetails Is Nothing Then Throw New ArgumentNullException("inventoryDetails")
        Me.inventoryDetails = inventoryDetails

        InitializeComponent()

        txtItemID.Text = inventoryDetails.ItemID
        txtInventoryID.Text = inventoryDetails.InventoryID
        txtInformation.Text = inventoryDetails.Information
        txtStore.Text = inventoryDetails.Store
        txtReceiptNo.Text = inventoryDetails.ReceiptNo
        dtpDateReceived.Value = inventoryDetails.DateReceived
        numCostPerUnit.Value = inventoryDetails.CostPerUnit
        numGood.Value = inventoryDetails.Good
        numDamaged.Value = inventoryDetails.Damaged
        numMaintenance.Value = inventoryDetails.Maintenance
        numReplacement.Value = inventoryDetails.Replacement
        lblInformation.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_INVENTORY Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()
            Dim errCount As Integer = 0

            If Not txtInformation.IsValid Then
                err.SetError(txtInformation, CODE_ERR_TEXT)
                errCount += 1
            End If

            If Not txtStore.IsValid Then
                err.SetError(txtStore, CODE_ERR_TEXT)
                errCount += 1
            End If

            If Not txtReceiptNo.IsValid Then
                err.SetError(txtReceiptNo, CODE_ERR_TEXT)
                errCount += 1
            End If

            If errCount > 0 Then Exit Sub

            If txtInformation.Text <> inventoryDetails.Information Or txtStore.Text <> inventoryDetails.Store Or txtReceiptNo.Text <> inventoryDetails.ReceiptNo Or dtpDateReceived.Value <> inventoryDetails.DateReceived Or numCostPerUnit.Value <> inventoryDetails.CostPerUnit Or numGood.Value <> inventoryDetails.Good Or numDamaged.Value <> inventoryDetails.Damaged Or numMaintenance.Value <> inventoryDetails.Maintenance Or numReplacement.Value <> inventoryDetails.Replacement Then
                Await EditInventory()
            Else
                MessageBox.Show(CODE_SAME)
            End If
        End Using

        lblInformation.Select()
    End Sub

    Private Async Function EditInventory() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spUpdateInventory @key, @ItemID, @InventoryID, @Information, @Store, @ReceiptNo, @DateReceived, @CostPerUnit, @Good, @Damaged, @Maintenance, @Replacement", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@ItemID", inventoryDetails.ItemID)
                    com.Parameters.AddWithValue("@InventoryID", inventoryDetails.InventoryID)
                    com.Parameters.AddWithValue("@Information", txtInformation.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@Store", txtStore.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@DateReceived", dtpDateReceived.Value)
                    com.Parameters.AddWithValue("@CostPerUnit", numCostPerUnit.Value)
                    com.Parameters.AddWithValue("@Good", numGood.Value)
                    com.Parameters.AddWithValue("@Damaged", numDamaged.Value)
                    com.Parameters.AddWithValue("@Maintenance", numMaintenance.Value)
                    com.Parameters.AddWithValue("@Replacement", numReplacement.Value)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblInventory_ItemID"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "item that is associated with this record"))
                                    Me.Close()

                                Case "Information"
                                    err.SetError(txtInformation, CODE_ERR_TEXT)
                                Case "Store"
                                    err.SetError(txtStore, CODE_ERR_TEXT)
                                Case "ReceiptNo"
                                    err.SetError(txtReceiptNo, CODE_ERR_TEXT)
                                Case "Good"
                                    err.SetError(numGood, CODE_ERR_NUM)
                                Case "Damaged"
                                    err.SetError(numDamaged, CODE_ERR_NUM)
                                Case "Maintenance"
                                    err.SetError(numMaintenance, CODE_ERR_NUM)
                                Case "Replacement"
                                    err.SetError(numReplacement, CODE_ERR_NUM)
                                Case "MultipleAssetQty"
                                    If numGood.Value + numDamaged.Value + numMaintenance.Value + numReplacement.Value <= 1 Then
                                        MessageBox.Show("The quantity cannot be modified if the asset is in-use.")
                                    Else
                                        MessageBox.Show("Items under the type of ASSET can only hold 1 quantity per inventory.")
                                    End If

                                Case "Exists"
                                    MessageBox.Show(CODE_EXISTS)
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

End Class
