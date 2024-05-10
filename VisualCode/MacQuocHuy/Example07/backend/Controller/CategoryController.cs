using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using a.Exercise02.Models;
using a.Exercise02.Context;

namespace a.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public CategoryController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = _context.Categories.Select(s => new Category
            {
                id = s.id,
                parent_id = s.parent_id,
                category_name = s.category_name,
                category_description = s.category_description,
                icon = s.icon,
                image = s.image,
                active = s.active,
                created_at = s.created_at,
                update_at = s.update_at,
                created_by = s.created_by,
                updated_by = s.updated_by
            }).ToList();
            return categories;
        }

        // GET: api/Categories/{id}
        [HttpGet("{id}")]
        public Category Get(Guid id)
        {
            return _context.Categories.Find(id);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormCategoryView category)
        {
            var cate = new Category()
            {
                parent_id = category.parent_id,
                category_name = category.category_name,
                category_description = category.category_description,
                icon = category.icon,
                image = category.image,
                imageplaceholder = category.imageplaceholder,
                active = category.active
            };
            _context.Categories.Add(cate);
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // PUT: api/Categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormCategoryView _category)
        {
            var category = _context.Categories.Find(id);
            category.parent_id = _category.parent_id;
            category.category_name = _category.category_name;
            category.category_description = _category.category_description;
            category.icon = _category.icon;
            category.image = _category.image;
            category.imageplaceholder = _category.imageplaceholder;
            category.active = _category.active;
            category.update_at = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // DELETE: api/Categories/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(1);
        }
    }
}
