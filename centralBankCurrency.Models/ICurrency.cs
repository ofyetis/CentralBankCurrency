using System;
using System.Collections.Generic;
using System.Text;

namespace CentralBankCurrency.Models
{
    public interface ICurrency
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ForexBuying { get; set; }
        public string ForexSelling { get; set; }
    }
}
