using FileApiLesson.Domen.Entitys.DTOs;
using FileApiLesson.Domen.Entitys.Models;
using FileApiLesson.Infrustructure.Persistance;
using LearningApiAndEntity.Infracture;




namespace FileApiLesson.Aplication.Services.UserProfileServices
{
    public class UserProfileService : IUserProfileServeces
    {
        private readonly ApplicationDbContext _context;

        public UserProfileService(ApplicationDbContext aplicationDb)
        {
            _context = aplicationDb;
        }

        public async Task<UserProfileDTO> CreateUserProfileAsynk(UserProfileDTO userDTO)
        {
            //UserProfileExternalService obj = new UserProfileExternalService();
            var model = new UserProfile
            {
                FullName = userDTO.FullName,
                Phone = userDTO.Phone,
                Role = userDTO.Role,
                Login = userDTO.Login,
                Password = userDTO.Password,
                //PicturePath = await obj.AddPictureAnGetPath(userDTO.Picture),
            };

            _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return userDTO;
        }

        public Task<bool> DeleteUserProfileAsynk(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProfile>> GetAllUserProfileAsynk()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetByIdUserProfileAsynk(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> UpdateUserProfileAsynk(int id, UserProfileDTO UserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
