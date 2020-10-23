using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Persistence.Repositories
{
    public class ShippingAddressRepository
    {
        private readonly OrderDbContext _context;
        private DbSet<ShippingAddress> _dbSet;

        public ShippingAddressRepository(OrderDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ShippingAddress>();
        }



        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
