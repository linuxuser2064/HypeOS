Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class TouchOSContainer
    Private Const SB_BOTH As Int32 = 3
    Private Const WM_NCCALCSIZE = 131
    <DllImport("user32.dll")>
    Private Shared Function ShowScrollBar(ByVal hWnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Integer) As Integer
    End Function
    Protected Overrides Sub WndProc(ByRef m As Message)
        If mdiClient IsNot Nothing Then
            ShowScrollBar(mdiClient.Handle, SB_BOTH, 0)
        End If

        MyBase.WndProc(m)
    End Sub
    Private mdiClient As MdiClient = Nothing

    Public WithEvents FramebufRender As PictureBox = New PictureBox() With {.Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.StretchImage}
    Public framebuf As Bitmap = New Bitmap(1024, 768)
    Public drawing As Graphics = Graphics.FromImage(framebuf)
    Public WithEvents FramebufUpdateTimer As Windows.Forms.Timer = New Windows.Forms.Timer() With {.Interval = 50, .Enabled = True}
    Public TextLin As Int32 = 0
    Public LogoImgValue As Image
    Public InException As Boolean = False

    Sub FramebufRender_KeyDown(sender As Object, e As KeyPressEventArgs) Handles FramebufRender.KeyPress
        If InException = True Then
            FramebufRender.Hide()
            drawing.Clear(Color.Black)
            If LogoImgValue IsNot Nothing Then
                drawing.DrawImage(LogoImgValue, New PointF(512 - (LogoImgValue.Size.Width / 2), 384 - (LogoImgValue.Size.Height / 2)))
            End If
            InException = False
        End If
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

        println("HypeOS Touch [Build 17, MSIL-i386] (c) MarkPCExpert 2023")
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

    End Sub

    Public Function TouchOsSwitchUserMode() As Integer
        Me.FramebufRender.Hide()
        Me.FramebufRender.SendToBack()
        Return 0
    End Function

    Public Function TouchOsSwitchFramebufMode() As Integer
        Me.FramebufRender.Show()
        Me.FramebufRender.BringToFront()
        Me.FramebufRender.Select()
        Return 0
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TouchOsSwitchUserMode()
        TouchOsLaunchForm(TouchOsLogon)
        Timer1.Stop()
    End Sub

    Public Function TouchOsLaunchForm(form As Form) As Integer
        form.MdiParent = Me
        form.Show()
        Return 0
    End Function

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        For Each x As Form In Application.OpenForms
            If Not x.Name = "TouchOSContainer" Then
                If x.WindowState = FormWindowState.Maximized Then
                    x.WindowState = FormWindowState.Normal
                    x.Size = New Size(Me.ClientSize.Width - 6, Me.ClientSize.Height - 6)
                    x.Location = New Point(1, 1)
                End If
            End If
        Next
    End Sub
End Class