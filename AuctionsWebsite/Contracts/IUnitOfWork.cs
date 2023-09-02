using Contracts.Auction;
using Contracts.Auth;
using Contracts.Product;
using System;

namespace Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository Auth { get; }

        IAuctionRepository Auction { get; }

        IProductRepository Product { get; }

        void Save();
    }
}