using System;
using CurrencyExchanger.Core.Services.Interfaces;
using CurrencyExchanger.Core.Services.Models;

namespace CurrencyExchanger.Core.Services.ExchangeService
{
    public class ExchangeService : IExchangeService
    {
        public double CalculateExchange(Rate sourceRate, Rate returnRate)
        {
            if (returnRate.Mid > 0)
            {
                return Math.Round(((sourceRate.Mid * sourceRate.Amount) / returnRate.Mid), 2, MidpointRounding.ToEven);
            }

            return 0;
        }
    }
}