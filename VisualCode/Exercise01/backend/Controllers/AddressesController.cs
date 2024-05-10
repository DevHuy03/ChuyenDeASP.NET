using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        public readonly Exercise01Context db;
        public AddressesController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<AddressesController>
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            var addresses = db.addresses.Select(s => new Address
            {
                address_id = s.address_id,
                full_address = s.full_address,
                postal_code = s.postal_code,
                city = s.city,
                created_at = s.created_at,
                updated_at = s.updated_at,
                user_id = s.user_id,
                Users = db.users.Where(a => a.user_id == s.user_id).FirstOrDefault()
            }).ToList();
            return addresses;
        }
        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public Address Get(int id)
        {
            var addresses = db.addresses.Select(s => new Address
            {
                address_id = s.address_id,
                full_address = s.full_address,
                postal_code = s.postal_code,
                city = s.city,
                created_at = s.created_at,
                updated_at = s.updated_at,
                user_id = s.user_id,
                Users = db.users.Where(a => a.user_id == s.user_id).FirstOrDefault()
            }).Where(a => a.address_id == id).FirstOrDefault();
            return addresses;
        }

        // POST api/<AddressesController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormAddressView _address)
        {
            var addresses = new Address()
            {
                full_address = _address.full_address,
                postal_code = _address.postal_code,
                city = _address.city,
                Users = db.users.Find(_address.user_id)
            };
            db.addresses.Add(addresses);
            await db.SaveChangesAsync();
            if (addresses.address_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormAddressView _address)
        {
            var address = db.addresses.Find(id);
            address.full_address = _address.full_address;
            address.postal_code = _address.postal_code;
            address.city = _address.city;
            address.Users = db.users.Find(_address.user_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var address = db.addresses.Find(id);
            db.addresses.Remove(address);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}