﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingCostCalculator.Persistence;

namespace ShippingCostCalculator.Migrations
{
    [DbContext(typeof(ShippingCostCalculatorDbContext))]
    partial class ShippingCostCalculatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShippingCostCalculator.Model.ShippingCompany", b =>
                {
                    b.Property<Guid>("ShippingCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ShippingCompanyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ShippingCompanyId");

                    b.ToTable("ShippingCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
