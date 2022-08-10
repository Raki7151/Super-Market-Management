using System.ComponentModel.DataAnnotations;
namespace SuperMarket.Models
{
    public class Bill
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Item Category")]
        public string ProductCategory { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}
