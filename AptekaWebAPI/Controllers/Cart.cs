using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("/user/api/cart")]
    public class Cart : ControllerBase
    {
        [HttpPost("{id}")]
        public ActionResult AddById([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveById([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Modify([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpGet("/all")]
        public ActionResult GetAll()
        {
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetByID([FromRoute] int id)
        {
            return NotFound();
        }
    }
}
