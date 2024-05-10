using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public OrderItemsController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public IActionResult GetOrderItems()
        {
            var orderItems = _context.OrderItems.ToList();
            return Ok(orderItems);
        }

        // GET: api/OrderItems/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderItem(Guid id)
        {
            var orderItem = _context.OrderItems.FirstOrDefault(oi => oi.Id == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        // POST: api/OrderItems
        [HttpPost]
        public IActionResult CreateOrderItem([FromBody] OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrderItem), new { id = orderItem.Id }, orderItem);
        }

        // PUT: api/OrderItems/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOrderItem(Guid id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/OrderItems/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderItem(Guid id)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
