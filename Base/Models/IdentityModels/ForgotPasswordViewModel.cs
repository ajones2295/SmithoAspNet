using System.ComponentModel.DataAnnotations;

namespace Models.IdentityModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}