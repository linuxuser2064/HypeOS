Imports System.IO

Public Class LoginDialog
    ' = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\HypeOSPath.txt")
    Public CurrentUsername As String
    Public CurrentPassword As String
    Public LoggedIn As Boolean = False

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'MsgBox(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\HypeOSPath.txt"))
        If CoreApi.HypeAuthenticateUserAndStartShell(UsernameTextBox.Text, PasswordTextBox.Text) = 0 Then
            LaunchForm(Deskbar)
            LaunchForm(Desktop)
            Me.Close()
        End If
        'Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        CoreApi.HypeShutdownSystemAndExit()
    End Sub
End Class
