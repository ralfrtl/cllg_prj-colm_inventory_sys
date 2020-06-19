Imports System.Data.SqlClient

Public Class frmEditUser

    Private userDetails As UserDetails
    Private permissionDetails As PermissionDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(userDetails As UserDetails)
        If userDetails Is Nothing Then Throw New ArgumentNullException("userDetails")
        Me.userDetails = userDetails
        Me.permissionDetails = userDetails.Permission

        InitializeComponent()

        txtUserID.Text = userDetails.UserID
        txtUsername.Text = userDetails.Username
        sbtnActive.Checked = userDetails.Active
        PrintPermission()
        lblActive.Select()
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

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_USER Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()

            If permissionDetails Is Nothing Then
                err.SetError(btnSelectPermission, CODE_ERR)
                Exit Sub
            End If

            Await EditRecord()
        End Using

        lblActive.Select()
    End Sub

    Private Async Function EditRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spUpdateUser @Key, @UserID, @Username, @Password, @PermissionName, @Active", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@UserID", userDetails.UserID)
                    com.Parameters.AddWithValue("@Username", userDetails.Username)
                    com.Parameters.AddWithValue("@Password", DBNull.Value)
                    com.Parameters.AddWithValue("@PermissionName", permissionDetails.PermissionName)
                    com.Parameters.AddWithValue("@Active", sbtnActive.Checked)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblUser_PermissionName"
                                    If userDetails.Permission.PermissionName <> permissionDetails.PermissionName Then
                                        MessageBox.Show(String.Format(CODE_NOT_EXISTS, "permission") & NXT & NXT & "Reverting back to the current permission.")
                                        permissionDetails = userDetails.Permission
                                        PrintPermission()
                                    Else
                                        MessageBox.Show(String.Format(CODE_NOT_EXISTS, "permission that is associated with this record"))
                                        Me.Close()
                                    End If

                                Case "Not Exists"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "record"))
                                    Me.Close()
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    MessageBox.Show("Log:" & NXT & NXT &
                                                    reader("LOG"))
                                    Me.Close()
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
