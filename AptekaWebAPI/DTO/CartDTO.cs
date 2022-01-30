using AptekaWebAPI.Entities;

namespace AptekaWebAPI.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
