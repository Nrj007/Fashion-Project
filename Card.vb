Imports System.Data.SqlClient
Public Class Card

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Visible = False
    End Sub

    Private Sub BunifuTextBox1_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox1.TextChanged
        PictureBox2.Visible = False
        PictureBox1.Visible = False
        PictureBox3.Visible = False
        If BunifuTextBox1.Text.StartsWith("2") Then
            PictureBox1.Visible = True
        End If
        If BunifuTextBox1.Text.StartsWith("4") Then
            PictureBox3.Visible = True
        End If
        If BunifuTextBox1.Text.StartsWith("6") Then
            PictureBox2.Visible = True
        End If
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click

        If BunifuTextBox1.Text = Nothing Or BunifuTextBox2.Text = Nothing Or BunifuTextBox3.Text = Nothing Or BunifuTextBox4.Text = Nothing Then
            MessageBox.Show("Fill The details")
        Else
            Dim amount = payment.BunifuLabel14.Text
            Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim query As String = "INSERT INTO Payment VALUES (@cname,@cno,@upi,@amount,@payment_type)"
            Dim cmd As New SqlCommand(query, con)
            Dim name = BunifuTextBox2.Text
            Dim cno = BunifuTextBox1.Text
            Dim upi1 = upi.BunifuTextBox1.Text
            Dim cvv = BunifuTextBox4.Text


            If cno.Length < 16 Then
                MessageBox.Show("Enter a valid card number")
                cno = cno.Substring(0, cno.Length)
                Exit Sub
            ElseIf cno.Length > 16 Then
                MessageBox.Show("Maximum 16 characters allowed!")
                cno = cno.Substring(0, 16)
                Exit Sub
            End If
            If String.IsNullOrEmpty(name) Then
                MessageBox.Show("Enter Name")
                Exit Sub
            End If
            If String.IsNullOrEmpty(BunifuTextBox3.Text) Then
                MessageBox.Show("Enter Date")
                Exit Sub
            End If
            If cvv.Length < 3 Then
                MessageBox.Show("Enter a valid phno")
                cvv = cvv.Substring(0, cvv.Length)
                Exit Sub
            ElseIf cvv.Length > 3 Then
                MessageBox.Show("Maximum 3 characters allowed!")
                cvv = cvv.Substring(0, 3)
                Exit Sub
            End If

            con.Open()
            cmd.Parameters.AddWithValue("@cname", name)
            cmd.Parameters.AddWithValue("@upi", upi1)
            cmd.Parameters.AddWithValue("@amount", amount)
            cmd.Parameters.AddWithValue("@cno", cno)
            cmd.Parameters.AddWithValue("@payment_type", upi1)
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Payment Successful")
                Me.Hide()
            Catch ex As Exception
                MessageBox.Show("eroor" & ex.Message)
            End Try
        End If
    End Sub

    Private Sub BunifuPanel1_Click(sender As Object, e As EventArgs) Handles BunifuPanel1.Click

    End Sub
End Class