using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Properties.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Login { get; set; }


        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        public string Password { get; set; }
    }
}