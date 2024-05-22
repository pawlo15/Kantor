using Kantor.Core.DTOs.Operation;
using MediatR;

namespace Kantor.Core.CQRS.Query.Operation
{
    public class GetCurrenciesQuery : IRequest<GetCurrenciesQuery.Result>
    {
        public record Result
        {
            public ICollection<CurrencyItemDTO> Currencies { get; set; }
        }
    }
}
