using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Notification
    {

        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid account_id { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
        public bool? seen { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public DateTime? receive_time { get; set; } = DateTime.UtcNow; 
        public DateTime? notification_expiry_date { get; set; }
        public virtual Staff_Account Staff_Accounts { get; set; }

    }
}