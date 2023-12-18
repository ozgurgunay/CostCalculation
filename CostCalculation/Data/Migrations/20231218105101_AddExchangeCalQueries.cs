using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostCalculation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExchangeCalQueries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRatesViewModels",
                columns: table => new
                {
                    FOBEuroKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FOBEuroKasa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KasaNakliyeBedeli = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KgNakliyeBedeli = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KgEuroCPT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KasaEuroCPT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaketEuroCPT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TutarEuroFOB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TutarEuroCPT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EuroKur = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Navlun = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BPalNavlun = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KPalNavlun = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRatesViewModels");
        }
    }
}
