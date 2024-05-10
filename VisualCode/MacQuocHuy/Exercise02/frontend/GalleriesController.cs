using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public GalleriesController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Galleries
        [HttpGet]
        public IActionResult GetGalleries()
        {
            var galleries = _context.Galleries.ToList();
            return Ok(galleries);
        }

        // GET: api/Galleries/{id}
        [HttpGet("{id}")]
        public IActionResult GetGallery(Guid id)
        {
            var gallery = _context.Galleries.FirstOrDefault(g => g.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }
            return Ok(gallery);
        }

        // POST: api/Galleries
        [HttpPost]
        public IActionResult CreateGallery([FromBody] Galleries gallery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Galleries.Add(gallery);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetGallery), new { id = gallery.Id }, gallery);
        }

        // PUT: api/Galleries/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateGallery(Guid id, [FromBody] Galleries gallery)
        {
            if (id != gallery.Id)
            {
                return BadRequest();
            }

            _context.Entry(gallery).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Galleries/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteGallery(Guid id)
        {
            var gallery = _context.Galleries.Find(id);
            if (gallery == null)
            {
                return NotFound();
            }

            _context.Galleries.Remove(gallery);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
