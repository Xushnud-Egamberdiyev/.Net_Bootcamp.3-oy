using Email_Application.IServer;
using Email_Application.Serveces;
using Email_Domen.Entity.DTOs;
using Email_Domen.Entity.Enum;
using Email_Domen.Entity.Model;
using Email_Homework.Atributes;
using Email_Homework.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Email_Homework.Controllers.AuthCantrollers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServeces _adminServeces;

        public AdminController(IAdminServeces services)
        {
            _adminServeces = services;
        }

        [HttpPost]
        [IdentityFilter(Permission.CreateAdmin)]
        public async Task<DocModel> CreateAdmin([FromForm]DocDTO model)
        {
            try
            {
                var result = await _adminServeces.Create(model);
                return result;
            }
            catch (Exception ex)
            {
                return new DocModel();
            }

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

        public async Task<ActionResult<DocDTO>> UpdateAdmin([FromForm] int id,DocDTO model)
        {
            var result = await _adminServeces.UpdateAsync(id,model);
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
