using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishListService.Model;

namespace WishListService.Persistence
{
    public class WishListDbContext : DbContext
    {
        public WishListDbContext()
        {

        }

        public WishListDbContext(DbContextOptions<WishListDbContext> options) : base(options)
        {

        }

        public DbSet<WishList> WishList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");
                entity.HasKey(c => c.WishListId).HasName("WishListId");
                entity.Property(p => p.WishListId).HasColumnName("WishListId");
                entity.Property(p => p.UserId).HasColumnName("UserId");
                entity.Property(p => p.ProductId).HasColumnName("ProductId");
            });
        }
    }
}