Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Bunifu
Public Class Admin
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.Visible = False
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.Visible = True
    End Sub

    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        '====================================================Insering values_1 =========================================================================
        Dim Id As String = BunifuTextBox1.Text
        Dim name As String = BunifuTextBox2.Text
        Dim qty As String = BunifuTextBox3.Text
        Dim price As String = BunifuTextBox4.Text
        Dim category As String = BunifuTextBox5.Text
        Dim query As String = "INSERT INTO [dbo].[men] VALUES (@Id,@name,@quantity,@price,@category,@image)"
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Try
            con.Open()
        Catch ex As Exception
            MessageBox.Show("connection timeout")
        End Try
        Try
            Dim image As Image = PictureBox1.Image
            Dim filesize As New UInt32
            Dim ms As New System.IO.MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim picture() As Byte = ms.GetBuffer
            filesize = ms.Length()
            ms.Close()
            If Id = Nothing Or name = Nothing Or qty = Nothing Or price = Nothing Or category = Nothing Then
                MessageBox.Show("Fill The Details")
            Else
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@Id", Id)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@quantity", qty)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@price", price)
                cmd.Parameters.AddWithValue("@image", picture)

                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("sucess")
                Catch ex As Exception
                    MessageBox.Show("id already")
                End Try

                con.Close()
            End If
        Catch ex As NullReferenceException
            MessageBox.Show("fill details")
        End Try
    End Sub

    Private Sub update_Click(sender As Object, e As EventArgs) Handles update.Click

        Try
            '=======================================================UPADTE_1===============================================================================
            Dim image As Image = PictureBox1.Image
            Dim filesize As New UInt32
            Dim ms As New System.IO.MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim picture() As Byte = ms.GetBuffer
            filesize = ms.Length()
            Dim Id As String = BunifuTextBox1.Text
            Dim name As String = BunifuTextBox2.Text
            Dim qty As String = BunifuTextBox3.Text
            Dim price As String = BunifuTextBox4.Text
            Dim category As String = BunifuTextBox5.Text
            Dim query As String = "UPDATE men SET name=@name,quantity=@quantity,price=@price,category=@category,image=@image WHERE Id=@Id"
            Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim cmd As SqlCommand = New SqlCommand(query, con)

            If Id = Nothing Then
                MessageBox.Show("Enter Product Id ")
            Else
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name
                cmd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = qty
                cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = category
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = price
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = picture

                con.Open()

                If cmd.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("values updated")
                Else
                    MessageBox.Show("Not Updated")
                End If
                con.Close()
            End If

        Catch ex As NullReferenceException
            MessageBox.Show(" Enter ID and Image  ")
        End Try
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click

        Try
            '===============================================================DELETE_1=============================================================================
            Dim image As Image = PictureBox1.Image
            Dim filesize As New UInt32
            Dim ms As New System.IO.MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim picture() As Byte = ms.GetBuffer
            filesize = ms.Length()

            Dim Id As String = BunifuTextBox1.Text
            Dim name As String = BunifuTextBox2.Text
            Dim qty As String = BunifuTextBox3.Text
            Dim price As String = BunifuTextBox4.Text
            Dim category As String = BunifuTextBox5.Text
            Dim query As String = "DELETE FROM men WHERE Id=@Id"
            Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            con.Open()
            If Id = Nothing Then
                MessageBox.Show("Enter Product Id ")
            Else
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = picture
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name
                cmd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = qty
                cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = category
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = price
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id

                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Product Deleted")
                Catch ex As Exception
                    MessageBox.Show("Connection Timedout")
                End Try

            End If
        Catch ex As NullReferenceException
            MessageBox.Show(" Enter Product ID AND IMAGE ")
        End Try
        BunifuTextBox1.Clear()
        BunifuTextBox2.Clear()
        BunifuTextBox3.Clear()
        BunifuTextBox4.Clear()
        BunifuTextBox5.Clear()
        PictureBox1.Image = Nothing
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click

        '===================================================CLEARING_1=========================================================================
        BunifuTextBox1.Clear()
        BunifuTextBox2.Clear()
        BunifuTextBox3.Clear()
        BunifuTextBox4.Clear()
        BunifuTextBox5.Clear()
        PictureBox1.Image = Nothing
    End Sub

    Private Sub BunifuButton4_Click(sender As Object, e As EventArgs) Handles BunifuButton4.Click
        '===================================================Picture_1=======================================================================================
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Date.Now.ToString("dd-MMM-yy | hh:mm:ss")
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click

        'Retrieve


        Dim Id As String = BunifuTextBox1.Text
        Dim name As String = BunifuTextBox2.Text
        Dim qty As String = BunifuTextBox3.Text
        Dim price As String = BunifuTextBox4.Text
        Dim category As String = BunifuTextBox5.Text
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")

        Dim command As New SqlCommand("SELECT [Id],[name],[quantity],[price],[category],[image] FROM [dbo].[men] WHERE Id = @Id", con)

        command.Parameters.AddWithValue("@Id", Id)
        command.Parameters.AddWithValue("@name", name)
        command.Parameters.AddWithValue("@quantity", qty)
        command.Parameters.AddWithValue("@category", category)
        command.Parameters.AddWithValue("@price", price)
        Dim reader As SqlDataReader
        con.Open()
        reader = command.ExecuteReader
        If reader.Read() Then
            Dim data As Byte() = reader("Image")
            Dim ms As New MemoryStream(data)
            PictureBox1.Image = Image.FromStream(ms)
            BunifuTextBox2.Text = reader("name").ToString()
            BunifuTextBox3.Text = reader("quantity").ToString()
            BunifuTextBox4.Text = reader("price").ToString()
            BunifuTextBox5.Text = reader("category").ToString()

        Else
            MessageBox.Show("Id Invalid")

        End If
    End Sub


    ''-----------------WOMEN FASHION-------------------------------------------------------------------------------------
    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        Dim Id As String = BunifuTextBox6.Text
        Dim name As String = BunifuTextBox7.Text
        Dim qty As String = BunifuTextBox8.Text
        Dim price As String = BunifuTextBox9.Text
        Dim category As String = BunifuTextBox10.Text

        ''----------------------------------INSERTING VALUES -------------------------------

        Dim query As String = "INSERT INTO Table_2 VALUES (@Id,@name,@quantity,@category,@price,@image)"
        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(query, con)


        con.Open()

        Try
            Dim image As Image = PictureBox2.Image
            Dim filesize As New UInt32
            Dim ms As New System.IO.MemoryStream
            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
            Dim picture() As Byte = ms.GetBuffer
            filesize = ms.Length()

            ms.Close()
            If Id = Nothing Or name = Nothing Or qty = Nothing Or price = Nothing Or category = Nothing Then
                MessageBox.Show("Fill The Details")
            Else
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@Id", Id)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@quantity", qty)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@price", price)
                cmd.Parameters.AddWithValue("@image", picture)

                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("sucess")
                Catch ex As Exception
                    MessageBox.Show("id already")
                End Try

                con.Close()
            End If

        Catch ex As NullReferenceException
            MessageBox.Show("fill details")
        End Try
    End Sub

    ''-------------------------------Picture Box 2-----------------------------------
    Private Sub BunifuButton9_Click(sender As Object, e As EventArgs) Handles BunifuButton9.Click
        OpenFileDialog2.FileName = ""
        If OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog2.FileName)
        End If
    End Sub

    Private Sub retrieve_Click(sender As Object, e As EventArgs) Handles retrieve.Click
        Dim Id As String = BunifuTextBox6.Text
        Dim name As String = BunifuTextBox7.Text
        Dim qty As String = BunifuTextBox8.Text
        Dim price As String = BunifuTextBox9.Text
        Dim category As String = BunifuTextBox10.Text

        ''----------------------------------------------RETRIEVE_2-----------------------------------------------------------------------------------

        Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim command As New SqlCommand("SELECT [Id],[name],[quantity],[price],[category],[image] FROM [dbo].[Table_2] WHERE Id = @Id", con)

        command.Parameters.AddWithValue("@Id", Id)
        command.Parameters.AddWithValue("@name", name)
        command.Parameters.AddWithValue("@quantity", qty)
        command.Parameters.AddWithValue("@category", category)
        command.Parameters.AddWithValue("@price", price)
        Dim reader As SqlDataReader
        con.Open()
        reader = command.ExecuteReader
        If reader.Read() Then
            Dim data As Byte() = reader("Image")
            Dim ms As New MemoryStream(data)
            PictureBox2.Image = Image.FromStream(ms)
            BunifuTextBox7.Text = reader("name").ToString()
            BunifuTextBox8.Text = reader("quantity").ToString()
            BunifuTextBox9.Text = reader("price").ToString()
            BunifuTextBox10.Text = reader("category").ToString()

        Else
            MessageBox.Show("Id Invalid")

        End If
    End Sub

    Private Sub BunifuButton7_Click(sender As Object, e As EventArgs) Handles BunifuButton7.Click
        Try
            Dim image As Image = PictureBox2.Image
            Dim filesize As New UInt32
            Dim ms As New System.IO.MemoryStream
            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
            Dim picture() As Byte = ms.GetBuffer
            filesize = ms.Length()


            Dim Id As String = BunifuTextBox6.Text
            Dim name As String = BunifuTextBox7.Text
            Dim qty As String = BunifuTextBox8.Text
            Dim price As String = BunifuTextBox9.Text
            Dim category As String = BunifuTextBox10.Text

            '------------------------------------------UPDATING VALUES_2------------------------------------------------------------------------

            Dim query As String = "UPDATE Table_2 SET name=@name,quantity=@quantity,price=@price,category=@category,image=@image WHERE Id=@Id"
            Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim cmd As SqlCommand = New SqlCommand(query, con)

            If Id = Nothing Then
                MessageBox.Show("Enter Product Id ")

            Else

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name
                cmd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = qty
                cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = category
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = price
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = picture

                con.Open()

                If cmd.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("values updated")
                Else
                    MessageBox.Show("Not Updated")
                End If
                con.Close()

            End If

        Catch ex As NullReferenceException
            MessageBox.Show(" Enter ID and Image  ")
        End Try


    End Sub

    Private Sub BunifuButton8_Click(sender As Object, e As EventArgs) Handles BunifuButton8.Click
        Try
            Dim image As Image = PictureBox2.Image
            Dim filesize As New UInt32
            Dim ms As New System.IO.MemoryStream
            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
            Dim picture() As Byte = ms.GetBuffer
            filesize = ms.Length()

            Dim Id As String = BunifuTextBox6.Text
            Dim name As String = BunifuTextBox7.Text
            Dim qty As String = BunifuTextBox8.Text
            Dim price As String = BunifuTextBox9.Text
            Dim category As String = BunifuTextBox10.Text

            ''----------------------------------------DELETING_2------------------------------------------------

            Dim query As String = "DELETE FROM Table_2 WHERE Id=@Id"
            Dim con As SqlConnection = New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            con.Open()
            If Id = Nothing Then
                MessageBox.Show("Enter Product Id ")
            Else
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = picture
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name
                cmd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = qty
                cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = category
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = price
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id
                cmd.ExecuteNonQuery()
                MessageBox.Show("Product Deleted")
            End If
        Catch ex As NullReferenceException
            MessageBox.Show(" Enter Product ID AND IMAGE ")
        End Try
        BunifuTextBox6.Clear()
        BunifuTextBox7.Clear()
        BunifuTextBox8.Clear()
        BunifuTextBox9.Clear()
        BunifuTextBox10.Clear()
        PictureBox2.Image = Nothing
    End Sub
    Private Sub BunifuButton6_Click(sender As Object, e As EventArgs)
        '----------------------------------------------------------CLEARING_2---------------------------------------------------------------------------
        BunifuTextBox6.Clear()
        BunifuTextBox7.Clear()
        BunifuTextBox8.Clear()
        BunifuTextBox9.Clear()
        BunifuTextBox10.Clear()
        PictureBox2.Image = Nothing
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Preview.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Men.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Preview.LinkClicked
        Men.Show()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

        TabPage1.Visible = False
        TabPage2.Visible = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Inventory.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Reports.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked_2(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Women.Show()

    End Sub
End Class

