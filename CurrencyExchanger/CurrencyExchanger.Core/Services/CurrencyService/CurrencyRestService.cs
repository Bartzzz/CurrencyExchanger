using System.Collections.Generic;
using System.Linq;
using CurrencyExchanger.CurrencyExchanger.Core.Services.CurrencyService.Models;
using CurrencyExchanger.CurrencyExchanger.Core.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace CurrencyExchanger.CurrencyExchanger.Core.Services.CurrencyService
{
    public class CurrencyRestService : ICurrencyService
    {
        private static string _baseUri = "http://api.nbp.pl/api/";
        private static string _getRatesResource = "exchangerates/tables/A/";

        private RestClient _client;
        public CurrencyRestService()
        {
            _client = new RestClient(_baseUri);
        }
        public IList<Rate> GetRates()
        {
            var request = new RestRequest(_getRatesResource);
            var response = _client.Get(request);
            var test = JsonConvert.DeserializeObject<List<CurrencyRates>>(response.Content).FirstOrDefault();
            return test?.Rates;
        }
    }
}