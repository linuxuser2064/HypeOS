Imports System.Windows.Forms

Public Class RunDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim types As Type() = myAssembly.GetTypes()

        Dim frmName As String = ComboBox1.Text

        Dim obj = myAssembly.GetType(frmName).InvokeMember("newForm", Reflection.BindingFlags.CreateInstance, Nothing, Nothing, Nothing)
        Dim frm As Form = CType(obj, Form)
        LaunchForm(frm)
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub RunDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim types As Type() = myAssembly.GetTypes()

        For Each t As Type In types
            If t.BaseType.ToString = "System.Windows.Forms.Form" Then
                ComboBox1.Items.Add(t.Name)
            End If
        Next
    End Sub
End Class
