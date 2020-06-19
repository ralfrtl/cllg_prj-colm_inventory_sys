Imports System.Data.SqlClient

Public Class frmViewCustomer

    Private WithEvents parentCard As ctrlCustomerCard
    Private cts As New Threading.CancellationTokenSource

    Public Sub New(parentCard As ctrlCustomerCard)
        If parentCard Is Nothing Then Throw New ArgumentNullException("parentCard")
        Me.parentCard = parentCard

        InitializeComponent()

        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))

        If Not ACCESS_CUSTOMER Then
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnAddOffense.Enabled = False
            btnEditOffense.Enabled = False
        End If
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Protected Overrides Async Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Await LoadCustomer()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.Shift Or Keys.Alt Or Keys.E) Then
            btnEdit_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.Alt Or Keys.D) Then
            btnDelete_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.A) Then
            btnAddOffense_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.E) Then
            btnEditOffense_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = Keys.F5 Then
            LoadRecordList()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.S) Then
            txtSearch.TextBox.Select()
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub parentCard_Disposed(sender As Object, e As EventArgs) Handles parentCard.Disposed
        Me.Dispose()
    End Sub

#Region "CustomerDetails"

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_CUSTOMER Then Exit Sub

        Using editCustomer As New frmEditCustomer(parentCard.customerDetails)
            editCustomer.ShowDialog()
            Await LoadCustomer()
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_CUSTOMER Then Exit Sub

        Using deleteCustomer As New frmDeleteCustomer(parentCard.customerDetails)
            If deleteCustomer.ShowDialog() = DialogResult.OK Then
                parentCard.Dispose()
            End If
        End Using
    End Sub

    Private Async Function LoadCustomer() As Threading.Tasks.Task
        Using l As New ctrlLoadingScreen(Me, "Loading", Sub()
                                                            Me.Hide()
                                                            Me.Close()
                                                        End Sub)
            If Not Await LoadRecord() Then Exit Function

            PrintRecord()
            parentCard.PrintRecord()
            LoadRecordList()
        End Using
    End Function

    Private Async Function LoadRecord() As Threading.Tasks.Task(Of Boolean)
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Await parentCard.customerDetails.LoadRecord(cts.Token)

        If parentCard.customerDetails.IsCancelled Then
            Return False
        ElseIf parentCard.customerDetails.IsDisconnected Or parentCard.customerDetails.IsFaulted Then
            Notification.Show("Failed to load customer details.", Color.FromArgb(230, 50, 50))
        ElseIf Not parentCard.customerDetails.Exists Then
            Notification.Show(String.Format(CODE_NOT_EXISTS, "customer#" & parentCard.customerDetails.CustomerID), Color.FromArgb(230, 50, 50))
            parentCard.Dispose()
            Return False
        End If

        Return True
    End Function

    Private Sub PrintRecord()
        lblFullName.Text = parentCard.customerDetails.FirstName & " " & parentCard.customerDetails.MiddleName & " " & parentCard.customerDetails.LastName
        lblCustomerID.Text = "ID : " & parentCard.customerDetails.CustomerID
        lblPosition.Text = "Position : " & parentCard.customerDetails.Position
        lblDepartment.Text = "Department : " & parentCard.customerDetails.Department
        lblOffense.Text = "No. of offense(s) : " & parentCard.customerDetails.Offense
    End Sub

#End Region

#Region "CustomerOffense"

    Private Async Sub btnAddOffense_Click(sender As Object, e As EventArgs) Handles btnAddOffense.Click
        If Not ACCESS_CUSTOMER Then Exit Sub

        Using addCustomerOffense As New frmAddCustomerOffense(parentCard.customerDetails)
            addCustomerOffense.ShowDialog()
            Await LoadCustomer()
        End Using
    End Sub

    Private Async Sub btnEditOffense_Click(sender As Object, e As EventArgs) Handles btnEditOffense.Click
        If Not ACCESS_CUSTOMER Then Exit Sub
        If dgv.CurrentRow Is Nothing Then Exit Sub

        Dim customerOffenseDetails As New CustomerOffenseDetails
        With customerOffenseDetails
            .OffenseID = dgv.Item(colOffenseID.Index, dgv.CurrentRow.Index).Value
            .CustomerID = parentCard.customerDetails.CustomerID
            .Information = dgv.Item(colInformation.Index, dgv.CurrentRow.Index).Value
            .Settled = dgv.Item(colSettled.Index, dgv.CurrentRow.Index).Value
        End With

        Using editCustomerOffense As New frmEditCustomerOffense(customerOffenseDetails)
            editCustomerOffense.ShowDialog()
            Await LoadCustomer()
        End Using
    End Sub

    Private Sub btnRefresh_Search_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, btnSearch.Click
        LoadRecordList()
    End Sub

    Private Sub ctrlSearch_TextBoxKeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.OnTextBoxKeyUp
        If e.KeyData = Keys.Enter Then
            LoadRecordList()
        End If
    End Sub

    Private Async Sub LoadRecordList()
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        dgv.Rows.Clear()

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT * FROM vwCustomerOffense WHERE CustomerID = @a AND (OffenseID LIKE @b OR Information LIKE @b OR Settled LIKE @b) ORDER BY Settled ASC", con)
                    com.Parameters.AddWithValue("@a", parentCard.customerDetails.CustomerID)
                    com.Parameters.AddWithValue("@b", "%" & txtSearch.Text & "%")

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            dgv.Rows.Add({reader("OffenseID"),
                                         reader("Information"),
                                         reader("Settled")})
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Exit Sub
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show("Failed to load customer offense list.", Color.FromArgb(230, 50, 50))
            End If
        End Try

        dgv.Select()
    End Sub

#End Region

End Class
