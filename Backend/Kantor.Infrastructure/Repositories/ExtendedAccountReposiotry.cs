using Kantor.Infrastructure.Configuration;
using Kantor.Infrastructure.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace Kantor.Infrastructure.Repositories
{
    public class ExtendedAccountReposiotry : GenericRepository<Account, Guid>
    {
        public ExtendedAccountReposiotry(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Account> GetAsync(Guid id) 
            => await _context.Accounts
                .Include(a => a.AccountBalances)
                .ThenInclude(ab => ab.Currency)
                .FirstOrDefaultAsync(a => a.UserId == id);
    }
}
