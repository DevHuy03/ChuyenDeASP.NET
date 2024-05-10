using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTagController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public ProductTagController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/ProductTag
        [HttpGet]
        public IActionResult GetProductTags()
        {
            var productTags = _context.ProductTags.ToList();
            return Ok(productTags);
        }

        // GET: api/ProductTag/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductTag(Guid id)
        {
            var productTag = _context.ProductTags.Find(id);
            if (productTag == null)
            {
                return NotFound();
            }
            return Ok(productTag);
        }

        // POST: api/ProductTag
        [HttpPost]
        public IActionResult CreateProductTag([FromBody] ProductTag productTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductTags.Add(productTag);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductTag), new { id = productTag.Id }, productTag);
        }

        // PUT: api/ProductTag/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProductTag(Guid id, [FromBody] ProductTag productTag)
        {
            if (id != productTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(productTag).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ProductTag/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProductTag(Guid id)
        {
            var productTag = _context.ProductTags.Find(id);
            if (productTag == null)
            {
                return NotFound();
            }

            _context.ProductTags.Remove(productTag);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
