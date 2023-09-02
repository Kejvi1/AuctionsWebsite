using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.General
{
    /// <summary>
    /// Greater than attribute
    /// </summary>
    public class GreaterThanNowAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates if input date is greater than datetime now
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;
            if (dt > DateTime.UtcNow)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Input date is is not greater than today");
        }
    }
}