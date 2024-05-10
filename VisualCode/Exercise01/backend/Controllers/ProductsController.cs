using Microsoft.AspNetCore.Mvc;
using Exercise01.Models;
using Exercise01.Context;
namespace Exercise01.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly Exercise01Context db;
        public ProductsController(Exercise01Context db)
        {
            this.db = db;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = db.products.Select(s => new Product
            {
                product_id = s.product_id,
                product_title = s.product_title,
                image_url = s.image_url,
                sku = s.sku,
                price_unit = s.price_unit,
                quantity = s.quantity,
                category_id = s.category_id,
                Category = db.categories.Where(a => a.category_id == s.category_id).FirstOrDefault()
            }).ToList();
            return products;
        }
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var products = db.products.Select(s => new Product
            {
                product_id = s.product_id,
                product_title = s.product_title,
                image_url = s.image_url,
                sku = s.sku,
                price_unit = s.price_unit,
                quantity = s.quantity,
                category_id = s.category_id,
                Category = db.categories.Where(a => a.category_id == s.category_id).FirstOrDefault()
            }).Where(a => a.product_id == id).FirstOrDefault();
            return products;
        }

        // POST api/<ProductsController> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormProductView _product)
        {
            var product = new Product()
            {
                product_title = _product.product_title,
                image_url = _product.image_url,
                sku = _product.sku,
                price_unit = _product.price_unit,
                quantity = _product.quantity,
                Category = db.categories.Find(_product.category_id)
            };
            db.products.Add(product);
            await db.SaveChangesAsync();
            if (product.product_id > 0)
            {
                return Ok(1);
            }
            return Ok(0);
        }
        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormProductView _user)
        {
            var product = db.products.Find(id);
            product.product_title = _user.product_title;
            product.image_url = _user.image_url;
            product.sku = _user.sku;
            product.price_unit = _user.price_unit;
            product.quantity = _user.quantity;
            product.Category = db.categories.Find(_user.category_id);
            await db.SaveChangesAsync();
            return Ok(1);
        }
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = db.products.Find(id);
            db.products.Remove(product);
            await db.SaveChangesAsync();
            return Ok(1);
        }
    }
}