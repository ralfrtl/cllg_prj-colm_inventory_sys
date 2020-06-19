
Public Class Dummy1 : Inherits Form

    'This is a truly borderless form with aero drop shodow
    'One issue with this is that the built-in SysMenu is not working and the controls flicker on startup


    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams

            If Not AeroFormShadow.IsAeroEnabled Then
                cp.ClassStyle = cp.ClassStyle Or WindowsMessage.ClassStyles.CS_DropShadow
            End If

            '   This conflicts with WndProc()
            'cp.Style = cp.Style Or WindowsMessage.WindowStyles.WS_SYSMENU

            cp.Style = cp.Style Or WindowsMessage.WindowStyles.WS_MINIMIZEBOX

            'cp.ExStyle = cp.ExStyle Or WindowsMessage.WindowStylesEx.WS_EX_TOOLWINDOW

            Return cp
        End Get
    End Property
    Protected Overrides Sub WndProc(ByRef m As Message)
        Me.MaximumSize = Screen.FromControl(Me).WorkingArea.Size
        Dim sizeScope As Integer = 5
        Dim titlebarRec As New Rectangle(sizeScope, sizeScope, Me.DisplayRectangle.Right - sizeScope, Me.DisplayRectangle.Top + 30 - sizeScope)
        Dim topRec As New Rectangle(0, 0, Me.Width, sizeScope)
        Dim bottomRec As New Rectangle(0, Me.DisplayRectangle.Bottom - sizeScope, Me.Width, sizeScope)
        Dim leftRec As New Rectangle(0, 0, sizeScope, Me.Height)
        Dim rightRec As New Rectangle(Me.Width - sizeScope, 0, sizeScope, Me.Height)
        Dim isMax As Boolean = Me.WindowState = FormWindowState.Maximized

        Select Case m.Msg
            Case WindowsMessage.WndMsg.WM_NCHITTEST
                Dim cursorLoc As New Point(Me.PointToClient(New Point(m.LParam.ToInt32)))

                If titlebarRec.Contains(cursorLoc) Then
                    m.Result = WindowsMessage.HitTest.HT_CAPTION
                    Return
                ElseIf topRec.Contains(cursorLoc) And leftRec.Contains(cursorLoc) And Not isMax Then
                    m.Result = WindowsMessage.HitTest.HT_TOPLEFT
                    Return
                ElseIf topRec.Contains(cursorLoc) And rightRec.Contains(cursorLoc) And Not isMax Then
                    m.Result = WindowsMessage.HitTest.HT_TOPRIGHT
                    Return
                ElseIf bottomRec.Contains(cursorLoc) And leftRec.Contains(cursorLoc) And Not isMax Then
                    m.Result = WindowsMessage.HitTest.HT_BOTTOMLEFT
                    Return
                ElseIf bottomRec.Contains(cursorLoc) And rightRec.Contains(cursorLoc) And Not isMax Then
                    m.Result = WindowsMessage.HitTest.HT_BOTTOMRIGHT
                    Return
                ElseIf topRec.Contains(cursorLoc) And Not isMax Then
                    m.Result = WindowsMessage.HitTest.HT_TOP
                    Return
                ElseIf bottomRec.Contains(cursorLoc) And Not isMax Then
                    m.Result = WindowsMessage.HitTest.HT_BOTTOM
                    Return
                ElseIf leftRec.Contains(cursorLoc) And Not isMax Then
                    m.Result = WindowsMessage.HitTest.HT_LEFT
                    Return
                ElseIf rightRec.Contains(cursorLoc) And Not isMax Then
                    m.Result = WindowsMessage.HitTest.HT_RIGHT
                    Return
                End If
            Case WindowsMessage.WndMsg.WM_NCLBUTTONUP
                '   TODO: Send SysCommand (Minimize, Maximize, Restore, Close)
                '   EX: Me.WndProc(Message.Create(Me.Handle, WM_SYSCOMMAND, SysCommand.SC_MAXIMIZE, IntPtr.Zero))
            Case WindowsMessage.WndMsg.WM_NCRBUTTONUP
                'TODO: SysMenu
            Case WindowsMessage.WndMsg.WM_NCMOUSEMOVE
                '   TODO: ToolTip
            Case WindowsMessage.WndMsg.WM_GETSYSMENU
                'TODO: SysMenu
            Case WindowsMessage.WndMsg.WM_NCPAINT
                If AeroFormShadow.IsAeroEnabled Then
                    AeroFormShadow.DwmSetWindowAttribute(Me.Handle, 2, 2, 4)
                    AeroFormShadow.DwmExtendFrameIntoClientArea(Me.Handle, New Margins(0, 0, 0, 1))
                End If
            Case Else
        End Select

        MyBase.WndProc(m)
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Alt Or Keys.Space) Then
            'TODO: SysMenu
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub New()
        InitializeComponent()

        'Me.SuspendLayout()
        'Me.Invalidate()
        'Me.ResumeLayout()
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Dummy1
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 400)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Dummy1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

End Class
