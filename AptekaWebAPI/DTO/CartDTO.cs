using AptekaWebAPI.Entities;

namespace AptekaWebAPI.DTO
{
    public class CartDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public int Count { get; set; }
    }
}
