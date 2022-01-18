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
        [HttpPut("/Log")]
        public ActionResult Logining([FromHeader] string token,[FromHeader] string login, [FromHeader] string password)
        {
            return NotFound();
        }
    }
}
