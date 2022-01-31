using AptekaWebAPI.Properties.DTOs;
using AptekaWebAPI.Services;
using AptekaWebAPI.Tokens;
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
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null || activeUser.Id > 3) throw new Exception();
            _service.AddNewProduct(dto);
            return Ok();
        }

        [HttpGet("allProducts")]
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts([FromHeader] string token)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null || activeUser.Id > 3) throw new Exception();
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProductById([FromHeader] string token, [FromRoute] int id)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null || activeUser.Id > 3) throw new Exception();

            var product = _service.GetById(id);
            return Ok(product);
        }


        [HttpPut("update")]
        public ActionResult Modify([FromHeader] string token,[FromBody] UpdateProductDTO dto)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null || activeUser.Id > 3) throw new Exception();

            _service.Modify(dto);
            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public ActionResult Delete([FromHeader] string token, [FromRoute] int id)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null || activeUser.Id > 3) throw new Exception();
            _service.Delete(id);
            return Ok();
        }
    }

}
