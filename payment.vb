Imports System.IO
Imports System.Data.SqlClient
Public Class payment
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Customer.Show()
    End Sub
    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True
        Timer1.Enabled = 1000
        '##################################################################################################################################################################################################################

        Dim user As String
        user = Login.BunifuTextBox1.Text
        BunifuLabel13.Text = "Hi, " & user
        Dim user1 = user
        Dim name = BunifuTextBox1.Text
        Dim address = BunifuTextBox3.Text
        Dim state = BunifuTextBox4.Text
        Dim email = BunifuTextBox7.Text
        Dim phno = BunifuTextBox8.Text
        Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "SELECT [username],[name],[address],[state],[pincode],[email],[phno]FROM [dbo].[delivery] where username=@username"
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader
        con.Open()
        cmd.Parameters.AddWithValue("@username", user1)
        reader = cmd.ExecuteReader()
        If reader.Read() Then

            user = reader("username").ToString
            BunifuTextBox1.Text = reader("name").ToString()
            BunifuTextBox3.Text = reader("address").ToString()
            BunifuTextBox4.Text = reader("state").ToString()
            BunifuTextBox7.Text = reader("email").ToString()
            BunifuTextBox8.Text = reader("phno").ToString()
            BunifuTextBox6.Text = reader("pincode").ToString()

        End If
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim user = Login.BunifuTextBox1.Text
        Dim user1 = user
        Dim name = BunifuTextBox1.Text
        Dim address = BunifuTextBox3.Text
        Dim state = BunifuTextBox4.Text
        Dim email = BunifuTextBox7.Text
        Dim phno = BunifuTextBox8.Text
        Dim pincode = BunifuTextBox6.Text

        If String.IsNullOrEmpty(name) Then
            MessageBox.Show("Enter Name")
            Exit Sub
        End If

        If String.IsNullOrEmpty(address) Then
            MessageBox.Show("Enter Address")
            Exit Sub
        End If

        If String.IsNullOrEmpty(state) Then
            MessageBox.Show("Enter State")
            Exit Sub
        End If
        If pincode.Length < 6 Then
            MessageBox.Show("Enter a valid Pincode")
            pincode = pincode.Substring(0, pincode.Length)
            Exit Sub
        ElseIf pincode.Length > 6 Then
            MessageBox.Show("Maximum 6 characters allowed!")
            pincode = pincode.Substring(0, 6)
            Exit Sub
        End If
        If Not BunifuTextBox7.Text.Contains("@") Then
            MessageBox.Show("Enter valid Email Id")
            Exit Sub
        End If

        If String.IsNullOrEmpty(email) Then
            MessageBox.Show("Enter Email")
            Exit Sub
        End If
        If phno.Length < 10 Then
            MessageBox.Show("Enter a valid Phone Number")
            phno = phno.Substring(0, phno.Length)
            Exit Sub
        ElseIf phno.Length > 10 Then
            MessageBox.Show("Maximum 6 characters allowed!")
            phno = phno.Substring(0, 10)
            Exit Sub
        End If
        Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "INSERT INTO [dbo].[delivery] VALUES (@username,@name,@address,@state,@pincode,@email,@phno)"
        Dim cmd As New SqlCommand(query, con)
        con.Open()
        cmd.Parameters.AddWithValue("@username", user1)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@address", address)
        cmd.Parameters.AddWithValue("@state", state)
        cmd.Parameters.AddWithValue("@email", email)
        cmd.Parameters.AddWithValue("@phno", phno)
        cmd.Parameters.AddWithValue("@pincode", pincode)
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Details Saved")
        Catch ex As Exception
            MessageBox.Show("Already Exits")
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Card.Show()
        End If
        If RadioButton1.Checked = False Then
            Card.Hide()
        End If
    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click

        Dim user = Login.BunifuTextBox1.Text
        Dim user1 = user
        Dim name = BunifuTextBox1.Text
        Dim address = BunifuTextBox3.Text
        Dim state = BunifuTextBox4.Text
        Dim email = BunifuTextBox7.Text
        Dim phno = BunifuTextBox8.Text
        Dim pincode = BunifuTextBox6.Text

        Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "UPDATE [dbo].[delivery] SET name=@name,address=@address,state=@state,pincode=@pincode,email=@email,phno=@phno WHERE username=@username "
        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = user1
        cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address
        cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = state
        cmd.Parameters.Add("@pincode", SqlDbType.VarChar).Value = pincode
        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email
        cmd.Parameters.Add("@phno", SqlDbType.VarChar).Value = phno
        con.Open()

        If cmd.ExecuteNonQuery() = 1 Then
            MessageBox.Show("values updated")
        Else
            MessageBox.Show("Not Updated")
        End If
        con.Close()

    End Sub
    Public Sub BunifuPanel3_Paint(sender As Object, e As PaintEventArgs) Handles BunifuPanel3.Paint
        Dim user As String
        user = Login.BunifuTextBox1.Text
        BunifuLabel13.Text = user
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim query As String = "SELECT name, price, quantity, size FROM [dbo].[cart] where username=@username"
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim totalPrice As Double = 0
        con.Open()
        cmd.Parameters.AddWithValue("username", user)
        Dim dr As SqlDataReader = cmd.ExecuteReader


        FlowLayoutPanel1.Controls.Clear()

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
            panel.Size = New Size(400, 30)
            panel.Location = New Point((FlowLayoutPanel1.Width - panel.Width) / 2, FlowLayoutPanel1.Controls.Count * 50)
            panel.BorderStyle = BorderStyle.None
            panel.Margin = New Padding(20)
            panel.ForeColor = Color.FromArgb(75, 73, 73)
            panel.BackgroundColor = Color.FromArgb(24, 24, 24)
            FlowLayoutPanel1.Controls.Add(panel)


            Dim label1 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label1.Text = name
            label1.Location = New Point(20, 10)
            label1.Font = New Font("Inter", 9)
            label1.ForeColor = Color.White
            label1.Margin = New Padding(5)
            panel.Controls.Add(label1)

            Dim label2 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label2.Text = price
            label2.Font = New Font("inter", 9)
            label2.ForeColor = Color.White
            label2.Location = New Point(200, 10)
            panel.Controls.Add(label2)

            Dim label3 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label3.Text = qty
            label3.Location = New Point(300, 10)
            label3.Font = New Font("inter", 9)
            label3.ForeColor = Color.White
            panel.Controls.Add(label3)

            Dim label4 As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel()
            label4.Text = size
            label4.Location = New Point(345, 10)
            label4.Font = New Font("inter", 9)
            label4.ForeColor = Color.White
            panel.Controls.Add(label4)



        End While
        BunifuLabel14.Text = totalPrice
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim user As String
        user = Login.BunifuTextBox1.Text
        Dim name1 = BunifuTextBox1.Text
        Dim address1 = BunifuTextBox3.Text
        Dim state1 = BunifuTextBox4.Text
        Dim email1 = BunifuTextBox7.Text
        Dim phno1 = BunifuTextBox8.Text
        Dim pincode1 = BunifuTextBox6.Text

        If name1 = Nothing Or address1 = Nothing Or state1 = Nothing Or email1 = Nothing Or phno1 = Nothing Or pincode1 = Nothing Then
            MessageBox.Show("Fill Details")
            Exit Sub
        End If
        If RadioButton1.Checked = False And RadioButton2.Checked = False And RadioButton3.Checked = False Then
            MessageBox.Show("Please Choose Payment Method")
        Else
            Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim query As String = "INSERT INTO [Orders] VALUES (@name,@address,@productname,@qty,@size,@state,@pincode,@phno,@tid,@login,GetDate(),@price)"
            Dim cmd As New SqlCommand(query, con)
            Dim upi = RadioButton2.Checked
            Dim card = RadioButton1.Checked
            Dim cash = RadioButton1.Checked
            Dim name = BunifuTextBox1.Text
            Dim address = BunifuTextBox3.Text
            Dim state = BunifuTextBox4.Text
            Dim pincode = BunifuTextBox6.Text
            Dim phno = BunifuTextBox8.Text
            Dim time = Timer1.Enabled

            For Each panel As Bunifu.UI.WinForms.BunifuPanel In FlowLayoutPanel1.Controls
                Dim pname As String = panel.Controls(0).Text
                Dim price As Double = CDbl(panel.Controls(1).Text)
                Dim quantity As Integer = (panel.Controls(2).Text)
                Dim size As String = panel.Controls(3).Text
                Dim tid As Integer = 0
                con.Open()
                Dim getTidCmd As New SqlCommand("SELECT MAX(tid) FROM Payment", con)
                Dim tidResult As Object = getTidCmd.ExecuteScalar()
                If Not IsDBNull(tidResult) Then
                    tid = CInt(tidResult)
                End If
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@address", address)
                cmd.Parameters.AddWithValue("@productname", pname)
                cmd.Parameters.AddWithValue("@qty", quantity)
                cmd.Parameters.AddWithValue("@size", size)
                cmd.Parameters.AddWithValue("@state", state)
                cmd.Parameters.AddWithValue("@pincode", pincode)
                cmd.Parameters.AddWithValue("@phno", phno)
                cmd.Parameters.AddWithValue("@tid", tid)
                cmd.Parameters.AddWithValue("@login", user)
                cmd.Parameters.AddWithValue("@price", price)
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error Occurred while placing the order for " & ex.Message)
                    Exit Sub
                End Try
                Dim productName As String = panel.Controls(0).Text
                Dim quantity1 As Integer = panel.Controls(2).Text
                Dim updateMenCmd As New SqlCommand("UPDATE men SET Quantity = Quantity - @Qty WHERE name = @productname", con)
                updateMenCmd.Parameters.AddWithValue("@Qty", quantity1)
                updateMenCmd.Parameters.AddWithValue("@productname", productName)
                Dim updateWomenCmd As New SqlCommand("UPDATE table_2 SET Quantity = Quantity - @Qty WHERE name = @productname", con)
                updateWomenCmd.Parameters.AddWithValue("@Qty", quantity1)
                updateWomenCmd.Parameters.AddWithValue("@productname", productName)

                Try
                    updateMenCmd.ExecuteNonQuery()
                    updateWomenCmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error Occurred while updating the quantity for " & ex.Message)
                    Exit Sub
                End Try

                con.Close()
            Next
            Dim con2 As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim query2 As String = "DELETE FROM cart where username=@username"
            Dim cmd2 As New SqlCommand(query2, con2)
            con2.Open()
            Try
                cmd2.Parameters.Add("@username", SqlDbType.VarChar).Value = user
                cmd2.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("No cart items" & ex.Message)
            End Try
            Me.Hide()
            conformation.Show()
        End If



        '==================================================================================================================================


    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            upi.Show()
        End If
        If RadioButton2.Checked = False Then
            upi.Hide()
        End If
    End Sub

    Private Sub BunifuLabel12_Click(sender As Object, e As EventArgs) Handles BunifuLabel12.Click

    End Sub

    Private Sub BunifuTextBox7_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox7.TextChanged

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            Dim amount = BunifuLabel14.Text
            Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim query As String = "INSERT INTO Payment (payment_type,amount) VALUES ('COD',@amount)"
            Dim cmd As New SqlCommand(query, con)
            con.Open()
            cmd.Parameters.AddWithValue("@amount", amount)
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("COD payment type added")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
            con.Close()
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Customer.Show()
    End Sub

    Private Sub BunifuPanel3_Click(sender As Object, e As EventArgs) Handles BunifuPanel3.Click

    End Sub
End Class
