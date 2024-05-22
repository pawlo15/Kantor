using Kantor.Shared.Abstraction;
using Kantor.Infrastructure.Entities.Auth;
using Kantor.Infrastructure.Entities.Operations;
using System.Collections.ObjectModel;

namespace Kantor.Infrastructure.Entities.User
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SecureKey { get; set; }

        public virtual Account.Account Account { get; set; }
        public virtual Credentials Credentials { get; set; }
        public virtual ICollection<UserHistory> History { get; set; } = new Collection<UserHistory>();
        public virtual ICollection<OperationHistory> OperationHistory { get; set; } = new Collection<OperationHistory>();
    }
}
