using Microsoft.AspNetCore.Mvc;
using SendEmail.Domain.Entity.Modols;




namespace SenEamil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public IEmailService EmailService => _emailService;

        [HttpPost]
        public Task<IActionResult> SendEmail([FromBody] EmailModel model)
        {

        }

    }
}
