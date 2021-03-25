using System.Collections.Generic;
using CurrencyExchanger.Core.Services.Models;

namespace CurrencyExchanger.Core.Services.Interfaces
{
    public interface ICurrencyService
    {
        IList<Rate> GetRates();
    }
}