# Get Currency List in Different Formats From TCMB in ASP.NET Core

## About

This article shows how to export xml and csv data in an ASP.NET Core application. 

REST architecture is used in this project, to improve the portability of the interface to other types of platforms, and to allow the different components of the developments to be evolved independently.

The OutputFormatter classes are used to convert the C# model classes to the csv data. The Currency class is used as the model class to export data. The exported data can be in various formats as json in default, xml or csv.

```csharp
namespace CentralBankCurrency.Models
{
    public class Currency: ICurrency
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }
    }
}
```

The MVC Controller CurrencyController  makes it possible to export the data. Clients can request a particular format as part of the URL by using a format-specific file extension such as .xml, .json or .csv. The route allows the requested format to be specified as an optional extension. The [FormatFilter] attribute checks for the existence of the format value in the RouteData and maps the response format to the appropriate formatter when the response is created.

```csharp
using System.Linq;
using CentralBankCurrency.Business;
using Microsoft.AspNetCore.Mvc;

namespace CentralBankCurrency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [FormatFilter]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        [HttpGet("{format?}")]
        public IActionResult GetCentralBankCurrency(string filterBy, string filterValue, string orderBy, string orderType)
        {
            var currencyRates = currencyService.GetCurrencyRates(filterBy, filterValue, orderBy, orderType).ToList();
            return Ok(currencyRates);
        }
    }
}

```

The raw XML data of TCMB currencies is taken and loaded into an XElement by the CurrencyRepository which is inherited from ICurrencyRepository interface.

```csharp
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
```

The GetCurrencyRates service takes the XElement from the repository, sorts and filters it according to the parameters and returns a Currency model list.

The SortCurrency and FilterCurrency services only do what their jobs are.

```csharp
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
                                   ForexBuying = currencies.Element("ForexBuying").Value, //döviz alýþ
                                   ForexSelling = currencies.Element("ForexSelling").Value, //döviz satýþ
                                   BanknoteBuying = currencies.Element("BanknoteBuying").Value, //efektif alýþ
                                   BanknoteSelling = currencies.Element("BanknoteSelling").Value //efektif satýþ
                               };

            return currencyList;
        }
```


The csv output formatter is implemented using the code from <a href="https://damienbod.com/2016/06/17/import-export-csv-in-asp-net-core/">Damien's web site</a> with some small changes. Thanks for this. This formatter uses ';' to separate the properties and a new line for each object.

If another format will be requested by the client, the output formatter class should be implemented to this solution.


```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace CsvFormatter
{
    /// <summary>
    /// Original code taken from
    /// https://damienbod.com/2016/06/17/import-export-csv-in-asp-net-core/
    /// Adapted for ASP.NET Core and uses ; instead of , for delimiters
    /// </summary>
    public class CsvOutputFormatter: OutputFormatter
    {
        private readonly CsvFormatterOptions csvOptions;
        public CsvOutputFormatter(CsvFormatterOptions csvFormatterOptions)
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            csvOptions = csvFormatterOptions ?? throw new ArgumentNullException(nameof(csvFormatterOptions));
        }

        protected override bool CanWriteType(Type type)
        {
            return true;
        }

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
            var streamWriter = new StreamWriter(response.Body, csvOptions.Encoding);
            foreach (var obj in (IEnumerable<object>)context.Object)
            {
                var values = obj.GetType().GetProperties().Select(x => new
                        {
                            Value = x.GetValue(obj, null)
                        });
                string valueLine = string.Empty;
                foreach (var val in values)
                {
                    if (val.Value != null)
                    {
                        var _val = val.Value.ToString();

                        //Escape quotas
                        _val = _val.Replace("\"", "\"\"");

                        //Check if the value contains a delimiter and place it in quotes if so
                        if (_val.Contains(csvOptions.CsvDelimiter))
                            _val = string.Concat("\"", _val, "\"");

                        //Replace any \r or \n special characters from a new line with a space
                        if (_val.Contains("\r"))
                            _val = _val.Replace("\r", " ");
                        if (_val.Contains("\n"))
                            _val = _val.Replace("\n", " ");

                        valueLine = string.Concat(valueLine, _val, csvOptions.CsvDelimiter);
                    }
                    else
                    {
                        valueLine = string.Concat(valueLine, string.Empty, csvOptions.CsvDelimiter);
                    }
                }
                await streamWriter.WriteLineAsync(valueLine.Remove(valueLine.Length - csvOptions.CsvDelimiter.Length));
            }
            await streamWriter.FlushAsync();
        }
    }
}

```

The custom formatters need to be added to the ConfigureServices, so that it knows how to handle media types 'text/csv'. XMLSerializerFormatters need to be added in order to be able to export xml format as well.


