using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.DTO
{
    public class UpdateUserDTO
    {

        public string Name { get; set; }
        public string LastName { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}