using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.DTO
{
    public class LoginUserDTO
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        public string Password { get; set; }
    }
}