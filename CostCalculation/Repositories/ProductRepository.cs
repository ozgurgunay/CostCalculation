using CostCalculation.Data;
using CostCalculation.DTOs;
using CostCalculation.Entities;
using CostCalculation.Repositories.Interfaces;
using CostCalculation.ValidationRules;
using CostCalculation.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace CostCalculation.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(Context dbContext) : base(dbContext)
        {
        }

    }
}
