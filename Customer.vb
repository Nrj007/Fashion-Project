Imports System.Data.SqlClient
Imports System.IO
Public Class Customer
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim user As String = Login.BunifuTextBox1.Text
        BunifuLabel1.Text = "Hi, " & user

        Dim timer As New Timer()
        timer.Interval = 1000 ' 1 second
        AddHandler timer.Tick, AddressOf UpdateCounts
        timer.Start()
    End Sub

    Private Sub UpdateCounts(sender As Object, e As EventArgs)
        Dim user As String = Login.BunifuTextBox1.Text
        Dim count As Integer = 0


        Using con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim query As String = "SELECT COUNT(DISTINCT name) AS nameCount FROM cart WHERE username=@username"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@username", user)
            con.Open()
            count = CInt(cmd.ExecuteScalar())
        End Using
        BunifuLabel5.Text = count.ToString()


        Dim con1 As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim command1 As New SqlCommand("SELECT [pic] FROM [dbo].[customer] WHERE username = @username", con1)
        command1.Parameters.AddWithValue("@username", user)
        con1.Open()
        Dim reader As SqlDataReader
        reader = command1.ExecuteReader
        If reader.Read() Then
            Dim data As Byte() = reader("pic")
            Dim ms As New MemoryStream(data)
            BunifuPictureBox2.Image = Image.FromStream(ms)
        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Hide()
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Me.Hide()
        Women.Show()
    End Sub
    Private Sub BunifuLabel1_Click(sender As Object, e As EventArgs) Handles BunifuLabel1.Click
        user.Show()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Me.Hide()
        Men.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Hide()
        Men.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Hide()
        Women.Show()
    End Sub
    Private Sub BunifuImageButton1_Click_2(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        carts.Show()
    End Sub

    Private Sub BunifuPanel2_Click(sender As Object, e As EventArgs) Handles BunifuPanel2.Click

    End Sub

    Private Sub BunifuLabel2_Click(sender As Object, e As EventArgs) Handles BunifuLabel2.Click

    End Sub

    Private Sub BunifuLabel5_Click(sender As Object, e As EventArgs) Handles BunifuLabel5.Click

    End Sub

    Private Sub BunifuLabel8_Click(sender As Object, e As EventArgs) Handles BunifuLabel8.Click

    End Sub

    Private Sub BunifuLabel6_Click(sender As Object, e As EventArgs) Handles BunifuLabel6.Click
        Me.Hide()
        Women.Show()
    End Sub

    Private Sub BunifuLabel7_Click(sender As Object, e As EventArgs) Handles BunifuLabel7.Click
        Me.Hide()
        Men.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        user.Show()
    End Sub

    Private Sub BunifuShadowPanel1_ControlAdded(sender As Object, e As ControlEventArgs) Handles BunifuShadowPanel1.ControlAdded

    End Sub
End Class