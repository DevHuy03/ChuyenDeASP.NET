using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using a.Exercise02.Models;
using a.Exercise02.Context;

namespace a.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_CategoryController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_CategoryController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Category
        [HttpGet]
        public IEnumerable<Product_Category> Get()
        {
            var product_category = _context.Product_Categories.Select(s => new Product_Category
            {
                id = s.id,
                product_id = s.product_id,
                category_id = s.category_id
            }).ToList();
            return product_category;
        }

        // GET: api/Product_Categories/{id}
        [HttpGet("{id}")]
        public Product_Category Get(Guid id)
        {
            return _context.Product_Categories.Find(id);
        }

        // POST: api/Product_Categories
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormProductCategoryView _product_category)
        {
            var product_category = new Product_Category()
            {
                Products = _context.Products.Find(_product_category.product_id),
                Categories = _context.Categories.Find(_product_category.category_id)
            };
            _context.Product_Categories.Add(product_category);
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // PUT: api/Product_Categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormProductCategoryView _product_category)
        {
            var product_categories = _context.Product_Categories.Find(id);
            product_categories.Products = _context.Products.Find(_product_category.product_id);
            product_categories.Categories = _context.Categories.Find(_product_category.category_id);
            await _context.SaveChangesAsync();
            return Ok(1);
        }
        
        // DELETE: api/Product_Categories/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct_Category(Guid id)
        {
            var product_categoies = _context.Product_Categories.Find(id);
            if (product_categoies == null)
            {
                return NotFound();
            }

            _context.Product_Categories.Remove(product_categoies);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
