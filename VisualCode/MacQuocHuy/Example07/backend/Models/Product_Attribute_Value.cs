using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Product_Attribute_Value
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid product_attribute_id { get; set; }
        public Guid attribute_value_id { get; set; }
        public virtual Product_Attribute Product_Attributes { get; set; }
        public virtual Attribute_Value Attribute_Values { get; set; }

    }
}
