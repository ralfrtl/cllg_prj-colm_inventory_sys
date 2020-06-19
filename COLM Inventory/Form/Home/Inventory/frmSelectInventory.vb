Imports System.Data.SqlClient

Public Class frmSelectInventory

    Private itemDetails As ItemDetails
    Private cts As New Threading.CancellationTokenSource

    Friend SelectedInventory As InventoryDetails

    Public Sub New(itemDetails As ItemDetails)
        InitializeComponent()

        If itemDetails Is Nothing Then Throw New ArgumentNullException("itemDetails")

        Me.itemDetails = itemDetails
        lblItemIDVal.Text = itemDetails.ItemID
        lblItemNameVal.Text = itemDetails.Name
        lblItemDescriptionVal.Text = itemDetails.Description
        lblItemTypeVal.Text = itemDetails.ItemType
        lblUnitTypeVal.Text = itemDetails.UnitType
        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))

        If Not ACCESS_INVENTORY Then
            btnAdd.Enabled = False
        End If
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        LoadRecordList()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.Shift Or Keys.A) Then
            btnAdd_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = Keys.F5 Then
            LoadRecordList()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.S) Then
            txtSearch.TextBox.Select()
            Return True
        ElseIf keyData = Keys.Enter Then
            If ActiveControl Is dgv Then
                btnContinue_Click(Nothing, Nothing)
                Return True
            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_INVENTORY Then Exit Sub

        Using addInventory As New frmAddInventory(itemDetails)
            addInventory.ShowDialog()
            LoadRecordList()
        End Using
    End Sub

    Private Sub btnRefresh_Search_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, btnSearch.Click
        LoadRecordList()
    End Sub

    Private Sub ctrlSearch_TextBoxKeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.OnTextBoxKeyUp
        If e.KeyData = Keys.Enter Then
            LoadRecordList()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If dgv.CurrentRow Is Nothing Then Exit Sub

        SelectedInventory = New InventoryDetails
        With SelectedInventory
            .ItemID = itemDetails.ItemID
            .InventoryID = dgv.Item(colInventoryID.Index, dgv.CurrentRow.Index).Value
            .Information = dgv.Item(colInformation.Index, dgv.CurrentRow.Index).Value
            .Store = dgv.Item(colStore.Index, dgv.CurrentRow.Index).Value
            .ReceiptNo = dgv.Item(colReceiptNo.Index, dgv.CurrentRow.Index).Value
            .DateReceived = dgv.Item(colDateReceived.Index, dgv.CurrentRow.Index).Value
            .CostPerUnit = dgv.Item(colCostPerUnit.Index, dgv.CurrentRow.Index).Value
            .Good = dgv.Item(colGood.Index, dgv.CurrentRow.Index).Value
            .Damaged = dgv.Item(colDamaged.Index, dgv.CurrentRow.Index).Value
            .Maintenance = dgv.Item(colMaintenance.Index, dgv.CurrentRow.Index).Value
            .Replacement = dgv.Item(colReplacement.Index, dgv.CurrentRow.Index).Value
        End With

        Me.Close()
    End Sub

    Private Async Sub LoadRecordList()
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        dgv.Rows.Clear()

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT * FROM vwInventory WHERE ItemID = @a AND (InventoryID LIKE @b OR Information LIKE @b OR Store LIKE @b OR ReceiptNo LIKE @b OR DateReceived LIKE @b OR CostPerUnit LIKE @b OR Good LIKE @b OR Damaged LIKE @b) AND (Good > 0 OR Damaged > 0) AND InUse <> 'True'", con)
                    com.Parameters.AddWithValue("@a", itemDetails.ItemID)
                    com.Parameters.AddWithValue("@b", "%" & txtSearch.Text & "%")

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            dgv.Rows.Add({reader("InventoryID"),
                            reader("Information"),
                            "Store: " & reader("Store") & NXT & "ReceiptNo: " & reader("ReceiptNo") & NXT & "DateReceived: " & reader("DateReceived") & NXT & "CostPerUnit: " & reader("CostPerUnit"),
                            reader("Store"),
                            reader("ReceiptNo"),
                            reader("DateReceived"),
                            reader("CostPerUnit"),
                            reader("Good"),
                            reader("Damaged"),
                            reader("Maintenance"),
                            reader("Replacement")})
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Exit Sub
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show("Failed to load inventory list.", Color.FromArgb(230, 50, 50))
            End If
        End Try

        dgv.Select()
    End Sub

End Class
