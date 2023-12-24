using CostCalculation.Data;
using CostCalculation.DTOs;
using CostCalculation.Entities;
using CostCalculation.Repositories.Interfaces;
using CostCalculation.Services.IServices;
using CostCalculation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CostCalculation.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        #region Variables

        private readonly IProductRepository _productRepository;
        private readonly IFreightRepository _foreightRepository;
        private readonly IProductService _productService;
        private readonly DbContextOptions<Context> _dbContextOptions;

        #endregion

        #region Constructor
        public ProductController(IProductRepository productRepository, DbContextOptions<Context> dbContextOptions, IProductService productService, IFreightRepository foreightRepository)
        {
            _productRepository = productRepository;
            _dbContextOptions = dbContextOptions;
            _productService = productService;
            _foreightRepository = foreightRepository;
        }
        #endregion
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var freightInfoList = await _foreightRepository.GetAllAsync();
            var productIndexPageViewModel = new ProductIndexPageViewModel
            {
                Products = products,
                FreightInfoList = freightInfoList,
            };
            return View(productIndexPageViewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ProductAdd([FromBody] ProductDTO productDTO)
        {
            #region oldies
            //ProductValidation validations = new ProductValidation();
            //FluentValidation.Results.ValidationResult validationResult = validations.Validate(productDTO);
            //bool isSuccess = false;

            //if (!validationResult.IsValid)
            //{
            //    var errorMessages = validationResult.Errors
            //        .Select(error => error.ErrorMessage)
            //        .ToList();

            //    return BadRequest(errorMessages);
            //}

            //try
            //{
            //    if (productDTO.ProductName != null)
            //    {
            //        Product product = new Product
            //        {
            //            ProductName = productDTO.ProductName,
            //            ProductDescription = productDTO.ProductDescription,
            //            BoxNetKg = productDTO.BoxNetKg,
            //            BoxBrossKg = productDTO.BoxBrossKg,
            //            PalletBoxCount = productDTO.PalletBoxCount,
            //            Pallet = productDTO.Pallet,
            //            BagGr = productDTO.BagGr,
            //            Price = productDTO.Price,
            //            OutRate = productDTO.OutRate,
            //            LaborCost = productDTO.LaborCost,
            //            CreatedDate = DateTime.Now
            //        };

            //        if (ModelState.IsValid)
            //        {
            //            await _productRepository.AddAsync(product);
            //            isSuccess = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message + "Doldurduğunuz tüm alanları kontrol ediniz." });
            //}

            //if (isSuccess)
            //{
            //    return Ok(isSuccess);
            //}
            //else
            //{
            //    return BadRequest(new { message = "Başarısız." });
            //}
            #endregion
            ProductResultViewModel result = await _productService.AddProductAsync(productDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct([FromBody] int id)
        {
            #region oldies
            //try
            //{
            //    var product = await _productRepository.GetByIdAsync(id);
            //    if (product == null)
            //    {
            //        return NotFound();
            //    }

            //    await _productRepository.DeleteAsync(product);
            //    return Ok(true);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, $"Internal server error: {ex.Message}");
            //}
            #endregion
            bool isSuccess = await _productService.DeleteProductAsync(id);
            if (isSuccess)
            {
                return Ok(true);
            }
            else 
            { 
                return NotFound();
            }
        }
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDTO)
        {
            #region
            //ProductValidation validations = new ProductValidation();
            //FluentValidation.Results.ValidationResult validationResult = validations.Validate(productDTO);
            //bool isSuccess = false;

            //if (!validationResult.IsValid)
            //{
            //    var errorMessages = validationResult.Errors
            //        .Select(error => error.ErrorMessage)
            //        .ToList();

            //    return BadRequest(errorMessages);
            //}
            //try
            //{
            //    if (productDTO.ProductName != null)
            //    {
            //        Product product = new Product
            //        {
            //            ProductId = productDTO.ProductId.HasValue ? productDTO.ProductId.Value : 0,
            //            ProductName = productDTO.ProductName,
            //            ProductDescription = productDTO.ProductDescription,
            //            BoxNetKg = productDTO.BoxNetKg,
            //            BoxBrossKg = productDTO.BoxBrossKg,
            //            PalletBoxCount = productDTO.PalletBoxCount,
            //            Pallet = productDTO.Pallet,
            //            BagGr = productDTO.BagGr,
            //            Price = productDTO.Price,
            //            OutRate = productDTO.OutRate,
            //            LaborCost = productDTO.LaborCost,
            //            UpdateDate = DateTime.Now,
            //            UpdateData = true
            //        };
            //        if (product.ProductId == 0)
            //        {
            //            isSuccess = false;

            //        }

            //        if (ModelState.IsValid)
            //        {
            //            await _productRepository.UpdateAsync(product);
            //            isSuccess = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message + "Güncellediğiniz tüm alanları kontrol ediniz." });
            //}

            //if (isSuccess)
            //{
            //    return Ok(isSuccess);
            //}
            //else
            //{
            //    return BadRequest(new { message = "Başarısız." });
            //}
            #endregion
            var result = await _productService.UpdateProductAsync(productDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessages);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductPrices([FromBody] UpdateProductPricesDTO updateProductPricesDTO)
        {
            #region
            //UpdateProductPricesValidation validations = new UpdateProductPricesValidation();
            //FluentValidation.Results.ValidationResult validationResult = validations.Validate(updateProductPricesDTO);
            //bool isSuccess = false;

            //if (!validationResult.IsValid)
            //{
            //    var errorMessages = validationResult.Errors
            //        .Select(error => error.ErrorMessage)
            //        .ToList();

            //    return BadRequest(errorMessages);
            //}
            //try
            //{
            //    int? productId = updateProductPricesDTO.ProductId;
            //    if (productId != null)
            //    {
            //        Product product = await _productRepository.GetByIdAsync(productId.Value);
            //        if (product != null)
            //        {
            //            if (updateProductPricesDTO.Price < 0)
            //            {
            //                return BadRequest(new { message = "Fiyat değeri 0'dan küçük olamaz!" });
            //            }
            //            else
            //            {
            //                product.Price = updateProductPricesDTO.Price;
            //            }
            //            if (updateProductPricesDTO.OutRate < 0)
            //            {
            //                return BadRequest(new { message = "Çıkma Oranı değeri 0'dan küçük olamaz!" });
            //            }
            //            else
            //            {
            //                product.OutRate = updateProductPricesDTO.OutRate;
            //                product.UpdateDate = DateTime.Now;
            //                product.UpdateData = true;
            //            }
            //            if (product.ProductId == 0)
            //            {
            //                isSuccess = false;
            //            }
            //            if (ModelState.IsValid)
            //            {
            //                await _productRepository.UpdateAsync(product);
            //                isSuccess = true;
            //            }
            //        }
            //        else
            //        {
            //            return BadRequest(new { message = "Ürün bulunamadı." });
            //        }
            //    }
            //    else
            //    {
            //        return BadRequest(new { message = "ProductId null olamaz." });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message + "Güncellediğiniz tüm alanları kontrol ediniz." });
            //}

            //if (isSuccess)
            //{
            //    return Ok(isSuccess);
            //}
            //else
            //{
            //    return BadRequest(new { message = "Başarısız." });
            //}
            #endregion

            var result = await _productService.UpdateProductPricesAsync(updateProductPricesDTO);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessages);
            }
        }
        [HttpGet]
        public IActionResult PalletCalculateList()
        {
            var palletCalculateQueries = new PalletCalculateQueries(_dbContextOptions);
            var result = palletCalculateQueries.GetPalletCalculateResults();
            return View(result);
        }
        [HttpGet]
        public IActionResult ExchangeCalculateList()
        {
            var exchangeCalculateQueries = new ExchangeCalculateQueries(_dbContextOptions);
            var result = exchangeCalculateQueries.GetExchangeCalculateResults();
            return View(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddFreight([FromBody]FreightDTO freightDTO)
        {
            ResultViewModel result = await _productService.AddFreightAsync(freightDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateFreight([FromBody]FreightDTO freightDTO)
        {
            ResultViewModel result = await _productService.UpdateFreightAsync(freightDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessages);
            }
        }
        public async Task<ActionResult<Freight>> GetFreight(int id)
        {
            var freight = await _foreightRepository.GetByIdAsync(id);
            if (freight == null)
            {
                return NotFound();
            }
            return Ok(freight);
        }
    }
}
