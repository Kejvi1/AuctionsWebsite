using Contracts.Bid;
using Entities.DAO.Bid;

namespace Repositories.Bid
{
    public class BidRepository : GenericRepository<BidDAO>, IBidRepository
    {
        public BidRepository(ApplicationContext context) : base(context)
        {
        }

        public void PlaceBid(BidDAO bid)
        {
            base.Add(bid);
        }
    }
}