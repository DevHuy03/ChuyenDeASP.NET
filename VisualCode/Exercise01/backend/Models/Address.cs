// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise01.Models
{
    public class Address
    {
        public Address()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        public int address_id { get; set; }
        public int user_id { get; set; }
        public string full_address { get; set; }
        public int postal_code { get; set; }
        public string city { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public User Users { get; set; }

    }
}
