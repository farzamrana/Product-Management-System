using System.ComponentModel.DataAnnotations;

namespace WebApplication56.Models
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageFileName { get; set; }
    }
}