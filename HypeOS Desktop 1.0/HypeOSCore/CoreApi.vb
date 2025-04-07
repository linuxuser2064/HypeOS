Imports System.IO
Imports System.Security

Module CoreApi
    Public CurrentUsername As String
    Public CurrentPassword As String
    Public LoggedIn As Boolean = False
    Public MainLoginFrm As Form = LoginDialog
    Public InstallPath As String
    Public tribute As String = "Rest in peace Hyper's grandpa. You will be missed."
    Public Function LaunchForm(form As Form) As Integer
        form.MdiParent = Form1
        form.Show()
        Return 0
    End Function

    Public Function HypeSwitchFramebufMode() As Integer
        Form1.FramebufRender.Show()
        Form1.FramebufRender.BringToFront()
        Form1.FramebufRender.Select()
        Return 0
    End Function

    Public Function HypeSwitchUserMode() As Integer
        Form1.FramebufRender.Hide()
        Form1.FramebufRender.SendToBack()
        Return 0
    End Function

    Public Function HypeAuthenticateUserAndStartShell(username As String, password As String) As Integer
        For Each x In Directory.GetDirectories(InstallPath + "\Users")
            If username = File.ReadAllText(x + "\user.un") Then

            End If
        Next
        For Each x In Directory.GetDirectories(InstallPath + "\Users")
            If username = File.ReadAllText(x + "\user.un") Then
                If password = File.ReadAllText(x + "\user.ps") Then
                    CurrentUsername = File.ReadAllText(x + "\user.un")
                    CurrentPassword = File.ReadAllText(x + "\user.ps")
                    LoggedIn = True
                Else
                    Return 1
                End If
            Else
                Return 1
            End If
        Next
        Return 0
    End Function

    Public Function FramebufKeyPressed(func As String) As Integer
        If Form1.InException = True Then
            HypeSwitchUserMode()
            Form1.drawing.Clear(Color.Black)
            If Form1.LogoImgValue IsNot Nothing Then
                Form1.drawing.DrawImage(Form1.LogoImgValue, New PointF(512 - (Form1.LogoImgValue.Size.Width / 2), 384 - (Form1.LogoImgValue.Size.Height / 2)))
            End If
            Form1.InException = False
        End If

        If func = "SwitchToTouchOs" Then
            HypeSwitchToTouchOs()
        End If

        If func = "SwitchToHypeOs" Then
            HypeSwitchToHypeOs()
        End If
        Return 0
    End Function

    Public Function HypeSwitchToTouchOs() As Integer
        Form1.FramebufUpdateTimer.Stop()
        Form1.Timer1.Stop()
        TouchOSContainer.Show()
        Form1.Close()
        Return 0
    End Function

    Public Function HypeShutdownSystemAndExit() As Integer
        TouchOSContainer.TouchOsSwitchFramebufMode()
        HypeSwitchFramebufMode()
        TouchOSContainer.println("System shutting down")
        Form1.println("System shutting down")
        Form1.Refresh()
        TouchOSContainer.Refresh()
        Threading.Thread.Sleep(1250)
        End
        Return 0
    End Function

    Public Function HypeSwitchToHypeOs() As Integer
        Form1.FramebufRender.Hide()
        Form1.Refresh()
        Threading.Thread.Sleep(1000)
        LoginDialog.MdiParent = Form1
        LoginDialog.Show()
        Form1.Timer1.Stop()
        Return 0
    End Function
End Module
