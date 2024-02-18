using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;
using _48_Najot_TalimApi.MyRepository.CourseCrud;
using _48_Najot_TalimApi.MyServises.CourseSrv;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _48_Najot_TalimApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public ICourseSrv _course;
        public Icourse _crud;
        public CourseController(ICourseSrv courseSrv, Icourse icourse)
        {
            _course = courseSrv;
            _crud = icourse;
        }

        [HttpPost]
        public string PostCourse(CourseDTO courseDTO)
        {
            var result = _course.CreateCourse(courseDTO);

            return result;
        }

        [HttpDelete]
        public string DeleteCourse(int id)
        {
            string course = _course.DeleteById(id);
            return course;
        }

        [HttpGet]
        public IEnumerable<CourseModel> GetCourse()
        {
            IEnumerable<CourseModel> result = _crud.GetAll();
            return result;
        }

        [HttpGet]
        public CourseModel GetByIDCourse(int id)
        {
            CourseModel result = _course.GetById(id);
            return result;
        }

        [HttpPut]
        public string Update(int id, CourseDTO courseDTO)
        {
            string result = _course.UpdateCourse(courseDTO,id);
            return result;
        }

    }
}
