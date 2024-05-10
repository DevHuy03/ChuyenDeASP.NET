using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAccountController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public StaffAccountController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/StaffAccount
        [HttpGet]
        public IActionResult GetStaffAccounts()
        {
            var staffAccounts = _context.StaffAccounts.ToList();
            return Ok(staffAccounts);
        }

        // GET: api/StaffAccount/{id}
        [HttpGet("{id}")]
        public IActionResult GetStaffAccount(Guid id)
        {
            var staffAccount = _context.StaffAccounts.Find(id);
            if (staffAccount == null)
            {
                return NotFound();
            }
            return Ok(staffAccount);
        }

        // POST: api/StaffAccount
        [HttpPost]
        public IActionResult CreateStaffAccount([FromBody] StaffAccount staffAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaffAccounts.Add(staffAccount);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStaffAccount), new { id = staffAccount.Id }, staffAccount);
        }

        // PUT: api/StaffAccount/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStaffAccount(Guid id, [FromBody] StaffAccount staffAccount)
        {
            if (id != staffAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffAccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/StaffAccount/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStaffAccount(Guid id)
        {
            var staffAccount = _context.StaffAccounts.Find(id);
            if (staffAccount == null)
            {
                return NotFound();
            }

            _context.StaffAccounts.Remove(staffAccount);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
