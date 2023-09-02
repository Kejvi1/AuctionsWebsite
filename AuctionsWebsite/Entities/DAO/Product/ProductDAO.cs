using Entities.DAO.Auction;

namespace Entities.DAO.Product
{
    /// <summary>
    /// Product model
    /// </summary>
    public class ProductDAO
    {
        /// <summary>
        /// Product id
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

        #region navigational properties

        /// <summary>
        /// Auction object
        /// </summary>
        public AuctionDAO Auction { get; set; }

        #endregion
    }
}