using Contracts.Auth;
using Entities.DAO.Auth;
using Entities.DAO.Wallet;
using Entities.DTO.Auth;
using System.Linq;

namespace Repositories.Auth
{
    public class AuthRepository : GenericRepository<RegisterDAO>, IAuthRepository
    {
        public AuthRepository(ApplicationContext context) : base(context)
        {
        }

        public bool GetByUsername(string username)
        {
            return base.Find(u => u.Username == username).Any();
        }

        public RegisterDAO Login(LoginDTO loginObj)
        {
            return base.Find(u => u.Username == loginObj.Username && u.Password == loginObj.Password).FirstOrDefault();
        }

        public void Register(RegisterDTO registerObj)
        {
            var walletDAO = new WalletDAO
            {
                Amount = 1000
            };

            var userDAO = new RegisterDAO
            {
                Username = registerObj.Username,
                Password = registerObj.Password,
                FirstName = registerObj.FirstName,
                LastName = registerObj.LastName,
                Wallet = walletDAO
            };

            base.Add(userDAO);
        }
    }
}