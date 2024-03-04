using Email_Application.IServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Email_Homework.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmailController : ControllerBase
    {
        private readonly ILoginServece _login;

        public EmailController(ILoginServece login)
        {
            _login = login;
        }
        //[HttpPost]
        //public async Task<IActionResult> SignUpAsync(SingUpDTO model)
        //{
        //    await _login.SingUpAsync(model);


        //    return Ok("Success");
        //}

        //[HttpPost]
        //public async Task<IActionResult> SignInAsync([FromBody] LoginDTO model)
        //{
        //    var verify = await _login.SingInAsync(model);

        //    if (verify != null)
        //    {
        //        return Ok("Iltimos, biz sizga yuborgan kodni keyingi api-ga kiriting \"");
        //    }

        //    return BadRequest("Siz topilmadingiz!\nAvval roʻyxatdan oʻting!");
        //}

        //[HttpPost]
        //public async Task<IActionResult> SignInVerificationAsync(CHecPassword model)
        //{
        //    var verify = await _login.CheckPassword(model);

        //    if (verify != null)
        //    {
        //        return Ok("Tabriklaymiz!\nSiz tizimga kirdingiz!");
        //    }

        //    return BadRequest("Nimadir noto'g'ri bajarildi!");
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetMail()
        //{
        //    return Ok("ooooooooooooooook");
        //}

    }
}
