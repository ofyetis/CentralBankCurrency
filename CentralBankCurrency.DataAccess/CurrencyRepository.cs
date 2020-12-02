using System.Xml.Linq;

namespace CentralBankCurrency.DataAccess
{
    public class CurrencyRepository: ICurrencyRepository
    {
        public XElement GetCurrencyRates()
        {
            return XElement.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
