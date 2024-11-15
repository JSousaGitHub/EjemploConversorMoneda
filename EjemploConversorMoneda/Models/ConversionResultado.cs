

namespace EjermploConversorMoneda.Models; 

public class ConversionResultado {

    /// <summary>
    /// Gets or sets the result of the conversion.
    /// </summary>
    [JsonPropertyName("result")]
    public string Result { get; set; }

    /// <summary>
    /// Gets or sets the documentation of the conversion service.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string Documentation { get; set; }

    /// <summary>
    /// Gets or sets the terms of use of the conversion service.
    /// </summary>
    [JsonPropertyName("terms_of_use")]
    public string TermsOfUse { get; set; }

    /// <summary>
    /// Gets or sets the UNIX timestamp of the last update.
    /// </summary>
    [JsonPropertyName("time_last_update_unix")]
    public long TimeLastUpdateUnix { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp of the last update.
    /// </summary>
    [JsonPropertyName("time_last_update_utc")]
    public string TimeLastUpdateUtc { get; set; }

    /// <summary>
    /// Gets or sets the UNIX timestamp of the next update.
    /// </summary>
    [JsonPropertyName("time_next_update_unix")]
    public long TimeNextUpdateUnix { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp of the next update.
    /// </summary>
    [JsonPropertyName("time_next_update_utc")]
    public string TimeNextUpdateUtc { get; set; }

    /// <summary>
    /// Gets or sets the base currency code.
    /// </summary>
    [JsonPropertyName("base_code")]
    public string BaseCode { get; set; }

    /// <summary>
    /// Gets or sets the target currency code.
    /// </summary>
    [JsonPropertyName("target_code")]
    public string TargetCode { get; set; }

    /// <summary>
    /// Gets or sets the conversion rate.
    /// </summary>
    [JsonPropertyName("conversion_rate")]
    public decimal ConversionRate { get; set; }

    /// <summary>
    /// Gets or sets the result of the conversion.
    /// </summary>
    [JsonPropertyName("conversion_result")]
    public decimal ConversionResult { get; set; }



}
