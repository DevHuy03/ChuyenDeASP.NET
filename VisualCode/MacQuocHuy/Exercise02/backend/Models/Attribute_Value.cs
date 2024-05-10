using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Attribute_Value
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid attribute_id { get; set; }
        public string attribute_value { get; set; }
        public string? color { get; set; }
        public virtual Attribute Attributes { get; set; }
    }
}
