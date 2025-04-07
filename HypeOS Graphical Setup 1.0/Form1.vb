Imports System.IO

Public Class Form1
    Dim BackImg As Bitmap = New Bitmap(1, 1)
    Dim BackGNDGraphics As Graphics = Graphics.FromImage(BackImg)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'logitek
        BackGNDGraphics.Clear(Color.FromArgb(64, 64, 64))
        BackGNDGraphics.DrawImage(BackImg, Point.Empty)
        Me.BackgroundImage = BackImg
        'TextLoadingAnimation1.BringToFront()
        'TextLoadingAnimation1.Dock = DockStyle.Fill
    End Sub

    Private Sub TextLoadingAnimation1_MouseMove(sender As Object, e As MouseEventArgs)
    End Sub

    Public Sub ShutDownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutDownToolStripMenuItem.Click
        Dim WinbOpenForms As Collection = New Collection
        'My.Resources.ezgif_5_fded4a8b6d = New Bitmap(BackImg)

        For Each x As Form In Application.OpenForms
            WinbOpenForms.Add(x)
        Next

        For Each x As Form In WinbOpenForms
            If x.Name = "Form1" Then
                'Else
                x.FormBorderStyle = FormBorderStyle.None
                x.BackColor = Color.Black
                x.Text = ""
            End If
        Next
        Me.Refresh()
        Me.Refresh()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Normal
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.Location = Point.Empty
        Me.Refresh()
        Me.Refresh()
        Me.Refresh()
        Me.BackgroundImage = Nothing
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.Refresh()
        PreSetup.FormBorderStyle = FormBorderStyle.None

        Threading.Thread.Sleep(1500)
        Me.FormBorderStyle = FormBorderStyle.None
        Threading.Thread.Sleep(350)
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        PreSetup.MdiParent = Me
        PreSetup.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Shell(Application.ExecutablePath, AppWinStyle.NormalFocus)
        End
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'TextLoadingAnimation1.Hide()
        StatusStrip1.Show()
    End Sub
End Class
