// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class User
    {
        public User()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string image_url { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Credential> Credentials { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

    }
}
