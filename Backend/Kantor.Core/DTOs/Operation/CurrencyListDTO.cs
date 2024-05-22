namespace Kantor.Core.DTOs.Operation
{
    public record CurrencyListDTO
    {
        public ICollection<CurrencyListItemDTO> Curriencies { get; set; }
    }
}
