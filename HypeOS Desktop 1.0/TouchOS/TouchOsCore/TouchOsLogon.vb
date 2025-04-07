Public Class TouchOsLogon
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Public Function OpenOsk()
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start(osk)
        End If
        Return 0
    End Function

    Public Function CloseOsk() As Integer
        For Each x In Process.GetProcessesByName("osk")
            x.Kill()
        Next
        Return 0
    End Function
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        OpenOsk()
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        CloseOsk()
    End Sub

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        OpenOsk()
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        CloseOsk()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Me.Refresh()
        If CoreApi.HypeAuthenticateUserAndStartShell(TextBox1.Text, TextBox2.Text) = 0 Then
            Label5.Show()
        Else
            Me.Close()
            TouchOSContainer.TouchOsLaunchForm(TouchOsMainScreen)
        End If
        Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        HypeShutdownSystemAndExit()
    End Sub

    Private Sub TouchOsLogon_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Button2.Location = Point.Empty
    End Sub
End Class