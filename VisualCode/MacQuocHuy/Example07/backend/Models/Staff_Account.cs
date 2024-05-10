using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Staff_Account
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public int role_id  { get; set; }
        public string first_name{ get; set; }
        public string last_name { get; set; }
        public string? phone_number { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public bool active { get; set; }
        public string? image { get; set; }
        public string? placeholder  { get; set; }
        public DateTime registered_at { get; set; } = DateTime.UtcNow; 
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]     
        public DateTime update_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }   

        public Role Roles { get; set; }        
        public virtual ICollection<Staff_Account> InverseCreactedby { get; } = new List<Staff_Account>();
        public virtual ICollection<Staff_Account> InverseUpdatedBy{ get; } = new List<Staff_Account>();
        public virtual Staff_Account? Createdbys { get; set; }
        public virtual Staff_Account? Updatedbys { get; set; }

    }
}