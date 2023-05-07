Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class test1
    Public Sub New(pic As Image, name As String)
        Dim price = BunifuLabel1
        InitializeComponent()
        PictureBox1.Image = pic
        BunifuLabel2.Text = name
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim command As New SqlCommand("SELECT price FROM ( SELECT price  FROM Table_2  WHERE name = @name UNION  SELECT price  FROM Men WHERE name = @name ) AS prices", con)
        command.Parameters.AddWithValue("@name", name)
        Dim reader As SqlDataReader
        con.Open()
        reader = command.ExecuteReader
        If reader.Read() Then

            BunifuLabel1.Text = reader("price").ToString()
        Else
            MessageBox.Show("incorrect")
        End If
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MessageBox.Show("Please select quantity and size")
        Else

            Dim itemName As String = BunifuLabel2.Text
            Dim itemPrice As String = BunifuLabel1.Text
            Dim itemQty As Integer = Integer.Parse(ComboBox1.SelectedItem.ToString())
            Dim itemSize As String = ComboBox2.SelectedItem.ToString()
            Dim totalPrice As String = itemPrice * itemQty

            Dim panel As Bunifu.UI.WinForms.BunifuPanel = New Bunifu.UI.WinForms.BunifuPanel()
            panel.Size = New Size(400, 30)
            panel.Location = New Point((payment_buynow.FlowLayoutPanel1.Width - panel.Width) / 2, payment_buynow.FlowLayoutPanel1.Controls.Count * 50)
            panel.BorderStyle = BorderStyle.None
            panel.Margin = New Padding(20)
            panel.ForeColor = Color.FromArgb(75, 73, 73)
            panel.BackgroundColor = Color.FromArgb(24, 24, 24)

            Dim label1 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label1.Text = itemName
            label1.Location = New Point(20, 10)
            label1.Font = New Font("Inter", 9)
            label1.ForeColor = Color.White
            label1.Margin = New Padding(5)
            Panel.Controls.Add(label1)

            Dim label2 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label2.Text = itemPrice
            label2.Font = New Font("inter", 9)
            label2.ForeColor = Color.White
            label2.Location = New Point(200, 10)
            panel.Controls.Add(label2)

            Dim label3 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label3.Text = itemQty
            label3.Location = New Point(300, 10)
            label3.Font = New Font("inter", 9)
            label3.ForeColor = Color.White
            Panel.Controls.Add(label3)

            Dim label4 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label4.Text = itemSize
            label4.Location = New Point(370, 10)
            label4.Font = New Font("inter", 9)
            label4.ForeColor = Color.White
            Panel.Controls.Add(label4)
            payment_buynow.BunifuLabel14.Text = totalPrice
            payment_buynow.FlowLayoutPanel1.Controls.Add(panel)

            Women.hide()
            Men.Hide()
            Me.Hide()
            payment_buynow.Show()
        End If

    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim user As String
        user = Login.BunifuTextBox1.Text
        Label1.Text = user
        Dim name = BunifuLabel2.Text
        Dim price = BunifuLabel1.Text

        Dim qty = ComboBox1.SelectedItem
        Dim size = ComboBox2.SelectedItem

        If qty = Nothing Or size = Nothing Then
            MessageBox.Show("Fill Details")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim query As String = "INSERT INTO [dbo].[cart] VALUES (@username,@name,@price,@quantity,@size)"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            con.Open()
            cmd.Parameters.AddWithValue("username", user)
            cmd.Parameters.AddWithValue("@name", name)
            cmd.Parameters.AddWithValue("@price", price)
            cmd.Parameters.AddWithValue("@quantity", qty)
            cmd.Parameters.AddWithValue("@size", size)

            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Item Added ")
                Me.Hide()
                Customer.Hide()
            Catch ex As Exception
                MessageBox.Show("Item Already Exists")
            End Try
        End If
    End Sub
    Private Sub BunifuImageButton1_Click_2(sender As Object, e As EventArgs)
        carts.Show()
    End Sub

    Private Sub test1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GunaControlBox1_Click(sender As Object, e As EventArgs) Handles GunaControlBox1.Click

    End Sub
End Class