using CostCalculation.DTOs;
using CostCalculation.ViewModel;

namespace CostCalculation.Services.IServices
{
    public interface IProductService
    {
        Task<ProductResultViewModel> AddProductAsync(ProductDTO productDTO);
        Task<bool> DeleteProductAsync(int id);
        Task<ProductResultViewModel> UpdateProductAsync(ProductDTO productDTO);
        Task<ProductResultViewModel> UpdateProductPricesAsync(UpdateProductPricesDTO updateProductPricesDTO);
        Task<ResultViewModel> AddFreightAsync(FreightDTO freightDTO);
        Task<ResultViewModel> UpdateFreightAsync(FreightDTO fightDTO);
    }
}
