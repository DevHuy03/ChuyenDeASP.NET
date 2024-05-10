using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffRoleController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public StaffRoleController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/StaffRole
        [HttpGet]
        public IActionResult GetStaffRoles()
        {
            var staffRoles = _context.StaffRoles.ToList();
            return Ok(staffRoles);
        }

        // GET: api/StaffRole/{id}
        [HttpGet("{id}")]
        public IActionResult GetStaffRole(Guid id)
        {
            var staffRole = _context.StaffRoles.Find(id);
            if (staffRole == null)
            {
                return NotFound();
            }
            return Ok(staffRole);
        }

        // POST: api/StaffRole
        [HttpPost]
        public IActionResult CreateStaffRole([FromBody] StaffRole staffRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaffRoles.Add(staffRole);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStaffRole), new { id = staffRole.Id }, staffRole);
        }

        // PUT: api/StaffRole/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStaffRole(Guid id, [FromBody] StaffRole staffRole)
        {
            if (id != staffRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffRole).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/StaffRole/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStaffRole(Guid id)
        {
            var staffRole = _context.StaffRoles.Find(id);
            if (staffRole == null)
            {
                return NotFound();
            }

            _context.StaffRoles.Remove(staffRole);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
