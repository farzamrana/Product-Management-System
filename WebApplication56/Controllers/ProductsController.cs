using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication56.Data;
using WebApplication56.Models;

namespace WebApplication56.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly BestStoreContext _context;

        public ProductsController(BestStoreContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductDto productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validate if Brand exists
                var brandExists = await _context.Brands.AnyAsync(b => b.Id == productDto.BrandId);
                if (!brandExists)
                {
                    return BadRequest($"Brand with ID {productDto.BrandId} does not exist");
                }

                // Validate if Category exists
                var categoryExists = await _context.Categories.AnyAsync(c => c.Id == productDto.CategoryId);
                if (!categoryExists)
                {
                    return BadRequest($"Category with ID {productDto.CategoryId} does not exist");
                }

                var product = new Product
                {
                    Name = productDto.Name,
                    BrandId = productDto.BrandId,
                    CategoryId = productDto.CategoryId,
                    Price = productDto.Price,
                    Description = productDto.Description,
                    ImageFileName = productDto.ImageFileName,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred while creating product: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating product: {ex.Message}");
            }
        }

        // POST: api/Products/seed
        [HttpPost("seed")]
        public async Task<ActionResult> SeedProducts()
        {
            if (await _context.Products.AnyAsync())
            {
                return BadRequest("Products already seeded");
            }

            // Get existing categories and brands
            var categories = await _context.Categories.ToListAsync();
            var brands = await _context.Brands.ToListAsync();

            if (!categories.Any())
            {
                return BadRequest("Please seed categories first by calling POST /api/Categories/seed");
            }

            if (!brands.Any())
            {
                return BadRequest("Please seed brands first by calling POST /api/Brands/seed");
            }

            var products = new List<Product>
            {
                new Product { 
                    Name = "iPhone 13", 
                    BrandId = brands.First(b => b.Name == "Apple").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 999.99m, 
                    Description = "Latest iPhone model", 
                    ImageFileName = "iphone13.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Samsung Galaxy S21", 
                    BrandId = brands.First(b => b.Name == "Samsung").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 899.99m, 
                    Description = "Android flagship", 
                    ImageFileName = "samsung-s21.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Nike Air Max", 
                    BrandId = brands.First(b => b.Name == "Nike").Id,
                    CategoryId = categories.First(c => c.Name == "Footwear").Id,
                    Price = 129.99m, 
                    Description = "Classic running shoes", 
                    ImageFileName = "nike-airmax.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Leather Wallet", 
                    BrandId = brands.First(b => b.Name == "Fossil").Id,
                    CategoryId = categories.First(c => c.Name == "Accessories").Id,
                    Price = 49.99m, 
                    Description = "Genuine leather wallet", 
                    ImageFileName = "fossil-wallet.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Gaming Laptop", 
                    BrandId = brands.First(b => b.Name == "ASUS").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 1499.99m, 
                    Description = "High-performance gaming laptop", 
                    ImageFileName = "asus-laptop.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Smart Watch", 
                    BrandId = brands.First(b => b.Name == "Fitbit").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 199.99m, 
                    Description = "Fitness tracking smartwatch", 
                    ImageFileName = "fitbit-watch.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Coffee Maker", 
                    BrandId = brands.First(b => b.Name == "Breville").Id,
                    CategoryId = categories.First(c => c.Name == "Home").Id,
                    Price = 79.99m, 
                    Description = "Automatic coffee maker", 
                    ImageFileName = "breville-coffee.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Yoga Mat", 
                    BrandId = brands.First(b => b.Name == "Lululemon").Id,
                    CategoryId = categories.First(c => c.Name == "Sports").Id,
                    Price = 39.99m, 
                    Description = "Premium yoga mat", 
                    ImageFileName = "lululemon-mat.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Wireless Headphones", 
                    BrandId = brands.First(b => b.Name == "Sony").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 299.99m, 
                    Description = "Noise-cancelling headphones", 
                    ImageFileName = "sony-headphones.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Backpack", 
                    BrandId = brands.First(b => b.Name == "The North Face").Id,
                    CategoryId = categories.First(c => c.Name == "Accessories").Id,
                    Price = 89.99m, 
                    Description = "Water-resistant backpack", 
                    ImageFileName = "northface-backpack.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Digital Camera", 
                    BrandId = brands.First(b => b.Name == "Canon").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 799.99m, 
                    Description = "Mirrorless camera", 
                    ImageFileName = "canon-camera.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Running Shoes", 
                    BrandId = brands.First(b => b.Name == "Adidas").Id,
                    CategoryId = categories.First(c => c.Name == "Footwear").Id,
                    Price = 119.99m, 
                    Description = "Professional running shoes", 
                    ImageFileName = "adidas-shoes.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Smart TV", 
                    BrandId = brands.First(b => b.Name == "LG").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 699.99m, 
                    Description = "4K Smart TV", 
                    ImageFileName = "lg-tv.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Blender", 
                    BrandId = brands.First(b => b.Name == "Vitamix").Id,
                    CategoryId = categories.First(c => c.Name == "Home").Id,
                    Price = 449.99m, 
                    Description = "High-performance blender", 
                    ImageFileName = "vitamix-blender.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Gaming Console", 
                    BrandId = brands.First(b => b.Name == "Sony").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 499.99m, 
                    Description = "Latest gaming console", 
                    ImageFileName = "ps5.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Sunglasses", 
                    BrandId = brands.First(b => b.Name == "Ray-Ban").Id,
                    CategoryId = categories.First(c => c.Name == "Accessories").Id,
                    Price = 159.99m, 
                    Description = "Classic aviator sunglasses", 
                    ImageFileName = "rayban-sunglasses.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Dumbbell Set", 
                    BrandId = brands.First(b => b.Name == "Bowflex").Id,
                    CategoryId = categories.First(c => c.Name == "Sports").Id,
                    Price = 299.99m, 
                    Description = "Adjustable dumbbell set", 
                    ImageFileName = "bowflex-dumbbells.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Air Fryer", 
                    BrandId = brands.First(b => b.Name == "Ninja").Id,
                    CategoryId = categories.First(c => c.Name == "Home").Id,
                    Price = 129.99m, 
                    Description = "Digital air fryer", 
                    ImageFileName = "ninja-airfryer.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Smart Doorbell", 
                    BrandId = brands.First(b => b.Name == "Ring").Id,
                    CategoryId = categories.First(c => c.Name == "Home").Id,
                    Price = 199.99m, 
                    Description = "Video doorbell", 
                    ImageFileName = "ring-doorbell.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product { 
                    Name = "Wireless Mouse", 
                    BrandId = brands.First(b => b.Name == "Logitech").Id,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id,
                    Price = 29.99m, 
                    Description = "Ergonomic wireless mouse", 
                    ImageFileName = "logitech-mouse.jpg",
                    CreatedAt = DateTime.UtcNow
                }
            };

            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();

            return Ok("Products seeded successfully");
        }

        // GET: api/Products/report
        [HttpGet("report")]
        public async Task<ActionResult<object>> GetProductReport(
            [FromQuery] int? brandId = null,
            [FromQuery] int? categoryId = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var query = _context.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .AsQueryable();

                // Apply filters
                if (brandId.HasValue)
                {
                    query = query.Where(p => p.BrandId == brandId.Value);
                }

                if (categoryId.HasValue)
                {
                    query = query.Where(p => p.CategoryId == categoryId.Value);
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(p => p.Price >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(p => p.Price <= maxPrice.Value);
                }

                if (startDate.HasValue)
                {
                    query = query.Where(p => p.CreatedAt >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(p => p.CreatedAt <= endDate.Value);
                }

                var products = await query.ToListAsync();

                // Calculate report statistics
                var report = new
                {
                    TotalProducts = products.Count,
                    AveragePrice = products.Any() ? products.Average(p => p.Price) : 0,
                    TotalValue = products.Sum(p => p.Price),
                    ProductsByBrand = products
                        .GroupBy(p => p.Brand.Name)
                        .Select(g => new
                        {
                            BrandName = g.Key,
                            Count = g.Count(),
                            TotalValue = g.Sum(p => p.Price)
                        }),
                    ProductsByCategory = products
                        .GroupBy(p => p.Category.Name)
                        .Select(g => new
                        {
                            CategoryName = g.Key,
                            Count = g.Count(),
                            TotalValue = g.Sum(p => p.Price)
                        }),
                    PriceRange = new
                    {
                        Min = products.Any() ? products.Min(p => p.Price) : 0,
                        Max = products.Any() ? products.Max(p => p.Price) : 0
                    },
                    Products = products.Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Price,
                        p.Description,
                        p.ImageFileName,
                        p.CreatedAt,
                        BrandName = p.Brand.Name,
                        CategoryName = p.Category.Name
                    })
                };

                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while generating the report: {ex.Message}");
            }
        }
    }
} 