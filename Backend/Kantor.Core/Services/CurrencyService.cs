using Kantor.Core.DTOs.Operation;
using Kantor.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Kantor.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _host;

        public CurrencyService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _host = configuration.GetSection("AppSettings:CurrenciesHost").Value;
        }

        public async Task<CurrencyListDTO> GetCurrency()
        {
            var httpResponse = await _httpClient.GetAsync(_host);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<CurrencyListDTO>(content);

                return response;
            }
            else
                throw new Exception("Wystąpił błąd podczas pobierania kursów walut.");
        }
    }
}
