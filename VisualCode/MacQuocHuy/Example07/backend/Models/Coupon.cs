using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Coupon
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public string code { get; set; }
        public double? discount_value { get; set; }
        public string discount_type { get; set; }
        public double times_used { get; set; }
        public double max_usage { get; set; }
        public double order_amount_limit { get; set; }
        public DateTime coupon_start_date { get; set; } = DateTime.UtcNow; 
        public DateTime coupon_end_date { get; set; } = DateTime.UtcNow; 
    }
}
