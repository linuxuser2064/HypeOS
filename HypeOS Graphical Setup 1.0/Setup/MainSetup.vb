Imports System.IO
Imports System.IO.Compression
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MainSetup
    Public InstallPath As String
    Private Sub MainSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'For Each x In Directory.GetDirectories(InstallPath)
        '    MsgBox(x)
        '    For Each y In Directory.GetFiles(x)
        '        'File.Delete(y)

        '        MsgBox(y)
        '    Next
        '    'Directory.Delete(x)
        'Next
        Process.Start("cmd.exe", "/c rd /s /q " + InstallPath)
        TextBox1.Text = InstallPath
        Label4.Text = Me.AccessibleDescription
        Panel1.Dock = DockStyle.Fill
        Panel2.Dock = DockStyle.Fill
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
        PictureBox3.Image = Image.FromFile(OpenFileDialog1.FileName)
        File.Delete(InstallPath + "\Users\" + TextBox2.Text + "\profile.pic")
        File.Copy(OpenFileDialog1.FileName, InstallPath + "\Users\" + TextBox2.Text + "\profile.pic")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox3.Image = My.Resources.hypeos_logo_128
        File.Delete(InstallPath + "\Users\" + TextBox2.Text + "\profile.pic")
        My.Resources.hypeos_logo.Save(InstallPath + "\Users\" + TextBox2.Text + "\profile.pic")
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\HypeOSPath.txt", InstallPath)
        Directory.CreateDirectory(InstallPath)
        Directory.CreateDirectory(InstallPath + "\Users")
        Directory.CreateDirectory(InstallPath + "\HYPEOS_BIN")
        Directory.CreateDirectory(InstallPath + "\Users\" + TextBox2.Text)
        File.WriteAllText(InstallPath + "\Users\" + TextBox2.Text + "\user.un", TextBox2.Text)
        My.Resources.hypeos_logo.Save(InstallPath + "\Users\" + TextBox2.Text + "\profile.pic")
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        File.WriteAllText(InstallPath + "\Users\" + TextBox2.Text + "\user.ps", TextBox3.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Hide()
        Panel2.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'For Each x In Directory.GetDirectories(InstallPath)
        '    MsgBox(InstallPath + "\" + x)
        '    For Each y In Directory.GetFiles(InstallPath + "\" + x)
        '        File.Delete(InstallPath + "\" + x + "\" + y)

        '        MsgBox(InstallPath + "\" + x + "\" + y)
        '    Next
        '    Directory.Delete(InstallPath + "\" + x)
        'Next
        Process.Start("cmd.exe", "/c rd /s /q " + InstallPath)
        ''Directory.Delete(InstallPath + "\Users")
        ''Directory.Delete(InstallPath + "\HYPEOS_BIN")
        ''Directory.Delete(InstallPath + )
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Process.Start("cmd.exe", "/c rd /s /q " + InstallPath)
        Panel1.Show()
        Panel2.Hide()
        Button2.Enabled = False
        Button3.Enabled = False
        PictureBox3.Image = My.Resources.hypeos_logo_128
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panel3.Dock = DockStyle.Fill
        Panel3.BringToFront()
        Panel3.Show()
        If Directory.Exists(TextBox1.Text) = False Then
            Try
                Directory.CreateDirectory(TextBox1.Text)
                Label10.Text = "Creating directory..."
                Me.Refresh()
            Catch ex As Exception
                MsgBox("Error while creating directory", MsgBoxStyle.Critical, "Error")
                Label10.Text = "Idle"
                Return
            End Try
        End If
        Try
            Label10.Text = "Dumping archive..."
            Me.Refresh()
            File.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp + "\dmp.zip", My.Resources.main)
        Catch ex As Exception
            MsgBox("Error while dumping archive. The program is corrupt.", MsgBoxStyle.Critical, "Error")
            Label10.Text = "Idle"
            Return
        End Try
        Try
            Label10.Text = "Extracting archive..."
            Me.Refresh()
            ZipFile.ExtractToDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\dmp.zip", TextBox1.Text)
        Catch ex As Exception
            MsgBox("Error while extracting archive. The archive is corrupt.", MsgBoxStyle.Critical, "Error")
            Label10.Text = "Idle"
            Return
        End Try
        Label10.Text = "Done!"
        Button9.Enabled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Shell(InstallPath + "\HOSKRNL.exe", AppWinStyle.NormalFocus)
        End
    End Sub
End Class