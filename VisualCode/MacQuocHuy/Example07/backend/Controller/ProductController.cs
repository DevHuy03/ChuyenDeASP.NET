using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using a.Exercise02.Models;
using a.Exercise02.Context;

namespace a.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public ProductController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormProductView _product)
        {
            var product = new Product()
            {
                slug = _product.slug,
                product_name = _product.product_name,
                sku = _product.sku,
                sale_price = _product.sale_price,
                compare_price = _product.compare_price,
                buying_price = _product.buying_price,
                quantity = _product.quantity,
                short_description = _product.short_description,
                product_description = _product.product_description,
                product_type = _product.product_type,
                published = _product.published,
                disable_out_of_stock = _product.disable_out_of_stock,
                note = _product.note,
                sale_percent = _product.sale_percent,
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormProductView _product)
        {
            var product = _context.Products.Find(id);
                product.slug = _product.slug;
                product.product_name = _product.product_name;
                product.sku = _product.sku;
                product.sale_price = _product.sale_price;
                product.compare_price = _product.compare_price;
                product.buying_price = _product.buying_price;
                product.quantity = _product.quantity;
                product.short_description = _product.short_description;
                product.product_description = _product.product_description;
                product.product_type = _product.product_type;
                product.published = _product.published;
                product.disable_out_of_stock = _product.disable_out_of_stock;
                product.note = _product.note;
                product.sale_percent = _product.sale_percent;
                product.updated_at = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(1);
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(1);
        }
    }
}
