Public Class CmdWnd
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.AppendText(TextBox2.Text + " " + TextBox3.Text + vbCrLf + Cmd(TextBox2.Text, TextBox3.Text) + ">")
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class