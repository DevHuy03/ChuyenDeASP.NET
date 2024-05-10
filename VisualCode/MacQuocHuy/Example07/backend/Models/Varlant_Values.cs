using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Varlant_Value
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid varlant_id { get; set; }
        public Guid product_attribute_value_id { get; set; }
        public virtual Product_Attribute_Value Product_Attribute_Values { get; set; }
    }
}
