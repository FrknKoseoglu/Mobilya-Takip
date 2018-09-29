Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class Form3
    Dim baglanti As New SqlClient.SqlConnection("Server=DESKTOP-K98BF9V\SQLEXPRESS;Database=VT1;Integrated Security=True")
    Dim adaptör As New SqlClient.SqlDataAdapter("SELECT * FROM musteri", baglanti)
    Dim ds As New DataSet
    Dim komut As New SqlClient.SqlCommand
    Dim str_sqlmusteri As String
    Dim reader As SqlDataReader
    Dim tarih As DateTime
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Eksik Bilgi Girdiniz!")
        Else
            If TextBox5.Text.Length <> 10 Or TextBox4.Text.Length <> 10 Then
                MsgBox("Telefon Numaraları 10 haneli 5XX-XXX-XXXX Şeklinde Girilmelidir.")
            Else
                Try
                    baglanti.Open()
                    Dim komut As New SqlClient.SqlCommand
                    komut.Connection = baglanti
                    komut.CommandType = CommandType.Text
                    str_sqlmusteri = "INSERT INTO musteri (musterino,musteriad,musterisoyad,evtel,istel,evadres,isadres) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
                    'MsgBox(str_sqlmusteri)'
                    Dim komut2 As New SqlClient.SqlCommand(str_sqlmusteri, baglanti)
                    reader = komut2.ExecuteReader
                    baglanti.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
            End If
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Visible = False
        Button3.Visible = True
        GroupBox1.Visible = False
        GroupBox2.Visible = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Visible = False
        Button4.Visible = True
        GroupBox1.Visible = True
        GroupBox2.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        komut.Connection = baglanti
        komut.CommandType = CommandType.Text
        Dim komut2 As New SqlClient.SqlCommand("select * from musteri where musterino='" & TextBox8.Text & "'", baglanti)
        baglanti.Open()
        Dim reader As SqlDataReader = komut2.ExecuteReader()
            While (reader.Read())
                Label23.Text = reader.GetInt32(0)
                Label24.Text = reader.GetString(1)
                Label25.Text = reader.GetString(2)
            Label26.Text = reader.GetInt32(3)
                Label27.Text = reader.GetInt32(4)
                Label28.Text = reader.GetString(5)
                Label29.Text = reader.GetString(6)
                Label30.Text = reader.GetString(7)
                Label31.Text = reader.GetInt32(8)
                Label40.Text = reader.GetString(9)
                Label32.Text = reader.GetString(10)
                Label33.Text = reader.GetInt32(11)
                Label34.Text = reader.GetInt32(12)
                Label35.Text = reader.GetInt32(13)
            Label36.Text = reader.GetInt32(14)
            Try
                tarih = reader.GetString(16)
                Label54.Text = reader.GetString(17)
                Label55.Text = reader.GetString(18)
                Label56.Text = reader.GetString(19)
                Label57.Text = reader.GetString(20)
                Label58.Text = reader.GetString(21)
                Label59.Text = reader.GetString(22)
                Label60.Text = reader.GetString(23)
                Label61.Text = reader.GetString(24)
                Label62.Text = reader.GetString(25)
                Label63.Text = reader.GetString(26)
                Label64.Text = reader.GetString(27)
                Label65.Text = reader.GetString(28)
            Catch

            End Try

        End While





            baglanti.Close()

            If Label30.Text = "Yapılmadı" Then
                GroupBox3.Visible = False
                GroupBox4.Visible = False
            ElseIf Label30.Text = "Yapıldı" Then
                GroupBox3.Visible = True
                GroupBox4.Visible = True
            End If
            If Label32.Text = "Taksit" Then
                If Label33.Text = 3 Then
                    Label45.Visible = False
                    Label46.Visible = False
                    Label47.Visible = False
                    Label48.Visible = False
                    Label49.Visible = False
                    Label50.Visible = False
                    Label51.Visible = False
                    Label52.Visible = False
                    Label53.Visible = False
                    Label57.Visible = False
                    Label58.Visible = False
                    Label59.Visible = False
                    Label60.Visible = False
                    Label61.Visible = False
                    Label62.Visible = False
                    Label63.Visible = False
                    Label64.Visible = False
                Label65.Visible = False
                ' Taksit Tarihleri
                Label69.Visible = False
                Label70.Visible = False
                Label71.Visible = False
                Label72.Visible = False
                Label73.Visible = False
                Label74.Visible = False
                Label75.Visible = False
                Label76.Visible = False
                Label77.Visible = False
            ElseIf Label33.Text = 6 Then
                    Label48.Visible = False
                    Label49.Visible = False
                    Label50.Visible = False
                    Label51.Visible = False
                    Label53.Visible = False
                    Label52.Visible = False
                    Label60.Visible = False
                    Label61.Visible = False
                    Label62.Visible = False
                    Label63.Visible = False
                    Label64.Visible = False
                Label65.Visible = False
                'Taksit Tarihleri
                Label72.Visible = False
                Label73.Visible = False
                Label74.Visible = False
                Label75.Visible = False
                Label76.Visible = False
                Label77.Visible = False
                ElseIf Label33.Text = 9 Then
                    Label51.Visible = False
                    Label52.Visible = False
                    Label53.Visible = False
                    Label63.Visible = False
                    Label64.Visible = False
                Label65.Visible = False
                'Taksit Tarihleri
                Label75.Visible = False
                Label76.Visible = False
                Label77.Visible = False
                End If
            Else
                GroupBox4.Visible = False
            End If

        Label66.Text = tarih
        Label67.Text = tarih.AddMonths(1)
        Label68.Text = tarih.AddMonths(2)
        Label69.Text = tarih.AddMonths(3)
        Label70.Text = tarih.AddMonths(4)
        Label71.Text = tarih.AddMonths(5)
        Label72.Text = tarih.AddMonths(6)
        Label73.Text = tarih.AddMonths(7)
        Label74.Text = tarih.AddMonths(8)
        Label75.Text = tarih.AddMonths(9)
        Label76.Text = tarih.AddMonths(10)
        Label77.Text = tarih.AddMonths(11)
        


    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub


    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub
End Class