using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentService.Model;
using IncidentService.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentStatusController : ControllerBase
    {
        private readonly IncidentStatusRepository _incidentStatusRepository;
        public IncidentStatusController(IncidentStatusRepository incidentStatusRepository)
        {
            _incidentStatusRepository = incidentStatusRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_incidentStatusRepository.List());
        }

        [HttpPost]
        public IActionResult Post(string statusDescription)
        {
            var result = _incidentStatusRepository.Insert(new IncidentStatus()
            {
                Description = statusDescription
            });
            return Created(result.IncidentStatusId.ToString(),result);
        }
    }
}
