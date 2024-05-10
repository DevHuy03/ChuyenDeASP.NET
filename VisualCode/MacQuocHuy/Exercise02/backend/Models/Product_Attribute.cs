using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Product_Attribute
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid product_id { get; set; }
        public Guid attribute_id { get; set; }
        public virtual Product Products { get; set; }
        public virtual Attribute Attributes { get; set; }

    }
}
