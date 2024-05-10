using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MacQuocHuy.Exercise02.Models;
using MacQuocHuy.Exercise02.Context;

namespace MacQuocHuy.Exercise02.Controllers
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

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            var tags = _context.Tags.Select(s => new Tag
            {
                id = s.id,
                tag_name = s.tag_name,
                icon = s.icon,
                created_at = s.created_at,
                updated_at = s.updated_at
            }).ToList();
            return tags;
        }

        // GET: api/Tags/{id}
        [HttpGet("{id}")]
        public Tag Get(Guid id)
        {
            return _context.Tags.Find(id);
        }
        
        // POST: api/Tags
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormTagView _tag)
        {
            var tags = new Tag()
            {
                tag_name = _tag.tag_name,
                icon = _tag.icon
            };
            _context.Tags.Add(tags);
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // PUT: api/Tags/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormTagView _tag)
        {
            var tags = _context.Tags.Find(id);
            tags.tag_name = _tag.tag_name;
            tags.icon = _tag.icon;
            tags.updated_at = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // DELETE: api/Tags/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(Guid id)
        {
            var tag = _context.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            _context.SaveChanges();

            return Ok(1);
        }
    }
}
