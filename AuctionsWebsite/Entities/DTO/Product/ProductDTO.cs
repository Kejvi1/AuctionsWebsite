using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Product
{
    /// <summary>
    /// Product model
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Product name
        /// </summary>
        [StringLength(maximumLength: int.MaxValue, MinimumLength = 3, ErrorMessage = "{0} doesn't meet the requirements!")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProductName { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [StringLength(maximumLength: int.MaxValue, MinimumLength = 10, ErrorMessage = "{0} doesn't meet the requirements!")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProductDescription { get; set; }
    }
}