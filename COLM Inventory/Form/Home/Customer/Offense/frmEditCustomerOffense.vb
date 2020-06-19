Imports System.Data.SqlClient

Public Class frmEditCustomerOffense

    Private customerOffenseDetails As CustomerOffenseDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(customerOffenseDetails As CustomerOffenseDetails)
        If customerOffenseDetails Is Nothing Then Throw New ArgumentNullException("customerOffenseDetails")
        Me.customerOffenseDetails = customerOffenseDetails

        InitializeComponent()

        txtOffenseID.Text = customerOffenseDetails.OffenseID
        txtInformation.Text = customerOffenseDetails.Information
        sbtnSettled.Checked = customerOffenseDetails.Settled
        lblInformation.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_CUSTOMER Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()

            If Not txtInformation.IsValid Then
                err.SetError(txtInformation, CODE_ERR_TEXT)
                Exit Sub
            End If

            Await EditRecord()
        End Using

        lblInformation.Select()
    End Sub

    Private Async Function EditRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spUpdateCustomerOffense @Key, @OffenseID, @CustomerID, @Information, @Settled", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@OffenseID", customerOffenseDetails.OffenseID)
                    com.Parameters.AddWithValue("@CustomerID", customerOffenseDetails.CustomerID)
                    com.Parameters.AddWithValue("@Information", txtInformation.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@Settled", sbtnSettled.Checked)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblCustomerOffense_CustomerID"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "customer that is associated with this records"))
                                    Me.Close()

                                Case "Information"
                                    err.SetError(txtInformation, CODE_ERR_TEXT)

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

    Private Sub txtInformation_TextChanged(sender As Object, e As EventArgs) Handles txtInformation.TextChanged

    End Sub

    Private Sub lblSettled_Click(sender As Object, e As EventArgs) Handles lblSettled.Click

    End Sub

    Private Sub ctrlSwitch_CheckedChanged(sender As Object, e As EventArgs) Handles sbtnSettled.CheckedChanged

    End Sub
End Class
