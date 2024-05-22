using Kantor.Shared.Abstraction;
using System.Collections.ObjectModel;

namespace Kantor.Infrastructure.Entities.Account
{
    public class Account : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public virtual User.User User { get; set; }
        public virtual ICollection<AccountBalance> AccountBalances { get; set; } = new Collection<AccountBalance>();
    }
}
