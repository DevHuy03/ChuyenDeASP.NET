using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MacQuocHuy.Exercise02.Models;
using MacQuocHuy.Exercise02.Context;

namespace MacQuocHuy.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_TagController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_TagController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Tags
        [HttpGet]
        public IEnumerable<Product_Tag> Get()
        {
            var product_tag = _context.Product_Tags.Select(s => new Product_Tag
            {
                id = s.id,
                tag_id = s.tag_id,
                product_id = s.product_id
            }).ToList();
            return product_tag;
        }

        // GET: api/Product_Tags/{id}
        [HttpGet("{id}")]
        public Product_Tag Get(Guid id)
        {
            return _context.Product_Tags.Find(id);
        }

        // POST: api/Product_Tags
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormProductTagView _product_tag)
        {
            var product_tag = new Product_Tag()
            {
                Tags = _context.Tags.Find(_product_tag.tag_id),
                Products = _context.Products.Find(_product_tag.product_id)
            };
            _context.Product_Tags.Add(product_tag);
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // PUT: api/Product_Tags/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormProductTagView _product_tag)
        {
            var product_tags = _context.Product_Tags.Find(id);
            product_tags.Tags = _context.Tags.Find(_product_tag.tag_id);
            product_tags.Products = _context.Products.Find(_product_tag.product_id);
            await _context.SaveChangesAsync();
            return Ok(1);
        }
        
        // DELETE: api/Product_Tags/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct_Tag(Guid id)
        {
            var product_tags = _context.Product_Tags.Find(id);
            if (product_tags == null)
            {
                return NotFound();
            }

            _context.Product_Tags.Remove(product_tags);
            _context.SaveChanges();

            return Ok(1);
        }
    }
}
