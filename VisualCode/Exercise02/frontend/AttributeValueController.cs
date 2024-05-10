using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeValuesController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public AttributeValuesController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/AttributeValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeValue>>> GetAttributeValues()
        {
            return await _context.AttributeValues.ToListAsync();
        }

        // GET: api/AttributeValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeValue>> GetAttributeValue(int id)
        {
            var attributeValue = await _context.AttributeValues.FindAsync(id);

            if (attributeValue == null)
            {
                return NotFound();
            }

            return attributeValue;
        }

        // POST: api/AttributeValues
        [HttpPost]
        public async Task<ActionResult<AttributeValue>> PostAttributeValue(AttributeValue attributeValue)
        {
            _context.AttributeValues.Add(attributeValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttributeValue", new { id = attributeValue.Id }, attributeValue);
        }

        // PUT: api/AttributeValues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttributeValue(int id, AttributeValue attributeValue)
        {
            if (id != attributeValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(attributeValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeValueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/AttributeValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttributeValue(int id)
        {
            var attributeValue = await _context.AttributeValues.FindAsync(id);
            if (attributeValue == null)
            {
                return NotFound();
            }

            _context.AttributeValues.Remove(attributeValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttributeValueExists(int id)
        {
            return _context.AttributeValues.Any(e => e.Id == id);
        }
    }
}
