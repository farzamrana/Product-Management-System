using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication56.Data;
using WebApplication56.Models;

namespace WebApplication56.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly BestStoreContext _context;

        public CategoriesController(BestStoreContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            category.CreatedAt = DateTime.UtcNow;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, category);
        }

        // POST: api/Categories/seed
        [HttpPost("seed")]
        public async Task<ActionResult> SeedCategories()
        {
            if (await _context.Categories.AnyAsync())
            {
                return BadRequest("Categories already seeded");
            }

            var categories = new List<Category>
            {
                new Category { Name = "Electronics", Description = "Electronic devices and accessories", CreatedAt = DateTime.UtcNow },
                new Category { Name = "Footwear", Description = "Shoes and boots", CreatedAt = DateTime.UtcNow },
                new Category { Name = "Accessories", Description = "Various accessories", CreatedAt = DateTime.UtcNow },
                new Category { Name = "Home", Description = "Home and kitchen items", CreatedAt = DateTime.UtcNow },
                new Category { Name = "Sports", Description = "Sports equipment and accessories", CreatedAt = DateTime.UtcNow }
            };

            _context.Categories.AddRange(categories);
            await _context.SaveChangesAsync();

            return Ok("Categories seeded successfully");
        }
    }
} 