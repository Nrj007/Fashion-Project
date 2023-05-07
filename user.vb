Imports System.Data.SqlClient
Imports System.IO
Public Class user
    Private Sub BunifuPictureBox1_Click(sender As Object, e As EventArgs) Handles BunifuPictureBox1.Click
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            BunifuPictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim user As String = Login.BunifuTextBox1.Text
        BunifuLabel1.Text = user
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "SELECT productname, qty, size FROM [dbo].[orders] where login=@login"
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim totalPrice As Double = 0
        con.Open()
        cmd.Parameters.AddWithValue("login", user)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        While dr.Read()
            Dim name = dr("productname").ToString()
            Dim qtyStr = dr("qty").ToString()
            Dim size = dr("size").ToString()

            Dim price As Double = 0
            Dim panel As Bunifu.UI.WinForms.BunifuPanel = New Bunifu.UI.WinForms.BunifuPanel()
            panel.Size = New Size(680, 50)
            panel.Location = New Point((FlowLayoutPanel1.Width - panel.Width) / 2, FlowLayoutPanel1.Controls.Count * 50)
            panel.BorderStyle = BorderStyle.None
            panel.Margin = New Padding(20)
            panel.ForeColor = Color.FromArgb(75, 73, 73)
            panel.BackgroundColor = Color.Black
            panel.BorderRadius = BorderStyle.FixedSingle
            FlowLayoutPanel1.Controls.Add(panel)

            Dim label1 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label1.Text = name
            label1.Location = New Point(10, 10)
            label1.Font = New Font("Inter", 16)
            label1.ForeColor = Color.White
            label1.Margin = New Padding(5)
            panel.Controls.Add(label1)

            Dim label3 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label3.Text = qtyStr
            label3.Location = New Point(250, 10)
            label3.Font = New Font("inter", 16)
            label3.ForeColor = Color.White
            panel.Controls.Add(label3)

            Dim label4 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label4.Text = size
            label4.Location = New Point(350, 10)
            label4.Font = New Font("inter", 16)
            label4.ForeColor = Color.White
            panel.Controls.Add(label4)


        End While
        dr.Close()

        Dim user1 As String = Login.BunifuTextBox1.Text
        Dim con1 As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query1 = "SELECT Id FROM customer WHERE username=@username"
        Dim cm1d As New SqlCommand(query1, con1)
        con1.Open()
        cm1d.Parameters.AddWithValue("username", user1)
        Dim reader As SqlDataReader = cm1d.ExecuteReader()
        If reader.Read() Then
            Dim customerId As String = reader("Id").ToString()
            BunifuLabel3.Text = customerId
        End If
        reader.Close()
        con1.Close()


        Dim con2 As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim command1 As New SqlCommand("SELECT [pic] FROM [dbo].[customer] WHERE username = @username", con2)
        command1.Parameters.AddWithValue("@username", user)
        con2.Open()
        Dim rdr As SqlDataReader
        rdr = command1.ExecuteReader
        If rdr.Read() Then
            Dim data As Byte() = rdr("pic")
            Dim ms As New MemoryStream(data)
            BunifuPictureBox1.Image = Image.FromStream(ms)
        End If

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim image As Image = BunifuPictureBox1.Image
        Dim filesize As New UInt32
        Dim ms As New System.IO.MemoryStream
        BunifuPictureBox1.Image.Save(ms, BunifuPictureBox1.Image.RawFormat)
        Dim picture() As Byte = ms.GetBuffer
        filesize = ms.Length()
        Dim password As String = BunifuTextBox1.Text
        Dim user As String = Login.BunifuTextBox1.Text
        BunifuLabel1.Text = user
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "UPDATE CUSTOMER SET password=@password where username=@username "
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        If password = Nothing Then
            MessageBox.Show("Enter Password ")
        Else
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = user
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture

            con.Open()

            If cmd.ExecuteNonQuery() = 1 Then
                MessageBox.Show(" Updated")
            Else
                MessageBox.Show("Not Updated")
            End If
            con.Close()
        End If
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim image As Image = BunifuPictureBox1.Image
        Dim filesize As New UInt32
        Dim ms As New System.IO.MemoryStream
        BunifuPictureBox1.Image.Save(ms, BunifuPictureBox1.Image.RawFormat)
        Dim picture() As Byte = ms.GetBuffer
        filesize = ms.Length()
        Dim user As String = Login.BunifuTextBox1.Text
        BunifuLabel1.Text = user
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "UPDATE CUSTOMER SET pic=@pic where username=@username "
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = user
        cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture
        con.Open()

            If cmd.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Profile Pic Updated")
        Else
            MessageBox.Show("Not Updated")
        End If
        con.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub BunifuPanel2_Click(sender As Object, e As EventArgs) Handles BunifuPanel2.Click

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class