using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostCalculation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExchangeRateUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tarih",
                table: "ExchangeRates",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ExchangeRates",
                newName: "Tarih");
        }
    }
}
