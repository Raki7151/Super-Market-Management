using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public class ForgotPassword
    {
        [Required(ErrorMessage ="Email field is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
