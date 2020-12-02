using System.Xml.Linq;

namespace UnitTestCentralBankCurrency
{
	public class TestCurrencyRepository
    {
        public static XElement GetCurrencyRates()
        {
			return XElement.Parse(rawCurrencyXml);
		}

		public static XElement GetCodeFilteredCurrency()
		{
			return XElement.Parse(codeFilteredCurrency);
		}

		public static XElement GetCurrencyRates3Item()
		{
			return XElement.Parse(rawCurrencyXml3Item);
		}

		public static XElement GetUsDollarCurrencyString()
		{
			return XElement.Parse(usDollarCurrencyString);
		}

		public static XElement GetAustralianDollarCurrencyString()
		{
			return XElement.Parse(australianDollarCurrencyString);
		}

		public static XElement GetDanimarkaKronuCurrencyString()
		{
			return XElement.Parse(danimarkaKronuCurrencyString);
		}


		public static string rawCurrencyXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-stylesheet type=""text/xsl"" href=""isokur.xsl""?>
<Tarih_Date Tarih=""30.11.2020"" Date=""11/30/2020""  Bulten_No=""2020/227"" >
<Currency CrossOrder=""0"" Kod=""USD"" CurrencyCode=""USD"">
		<Unit>1</Unit>
		<Isim>ABD DOLARI</Isim>
		<CurrencyName>US DOLLAR</CurrencyName>
		<ForexBuying>7.7892</ForexBuying>
		<ForexSelling>7.8032</ForexSelling>
		<BanknoteBuying>7.7837</BanknoteBuying>
		<BanknoteSelling>7.8149</BanknoteSelling>
		<CrossRateUSD/>
		<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""1"" Kod=""AUD"" CurrencyCode=""AUD"">
		<Unit>1</Unit>
		<Isim>AVUSTRALYA DOLARI</Isim>
		<CurrencyName>AUSTRALIAN DOLLAR</CurrencyName>
		<ForexBuying>5.7366</ForexBuying>
		<ForexSelling>5.7740</ForexSelling>
		<BanknoteBuying>5.7102</BanknoteBuying>
		<BanknoteSelling>5.8087</BanknoteSelling>
			<CrossRateUSD>1.3546</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""2"" Kod=""DKK"" CurrencyCode=""DKK"">
		<Unit>1</Unit>
		<Isim>DANİMARKA KRONU</Isim>
		<CurrencyName>DANISH KRONE</CurrencyName>
		<ForexBuying>1.2519</ForexBuying>
		<ForexSelling>1.2580</ForexSelling>
		<BanknoteBuying>1.2510</BanknoteBuying>
		<BanknoteSelling>1.2609</BanknoteSelling>
			<CrossRateUSD>6.2124</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""9"" Kod=""EUR"" CurrencyCode=""EUR"">
		<Unit>1</Unit>
		<Isim>EURO</Isim>
		<CurrencyName>EURO</CurrencyName>
		<ForexBuying>9.3306</ForexBuying>
		<ForexSelling>9.3474</ForexSelling>
		<BanknoteBuying>9.3241</BanknoteBuying>
		<BanknoteSelling>9.3615</BanknoteSelling>
			<CrossRateUSD/>
			<CrossRateOther>1.1979</CrossRateOther>
		
</Currency>
<Currency CrossOrder=""10"" Kod=""GBP"" CurrencyCode=""GBP"">
		<Unit>1</Unit>
		<Isim>İNGİLİZ STERLİNİ</Isim>
		<CurrencyName>POUND STERLING</CurrencyName>
		<ForexBuying>10.3728</ForexBuying>
		<ForexSelling>10.4269</ForexSelling>
		<BanknoteBuying>10.3655</BanknoteBuying>
		<BanknoteSelling>10.4425</BanknoteSelling>
			<CrossRateUSD/>
			<CrossRateOther>1.3340</CrossRateOther>
		
</Currency>
<Currency CrossOrder=""3"" Kod=""CHF"" CurrencyCode=""CHF"">
		<Unit>1</Unit>
		<Isim>İSVİÇRE FRANGI</Isim>
		<CurrencyName>SWISS FRANK</CurrencyName>
		<ForexBuying>8.6062</ForexBuying>
		<ForexSelling>8.6614</ForexSelling>
		<BanknoteBuying>8.5933</BanknoteBuying>
		<BanknoteSelling>8.6744</BanknoteSelling>
			<CrossRateUSD>0.9030</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""4"" Kod=""SEK"" CurrencyCode=""SEK"">
		<Unit>1</Unit>
		<Isim>İSVEÇ KRONU</Isim>
		<CurrencyName>SWEDISH KRONA</CurrencyName>
		<ForexBuying>0.91539</ForexBuying>
		<ForexSelling>0.92486</ForexSelling>
		<BanknoteBuying>0.91475</BanknoteBuying>
		<BanknoteSelling>0.92699</BanknoteSelling>
			<CrossRateUSD>8.4730</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""6"" Kod=""CAD"" CurrencyCode=""CAD"">
		<Unit>1</Unit>
		<Isim>KANADA DOLARI</Isim>
		<CurrencyName>CANADIAN DOLLAR</CurrencyName>
		<ForexBuying>5.9953</ForexBuying>
		<ForexSelling>6.0224</ForexSelling>
		<BanknoteBuying>5.9731</BanknoteBuying>
		<BanknoteSelling>6.0453</BanknoteSelling>
			<CrossRateUSD>1.2975</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""11"" Kod=""KWD"" CurrencyCode=""KWD"">
		<Unit>1</Unit>
		<Isim>KUVEYT DİNARI</Isim>
		<CurrencyName>KUWAITI DINAR</CurrencyName>
		<ForexBuying>25.3452</ForexBuying>
		<ForexSelling>25.6769</ForexSelling>
		<BanknoteBuying>24.9651</BanknoteBuying>
		<BanknoteSelling>26.0620</BanknoteSelling>
			<CrossRateUSD/>
			<CrossRateOther>3.2723</CrossRateOther>
		
</Currency>
<Currency CrossOrder=""7"" Kod=""NOK"" CurrencyCode=""NOK"">
		<Unit>1</Unit>
		<Isim>NORVEÇ KRONU</Isim>
		<CurrencyName>NORWEGIAN KRONE</CurrencyName>
		<ForexBuying>0.88048</ForexBuying>
		<ForexSelling>0.88640</ForexSelling>
		<BanknoteBuying>0.87987</BanknoteBuying>
		<BanknoteSelling>0.88844</BanknoteSelling>
			<CrossRateUSD>8.8248</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""8"" Kod=""SAR"" CurrencyCode=""SAR"">
		<Unit>1</Unit>
		<Isim>SUUDİ ARABİSTAN RİYALİ</Isim>
		<CurrencyName>SAUDI RIYAL</CurrencyName>
		<ForexBuying>2.0769</ForexBuying>
		<ForexSelling>2.0806</ForexSelling>
		<BanknoteBuying>2.0613</BanknoteBuying>
		<BanknoteSelling>2.0962</BanknoteSelling>
			<CrossRateUSD>3.7505</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""5"" Kod=""JPY"" CurrencyCode=""JPY"">
		<Unit>100</Unit>
		<Isim>JAPON YENİ</Isim>
		<CurrencyName>JAPENESE YEN</CurrencyName>
		<ForexBuying>7.4682</ForexBuying>
		<ForexSelling>7.5177</ForexSelling>
		<BanknoteBuying>7.4406</BanknoteBuying>
		<BanknoteSelling>7.5463</BanknoteSelling>
			<CrossRateUSD>104.05</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""12"" Kod=""BGN"" CurrencyCode=""BGN"">
		<Unit>1</Unit>
		<Isim>BULGAR LEVASI</Isim>
		<CurrencyName>BULGARIAN LEV</CurrencyName>
		<ForexBuying>4.7436</ForexBuying>
		<ForexSelling>4.8057</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>1.6328</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""13"" Kod=""RON"" CurrencyCode=""RON"">
		<Unit>1</Unit>
		<Isim>RUMEN LEYİ</Isim>
		<CurrencyName>NEW LEU</CurrencyName>
		<ForexBuying>1.9037</ForexBuying>
		<ForexSelling>1.9286</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>4.0686</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""14"" Kod=""RUB"" CurrencyCode=""RUB"">
		<Unit>1</Unit>
		<Isim>RUS RUBLESİ</Isim>
		<CurrencyName>RUSSIAN ROUBLE</CurrencyName>
		<ForexBuying>0.10171</ForexBuying>
		<ForexSelling>0.10304</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>76.15</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""15"" Kod=""IRR"" CurrencyCode=""IRR"">
		<Unit>100</Unit>
		<Isim>İRAN RİYALİ</Isim>
		<CurrencyName>IRANIAN RIAL</CurrencyName>
		<ForexBuying>0.01844</ForexBuying>
		<ForexSelling>0.01868</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>42000</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""16"" Kod=""CNY"" CurrencyCode=""CNY"">
		<Unit>1</Unit>
		<Isim>ÇİN YUANI</Isim>
		<CurrencyName>CHINESE RENMINBI</CurrencyName>
		<ForexBuying>1.1771</ForexBuying>
		<ForexSelling>1.1925</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>6.5803</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""17"" Kod=""PKR"" CurrencyCode=""PKR"">
		<Unit>1</Unit>
		<Isim>PAKİSTAN RUPİSİ</Isim>
		<CurrencyName>PAKISTANI RUPEE</CurrencyName>
		<ForexBuying>0.04859</ForexBuying>
		<ForexSelling>0.04922</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>159.41</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""18"" Kod=""QAR"" CurrencyCode=""QAR"">
		<Unit>1</Unit>
		<Isim>KATAR RİYALİ</Isim>
		<CurrencyName>QATARI RIAL</CurrencyName>
		<ForexBuying>2.1271</ForexBuying>
		<ForexSelling>2.1549</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>3.6414</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""0"" Kod=""XDR"" CurrencyCode=""XDR"">
	<Unit>1</Unit>
	<Isim>ÖZEL ÇEKME HAKKI (SDR)                            </Isim>
	<CurrencyName>SPECIAL DRAWING RIGHT (SDR)                       </CurrencyName>
	<ForexBuying>11.1438</ForexBuying>
	<ForexSelling/>
	<BanknoteBuying/>
	<BanknoteSelling/>
	<CrossRateUSD/>
	<CrossRateOther>1.42939</CrossRateOther>
</Currency>
</Tarih_Date>";

