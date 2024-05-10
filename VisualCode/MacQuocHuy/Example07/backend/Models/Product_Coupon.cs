using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Product_Coupon
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public Guid id { get; set; }
        public Guid coupon_id { get; set; }
        public Guid product_id { get; set; }
        public virtual Coupon Coupons { get; set; }
        public virtual Product Products { get; set; }
    }
}