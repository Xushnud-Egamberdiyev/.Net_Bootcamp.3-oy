using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;
using _48_Najot_TalimApi.MyRepository.StudentCrud;
using _48_Najot_TalimApi.MyServises.StudentSrv;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data.SqlTypes;

namespace _48_Najot_TalimApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public IStudentSrv _student;
        public Istudent _crud;
        public StudentsController(IStudentSrv studentSrv, Istudent istudent)
        {
            _student = studentSrv;
            _crud = istudent;
        }
        [HttpPost]
        public string CreateStudent(StudentDTO studentDTO)
        {
            var x = _student.Create(studentDTO);
            return x;
        }

        [HttpDelete]
        public string DeleteStudent(int id)
        {
            var x = _student.Delete(id);
            return x;
        }

        [HttpGet]
        public IEnumerable<StudentModel> GetStudent()
        {
            IEnumerable<StudentModel> x = _crud.GetAll();
            return x;
        }

        [HttpGet]
        public StudentModel GetByIdStudent(int id)
        {
            StudentModel result = _crud.GetByIDStudents(id);
            return result;

        }
        [HttpPut]
        public string PutStudent(StudentDTO studentDTO, int id)
        {
            var x =_student.Update(id, studentDTO);
            return x;
        }
    }
}

