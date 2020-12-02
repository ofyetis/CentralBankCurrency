using CentralBankCurrency.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace UnitTestCentralBankCurrency
{
    [TestClass]
    public class UnitTestCurrencyService
    {
        [TestMethod]
        public void FilterCurrency_NullGiven_ReturnsTrue()
        {
            //Arrange
            CurrencyService currencyService = new CurrencyService();

            var tcmbCurrency = TestCurrencyRepository.GetCurrencyRates();
            var currencyList = (from a in tcmbCurrency.Elements("Currency")
                                select a).ToList();

            //Act
            var result = currencyService.FilterCurrency(currencyList, null, null);
            var expectedResult = currencyList;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FilterCurrency_KodFilterGiven_ReturnsTrue()
        {
            //Arrange
            CurrencyService currencyService = new CurrencyService();

            var tcmbCurrency = TestCurrencyRepository.GetCurrencyRates();
            var currencyList = (from a in tcmbCurrency.Elements("Currency")
                                select a).ToList();

            //Act
            var result = currencyService.FilterCurrency(currencyList, "Kod", "USD");
            List<XElement> expectedResult = new List<XElement>();
            expectedResult.Add(TestCurrencyRepository.GetCodeFilteredCurrency());

            //Assert
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].ToString(), result[i].ToString());
            }
        }

        [TestMethod]
        public void FilterCurrency_KodFilterGiven_ReturnsFalse()
        {
            //Arrange
            CurrencyService currencyService = new CurrencyService();

            var tcmbCurrency = TestCurrencyRepository.GetCurrencyRates();
            var currencyList = (from a in tcmbCurrency.Elements("Currency")
                                select a).ToList();

            //Act
            var result = currencyService.FilterCurrency(currencyList, "Kod", "ttt");
            List<XElement> expectedResult = new List<XElement>();
            expectedResult.Add(TestCurrencyRepository.GetCodeFilteredCurrency());

            //Assert
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].ToString(), result[i].ToString());
            }
        }
        
        [TestMethod]
        public void SortCurrency_NullGiven_ReturnsTrue()
        {
            //Arrange
            CurrencyService currencyService = new CurrencyService();

            var tcmbCurrency = TestCurrencyRepository.GetCurrencyRates();
            var sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                select a).ToList();

            //Act
            var result = currencyService.SortCurrency(tcmbCurrency, null, null);
            var expectedResult = sortedCurrencyList;

            //Assert
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].ToString(), result[i].ToString());
            }
        }

        [TestMethod]
        public void SortCurrency_IsimAscendingGiven_ReturnsTrue()
        {
            //Arrange
            CurrencyService currencyService = new CurrencyService();

            var tcmbCurrency = TestCurrencyRepository.GetCurrencyRates3Item();
            var sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                      select a).ToList();

            //Act
            var result = currencyService.SortCurrency(tcmbCurrency, "Isim", "asc");
            List<XElement> expectedResult = new List<XElement>
            {
                TestCurrencyRepository.GetUsDollarCurrencyString(),
                TestCurrencyRepository.GetAustralianDollarCurrencyString(),
                TestCurrencyRepository.GetDanimarkaKronuCurrencyString()
            };

            //Assert
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].ToString(), result[i].ToString());
            }
        }

        [TestMethod]
        public void SortCurrency_IsimDescendingGiven_ReturnsTrue()
        {
            //Arrange
            CurrencyService currencyService = new CurrencyService();

            var tcmbCurrency = TestCurrencyRepository.GetCurrencyRates3Item();
            var sortedCurrencyList = (from a in tcmbCurrency.Elements("Currency")
                                      select a).ToList();

            //Act
            var result = currencyService.SortCurrency(tcmbCurrency, "Isim", "desc");
            List<XElement> expectedResult = new List<XElement>
            {
                TestCurrencyRepository.GetDanimarkaKronuCurrencyString(),
                TestCurrencyRepository.GetAustralianDollarCurrencyString(),
                TestCurrencyRepository.GetUsDollarCurrencyString()
            };

            //Assert
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].ToString(), result[i].ToString());
            }
        }

    }
}
