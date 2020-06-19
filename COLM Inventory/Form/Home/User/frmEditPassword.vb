Imports System.Data.SqlClient

Public Class frmEditPassword

    Private userDetails As UserDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(userDetails As UserDetails)
        If userDetails Is Nothing Then Throw New ArgumentNullException("userDetails")
        Me.userDetails = userDetails

        InitializeComponent()

        lblNewPassword.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Async Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()
            Dim errCount As Integer = 0

            If txtNewPassword.Text.TrimAll.Length <= 5 Then
                err.SetError(txtNewPassword, "The field must be 6 to 50 non-whitespace character.")
                errCount += 1
            End If

            If txtNewPassword.Text <> txtConfirmPassword.Text Then
                err.SetError(txtConfirmPassword, "Password didn't match.")
                errCount += 1
            End If

            If txtCurrentPassword.Text.TrimAll.Length <= 5 Then
                err.SetError(txtCurrentPassword, "Incorrect password.")
                errCount += 1
            End If

            If errCount > 0 Then Exit Sub

            If Await TestLogin() Then
                Await EditRecord()
            End If
        End Using

        lblNewPassword.Select()
    End Sub

    Private Async Function TestLogin() As Threading.Tasks.Task(Of Boolean)
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT dbo.fnLogin(@Username, @Password) AS RES", con)
                    com.Parameters.AddWithValue("@Username", USERNAME)
                    com.Parameters.AddWithValue("@Password", txtCurrentPassword.Text)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "0"
                                    err.SetError(txtCurrentPassword, "Incorrect password.")
                                    Return False
                                Case "1"
                                    Return True
                                Case Else
                                    MessageBox.Show(CODE_ELSE & reader("RES"))
                                    Return False
                            End Select
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Return False
        Catch ex As InvalidOperationException
            Notification.Show(ERR_CON, Color.FromArgb(230, 50, 50))
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show(ERR_ELSE, Color.FromArgb(230, 50, 50))
            End If
        End Try

        Return False
    End Function

    Private Async Function EditRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spUpdateUser @Key, @UserID, @Username, @Password, @PermissionName, @Active", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@UserID", userDetails.UserID)
                    com.Parameters.AddWithValue("@Username", USERNAME)
                    com.Parameters.AddWithValue("@Password", txtNewPassword.Text)
                    com.Parameters.AddWithValue("@PermissionName", userDetails.Permission.PermissionName)
                    com.Parameters.AddWithValue("@Active", userDetails.Active)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblUser_PermissionName"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "permission that is associated with this record"))
                                    Me.Close()

                                Case "Password"
                                    err.SetError(txtNewPassword, "The field must be 6 to 50 non-whitespace character.")

                                Case "Not Exists"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "record"))
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()
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

End Class
