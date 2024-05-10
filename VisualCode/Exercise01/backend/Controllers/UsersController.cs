using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly Exercise01Context db;
        public UsersController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = db.users.Select(s => new User
            {
                user_id = s.user_id,
                first_name = s.first_name,
                last_name = s.last_name,
                image_url = s.image_url,
                email = s.email,
                phone = s.phone,
                created_at = s.created_at,
                updated_at = s.updated_at,
            }).ToList();
            return users;
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var users = db.users.Select(s => new User
            {
                user_id = s.user_id,
                first_name = s.first_name,
                last_name = s.last_name,
                image_url = s.image_url,
                email = s.email,
                phone = s.phone,
                created_at = s.created_at,
                updated_at = s.updated_at,
            }).Where(a => a.user_id == id).FirstOrDefault();
            return users;
        }

        // POST api/<UsersController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormUserView _user)
        {
            var users = new User()
            {
                first_name = _user.first_name,
                last_name = _user.last_name,
                image_url = _user.image_url,
                email = _user.email,
                phone = _user.phone,
            };
            db.users.Add(users);
            await db.SaveChangesAsync();
            if (users.user_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormUserView _user)
        {
            var users = db.users.Find(id);
            users.first_name = _user.first_name;
            users.last_name = _user.last_name;
            users.image_url = _user.image_url;
            users.email = _user.email;
            users.phone = _user.phone;
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var users = db.users.Find(id);
            db.users.Remove(users);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}