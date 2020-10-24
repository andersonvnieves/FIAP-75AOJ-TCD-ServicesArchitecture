using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShippingCostCalculator.Model;

namespace ShippingCostCalculator.Persistence.Repositories
{
    public class ShippingCompanyRepository
    {
        private readonly ShippingCostCalculatorDbContext _context;
        private readonly DbSet<ShippingCompany> _shippingCompanies;

        public ShippingCompanyRepository(ShippingCostCalculatorDbContext context)
        {
            _context = context;
            _shippingCompanies = _context.Set<ShippingCompany>();
        }

        public ShippingCompany Insert(string name)
        {
            var entity = new ShippingCompany()
            {
                ShippingCompanyId = Guid.NewGuid(),
                ShippingCompanyName = name
            };
            _shippingCompanies.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public ICollection<ShippingCompany> List()
        {
            return _shippingCompanies.ToList();
        }

    }
}
