using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationTokensController : ControllerBase
    {
        public readonly Exercise01Context db;
        public VerificationTokensController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<VerificationTokensController>
        [HttpGet]
        public IEnumerable<VerificationToken> Get()
        {
            var verificationtokens = db.verification_tokens.Select(s => new VerificationToken
            {
                verification_token_id = s.verification_token_id,
                verif_token = s.verif_token,
                exprice_date = s.exprice_date,
                created_at = s.created_at,
                updated_at = s.updated_at,
                credential_id = s.credential_id,
                Credentials = db.credentials.Where(a => a.credential_id == s.credential_id).FirstOrDefault()
            }).ToList();
            return verificationtokens;
        }
        // GET api/<VerificationTokensController>/5
        [HttpGet("{id}")]
        public VerificationToken Get(int id)
        {
            var verificationtokens = db.verification_tokens.Select(s => new VerificationToken
            {
                verification_token_id = s.verification_token_id,
                verif_token = s.verif_token,
                exprice_date = s.exprice_date,
                created_at = s.created_at,
                updated_at = s.updated_at,
                credential_id = s.credential_id,
                Credentials = db.credentials.Where(a => a.credential_id == s.credential_id).FirstOrDefault()
            }).Where(a => a.verification_token_id == id).FirstOrDefault();
            return verificationtokens;
        }

        // POST api/<VerificationTokensController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormVerificationTokenView _veri)
        {
            var verificationtokens = new VerificationToken()
            {
                verif_token = _veri.verif_token,
                Credentials = db.credentials.Find(_veri.credential_id)
            };
            db.verification_tokens.Add(verificationtokens);
            await db.SaveChangesAsync();
            if (verificationtokens.verification_token_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<VerificationTokensController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormVerificationTokenView _veri)
        {
            var verificationtokens = db.verification_tokens.Find(id);
            verificationtokens.verif_token = _veri.verif_token;
            verificationtokens.Credentials = db.credentials.Find(_veri.credential_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<VerificationTokensController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var verificationtokens = db.verification_tokens.Find(id);
            db.verification_tokens.Remove(verificationtokens);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}