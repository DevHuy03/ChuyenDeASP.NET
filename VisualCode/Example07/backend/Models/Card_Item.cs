using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Card_Item
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid id { get; set; }
        public Guid card_id { get; set; }
        public Guid product_id { get; set; }
        public int quantity { get; set; }
        public virtual Card Cards { get; set; }
        public virtual Product Products { get; set; }
    }
}