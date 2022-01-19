using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AptekaWebAPI.Services;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class Authentication : ControllerBase
    {
        private readonly IAutrhenticationService _service;
        public Authentication(IAutrhenticationService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult OperationType([FromBody] string type)
        {
            var result = _service.OperationType(type);
            return Ok(result);
        }

        [HttpGet("/registration")]
        public ActionResult Registrating([FromHeader] string login,[FromHeader] string password)
        {
            return NotFound();
        }


        [HttpPut("/login")]
        public ActionResult Logining([FromHeader] string login, [FromHeader] string password)
        {
            return NotFound();
        }
    }
}
