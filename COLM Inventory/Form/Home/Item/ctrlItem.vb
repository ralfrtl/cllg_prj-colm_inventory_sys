Imports System.Data.SqlClient

Public Class ctrlItem

    Private selectedCardVal As ctrlItemCard
    Private cts As New Threading.CancellationTokenSource

    Friend Property SelectedCard As ctrlItemCard
        Get
            Return selectedCardVal
        End Get
        Set(value As ctrlItemCard)
            Dim temp As ctrlItemCard = selectedCardVal
            selectedCardVal = value

            If temp IsNot Nothing Then
                temp.Invalidate()

                If value Is Nothing Then
                    fpnlCardList.SelectNextControl(temp, True, True, False, True)
                End If
            End If
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))

        If Not ACCESS_ITEM Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not DesignMode Then
            cbtnMore_CheckedChanged(Nothing, Nothing)
            LoadRecordList()
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)

        If fpnlCardList.Controls.Count > 0 Then
            fpnlCardList.Padding = New Padding((fpnlCardList.Width - fpnlCardList.Controls.Item(0).Width) / 2, 0, 0, 0)
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
            LoadRecordList()
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

    Private Sub ctrlItem_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        cts.Cancel()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_ITEM Then Exit Sub

        Using addItem As New frmAddItem()
            addItem.ShowDialog()
            LoadRecordList()
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_ITEM Then Exit Sub
        If SelectedCard Is Nothing Then Exit Sub

        Using editItem As New frmEditItem(SelectedCard.itemDetails)
            editItem.ShowDialog()
            LoadRecordList()
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_ITEM Then Exit Sub
        If SelectedCard Is Nothing Then Exit Sub

        Using deleteItem As New frmDeleteItem(SelectedCard.itemDetails)
            If deleteItem.ShowDialog() = DialogResult.OK Then
                SelectedCard.Dispose()
            End If
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

    Private Sub fpnlCardList_Click(sender As Object, e As EventArgs) Handles fpnlCardList.Click
        If SelectedCard IsNot Nothing Then
            SelectedCard.Select()
        End If
    End Sub

    Private Async Sub LoadRecordList()
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        SelectedCard = Nothing
        fpnlCardList.Controls.Clear()

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT " & IIf(numTop.Value = 0, "", "Top(" & numTop.Value & ")") & " * FROM vwItem WHERE " & SearchFilter("@a"), con)
                    com.Parameters.AddWithValue("@a", IIf(cbtnMatchWholeWord.Checked, txtSearch.Text, "%" & txtSearch.Text & "%"))
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            Await Threading.Tasks.Task.Delay(100, cts.Token)

                            Dim itemDetails As New ItemDetails
                            With itemDetails
                                .ItemID = reader("ItemID")
                                .Name = reader("Name")
                                .Description = reader("Description")
                                .ItemType = reader("ItemType")
                                .UnitType = reader("UnitType")
                                .LowThreshold = reader("LowThreshold")
                                .Total = reader("Total")
                                .Available = reader("Available")
                                .Reserved = reader("Reserved")
                                .Borrowed = reader("Borrowed")
                                .Stationed = reader("Stationed")
                                .Good = reader("Good")
                                .Damaged = reader("Damaged")
                                .Maintenance = reader("Maintenance")
                                .Replacement = reader("Replacement")
                            End With

                            Dim newCard As New ctrlItemCard(itemDetails)
                            newCard.Margin = New Padding(0, IIf(fpnlCardList.Controls.Count = 0, 5, 0), 0, 5)

                            fpnlCardList.Controls.Add(newCard)
                            If fpnlCardList.Controls.Count = 1 Then fpnlCardList.Padding = New Padding((fpnlCardList.Width - fpnlCardList.Controls.Item(0).Width) / 2, 0, 0, 0)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Exit Sub
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show("Failed to load item list.", Color.FromArgb(230, 50, 50))
            End If
        End Try

        If fpnlCardList.Controls.Count = 0 Then
            fpnlCardList.Select()
        ElseIf fpnlCardList.Controls.Count > 0 Then
            If SelectedCard Is Nothing Then
                fpnlCardList.Controls.Item(0).Select()
            End If
        End If
    End Sub

    Private Function SearchFilter(parameterVar As String) As String
        Dim searchOperator As String = IIf(cbtnMatchWholeWord.Checked, " = ", " LIKE ")
        Dim searchBinder As String = IIf(cbtnMatchEveryField.Checked, " AND ", " OR ")
        Dim defaultFilter As String = "ItemID" & searchOperator & parameterVar & searchBinder &
                                      "Name" & searchOperator & parameterVar & searchBinder &
                                      "Description" & searchOperator & parameterVar & searchBinder &
                                      "ItemType" & searchOperator & parameterVar & searchBinder &
                                      "UnitType" & searchOperator & parameterVar & searchBinder &
                                      "LowThreshold" & searchOperator & parameterVar & searchBinder &
                                      "Total" & searchOperator & parameterVar & searchBinder &
                                      "Available" & searchOperator & parameterVar & searchBinder &
                                      "Borrowed" & searchOperator & parameterVar & searchBinder &
                                      "Stationed" & searchOperator & parameterVar & searchBinder &
                                      "Reserved" & searchOperator & parameterVar & searchBinder &
                                      "Good" & searchOperator & parameterVar & searchBinder &
                                      "Damaged" & searchOperator & parameterVar & searchBinder &
                                      "Maintenance" & searchOperator & parameterVar & searchBinder &
                                      "Replacement" & searchOperator & parameterVar & searchBinder
        Dim filter = defaultFilter

        If cbtnFilter.Checked Then
            If Not cbtnItemID.Checked Then
                filter = filter.Replace("ItemID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnName.Checked Then
                filter = filter.Replace("Name" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDescription.Checked Then
                filter = filter.Replace("Description" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnItemType.Checked Then
                filter = filter.Replace("ItemType" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnUnitType.Checked Then
                filter = filter.Replace("UnitType" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnLowThreshold.Checked Then
                filter = filter.Replace("LowThreshold" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnTotal.Checked Then
                filter = filter.Replace("Total" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAvailable.Checked Then
                filter = filter.Replace("Available" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnBorrowed.Checked Then
                filter = filter.Replace("Borrowed" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnStationed.Checked Then
                filter = filter.Replace("Stationed" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnReserved.Checked Then
                filter = filter.Replace("Reserved" & searchOperator & parameterVar & searchBinder, "")
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
