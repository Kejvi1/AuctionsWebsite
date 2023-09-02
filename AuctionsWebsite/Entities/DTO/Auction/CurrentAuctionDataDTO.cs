namespace Entities.DTO.Auction
{
    public class CurrentAuctionDataDTO
    {
        /// <summary>
        /// Auction id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Seller id
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Seller name
        /// </summary>
        public string Seller { get; set; }

        /// <summary>
        /// Top bid
        /// </summary>
        public double TopBid { get; set; }

        /// <summary>
        /// Time remaining
        /// </summary>
        public int TimeRemaining { get; set; }
    }
}