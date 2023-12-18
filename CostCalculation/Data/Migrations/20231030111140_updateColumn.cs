using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostCalculation.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalletCalculateViewModels",
                columns: table => new
                {
                    NumberOfBox = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrütKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ikincikalitefiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ikinciKaliteZararı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ambalajMalTop = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iscilikTop = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalletCalculateViewModels");
        }
    }
}
