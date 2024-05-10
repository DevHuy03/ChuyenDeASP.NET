using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public RoleController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Role
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _context.Roles.ToList();
            return Ok(roles);
        }

        // GET: api/Role/{id}
        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // POST: api/Role
        [HttpPost]
        public IActionResult CreateRole([FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Roles.Add(role);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }

        // PUT: api/Role/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, [FromBody] Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            _context.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Role/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
