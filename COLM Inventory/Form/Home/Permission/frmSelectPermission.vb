Imports System.Data.SqlClient

Public Class frmSelectPermission

    Private cts As New Threading.CancellationTokenSource

    Friend SelectedPermission As PermissionDetails

    Public Sub New()
        InitializeComponent()

        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))

        If Not ACCESS_PERMISSION Then
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
        If Not ACCESS_PERMISSION Then Exit Sub

        Using addPermission As New frmAddPermission()
            addPermission.ShowDialog()
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

        SelectedPermission = New PermissionDetails
        With SelectedPermission
            .PermissionName = dgv.Item(colPermissionName.Index, dgv.CurrentRow.Index).Value
            .AccessUser = dgv.Item(colUser.Index, dgv.CurrentRow.Index).Value
            .AccessPermission = dgv.Item(colPermission.Index, dgv.CurrentRow.Index).Value
            .AccessCustomer = dgv.Item(colCustomer.Index, dgv.CurrentRow.Index).Value
            .AccessItem = dgv.Item(colItem.Index, dgv.CurrentRow.Index).Value
            .AccessInventory = dgv.Item(colInventory.Index, dgv.CurrentRow.Index).Value
            .AccessReservation = dgv.Item(colReservation.Index, dgv.CurrentRow.Index).Value
            .AccessConsume = dgv.Item(colConsume.Index, dgv.CurrentRow.Index).Value
            .AccessBorrow = dgv.Item(colBorrow.Index, dgv.CurrentRow.Index).Value
            .AccessStation = dgv.Item(colStation.Index, dgv.CurrentRow.Index).Value
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
                Using com As New SqlCommand("SELECT * FROM vwPermission WHERE PermissionName LIKE @a OR AccessUser LIKE @a OR AccessPermission LIKE @a OR AccessCustomer LIKE @a OR AccessItem LIKE @a OR AccessInventory LIKE @a OR AccessReservation LIKE @a OR AccessConsume LIKE @a OR AccessBorrow LIKE @a OR AccessStation LIKE @a", con)
                    com.Parameters.AddWithValue("@a", "%" & txtSearch.Text & "%")

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            dgv.Rows.Add({reader("PermissionName"),
                                          reader("AccessUser"),
                                          reader("AccessPermission"),
                                          reader("AccessCustomer"),
                                          reader("AccessItem"),
                                          reader("AccessInventory"),
                                          reader("AccessReservation"),
                                          reader("AccessConsume"),
                                          reader("AccessBorrow"),
                                          reader("AccessStation")})
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

        dgv.Select()
    End Sub

End Class