using Kantor.Core.DTOs.Operation;

namespace Kantor.Core.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyListDTO> GetCurrency();
    }
}
