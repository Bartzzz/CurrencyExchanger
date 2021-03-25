using System.Collections.Generic;

namespace CurrencyExchanger.ViewModel
{
    public class MainWindowViewModel
    {
        public IList<Rate> Currencies { get; set; }
        public MainWindowViewModel()
        {
            Currencies = new List<Rate>();
        }
    }
}
