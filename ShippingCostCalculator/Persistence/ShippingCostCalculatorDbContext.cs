using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShippingCostCalculator.Model;

namespace ShippingCostCalculator.Persistence
{
    public class ShippingCostCalculatorDbContext : DbContext
    {
        public ShippingCostCalculatorDbContext(DbContextOptions<ShippingCostCalculatorDbContext> options) : base(options)
        {

        }


        public DbSet<ShippingCompany> ShippingCompanies { get; set; }
    }
}
