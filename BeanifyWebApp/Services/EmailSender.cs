using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BeanifyWebApp.Security;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BeanifyWebApp.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
       // Sending Email Adress
        private string sender = "noreply.beanify@gmail.com";

        public Task SendEmailAsync(string email, string subject, string message)
        { 
            // Creating an MailMessage object
            MailMessage mailMessage = new MailMessage(sender, email);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            return SendEmailAsyncUsingGoogleSMTP(mailMessage);
            //return SendEmailAsyncUsingSendGrid(mailMessage);
        }

        private Task SendEmailAsyncUsingGoogleSMTP(MailMessage mailMessage)
        {
            SmtpClient client2 = new SmtpClient("smtp.gmail.com", 587); //Gmail SMTP Server 
            string senderpwd = Decryptor.Decrypt(); // Password is encrypted and no more hard coded
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

        private Task SendEmailAsyncUsingSendGrid(MailMessage mailMessage)
        {
            string sender = "coffee@beanify.com";

            var apiKey = Environment.GetEnvironmentVariable("BEANIFY_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            
            var from = new EmailAddress(sender);
            var to = new EmailAddress(mailMessage.To.ToString());
            var msg = MailHelper.CreateSingleEmail(from, to, mailMessage.Subject, null, "Hello World");
            try
            {
                client.SendEmailAsync(msg);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Task.CompletedTask;
        }

    }
}