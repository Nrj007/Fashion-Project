Imports Bunifu
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class sample
    Private Sub sample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As SqlConnection = New SqlConnection("Data Source=DESKTOP-UEAJQU3\SQLEXPRESS;Initial Catalog=Fashion1;Integrated Security=True")
        Dim command As New SqlCommand("SELECT [Id],[name],[quantity],[price],[category],[image] FROM [dbo].[Table_2] ", con)
        Dim reader As SqlDataReader
        con.Open()
        reader = command.ExecuteReader
        If reader.Read() Then

            Dim data As Byte() = reader("Image")
            Dim ms As New MemoryStream(data)
            PictureBox1.Image = Image.FromStream(ms)
            Label1.Text = reader("name").ToString()
            Label2.Text = reader("price").ToString()

        End If
    End Sub


End Class