Imports System.IO
Imports System.Data.SqlClient
Public Class bill
    Private Sub bill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim user As String = Login.BunifuTextBox1.Text
        BunifuLabel1.Text = user
        user = Login.BunifuTextBox1.Text
        BunifuLabel1.Text = "Hi, " & user
        Dim user1 = user
        Dim name = BunifuLabel2.Text
        Dim address = BunifuLabel5.Text
        Dim state = BunifuLabel4.Text
        Dim phno = BunifuLabel3.Text
        Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "SELECT [username],[name],[address],[state],[pincode],[email],[phno]FROM [dbo].[delivery] where username=@username"
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader
        con.Open()
        cmd.Parameters.AddWithValue("@username", user1)
        reader = cmd.ExecuteReader()
        If reader.Read() Then

            user = reader("username").ToString
            BunifuLabel2.Text = reader("name").ToString()
            BunifuLabel5.Text = reader("address").ToString()
            BunifuLabel4.Text = reader("state").ToString()
            BunifuLabel3.Text = reader("phno").ToString()
        End If
    End Sub
End Class