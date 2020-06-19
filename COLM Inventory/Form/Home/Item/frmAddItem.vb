Imports System.Data.SqlClient

Public Class frmAddItem

    Private cts As New Threading.CancellationTokenSource

    Public Sub New()
        InitializeComponent()

        lblName.Select()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        cts.Cancel()
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ACCESS_ITEM Then Exit Sub

        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Using l As New ctrlLoadingScreen(Me, "Adding record", Sub() cts.Cancel())
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

            Await AddRecord()
        End Using

        lblName.Select()
    End Sub

    Private Async Function AddRecord() As Threading.Tasks.Task
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spInsertItem @Key, @Name, @Description, @ItemType, @UnitType, @LowThreshold", con)
                    com.Parameters.AddWithValue("@Key", SESSION_KEY)
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

                                Case "Exists"
                                    MessageBox.Show(CODE_EXISTS)
                                Case "Failed"
                                    MessageBox.Show(CODE_FAILED)
                                    Me.Close()
                                Case "Successful"
                                    Notification.Show(CODE_SUCCESS, Color.Green)
                                    MessageBox.Show("Log:" & NXT & NXT &
                                                    reader("LOG"))

                                    txtName.Text = ""
                                    txtDescription.Text = ""
                                    cmbItemType.SelectedIndex = -1
                                    txtUnitType.Text = ""
                                    numLowThreshold.Value = 0
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
