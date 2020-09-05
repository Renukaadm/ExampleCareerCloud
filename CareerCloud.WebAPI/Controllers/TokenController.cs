using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/Token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private SecurityLoginLogic _logic;
        public TokenController()
        {
            EFGenericRepository<SecurityLoginPoco> repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }

        [HttpPost]
        [Route("{userName}/{password}")]
        public IActionResult Post(string userName, string password)
        {
            SecurityLoginPoco poco = null;
            try
            {
                poco = _logic.Authenticate(userName, password);
            }
            catch (ArgumentOutOfRangeException)
            {
                return Unauthorized();
            }

            Claim[] claims = new Claim[]
            {
                new Claim("Id", poco.Id.ToString()),
                new Claim("FullName", poco.FullName),
                new Claim("Email", poco.EmailAddress),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("kljahfklajhsdfkljasdf"));

            var signKey = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new
                JwtSecurityToken(
                    "CareerCloud",
                    "CareerClient",
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signKey);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}