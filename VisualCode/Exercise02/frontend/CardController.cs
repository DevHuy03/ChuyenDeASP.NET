using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;


namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public CartController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet]
        public IActionResult GetCarts()
        {
            var carts = _context.Cards.ToList();
            return Ok(carts);
        }

        // GET: api/Cart/{cart_id}
        [HttpGet("{cart_id}")]
        public IActionResult GetCart(Guid cart_id)
        {
            var cart = _context.Cards.FirstOrDefault(c => c.cart_id == cart_id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        // POST: api/Cart
        [HttpPost]
        public IActionResult CreateCart([FromBody] Card cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cards.Add(cart);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCart), new { cart_id = cart.cart_id }, cart);
        }

        // PUT: api/Cart/{cart_id}
        [HttpPut("{cart_id}")]
        public IActionResult UpdateCart(Guid cart_id, [FromBody] Card cart)
        {
            if (cart_id != cart.cart_id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Cart/{cart_id}
        [HttpDelete("{cart_id}")]
        public IActionResult DeleteCart(Guid cart_id)
        {
            var cart = _context.Cards.Find(cart_id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(cart);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
