﻿using Email_Application.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace Email_Homework.Controllers.AuthCantrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IAuthService _authService;

        public IdentityController(IAuthService auth)
        {
            _authService = auth;
        }
        //[HttpPost]
        //public IActionResult Login(User model, LoginDTO loginDTO )
        //{
        //    try
        //    {
        //        var result = _authService.GenerateToken(model);
        //        return Ok(result);
        //    }
        //    catch
        //    {
        //        return BadRequest("Something went wrong");
        //    }

        //}


    }
}
