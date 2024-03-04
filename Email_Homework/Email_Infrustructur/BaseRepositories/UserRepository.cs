using Email_Application.IServer;
using Email_Domen.Entity.Model;

namespace Email_Infrustructur.BaseRepositories
{
    public class UserRepository : BaseRepository<DocModel>, IUserRepository
    {
        public UserRepository(AddAplication context) : base(context)
        {
        }
    }
}
