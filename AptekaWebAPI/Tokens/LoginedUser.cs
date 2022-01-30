using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Tokens
{
    public class LoginedUser
    {
        public LoginedUser()
        {

        }
        public int Id { get; set; }

        public string Token { get; set; }
    }
}
