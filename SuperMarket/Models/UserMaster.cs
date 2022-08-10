using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Models
{
    public class UserMaster
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="FirstName*")]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="LastName*")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Gender*")]
        public string Gender { get; set; }

        [Required]
        [RegularExpression("[6-9]{1}[0-9]{9}", ErrorMessage = "Invalid Mobile No.")]
        [Display(Name = "Mobile No.*")]
        public string MobileNo { get; set; }
        [Required]
        [Display(Name = "Email*")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "UserId*")]
        public string UserId { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Category*")]
        public string Name { get; set; }

        [Required]
        public int RoleId { get; set; }

        
    }
}


