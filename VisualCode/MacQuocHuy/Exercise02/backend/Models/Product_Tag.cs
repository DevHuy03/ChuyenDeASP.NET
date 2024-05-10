using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Product_Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid tag_id { get; set; }
        public Guid product_id{ get; set; }
        public virtual Tag Tags { get; set; }
        public virtual Product Products { get; set; }
    }
}
