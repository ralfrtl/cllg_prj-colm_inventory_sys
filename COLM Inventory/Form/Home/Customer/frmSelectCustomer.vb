Imports System.Data.SqlClient

Public Class frmSelectCustomer

    Private cts As New Threading.CancellationTokenSource

    Friend SelectedCustomer As CustomerDetails

    Public Sub New()
        InitializeComponent()

        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))

        If Not ACCESS_CUSTOMER Then
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
        If Not ACCESS_CUSTOMER Then Exit Sub

        Using addCustomer As New frmAddCustomer()
            addCustomer.ShowDialog()
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

        SelectedCustomer = New CustomerDetails
        With SelectedCustomer
            .CustomerID = dgv.Item(colCustomerID.Index, dgv.CurrentRow.Index).Value
            .FirstName = dgv.Item(colFirstName.Index, dgv.CurrentRow.Index).Value
            .MiddleName = dgv.Item(colMiddleName.Index, dgv.CurrentRow.Index).Value
            .LastName = dgv.Item(colLastName.Index, dgv.CurrentRow.Index).Value
            .Position = dgv.Item(colPosition.Index, dgv.CurrentRow.Index).Value
            .Department = dgv.Item(colDepartment.Index, dgv.CurrentRow.Index).Value
            .Offense = dgv.Item(colOffense.Index, dgv.CurrentRow.Index).Value
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
                Using com As New SqlCommand("SELECT * FROM vwCustomer WHERE CustomerID LIKE @a OR FirstName LIKE @a OR MiddleName LIKE @a OR LastName LIKE @a OR Position LIKE @a OR Department LIKE @a OR Offense LIKE @a", con)
                    com.Parameters.AddWithValue("@a", "%" & txtSearch.Text & "%")

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            dgv.Rows.Add({reader("CustomerID"),
                                          reader("FirstName"),
                                          reader("MiddleName"),
                                          reader("LastName"),
                                          reader("Position"),
                                          reader("Department"),
                                          reader("Offense")})
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

        dgv.Select()
    End Sub

End Class