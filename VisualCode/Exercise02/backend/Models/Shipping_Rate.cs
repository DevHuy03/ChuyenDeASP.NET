using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Shipping_Rate
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public Guid id { get; set; }
        public int shipping_zone_id { get; set; }
        public string? weight_unit { get; set; }
        public double min_value { get; set; }
        public double max_value { get; set; }
        public bool no_max { get; set; }
        public double? price { get; set; }
        public virtual Shipping_Zone Shipping_Zones { get; set; }

    }
}