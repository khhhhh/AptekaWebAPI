using AptekaWebAPI.Tokens;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{

    [ApiController]
    [Route("api/buy")]
    public class Buy : ControllerBase
    {
        [HttpGet()]
        public ActionResult BuyFromCart([FromHeader] string token)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null) throw new Exception();

            return Ok();
        }
    }
}
