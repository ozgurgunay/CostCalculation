using CostCalculation.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CostCalculation.Data
{
    public class ExchangeCalculateQueries
    {
        private readonly Context _dbContext;
        public ExchangeCalculateQueries(DbContextOptions<Context> options)
        {
            _dbContext = new Context(options);
        }

        public List<ExchangeCalculateViewModel> GetExchangeCalculateResults()
        {
            var query = _dbContext.ExchangeRatesViewModels
                .FromSqlRaw(@"SELECT
	                            p.ProductId AS ProductId,
	                            p.ProductName AS ProductName,
                                p.ProductDescription AS ProductDescription,
	                            CAST(ROUND(CASE WHEN pc.[Net Kg] = 0 THEN 0	ELSE ((pc.[Toplam Maliyet] / pc.[Net Kg]) / ER.BanknoteSelling) END,2) AS DECIMAL(18, 2)) AS FOBEuroKg,
	                            CAST(ROUND(CASE WHEN pc.[Kasa Sayısı] = 0 THEN 0 ELSE ((pc.[Toplam Maliyet] / pc.[Kasa Sayısı]) / ER.BanknoteSelling) END,2) AS DECIMAL(18, 2)) AS FOBEuroKasa,
	                            CAST(ROUND(CASE WHEN p.PalletBoxCount = 0 THEN 0 ELSE ((f.FreightValue / f.SmallPalletNumber) / p.PalletBoxCount) END,2) AS DECIMAL(18, 2)) AS KasaNakliyeBedeli,
	                            CAST(ROUND(CASE WHEN p.BoxNetKg = 0 OR p.PalletBoxCount = 0 THEN 0 ELSE (((f.FreightValue / f.SmallPalletNumber) / p.PalletBoxCount) / p.BoxNetKg) END,2) AS DECIMAL(18, 2)) AS KgNakliyeBedeli,
	                            CAST(ROUND(CASE WHEN pc.[Net Kg] = 0 OR p.PalletBoxCount = 0 OR p.BoxNetKg = 0 THEN 0 ELSE ((pc.[Toplam Maliyet] / pc.[Net Kg]) / ER.BanknoteSelling) + (((f.FreightValue / f.SmallPalletNumber) / p.PalletBoxCount) / p.BoxNetKg) END,2) AS DECIMAL(18, 2)) AS KgEuroCPT,
	                            CAST(ROUND(CASE WHEN pc.[Kasa Sayısı] = 0 OR p.PalletBoxCount = 0 THEN 0 ELSE (((pc.[Toplam Maliyet] / pc.[Kasa Sayısı]) / ER.BanknoteSelling) + ((f.FreightValue / f.SmallPalletNumber) / p.PalletBoxCount)) END,2) AS DECIMAL(18, 2)) AS KasaEuroCPT,
	                            CAST(ROUND(CASE WHEN pc.[Net Kg] = 0 OR p.PalletBoxCount = 0 OR p.BoxNetKg = 0 THEN 0 ELSE (((pc.[Toplam Maliyet] / pc.[Net Kg]) / ER.BanknoteSelling) + (((f.FreightValue / f.SmallPalletNumber) / p.PalletBoxCount) / p.BoxNetKg)) * p.BagGr END,2) AS DECIMAL(18, 2)) AS PaketEuroCPT,
	                            CAST(ROUND(CASE WHEN pc.[Net Kg] = 0 THEN 0 ELSE ((pc.[Toplam Maliyet] / pc.[Net Kg]) / ER.BanknoteSelling) * pc.[Net Kg] END,2) AS DECIMAL(18, 2)) AS TutarEuroFOB, 
	                            CAST(ROUND(CASE WHEN pc.[Net Kg] = 0 OR p.PalletBoxCount = 0 OR p.BoxNetKg = 0 THEN 0 ELSE ((((pc.[Toplam Maliyet] / pc.[Net Kg]) / ER.BanknoteSelling) + (((f.FreightValue / f.SmallPalletNumber) / p.PalletBoxCount) / p.BoxNetKg)) * pc.[Net Kg]) END,2) AS DECIMAL(18, 2)) AS TutarEuroCPT,		
                                ER.BanknoteSelling AS EuroKur,
	                            f.FreightValue AS Navlun,
	                            CAST(ROUND(f.FreightValue / f.BigPalletNumber,2) AS DECIMAL(18, 2)) AS BPalNavlun,
	                            CAST(ROUND(f.FreightValue / f.SmallPalletNumber,2) AS DECIMAL(18, 2)) AS KPalNavlun
                            FROM PalletCalculate pc
                            JOIN Products p ON pc.[Ürün Id] = p.ProductId
                            CROSS JOIN (SELECT TOP (1) * FROM ExchangeRates ORDER BY Id DESC) er
                            CROSS JOIN (SELECT TOP (1) * FROM Freights ORDER BY Id DESC) f
                            ")
                .ToList();

            return query;
        }

    }
}
