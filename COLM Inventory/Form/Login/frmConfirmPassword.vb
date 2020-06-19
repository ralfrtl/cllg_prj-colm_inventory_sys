Imports System.Data.SqlClient

Public Class frmConfirmPassword

    Private cts As New Threading.CancellationTokenSource

    Friend Password As String = Nothing

    Public Sub New()
        InitializeComponent()

        txtPassword.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Async Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Checking password", Sub() cts.Cancel())
            If txtPassword.Text.TrimAll.Length > 5 Then
                Await TestLogin()
            Else
                err.SetError(txtPassword, "Incorrect password.")
            End If
        End Using
    End Sub

    Private Async Function TestLogin() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT dbo.fnLogin(@Username, @Password) AS RES", con)
                    com.Parameters.AddWithValue("@Username", USERNAME)
                    com.Parameters.AddWithValue("@Password", txtPassword.Text)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "0"
                                    err.SetError(txtPassword, "Incorrect password.")
                                Case "1"
                                    Password = txtPassword.Text
                                    Me.Close()
                                Case Else
                                    MessageBox.Show(CODE_ELSE & reader("RES"))
                            End Select
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
