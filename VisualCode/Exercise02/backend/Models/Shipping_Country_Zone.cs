using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Shipping_Country_Zone
    {
        public Guid id { get; set; }
        public int shipping_zone_id { get; set; }
        public int country_id { get; set; }       
        public virtual Shipping_Zone Shipping_Zones { get; set; }
        public virtual Countrie Countries { get; set; }

    }
}
