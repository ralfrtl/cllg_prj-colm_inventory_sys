Imports System.Data.SqlClient

Public Class ConsumeDetails

    Private existsVal As Boolean = True
    Private isCompletedVal As Boolean = False
    Private isCancelledVal As Boolean = False
    Private isFaultedVal As Boolean = False
    Private isDisconnectedVal As Boolean = False

    Public ConsumeID As Integer
    Public Customer As New CustomerDetails
    Public Inventory As New InventoryDetails
    Public Good As Integer
    Public Damaged As Integer

    Public ReadOnly Property Exists As Boolean
        Get
            Return existsVal
        End Get
    End Property

    Public ReadOnly Property IsCancelled As Boolean
        Get
            Return isCancelledVal
        End Get
    End Property

    Public ReadOnly Property IsFaulted As Boolean
        Get
            Return isFaultedVal
        End Get
    End Property

    Public ReadOnly Property IsCompleted As Boolean
        Get
            Return isCompletedVal
        End Get
    End Property

    Public ReadOnly Property IsDisconnected As Boolean
        Get
            Return isDisconnectedVal
        End Get
    End Property

    Public Async Function LoadRecord() As Threading.Tasks.Task
        Await LoadRecord(Nothing)
    End Function

    Public Async Function LoadRecord(cancellationToken As Threading.CancellationToken) As Threading.Tasks.Task
        isCancelledVal = False
        isCompletedVal = False
        isDisconnectedVal = False
        isFaultedVal = False

        If cancellationToken.IsCancellationRequested Then
            isCancelledVal = True
            isCompletedVal = True
            Exit Function
        End If

        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT * FROM vwConsume WHERE ConsumeID = @a", con)
                    com.Parameters.AddWithValue("@a", ConsumeID)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cancellationToken)
                        If reader.Read Then
                            ConsumeID = reader("ConsumeID")

                            Customer.CustomerID = reader("CustomerID")
                            Customer.FirstName = reader("FirstName")
                            Customer.MiddleName = reader("MiddleName")
                            Customer.LastName = reader("LastName")
                            Customer.Position = reader("Position")
                            Customer.Department = reader("Department")
                            Customer.Offense = reader("Offense")

                            Inventory.ItemID = reader("ItemID")
                            Inventory.InventoryID = reader("InventoryID")
                            Inventory.Information = reader("Information")
                            Inventory.Store = reader("Store")
                            Inventory.ReceiptNo = reader("ReceiptNo")
                            Inventory.DateReceived = CType(reader("DateReceived"), DateTime)
                            Inventory.CostPerUnit = reader("CostPerUnit")
                            Inventory.Good = reader("Good")
                            Inventory.Damaged = reader("Damaged")

                            Good = reader("ConsumedGood")
                            Damaged = reader("ConsumedDamaged")

                            existsVal = True
                        Else
                            existsVal = False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            isCancelledVal = True
        Catch ex As InvalidOperationException
            isDisconnectedVal = True
        Catch ex As Exception
            isFaultedVal = True
        End Try

        isCompletedVal = True
    End Function

End Class
