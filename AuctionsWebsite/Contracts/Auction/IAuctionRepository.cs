using Entities.DAO.Auction;
using Entities.DTO.Auction;
using System.Collections.Generic;

namespace Contracts.Auction
{
    public interface IAuctionRepository
    {
        IEnumerable<CurrentAuctionDataDTO> GetAuctions();

        AuctionDAO GetAuctionById(int id);

        AuctionDetailsDTO GetAuctionDetails(int id);

        void CreateAuction(AuctionDTO auction, int prodId, int uId);

        void DeleteAuction(AuctionDAO auction);
    }
}