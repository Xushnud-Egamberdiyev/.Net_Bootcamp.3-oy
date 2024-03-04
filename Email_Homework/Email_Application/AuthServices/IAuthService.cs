using Email_Domen.Entity.DTOs;

namespace Email_Application.AuthServices
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(UserChecDTO user);
    }
}
