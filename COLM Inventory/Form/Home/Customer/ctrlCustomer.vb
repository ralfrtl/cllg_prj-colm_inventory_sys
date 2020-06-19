Imports System.Data.SqlClient

Public Class ctrlCustomer

    Private selectedCardVal As ctrlCustomerCard
    Private cts As New Threading.CancellationTokenSource

    Friend Property SelectedCard As ctrlCustomerCard
        Get
            Return selectedCardVal
        End Get
        Set(value As ctrlCustomerCard)
            Dim temp As ctrlCustomerCard = selectedCardVal
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

        If Not ACCESS_CUSTOMER Then
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

    Private Sub ctrlCustomer_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        cts.Cancel()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_CUSTOMER Then Exit Sub

        Using addCustomer As New frmAddCustomer()
            addCustomer.ShowDialog()
            LoadRecordList()
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_CUSTOMER Then Exit Sub
        If SelectedCard Is Nothing Then Exit Sub

        Using editCustomer As New frmEditCustomer(SelectedCard.customerDetails)
            editCustomer.ShowDialog()
            LoadRecordList()
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_CUSTOMER Then Exit Sub
        If SelectedCard Is Nothing Then Exit Sub

        Using deleteCustomer As New frmDeleteCustomer(SelectedCard.customerDetails)
            If deleteCustomer.ShowDialog() = DialogResult.OK Then
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
        Else
            pnlFilter.Enabled = False
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
                Using com As New SqlCommand("SELECT " & IIf(numTop.Value = 0, "", "Top(" & numTop.Value & ")") & " * FROM vwCustomer WHERE " & SearchFilter("@a"), con)
                    com.Parameters.AddWithValue("@a", IIf(cbtnMatchWholeWord.Checked, txtSearch.Text, "%" & txtSearch.Text & "%"))
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            Await Threading.Tasks.Task.Delay(100, cts.Token)

                            Dim customerDetails As New CustomerDetails
                            With customerDetails
                                .CustomerID = reader("CustomerID")
                                .FirstName = reader("FirstName")
                                .MiddleName = reader("MiddleName")
                                .LastName = reader("LastName")
                                .Position = reader("Position")
                                .Department = reader("Department")
                                .Offense = reader("Offense")
                            End With

                            Dim newCard As New ctrlCustomerCard(customerDetails)
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
                Notification.Show("Failed to load customer list.", Color.FromArgb(230, 50, 50))
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
        Dim defaultFilter As String = "CustomerID" & searchOperator & parameterVar & searchBinder &
                                      "FirstName" & searchOperator & parameterVar & searchBinder &
                                      "MiddleName" & searchOperator & parameterVar & searchBinder &
                                      "LastName" & searchOperator & parameterVar & searchBinder &
                                      "Position" & searchOperator & parameterVar & searchBinder &
                                      "Department" & searchOperator & parameterVar & searchBinder &
                                      "Offense" & searchOperator & parameterVar & searchBinder
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
        End If

        If filter.Length = 0 Then
            filter = defaultFilter
        End If

        filter = filter.Remove(filter.Length - searchBinder.Length, searchBinder.Length)

        Return filter
    End Function

End Class
