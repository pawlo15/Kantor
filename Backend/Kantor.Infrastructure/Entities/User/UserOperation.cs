using Kantor.Shared.Abstraction;
using System.Collections.ObjectModel;

namespace Kantor.Infrastructure.Entities.User
{
    public class UserOperation : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserHistory> History { get; set; } = new Collection<UserHistory>();
    }
}
