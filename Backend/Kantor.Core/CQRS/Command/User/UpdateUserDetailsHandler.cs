using Kantor.Infrastructure.Entities.User;
using Kantor.Infrastructure.Enums;
using Kantor.Infrastructure.Exceptions;
using Kantor.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Kantor.Core.CQRS.Command.User
{
    public class UpdateUserDetailsHandler : IRequestHandler<UpdateUserDetailsCommand>
    {
        private readonly IUnitOfWork _uow;
        public UpdateUserDetailsHandler(IUnitOfWork unitOfWork) 
        {
            _uow = unitOfWork;
        }

        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.UserRepository.GetAsync(Guid.Empty);
            if (entity == null)
                throw new DomainException("Brak użytkownika");

            if (!request.Name.IsNullOrEmpty())
            {
                entity.Name = request.Name;
                entity.History.Add(new UserHistory
                {
                    Date = DateTime.UtcNow,
                    OperationId = (int)UserOperationEnum.NameChange,
                    Action = UserOperationEnum.NameChange.ToString()
                });
            }

            if (!request.Email.IsNullOrEmpty() && !request.SecureKey.IsNullOrEmpty())
            {
                entity.Email = request.Email;
                entity.History.Add(new UserHistory
                {
                    Date = DateTime.UtcNow,
                    OperationId = (int)UserOperationEnum.EmailChange,
                    Action = UserOperationEnum.EmailChange.ToString()
                });
            }

            await _uow.UserRepository.UpdateAsync(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
