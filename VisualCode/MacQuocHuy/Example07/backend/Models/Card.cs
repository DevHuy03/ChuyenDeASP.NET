using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace a.Exercise02.Models
{
    public class Card
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid customer_id { get; set; }
        public virtual Customer Customers { get; set; }

    }
}