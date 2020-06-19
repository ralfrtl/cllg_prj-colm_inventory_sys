Imports System.Data.SqlClient

Public Class ctrlReservation

    Private cts As New Threading.CancellationTokenSource

    Public Property ShowItemColumn As Boolean
        Get
            Return colItem.Visible
        End Get
        Set(value As Boolean)
            colItem.Visible = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
        tltp.SetToolTip(txtSearch.TextBox, tltp.GetToolTip(txtSearch))

        If Not ACCESS_RESERVATION Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not DesignMode Then
            cbtnMore_CheckedChanged(Nothing, Nothing)
            btnRefresh_Search_Click(Nothing, Nothing)
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.Shift Or Keys.A) Then
            btnAdd_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.E) Then
            btnEdit_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.D) Then
            btnDelete_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = Keys.F5 Then
            btnRefresh_Search_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.S) Then
            txtSearch.TextBox.Select()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Shift Or Keys.M) Then
            cbtnMore.Checked = Not cbtnMore.Checked
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub ctrlReservation_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        cts.Cancel()
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_RESERVATION Then Exit Sub

        If TryCast(Me.ParentForm, frmViewItem) IsNot Nothing Then
            Using addReservation As New frmAddReservation(TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails)
                addReservation.ShowDialog()
                Await TryCast(Me.ParentForm, frmViewItem).LoadItem
                TryCast(Me.ParentForm, frmViewItem).SelectTab(frmViewItem.Tab.Reservation)
                btnRefresh_Search_Click(Nothing, Nothing)
            End Using
        End If
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_RESERVATION Then Exit Sub
        If dgv.CurrentRow Is Nothing Then Exit Sub
        If TryCast(Me.ParentForm, frmViewItem) Is Nothing Then Exit Sub

        Dim reservationDetails As New ReservationDetails
        With reservationDetails
            .ReservationID = dgv.Item(colReservationID.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.CustomerID = dgv.Item(colCustomerID.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.FirstName = dgv.Item(colFirstName.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.MiddleName = dgv.Item(colMiddleName.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.LastName = dgv.Item(colLastName.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.Position = dgv.Item(colPosition.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.Department = dgv.Item(colDepartment.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.Offense = dgv.Item(colOffense.Index, dgv.CurrentRow.Index).Value
            .Item = TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails
            .QuantityNeeded = dgv.Item(colQuantityNeeded.Index, dgv.CurrentRow.Index).Value
            .DateNeeded = CType(dgv.Item(colDateNeeded.Index, dgv.CurrentRow.Index).Value, DateTime)
        End With

        Using editReservaion As New frmEditReservation(reservationDetails)
            editReservaion.ShowDialog()
            Await TryCast(Me.ParentForm, frmViewItem).LoadItem
            TryCast(Me.ParentForm, frmViewItem).SelectTab(frmViewItem.Tab.Reservation)
            btnRefresh_Search_Click(Nothing, Nothing)
        End Using
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not ACCESS_RESERVATION Then Exit Sub
        If dgv.CurrentRow Is Nothing Then Exit Sub
        If TryCast(Me.ParentForm, frmViewItem) Is Nothing Then Exit Sub

        Dim reservationDetails As New ReservationDetails
        With reservationDetails
            .ReservationID = dgv.Item(colReservationID.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.CustomerID = dgv.Item(colCustomerID.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.FirstName = dgv.Item(colFirstName.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.MiddleName = dgv.Item(colMiddleName.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.LastName = dgv.Item(colLastName.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.Position = dgv.Item(colPosition.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.Department = dgv.Item(colDepartment.Index, dgv.CurrentRow.Index).Value
            .ReservedBy.Offense = dgv.Item(colOffense.Index, dgv.CurrentRow.Index).Value
            .Item = TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails
            .QuantityNeeded = dgv.Item(colQuantityNeeded.Index, dgv.CurrentRow.Index).Value
            .DateNeeded = CType(dgv.Item(colDateNeeded.Index, dgv.CurrentRow.Index).Value, DateTime)
        End With

        Using deleteReservaion As New frmDeleteReservation(reservationDetails)
            deleteReservaion.ShowDialog()
            Await TryCast(Me.ParentForm, frmViewItem).LoadItem
            TryCast(Me.ParentForm, frmViewItem).SelectTab(frmViewItem.Tab.Reservation)
            btnRefresh_Search_Click(Nothing, Nothing)
        End Using
    End Sub

    Private Sub btnRefresh_Search_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, btnSearch.Click
        If TryCast(Me.ParentForm, frmViewItem) IsNot Nothing Then
            LoadRecordList(TryCast(Me.ParentForm, frmViewItem).parentCard.itemDetails.ItemID)
        End If
    End Sub

    Private Sub ctrlSearch_TextBoxKeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.OnTextBoxKeyUp
        If e.KeyData = Keys.Enter Then
            btnRefresh_Search_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cbtnMore_CheckedChanged(sender As Object, e As EventArgs) Handles cbtnMore.CheckedChanged
        If cbtnMore.Checked Then
            pnlFilter.Enabled = True
            pnlRibbon.Size = New Size(0, pnlFilter.Bottom + 5)
        Else
            pnlFilter.Enabled = False
            pnlRibbon.Size = New Size(0, pnlFilter.Top)
        End If
    End Sub

    Private Sub lblPreview_MouseEnter(sender As Object, e As EventArgs) Handles lblPreview.MouseEnter
        Dim find As String = IIf(cbtnMatchEveryField.Checked, "AND ", "OR ")
        tltp.SetToolTip(lblPreview, Replace(SearchFilter("<SearchKey>"), find, find & NXT))
    End Sub

    Private Async Sub LoadRecordList(itemID As Integer)
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        dgv.Rows.Clear()

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT " & IIf(numTop.Value = 0, "", "Top(" & numTop.Value & ")") & " * FROM vwReservation WHERE ItemID = @a AND (" & SearchFilter("@b") & ")", con)
                    com.Parameters.AddWithValue("@a", itemID)
                    com.Parameters.AddWithValue("@b", IIf(cbtnMatchWholeWord.Checked, txtSearch.Text, "%" & txtSearch.Text & "%"))
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        While Await reader.ReadAsync(cts.Token)
                            dgv.Rows.Add({reader("ReservationID"),
                                          "ID: " & reader("CustomerID") & NXT & "Name: " & reader("FirstName") & " " & reader("MiddleName") & " " & reader("LastName") & NXT & "Position: " & reader("Position") & NXT & "Department: " & reader("Department") & NXT & "No. of offense(s): " & reader("Offense"),
                                          reader("CustomerID"),
                                          reader("FirstName"),
                                          reader("MiddleName"),
                                          reader("LastName"),
                                          reader("Position"),
                                          reader("Department"),
                                          reader("Offense"),
                                          "ID: " & reader("ItemID") & NXT & "Name: " & reader("Name") & NXT & "Description: " & reader("Description") & NXT & "Item type: " & reader("ItemType") & NXT & "Unit type: " & reader("UnitType") & NXT & "Low threshold: " & reader("LowThreshold"),
                                          reader("ItemID"),
                                          reader("Name"),
                                          reader("Description"),
                                          reader("ItemType"),
                                          reader("UnitType"),
                                          reader("LowThreshold"),
                                          reader("QuantityNeeded"),
                                          reader("DateNeeded"),
                                          reader("Expired")})

                            If reader("Expired") = "True" Then
                                dgv.Rows.Item(dgv.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DimGray
                                dgv.Rows.Item(dgv.Rows.Count - 1).DefaultCellStyle.SelectionBackColor = Color.DimGray
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Exit Sub
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show("Failed to load item reservation list.", Color.FromArgb(230, 50, 50))
            End If
        End Try

        dgv.Select()
    End Sub

    Private Function SearchFilter(parameterVar As String) As String
        Dim searchOperator As String = IIf(cbtnMatchWholeWord.Checked, " = ", " LIKE ")
        Dim searchBinder As String = IIf(cbtnMatchEveryField.Checked, " AND ", " OR ")
        Dim defaultFilter As String = "ReservationID" & searchOperator & parameterVar & searchBinder &
                                      "CustomerID" & searchOperator & parameterVar & searchBinder &
                                      "FirstName" & searchOperator & parameterVar & searchBinder &
                                      "MiddleName" & searchOperator & parameterVar & searchBinder &
                                      "LastName" & searchOperator & parameterVar & searchBinder &
                                      "Position" & searchOperator & parameterVar & searchBinder &
                                      "Department" & searchOperator & parameterVar & searchBinder &
                                      "Offense" & searchOperator & parameterVar & searchBinder &
                                      "ItemID" & searchOperator & parameterVar & searchBinder &
                                      "Name" & searchOperator & parameterVar & searchBinder &
                                      "Description" & searchOperator & parameterVar & searchBinder &
                                      "ItemType" & searchOperator & parameterVar & searchBinder &
                                      "UnitType" & searchOperator & parameterVar & searchBinder &
                                      "LowThreshold" & searchOperator & parameterVar & searchBinder &
                                      "QuantityNeeded" & searchOperator & parameterVar & searchBinder &
                                      "DateNeeded" & searchOperator & parameterVar & searchBinder &
                                      "Expired" & searchOperator & parameterVar & searchBinder
        Dim filter = defaultFilter

        If cbtnFilter.Checked Then
            If Not cbtnCustomerID.Checked Then
                filter = filter.Replace("CustomerID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnFirstName.Checked Then
                filter = filter.Replace("FirstName" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnMiddleName.Checked Then
                filter = filter.Replace("MiddleName" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnLastName.Checked Then
                filter = filter.Replace("LastName" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnPosition.Checked Then
                filter = filter.Replace("Position" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDepartment.Checked Then
                filter = filter.Replace("Department" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnOffense.Checked Then
                filter = filter.Replace("Offense" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnItemID.Checked Then
                filter = filter.Replace("ItemID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnName.Checked Then
                filter = filter.Replace("Name" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDescription.Checked Then
                filter = filter.Replace("Description" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnItemType.Checked Then
                filter = filter.Replace("ItemType" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnUnitType.Checked Then
                filter = filter.Replace("UnitType" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnLowThreshold.Checked Then
                filter = filter.Replace("LowThreshold" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnReservationID.Checked Then
                filter = filter.Replace("ReservationID" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnQuantityNeeded.Checked Then
                filter = filter.Replace("QuantityNeeded" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnDateNeeded.Checked Then
                filter = filter.Replace("DateNeeded" & searchOperator & parameterVar & searchBinder, "")
            End If
            If Not cbtnExpired.Checked Then
                filter = filter.Replace("Expired" & searchOperator & parameterVar & searchBinder, "")
            End If
        End If

        If filter.Length = 0 Then
            filter = defaultFilter
        End If

        filter = filter.Remove(filter.Length - searchBinder.Length, searchBinder.Length)

        Return filter
    End Function

    Friend Sub SelectList()
        dgv.Select()
    End Sub

End Class
