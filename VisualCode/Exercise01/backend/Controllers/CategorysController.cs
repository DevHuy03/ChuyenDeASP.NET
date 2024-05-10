using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly Exercise01Context db;
        public CategoriesController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return db.categories.ToList();
        }
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return db.categories.Find(id);
        }

        // POST api/<ProductsController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormCategoryView category)
        {
            var cate = new Category()
            {
                category_title = category.category_title,
                image_url = category.image_url
            };
            db.categories.Add(cate);
            await db.SaveChangesAsync();
            if (cate.category_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormCategoryView _user)
        {
            var category = db.categories.Find(id);
            category.category_title = _user.category_title;
            category.image_url = _user.image_url;

            await db.SaveChangesAsync();
            return Ok(1);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = db.categories.Find(id);
            db.categories.Remove(category);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}