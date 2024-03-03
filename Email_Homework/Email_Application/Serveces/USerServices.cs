using Email_Application.IServer;
using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Email_Application.Serveces
{
    public class UserServeces : IUSerServices
    {
        private readonly IUserRepository _userRepository;


        public UserServeces(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<DocModel> CreateAsync(DocDTO docDTO)
        {
            var model = new DocModel()
            {
                FullName = docDTO.FullName,
                PhoneNumber = docDTO.PhoneNumber,
                Description = docDTO.Description,
                Data = DateTime.UtcNow
            };

            var result = await _userRepository.Create(model);
            return result;
        }

        public Task<bool> Delete(Expression<Func<DocModel, bool>> expression)
        {
            var result = _userRepository.Delete(expression);

            return result;
        }

        public async Task<IEnumerable<DocModel>> GetAllAsync(string fullname)
        {
            var model = _userRepository.GetAll().Result.Select(x => x).Where(c => c.FullName == fullname);

            return model;
        }

        public async Task<DocModel> GetById(string fullname, int id)
        {
            var model = await _userRepository.GetByAny(x => x.FullName == fullname && x.Id == id);

            return model;
        }

        public async Task<DocModel> UpdateAsync(int id,string fullname, DocDTO docDTO)
        {
            var res = await _userRepository.GetByAny(x => x.Id == id && x.FullName == fullname);

            if (res != null)
            {
                var model = new DocModel()
                {
                    FullName = res.FullName,
                    PhoneNumber = res.PhoneNumber,
                    Description = res.Description,
                    Data = DateTime.UtcNow
                };

                var result = await _userRepository.Update(model);

                return result;
            }
            return new DocModel();
        }



    }
}
