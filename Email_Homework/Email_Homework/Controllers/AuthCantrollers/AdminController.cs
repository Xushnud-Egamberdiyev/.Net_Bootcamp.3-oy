using Email_Application.IServer;
using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Enum;
using Email_Domen.Entity.Model;
using Email_Homework.Attributes;
using Email_Homework.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace Email_Homework.Controllers.AuthCantrollers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IAdminServeces _adminServeces;

        public AdminController(IAdminServeces services, IWebHostEnvironment env)
        {
            _adminServeces = services;
            _env = env;
        }

        [HttpPost]
        [IdentityFilter(Permission.CreateAdmin)]
        public async Task<DocModel> CreateAdmin([FromForm] DocDTO model, FileModel formFile)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);

            string picturePath = await service.AddPictureAndGetPath(formFile);

            var result = _adminServeces.Create(model, picturePath).Result;

            return result;

        }
        [HttpGet]
        [IdentityFilter(Permission.GetAdmin)]
        public async Task<ActionResult<IEnumerable<DocDTO>>> GetAllAdmin()
        {
            var result = await _adminServeces.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetAdminById)]

        public async Task<ActionResult<DocDTO>> GetByIdAdmin([FromForm] int id)
        {
            var result = await _adminServeces.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        [IdentityFilter(Permission.UpdateAdmin)]

        public async Task<ActionResult<DocDTO>> UpdateAdmin(int id, [FromForm] DocDTO model, FileModel file)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);

            string picturePath = await service.AddPictureAndGetPath(file);
            var result = await _adminServeces.UpdateAsync(id, model, picturePath);
            return Ok(result);
        }
        [HttpDelete]
        [IdentityFilter(Permission.DeleteAdmin)]

        public async Task<ActionResult<string>> DeleteAdmin([FromForm] int id)
        {
            var result = await _adminServeces.Delete(x => x.Id == id);

            if (result)
            {
                return Ok("Delet boldi");
            }
            return BadRequest("Something went wrong");
        }
    }
}
