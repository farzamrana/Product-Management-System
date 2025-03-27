using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication56.Data;
using WebApplication56.Models;

namespace WebApplication56.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly BestStoreContext _context;

        public BrandsController(BestStoreContext context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        // POST: api/Brands
        [HttpPost]
        public async Task<ActionResult<Brand>> CreateBrand(CreateBrandDto brandDto)
        {
            var brand = new Brand
            {
                Name = brandDto.Name,
                Description = brandDto.Description,
                Website = brandDto.Website,
                CreatedAt = DateTime.UtcNow
            };

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrands), new { id = brand.Id }, brand);
        }

        // POST: api/Brands/seed
        [HttpPost("seed")]
        public async Task<ActionResult> SeedBrands()
        {
            if (await _context.Brands.AnyAsync())
            {
                return BadRequest("Brands already seeded");
            }

            var brands = new List<Brand>
            {
                new Brand { Name = "Apple", Description = "Technology company", Website = "www.apple.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "Samsung", Description = "Electronics manufacturer", Website = "www.samsung.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "Nike", Description = "Sports apparel and equipment", Website = "www.nike.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "Fossil", Description = "Fashion accessories", Website = "www.fossil.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "ASUS", Description = "Computer hardware", Website = "www.asus.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "Fitbit", Description = "Fitness tracking devices", Website = "www.fitbit.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "Breville", Description = "Kitchen appliances", Website = "www.breville.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "Lululemon", Description = "Athletic apparel", Website = "www.lululemon.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "Sony", Description = "Electronics and entertainment", Website = "www.sony.com", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "The North Face", Description = "Outdoor clothing and equipment", Website = "www.thenorthface.com", CreatedAt = DateTime.UtcNow }
            };

            _context.Brands.AddRange(brands);
            await _context.SaveChangesAsync();

            return Ok("Brands seeded successfully");
        }
    }
} 