using AptekaWebAPI.Entities;

namespace AptekaWebAPI.DTO
{
    public class CartDTO
    {
        public User User { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
