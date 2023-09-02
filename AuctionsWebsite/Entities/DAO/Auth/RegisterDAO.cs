using Entities.DAO.Auction;
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
        public WalletDAO Wallet { get; set; }

        /// <summary>
        /// Auctions
        /// </summary>
        public ICollection<AuctionDAO> Auctions { get; set; }

        #endregion
    }
}