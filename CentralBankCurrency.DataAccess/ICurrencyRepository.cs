using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CentralBankCurrency.DataAccess
{
    public interface ICurrencyRepository
    {
        public XElement GetCurrencyRates();
    }
}
