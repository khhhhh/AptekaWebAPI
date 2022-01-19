using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services
{
    public interface IAutrhenticationService
    {
        public string Registrating(string login, string password);

        public string Logining(string login, string password);
    }
}
