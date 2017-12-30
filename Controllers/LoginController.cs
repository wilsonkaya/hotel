using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace otelapi
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public IActionResult GetToken([FromBody] TokenRequest request)
        {
            if (request.Username == "erdem" && request.Password == "erdem")
            {
                var claims = new[]
                {
            new Claim(ClaimTypes.Name, request.Username)
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expires=token.ValidTo.ToLocalTime()
                });
            }

            return BadRequest("Could not verify username and password");
        }
    }
}
