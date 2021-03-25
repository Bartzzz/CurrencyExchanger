using CurrencyExchanger.CurrencyExchanger.Core.Services.CurrencyService;
using CurrencyExchanger.CurrencyExchanger.Core.Services.Interfaces;
using System.Windows;

namespace CurrencyExchanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ICurrencyService currencyService = new CurrencyRestService();
            var test = currencyService.GetRates();
        }
    }
}
