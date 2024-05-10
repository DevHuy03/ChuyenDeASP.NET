using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideshowController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public SlideshowController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Slideshow
        [HttpGet]
        public IActionResult GetSlideshows()
        {
            var slideshows = _context.Slideshows.ToList();
            return Ok(slideshows);
        }

        // GET: api/Slideshow/{id}
        [HttpGet("{id}")]
        public IActionResult GetSlideshow(Guid id)
        {
            var slideshow = _context.Slideshows.Find(id);
            if (slideshow == null)
            {
                return NotFound();
            }
            return Ok(slideshow);
        }

        // POST: api/Slideshow
        [HttpPost]
        public IActionResult CreateSlideshow([FromBody] Slideshow slideshow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Slideshows.Add(slideshow);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSlideshow), new { id = slideshow.Id }, slideshow);
        }

        // PUT: api/Slideshow/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSlideshow(Guid id, [FromBody] Slideshow slideshow)
        {
            if (id != slideshow.Id)
            {
                return BadRequest();
            }

            _context.Entry(slideshow).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Slideshow/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSlideshow(Guid id)
        {
            var slideshow = _context.Slideshows.Find(id);
            if (slideshow == null)
            {
                return NotFound();
            }

            _context.Slideshows.Remove(slideshow);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
