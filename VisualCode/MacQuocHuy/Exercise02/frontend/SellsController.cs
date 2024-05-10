using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellsController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public SellsController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Sells
        [HttpGet]
        public IActionResult GetSells()
        {
            var sells = _context.Sells.ToList();
            return Ok(sells);
        }

        // GET: api/Sells/{id}
        [HttpGet("{id}")]
        public IActionResult GetSell(Guid id)
        {
            var sell = _context.Sells.Find(id);
            if (sell == null)
            {
                return NotFound();
            }
            return Ok(sell);
        }

        // POST: api/Sells
        [HttpPost]
        public IActionResult CreateSell([FromBody] Sells sell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sells.Add(sell);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSell), new { id = sell.Id }, sell);
        }

        // PUT: api/Sells/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSell(Guid id, [FromBody] Sells sell)
        {
            if (id != sell.Id)
            {
                return BadRequest();
            }

            _context.Entry(sell).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Sells/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSell(Guid id)
        {
            var sell = _context.Sells.Find(id);
            if (sell == null)
            {
                return NotFound();
            }

            _context.Sells.Remove(sell);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
