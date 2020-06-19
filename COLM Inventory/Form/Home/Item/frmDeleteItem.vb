Imports System.Data.SqlClient

Public Class frmDeleteItem

    Private itemDetails As ItemDetails
    Private cts As New Threading.CancellationTokenSource
    Private password As String = Nothing

    Public Sub New(itemDetails As ItemDetails)
        If itemDetails Is Nothing Then Throw New ArgumentNullException("itemDetails")
        Me.itemDetails = itemDetails

        InitializeComponent()

        lblItemID.Text = "Item ID : " & itemDetails.ItemID
        btnCancel.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_ITEM Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Removing record", Sub() cts.Cancel())
            If MessageBox.Show("Deleting this record will also delete the records that rely on it." & NXT & NXT &
                               "Mainly, records from:" & NXT &
                               "    - Inventory list" & NXT &
                               "    - Consume list" & NXT &
                               "    - Borrow list" & NXT &
                               "    - Station list" & NXT &
                               "    - Reservation list" & NXT & NXT &
                               "This action cannot be undone, continue?" & NXT & NXT &
                               "*Confirm password to continue.*", "", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Using confirmPass As New frmConfirmPassword()
                    confirmPass.ShowDialog()
                    If confirmPass.Password IsNot Nothing Then
                        password = confirmPass.Password
                        Await DeleteRecord()
                        password = Nothing
                    End If
                End Using
            End If
        End Using
    End Sub

    Private Async Function DeleteRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spDeleteItem @Key, @LogPassword, @ItemID", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@LogPassword", password)
                    com.Parameters.AddWithValue("@ItemID", itemDetails.ItemID)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "LogPassword"
                                    MessageBox.Show(CODE_FAILED)

                                Case "Not Exists"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "record"))
                                    Me.DialogResult = DialogResult.OK
                                    Me.Close()
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    Me.DialogResult = DialogResult.OK
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
