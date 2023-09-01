using Entities.DAO.Auth;

namespace Entities.DAO.Wallet
{
    /// <summary>
    /// Model which will be used for manipulating wallets
    /// </summary>
    public class WalletDAO
    {
        /// <summary>
        /// Wallet id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Wallet amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        public int UserId { get; set; }

        #region navigational properties

        /// <summary>
        /// User object
        /// </summary>
        public RegisterDAO User { get; set; }

        #endregion
    }
}