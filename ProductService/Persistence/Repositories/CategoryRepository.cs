using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Model;

namespace ProductService.Persistence.Repositories
{
    public class CategoryRepository
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        public void Insert(Category entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public ICollection<Category> ListAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }


        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
