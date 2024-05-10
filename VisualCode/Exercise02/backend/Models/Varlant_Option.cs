using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Varlant_Option
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public string title { get; set; }
        public Guid image_id { get; set; }
        public Guid product_id { get; set; }
        public double sale_price { get; set; }
        public double compare_price { get; set; }
        public double buying_price { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }
        public bool active { get; set; }
        public virtual Gallery Gallerise { get; set; }
        public virtual Product Products { get; set; }


    }
}
