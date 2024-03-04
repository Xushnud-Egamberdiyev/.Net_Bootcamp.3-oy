using Email_Application.AuthServices;
using Email_Application.IServer;
using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Email_Application.Serveces
{
    public class LoginServece : ILoginServece
    {
        private readonly IConfiguration _config;

        private readonly IloginRepository _LoginRep;
        private readonly IAuthService _authService;


        public LoginServece(IConfiguration configuration, IAuthService authService, IloginRepository iloginRepository)
        {
            _config = configuration;
            _authService = authService;
            _LoginRep = iloginRepository;
        }
        public async Task<string> SingUpAsync(SingUpDTO singUpDTO)
        {
            if (singUpDTO.Password != singUpDTO.confirmationcode)
            {
                throw new Exception("Passwords do not match");
            }
           


            var model = new Login()
            {
                Email = singUpDTO.Email,
                Password = singUpDTO.Password,
            };
            await _LoginRep.Create(model);
            return "Siz roʻyxatdan oʻtdingiz!\nBoshlash uchun tizimga kiring!";


        }

        public async Task<Login> SingInAsync(LoginDTO loginDTO)
        {
            //var model = await _context.Logins.FirstOrDefaultAsync(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);
            var model = await _LoginRep.GetByAny(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);

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


            await smtpClient.SendMailAsync(mailMessage);


            //var login = await _context.Logins.FirstAsync(x => x.Email == model.Email);

            //login.SendCode = code;
            //await _context.SaveChangesAsync();

            var login = await _LoginRep.GetByAny(x => x.Email == model.Email);

            if (login != null)
            {
                login.Email = loginDTO.Email;
                login.Password = loginDTO.Password;
                login.SendCode = code;
            }


            var update = await _LoginRep.Update(login);

            return update;
        }

        public async Task<string> CheckPassword(UserChecDTO Chec)
        {
            var model = await _LoginRep.GetByAny(x => x.Email == Chec.Email && x.SendCode == Chec.ChecPassword);

            if (model is null)
                try
                {
                    var result = await _authService.GenerateToken(Chec);
                    return result;
                }
                catch
                {
                    return "Something went wrong";
                }

            return "Null";

        }
    }
}
