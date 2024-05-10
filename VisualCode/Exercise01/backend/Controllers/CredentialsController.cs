using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        public readonly Exercise01Context db;
        public CredentialsController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<CredentialsController>
        [HttpGet]
        public IEnumerable<Credential> Get()
        {
            var credentials = db.credentials.Select(s => new Credential
            {
                credential_id = s.credential_id,
                username = s.username,
                password = s.password,
                role = s.role,
                is_enabled = s.is_enabled,
                is_account_non_expired = s.is_account_non_expired,
                user_id = s.user_id,
                Users = db.users.Where(a => a.user_id == s.user_id).FirstOrDefault()
            }).ToList();
            return credentials;
        }
        // GET api/<CredentialsController>/5
        [HttpGet("{id}")]
        public Credential Get(int id)
        {
            var credentials = db.credentials.Select(s => new Credential
            {
                credential_id = s.credential_id,
                username = s.username,
                password = s.password,
                role = s.role,
                is_enabled = s.is_enabled,
                is_account_non_expired = s.is_account_non_expired,
                user_id = s.user_id,
                Users = db.users.Where(a => a.user_id == s.user_id).FirstOrDefault()
            }).Where(a => a.credential_id == id).FirstOrDefault();
            return credentials;
        }

        // POST api/<CredentialsController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormCredentiaView _cre)
        {
            var credentials = new Credential()
            {
                username = _cre.username,
                password = _cre.password,
                role = _cre.role,
                is_enabled = _cre.is_enabled,
                is_account_non_expired = _cre.is_account_non_expired,
                is_account_non_locked = _cre.is_account_non_locked,
                is_credentials_non_expired = _cre.is_credentials_non_expired,
                Users = db.users.Find(_cre.user_id)
            };
            db.credentials.Add(credentials);
            await db.SaveChangesAsync();
            if (credentials.credential_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<CredentialsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormCredentiaView _cre)
        {
            var credentials = db.credentials.Find(id);
            credentials.username = _cre.username;
            credentials.password = _cre.password;
            credentials.role = _cre.role;
            credentials.is_enabled = _cre.is_enabled;
            credentials.is_account_non_expired = _cre.is_account_non_expired;
            credentials.is_account_non_locked = _cre.is_account_non_locked;
            credentials.is_account_non_expired = _cre.is_account_non_expired;
            credentials.Users = db.users.Find(_cre.user_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<CredentialsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var credentials = db.credentials.Find(id);
            db.credentials.Remove(credentials);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}