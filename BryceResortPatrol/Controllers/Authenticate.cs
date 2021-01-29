using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BryceResortPatrol.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class Authenticate : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;

        public Authenticate(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        [HttpPost, Route("sign-in")]
        public IActionResult SignIn([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("An error occurred when attempting to login.");
            }

            try
            {
                var loginToken = this.authenticateService.GetLoginToken(user);
                return Ok(new { token = loginToken });
            }
            catch (UnauthorizedAccessException)
            {
                //log whomever tried to access
                return Unauthorized("Nope");
            }
        }

        [HttpGet, Route("validate")]
        [Authorize]
        public bool Validate()
        {
            return true;
        }
    }
}
