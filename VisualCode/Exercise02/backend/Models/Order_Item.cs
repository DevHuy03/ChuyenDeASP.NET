using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Order_Item
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid product_id { get; set; }
        public string order_id { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public virtual Product Products { get; set; }
        public virtual Order Orders { get; set; }

    }
}