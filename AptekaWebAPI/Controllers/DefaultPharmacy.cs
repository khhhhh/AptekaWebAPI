using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Controllers
{
    abstract public class DefaultPharmacy
    {
        public abstract ActionResult GetAll();

        public abstract ActionResult GetById([FromRoute] int id);

        public abstract ActionResult GetByName([FromRoute] string name);

    }
}
