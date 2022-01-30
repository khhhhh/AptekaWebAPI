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
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts([FromHeader] string token)
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProductById([FromHeader] string token, [FromRoute] int id)
        {
            var product = _service.GetById(id);
            return Ok(product);
        }


        [HttpPut("update")]
        public ActionResult Modify([FromHeader] string token,[FromBody] UpdateProductDTO dto)
        {
            _service.Modify(dto);
            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public ActionResult Delete([FromHeader] string token, [FromRoute] int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }

}
