using Entities.DAO.Product;
using System;

namespace Entities.DAO.Auction
{
    /// <summary>
    /// Auction model
    /// </summary>
    public class AuctionDAO
    {
        /// <summary>
        /// Auction id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Starting bid
        /// </summary>
        public double StartingBid { get; set; }

        /// <summary>
        /// End date of auction
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Product id
        /// </summary>
        public int ProductId { get; set; }

        #region navigational properties

        /// <summary>
        /// Product object
        /// </summary>
        public ProductDAO Product { get; set; }

        #endregion
    }
}