```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ICurrencyService, CurrencyService>();
    services.AddTransient<ICurrencyRepository, CurrencyRepository>();
    var csvFormatterOptions = new CsvFormatterOptions
    {
        CsvDelimiter = ";"
    };

    services.AddControllers();
    services.AddControllers().AddXmlSerializerFormatters();
    services.AddControllers(options =>
    {
        options.OutputFormatters.Add(new CsvOutputFormatter(csvFormatterOptions));
        options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));
    });
}
```

When any type is not specified in the URL, the type of the response will be json in default.
http://localhost:53365/api/currency/

```csharp
[
    {
        "name": "ABD DOLARI",
        "code": "USD",
        "forexBuying": "7.8412",
        "forexSelling": "7.8553",
        "banknoteBuying": "7.8357",
        "banknoteSelling": "7.8671"
    },
    {
        "name": "AVUSTRALYA DOLARI",
        "code": "AUD",
        "forexBuying": "5.7548",
        "forexSelling": "5.7924",
        "banknoteBuying": "5.7284",
        "banknoteSelling": "5.8271"
    }
]
```
When the json format is requested, the response will return like the preceding result.
http://localhost:53365/api/currency/json


When the xml format is requested, the response will be like below.
http://localhost:53365/api/currency/xml

```csharp
<ArrayOfCurrency xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Currency>
        <Name>ABD DOLARI</Name>
        <Code>USD</Code>
        <ForexBuying>7.8412</ForexBuying>
        <ForexSelling>7.8553</ForexSelling>
        <BanknoteBuying>7.8357</BanknoteBuying>
        <BanknoteSelling>7.8671</BanknoteSelling>
    </Currency>
    <Currency>
        <Name>AVUSTRALYA DOLARI</Name>
        <Code>AUD</Code>
        <ForexBuying>5.7548</ForexBuying>
        <ForexSelling>5.7924</ForexSelling>
        <BanknoteBuying>5.7284</BanknoteBuying>
        <BanknoteSelling>5.8271</BanknoteSelling>
    </Currency>
</ArrayOfCurrency>
```

When the csv format is given in the URL, the response will be given without header like below.
http://localhost:53365/api/currency/csv

```csharp

ABD DOLARI;USD;7.8412;7.8553;7.8357;7.8671
AVUSTRALYA DOLARI;AUD;5.7548;5.7924;5.7284;5.8271

```

When the orderType parameter is given, the result will be ordered according to the orderType.
http://localhost:53365/api/currency/json?orderBy=Isim&orderType=desc

```csharp
[
    {
        "name": "AVUSTRALYA DOLARI",
        "code": "AUD",
        "forexBuying": "5.7548",
        "forexSelling": "5.7924",
        "banknoteBuying": "5.7284",
        "banknoteSelling": "5.8271"
    },
    {
        "name": "ABD DOLARI",
        "code": "USD",
        "forexBuying": "7.8412",
        "forexSelling": "7.8553",
        "banknoteBuying": "7.8357",
        "banknoteSelling": "7.8671"
    }
]
```

When the filterBy parameter is given, the result will be filtered according to the filterValue.
http://localhost:53365/api/currency/json?filterBy=Isim&filterValue=AVUSTRALYA DOLARI

```csharp
[
    {
        "name": "AVUSTRALYA DOLARI",
        "code": "AUD",
        "forexBuying": "5.7548",
        "forexSelling": "5.7924",
        "banknoteBuying": "5.7284",
        "banknoteSelling": "5.8271"
    }
]
```

There is also a unit test project in this solution. In TestCurrencyRepository class there are some variable definitions that include xml strings and there are services which parse those variables into an XElement.

```csharp
		public static string usDollarCurrencyString = @"<Currency CrossOrder=""0"" Kod=""USD"" CurrencyCode=""USD"">
<Unit>1</Unit>
<Isim>ABD DOLARI</Isim>
<CurrencyName>US DOLLAR</CurrencyName>
<ForexBuying>7.7892</ForexBuying>
<ForexSelling>7.8032</ForexSelling>
<BanknoteBuying>7.7837</BanknoteBuying>
<BanknoteSelling>7.8149</BanknoteSelling>
<CrossRateUSD/>
<CrossRateOther/>
		
</Currency>";

		public static XElement GetUsDollarCurrencyString()
		{
			return XElement.Parse(usDollarCurrencyString);
		}
```

In UnitTestCurrencyService test class there are test methods defined. To execute the test method the only thing you need to do is clicking Run Test option after right clicking the name of the method or run the test by Test Explorer window.

```csharp
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
```

<strong>List of Installed Packages</strong>

https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Formatters.Xml/2.2.0

https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/3.1.4

https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Core/2.2.5

https://www.nuget.org/packages/Newtonsoft.Json/12.0.3


<strong>Links</strong>

https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-3.1

https://damienbod.com/2016/06/17/import-export-csv-in-asp-net-core/

https://docs.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement?view=net-5.0
