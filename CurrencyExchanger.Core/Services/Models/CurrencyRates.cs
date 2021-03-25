using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CurrencyExchanger.Core.Services.Models
{
    public class CurrencyRates
    {
        [JsonPropertyName("table")]
            public string Table { get; set; }

            [JsonPropertyName("no")]
            public string No { get; set; }

            [JsonPropertyName("effectiveDate")]
            public string EffectiveDate { get; set; }

            [JsonPropertyName("rates")]
            public List<Rate> Rates { get; set; }
    }
}
