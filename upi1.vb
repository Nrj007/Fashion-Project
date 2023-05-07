Imports System.Data.SqlClient
Public Class upi1
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If Not BunifuTextBox1.Text.Contains("@") Then
            MessageBox.Show("Enter valid UPI ID")
            Exit Sub
        End If
        If BunifuTextBox1.Text = Nothing Then
            MessageBox.Show("Enter Upi Id")
        Else
            Dim amount = payment_buynow.BunifuLabel14.Text
            Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
            Dim query As String = "INSERT INTO Payment VALUES (@cname,@cno,@upi,@amount,@payment_type)"
            Dim cmd As New SqlCommand(query, con)
            Dim name = Card.BunifuTextBox1.Text
            Dim cno = Card.BunifuTextBox2.Text
            Dim upi = BunifuTextBox1.Text

            con.Open()
            cmd.Parameters.AddWithValue("@cname", name)
            cmd.Parameters.AddWithValue("@cno", cno)
            cmd.Parameters.AddWithValue("@upi", upi)
            cmd.Parameters.AddWithValue("@amount", amount)
            cmd.Parameters.AddWithValue("@payment_type", cno)

            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Payment Successful")
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("eroor" & ex.Message)
            End Try
        End If
    End Sub

    Private Sub upi1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim time As Integer = 180
        Dim timer As New Timer()


        timer.Interval = 1000

        AddHandler timer.Tick, Sub()
                                   time -= 1
                                   If time >= 0 Then
                                       '
                                       BunifuLabel1.Text = $"{time \ 60:00}:{time Mod 60:00}"
                                   Else
                                       timer.Stop()
                                       MessageBox.Show("Connection Timed Out!")
                                       Me.Close()
                                       payment.Close()
                                       timer.Stop()
                                   End If
                               End Sub

        timer.Start()
    End Sub
End Class