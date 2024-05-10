using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public ProductCategoryController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/ProductCategory
        [HttpGet]
        public IActionResult GetProductCategories()
        {
            var productCategories = _context.ProductCategories.ToList();
            return Ok(productCategories);
        }

        // GET: api/ProductCategory/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductCategory(Guid id)
        {
            var productCategory = _context.ProductCategories.FirstOrDefault(pc => pc.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return Ok(productCategory);
        }

        // POST: api/ProductCategory
        [HttpPost]
        public IActionResult CreateProductCategory([FromBody] ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.Id }, productCategory);
        }

        // PUT: api/ProductCategory/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProductCategory(Guid id, [FromBody] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(productCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ProductCategory/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProductCategory(Guid id)
        {
            var productCategory = _context.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
