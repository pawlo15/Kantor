using Kantor.Core.DTOs.User;
using MediatR;

namespace Kantor.Core.CQRS.Query.User
{
    public class GetUserDetailsQuery : IRequest<UserDetailsDTO>
    {
        public Guid Id { get; set; }
    }
}
