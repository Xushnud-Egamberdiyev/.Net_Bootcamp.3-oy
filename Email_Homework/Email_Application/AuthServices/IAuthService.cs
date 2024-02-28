using Email_Domen.Entity.AuthModels;

namespace Email_Application.AuthServices
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(User user);
    }
}
