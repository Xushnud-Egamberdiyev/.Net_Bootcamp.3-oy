using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjects.Application.Abstractions.IServices
{
    public interface IUserService
    {
        public Task<User> Create(User user);
        public Task<User> GetByAny(Expression<Func<User, bool>> expression);
        public Task<IEnumerable<User>> GetAll();
        public Task<bool> Delete(Expression<Func<User, bool>> expression);
        public Task<User> Update(int Id, UserDTO userDTO);
    }
}
