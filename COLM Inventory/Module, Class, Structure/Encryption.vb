Imports System.Security.Cryptography
Imports System.Text

Public Class Encryption

    Public Shared Function SHA1(text As String) As String
        Dim sha As SHA1 = SHA1Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(text)
        Dim hash As Byte() = sha.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function

    Public Shared Function SHA256(text As String) As String
        Dim sha As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(text)
        Dim hash As Byte() = sha.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function

    Public Shared Function SHA384(text As String) As String
        Dim sha As SHA384 = SHA384Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(text)
        Dim hash As Byte() = sha.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function

    Public Shared Function SHA512(text As String) As String
        Dim sha As SHA512 = SHA512Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(text)
        Dim hash As Byte() = sha.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function

End Class
