using CostCalculation.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CostCalculation.Data
{
    public class PalletCalculateQueries
    {
        private readonly Context _dbContext;
        public PalletCalculateQueries(DbContextOptions<Context> options)
        {
            _dbContext = new Context(options);
        }
        public List<PalletCalculateViewModel> GetPalletCalculateResults()
        {
            var query = _dbContext.PalletCalculateViewModels
            .FromSqlRaw(@"SELECT 
							p.ProductId AS ProductId,
							p.ProductName AS ProductName,
							p.ProductDescription AS ProductDescription,
							p.Price AS Price,
							p.OutRate AS OutRate,	
							p.PalletBoxCount * p.Pallet AS NumberOfBox,
							CAST((p.Pallet * (p.PalletBoxCount * p.BoxBrossKg)) AS DECIMAL(18, 2)) AS BrütKg,
							p.BoxBrossKg * p.PalletBoxCount AS PaletBrütKg,
							CAST((p.PalletBoxCount * p.Pallet * p.BoxNetKg) AS DECIMAL(18, 2)) AS NetKg,
							CAST((p.Price * p.PalletBoxCount * p.Pallet * p.BoxNetKg) AS DECIMAL(18, 2)) AS ProductPrice,
							CAST(ROUND(CASE
								WHEN DATEPART(MONTH, GETDATE()) IN (1,2,3,4) THEN p.Price * 0.45
								ELSE p.Price * 0.30 END,2) AS DECIMAL(18, 2)) AS SecondQualityPrice,
							CAST(ROUND(((p.PalletBoxCount * p.Pallet * p.BoxNetKg * 100 / (100 - p.OutRate) - (p.PalletBoxCount * p.Pallet * p.BoxNetKg )) * (p.Price - CASE WHEN DATEPART(MONTH, GETDATE()) IN (1,2,3,4) THEN p.Price * 0.45 ELSE p.Price * 0.30 END)),2) AS DECIMAL(18, 2)) AS SecondQualityCost,
							CAST((p.PalletBoxCount * p.Pallet * 27) AS DECIMAL(18, 2)) AS PackagingPriceTotal,
							CAST((p.LaborCost * (p.Pallet * (p.PalletBoxCount * p.BoxBrossKg) - 15)) AS DECIMAL(18, 2)) AS LaborCost,
							CAST(((0.03) * (p.Price * p.PalletBoxCount * p.Pallet * p.BoxNetKg)) AS DECIMAL(18, 2)) AS StoppagejCost,
							CAST(((p.Price * p.PalletBoxCount * p.Pallet * p.BoxNetKg) + 
							(p.PalletBoxCount * p.Pallet * p.BoxNetKg * 100 / (100 - p.OutRate) - (p.PalletBoxCount * p.Pallet * p.BoxNetKg )) * (p.Price - CASE WHEN DATEPART(MONTH, GETDATE()) IN (1,2,3,4) THEN p.Price * 0.45 ELSE p.Price * 0.30 END) + 
							(p.PalletBoxCount * p.Pallet * 27 ) + 
							(p.LaborCost * (p.Pallet * (p.PalletBoxCount * p.BoxBrossKg) - 15)) + 
							(0.03) * (p.Price * p.PalletBoxCount * p.Pallet * p.BoxNetKg)) AS DECIMAL(18, 2)) AS TotalCost,
							CASE 
								WHEN p.UpdateData < 1 THEN 'Güncelleme yapılmadı.' 
								ELSE CONVERT(NVARCHAR, p.UpdateDate, 104)
							END AS UpdateDate
						FROM Products AS p
                        ")
            .ToList();

            return query;
        }
    }
    //SecondQualityPrice ->> kışın %45 ile çarpma diğer aylarda %30
}
