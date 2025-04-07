Public Class WindSurfer
    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        For Each x As TabPage In TabControl1.TabPages
            x.Dispose()
        Next
        Me.Close()
    End Sub

    Private Sub WebView21_NavigationStarting(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs) Handles WebView21.NavigationStarting
        TextBox1.Text = WebView21.CoreWebView2.Source
        TabPage1.Text = WebView21.CoreWebView2.DocumentTitle

    End Sub

    Private Sub WebView21_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        TextBox1.Text = WebView21.CoreWebView2.Source
        TabPage1.Text = WebView21.CoreWebView2.DocumentTitle

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

    Private Sub WindSurfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem.Click
        Dim NewTabPage As BrowserTabPage = New BrowserTabPage
        TabControl1.TabPages.Add(NewTabPage)
        ''MsgBox("errar")
    End Sub

    Private Sub CloseTabToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem1.Click
        TabControl1.SelectedTab.Dispose()
    End Sub
End Class