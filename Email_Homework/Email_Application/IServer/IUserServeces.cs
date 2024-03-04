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
    public interface IUSerServices
    {
        Task<DocModel> CreateAsync(DocDTO docDTO, string picturepath);
        Task<DocModel> GetById(string fullname, int id);
        Task<IEnumerable<DocModel>> GetAllAsync(string fullname);
        Task<bool> Delete(Expression<Func<DocModel, bool>> expression);
        Task<DocModel> UpdateAsync(int id,string fullname, DocDTO docDTO, string picturepath);
    }
}
