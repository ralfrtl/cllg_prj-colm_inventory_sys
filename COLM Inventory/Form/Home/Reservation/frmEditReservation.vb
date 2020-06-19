Imports System.Data.SqlClient

Public Class frmEditReservation

    Private reservationDetails As ReservationDetails
    Private customerDetails As CustomerDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(reservationDetails As ReservationDetails)
        If reservationDetails Is Nothing Then Throw New ArgumentNullException("reservationDetails")
        Me.reservationDetails = reservationDetails
        customerDetails = reservationDetails.ReservedBy

        InitializeComponent()

        PrintItem()
        PrintCustomer()
        txtReservationID.Text = reservationDetails.ReservationID
        numQuantityNeeded.Value = reservationDetails.QuantityNeeded
        dtpDateNeeded.MinDate = DateAdd(DateInterval.Month, -1, DateTime.Now)
        dtpDateNeeded.Value = reservationDetails.DateNeeded
        lblCustomer.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Sub btnSelectCustomer_Click(sender As Object, e As EventArgs) Handles btnSelectCustomer.Click
        Using selectCustomer As New frmSelectCustomer()
            selectCustomer.ShowDialog()
            customerDetails = selectCustomer.SelectedCustomer
            PrintCustomer()
        End Using
    End Sub

    Private Sub numQuantityNeeded_ValueChanged(sender As Object, e As EventArgs) Handles numQuantityNeeded.ValueChanged
        Dim diff As Integer = numQuantityNeeded.Value - reservationDetails.QuantityNeeded

        lblQuantityNeededDiff.Text = IIf(diff > 0, "+", "") & IIf(diff <> 0, diff, "")
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_RESERVATION Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()

            If customerDetails Is Nothing Then
                err.SetError(btnSelectCustomer, CODE_ERR)
                Exit Sub
            End If

            If reservationDetails.ReservedBy.CustomerID = customerDetails.CustomerID And reservationDetails.QuantityNeeded = numQuantityNeeded.Value And reservationDetails.DateNeeded = dtpDateNeeded.Value Then
                MessageBox.Show(CODE_SAME)
                Exit Sub
            End If

            If customerDetails.Offense > 0 Then
                If MessageBox.Show("The customer that you have selected has unsettled offense(s)." & NXT & NXT & "Do you still want to proceed?") = DialogResult.OK Then
                    Await EditRecord()
                End If
            Else
                Await EditRecord()
            End If
        End Using

        lblCustomer.Select()
    End Sub

    Private Async Function EditRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spUpdateReservation @Key, @ReservationID, @ReservedBy, @ItemID, @QuantityNeeded, @DateNeeded", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@ReservationID", reservationDetails.ReservationID)
                    com.Parameters.AddWithValue("@ReservedBy", customerDetails.CustomerID)
                    com.Parameters.AddWithValue("@ItemID", reservationDetails.Item.ItemID)
                    com.Parameters.AddWithValue("@QuantityNeeded", numQuantityNeeded.Value)
                    com.Parameters.AddWithValue("@DateNeeded", dtpDateNeeded.Value)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblReservation_ReservedBy"
                                    If customerDetails.CustomerID <> reservationDetails.ReservedBy.CustomerID Then
                                        MessageBox.Show(String.Format(CODE_NOT_EXISTS, "customer") & NXT & NXT & "Reverting back to the current customer.")
                                        customerDetails = reservationDetails.ReservedBy
                                        PrintCustomer()
                                    Else
                                        MessageBox.Show(String.Format(CODE_NOT_EXISTS, "customer that is associated with this record"))
                                        Me.Close()
                                    End If
                                Case "FK_tblReservation_ItemID"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "item that is associated with this record"))
                                    Me.Close()

                                Case "QuantityNeeded"
                                    err.SetError(numQuantityNeeded, CODE_ERR_NUM)

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

    Private Sub PrintItem()
        lblItemIDVal.Text = reservationDetails.Item.ItemID
        lblItemNameVal.Text = reservationDetails.Item.Name
        lblItemDescriptionVal.Text = reservationDetails.Item.Description
        lblItemTypeVal.Text = reservationDetails.Item.ItemType
        lblUnitTypeVal.Text = reservationDetails.Item.UnitType
    End Sub

    Private Sub PrintCustomer()
        If customerDetails IsNot Nothing Then
            lblCustomerIDVal.Text = customerDetails.CustomerID
            lblCustomerNameVal.Text = customerDetails.FirstName & " " & customerDetails.MiddleName & " " & customerDetails.LastName
            lblCustomerDepartmentVal.Text = customerDetails.Department
            lblCustomerPositionVal.Text = customerDetails.Position
            lblCustomerOffenseVal.Text = customerDetails.Offense
        Else
            lblCustomerIDVal.Text = ""
            lblCustomerNameVal.Text = ""
            lblCustomerDepartmentVal.Text = ""
            lblCustomerPositionVal.Text = ""
            lblCustomerOffenseVal.Text = ""
        End If
    End Sub

End Class
