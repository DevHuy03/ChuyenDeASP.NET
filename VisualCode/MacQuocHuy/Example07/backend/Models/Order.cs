using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Order
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public string id { get; set; }
        public Guid coupon_id { get; set; }
        public Guid customer_id { get; set; }
        public Guid order_status_id { get; set; }
        public DateTime? order_approved_at { get; set; } = DateTime.UtcNow; 
        public DateTime? order_delvered_carrier_date { set; get; } = DateTime.UtcNow; 
        public  DateTime? order_delvered_customer_date { get; set; } = DateTime.UtcNow; 
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public Guid updated_by { get; set; }
        public virtual Coupon Coupons { get; set; }
        public virtual Customer Customers { get; set; }
        public virtual Order_Status Order_Statuses { get; set; }
        public virtual Staff_Account UpdatedBy { get; set; }


    }
}