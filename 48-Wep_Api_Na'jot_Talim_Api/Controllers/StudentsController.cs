using _48_Wep_Api_Na_jot_Talim_Api.DTO;
using _48_Wep_Api_Na_jot_Talim_Api.MyPattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _48_Wep_Api_Na_jot_Talim_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Istudent _istudent;

        public StudentsController(Istudent istudent)
        {
            _istudent = istudent;
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
    }
}
