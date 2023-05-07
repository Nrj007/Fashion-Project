Imports System.Data.SqlClient
Public Class carts
    Private Sub carts_Load(sender As Object, e As EventArgs) Handles MyBase.Load


      
        Dim user As String
        user = Login.BunifuTextBox1.Text
        Label1.Text = user
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "SELECT name, price, quantity, size FROM [dbo].[cart] where username=@username"
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim totalPrice As Double = 0
        con.Open()
        cmd.Parameters.AddWithValue("username", user)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        While dr.Read()
            Dim name = dr("name").ToString()
            Dim priceStr = dr("price").ToString()
            Dim qtyStr = dr("quantity").ToString()
            Dim size = dr("size").ToString()

            Dim qty As Integer = 0
            Integer.TryParse(qtyStr, qty)

            Dim price As Double = 0
            If Double.TryParse(priceStr, price) Then
                totalPrice += price * qty
            End If

            Dim panel As Bunifu.UI.WinForms.BunifuPanel = New Bunifu.UI.WinForms.BunifuPanel()
            panel.Size = New Size(680, 50)
            panel.Location = New Point((FlowLayoutPanel1.Width - panel.Width) / 2, FlowLayoutPanel1.Controls.Count * 50)
            panel.BorderStyle = BorderStyle.None
            panel.Margin = New Padding(20)
            panel.ForeColor = Color.FromArgb(75, 73, 73)
            panel.BackgroundColor = Color.FromArgb(24, 24, 24)
            FlowLayoutPanel1.Controls.Add(panel)


            Dim label1 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label1.Text = name
            label1.Location = New Point(10, 10)
            label1.Font = New Font("Inter", 16)
            label1.ForeColor = Color.White
            label1.Margin = New Padding(5)
            panel.Controls.Add(label1)

            Dim label2 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label2.Text = price
            label2.Font = New Font("inter", 16)
            label2.ForeColor = Color.White
            label2.Location = New Point(150, 10)
            panel.Controls.Add(label2)

            Dim label3 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label3.Text = qty
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

            Dim button As Button = New Button()
            button.Text = "Remove"
            button.Location = New Point(450, 10)
            panel.Controls.Add(button)
            button.Tag = name
            button.BackColor = Color.White


            Dim button1 As Button = New Button()
            button1.Text = "Buy Now"
            button1.Location = New Point(550, 10)
            panel.Controls.Add(button1)
            AddHandler button1.Click, AddressOf Button1_Click
            AddHandler button.Click, AddressOf Button_Click

            BunifuLabel1.Text = "Total: " & totalPrice.ToString("C2")

        End While
        dr.Close()
        con.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Customer.Hide()
        Women.Hide()
        Men.Hide()
        Me.Hide()
        payment.Show()
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim button As Button = CType(sender, Button)
        If button IsNot Nothing Then
            Dim panel As Control = button.Parent
            Dim itemName As String = button.Tag.ToString()
            Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim query As String = "DELETE FROM cart WHERE name=@name"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@name", itemName)
            con.Open()

            Try
                cmd.ExecuteNonQuery()
                FlowLayoutPanel1.Controls.Remove(panel)
                MessageBox.Show("Item removed from cart.")


                Dim user As String = Login.BunifuTextBox1.Text
                Dim totalPrice As Double = 0
                Dim con2 As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
                Dim query2 As String = "SELECT price, quantity FROM [dbo].[cart] where username=@username"
                Dim cmd2 As SqlCommand = New SqlCommand(query2, con2)
                con2.Open()
                cmd2.Parameters.AddWithValue("username", user)
                Dim dr As SqlDataReader = cmd2.ExecuteReader
                While dr.Read()
                    Dim priceStr = dr("price").ToString()
                    Dim qtyStr = dr("quantity").ToString()

                    Dim qty As Integer = 0
                    Integer.TryParse(qtyStr, qty)

                    Dim price As Double = 0
                    If Double.TryParse(priceStr, price) Then
                        totalPrice += price * qty
                    End If
                End While
                dr.Close()
                con2.Close()
                BunifuLabel1.Text = "Total: " & totalPrice.ToString("C2")

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
                MessageBox.Show("An error occurred while removing the item." & ex.Message)
            End Try
            con.Close()
            FlowLayoutPanel1.Controls.Remove(panel)
        End If
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class
