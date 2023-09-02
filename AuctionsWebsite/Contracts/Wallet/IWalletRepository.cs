using Entities.DAO.Wallet;

namespace Contracts.Wallet
{
    public interface IWalletRepository
    {
        WalletDAO GetWalletForUser(int userId);
    }
}