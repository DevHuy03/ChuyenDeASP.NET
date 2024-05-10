using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Customer_Addresse
    {

        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid customer_id { get; set; }
        public string address_line1 { get; set; }
        public string? address_line2 { get; set; }
        public string phone_number { get; set; } 
        public string dial_code { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public virtual Customer Customers { get; set; }

    }
}