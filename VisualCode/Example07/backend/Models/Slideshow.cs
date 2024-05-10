using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Slideshow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string? title { get; set; }
        public string? destination_url { get; set; }
        public string image { get; set; }
        public string placeholder { get; set; }
        public string? description { get; set; }
        public string? btn_label { get; set; }
        public int display_order { get; set; }
        public bool published { get; set; }
        public short clicks { get; set; }
        public string? styles { get; set; }
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
