using Email_Application.IServer;
using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Enum;
using Email_Domen.Entity.Model;
using Email_Homework.Attributes;
using Email_Homework.ExternalServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Email_Homework.Controllers.AuthCantrollers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUSerServices _userSer;

        public UserController(IUSerServices services, IWebHostEnvironment env)
        {
            _userSer = services;
            _env = env;
        }

        [HttpPost]
        [IdentityFilter(Permission.CreateUser)]
        public async Task<DocModel> CreateUser([FromForm] DocDTO model, FileModel file)
        {

            UserProfileExternalService service = new UserProfileExternalService(_env);

            string picturePath = await service.AddPictureAndGetPath(file);

            var result = _userSer.CreateAsync(model, picturePath).Result;
            return result;



        }
        [HttpGet]
        [IdentityFilter(Permission.GetUser)]
        public async Task<ActionResult<IEnumerable<DocDTO>>> GetAllUser([FromForm] string fullname)
        {
            var result = await _userSer.GetAllAsync(fullname);
            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetUserById)]

        public async Task<ActionResult<DocDTO>> GetByIdUser([FromForm] int id, string fullname)
        {
            var result = await _userSer.GetById(fullname, id);
            return Ok(result);
        }

        [HttpPut]
        [IdentityFilter(Permission.UpdateUSer)]

        public async Task<ActionResult<DocDTO>> UpdateUser(int id, string fullname, [FromForm] DocDTO model, FileModel file)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);

            string picturePath = await service.AddPictureAndGetPath(file);
            var result = await _userSer.UpdateAsync(id, fullname, model, picturePath);
            return Ok(result);
        }
        [HttpDelete]
        [IdentityFilter(Permission.DeleteUser)]

        public async Task<ActionResult<string>> DeleteUSer([FromForm] int id)
        {
            var result = await _userSer.Delete(x => x.Id == id);

            if (result)
            {
                return Ok("Delet boldi");
            }
            return BadRequest("Something went wrong");
        }
    }
}
