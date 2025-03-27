using System.ComponentModel.DataAnnotations;

namespace WebApplication56.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
} 