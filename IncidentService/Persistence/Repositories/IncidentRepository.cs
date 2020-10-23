using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using IncidentService.Model;
using Microsoft.EntityFrameworkCore;

namespace IncidentService.Persistence.Repositories
{
    public class IncidentRepository
    {
        private readonly IncidentDbContext _context;
        private readonly DbSet<Incident> _dbSet;

        public IncidentRepository(IncidentDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Incident>();
        }

        public Incident Insert(Incident entity)
        {
            entity.IncidentId = Guid.NewGuid();
            _dbSet.Add(entity);
            Save();
            return entity;
        }

        public ICollection<Incident> List()
        {
            return _dbSet.Include(i => i.IncidentStatus).ToList();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
