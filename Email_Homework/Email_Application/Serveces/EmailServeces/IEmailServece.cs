using Email_Domen.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Application.Serveces.EmailServeces
{
    public interface IEmailServece
    {
        public Task SendEmailAsync(EmailModel model);
    }
}
