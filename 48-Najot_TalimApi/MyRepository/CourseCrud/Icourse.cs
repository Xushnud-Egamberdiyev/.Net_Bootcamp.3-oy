using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;

namespace _48_Najot_TalimApi.MyRepository.CourseCrud
{
    public interface Icourse
    {
        public string Create(CourseDTO courseDTO);
        public string Update(CourseDTO courseDTO, int id);
        public string Delete(int id);
        public IEnumerable<CourseModel> GetAll();
        public CourseModel GetId(int id);
    }
}
