using Entities.DTO.Product;
using Entities.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Auction
{
    /// <summary>
    /// Auction model
    /// </summary>
    public class AuctionDTO : ProductDTO
    {
        /// <summary>
        /// Starting bid
        /// </summary>
        [Range(1, double.MaxValue, ErrorMessage = "{0} doesn't meet the requirements!")]
        public double StartingBid { get; set; }

        /// <summary>
        /// End date of auction
        /// </summary>
        [GreaterThanNow(ErrorMessage = "EndDate should be greater than now!")]
        public DateTime EndDate { get; set; }
    }
}