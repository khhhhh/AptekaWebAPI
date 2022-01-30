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
using AptekaWebAPI.Properties.DTOs;
using AptekaWebAPI.DTO;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class Authentication : ControllerBase
    {
        private readonly IAutrhenticationService _service;
        private readonly JWTSettings _jwtSettings;

        public Authentication(IAutrhenticationService service, IOptions<JWTSettings> jwtSettings)
        {
            _service = service;
            _jwtSettings = jwtSettings.Value;

        }

        [HttpPost("registration")]
        public ActionResult Registrating([FromBody] CreateUserDTO dto)
        {
            var count = _service.Registrating(dto);
            return Ok(count);
        }


        [HttpGet("login")]
        public ActionResult<string> Logining([FromBody] LoginUserDTO dto)
        {
            var userID = _service.Logining(dto);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, dto.Login)
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginedUserToken = tokenHandler.WriteToken(token);

            var loginedUser = new LoginedUser()
            {
                Id = userID,
                Token = loginedUserToken
            };

            var activeUsers = new ActiveUsers();
            activeUsers.addUser(loginedUser);

            return Ok($"Your token : {loginedUserToken}");
        }
    }
}
