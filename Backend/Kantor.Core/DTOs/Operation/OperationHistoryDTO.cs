namespace Kantor.Core.DTOs.Operation
{
    public record OperationHistoryDTO
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal TotalValue { get; set; }

        public string CurrencyCode { get; set; }
        public byte CurrencyId { get; set; }

        public string OperationType { get; set; }
        public byte OperationTypeId { get; set; }
    }
}
