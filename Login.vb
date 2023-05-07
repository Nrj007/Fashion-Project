
Imports Bunifu
Imports System.Data
Imports System.Data.SqlClient
Public Class Login
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim username As String = BunifuTextBox1.Text
        Dim password As String = BunifuTextBox2.Text
        Dim query As String = "SELECT * FROM dbo.Customer where username=@username and password=@password"
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(query, con)

        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = BunifuTextBox1.Text
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = BunifuTextBox2.Text
        con.Open()

        Dim reader As SqlDataReader = cmd.ExecuteReader

        If BunifuTextBox1.Text = "admin" And BunifuTextBox2.Text = "admin" Then
            Me.Hide()
            MessageBox.Show("Admin Logged ")
            adminpass.Show()
            Exit Sub
        End If
        If (reader.Read()) Then
            BunifuTextBox2.BorderColorIdle = Color.Lime
            BunifuTextBox1.BorderColorIdle = Color.Lime
            MessageBox.Show(" Login Successful! ")
            Me.Hide()
            Customer.Show()

        Else
            BunifuTextBox2.BorderColorIdle = Color.Red
            BunifuTextBox1.BorderColorIdle = Color.Red
            MessageBox.Show("Invalid Credentials!")

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Register.Show()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuLabel2_Click(sender As Object, e As EventArgs) Handles BunifuLabel2.Click
        Me.Hide()
        forget_password.Show()
    End Sub
End Class
