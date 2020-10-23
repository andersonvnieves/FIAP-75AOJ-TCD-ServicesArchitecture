using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentService.DTO
{
    public class IncidentDTO
    {
        public Guid OpenedBy { get; set; }
        public string Title { get; set; }
        public string ProblemDescription { get; set; }
        public Guid RelatedOrderId { get; set; }
        public Guid IncidentStatusId { get; set; }
    }
}
