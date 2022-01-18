using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
