using MediatR;

namespace Kantor.Core.CQRS.Command.User
{
    public class UpdateUserDetailsCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? SecureKey { get; set; }
        private Guid Id;

        public Guid GetId() => Id;
        public void SetId(Guid id) => Id = id;
    }
}
