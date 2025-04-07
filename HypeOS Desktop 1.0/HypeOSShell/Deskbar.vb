Public Class Deskbar
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Location = New Point(0, Form1.ClientSize.Height - 40)
        Me.Size = New Size(Form1.ClientSize.Width - 4, 36)
        Label1.Text = My.Computer.Clock.LocalTime.ToLongTimeString
        ListView1.Items.Clear()

        For Each x As Form In Application.OpenForms
            If Not x.AccessibleRole = AccessibleRole.Cell Then
                ListView1.Items.Add(New ListViewItem(x.Text))
            End If
        Next
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        'If ListView1.SelectedItems.Count > 0 Then
        '    MsgBox(ListView1.SelectedItems.Item(0).SubItems(0).Text)
        'Else
        '    MsgBox("no item :skull:")
        'End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            'MsgBox(ListView1.SelectedItems.Item(0).SubItems(0).Text)
            For Each x As Form In Application.OpenForms
                If x.Text = ListView1.FocusedItem.Text Then
                    If x.WindowState = FormWindowState.Minimized Then x.WindowState = FormWindowState.Normal
                    x.BringToFront()
                End If
            Next
        Else
            'MsgBox("no item :skull:")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Throw New NotImplementedException
    End Sub
End Class