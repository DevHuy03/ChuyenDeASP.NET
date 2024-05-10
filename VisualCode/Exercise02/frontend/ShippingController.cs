using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public ShippingController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Shipping
        [HttpGet]
        public IActionResult GetShippings()
        {
            var shippings = _context.Shippings.ToList();
            return Ok(shippings);
        }

        // GET: api/Shipping/{id}
        [HttpGet("{id}")]
        public IActionResult GetShipping(int id)
        {
            var shipping = _context.Shippings.Find(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return Ok(shipping);
        }

        // POST: api/Shipping
        [HttpPost]
        public IActionResult CreateShipping([FromBody] Shipping shipping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Shippings.Add(shipping);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetShipping), new { id = shipping.Id }, shipping);
        }

        // PUT: api/Shipping/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateShipping(int id, [FromBody] Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Shipping/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteShipping(int id)
        {
            var shipping = _context.Shippings.Find(id);
            if (shipping == null)
            {
                return NotFound();
            }

            _context.Shippings.Remove(shipping);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
