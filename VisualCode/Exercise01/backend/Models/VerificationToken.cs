// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class VerificationToken
    {
        public VerificationToken()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
            exprice_date = DateTime.Now;
        }
        public int verification_token_id { get; set; }
        public int credential_id { get; set; }
        public string verif_token { get; set; }
        public DateTime exprice_date { get; set; }        
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Credential Credentials { get; set; }

    }
}
