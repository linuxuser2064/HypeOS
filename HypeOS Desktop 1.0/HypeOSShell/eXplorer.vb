Imports System.IO
Public Class eXplorer
    Public CurrentPath = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\HypeOSPath.txt")
    Private Sub Hypexplorer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirListBox.Items.Clear()
        DirListBox.Items.Add("..")
        FileListBox.Items.Clear()
        For Each x In My.Computer.FileSystem.GetDirectories(CurrentPath)
            DirListBox.Items.Add(IO.Path.GetFileName(x))
        Next
        For Each x In My.Computer.FileSystem.GetFiles(CurrentPath)
            FileListBox.Items.Add(IO.Path.GetFileName(x))
        Next
        'TextBox1.Text = IO.Path.GetFileName(CurrentPath)
        ToolStripStatusLabel1.Text = CurrentPath
    End Sub
    Private Sub ExecuteCommandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExecuteCommandToolStripMenuItem.Click
        Dim ExCmd As String = Cmd(ToolStripTextBox1.Text)
        If Not ExCmd = "0" Then
            MsgBox(ExCmd)
        End If
    End Sub

    Private Sub DirListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DirListBox.MouseDoubleClick
        If DirListBox.GetItemText(DirListBox.SelectedItem) = ".." Then
            CurrentPath = Directory.GetParent(CurrentPath).FullName
            'MsgBox(CurrentPath)
        Else
            'MsgBox(DirListBox.GetItemText(DirListBox.SelectedItem))
            CurrentPath = CurrentPath + "\" + DirListBox.GetItemText(DirListBox.SelectedItem)
        End If
        DirListBox.Items.Clear()
        DirListBox.Items.Add("..")
        FileListBox.Items.Clear()
        For Each x In My.Computer.FileSystem.GetDirectories(CurrentPath)
            DirListBox.Items.Add(IO.Path.GetFileName(x))
        Next
        For Each x In My.Computer.FileSystem.GetFiles(CurrentPath)
            FileListBox.Items.Add(IO.Path.GetFileName(x))
        Next
        ToolStripStatusLabel1.Text = CurrentPath
    End Sub

    Private Sub FileListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles FileListBox.MouseDoubleClick
        'MsgBox("cmd.exe" + "/c start " + CurrentPath + "\" + FileListBox.GetItemText(FileListBox.SelectedItem))
        Process.Start("cmd.exe", "/c start " + CurrentPath + "\" + FileListBox.GetItemText(FileListBox.SelectedItem))
    End Sub
End Class
