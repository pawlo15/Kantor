namespace Kantor.Core.DTOs.Operation
{
    public record CurrencyListDTO
    {
        public ICollection<CurrencyListItemDTO> Currencies { get; set; }
    }
}
