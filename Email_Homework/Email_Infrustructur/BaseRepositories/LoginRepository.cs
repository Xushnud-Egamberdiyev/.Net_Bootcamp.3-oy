using Email_Application.IServer;
using Email_Domen.Entity.Model;

namespace Email_Infrustructur.BaseRepositories
{
    public class LoginRepository : BaseRepository<Login>, IloginRepository
    {
        public LoginRepository(AddAplication context) : base(context)
        {
        }
    }
}
