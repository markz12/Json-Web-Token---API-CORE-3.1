using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWTAuth.Services;
using Microsoft.Extensions.Configuration;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet(nameof(FetchToken))] // Get TOKEN - MARK VANZ
        public async Task<IActionResult> FetchToken(string email)
        {
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken(email);
            return Ok(token); // Return Token
        }
    }
}