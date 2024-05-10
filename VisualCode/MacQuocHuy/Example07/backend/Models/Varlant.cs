using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Varlant
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public string variant_option { get; set; }
        public Guid product_id { get; set; }
        public Guid variant_option_id { get; set; }
        public virtual Varlant_Option Varlant_Options { get; set; }
        public virtual Product Products { get; set; }

    }
}
