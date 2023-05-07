Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class Men

    Private Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim user As String
        user = Login.BunifuTextBox1.Text
        BunifuLabel1.Text = "Hi, " & user
        FlowLayoutPanel1.Controls.Clear()
        Dim conn As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim cmd As New SqlCommand("SELECT [name], [image] FROM [dbo].[men] ", conn)
        Dim dr As SqlDataReader
        conn.Open()
        dr = cmd.ExecuteReader
        While dr.Read
            Dim len As Long = dr.GetBytes(1, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte
            dr.GetBytes(1, 0, array, 0, CInt(len))
            Dim Pic = New PictureBox
            Pic.Size = New Size(298, 359)
            Pic.BackgroundImageLayout = ImageLayout.Stretch
            Pic.Margin = New Padding(20)

            Dim la = New Label
            la.ForeColor = Color.Black
            la.BackColor = Color.Snow
            la.Dock = DockStyle.Bottom
            la.Font = New Font("bizmo", 13)
            la.TextAlign = ContentAlignment.MiddleCenter

            Dim price As New Button
            price.TextAlign = ContentAlignment.MiddleCenter
            price.Dock = DockStyle.Bottom
            price.BackColor = Color.Black
            price.Height = 35
            price.ForeColor = Color.Snow
            price.Text = "See Details"


            AddHandler price.Click, AddressOf Price_Click
            Dim ms As New System.IO.MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)
            Pic.BackgroundImage = bitmap
            la.Text = dr.Item("name").ToString
            Pic.Controls.Add(la)
            Pic.Controls.Add(price)
            FlowLayoutPanel1.Controls.Add(Pic)

        End While
        Dim timer As New Timer()
        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf UpdateCounts
        timer.Start()


        Dim con1 As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim command1 As New SqlCommand("SELECT [pic] FROM [dbo].[customer] WHERE username = @username", con1)
        command1.Parameters.AddWithValue("@username", user)
        con1.Open()
        Dim reader As SqlDataReader
        reader = command1.ExecuteReader
        If reader.Read() Then
            Dim data As Byte() = reader("pic")
            Dim ms As New MemoryStream(data)
            BunifuPictureBox1.Image = Image.FromStream(ms)
        End If
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
    End Sub

    Private Sub Price_Click(sender As Object, e As EventArgs)
        Dim button = DirectCast(sender, Button)
        Dim picBox = DirectCast(button.Parent, PictureBox)
        Dim pic = picBox.BackgroundImage
        Dim name = picBox.Controls.OfType(Of Label)().FirstOrDefault()?.Text

        Dim newForm As New test1(pic, name)
        newForm.Show()
    End Sub
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Hide()
        Customer.Show()
    End Sub
    Private Sub BunifuTextBox1_TextChanged(sender As Object, e As EventArgs)
        FlowLayoutPanel1.Controls.Clear()

        Dim searchTerm As String = BunifuTextBox1.Text.Trim()
        If searchTerm.Length > 0 Then
            Dim conn As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim cmd As New SqlCommand("SELECT [name], [image] FROM [dbo].[men] WHERE Name LIKE '%' + @SearchTerm + '%'", conn)
            cmd.Parameters.AddWithValue("@SearchTerm", searchTerm)

            conn.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim len As Long = dr.GetBytes(1, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte
                dr.GetBytes(1, 0, array, 0, CInt(len))
                Dim Pic = New PictureBox
                Pic.Size = New Size(298, 359)
                Pic.BackgroundImageLayout = ImageLayout.Stretch
                Pic.Margin = New Padding(20)

                Dim la = New Label
                la.ForeColor = Color.Black
                la.BackColor = Color.Snow
                la.Dock = DockStyle.Bottom
                la.Font = New Font("bizmo", 13)
                la.TextAlign = ContentAlignment.MiddleCenter

                Dim price As New Button
                price.TextAlign = ContentAlignment.MiddleCenter
                price.Dock = DockStyle.Bottom
                price.BackColor = Color.Black
                price.Height = 35
                price.ForeColor = Color.Snow
                price.Text = "See Details"

                AddHandler price.Click, AddressOf Price_Click
                Dim ms As New System.IO.MemoryStream(array)
                Dim bitmap As New System.Drawing.Bitmap(ms)
                Pic.BackgroundImage = bitmap
                la.Text = dr.Item("name").ToString
                Pic.Controls.Add(la)
                Pic.Controls.Add(price)
                FlowLayoutPanel1.Controls.Add(Pic)
            End While
        Else

            Dim conn As New SqlConnection("Data Source=DESKTOP-UEAJQU3\SQLEXPRESS;Initial Catalog=Fashion1;Integrated Security=True")
            Dim cmd As New SqlCommand("SELECT [name], [image] FROM [dbo].[men]", conn)
            Dim dr As SqlDataReader

            conn.Open()
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim len As Long = dr.GetBytes(1, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte
                dr.GetBytes(1, 0, array, 0, CInt(len))
                Dim Pic = New PictureBox
                Pic.Size = New Size(298, 359)
                Pic.BackgroundImageLayout = ImageLayout.Stretch
                Pic.Margin = New Padding(20)

                Dim la = New Label
                la.ForeColor = Color.Black
                la.BackColor = Color.Snow
                la.Dock = DockStyle.Bottom
                la.Font = New Font("bizmo", 13)
                la.TextAlign = ContentAlignment.MiddleCenter

                Dim price As New Button
                price.TextAlign = ContentAlignment.MiddleCenter
                price.Dock = DockStyle.Bottom
                price.BackColor = Color.Black
                price.Height = 35
                price.ForeColor = Color.Snow
                price.Text = "See Details"

                AddHandler price.Click, AddressOf Price_Click
                Dim ms As New System.IO.MemoryStream(array)
                Dim bitmap As New System.Drawing.Bitmap(ms)
                Pic.BackgroundImage = bitmap
                la.Text = dr.Item("name").ToString
                Pic.Controls.Add(la)
                Pic.Controls.Add(price)
                FlowLayoutPanel1.Controls.Add(Pic)

            End While
        End If
    End Sub

    Private Sub BunifuTextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles BunifuTextBox1.TextChanged
        FlowLayoutPanel1.Controls.Clear()

        Dim searchTerm As String = BunifuTextBox1.Text.Trim()
        If searchTerm.Length > 0 Then
            FlowLayoutPanel1.Controls.Clear()
            Dim conn As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim cmd As New SqlCommand("SELECT [name], [image] FROM [dbo].[men] WHERE Name LIKE '%' + @name + '%'", conn)
            cmd.Parameters.AddWithValue("@name", searchTerm)

            conn.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim len As Long = dr.GetBytes(1, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte
                dr.GetBytes(1, 0, array, 0, CInt(len))
                Dim Pic = New PictureBox
                Pic.Size = New Size(298, 359)
                Pic.BackgroundImageLayout = ImageLayout.Stretch
                Pic.Margin = New Padding(20)

                Dim la = New Label
                la.ForeColor = Color.Black
                la.BackColor = Color.Snow
                la.Dock = DockStyle.Bottom
                la.Font = New Font("bizmo", 13)
                la.TextAlign = ContentAlignment.MiddleCenter

                Dim price As New Button
                price.TextAlign = ContentAlignment.MiddleCenter
                price.Dock = DockStyle.Bottom
                price.BackColor = Color.Black
                price.Height = 35
                price.ForeColor = Color.Snow
                price.Text = "See Details"

                AddHandler price.Click, AddressOf Price_Click
                Dim ms As New System.IO.MemoryStream(array)
                Dim bitmap As New System.Drawing.Bitmap(ms)
                Pic.BackgroundImage = bitmap
                la.Text = dr.Item("name").ToString
                Pic.Controls.Add(la)
                Pic.Controls.Add(price)
                FlowLayoutPanel1.Controls.Add(Pic)

            End While
        Else
            Dim conn As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim cmd As New SqlCommand("SELECT [name], [image] FROM [dbo].[men] ", conn)
            Dim dr As SqlDataReader

            conn.Open()
            dr = cmd.ExecuteReader
            While dr.Read
                Dim len As Long = dr.GetBytes(1, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte
                dr.GetBytes(1, 0, array, 0, CInt(len))
                Dim Pic = New PictureBox
                Pic.Size = New Size(298, 359)
                Pic.BackgroundImageLayout = ImageLayout.Stretch
                Pic.Margin = New Padding(20)

                Dim la = New Label
                la.ForeColor = Color.Black
                la.BackColor = Color.Snow
                la.Dock = DockStyle.Bottom
                la.Font = New Font("bizmo", 13)
                la.TextAlign = ContentAlignment.MiddleCenter

                Dim price As New Button
                price.TextAlign = ContentAlignment.MiddleCenter
                price.Dock = DockStyle.Bottom
                price.BackColor = Color.Black
                price.Height = 35
                price.ForeColor = Color.Snow
                price.Text = "See Details"


                AddHandler price.Click, AddressOf Price_Click
                Dim ms As New System.IO.MemoryStream(array)
                Dim bitmap As New System.Drawing.Bitmap(ms)
                Pic.BackgroundImage = bitmap
                la.Text = dr.Item("name").ToString
                Pic.Controls.Add(la)
                Pic.Controls.Add(price)
                FlowLayoutPanel1.Controls.Add(Pic)

            End While
        End If
    End Sub
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        carts.Show()
    End Sub

    Private Sub BunifuLabel7_Click(sender As Object, e As EventArgs) Handles BunifuLabel7.Click

    End Sub

    Private Sub BunifuLabel6_Click(sender As Object, e As EventArgs) Handles BunifuLabel6.Click
        Me.Hide()
        Women.Show()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub BunifuPictureBox1_Click(sender As Object, e As EventArgs) Handles BunifuPictureBox1.Click
        user.Show()
    End Sub

    Private Sub BunifuLabel5_Click(sender As Object, e As EventArgs) Handles BunifuLabel5.Click

    End Sub
End Class