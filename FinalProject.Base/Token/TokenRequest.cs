using System.ComponentModel.DataAnnotations;

namespace FinalProject.Base
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(125)]
        [EmailAttribute]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [PasswordAttribute]
        public string Password { get; set; }
    }
}