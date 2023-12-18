using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostCalculation.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PalletCalculateViewModels");

            migrationBuilder.AddColumn<string>(
                name: "UpdateDate",
                table: "PalletCalculateViewModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CrossOrder = table.Column<short>(type: "smallint", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForexBuying = table.Column<double>(type: "float", nullable: false),
                    ForexSelling = table.Column<double>(type: "float", nullable: false),
                    BanknoteBuying = table.Column<double>(type: "float", nullable: false),
                    BanknoteSelling = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "PalletCalculateViewModels");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PalletCalculateViewModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
