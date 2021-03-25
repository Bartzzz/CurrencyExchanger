using System.Text.Json.Serialization;

namespace CurrencyExchanger.Core.Services.Models
{
    public class Rate
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("mid")]
        public double Mid { get; set; }
        [JsonIgnore]
        public double Amount { get; set; }
    }
}
