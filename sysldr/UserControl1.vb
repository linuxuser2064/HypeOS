Public Class fbldr
    Private framebuf As Bitmap = New Bitmap(1024, 768)
    Private drawing As Graphics = Graphics.FromImage(framebuf)
    'Private frmdraw As Graphics = Me.CreateGraphics()
    Public TextLin As Int32 = 0
    Public LogoImgValue As Image
    Public Property LogoImg() As Image
        Get
            Return LogoImgValue
        End Get
        Set(value As Image)
            LogoImgValue = value
        End Set
    End Property
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = framebuf
        PictureBox1.Refresh()
        drawing.Clear(Color.Black)
        If LogoImgValue IsNot Nothing Then
            drawing.DrawImage(LogoImgValue, New PointF(512 - (LogoImgValue.Size.Width / 2), 384 - (LogoImgValue.Size.Height / 2)))
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If LogoImgValue IsNot Nothing Then
            drawing.DrawImage(LogoImgValue, New PointF(512 - (LogoImgValue.Size.Width / 2), 384 - (LogoImgValue.Size.Height / 2)))
        End If
        PictureBox1.Refresh()
        'frmdraw.DrawImage(framebuf, 0, 0, Me.Size.Width, Me.Size.Height)
    End Sub

    Function println(text As String) As Integer
        drawing.DrawImage(LogoImgValue, New PointF(512 - (LogoImgValue.Size.Width / 2), 384 - (LogoImgValue.Size.Height / 2)))
        drawing.DrawString(text, New Font("MS Gothic", 16, FontStyle.Bold), Brushes.Silver, New PointF(0, TextLin * 17))
        TextLin += text.Split(vbCrLf).Length
        'frmdraw.DrawImage(framebuf, 0, 0, Me.Size.Width, Me.Size.Height)
        PictureBox1.Refresh()
        Return 0
    End Function

    Private Sub fbldr_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'frmdraw.DrawImage(framebuf, 0, 0, Me.Size.Width, Me.Size.Height)
        PictureBox1.Refresh()
    End Sub
End Class
