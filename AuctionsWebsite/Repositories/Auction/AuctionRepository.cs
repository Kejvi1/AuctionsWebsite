using Contracts.Auction;
using Entities.DAO.Auction;
using Entities.DTO.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Auction
{
    public class AuctionRepository : GenericRepository<AuctionDAO>, IAuctionRepository
    {
        public AuctionRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<CurrentAuctionDataDTO> GetAuctions()
        {
            var @include = new Expression<Func<AuctionDAO, object>>[]
            {
                a => a.Product,
                a => a.User,
                a => a.Bids
            };

            var data = base.Find(a => a.EndDate <= DateTime.Now, includes: include);

            var dto = data.Select(a => new CurrentAuctionDataDTO
            {
                Id = a.Id,
                Product = a.Product.ProductName,
                Seller = a.User.FirstName,
                SellerId = a.User.Id,
                TimeRemaining = DateTime.Now.Subtract(a.EndDate).Days,
                TopBid = a.Bids.Max().Amount
            }).OrderBy(a => a.TimeRemaining);

            return dto;
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