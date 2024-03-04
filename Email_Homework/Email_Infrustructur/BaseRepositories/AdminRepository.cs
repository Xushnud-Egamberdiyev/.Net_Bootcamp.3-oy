using Email_Application.IServer;
using Email_Domen.Entity.Model;

namespace Email_Infrustructur.BaseRepositories
{
    public class AdminRepository : BaseRepository<DocModel>, IAdminRepository
    {
        public AdminRepository(AddAplication context) : base(context, context.Set<DocModel>())
        {
        }
    }
}
