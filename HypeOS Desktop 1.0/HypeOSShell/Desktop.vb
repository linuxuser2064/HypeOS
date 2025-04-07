Public Class Desktop
    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Item(0).Index = 0 Then
            eXplorer.MdiParent = Form1
            eXplorer.Show()
        ElseIf ListView1.SelectedItems.Item(0).Index = 1 Then
            CmdWnd.MdiParent = Form1
            CmdWnd.Show()
        ElseIf ListView1.SelectedItems.Item(0).Index = 2 Then
            WindSurfer.MdiParent = Form1
            WindSurfer.Show()
        End If
    End Sub

    Private Sub Desktop_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Me.SendToBack()
        Me.Size = New Size(Form1.ClientSize.Width - 4, Form1.ClientSize.Height - 4)
        Me.Location = Point.Empty
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.SendToBack()
        Me.Size = New Size(Form1.ClientSize.Width - 4, Form1.ClientSize.Height - 4)
        Me.Location = Point.Empty
    End Sub
End Class