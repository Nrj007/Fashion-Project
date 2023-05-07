Public Class adminpass
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If BunifuTextBox1.Text = "2002" Then
            Me.Hide()
            MessageBox.Show("Admin Authenticated")
            Admin.Show()
        Else
            MessageBox.Show("Incorrect Pin")
        End If
    End Sub

    Private Sub adminpass_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class