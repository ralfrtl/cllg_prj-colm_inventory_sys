Imports System.Data.SqlClient

Public Class ItemDetails

    Private existsVal As Boolean = True
    Private isCompletedVal As Boolean = False
    Private isCancelledVal As Boolean = False
    Private isFaultedVal As Boolean = False
    Private isDisconnectedVal As Boolean = False

    Public ItemID As Integer
    Public Name As String
    Public Description As String
    Public ItemType As String
    Public UnitType As String
    Public LowThreshold As Integer
    Public Total As Integer
    Public Available As Integer
    Public Borrowed As Integer
    Public Stationed As Integer
    Public Reserved As Integer
    Public Good As Integer
    Public Damaged As Integer
    Public Maintenance As Integer
    Public Replacement As Integer

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
                Using com As New SqlCommand("SELECT * FROM vwItem WHERE ItemID = @a", con)
                    com.Parameters.AddWithValue("@a", ItemID)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cancellationToken)
                        If reader.Read() Then
                            ItemID = reader("ItemID")
                            Name = reader("Name")
                            Description = reader("Description")
                            ItemType = reader("ItemType")
                            UnitType = reader("UnitType")
                            LowThreshold = reader("LowThreshold")
                            Total = reader("Total")
                            Available = reader("Available")
                            Borrowed = reader("Borrowed")
                            Stationed = reader("Stationed")
                            Reserved = reader("Reserved")
                            Good = reader("Good")
                            Damaged = reader("Damaged")
                            Maintenance = reader("Maintenance")
                            Replacement = reader("Replacement")

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
