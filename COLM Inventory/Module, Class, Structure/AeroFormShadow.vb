Imports System.Runtime.InteropServices

Public Class AeroFormShadow

    <DllImport("dwmapi.dll")>
    Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As Margins) As Integer
    End Function

    <DllImport("dwmapi.dll")>
    Public Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal attr As Integer, ByRef attrValue As Integer, ByVal attrSize As Integer) As Integer
    End Function

    <DllImport("dwmapi.dll")>
    Public Shared Function DwmIsCompositionEnabled(ByRef pfEnabled As Integer) As Integer
    End Function

    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Public Shared Function CreateRoundRectRgn(ByVal Left As Integer, ByVal Top As Integer, ByVal Right As Integer, ByVal Bottom As Integer, ByVal WidthEllipse As Integer, ByVal HeightEllipse As Integer) As IntPtr
    End Function

    Public Shared Function IsAeroEnabled() As Boolean
        If Environment.OSVersion.Version.Major >= 6 Then
            Dim enabled As Integer = 0
            DwmIsCompositionEnabled(enabled)
            Return If(enabled = 1, True, False)
        End If
        Return False
    End Function

End Class

''' <summary>
''' This structure is used by DwmExtendFrameIntoClientArea.
''' </summary>
Public Structure Margins

    Public Property Left As Integer
    Public Property Right As Integer
    Public Property Top As Integer
    Public Property Bottom As Integer

    Public Sub New(left As Integer, right As Integer, top As Integer, bottom As Integer)
        Me.Left = left
        Me.Top = top
        Me.Right = right
        Me.Bottom = bottom
    End Sub

End Structure
