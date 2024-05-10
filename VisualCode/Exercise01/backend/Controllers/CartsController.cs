using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        public readonly Exercise01Context db;
        public CartsController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<CartsController>
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            var carts = db.carts.Select(s => new Cart
            {
                cart_id = s.cart_id,
                created_at = s.created_at,
                updated_at = s.updated_at,
                user_id = s.user_id,
                Users = db.users.Where(a => a.user_id == s.user_id).FirstOrDefault()
            }).ToList();
            return carts;
        }
        // GET api/<CartsController>/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            var carts = db.carts.Select(s => new Cart
            {
                cart_id = s.cart_id,
                created_at = s.created_at,
                updated_at = s.updated_at,
                user_id = s.user_id,
                Users = db.users.Where(a => a.user_id == s.user_id).FirstOrDefault()
            }).Where(a => a.cart_id == id).FirstOrDefault();
            return carts;
        }

        // POST api/<CartsController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormCartView _cart)
        {
            var carts = new Cart()
            {
                Users = db.users.Find(_cart.user_id)
            };
            db.carts.Add(carts);
            await db.SaveChangesAsync();
            if (carts.cart_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<CartsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormCartView _user)
        {
            var carts = db.carts.Find(id);
            carts.Users = db.users.Find(_user.user_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<CartsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carts = db.carts.Find(id);
            db.carts.Remove(carts);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}