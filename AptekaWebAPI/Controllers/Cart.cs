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
            if (activeUser == null ) throw new Exception("User not found!");
            if (activeUser.Id < 4) throw new Exception("You are logged in like an Admin. Please, log in as User");
            _service.AddById(activeUser.Id, dto);
            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public ActionResult RemoveById([FromHeader] string token, [FromRoute] int id)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null ) throw new Exception("User not found!");
            if (activeUser.Id < 4) throw new Exception("You are logged in like an Admin. Please, log in as User");

            _service.RemoveById(id);
            return Ok();
        }

        [HttpPut("update")]
        public ActionResult Modify([FromHeader] string token, [FromBody] AddToCartDTO dto)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null ) throw new Exception("User not found!");
            if (activeUser.Id < 4) throw new Exception("You are logged in like an Admin. Please, log in as User");

            _service.Modify(dto);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult GetAllFavourites([FromHeader] string token)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null ) throw new Exception("User not found!");
            if (activeUser.Id < 4) throw new Exception("You are logged in like an Admin. Please, log in as User");

            var allProducts = _service.GetAll(activeUser.Id);
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public ActionResult GetFavouriteByID([FromHeader] string token, [FromRoute] int id)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null ) throw new Exception("User not found!");
            if (activeUser.Id < 4) throw new Exception("You are logged in like an Admin. Please, log in as User");
            var selectedProduct = _service.GetByID(id);
            return Ok(selectedProduct);
        }
    }
}
