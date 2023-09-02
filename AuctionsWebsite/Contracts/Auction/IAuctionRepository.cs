using Entities.DAO.Product;
using Entities.DTO.Auction;

namespace Contracts.Auction
{
    public interface IAuctionRepository
    {
        void CreateAuction(AuctionDTO auction, ProductDAO prod);
    }
}