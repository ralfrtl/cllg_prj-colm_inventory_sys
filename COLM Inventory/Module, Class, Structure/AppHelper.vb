Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Module Session

    Public CONNECTION_STRING As String = My.Settings.DBConnection

    Public SESSION_KEY As String = ""
    Public USER_ID As Integer = 0
    Public USERNAME As String = ""
    Public PERMISSION_NAME As String = ""
    Public ACCESS_USER As Boolean = False
    Public ACCESS_PERMISSION As Boolean = False
    Public ACCESS_CUSTOMER As Boolean = False
    Public ACCESS_ITEM As Boolean = False
    Public ACCESS_INVENTORY As Boolean = False
    Public ACCESS_RESERVATION As Boolean = False
    Public ACCESS_CONSUME As Boolean = False
    Public ACCESS_BORROW As Boolean = False
    Public ACCESS_STATION As Boolean = False

    ''' <summary>
    ''' Checks if the application is connected to the server.
    ''' </summary>
    ''' <returns>True if connected; Otherwise false.</returns>
    Public Function IsServerUp() As Boolean
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()

                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module

Public Module [String]

    ''' <summary>
    ''' Adds a next line.
    ''' </summary>
    Public ReadOnly NXT As String = ChrW(13) & ChrW(10)

    ''' <summary>
    ''' Filler text.
    ''' </summary>
    Public ReadOnly LOREM As String = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."

    Public ReadOnly CODE_NOT_PERMITTED As String = "There is a problem regarding your account information." & NXT & NXT & "The application will restart, please login again."
    Public ReadOnly CODE_ERR As String = "Required."
    Public ReadOnly CODE_ERR_TEXT As String = "The field must be equal or greater than 1 non-whitespace character."
    Public ReadOnly CODE_ERR_NUM As String = "The field must be equal or greater than 0."
    Public ReadOnly CODE_SAME As String = "The given data and the current record details are the same."
    Public ReadOnly CODE_EXISTS As String = "A similar record already exist."
    Public ReadOnly CODE_NOT_EXISTS As String = "The {0} does not or no longer exist."
    Public ReadOnly CODE_FAILED As String = "Action failed." & NXT & NXT &
                                            "This could be the result of one of this:" & NXT &
                                            "-    Some parameter is required or invalid." & NXT &
                                            "-    The record has been modified by a different transaction." & NXT &
                                            "-    The connection is disconnected or interrupted." & NXT &
                                            "-    The action took so long to get executed." & NXT &
                                            "-    Unhandled server error."
    Public ReadOnly CODE_SUCCESS As String = "Action successful."
    Public ReadOnly CODE_ELSE As String = "Server Error" & NXT & NXT & "Error details:" & NXT

    ''' <summary>
    ''' InvalidOperationException
    ''' </summary>
    Public ReadOnly ERR_CON As String = "No connection."

    ''' <summary>
    ''' Exception
    ''' </summary>
    Public ReadOnly ERR_ELSE As String = "Error."

End Module

Public Module Audio

    ''' <summary>
    ''' Sounds a tone through the computer's speaker.
    ''' </summary>
    Public Sub BEEP_ALERT()
        Try
            My.Computer.Audio.Play(My.Resources.Alert, AudioPlayMode.Background)
        Catch ex As Exception
            Beep()
        End Try
    End Sub

End Module

Public Module Extension

    ''' <summary>
    ''' Validates the textbox if the input is null, empty, or whitespace.
    ''' </summary>
    ''' <param name="control">The control to validate.</param>
    ''' <returns>True if input is valid; Otherwise false.</returns>
    <Extension>
    Public Function IsValid(control As TextBox) As Boolean
        Return Not String.IsNullOrWhiteSpace(control.Text)
    End Function

    ''' <summary>
    ''' Validates the control if there is a selected item.
    ''' </summary>
    ''' <param name="control">The control to validate.</param>
    ''' <returns>True if an item is selected; Otherwise false.</returns>
    <Extension>
    Public Function isValid(control As ComboBox) As Boolean
        If control.SelectedIndex >= 0 Then
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' Removes all space, tab, and new line of the text.
    ''' </summary>
    ''' <param name="text">The text to trim.</param>
    ''' <returns>True if an item is selected; Otherwise false.</returns>
    <Extension>
    Public Function TrimAll(text As String) As String
        text = Replace(text, " ", "")
        text = Replace(text, ChrW(9), "")
        text = Replace(text, NXT, "")

        If text Is Nothing Then text = ""

        Return text
    End Function

    ''' <summary>
    ''' Removes all consecutive space, tab, and new line of the text.
    ''' </summary>
    ''' <param name="text">The text to trim.</param>
    ''' <returns>True if an item is selected; Otherwise false.</returns>
    <Extension>
    Public Function TrimConsecutive(text As String) As String
        text = "" & text

        While text.Contains("  ")
            text = Replace(text, "  ", "")
        End While

        While text.Contains(ChrW(9) & ChrW(9))
            text = Replace(text, ChrW(9) & ChrW(9), ChrW(9))
        End While

        While text.Contains(NXT & NXT)
            text = Replace(text, NXT & NXT, NXT)
        End While

        If text Is Nothing Then text = ""

        Return text
    End Function

End Module
