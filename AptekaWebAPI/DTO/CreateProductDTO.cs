using AptekaWebAPI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Properties.DTOs
{
    public class CreateProductDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<CreateCategoryDTO> Categories { get; set; }
    }
}