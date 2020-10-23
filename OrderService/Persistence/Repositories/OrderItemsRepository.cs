using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Persistence.Repositories
{
    public class OrderItemsRepository
    {
        private readonly OrderDbContext _context;
        private DbSet<OrderItems> _dbSet;

        public OrderItemsRepository(OrderDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<OrderItems>();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
