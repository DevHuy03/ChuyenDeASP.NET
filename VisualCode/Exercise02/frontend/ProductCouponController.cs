using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCouponController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public ProductCouponController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/ProductCoupon
        [HttpGet]
        public IActionResult GetProductCoupons()
        {
            var productCoupons = _context.ProductCoupons.ToList();
            return Ok(productCoupons);
        }

        // GET: api/ProductCoupon/{coupon_id}/{product_id}
        [HttpGet("{coupon_id}/{product_id}")]
        public IActionResult GetProductCoupon(Guid coupon_id, Guid product_id)
        {
            var productCoupon = _context.ProductCoupons.FirstOrDefault(pc => pc.coupon_id == coupon_id && pc.product_id == product_id);
            if (productCoupon == null)
            {
                return NotFound();
            }
            return Ok(productCoupon);
        }

        // POST: api/ProductCoupon
        [HttpPost]
        public IActionResult CreateProductCoupon([FromBody] ProductCoupon productCoupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductCoupons.Add(productCoupon);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductCoupon), new { coupon_id = productCoupon.coupon_id, product_id = productCoupon.product_id }, productCoupon);
        }

        // DELETE: api/ProductCoupon/{coupon_id}/{product_id}
        [HttpDelete("{coupon_id}/{product_id}")]
        public IActionResult DeleteProductCoupon(Guid coupon_id, Guid product_id)
        {
            var productCoupon = _context.ProductCoupons.FirstOrDefault(pc => pc.coupon_id == coupon_id && pc.product_id == product_id);
            if (productCoupon == null)
            {
                return NotFound();
            }

            _context.ProductCoupons.Remove(productCoupon);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
