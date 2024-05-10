// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Product_Category
    {
        public Guid id { get; set; }
        public Guid category_id { get; set; }
        public Guid product_id { get; set; }
        public virtual Category Categories { get; set; }
        public virtual Product Products { get; set; }

    }
}
