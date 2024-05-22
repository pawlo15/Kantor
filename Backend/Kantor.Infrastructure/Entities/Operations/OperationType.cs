using Kantor.Shared.Abstraction;
using System.Collections.ObjectModel;

namespace Kantor.Infrastructure.Entities.Operations
{
    public class OperationType : IEntity<byte>
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OperationHistory> History { get; set; } = new Collection<OperationHistory>();
    }
}
