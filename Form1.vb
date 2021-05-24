Imports System.Data.SqlClient

Public Class Form1
    Dim con As New SqlConnection("Data Source=DESKTOP-R6H7V2T\SQLEXPRESS;Initial Catalog=kowero;Integrated Security=True")
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataInGrid()
    End Sub

    Private Sub LoadDataInGrid()
        con.Open()
        Dim command As New SqlCommand("Select * from contacts", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        Display.DataSource = dt
        con.Close()
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim pid As Integer = Convert.ToInt32(TextId.Text)
        Dim name As String = TextName.Text
        Dim number As String = TextPhone.Text
        con.Open()
        Dim command As New SqlCommand("Insert into contacts(id,name,number) values ('" & pid & "','" & name & "','" & number & "')", con)
        command.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Successfully Inserted")
        LoadDataInGrid()
    End Sub



    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        Dim pid As Integer = Convert.ToInt32(TextId.Text)
        Dim name As String = TextName.Text
        Dim number As String = TextPhone.Text
        con.Open()
        Dim command As New SqlCommand("update contacts set name = '" & name & "', number = '" & number & "' where id = '" & pid & "'", con)
        command.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Successfully updated")
        LoadDataInGrid()
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Dim pid As Integer = Convert.ToInt32(TextId.Text)
        con.Open()
        Dim command As New SqlCommand("delete contacts where id = '" & pid & "'", con)
        command.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Successfully deleted.")
        LoadDataInGrid()
    End Sub
End Class
