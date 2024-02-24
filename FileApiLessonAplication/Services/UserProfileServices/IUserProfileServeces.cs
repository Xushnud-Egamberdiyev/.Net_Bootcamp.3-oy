using FileApiLesson.Domen.Entitys.DTOs;
using FileApiLesson.Domen.Entitys.Models;

namespace FileApiLesson.Aplication.Services.UserProfileServices
{
    internal interface IUserProfileServeces
    {
        public Task<UserProfileDTO> CreateUserProfileAsynk(UserProfileDTO userDTO);
        public Task<List<UserProfile>> GetAllUserProfileAsynk();
        public Task<UserProfile> GetByIdUserProfileAsynk(int id);
        public Task<bool> DeleteUserProfileAsynk(int id);
        public Task<UserProfile> UpdateUserProfileAsynk(int id, UserProfileDTO UserDTO);


    }
}
