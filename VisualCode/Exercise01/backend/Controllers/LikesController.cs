using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        public readonly Exercise01Context db;
        public LikesController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<LikesController>
        [HttpGet]
        public IEnumerable<Like> Get()
        {
            var likes = db.likes.Select(s => new Like
            {
                like_date = s.like_date,
                created_at = s.created_at,
                updated_at = s.updated_at,
                product_id = s.product_id,
                Products = db.products.Where(a => a.product_id == s.product_id).FirstOrDefault(),
                user_id = s.user_id,
                Users = db.users.Where(a => a.user_id == s.user_id).FirstOrDefault()
            }).ToList();
            return likes;
        }
        // GET api/<LikesController>/5
        [HttpGet("{id}")]
        public Like Get(int id)
        {
            var likes = db.likes.Select(s => new Like
            {
                like_date = s.like_date,
                created_at = s.created_at,
                updated_at = s.updated_at,
                product_id = s.product_id,
                Products = db.products.Where(a => a.product_id == s.product_id).FirstOrDefault(),
                user_id = s.user_id,
                Users = db.users.Where(a => a.user_id == s.user_id).FirstOrDefault()
            }).Where(a => a.user_id == id).FirstOrDefault();
            return likes;
        }

        // POST api/<LikesController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormLikeView _like)
        {
            var likes = new Like()
            {
                Products = db.products.Find(_like.product_id),
                Users = db.users.Find(_like.user_id)
            };
            db.likes.Add(likes);
            await db.SaveChangesAsync();
            if (likes.product_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<LikesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormLikeView _like)
        {
            var likes = db.likes.Find(id);
            likes.Products = db.products.Find(_like.product_id);
            likes.Users = db.users.Find(_like.user_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<LikesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var likes = db.likes.Find(id);
            db.likes.Remove(likes);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}