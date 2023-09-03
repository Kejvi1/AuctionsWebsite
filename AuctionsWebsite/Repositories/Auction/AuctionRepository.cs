using Contracts.Auction;
using Contracts.Wallet;
using Entities.DAO.Auction;
using Entities.DTO.Auction;
using Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Auction
{
    public class AuctionRepository : GenericRepository<AuctionDAO>, IAuctionRepository
    {
        private IWalletRepository _wallet;

        public AuctionRepository(ApplicationContext context) : base(context)
        {
            _wallet = new WalletRepository(context);
        }

        public IEnumerable<CurrentAuctionDataDTO> GetAuctions()
        {
            var @include = new Expression<Func<AuctionDAO, object>>[]
            {
                a => a.Product,
                a => a.User,
                a => a.Bids
            };

            var data = base.Find(a => a.Status == 0, includes: include);

            var dto = data.Select(a => new CurrentAuctionDataDTO
            {
                Id = a.Id,
                Product = a.Product.ProductName,
                Seller = a.User.FirstName,
                SellerId = a.User.Id,
                TimeRemaining = (a.EndDate - DateTime.Now).Days,
                TopBid = a.Bids.OrderByDescending(a => a.Amount)?.FirstOrDefault()?.Amount ?? 0
            }).OrderBy(a => a.TimeRemaining);

            return dto;
        }

        public AuctionDAO GetAuctionById(int id)
        {
            return base.Find(a => a.Id == id).FirstOrDefault();
        }

        public AuctionDetailsDTO GetAuctionDetails(int id)
        {
            var @include = new string[]
            {
                "Product",
                "User",
                "Bids",
                "Bids.User"
            };

            var data = base.FindNested(a => a.Id == id, includes: include).FirstOrDefault();

            return new AuctionDetailsDTO
            {
                Id = id,
                ProductName = data.Product.ProductName,
                ProductDescription = data.Product.ProductDescription,
                SellerId = data.UserId,
                SellerName = data.User.FirstName,
                TimeRemaining = (data.EndDate - DateTime.Now).Days,
                HighestBidName = data.Bids.OrderByDescending(a => a.Amount)?.FirstOrDefault()?.User?.Username,
                HighestBidUserId = data.Bids.OrderByDescending(a => a.Amount)?.FirstOrDefault()?.UserId ?? 0,
                HighestBidAmount = data.Bids.OrderByDescending(a => a.Amount)?.FirstOrDefault()?.Amount ?? 0
            };
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

        public void DeleteAuction(AuctionDAO auction)
        {
            base.Remove(auction);
        }

        public void EndAuction(AuctionDetailsDTO auction)
        {
            //get seller wallet
            var sellerWallet = _wallet.GetWalletForUser(auction.SellerId);

            //get buyer wallet
            var buyerWallet = _wallet.GetWalletForUser(auction.HighestBidUserId);

            //check if buyers current wallet amount if lower than when he first bid in this auction
            //eg: if he has bid in multiple auctions and he is the highest bidder in all of them
            if (buyerWallet.Amount < auction.HighestBidAmount)
                throw new Exception("Can't end auction because buyer doesn't have the required funds!");

            //prepare update objects
            sellerWallet.Amount += auction.HighestBidAmount;
            buyerWallet.Amount -= auction.HighestBidAmount;

            _wallet.UpdateWallet(sellerWallet);
            _wallet.UpdateWallet(buyerWallet);

            var auctionDAO = new AuctionDAO
            {
                Id = auction.Id,
                Status = 1
            };

            base.Update(auctionDAO, p => p.Status);
        }
    }
}