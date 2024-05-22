using Kantor.Shared.Abstraction;

namespace Kantor.Infrastructure.Entities.Operations
{
    public class OperationHistory : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date {  get; set; }
        public decimal Value { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal TotalValue { get; set; }

        public byte CurrencyId { get; set; }
        public byte OperationTypeId { get; set; }
        public Guid UserId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual OperationType OperationType { get; set; }
        public virtual User.User User { get; set; }

    }
}
