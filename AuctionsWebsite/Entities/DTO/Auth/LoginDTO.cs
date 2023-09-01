using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Auth
{
    /// <summary>
    /// Model which will be used for authenticating user
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Username of user
        /// </summary>
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "{0} doesn't meet the requirements!")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Username { get; set; }

        /// <summary>
        /// Password for authenticating user
        /// </summary>
        [StringLength(maximumLength: int.MaxValue, MinimumLength = 3, ErrorMessage = "{0} doesn't meet the requirements!")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Password { get; set; }
    }
}