using Kantor.Infrastructure.Entities.Operations;
using Kantor.Shared.Abstraction;

namespace Kantor.Infrastructure.Entities.Account
{
    public class AccountBalance : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public byte CurrencyId { get; set; }
        public decimal Balance { get; set; }


        public virtual Account Account { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
