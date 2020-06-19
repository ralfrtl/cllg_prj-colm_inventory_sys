Imports System.Data.SqlClient

Public Class frmDeleteCustomer

    Private customerDetails As CustomerDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(customerDetails As CustomerDetails)
        If customerDetails Is Nothing Then Throw New ArgumentNullException("customerDetails")
        Me.customerDetails = customerDetails

        InitializeComponent()

        lblCustomerID.Text = "Customer ID : " & customerDetails.CustomerID
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
        If Not ACCESS_CUSTOMER Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Removing record", Sub() cts.Cancel())
            If MessageBox.Show("This action cannot be undone, continue?", "", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Await DeleteRecord()
            End If
        End Using
    End Sub

    Private Async Function DeleteRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spDeleteCustomer @Key, @CustomerID", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@CustomerID", customerDetails.CustomerID)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblReservation_ReservedBy"
                                    MessageBox.Show("This record is being reference by a record in item reservation list.")
                                    Me.Close()
                                Case "FK_tblConsume_CustomerID"
                                    MessageBox.Show("This record is being reference by a record in consumed inventory list.")
                                    Me.Close()
                                Case "FK_tblBorrow_CustomerID"
                                    MessageBox.Show("This record is being reference by a record in borrowed inventory list.")
                                    Me.Close()
                                Case "FK_tblStation_CustomerID"
                                    MessageBox.Show("This record is being reference by a record in stationed inventory list.")
                                    Me.Close()

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
