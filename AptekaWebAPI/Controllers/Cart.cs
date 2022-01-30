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
    [Route("/user/api/cart")]
    public class Cart : ControllerBase
    {
        private readonly ICartService _service;

        public Cart(ICartService service)
        {
            _service = service;

        }

        [HttpPost("/favourite/{id}")]
        public ActionResult AddById([FromHeader] string token, [FromRoute] int id)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null) throw new Exception();
            var 
            return NotFound();
        }

        [HttpDelete("/favourite/{id}")]
        public ActionResult RemoveById([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpPut("/favourite/{id}")]
        public ActionResult Modify([FromRoute] int id)
        {
            return NotFound();
        }

        [HttpGet("/allFavourites")]
        public ActionResult GetAllFavourites()
        {
            return NotFound();
        }

        [HttpGet("/favourite/{id}")]
        public ActionResult GetFavouriteByID([FromRoute] int id)
        {
            return NotFound();
        }
    }
}
