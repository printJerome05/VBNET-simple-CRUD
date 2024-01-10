Imports System.Data.SqlClient


Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Studentdata()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim name As String = TextBox_NAME.Text
        Dim dob As String = TextBox_DOB.Text
        Dim address As String = TextBox_ADDRESS.Text



        Dim query As String = "INSERT INTO student VALUES(@name,@dob,@address)"
        Using con As SqlConnection = New SqlConnection("Data Source=JEROMEMARCO;Initial Catalog=std_list;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)

                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@dob", dob)
                cmd.Parameters.AddWithValue("@address", address)

                Try
                    con.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                con.Close()

                MessageBox.Show("Insert Complete")
                TextBox_ID.Text = ""
                TextBox_NAME.Text = ""
                TextBox_DOB.Text = ""
                TextBox_ADDRESS.Text = ""
                Studentdata()
            End Using
        End Using
    End Sub

    Public Sub Studentdata()
        Dim query As String = "SELECT * FROM student"
        Using con As SqlConnection = New SqlConnection("Data Source=JEROMEMARCO;Initial Catalog=std_list;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                    End Using

                End Using
            End Using
        End Using

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = DataGridView1.Rows(index)

        TextBox_ID.Text = selectedrow.Cells(0).Value.ToString()
        TextBox_NAME.Text = selectedrow.Cells(1).Value.ToString()
        TextBox_DOB.Text = selectedrow.Cells(2).Value.ToString()
        TextBox_ADDRESS.Text = selectedrow.Cells(3).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim name As String = TextBox_NAME.Text
        Dim dob As String = TextBox_DOB.Text
        Dim address As String = TextBox_ADDRESS.Text



        Dim query As String = "UPDATE student SET name=@name, dob=@dob, address=@address WHERE id='" + TextBox_ID.Text + "'"
        Using con As SqlConnection = New SqlConnection("Data Source=JEROMEMARCO;Initial Catalog=std_list;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)

                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@dob", dob)
                cmd.Parameters.AddWithValue("@address", address)

                Try
                    con.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception

                End Try
                con.Close()

                MessageBox.Show("Update Complete")
                TextBox_ID.Text = ""
                TextBox_NAME.Text = ""
                TextBox_DOB.Text = ""
                TextBox_ADDRESS.Text = ""
                Studentdata()
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim name As String = TextBox_NAME.Text
        Dim dob As String = TextBox_DOB.Text
        Dim address As String = TextBox_ADDRESS.Text



        Dim query As String = "DELETE student WHERE id='" + TextBox_ID.Text + "'"
        Using con As SqlConnection = New SqlConnection("Data Source=JEROMEMARCO;Initial Catalog=std_list;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)

                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@dob", dob)
                cmd.Parameters.AddWithValue("@address", address)

                Try
                    con.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception

                End Try
                con.Close()

                MessageBox.Show("DELETE Complete")
                TextBox_ID.Text = ""
                TextBox_NAME.Text = ""
                TextBox_DOB.Text = ""
                TextBox_ADDRESS.Text = ""
                Studentdata()
            End Using
        End Using
    End Sub
End Class
