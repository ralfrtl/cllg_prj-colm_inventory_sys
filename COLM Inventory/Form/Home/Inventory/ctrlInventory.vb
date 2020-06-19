Imports System.Data.SqlClient

Public Class ctrlInventory

    Private cts As New Threading.CancellationTokenSource

    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))

        If Not ACCESS_INVENTORY Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not DesignMode Then
            cbtnMore_CheckedChanged(Nothing, Nothing)
            btnRefresh_Search_Click(Nothing, Nothing)
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.Shift Or Keys.A) Then
            btnAdd_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.E) Then
            btnEdit_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.D) Then
            btnDelete_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = Keys.F5 Then
            btnRefresh_Search_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.S) Then
            txtSearch.TextBox.Select()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.M) Then
            cbtnMore.Checked = Not cbtnMore.Checked
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub ctrlInventory_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        cts.Cancel()
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_INVENTORY Then Exit Sub

        If TryCast(Me.ParentForm, frmViewItem) IsNot Nothing Then
            Using addInventory As New frmAddInventory(TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails)
                addInventory.ShowDialog()
                Await TryCast(Me.ParentForm, frmViewItem).LoadItem
                TryCast(Me.ParentForm, frmViewItem).SelectTab(frmViewItem.Tab.Inventory)
                btnRefresh_Search_Click(Nothing, Nothing)
            End Using
        End If
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_INVENTORY Then Exit Sub
        If dgv.CurrentRow Is Nothing Then Exit Sub
        If TryCast(Me.ParentForm, frmViewItem) Is Nothing Then Exit Sub

        Dim inventoryDetails As New InventoryDetails
        With inventoryDetails
            .ItemID = TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails.ItemID
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

        Using editInventory As New frmEditInventory(inventoryDetails)
            editInventory.ShowDialog()
            Await TryCast(Me.ParentForm, frmViewItem).LoadItem
            TryCast(Me.ParentForm, frmViewItem).SelectTab(frmViewItem.Tab.Inventory)
            btnRefresh_Search_Click(Nothing, Nothing)
        End Using
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_INVENTORY Then Exit Sub
        If dgv.CurrentRow Is Nothing Then Exit Sub
        If TryCast(Me.ParentForm, frmViewItem) Is Nothing Then Exit Sub

        Dim inventoryDetails As New InventoryDetails
        With inventoryDetails
            .ItemID = TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails.ItemID
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

        Using deleteInventory As New frmDeleteInventory(inventoryDetails)
            deleteInventory.ShowDialog()
            Await TryCast(Me.ParentForm, frmViewItem).LoadItem
            TryCast(Me.ParentForm, frmViewItem).SelectTab(frmViewItem.Tab.Inventory)
            btnRefresh_Search_Click(Nothing, Nothing)
        End Using
    End Sub

    Private Sub btnRefresh_Search_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, btnSearch.Click
        If TryCast(Me.ParentForm, frmViewItem) IsNot Nothing Then
            LoadRecordList(TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails)
        End If
    End Sub

    Private Sub ctrlSearch_TextBoxKeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.OnTextBoxKeyUp
        If e.KeyData = Keys.Enter Then
            btnRefresh_Search_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cbtnMore_CheckedChanged(sender As Object, e As EventArgs) Handles cbtnMore.CheckedChanged
        If cbtnMore.Checked Then
            pnlFilter.Enabled = True
            pnlRibbon.Size = New Size(0, pnlFilter.Bottom + 5)
            pnlFilter.Show()
        Else
            pnlFilter.Enabled = False
            pnlFilter.Hide()
            pnlRibbon.Size = New Size(0, pnlFilter.Top)
        End If
    End Sub

    Private Sub lblPreview_MouseEnter(sender As Object, e As EventArgs) Handles lblPreview.MouseEnter
        Dim find As String = IIf(cbtnMatchEveryField.Checked, "AND ", "OR ")
        tltp.SetToolTip(lblPreview, Replace(SearchFilter("<SearchKey>"), find, find & NXT))
    End Sub

    Private Async Sub LoadRecordList(itemDetails As ItemDetails)
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        If itemDetails.ItemType = "Asset" Then
            colStatus.Visible = True
            colGood.Visible = False
            colDamaged.Visible = False
            colMaintenance.Visible = False
            colReplacement.Visible = False
        Else
            colStatus.Visible = False
            colGood.Visible = True
            colDamaged.Visible = True
            colMaintenance.Visible = True
            colReplacement.Visible = True
        End If

        dgv.Rows.Clear()

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT " & IIf(numTop.Value = 0, "", "Top(" & numTop.Value & ")") & " * FROM vwInventory WHERE ItemID = @a AND (" & SearchFilter("@b") & ") AND InUse <> 'True'", con)
                    com.Parameters.AddWithValue("@a", itemDetails.ItemID)
                    com.Parameters.AddWithValue("@b", IIf(cbtnMatchWholeWord.Checked, txtSearch.Text, "%" & txtSearch.Text & "%"))
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            If itemDetails.ItemType = "Asset" Then
                                dgv.Rows.Add({reader("InventoryID"),
                                          reader("Information"),
                                          reader("Store"),
                                          reader("ReceiptNo"),
                                          reader("DateReceived"),
                                          reader("CostPerUnit"),
                                          IIf(reader("Good") = 1, "Good", IIf(reader("Damaged") = 1, "Damaged", IIf(reader("Maintenance") = 1, "Under maintenance", IIf(reader("Replacement") = 1, "For replacement", IIf(reader("Good") = 1, "Good", "?"))))),
                                          reader("Good"),
                                          reader("Damaged"),
                                          reader("Maintenance"),
                                          reader("Replacement")})
                            Else
                                dgv.Rows.Add({reader("InventoryID"),
                                          reader("Information"),
                                          reader("Store"),
                                          reader("ReceiptNo"),
                                          reader("DateReceived"),
                                          reader("CostPerUnit"),
                                          "?",
                                          reader("Good"),
                                          reader("Damaged"),
                                          reader("Maintenance"),
                                          reader("Replacement")})
                            End If
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

    Private Function SearchFilter(parameterVar As String) As String
        Dim searchOperator As String = IIf(cbtnMatchWholeWord.Checked, " = ", " LIKE ")
        Dim searchBinder As String = IIf(cbtnMatchEveryField.Checked, " AND ", " OR ")
        Dim defaultFilter As String = "InventoryID" & searchOperator & parameterVar & searchBinder &
                                      "Information" & searchOperator & parameterVar & searchBinder &
                                      "Store" & searchOperator & parameterVar & searchBinder &
                                      "ReceiptNo" & searchOperator & parameterVar & searchBinder &
                                      "DateReceived" & searchOperator & parameterVar & searchBinder &
                                      "CostPerUnit" & searchOperator & parameterVar & searchBinder &
                                      "Good" & searchOperator & parameterVar & searchBinder &
                                      "Damaged" & searchOperator & parameterVar & searchBinder &
                                      "Maintenance" & searchOperator & parameterVar & searchBinder &
                                      "Replacement" & searchOperator & parameterVar & searchBinder
        Dim filter = defaultFilter

        If cbtnFilter.Checked Then
            If Not cbtnInventoryID.Checked Then
                filter = filter.Replace("InventoryID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnInformation.Checked Then
                filter = filter.Replace("Information" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnStore.Checked Then
                filter = filter.Replace("Store" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnReceiptNo.Checked Then
                filter = filter.Replace("ReceiptNo" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDateReceived.Checked Then
                filter = filter.Replace("DateReceived" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnCostPerUnit.Checked Then
                filter = filter.Replace("CostPerUnit" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnGood.Checked Then
                filter = filter.Replace("Good" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDamaged.Checked Then
                filter = filter.Replace("Damaged" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnMaintenance.Checked Then
                filter = filter.Replace("Maintenance" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnReplacement.Checked Then
                filter = filter.Replace("Replacement" & searchOperator & parameterVar & searchBinder, "")
            End If
        End If

        If filter.Length = 0 Then
            filter = defaultFilter
        End If

        filter = filter.Remove(filter.Length - searchBinder.Length, searchBinder.Length)

        Return filter
    End Function

End Class
