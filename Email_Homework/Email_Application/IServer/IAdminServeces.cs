using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Email_Application.IServer
{
    public interface IAdminServeces
    {
        Task<DocModel> Create(DocDTO docDTO);
        Task<DocModel> GetById(int id);
        Task<IEnumerable<DocModel>> GetAll();
        Task<bool> Delete(Expression<Func<DocModel, bool>> expression);
        Task<DocModel> UpdateAsync(int id, DocDTO docDTO);
    }
}
