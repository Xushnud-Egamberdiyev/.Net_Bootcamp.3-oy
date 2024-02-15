using _48_Najot_TalimApi.DTO;
using _48_Najot_TalimApi.Models;
using _48_Najot_TalimApi.MyPattern;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace _48_Najot_TalimApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Istudent _istudent;

        public StudentsController(Istudent istudent)
        {
            _istudent = istudent;
        }
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            try
            {
                var response = _istudent.GetAllStudents();
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                var response = _istudent.CreateStudent(studentDTO);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet] 
        public Student GetById(int id)
        {
           
                var response = _istudent.GetByIdStudent(id);
                return response;
         
        }


        [HttpDelete]
        public string StudentDelete(int id)
        {
            try
            {
                var response = _istudent.DeleteStudent(id);
                return "Malumot ochirildi";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPatch]
        public Student StudentUpdate(int id, StudentDTO studentDTO)
        {
            try
            {
                var response = _istudent.UpdateStudent(id, studentDTO);
                return Student;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
