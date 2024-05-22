using Kantor.Core.DTOs.Operation;
using MediatR;

namespace Kantor.Core.CQRS.Command.Operation
{
    public class ExchangeCommand : IRequest
    {
        public CurrencyItemDTO Currency { get; set; }
        public decimal Amount { get; set; }
        public bool IsSale { get; set; }

        private Guid Id;

        public void SetId(Guid id) => Id = id;
        public Guid GetId() => Id;
    }
}
