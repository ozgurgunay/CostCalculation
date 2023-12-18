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
    [Migration("20231004110038_changeProductTable")]
    partial class changeProductTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CostCalculation.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("BagGr")
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

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
