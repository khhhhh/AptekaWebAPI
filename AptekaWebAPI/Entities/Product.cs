using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public int Count { get; set; }
        public int ProductPrice { get; set; }
        public string Image { get; set; }
    }
}
