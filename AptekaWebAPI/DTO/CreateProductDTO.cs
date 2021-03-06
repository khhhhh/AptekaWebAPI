using AptekaWebAPI.DTO;
using AptekaWebAPI.Entities;
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
        [MaxLength(600)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int Count { get; set; }

        public List<ProductCategory> Categories { get; set; }
    }
}