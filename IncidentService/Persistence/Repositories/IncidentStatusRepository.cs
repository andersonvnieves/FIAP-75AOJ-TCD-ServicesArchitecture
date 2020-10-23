using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentService.Model;
using Microsoft.EntityFrameworkCore;

namespace IncidentService.Persistence.Repositories
{
    public class IncidentStatusRepository
    {
        private readonly IncidentDbContext _context;
        private readonly DbSet<IncidentStatus> _dbSet;

        public IncidentStatusRepository(IncidentDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<IncidentStatus>();
        }

        public IncidentStatus Insert(IncidentStatus entity)
        {
            
            entity.IncidentStatusId = Guid.NewGuid();

            _dbSet.Add(entity);
            Save();
            return entity;
        }

        public ICollection<IncidentStatus> List()
        {
            return _dbSet.ToList();
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
