using Kantor.Infrastructure.Entities.Operations;
using Kantor.Infrastructure.Enums;
using Kantor.Infrastructure.Exceptions;
using Kantor.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Kantor.Core.CQRS.Command.Operation
{
    public class ExchangeHandler : IRequestHandler<ExchangeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExchangeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ExchangeCommand request, CancellationToken cancellationToken)
        {
            if(!request.Currency.IsCorrectSecurityCode())
                throw new DomainException("Niepoprawny kod bezpieczeństwa");

            var client = await _unitOfWork.UserRepository.GetAsync(request.GetId())
                ?? throw new DomainException("Nie znaleziono konta");

            var currencies = await _unitOfWork.CurrencyRepository.GetAllAsync();
            var currency = currencies.FirstOrDefault(x => x.Code == request.Currency.Name);

            var exchangeCurrencyBalance = client.Account.AccountBalances.FirstOrDefault(x => x.Currency.Code == request.Currency.Name);
            var balancePLN = client.Account.AccountBalances.FirstOrDefault(x => x.CurrencyId == (byte)CurrencyTypeEnum.PLN);
            
            decimal value = 0M;
            OperationHistory operation = new()
            {
                Value = request.Amount,
                CurrencyId = currency.Id,
                Date = DateTime.UtcNow
            };

            if (request.IsSale)
            {
                operation.OperationTypeId = (byte)OperationTypeEnum.Sale;
                operation.ExchangeRate = request.Currency.Sale;
                value = Math.Round(request.Amount * request.Currency.Sale, 2);

                if (balancePLN.Balance < value)
                    throw new DomainException("Brak wystarczających środków na koncie");

                if(exchangeCurrencyBalance == null)
                {
                    client.Account.AccountBalances.Add(new()
                    {
                        Balance = request.Amount,
                        CurrencyId = currency.Id
                    });
                }
                else
                {
                    exchangeCurrencyBalance.Balance += request.Amount;
                }
                balancePLN.Balance -= value;
            }
            else
            {
                operation.OperationTypeId = (byte)OperationTypeEnum.Purchase;
                operation.ExchangeRate = request.Currency.Purchase;

                value = Math.Round(request.Amount * request.Currency.Purchase, 2);

                if(exchangeCurrencyBalance == null || exchangeCurrencyBalance.Balance < request.Amount)
                    throw new DomainException("Nie można dokonać operacji");

                exchangeCurrencyBalance.Balance -= request.Amount;
                balancePLN.Balance += value;
            }

            operation.TotalValue = value;
            client.OperationHistory.Add(operation);

            await _unitOfWork.UserRepository.UpdateAsync(client);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
