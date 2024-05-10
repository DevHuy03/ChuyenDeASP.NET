// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class OrderItem
    {
        public OrderItem()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        public int product_id { get; set; }
        public int order_id { get; set; }
        public int ordered_quantity { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Product Products { get; set; }
        public Order Orders { get; set; }

    }
}
