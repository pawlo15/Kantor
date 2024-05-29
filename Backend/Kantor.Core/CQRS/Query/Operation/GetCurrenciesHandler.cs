using AutoMapper;
using Kantor.Core.DTOs.Operation;
using Kantor.Core.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Kantor.Core.CQRS.Query.Operation
{
    public class GetCurrenciesHandler : IRequestHandler<GetCurrenciesQuery, GetCurrenciesQuery.Result>
    {
        private readonly ICurrencyService _service;
        private readonly IMapper _mapper;
        private readonly decimal _purchaseRate;
        private readonly decimal _saleRate;

        public GetCurrenciesHandler(ICurrencyService service, IMapper mapper, IConfiguration configuration)
        {
            _service = service;
            _mapper = mapper;
            _purchaseRate = 0.98M;
            _saleRate = 1.02M;
        }

        public async Task<GetCurrenciesQuery.Result> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var response = await _service.GetCurrency();

            var result = new GetCurrenciesQuery.Result
            {
                Currencies = _mapper.Map<ICollection<CurrencyItemDTO>>(response.Currencies),
            };

            DateTime validFrom = DateTime.UtcNow;
            DateTime validTo = validFrom.AddMinutes(2);

            foreach (var currency in result.Currencies)
            {
                currency.Purchase = Math.Round(currency.Purchase * _purchaseRate, 4);
                currency.Sale = Math.Round(currency.Sale * _saleRate, 4);
                currency.ValidFrom = validFrom;
                currency.ValidTo = validTo;
                currency.SetHash();
            }

            return result;
        }
    }
}
