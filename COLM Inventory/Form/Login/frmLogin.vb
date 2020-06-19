Imports System.Data.SqlClient

Public Class frmLogin

    Private cts As New Threading.CancellationTokenSource

    Protected Overrides Async Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Await Entrance()
    End Sub

    Private Sub pnlAppInfo_Paint(sender As Object, e As PaintEventArgs) Handles pnlAppInfo.Paint
        With e.Graphics
            .DrawString("INVENTORY MANAGEMENT", New Font("Century Gothic", 20.0!), Brushes.White, New Rectangle(0, 0, sender.Width, sender.Height / 2), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            .FillRectangle(Brushes.White, New Rectangle(25, (sender.Height / 2) - 1.5, (sender.Width / 2) - 45, 3))
            .FillRectangle(Brushes.White, New Rectangle((sender.Width / 2) + 20, (sender.Height / 2) - 1.5, (sender.Width / 2) - 45, 3))
            .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            .DrawImage(My.Resources.LogoTransparent, New Rectangle((sender.Width / 2) - 20, (sender.height / 2) - 20, 40, 40))
        End With
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txt_KeyUp(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyUp, txtPassword.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnLogin_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged, txtPassword.TextChanged
        If pnlError.Visible Then
            pnlError.Hide()
        End If
    End Sub

    Private Sub tpnlUsername_Click(sender As Object, e As EventArgs) Handles tpnlUsername.Click, lblUserName.Click
        txtUsername.Select()
    End Sub

    Private Sub tpnlPassword_Click(sender As Object, e As EventArgs) Handles tpnlPassword.Click, lblPassword.Click
        txtPassword.Select()
    End Sub

    Private Async Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        cts.Cancel()
        cts = New Threading.CancellationTokenSource

        HideError()

        If Not txtUsername.IsValid Or Not txtPassword.IsValid Then
            lblError.Text = "Username and Password is required."
            Await ShowError()
            lblPassword.Select()
            Exit Sub
        End If

        Using l As New ctrlLoadingScreen(Me, "Logging in", Sub() cts.Cancel())
            If Await Login() Then
                If Await FetchInfo() Then
                    Notification.Show("Logged in.", Color.Green)
                    SaveLog()
                    Me.Hide()

                    Using home As New frmHome
                        home.ShowDialog()
                    End Using

                    Application.Restart()
                End If
            End If
        End Using

        If lblError.Text.TrimAll.Length > 0 Then
            Await ShowError()
        End If

        lblUserName.Select()
    End Sub

    Private Async Function Login() As Threading.Tasks.Task(Of Boolean)
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("EXECUTE spLogin @Username, @Password, @DeviceInfo", con)
                    com.Parameters.AddWithValue("@Username", txtUsername.Text)
                    com.Parameters.AddWithValue("@Password", txtPassword.Text)
                    com.Parameters.AddWithValue("@DeviceInfo", DBNull.Value)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            Select Case reader("RES")
                                Case "Failed"
                                    lblError.Text = "Username or Password is incorrect."
                                    Return False
                                Case "Successful"
                                    SESSION_KEY = reader("KEY")
                                    Return True
                                Case Else
                                    MessageBox.Show(CODE_ELSE & reader("RES"))
                                    lblError.Text = "Server error."
                                    Return False
                            End Select
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Return False
        Catch ex As InvalidOperationException
            lblError.Text = ERR_CON
        Catch ex As Exception
            lblError.Text = ERR_ELSE
        End Try

        Return False
    End Function

    Private Async Function FetchInfo() As Threading.Tasks.Task(Of Boolean)
        Try
            Using con As New SqlConnection(CONNECTION_STRING)
                con.Open()
                Using com As New SqlCommand("SELECT * FROM vwUser WHERE Username = @a", con)
                    com.Parameters.AddWithValue("@a", txtUsername.Text)

                    Using reader As SqlDataReader = Await com.ExecuteReaderAsync(cts.Token)
                        If reader.Read Then
                            USER_ID = reader("UserID")
                            USERNAME = reader("Username")
                            PERMISSION_NAME = reader("PermissionName")
                            ACCESS_USER = reader("AccessUser")
                            ACCESS_PERMISSION = reader("AccessPermission")
                            ACCESS_CUSTOMER = reader("AccessCustomer")
                            ACCESS_ITEM = reader("AccessItem")
                            ACCESS_INVENTORY = reader("AccessInventory")
                            ACCESS_RESERVATION = reader("AccessReservation")
                            ACCESS_CONSUME = reader("AccessConsume")
                            ACCESS_BORROW = reader("AccessBorrow")
                            ACCESS_STATION = reader("AccessStation")

                            Return True
                        Else
                            lblError.Text = "Username or Password is incorrect."
                            Return False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Threading.Tasks.TaskCanceledException
            Return False
        Catch ex As InvalidOperationException
            lblError.Text = ERR_CON
        Catch ex As Exception
            lblError.Text = ERR_ELSE
        End Try

        Return False
    End Function

    Private Sub SaveLog()
        Try
            With My.Computer.FileSystem
                If Not .DirectoryExists(.SpecialDirectories.MyDocuments & "/InventoryManagement/") Then
                    .CreateDirectory(.SpecialDirectories.MyDocuments & "/InventoryManagement/")
                End If

                If Not .FileExists(.SpecialDirectories.MyDocuments & "/InventoryManagement/Log.txt") Then
                    .WriteAllText(.SpecialDirectories.MyDocuments & "/InventoryManagement/Log.txt", USERNAME & " : Login : " & DateTime.Now.ToString("MMMM dd, yyyy   HH:mm:ss tt"), True)
                Else
                    .WriteAllText(.SpecialDirectories.MyDocuments & "/InventoryManagement/Log.txt", NXT & USERNAME & " : Login : " & DateTime.Now.ToString("MMMM dd, yyyy   HH:mm:ss tt"), True)
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Async Function Entrance() As Threading.Tasks.Task
        tpnlUsername.Hide()
        tpnlUsername.Size = New Size(0, 30)
        tpnlUsername.Location = New Point(0, ((pnlAppInfo.Height / 4) * 3) + pnlAppInfo.Top - tpnlUsername.Height)
        tpnlUsername.Show()
        tpnlPassword.Hide()
        tpnlPassword.Size = New Size(0, 30)
        tpnlPassword.Location = New Size(0, tpnlUsername.Bottom + 10)
        tpnlPassword.Show()

        Await Threading.Tasks.Task.Delay(200)

        Dim sw As Stopwatch = Stopwatch.StartNew
        While sw.ElapsedMilliseconds <= 500
            tpnlUsername.Size = New Size(Easing.Calculate(Easing.Effect.OutExpo, sw.ElapsedMilliseconds, 300, 0, 280), 30)
            tpnlUsername.Location = New Point((Me.ClientSize.Width - tpnlUsername.Width) / 2, tpnlUsername.Location.Y)
            tpnlUsername.Refresh()
            tpnlPassword.Size = New Size(Easing.Calculate(Easing.Effect.OutExpo, sw.ElapsedMilliseconds - 200, 300, 0, 280), 30)
            tpnlPassword.Location = New Point((Me.ClientSize.Width - tpnlPassword.Width) / 2, tpnlPassword.Location.Y)
            tpnlPassword.Refresh()
        End While
        sw.Stop()

        tpnlUsername.Size = New Size(280, 30)
        tpnlUsername.Location = New Point((Me.ClientSize.Width - tpnlUsername.Width) / 2, tpnlUsername.Location.Y)
        tpnlPassword.Size = New Size(280, 30)
        tpnlPassword.Location = New Point((Me.ClientSize.Width - tpnlPassword.Width) / 2, tpnlPassword.Location.Y)
    End Function

    Private Sub HideError()
        pnlError.Hide()
        pnlError.Size = New Size(0, 30)
        pnlError.Location = New Point((Me.ClientSize.Width - pnlError.Width) / 2, btnLogin.Bottom + 10)
        lblError.Hide()
        lblError.Text = ""
    End Sub

    Private Async Function ShowError() As Threading.Tasks.Task
        If lblError.Text.TrimAll.Length = 0 Then Exit Function

        Await Threading.Tasks.Task.Delay(100)

        pnlError.Show()

        Dim sw As Stopwatch = Stopwatch.StartNew
        While sw.ElapsedMilliseconds <= 400
            pnlError.Size = New Size(Easing.Calculate(Easing.Effect.OutExpo, sw.ElapsedMilliseconds, 400, 0, 250), 30)
            pnlError.Location = New Point((Me.ClientSize.Width - pnlError.Width) / 2, btnLogin.Bottom + 10)
            pnlError.Refresh()
        End While
        sw.Stop()

        pnlError.Size = New Size(250, 30)
        pnlError.Location = New Point((Me.ClientSize.Width - pnlError.Width) / 2, btnLogin.Bottom + 10)
        lblError.Show()
    End Function

End Class
