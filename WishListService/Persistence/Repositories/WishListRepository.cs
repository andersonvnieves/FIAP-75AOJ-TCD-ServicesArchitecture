using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishListService.Model;

namespace WishListService.Persistence.Repositories
{
    public class WishListRepository
    {
        private readonly WishListDbContext _context;
        private readonly DbSet<WishList> _dbSet;

        public WishListRepository(WishListDbContext context)
        {
            _context = context;
            _dbSet = context.Set<WishList>();
        }

        public void Insert(WishList entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public void Delete(WishList entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public ICollection<WishList> ListByUserId(Guid userId)
        {
            return _dbSet.Where(c => c.UserId.Equals(userId)).AsNoTracking().ToList();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
