using System.ComponentModel.DataAnnotations;

namespace WebApplication56.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Website { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }

    public class CreateBrandDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Website { get; set; }
        public string Social { get; set; }
    }
} 