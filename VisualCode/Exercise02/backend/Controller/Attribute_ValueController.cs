using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MacQuocHuy.Exercise02.Models;
using MacQuocHuy.Exercise02.Context;

namespace MacQuocHuy.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Attribute_ValuesController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Attribute_ValuesController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Attribute_Values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attribute_Value>>> GetAttribute_Values()
        {
            return await _context.Attribute_Values.ToListAsync();
        }

        // GET: api/Attribute_Values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attribute_Value>> GetAttribute_Value(int id)
        {
            var Attribute_Value = await _context.Attribute_Values.FindAsync(id);

            if (Attribute_Value == null)
            {
                return NotFound();
            }

            return Attribute_Value;
        }

        // POST: api/Attribute_Values
        [HttpPost]
        public async Task<ActionResult<Attribute_Value>> PostAttribute_Value(Attribute_Value Attribute_Value)
        {
            _context.Attribute_Values.Add(Attribute_Value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttribute_Value", new { id = Attribute_Value.id }, Attribute_Value);
        }

        // PUT: api/Attribute_Values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute_Value(Guid id, Attribute_Value Attribute_Value)
        {
            if (id != Attribute_Value.id)
            {
                return BadRequest();
            }

            _context.Entry(Attribute_Value).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Attribute_ValueExists(id))
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

        // DELETE: api/Attribute_Values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute_Value(Guid id)
        {
            var Attribute_Value = await _context.Attribute_Values.FindAsync(id);
            if (Attribute_Value == null)
            {
                return NotFound();
            }

            _context.Attribute_Values.Remove(Attribute_Value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Attribute_ValueExists(Guid id)
        {
            return _context.Attribute_Values.Any(e => e.id == id);
        }
    }
}
