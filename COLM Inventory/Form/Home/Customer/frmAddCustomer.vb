Imports System.Data.SqlClient

Public Class frmAddCustomer

    Private cts As New Threading.CancellationTokenSource

    Public Sub New()
        InitializeComponent()

        lblFirstName.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_CUSTOMER Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Adding record", Sub() cts.Cancel())
            err.Clear()
            Dim errCount As Integer = 0

            If Not txtFirstName.IsValid Then
                err.SetError(txtFirstName, CODE_ERR_TEXT)
                errCount += 1
            End If

            If Not txtLastName.IsValid Then
                err.SetError(txtLastName, CODE_ERR_TEXT)
                errCount += 1
            End If

            If Not txtPosition.IsValid Then
                err.SetError(txtPosition, CODE_ERR_TEXT)
                errCount += 1
            End If

            If Not txtDeparment.IsValid Then
                err.SetError(txtDeparment, CODE_ERR_TEXT)
                errCount += 1
            End If

            If errCount > 0 Then Exit Sub

            Await AddRecord()
        End Using

        lblFirstName.Select()
    End Sub

    Private Async Function AddRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spInsertCustomer @Key, @FirstName, @MiddleName, @LastName, @Position, @Department", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@FirstName", txtFirstName.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@LastName", "" & txtLastName.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@Position", txtPosition.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@Department", txtDeparment.Text.TrimConsecutive)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FirstName"
                                    err.SetError(txtFirstName, CODE_ERR_TEXT)
                                Case "LastName"
                                    err.SetError(txtLastName, CODE_ERR_TEXT)
                                Case "Position"
                                    err.SetError(txtPosition, CODE_ERR_TEXT)
                                Case "Department"
                                    err.SetError(txtDeparment, CODE_ERR_TEXT)

                                Case "Exists"
                                    MessageBox.Show(CODE_EXISTS)
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    MessageBox.Show("Log:" & NXT & NXT &
                                                    reader("LOG"))

                                    txtFirstName.Text = ""
                                    txtMiddleName.Text = ""
                                    txtLastName.Text = ""
                                    txtPosition.Text = ""
                                    txtDeparment.Text = ""
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
