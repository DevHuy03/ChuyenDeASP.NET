using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MacQuocHuy.Exercise02.Models;
using MacQuocHuy.Exercise02.Context;

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

        // GET: api/Cart_Item
        [HttpGet]
        public IActionResult GetCartItems()
        {
            var cartItems = _context.Card_Items.ToList();
            return Ok(cartItems);
        }

        // GET: api/CartItem/{id}
        [HttpGet("{id}")]
        public IActionResult GetCartItem(Guid id)
        {
            var cartItem = _context.Card_Items.FirstOrDefault(ci => ci.id == id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        // POST: api/CartItem
        [HttpPost]
        public IActionResult CreateCartItem([FromBody] Card_Item cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Card_Items.Add(cartItem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.id }, cartItem);
        }

        // PUT: api/CartItem/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCartItem(Guid id, [FromBody] Card_Item cartItem)
        {
            if (id != cartItem.id)
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
            var cartItem = _context.Card_Items.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.Card_Items.Remove(cartItem);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
