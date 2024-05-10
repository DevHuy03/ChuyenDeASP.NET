using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductShippingController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public ProductShippingController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/ProductShipping
        [HttpGet]
        public IActionResult GetProductShippings()
        {
            var productShippings = _context.ProductShippings.ToList();
            return Ok(productShippings);
        }

        // GET: api/ProductShipping/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductShipping(Guid id)
        {
            var productShipping = _context.ProductShippings.Find(id);
            if (productShipping == null)
            {
                return NotFound();
            }
            return Ok(productShipping);
        }

        // POST: api/ProductShipping
        [HttpPost]
        public IActionResult CreateProductShipping([FromBody] ProductShipping productShipping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductShippings.Add(productShipping);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductShipping), new { id = productShipping.Id }, productShipping);
        }

        // PUT: api/ProductShipping/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProductShipping(Guid id, [FromBody] ProductShipping productShipping)
        {
            if (id != productShipping.Id)
            {
                return BadRequest();
            }

            _context.Entry(productShipping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ProductShipping/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProductShipping(Guid id)
        {
            var productShipping = _context.ProductShippings.Find(id);
            if (productShipping == null)
            {
                return NotFound();
            }

            _context.ProductShippings.Remove(productShipping);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
