﻿// <auto-generated />
using System;
using CostCalculation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CostCalculation.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231108184348_AddExchangeRateTable")]
    partial class AddExchangeRateTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CostCalculation.Entities.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BanknoteBuying")
                        .HasColumnType("float");

                    b.Property<double>("BanknoteSelling")
                        .HasColumnType("float");

                    b.Property<short>("CrossOrder")
                        .HasColumnType("smallint");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ForexBuying")
                        .HasColumnType("float");

                    b.Property<double>("ForexSelling")
                        .HasColumnType("float");

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("UNIT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("CostCalculation.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("BagGr")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("BoxBrossKg")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("BoxNetKg")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeleteData")
                        .HasColumnType("bit");

                    b.Property<decimal>("LaborCost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("OutRate")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Pallet")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("PalletBoxCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UpdateData")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CostCalculation.ViewModel.PalletCalculateViewModel", b =>
                {
                    b.Property<decimal>("BrütKg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LaborCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetKg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NumberOfBox")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OutRate")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("PackagingPriceTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PaletBrütKg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SecondQualityCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SecondQualityPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StoppagejCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UpdateDate")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("PalletCalculateViewModels");
                });
#pragma warning restore 612, 618
        }
    }
}