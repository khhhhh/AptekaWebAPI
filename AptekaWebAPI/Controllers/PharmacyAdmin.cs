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

        [HttpPost("addProduct")]
        public ActionResult AddNewProduct([FromHeader] string token, [FromBody] CreateProductDTO dto)
        {
            _service.AddNewProduct(dto);
            return Ok();
        }

        [HttpGet("allProducts")]
        public ActionResult GetAllProducts()
        {
            _service.GetAll();
            return Ok();
        }

        [HttpGet("product/{id}")]
        public ActionResult GetProductById([FromHeader] string token, [FromRoute] int id)
        {
            _service.GetById(id);
            return Ok();
        }

        [HttpGet("product/{name}")]
        public ActionResult GetProductByName([FromHeader] string token, [FromRoute] string name)
        {
            _service.GetByName(name);
            return Ok();
        }


        [HttpPut("product/{id}")]
        public ActionResult Modify([FromHeader] string token,[FromBody] UpdateProductDTO dto)
        {
            _service.Modify(dto);
            return Ok();
        }

        [HttpDelete("product/{id}")]
        public ActionResult Delete([FromHeader] string token, [FromRoute] int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }

}
