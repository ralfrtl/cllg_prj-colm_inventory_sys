Imports System.Data.SqlClient

Public Class ctrlPermission

    Private selectedCardVal As ctrlPermissionCard
    Private cts As New Threading.CancellationTokenSource

    Friend Property SelectedCard As ctrlPermissionCard
        Get
            Return selectedCardVal
        End Get
        Set(value As ctrlPermissionCard)
            Dim temp As ctrlPermissionCard = selectedCardVal
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

        If Not ACCESS_PERMISSION Then
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

    Private Sub ctrlPermission_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        cts.Cancel()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_PERMISSION Then Exit Sub

        Using addPermission As New frmAddPermission
            addPermission.ShowDialog()
            LoadRecordList()
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_PERMISSION Then Exit Sub
        If SelectedCard Is Nothing Then Exit Sub

        If SelectedCard.permissionDetails.PermissionName <> "Admin" And SelectedCard.permissionDetails.PermissionName <> "Guest" Then
            Using editPermission As New frmEditPermission(SelectedCard.permissionDetails)
                editPermission.ShowDialog()
                LoadRecordList()
            End Using
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_PERMISSION Then Exit Sub
        If SelectedCard Is Nothing Then Exit Sub

        If SelectedCard.permissionDetails.PermissionName <> "Admin" And SelectedCard.permissionDetails.PermissionName <> "Guest" Then
            Using deletePermission As New frmDeletePermission(SelectedCard.permissionDetails)
                If deletePermission.ShowDialog() = DialogResult.OK Then
                    SelectedCard.Dispose()
                End If
            End Using
        End If
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
                Using com As New SqlCommand("SELECT " & IIf(numTop.Value = 0, "", "Top(" & numTop.Value & ")") & " * FROM vwPermission WHERE " & SearchFilter("@a"), con)
                    com.Parameters.AddWithValue("@a", IIf(cbtnMatchWholeWord.Checked, txtSearch.Text, "%" & txtSearch.Text & "%"))
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            Await Threading.Tasks.Task.Delay(100, cts.Token)

                            Dim permissionDetails As New PermissionDetails
                            With permissionDetails
                                .PermissionName = reader("PermissionName")
                                .AccessUser = reader("AccessUser")
                                .AccessPermission = reader("AccessPermission")
                                .AccessCustomer = reader("AccessCustomer")
                                .AccessItem = reader("AccessItem")
                                .AccessInventory = reader("AccessInventory")
                                .AccessReservation = reader("AccessReservation")
                                .AccessConsume = reader("AccessConsume")
                                .AccessBorrow = reader("AccessBorrow")
                                .AccessStation = reader("AccessStation")
                            End With

                            Dim newCard As New ctrlPermissionCard(permissionDetails)
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
                Notification.Show("Failed to load permission list.", Color.FromArgb(230, 50, 50))
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
        Dim defaultFilter As String = "PermissionName" & searchOperator & parameterVar & searchBinder &
                                      "AccessUser" & searchOperator & parameterVar & searchBinder &
                                      "AccessPermission" & searchOperator & parameterVar & searchBinder &
                                      "AccessCustomer" & searchOperator & parameterVar & searchBinder &
                                      "AccessItem" & searchOperator & parameterVar & searchBinder &
                                      "AccessInventory" & searchOperator & parameterVar & searchBinder &
                                      "AccessReservation" & searchOperator & parameterVar & searchBinder &
                                      "AccessConsume" & searchOperator & parameterVar & searchBinder &
                                      "AccessBorrow" & searchOperator & parameterVar & searchBinder &
                                      "AccessStation" & searchOperator & parameterVar & searchBinder
        Dim filter = defaultFilter

        If cbtnFilter.Checked Then
            If Not cbtnPermissionName.Checked Then
                filter = filter.Replace("PermissionName" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessUser.Checked Then
                filter = filter.Replace("AccessUser" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessPermission.Checked Then
                filter = filter.Replace("AccessPermission" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessCustomer.Checked Then
                filter = filter.Replace("AccessCustomer" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessItem.Checked Then
                filter = filter.Replace("AccessItem" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessInventory.Checked Then
                filter = filter.Replace("AccessInventory" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessReservation.Checked Then
                filter = filter.Replace("AccessReservation" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessConsume.Checked Then
                filter = filter.Replace("AccessConsume" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessBorrow.Checked Then
                filter = filter.Replace("AccessBorrow" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnAccessStation.Checked Then
                filter = filter.Replace("AccessStation" & searchOperator & parameterVar & searchBinder, "")
            End If
        End If

        If filter.Length = 0 Then
            filter = defaultFilter
        End If

        filter = filter.Remove(filter.Length - searchBinder.Length, searchBinder.Length)

        Return filter
    End Function

End Class
