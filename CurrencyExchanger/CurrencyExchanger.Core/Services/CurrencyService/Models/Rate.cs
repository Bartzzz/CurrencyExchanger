using System.Text.Json.Serialization;

namespace CurrencyExchanger.CurrencyExchanger.Core.Services.CurrencyService.Models
{
    public class Rate
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("mid")]
        public double Mid { get; set; }
    }
}
