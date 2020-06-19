
Public Class frmHome

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)

        WatchConnection()
    End Sub

    Private Async Sub WatchConnection()
        Dim reConnectionDeley As Integer = 3000

        Await Threading.Tasks.Task.Delay(reConnectionDeley)

        While True
            If Not Me.Visible Then Exit While

            If Session.IsServerUp() Then
                If pnlNoConnection.Visible Then
                    Notification.Show("Connection established.", Color.Green)
                    pnlNoConnection.Hide()
                    reConnectionDeley = 8000
                End If
            Else
                If Not pnlNoConnection.Visible Then
                    Notification.Show(ERR_CON, Color.FromArgb(230, 50, 50))
                    ShowError()
                    reConnectionDeley = 500
                End If
            End If

            Await Threading.Tasks.Task.Delay(reConnectionDeley)
        End While
    End Sub

    Private Sub ShowError()
        pnlNoConnection.Hide()
        pnlNoConnection.Size = New Size(0, 30)
        pnlNoConnection.Show()

        lblNoConnection.Hide()

        Dim sw As Stopwatch = Stopwatch.StartNew
        While sw.ElapsedMilliseconds <= 300
            pnlNoConnection.Size = New Size(Easing.Calculate(Easing.Effect.OutExpo, sw.ElapsedMilliseconds, 300, 0, Me.ClientSize.Width - 40), 30)
            pnlNoConnection.Location = New Point((Me.ClientSize.Width - pnlNoConnection.Width) / 2, Me.ClientSize.Height - 50)
            pnlNoConnection.Refresh()
        End While
        sw.Stop()

        lblNoConnection.Show()
    End Sub

End Class
