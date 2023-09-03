using Contracts.Wallet;
using Entities.DAO.Wallet;
using System.Linq;

namespace Repositories.Wallet
{
    public class WalletRepository : GenericRepository<WalletDAO>, IWalletRepository
    {
        public WalletRepository(ApplicationContext context) : base(context)
        {
        }

        public WalletDAO GetWalletForUser(int userId)
        {
            return base.Find(w => w.UserId == userId).FirstOrDefault();
        }

        public void UpdateWallet(WalletDAO wallet)
        {
            base.Update(wallet, w => w.Amount);
        }
    }
}