		public static string rawCurrencyXml3Item = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-stylesheet type=""text/xsl"" href=""isokur.xsl""?>
<Tarih_Date Tarih=""30.11.2020"" Date=""11/30/2020""  Bulten_No=""2020/227"" >
<Currency CrossOrder=""0"" Kod=""USD"" CurrencyCode=""USD"">
		<Unit>1</Unit>
		<Isim>ABD DOLARI</Isim>
		<CurrencyName>US DOLLAR</CurrencyName>
		<ForexBuying>7.7892</ForexBuying>
		<ForexSelling>7.8032</ForexSelling>
		<BanknoteBuying>7.7837</BanknoteBuying>
		<BanknoteSelling>7.8149</BanknoteSelling>
		<CrossRateUSD/>
		<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""1"" Kod=""AUD"" CurrencyCode=""AUD"">
		<Unit>1</Unit>
		<Isim>AVUSTRALYA DOLARI</Isim>
		<CurrencyName>AUSTRALIAN DOLLAR</CurrencyName>
		<ForexBuying>5.7366</ForexBuying>
		<ForexSelling>5.7740</ForexSelling>
		<BanknoteBuying>5.7102</BanknoteBuying>
		<BanknoteSelling>5.8087</BanknoteSelling>
			<CrossRateUSD>1.3546</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""2"" Kod=""DKK"" CurrencyCode=""DKK"">
		<Unit>1</Unit>
		<Isim>DANİMARKA KRONU</Isim>
		<CurrencyName>DANISH KRONE</CurrencyName>
		<ForexBuying>1.2519</ForexBuying>
		<ForexSelling>1.2580</ForexSelling>
		<BanknoteBuying>1.2510</BanknoteBuying>
		<BanknoteSelling>1.2609</BanknoteSelling>
			<CrossRateUSD>6.2124</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
</Tarih_Date>";

