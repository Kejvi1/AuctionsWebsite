using Entities.DAO.Auction;
using Entities.DAO.Bid;
using Entities.DAO.Wallet;
using System.Collections.Generic;

namespace Entities.DAO.Auth
{
    /// <summary>
    /// Model which will be used for registering user
    /// </summary>
    public class RegisterDAO
    {
        /// <summary>
        /// Record Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        #region navigational properties

        /// <summary>
        /// Wallet object
        /// </summary>
        public virtual WalletDAO Wallet { get; set; }

        /// <summary>
        /// Auctions collection
        /// </summary>
        public virtual ICollection<AuctionDAO> Auctions { get; set; }

        /// <summary>
        /// Bids collection
        /// </summary>
        public virtual ICollection<BidDAO> Bids { get; set; }

        #endregion
    }
}