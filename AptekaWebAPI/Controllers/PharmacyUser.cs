using AptekaWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("/user/api/pharmacy")]
    public class PharmacyUser : ControllerBase
    {
        private readonly IPharmacyUserService _service;

        public PharmacyUser(IPharmacyUserService service)
        {
            _service = service;

        }
        [HttpGet("all")]
        public ActionResult GetAll([FromHeader] string token)
        {
            _service.GetAll();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromHeader] string token, [FromRoute] int id)
        {
            _service.GetById(id);
            return Ok();
        }

    }
}
