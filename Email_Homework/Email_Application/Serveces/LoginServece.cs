using Email_Application.IServer;
using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Email_Infrustructur;

namespace Email_Application.Serveces
{
    public class LoginServece : ILoginServece
    {
        private readonly App
        private readonly IConfiguration _config;

        public LoginServece(AddAplication aplication, IConfiguration configuration)
        {
            _config = configuration;
            _context = aplication;
        }
        public async Task SingUpAsync(SingUpDTO singUpDTO)
        {
            if (singUpDTO.Password != singUpDTO.confirmationcode)
            {
                throw new Exception("Email already exists");
            }
            else if (singUpDTO.Password != singUpDTO.confirmationcode)
            {
                throw new Exception("Passwords do not match");
            }


            var model = new Login()
            {
                Email = singUpDTO.Email,
                Password = singUpDTO.Password,
                SendCode = "0"
            };

            await _context.Logins.AddAsync(model);
            await _context.SaveChangesAsync();

        }

        public async Task<Login> SingInAsync(LoginDTO loginDTO)
        {
            var model = await _context.Logins.FirstOrDefaultAsync(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);

            if (model == null)
                return null;

            Random random = new Random();
            string code = $"{random.Next(10000, 100000)}";

            var emailSettings = _config.GetSection("EmailSettings");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = "Unique Code",
                Body = code,
                IsBodyHtml = true,

            };
            mailMessage.To.Add(model.Email);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };

            //smtpClient.UseDefaultCredentials = true;

            await smtpClient.SendMailAsync(mailMessage);


            var login = await _context.Logins.FirstAsync(x => x.Email == model.Email);

            login.SendCode = code;
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Login> CheckPassword(CHecPassword Chec)
        {
            var model = await _context.Logins.FirstOrDefaultAsync(x => x.Email == Chec.Email && x.SendCode == Chec.ChecPassword);

            if (model is null)
                return null;

            return model;


        }
    }
}
