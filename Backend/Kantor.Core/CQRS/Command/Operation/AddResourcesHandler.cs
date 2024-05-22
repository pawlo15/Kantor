using Kantor.Infrastructure.Enums;
using Kantor.Infrastructure.Exceptions;
using Kantor.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Kantor.Core.CQRS.Command.Operation
{
    public class AddResourcesHandler : IRequestHandler<AddResourcesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddResourcesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddResourcesCommand request, CancellationToken cancellationToken)
        {
            var clientAccount = await _unitOfWork.AccountRepository.GetAsync(request.GetId()) 
                ?? throw new DomainException("Nie odnaleziono konta");
            
            var accountBalance = clientAccount.AccountBalances.FirstOrDefault(x => x.CurrencyId == (byte)CurrencyTypeEnum.PLN);

            if(accountBalance == null)
            {
                clientAccount.AccountBalances.Add(new()
                {
                    Balance = request.Value,
                    CurrencyId = (byte)CurrencyTypeEnum.PLN,
                });
            }
            else
                accountBalance.Balance += request.Value;
            
            await _unitOfWork.AccountRepository.UpdateAsync(clientAccount);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
