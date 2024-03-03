using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Application.IServer
{
    public interface ILoginServece
    {
        public Task SingUpAsync(SingUpDTO singUpDTO);
        public Task<Login> SingInAsync(LoginDTO loginDTO);
        public Task<Login> CheckPassword(CHecPassword cHecPassword);
    }
}
