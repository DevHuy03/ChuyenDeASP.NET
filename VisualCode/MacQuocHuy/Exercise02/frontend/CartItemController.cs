using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public CartItemController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/CartItem
        [HttpGet]
        public IActionResult GetCartItems()
        {
            var cartItems = _context.CartItems.ToList();
            return Ok(cartItems);
        }

        // GET: api/CartItem/{id}
        [HttpGet("{id}")]
        public IActionResult GetCartItem(Guid id)
        {
            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.Id == id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        // POST: api/CartItem
        [HttpPost]
        public IActionResult CreateCartItem([FromBody] CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.Id }, cartItem);
        }

        // PUT: api/CartItem/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCartItem(Guid id, [FromBody] CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/CartItem/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(Guid id)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
