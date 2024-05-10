using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public CustomerAddressesController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/CustomerAddresses
        [HttpGet]
        public IActionResult GetCustomerAddresses()
        {
            var customerAddresses = _context.CustomerAddresses.ToList();
            return Ok(customerAddresses);
        }

        // GET: api/CustomerAddresses/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomerAddress(Guid id)
        {
            var customerAddress = _context.CustomerAddresses.FirstOrDefault(ca => ca.Id == id);
            if (customerAddress == null)
            {
                return NotFound();
            }
            return Ok(customerAddress);
        }

        // POST: api/CustomerAddresses
        [HttpPost]
        public IActionResult CreateCustomerAddress([FromBody] CustomerAddress customerAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomerAddresses.Add(customerAddress);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCustomerAddress), new { id = customerAddress.Id }, customerAddress);
        }

        // PUT: api/CustomerAddresses/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomerAddress(Guid id, [FromBody] CustomerAddress customerAddress)
        {
            if (id != customerAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerAddress).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/CustomerAddresses/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerAddress(Guid id)
        {
            var customerAddress = _context.CustomerAddresses.Find(id);
            if (customerAddress == null)
            {
                return NotFound();
            }

            _context.CustomerAddresses.Remove(customerAddress);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
