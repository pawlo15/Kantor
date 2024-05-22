namespace Kantor.Core.DTOs.Account
{
    public record AccountBalanceDTO
    {
        public byte CurrencyId { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
    }
}
