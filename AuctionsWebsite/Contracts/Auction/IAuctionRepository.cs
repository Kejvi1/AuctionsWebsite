using Entities.DTO.Auction;
using System.Collections.Generic;

namespace Contracts.Auction
{
    public interface IAuctionRepository
    {
        IEnumerable<CurrentAuctionDataDTO> GetAuctions();

        void CreateAuction(AuctionDTO auction, int prodId, int uId);
    }
}