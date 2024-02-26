using Email_Domen.Entity.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Email_Application.Serveces.EmailServeces
{
    public class EmailServece : IEmailServece
    {
        public readonly IConfiguration _config;
        public EmailServece(IConfiguration configuration)
        {
            _config = configuration;
        }
        
        public async Task SendEmailAsync(EmailModel model)
        {
            var emailSettings = _config.GetSection("EmailSettings");
            var emailMassage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = model.Subject,
                Body = model.Body,
                IsBodyHtml = true,
            };

            emailMassage.To.Add(model.To);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };

            await smtpClient.SendMailAsync(emailMassage);
        }
    }
}
