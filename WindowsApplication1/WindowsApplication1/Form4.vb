Imports System.Data
Imports System.Data.SqlClient
Public Class Form4
    Dim baglanti As New SqlClient.SqlConnection("Server=DESKTOP-K98BF9V\SQLEXPRESS;Database=VT1;Integrated Security=True")
    Dim komut As New SqlClient.SqlCommand
    Dim adaptör As New SqlClient.SqlDataAdapter("SELECT * FROM musteri", baglanti)
    Dim ds As New DataSet
    Dim stokno As Integer
    Dim urunad As String
    Dim tadet As Integer
    Dim badet As Integer
    Dim uadet As Integer
    Dim tfiyat As Integer
    Dim bfiyat As Integer
    Dim ufiyat As Integer
    Dim gtakim As Integer
    Dim gberjer As Integer
    Dim guclu As Integer
    Dim toplam As Integer
    Dim htakim As Integer
    Dim hberjer As Integer
    Dim huclu As Integer
    Dim taksit1 As String
    Dim taksit2 As String
    Dim taksit4 As String
    Dim taksit3 As String
    Dim taksit5 As String
    Dim taksit6 As String
    Dim taksit7 As String
    Dim taksit8 As String
    Dim taksit9 As String
    Dim taksit10 As String
    Dim taksit11 As String
    Dim taksit12 As String
    Dim t1 As String
    Dim t2 As String
    Dim t3 As String
    Dim t4 As String
    Dim t5 As String
    Dim t6 As String
    Dim t7 As String
    Dim t8 As String
    Dim t9 As String
    Dim t10 As String
    Dim t11 As String
    Dim t12 As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        komut.Connection = baglanti
        komut.CommandType = CommandType.Text
        Dim komut2 As New SqlClient.SqlCommand("select * from musteri where musterino='" & TextBox1.Text & "'", baglanti)
        baglanti.Open()
        Dim reader As SqlDataReader = komut2.ExecuteReader()
        Try
            While (reader.Read())
                Label9.Text = reader.GetInt32(0)
                Label10.Text = reader.GetString(1)
                Label11.Text = reader.GetString(2)
                Label12.Text = reader.GetInt32(3)
                Label13.Text = reader.GetInt32(4)
                Label14.Text = reader.GetString(5)
                Label15.Text = reader.GetString(6)
               
            End While
        Catch
            MsgBox("Müşteri Bulunamadı veya Hatalı Giriş Yaptınız!")
        End Try

        baglanti.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Null As String = "Null"
        If RadioButton1.Checked Then
            Dim evtel As String = Label12.Text
        End If
        If RadioButton2.Checked Then
            Dim istel As String = Label13.Text
        End If
        If RadioButton3.Checked Then
            Dim evadres As String = Label14.Text
        End If
        If RadioButton4.Checked Then
            Dim isadres As String = Label15.Text
        End If

        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Gönderim için Telefon Numarası Seçiniz!")
        End If
        If RadioButton3.Checked = False And RadioButton4.Checked = False Then
            MsgBox("Gönderim için Adres Seçiniz!")
        End If
        If RadioButton1.Checked Or RadioButton2.Checked Then

            If RadioButton3.Checked Or RadioButton4.Checked Then
                If Label9.Text = Null Then
                    MsgBox("Müşteri Seçilmedi!")
                Else

                    TextBox2.Visible = True
                    Button3.Visible = True

                End If
            End If

        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        komut.Connection = baglanti
        komut.CommandType = CommandType.Text
        Dim komut2 As New SqlClient.SqlCommand("select * from STOK where stokno='" & TextBox2.Text & "'", baglanti)
        baglanti.Open()
        Dim reader As SqlDataReader = komut2.ExecuteReader()
        Try
            While (reader.Read())
                stokno = reader.GetInt32(0)
                urunad = reader.GetString(1)
                tadet = reader.GetInt32(2)
                badet = reader.GetInt32(3)
                uadet = reader.GetInt32(4)
                tfiyat = reader.GetInt32(5)
                bfiyat = reader.GetInt32(6)
                ufiyat = reader.GetInt32(7)
            End While
        Catch
            MsgBox("Stok Bulunamadı veya Hatalı Giriş Yaptınız!")
        End Try
        baglanti.Close()
        GroupBox2.Visible = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            gtakim = TextBox3.Text
            gberjer = TextBox4.Text
            guclu = TextBox5.Text
        
        htakim = gtakim * tfiyat
        hberjer = gberjer * bfiyat
        huclu = guclu * ufiyat
            toplam = htakim + hberjer + huclu

            If RadioButton6.Checked = False And RadioButton5.Checked = False Then
                MsgBox("Bir Ödeme Seçeneği Seçiniz!")
            End If

            If RadioButton5.Checked Then
                Label16.Text = toplam
                Button5.Visible = True
                Button8.Visible = True
                Label45.Visible = False
                Label46.Visible = False
                Label47.Visible = False
                Label48.Visible = False
                Label49.Visible = False
                Label50.Visible = False
                Label51.Visible = False
                Label52.Visible = False
                Label53.Visible = False
                Label54.Visible = False
                Label55.Visible = False
                Label56.Visible = False
                CheckBox1.Visible = False
                CheckBox2.Visible = False
                CheckBox3.Visible = False
                CheckBox4.Visible = False
                CheckBox5.Visible = False
                CheckBox6.Visible = False
                CheckBox7.Visible = False
                CheckBox8.Visible = False
                CheckBox9.Visible = False
                CheckBox10.Visible = False
                CheckBox11.Visible = False
                CheckBox12.Visible = False
            End If
            If RadioButton6.Checked And RadioButton5.Checked = False Then
                If RadioButton7.Checked = False And RadioButton9.Checked = False And RadioButton8.Checked = False And RadioButton10.Checked = False Then
                    MsgBox("Bir Taksit Seçeneği Seçiniz!")
                End If
                If RadioButton7.Checked Then
                    Label16.Text = toplam
                    Label21.Visible = True
                    Label22.Visible = True
                    Label22.Text = Math.Round(toplam / 3, 0)
                    Button5.Visible = True
                    Button8.Visible = True
                    Label48.Visible = False
                    Label49.Visible = False
                    Label50.Visible = False
                    Label51.Visible = False
                    Label52.Visible = False
                    Label53.Visible = False
                    Label54.Visible = False
                    Label55.Visible = False
                    Label56.Visible = False
                    CheckBox4.Visible = False
                    CheckBox5.Visible = False
                    CheckBox6.Visible = False
                    CheckBox7.Visible = False
                    CheckBox8.Visible = False
                    CheckBox9.Visible = False
                    CheckBox10.Visible = False
                    CheckBox11.Visible = False
                    CheckBox12.Visible = False
                End If
                If RadioButton8.Checked Then
                    Label16.Text = toplam
                    Label21.Visible = True
                    Label22.Visible = True
                    Label22.Text = Math.Round(toplam / 6, 0)
                    Button5.Visible = True
                    Button8.Visible = True
                    Label51.Visible = False
                    Label52.Visible = False
                    Label53.Visible = False
                    Label54.Visible = False
                    Label55.Visible = False
                    Label56.Visible = False
                    CheckBox7.Visible = False
                    CheckBox8.Visible = False
                    CheckBox9.Visible = False
                    CheckBox10.Visible = False
                    CheckBox11.Visible = False
                    CheckBox12.Visible = False
                End If
                If RadioButton9.Checked Then
                    Label16.Text = toplam
                    Label21.Visible = True
                    Label22.Visible = True
                    Label22.Text = Math.Round(toplam / 9, 0)
                    Button5.Visible = True
                    Button8.Visible = True
                    Label54.Visible = False
                    Label55.Visible = False
                    Label56.Visible = False
                    CheckBox10.Visible = False
                    CheckBox11.Visible = False
                    CheckBox12.Visible = False
                End If
                If RadioButton10.Checked Then
                    Label16.Text = toplam
                    Label21.Visible = True
                    Label22.Visible = True
                    Label22.Text = Math.Round(toplam / 12, 0)
                    Button5.Visible = True
                    Button8.Visible = True
                End If


            End If
        Catch
            MsgBox("Boş değer yerine 0 giriniz!")
        End Try
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim tarih As DateTime = DateTime.Now.ToShortDateString
        GroupBox4.Visible = True
        Dim Satis As String = "Yapıldı"
        Label28.Text = Label9.Text
        Label29.Text = Label10.Text
        Label30.Text = Label11.Text
        If RadioButton1.Checked Then
            Label31.Text = Label12.Text
        Else
            Label31.Text = Label13.Text
        End If
        If RadioButton3.Checked Then
            Label32.Text = Label14.Text
        Else
            Label32.Text = Label15.Text
        End If
        If RadioButton5.Checked Then
            Label36.Text = "Peşin"
            Label37.Text = "0"
        Else
            Label36.Text = "Taksit"
            If RadioButton7.Checked Then
                Label37.Text = RadioButton7.Text
            End If
            If RadioButton8.Checked Then
                Label37.Text = RadioButton8.Text
            End If
            If RadioButton9.Checked Then
                Label37.Text = RadioButton9.Text
            End If
            If RadioButton10.Checked Then
                Label37.Text = RadioButton10.Text
            End If
        End If
        Label38.Text = Label16.Text
        Label40.Text = TextBox2.Text
        Label41.Text = urunad
        Label43.Text = Label22.Text

        CheckBox1.Text = tarih
        CheckBox2.Text = tarih.AddMonths(1)
        CheckBox3.Text = tarih.AddMonths(2)
        CheckBox4.Text = tarih.AddMonths(3)
        CheckBox5.Text = tarih.AddMonths(4)
        CheckBox6.Text = tarih.AddMonths(5)
        CheckBox7.Text = tarih.AddMonths(6)
        CheckBox8.Text = tarih.AddMonths(7)
        CheckBox9.Text = tarih.AddMonths(8)
        CheckBox10.Text = tarih.AddMonths(9)
        CheckBox11.Text = tarih.AddMonths(10)
        CheckBox12.Text = tarih.AddMonths(11)

        If RadioButton9.Checked Then
            CheckBox12.Text = "-"
            CheckBox11.Text = "-"
            CheckBox10.Text = "-"
        End If
        If RadioButton8.Checked Then
            CheckBox12.Text = "-"
            CheckBox11.Text = "-"
            CheckBox10.Text = "-"
            CheckBox9.Text = "-"
            CheckBox8.Text = "-"
            CheckBox7.Text = "-"
        End If
        If RadioButton7.Checked Then
            CheckBox12.Text = "-"
            CheckBox11.Text = "-"
            CheckBox10.Text = "-"
            CheckBox9.Text = "-"
            CheckBox8.Text = "-"
            CheckBox7.Text = "-"
            CheckBox6.Text = "-"
            CheckBox5.Text = "-"
            CheckBox4.Text = "-"
        End If


        Try

            Dim reader As SqlDataReader
            Dim str_sqlmusteri As String
            baglanti.Open()
            Dim komut As New SqlClient.SqlCommand
            komut.Connection = baglanti
            komut.CommandType = CommandType.Text
            str_sqlmusteri = "Update musteri Set Satis='" & Satis & "',Surunkod='" & TextBox2.Text & "',Surunad='" & urunad & "',odeme='" & Label36.Text & "',taksit='" & Label37.Text & "',tutar='" & toplam & "',gtel='" & Label31.Text & "',gadres='" & Label32.Text & "',aylik='" & Label22.Text & "', tarih='" & tarih & "' Where musterino='" & TextBox1.Text & "'"
            MsgBox(str_sqlmusteri)
            Dim komut2 As New SqlClient.SqlCommand(str_sqlmusteri, baglanti)
            reader = komut2.ExecuteReader
            baglanti.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try



        tadet = tadet - gtakim
        badet = badet - gberjer
        uadet = uadet - guclu
        Dim reader2 As SqlDataReader
        Dim sql_stokupdate As String
        baglanti.Open()
        Dim komut3 As New SqlClient.SqlCommand
        komut3.Connection = baglanti
        komut3.CommandType = CommandType.Text
        sql_stokupdate = "Update STOK Set tadet='" & tadet & "',badet='" & badet & "',uadet='" & uadet & "' Where stokno='" & TextBox2.Text & "'"
        'MsgBox(sql_stokupdate)'
        Dim komut4 As New SqlClient.SqlCommand(sql_stokupdate, baglanti)
        reader2 = komut4.ExecuteReader
        baglanti.Close()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.Show()
        Me.Close()
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

            If CheckBox1.Checked Then
                taksit1 = "Ödendi"
            ElseIf CheckBox1.Visible = True And CheckBox1.Checked = False Then
                taksit1 = "Ödenmedi"
            ElseIf CheckBox1.Visible = False Then
                taksit1 = "-"
            End If
            If CheckBox2.Checked Then
                taksit2 = "Ödendi"
            ElseIf CheckBox2.Visible = True And CheckBox2.Checked = False Then
                taksit2 = "Ödenmedi"
            ElseIf CheckBox2.Visible = False Then
                taksit2 = "-"
            End If
            If CheckBox3.Checked Then
                taksit3 = "Ödendi"
            ElseIf CheckBox3.Visible = True And CheckBox3.Checked = False Then
                taksit3 = "Ödenmedi"
            ElseIf CheckBox3.Visible = False Then
                taksit3 = "-"
            End If
            If CheckBox4.Checked Then
                taksit4 = "Ödendi"
            ElseIf CheckBox4.Visible = True And CheckBox4.Checked = False Then
                taksit4 = "Ödenmedi"
            ElseIf CheckBox4.Visible = False Then
                taksit4 = "-"
            End If
            If CheckBox5.Checked Then
                taksit5 = "Ödendi"
            ElseIf CheckBox5.Visible = True And CheckBox5.Checked = False Then
                taksit5 = "Ödenmedi"
            End If
            If CheckBox5.Checked Then
                taksit5 = "Ödendi"
            ElseIf CheckBox6.Visible = True And CheckBox6.Checked = False Then
                taksit6 = "Ödenmedi"
            ElseIf CheckBox6.Visible = False Then
                taksit6 = "-"
            End If
            If CheckBox7.Checked Then
                taksit7 = "Ödendi"
            ElseIf CheckBox7.Visible = True And CheckBox7.Checked = False Then
                taksit7 = "Ödenmedi"
            ElseIf CheckBox7.Visible = False Then
                taksit7 = "-"
            End If
            If CheckBox8.Checked Then
                taksit8 = "Ödendi"
            ElseIf CheckBox8.Visible = True And CheckBox8.Checked = False Then
                taksit8 = "Ödenmedi"
            ElseIf CheckBox8.Visible = False Then
                taksit8 = "-"
            End If
            If CheckBox9.Checked Then
                taksit9 = "Ödendi"
            ElseIf CheckBox9.Visible = True And CheckBox9.Checked = False Then
                taksit9 = "Ödenmedi"
            ElseIf CheckBox9.Visible = False Then
                taksit9 = "-"
            End If
            If CheckBox10.Checked Then
                taksit10 = "Ödendi"
            ElseIf CheckBox10.Visible = True And CheckBox10.Checked = False Then
                taksit10 = "Ödenmedi"
            ElseIf CheckBox10.Visible = False Then
                taksit10 = "-"
            End If
            If CheckBox11.Checked Then
                taksit11 = "Ödendi"
            ElseIf CheckBox11.Visible = True And CheckBox11.Checked = False Then
                taksit11 = "Ödenmedi"
            ElseIf CheckBox11.Visible = False Then
                taksit11 = "-"
            End If
            If CheckBox12.Checked Then
                taksit12 = "Ödendi"
            ElseIf CheckBox12.Visible = True And CheckBox12.Checked = False Then
                taksit12 = "Ödenmedi"
            ElseIf CheckBox12.Visible = False Then
                taksit12 = "-"
            End If

            Try

            Dim reader1 As SqlDataReader
                Dim str_sqlmusteri As String
                baglanti.Open()
                Dim komut As New SqlClient.SqlCommand
                komut.Connection = baglanti
                komut.CommandType = CommandType.Text
                str_sqlmusteri = "Update musteri Set taksit1='" & taksit1 & "',taksit2='" & taksit2 & "',taksit3='" & taksit3 & "',taksit4='" & taksit4 & "',taksit5='" & taksit5 & "',taksit6='" & taksit6 & "',taksit7='" & taksit7 & "',taksit8='" & taksit8 & "',taksit9='" & taksit9 & "',taksit10='" & taksit10 & "',taksit11='" & taksit11 & "',taksit12='" & taksit12 & "' Where musterino='" & TextBox1.Text & "'"
            'MsgBox(str_sqlmusteri)'
            Dim komut1 As New SqlClient.SqlCommand(str_sqlmusteri, baglanti)
            reader1 = komut1.ExecuteReader
                baglanti.Close()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Label16.Text = 0
        Label22.Text = 0
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        RadioButton5.Checked = False
        RadioButton6.Checked = False
        RadioButton7.Checked = False
        RadioButton8.Checked = False
        RadioButton9.Checked = False
        RadioButton10.Checked = False
        Button5.Visible = False
        Button8.Visible = False
    End Sub
End Class