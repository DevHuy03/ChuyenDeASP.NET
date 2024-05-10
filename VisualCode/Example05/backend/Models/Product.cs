using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table ("Product")]
public class Product
{
    [Key]
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string imageUrl { get; set; }
    public decimal price { get; set; }

}