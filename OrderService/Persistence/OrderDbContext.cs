using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Persistence
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItemses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
    }
}
