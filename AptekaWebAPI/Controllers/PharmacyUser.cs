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
        [HttpGet("/all")]
        public ActionResult GetAll()
        {

            return NotFound();
        }

        [HttpGet("/{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpGet("/{name}")]
        public ActionResult GetByName([FromRoute] string name)
        {
            return NotFound();
        }


        [HttpPut("/{id}")]
        public ActionResult Modify([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpDelete("/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            return NotFound();
        }

    }
}
