using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostCalculation.Data.Migrations
{
    /// <inheritdoc />
    public partial class BoxBrossKgAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmptyBoxKg",
                table: "Products",
                newName: "BoxBrossKg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BoxBrossKg",
                table: "Products",
                newName: "EmptyBoxKg");
        }
    }
}
