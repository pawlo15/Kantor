using Kantor.Infrastructure.Entities.Account;
using Kantor.Shared.Abstraction;
using System.Collections.ObjectModel;

namespace Kantor.Infrastructure.Entities.Operations
{
    public class Currency : IEntity<byte>
    {
        public byte Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OperationHistory> History { get; set; } = new Collection<OperationHistory>();
        public virtual ICollection<AccountBalance> AccountBalances { get; set; } = new Collection<AccountBalance>();
    }
}
