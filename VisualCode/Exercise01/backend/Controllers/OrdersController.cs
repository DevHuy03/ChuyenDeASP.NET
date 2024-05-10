using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly Exercise01Context db;
        public OrdersController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var orders = db.orders.Select(s => new Order
            {
                order_id = s.order_id,
                order_desc = s.order_desc,
                order_fee = s.order_fee,
                order_date = s.order_date,
                created_at = s.created_at,
                updated_at = s.updated_at,
                cart_id = s.cart_id,
                Carts = db.carts.Where(a => a.cart_id == s.cart_id).FirstOrDefault()
            }).ToList();
            return orders;
        }
        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            var orders = db.orders.Select(s => new Order
            {
                order_id = s.order_id,
                order_desc = s.order_desc,
                order_fee = s.order_fee,
                order_date = s.order_date,
                created_at = s.created_at,
                updated_at = s.updated_at,
                cart_id = s.cart_id,
                Carts = db.carts.Where(a => a.cart_id == s.cart_id).FirstOrDefault()
            }).Where(a => a.order_id == id).FirstOrDefault();
            return orders;
        }

        // POST api/<OrdersController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormOrderView _order)
        {
            var orders = new Order()
            {
                order_desc = _order.order_desc,
                order_fee = _order.order_fee,
                Carts = db.carts.Find(_order.cart_id)
            };
            db.orders.Add(orders);
            await db.SaveChangesAsync();
            if (orders.order_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormOrderView _order)
        {
            var orders = db.orders.Find(id);
            orders.order_desc = _order.order_desc;
            orders.order_fee = _order.order_fee;
            orders.Carts = db.carts.Find(_order.cart_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var orders = db.orders.Find(id);
            db.orders.Remove(orders);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}