		public static string currencyList = @"<Currency CrossOrder=""0"" Kod=""USD"" CurrencyCode=""USD"">
		<Unit>1</Unit>
		<Isim>ABD DOLARI</Isim>
		<CurrencyName>US DOLLAR</CurrencyName>
		<ForexBuying>7.7892</ForexBuying>
		<ForexSelling>7.8032</ForexSelling>
		<BanknoteBuying>7.7837</BanknoteBuying>
		<BanknoteSelling>7.8149</BanknoteSelling>
		<CrossRateUSD/>
		<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""1"" Kod=""AUD"" CurrencyCode=""AUD"">
		<Unit>1</Unit>
		<Isim>AVUSTRALYA DOLARI</Isim>
		<CurrencyName>AUSTRALIAN DOLLAR</CurrencyName>
		<ForexBuying>5.7366</ForexBuying>
		<ForexSelling>5.7740</ForexSelling>
		<BanknoteBuying>5.7102</BanknoteBuying>
		<BanknoteSelling>5.8087</BanknoteSelling>
			<CrossRateUSD>1.3546</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""2"" Kod=""DKK"" CurrencyCode=""DKK"">
		<Unit>1</Unit>
		<Isim>DANİMARKA KRONU</Isim>
		<CurrencyName>DANISH KRONE</CurrencyName>
		<ForexBuying>1.2519</ForexBuying>
		<ForexSelling>1.2580</ForexSelling>
		<BanknoteBuying>1.2510</BanknoteBuying>
		<BanknoteSelling>1.2609</BanknoteSelling>
			<CrossRateUSD>6.2124</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""9"" Kod=""EUR"" CurrencyCode=""EUR"">
		<Unit>1</Unit>
		<Isim>EURO</Isim>
		<CurrencyName>EURO</CurrencyName>
		<ForexBuying>9.3306</ForexBuying>
		<ForexSelling>9.3474</ForexSelling>
		<BanknoteBuying>9.3241</BanknoteBuying>
		<BanknoteSelling>9.3615</BanknoteSelling>
			<CrossRateUSD/>
			<CrossRateOther>1.1979</CrossRateOther>
		
</Currency>
<Currency CrossOrder=""10"" Kod=""GBP"" CurrencyCode=""GBP"">
		<Unit>1</Unit>
		<Isim>İNGİLİZ STERLİNİ</Isim>
		<CurrencyName>POUND STERLING</CurrencyName>
		<ForexBuying>10.3728</ForexBuying>
		<ForexSelling>10.4269</ForexSelling>
		<BanknoteBuying>10.3655</BanknoteBuying>
		<BanknoteSelling>10.4425</BanknoteSelling>
			<CrossRateUSD/>
			<CrossRateOther>1.3340</CrossRateOther>
		
</Currency>
<Currency CrossOrder=""3"" Kod=""CHF"" CurrencyCode=""CHF"">
		<Unit>1</Unit>
		<Isim>İSVİÇRE FRANGI</Isim>
		<CurrencyName>SWISS FRANK</CurrencyName>
		<ForexBuying>8.6062</ForexBuying>
		<ForexSelling>8.6614</ForexSelling>
		<BanknoteBuying>8.5933</BanknoteBuying>
		<BanknoteSelling>8.6744</BanknoteSelling>
			<CrossRateUSD>0.9030</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""4"" Kod=""SEK"" CurrencyCode=""SEK"">
		<Unit>1</Unit>
		<Isim>İSVEÇ KRONU</Isim>
		<CurrencyName>SWEDISH KRONA</CurrencyName>
		<ForexBuying>0.91539</ForexBuying>
		<ForexSelling>0.92486</ForexSelling>
		<BanknoteBuying>0.91475</BanknoteBuying>
		<BanknoteSelling>0.92699</BanknoteSelling>
			<CrossRateUSD>8.4730</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""6"" Kod=""CAD"" CurrencyCode=""CAD"">
		<Unit>1</Unit>
		<Isim>KANADA DOLARI</Isim>
		<CurrencyName>CANADIAN DOLLAR</CurrencyName>
		<ForexBuying>5.9953</ForexBuying>
		<ForexSelling>6.0224</ForexSelling>
		<BanknoteBuying>5.9731</BanknoteBuying>
		<BanknoteSelling>6.0453</BanknoteSelling>
			<CrossRateUSD>1.2975</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""11"" Kod=""KWD"" CurrencyCode=""KWD"">
		<Unit>1</Unit>
		<Isim>KUVEYT DİNARI</Isim>
		<CurrencyName>KUWAITI DINAR</CurrencyName>
		<ForexBuying>25.3452</ForexBuying>
		<ForexSelling>25.6769</ForexSelling>
		<BanknoteBuying>24.9651</BanknoteBuying>
		<BanknoteSelling>26.0620</BanknoteSelling>
			<CrossRateUSD/>
			<CrossRateOther>3.2723</CrossRateOther>
		
</Currency>
<Currency CrossOrder=""7"" Kod=""NOK"" CurrencyCode=""NOK"">
		<Unit>1</Unit>
		<Isim>NORVEÇ KRONU</Isim>
		<CurrencyName>NORWEGIAN KRONE</CurrencyName>
		<ForexBuying>0.88048</ForexBuying>
		<ForexSelling>0.88640</ForexSelling>
		<BanknoteBuying>0.87987</BanknoteBuying>
		<BanknoteSelling>0.88844</BanknoteSelling>
			<CrossRateUSD>8.8248</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""8"" Kod=""SAR"" CurrencyCode=""SAR"">
		<Unit>1</Unit>
		<Isim>SUUDİ ARABİSTAN RİYALİ</Isim>
		<CurrencyName>SAUDI RIYAL</CurrencyName>
		<ForexBuying>2.0769</ForexBuying>
		<ForexSelling>2.0806</ForexSelling>
		<BanknoteBuying>2.0613</BanknoteBuying>
		<BanknoteSelling>2.0962</BanknoteSelling>
			<CrossRateUSD>3.7505</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""5"" Kod=""JPY"" CurrencyCode=""JPY"">
		<Unit>100</Unit>
		<Isim>JAPON YENİ</Isim>
		<CurrencyName>JAPENESE YEN</CurrencyName>
		<ForexBuying>7.4682</ForexBuying>
		<ForexSelling>7.5177</ForexSelling>
		<BanknoteBuying>7.4406</BanknoteBuying>
		<BanknoteSelling>7.5463</BanknoteSelling>
			<CrossRateUSD>104.05</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""12"" Kod=""BGN"" CurrencyCode=""BGN"">
		<Unit>1</Unit>
		<Isim>BULGAR LEVASI</Isim>
		<CurrencyName>BULGARIAN LEV</CurrencyName>
		<ForexBuying>4.7436</ForexBuying>
		<ForexSelling>4.8057</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>1.6328</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""13"" Kod=""RON"" CurrencyCode=""RON"">
		<Unit>1</Unit>
		<Isim>RUMEN LEYİ</Isim>
		<CurrencyName>NEW LEU</CurrencyName>
		<ForexBuying>1.9037</ForexBuying>
		<ForexSelling>1.9286</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>4.0686</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""14"" Kod=""RUB"" CurrencyCode=""RUB"">
		<Unit>1</Unit>
		<Isim>RUS RUBLESİ</Isim>
		<CurrencyName>RUSSIAN ROUBLE</CurrencyName>
		<ForexBuying>0.10171</ForexBuying>
		<ForexSelling>0.10304</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>76.15</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""15"" Kod=""IRR"" CurrencyCode=""IRR"">
		<Unit>100</Unit>
		<Isim>İRAN RİYALİ</Isim>
		<CurrencyName>IRANIAN RIAL</CurrencyName>
		<ForexBuying>0.01844</ForexBuying>
		<ForexSelling>0.01868</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>42000</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""16"" Kod=""CNY"" CurrencyCode=""CNY"">
		<Unit>1</Unit>
		<Isim>ÇİN YUANI</Isim>
		<CurrencyName>CHINESE RENMINBI</CurrencyName>
		<ForexBuying>1.1771</ForexBuying>
		<ForexSelling>1.1925</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>6.5803</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""17"" Kod=""PKR"" CurrencyCode=""PKR"">
		<Unit>1</Unit>
		<Isim>PAKİSTAN RUPİSİ</Isim>
		<CurrencyName>PAKISTANI RUPEE</CurrencyName>
		<ForexBuying>0.04859</ForexBuying>
		<ForexSelling>0.04922</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>159.41</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""18"" Kod=""QAR"" CurrencyCode=""QAR"">
		<Unit>1</Unit>
		<Isim>KATAR RİYALİ</Isim>
		<CurrencyName>QATARI RIAL</CurrencyName>
		<ForexBuying>2.1271</ForexBuying>
		<ForexSelling>2.1549</ForexSelling>
		<BanknoteBuying></BanknoteBuying>
		<BanknoteSelling></BanknoteSelling>
			<CrossRateUSD>3.6414</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>
<Currency CrossOrder=""0"" Kod=""XDR"" CurrencyCode=""XDR"">
	<Unit>1</Unit>
	<Isim>ÖZEL ÇEKME HAKKI (SDR)                            </Isim>
	<CurrencyName>SPECIAL DRAWING RIGHT (SDR)                       </CurrencyName>
	<ForexBuying>11.1438</ForexBuying>
	<ForexSelling/>
	<BanknoteBuying/>
	<BanknoteSelling/>
	<CrossRateUSD/>
	<CrossRateOther>1.42939</CrossRateOther>
</Currency>";

