using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public TagController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Tag
        [HttpGet]
        public IActionResult GetTags()
        {
            var tags = _context.Tags.ToList();
            return Ok(tags);
        }

        // GET: api/Tag/{id}
        [HttpGet("{id}")]
        public IActionResult GetTag(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        // POST: api/Tag
        [HttpPost]
        public IActionResult CreateTag([FromBody] Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tags.Add(tag);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
        }

        // PUT: api/Tag/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTag(int id, [FromBody] Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            _context.Entry(tag).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Tag/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
