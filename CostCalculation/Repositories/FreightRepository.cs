using CostCalculation.Data;
using CostCalculation.Entities;
using CostCalculation.Repositories.Interfaces;

namespace CostCalculation.Repositories
{
    public class FreightRepository : GenericRepository<Freight>, IFreightRepository
    {
        public FreightRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
