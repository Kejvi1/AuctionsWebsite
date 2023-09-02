using Contracts.Auction;
using Entities.DAO.Auction;
using Entities.DTO.Auction;

namespace Repositories.Auction
{
    public class AuctionRepository : GenericRepository<AuctionDAO>, IAuctionRepository
    {
        public AuctionRepository(ApplicationContext context) : base(context)
        {
        }

        public void CreateAuction(AuctionDTO auction, int prodId, int uId)
        {
            var auctionDAO = new AuctionDAO
            {
                EndDate = auction.EndDate,
                StartingBid = auction.StartingBid,
                ProductId = prodId,
                UserId = uId
            };

            base.Add(auctionDAO);
        }
    }
}