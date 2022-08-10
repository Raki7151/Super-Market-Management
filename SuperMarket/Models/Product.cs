using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Item")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string ProductCategory { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }

    }
}
