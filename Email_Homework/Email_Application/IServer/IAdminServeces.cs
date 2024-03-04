using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using System.Linq.Expressions;

namespace Email_Application.IServer
{
    public interface IAdminServeces
    {
        Task<DocModel> Create(DocDTO docDTO, string picturepath);
        Task<DocModel> GetById(int id);
        Task<IEnumerable<DocModel>> GetAll();
        Task<bool> Delete(Expression<Func<DocModel, bool>> expression);
        Task<DocModel> UpdateAsync(int id, DocDTO docDTO, string picturepath);
    }
}
