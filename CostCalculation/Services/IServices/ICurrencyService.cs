using CostCalculation.DTOs;

namespace CostCalculation.Services.IServices
{
    public interface ICurrencyService
    {
        Task<ExchangeCurrencyDTO> GetAndStoreEuroCurrencyData();
    }
}
