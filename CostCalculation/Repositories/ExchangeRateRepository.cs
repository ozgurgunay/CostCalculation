using CostCalculation.Data;
using CostCalculation.Entities;
using CostCalculation.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CostCalculation.Repositories
{
    public class ExchangeRateRepository : GenericRepository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(Context dbContext) : base(dbContext)
        {
        }

        public async Task<ExchangeRate?> GetLastExchangeRate()
        {
            try
            {
                var lastExchangeRate = await _dbContext.ExchangeRates
                    .OrderByDescending(rate => rate.Id)
                    .FirstOrDefaultAsync();

                return lastExchangeRate;
            }
            catch (Exception ex)
            {
                throw new Exception("Son döviz kuru alınamadı.", ex);
            }
        }

    }
}
