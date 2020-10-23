using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentService.Model
{
    public class IncidentStatus
    {
        public Guid IncidentStatusId { get; set; }
        public string Description { get; set; }
    }
}
