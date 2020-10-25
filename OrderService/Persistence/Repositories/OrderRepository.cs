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

        public Order GetById(Guid orderId)
        {
            return _dbSet.Where(c => c.OrderId == orderId).FirstOrDefault();
        }

        public Order GetStatusByOrderId(Guid orderId)
        {
            return _dbSet.Include(i => i.OrderStatus).Where(c => c.OrderId == orderId).FirstOrDefault();
        }

        public Order Insert(Order entity)
        {
            entity.OrderId = Guid.NewGuid();
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;

        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
