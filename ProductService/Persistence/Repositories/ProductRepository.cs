using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Model;

namespace ProductService.Persistence.Repositories
{
    public class ProductRepository
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public void Insert(Product entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public void Update(Product entity)
        {
            _dbSet.Update(entity);
            Save();
        }

        public Product ProductById(Guid productId)
        {
            return _dbSet.Where(c => c.ProductId.Equals(productId)).Include("Category").First();
        }

        public ICollection<Product> ProductsByCategoryId(Guid categoryId)
        {
            return _dbSet.Where(c => c.CategoryId.Equals(categoryId)).AsNoTracking().ToList();
        }

        public ICollection<Product> ProductsByKeyWord(string keyWord)
        {
            return _dbSet.Where(c => c.KeyWords.Any(s => s.Name.ToLower().Contains(keyWord.Trim().ToLower()))).AsNoTracking().ToList();
        }

        public ICollection<Product> MostViewsdByCategoryId(Guid categoryId)
        {

            return _dbSet.Where(c => c.CategoryId.Equals(categoryId)).OrderByDescending(o => o.Views).AsNoTracking().ToList();
        }


        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
