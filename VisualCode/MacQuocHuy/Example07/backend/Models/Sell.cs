using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Sell
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public int id { get; set; }
        public Guid product_id { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public virtual Product Products { get; set; }
    }
}