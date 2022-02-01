using System.ComponentModel.DataAnnotations;

namespace AptekaWebAPI.DTO
{
    public class CreateAddressDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; } 
    }
}
