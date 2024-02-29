using Email_Domen.Entity.Enum;
using Email_Homework.Atributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Email_Homework.Controllers.AuthCantrollers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        List<string> users = new List<string>()
        {
            "Student 1","Student 2","Student 3","Student 4","Student 5"
        };

        List<string> teachers = new List<string>()
        {
            "Teacher 1","Teacher 2","Teacher 3","Teacher 4","Teacher 5"
        };

        [HttpGet]
        [IdentityFilterAtribute(Permission.GetAllStudent)]
        public IActionResult GetTeachers()
        {
            return Ok(users);
        }

        [HttpGet]
        [IdentityFilterAtribute(Permission.GetTeacher)] 
        public IActionResult GetStudents()
        {
            return Ok(teachers);
        }

        [HttpPost]
        [IdentityFilterAtribute(Permission.CreateStudent)]
        public IActionResult CreateStudent()
        {
            return Ok("Create boldi");
        }

        [HttpDelete]
        [IdentityFilterAtribute(Permission.DeleteStudent)]
        public IActionResult DeleteStudent()
        {
            return Ok("Delete boldi");
        }
    }
}
