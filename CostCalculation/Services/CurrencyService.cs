using CostCalculation.DTOs;
using CostCalculation.Entities;
using CostCalculation.Repositories.Interfaces;
using CostCalculation.Services.IServices;
using CostCalculation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Globalization;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;

namespace CostCalculation.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;    //veri çekme işlemleri için
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public CurrencyService(HttpClient httpClient, IExchangeRateRepository exchangeRateRepository, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _exchangeRateRepository = exchangeRateRepository;
            _httpClientFactory = httpClientFactory;
        }
        public async Task StoreEuroCurrencyData()
        {
            try
            {
                string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
                string xmlData = await GetXmlDataAsync(url);
                var exchangeRate = ProcessXmlData(xmlData);

                if (exchangeRate != null)
                {
                    await _exchangeRateRepository.AddAsync(exchangeRate);
                }
                else
                {
                    throw new Exception("Döviz Kuru bilgisi bulunamadı!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CurrencyViewModel> GetCurrencyData()
        {
            try
            {
                var lastExchangeRate = await _exchangeRateRepository.GetLastExchangeRate();

                var currencyInfo = new CurrencyViewModel
                {
                    FormattedDate = lastExchangeRate?.Date.ToString(),
                    CurrencyName = lastExchangeRate?.CurrencyName,
                    FormattedBanknoteSelling = lastExchangeRate?.BanknoteSelling.ToString()
                };

                return currencyInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Döviz kuru alınamadı.", ex);
            }
        }
        private async Task<string> GetXmlDataAsync(string url)
        {
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                return await client.GetStringAsync(url);
            }
        }
        private ExchangeRate? ProcessXmlData(string xmlData)
        {
            XDocument doc = XDocument.Parse(xmlData);

            XElement? euroCurrency = doc.Descendants("Currency").FirstOrDefault(currency => currency.Attribute("Kod")?.Value == "EUR" && currency.Attribute("CurrencyCode")?.Value == "EUR");

            if (euroCurrency != null)
            {
                return new ExchangeRate
                {
                    Date = DateTime.ParseExact(doc.Root.Attribute("Tarih").Value, "dd.MM.yyyy", CultureInfo.InvariantCulture).Date,
                    CrossOrder = Convert.ToInt16(euroCurrency.Attribute("CrossOrder")?.Value),
                    Kod = euroCurrency.Attribute("Kod")?.Value,
                    CurrencyCode = euroCurrency.Attribute("CurrencyCode")?.Value,
                    UNIT = euroCurrency.Element("Unit")?.Value,
                    Isim = euroCurrency.Element("Isim")?.Value,
                    CurrencyName = euroCurrency.Element("CurrencyName")?.Value,
                    ForexBuying = Convert.ToDouble(euroCurrency.Element("ForexBuying")?.Value),
                    ForexSelling = Convert.ToDouble(euroCurrency.Element("ForexSelling")?.Value),
                    BanknoteBuying = Convert.ToDouble(euroCurrency.Element("BanknoteBuying")?.Value),
                    BanknoteSelling = Convert.ToDouble(euroCurrency.Element("BanknoteSelling")?.Value),
                };
            }
            return null;
        }
        

    }
}
