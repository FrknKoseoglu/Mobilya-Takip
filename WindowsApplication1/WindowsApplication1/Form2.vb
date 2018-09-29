Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class Form2
    Dim baglanti As New SqlClient.SqlConnection("Server=DESKTOP-K98BF9V\SQLEXPRESS;Database=VT1;Integrated Security=True")
    Dim adaptör As New SqlClient.SqlDataAdapter("SELECT * FROM STOK", baglanti)
    Dim ds As New DataSet
    Dim str_stoksql As String
    Dim reader As SqlDataReader



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Try
            baglanti.Open()
            Dim komut As New SqlClient.SqlCommand
            komut.Connection = baglanti
            komut.CommandType = CommandType.Text
            str_stoksql = "INSERT INTO STOK (stokno,urunad,tadet,badet,uadet,tfiyat,bfiyat,ufiyat,resim) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & Label10.Text & "')"
            'MsgBox(str_stoksql)'
            Dim komut2 As New SqlClient.SqlCommand(str_stoksql, baglanti)
            reader = komut2.ExecuteReader
            baglanti.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Dim openFileDialog1 As New OpenFileDialog()
    Dim myStream As Stream = Nothing
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            openFileDialog1.InitialDirectory = "C:\\"
            openFileDialog1.Filter = "All Files|*.*|Bitmap|*.bmp|GIF|*.gif|JPEG|*.jpg"
            openFileDialog1.FilterIndex = 4

            If openFileDialog1.ShowDialog() <> DialogResult.OK Then

                PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                PictureBox1.BorderStyle = BorderStyle.Fixed3D
            End If
            Dim ResimSecYol As String = Path.GetFullPath(openFileDialog1.FileName)
            Dim ResimSecDosya As FileStream = New FileStream(ResimSecYol, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim resim As Bitmap = New Bitmap(ResimSecDosya, True)
            PictureBox1.Image = resim
            Label10.Text = ResimSecYol
        Catch
            MsgBox("Bir Resim Eklemediniz..!")
        End Try


    End Sub
  
    
End Class