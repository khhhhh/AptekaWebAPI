﻿using System;
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
            if(type.Equals("login"))
            {
                return "/api/authentication/login";
            }
            else
            {
                return "/api/authentication/registration";
            }
        }

        public string Registrating(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
