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
