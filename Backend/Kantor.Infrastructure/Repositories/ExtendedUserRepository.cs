using Kantor.Infrastructure.Configuration;
using Kantor.Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Kantor.Infrastructure.Repositories
{
    public class ExtendedUserRepository : GenericRepository<User, Guid>
    {
        public ExtendedUserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<bool> LoginExist(string login)
            => _context.User.Any(x => x.Login == login);

        public override async Task<User> GetAsync(Guid id)
            => await _context.User.Include(u => u.Account)
                .ThenInclude(a => a.AccountBalances)
                .ThenInclude(ab => ab.Currency)
                .Include(u => u.OperationHistory)
                .ThenInclude(oh => oh.OperationType)
                .Include(u => u.History)
                .ThenInclude(uh => uh.Operation)
                .AsSplitQuery()
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
    }
}
