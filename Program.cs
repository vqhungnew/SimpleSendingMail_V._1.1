//REF:https://www.tutorialsteacher.com/articles/send-emails-in-csharp

using System;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("vaa_laptrinhmang@outlook.com");
        Console.WriteLine("This is a SIMPLE and TEST program to send email by C#\n");
        Console.WriteLine("To use this app, YOU MUST register an EMAIL from website OPUTLOOK.COM. You email should look like xxxx@OUTLOOK.COM\n");
        //Get Receiver'e email
        Console.WriteLine("\n Enter email of Receiver:");
        string recvEmail = Console.ReadLine();
        mailMessage.To.Add(recvEmail);
        mailMessage.Subject = "Subject";
        mailMessage.Body = "This is test email";

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "eas.outlook.com";
        smtpClient.Port = 587;
        smtpClient.UseDefaultCredentials = false;


        //Get password from keyboard
        string emailPass = getPasswordFromUser();
        
        smtpClient.Credentials = new NetworkCredential("vaa_laptrinhmang@outlook.com", emailPass);
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mailMessage);
            Console.WriteLine("Email Sent Successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    //make password INVISIBLE on the screen
    //https://stackoverflow.com/questions/23433980/c-sharp-console-hide-the-input-from-console-window-while-typing

    public static string getPasswordFromUser()
    {
        System.Console.Write("\nEnter your password of yor email ENDING by ENTER key: ");
        string password = null;
        while (true)
        {
            var key = System.Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
                break;
            password += key.KeyChar;
            // Console.WriteLine(password);
        }
        return password;
    }
}