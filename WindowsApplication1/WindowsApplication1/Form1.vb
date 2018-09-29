Imports System.Data.SqlClient
Public Class Form1
    Dim baglanti As New SqlClient.SqlConnection("Server=DESKTOP-K98BF9V\SQLEXPRESS;Database=VT1;Integrated Security=True")
    Dim komut As New SqlClient.SqlCommand
    Dim adaptör As New SqlClient.SqlDataAdapter("SELECT * FROM STOK", baglanti)
    Dim ds As New DataSet


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        komut.Connection = baglanti
        komut.CommandType = CommandType.Text
        Dim komut2 As New SqlClient.SqlCommand("select * from STOK where stokno='" & TextBox1.Text & "'", baglanti)
        baglanti.Open()
        Dim reader As SqlDataReader = komut2.ExecuteReader()
        Try
            While (reader.Read())
                Label6.Text = reader.GetInt32(0)
                Label7.Text = reader.GetString(1)
                Label8.Text = reader.GetInt32(2)
                Label9.Text = reader.GetInt32(3)
                Label10.Text = reader.GetInt32(4)
                Label12.Text = reader.GetInt32(5)
                Label13.Text = reader.GetInt32(6)
                Label14.Text = reader.GetInt32(7)
                Label15.Text = reader.GetString(8)
                PictureBox1.ImageLocation = Label15.Text
            End While
        Catch
            MsgBox("Stok Bulunamadı veya Hatalı Giriş Yaptınız!")
        End Try
        baglanti.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim stokno As Integer
        Dim sql As String
        Dim komut As New SqlClient.SqlCommand
        komut.Connection = baglanti
        komut.CommandType = CommandType.Text
        stokno = TextBox1.Text
        sql = "update STOK set stokno='" & stokno & "'"


        komut.CommandText = sql
        baglanti.Open()

        komut.ExecuteNonQuery()
        MessageBox.Show("Ürün Satışı Gerçekleşti.")
        baglanti.Close()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form4.Show()
        Me.Hide()
    End Sub
End Class
