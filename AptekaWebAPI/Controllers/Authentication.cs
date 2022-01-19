﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class Authentication : ControllerBase
    {

        [HttpGet("/registration")]
        public ActionResult Registrating([FromHeader] string token, [FromHeader] string login,[FromHeader] string password)
        {
            return NotFound();
        }


        [HttpPut("/login")]
        public ActionResult Logining([FromHeader] string token, [FromHeader] string login, [FromHeader] string password)
        {
            return NotFound();
        }
    }
}
