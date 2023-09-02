using Entities.DAO.Bid;

namespace Contracts.Bid
{
    public interface IBidRepository
    {
        void PlaceBid(BidDAO bid);
    }
}