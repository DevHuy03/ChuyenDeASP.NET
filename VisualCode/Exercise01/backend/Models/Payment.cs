// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class Payment
    {
        public Payment()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        public int payment_id { get; set; }
        public int order_id { get; set; }
        public bool is_payed { get; set; }
        public int payment_status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Order Orders { get; set; }

    }
}
