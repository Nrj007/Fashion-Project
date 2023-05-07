Imports System.Data.SqlClient
Public Class forget_password
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim user = BunifuTextBox1.Text
        Dim con1 As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query1 = "SELECT password FROM customer WHERE username=@username"
        Dim cm1d As New SqlCommand(query1, con1)
        con1.Open()
        cm1d.Parameters.AddWithValue("username", user)
        Dim reader As SqlDataReader = cm1d.ExecuteReader()
        If reader.Read() Then
            Dim customerId As String = reader("password").ToString()
            BunifuLabel3.Visible = True
            BunifuLabel4.Visible = True
            BunifuLabel4.Text = customerId

        Else
            MessageBox.Show("Invalid Username")
        End If
        reader.Close()
        con1.Close()
    End Sub

    Private Sub BunifuLabel2_Click(sender As Object, e As EventArgs) Handles BunifuLabel2.Click

    End Sub

    Private Sub forget_password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BunifuLabel3.Visible = False
        BunifuLabel4.Visible = False
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub BunifuLabel3_Click(sender As Object, e As EventArgs) Handles BunifuLabel3.Click

    End Sub

    Private Sub BunifuLabel4_Click(sender As Object, e As EventArgs) Handles BunifuLabel4.Click

    End Sub

    Private Sub BunifuTextBox1_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox1.TextChanged

    End Sub

    Private Sub BunifuLabel1_Click(sender As Object, e As EventArgs) Handles BunifuLabel1.Click

    End Sub
End Class