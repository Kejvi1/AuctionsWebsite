using Contracts.Auction;
using Entities.DAO.Auction;
using Entities.DAO.Product;
using Entities.DTO.Auction;

namespace Repositories.Auction
{
    public class AuctionRepository : GenericRepository<AuctionDAO>, IAuctionRepository
    {
        public AuctionRepository(ApplicationContext context) : base(context)
        {
        }

        public void CreateAuction(AuctionDTO auction, ProductDAO prod)
        {
            var auctionDAO = new AuctionDAO
            {
                EndDate = auction.EndDate,
                StartingBid = auction.StartingBid,
                ProductId = prod.Id
            };

            base.Add(auctionDAO);
        }
    }
}