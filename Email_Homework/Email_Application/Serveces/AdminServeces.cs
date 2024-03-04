using Email_Application.IServer;
using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using System.Linq.Expressions;

namespace Email_Application.Serveces
{
    public class AdminServeces : IAdminServeces
    {
        private readonly IAdminRepository _adminRepository;


        public AdminServeces(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<DocModel> Create(DocDTO docDTO, string picturepath)
        {
            var model = new DocModel()
            {
                FullName = docDTO.FullName,
                PhoneNumber = docDTO.PhoneNumber,
                Description = docDTO.Description,
                Data = DateTime.UtcNow,
                PicturePath = picturepath

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
            var model = await _adminRepository.GetByAny(x => x.Id == id);

            return model;
        }

        public async Task<DocModel> UpdateAsync(int id, DocDTO docDTO, string picturepath)
        {
            var res = await _adminRepository.GetByAny(x => x.Id == id);

            if (res != null)
            {
                res.FullName = docDTO.FullName;
                res.PhoneNumber = docDTO.PhoneNumber;
                res.Description = docDTO.Description;
                res.Data = DateTime.UtcNow;
                res.PicturePath = picturepath;

                var result = await _adminRepository.Update(res);

                return result;
            }
            return new DocModel();
        }

    }
}
