using Contracts;
using Contracts.Auth;
using Microsoft.Extensions.Configuration;
using Repositories.Auth;

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

        public void Dispose() => _context.Dispose();

        public void Save() => _context.SaveChanges();
    }
}