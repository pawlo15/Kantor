using Kantor.Infrastructure.Entities.Auth;
using Kantor.Infrastructure.Entities.Operations;
using Kantor.Infrastructure.Entities.User;

namespace Kantor.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public ExtendedUserRepository UserRepository { get; }
        public ExtendedAccountReposiotry AccountRepository { get; }
        public GenericRepository<UserHistory, Guid> UserHistoryRepository { get; }
        public GenericRepository<UserOperation, int> UserOperationRepository { get; }
        public GenericRepository<Credentials, Guid> CredentialsRepository { get; }
        public GenericRepository<Currency, byte> CurrencyRepository { get; }
        public Task SaveChangesAsync();
    }
}
