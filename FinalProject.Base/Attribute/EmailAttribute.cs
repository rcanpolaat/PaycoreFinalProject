using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace FinalProject.Base
{
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value is null)
                    return new ValidationResult("Email field must not be empty .");

                //Email for sign in must be appropriate this regex
                if (!Regex.IsMatch(value.ToString(), @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", RegexOptions.Compiled))
                    return new ValidationResult("Invalid Email field.");

                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult("Invalid Email field.");
            }
        }
    }
}