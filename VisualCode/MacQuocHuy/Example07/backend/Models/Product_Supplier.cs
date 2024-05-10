using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Product_Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid product_id { get; set; }
        public Guid supplier_id { get; set; }
        public virtual Product Products { get; set; }
        public virtual Supplier Suppliers { get; set; }
    }
}
