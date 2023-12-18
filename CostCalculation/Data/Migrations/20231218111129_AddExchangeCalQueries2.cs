using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostCalculation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExchangeCalQueries2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TutarEuroFOB",
                table: "ExchangeRatesViewModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "TutarEuroCPT",
                table: "ExchangeRatesViewModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PaketEuroCPT",
                table: "ExchangeRatesViewModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "KgEuroCPT",
                table: "ExchangeRatesViewModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "KasaEuroCPT",
                table: "ExchangeRatesViewModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "FOBEuroKg",
                table: "ExchangeRatesViewModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "FOBEuroKasa",
                table: "ExchangeRatesViewModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "EuroKur",
                table: "ExchangeRatesViewModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "ExchangeRatesViewModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ExchangeRatesViewModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ExchangeRatesViewModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "ExchangeRatesViewModels");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ExchangeRatesViewModels");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ExchangeRatesViewModels");

            migrationBuilder.AlterColumn<decimal>(
                name: "TutarEuroFOB",
                table: "ExchangeRatesViewModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "TutarEuroCPT",
                table: "ExchangeRatesViewModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaketEuroCPT",
                table: "ExchangeRatesViewModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "KgEuroCPT",
                table: "ExchangeRatesViewModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "KasaEuroCPT",
                table: "ExchangeRatesViewModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "FOBEuroKg",
                table: "ExchangeRatesViewModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "FOBEuroKasa",
                table: "ExchangeRatesViewModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "EuroKur",
                table: "ExchangeRatesViewModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
