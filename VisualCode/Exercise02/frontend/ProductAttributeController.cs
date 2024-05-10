using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public ProductAttributeController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/ProductAttribute
        [HttpGet]
        public IActionResult GetProductAttributes()
        {
            var productAttributes = _context.ProductAttributes.ToList();
            return Ok(productAttributes);
        }

        // GET: api/ProductAttribute/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductAttribute(Guid id)
        {
            var productAttribute = _context.ProductAttributes.FirstOrDefault(pa => pa.Id == id);
            if (productAttribute == null)
            {
                return NotFound();
            }
            return Ok(productAttribute);
        }

        // POST: api/ProductAttribute
        [HttpPost]
        public IActionResult CreateProductAttribute([FromBody] ProductAttribute productAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductAttributes.Add(productAttribute);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductAttribute), new { id = productAttribute.Id }, productAttribute);
        }

        // PUT: api/ProductAttribute/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProductAttribute(Guid id, [FromBody] ProductAttribute productAttribute)
        {
            if (id != productAttribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(productAttribute).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ProductAttribute/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProductAttribute(Guid id)
        {
            var productAttribute = _context.ProductAttributes.Find(id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            _context.ProductAttributes.Remove(productAttribute);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
