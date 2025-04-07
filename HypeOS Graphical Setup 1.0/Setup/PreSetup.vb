Imports System.IO

Public Class PreSetup
    Dim LaunchingSetup As Boolean = False
    Private Sub PreSetup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If LaunchingSetup = False Then
            Form1.ShutDownToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub PreSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.TabPages.Remove(TabPage2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Add(TabPage2)
        TabControl1.SelectTab(1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FolderBrowserDialog1.ShowDialog()
        TextBox1.Text = FolderBrowserDialog1.SelectedPath
        MainSetup.InstallPath = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LaunchingSetup = True
        Me.Close()
        MainSetup.MdiParent = Form1
        MainSetup.Show()
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        ComboBox1.Tag = "s"
        If ComboBox2.Tag = "s" Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
        ComboBox2.Tag = "s"
        If ComboBox1.Tag = "s" Then
            Button1.Enabled = True
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        MainSetup.InstallPath = TextBox1.Text
        If Path.IsPathRooted(TextBox1.Text) Then
            TextBox1.Tag = "s"
        Else
            TextBox1.Tag = "i"
        End If

        If ComboBox3.Tag = "s" AndAlso TextBox1.Tag = "s" Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
    End Sub

    Private Sub ComboBox3_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedValueChanged
        ComboBox3.Tag = "s"
        If ComboBox3.Tag = "s" AndAlso TextBox1.Tag = "s" Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        MainSetup.AccessibleDescription = ComboBox3.GetItemText(ComboBox3.SelectedItem)
    End Sub
End Class