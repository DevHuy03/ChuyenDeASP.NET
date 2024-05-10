using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public OrderStatusController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/OrderStatus
        [HttpGet]
        public IActionResult GetOrderStatuses()
        {
            var orderStatuses = _context.OrderStatuses.ToList();
            return Ok(orderStatuses);
        }

        // GET: api/OrderStatus/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderStatus(int id)
        {
            var orderStatus = _context.OrderStatuses.FirstOrDefault(os => os.Id == id);
            if (orderStatus == null)
            {
                return NotFound();
            }
            return Ok(orderStatus);
        }

        // POST: api/OrderStatus
        [HttpPost]
        public IActionResult CreateOrderStatus([FromBody] OrderStatus orderStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderStatuses.Add(orderStatus);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrderStatus), new { id = orderStatus.Id }, orderStatus);
        }

        // PUT: api/OrderStatus/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOrderStatus(int id, [FromBody] OrderStatus orderStatus)
        {
            if (id != orderStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderStatus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/OrderStatus/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderStatus(int id)
        {
            var orderStatus = _context.OrderStatuses.Find(id);
            if (orderStatus == null)
            {
                return NotFound();
            }

            _context.OrderStatuses.Remove(orderStatus);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
