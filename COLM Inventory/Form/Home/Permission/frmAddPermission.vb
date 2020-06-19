Imports System.Data.SqlClient

Public Class frmAddPermission

    Private cts As New Threading.CancellationTokenSource

    Public Sub New()
        InitializeComponent()

        lblPermissionName.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_PERMISSION Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Adding record", Sub() cts.Cancel())
            err.Clear()

            If Not txtPermissionName.IsValid Then
                err.SetError(txtPermissionName, CODE_ERR_TEXT)
                Exit Sub
            End If

            Await AddRecord()
        End Using

        lblPermissionName.Select()
    End Sub

    Private Async Function AddRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spInsertPermission @Key, @PermissionName, @AccessUser, @AccessPermission, @AccessCustomer, @AccessItem, @AccessInventory, @AccessReservation, @AccessConsume, @AccessBorrow, @AccessStation", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@PermissionName", txtPermissionName.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@AccessUser", sbtnAccessUser.Checked)
                    com.Parameters.AddWithValue("@AccessPermission", sbtnAccessPermission.Checked)
                    com.Parameters.AddWithValue("@AccessCustomer", sbtnAccessCustomer.Checked)
                    com.Parameters.AddWithValue("@AccessItem", sbtnAccessItem.Checked)
                    com.Parameters.AddWithValue("@AccessInventory", sbtnAccessInventory.Checked)
                    com.Parameters.AddWithValue("@AccessReservation", sbtnAccessReservation.Checked)
                    com.Parameters.AddWithValue("@AccessConsume", sbtnAccessConsume.Checked)
                    com.Parameters.AddWithValue("@AccessBorrow", sbtnAccessBorrow.Checked)
                    com.Parameters.AddWithValue("@AccessStation", sbtnAccessStation.Checked)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "PermissionName"
                                    err.SetError(txtPermissionName, CODE_ERR_TEXT)

                                Case "Exists"
                                    MessageBox.Show(CODE_EXISTS)
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    MessageBox.Show("Log:" & NXT & NXT &
                                                    reader("LOG"))

                                    txtPermissionName.Text = ""
                                    sbtnAccessUser.Checked = False
                                    sbtnAccessPermission.Checked = False
                                    sbtnAccessCustomer.Checked = False
                                    sbtnAccessItem.Checked = False
                                    sbtnAccessInventory.Checked = False
                                    sbtnAccessReservation.Checked = False
                                    sbtnAccessConsume.Checked = False
                                    sbtnAccessBorrow.Checked = False
                                    sbtnAccessStation.Checked = False
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
