using FileApiLesson.Domen.Entitys.DTOs;
using FileApiLesson.Domen.Entitys.Models;
using FileLessonApi.ExternalService;
using LearningApiAndEntity.Infracture;

namespace FileApiLesson.Aplication.Services.UserProfileServices
{
    public class UserProfileService : IUserProfileServeces
    {
        private readonly AplicationDbContext _context;
        public UserProfileService(AplicationDbContext aplicationDbContext)
        {
            _context = aplicationDbContext;
        }

        public async Task<UserProfileDTO> CreateUserProfileAsynk(UserProfileDTO userDTO)
        {
            UserProfileExternalService obj = new UserProfileExternalService();
            var model = new UserProfile
            {
                FullName = userDTO.FullName,
                Phone = userDTO.Phone,
                Role = userDTO.Role,
                Login = userDTO.Login,
                Password = userDTO.Password,
                PicturePath = await obj.AddPictureAnGetPath(userDTO.Picture),
            };

            _context.Users
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
