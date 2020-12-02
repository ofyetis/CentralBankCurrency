using CentralBankCurrency.DataAccess;
using CentralBankCurrency.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CentralBankCurrency.Business
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyRepository currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        /// <summary>
        /// It gets currencies from central bank, sorts and filters according to the parameters.
        /// </summary>
        /// <param name="filterBy"></param>
        /// <param name="filterValue"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public IEnumerable<Currency> GetCurrencyRates(string filterBy, string filterValue, string orderBy, string orderType)
        {
            var tcmbCurrency = currencyRepository.GetCurrencyRates();

            var sortedCurrencyList = SortCurrency(tcmbCurrency, orderBy, orderType);

            var filteredCurrencyList = FilterCurrency(sortedCurrencyList, filterBy, filterValue);

            var currencyList = from currencies in filteredCurrencyList
                               select new Currency()
                               {
                                   Name = currencies.Element("Isim").Value,
                                   Code = currencies.Attribute("Kod").Value,
                                   ForexBuying = currencies.Element("ForexBuying").Value, //döviz alış
                                   ForexSelling = currencies.Element("ForexSelling").Value, //döviz satış
                                   BanknoteBuying = currencies.Element("BanknoteBuying").Value, //efektif alış
                                   BanknoteSelling = currencies.Element("BanknoteSelling").Value //efektif satış
                               };

            return currencyList;
        }

        /// <summary>
        /// It takes XElement as parameter, sorts it according to the other parameters and returns the result as List.
        /// </summary>
        /// <param name="tcmbCurrency"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public List<XElement> SortCurrency(XElement tcmbCurrency, string orderBy, string orderType)
        {
            List<XElement> sortedCurrencyList = new List<XElement>();

            if (orderBy != null)
            {
                switch (orderBy)
                {
                    case "Isim":
                        if (orderType != null && orderType == "desc")
                        {
                            sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                                  let orderElement = (string)a.Element(orderBy)
                                                  orderby orderElement descending
                                                  select a).ToList();
                        }
                        else
                        {
                            sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                                  let orderElement = (string)a.Element(orderBy)
                                                  orderby orderElement ascending
                                                  select a).ToList();
                        }
                        break;
                    case "Kod":
                        if (orderType != null && orderType == "desc")
                        {
                            sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                                  let orderElement = (string)a.Attribute(orderBy)
                                                  orderby orderElement descending
                                                  select a).ToList();
                        }
                        else
                        {
                            sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                                  let orderElement = (string)a.Attribute(orderBy)
                                                  orderby orderElement ascending
                                                  select a).ToList();
                        }
                        break;
                    case "ForexBuying":
                    case "ForexSelling":
                    case "BanknoteBuying":
                    case "BanknoteSelling":
                        if (orderType != null && orderType == "desc")
                        {
                            sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                                  let orderElement = (decimal)a.Element(orderBy)
                                                  orderby orderElement descending
                                                  select a).ToList();
                        }
                        else
                        {
                            sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                                  let orderElement = (decimal)a.Element(orderBy)
                                                  orderby orderElement ascending
                                                  select a).ToList();
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                      select a).ToList();
            };
            return sortedCurrencyList;
        }

        /// <summary>
        /// It filters the List of XElement according to the parameters.
        /// </summary>
        /// <param name="sortedCurrencyList"></param>
        /// <param name="filterBy"></param>
        /// <param name="filterValue"></param>
        /// <returns></returns>
        public List<XElement> FilterCurrency(List<XElement> sortedCurrencyList, string filterBy, string filterValue)
        {
            if (filterBy != null)
            {
                if (filterBy == "Kod")
                {
                    sortedCurrencyList = (from b in sortedCurrencyList
                                          where (string)b.Attribute(filterBy) == filterValue
                                          select b).ToList();
                }
                else
                {
                    sortedCurrencyList = (from b in sortedCurrencyList
                                          where (string)b.Element(filterBy) == filterValue
                                          select b).ToList();
                }
            };
            return sortedCurrencyList;
        }

    }
}
