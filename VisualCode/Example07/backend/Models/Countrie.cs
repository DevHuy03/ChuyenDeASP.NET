using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MacQuocHuy.Exercise02.Models
{
    public class Countrie
    {
        [Key] 
   	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int id { get; set; }
        public string iso { get; set; }
        public string name { get; set; }
        public string upper_name { get; set; }
        public string iso3 { get; set; }
        public int num_code { get; set; }
        public int phone_code { get; set; }
    }
}