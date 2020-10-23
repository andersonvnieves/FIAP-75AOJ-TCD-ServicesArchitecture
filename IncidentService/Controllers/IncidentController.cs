using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentService.DTO;
using IncidentService.Model;
using IncidentService.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IncidentRepository _incidentRepository;
        public IncidentController(IncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }


        [HttpPost]
        public IActionResult Post(IncidentDTO dto)
        {
            var entity = new Incident()
            {
                CreatedAt = DateTime.Now,
                OpenedBy = dto.OpenedBy,
                Title = dto.Title,
                ProblemDescription = dto.ProblemDescription,
                RelatedOrderId = dto.RelatedOrderId,
                IncidentStatusId = dto.IncidentStatusId

            };

            var result =_incidentRepository.Insert(entity);
            return Created(result.IncidentId.ToString(), result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_incidentRepository.List());
        }

       
    }
}
