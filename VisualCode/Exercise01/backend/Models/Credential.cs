// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class Credential
    {
        public Credential()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        public int credential_id { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        public bool is_enabled { get; set; }
        public bool is_account_non_expired{ get; set; }
        public bool is_account_non_locked { get; set; }
        public bool is_credentials_non_expired { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public User Users { get; set; }
        public virtual ICollection<VerificationToken> VerificationTokens { get; set; }

    }
}
