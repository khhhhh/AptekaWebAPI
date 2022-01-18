using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("/login")]
    public class Login : ControllerBase
    {
        [HttpPut]
        public ActionResult Logining([FromHeader] string token,[FromBody] string login, [FromBody] string password)
        {
            return NotFound();
        }
    }
}
