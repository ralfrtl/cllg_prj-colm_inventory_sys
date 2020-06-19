Imports System.Data.SqlClient

Public Class ctrlUser

    Private selectedCardVal As ctrlUserCard
    Private cts As New Threading.CancellationTokenSource

    Friend Property SelectedCard As ctrlUserCard
        Get
            Return selectedCardVal
        End Get
        Set(value As ctrlUserCard)
            Dim temp As ctrlUserCard = selectedCardVal
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

        If Not ACCESS_USER Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
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

    Private Sub ctrlUser_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        cts.Cancel()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_USER Then Exit Sub

        Using addUser As New frmAddUser()
            addUser.ShowDialog()
            LoadRecordList()
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_USER Then Exit Sub
        If SelectedCard Is Nothing Then Exit Sub

        If SelectedCard.userDetails.UserID = USER_ID Then
            Using editUser As New frmEditPassword(SelectedCard.userDetails)
                editUser.ShowDialog()
            End Using
        Else
            Using editUser As New frmEditUser(SelectedCard.userDetails)
                editUser.ShowDialog()
            End Using
        End If

        LoadRecordList()
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
                Using com As New SqlCommand("SELECT " & IIf(numTop.Value = 0, "", "Top(" & numTop.Value & ")") & " * FROM vwUser WHERE " & SearchFilter("@a") & " ORDER BY Active DESC", con)
                    com.Parameters.AddWithValue("@a", IIf(cbtnMatchWholeWord.Checked, txtSearch.Text, "%" & txtSearch.Text & "%"))
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            Await Threading.Tasks.Task.Delay(100, cts.Token)

                            Dim userDetails As New UserDetails
                            With userDetails
                                .UserID = reader("UserID")
                                .Username = reader("Username")
                                .Permission.PermissionName = reader("PermissionName")
                                .Permission.AccessUser = reader("AccessUser")
                                .Permission.AccessPermission = reader("AccessPermission")
                                .Permission.AccessCustomer = reader("AccessCustomer")
                                .Permission.AccessItem = reader("AccessItem")
                                .Permission.AccessInventory = reader("AccessInventory")
                                .Permission.AccessReservation = reader("AccessReservation")
                                .Permission.AccessConsume = reader("AccessConsume")
                                .Permission.AccessBorrow = reader("AccessBorrow")
                                .Permission.AccessStation = reader("AccessStation")
                                .Active = reader("Active")
                            End With

                            Dim newCard As New ctrlUserCard(userDetails)
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
                Notification.Show("Failed to load user list.", Color.FromArgb(230, 50, 50))
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
        Dim defaultFilter As String = "UserID" & searchOperator & parameterVar & searchBinder &
                                      "Username" & searchOperator & parameterVar & searchBinder &
                                      "PermissionName" & searchOperator & parameterVar & searchBinder &
                                      "Active" & searchOperator & parameterVar & searchBinder
        Dim filter = defaultFilter

        If cbtnFilter.Checked Then
            If Not cbtnUserID.Checked Then
                filter = filter.Replace("UserID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnUsername.Checked Then
                filter = filter.Replace("Username" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnPermissionName.Checked Then
                filter = filter.Replace("PermissionName" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnActive.Checked Then
                filter = filter.Replace("Active" & searchOperator & parameterVar & searchBinder, "")
            End If
        End If

        If filter.Length = 0 Then
            filter = defaultFilter
        End If

        filter = filter.Remove(filter.Length - searchBinder.Length, searchBinder.Length)

        Return filter
    End Function

End Class
