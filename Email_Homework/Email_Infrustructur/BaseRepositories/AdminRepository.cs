using Email_Application.IServer;
using Email_Domen.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Infrustructur.BaseRepositories
{
    public class AdminRepository : BaseRepository<DocModel>, IAdminRepository
    {
        public AdminRepository(AddAplication context) : base(context, context.Set<DocModel>())
        {
        }
    }
}
