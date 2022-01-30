using System.ComponentModel.DataAnnotations;

namespace AptekaWebAPI.DTO
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }

    }
}
