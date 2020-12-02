using System.ComponentModel;

namespace CentralBankCurrency.Models
{
    public enum Fields
    {
        [Description("Isim")]
        Isim = 1,
        [Description("Kod")]
        Kod = 2,
        [Description("ForexBuying")]
        DovizAlis = 3,
        [Description("ForexSelling")]
        DovizSatis = 4,
        [Description("BanknoteBuying")]
        EfektifAlis = 5,
        [Description("BanknoteSelling")]
        EfektifSatis = 6
    }
}
