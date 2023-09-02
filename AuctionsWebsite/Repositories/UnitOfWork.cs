using Contracts;
using Contracts.Auction;
using Contracts.Auth;
using Contracts.Bid;
using Contracts.Product;
using Contracts.Wallet;
using Repositories.Auction;
using Repositories.Auth;
using Repositories.Bid;
using Repositories.Product;
using Repositories.Wallet;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IAuthRepository Auth =>
            new AuthRepository(context: _context);

        public IAuctionRepository Auction =>
            new AuctionRepository(context: _context);

        public IProductRepository Product =>
            new ProductRepository(context: _context);

        public IWalletRepository Wallet =>
            new WalletRepository(context: _context);

        public IBidRepository Bid =>
            new BidRepository(context: _context);

        public void Dispose() => _context.Dispose();

        public void Save() => _context.SaveChanges();
    }
}