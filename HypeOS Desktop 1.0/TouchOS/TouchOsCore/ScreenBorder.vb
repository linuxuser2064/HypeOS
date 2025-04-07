Public Class ScreenBorder
    Private titleValue As String
    Public Property WindowTitle() As String
        Get
            Return titleValue
        End Get
        Set(ByVal value As String)
            titleValue = value
            Label1.Text = titleValue
        End Set
    End Property

    Private parentFormValue As Form
    Public Property ClosableForm() As Form
        Get
            Return parentFormValue
        End Get
        Set(ByVal value As Form)
            parentFormValue = value
        End Set
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        parentFormValue.Close()
    End Sub
End Class
