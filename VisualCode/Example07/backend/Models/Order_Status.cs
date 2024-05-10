using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Order_Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string status_name { get; set; }
        public string color { get; set; }
        public string? privacy { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        public virtual Staff_Account CreatedBy { get; set; }
        public virtual Staff_Account UpdatedBy { get; set; }
    }
}