Imports System
Imports System.Net.Mail
Imports System.Threading

Module Module1

    Sub Main()
        Dim birinci_trafo1 As Integer
        Dim ikinci_trafo1 As Integer
        Console.Write("Birinci trafodan ilk akim durumunu girin (2 = Kesildi, 1 = Veriliyor): ")
        birinci_trafo1 = Integer.Parse(Console.ReadLine())

        Console.Write("Ikinci trafoya ilk akim durumunu girin (2 = Kesildi, 1 = Veriliyor): ")
        ikinci_trafo1 = Integer.Parse(Console.ReadLine())

        While True
            Dim birinci_trafo2 As Integer
            Dim ikinci_trafo2 As Integer
            Console.Write("Birinci trafodan yeni akim durumunu girin (2 = Kesildi, 1 = Veriliyor): ")
            birinci_trafo2 = Integer.Parse(Console.ReadLine())

            Console.Write("Ikinci trafoya yeni akim durumunu girin (2 = Kesildi, 1 = Veriliyor): ")
            ikinci_trafo2 = Integer.Parse(Console.ReadLine())

            If birinci_trafo1 <> birinci_trafo2 AndAlso ikinci_trafo1 <> ikinci_trafo2 AndAlso birinci_trafo2 <> ikinci_trafo2 Then
                ChangeConsoleColor(4)
                Console.WriteLine("Trafo degismistir!")
                Console.WriteLine("Birinci trafonun durumu: {0} - Ikinci trafonun durumu: {1}", birinci_trafo2, ikinci_trafo2)
                PlaySound()
                ChangeConsoleColor(7)
                SendEmailNotification(birinci_trafo2, ikinci_trafo2)
            End If

            If birinci_trafo2 = 2 AndAlso ikinci_trafo2 = 2 Then
                Console.WriteLine("Yeni durumda iki trafo da kapali")
            End If

            If birinci_trafo2 = 1 AndAlso ikinci_trafo2 = 1 Then
                Console.WriteLine("Yeni durumda iki trafo da acik")
            End If

            birinci_trafo1 = birinci_trafo2
            ikinci_trafo1 = ikinci_trafo2
        End While
    End Sub
    Sub SendEmailNotification(trafo1Durumu As Integer, trafo2Durumu As Integer)
        Try
            Dim Mail As New MailMessage()
            Mail.Subject = "Trafo Değişikliği Bildirimi"
            Mail.To.Add("bbbbb@gmail.com")
            Mail.From = New MailAddress("aaaaa@gmail.com")
            Mail.Body = "Birinci trafonun durumu: " & trafo1Durumu & " - Ikinci trafonun durumu: " & trafo2Durumu

            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("aaaaaa", "123456")
            SMTP.Port = 587

            SMTP.Send(Mail)

            Console.WriteLine("E-posta başarıyla gönderildi.")
        Catch ex As Exception
            Console.WriteLine("E-posta gönderirken bir hata oluştu: " & ex.Message)
        End Try
    End Sub
    Sub PlaySound()
        Console.Beep(1000, 500)
    End Sub

    Sub ChangeConsoleColor(color As Integer)
        Console.ForegroundColor = CType(color, ConsoleColor)
    End Sub

End Module