using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services.Models
{
    public class AuthenticationService : IAutrhenticationService
    {
        public string Logining(string login, string password)
        {
            throw new NotImplementedException();
        }

        public string OperationType(string type)
        {
            if(!string.IsNullOrEmpty(type) && type.Equals("login"))
            {
                return "/api/authentication/login";
            }
            else if(!string.IsNullOrEmpty(type))
            {
                return "/api/authentication/registration";
            }
            else
            {
                return "Online Pharmacy\n";
            }
        }

        public string Registrating(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
