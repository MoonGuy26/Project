using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using BeanifyWebApp.Security;

namespace BeanifyWebApp.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private string sender = "s.daroukh.dev@gmail.com"; // Sending Email Adress
        private SmtpClient client2 = new SmtpClient("smtp.gmail.com", 587); //Gmail SMTP Server 
        private string senderpwd = Decryptor.Decrypt(); // Password is encrypted and no more hard coded

        public Task SendEmailAsync(string email, string subject, string message)
        { 
            // Creating an MailMessage object
            MailMessage mailMessage = new MailMessage(sender, email);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            // Connecting to the email
            System.Net.NetworkCredential basicCredential12 = new System.Net.NetworkCredential(sender, senderpwd);
            client2.EnableSsl = true;
            client2.UseDefaultCredentials = false;
            client2.Credentials = basicCredential12;
            try
            {
                client2.Send(mailMessage);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Task.CompletedTask;
        }
    }
}