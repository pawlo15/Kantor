using Kantor.Infrastructure.Configuration;
using Kantor.Infrastructure.Entities.Auth;
using Kantor.Infrastructure.Entities.Operations;
using Kantor.Infrastructure.Entities.User;
using Kantor.Infrastructure.Repositories.Interfaces;

namespace Kantor.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private ExtendedUserRepository _userRepository;
        private ExtendedAccountReposiotry _accountRepository;
        private GenericRepository<UserHistory, Guid> _userHistoryRepository;
        private GenericRepository<UserOperation, int> _userOperationRepository;
        private GenericRepository<Credentials, Guid> _credentialsRepository;
        private GenericRepository<Currency, byte> _currencyRepository;

        public UnitOfWork(DataContext context) 
        { 
            _context = context;
        }
        
        public ExtendedUserRepository UserRepository
        {
            get
            {
                _userRepository ??= new ExtendedUserRepository(_context);
                return _userRepository;
            }
        }

        public GenericRepository<UserHistory, Guid> UserHistoryRepository
        {
            get
            {
                _userHistoryRepository ??= new GenericRepository<UserHistory, Guid>(_context);
                return _userHistoryRepository;
            }
        }

        public GenericRepository<UserOperation, int> UserOperationRepository
        {
            get
            {
                _userOperationRepository ??= new GenericRepository<UserOperation, int>(_context);
                return _userOperationRepository;
            }
        }

        public GenericRepository<Credentials, Guid> CredentialsRepository
        {
            get
            {
                _credentialsRepository ??= new GenericRepository<Credentials, Guid>(_context);
                return _credentialsRepository;
            }
        }

        public ExtendedAccountReposiotry AccountRepository
        {
            get
            {
                _accountRepository ??= new ExtendedAccountReposiotry(_context);
                return _accountRepository;
            }
        }

        public GenericRepository<Currency, byte> CurrencyRepository
        {
            get
            {
                _currencyRepository ??= new GenericRepository<Currency, byte>(_context);
                return _currencyRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
