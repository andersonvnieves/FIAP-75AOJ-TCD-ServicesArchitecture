using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Persistence.Repositories
{
    public class OrderStatusRepository
    {
        private readonly OrderDbContext _context;
        private DbSet<OrderStatus> _dbSet;

        public OrderStatusRepository(OrderDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<OrderStatus>();
        }

        public OrderStatus Insert(string status)
        {
            var entity = new OrderStatus()
            {
                OrderStatusId = Guid.NewGuid(),
                StatusName = status
            };

            _dbSet.Add(entity);
            Save();

            return entity;
        }

        public OrderStatus GetStatusById(Guid statusId)
        {
            return _dbSet.Where(c => c.OrderStatusId.Equals(statusId)).FirstOrDefault();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
