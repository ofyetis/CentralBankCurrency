using CentralBankCurrency.Models;
using System.Collections.Generic;

namespace CentralBankCurrency.Business
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetCurrencyRates(string filterBy = null, string filterValue = null, string orderBy = null, string orderType = null);
    }
}
