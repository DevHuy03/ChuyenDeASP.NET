using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string supplier_name { get; set; }
        public string? company { get; set; }
        public string? phone_number { get; set; }
        public string? address_line1 { get; set; }
        public string? address_line2 { get; set; }
        public int country_id { get; set; }
        public string? city { get; set; }
        public string? note { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        public virtual Staff_Account CreatedBy { get; set; }
        public virtual Staff_Account UpdatedBy { get; set; }
    }
}
