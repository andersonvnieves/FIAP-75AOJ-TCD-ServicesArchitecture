using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Model;

namespace ProductService.Persistence.Repositories
{
    public class KeyWordRepository
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<KeyWord> _dbSet;

        public KeyWordRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<KeyWord>();
        }

        public KeyWord Insert(KeyWord entity)
        {
            entity.KeyWordId = Guid.NewGuid();
            _dbSet.Add(entity);
            Save();
            return entity;
        }

        public KeyWord KeyWordByName(string name)
        {
            return _dbSet.Where(c => c.Name.ToLower().Equals(name.Trim().ToLower())).FirstOrDefault();
        }


        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
