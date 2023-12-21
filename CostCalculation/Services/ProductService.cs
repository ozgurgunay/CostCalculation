using CostCalculation.Data;
using CostCalculation.DTOs;
using CostCalculation.Entities;
using CostCalculation.Repositories.Interfaces;
using CostCalculation.Services.IServices;
using CostCalculation.ValidationRules;
using CostCalculation.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CostCalculation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFreightRepository _foreightRepository;
        private readonly DbContextOptions<Context> _dbContextOptions;
        public ProductService(DbContextOptions<Context> dbContextOptions, IProductRepository productRepository, IFreightRepository foreightRepository)
        {
            _dbContextOptions = dbContextOptions;
            _productRepository = productRepository;
            _foreightRepository = foreightRepository;
        }
        public async Task<ResultViewModel> AddFreightAsync(FreightDTO freightDTO)
        {
            FreightValidation validationRules = new FreightValidation();
            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(freightDTO);
            if(!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return new ResultViewModel { IsSuccess = false, ErrorMessages = errorMessages };                
            }
            try
            {
                if(freightDTO?.FreightValue != null)
                {
                    Freight freight = new Freight
                    {
                        FreightValue = freightDTO.FreightValue,
                        BigPalletNumber = freightDTO.BigPalletNumber,
                        SmallPalletNumber = freightDTO.SmallPalletNumber,
                        Date = DateTime.Now
                    };
                    await _foreightRepository.AddAsync(freight);
                    return new ResultViewModel { IsSuccess = true };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { ex.Message + "Doldurduğunuz tüm alanları kontrol ediniz." } };
            }
            return new ResultViewModel { IsSuccess = false };
        }
        public async Task<ProductResultViewModel> AddProductAsync(ProductDTO productDTO)
        {
            ProductValidation validations = new ProductValidation();
            FluentValidation.Results.ValidationResult validationResult = validations.Validate(productDTO);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors
                   .Select(error => error.ErrorMessage)
                  .ToList();
                return new ProductResultViewModel { IsSuccess = false, ErrorMessages = errorMessages };
            }
            try
            {
                if (productDTO.ProductName != null)
                {
                    Product product = new Product
                    {
                        ProductName = productDTO.ProductName,
                        ProductDescription = productDTO.ProductDescription,
                        BoxNetKg = productDTO.BoxNetKg,
                        BoxBrossKg = productDTO.BoxBrossKg,
                        PalletBoxCount = productDTO.PalletBoxCount,
                        Pallet = productDTO.Pallet,
                        BagGr = productDTO.BagGr,
                        Price = productDTO.Price,
                        OutRate = productDTO.OutRate,
                        LaborCost = productDTO.LaborCost,
                        CreatedDate = DateTime.Now
                    };
                    await _productRepository.AddAsync(product);
                    //await _dbContextOptions.SaveChangesAsync();
                    return new ProductResultViewModel { IsSuccess = true };
                }
            }
            catch (Exception ex)
            {
                return new ProductResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { ex.Message + "Doldurduğunuz tüm alanları kontrol ediniz." } };
            }

            return new ProductResultViewModel { IsSuccess = false };
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }

            await _productRepository.DeleteAsync(product);
            return true;
        }
        public async Task<ResultViewModel> UpdateFreightAsync(FreightDTO freightDTO)
        {
            FreightValidation validations = new FreightValidation();
            FluentValidation.Results.ValidationResult validationResult = validations.Validate(freightDTO);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return new ResultViewModel { IsSuccess = false, ErrorMessages = errorMessages };
            }
            try
            {
                if (freightDTO?.FreightValue != null)
                {
                    Freight freight = new Freight
                    {
                        Id = freightDTO.FreightId.HasValue ? freightDTO.FreightId.Value : 0,
                        FreightValue = freightDTO.FreightValue,
                        BigPalletNumber = freightDTO.BigPalletNumber,
                        SmallPalletNumber = freightDTO.SmallPalletNumber                      
                    };

                    if (freight.Id == 0)
                    {
                        return new ResultViewModel { IsSuccess = false };
                    }
                    await _foreightRepository.UpdateAsync(freight);
                    return new ResultViewModel { IsSuccess = true };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { ex.Message + "Güncellediğiniz tüm alanları kontrol ediniz." } };
            }
            return new ResultViewModel { IsSuccess = false };
        }
        public async Task<ProductResultViewModel> UpdateProductAsync(ProductDTO productDTO)
        {
            ProductValidation validations = new ProductValidation();
            FluentValidation.Results.ValidationResult validationResult = validations.Validate(productDTO);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors
                    .Select(error => error.ErrorMessage)
                    .ToList();

                return new ProductResultViewModel { IsSuccess = false, ErrorMessages = errorMessages };
            }
            try
            {
                if (productDTO.ProductName != null)
                {
                    Product product = new Product
                    {
                        ProductId = productDTO.ProductId.HasValue ? productDTO.ProductId.Value : 0,
                        ProductName = productDTO.ProductName,
                        ProductDescription = productDTO.ProductDescription,
                        BoxNetKg = productDTO.BoxNetKg,
                        BoxBrossKg = productDTO.BoxBrossKg,
                        PalletBoxCount = productDTO.PalletBoxCount,
                        Pallet = productDTO.Pallet,
                        BagGr = productDTO.BagGr,
                        Price = productDTO.Price,
                        OutRate = productDTO.OutRate,
                        LaborCost = productDTO.LaborCost,
                        UpdateDate = DateTime.Now,
                        UpdateData = true
                    };

                    if (product.ProductId == 0)
                    {
                        return new ProductResultViewModel { IsSuccess = false };
                    }
                    await _productRepository.UpdateAsync(product);
                    return new ProductResultViewModel { IsSuccess = true };
                }
            }
            catch (Exception ex)
            {
                return new ProductResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { ex.Message + "Güncellediğiniz tüm alanları kontrol ediniz." } };
            }
            return new ProductResultViewModel { IsSuccess = false };
        }
        public async Task<ProductResultViewModel> UpdateProductPricesAsync(UpdateProductPricesDTO updateProductPricesDTO)
        {
            UpdateProductPricesValidation validations = new UpdateProductPricesValidation();
            FluentValidation.Results.ValidationResult validationResult = validations.Validate(updateProductPricesDTO);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return new ProductResultViewModel { IsSuccess = false, ErrorMessages = errorMessages };
            }
            try
            {
                int? productId = updateProductPricesDTO.ProductId;
                if (productId != null)
                {
                    Product? product = await _productRepository.GetByIdAsync(productId.Value);
                    if (product != null)
                    {
                        if (updateProductPricesDTO.Price < 0)
                        {
                            return new ProductResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { "Fiyat değeri 0'dan küçük olamaz!" } };
                        }
                        else
                        {
                            product.Price = updateProductPricesDTO.Price;
                        }
                        if (updateProductPricesDTO.OutRate < 0)
                        {
                            return new ProductResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { "Çıkma Oranı değeri 0'dan küçük olamaz!" } };
                        }
                        else
                        {
                            product.OutRate = updateProductPricesDTO.OutRate;
                            product.UpdateDate = DateTime.Now;
                            product.UpdateData = true;
                        }
                        if (product.ProductId == 0)
                        {
                            return new ProductResultViewModel { IsSuccess = false };
                        }
                        await _productRepository.UpdateAsync(product);
                        return new ProductResultViewModel { IsSuccess = true };
                    }
                    else
                    {
                        return new ProductResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { "Ürün bulunamadı." } };
                    }
                }
                else
                {
                    return new ProductResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { "ProductId null olamaz." } };
                }
            }
            catch (Exception ex)
            {
                return new ProductResultViewModel { IsSuccess = false, ErrorMessages = new List<string> { ex.Message + "Güncellediğiniz tüm alanları kontrol ediniz." } };
            }
        }


    }
}
