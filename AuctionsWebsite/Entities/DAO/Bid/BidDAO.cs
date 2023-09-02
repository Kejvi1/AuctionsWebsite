using Entities.DAO.Auction;
using Entities.DAO.Auth;

namespace Entities.DAO.Bid
{
    /// <summary>
    /// Model which will be used for bidding
    /// </summary>
    public class BidDAO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Auction id
        /// </summary>
        public int AuctionId { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Bidded amount
        /// </summary>
        public double Amount { get; set; }

        #region navigational properties

        /// <summary>
        /// Auction object
        /// </summary>
        public virtual AuctionDAO Auction { get; set; }

        /// <summary>
        /// User object
        /// </summary>
        public virtual RegisterDAO User { get; set; }

        #endregion
    }
}