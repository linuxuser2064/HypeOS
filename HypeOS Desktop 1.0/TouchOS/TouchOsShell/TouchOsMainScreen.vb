Public Class TouchOsMainScreen
    Private Sub SplitContainer2_Panel1_Click(sender As Object, e As EventArgs) Handles SplitContainer2.Panel1.Click
        TouchOSContainer.TouchOsLaunchForm(TouchSurfer)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        HypeShutdownSystemAndExit()
    End Sub

    Private Sub SplitContainer3_Panel1_Click(sender As Object, e As EventArgs) Handles SplitContainer3.Panel1.Click
        TouchOSContainer.TouchOsLaunchForm(MediaHype)
    End Sub
End Class