using Email_Application.IServer;
using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Model;
using System.Linq.Expressions;

namespace Email_Application.Serveces
{
    public class UserServeces : IUSerServices
    {
        private readonly IUserRepository _userRepository;


        public UserServeces(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<DocModel> CreateAsync(DocDTO docDTO, string picturepath)
        {

            var model = new DocModel()
            {
                FullName = docDTO.FullName,
                PhoneNumber = docDTO.PhoneNumber,
                Description = docDTO.Description,
                Data = DateTime.UtcNow,
                PicturePath = picturepath

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

        public async Task<DocModel> UpdateAsync(int id, string fullname, DocDTO docDTO, string picturepath)
        {
            var res = await _userRepository.GetByAny(x => x.Id == id && x.FullName == fullname);

            if (res != null)
            {
                res.FullName = docDTO.FullName;
                res.PhoneNumber = docDTO.PhoneNumber;
                res.Description = docDTO.Description;
                res.Data = DateTime.UtcNow;
                res.PicturePath = picturepath;

                var result = await _userRepository.Update(res);

                return result;
            }
            return new DocModel();
        }



    }
}
