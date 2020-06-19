Imports System.Data.SqlClient

Public Class frmEditItem

    Private itemDetails As ItemDetails
    Private cts As New Threading.CancellationTokenSource
    Private password As String = Nothing

    Public Sub New(itemDetails As ItemDetails)
        If itemDetails Is Nothing Then Throw New ArgumentNullException("itemDetails")
        Me.itemDetails = itemDetails

        InitializeComponent()

        txtItemID.Text = itemDetails.ItemID
        txtName.Text = itemDetails.Name
        txtDescription.Text = itemDetails.Description
        cmbItemType.Text = itemDetails.ItemType
        txtUnitType.Text = itemDetails.UnitType
        numLowThreshold.Value = itemDetails.LowThreshold
        lblName.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not ACCESS_ITEM Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Modifying record", Sub() cts.Cancel())
            err.Clear()
            Dim errCount As Integer = 0

            If Not txtName.IsValid Then
                err.SetError(txtName, CODE_ERR_TEXT)
                errCount += 1
            End If

            If Not txtDescription.IsValid Then
                err.SetError(txtDescription, CODE_ERR_TEXT)
                errCount += 1
            End If

            If Not cmbItemType.isValid Then
                err.SetError(cmbItemType, CODE_ERR)
                errCount += 1
            End If

            If Not txtUnitType.IsValid Then
                err.SetError(txtUnitType, CODE_ERR_TEXT)
                errCount += 1
            End If

            If errCount > 0 Then Exit Sub

            If txtName.Text <> itemDetails.Name Or txtDescription.Text <> itemDetails.Description Or cmbItemType.SelectedItem <> itemDetails.ItemType Or txtUnitType.Text <> itemDetails.UnitType Or numLowThreshold.Value <> itemDetails.LowThreshold Then
                If cmbItemType.SelectedItem <> itemDetails.ItemType Then
                    If MessageBox.Show("Changing the item type of this record will delete the records that rely on it." & NXT & NXT &
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
                                Await EditRecord()
                                password = Nothing
                            End If
                        End Using
                    End If
                Else
                    Await EditRecord()
                End If
            Else
                MessageBox.Show(CODE_SAME)
            End If
        End Using

        lblName.Select()
    End Sub

    Private Async Function EditRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spUpdateItem @Key, @LogPassword, @ItemID, @Name, @Description, @ItemType, @UnitType, @LowThreshold", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
                    com.Parameters.AddWithValue("@LogPassword", password)
                    com.Parameters.AddWithValue("@ItemID", itemDetails.ItemID)
                    com.Parameters.AddWithValue("@Name", txtName.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@Description", txtDescription.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@ItemType", "" & cmbItemType.Text)
                    com.Parameters.AddWithValue("@UnitType", txtUnitType.Text.TrimConsecutive)
                    com.Parameters.AddWithValue("@LowThreshold", numLowThreshold.Value)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Not Permitted"
                                    MessageBox.Show(CODE_NOT_PERMITTED)
                                    Application.Restart()

                                Case "Name"
                                    err.SetError(txtName, CODE_ERR_TEXT)
                                Case "Description"
                                    err.SetError(txtDescription, CODE_ERR_TEXT)
                                Case "ItemType"
                                    err.SetError(cmbItemType, CODE_ERR)
                                Case "UnitType"
                                    err.SetError(txtUnitType, CODE_ERR_TEXT)
                                Case "LowThreshold"
                                    err.SetError(numLowThreshold, CODE_ERR_NUM)
                                Case "LogPassword"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()

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

End Class
