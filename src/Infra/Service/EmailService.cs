using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using Domain.Entities.newEntities;
using Application.Interfaces.Service;
using System.Security.Authentication;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient(_configuration["Smtp:Host"], int.Parse(_configuration["Smtp:Port"])))
            {
                client.Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]);
                client.EnableSsl = true;
               // client.TargetName = "STARTTLS";
                //client.SslProtocols = SslProtocols.Tls12;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["Smtp:From"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(to);


                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
