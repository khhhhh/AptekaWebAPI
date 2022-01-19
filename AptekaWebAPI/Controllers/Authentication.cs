using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AptekaWebAPI.Services;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("api/home/")]
    public class Authentication : ControllerBase
    {
        private readonly IAutrhenticationService _service;
        public Authentication(IAutrhenticationService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("authentication/{type}")]
        public ActionResult<string> OperationType([FromRoute] string type)
        {

            var result = _service.OperationType(type);
            return Ok(result);
        }

        [HttpGet("~/registration")]
        public ActionResult Registrating([FromHeader] string login,[FromHeader] string password)
        {
            return NotFound();
        }


        [HttpPut("~/login")]
        public ActionResult Logining([FromHeader] string login, [FromHeader] string password)
        {
            return NotFound();
        }
    }
}
