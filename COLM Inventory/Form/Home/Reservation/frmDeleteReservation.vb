Imports System.Data.SqlClient

Public Class frmDeleteReservation

    Private reservationDetails As ReservationDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(reservationDetails As ReservationDetails)
        If reservationDetails Is Nothing Then Throw New ArgumentNullException("reservationDetails")
        Me.reservationDetails = reservationDetails

        InitializeComponent()

        lblItemID.Text = "Item ID : " & Me.reservationDetails.Item.ItemID
        lblReservationID.Text = "Reservation ID : " & Me.reservationDetails.ReservationID
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_RESERVATION Then Exit Sub

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
                Using com As New SqlCommand("EXECUTE spDeleteReservation @Key, @ReservationID", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@ReservationID", reservationDetails.ReservationID)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "Not Exists"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "record"))
                                    Me.Close()
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
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
