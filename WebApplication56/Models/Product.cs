using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication56.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "decimal(16,2)")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageFileName { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
} 