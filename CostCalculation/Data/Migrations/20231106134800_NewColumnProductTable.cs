using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostCalculation.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "iscilikTop",
                table: "PalletCalculateViewModels",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "ikincikalitefiyat",
                table: "PalletCalculateViewModels",
                newName: "StoppagejCost");

            migrationBuilder.RenameColumn(
                name: "ikinciKaliteZararı",
                table: "PalletCalculateViewModels",
                newName: "SecondQualityPrice");

            migrationBuilder.RenameColumn(
                name: "ambalajMalTop",
                table: "PalletCalculateViewModels",
                newName: "SecondQualityCost");

            migrationBuilder.AddColumn<bool>(
                name: "UpdateData",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PalletCalculateViewModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "LaborCost",
                table: "PalletCalculateViewModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OutRate",
                table: "PalletCalculateViewModels",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PackagingPriceTotal",
                table: "PalletCalculateViewModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PaletBrütKg",
                table: "PalletCalculateViewModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PalletCalculateViewModels",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "PalletCalculateViewModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PalletCalculateViewModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "PalletCalculateViewModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateData",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PalletCalculateViewModels");

            migrationBuilder.DropColumn(
                name: "LaborCost",
                table: "PalletCalculateViewModels");

            migrationBuilder.DropColumn(
                name: "OutRate",
                table: "PalletCalculateViewModels");

            migrationBuilder.DropColumn(
                name: "PackagingPriceTotal",
                table: "PalletCalculateViewModels");

            migrationBuilder.DropColumn(
                name: "PaletBrütKg",
                table: "PalletCalculateViewModels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PalletCalculateViewModels");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "PalletCalculateViewModels");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PalletCalculateViewModels");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "PalletCalculateViewModels");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "PalletCalculateViewModels",
                newName: "iscilikTop");

            migrationBuilder.RenameColumn(
                name: "StoppagejCost",
                table: "PalletCalculateViewModels",
                newName: "ikincikalitefiyat");

            migrationBuilder.RenameColumn(
                name: "SecondQualityPrice",
                table: "PalletCalculateViewModels",
                newName: "ikinciKaliteZararı");

            migrationBuilder.RenameColumn(
                name: "SecondQualityCost",
                table: "PalletCalculateViewModels",
                newName: "ambalajMalTop");
        }
    }
}
