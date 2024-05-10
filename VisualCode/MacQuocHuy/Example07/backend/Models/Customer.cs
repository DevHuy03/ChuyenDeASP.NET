using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Customer
    {

        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string? email { get; set; }
        public string? password_hash { get; set; }
        public bool active { get; set; }
        public DateTime registered_at { get; set; } = DateTime.UtcNow;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime updated_at { get; set; } = DateTime.UtcNow;
    }
}