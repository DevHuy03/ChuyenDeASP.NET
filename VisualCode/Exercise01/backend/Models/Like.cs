// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class Like
    {
        public Like()
        {
            like_date = DateTime.Now;
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public DateTime like_date { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Product Products { get; set; }
        public User Users { get; set; }

    }
}
