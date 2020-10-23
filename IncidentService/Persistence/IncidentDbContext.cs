using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentService.Model;
using Microsoft.EntityFrameworkCore;

namespace IncidentService.Persistence
{
    public class IncidentDbContext : DbContext
    {
        public IncidentDbContext(DbContextOptions<IncidentDbContext> options) : base(options)
        {

        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentStatus> IncidentStatuses { get; set; }
    }
}