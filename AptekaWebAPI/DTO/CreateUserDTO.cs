using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Properties.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        public string Password { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}