		public static string codeFilteredCurrency = @"<Currency CrossOrder=""0"" Kod=""USD"" CurrencyCode=""USD"">
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

		public static string australianDollarCurrencyString = @"<Currency CrossOrder=""1"" Kod=""AUD"" CurrencyCode=""AUD"">
		<Unit>1</Unit>
		<Isim>AVUSTRALYA DOLARI</Isim>
		<CurrencyName>AUSTRALIAN DOLLAR</CurrencyName>
		<ForexBuying>5.7366</ForexBuying>
		<ForexSelling>5.7740</ForexSelling>
		<BanknoteBuying>5.7102</BanknoteBuying>
		<BanknoteSelling>5.8087</BanknoteSelling>
			<CrossRateUSD>1.3546</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>";

		public static string danimarkaKronuCurrencyString = @"<Currency CrossOrder=""2"" Kod=""DKK"" CurrencyCode=""DKK"">
		<Unit>1</Unit>
		<Isim>DANİMARKA KRONU</Isim>
		<CurrencyName>DANISH KRONE</CurrencyName>
		<ForexBuying>1.2519</ForexBuying>
		<ForexSelling>1.2580</ForexSelling>
		<BanknoteBuying>1.2510</BanknoteBuying>
		<BanknoteSelling>1.2609</BanknoteSelling>
			<CrossRateUSD>6.2124</CrossRateUSD>
			<CrossRateOther/>
		
</Currency>";
	}
}
