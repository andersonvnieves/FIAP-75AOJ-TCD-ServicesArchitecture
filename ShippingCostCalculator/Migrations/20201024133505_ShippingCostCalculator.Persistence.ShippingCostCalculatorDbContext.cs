using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShippingCostCalculator.Migrations
{
    public partial class ShippingCostCalculatorPersistenceShippingCostCalculatorDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippingCompanies",
                columns: table => new
                {
                    ShippingCompanyId = table.Column<Guid>(nullable: false),
                    ShippingCompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCompanies", x => x.ShippingCompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingCompanies");
        }
    }
}
