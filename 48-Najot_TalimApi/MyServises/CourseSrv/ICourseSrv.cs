using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;

namespace _48_Najot_TalimApi.MyServises.CourseSrv
{
    public interface ICourseSrv
    {
        public string CreateCourse(CourseDTO courseDTO);
        public CourseModel GetById(int id);
        public string DeleteById(int id);
        public string UpdateCourse(CourseDTO courseDTO, int id);
    }
}
