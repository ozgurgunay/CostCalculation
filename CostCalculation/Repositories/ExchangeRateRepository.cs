using CostCalculation.Data;
using CostCalculation.Entities;
using CostCalculation.Repositories.Interfaces;

namespace CostCalculation.Repositories
{
    public class ExchangeRateRepository : GenericRepository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
