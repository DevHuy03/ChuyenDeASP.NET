using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public VariantController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Variant
        [HttpGet]
        public IActionResult GetVariants()
        {
            var variants = _context.Variants.ToList();
            return Ok(variants);
        }

        // GET: api/Variant/{id}
        [HttpGet("{id}")]
        public IActionResult GetVariant(Guid id)
        {
            var variant = _context.Variants.Find(id);
            if (variant == null)
            {
                return NotFound();
            }
            return Ok(variant);
        }

        // POST: api/Variant
        [HttpPost]
        public IActionResult CreateVariant([FromBody] Variant variant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Variants.Add(variant);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetVariant), new { id = variant.Id }, variant);
        }

        // PUT: api/Variant/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateVariant(Guid id, [FromBody] Variant variant)
        {
            if (id != variant.Id)
            {
                return BadRequest();
            }

            _context.Entry(variant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Variant/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteVariant(Guid id)
        {
            var variant = _context.Variants.Find(id);
            if (variant == null)
            {
                return NotFound();
            }

            _context.Variants.Remove(variant);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
