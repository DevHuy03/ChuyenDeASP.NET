using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string? slug { get; set; }
        public string? product_name { get; set; }
        public string? sku { get; set; }
        public double? sale_price { get; set; }
        public double? compare_price { get; set; }
        public double? buying_price { get; set; }
        public int? quantity { get; set; }
        public string? short_description { get; set; }
        public string? product_description { get; set; }
        public string? product_type { get; set; }
        public bool? published { get; set; }= false;
        public bool? disable_out_of_stock { get; set; }
        public string? note { get; set; }
        public string? sale_percent { get; set; }

        // public double? compare_price { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? updated_at { get; set; }
        public Guid? created_by { get; set; }
        public Guid? updated_by { get; set; }
        public virtual Staff_Account? CreatedBy { get; set; }
        public virtual Staff_Account? UpdatedBy { get; set; }
    }
}
