Imports System.Data.SqlClient

Public Class frmEditPermission

    Private permissionDetails As PermissionDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(permissionDetails As PermissionDetails)
        If permissionDetails Is Nothing Then Throw New ArgumentNullException("permissionDetails")
        Me.permissionDetails = permissionDetails

        InitializeComponent()

        PrintPermission()
        lblPermissionName.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_PERMISSION Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()

            If Not txtPermissionName.IsValid Then
                err.SetError(txtPermissionName, CODE_ERR_TEXT)
                Exit Sub
            End If

            Await EditRecord()
        End Using

        lblPermissionName.Select()
    End Sub

    Private Async Function EditRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spUpdatePermission @Key, @PermissionName, @NewPermissionName, @AccessUser, @AccessPermission, @AccessCustomer, @AccessItem, @AccessInventory, @AccessReservation, @AccessConsume, @AccessBorrow, @AccessStation", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@PermissionName", permissionDetails.PermissionName)
                    com.Parameters.AddWithValue("@NewPermissionName", txtPermissionName.Text.TrimConsecutive)
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
        txtPermissionName.Text = permissionDetails.PermissionName
        sbtnAccessUser.Checked = permissionDetails.AccessUser
        sbtnAccessPermission.Checked = permissionDetails.AccessPermission
        sbtnAccessCustomer.Checked = permissionDetails.AccessCustomer
        sbtnAccessItem.Checked = permissionDetails.AccessItem
        sbtnAccessInventory.Checked = permissionDetails.AccessInventory
        sbtnAccessReservation.Checked = permissionDetails.AccessReservation
        sbtnAccessConsume.Checked = permissionDetails.AccessConsume
        sbtnAccessBorrow.Checked = permissionDetails.AccessBorrow
        sbtnAccessStation.Checked = permissionDetails.AccessStation
    End Sub

End Class
