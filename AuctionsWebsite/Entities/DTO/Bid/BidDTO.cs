namespace Entities.DTO.Bid
{
    /// <summary>
    /// Bid model
    /// </summary>
    public class BidDTO
    {
        /// <summary>
        /// Auction id
        /// </summary>
        public int AuctionId { get; set; }

        /// <summary>
        /// Bid
        /// </summary>
        public double Bid { get; set; }
    }
}