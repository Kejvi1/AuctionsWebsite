using Contracts;
using Contracts.Auction;
using Contracts.Auth;
using Contracts.Product;
using Microsoft.Extensions.Configuration;
using Repositories.Auction;
using Repositories.Auth;
using Repositories.Product;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _config;

        public UnitOfWork(ApplicationContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public IAuthRepository Auth =>
            new AuthRepository(context: _context);

        public IAuctionRepository Auction =>
            new AuctionRepository(context: _context);

        public IProductRepository Product =>
            new ProductRepository(context: _context);

        public void Dispose() => _context.Dispose();

        public void Save() => _context.SaveChanges();
    }
}