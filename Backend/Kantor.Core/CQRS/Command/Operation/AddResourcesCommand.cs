using MediatR;

namespace Kantor.Core.CQRS.Command.Operation
{
    public class AddResourcesCommand : IRequest
    {
        public decimal Value { get; set; }

        private Guid Id;

        public Guid GetId() => Id;
        public void SetId(Guid id) => Id = id;
    }
}
