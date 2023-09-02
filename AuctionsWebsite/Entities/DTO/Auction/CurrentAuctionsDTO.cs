using System.Collections.Generic;

namespace Entities.DTO.Auction
{
    /// <summary>
    /// Current actions model
    /// </summary>
    public class CurrentAuctionsDTO
    {
        /// <summary>
        /// Current wallet amount
        /// </summary>
        public double CurrentWalletAmount { get; set; }

        /// <summary>
        /// Auctions
        /// </summary>
        public IEnumerable<CurrentAuctionDataDTO> Auctions { get; set; }
    }
}