using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{
    [ApiController]
    [Route("/admin/api/pharmacy")]
    public class PharmacyAdmin : ControllerBase
    {
        [HttpGet("/allProducts")]
        public ActionResult GetAllProducts()
        {

            return NotFound();
        }

        [HttpGet("/product/{id}")]
        public ActionResult GetProductById([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpGet("/product/{name}")]
        public ActionResult GetProductByName([FromRoute] string name)
        {
            return NotFound();
        }


        [HttpPut("/product/{id}")]
        public ActionResult Modify([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpDelete("/product/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            return NotFound();
        }
    }
}
