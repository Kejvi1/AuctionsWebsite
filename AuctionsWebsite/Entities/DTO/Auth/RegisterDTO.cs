using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Auth
{
    /// <summary>
    /// Register model which will be used for registering user data
    /// </summary>
    public class RegisterDTO : LoginDTO
    {
        /// <summary>
        /// First name of user
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of user
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }

        /// <summary>
        /// Checks if input passwords are the same
        /// </summary>
        [Compare(nameof(Password))]
        [Required(ErrorMessage = "{0} is required")]
        public string ConfirmPassword { get; set; }
    }
}