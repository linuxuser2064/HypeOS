Public Class BrowserTabPage
    Private Sub WebView21_NavigationStarting(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs) Handles WebView21.NavigationStarting
        Me.Text = WebView21.CoreWebView2.DocumentTitle
        TextBox1.Text = WebView21.CoreWebView2.Source
    End Sub

    Private Sub WebView21_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        Me.Text = WebView21.CoreWebView2.DocumentTitle
        TextBox1.Text = WebView21.CoreWebView2.Source
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebView21.GoBack()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebView21.GoForward()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WebView21.CoreWebView2.Navigate(TextBox1.Text)
    End Sub
End Class
