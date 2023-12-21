using CostCalculation.Entities;

namespace CostCalculation.Repositories.Interfaces
{
    public interface IExchangeRateRepository : IGenericRepository<ExchangeRate>
    {
        Task<ExchangeRate?> GetLastExchangeRate();
    }
}
