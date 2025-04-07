Public Class MediaHype
    Public MediaOpenFileDlg As TouchOsOpenFileDialog = New TouchOsOpenFileDialog
    Private MediaPlaying As Boolean = False
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileToolStripMenuItem.Click
        TouchOSContainer.TouchOsLaunchForm(TouchOsOpenFileDialog)
        OpenFileDialogWaitTimer.Start()
    End Sub

    Private Sub OpenFileDialogWaitTimer_Tick(sender As Object, e As EventArgs) Handles OpenFileDialogWaitTimer.Tick
        If MediaOpenFileDlg.DialogResult = DialogResult.OK Then
            MsgBox(MediaOpenFileDlg.SelectedFile)
            VideoPlayerWinForm1.Open(New Uri(MediaOpenFileDlg.SelectedFile))
            OpenFileDialogWaitTimer.Stop()
        End If
    End Sub

    Private Sub MediaHype_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VideoPlayerWinForm1.Init("none", "none", "")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        VideoPlayerWinForm1.Stop()
        MediaPlaying = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MediaPlaying = False Then
            VideoPlayerWinForm1.Play()
            MediaPlaying = True
        Else
            VideoPlayerWinForm1.Pause()
            MediaPlaying = False
        End If
    End Sub
End Class