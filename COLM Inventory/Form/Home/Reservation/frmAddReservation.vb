Imports System.Data.SqlClient

Public Class frmAddReservation

    Private itemDetails As ItemDetails
    Private customerDetails As CustomerDetails
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(itemDetails As ItemDetails)
        If itemDetails Is Nothing Then Throw New ArgumentNullException("itemDetails")
        Me.itemDetails = itemDetails

        InitializeComponent()

        PrintItem()
        dtpDateNeeded.MinDate = DateTime.Now
        lblReservedBy.Select()
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

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_RESERVATION Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Adding record", Sub() cts.Cancel())
            err.Clear()

            If customerDetails Is Nothing Then
                err.SetError(btnSelectCustomer, CODE_ERR)
                Exit Sub
            End If

            Await AddRecord()
        End Using

        lblReservedBy.Select()
    End Sub

    Private Async Function AddRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spInsertReservation @Key, @ReservedBy, @ItemID, @QuantityNeeded, @DateNeeded", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@ReservedBy", customerDetails.CustomerID)
                    com.Parameters.AddWithValue("@ItemID", itemDetails.ItemID)
                    com.Parameters.AddWithValue("@QuantityNeeded", numQuantityNeeded.Value)
                    com.Parameters.AddWithValue("@DateNeeded", dtpDateNeeded.Value)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "FK_tblReservation_ReservedBy"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "customer"))
                                    customerDetails = Nothing
                                    PrintCustomer()
                                Case "FK_tblReservation_ItemID"
                                    MessageBox.Show(String.Format(CODE_NOT_EXISTS, "item that is associated with this record"))
                                    Me.Close()

                                Case "QuantityNeeded"
                                    err.SetError(numQuantityNeeded, CODE_ERR_NUM)

                                Case "Exists"
                                    MessageBox.Show(CODE_EXISTS)
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    MessageBox.Show("Log:" & NXT & NXT &
                                                    reader("LOG"))

                                    customerDetails = Nothing
                                    PrintCustomer()
                                    numQuantityNeeded.Value = 1
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
        lblItemIDVal.Text = itemDetails.ItemID
        lblItemNameVal.Text = itemDetails.Name
        lblItemDescriptionVal.Text = itemDetails.Description
        lblItemTypeVal.Text = itemDetails.ItemType
        lblUnitTypeVal.Text = itemDetails.UnitType
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
