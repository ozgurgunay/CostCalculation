using CostCalculation.Entities;
using CostCalculation.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CostCalculation.Data
{
    public class Context : IdentityDbContext<AppUser, AppRole, string>
    {
        public Context(DbContextOptions<Context> options):base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Freight> Freights { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PalletCalculateViewModel>().HasNoKey();
        //}

        public DbSet<PalletCalculateViewModel> PalletCalculateViewModels { get; set; }
        public DbSet<ExchangeCalculateViewModel> ExchangeRatesViewModels { get; set;}

    }
    public class YourDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BL2GJU5\\MSSQLSERV;Initial Catalog=CostCalculateDB;Integrated Security=True;TrustServerCertificate=True");

            return new Context(optionsBuilder.Options);
        }
    }
}
