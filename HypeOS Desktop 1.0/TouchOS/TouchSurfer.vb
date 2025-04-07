Public Class TouchSurfer
    Private Sub WebView21_NavigationStarting(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs) Handles WebView21.NavigationStarting
        TextBox1.Text = e.Uri
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button5.Click
        WebView21.Source = New Uri(TextBox1.Text)
        TabPage1.Text = WebView21.CoreWebView2.DocumentTitle
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebView21.GoBack()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WebView21.GoForward()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebView21.Reload()
    End Sub

    Private Sub WebView21_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        TextBox1.Text = WebView21.Source.AbsoluteUri
        TabPage1.Text = WebView21.CoreWebView2.DocumentTitle
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Not TabControl1.TabCount = 1 Then
            TabControl1.SelectedTab.Dispose()
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim newTab1 As TabPage = New TouchOsWebBrowserTab
        TabControl1.TabPages.Add(newTab1)
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        TouchOsLogon.OpenOsk()
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        TouchOsLogon.CloseOsk()
    End Sub
End Class