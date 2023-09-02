using Entities.DTO.Auction;

namespace Contracts.Auction
{
    public interface IAuctionRepository
    {
        void CreateAuction(AuctionDTO auction, int prodId, int uId);
    }
}