
Imports System.Data.SqlClient

Public Class CustomerDetails

    Private existsVal As Boolean = True
    Private isCompletedVal As Boolean = False
    Private isCancelledVal As Boolean = False
    Private isFaultedVal As Boolean = False
    Private isDisconnectedVal As Boolean = False

    Public CustomerID As Integer
    Public FirstName As String
    Public MiddleName As String
    Public LastName As String
    Public Position As String
    Public Department As String
    Public Offense As Integer

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
                Using com As New SqlCommand("SELECT * FROM vwCustomer WHERE CustomerID = @a", con)
                    com.Parameters.AddWithValue("@a", CustomerID)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cancellationToken)
                        If reader.Read Then
                            CustomerID = reader("CustomerID")
                            FirstName = reader("FirstName")
                            MiddleName = reader("MiddleName")
                            LastName = reader("LastName")
                            Position = reader("Position")
                            Department = reader("Department")
                            Offense = reader("Offense")

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
