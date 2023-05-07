Imports System.Data.SqlClient
Public Class Reports
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim connectionString As String = "Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True"
        Dim query As String = "Select * FROM orders"
        Dim dataTable As New DataTable()

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                dataTable.Load(command.ExecuteReader())
            End Using
        End Using

        DataGridView1.DataSource = dataTable
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection("Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True")
        Dim cmd As New SqlCommand("SELECT SUM(CAST(amount AS decimal(10,2))) AS total_amount FROM payment", con)
        con.Open()
        Dim result As Object = cmd.ExecuteScalar()
        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
            BunifuLabel3.Text = "Total Revenue: " & Convert.ToDecimal(result)
        Else
            BunifuLabel3.Text = "No results found."
        End If
        con.Close()

    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim connectionString As String = "Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True"
        Dim query As String = "Select * FROM Payment"
        Dim dataTable As New DataTable()

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                dataTable.Load(command.ExecuteReader())
            End Using
        End Using

        DataGridView1.DataSource = dataTable
    End Sub
End Class