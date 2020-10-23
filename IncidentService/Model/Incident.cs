using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentService.Model
{
    public class Incident
    {
        public Guid IncidentId { get; set; }
        public Guid OpenedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public string Title { get; set; }
        public string ProblemDescription { get; set; }
        public Guid RelatedOrderId { get; set; }
        public string Resolution { get; set; }
        public Guid IncidentStatusId { get; set; }        
        public IncidentStatus IncidentStatus { get; set; }
    }
}
