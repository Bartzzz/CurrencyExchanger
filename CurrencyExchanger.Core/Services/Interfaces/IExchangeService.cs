using CurrencyExchanger.Core.Services.Models;

namespace CurrencyExchanger.Core.Services.Interfaces
{
    public interface IExchangeService
    {
        double CalculateExchange(Rate sourceRate, Rate returnRate);
    }
}