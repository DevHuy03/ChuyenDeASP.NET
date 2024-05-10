using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        public readonly Exercise01Context db;
        public PaymentsController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<PaymentsController>
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            var payments = db.payments.Select(s => new Payment
            {
                payment_id = s.payment_id,
                payment_status = s.payment_status,
                is_payed = s.is_payed,
                created_at = s.created_at,
                updated_at = s.updated_at,
                order_id = s.order_id,
                Orders = db.orders.Where(a => a.order_id == s.order_id).FirstOrDefault()
            }).ToList();
            return payments;
        }
        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        public Payment Get(int id)
        {
            var payments = db.payments.Select(s => new Payment
            {
                payment_id = s.payment_id,
                payment_status = s.payment_status,
                is_payed = s.is_payed,
                created_at = s.created_at,
                updated_at = s.updated_at,
                order_id = s.order_id,
                Orders = db.orders.Where(a => a.order_id == s.order_id).FirstOrDefault()
            }).Where(a => a.payment_id == id).FirstOrDefault();
            return payments;
        }

        // POST api/<PaymentsController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormPaymentView _payment)
        {
            var payments = new Payment()
            {
                order_id = _payment.order_id,
                is_payed = _payment.is_payed,
                payment_status = _payment.payment_status,
                Orders = db.orders.Find(_payment.order_id)
            };
            db.payments.Add(payments);
            await db.SaveChangesAsync();
            if (payments.payment_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<PaymentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormPaymentView _payment)
        {
            var payments = db.payments.Find(id);
            payments.order_id = _payment.order_id;
            payments.is_payed = _payment.is_payed;
            payments.payment_status = _payment.payment_status;
            payments.Orders = db.orders.Find(_payment.order_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<PaymentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var payments = db.payments.Find(id);
            db.payments.Remove(payments);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}