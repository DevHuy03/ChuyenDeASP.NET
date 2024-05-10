using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        public readonly Exercise01Context db;
        public OrderItemsController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<OrderItemsController>
        [HttpGet]
        public IEnumerable<OrderItem> Get()
        {
            var orderitems = db.order_items.Select(s => new OrderItem
            {
                ordered_quantity = s.ordered_quantity,
                created_at = s.created_at,
                updated_at = s.updated_at,
                product_id = s.product_id,
                Products = db.products.Where(a => a.product_id == s.product_id).FirstOrDefault(),
                order_id = s.order_id,
                Orders = db.orders.Where(a => a.order_id == s.order_id).FirstOrDefault()
            }).ToList();
            return orderitems;
        }
        // GET api/<OrderItemsController>/5
        [HttpGet("{id}")]
        public OrderItem Get(int id)
        {
            var orderitems = db.order_items.Select(s => new OrderItem
            {
                ordered_quantity = s.ordered_quantity,
                created_at = s.created_at,
                updated_at = s.updated_at,
                product_id = s.product_id,
                Products = db.products.Where(a => a.product_id == s.product_id).FirstOrDefault(),
                order_id = s.order_id,
                Orders = db.orders.Where(a => a.order_id == s.order_id).FirstOrDefault()
            }).Where(a => a.order_id == id).FirstOrDefault();
            return orderitems;
        }

        // POST api/<OrderItemsController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormOrderItemView _odi)
        {
            var orderitems = new OrderItem()
            {
                ordered_quantity = _odi.ordered_quantity,
                Products = db.products.Find(_odi.product_id),
                Orders = db.orders.Find(_odi.order_id)
            };
            db.order_items.Add(orderitems);
            await db.SaveChangesAsync();
            if (orderitems.order_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<OrderItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormOrderItemView _odi)
        {
            var orderitems = db.order_items.Find(id);
            orderitems.ordered_quantity = _odi.ordered_quantity;
            orderitems.Products = db.products.Find(_odi.product_id);
            orderitems.Orders = db.orders.Find(_odi.order_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<OrderItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var orderitems = db.order_items.Find(id);
            db.order_items.Remove(orderitems);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}