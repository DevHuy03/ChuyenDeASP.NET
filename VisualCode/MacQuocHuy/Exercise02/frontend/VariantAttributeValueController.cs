using Microsoft.AspNetCore.Mvc;
using Exercise02.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantAttributeValuesController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public VariantAttributeValuesController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/VariantAttributeValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VariantAttributeValue>>> GetVariantAttributeValues()
        {
            return await _context.VariantAttributeValues.ToListAsync();
        }

        // GET: api/VariantAttributeValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VariantAttributeValue>> GetVariantAttributeValue(int id)
        {
            var variantAttributeValue = await _context.VariantAttributeValues.FindAsync(id);

            if (variantAttributeValue == null)
            {
                return NotFound();
            }

            return variantAttributeValue;
        }

        // POST: api/VariantAttributeValues
        [HttpPost]
        public async Task<ActionResult<VariantAttributeValue>> PostVariantAttributeValue(VariantAttributeValue variantAttributeValue)
        {
            _context.VariantAttributeValues.Add(variantAttributeValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariantAttributeValue", new { id = variantAttributeValue.Id }, variantAttributeValue);
        }

        // DELETE: api/VariantAttributeValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariantAttributeValue(int id)
        {
            var variantAttributeValue = await _context.VariantAttributeValues.FindAsync(id);
            if (variantAttributeValue == null)
            {
                return NotFound();
            }

            _context.VariantAttributeValues.Remove(variantAttributeValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VariantAttributeValueExists(int id)
        {
            return _context.VariantAttributeValues.Any(e => e.Id == id);
        }
    }
}
