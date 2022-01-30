using AptekaWebAPI.Entities;
using System.Collections.Generic;

namespace AptekaWebAPI.Properties.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}