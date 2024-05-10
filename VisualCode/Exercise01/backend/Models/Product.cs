// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class Product
    {
        public Product()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        public int product_id { get; set; }
        public int category_id { get; set; }
        public string product_title { get; set; }
        public string image_url { get; set; }
        public int sku{ get; set; }
        public double price_unit { get; set; }
        public int quantity { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
