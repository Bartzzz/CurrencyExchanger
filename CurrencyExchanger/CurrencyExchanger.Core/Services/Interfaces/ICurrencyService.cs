using System.Collections.Generic;
using CurrencyExchanger.CurrencyExchanger.Core.Services.CurrencyService.Models;

namespace CurrencyExchanger.CurrencyExchanger.Core.Services.Interfaces
{
    public interface ICurrencyService
    {
        IList<Rate> GetRates();
    }
}