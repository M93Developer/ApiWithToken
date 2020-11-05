using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Api.Services;
using Api.Model;
using Microsoft.Extensions.Configuration;
using Api.Services.Contracts;

namespace AprendeNetCore2.Controllers
{

    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody]ApiUser user)
        {

            if (await _authService.ValidateLogin(user)){
                var startDateTime = DateTime.UtcNow;
                var expireDateTime = startDateTime.Add(TimeSpan.FromHours(5));

                var token = _authService.GenerateToken(startDateTime, user, expireDateTime);

                return Ok(new
                {
                    Token = token,
                    ExpireAt = expireDateTime
                });
            }
            else
            {
                return StatusCode(401);
            }

        }


    }
}
