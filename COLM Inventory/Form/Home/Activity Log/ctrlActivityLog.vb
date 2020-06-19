Imports System.Data.SqlClient

Public Class ctrlActivityLog

    Private cts As New Threading.CancellationTokenSource

    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))
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
        If keyData = Keys.F5 Then
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

    Private Sub ctrlActivityLog_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        cts.Cancel()
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

    Private Async Sub LoadRecordList()
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        fpnlCardList.Controls.Clear()

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT Top(" & numTop.Value & ") * FROM vwActivityLog WHERE " & SearchFilter("@a") & " ORDER BY LogID DESC", con)
                    com.Parameters.AddWithValue("@a", IIf(cbtnMatchWholeWord.Checked, txtSearch.Text, "%" & txtSearch.Text & "%"))
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            Await Threading.Tasks.Task.Delay(100, cts.Token)

                            Dim activityLogDetails As New ActivityLogDetails
                            With activityLogDetails
                                .LogID = reader("LogID")
                                .Activity = reader("Activity")
                                .Details = reader("Details").ToString
                                .Timestamp = reader("Timestamp")
                                .UserID = reader("UserID")
                                .Username = reader("Username")
                                .PermissionName = reader("PermissionName")
                            End With

                            Dim newCard As New ctrlActivityLogCard(activityLogDetails)
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
                Notification.Show("Failed to load activity log list.", Color.FromArgb(230, 50, 50))
            End If
        End Try

        fpnlCardList.Select()
    End Sub

    Private Function SearchFilter(parameterVar As String) As String
        Dim searchOperator As String = IIf(cbtnMatchWholeWord.Checked, " = ", " LIKE ")
        Dim searchBinder As String = IIf(cbtnMatchEveryField.Checked, " AND ", " OR ")
        Dim defaultFilter As String = "LogID" & searchOperator & parameterVar & searchBinder &
                                      "Activity" & searchOperator & parameterVar & searchBinder &
                                      "Details" & searchOperator & parameterVar & searchBinder &
                                      "Timestamp" & searchOperator & parameterVar & searchBinder &
                                      "Username" & searchOperator & parameterVar & searchBinder &
                                      "PermissionName" & searchOperator & parameterVar & searchBinder
        Dim filter = defaultFilter

        If cbtnFilter.Checked Then
            If Not cbtnLogID.Checked Then
                filter = filter.Replace("LogID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnActivity.Checked Then
                filter = filter.Replace("Activity" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDetails.Checked Then
                filter = filter.Replace("Details" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnTimestamp.Checked Then
                filter = filter.Replace("Timestamp" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnUsername.Checked Then
                filter = filter.Replace("Username" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnPermissionName.Checked Then
                filter = filter.Replace("PermissionName" & searchOperator & parameterVar & searchBinder, "")
            End If
        End If

        If filter.Length = 0 Then
            filter = defaultFilter
        End If

        filter = filter.Remove(filter.Length - searchBinder.Length, searchBinder.Length)

        Return filter
    End Function

End Class
