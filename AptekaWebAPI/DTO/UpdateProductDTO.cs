using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Properties.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}