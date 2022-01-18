using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{
    [Route("/api/pharmacy")]
    public class PharmacyUser
    {
        [HttpGet("/all")]
        public ActionResult GetAll()
        {
            return null;
        }

        [HttpGet("/{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            return null;
        }

        [HttpGet("/{name}")]
        public ActionResult GetByName([FromRoute] string name)
        {
            return null;
        }


        [HttpPut("/{id}")]
        public ActionResult Modify([FromRoute] int id)
        {
            return null;
        }

        [HttpDelete("/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            return null;
        }

        //add to cart

        //create new controller for carts
    }
}
