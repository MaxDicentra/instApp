using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using instagram.Services;

namespace instagram.Models
{
    public class EmailService : IEmailSender
    {
        public IConfiguration Configuration { get; }

        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Administration", Configuration.GetSection("EmailServices")["EmailAdress"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 25, false);
                await client.AuthenticateAsync(Configuration.GetSection("EmailServices")["EmailAdress"], Configuration.GetSection("EmailServices")["Password"]);               
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }

}
