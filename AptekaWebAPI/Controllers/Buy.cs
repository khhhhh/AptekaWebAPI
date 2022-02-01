using AptekaWebAPI.Services.Interfaces;
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
        private readonly IBuyService _service;

        public Buy(IBuyService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult BuyFromCart([FromHeader] string token)
        {
            var activeUser = new ActiveUsers().GetAllLoginedUsers().Where(x => x.Token == token).FirstOrDefault();
            if (activeUser == null || activeUser.Id < 4) throw new Exception(Resources.notLoggedIn);
            try
            {
                _service.EmailSend(activeUser.Id);
                _service.RemoveAllFromCart(activeUser.Id);
            }
            catch
            {
                throw new Exception(Resources.errorPurchase);
            }

            return Ok();
        }
    }
}
