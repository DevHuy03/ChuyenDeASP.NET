// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class Order
    {
        public Order()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
            order_date = DateTime.Now;
        }
        public int order_id { get; set; }
        public int cart_id { get; set; }
        public DateTime order_date { get; set; }
        public string order_desc { get; set; }
        public int order_fee { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Cart Carts { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

    }
}
