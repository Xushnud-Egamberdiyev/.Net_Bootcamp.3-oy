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
    public class AdminServeces : IAdminServeces
    {
        private readonly IAdminRepository _adminRepository;


        public AdminServeces(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<DocModel> Create(DocDTO docDTO)
        {
            var model = new DocModel()
            {
                FullName = docDTO.FullName,
                PhoneNumber = docDTO.PhoneNumber,
                Description = docDTO.Description,
                Data = DateTime.UtcNow
            };

            var result = await _adminRepository.Create(model);
            return result;
        }

        public Task<bool> Delete(Expression<Func<DocModel, bool>> expression)
        {
            var result = _adminRepository.Delete(expression);

            return result;
        }

        public async Task<IEnumerable<DocModel>> GetAll()
        {
            var model = await _adminRepository.GetAll();

            return model;
        }

        public async Task<DocModel> GetById(int id)
        {
            var model = await _adminRepository.GetByAny(x =>x.Id == id);

            return model;
        }

        public async Task<DocModel> UpdateAsync(int id, DocDTO docDTO)
        {
            var res = await _adminRepository.GetByAny(x => x.Id == id);

            if (res != null)
            {
                var model = new DocModel()
                {
                    FullName = res.FullName,
                    PhoneNumber = res.PhoneNumber,
                    Description = res.Description,
                    Data = DateTime.UtcNow
                };

                var result = await _adminRepository.Update(model);

                return result;
            }
            return new DocModel();
        }

    }
}
