Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1

    Private Const SB_BOTH As Int32 = 3
    Private Const WM_NCCALCSIZE = 131
    <DllImport("user32.dll")>
    Private Shared Function ShowScrollBar(ByVal hWnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Integer) As Integer
    End Function
    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            If mdiClient IsNot Nothing Then
                ShowScrollBar(mdiClient.Handle, SB_BOTH, 0)
            End If

            MyBase.WndProc(m)
        Catch ex As Exception
            MyBase.WndProc(m)
        End Try
    End Sub
    Private mdiClient As MdiClient = Nothing

    Public WithEvents FramebufRender As PictureBox = New PictureBox() With {.Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.StretchImage}
    Public framebuf As Bitmap = New Bitmap(1024, 768)
    Public drawing As Graphics = Graphics.FromImage(framebuf)
    Public WithEvents FramebufUpdateTimer As Timer = New Timer() With {.Interval = 50, .Enabled = True}
    Public TextLin As Int32 = 0
    Public LogoImgValue As Image
    Public InException As Boolean = False

    Sub FramebufRender_KeyDown(sender As Object, e As KeyPressEventArgs) Handles FramebufRender.KeyPress
        CoreApi.FramebufKeyPressed(FramebufKeypressFunction)
    End Sub
    Function println(text As String) As Integer
        'If LogoImgValue IsNot Nothing Then
        '    drawing.DrawImage(LogoImgValue, New PointF(512 - (LogoImgValue.Size.Width / 2), 384 - (LogoImgValue.Size.Height / 2)))
        'End If
        If TextLin + text.Split(vbCrLf).Length > 38 Then
            drawing.Clear(Color.Black)
            If LogoImgValue IsNot Nothing Then
                drawing.DrawImage(LogoImgValue, New PointF(512 - (LogoImgValue.Size.Width / 2), 384 - (LogoImgValue.Size.Height / 2)))
            End If
            TextLin = 0
        End If
        drawing.DrawString(text, New Font("MS Gothic", 16, FontStyle.Bold), Brushes.Silver, New PointF(0, TextLin * 20))
        TextLin += text.Split(vbCrLf).Length
        FramebufRender.Image = framebuf
        Return 0
    End Function

    Sub FramebufUpdateTimer_Tick(sender As Object, e As EventArgs) Handles FramebufUpdateTimer.Tick
        'If LogoImgValue IsNot Nothing Then
        '    drawing.DrawImage(LogoImgValue, New PointF(512 - (LogoImgValue.Size.Width / 2), 384 - (LogoImgValue.Size.Height / 2)))
        'End If
        ''FramebufRender.Refresh()
        FramebufRender.Invalidate()
    End Sub

    Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each c As Control In Me.Controls

            If TypeOf c Is MdiClient Then
                mdiClient = TryCast(c, MdiClient)
            End If
        Next
        Me.ClientSize = New Size(1024, 768)
        LogoImgValue = My.Resources.hypeos_logo2
        FramebufRender.Image = framebuf
        drawing.Clear(Color.Black)
        If LogoImgValue IsNot Nothing Then
            drawing.DrawImage(LogoImgValue, New PointF(512 - (LogoImgValue.Size.Width / 2), 384 - (LogoImgValue.Size.Height / 2)))
        End If

        Me.Controls.Add(FramebufRender)
        FramebufRender.BringToFront()
        FramebufRender.Select()
    End Sub

    Public FramebufKeypressFunction As String
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Label1.Hide()

        'FramebufRender.Hide()
        'Me.Refresh()
        'Threading.Thread.Sleep(1000)
        'LoginDialog.MdiParent = Me
        'LoginDialog.Show()
        HypeSwitchToTouchOs()
        Timer1.Stop()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        println("HypeOS 1 [i386, build 1316] (c) MarkPCExpert")
        Try
            InstallPath = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\HypeOSPath.txt")
        Catch ex As Exception
            println("CRITICAL ERROR - Cannot find sysdir
HypeOS is corrupted. Please reinstall HypeOS.")
            FramebufRender.Refresh()
            Threading.Thread.Sleep(5000)
            End
        End Try
        println("sydir: " + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\HypeOSPath.txt").Replace("\", "＼"))
        FramebufKeypressFunction = "SwitchToHypeOs"
        println("Press any key to run HypeOS...")

        'Label1.Text = Label1.Text + File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\HypeOSPath.txt").Replace("\", "＼")
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If My.Computer.Keyboard.CtrlKeyDown = True And My.Computer.Keyboard.ShiftKeyDown = True Then
            If e.KeyCode = Keys.R Then
                LaunchForm(RunDialog)
            End If
        End If
    End Sub
End Class
