
using Microsoft.DotNet.MSIdentity.Shared;

namespace EjermploConversorMoneda.Services;

public class CurrencyConverterService {

    private readonly HttpClient _httpClient;

    // TODO: ---> Cambiar C�digo de la API de conversi�n
    // private readonly string _apiKey = "4b98ce431c662ac85c443184";
    // private readonly string _apiKey = "1accae3913ab892d0bde4a55";   // C�digo de Pedro Jos�

    private readonly string _apiKey = "4b9sge31sfd2ac85rwer3184";

    public CurrencyConverterService(HttpClient httpClient) {
        _httpClient = httpClient;
    }


    public async Task<ConversionResultado> ConvertCurrency(string amount, string fromCurrency, string toCurrency) {

        // Solicitud de la conversi�n a CountryData
        var requestUrl = $"https://v6.exchangerate-api.com/v6/{_apiKey}/pair/{fromCurrency}/{toCurrency}/{amount}";
        var response = await _httpClient.GetAsync(requestUrl);

        // Gesti�n de la respuesta
        if(response.IsSuccessStatusCode) {

            // Espera la respuesta a la solicitud
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Conversi�n datos de string_Json al tipo ConversionResultado
            var resultConvers = System.Text.Json.JsonSerializer.Deserialize<ConversionResultado>(jsonResponse);

            return resultConvers;

        } else {

            throw new Exception("Error al obtener la tasa de conversi�n.");
        }
    }


    public async Task<List<string>> GetCurrencyList() {
        var response = await _httpClient.GetAsync("https://api.exchangerate-api.com/v4/latest/USD");

        if(response.IsSuccessStatusCode) {
            var content = await response.Content.ReadAsStringAsync();
            var currencyListResponse = System.Text.Json.JsonSerializer.Deserialize<CurrencyListResponse>(content);
            var currencyCodes = currencyListResponse.rates.Keys.ToList();
            return currencyCodes;
        }

        return new List<string>();
    }

}
