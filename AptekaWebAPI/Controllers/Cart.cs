using AptekaWebAPI.DTO;
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
    [Route("/user/api/cart/favourite")]
    public class Cart : ControllerBase
    {
        private readonly ICartService _service;

        public Cart(ICartService service)
        {
            _service = service;

        }

        [HttpPost]
        public ActionResult AddById([FromHeader] string token, [FromBody] AddToCartDTO dto)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null) throw new Exception();
            _service.AddById(activeUser.Id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveById([FromHeader] string token, [FromRoute] int id)
        {
            _service.RemoveById(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Modify([FromHeader] string token, [FromBody] AddToCartDTO dto)
        {
            _service.Modify(dto);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult GetAllFavourites([FromHeader] string token)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null) throw new Exception();

            var allProducts = _service.GetAll(activeUser.Id);
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public ActionResult GetFavouriteByID([FromHeader] string token, [FromRoute] int id)
        {
            var selectedProduct = _service.GetByID(id);
            return Ok(selectedProduct);
        }
    }
}
