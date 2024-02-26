using SendEmail.Domain.Entity.Modols;

namespace SendEmail.Aplication.Servece.SendEmailServece
{
    public interface IEmailService
    {
        public Task SendEmailAsync(EmailModel model);
    }
}
    