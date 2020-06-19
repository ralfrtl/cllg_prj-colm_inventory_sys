Imports System.Data.SqlClient

Public Class ctrlDashboard

    Private cts As New Threading.CancellationTokenSource

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()

        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Async Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not DesignMode Then
            Await LoadDashboard()
        End If
    End Sub

    Private Async Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Await LoadDashboard()
    End Sub

    Private Async Function LoadDashboard() As Threading.Tasks.Task
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT * FROM vwDashboard", con)
                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            crdItem.Text = reader("Item")
                            crdInventory.Text = reader("Inventory")
                            crdAsset.Text = reader("Asset")
                            crdAssetBulk.Text = reader("AssetBulk")
                            crdConsumable.Text = reader("Consumable")
                            crdReserved.Text = reader("Reserved")
                            crdBorrowed.Text = reader("Borrowed")
                            crdStationed.Text = reader("Stationed")
                            crdLow.Text = reader("Low")
                            crdOut.Text = reader("Out")
                        Else
                            crdItem.Text = 0
                            crdInventory.Text = 0
                            crdAsset.Text = 0
                            crdAssetBulk.Text = 0
                            crdConsumable.Text = 0
                            crdReserved.Text = 0
                            crdBorrowed.Text = 0
                            crdStationed.Text = 0
                            crdLow.Text = 0
                            crdOut.Text = 0
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Exit Function
        Catch ex As Exception
            If Not ex.Message.Contains("Operation cancelled by user.") Then
                Notification.Show("Failed to load dashboard content.", Color.FromArgb(230, 50, 50))
            End If
        End Try
    End Function

End Class
