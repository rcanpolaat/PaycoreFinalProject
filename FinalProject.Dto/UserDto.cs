using System;
using System.ComponentModel.DataAnnotations;
using FinalProject.Base;

namespace FinalProject.Dto
{
    public class UserDto
    {
        [Required]
        [MaxLength(50)]
        [EmailAttribute]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [PasswordAttribute]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
    }
}
