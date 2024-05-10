using Microsoft.AspNetCore.Mvc;
using Example06.Models;
using Example06.Context;
namespace Example06.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ProductContext db;
        public CategoriesController (ProductContext db)
        {
            this.db = db;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return db.Categories.ToList() ;
        }
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
            {
                return db.Categories.Find(id);
            }

    // POST api/<ProductsController> 
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FormCategoryView category)
    {
        var cate = new Category()
        {
            Name = category.Name,
            SlugCategory = category.SlugCategory
        };
        db. Categories.Add(cate);
        await db.SaveChangesAsync();
        if (cate.idCategory > 0)
        {
            return Ok(1);
        }
        return Ok(0);
    }
        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}