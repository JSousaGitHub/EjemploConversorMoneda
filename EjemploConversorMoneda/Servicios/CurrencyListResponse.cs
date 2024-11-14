
namespace EjermploConversorMoneda.Services;

public class CurrencyListResponse {

    [JsonPropertyName("rates")]
    public Dictionary<string, decimal> rates { get; set; }
}
