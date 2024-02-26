using Email_Application.Serveces.EmailServeces;
using Email_Domen.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Email_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServece _email;

        public EmailController(IEmailServece emailServece)
        {
            _email = emailServece;
        }

        public async Task<IActionResult> SendEmail([FromBody] EmailModel model)
        {
            await _email.SendEmailAsync(model);

            return Ok("Muvofiqiyatli saqlandi");
        }
    }
}
