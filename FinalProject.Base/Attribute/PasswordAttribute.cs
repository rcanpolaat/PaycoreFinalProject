using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FinalProject.Base
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                string source = value.ToString();

                if (!Regex.IsMatch(source, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$", RegexOptions.Compiled))
                    return new ValidationResult("Password must contain at least one upper case letter and a number");

                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Password must contain at least one upper case letter and a number");
            }
        }
    }
}
