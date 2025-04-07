Imports System.IO
Imports System.Threading
Module CmdShell
    Public CurrentDir As String = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\HypeOSPath.txt")
    Function Cmd(command As String, Optional args As String = "") As String
        If command = "shutdown" Then
            If String.IsNullOrWhiteSpace(args) = False Then
                Try
                    Thread.Sleep(Convert.ToString(args) * 1000)
                    Application.Exit()
                    Return "0"
                Catch ex As Exception
                    Return ex.Message
                End Try
            Else
                Application.Exit()
                Return "0"
            End If

        ElseIf command = "dir" Then
            If String.IsNullOrWhiteSpace(args) = True Then
                Dim DirReturn As String = "Directory listing for " + CurrentDir + vbCrLf
                For Each x As String In Directory.GetDirectories(CurrentDir)
                    DirReturn = DirReturn + x + vbCrLf
                Next
                Return DirReturn
            Else
                Dim DirReturn As String = "Directory listing for " + args + vbCrLf
                For Each x As String In Directory.GetDirectories(args)
                    DirReturn = DirReturn + x + vbCrLf
                Next
                Return DirReturn
            End If

        Else
            Return "1_Command not found"
        End If
        Return 0
    End Function
End Module
