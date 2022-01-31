using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }   
        public string LastName { get; set; } 
        public Address Address { get; set; } 
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
    }
}
