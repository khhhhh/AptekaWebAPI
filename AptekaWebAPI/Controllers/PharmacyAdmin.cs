using AptekaWebAPI.Properties.DTOs;
using AptekaWebAPI.Services;
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
        private readonly IPharmacyAdminService _service;

        public PharmacyAdmin(IPharmacyAdminService service)
        {
            _service = service;

        }

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
        public ActionResult Modify([FromHeader] string token,[FromBody] UpdateProductDTO dto)
        {
            _service.Modify(dto);
            return Ok();
        }

        [HttpDelete("/product/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            return NotFound();
        }
    }

}
