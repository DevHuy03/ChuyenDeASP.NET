using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Shipping_Zone
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int id { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public bool active { get; set; }
        public bool free_shipping { get; set; }
        public string? rate_type { get; set; }
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