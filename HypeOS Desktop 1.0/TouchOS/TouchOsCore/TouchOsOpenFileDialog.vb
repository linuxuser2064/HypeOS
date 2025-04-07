Public Class TouchOsOpenFileDialog
    Public SelectedFile As String
    Private Sub DriveListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles DriveListBox1.SelectedValueChanged
        DirListBox1.Path = DriveListBox1.Drive
        FileListBox1.Path = DriveListBox1.Drive
    End Sub

    Private Sub DirListBox1_DoubleClick(sender As Object, e As EventArgs) Handles DirListBox1.DoubleClick
        Try
            FileListBox1.Path = DirListBox1.Path
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FileListBox1_Click(sender As Object, e As EventArgs) Handles FileListBox1.Click
        TextBox1.Text = FileListBox1.Path + "\" + FileListBox1.FileName
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SelectedFile = TextBox1.Text
        Me.Close()
    End Sub
End Class