using CurrencyExchanger.Core.Services.CurrencyService;
using CurrencyExchanger.UI.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using CurrencyExchanger.Core.Services.ExchangeService;
using CurrencyExchanger.Core.Services.Interfaces;

namespace CurrencyExchanger.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICurrencyService, CurrencyRestService>();
            containerRegistry.RegisterSingleton<IExchangeService, ExchangeService>();
        }
    }
}
