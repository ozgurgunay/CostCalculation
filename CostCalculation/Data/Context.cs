using CostCalculation.Entities;
using CostCalculation.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CostCalculation.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Freight> Freights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalletCalculateViewModel>().HasNoKey();
        }

        public DbSet<PalletCalculateViewModel> PalletCalculateViewModels { get; set; }
        public DbSet<ExchangeCalculateViewModel> ExchangeRatesViewModels { get; set;}

    }
}
