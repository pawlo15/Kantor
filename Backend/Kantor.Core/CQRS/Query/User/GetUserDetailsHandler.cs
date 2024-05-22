using AutoMapper;
using Kantor.Core.DTOs.User;
using Kantor.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Kantor.Core.CQRS.Query.User
{
    public class GetUserDetailsHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetUserDetailsHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserDetailsDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _uow.UserRepository.GetAsync(request.Id);

            return _mapper.Map<UserDetailsDTO>(result);
        }
    }
}
