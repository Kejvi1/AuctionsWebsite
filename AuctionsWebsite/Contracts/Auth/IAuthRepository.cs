using Entities.DAO.Auth;
using Entities.DTO.Auth;

namespace Contracts.Auth
{
    public interface IAuthRepository : IGenericRepository<RegisterDAO>
    {
        bool GetByUsername(string username);

        RegisterDAO Login(LoginDTO loginObj);

        void Register(RegisterDTO registerObj);
    }
}