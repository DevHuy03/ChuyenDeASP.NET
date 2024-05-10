// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class Cart 
    {
        public Cart()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        public int cart_id { get; set; }
        public int user_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public User Users { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
