using Microsoft.Extensions.Configuration;
using SendEmail.Domain.Entity.Modols;
using System.Net;
using System.Net.Mail;


namespace SendEmail.Aplication.Servece.SendEmailServece
{
    public class EmailServece : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailServece(IConfiguration configuration)
        {
            _config = configuration;
        }c
        public async Task SendEmailAsync(EmailModel model)
        {
            var emailSettings = _config.GetSection("EmailSettings");
            var emailMassage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = model.Subject,
                Body = model.Boby,
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
