Imports System.Data.SqlClient

Public Class frmAddUser

    Private permissionDetails As PermissionDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New()
        InitializeComponent()

        lblUsername.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Sub btnSelectPermission_Click(sender As Object, e As EventArgs) Handles btnSelectPermission.Click
        Using selectPermission As New frmSelectPermission
            selectPermission.ShowDialog()
            permissionDetails = selectPermission.SelectedPermission
            PrintPermission()
        End Using
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_USER Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Adding record", Sub() cts.Cancel())
            err.Clear()
            Dim errCount As Integer = 0

            If txtUsername.Text.TrimAll.Length <= 3 Then
                err.SetError(txtUsername, "The field must be 4 to 16 non-whitespace character.")
                errCount += 1
            End If

            If txtPassword.Text.TrimAll.Length <= 5 Then
                err.SetError(txtPassword, "The field must be 6 to 50 non-whitespace character.")
                errCount += 1
            End If

            If permissionDetails Is Nothing Then
                err.SetError(btnSelectPermission, CODE_ERR)
                errCount += 1
            End If

            If errCount > 0 Then Exit Sub

            Await AddRecord()
        End Using

        lblUsername.Select()
    End Sub

    Private Async Function AddRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spInsertUser @Key, @Username, @Password, @PermissionName", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@Username", txtUsername.Text.TrimAll)
                    com.Parameters.AddWithValue("@Password", txtPassword.Text)
                    com.Parameters.AddWithValue("@PermissionName", permissionDetails.PermissionName)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblUser_PermissionName"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "permission"))
                                    permissionDetails = Nothing
                                    PrintPermission()

                                Case "Username"
                                    err.SetError(txtUsername, "The field must be 4 to 16 non-whitespace character.")
                                Case "Password"
                                    err.SetError(txtPassword, "The field must be 6 to 50 non-whitespace character.")

                                Case "Exists"
                                    MessageBox.Show(CODE_EXISTS)
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    MessageBox.Show("Log:" & NXT & NXT &
                                                    reader("LOG"))

                                    txtUsername.Text = ""
                                    txtPassword.Text = ""
                                    permissionDetails = Nothing
                                Case Else
                                    MessageBox.Show(CODE_ELSE & reader("RES"))
                            End Select
                        Else
                            MessageBox.Show(CODE_FAILED)
                            Me.Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Exit Function
        Catch ex As InvalidOperationException
            Notification.Show(ERR_CON, Color.FromArgb(230, 50, 50))
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show(ERR_ELSE, Color.FromArgb(230, 50, 50))
            End If
        End Try
    End Function

    Private Sub PrintPermission()
        If permissionDetails IsNot Nothing Then
            lblPermissionName.Text = "Permission name : " & permissionDetails.PermissionName
            lblAccessUser.Text = "Access user : " & permissionDetails.AccessUser
            lblAccessPermission.Text = "Access permission : " & permissionDetails.AccessPermission
            lblAccessCustomer.Text = "Access customer : " & permissionDetails.AccessCustomer
            lblAccessItem.Text = "Access item : " & permissionDetails.AccessItem
            lblAccessInventory.Text = "Access inventory : " & permissionDetails.AccessInventory
            lblAccessReservation.Text = "Access reservation : " & permissionDetails.AccessReservation
            lblAccessConsume.Text = "Access consume : " & permissionDetails.AccessConsume
            lblAccessBorrow.Text = "Access borrow : " & permissionDetails.AccessBorrow
            lblAccessStation.Text = "Access station : " & permissionDetails.AccessStation
        Else
            lblPermissionName.Text = "Permission name : "
            lblAccessUser.Text = "Access user : "
            lblAccessPermission.Text = "Access permission : "
            lblAccessCustomer.Text = "Access customer : "
            lblAccessItem.Text = "Access item : "
            lblAccessInventory.Text = "Access inventory : "
            lblAccessReservation.Text = "Access reservation : "
            lblAccessConsume.Text = "Access consume : "
            lblAccessBorrow.Text = "Access borrow : "
            lblAccessStation.Text = "Access station : "
        End If
    End Sub

End Class
