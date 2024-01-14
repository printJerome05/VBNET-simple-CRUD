'need to import below if database is a mysql then add pacakage/reference
Imports MySql.Data.MySqlClient

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As MySqlConnection = New MySqlConnection("server=localhost;user id=root;password=;database=studentest")
        Try
            con.Open()
            MessageBox.Show("Connection Succesful")
        Catch ex As Exception
            MessageBox.Show("Connection Error")

        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Studentdata()
    End Sub

    Public Sub Studentdata()
        Dim query As String = "SELECT * FROM student"
        Using con As MySqlConnection = New MySqlConnection("server=localhost;user id=root;password=;database=studentest")
            Using cmd As MySqlCommand = New MySqlCommand(query, con)
                Using da As New MySqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                    End Using

                End Using
            End Using
        End Using
    End Sub

    Private Sub Button_Create_Click(sender As Object, e As EventArgs) Handles Button_Create.Click
        Try
            Dim name As String = TextBox_name.Text
            Dim dob As String = TextBox_dob.Text
            Dim address As String = TextBox_address.Text
            Dim query As String = "INSERT INTO student(name,dob,address) VALUES(@name,@dob,@address)"
            Using con As MySqlConnection = New MySqlConnection("server=localhost;user id=root;password=;database=studentest")
                Using cmd As MySqlCommand = New MySqlCommand(query, con)
                    con.Open()
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@dob", dob)
                    cmd.Parameters.AddWithValue("@address", address)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Insert Complete")
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            TextBox_id.Text = ""
            TextBox_name.Text = ""
            TextBox_dob.Text = ""
            TextBox_address.Text = ""
            Studentdata()
        End Try
    End Sub

    Private Sub Button_Update_Click(sender As Object, e As EventArgs) Handles Button_Update.Click
        Try

            Dim name As String = TextBox_name.Text
            Dim dob As String = TextBox_dob.Text
            Dim address As String = TextBox_address.Text
            Dim query As String = "UPDATE student SET name=@name, dob=@dob, address=@address WHERE id='" + TextBox_id.Text + "'"
            Using con As MySqlConnection = New MySqlConnection("server=localhost;user id=root;password=;database=studentest")
                Using cmd As MySqlCommand = New MySqlCommand(query, con)
                    con.Open()
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@dob", dob)
                    cmd.Parameters.AddWithValue("@address", address)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Update Complete")
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            TextBox_id.Text = ""
            TextBox_name.Text = ""
            TextBox_dob.Text = ""
            TextBox_address.Text = ""
            Studentdata()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Cell click to display data in the textbox'

        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = DataGridView1.Rows(index)
        TextBox_id.Text = selectedrow.Cells(0).Value.ToString()
        TextBox_name.Text = selectedrow.Cells(1).Value.ToString()
        TextBox_dob.Text = selectedrow.Cells(2).Value.ToString()
        TextBox_address.Text = selectedrow.Cells(3).Value.ToString()
    End Sub

    Private Sub Button_Delete_Click(sender As Object, e As EventArgs) Handles Button_Delete.Click
        Try
            Dim query As String = "DELETE FROM student WHERE id='" + TextBox_id.Text + "'"
            Using con As MySqlConnection = New MySqlConnection("server=localhost;user id=root;password=;database=studentest")
                Using cmd As MySqlCommand = New MySqlCommand(query, con)
                    con.Open()
                    MessageBox.Show("Delete Complete")
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            TextBox_id.Text = ""
            TextBox_name.Text = ""
            TextBox_dob.Text = ""
            TextBox_address.Text = ""
            Studentdata()
        End Try
    End Sub

    Private Sub Button_Clear_Click(sender As Object, e As EventArgs) Handles Button_Clear.Click
        TextBox_id.Text = ""
        TextBox_name.Text = ""
        TextBox_dob.Text = ""
        TextBox_address.Text = ""
        Studentdata()
    End Sub
End Class
