Imports System.Data.SqlClient

Public Class frmAddCustomerOffense

    Private customerDetails As New CustomerDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(customerDetails As CustomerDetails)
        If customerDetails Is Nothing Then Throw New ArgumentNullException("customerDetails")
        Me.customerDetails = customerDetails

        InitializeComponent()

        lblInformation.Select()
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

            If Not txtInformation.IsValid Then
                err.SetError(txtInformation, CODE_ERR_TEXT)
                Exit Sub
            End If

            Await AddRecord()
        End Using

        lblInformation.Select()
    End Sub

    Private Async Function AddRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spInsertCustomerOffense @Key, @CustomerID, @Information", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@CustomerID", customerDetails.CustomerID)
                    com.Parameters.AddWithValue("@Information", txtInformation.Text.TrimConsecutive)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "Information"
                                    err.SetError(txtInformation, CODE_ERR_TEXT)

                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    MessageBox.Show("Log:" & NXT & NXT &
                                                    reader("LOG"))

                                    txtInformation.Text = ""
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
