namespace Entities.DTO.Auction
{
    /// <summary>
    /// Auction details model
    /// </summary>
    public class AuctionDetailsDTO
    {
        /// <summary>
        /// Auction id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Seller id
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Seller name
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// Time remaining in days
        /// </summary>
        public int TimeRemaining { get; set; }

        /// <summary>
        /// Highest bid amount
        /// </summary>
        public double HighestBidAmount { get; set; }

        /// <summary>
        /// Highest bid name
        /// </summary>
        public string HighestBidName { get; set; }

        /// <summary>
        /// User id with the highest bid
        /// </summary>
        public int HighestBidUserId { get; set; }

        /// <summary>
        /// Starting bid
        /// </summary>
        public double StartingBid { get; set; }
    }
}