using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MacQuocHuy.Exercise02.Models;
using MacQuocHuy.Exercise02.Context;

namespace MacQuocHuy.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public GalleryController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Gallery
        [HttpGet]
        public IActionResult GetGallery()
        {
            var gallery = _context.Galleries.ToList();
            return Ok(gallery);
        }

        // GET: api/Gallery/{id}
        [HttpGet("{id}")]
        public IActionResult GetGallery(Guid id)
        {
            var gallery = _context.Galleries.Find(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return Ok(gallery);
        }

        // POST: api/Gallery
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormGalleryView _gallery)
        {
            var gallery = new Gallery()
            {
                Products = _context.Products.Find(_gallery.product_id),
                image = _gallery.image,
                placeholder = _gallery.placeholder,
                is_thumbnail = _gallery.is_thumbnail
            };
            _context.Galleries.Add(gallery);
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // PUT: api/Gallery/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormGalleryView _gallery)
        {
            var gallery = _context.Galleries.Find(id);
            gallery.Products = _context.Products.Find(_gallery.product_id);
            gallery.image = _gallery.image;
            gallery.placeholder = _gallery.placeholder;
            gallery.is_thumbnail = _gallery.is_thumbnail;
            gallery.updated_at = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // DELETE: api/Gallery/{id}
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

            return Ok(1);
        }


    }
}
