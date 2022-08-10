using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public class Dairy
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Item")]
        public string Item { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}
