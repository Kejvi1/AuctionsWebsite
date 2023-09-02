using Entities.DAO.Auth;
using Entities.DAO.Bid;
using Entities.DAO.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        /// <summary>
        /// User id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Status of action
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// 0 -> open
        /// </item>
        /// <item>
        /// 1 -> finished
        /// </item>
        /// </list>
        /// </remarks>
        [DefaultValue(0)]
        public int Status { get; set; }

        #region navigational properties

        /// <summary>
        /// Product object
        /// </summary>
        public virtual ProductDAO Product { get; set; }

        /// <summary>
        /// User object
        /// </summary>
        public virtual RegisterDAO User { get; set; }

        /// <summary>
        /// Bids collection
        /// </summary>
        public virtual ICollection<BidDAO> Bids { get; set; }

        #endregion
    }
}