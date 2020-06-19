Imports System.Data.SqlClient

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Partial Class MyApplication

        Private Async Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            Try
                Using con As New SqlConnection(CONNECTION_STRING)
                    con.Open()
                    Using com As New SqlCommand("spInsertActivityLog", con)
                        com.CommandType = CommandType.StoredProcedure
                        com.Parameters.AddWithValue("@Key", SESSION_KEY)
                        com.Parameters.AddWithValue("@Activity", "Logged out.")
                        com.Parameters.AddWithValue("@Details", DBNull.Value)
                        Await com.ExecuteScalarAsync()
                    End Using
                End Using
            Catch ex As Exception
            End Try

            Try
                With My.Computer.FileSystem
                    If Not .DirectoryExists(.SpecialDirectories.MyDocuments & "/InventoryManagement/") Then
                        .CreateDirectory(.SpecialDirectories.MyDocuments & "/InventoryManagement/")
                    End If

                    If Not .FileExists(.SpecialDirectories.MyDocuments & "/InventoryManagement/Log.txt") Then
                        .WriteAllText(.SpecialDirectories.MyDocuments & "/InventoryManagement/Log.txt", USERNAME & " : Logout : " & DateTime.Now.ToString("MMMM dd, yyyy   HH:mm:ss tt"), True)
                    Else
                        .WriteAllText(.SpecialDirectories.MyDocuments & "/InventoryManagement/Log.txt", NXT & USERNAME & " : Logout : " & DateTime.Now.ToString("MMMM dd, yyyy   HH:mm:ss tt"), True)
                    End If
                End With
            Catch ex As Exception
            End Try
        End Sub

    End Class

End Namespace
