// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Product_Shipping_Info
    {
        public Guid id { get; set; }
        public Guid product_id { get; set; }
        public double weight { get; set; }
        public string? weight_unit { get; set; }
        public double volume { get; set; }
        public string? volume_unit { get; set; }
        public double dimension_width { get; set; }
        public double dimension_height { get; set; }
        public double dimension_depth { get; set; }
        public string? dimension_unit  { get; set; }
        public virtual Product Products { get; set; }

    }
}
