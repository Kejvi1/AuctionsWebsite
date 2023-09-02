using Contracts.Auction;
using Contracts.Auth;
using Contracts.Bid;
using Contracts.Product;
using Contracts.Wallet;
using System;

namespace Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository Auth { get; }

        IAuctionRepository Auction { get; }

        IProductRepository Product { get; }

        IWalletRepository Wallet { get; }

        IBidRepository Bid { get; }

        void Save();
    }
}