using Contracts.Auth;
using System;

namespace Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository Auth { get; }

        void Save();
    }
}