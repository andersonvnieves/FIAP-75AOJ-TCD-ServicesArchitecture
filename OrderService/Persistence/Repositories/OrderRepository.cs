using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Persistence.Repositories
{
    public class OrderRepository
    {
        private readonly OrderDbContext _context;
        private DbSet<Order> _dbSet;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Order>();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
