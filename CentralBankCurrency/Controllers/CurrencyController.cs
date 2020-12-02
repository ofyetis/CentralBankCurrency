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
