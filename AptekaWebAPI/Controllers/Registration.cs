using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("/registration")]
    public class Registration : ControllerBase
    {

        [HttpPut]
        public ActionResult Registrating([FromHeader] string token, [FromHeader] string login,[FromHeader] string password)
        {
            return NotFound();
        }
    }
}
