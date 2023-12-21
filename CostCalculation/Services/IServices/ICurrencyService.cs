using CostCalculation.DTOs;
using CostCalculation.ViewModels;

namespace CostCalculation.Services.IServices
{
    public interface ICurrencyService
    {
        Task StoreEuroCurrencyData();
        Task<CurrencyViewModel> GetCurrencyData();
    }
}
