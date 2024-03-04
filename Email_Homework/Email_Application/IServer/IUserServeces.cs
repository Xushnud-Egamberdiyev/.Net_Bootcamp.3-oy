using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using System.Linq.Expressions;

namespace Email_Application.IServer
{
    public interface IUSerServices
    {
        Task<DocModel> CreateAsync(DocDTO docDTO, string picturepath);
        Task<DocModel> GetById(string fullname, int id);
        Task<IEnumerable<DocModel>> GetAllAsync(string fullname);
        Task<bool> Delete(Expression<Func<DocModel, bool>> expression);
        Task<DocModel> UpdateAsync(int id, string fullname, DocDTO docDTO, string picturepath);
    }
}
