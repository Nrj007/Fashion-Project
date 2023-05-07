Imports System.Data.SqlClient
Public Class Inventory
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim connectionString As String = "Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True"
        Dim query As String = "Select Id, name, quantity FROM men"
        Dim dataTable As New DataTable()

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                dataTable.Load(command.ExecuteReader())
            End Using
        End Using

        DataGridView1.DataSource = dataTable

    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim connectionString As String = "Data Source=WIN11;Initial Catalog=Fashion1;Integrated Security=True"
        Dim query As String = "Select Id, name, quantity FROM Table_2"
        Dim dataTable As New DataTable()

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                dataTable.Load(command.ExecuteReader())
            End Using
        End Using

        DataGridView2.DataSource = dataTable
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
End Class