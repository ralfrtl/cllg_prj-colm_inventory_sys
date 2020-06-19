Imports System.Data.SqlClient

Public Class ctrlConsume

    Private cts As New Threading.CancellationTokenSource

    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))

        If Not ACCESS_CONSUME Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
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

    Private Sub ctrlConsume_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        cts.Cancel()
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_CONSUME Then Exit Sub

        If TryCast(Me.ParentForm, frmViewItem) IsNot Nothing Then
            Using useInventory As New frmUseInventory(TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails, frmUseInventory.Action.Consume)
                useInventory.ShowDialog()
                Await TryCast(Me.ParentForm, frmViewItem).LoadItem
                TryCast(Me.ParentForm, frmViewItem).SelectTab(frmViewItem.Tab.Consume)
                btnRefresh_Search_Click(Nothing, Nothing)
            End Using
        End If
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_CONSUME Then Exit Sub
        If dgv.CurrentRow Is Nothing Then Exit Sub
        If TryCast(Me.ParentForm, frmViewItem) Is Nothing Then Exit Sub

        Dim consumeDetails As New ConsumeDetails
        With consumeDetails
            .ConsumeID = dgv.Item(colConsumeID.Index, dgv.CurrentRow.Index).Value
            .Customer.CustomerID = dgv.Item(colCustomerID.Index, dgv.CurrentRow.Index).Value
            .Customer.FirstName = dgv.Item(colFirstName.Index, dgv.CurrentRow.Index).Value
            .Customer.MiddleName = dgv.Item(colMiddleName.Index, dgv.CurrentRow.Index).Value
            .Customer.LastName = dgv.Item(colLastName.Index, dgv.CurrentRow.Index).Value
            .Customer.Position = dgv.Item(colPosition.Index, dgv.CurrentRow.Index).Value
            .Customer.Department = dgv.Item(colDepartment.Index, dgv.CurrentRow.Index).Value
            .Customer.Offense = dgv.Item(colOffense.Index, dgv.CurrentRow.Index).Value
            .Inventory.ItemID = TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails.ItemID
            .Inventory.InventoryID = dgv.Item(colInventoryID.Index, dgv.CurrentRow.Index).Value
            .Inventory.Information = dgv.Item(colInformation.Index, dgv.CurrentRow.Index).Value
            .Inventory.Store = dgv.Item(colStore.Index, dgv.CurrentRow.Index).Value
            .Inventory.ReceiptNo = dgv.Item(colReceiptNo.Index, dgv.CurrentRow.Index).Value
            .Inventory.DateReceived = CType(dgv.Item(colDateReceived.Index, dgv.CurrentRow.Index).Value, DateTime)
            .Inventory.CostPerUnit = dgv.Item(colCostPerUnit.Index, dgv.CurrentRow.Index).Value
            .Inventory.Good = dgv.Item(colGood.Index, dgv.CurrentRow.Index).Value
            .Inventory.Damaged = dgv.Item(colDamaged.Index, dgv.CurrentRow.Index).Value
            .Good = dgv.Item(colConsumedGood.Index, dgv.CurrentRow.Index).Value
            .Damaged = dgv.Item(colConsumedDamaged.Index, dgv.CurrentRow.Index).Value
        End With

        Using editConsume As New frmEditConsume(consumeDetails)
            editConsume.ShowDialog()
            Await TryCast(Me.ParentForm, frmViewItem).LoadItem
            TryCast(Me.ParentForm, frmViewItem).SelectTab(frmViewItem.Tab.Consume)
            btnRefresh_Search_Click(Nothing, Nothing)
        End Using
    End Sub

    Private Sub btnRefresh_Search_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, btnSearch.Click
        If TryCast(Me.ParentForm, frmViewItem) IsNot Nothing Then
            LoadRecordList(TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails.ItemID)
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
        Else
            pnlFilter.Enabled = False
            pnlRibbon.Size = New Size(0, pnlFilter.Top)
        End If
    End Sub

    Private Sub lblPreview_MouseEnter(sender As Object, e As EventArgs) Handles lblPreview.MouseEnter
        Dim find As String = IIf(cbtnMatchEveryField.Checked, "AND ", "OR ")
        tltp.SetToolTip(lblPreview, Replace(SearchFilter("<SearchKey>"), find, find & NXT))
    End Sub

    Private Async Sub LoadRecordList(itemID As Integer)
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        dgv.Rows.Clear()

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT " & IIf(numTop.Value = 0, "", "Top(" & numTop.Value & ")") & " * FROM vwConsume WHERE ItemID = @a AND (" & SearchFilter("@b") & ")", con)
                    com.Parameters.AddWithValue("@a", itemID)
                    com.Parameters.AddWithValue("@b", IIf(cbtnMatchWholeWord.Checked, txtSearch.Text, "%" & txtSearch.Text & "%"))
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            dgv.Rows.Add({reader("ConsumeID"),
                                          "ID: " & reader("CustomerID") & NXT & "Name: " & reader("FirstName") & " " & reader("MiddleName") & " " & reader("LastName") & NXT & "Position: " & reader("Position") & NXT & "Department: " & reader("Department") & NXT & "No. of offense(s): " & reader("Offense"),
                                          reader("CustomerID"),
                                          reader("FirstName"),
                                          reader("MiddleName"),
                                          reader("LastName"),
                                          reader("Position"),
                                          reader("Department"),
                                          reader("Offense"),
                                          "ID: " & reader("InventoryID") & NXT & "Information: " & reader("Information"),
                                          reader("InventoryID"),
                                          reader("Information"),
                                          "Store: " & reader("Store") & NXT & "ReceiptNo: " & reader("ReceiptNo") & NXT & "DateReceived: " & reader("DateReceived") & NXT & "CostPerUnit: " & reader("CostPerUnit"),
                                          reader("Store"),
                                          reader("ReceiptNo"),
                                          reader("DateReceived"),
                                          reader("CostPerUnit"),
                                          reader("Good"),
                                          reader("Damaged"),
                                          reader("ConsumedGood"),
                                          reader("ConsumedDamaged")})
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Exit Sub
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show("Failed to load consumed inventory list.", Color.FromArgb(230, 50, 50))
            End If
        End Try

        dgv.Select()
    End Sub

    Private Function SearchFilter(parameterVar As String) As String
        Dim searchOperator As String = IIf(cbtnMatchWholeWord.Checked, " = ", " LIKE ")
        Dim searchBinder As String = IIf(cbtnMatchEveryField.Checked, " AND ", " OR ")
        Dim defaultFilter As String = "ConsumeID" & searchOperator & parameterVar & searchBinder &
                                      "CustomerID" & searchOperator & parameterVar & searchBinder &
                                      "FirstName" & searchOperator & parameterVar & searchBinder &
                                      "MiddleName" & searchOperator & parameterVar & searchBinder &
                                      "LastName" & searchOperator & parameterVar & searchBinder &
                                      "Position" & searchOperator & parameterVar & searchBinder &
                                      "Department" & searchOperator & parameterVar & searchBinder &
                                      "Offense" & searchOperator & parameterVar & searchBinder &
                                      "InventoryID" & searchOperator & parameterVar & searchBinder &
                                      "Information" & searchOperator & parameterVar & searchBinder &
                                      "Store" & searchOperator & parameterVar & searchBinder &
                                      "ReceiptNo" & searchOperator & parameterVar & searchBinder &
                                      "DateReceived" & searchOperator & parameterVar & searchBinder &
                                      "CostPerUnit" & searchOperator & parameterVar & searchBinder &
                                      "ConsumedGood" & searchOperator & parameterVar & searchBinder &
                                      "ConsumedDamaged" & searchOperator & parameterVar & searchBinder
        Dim filter = defaultFilter

        If cbtnFilter.Checked Then
            If Not cbtnCustomerID.Checked Then
                filter = filter.Replace("CustomerID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnFirstName.Checked Then
                filter = filter.Replace("FirstName" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnMiddleName.Checked Then
                filter = filter.Replace("MiddleName" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnLastName.Checked Then
                filter = filter.Replace("LastName" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnPosition.Checked Then
                filter = filter.Replace("Position" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDepartment.Checked Then
                filter = filter.Replace("Department" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnOffense.Checked Then
                filter = filter.Replace("Offense" & searchOperator & parameterVar & searchBinder, "")
            End If
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
            If Not cbtnConsumeID.Checked Then
                filter = filter.Replace("ConsumeID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnGood.Checked Then
                filter = filter.Replace("ConsumedGood" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDamaged.Checked Then
                filter = filter.Replace("ConsumedDamaged" & searchOperator & parameterVar & searchBinder, "")
            End If
        End If

        If filter.Length = 0 Then
            filter = defaultFilter
        End If

        filter = filter.Remove(filter.Length - searchBinder.Length, searchBinder.Length)

        Return filter
    End Function

End Class
