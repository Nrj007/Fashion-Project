Public Class Conformation

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs)
        Main.Show()

    End Sub
    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            e.Cancel = True
        Else
            Application.Exit()
        End If
    End Sub
End Class
