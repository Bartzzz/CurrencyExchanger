using System;
using CurrencyExchanger.Core.Services.Models;
using Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using CurrencyExchanger.Core.Services.Interfaces;
using ImTools;
using Prism.Commands;

namespace CurrencyExchanger.UI.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IExchangeService _exchangeService;
        public IList<Rate> Rates { get; set; }
        public DelegateCommand CalculateExchangeCommand { get; private set; }

        private Rate _returnRate;
        private double _returnAmount;
        public Rate ReturnRate
        {
            get => this._returnRate;
            set
            {
                if (_returnRate != value)
                {
                    _returnRate = value;
                    _returnAmount = 0;
                    RaisePropertyChanged();
                    CalculateExchangeCommand.Execute();
                }
            }
        }
        public double ReturnAmount
        {
            get => _returnAmount;
            set
            {
                _returnAmount = value;
                RaisePropertyChanged();
            }
        }
        private Rate _sourceRate;
        private string _sourceAmount = "0";
     

        public Rate SourceRate
        {
            get => _sourceRate;
            set
            {
                if (_sourceRate != value)
                {
                    _sourceRate = value;
                    _returnAmount = 0;
                    RaisePropertyChanged();
                    CalculateExchangeCommand.Execute();
                }
            }
        }

        public string SourceAmount
        {
            get => _sourceAmount;
            set
            {
                if (VerifyText(value) || string.IsNullOrEmpty(value))
                {
                    _sourceAmount = value;
                    RaisePropertyChanged();
                }

                CalculateExchangeCommand.Execute();
            }
        }

        public ShellWindowViewModel(ICurrencyService currencyService, IExchangeService exchangeService)
        {
            _currencyService = currencyService;
            _exchangeService = exchangeService;
            _returnRate = new Rate();
            _sourceRate = new Rate();
            Rates = _currencyService.GetRates();
            CalculateExchangeCommand = new DelegateCommand(CalculateExchange).ObservesProperty(() => SourceRate).ObservesProperty(() => ReturnRate);
        }
        private bool VerifyText(string text)
        {
            Regex regex = new Regex("\\d+(\\.\\d{1,2})?");
            return regex.IsMatch(text);
        }

        private void CalculateExchange()
        {
            if (VerifyProvidedData())
            {
                SourceRate.Amount = double.Parse(_sourceAmount, NumberStyles.Any, CultureInfo.InvariantCulture);
                ReturnAmount =  _exchangeService.CalculateExchange(SourceRate, ReturnRate);
            }
        }

        private bool VerifyProvidedData()
        {
            if(!double.TryParse(_sourceAmount, NumberStyles.Any, CultureInfo.InvariantCulture, out double sourceAmount))
            {
                return false;
            }
            return !string.IsNullOrEmpty(SourceRate.Currency)
                   && sourceAmount > 0
                   && SourceRate.Mid > 0
                   && !string.IsNullOrEmpty(ReturnRate.Currency)
                   && ReturnRate.Mid > 0;
        }

    }
}
