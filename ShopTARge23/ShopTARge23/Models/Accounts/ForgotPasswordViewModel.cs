using System.ComponentModel.DataAnnotations;

namespace ShopTARge23.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
