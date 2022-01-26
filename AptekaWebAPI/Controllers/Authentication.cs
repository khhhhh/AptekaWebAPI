using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AptekaWebAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using AptekaWebAPI.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("api/home/")]
    public class Authentication : ControllerBase
    {
        private readonly IAutrhenticationService _service;
        private readonly JWTSettings _jwtSettings;

        public Authentication(IAutrhenticationService service, IOptions<JWTSettings> jwtSettings)
        {
            _service = service;
            _jwtSettings = jwtSettings.Value;

        }


        //[HttpGet]
        //[Route("authentication/{type}")]
        //public ActionResult<string> OperationType([FromRoute] string type)
        //{

        //    var result = _service.OperationType(type);
        //    return Ok(result);
        //}

        [HttpGet("/registration")]
        public ActionResult Registrating([FromHeader] string login,[FromHeader] string password)
        {
            return NotFound();
        }


        [HttpPut("/login")]
        public ActionResult Logining([FromHeader] string login, [FromHeader] string password)
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Login)
            //    }),
            //    Expires = DateTime.UtcNow.AddMonths(6),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var loginedUserToken = tokenHandler.WriteToken(token);
            return NotFound();
        }
    }
}
