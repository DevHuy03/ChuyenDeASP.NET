// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class Category
    {
        public Category()
        {
            created_at = DateTime.Now;
            update_at = DateTime.Now;
        }
        public int category_id { get; set; }
        public int? sub_category_id { get; set; }
        public string category_title { get; set; }
        public string image_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> InverseParent { get; } = new List<Category>();
        public virtual Category? Parent { get; set; }
    }
}
